angular.module('answers').controller('details', ['$scope', 'events', 'data', function ($scope, events, dataService) {

    $scope.cancel = function () {
        events.publish('toggleEdit', false);
    }
    $scope.$on('edit', function (event, itemId) {
        loadItem(itemId);
    });

    function loadItem(itemId) {
        setIsLoading(true);
        dataService.loadDetails(itemId).success(function (result) {
            updateScope(result);
            setIsLoading(false);
        });
    }
    function updateScope(data) {
        $scope.item = data.person;
        $scope.colours = data.availableColors;
        updateColorSet();

    }

    function setIsLoading(value) {
        $scope.isLoading = value;
    }
    function updateColorSet() {
        for (var i = 0; i < $scope.item.colours.length; i++) {
            var color = $scope.item.colours[i];
            for (var j = 0; j < $scope.colours.length; j++) {
                var availableColor = $scope.colours[j];
                if (availableColor.id === color.id) {
                    availableColor.isEnabled = true;
                    break;
                };
            }
        }
    }
    $scope.toggleIsEnabled = function () {
        $scope.item.isEnabled = !$scope.item.isEnabled;
    }

    $scope.toggleIsAuthorised = function () {
        $scope.item.isAuthorised = !$scope.item.isAuthorised;
    }

    $scope.toggleColor = function (color) {
        color.isEnabled = !color.isEnabled;
    }

    $scope.submit = function () {
        var updatedObject = {
            id: $scope.item.id,
            isAuthorised: $scope.item.isAuthorised,
            isEnabled: $scope.item.isEnabled,
            favouriteColoursIds: []
        };

        var favouriteColors = [];

        for (var i = 0; i < $scope.colours.length; i++) {
            if ($scope.colours[i].isEnabled === true) {
                updatedObject.favouriteColoursIds.push($scope.colours[i].id);
                favouriteColors.push($scope.colours[i]);
            }
        }

        setIsLoading(true);
        dataService.updateItem(updatedObject).success(function () {
            events.publish('toggleEdit', false);
            events.publish('updateRecord', { recordData: updatedObject, favouriteColors: favouriteColors });
            cleanScope();
            setIsLoading(false);
        }).error(function () {
            setIsLoading(false);
            alert("ups, something went wrong");
        });
    }

    function cleanScope() {
        delete $scope.item;
        delete $scope.colours;
    }

}]);