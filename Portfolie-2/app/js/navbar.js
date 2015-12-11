define(['Scripts/knockout-3.4.0'], function(ko) {
    var viewModel = {
        message: ko.observable("Hello world!")
    };

    $(function() {
        ko.applyBinding(viewModel);
    });
        
    //return postViewModel;

    //function X() {
    //    var hello = ko.observable('uuyutuy');
    //    var data = ko.observableArray(['a', 'b', 'c']);

    //    $.getJSON("/api/posts", function (posts) {
            
    //        data(posts.data);
    //                console.log(posts);
    //            });

    //    return {
    //        hello: hello,
    //        posts: data
    //    }
        
    //}

    //return X;
})

