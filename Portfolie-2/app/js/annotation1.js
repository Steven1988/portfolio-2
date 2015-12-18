define(['knockout', 'jQuery'], function (ko) {
    favoriteVM = function () {
        var self = this;
        self.PostId = ko.observable();
        self.UserId = ko.observable();
        self.Annotation = ko.observable("");

        //var sesUserId = 1;
        //sesUserId = self.UserId;

        //var selectedPostId = 124462;
        //selectedPostId = self.PostId;

        self.loadUserData = function () {
            //var data_to_send = ko.toJSON(self);
            //var jObjects = JSON.parse(data_to_send);  
            //var userId = jObjects.UserId;
            //    postId = jObjects.PostId;

        
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