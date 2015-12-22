define(['knockout', 'jQuery'], function (ko) {
    userVM = function (params) {
        var data = ko.observableArray([]);
        var data = ko.observableArray([]);

        var sesUser = params.sesUser;

        console.log(sesUser().Id);
        $.getJSON("api/SearchHistory/" + sesUser().Id, function (searchHistoryPost) {
            data(searchHistoryPost);
            console.log(searchHistoryPost);
        });

        // ****** Not implemented the rigth way *******
        $.getJSON("api/Favorites", function (allFav) {
            for (var i; i < allFav.length; i++) {
                if (allFav.UserId == sesUser().Id) {
                    console.log("Im in the IF. :D");
                }
                console.log(i);
            }
            console.log(sesUser().Id)
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
    };
    return userVM;
})