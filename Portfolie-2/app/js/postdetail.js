define(['Scripts/knockout-3.4.0'], function (ko) {
    function postdetailViewModel() {
        this.MyName = "Stefan";

        var id = 105975;
        $.getJSON("/api/posts/" + id, function (data) {
            //console.log(data);
        });

        //console.log(data);
        //console.log("the id is: " + id)
    }

    return postdetailViewModel;

});