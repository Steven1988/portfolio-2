define(['knockout','jQuery','bootstrap'], function (ko) {
    postViewModel = function () {
        vm = this;
        var data = ko.observableArray([]);
        var page = ko.observable();
        var currentComponent = ko.observable();

        $.getJSON("/api/posts", function (posts) {

            data(posts.data);
            //console.log(posts);

            //console.log(posts.data[0].Body);

            page(posts.paging);
            console.log(posts.paging);
        });

        //var summary = 50;
        //console.log(posts.Body);

        goToPost = function (Id, Url) {
           
            console.log(Url);

            //currentComponent('postdetail');
            ko.navbarVM().showContent('postdetail')
            ko.components.get('postdetail', ko.postdetailVM(Id));

            //postdetailVM(Id)
            //$.getJSON(Url, function (posts) {
            //    data(posts.data);
            //})
            //return data;
            //do somthing
        }

        return {
            posts: data,
            page: page,
            currentComponent: currentComponent
        }
    };
    return postViewModel;
})

