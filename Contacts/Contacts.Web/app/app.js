var app = angular.module('contactsApp', ['ngRoute', 'ngResource', 'ngAnimate', 'ui.select2', 'ngTable']);

app.config(['$routeProvider', '$locationProvider', '$httpProvider', function ($routeProvider, $locationProvider, $httpProvider) {
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
    $httpProvider.defaults.useXDomain = true;
    
    $locationProvider.html5Mode(true);
    
    $routeProvider
        .when('/Home', { templateUrl: '/app/views/home/Home.html', controller: 'HomeController' })
        .when('/Contacts', { templateUrl: '/app/views/contacts/Contacts.html', controller: 'ContactsController' })
        .when('/Error', { templateUrl: '/app/views/shared/Error.html' })
        .otherwise({
            redirectTo: '/Home'
        });
    
}]);