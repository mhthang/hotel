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
 addFactory("AccountFactory", AccountFactory);
 
var addController = function (name, controller) {
    try {
        HotelManager.controller(name, controller);
    } catch (e) {
        console.log(JSON.stringify(e));
    }
}

//#region Controller
 
addController("OrderController", OrderController);
addController("AccountController", AccountController);

 

//#endregion
 


