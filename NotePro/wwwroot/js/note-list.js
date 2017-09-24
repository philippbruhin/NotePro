
//disable anchor delete after one click to prevent fatal error on double click
$("a.delete-note").one("click", function () {
    $(this).click(function () { return false; });
});
