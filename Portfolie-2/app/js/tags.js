define(['knockout', 'jQuery'], function (ko) {
    tagViewModel = function() {
        var hello = ko.observable('Something new');
        var data = ko.observableArray([]);
        $.getJSON("/api/tags", function (tags) {

            data(tags);
            console.log(tags);
});

        return {
hello: hello,
tags: data
}
//console.log(tags);
};

    return tagViewModel;
})


//var app = app || {};

//app.mainViewModel = function () {
//    this.firstName = "Alexander";
//    this.lastName = "Nima";
//}
//ko.components.register('tags2', {
//    viewModel: {
//        createViewModel: function () {
//            var hello = ko.observable("");
//            var data = ko.observableArray([]);

//            $.getJSON("/api/tags", function (tags) {

//                data(tags.data);
//                console.log(tags);
//            });
//            return {
//                hello: hello,
//                posts: data
//            };
//        }
//        //require: 'app/js/posts.js'     
//    },
//    template: { require: 'Scripts/text!Views/tags.html' }
//});

//ko.components.register('Tags', {
//    viewModel: { require: 'app/js/tags' },
//    template: { require: 'Scripts/text!Views/tags.html' },
//    synchronous: true
//});

//ko.applyBindings(new app.mainViewModel())
////ko.applyBindings(new postViewModel())