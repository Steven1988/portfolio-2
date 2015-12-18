define(['knockout','jQuery','bootstrap'], function (ko) {
    postViewModel = function (params) {
        vm = this;
        var data = ko.observableArray([]);
        var page = ko.observable();
        var currentPostId = params.selectedPostId

        $.getJSON("/api/posts", function (posts) {

            data(posts.data);
            //console.log(posts);

            //console.log(posts.data[0].Body);

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

        //******** functions *********
        //goToPost = function (Id) {
        //    currentPostId(Id);
        //    console.log(currentPostId);


        //    currentComponent('postdetail');
        //    ko.navbarVM().showContent('postdetail')
        //    ko.components.get('postdetail', ko.postdetailVM(Id));

        //    postdetailVM(Id)
        //    $.getJSON(Url, function (posts) {
        //        data(posts.data);
        //    })
        //    return data;
        //}

        return {
            posts: data,
            page: page,
            goToPost: params.goToPostDetail,
            currentPostId: currentPostId
        }
    };
    return postViewModel;
})

