
var SetFilter = function () {
    alert("on change");
    var val = $("input.sort:checked").val();
    alert("val " + val);
    window.open("/Home/Index?sortOptionIndex=" + val, "_self")
};

$(".btn-group").children().on("change", SetFilter);