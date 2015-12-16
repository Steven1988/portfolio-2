define(['knockout', 'jQuery'], function (ko) {
    searchVM = function () {
        vm = this
        var searchItem = ko.observable("");
        var data = ko.observableArray([]);

        getResult = function (searchItem) {
            var searchString = ko.toJS(searchItem);
            //console.log(searchString);

            $.getJSON('api/search/' + searchString, function (searchPosts) {

                data(searchPosts.data)
                console.log(searchPosts);
            });

            return searchItem;
        }
        return {
            searchPosts: data,
            searchItem: searchItem
        }
    }
   
    return searchVM;
});