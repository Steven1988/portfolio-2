define(['knockout','jQuery'], function (ko) {
    postViewModel = function() {
        var hello = ko.observable('Something new');
        var data = ko.observableArray([]);
        $.getJSON("/api/posts", function (posts) {
            
            data(posts.data);
            console.log(posts);
        });
        
        return {
            hello: hello,
            posts: data
        }
        //console.log(posts);
    };

    return postViewModel;
})

