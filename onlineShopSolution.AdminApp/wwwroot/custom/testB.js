var dmsGrid = {
    me: null,
    urlServer: '',
    idGrid: '',
    ObjectMaster: null,
    objAction: null,
    onClick: Object,
    Data: [],
    SelectItems: [],
    funGetAdvanced: null,
    /**
     * khởi tạo grid
     * @param {any} idName id khai báo input serser lấy dữ liệu
     * @param {any} idTableName id khai báo bảng
     */
    InitGrid(idUrlName, idTableName, idTemplategrid, objCustom, objAdvanced) {
        var objUrl = $(`#${idUrlName}`);
        if (!!objUrl && objUrl.length > 0) {
            dmsGrid.urlServer = objUrl.val();
        }
        if (!!objAdvanced && typeof (objAdvanced) == 'function') {
            dmsGrid.funGetAdvanced = objAdvanced;
        }
        dmsGrid.idGrid = idTableName;
        var tableObj = $(`#${idTableName}`);
        tableObj.addClass('dms-grid');
        dmsGrid.ObjectMaster = tableObj;
        if (tableObj.length) {
            const paging = tableObj.attr('data-paging');
            const sort = tableObj.attr('data-sort');
            const searching = tableObj.attr('data-searching');
            var listColumn = dmsGrid.GetListColumn(idTemplategrid);
            var listDefColum = dmsGrid.GetListDefColumn(idTemplategrid);
            var indexOrder = 1;

            table = $(`#${idTableName}`).DataTable({
                "autoWidth": false,
                paging: paging,
                sort: sort,
                searching: searching,
                searchDelay: 1000,
                orderCellsTop: true,
                fixedHeader: true,
                fixedFooter: true,
                "bInfo": true,
                "bFilter": false,
                "bLengthChange": false,
                scrollCollapse: true,
                order: [[indexOrder, "desc"]],
                language: {
                    emptyTable: "Không có dữ liệu",
                    info: "Hiển thị: _TOTAL_ bản ghi",
                    infoEmpty: "Hiển thị: 0 bản ghi",
                    infoFiltered: "(đã lọc từ _MAX_ bản ghi)",
                    lengthMenu: "Hiển thị _MENU_ mục",
                    loadingRecords: "Loading...",
                    processing: "Loading...",
                    search: "",
                    zeroRecords: "Không có bản ghi nào",
                    searchPlaceholder: "Tìm kiếm",
                    paginate: {
                        first: "Đầu trang",
                        last: "Cuối trang",
                        next: "Tiếp",
                        previous: "Quay lại"
                    },
                    aria: {
                        sortAscending: ": activate to sort column ascending",
                        sortDescending: ": activate to sort column descending"
                    }
                },
                //rowId: 'staffId',
                "processing": true,
                "serverSide": true,
                "bServerSide": true,
                "pageLength": 20,
                ajax: {
                    "url": dmsGrid.urlServer,
                    type: "POST",
                    data: function (d) {
                        if (objCustom == null || !objCustom instanceof Object) {
                            objCustom = {};
                        }
                        dataSearch = $.extend({}, d, objCustom);
                        if (!!dmsGrid.funGetAdvanced) {
                            var listAdvance = dmsGrid.funGetAdvanced();
                            dataSearch.advancedSearch = listAdvance;
                        }
                        return dataSearch;
                    },
                    error: defaultAjaxErrorHandle
                },
                columns: listColumn,
                columnDefs: listDefColum,
                select: {
                    style: 'os',
                    selector: 'td:first-child'
                },
                "drawCallback": function (settings, json) {
                    //$("td.acc-redirect").on("click", function () {
                    //    var data = $(this).parent().find("input.acc-redirect-id").val();
                    //    var urlHostAddress = $("#urlHostAddress").val();
                    //    var link = urlHostAddress + data + "";
                    //    window.open(link, "_blank");
                    //});
                },
                "info": true,
                "stateSave": false,
                "initComplete": function (settings, json) {
                    var objTable = dmsGrid.ObjectMaster.DataTable();
                    dmsGrid.Data = objTable.rows().data();
                }

            });
            $(`#${idTableName} thead tr`).clone(true).appendTo(`#${idTableName} thead`).addClass("search-header");
            $(`#${idTableName} thead tr:eq(1)`).off("click");
            $(`#${idTableName} thead tr:eq(1) th`).off("click");
            $(`#${idTableName} thead tr:eq(1) th`).off("keypress");
            $(`#${idTableName} thead tr:eq(1) th`).each(function (i) {
                $(`#${idTableName} thead tr:eq(1) th`).each(function (i) {
                    var title = $(this).text();
                    var me = $(this);
                    if (!me.hasClass('not-search')) {
                        $(this).html('<i class="fa fa-search" aria-hidden="true"></i><input type="text" class="search-column" placeholder="Search ' + title + '" />');

                        $('input', this).on('keyup', function (e) {
                            var input_filter_value = this.value;
                            if (!!window.input_filter_timeout) {
                                clearTimeout(window.input_filter_timeout);
                                window.input_filter_timeout = null;
                            }
                            window.input_filter_timeout = setTimeout(function () {
                                if (table.columns(i).search() !== input_filter_value) {
                                    table.columns(i).search(input_filter_value).draw();
                                }
                            }, table.context[0].searchDelay);

                        });
                    } else if (me.hasClass('checkbox')) {
                        me.html('<input type="checkbox" class="check-box-all" onchange="dmsGrid.CheckAll(this)">');
                    } else {
                        me.text("");
                    }
                });
            });
        }
        dmsGrid.me = dmsGrid;
    },
    GetListColumn(idTemplate) {
        var arr = [];
        var tableObj = $(`#${idTemplate}`);
        var objTemplateGrid = $(tableObj.html());
        var listObjColumn = objTemplateGrid.children().toArray();
        if (!!listObjColumn && listObjColumn.length > 0) {
            $.each(listObjColumn, function (index, item) {
                var objItem = $(item);
                var typeData = objItem.attr('data-type');
                var objColumn = {};
                switch (typeData) {
                    case 'checkbox':
                        objColumn = {
                            data: $(item).attr('data-name'),
                            className: 'select-checkbox-custome checkbox'
                        };
                        break;
                    case 'text':

                        objColumn = {
                            data: $(item).attr('data-name'),
                            orderable: true,
                            title: $(item).attr('data-display-name')
                        };
                        break;
                    case 'date':
                        objColumn = {
                            data: $(item).attr('data-name'),
                            orderable: true,
                            title: $(item).attr('data-display-name')
                        };
                        break;
                    case 'action':
                        objColumn = {
                            title: $(item).attr('data-display-name')
                        };

                        break;
                    default:
                        objColumn = {
                            data: $(item).attr('data-name'),
                            orderable: true,
                            title: $(item).attr('data-display-name')
                        };
                        break;
                }
                arr.push(objColumn);
            });
        }

        return arr;
    },
    GetListDefColumn(idTemplate) {
        var listColumn = [];
        var tableObj = $(`#${idTemplate}`);
        if (tableObj.length) {
            var objTemplateGrid = $(tableObj.html());
            var objListColumn = objTemplateGrid.children().toArray();
            if (!!objListColumn && objListColumn.length > 0) {
                var numColumn = 0;
                objListColumn.forEach(item => {
                    var objItem = $(item);
                    if (!!objItem && objItem.length > 0) {
                        var typeData = objItem.attr('data-type');
                        var objColumn = null;
                        var nameColumn = objItem.attr('data-name');
                        switch (typeData) {
                            case 'checkbox':
                                objColumn = {
                                    "searchable": false,
                                    orderable: false,
                                    className: 'select-checkbox not-search',
                                    targets: numColumn,
                                    'render': function (data, type, full, meta) {
                                        var str = `<input type="checkbox" class="check-box-item" onchange="dmsGrid.SelectRow(this)" value="${full.Id}">`;
                                        return str;
                                    }
                                };
                                break;
                            case 'text':
                                var classColumn = 'customColumn';
                                var valueEnableSearch = objItem.attr('data-searching');
                                if (!!valueEnableSearch) {
                                    enableSeatch = TryParseBool(valueEnableSearch);
                                    if (!enableSeatch) {
                                        classColumn += ' not-search';
                                    }
                                }
                                objColumn = {
                                    "searchable": true,
                                    "orderable": false,
                                    'className': classColumn,
                                    'targets': numColumn,
                                    'render': function (data, type, full, meta) {
                                        return full[nameColumn];
                                    }
                                };
                                break;
                            case 'date':
                                var classColumn = '';
                                var valueEnableSearch = objItem.attr('data-searching');
                                if (!!valueEnableSearch) {
                                    enableSeatch = TryParseBool(valueEnableSearch);
                                    if (!enableSeatch) {
                                        classColumn = 'not-search';
                                    }
                                }
                                objColumn = {
                                    "searchable": true,
                                    "orderable": false,
                                    "className": classColumn,
                                    "targets": numColumn,
                                    'render': function (data, type, full, meta) {
                                        var str = "";
                                        if (full[nameColumn] !== "") {
                                            str += new Date(full[nameColumn]).toLocaleDateString("en-GB");
                                        }
                                        return str;
                                    }
                                };
                                break;
                            case 'action':
                                var templateName = objItem.attr('data-template');
                                var objTemplate = $(`#${templateName}`);
                                if (!!objTemplate && objTemplate.length > 0) {
                                    var objhtml = $(objTemplate.html());
                                    dmsGrid.objAction = objhtml;
                                    objColumn = {
                                        "searchable": false,
                                        "orderable": false,
                                        "className": 'not-search',
                                        "targets": -1,
                                        'render': function (data, type, full, meta) {
                                            var listObjAction = dmsGrid.objAction.find('.btn-action-grid');
                                            listObjAction.each(function () {
                                                var dataId = full[nameColumn];
                                                var objectId = full['Id'];
                                                $(this).attr('data-id', dataId);
                                                $(this).attr('data-object-id', objectId)
                                            });

                                            return dmsGrid.objAction[0].outerHTML;
                                        }
                                    };
                                }
                                break;
                            case 'jsonlist':

                                var fieldName = objItem.attr('data-name');
                                var listColumnNameJson = objItem.attr('data-list-column-item');
                                dmsGrid[`${fieldName}List`] = listColumnNameJson;
                                objColumn = {
                                    "searchable": true,
                                    "orderable": false,
                                    "className": classColumn,
                                    "targets": numColumn,
                                    'render': function (data, type, full, meta) {
                                        var stringColumnJson = dmsGrid[`${nameColumn}List`];
                                        var listColumnJson = [];
                                        if (!!stringColumnJson) {
                                            listColumnJson = stringColumnJson.split(';');
                                        }
                                        var boxList = $('<div class="list-json-data"></div>');
                                        var dataJson = full[nameColumn];
                                        if (!!dataJson) {
                                            var objJson = JSON.parse(dataJson);
                                            if (!!objJson && objJson.length > 0) {
                                                objJson.forEach(itemVal => {
                                                    var objItemClone = $(`<div class="item-json dis-flex" data-id="${itemVal['Id']}"></div>`);
                                                    if (listColumnJson.length > 0) {
                                                        listColumnJson.forEach(iteItem => {
                                                            var objItemtext = $(`<div class="item-json-text flex" data-field-name="${iteItem}">${itemVal[iteItem]}</div>`);
                                                            objItemClone.append(objItemtext);
                                                        });
                                                    }
                                                    boxList.append($(objItemClone));
                                                });
                                            }
                                        }
                                        return boxList[0].outerHTML;
                                    }
                                };
                                break;
                        }
                        numColumn += 1;
                        listColumn.push(objColumn)
                    }
                });
            }
        }
        return listColumn;
    },
    /**
     * hàm select row
     * @param {any} e
     */
    SelectRow(e) {
        var me = this;
        var data = me.Data;
        var IdSelect = $(e).val();
        if (e.checked) {
            var itemSelect = data.filter(x => { return x.Id == IdSelect });
            if (IdSelect.length > 0) {
                me.SelectItems.push(itemSelect[0]);
            }

        } else {
            var index = me.SelectItems.findIndex(function (x) { return x.Id == IdSelect });
            me.SelectItems.splice(index, 1);
        }
    },
    /**
     * hàm check all
     * @param {any} e
     */
    CheckAll(e) {
        var me = this;
        if (e.checked) {
            me.ObjectMaster.find('.check-box-item').prop('checked', true);
            me.SelectItems = dmsGrid.Data;
        } else {
            me.ObjectMaster.find('.check-box-item').prop('checked', false);
            me.SelectItems = [];
        }
    },
    Reload() {
        var me = this;
        me.ObjectMaster.DataTable().ajax.reload();
    }

};
