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
addFactory("AccountManageFactory", AccountManageFactory);
var addController = function (name, controller) {
    try {
        HotelManager.controller(name, controller);
    } catch (e) {
        console.log(JSON.stringify(e));
    }
}

//#region Controller Manage
 
addController("OrderController", OrderController);
addController("AccountController", AccountController);
addController("AccountManageController", AccountManageController);

 

//#endregion
 


