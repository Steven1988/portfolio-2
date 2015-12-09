var app = app || {};

app.mainViewModel = function () {
    this.firstName = "Alexander";
    this.lastName = "Nima";
}


ko.components.register('postDetail', {
    viewModel: { require: 'postdetail.js' },
    template: { require: '../../Views/postdetail.html' }
});

ko.applyBindings(new app.mainViewModel())