define(['knockout', 'jQuery', 'bootstrap'], function (ko) {
    navbarVM = function (params) {

        var menuItems = [
            { mItem: "Search", icon: "fa fa-search" },
            { mItem: "Posts", icon: "fa fa-envelope" },
            { mItem: "Tags", icon: "fa fa-tags" }
        ];
    
        var dropdownMenu = [
            { dropItem: "Your Profile", icon: "fa fa-user" },
            { dropItem: "Favorites", icon: "fa fa-comments" },
        ];

        var currentComponent = params.selectedComponent;
        var mItem = ko.observable();

        showContent = function (mItem) {
            if (mItem == "Search History") {
                mItem = mItem.replace(/\s+/g, '');
            }
            if (mItem == "Your Profile") {
                mItem = mItem.replace(/\s+/g, '');
            }
            name = mItem.toLowerCase();
            currentComponent(name);
            console.log(name);

        }
        return {
            menuItems: menuItems,
            currentComponent: currentComponent,
            showContent: showContent,
            dropdownMenu: dropdownMenu
        }
    }
    return navbarVM;
});