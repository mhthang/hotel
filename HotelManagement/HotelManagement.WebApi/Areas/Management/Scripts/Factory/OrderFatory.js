var OrderFactory = function ($rootScope, $localstorage, $timeout, CommonFactory) {
    var service = {};
    var URL = "/TimeKeeping/TimeKeepingReport/";
    service.SearchReport = function (strKey, intStoreID, strFromDate, strToDate, intPageIndex, callback) {
        var datasend = JSON.stringify({
            strKey: strKey,
            intStoreID: intStoreID,
            strFromDate: strFromDate,
            strToDate: strToDate,
            intPageIndex: intPageIndex
        });

        CommonFactory.PostDataAjax(URL + "SearchReport", datasend,
            function (err) {
            },
            function (response) {
                callback(response);
            },

            function (error) {
                callback(error);
            });
    }


    return service;
};
OrderFactory.$inject = ["$rootScope", "$localstorage", "$timeout", "CommonFactory"];
