
var SetFilter = function () {
    var val = $("input.sort:checked").val();
    window.open("/Home/Index?sortOptionIndex=" + val, "_self");
};

$(".btn-group").children().on("change", SetFilter);