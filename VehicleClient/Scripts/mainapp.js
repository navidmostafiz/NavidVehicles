/// <reference path="angular.js" />

var myApp = angular.module('myModule', []);

var vehicleController = function ($scope, $http) {

    $http.get("http://localhost:8511/api/vehicles/vehicles").then(function (response) {

        $scope.GetAllVehicles = response.data;

        alert("inside get then");
    });

    alert("inside controller");

    $scope.GetAllVehicles2 = [1, 2, 3, 4, 5];

    $scope.test2 = "popp";

};


myApp.controller('vehicleController', vehicleController);