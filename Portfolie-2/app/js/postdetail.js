define(['knockout', 'jQuery'], function (ko) {
    postdetailVM = function () {
       
        var self = this;
        self.ParentId = ko.observable();
        self.UserId = ko.observable();

        var id = 124462;
        var data = ko.observableArray([]);

        
        
        $.get("/api/posts/" + id, function (pd) {
            data(pd.data);
           
            console.log(pd);
            console.log(pd.data.ParentId);
            
            
            //var jObjects = JSON.parse(pd);
            
           // var sParentId = jObjects.ParentId;

           // console.log(jObjects);
        });
        
        saveInfo = function (Id) {
            console.log(Id);
            console.log("save info function")
        }
                
        
   
        //if (data.Comments !== [""])
        //{
        //    $('.someclass')append(some element);
        //} else {
        // //   something else
        //}
        return {
            data: data
        }
        
    }
    return postdetailVM;
});