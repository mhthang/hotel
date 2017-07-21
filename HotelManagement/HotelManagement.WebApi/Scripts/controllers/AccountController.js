var AccountController = function ($scope, $rootScope, $localstorage, $timeout, $location, AccountFactory) {
    $scope.Title = "Đăng nhập hệ thống";
    $scope.UserName = "";
    $scope.Password = "";
    $scope.isLoading = false;
    $scope.Login = function () {
        try {
            $scope.isLoading = true;
            AccountFactory.Login($scope.UserName, $scope.Password, function (response) {
                if (response != null) {
                    window.location.href = '/listmail?mailtype=inbox';
                } else
                    alert("Có lỗi khi đăng nhập");
                $scope.isLoading = false;
            });
        } catch (e) {
            alert(e);
        }
    }
}

AccountController.$inject = ["$scope", "$rootScope", "$localstorage", "$timeout", "$location", "AccountFactory"];