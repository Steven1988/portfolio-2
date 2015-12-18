define(['knockout', 'jQuery', 'bootstrap'], function (ko) {
    navbarVM = function (params) {

        var menuItems = [
            { mItem: "Search", icon: "<i class='fa fa-search'></i>" },
            { mItem: "Posts", icon: "<i class='fa fa-envelope'></i>" },
            { mItem: "Tags", icon: "<i class='fa fa-tags'></i>" },
            { mItem: "Postdetail", icon: "<i class='fa fa-asterisk'></i>" }
        ];
    
        var dropdownMenu = [
            { dropItem: "Favorites", icon: "fa-comments" },
            { dropItem: "Search History", icon: "fa-comments" }
        ];

        var currentComponent = params.selectedComponent;
        var mItem = ko.observable();

        showContent = function (mItem) {
            if (mItem == "Search History") {
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