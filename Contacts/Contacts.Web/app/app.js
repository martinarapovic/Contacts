var app = angular.module('ContactsApp', ['ngRoute', 'ngResource', 'ngAnimate', 'ui.select2', 'ngTable']);

app.config(['$routeProvider', '$locationProvider', '$httpProvider', function ($routeProvider, $locationProvider, $httpProvider) {
    delete $httpProvider.defaults.headers.common["X-Requested-With"];
    //$httpProvider.defaults.headers.common["Accept"] = "application/json";
    //$httpProvider.defaults.headers.common["Content-Type"] = "application/json";
    
    $locationProvider.html5Mode(true);
    
    $routeProvider
        .when('/home', { templateUrl: '/app/views/home/Home.html', controller: 'HomeController' })
        .when('/contacts', { templateUrl: '/app/views/contacts/Contacts.html', controller: 'ContactsController' })
        .when('/contacts/add', { templateUrl: '/app/views/contacts/Add.html', controller: 'ContactsController' })
        .when('/contacts/edit/:contactId', { templateUrl: '/app/views/contacts/Edit.html', controller: 'ContactsController' })
        .when('/error', { templateUrl: '/app/views/shared/Error.html' })
        .otherwise({
            redirectTo: '/home'
        });
    
}]);