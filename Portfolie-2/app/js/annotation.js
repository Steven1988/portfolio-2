define(['knockout', 'jQuery'], function (ko) {
    favoriteVM = function () {
        this.MyName = "Nima";

        var PostId = 105568;
        var UserId = 1;
        var Anotation = "Something is not awsome";

        var data = ko.observableArray([]);
        $.getJSON("/api/posts/" + UserId + "/" +PostId, function (fav) {
            data(fav.data);
            console.log(data);
        });
        return {
            data: data
        }
    }
    return favoriteVM;
});