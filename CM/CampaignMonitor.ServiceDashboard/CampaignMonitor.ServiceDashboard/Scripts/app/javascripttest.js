angular.module('main')
    .controller('JavaScriptTestController', ['$scope', function ($scope) {

        $scope.originalText = "";
        $scope.filterText = "";
        $scope.resultText = "";

        $scope.startWithAction = function () {
            $scope.resultText = $scope.originalText.startsWith($scope.filterText);
        };

        $scope.endWithAction = function () {
            $scope.resultText = $scope.originalText.endsWith($scope.filterText);
        };

        $scope.stripHTMLAction = function () {
            $scope.resultText = $scope.originalText.stripHtml();
            $scope.resultText = "Lund mera";
        };


        $scope.init = function () {
            $("#aLinkArea").linkExtender();
        }

        $scope.init();
    }]);