'use strict';
app.directive("myModalConfirm",
    [
        function () {
            return {
                restrict: "A",
                scope: {
                    confirm: '&onConfirm',
                    cancel: '&onCancel',
                    closable: '=closable',
                    id: '@modalId',
                    title: '@title',
                    message: '@message'
                },
                templateUrl: "/app/partials/modalConfirm.html",
                link: function (scope, element, attrs, ngModelCtrl) {

                    scope.closeModal = function () {
                        angular.element('#' + scope.id).modal('hide');
                    };

                    element.on('click', function (e) {
                        angular.element('#' + scope.id).modal('show');
                    });
                }
            };
        }
    ]
);