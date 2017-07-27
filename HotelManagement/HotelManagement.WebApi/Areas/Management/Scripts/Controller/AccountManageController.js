AccountManageController = function ($scope, $rootScope, $localstorage, $timeout, $location, $http, AccountManageFactory) {
    $scope.IsLoadingPage = false;
    $scope.keyword = "";
    $scope.LoadUser = function () {
        var requestModel = {
            FullName: $scope.keyword,
            intPositionID: -1,
            strIDNo: '',
            strPhone:''
        };
        $http.get("/api/System_UserApi/GetAll", { params: requestModel }).then(function (response) {
            $scope.lstUser = response.data;
            $scope.IsLoadingPage = false;
        }, function (response) {
        });
    }
    $scope.CreateUser = function () {
        var requestModel = {
            strUsername: $scope.model.strUsername,
            Password: $scope.model.Password,
            Fullname: $scope.model.Fullname,
            Position: $scope.model.Position,
            Phone: $scope.model.Phone,
            Address: $scope.model.Address,
            Image: '',
            Note: '',
            IDNo: $scope.model.IDNo
        }
        $http.get("/api/System_UserApi/Insert_Update", { params: requestModel }).then(function (response) {
            if (response.data)
                alert('Thành công');
            $scope.LoadUser();
            $('#myModal').modal('hide');
            $scope.IsLoadingPage = false;
        }, function (response) {
        });
    }
    $scope.Delete = function (username) {
        var requestModel = {
            Username: username,
            Userlogin : "Chó quốc"
        }
        $http.get("/api/System_UserApi/Delete", { params: requestModel }).then(function (response) {
            if (response.data)
                alert('Thành công');
            $scope.LoadUser();
            $scope.IsLoadingPage = false;
        }, function (response) {
        });
    }
    $scope.Edit = function (user) {
        $scope.modeledit = user;
        $('#editmodal').modal('show');
    }
    $scope.UpdateUser = function () {
        var requestModel = {
            strUsername: $scope.model.strUsername,
            Password: $scope.model.Password,
            Fullname: $scope.model.Fullname,
            Position: $scope.model.Position,
            Phone: $scope.model.Phone,
            Address: $scope.model.Address,
            Image: '',
            Note: '',
            IDNo: $scope.model.IDNo
        }
        $http.get("/api/System_UserApi/Insert_Update", { params: requestModel }).then(function (response) {
            if (response.data)
                alert('Thành công');
            $scope.LoadUser();
            $('#myModal').modal('hide');
            $scope.IsLoadingPage = false;
        }, function (response) {
        });
    }
    $scope.LoadUser();
}

AccountManageController.$inject = ["$scope", "$rootScope", "$localstorage", "$timeout", "$location", "$http", "AccountManageFactory"];
