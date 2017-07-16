﻿OrderController = function ($scope, $rootScope, $localstorage, $timeout, $location, $http, OrderFactory) {
    $scope.IsLoadingPage = false;
    $scope.lstRoomFree = [];
    $scope.lstRoomBusy = [];
    $scope.OrderDetail = [];
    $scope.lstProduct = [];
    $scope.TotalBill = 0;
    $scope.ObjDetail = []
    $scope.Search = function (Status, PageIndex) {
        try {

            $scope.IsLoadingPage = true;
            var PageSize = 8;
            OrderFactory.Search(Status, PageSize, PageIndex, function (response) {
                if (response != null) {
                    $timeout(function () {
                        if (Status == 1) {
                            $scope.lstRoomFree = JSON.parse(response.DataTable);
                            if ($scope.lstRoomFree.lenght > 0) {
                                $scope.TotalRowFree = $scope.lstRoomFree[0].TOTALROWS
                            } $scope.IsLoadingPage = false;
                        }
                        if (Status == 2) {
                            $scope.lstRoomBusy = JSON.parse(response.DataTable);
                            if ($scope.lstRoomBusy.lenght > 0) {
                                $scope.TotalRowBusy = $scope.lstRoomFree[0].TOTALROWS
                            } $scope.IsLoadingPage = false;
                        }
                        if (Status == 3) {
                            $scope.lstRoomCleanning = JSON.parse(response.DataTable);
                            if ($scope.lstRoomCleanning.lenght > 0) {
                                $scope.TotalRowCleanning = $scope.lstRoomFree[0].TOTALROWS
                            } $scope.IsLoadingPage = false;
                        }
                        $scope.IsLoadingPage = false;


                    }, 10);

                } else {
                    alert("Có lỗi khi lấy danh sách phòng, vui lòng liên hệ IT");
                    $scope.IsLoadingPage = false;
                }

            });
        } catch (e) {
            alert(e);
        }
    }
    $scope.ViewOrderDetail = function (it) {
        debugger;
        var OrderID = it.ORDERID;
        var RoomID = it.ID;
        if (OrderID == null) {
            location.href = "/phieu-dat-phong-0-" + RoomID;
            //window.location.replace("/phieu-dat-phong-0-" + RoomID);
        }
        else {
            location.href = "/phieu-dat-phong-" + OrderID + "-" + RoomID;
            //window.location.replace("/phieu-dat-phong-" + OrderID + "-" + RoomID);
        }

    }
    // Lấy chi tiết hóa đon 
    $scope.GetOrderDetail = function () {

        OrderID = window.location.href.split('-').slice(-2)[0];
        var RoomID = window.location.href.split('-').slice(-1)[0];
      
        var requestModel = {
            OrderID: OrderID
        };

        $http.get("/api/OrderApi/GetByID", { params: requestModel }).then(function (response) {
            // this callback will be called asynchronously
            // when the response is available    

            $scope.OrderDetail = response.data;

            if ($scope.OrderDetail.OrderDetail) {
                if ($scope.OrderDetail.OrderDetail.length > 0) {
                    var RoomBill = $scope.OrderDetail.TotalRoom
                    var ProductBill = 0;
                    for (var i = 0; i < $scope.OrderDetail.OrderDetail.length; i++) {
                        ProductBill += ($scope.OrderDetail.OrderDetail[i].Price * $scope.OrderDetail.OrderDetail[i].Quantity)
                    }
                }

            }
            debugger;
            $scope.TotalBill = RoomBill + ProductBill;
            $scope.OrderDetail.RoomID = RoomID;
        }, function (response) {

            // called asynchronously if an error occurs
            // or server returns response with an error status.             
        });
    };
    // Lấy TTKH
    $scope.GetCustomerInfo = function () {
        $scope.IsLoadingPage = true;
        var key = $scope.OrderDetail.Phone;
        if (key.length >= 9) {
            var requestModel = {
                Keyword: '',
                Phone: key,
                PageSize: 1,
                PageIndex: 1

            };
            $http.get("/api/CustomerApi/GetAll", { params: requestModel }).then(function (response) {
                $scope.CusDetail = response.data;

                if ($scope.CusDetail.length > 0) {
                    $scope.OrderDetail.Address = $scope.CusDetail[0].Address;
                    $scope.OrderDetail.CustomerName = $scope.CusDetail[0].CustomerName;
                    $scope.OrderDetail.Email = $scope.CusDetail[0].Email;
                    $scope.OrderDetail.IDNo = $scope.CusDetail[0].IDNo;
                    $scope.OrderDetail.Image = $scope.CusDetail[0].Image;
                    $scope.OrderDetail.Note = $scope.CusDetail[0].Note;
                    $scope.OrderDetail.CustomerID = $scope.CusDetail[0].CustomerID;
                }
                $scope.IsLoadingPage = false;
            }, function (response) {
            });
        }
    }

    // Lấy DS dịch vụ
    $scope.GetProductList = function () {
        $scope.IsLoadingPage = true;
        var requestModel = {

        };
        $http.get("/api/ProductApi/GetAll", { params: requestModel }).then(function (response) {
            $scope.lstProduct = response.data;
            $scope.IsLoadingPage = false;
        }, function (response) {
        });

    }
    $scope.SaveChange = function () {
        //$scope.OrderDetail = [];
        ///VAlid data
        var checkin = $('#CheckinDate').val()
        var checkout = $('#CheckOutDate').val()

        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var hh = today.getHours();
        var mm = today.getMinutes();
        var yyyy = today.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }
        if (mm < 10) {
            mm = '0' + mm;
        }
        var today = dd + '/' + mm + '/' + yyyy + ' ' + hh + ':' + mm;



        if (checkin == '' || checkin == null || checkin == undefined) {
            checkin = today;
        }
        else {
            checkin = checkin + ' ' + hh + ':' + mm;
        }
        $scope.OrderDetail.OrderDetail = [];
        $scope.OrderDetail.Userlogin = '123';
        $scope.OrderDetail.CheckinDate = checkin;
        $scope.OrderDetail.CheckOutDate = null;
        var res = $scope.OrderDetail;
        debugger;
        //Luu data
        $scope.IsLoadingPage = true;
        var requestModel = {
            objOrder: res
        };
        $http.post("/api/orderapi/Insert_Update", res).then(function (response) {
            debugger;
            if (response.data ==1) {
                alert("Tạo phòng thành công");
               
                location.href = "/danh-sach-phong"
                //window.location.replace('/phieu-dat-phong-' + $scope.OrderDetail.OrderID + '-' + $scope.OrderDetail.RoomID)
                 $scope.IsLoadingPage = false;
            }
            $scope.IsLoadingPage = false;
        }, function (response) {
        });

    }
    $scope.printDiv = function () {

        try {

            var oIframe = document.getElementById('invoice');
            var oContent = document.getElementById('invoice').innerHTML;
            var oDoc = (oIframe.contentWindow || oIframe.contentDocument);
            //if (oDoc.document) oDoc = oDoc.document;
            oDoc.write("<head><title>title</title>");
            oDoc.write("</head><body onload='this.focus(); this.print();'>");
            oDoc.write(oContent + "</body>");
            oDoc.close();
        } catch (e) {
            self.print();
        }


    }

}

OrderController.$inject = ["$scope", "$rootScope", "$localstorage", "$timeout", "$location", "$http", "OrderFactory"];
