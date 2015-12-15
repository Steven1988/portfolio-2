var app = app || {};

require(['knockout', 'jQuery'], function (ko) {

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

    ko.components.register('tags', {
        viewModel: { require: 'app/js/tags' },
        template: { require: 'Scripts/text!Views/tags.html' }
    });
    //ko.components.register('posts', {
    //    viewModel: {
    //        createViewModel: postVM = function () {
    //            var hello = ko.observable("hello my");
    //            var data = ko.observableArray([]);

    //            $.getJSON("/api/posts", function (posts) {

    //                data(posts.data);
    //                console.log(posts);
    //            });
    //            return {
    //                hello: hello,
    //                posts: data
    //            };
    //        }
    //        //require: 'app/js/posts.js'     
    //    },
    //    template: { require: 'Scripts/text!Views/posts.html' }
    //});

    ko.components.register('postDetail', {
        viewModel: { require: 'app/js/postdetail' },
        template: { require: 'Scripts/text!Views/postdetail.html' }
    });


    ko.applyBindings(new app.mainViewModel());
});