define(['knockout','jQuery','bootstrap'], function (ko) {
    postViewModel = function (params) {
        vm = this;
        var data = ko.observableArray([]);
        var page = ko.observable();
        var currentPostId = params.selectedPostId;

        $.getJSON("/api/posts", function (posts) {

            data(posts.data);
            //console.log(posts);

            page(posts.paging);
            console.log(posts.paging);
        });

        //******* Paging ********
        nextPage = function (nextUrl) {
            $.getJSON(nextUrl, function (posts) {
                data(posts.data);
                page(posts.paging);
            });
        }
        prevPage = function (prevUrl) {
            $.getJSON(prevUrl, function (posts) {
                data(posts.data);
                page(posts.paging);
            });
        }
        //var summary = 50;
        //console.log(posts.Body);


        return {
            posts: data,
            page: page,
            goToPost: params.goToPostDetail,
            currentPostId: currentPostId
        }
    };
    return postViewModel;
})

