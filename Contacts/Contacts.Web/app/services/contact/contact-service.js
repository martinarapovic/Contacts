app.factory('contactService', ['$resource', '$q', 'serviceHelper', function ($resource, $q, serviceHelper) {
    var contact = serviceHelper.Contact;

    var getFiveLatestContacts = function () {
        return contact.query({ count: 5 });
    };

    var getContacts = function () {
        return contact.query();
    };

    var getContactsPaged = function (params) {
        return contact.getPaged(params);
    };

    var deleteContact = function (contactId) {
        return contact.delete({ contactId: contactId });
    };

    var addContact = function (item) {
        return contact.save(item);
    };

    var editContact = function (item) {
        return contact.update({ contactId: item.ContactId }, item);
    };

    var getContact = function (id) {
        return contact.get({ contactId: id });
    };
    

    return {
        getFiveLatestContacts: getFiveLatestContacts,
        getContacts: getContacts,
        getContactsPaged: getContactsPaged,
        getContact: getContact,
        deleteContact: deleteContact,
        addContact: addContact,
        editContact: editContact
    };
}]);