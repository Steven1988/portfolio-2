define(['knockout', 'jQuery'], function (ko) {
    userVM = function (params) {
        var data = ko.observableArray([]);
        var sesUser = params.sesUser;

        console.log(sesUser().Id);
        $.getJSON("api/SearchHistory/" + sesUser().Id, function (searchHistoryPost) {

            data(searchHistoryPost);
            console.log(searchHistoryPost);

        });


        deleteHistory = function () {
            $.ajax({
                url: "api/SearchHistory/" + sesUser().Id,
                type: "DELETE",
                contentType: "application/json",
                data: ko.toJSON(data),
                success: function () {
                    alert("Your history has been erased.");
                }
            });

        }

        return {
            searchHistoryPost: data,
            sesUser: sesUser
        }
        //console.log(posts);
    };
    return userVM;
})