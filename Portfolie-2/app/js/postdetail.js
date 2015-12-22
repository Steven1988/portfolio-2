define(['knockout', 'jQuery'], function (ko) {
    postdetailVM = function (params) {
        var self = this;
        var currentPostId = params.selectedPost;

        var sesUser = params.sesUser;
        sesUserId = sesUser().Id;

        var data = ko.observableArray([]);
        var anno = ko.observable();

        function trimfield(str) {
            return str.replace(/^\s+|\s+$/g, '');
        }

        if (sesUserId != "") {
            $.getJSON("/api/posts/" + currentPostId() + "/" + sesUserId, function (pd) {
                data(pd.data);
                console.log(pd.data);
            });
        } else {
            $.getJSON("/api/posts/" + self.id, function (pd) {
                data(pd.data);
                console.log(pd.data);
            });
        }
        

        saveAnno = function (anno) {
            var favObj = {
                UserId: sesUserId,
                PostId: self.id,
                Annotation: anno
            }

            console.log(favObj);

            //***Validation to check if the text area is empty.****

            //var validation = $('#textAnnotation');
            var validation = document.getElementById('textSave');
            if (trimfield(validation.value) == '') {
               // $(".error-messages").text("Please write in something!").fadeIn();
               alert("Please Write in Something!");
                validation.focus();
                return false;

            } else {
                
                $.post("api/Favorites/" + favObj.UserId + "/" + favObj.PostId, favObj, function (Annotation) {
                    console.log("Your data is saved" + favObj.Annotation);
                    window.location.reload(true);

                    



                });
            }
        }
        updateFav = function (anno) {
            var favObj = {
                UserId: sesUserId,
                PostId: self.id,
                Annotation: anno
            }

            var validation = document.getElementById('textUpdate');
            if (trimfield(validation.value) == '') {
                alert("Please Write in Something!");
                validation.focus();
                return false;

            } else {
                $.ajax({
                    url: "api/Favorites/" + favObj.UserId + "/" + favObj.PostId,
                    type: "PUT",
                    contentType: "application/json",
                    data: ko.toJSON(favObj),
                    success: function () {
                        console.log(favObj);
                        console.log("Your data is Updated");
                    }
                });
            }
        }

        deleteFav = function (anno) {
            $.ajax({
                url: "api/Favorites/" + sesUserId + "/" + self.id,
                type: "DELETE",
                //dataType: "json",
                contentType: "application/json",
                data: ko.toJSON(self),
                success: function () {
                    //window.location.reload(true);
                    console.log("Your data is Deleted");
                    self.anno = "";    
                    anno = "";
                }
            });
            
        }
        return {
            data: data,
            currentPostId: currentPostId
        }
    }
    return postdetailVM;
});