define(['knockout', 'jQuery'], function (ko) {
    tagViewModel = function() {
        var data = ko.observableArray([]);
        $.getJSON("/api/tags", function (tags) {
            data(tags);
        });

        closeAdvert = function () {
            $('.advert').hide();
        }

        return {
            tags: data
        }
    };
    return tagViewModel;
})