'use strict';
var app = angular.module('contactsApp',
    [
        'ngRoute',
        'ngResource',
        'ngAnimate',
        'ui.select2'
    ]
);

app.constant('appConfig', {
    webApiBaseUrl : 'http://localhost:57355/',
    webSiteBaseUrl: 'http://localhost:60673/'
});

app.config(
    [            '$routeProvider', '$locationProvider', '$httpProvider',
        function ($routeProvider,   $locationProvider,   $httpProvider) {
            delete $httpProvider.defaults.headers.common["X-Requested-With"];
            //$httpProvider.defaults.headers.common["Accept"] = "application/json";
            //$httpProvider.defaults.headers.common["Content-Type"] = "application/json";
    
            $routeProvider
                .when('/', { templateUrl: '/app/views/home/Home.html', controller: 'homeController' })
                .when('/contacts', { templateUrl: '/app/views/contact/Contacts.html', controller: 'contactsController' })
                .when('/contacts/add', { templateUrl: '/app/views/contact/Contact.html', controller: 'contactController' })
                .when('/contacts/edit/:contactId', { templateUrl: '/app/views/contact/Contact.html', controller: 'contactController' })
                .when('/error', { templateUrl: '/app/views/shared/Error.html' })
                .otherwise({
                    redirectTo: '/'
                });
    
            $locationProvider.html5Mode(true);

        }
    ]
);