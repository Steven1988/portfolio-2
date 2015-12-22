define(['knockout', 'jQuery'], function (ko) {
    searchVM = function (params) {

        var searchItem = ko.observable("");
        var data = ko.observableArray([]);
        var page = ko.observable();

        var sesUser = params.sesUser;
        if (sesUser() == null) {
            sesUserId = "";
        } else {
            sesUserId = sesUser().Id;
        }    
        var currentPostId = params.selectedPostId;

        getResult = function (searchItem) {
            var searchString = ko.toJS(searchItem);

            if (sesUserId != "") {
                $.getJSON('api/search/' +searchString + "/" + sesUserId, function(searchPosts) {
                    data(searchPosts.data);
                    page(searchPosts.paging);
                });
            }
            else {
                $.getJSON('api/search/' +searchString, function (searchPosts) {
                    data(searchPosts.data);
                    page(searchPosts.paging);
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

        closeAdvert = function () {
            $('.advert').hide();
        }

        //truncateText http://jsfiddle.net/bZEQM/31/
        ko.bindingHandlers.truncatedText = {
            update: function (element, valueAccessor, allBindingsAccessor) {
                var originalText = ko.utils.unwrapObservable(valueAccessor()),

                    length = ko.utils.unwrapObservable(allBindingsAccessor().maxTextLength) || 20,
                    truncatedText = originalText.length > length ? originalText.substring(0, length) + "..." : originalText;
                // updating text binding handler to show truncatedText
                ko.bindingHandlers.html.update(element, function () {
                    return truncatedText;
                });
            }
        };

        return {
            searchPosts: data,
            page: page,
            searchItem: searchItem,
            sesUserId: sesUserId,
            goToPost: params.goToPostDetail,
            closeAdvert: closeAdvert
        }
    }
   
    return searchVM;
});