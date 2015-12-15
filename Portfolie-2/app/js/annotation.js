var app = app || {};

app.mainViewModel = function () {
    this.firstName = "Alexander";
    this.lastName = "Nima";
}

ko.components.register('saveAnnotation', {
    viewModel: {
        createViewModel: function () {
            //var hello = ko.observable("hello my");
            //var data = ko.observableArray([]);
            var datas= function() {
                this.UserId = 1;
                this.PostId = 205064;
                this.annotation = "Please god me help me... Please Please";
            };
            return {
                UserId : UserId,
                PostId :PostId,
                annotation :annotation
            };

            $.post("/api/annotation",datas, function (posts) {
                alert("Your data has been posted to the server!");
                //data(posts.data);
                //console.log(posts);
            });
            
        }
        //require: 'app/js/posts.js'     
    },
    template: { require: 'Scripts/text!Views/annotation.html' }
});

ko.components.register('postDetail', {
    viewModel: { require: 'app/js/postdetail' },
    template: { require: 'Scripts/text!Views/postdetail.html' },
    synchronous: true
});

ko.components.register('Tags', {
    viewModel: { require: 'app/js/tags' },
    template: { require: 'Scripts/text!Views/tags.html' },
    synchronous: true
});

ko.applyBindings(new app.mainViewModel())
//ko.applyBindings(new postViewModel())