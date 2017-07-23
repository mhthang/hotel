var AccountController = function ($scope, $rootScope, $localstorage, $timeout, $location,$http, AccountFactory) {
    $scope.Title = "Đăng nhập hệ thống";
    $scope.mode = {};
    
    $scope.isLoading = false;
    $scope.Login = function () {
        try {
            $scope.isLoading = true;
            if($scope.UserName == "")
            {
                alert('Bạn vui lòng nhập username');
                return;
            }
            if ($scope.Password == "") {
                alert('Bạn vui lòng nhập password');
                return;
            }
            $http.post("/api/accountapi/SignIn", $scope.mode).then(function (response) {

                if (response.data == 1) {
                    alert("Thành công");

                    location.href = "/danh-sach-phong"
                    //window.location.replace('/phieu-dat-phong-' + $scope.OrderDetail.OrderID + '-' + $scope.OrderDetail.RoomID)
                    $scope.IsLoadingPage = false;
                }
                $scope.IsLoadingPage = false;
            }, function (response) {
            });
        } catch (e) {
            alert(e);
        }
    }
}

AccountController.$inject = ["$scope", "$rootScope", "$localstorage", "$timeout", "$location", "$http", "AccountFactory"];