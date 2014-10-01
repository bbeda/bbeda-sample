angular.module('answers').directive('yesNo', function () {
    function link(scope, element, attrs) {
        function updateElement(value) {
            element.text(value ? 'Yes' : 'No');
            element.addClass(value ? 'text-yes' : 'text-no');
        }

        scope.$watch('value', function (value) {
            updateElement(value);
        });
    }

    return {
        link: link,
        restrict: 'E',
        scope: {
            value: '=value'
        }
    };
});