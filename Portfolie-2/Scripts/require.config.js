﻿require.config({
    baseUrl: "/",
    paths: {
        jQuery: "Scripts/jquery-1.9.1.min",
        knockout: "Scripts/knockout-3.4.0",
        bootstrap: "Scripts/bootstrap.min",
        autohideNavbar: "Scripts/jquery.bootstrap-autohidingnavbar.min",
        moment: "Scripts/moment"
    },
    shim: {
        'bootstrap': ['jQuery']
    }
});