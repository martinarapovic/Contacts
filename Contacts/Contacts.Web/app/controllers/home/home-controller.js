'use strict';
app.controller('homeController',
    [            '$scope', '$rootScope', 'contactService',
        function ($scope,   $rootScope,   contactService) {
            
            initialize();

            function initialize() {
                loadContacts();
            }

            function loadContacts() {
                contactService.getFiveLatestContacts()
                    .$promise
                        .then(function (contacts) {
                            console.log(contacts);
                            $scope.contacts = contacts;
                            
                            $rootScope.info = 'Contacts loaded.';
                        }).catch(function (error) {
                            console.log(error);
                            $rootScope.error = 'Error occurred while loading contacts.';
                        });
            }
        }
    ]
);