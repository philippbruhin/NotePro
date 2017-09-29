// Write your JavaScript code.

/* Star rating for note priority */
$('.rating input').change(function () {
    var $radio = $(this);
    $('.rating .selected').removeClass('selected');
    $radio.closest('label').addClass('selected');
});

// Tooltips Initialization
$(function () {
    $('[data-toggle="tooltip"]').tooltip();
})