define(['knockout', 'jQuery'], function (ko) {
    navbarVM = function (params) {
        var menuItems =
            [{ mItem: "posts" },
            { mItem: "tags" },
            { mItem: "postDetail" }];


        var currentComponent = params.selectedComponent;
        var mItem = ko.observable();

        showContent = function (mItem) {
            currentComponent(mItem);
            console.log(mItem);
        }
        return {
            menuItems: menuItems,
            currentComponent: currentComponent,
            showContent: showContent
        }
    }
    return navbarVM;
});