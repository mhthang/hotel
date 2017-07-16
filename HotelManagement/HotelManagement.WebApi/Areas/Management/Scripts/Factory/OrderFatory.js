var OrderFactory = function ($rootScope, $localstorage, $timeout, CommonFactory) {
    var service = {};
    //var URL = "/TimeKeeping/TimeKeepingReport/";
    service.Search = function (Status, PageSize, PageIndex, callback) {
        var datasend = JSON.stringify({
            Status: Status,
            PageSize: PageSize,
            PageIndex: PageIndex
        });

        CommonFactory.PostDataAjax("/Management/Order/GetRoomOrderByStatus", datasend,
            function (err) {
            },
            function (response) {
                callback(response);
            },

            function (error) {
                callback(error);
            });
    }
    service.RoomDetail = function (OrderID, callback) {
        var datasend = JSON.stringify({
            OrderID: OrderID
        });

        CommonFactory.PostDataAjax("/Management/Order/GetRoomDetail", datasend,
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
