var app = app || {};

app.mainViewModel = function () {
    this.firstName = "Alexander";
    this.lastName = "Nima";
}

ko.components.register('postDetail', {
    viewModel: { require: 'app/js/postdetail' },
    template: { require: 'Scripts/text!Views/postdetail.html' },
    synchronous: true
});

ko.applyBindings(new app.mainViewModel())