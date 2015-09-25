var app = angular.module('BigRoomApp', ['ngRoute', 'angular-loading-bar']);

app.config(function($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

});