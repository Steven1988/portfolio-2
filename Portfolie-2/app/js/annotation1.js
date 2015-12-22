define(['knockout', 'jQuery'], function (ko) {
    favoriteVM = function () {
        var self = this;
        self.PostId = ko.observable();
        self.UserId = ko.observable();
        self.Annotation = ko.observable("");

        self.loadUserData = function () {
            $.getJSON("/api/Favorites/"+self.UserId()+"/"+self.PostId(), function (datas) {

                self.UserId(datas.UserId);
                self.PostId(datas.PostId);
                self.Annotation(datas.Annotation);
            });
        }
        self.saveUserData = function () {

                $.post("api/Favorites/" + self.UserId() + "/" + self.PostId(), function () {
                alert("Your data is saved");
            });
        }

        self.updateUserData = function () {
            $.ajax({
                url: "api/Favorites/"+self.UserId()+"/"+self.PostId(),
                type: "PUT",
                contentType: "application/json",
                data: ko.toJSON(self),
                success: function () {
                alert("Your data is Updated");
        }        
            });
        };

        self.deleteUserData = function () {
            $.ajax({
                url: "api/Favorites/" + self.UserId() +"/"+ self.PostId(), 
                type: "DELETE",
                //dataType: "json",
                contentType: "application/json",
                data: ko.toJSON(self),
                 success: function () {
                    alert("Your data is Deleted");
                }
            });
        };
    }
    return favoriteVM;

});