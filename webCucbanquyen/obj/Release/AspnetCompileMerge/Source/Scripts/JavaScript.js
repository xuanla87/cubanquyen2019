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
function moveTabPage(x, formId) {
    $(".page-tab-move").val(x);
    $("#" + formId).submit();
}

$(window).ready(function () {
    $("#lg-vn").click(function () {
        $.ajax({
            type: "GET",
            url: "/Home/setLanguage",
            data: { code: "vn" },
            datatype: "json",
            success: function (data) {
                if (data == false)
                    window.location.reload(true);
                else
                    window.location.href = "/";
            }
        });
    });
    $("#lg-en").click(function () {
        $.ajax({
            type: "GET",
            url: "/Home/setLanguage",
            data: { code: "en" },
            datatype: "json",
            success: function (data) {
                if (data == false)
                    window.location.reload(true);
                else
                    window.location.href = "/";
            }
        });
    });
});