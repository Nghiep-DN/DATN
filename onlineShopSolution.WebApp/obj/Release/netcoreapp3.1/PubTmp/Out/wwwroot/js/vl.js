var SiteController = function () {
    this.init = function () {
        registerEvent();
        loadCart();
    }
    function loadCart() {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: 'GET',
            url: '/' + culture + '/Cart/GetListCartItem/',
            success: function (res) {
                if (res) {
                 
                    $('#numberItem-header').text(res.length);
                    $('#numberItem-sideBar').text(res.length);
                }
            }, error: function (res) {
                console.log("lỗi", res);
            }

        });
    }
    function registerEvent() {
        $('body').on('click', '.btn-add-cart', function (e) {
            e.preventDefault(); //ngan hanh dong default cua the a vd href='#';
            const id = $(this).data('id');
            const culture = $('#hidCulture').val();

            $.ajax({
                type: 'POST',
                url: '/' + culture + '/cart/addToCart',
               // dataType: 'json',
                data: {
                    id: id,
                    languageId: culture
                },
                success: function (res) {
                    console.log(res);
                    if (res) {
                        $('#numberItem-header').text(res.length);
                        toastr.success('Thêm vào giỏ hàng thành công!', 'Xin cảm ơn <3');
                     
                    }
                }, error: function (res) {
                    console.log("lỗi", res);
                }

            });
        });
    }
}


//function numberWithCommas(x) {
//    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
//} 