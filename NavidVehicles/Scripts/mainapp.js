/// <reference path="angular.js" />

var myApp = angular.module('myModule', ['ngMessages', 'angularSpinner']);

var vehicleController = function ($scope, $http, usSpinnerService) {

    ShowSpinner(true);

    $scope.Vehicle = {
        Id: "",
        Year: "",
        Make: "",
        Model: ""
    };

    $scope.NewVehicle = {
        Year: "",
        Make: "",
        Model: ""
    };

    //pop vehicle list
    $http.get("/api/vehicles/vehicles")
        .then(function (response) {
            $scope.GetAllVehicles = response.data;
            $scope.status = "Vehicle List Loaded!";
            ShowSpinner(false);
        });

    $scope.status = "Welcome!"
    $scope.headingTitle = "Vehicle Menu";

    //vehicle detail
    $scope.ShowVehicleDetail = function (data) {

        $scope.Vehicle = data;
        $scope.status = "Showing Vehicle Details for Id = " + $scope.Vehicle.Id;
    };

    //create new vehicle
    $scope.CreateVehicle = function () {

        var newVehicle = $scope.NewVehicle;
        if (newVehicle.Year != "" && newVehicle.Make != "" && newVehicle.Model != "") {
            ShowSpinner(true);

            $http.post("/api/vehicles/vehicles", newVehicle)
            .then(function (response) {
                if (response.data != null) { $scope.status = "New Vehicle Created!"; }
                ResetNewVehicle()
                LoadAllVehicles();
                $scope.NewVehicleForm.$setUntouched();
                ShowSpinner(false);
            }, function (response) {
                $scope.status = "Vehicle Creation Failed! " + response.statusText;
                $scope.NewVehicleForm.$setUntouched();
                ShowSpinner(false);
            });
        } else { $scope.status = "Cannot Create: Fields cannot be empty."; }
    };

    //update existing vehicle
    $scope.UpdateVehicle = function () {

        var vehicle = $scope.Vehicle;
        if (vehicle.Id != "" && vehicle.Year != "" && vehicle.Make != "" && vehicle.Model != "") {
            ShowSpinner(true);

            $http.put("/api/vehicles/vehicles", vehicle)
            .then(function (response) {
                if (response.data == true) { $scope.status = "Vehicle Updated!"; }
                ResetVehicle();
                LoadAllVehicles();
                $scope.VehicleForm.$setUntouched();
                ShowSpinner(false);
            }, function (response) {
                $scope.status = "Update Failed! " + response.statusText;
                $scope.VehicleForm.$setUntouched();
                ShowSpinner(false);
            });
        } else { $scope.status = "Fields cannot be empty."; }
    };

    //delete vehicle
    $scope.DeleteVehicle = function () {

        var vehicle = $scope.Vehicle;
        if ($scope.Vehicle.Id != "") {
            ShowSpinner(true);

            $http.delete("/api/vehicles/vehicles/" + vehicle.Id)
           .then(function (response) {
               if (response.data == true) { $scope.status = "Deleted!"; }
               ResetVehicle();
               LoadAllVehicles();
               $scope.VehicleForm.$setUntouched();
               ShowSpinner(false);
           }, function (response) {
               $scope.status = "Vehicle delete Failed! " + response.statusText;
               $scope.VehicleForm.$setUntouched();
               ShowSpinner(false);
           });
        } else { $scope.status = "Id cannot be empty."; }
    };

    //Reload vehicle list on button
    $scope.ReloadAllVehicles = function () {
        LoadAllVehicles();
    };

    //reloading vehicle list
    function LoadAllVehicles() {
        ShowSpinner(true);
        $http.get("/api/vehicles/vehicles")
           .then(function (response) {
               $scope.GetAllVehicles = response.data;
               ShowSpinner(false);
           }, function (response) {
               $scope.status = "Vehicle List Failed! " + response.statusText;
               ShowSpinner(false);
           });
    };

    //reset
    function ResetVehicle() {

        $scope.Vehicle = {
            Id: "",
            Year: "",
            Make: "",
            Model: ""
        };

    };

    //reset
    function ResetNewVehicle() {

        $scope.NewVehicle = {
            Year: "",
            Make: "",
            Model: ""
        };

    };

    //show spinner
    function ShowSpinner(setBool) {

        if (setBool) { usSpinnerService.spin('spinner-1'); }
        else { usSpinnerService.stop('spinner-1'); }

    };

};


myApp.controller('vehicleController', vehicleController);