let pageConfig = {
    pageSize: 5,
    pageIndex: 1
}
let contactController = {
    init: function () {
        contactController.loadData();
        contactController.registerEvent();
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
            contactController.delete(id);

        });

        $('.btnDetail').off('click').on('click', function () {
            var id = $(this).data('id');
            console.log(id);
            contactController.getDetail(id);
            $('#FeedbackModal').modal('show');
        });
        $('#btnReset').on('click', function () {
            $('#txtSearch').val('');
            $('#statusSearch').val('');
            contactController.loadData();
        });

        $('#btnSearch').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                contactController.loadData(true);
            }
        });
    },

    loadData: function (changePageSize) {
        let stt = $('#statusSearch').val();
        let nameSearch = $('#txtSearch').val();
        $.ajax({
            url: '/contact/loadData',
            type: 'GET',
            data: {
                keyword: nameSearch,
                pageIndex: pageConfig.pageIndex,
                pageSize: pageConfig.pageSize
            },
            dataType: 'json',
            success: function (res) {
                console.log(res.data);
                console.log(res.data.items);
                if (res.status) {
                    var data = res.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data.items, function (i, item) {
                       
                        html += Mustache.render(template, {
                            ID: item.id,
                            Name: item.name,
                            Email: item.email,
                            PhoneNumber: item.phoneNumber,
                            Message: item.message,
                            Status: item.status == true ? "<span class=\"badge badge-success\">Đã phãn hồi</span>" : "<span class=\"badge badge-danger\">Chưa phản hồi</span>"
                        })
                    });
                    $('#tblData').html(html);
                    contactController.paging(res.data.totalRecords, function () {
                        contactController.loadData();
                    }, changePageSize);
                    contactController.registerEvent();
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
            url: '/Contact/getDetail',
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
                    $('#txtName').val(data.name);
                    $('#txtEmail').val(data.email);
                    $('#txtPhoneNumber').val(data.phoneNumber);
                    $('#txtMessage').val(data.message);
                    contactController.registerEvent();
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
                    url: '/Contact/DeleteFeedback',
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
                            contactController.loadData(true);
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
contactController.init();