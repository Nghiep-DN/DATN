let pageConfig = {
    pageSize: 3,
    pageIndex: 1
}
let category = {
    init: function () {
        category.loadData();
        category.registerEvent();
    },
    registerEvent: function () {
      


        $("#checkAll").click(function () {
            $('input:checkbox').not(this).prop('checked', this.checked);
        });

        $('#btnAddNew').on('click', function () {
            category.resetModal();
            $('#categoryModal').modal('show');
        });

        $('#btnEdit').on('click', function () {
            // hiển thị form chi tiết
            // lấy dữ liệu tương ứng 
               // lưu ý: lấy trên service (vì trên client hiển thị 1 số trường thôi, )
               //1.xác định các row được chọn
            var trSelected = $('input[type="checkbox"].i-checks:checked');
           
            if (trSelected.length > 0) {
                var id = trSelected.data('id');
                category.getDetail(id);
                $('#categoryModal').modal('show');
            } else {
                toastr.error("Vui lòng chọn một danh mục.", "lỗi");
            }
           

               //2.lấy các mã cần xóa
               //3.gọi api service lấy dl tương ứng với mã vừa chọn 
            // binding các tt lên form
            // chỉnh sửa dl trên form
            // thực hiện lưu dl

            
        });

        $('#btnSave').on('click', function () {
            //validate
            $('#frmValid').validate({
                rules: { //required,minlength,maxlength,datetime...
                    "txtName": {
                        required: true,
                        minlength: 3
                    }
                },
                messages: {
                    "txtName": {
                        required: 'Tên không được để trống.',
                        minlength: "Tên phải dài hơn 3 ký tự."
                    }
                }
            });
            //category.checkRequired();
            category.saveData();
            $('#categoryModal').modal('hide');
            category.resetModal();
        });

        $('#btnDelete').on('click', function () {
            var lstTrSelected=[];
            var trSelected = $('#tblcategory input[type="checkbox"].i-checks:checked');
            if (trSelected.length > 0) {
                trSelected.each(function () {
                    lstTrSelected.push(trSelected);
                    console.log('ok > 0', length, trSelected.data('id'));
                    var id = trSelected.data('id');
                    category.delete(id);
                });
            } else {
                toastr.error("Vui lòng chọn thông tin cần xóa.","Lỗi.")
            }
            console.log('-> lst ', lstTrSelected);
            console.log('-> trSelected ', trSelected);
        });
    },
    getDetail(id) {
        $.ajax({
            url: '/category/getdetail/',
            dataType: 'JSON',
            data: { id:id },
            type: 'GET',
            success: function (res) {
                console.log('detail=>',res);
                if (res.status == 200) {
                    var data = res.data;
                    $('#hidID').val(data.id);
                    $('#txtName').val(data.name);
                    $('#txtSeoAlias').val(data.seoAlias);
                    $('#txtSeoDescription').val(data.seoDescription);
                    $('#txtSeoTitle').val(data.seoTitle);

                }
                else {
                    toastr.error(res.message);
                }
            }


        }).fail(function (res) {
            toastr.error("Error");
        });
    },
    resetModal() {
        $('#hidID').val('');
        $('#txtName').val('');
        $('#txtSeoDescription').val('');
        $('#txtSeoAlias').val('');
        $('#txtSeoTitle').val('');
    },
    loadData() {
        $.ajax({
            url: 'https://localhost:5001/api/categories/getAll?languageId=vi',
            method: 'GET',
            success: function (res) {
            },
            fail: function (res) {
                console.log("fail.");
            }
        }).done(function (res) {
            $('.card-body tbody tr').empty();
            $.each(res, function (index, item) {
                var dt = $(`<tr>
                <td><input type="checkbox" data-id="` + item.id + `"  class="i-checks"></td>
                <td>`+ item.id + `</td>
                <td>`+ item.name + `</td>
                <td>`+ item.seoAlias + `</td>
                <td>`+ item.seoDescription + `</td>
                <td>`+ item.seoTitle + `</td>
               
            
                </tr>`)
                $('.card-body tbody').append(dt);
            })
                // <td>`+ item.isShowOnHome + `</td>
               // < td > <input type="button" value="Chi tiết" class="btn btn-success" id="btnDetailCategory" />   </td >
            category.paging(res.total, function () {
                category.loadData();
            }, changePageSize);
            category.registerEvent();
            //auto chọn tk đầu :)))))
            //$('#tblcategory tbody tr').first().addClass('row-selected');
            //$('input[name="locationthemes"]:checked')
        })
    },
    saveData:function() {
        //cach2: check tất cả các trường có Required
        //var inputRequireds = $("[required]");
        //var isValid = true;
        //$.each(inputRequireds, function (index, input) {
        //    var valid = $(input).trigger("blur");
        //    if (isValid && valid.hasClass("required-error")) {
        //        isValid = false;
        //    }
        //})
    //    if (isValid) {
            //thu thap thong tin tren form
        var request = {};
            request.id = $('#hidID').val();
            request.name = $('#txtName').val();
            request.seoDescription = $('#txtSeoDescription').val();
            request.seoAlias = $('#txtSeoAlias').val();
            request.seoTitle = $('#txtSeoTitle').val();
            $.ajax({

                url: '/category/savedata/',
                method: 'POST',
                dataType: 'JSON',
                data: request,
                success(res) {
                    if (res.status == 201) {
                        toastr.success(res.message);
                        category.loadData();
                    } else if (res.status == 200) {
                        toastr.success(res.message);
                        category.loadData();
                    }
                    else {
                        toastr.error(res.Message, 'Error!');
                    }
                }
            }).done(function (res) {
                console.log("add=>", res);
               
            }).fail(function (res) {

                toastr.error(res.Message, 'Error!');
            });
            //this.loadData();
            //this.hideDialogDetail();

      //  }
    },
    //checkRequired() {
    //    //lay gia tri kieu js
    //    //var val = this.value;
    //    //if (!val) {
    //    //    $(this).addClass('required-error');
    //    //    $(this).attr('title', 'Vui lòng nhập đầy đủ thông tin!');
    //    //} else {
    //    //    $(this).removeClass('required-error');
    //    //    $(this).removeAttr('title');
    //    //}

    //    //validate
    //    $('#frmValid').validate({
    //        rules: { //required,minlength,maxlength,datetime...
    //            "txtName": {
    //                required: true,
    //                minlength: 3
    //            }
    //        },
    //        messages: {
    //            "txtName": {
    //                required: 'Tên không được để trống.',
    //                minlength: "Tên phải dài hơn 3 ký tự."
    //            }
    //        }
    //    });

    //},
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
                    url: '/Category/Delete',
                    type: 'DELETE',
                    dataType: 'json',
                    data: {
                        id: id
                    },
                    success: function (res) {
                        console.log(res);
                        if (res.status == 200) {
                            Swal.fire(
                                'Deleted!',
                                'Your file has been deleted.',
                                'success')
                            category.loadData();
                        }
                    }
                }).fail(function (res) {
                    toastr.error("Error");
                });
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {

        var totalPage = Math.ceil(totalRow / pageConfig.pageSize);
        if ($('#pagination a').length === 0 || changePageSize === true) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind("page");
        }
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            visiblePages: 10,
            //first: "Đầu",
            //next: "Tiếp",
            //last: "Cuối",
            //prev:"Trước",
            onPageClick: function (event, page) {
                pageConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });

    }
  



}
category.init();

