app.controller('HomeController', ['$scope', 'ContactsService', function ($scope, contactsService) {
    initialize();

    function initialize() {
        loadContacts();
    }

    function loadContacts() {
        $scope.contacts = contactsService.getFiveLatestContacts();
    }
}]);