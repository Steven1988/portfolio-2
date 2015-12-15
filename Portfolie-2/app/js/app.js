var app = app || {};

require(['knockout', 'jQuery', 'bootstrap'], function (ko) {

    app.mainViewModel = function () {
    this.firstName = "Alexander";
    this.lastName = "Nima";
        }

    //************ All of our components **************
    ko.components.register('navbarComponent', {
    viewModel: {
        createViewModel: function () {
            var hello = "hello from navbar";

            console.log(hello);
        }
    },
    template: { require: 'Scripts/text!Views/navbar.html' }
});

ko.components.register('posts2', {
    viewModel: {
        createViewModel: function () {
            var hello = ko.observable("hello my");
            var data = ko.observableArray([]);

            $.getJSON("/api/posts", function (posts) {

                data(posts.data);
                console.log(posts);
            });
            return {
                hello: hello,
                posts: data
            };
        }
        //require: 'app/js/posts.js'     
    },
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


    ko.components.register('postDetail', {
        viewModel: { require: 'app/js/postdetail' },
        template: { require: 'Scripts/text!Views/postdetail.html' }
    });


    ko.applyBindings(new app.mainViewModel());
});