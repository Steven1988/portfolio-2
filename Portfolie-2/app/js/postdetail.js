define(['knockout', 'jQuery'], function (ko) {
    postdetailVM = function (params) {
        var self = this;
        var currentPostId = params.selectedPost;

        var sesUser = params.sesUser;
        if (sesUser() == null) {
            sesUserId = "";
        } else {
            sesUserId = sesUser().Id;
        }

        var data = ko.observableArray([]);
        var anno = ko.observable();
        var date = ko.observable();
        function trimfield(str) {
            return str.replace(/^\s+|\s+$/g, '');
        }

        if (sesUserId != "") {
            $.getJSON("/api/posts/" + currentPostId() + "/" + sesUserId, function (pd) {
                data(pd.data);
                console.log(pd.data);
                var timestamp = data()[0].CreationDate.slice(0, -9);
                date(timestamp);
                    //.replace(/T/g, ' ')
                console.log(timestamp);
            });
        } 
        if (sesUserId == "") {
            $.getJSON("/api/posts/" + currentPostId(), function (pd) {
                data(pd.data);
                console.log(pd.data);
            });
        }

        saveAnno = function (anno) {
            var favObj = {
                UserId: sesUserId,
                PostId: currentPostId(),
                Annotation: anno
            }

            console.log(favObj);
            //***Validation to check if the text area is empty.****

            //var validation = $('#textAnnotation');
            var validation = document.getElementById('textSave');
            if (trimfield(validation.value) == '') {
                alert("Please Provide Details!");
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
                PostId: currentPostId(),
                Annotation: anno
            }

            var validation = document.getElementById('textUpdate');
            if (trimfield(validation.value) == '') {
                alert("Please Provide Details!");
                validation.focus();
                return false;

            } else {
                $.ajax({
                    url: "api/Favorites/" + favObj.UserId + "/" + favObj.PostId,
                    type: "PUT",
                    contentType: "application/json",
                    data: ko.toJSON(favObj),
                    success: function () {
                        window.location.reload(true);
                    }
                });
            }
        }

        deleteFav = function () {
            $.ajax({
                url: "api/Favorites/" + sesUserId + "/" + currentPostId(),
                type: "DELETE",
                //dataType: "json",
                contentType: "application/json",
                data: ko.toJSON(self),
                success: function () {
                    console.log("Your data is Deleted");
                    window.location.reload(true);
                    currentComponent("postdetail")
                }
            });
            
        }
        return {
            data: data,
            currentPostId: currentPostId,
            sesUserId: sesUserId,
            timestamp: date
        }
    }
    return postdetailVM;
});