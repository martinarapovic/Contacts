app.directive('showInfoMessage', function ($timeout) {
    return {
        restrict: 'A',
        link: function (scope, elem, attrs) {
            scope.$watch("info", function (newValue, oldValue) {
                if (newValue != undefined && newValue != oldValue) {
                    var n = noty({ text: newValue, layout: 'bottomRight', type: 'info' });

                    setTimeout(function () {
                        n.close();
                    }, 5000);
                }
            });
        }
    };
});