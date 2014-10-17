'use strict';
app.controller('contactsController',
    [            '$scope', '$rootScope', 'contactService',
        function ($scope,   $rootScope,   contactService) {
            
            initialize();

            function initialize() {
                var condition = $scope.searchTerm;
                if (!condition || condition == '') {
                    loadContacts();
                } else {
                    searchContacts(condition);
                }
            }

            function searchContacts(condition) {
                
                contactService.searchContacts(condition)
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
            
            function loadContacts() {
                var condition = $scope.searchTerm;
                contactService.getContacts()
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

            $scope.search = function() {
                initialize();
            };

            $scope.deleteContact = function (contactId) {
                contactService.deleteContact(contactId)
                    .$promise
                        .then(function (data) {
                            $rootScope.info = undefined;
                            initialize();
                        }).catch(function (error) {
                            console.log(error);
                            $rootScope.error = 'Error occurred while deleting contact.';
                        });
            };
        }
    ]
);