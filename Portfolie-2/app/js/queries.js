define(['knockout','jQuery'], function (ko) {
    SearchHistoryViewModel = function() {
        var hello = ko.observable('Something new');
        var data = ko.observableArray([]);
        var userId = 1;
        $.getJSON("api/SearchHistory/" + userId, function (searchHistoryPost) {
            
            data(searchHistoryPost.data);
            console.log(searchHistoryPost);
        });
        
        return {
            hello: hello,
            searchHistoryPost: data
        }
        //console.log(posts);
    };

    return SearchHistoryViewModel;
})

