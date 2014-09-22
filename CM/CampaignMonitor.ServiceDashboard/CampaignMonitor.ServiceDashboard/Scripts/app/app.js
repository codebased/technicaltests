// Main configuration file. Sets up AngularJS module and routes and any other config objects
var appRoot = angular.module('main', ['ngRoute', 'ngResource', 'angularStart.services', 'angularStart.directives']);     //Define the main module

appRoot
    .config(['$routeProvider', function ($routeProvider) {
        //Setup routes to load partial templates from server. TemplateUrl is the location for the server view (Razor .cshtml view)
        $routeProvider
            .when('/home', { templateUrl: '/dashboard/main', controller: 'MainController' })
            .when('/csharptest', { templateUrl: '/dashboard/csharptest', controller: 'CsharptestController' })
            .when('/javascripttest', { templateUrl: '/dashboard/javascripttest', controller: 'JavaScriptTestController' })
            .when('/service', { templateUrl: '/dashboard/service', controller: 'ServiceController' })
            .when('/contact', { templateUrl: '/dashboard/contact', controller: 'ContactController' })
            .otherwise({ redirectTo: '/home' });
    }])
    .controller('RootController', ['$scope', '$route', '$routeParams', '$location', function ($scope, $route, $routeParams, $location) {
        $scope.$on('$routeChangeSuccess', function (e, current, previous) {
            $scope.activeViewPath = $location.path();

        });
   }]);
