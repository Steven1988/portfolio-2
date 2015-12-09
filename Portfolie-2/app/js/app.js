var app = app || {};

app.mainViewModel = function () {
    this.firstName = "Alexander";
    this.lastName = "Nima";

}

ko.components.register('posts', {
    viewModel: { require: 'app/js/posts' },
    template: { require: 'Scripts/text!Views/posts.html' },
    synchronous: true
});

ko.components.register('postDetail', {
    viewModel: { require: 'app/js/postdetail' },
    template: { require: 'Scripts/text!Views/postdetail.html' },
    synchronous: true
});

ko.components.register('Tags', {
    viewModel: { require: 'app/js/tags' },
    template: { require: 'Scripts/text!Views/tags.html' },
    synchronous: true
});

ko.applyBindings(new app.mainViewModel())