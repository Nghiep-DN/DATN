let pageConfig = {
    pageSize: 5,
    pageIndex: 1
}
let slideController = {
    init: function () {
        slideController.loadData();
        slideController.registerEvent();
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
            slideController.delete(id);

        });

        $('.btnDetail').off('click').on('click', function () {
            var id = $(this).data('id');
            slideController.getDetail(id);
            $('#SlideModal').modal('show');
        });
        $('#btnAddNew').off('click').on('click', function () {
            $('#SlideModal').modal('show');
        });
        $('#btnReset').on('click', function () {
            $('#txtSearch').val('');
            $('#statusSearch').val('');
            slideController.loadData();
        });

        //$('#btnSearch').off('keypress').on('keypress', function (e) {
        //    if (e.which == 13) {
        //        slideController.loadData(true);
        //    }
        //});
        //$('#btnSave').on('click', function () {
        //    if ($('#frmValid').valid()) {
        //        slideController.saveData();

        //        $('#SlideModal').modal('hide');

        //    }
        //    slideController.resetModal();
        //});
    },
    resetModal() {
        $('#hidID').val('');
        $('#txtName').val('');
        $('#txtDescription').val('');
        $('#txtImage').val('');
        $('#txtSortOrder').val('');
    },
    loadData: function (changePageSize) {
        let stt = $('#statusSearch').val();
        let nameSearch = $('#txtSearch').val();
        $.ajax({
            url: '/slide/loadData',
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
                            Description: item.description,
                            Image: item.image,
                            SortOrder: item.sortOrder,
                            //Status: item.status == true ? "<span class=\"badge badge-success\">Đã phãn hồi</span>" : "<span class=\"badge badge-danger\">Chưa phản hồi</span>"
                        })
                    });
                    $('#tblData').html(html);
                    slideController.paging(res.data.totalRecords, function () {
                        slideController.loadData();
                    }, changePageSize);
                    slideController.registerEvent();
                }
            }

        });
    },
    //saveData: function () {
    //    let formFile = new FormData();

    //    let id = $('#hidID').val();
    //    //console.log('id', id);

    //    let name = $('#txtName').val();
    //    let description = $('#txtDescription').val();
    //    let hidImage = $('#hidImage').val();
    //    let imageName = $('input[type=file]')[0].files[0];
    //    let sortOrder = $('#txtSortOrder').val();
   

    //    formFile.append('ID', id)
    //    formFile.append('Name', name)
    //    formFile.append('Description', description)
    //    formFile.append('SortOrder', sortOrder)
    //    formFile.append('Status', $('#contentStatus').prop('checked'))

    //    //console.log("imageName",imageName);
    //   // console.log('hid: ', hidImage);
    //    formFile.append('file', imageName)
    //     console.log($('input[type=file]')[0].files[0])
    //    if (imageName == undefined) {
    //        formFile.append('Image', hidImage)
    //    }
    //    else {
    //        formFile.append('file', imageName)
    //    }
    //    $.ajax({
    //        url: '/Slide/create',
    //        type: 'POST',
    //        dataType: 'json',
    //        contentType: false,
    //        processData: false,
    //        enctype: 'multipart/form-data',
    //        data: formFile,
    //        success: function (res) {
    //            console.log(res);
    //            if (res) {
    //                toastr.success("Chúc mừng!","Tạo mới slide thành công.");
    //                $('#SlideModal').modal('hide');
    //                $('#txtImage').val('');
    //                slideController.loadData(true);
    //            }
    //        },
    //        error: function (err) {
    //            console.error(err);
    //        }
    //    });
    //},
    formatDate: function (todayTime) {
        var day = todayTime.getDate();
        var month = todayTime.getMonth() + 1;
        var year = todayTime.getFullYear();
        return day + "/" + month + "/" + year;
    },
    getDetail: function (id) {
        $.ajax({
            url: '/Slide/getDetail',
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
                    $('#txtImage').val(data.image);
                    $('#txtDescription').val(data.description);
                    $('#txtSortOrder').val(data.sortOrder);
                  
                    slideController.registerEvent();
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
                    url: '/Slide/Delete',
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
                            slideController.loadData(true);
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
slideController.init();