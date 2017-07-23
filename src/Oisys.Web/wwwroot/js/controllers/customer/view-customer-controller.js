﻿(function () {
    var viewCustomerController = function (loadingService) {
        var vm = this;

        vm.customers = [];

        loadingService.showLoading();

        $(function () {
            for (var i = 0; i < 100; i++) {
                vm.customers.push({
                    Id: i + 1,
                    Code: "Code " + i + 1,
                    Name: "Name",
                    City: "City1",
                    Province: "Province1",
                    ContactPerson: "MyContact",
                    ContactNumber: "911-5555"
                });
            };
        });

        return vm;
    };

    angular.module("oisys-app").controller("viewCustomerController", ["loadingService", viewCustomerController]);
})();