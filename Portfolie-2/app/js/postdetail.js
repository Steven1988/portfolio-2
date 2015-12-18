define(['knockout', 'jQuery'], function (ko) {
    postdetailVM = function (params) {
        var currentPostId = params.selectedPost;
        //console.log(currentPostId());

        var showInput = ko.observable();
        var highlight = ko.observable();
        var sesUserId = 255;
        var id = 28894151;
        var data = ko.observableArray([]);
        if (sesUserId != "") {
            $.getJSON("/api/posts/" + id + "/" + sesUserId, function (pd) {
                data(pd.data);
                console.log(pd.data);
                console.log("with sesUserId" + sesUserId)
            });
        } else {
            $.getJSON("/api/posts/" + id, function (pd) {
                data(pd.data);
                console.log(pd.data);
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
        }
    }
    return postdetailVM;
});