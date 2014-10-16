'use strict';
app.directive('myModal',
    [
        function() {
            return {
                required: 'ngModel',
                restrict: 'A',
                link: function(scope, element, attrs, ngModelCtrl) {
                    element.on('click', function(e) {
                        var modalId = '#' + attrs.myModal;
                        $(modalId).modal('show');
                    });
                }
            };
        }
    ]
);