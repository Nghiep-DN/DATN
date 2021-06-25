let pageConfig = {
    pageSize: 5,
    pageIndex: 1
}
let orderController = {
    init: function () {
        orderController.loadData();
        orderController.registerEvent();
    },
    registerEvent: function () {
        //validate
        $('#frmValid').validate({
            rules: { //required,minlength,maxlength,datetime...
                contentName: {
                    required: true,
                    minlength: 3
                }
            },
            messages: {//thong bao
                contentName: {
                    required: 'Tên không được để trống.',
                    minlength: "Tên phải dài hơn 3 ký tự."
                }
            }
        });

        $('.btnDelete').off('click').on('click', function () {
            var id = $(this).data('id');
            //console.log('-> id', id);
            orderController.delete(id);

        });

        $('.btnDetail').off('click').on('click', function () {
            var id = $(this).data('id');
            console.log(id);
            orderController.getDetail(id);
            $('#OrderModal').modal('show');
        });
        $('#btnReset').on('click', function () {
            $('#txtSearch').val('');
            $('#statusSearch').val('');
            orderController.loadData();
        });

        $('#btnSearch').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                orderController.loadData(true);
            }
        });

    },

    loadData: function (changePageSize) {
        let stt = $('#statusSearch').val();
        let nameSearch = $('#txtSearch').val();
        $.ajax({
            url: '/order/loadData',
            type: 'GET',
            data: {
                keyword: nameSearch,
                pageIndex: pageConfig.pageIndex,
                pageSize: pageConfig.pageSize
            },
            dataType: 'json',
            success: function (res) {
                
                //console.log(res.data);
                //console.log(res.data.items);
                if (res.status) {
                    var data = res.data;
                   // let crdate = orderController.formatDate(new Date(parseInt(data.orderDate)));
                   // console.log(crdate);
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data.items, function (i, item) {
                       
                        html += Mustache.render(template, {
                            ID: item.id,
                            ShipName: item.shipName,
                            ShipEmail: item.shipEmail,
                            ShipPhoneNumber: item.shipPhoneNumber,
                            ShipAddress: item.shipAddress,
                            OrderDate: item.orderDate,
                            Status: item.status == true ? "<span class=\"badge badge-success\">Đã phãn hồi</span>" : "<span class=\"badge badge-danger\">Chưa phản hồi</span>"
                        })
                    });
                    $('#tblData').html(html);
                    orderController.paging(res.data.totalRecords, function () {
                        orderController.loadData();
                    }, changePageSize);
                    orderController.registerEvent();
                }
            }

        });
    },
    formatDate: function (todayTime) {
        var day = todayTime.getDate();
        var month = todayTime.getMonth() + 1;
        var year = todayTime.getFullYear();
        return day + "/" + month + "/" + year;
    },
    getDetail: function (id) {
        $.ajax({
            url: '/order/getDetail',
            type: 'GET',
            dataType: 'json',
            data: {
                id: id
            },
            success: function (res) {
                console.log("detail->", res)
                if (res.status == true) {
                    var data = res.data;
                    $('#hidID').val(data.id);
                    $('#txtName').val(data.shipName);
                    $('#txtEmail').val(data.shipEmail);
                    $('#txtPhoneNumber').val(data.shipPhoneNumber);
                    $('#txtAddress').val(data.shipAddress);
                    $('#txtOrderDate').val( data.orderDate);
                    $('#selectStatus option:selected').text();
                    orderController.registerEvent();
                } else {
                    toastr.error(res.Message);
                }

            },
            error: function (err) {
                console.log(err)
            }
        });

    },
    delete: function (id) {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((res) => {
            if (res.value) {

                $.ajax({
                    url: '/order/Delete',
                    type: 'POST',
                    dataType: 'json',
                    data: {
                        id: id
                    },
                    success: function (res) {
                        console.log('dele: ',res.dataId)
                        if (res.status == 200) {
                            Swal.fire(
                                'Deleted!',
                                'Your file has been deleted.',
                                'success')
                            orderController.loadData(true);
                        }

                    },
                    error: function (err) {
                        console.log(err)
                    }
                });
            }
            else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Cancelled',
                    'Your file is safe :))',
                    'error'
                )
            }
        })

    },
    paging: function (totalRecords, callback, changePageSize) {

        var totalPage = Math.ceil(totalRecords / pageConfig.pageSize);
        if ($('#pagination a').length === 0 || changePageSize === true) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind("page");
        }
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            visiblePages: 10,
            first: "Đầu",
            next: "Tiếp",
            last: "Cuối",
            prev:"Trước",
            onPageClick: function (event, page) {
                pageConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });

    }
}
orderController.init();