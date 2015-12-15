﻿define(['knockout', 'jQuery'], function (ko) {
    postdetailVM = function () {
        this.MyName = "Stefan";

        var id = 105568;
        var data = ko.observableArray([]);
        $.getJSON("/api/posts/" + id, function (pd) {
            data(pd.data);
            console.log(data);
        });
        return {
            data: data
        }
    }
    return postdetailVM;
});