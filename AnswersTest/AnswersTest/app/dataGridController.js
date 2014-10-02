angular.module('answers').controller('dataGrid', ['$scope', 'data', 'events', function ($scope, dataService, events) {
    $scope.isLoading = true;
    dataService.loadAll().success(function (data) {
        $scope.isLoading = false;
        $scope.people = data;
    });

    $scope.edit = function (item) {
        events.publish('toggleEdit', true);
        events.publish('edit', item.id);
    }

    $scope.$on('updateRecord', function (event, data) {
        var record = data.recordData;
        var person = getElementById($scope.people, record.id);
        person.isAuthorised = record.isAuthorised;
        person.isEnabled = record.isEnabled;
        person.coloursDisplay = getColoursDisplay(data.favouriteColors);

    });

    function getColoursDisplay(colours) {
        var colorNames = [];
        for (var i = 0; i < colours.length; i++) {
            colorNames.push(colours[i].name);
        }
        return colorNames.join(" ,");
    }

    function getElementById(array, id) {
        for (var j = 0; j < array.length; j++) {
            if (array[j].id === id)
                return array[j];
        }
        return -1;
    }
}]);