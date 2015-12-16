define(['knockout','jQuery', 'moment'], function (ko, moment) {
    searchHistoryVM = function () {

        var hello = ko.observable('Something new');
        var data = ko.observableArray([]);
        
        var sesUserId = 1;
        var sesUserId1 = 102;
        var userId = sesUserId1;
        $.getJSON("api/SearchHistory/" + userId, function (searchHistoryPost) {
            
            data(searchHistoryPost);
            console.log(searchHistoryPost);
           
        });
        
        deletehistory = function (userId) {
            console.log(userId);

            $.ajax({
                url: "api/SearchHistory/" + userId,
                type: "DELETE",
                dataType: "json",
                contentType: "application/json",
                data: ko.toJSON(data)
            });

        }

        return {
            hello: hello,
            searchHistoryPost: data,
            sesUserId: sesUserId
        }
        //console.log(posts);
    };

    return searchHistoryVM;
})

