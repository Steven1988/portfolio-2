define(['Scripts/knockout-3.4.0'], function (ko) {
    postViewModel = function() {
      
        var data = ko.observableArray([]);
        $.getJSON("/api/posts", function (posts) {
            
            data(posts);
            console.log(posts);
        });
        
        return {
            posts: data
        }
    };
   
    return postViewModel;
})