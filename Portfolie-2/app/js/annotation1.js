define(['knockout', 'jQuery'], function (ko) {
    favoriteVM = function () {
        var self = this;
        self.PostId = ko.observable();
        self.UserId = ko.observable();
        self.Annotation = ko.observable("");

        var sesUserId = 1;
        sesUserId = self.UserId;

        var selectedPostId = 124462;
        selectedPostId = self.PostId;

        self.loadUserData = function (UserId, PostId) {
            var data_to_send = ko.toJSON(self);
            //console.log(data_to_send);

          
            var jObjects = JSON.parse(data_to_send);
            //console.log(jObjects);

            //var userId = jObjects.UserId;
            //    postId = jObjects.PostId;

            console.log(UserId)
            var userId = UserId,
                postId = PostId;
           
           
            //console.log(jObjects.UserId);
        
            $.getJSON("/api/Favorites/"+userId+"/"+postId, function (datas) {

                self.UserId(datas.UserId);
                self.PostId(datas.PostId);
                self.Annotation(datas.Annotation);
            });
        }
        self.saveUserData = function (UserId, PostId) {

            var data_to_send = ko.toJSON(self);
            var jObjects = JSON.parse(data_to_send);
                //console.log(jObjects);
            var userId = jObjects.UserId;
                postId = jObjects.PostId;
                $.post("api/Favorites/" + userId + "/" + postId, jObjects, function () {
                alert("Your data is saved");
                //console.log("Your data is saved")
            });
        }

        self.updateUserData = function () {

            var data_to_send = ko.toJSON(self);
            var jObjects = JSON.parse(data_to_send);
            var userId = jObjects.UserId;
                postId = jObjects.PostId;

            $.ajax({
                url: "api/Favorites/"+userId+"/"+postId, jObjects,
                type: "PUT",
               // dataType: "json",
                contentType: "application/json",
                data: ko.toJSON(self),
                success: function () {
                alert("Your data is Updated");
        }        
            });
        };

        self.deleteUserData = function () {
            var data_to_send = ko.toJSON(self);
            var jObjects = JSON.parse(data_to_send);
            var userId = jObjects.UserId;
                postId = jObjects.PostId;

            $.ajax({
                url: "api/Favorites/" + userId +"/"+ postId, 
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