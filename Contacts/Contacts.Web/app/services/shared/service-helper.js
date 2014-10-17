'use strict';
app.factory('serviceHelper',
    [            'appConfig', '$http', '$resource',
        function (appConfig,   $http,   $resource) {
            var baseUrl = appConfig.webApiBaseUrl;
            var createUrl = function(resourceUrl) {
                return baseUrl + resourceUrl;
            };

            var getContactResource = function () {
                return $resource(createUrl('api/contacts/:contactId'), {
                        contactId: '@Id'
                    }, {
                        'update': {
                             method: 'PUT'
                        },
                        'get': {
                            method: 'GET',
                            isArray: false
                        },
                        getPaged: {
                            url: createUrl("api/contacts?count=:count&page=:page&sortField=:sortField&sortOrder=:sortOrder"),
                            method: 'GET',
                            isArray: true,
                            params: {
                                count: '@count',
                                page: '@page',
                                sortField: '@sortField',
                                sortOrder: '@sortOrder'
                            }
                        },
                        getFiltered: {
                            url: createUrl("api/contacts/search/:condition"),
                            method: 'GET',
                            isArray: true,
                            //params: {
                                condition: '@condition'
                            //}
                        }
                    });
            };

            var getEmailAddressResource = function () {
                return $resource(createUrl('api/emailaddresses/:emailId'), {
                     emailId: '@Id'
                }, {
                    'update': {
                        method: 'PUT'
                    },
                    'get': {
                        method: 'GET',
                        isArray: false
                    }
                });
            };
    
            var getLabelResource = function () {
                return $resource(createUrl('api/labels/:labelId'), {
                     labelId: '@Id'
                }, {
                    'update': {
                        method: 'PUT'
                    },
                    'get': {
                        method: 'GET',
                        isArray: false
                    },
                    'query': {
                        method: 'GET',
                        isArray: true
                    }
                });
            };
    
            var getPhoneNumberResource = function () {
                return $resource(createUrl('api/phonenumbers/:phoneNumberId'), {
                    phoneNumberId: '@Id'
                }, {
                    'update': {
                        method: 'PUT'
                    },
                    'get': {
                        method: 'GET',
                        isArray: false
                    }
                });
            };


            var getTagResource = function () {
                return $resource(createUrl('api/tags/:tagId'), {
                    tagId: '@Id'
                }, {
                    'update': {
                        method: 'PUT'
                    },
                    'get': {
                        method: 'GET',
                        isArray: false
                    }
                });
            };

    
            return {
                Contact: getContactResource(),
                EmailAddress: getEmailAddressResource(),
                Label: getLabelResource(),
                PhoneNumber: getPhoneNumberResource(),
                Tag: getTagResource()
            };
        }
    ]
);