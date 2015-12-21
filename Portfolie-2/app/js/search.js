define(['knockout', 'jQuery'], function (ko) {
    searchVM = function (params) {
        vm = this;
        var searchItem = ko.observable("");
        var data = ko.observableArray([]);
        var page = ko.observable();

        var sesUser = params.sesUser;
        sesUserId = sesUser().Id;
        var currentPostId = params.selectedPostId;

        getResult = function (searchItem) {
            var searchString = ko.toJS(searchItem);

            if (sesUserId != "") {
                $.getJSON('api/search/' +searchString + "/" + sesUserId, function(searchPosts) {
                    data(searchPosts.data);
                    page(searchPosts.paging);
                    console.log(searchPosts);
                });
            }
            else {
                $.getJSON('api/search/' +searchString, function (searchPosts) {
                    data(searchPosts.data)
                    console.log(searchPosts);
                });
            }

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

            return searchItem;
        }
        return {
            searchPosts: data,
            page: page,
            searchItem: searchItem,
            sesUserId: sesUserId,
            goToPost: params.goToPostDetail
        }
    }
   
    return searchVM;
});