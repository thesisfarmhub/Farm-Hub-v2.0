$(document).ready(function () {
    $(".Advanced").hide();
    $("#advancedSearch").click(function (e) {
        e.preventDefault();
        $(".Advanced").toggle(1000);
    });
});