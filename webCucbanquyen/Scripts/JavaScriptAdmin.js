$('.number').keypress(function (event) {
    var keycode = event.which;
    if (!(event.shiftKey == false && (keycode == 46 || keycode == 8 || keycode == 37 || keycode == 39 || (keycode >= 48 && keycode <= 57)))) {
        event.preventDefault();
    }
});
function geturl(str) {
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/!|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_|{|}|`/g, "-");
    str = str.replace(/ /g, "-");
    str = str.replace(/-+-/g, "-");
    str = str.replace(/^\-+|\-+$/g, "");
    return str;
}
$("#Banner").click(function () {
    var ckfiner = new CKFinder();
    ckfiner.selectActionFunction = function (fileUrl) {
        $("#Banner").val(fileUrl);
    };
    ckfiner.popup();
});
$("#thumbnail").click(function () {
    var ckfiner = new CKFinder();
    ckfiner.selectActionFunction = function (fileUrl) {
        $("#thumbnail").val(fileUrl);
    };
    ckfiner.popup();
});
$("#detailUrl").click(function () {
    var ckfiner = new CKFinder();
    ckfiner.selectActionFunction = function (fileUrl) {
        $("#detailUrl").val(fileUrl);
    };
    ckfiner.popup();
});
$(document).ready(function () {
    $(".search").on("click", function () {
        $(".page-to-move").val(null);
        $(this).closest('form').submit();
    });
    $(".datepicker").datepicker({
        format: 'mm/dd/yyyy'
    });
});
function refresh(x) {
    window.location.href = "/Quantri/" + x;
}
function moveToPreviousPage(currentPage, formId) {
    moveToPage(currentPage - 1, formId);
}
function moveToNextPage(currentPage, formId) {
    moveToPage(currentPage + 1, formId);
}
function moveToPage(page, formId) {
    $(".page-to-move").val(page);
    $("#" + formId).submit();
}