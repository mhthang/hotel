﻿function SubjectGroupListCtrl($scope, $http, $stateParams, $modal, Constants) {

    $scope.SemId = $stateParams.semid;

    $scope.onload = function () {
        search($scope.SemId);
    };

    $scope.SearchResponse = null;

    var search = function (semesterId) {
        var requestModel = {
            Id: semesterId
        };

        $http.post(Constants.WebApi.SubjectGroup.Search, requestModel).then(function (response) {
            // this callback will be called asynchronously
            // when the response is available            
            $scope.SearchResponse = response.data;
            
        }, function (response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.             
        });
    };

    $scope.open = function(id)
    {
        var modalInstance = $modal.open({
            templateUrl: 'subjectGroup/edit',
            controller: SubjectGroupCtrl,
            resolve: {
                SemesterId: function () {
                    return $scope.SemId;
                },
                SubjectGroupId: function () {
                    return id;
                }
            }
        });

        modalInstance.result.then(function () {
            //on ok button press           
            search($scope.SemId);
        }, function () {
            //on cancel button press
        });
    }
}