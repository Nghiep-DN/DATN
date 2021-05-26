$(document).ready(function () {
    $('.box-menu-custom .item-menu').removeClass('active');
    $('.box-menu-custom .item-menu.item-search').addClass('active');

    dmsGrid.InitGrid('urlGetAjaxCaseDoc', 'tableCaseDocument', 'tempGridCaseDocument');
});