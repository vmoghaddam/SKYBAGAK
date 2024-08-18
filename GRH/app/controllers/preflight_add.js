'use strict';
app.controller('preflight_add_controller', ['$scope', '$location', 'flightService','neerjaService', 'authService', '$routeParams', '$rootScope', '$window', '$q'

    , function ($scope, $location, flightService, neerjaService, authService, $routeParams, $rootScope, $window, $q) {

    $scope.entity = {
        Id: -1,
    };
    $scope.isEditable = false;
    $scope.isLockVisible = false;


    $scope.isNew = true;
    $scope.isContentVisible = false;
    $scope.isFullScreen = false;
    var detector = new MobileDetect(window.navigator.userAgent);

    if (detector.mobile() && !detector.tablet())
        $scope.isFullScreen = true;


    $scope.popup_add_visible = false;
    $scope.popup_add_title = 'New';
    $scope.popup_instance = null;
    $scope.popup_width = 500;
    $scope.popup_height = 700;

    $scope.dto = null;


    $scope.popup_add = {


        showTitle: true,

        toolbarItems: [

         
            {
                widget: 'dxButton', location: 'before', options: {
                    type: 'default', text: 'Sign', icon: 'fas fa-signature', onClick: function (e) {
                        if ($rootScope.getOnlineStatus()) {
                            //$scope.entity.Id
                            var data = { FlightId: $scope.entity.Id, documentType: 'log' };

                            $rootScope.$broadcast('InitSignAdd', data);
                        }
                        else {
                            General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                        }

                    }
                }, toolbar: 'bottom'
            },
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Save', icon: 'check', validationGroup: 'logadd', onClick: function (e) {
                        var items = [];
                        $.each($scope.pfc_grouped, function (_i, cat) {

                            $.each(cat.items, function (_j, item) {

                                items.push({
                                    item_id: item.item_id,
                                    remark: item.remark,
                                    is_servicable: item.is_servicable,
                                    crew_id: item.crew_id,
                                    flight_id:item.flight_id
                                });
                            });

                        });

                        var dto = {};
                        dto.items = items;
                        neerjaService.save_items(dto).then(function (response) {
                            if (response.IsSuccess) {
                                General.ShowNotify(Config.Text_SavedOk, 'success');
                                
                                $scope.popup_add_visible = false;
                            }


                        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

                    }
                }, toolbar: 'bottom'
            },
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'danger', text: 'Close', icon: 'remove', onClick: function (e) {
                        $scope.popup_add_visible = false;
                    }
                }, toolbar: 'bottom'
            }
        ],

        visible: false,
        dragEnabled: true,
        closeOnOutsideClick: false,
        onShowing: function (e) {
            $rootScope.IsRootSyncEnabled = false;
            $scope.popup_instance.repaint();


        },
        onShown: function (e) {

            if ($scope.isNew) {
                $scope.isContentVisible = true;
            }
            if ($scope.tempData != null)
                $scope.bind();

            if ($scope.isFullScreen)
                //  $scope.scrollHeight = $(window).height() - 230;
                $scope.scrollStyle = { height: ($(window).height() - 230).toString() + 'px' };
            else
                $scope.scrollStyle = { height: ($scope.popup_height - 195).toString() + 'px' };
            //  $scope.scrollHeight = 200;



        },
        onHiding: function () {

            //$scope.clearEntity();
            $scope.FuelRemaining2 = 0;
            $rootScope.IsRootSyncEnabled = true;
            $scope.popup_add_visible = false;
            $rootScope.$broadcast('onPFCHide', null);
        },
        onContentReady: function (e) {
            if (!$scope.popup_instance)
                $scope.popup_instance = e.component;

        },
        bindingOptions: {
            visible: 'popup_add_visible',
            fullScreen: 'isFullScreen',
            title: 'popup_add_title',
            height: 'popup_height',
            width: 'popup_width',
            'toolbarItems[1].visible': true,//'isEditable',
            'toolbarItems[0].visible': 'isLockVisible',

        }
    };


    $scope.bind = function () {
        $scope.loadingVisible = true;
        flightService.epGetFlightLocal($scope.entity.Id).then(function (response) {
            $scope.loadingVisible = false;
            if (response.IsSuccess) {
                $scope.isContentVisible = true;
                $scope.flight = response.Data;


                neerjaService.get_pfc_items_grouped($scope.entity.Id).then(function (response2) {
                    console.log(response2);
                    $scope.pfc_grouped = response2; 


                }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });


            }


        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
        }


        $scope.item_click = function (item_id, cat_id) {
            var cat = Enumerable.From($scope.pfc_grouped).Where('$.category_id==' + cat_id).FirstOrDefault();
            var item = Enumerable.From(cat.items).Where('$.item_id==' + item_id).FirstOrDefault();
            if (item.is_servicable === 0 || item.is_servicable === false)
                item.is_servicable = 1;
            else if (item.is_servicable === 1 || item.is_servicable === true)
                item.is_servicable = 0;
            else item.is_servicable = 1;
          //  alert();
        }
        $scope.get_item_result = function (item_id, cat_id) {
            var cat = Enumerable.From($scope.pfc_grouped).Where('$.category_id==' + cat_id).FirstOrDefault();
            var item = Enumerable.From(cat.items).Where('$.item_id==' + item_id).FirstOrDefault();
            if (item.is_servicable === 0 || item.is_servicable === false)
                return 'U/S';
            else if (item.is_servicable === 1 || item.is_servicable === true)
                return 'S';
            else return '?';
        }

        $scope.get_item_class = function (item_id, cat_id) {
            var cat = Enumerable.From($scope.pfc_grouped).Where('$.category_id==' + cat_id).FirstOrDefault();
            var item = Enumerable.From(cat.items).Where('$.item_id==' + item_id).FirstOrDefault();
            if (item.is_servicable === 0 || item.is_servicable === false)
                return 'cls_item_us';
            else if (item.is_servicable === 1 || item.is_servicable === true)
                return 'cls_item_s';
            else return 'cls_item_x';
        }

    $scope.scroll_pfc_height = $(window).height()-200;
    $scope.scroll_pfc = {
        width: '100%',
        bounceEnabled: false,
        showScrollbar: 'never',
        pulledDownText: '',
        pullingDownText: '',
        useNative: true,
        refreshingText: 'Updating...',
        onPullDown: function (options) {

            options.component.release();

        },
        onInitialized: function (e) {


        },
        bindingOptions: {
            height: 'scroll_pfc_height'
        }

    };



    var appWindow = angular.element($window);
    appWindow.bind('resize', function () {
        $scope.$apply(function () {
            // $scope.leftHeight = $(window).height() - 135;
            // $scope.rightHeight = $(window).height() - 135 - 45;
        });
    });
    $scope.tempData = null;

    //////////////////////////////
    $scope.$on('InitPFCAdd', function (event, prms) {


        $scope.tempData = null;

        if (!prms.Id) {

            $scope.isNew = true;

            $scope.popup_add_title = 'Preflight Check Form';

        }

        else {

            $scope.popup_add_title = 'Preflight Check Form';
            $scope.tempData = prms;
        
            $scope.entity.Id = prms.Id;

        }

        $scope.popup_add_visible = true;

    });
    ///////////////////////////////
}]);