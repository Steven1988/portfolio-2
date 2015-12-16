define(['knockout', 'jQuery'], function (ko) {
    favoriteVM = function () {
        var self = this;
        self.PostId = ko.observable();
        self.UserId = ko.observable();
        self.Annotation = ko.observable("");

        self.loadUserData = function () {
            $.getJSON("/api/Favorites/255/124462", function (datas) {
                
                self.UserId(datas.UserId);
                self.PostId(datas.PostId);
                console.log(datas.UserId);
                
                self.Annotation(datas.Annotation);
            });
        }

        self.saveUserData = function () {

            var userId = self.UserId,
                postId = self.PostId,
                anno = this.Annotation;

            var data_to_send = { userData: ko.toJSON(self) };
            //alert(ko.toJSON(self));
            console.log(this.Annotation);
            $.post("api/Favorites/" + UserId + "/" + PostId + "/" + Annotation, function () {
                // alert("Your data is saved");
                console.log("Your data is saved")
            });
        }

        self.updateUserData = function () {
            $.ajax({
                url: "api/Favorites/" + UserId,
                type: "DELETE",
                dataType: "json",
                contentType: "application/json",
                data: ko.toJSON(self),
            });
        };

        self.deleteUserData = function () {
            $.ajax({
                url: "api/Favorites/" + UserId + PostId,
                type: "DELETE",
                dataType: "json",
                contentType: "application/json",
                data: ko.toJSON(self),


            });
        };

    }
    return favoriteVM;

});