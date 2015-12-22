define(['knockout','jQuery','bootstrap'], function (ko) {
    postViewModel = function (params) {
        vm = this;
        var data = ko.observableArray([]);
        var page = ko.observable();
        var currentPostId = params.selectedPostId;

        $.getJSON("/api/posts", function (posts) {
            data(posts.data);
            page(posts.paging);
            //console.log(posts);
        });

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

        //******* Paging ********
        nextPage = function (nextUrl) {
            $.getJSON(nextUrl, function (posts) {
                data(posts.data);
                page(posts.paging);
                window.scrollTo(0, 0);
            });
        }
        prevPage = function (prevUrl) {
            $.getJSON(prevUrl, function (posts) {
                data(posts.data);
                page(posts.paging);
            });
        }

        closeAdvert = function () {
            $('.advert').hide();
        }

        return {
            posts: data,
            page: page,
            goToPost: params.goToPostDetail,
            currentPostId: currentPostId
        }
    };

    return postViewModel;
})