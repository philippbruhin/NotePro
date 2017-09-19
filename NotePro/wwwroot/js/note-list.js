
//handle filter options in note list
var setFilter = function () {
    document.forms["sortform"].submit();
};

$(".sort").on("change", setFilter);
