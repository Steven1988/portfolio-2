﻿var app = app || {};

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

ko.components.register('saveAnnotation', {
    viewModel: {
        createViewModel: function () {
            
            var datas = function () {
                this.UserId = 1;
                this.PostId = 205064;
                this.annotation = "Please god me help me... Please Please";
            };
            return {
                UserId: UserId,
                PostId: PostId,
                annotation: annotation
            };

            $.post("/api/favorites", datas, function (posts) {
                alert("Your data has been posted to the server!");
                //data(posts.data);
                //console.log(posts);
            });

        }
        //require: 'app/js/posts.js'     
    },
    template: { require: 'Scripts/text!Views/fav.html' }
});

ko.components.register('annotation2', {
    viewModel: {
        createViewModel: function () {
            var UserId = ko.observable("1");
            var PostId = ko.observable("142816");
            var Annotation = ko.observable("Blo Blo Blo Blo");
            var data = ko.observable([]);

            $.post("/api/favorites/" + UserId + "/" + PostId, function (annotation) {

                data(annotation.data);
                console.log(annotation);
            });
            //return {
            //    UserId: UserId,
            //    PostId:PostId,
            //    posts: data
            //};
        }
        //require: 'app/js/posts.js'     
    },
    template: { require: 'Scripts/text!Views/fav.html' }
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