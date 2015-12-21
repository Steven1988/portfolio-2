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
            console.log(posts);
            console.log(posts.data[2].Body);
        });

        //truncateText http://jsfiddle.net/bZEQM/31/
        ko.bindingHandlers.truncatedText = {
            update: function (element, valueAccessor, allBindingsAccessor) {
                var originalText = ko.utils.unwrapObservable(valueAccessor()),
                    // 10 is a default maximum length
                    length = ko.utils.unwrapObservable(allBindingsAccessor().maxTextLength) || 20,
                    truncatedText = originalText.length > length ? originalText.substring(0, length) + "..." : originalText;
                //$(element).html(truncatedText);
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