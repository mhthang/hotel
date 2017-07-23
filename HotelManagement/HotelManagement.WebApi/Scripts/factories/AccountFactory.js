var AccountFactory = function ($rootScope, $localstorage, $timeout, Analytics, CommonFactory) {
    var service = {};
    var URL = "/api/accountapi/";
    service.Login = function (strUserName, strPassword, callback) {
        var model = {
            UserName: strUserName,
            Password: strPassword,
            RememberMe: true
        };
        
        CommonFactory.PostDataAjax(URL + "SignIn", model,
            function (err) {
                debugger
            },
            function (response) {
                callback(response);
            },

            function (error) {
                debugger
                callback(error);
            });
    }

    return service;
};
AccountFactory.$inject = ["$rootScope", "$localstorage", "$timeout", "Analytics", "CommonFactory"];
