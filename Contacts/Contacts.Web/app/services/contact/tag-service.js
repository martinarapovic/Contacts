app.factory('tagService', ['$resource', '$q', 'serviceHelper', function ($resource, $q, serviceHelper) {
    var tag = serviceHelper.Tag;

    var getTags = function () {
        return tag.query();
    };

    var deleteTag = function (id) {
        return tag.delete({ tagId: id });
    };

    var addTag = function (item) {
        return tag.save(item);
    };

    var editTag = function (item) {
        return tag.update({ tagId: item.TagId }, item);
    };

    var getTag = function (id) {
        return tag.get({ tagId: id });
    };

    return {
        getTags: getTags,
        getTag: getTag,
        deleteTag: deleteTag,
        addTag: addTag,
        editTag: editTag
    };
}]);