var HotelManager = angular.module("HotelManager", ["summernote", "ngSanitize"]);

var addFactory = function (name, factory) {
    try {
        HotelManager.factory(name, factory);
    } catch (e) {
        console.log(JSON.stringify(e));
    }
}

addFactory("$localstorage", $localstorage);
addFactory("CommonFactory", CommonFactory);
 
addFactory("OrderFactory", OrderFactory);
 
//addFactory("TimeKeepingFactory", TimeKeepingFactory);
//addFactory("TimeKeepingReportFactory", TimeKeepingReportFactory);
var addController = function (name, controller) {
    try {
        HotelManager.controller(name, controller);
    } catch (e) {
        console.log(JSON.stringify(e));
    }
}

//#region Controller
 
addController("OrderController", OrderController);

//addController("TimeKeepingController", TimeKeepingController);
//addController("TimeKeepingReportController", TimeKeepingReportController);

//#endregion
 


