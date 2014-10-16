'use strict';
app.factory('labelService',
    [            '$resource', '$q', 'serviceHelper',
        function ($resource,   $q,   serviceHelper) {
            var label = serviceHelper.Label;

            var getLabels = function () {
                return label.query();
            };

            var deleteLabel = function (id) {
                return label.delete({ labelId: id });
            };

            var addLabel = function (item) {
                return label.save(item);
            };

            var editLabel = function (item) {
                return label.update({ labelId: item.LabelId }, item);
            };

            var getLabel = function (id) {
                return label.get({ labelId: id });
            };

            return {
                getLabels: getLabels,
                getLabel: getLabel,
                deleteLabel: deleteLabel,
                addLabel: addLabel,
                editLabel: editLabel
            };
        }
    ]
);