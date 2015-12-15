define(['knockout', 'jQuery','bootstrap'], function (ko) {
    navbarVM = function (params) {
        var menuItems = [
            { mItem: "Posts" },
            { mItem: "Tags" },
            { mItem: "Postdetail" }
        ];

        var dropdownMenu = [
            { dropItem: "Favorites", icon: "fa-comments" },
            { dropItem: "Search History", icon: "fa-comments" }
        ];

        var currentComponent = params.selectedComponent;
        var mItem = ko.observable();

        showContent = function (mItem) {
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