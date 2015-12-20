define(['knockout', 'jQuery'], function (ko) {
    postdetailVM = function (params) {
        var self = this;
        var currentPostId = params.selectedPost;
        //console.log(currentPostId());

        var highlight = ko.observable();

        //**** input data to database ****
        //self.anno = ko.observable();

        self.sesUserId = 1;
        self.id = 28894151;
        var data = ko.observableArray([]);
        var anno = ko.observable();
        if (self.sesUserId != "") {
            $.getJSON("/api/posts/" + self.id + "/" + self.sesUserId, function (pd) {
                data(pd.data);
                console.log(pd.data);
                //console.log("with sesUserId" + sesUserId); 
                //anno(pd.FavoriteInstance.Annotation);
                //console.log(anno());
            });
        } else {
            $.getJSON("/api/posts/" + self.id, function (pd) {
                data(pd.data);
                console.log(pd.data);
               
            });
        }
        

        saveAnno = function (anno) {
            var favObj = {
                UserId: self.sesUserId,
                PostId: self.id,
                Annotation: anno
            }
            console.log(favObj);
            $.post("api/Favorites/" + favObj.UserId + "/" + favObj.PostId, favObj, function (Annotation) {
                console.log("Your data is saved" + favObj.Annotation);
                window.location.reload(true);
                
            });
        }
        updateFav = function (anno) {
            var favObj = {
                UserId: self.sesUserId,
                PostId: self.id,
                Annotation: anno
            }
            $.ajax({
                url: "api/Favorites/" + favObj.UserId + "/" + favObj.PostId,
                type : "PUT",
                contentType: "application/json",
                data: ko.toJSON(favObj),
                success: function () {
                    console.log(favObj);
                    console.log("Your data is Updated");
                }
             });
        }

        deleteFav = function () {
            $.ajax({
                url: "api/Favorites/" + self.sesUserId + "/" + self.id,
                type: "DELETE",
                //dataType: "json",
                contentType: "application/json",
                data: ko.toJSON(self),
                success: function () {
                    //window.location.reload(true);
                    console.log("Your data is Deleted");
                    self.anno = "";    
                }
            });
            
        }

        self.saveUserData = function () {
            $.post("api/Favorites/" +self.UserId() + "/" +self.PostId(), function () {
                alert("Your data is saved");
        });
        }

        toggleInput = function () {
            highlight(!highlight());
            console.log("toggle is clicked");
        };

        return {
            data: data,
            currentPostId: currentPostId,
            highlight: highlight
            //anno: anno
        }
    }
    return postdetailVM;
});