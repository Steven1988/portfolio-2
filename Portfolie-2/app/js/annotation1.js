function FavoriteViewModel() {
    var self = this;
    self.UserId = ko.observable("282");
    self.PostId = ko.observable("124462");
    self.Annotation = ko.observable("");
    
}

//self.loadUserData = function () {
//    $.getJSON("/api/favorite/"+UserId+"/"+PostId, function (data) {
//        alert(data.UserId);
//    });
//}

//self.saveUserData = function () {
//    alert(ko.toJSON(self)
//        );
//}

//self.saveUserData = function () {
//    var data_to_send = {
//        userData: ko.toJSON(self)
//    };
//    $.post("/api/favorites", data_to_send, function (data) {
//        alert("Your data has been posted to the server!");
//    });
//}
ko.applyBindings(new FavoriteViewModel());