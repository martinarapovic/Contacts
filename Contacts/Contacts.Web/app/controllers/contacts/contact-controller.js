'use strict';
app.controller('contactController',
    [            '$scope', '$rootScope', '$q', '$filter', '$location', '$routeParams', 'contactService', 'labelService',
        function ($scope,   $rootScope,   $q,   $filter,   $location,   $routeParams,   contactService,   labelService) {

            $scope.isEdit = $routeParams.contactId != undefined && $routeParams.contactId > 0;
            
            $scope.contact = {
                PhoneNumbers: [],
                EmailAddresses: [],
                Tags: []
            };
            
            initialize();
            
            function initialize() {
                
                $scope.contact = {
                    PhoneNumbers: [],
                    EmailAddresses: [],
                    Tags: []
                };
                
                //contactService.getContact($routeParams.contactId)
                //        .$promise
                //            .then(function (data) {
                //                console.log(data);
                //
                //                if (data.length > 0) {
                //                    $scope.contact = data;
                //                    return;
                //                }
                //
                //                // No contact with specified id
                //                $rootScope.error = 'Error getting contact with id=' + $routeParams.contactId + '.';
                //                $location.url('/contacts');
                //
                //                getLabels();
                //
                //            }).catch(function (error) {
                //                console.log(error);
                //                $rootScope.error = 'Error occurred while getting contact. Please reload page...';
                //            });
                
                if ($scope.isEdit) {
                    $q.all([
                        contactService.getContact($routeParams.contactId).$promise,
                        labelService.getLabels().$promise]).then(function (data) {
                            console.log(data);
                            
                            $scope.contact = data[0];
                            
                            setDefaultLabelsRelatedData(data[1]);
                        })
                        .catch(function (error) {
                            console.log(error);
                            $rootScope.error = 'Error occurred while getting data.';

                        });
                } else {
                    $q.all([labelService.getLabels().$promise])
                        .then(function (data) {
                            console.log(data);

                            setDefaultLabelsRelatedData(data[0]);
                        })
                        .catch(function (error) {
                            console.log(error);
                            $rootScope.error = 'Error occurred while getting data.';
                        });
                }
            }
            

         
            //labelService.getLabels()
            //        .$promise
            //            .then(function (data) {
            //
            //                console.log(data);
            //                $scope.labels = data;
            //
            //                // Set default selected label for phone numbers and email
            //                $scope.defaultSelectedLabelId = $scope.labels[0].LabelId;
            //                $scope.phoneNumberSelectedLabelId = $scope.defaultSelectedLabelId;
            //                $scope.emailAddressSelectedLabelId = $scope.defaultSelectedLabelId;
            //
            //            }).catch(function (error) {
            //                console.log(error);
            //                $rootScope.error = 'Error occurred while getting label.';
            //            });

            var setDefaultLabelsRelatedData = function (data) {
                $scope.labels = data;
                
                // Set default selected label for phone numbers and email
                $scope.defaultSelectedLabelId = $scope.labels[0].LabelId;
                $scope.phoneNumberSelectedLabelId = $scope.defaultSelectedLabelId;
                $scope.emailAddressSelectedLabelId = $scope.defaultSelectedLabelId;
            };

            $scope.addContact = function (contact) {
                contactService.addContact(contact)
                    .$promise
                        .then(function (data) {
                            $location.url('/contacts');
                            $rootScope.info = 'New contact added.';
                        }).catch(function (error) {
                            console.log(error);
                            $rootScope.error = 'Error occurred while adding contact.';
                        });
            };
            
            $scope.editContact = function (contact) {
                contactService.editContact(contact)
                    .$promise
                        .then(function (data) {
                            $location.url('/contacts');
                            $rootScope.info = 'Contact edited.';
                        }).catch(function (error) {
                            console.log(error);
                            $rootScope.error = 'Error occurred while editing contact.';
                        });
            };

            $scope.addPhoneNumber = function () {

                var label = $filter('filter')($scope.labels, { LabelId: $scope.phoneNumberSelectedLabelId })[0];
                
                var phone = {
                    PhoneNumberId: 0,
                    Number: $scope.number,
                    LabelId: label.LabelId,
                    Label : label,
                    ContactId: 0
                };
                
                var phoneNumberAlreadyAdded = $filter('filter')($scope.contact.PhoneNumbers, { Number: phone.Number });
                if (phoneNumberAlreadyAdded.length) {
                    $rootScope.error = 'Phone Number already added...';
                    return;
                }
                $scope.contact.PhoneNumbers.push(phone);

                $scope.number = null;
                $scope.phoneNumberSelectedLabelId = $scope.defaultSelectedLabelId;
            };
            
            $scope.deletePhoneNumber = function (index) {
                $scope.contact.PhoneNumbers.splice(index, 1);
            };
            
            $scope.addEmailAddress = function () {

                var label = $filter('filter')($scope.labels, { LabelId: $scope.emailAddressSelectedLabelId })[0];

                var emailAddressAdd = {
                    EmailAddressId: 0,
                    Address: $scope.emailAddress,
                    LabelId: label.LabelId,
                    Label: label,
                    ContactId: 0
                };

                var emailAddressAlreadyAdded = $filter('filter')($scope.contact.EmailAddresses, { Address: emailAddressAdd.Address });
                if (emailAddressAlreadyAdded.length) {
                    $rootScope.error = 'Email Address already added...';
                    return;
                }
                $scope.contact.EmailAddresses.push(emailAddressAdd);

                $scope.emailAddress = null;
                $scope.emailAddressSelectedLabelId = $scope.defaultSelectedLabelId;
            };

            $scope.deleteEmailAddress = function (index) {
                $scope.contact.emailAddresses.splice(index, 1);
            };
            
            $scope.addTag = function () {

                var tagAdd = {
                    TagId: 0,
                    Name: $scope.tag,
                    ContactId: 0
                };

                var tagAlreadyAdded = $filter('filter')($scope.contact.Tags, { Name: tagAdd.Name });
                if (tagAlreadyAdded.length) {
                    $rootScope.error = 'Tag already added...';
                    return;
                }
                $scope.contact.Tags.push(tagAdd);

                $scope.tag = null;
            };

            $scope.deleteTag = function (index) {
                $scope.contact.Tags.splice(index, 1);
            };
        }
    ]
);