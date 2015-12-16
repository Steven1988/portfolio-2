define(['knockout', 'jQuery'], function (ko) {
    favoriteVM = function () {
        var self = this;
        self.MyName = "Nima";

        self.PostId = ko.observable();
        self.UserId = ko.observable();
        self.Annotation = ko.observable("");
        

        var data = ko.observableArray([]);
        $.getJSON("/api/favorites/" + UserId + "/" + PostId, function (fav) {
           
            data(fav.data);
            console.log(data);
        });
        return {
            data: data,
            PostId: PostId,
            UserId: UserId,
            Annotation : Annotation
        }
    }
    return favoriteVM;

});