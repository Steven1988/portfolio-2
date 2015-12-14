// Here's my data model
var ViewModel = function () {
   // ko.components.register("navbar-component", {
   ////     template: '<div class="navbar navbar-inverse navbar-fixed-top" role="navigation"> <div class="container"> <div class="navbar-header"> <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse"> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> </button> <a class="navbar-brand" href="../indexWithMenu.html">SOVA</a> </div><div class="collapse navbar-collapse"> <ul class="nav navbar-nav"> <li class="active"> <a href="../Views/posts.html"> <i class="fa fa-comments"></i> New Posts </a> </li><li> <a href="../Views/tags.html"> <i class="fa fa-hashtag"></i> Find By Tags </a> </li></ul> <ul class="nav navbar-nav navbar-right"> <li class="dropdown"> <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"></i> User Menu <b class="caret"></b></a> <ul class="dropdown-menu"> <li><a href="../Views/favorites.html">My Favorites</a></li><li><a href="../Views/history.html">My Search History</a></li><li class="divider"></li><li class="dropdown-header">Nav header</li><li><a href="#">Separated link</a></li><li><a href="#">One more separated link</a></li></ul> </li></ul> </div></div></div>'
   //     template: { require: "Scripts/text!Views/navbar.html" }
   // });
   // console.log("navbar vm");
};


ko.components.register("navbar-component", {
    viewModel: {},
    //     template: '<div class="navbar navbar-inverse navbar-fixed-top" role="navigation"> <div class="container"> <div class="navbar-header"> <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse"> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> </button> <a class="navbar-brand" href="../indexWithMenu.html">SOVA</a> </div><div class="collapse navbar-collapse"> <ul class="nav navbar-nav"> <li class="active"> <a href="../Views/posts.html"> <i class="fa fa-comments"></i> New Posts </a> </li><li> <a href="../Views/tags.html"> <i class="fa fa-hashtag"></i> Find By Tags </a> </li></ul> <ul class="nav navbar-nav navbar-right"> <li class="dropdown"> <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"></i> User Menu <b class="caret"></b></a> <ul class="dropdown-menu"> <li><a href="../Views/favorites.html">My Favorites</a></li><li><a href="../Views/history.html">My Search History</a></li><li class="divider"></li><li class="dropdown-header">Nav header</li><li><a href="#">Separated link</a></li><li><a href="#">One more separated link</a></li></ul> </li></ul> </div></div></div>'
    template: { require: "Scripts/text!Views/navbar.html" }
});

//ko.applyBindings(new ViewModel());
