angular.module('answers').controller('dataGrid', ['$scope', 'data', function ($scope, dataService) {
    $scope.isLoading = true;
    dataService.loadAll().success(function (data, status) {
        $scope.isLoading = false;
        $scope.people = data;
    });

    $scope.edit = function () {
        alert("edit");
    }
}]);