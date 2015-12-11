define(['Scripts/knockout-3.4.0'], function (ko) {
    //postViewModel = function() {
      
    //    var data = ko.observableArray([]);
    //    $.getJSON("/api/posts", function (posts) {
            
    //        data(posts);
    //        console.log(posts);
    //    });
        
    //    return {
    //        hello: "hello",
    //        posts: data
    //    }
    //    //console.log(posts);

    //};

    //return postViewModel;

    function X() {
        var hello = ko.observable('uuyutuy');
        var data = ko.observableArray(['a', 'b', 'c']);

        $.getJSON("/api/posts", function (posts) {
            
            data(posts.data);
                    console.log(posts);
                });

        return {
            hello: hello,
            posts: data
        }
        
    }

    return X;
})

