var $localstorage = function ($window) {
    return {
        set: function (key, value) {
            $window.localStorage[key] = value;
        },
        get: function (key, defaultValue) { return $window.localStorage[key] || defaultValue; },
        setObject: function (key, value) {
            $window.localStorage[key] = JSON.stringify(value);
        },
        getObject: function (key) {
            try {
                var temp = $window.localStorage[key];
                if (temp) {
                    return JSON.parse(temp || "{}");
                }
            } catch (e) {
                return JSON.parse("{}");
            }
        },
        remove: function (key) {
            $window.localStorage.removeItem(key);
        },
        clearAll: function () {
            $window.localStorage.clear();
        }
    };
};

$localstorage.$inject = ["$window"];

var CommonFactory = function ($rootScope, $localstorage, $timeout, Analytics) {
    var service = {};

    //var trackTiming = function (start, end, url) {
    //    var timeSpent = end - start;
    //    Analytics.trackTimings("Ajax Request", url, timeSpent);
    //}

    var sendRequest = function (url, data, beforeSend, success, errorFunction, timeout, async) {
    }

    service.PostDataAjax = function (url, data, beforeSend, success, errorFunction, timeout) {
        if (!timeout) {
            timeout = 60000;
        }

        $.ajax({
            url: url,
            type: "POST",
            timeout: timeout,
            cache: true,
            crossDomain: true,
            contentType: "application/json; charset=utf-8;",
            dataType: "json",
            data: data,
            processData: true,
            beforeSend: beforeSend,
            async: true,
            tryCount: 0,
            retryLimit: 3,
            success: function (response) {
                success(response);
            },
            error: function (error) {
            debugger
            },
            complete: function (complete) {
                
            }
        });
    }

    service.PostDataAjaxSync = function (url, data, beforeSend, success, errorFunction, timeout) {
        if (!timeout) {
            timeout = 60000;
        }



        $.ajax({
            url: url,
            type: "POST",
            timeout: timeout,
            cache: true,
            crossDomain: true,
            contentType: "application/json; charset=utf-8;",
            dataType: "json",
            data: data,
            processData: true,
            beforeSend: beforeSend,
            async: false,
            success: function (response) {
                success(response);
            },
            error: function (error) {

            },
            complete: function (complete) {

            }
        });
    }
    return service;
};

CommonFactory.$inject = ["$rootScope", "$localstorage", "$timeout", "Analytics"];