angular.module('main')
    .controller('ServiceController', function ($scope, $resource) {

        var serviceResource = $resource('/api/dashboard', {}, { update: { method: 'PUT' } });

        $scope.serviceEvents = [];
        $scope.serviceStatus = function () {

            $scope.hasData = false;
            serviceResource.query(function (data) {
                $scope.serviceEvents.length = 0;
                angular.forEach(data, function (event) {
                    $scope.hasData = true;
                    if (event.Status == "Resolved") {
                        event.Title += "- Resolved 10 minutes ago";
                    } else {
                        event.Title += "- Begin 10 minutes ago";
                    }
                    $scope.serviceEvents.push(event);
                })
            });
        };

        $scope.init = function () {
            $scope.serviceStatus();
        };

        $scope.init();


    });