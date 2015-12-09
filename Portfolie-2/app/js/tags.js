define([''], function (ko) {
    function tagsViewModel() {
        this.tagname = "tagname";
        this.count = "count"
        console.log('im from the postdetailVM' + this.tagname+"   "+this.count);

    }
    return tagsViewModel;

});