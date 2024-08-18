'use strict';
app.controller('metarController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window', '$q', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window, $q) {
    $scope.isFullScreen = true;
    $scope.isContentVisible = true;


    $scope.loadingVisible = false;
    $scope.loadPanel = {
        message: 'Please wait...',

        showIndicator: true,
        showPane: true,
        shading: true,
        closeOnOutsideClick: false,
        shadingColor: "rgba(0,0,0,0.4)",
        // position: { of: "body" },
        onShown: function () {

        },
        onHidden: function () {

        },
        bindingOptions: {
            visible: 'loadingVisible'
        }
    };

    $scope.popup_add_visible = false;
    $scope.popup_add_title = 'METAR';
    $scope.popup_instance = null;
    $scope.popup_add = {


        showTitle: true,

        toolbarItems: [


            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Update', icon: 'check', validationGroup: 'metarupdate', onClick: function (e) {

                        if (!$rootScope.getOnlineStatus()) {
                            alert('You are OFFLINE.Please check your internet connection.');
                            return;
                        }
                        $scope.loadingVisible = true;
                        flightService.updateMETARs($scope.fdp.FDPId).then(function (response) {
                            $scope.loadingVisible = false;
                            $scope.tempData.METAR = response.Data;
                            $scope.fdp.METAR = response.Data;


                            $scope.filtered = Enumerable.From($scope.fdp.METAR)
                                .Where(function (x) { return $scope.selectedStations.indexOf(x.StationId) != -1; })
                                .OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
                                    return Number(moment(new Date(x.observation_time)).format('YYMMDDHHmm'));

                                }).Take(10).ToArray();



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

            $scope.popup_add_visible = false;
            $rootScope.$broadcast('onMETARHide', null);
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
            width: 'popup_width'

        }
    };


    $scope.scroll_left_height = $(window).height() - 200;
    $scope.scroll_left = {
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
            height: 'scroll_left_height'
        }

    };

    $scope.scroll_right = {
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
            height: 'scroll_left_height'
        }

    };
    $scope.stations = [];
    $scope.selectedStations = [];
    $scope.getStationClass = function (x) {
        var index = $scope.selectedStations.indexOf(x);
		var cls="";
        if (index != -1)
            cls= "station selected";
        else
            cls= "station";
		
		if ($scope.escapes.indexOf(x)!=-1)
			cls+=" escape";
		
		return cls;
    };
	$scope.isHighLight=function(txt) {
        
            var raw = txt.split(" ");
           // _d.highLight = 0;
		  var _h=0;
           $.each(raw, function (_j, _x) {
                if (_h != 1) {
                    var canParse = /^\d+$/.test(_x);
                    var parsed = parseInt(_x);

                    if ((canParse == true && parsed <= 5000) || ['CB', 'TS', 'SH', 'HZ', 'SN', 'BR'].indexOf(_x) != -1) {
                        _h = 1;
                    }
                }
               

            })
        

       return _h;

    };
	$scope.getHighLightClass=function(txt){
	    if ($scope.isHighLight(txt)==1)
			return 'highlight';
		else
			return '';
	};
    $scope.stationClick = function (x) {
        //var index = $scope.selectedStations.indexOf(x);
        //if (index != -1)
        //    $scope.selectedStations.splice(index, 1);
        //else
        //    $scope.selectedStations.push(x);
        $scope.selectedStations = [];
        $scope.selectedStations.push(x);

        $scope.filtered = Enumerable.From($scope.fdp.METAR)
            .Where(function (x) { return $scope.selectedStations.indexOf(x.StationId) != -1; })
            .OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
                return Number(moment(new Date(x.observation_time)).format('YYMMDDHHmm'));

            }).Take(10).ToArray();

    };


    $scope.selectedObj = null;
    $scope.showObj = function (item, n, $event) {

        $scope.selectedObj = item;


    };
    $scope.getObjClass = function (flt) {

        if (!$scope.selectedObj || $scope.selectedObj.Id != flt.Id)
            return "";
        else
            return "selected-obj";
        //return flt.FlightStatus.toLowerCase();
    }

    $scope.filtered = [];
    $scope.bind = function () {
        $scope.fdp = $scope.tempData;
        $scope.stations = [];
        $.each($scope.fdp.items, function (_i, _d) {
            $scope.stations.push(_d.FromAirportIATA);
            $scope.stations.push(_d.ToAirportIATA);
            if (_d.ALT1)
                $scope.stations.push(_d.ALT1);
            if (_d.ALT2)
                $scope.stations.push(_d.ALT2);

        });
        $scope.stations = Enumerable.From($scope.stations).Distinct().ToArray();
		
		$scope.escapes = [];
        $.each($scope.fdp.items, function (_i, _d) {
            try{
			var ess =_d.ALT4? _d.ALT4.split(','):null;
			if (ess)
            $.each(ess, function (_j, _x) {
                $scope.escapes.push(_x);
            });
			} catch(eeeee){}

        });
        
        $scope.escapes = Enumerable.From($scope.escapes).Where(function (x) { return x && x != '-' && $scope.stations.indexOf(x) == -1; }).Distinct().ToArray();
        $.each($scope.escapes, function (_i, _d) {
            $scope.stations.push(_d);
        });
        
        
        // $scope.selectedStations = Enumerable.From($scope.stations).ToArray();
        $scope.selectedStations = [];
        $scope.selectedStations.push(Enumerable.From($scope.stations).FirstOrDefault());
        $scope.filtered = Enumerable.From($scope.fdp.METAR).OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
            return Number(moment(new Date(x.observation_time)).format('YYMMDDHHmm'));

        }).Take(10).ToArray();

        /////////////////////
        //////////////////////
        //nool
        if ($rootScope.getOnlineStatus()) {
            flightService.updateMETARs($scope.fdp.FDPId).then(function (response) {
                
                $scope.tempData.METAR = response.Data;
                $scope.fdp.METAR = response.Data;


                $scope.filtered = Enumerable.From($scope.fdp.METAR)
                    .Where(function (x) { return $scope.selectedStations.indexOf(x.StationId) != -1; })
                    .OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
                        return Number(moment(new Date(x.observation_time)).format('YYMMDDHHmm'));

                    }).Take(10).ToArray();



            }, function (err) {   });
        }
        /////////////////////
        /////////////////////

    };
    ////////////////////////////
    var appWindow = angular.element($window);
    appWindow.bind('resize', function () {
        $scope.$apply(function () {
			$scope.scroll_left_height = $(window).height() - 200;
            // $scope.leftHeight = $(window).height() - 135;
            // $scope.rightHeight = $(window).height() - 135 - 45;
        });
    });
    $scope.tempData = null;
    $scope.$on('InitMETAR', function (event, prms) {


        $scope.tempData = prms;

        $scope.popup_add_visible = true;

    });
    //////////////////////////////

}]);  
