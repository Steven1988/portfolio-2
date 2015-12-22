var app = app || {};

require(['knockout', 'jQuery', 'bootstrap', 'moment'], function (ko) {

    app.mainViewModel = function () {
        mainVM = this;

        var currentComponent = ko.observable("search");
        currentPostId = ko.observable("");

        //**** setting the sesUserId ******
        var theUser = ko.observable();
        var desiredUserId = 8717;
        if (desiredUserId != "") {
            $.getJSON('/api/users/' + desiredUserId, function (user) {
                theUser(user);
            });
        } else {
            theUser(null);
            console.log("user is null");
        }

        goToPostDetail = function (Id) {
            currentPostId(Id);
            currentComponent("postdetail");
        }


        var mydate = new Date().getFullYear()
        console.log(mydate)

        return {
            currentComponent: currentComponent,
            currentPostId: currentPostId,
            user: theUser,
            currentDate: mydate
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
    ko.components.register('yourprofile', {
        viewModel: { require: 'app/js/user' },
        template: { require: 'Scripts/text!Views/user.html' }
    });

    ko.applyBindings(new app.mainViewModel());
});
