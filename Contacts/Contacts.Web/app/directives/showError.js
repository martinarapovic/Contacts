app.directive('showErrorMessage',
    [            '$timeout',
        function ($timeout) {
            return {
                restrict: 'A',
                link: function (scope, elem, attrs) {
                    scope.$watch('error', function (newValue, oldValue) {
                        if (newValue != undefined && newValue != oldValue) {
                            var n = noty({ text: newValue, layout: 'bottomRight', type: 'error' });
                    
                            $timeout(function () {
                                n.close();
                            }, 3000);
                        }
                    });
                }
            };
        }
    ]
);