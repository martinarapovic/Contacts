'use strict';
app.directive('myMenu', 
    [
        function () {
            return {
                restrict: 'E',
                replace: true,
                templateUrl: '/app/partials/menu.html',
                link: function (scope, element, attrs) {
                    var menuItems = element.find("a");
                    menuItems.on('click', function () {
                        menuItems.removeClass('active');
                        $(this).addClass('active');
                    });
                    
                }
            };
        }
    ]
);