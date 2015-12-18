define(['knockout', 'jQuery'], function (ko) {
    postdetailVM = function () {
        this.MyName = "Stefan";
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


        //if (data.Comments !== [""])
        //{
        //    $('.someclass')append(some element);
        //} else {
        // //   something else
        //}
        return {
            data: data
        }
    }
    return postdetailVM;
});