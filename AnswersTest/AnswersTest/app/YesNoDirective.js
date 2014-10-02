//angluar extension used to create custom text display an styling for boolean values.
angular.module('answers').directive('yesNo', function () {
    function link(scope, element, attrs) {
        function updateElement(value) {
            element.text(value ? 'Yes' : 'No');
            updateStyle(element, value);
        }

        scope.$watch('value', function (value) {
            updateElement(value);
        });
    }

    function updateStyle(element, value) {
        element.removeClass('text-yes');
        element.removeClass('text-no');
        element.addClass(value ? 'text-yes' : 'text-no');
    }

    return {
        link: link,
        restrict: 'E',
        scope: {
            value: '=value'
        }
    };
});