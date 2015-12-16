var app = app || {};

require(['knockout', 'jQuery', 'bootstrap'], function (ko) {

    app.mainViewModel = function () {
        mainVM = this;
        var currentComponent = ko.observable("search");

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

    ko.components.register('tags', {
        viewModel: { require: 'app/js/tags' },
        template: { require: 'Scripts/text!Views/tags.html' }
    });

    ko.components.register('searchHistoryPost', {
        viewModel: { require: 'app/js/queries' },
        template: { require: 'Scripts/text!Views/history.html' }
    });

    ko.components.register('postdetail', {
        viewModel: { require: 'app/js/postdetail' },
        template: { require: 'Scripts/text!Views/postdetail.html' }
    });

    ko.components.register('search', {
        viewModel: { require: 'app/js/search' },
        template: { require: 'Scripts/text!Views/search.html' }
    });


    ko.applyBindings(new app.mainViewModel());
});