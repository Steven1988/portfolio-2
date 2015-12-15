var app = app || {};

app.mainViewModel = function () {

    var currentComponent = ko.observable("posts");

    return {
        currentComponent: currentComponent,
        //change: function () {
        //    this.currentComponent("postDetail")
        //}
    }
}


ko.components.register('navbarComponent', {
    viewModel: {
        createViewModel: navbarVM = function (params) {
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
    },
    template: { require: 'Scripts/text!Views/navbar.html' }
});

ko.components.register('posts', {
    viewModel: {
        createViewModel: postVM = function () {
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