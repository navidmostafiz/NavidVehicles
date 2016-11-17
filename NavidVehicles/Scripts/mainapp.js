/// <reference path="angular.js" />

var myApp = angular.module('myModule', []);

var vehicleController = function ($scope, $http) {

    // $scope.LoadAllVehicles = function () {
    $http.get("http://localhost:8511/api/vehicles/vehicles")
        .then(function (response) {
            $scope.GetAllVehicles = response.data;
        });
    //};

    $scope.headingTitle = "Vehicle Menu";

    $scope.ShowVehicleDetail = function (data) {
        //alert("clicked" + data.Id + data.Make + data.Model + data.Year);
        var vehicleDetail = { Id: data.Id, Make: data.Make, Model: data.Model, Year: data.Year }
        $scope.vehicleDetails = vehicleDetail;
    };

    $scope.UpdateVehicle = function (data) {

        var vehicleDetail = { Id: data.Id, Make: data.Make, Model: data.Model, Year: data.Year }
        alert("clicked" + vehicleDetail.Id + vehicleDetail.Make + vehicleDetail.Model + vehicleDetail.Year);
        $http.put("http://localhost:8511/api/vehicles/vehicles", vehicleDetail)
        .then(function (response) {
            alert(response.data);
            if (response.data == true) { $scope.status = "Updated!"; }
        });
    };

    $scope.DeleteVehicle = function (data) {
        var vehicleDetail = { Id: data.Id, Make: data.Make, Model: data.Model, Year: data.Year }
        alert("clicked" + vehicleDetail.Id + vehicleDetail.Make + vehicleDetail.Model + vehicleDetail.Year);
        $http.delete("http://localhost:8511/api/vehicles/vehicles/" + vehicleDetail.Id)
       .then(function (response) {
           if (response.data == true) { $scope.status = "Deleted!"; }
           LoadAllVehicles();
       });
    };

    function LoadAllVehicles() {
        alert("ran");
        $http.get("http://localhost:8511/api/vehicles/vehicles")
           .then(function (response) {
               $scope.GetAllVehicles = response.data;
           });
    };


};


myApp.controller('vehicleController', vehicleController);