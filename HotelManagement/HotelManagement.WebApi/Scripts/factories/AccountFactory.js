var AccountFactory = function ($rootScope, $localstorage, $timeout, Analytics, CommonFactory) {
    var service = {};
    var URL = "Home/";
    service.Login = function (strUserName, strPassword, callback) {
        var datasend = JSON.stringify({
            strUserName: strUserName,
            strPassword: strPassword
        });

        CommonFactory.PostDataAjax(URL + "SignIn", datasend,
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
