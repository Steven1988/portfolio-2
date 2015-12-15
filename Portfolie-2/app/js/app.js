var app = app || {};

require(['knockout','jQuery'], function (ko) {

    app.mainViewModel = function () {

        var currentComponent = ko.observable("posts");

        return {
            currentComponent: currentComponent,
            //change: function () {
            //    this.currentComponent("postDetail")
            //}
        }
    }

    //************ All of our components **************
    ko.components.register('navbarComponent', {
        viewModel: { require: 'app/js/navbar' },
        template: { require: 'Scripts/text!Views/navbar.html' }
    });

    ko.components.register('posts', {
        viewModel: { require: 'app/js/posts' },
        template: { require: 'Scripts/text!Views/posts.html' }
    });

    ko.components.register('postDetail', {
        viewModel: { require: 'app/js/postdetail' },
        template: { require: 'Scripts/text!Views/postdetail.html' }
    });


    ko.applyBindings(new app.mainViewModel());
});