define(['knockout','jQuery', 'moment'], function (ko, moment) {
    searchHistoryVM = function () {

        var hello = ko.observable('Something new');
        var data = ko.observableArray([]);
        
        var sesUserId = 1;
        var sesUserId1 = 443;
        var userId = sesUserId1;
        $.getJSON("api/SearchHistory/" + userId, function (searchHistoryPost) {
            
            data(searchHistoryPost);
            console.log(data);
           
        });
        
        deleteHistory = function () {
            console.log(userId);

            $.ajax({
                url: "api/SearchHistory/" + sesUserId1,
                type: "DELETE",
                
                contentType: "application/json",
                data: ko.toJSON(data),
                success : function(){
                    alert("Your history has been erased.");
                }
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

