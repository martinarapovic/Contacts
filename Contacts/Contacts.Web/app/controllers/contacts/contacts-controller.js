"use strict";
app.controller('ContactsController', ['$scope', 'ContactsService', 'ngTableParams', function($scope, contactsService, ngTableParams) {
    var getPagingParameters = function(pagingParams) {
        var sorting = pagingParams.sorting();
        var sortField;
        var sortOrder;
        if (sorting) {
            for (var prop in sorting) {
                sortField = prop;
                sortOrder = sorting[prop];
                break;
            }
        }

        return {
            page: pagingParams.page(),
            count: pagingParams.count(),
            sortField: sortField,
            sortOrder: sortOrder
        };
    };

    $scope.tableParams = new ngTableParams({
        page: 1,
        count: 10,
        sorting: {
            Name: 'asc'
        }
    }, {
        counts: [],
        total: 0,
        getData: function ($defer, params) {
            contactsService.getContactsPaged(getPagingParameters(params))
                .$promise.then(function (data) {
                    params.total(data.length); // update params table
                    console.log(params);
                    console.log(data);
                    $defer.resolve(data); // set new data
                }).catch(function (error) {
                    console.log(error);
                });
        }
    });

    $scope.deleteContact = function (contactId) {
        contactsService.deleteContact(contactId).$promise
            .then(function (data) {
                if ($scope.tableParams.page() !== 1 && $scope.tableParams.data.length === 1) {
                    $scope.tableParams.page(1);
                }
                $scope.tableParams.reload();
            });
    };
    
}]);