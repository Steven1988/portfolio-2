var app = app || {};

app.mainViewModel = function () {
    this.firstName = "Alexander";
    this.lastName = "Nima";
}


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

ko.components.register('annotation2', {
    viewModel: {
        createViewModel: function () {
            var UserId = 1;
            var PostId = 142816;
            var Annotation = ko.observable("");
            var data = ko.observable([]);

            $.getJSON("/api/favorites/" + UserId + "/" + PostId, function (annotation) {

                data(annotation.data);
                console.log(annotation);
            });
            return {
                UserId: UserId,
                PostId:PostId,
                posts: data
            };
        }
        //require: 'app/js/posts.js'     
    },
    template: { require: 'Scripts/text!Views/annotation.html' }
});

ko.components.register('postDetail', {
    viewModel: {
        createViewModel: function () {

            var hello = ko.observable("New hello in PD")
            var data = ko.observableArray([]);
            var id = 105568;

            $.getJSON("/api/posts/" + id, function (pd) {
                data(pd.data);
                console.log(pd.data);
            });
            return {
                hello: hello,
                data: data
            };
        }
    },
    template: { require: 'Scripts/text!Views/postdetail.html' }
});

ko.components.register('Tags', {
    viewModel: { require: 'app/js/tags' },
    template: { require: 'Scripts/text!Views/tags.html' },
    synchronous: true
});


ko.applyBindings(new app.mainViewModel())
//ko.applyBindings(new postViewModel())