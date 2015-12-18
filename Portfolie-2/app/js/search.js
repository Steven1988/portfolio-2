define(['knockout', 'jQuery'], function (ko) {
    searchVM = function (params) {
        vm = this;
        var searchItem = ko.observable("");
        var data = ko.observableArray([]);
        var sessionUserId = ko.observable("1");
        var currentPostId = params.selectedPostId;

        //Tagname = searchItem;

        getResult = function (searchItem, sessionUserId) {
            var searchString = ko.toJS(searchItem);
            var sesUserId = ko.toJS(sessionUserId);
            //console.log(searchString);
            if (sesUserId != "") {
                $.getJSON('api/search/' +searchString + "/" + sesUserId, function(searchPosts) {
                    data(searchPosts.data)
                    console.log(searchPosts);
                });
            }
            else {
                $.getJSON('api/search/' +searchString, function (searchPosts) {
                    data(searchPosts.data)
                    console.log(searchPosts);
                });
            }

            return searchItem;
        }
        return {
            searchPosts: data,
            searchItem: searchItem,
            sesUserId: sessionUserId,
            goToPost: params.goToPostDetail
        }
    }
   
    return searchVM;
});