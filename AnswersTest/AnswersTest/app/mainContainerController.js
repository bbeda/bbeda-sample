angular.module('answers').controller('mainContainer', ['$scope', function ($scope) {
    $scope.isEditing = false;
    $scope.$on("toggleEdit", function (event, value) {
        $scope.isEditing = value;
    });
}]);