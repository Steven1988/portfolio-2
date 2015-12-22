define(['knockout', 'jQuery'], function (ko) {
    tagViewModel = function() {
        var data = ko.observableArray([]);
        $.getJSON("/api/tags", function (tags) {

            data(tags);
            //console.log(tags);
        });

        closeAdvert = function () {
            $('.advert').hide();
            console.log("clicked on close");
        }

        return {
            tags: data
        }
    };
    return tagViewModel;
})