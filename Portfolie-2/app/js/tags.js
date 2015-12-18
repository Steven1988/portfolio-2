define(['knockout', 'jQuery'], function (ko) {
    tagViewModel = function() {
        var data = ko.observableArray([]);
        $.getJSON("/api/tags", function (tags) {

            data(tags);
            //console.log(tags);
        });

        toSearch = function (Tagname) {
            searchVM(Tagname);
            console.log("the tagname is: " + Tagname)
        }

        return {
            tags: data
        }
        //console.log(tags);
    };
    return tagViewModel;
})