var CartController = function () {
    this.init = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        //$('body').on('click', '.btn-plus', function (e) {
        //    e.preventDefault(); //ngan hanh dong default cua the a vd href='#';
        //    const culture = $('#hidCulture').val();
        //    const id = $(this).data('id');
        //    const quantity = parseInt( $('#txtQuantity' + id).val())+1;
        //     $.ajax({
        //        type: 'POST',
        //        url: '/' + culture + '/Cart/UpdateCart',
        //        dataType: 'json',
        //        data: {
        //            id: id,
        //            quantity: quantity
        //        },
        //        success: function (res) {
        //            console.log(res);
        //            if (res) {
        //                //$('#txtQuantity' + id).val(quantity);
        //                $('#numberItem-header').text(res.length);
        //                loadData();
        //            }
        //        }, error: function (res) {
        //            console.log("lỗi", res);
        //        }

        //    });
        //});

        $('body').on('click', '.btn-plus', function (e) {
            e.preventDefault(); //ngan hanh dong default cua the a vd href='#';
            const culture = $('#hidCulture').val();
            const id = $(this).data('id');
            const quantity = parseInt($('#txtQuantity' + id).val()) + 1;
            updateCart(id, quantity);
        });

        $('body').on('click', '.btn-minus', function (e) {
            e.preventDefault(); //ngan hanh dong default cua the a vd href='#';
            const culture = $('#hidCulture').val();
            const id = $(this).data('id');
            const quantity = parseInt($('#txtQuantity' + id).val()) - 1;
            updateCart(id, quantity);
        });

        $('body').on('click', '.btn-remove', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            updateCart(id, 0);
        });
    }

    function updateCart(id,quantity) {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: 'POST',
            url: '/' + culture + '/Cart/UpdateCart',
            dataType: 'json',
            data: {
                id: id,
                quantity: quantity
            },
            success: function (res) {
                console.log(res);
                if (res) {
                    //$('#txtQuantity' + id).val(quantity);
                    $('#numberItem-header').text(res.length);
                    loadData();
                }
            }, error: function (res) {
                console.log("lỗi", res);
            }

        });
    }

    function loadData() {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: 'GET',
            url: '/' + culture + '/Cart/GetListCartItem/',
            success: function (res) {
                if (res) {
                    if (res.length === 0) {
                        $('#tblCart').hide();
                    }
                    var html = '';
                    var total = 0;
                    $.each(res, function (i, item) {
                        totalPrice = item.price * item.quantity;
                        html += "<tr>"
                            + "<td> <img width=\"60\" src=\"" + $('#hidBaseAddress').val()+ item.image + "\" alt=\"\" /></td>" //1.xoa cach khoang trang 2.xuong dong dung dau(+) 3."+thuoc tinh+" vao cho can gen
                            + "<td>" + item.name + "</td>"
                            + "<td><div class=\"input-append\"><input class=\"span1\" style=\"max-width:34px\" placeholder=\"1\" id=\"txtQuantity" + item.productId + "\" value=\"" + item.quantity + "\" size=\"16\" type=\"text\">"
                            + "<button class=\"btn btn-minus\" data-id=\"" + item.productId + "\" type=\"button\"><i class=\"icon-minus\"></i></button>"
                            + "<button class=\"btn btn-plus\" data-id=\"" + item.productId + "\" type=\"button\"><i class=\"icon-plus\"></i></button>"
                            + "<button class=\"btn btn-danger btn-remove\" data-id=\"" + item.productId + "\" type=\"button\"><i class=\"icon-remove icon-white\"></i></button>"
                            + "</div>"
                            + "</td>"
                            + "<td>" +numberWithCommas(item.price) + "</td>"
                            + "<td>" + numberWithCommas(totalPrice) + "</td>"
                            + "</tr>";
                        total += totalPrice;
                    });
                    $('#cart-body').html(html); 
                    $('#numberItem').text(res.length); 
                    $('#tbl-total').text(numberWithCommas(total));
                    $('#tbl-total-sideBar').text(numberWithCommas(total));
                    
                }
            }, error: function (res) {
                console.log("lỗi", res);
            }

        });
    }
    function numberWithCommas(x) {
        return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    } 
}
