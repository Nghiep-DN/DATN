$(document).ready(function () {
    let index = new Index();
    index.loadData();
    index.registerEvent();
 //   index.btnDeleteOnClick();

    $("#checkAll").click(function () {
        $('input:checkbox').not(this).prop('checked', this.checked);
    });

});

//function backToIndex(e) {
//    var objme = $(e);
//    if (!!objme && objme.length > 0) {
//        var id = objme.attr('data-id');
//        var url = $('#urlIndex').val();
//        window.location.href = url;
//    }
//}

//hướng đối tượng
class Index {
    //constructor
    constructor() {
        // this.loadData(); //goi trong class, khi khởi tạo DT thì sẽ thự thi luôn loadData
        //  loadData() // gọi 1 hàm khác bên ngoài
    };
    registerEvent() {
        //bind(this) de truyen doi tuong hien tai de duoi co the sd this
        $('#btnAddNew').click(this.btnAddOnClick.bind(this));
        //goi thang xuong ham
        //$('.btnAdd').click(this.btnAddOnClick());
        $('#btnCancel').click(this.btnCancelOnClick.bind(this));
        $('.btnClose').click(this.btnCancelOnClick.bind(this));
        $('#btnSave').click(this.btnSaveOnClick.bind(this));
        $('#btnDeleteCategory').click(this.btnDeleteOnClick.bind(this));
        //gan sự kiện để ng dùng nhập tên và email(validate)
        $('input[required]').blur(this.checkRequired);
    };

    loadData() {
        $.ajax({
            url: 'https://localhost:5001/api/categories/getAll?languageId=vi',
            //headers: {
            //    'Access-Control-Allow-Origin': '*'
            //},
            //contentType: "application/json",
            method: 'GET',
            //data: '', // tham so se truyền qua body request
            success: function (res) {
                //alert(res[0].name)
                //$.each(res, function (index, item) {
                //    console.log(item.name)
                //})        
            },
            fail: function (res) {
                console.log("fail.");
            }
        }).done(function (res) {
            $('.card-body tbody').empty();
            $.each(res, function (index, item) {
                var dt = $(`<tr>
                <td><input type="checkbox" class="i-checks" ></td>
                <td>`+ item.id + `</td>
                <td>`+ item.name + `</td>
                <td>`+ item.seoAlias + `</td>
                <td>`+ item.seoDesciption + `</td>
                <td>`+ item.seoTitle + `</td>
                <td>`+ item.isShowOnHome + `</td>
                <td> <input type="button" value="Chi tiết" class="btn btn-success" id="btnDetailCategory"/> | <input type="button" value="Sửa" class="btn btn-primary" id="btnUpdateCategory"/> | <input type="button" value="Xóa" data-id="`+item.id+`" class="btn btn-danger" id="btnDeleteCategory"/> </td>
                </tr>`)
                $('.card-body tbody').append(dt);
            })
        })
    };
     
    btnAddOnClick() {
        this.btnAddOnClick = $('input').val('');
        //this nay la EmployeeJS vi da dduoc bind(this) o tren
        this.showDialogDetail();
    };
    btnCancelOnClick() {
        this.hideDialogDetail();
    };
    btnDeleteOnClick() {
        console.log(" btn delete category");
        var id = $(this).data('id');
        this.deleteCategory(id);
    };

    btnSaveOnClick() {
        //validate du lieu tren form

        //cach1: check tung truong
        //var name = $('#txtName').val();
        //var email = $('#txtEmail').val();

        //if (!name) {
        //    $('#txtName').addClass('required-error');
        //    $('#txtName').focus();
        //    $('#txtName').attr('title', 'Tên không được để trống!');
        //    return;
        //}

        //if (!email) {
        //    $('#txtEmail').addClass('required-error');
        //    $('#txtEmail').focus();
        //    $('#txtEmail').attr('title', 'Email không được để trống!');
        //    return;
        //}

        //cach2: check tất cả các trường có Required
        var inputRequireds = $("[required]");
        var isValid = true;
        $.each(inputRequireds, function (index, input) {
            var valid = $(input).trigger("blur");
            if (isValid && valid.hasClass("required-error")) {
                isValid = false;
            }
        })
        if (isValid) {
            //thu thap thong tin tren form
            var request = {};
            request.name = $('#txtName').val();
            request.seoDescription = $('#txtSeoDescription').val();
            request.seoAlias = $('#txtSeoAlias').val();
            request.seoTitle = $('#txtSeoTitle').val();

            //var phone = $('#txtPhone').val();
            //var address = $('#txtAddress').val();
            //var Description = $('#txtDescription').val();
            //thuc hien save dl vao DB
                 //data.push(category);

            $.ajax({
                url: '/category/create/',
                method: 'POST',
                dataType:'JSON',
                data: request,
                success(res) {
                   
                }


            }).done(function (res) {
                if (res == true) {

                    toastr.success('Thêm mới thành công!', 'Thành công !!!');

                    this.loadData;
                }
                else {
                    toastr.error(res.Message, 'Error!');
                }


            }).fail(function (res) {

                toastr.error(res.Message, 'Error!');
            });

            this.loadData();
            this.hideDialogDetail();
            
        }
    };

    deleteCategory(id) {
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
                    type: 'POST',
                    dataType: 'json',
                    data: {
                        id: id
                    },
                    success: function (res) {
                        if (res.status == 200) {
                            Swal.fire(
                                'Deleted!',
                                'Your file has been deleted.',
                                'success')
                       //     productController.loadData(true);
                        }

                    },
                    error: function (err) {
                        console.log(err)
                    }
                });
            }
            //else if (result.dismiss === Swal.DismissReason.cancel) {
            //    Swal.fire(
            //        'Cancelled',
            //        'Your file is safe :))',
            //        'error'
            //    )
            //}
        })

    };

    checkRequired() {
        //lay gia tri kieu js
        var val = this.value;
        if (!val) {
            $(this).addClass('required-error');
            $(this).attr('title', 'Vui lòng nhập đầy đủ thông tin!');
        } else {
            $(this).removeClass('required-error');
            $(this).removeAttr('title');
        }
    };

    showDialogDetail() {
        $('#categoryModal').modal('show');
        $('#txtName').focus();
    };
    hideDialogDetail() {

        $('#categoryModal').modal('hide');
    }
}




//////////////////////////////////////////////////////////
let pageConfig = {
    pageSize: 3,
    pageIndex: 1
}
let productController = {
    init: function () {
        productController.loadData();
        productController.registerEvent();
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

        $('#btnAdd').off('click').on('click', function () {
            productController.resetForm();
            $('#hidId').val('0');
            $('#contentTopHot').inputmask('dd/mm/yyyy', { placeholder: 'dd/mm/yyyy', alias: 'dd/mm/yyyy' });
            $('#modalAddUpdate').modal('show');
        });
        $('#btnSave').off('click').on('click', function () {
            if ($('#frmValid').valid()) {
                productController.saveData();
                $('#modalAddUpdate').modal('hide');
            }
        });

        $(document).off('click').on('click', '.btnUpdate', function (e) {
            //alert(1);
            e.preventDefault();

            $('#modalAddUpdate').modal('show');
            var id = $(this).attr('data-id'); // khắc cốt ghi tâm
            console.log('-> id', id);
            //console.log('this->', this);
            productController.getDetail(id);
        });
        $('.btnDelete').off('click').on('click', function () {

            var id = $(this).data('id');
            console.log('-> id', id);
            productController.delete(id);

        });
        $('#btnReset').on('click', function () {

            $('#txtSearch').val('');
            $('#statusSearch').val('');
            productController.loadData();

        });

        $('#btnSearch').off('keypress').on('keypress', function (e) {

            if (e.which == 13) {

                productController.loadData(true);
            }

        });


    },
    resetForm: function () {
        $('#contentName').val('');
        $('#contentCode').val('');
        $('#contentQuatity').val('');
        $('#contentPrice').val('');
        $('#contentMetaTitle').val('');
        $('#contentDescription').val('');
        $('#hidImage').val('');
        $('#contentImage').val('');
        $('#contentDetail').val('');
        $('#contentWarranty').val('');
        $('#contentTopHot').val(false);
        $('#contentStatus').prop('checked', false);
    },
    loadData: function (changePageSize) {
        let stt = $('#statusSearch').val();
        let nameSearch = $('#txtSearch').val();
        $.ajax({
            url: '/ProductAdmin/loadData',
            type: 'GET',
            data: {
                tt: stt,
                name: nameSearch,
                page: pageConfig.pageIndex,
                pageSize: pageConfig.pageSize
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        //let crdate = productController.formatDate(new Date(parseInt(item.TopHot.substring(6, item.TopHot.length - 2))));

                        html += Mustache.render(template, {
                            ID: item.ID,
                            Name: item.Name,
                            Code: item.Code,
                            MetaTitle: item.MetaTitle,
                            Description: item.Description,
                            Image: item.Image,
                            Price: item.Price,
                            Quatity: item.Quatity,
                            Detail: item.Detail,
                            Warranty: item.Warranty,
                            Status: item.Status == true ? "<span class=\"badge badge-success\">Active</span>" : "<span class=\"badge badge-danger\">Locked</span>",
                            TopHot: item.TopHot

                        })
                    });
                    $('#tblData').html(html);
                    productController.paging(res.total, function () {
                        productController.loadData();
                    }, changePageSize);
                    productController.registerEvent();
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
    saveData: function () {
        let formFile = new FormData();

        let id = $('#hidID').val();
        //console.log('id', id);

        let name = $('#contentName').val();
        let code = $('#contentCode').val();
        let quatity = $('#contentQuatity').val();
        let price = $('#contentPrice').val();
        let metaTitle = $('#contentMetaTitle').val();
        let description = $('#contentDescription').val();
        let hidImage = $('#hidImage').val();
        let imageName = $('input[type=file]')[0].files[0];
        let detail = $('#contentDetail').val();
        let warranty = $('#contentWarranty').val();
        let tophot = $('#contentTopHot').val();

        formFile.append('ID', id)
        formFile.append('Code', code)
        formFile.append('Quatity', quatity)
        formFile.append('Price', price)
        formFile.append('Name', name)
        formFile.append('MetaTitle', metaTitle)
        formFile.append('Description', description)
        formFile.append('Detail', detail)
        formFile.append('Warranty', warranty)
        formFile.append('TopHot', tophot)
        formFile.append('Status', $('#contentStatus').prop('checked'))

        //console.log("imageName",imageName);
        //console.log('hid: ', hidImage);
        formFile.append('file', imageName)
        // console.log($('input[type=file]')[0].files[0])
        if (imageName == undefined) {
            formFile.append('Image', hidImage)
        }
        else {
            formFile.append('file', imageName)
        }
        $.ajax({
            url: '/ProductAdmin/saveData',
            type: 'POST',
            dataType: 'json',
            contentType: false,
            processData: false,
            enctype: 'multipart/form-data',
            data: formFile,
            success: function (res) {
                console.log(res);
                if (res) {
                    toastr.success("Save success", "Success!");
                    $('#modalAddUpdate').modal('hide');
                    $('#contentImage').val('');
                    productController.loadData(true);
                }
            },
            error: function (err) {
                console.error(err);
            }
        });
    },
    getDetail: function (id) {

        $.ajax({
            url: '/ProductAdmin/getDetail',
            type: 'GET',
            dataType: 'json',
            data: {
                id: id
            },
            success: function (res) {
                if (res.status == true) {
                    var data = res.data;

                    //let crdate = ProductController.formatDate(new Date(parseInt(data.TopHot.substring(6, data.TopHot.length - 2))));
                    $('#hidID').val(data.ID);
                    $('#contentName').val(data.Name);
                    $('#contentCode').val(data.Code);
                    $('#contentQuatity').val(data.Quatity);
                    $('#contentPrice').val(data.Price);
                    $('#contentMetaTitle').val(data.MetaTitle);
                    $('#contentDescription').val(data.Description);
                    $('#hidImage').val(data.Image);
                    $('#contentDetail').val(data.Detail);
                    $('#contentWarranty').val(data.Warranty);
                    // $('#createdDate').val(crdate);
                    $('#contentStatus').prop('checked', data.Status);
                    $('#contentTopHot').val(data.TopHot);
                    productController.registerEvent();
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
                    url: '/ProductAdmin/Delete',
                    type: 'POST',
                    dataType: 'json',
                    data: {
                        id: id
                    },
                    success: function (res) {
                        if (res.status == true) {
                            Swal.fire(
                                'Deleted!',
                                'Your file has been deleted.',
                                'success')
                            productController.loadData(true);
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
productController.init();
