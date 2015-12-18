var app = app || {};

require(['knockout', 'jQuery', 'bootstrap', 'moment'], function (ko) {

    app.mainViewModel = function () {
        mainVM = this;
        var currentComponent = ko.observable("search");
        currentPostId = ko.observable("");

        //mainVM.postVM = new postVM(postViewModel)
        //console.log(mainVM.postVM);
        //if (currentPostId != "") {
        //    currentComponent = "postdetail";
        //    //console.log(currentPostId);
        //}

        return {
            currentComponent: currentComponent,
            currentPostId: currentPostId
            //change: function () {
            //    this.currentComponent("postDetail")
            //}
        }
    }

    //************ All of our components **************
    ko.components.register('navbarComponent', {
        viewModel: { require: 'app/js/navbar' },
        template: { require: 'Scripts/text!Views/navbar.html' }
    });

    ko.components.register('posts', {
        viewModel: { require: 'app/js/posts' },
        template: { require: 'Scripts/text!Views/posts.html' }
    });

    ko.components.register('tags', {
        viewModel: { require: 'app/js/tags' },
        template: { require: 'Scripts/text!Views/tags.html' }
    });

    ko.components.register('searchhistory', {
        viewModel: { require: 'app/js/searchHistory' },
        template: { require: 'Scripts/text!Views/history.html' }
    });

    ko.components.register('favorites', {
        viewModel: { require: 'app/js/annotation1' },
        template: { require: 'Scripts/text!Views/fav.html' }
    });
    ko.components.register('postdetail', {
        viewModel: { require: 'app/js/postdetail' },
        template: { require: 'Scripts/text!Views/postdetail.html' }
    });

    ko.components.register('search', {
        viewModel: { require: 'app/js/search' },
        template: { require: 'Scripts/text!Views/search.html' }
    });


    ko.applyBindings(new app.mainViewModel());
});

//************ Advertisement **************
document.getElementById('closeAdButton').addEventListener('click', function (e) {
    e.preventDefault();
    this.parentNode.parentNode.style.display = 'none';
}, false);
