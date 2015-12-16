define(['knockout','jQuery','bootstrap'], function (ko) {
    postViewModel = function () {
        var data = ko.observableArray([]);
        var page = ko.observable();
        $.getJSON("/api/posts", function (posts) {

            data(posts.data);
            //console.log(posts);

            console.log(posts.data[0].Body);

            page(posts.paging);
            console.log(posts.paging);
        });

        var summary = 50;
        //console.log(posts.Body);
        //if (data.posts.Body) 

        goToPost = function () {
            //do somthing
        }

        return {
            posts: data,
            page: page
        }
    } ;
    return postViewModel;
})

