function AccountRegisterCtrl($scope, $rootScope, $http, $location, $translate, vcRecaptchaService, SweetAlert, AuthService, Constants) {

    var ResigterResultSuccess = "Please check your email to confirm your account.";
    var ResigterResultError = "Register Failed!";


    $scope.CreateUserBindingModel =
    {
        Email: '',
        UserName: '',
        FirstName: '',
        Password: '',
        ConfirmPassword: '',
        IsAcceptTerm: false,
        CaptchaResponse: null
    };

    $scope.gRecaptchaResponse = null;

    $scope.createNewUser = function () {
        if (vcRecaptchaService.getResponse() === ""){ //if string is empty
            SweetAlert.swal({
                title: "Please checked the captcha!",
                text: "Please resolve the captcha and submit",
                type: "warning"
            });
            return;
        }
        $scope.loading = true;
        $scope.CreateUserBindingModel.UserName = $scope.CreateUserBindingModel.Email;
        $scope.CreateUserBindingModel.ConfirmPassword = $scope.CreateUserBindingModel.Password;
        $scope.CreateUserBindingModel.CaptchaResponse = $scope.gRecaptchaResponse;

        $http.post(Constants.WebApi.Account.CreateUser, $scope.CreateUserBindingModel).then(function (response) {
            // this callback will be called asynchronously
            // when the response is available
            SweetAlert.swal({
                title: "Register Successfully",
                text: ResigterResultSuccess,
                type: "success",
                confirmButtonText: "Back to the Login Page."
            },
            function () { $location.path("/login"); }
            );
        }, function (response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.                   
            $scope.loading = false;
            SweetAlert.swal({
                title: ResigterResultError,
                text: parseErrors(response.data),
                type: "warning"
            });
        });

        function parseErrors(response) {
            var errors = [];
            for (var key in response.ModelState) {
                for (var i = 1; i < response.ModelState[key].length; i++) {
                    errors.push(response.ModelState[key][i] + '\n');
                }
            }
            return errors;
        }

        $scope.gRecaptchaResponse = null;
        vcRecaptchaService.reload();
    };

    $scope.cbExpiration = function () {
        $scope.gRecaptchaResponse = null;
    }

    $scope.hasError = function (form, field, validation) {
        if (validation) {
            return (form[field].$dirty && form[field].$error[validation]) || ($scope.submitted && form[field].$error[validation]);
        }
        return (form[field].$dirty && form[field].$invalid) || ($scope.submitted && form[field].$invalid);
    };

    $scope.transalate = function (translations) {
        ResigterResultSuccess = translations.REGISTER_RESULT_SUCCESS;
        ResigterResultError = translations.REGISTER_RESULT_ERROR;
    }

    $translate(['REGISTER_RESULT_SUCCESS', 'REGISTER_RESULT_ERROR']).then(function (translations) {
        $scope.transalate(translations);
    });

    $rootScope.$on('$translateChangeSuccess', function () {
        $translate(['REGISTER_RESULT_SUCCESS', 'REGISTER_RESULT_ERROR']).then(function (translations) {
            $scope.transalate(translations);
        });
    });
};