/* CHARACTER COUNTER */

(function ($) {

    $.fn.characterCounterTextarea = function () {
        return this.each(function () {

            var itHasLengthAttribute = $(this).attr('maxlength') !== undefined;

            if (itHasLengthAttribute) {
                $(this).on('input', updateCounter);
                $(this).on('focus', updateCounter);
                $(this).on('blur', removeCounterElement);

                addCounterElement($(this));
            }

        });
    };

    function updateCounter() {
        var maxLength = +$(this).attr('maxlength'),
            actualLength = +$(this).val().length,
            isValidLength = actualLength <= maxLength;

        $(this).parent().find('span[class="character-counter-textarea"]')
            .html(actualLength + '/' + maxLength);

        addInputStyle(isValidLength, $(this));
    }

    function addCounterElement($input) {
        var $counterElement = $('<span/>')
            .addClass('character-counter')
            .css('float', 'right')
            .css('font-size', '12px')
            .css('height', 1);

        $input.parent().append($counterElement);
    }

    function removeCounterElement() {
        $(this).parent().find('span[class="character-counter"]').html('');
    }

    function addInputStyle(isValidLength, $input) {
        var inputHasInvalidClass = $input.hasClass('invalid');
        if (isValidLength && inputHasInvalidClass) {
            $input.removeClass('invalid');
        } else if (!isValidLength && !inputHasInvalidClass) {
            $input.removeClass('valid');
            $input.addClass('invalid');
        }
    }

    $(document).ready(function () {
        $('textarea').characterCounter();
    });

}(jQuery));