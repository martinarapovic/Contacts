app.factory('ServiceHelper', ['$http', '$resource', function($http, $resource) {
    var baseUrl = config.webApiBaseUrl;
    var createUrl = function(resourceUrl) {
        return baseUrl + resourceUrl;
    };

    var getCustomerResource = function() {
        return $resource(createUrl('api/contacts/:customerId'), {
                customerId: '@Id'
            }, {
                'update': {
                     method: 'PUT'
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
                }
            });
    };

    var getEmailAddressResource = new function () {
        return $resource(createUrl('api/emailaddresses/:emailId'), { emailId: '@Id' });
    };
    
    var getLabelResource = new function () {
        return $resource(createUrl('api/labels/:labelId'), { labelId: '@Id' }, { 'update': { method: 'PUT' } });
    };
    
    var getPhoneNumberResource = new function () {
        return $resource(createUrl('api/phonenumbers/:phoneNumberId'), { phoneNumberId: '@Id' }, { 'update': { method: 'PUT' } });
    };


    var getTagResource = function () {
        return $resource(createUrl('api/tags/:tagId'), { tagId: '@Id' }, { 'update': { method: 'PUT' } });
    };

    
    return {
        Contact: getCustomerResource(),
        EmailAddress: getEmailAddressResource(),
        Label: getLabelResource(),
        PhoneNumber: getPhoneNumberResource(),
        Tag: getTagResource()
    };
}]);