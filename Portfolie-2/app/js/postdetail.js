define(['knockout', 'jQuery'], function (ko) {
    postdetailVM = function (params) {
        var currentPostId = params.selectedPost;
        console.log(currentPostId);

        var sesUserId = 255;
        var id = 124462;
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

        return {
            data: data,
            currentPostId: currentPostId
        }
    }
    return postdetailVM;
});