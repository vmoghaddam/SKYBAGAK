'use strict';
app.controller('epLogBookController', ['$scope', '$location', '$routeParams', '$rootScope', 'flightService', 'authService', 'notificationService', '$route', '$window', '$q', '$http', function ($scope, $location, $routeParams, $rootScope, flightService, authService, notificationService, $route, $window, $q, $http) {
    $scope._IsJLVisible = $rootScope.userName.toLowerCase() == 'bolandi' || $rootScope.userName.toLowerCase() == 'hadadi';
    $scope.updversion = 'v4.0';
    $scope.employeeId = $rootScope.employeeId;
    $scope.isPIC = false;
    $scope._user = '';
    try {
        $scope._user = $rootScope.userName.toLowerCase();
    }
    catch (e) {

    }



    // var m1=moment().format();     // 2013-02-04T10:35:24-08:00
    // var m2 = moment.utc().format(); // 2013-02-04T18:35:24+00:00
    // console.log(m1);
    // console.log(m2);
    //$scope.imgurl = staticFiles + 'Weather/SIGWX/ADDS/a.png'; 
    //$http.get('https://localhost:5001/Upload/Weather/SIGWX/ADDS/a.png');
    //$http.get('https://localhost:5001/Upload/Weather/SIGWX/ADDS/b.png'); 
    //$http.get('https://localhost:5001/Upload/Weather/SIGWX/ADDS/SIGWX_ADDS_20210819_2105.png').then(
    //    function (response) { console.log('image get'); },
    //    function (error) {
    //        alert('error3'); console.log(error);
    //        caches.keys().then(function (names) {
    //            //for (let name of names)
    //            //   caches.delete(name);
    //            console.log('cache.........', names);
    //        });
    //    }
    //).catch((exp) => {
    //    alert('catch');
    //    console.log(exp);
    //});

    $scope.image = {
        src: 'https://www.aerotime.aero/upload/files/1250x420/1200px-Ba_b747-400_g-bnle_arp_crop.jpg',
        position: {
            x: -137.5,
            y: -68
        },
        scaling: 2,
        maxScaling: 5,
        scaleStep: 0.11,
        mwScaleStep: 0.09,
        moveStep: 99,
        fitOnload: true,
        showIndicator: true,
        progress: 0
    };
    if (!authService.isAuthorized()) {

        authService.redirectToLogin();
    }
    else {
        $rootScope.page_title = 'Flights';
    }
    $scope.prms = $routeParams.prms;

    $scope.scroll_btns = {
        direction: 'horizontal',
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
        width: '100%',
        height: '100%',
        bindingOptions: {

        }

    };
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
    $scope.btn_search = {
        //text: 'Filter',
        type: 'default',
        icon: 'search',
        width: '100%', //37,
        //height: 30,
        onClick: function (e) {
            //$scope.popup_filter_visible = true;
            $scope.bind();
        }
    };
    //  $scope.dt_from = new Date(2021,9, 28);
    //  $scope.dt_to = new Date(2021, 7, 26);
    $scope.dt_from = (new Date());
    $scope.dt_to = (new Date($scope.dt_from)).addDays(0);
    $scope.date_from = {
        displayFormat: "yy MMM dd",
        adaptivityEnabled: true,
        type: "date",
        pickerType: "rollers",
        width: 130,
        useMaskBehavior: true,
        bindingOptions: {
            value: 'dt_from'
        }
    };
    $scope.date_to = {
        displayFormat: "yy MMM dd",
        adaptivityEnabled: true,
        type: "date",
        width: 130,
        pickerType: "rollers",
        useMaskBehavior: true,
        bindingOptions: {
            value: 'dt_to'
        }
    };
    $scope.IsLegLocked = false;
    $scope.btn_mb = {
        text: 'M & B',
        type: 'default',
        //icon: 'search',
        width: 180,

        onClick: function (e) {
            var data = { FlightId: $scope.selectedFlight.FlightId };
            $rootScope.$broadcast('InitMb', data);

        },
        bindingOptions: {
            disabled: 'IsLegLocked'
        }
    };
    $scope.btn_jlog = {
        text: 'Log',
        type: 'default',
        //icon: 'search',
        width: 180,

        onClick: function (e) {
            // alert($scope.preFlight.FuelTotal + '   ' + $scope.preFlight.FuelUsed);
            var rem = null;
            if ($scope.preFlight && $scope.preFlight.FuelTotal && $scope.preFlight.FuelUsed) {
                try {
                    rem = $scope.preFlight.FuelTotal - $scope.preFlight.FuelUsed;
                }
                catch (ee) {
                }

            }
			
			flightService.epGetDRByFlight($scope.selectedFlight.FlightId).then(function (response2) {
				//alert('dr'+response2.JLSignedBy);
				//alert('dr id'+response2.Id);
				 console.log('get dr',response2);
				 
				 var _jlsigned=response2.JLSignedBy;
				 if (!_jlsigned && response2.Data)
					 _jlsigned=response2.Data.JLSignedBy;
					 
				//if (!_jlsigned){
					
				//	General.ShowNotify('Please sign the DISPATCH RELEASE FORM.', 'error');
				//	return;
				//}
				//else
				{
				  var data = { Id: $scope.selectedFlight.FlightId, crewId: $scope.selectedFlight.CrewId, remFuel: rem };

                  $rootScope.$broadcast('InitLogAdd', data);
				}
				
			}, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
			
            

        },
        bindingOptions: {
            disabled: 'IsLegLocked'
        }
    };



    $scope.btn_asr = {
        text: 'ASR',
        type: 'default',
        //icon: 'search',
        width: 180,

        onClick: function (e) {

            //   var data = { Id: $scope.selectedFlight.FlightId, crewId: $scope.selectedFlight.CrewId };
            //if (!$rootScope.getOnlineStatus()) {
            //    alert('You are OFFLINE.Please check your internet connection.');
            //    return;
            //}
            var data = { FlightId: $scope.selectedFlight.FlightId };

            $rootScope.$broadcast('InitAsrAdd', data);

        },
        bindingOptions: {
            disabled: 'IsLegLocked'
        }
    };
    $scope.btn_vr = {
        text: 'Voyage Report',
        type: 'default',
        //icon: 'search',
        width: 180,

        onClick: function (e) {
            //if (!$rootScope.getOnlineStatus()) {
            //    alert('You are OFFLINE.Please check your internet connection.');
            //    return;
            //}
            var data = { FlightId: $scope.selectedFlight.FlightId };

            $rootScope.$broadcast('InitVrAdd', data);

        },
        bindingOptions: {
            disabled: 'IsLegLocked'
        }
    };
    $scope.btn_dr = {
        text: 'Disp. Release',
        type: 'default',
        //icon: 'search',
        width: 180,

        onClick: function (e) {
            //if (!$rootScope.getOnlineStatus()) {
            //    alert('You are OFFLINE.Please check your internet connection.');
            //    return;
            //}
            var data = { FlightId: $scope.selectedFlight.FlightId };

            $rootScope.$broadcast('InitDrAdd', data);

        },
        bindingOptions: {
            disabled: 'IsLegLocked'
        }
    };
    $scope.btn_ofp = {
        text: 'OFP',
        type: 'default',
        //icon: 'search',
        width: 180,

        onClick: function (e) {
            //if (!$rootScope.getOnlineStatus()) {
            //    alert('You are OFFLINE.Please check your internet connection.');
            //    return;
            //}
            var data = { FlightId: $scope.selectedFlight.FlightId ,TNK:$scope.selectedFlight.ACTUALTANKERINGFUEL};

            $rootScope.$broadcast('InitOFPAdd', data);

        },
        bindingOptions: {
            disabled: 'IsLegLocked'
        }
    };
    $scope.leftHeight = $(window).height() - 190;
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
            height: 'leftHeight'
        }

    };
    $scope.rightHeight = $(window).height() - 235;
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
            height: 'rightHeight'
        }

    };
    $scope.clickDate = function (n) {
        //if (n == -7) {
        //    alert(n);
        //    caches.keys().then(function (names) {
        //        for (let name of names)
        //            caches.delete(name);
        //    });
        //    return;
        //}
        var dt1 = new Date();
        var dt2 = (new Date()).addDays(n);
        $scope.dt_from = dt2;
        $scope.dt_to = dt1;
        $scope.bind();
    };
    $scope.clickDay = function (n) {


        //flightService.syncUnsignedOFPS(function (result) { });

        // return;

        var dt = (new Date()).addDays(n);
        $scope.dt_from = dt;
        $scope.dt_to = dt;
        $scope.bind();
    };
    $scope.clickCalendar = function () {
        var data = { initDate: $scope.dt_from };

        $rootScope.$broadcast('InitCalendar', data);
    };
    $scope.selectedFlight = null;
    $scope.preFlight = null;
    $scope.lastFlight = false;
    $scope.getATLClass = function () {
        return $scope.lastFlight ? "button-on" : "button-off";
    };
    $scope.getSelectedClass = function () {
        return $scope.selectedFlight ? "button-on" : "button-off";
    };
    $scope.showFlight = function (item, items, index) {

        $scope.lastFlight = items.length - 1 == index;
        $scope.preFlight = null;
        $scope.selectedFlight = item;

        if (index && index > 0) {
            $scope.preFlight = items[index - 1];

        }

      //  if (item.DutyType == 1165)
      //      $scope.bindCrews($scope.selectedFlight.FlightId);





    };
    ///////////////////////////
    $scope.overwriteLocal = function () {
        $scope.loadingVisible = true;
        flightService.epSyncFlight($scope.checkResult).then(function (response) {
            $scope.loadingVisible = false;

            if (response.IsSuccess) {
                General.ShowNotify(Config.Text_SavedOk, 'success');
                $rootScope.$broadcast('onFlightLocgSaved', response.Data);

            }
        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    $scope.overwriteServer = function () {

        $scope.dto = { Server: true };
        $scope.dto.FlightId = $scope.syncedFlight.FlightId;
        $scope.dto.CrewId = $scope.syncedFlight.CrewId;
        $scope.dto.DelayBlockOff = null;
        $scope.dto.BlockTime = null;
        $scope.dto.FlightTime = null;
        if ($scope.syncedFlight.BlockOff)
            $scope.dto.BlockOffDate = momentFromatFroServerUTC($scope.syncedFlight.BlockOff);
        if ($scope.syncedFlight.BlockOn)
            $scope.dto.BlockOnDate = momentFromatFroServerUTC($scope.syncedFlight.BlockOn);
        if ($scope.syncedFlight.TakeOff)
            $scope.dto.TakeOffDate = momentFromatFroServerUTC($scope.syncedFlight.TakeOff);
        if ($scope.syncedFlight.Landing)
            $scope.dto.LandingDate = momentFromatFroServerUTC($scope.syncedFlight.Landing);

        $scope.dto.FuelRemaining = $scope.syncedFlight.FuelRemaining;
        $scope.dto.FuelUplift = $scope.syncedFlight.FuelUplift;
        $scope.dto.FuelUsed = $scope.syncedFlight.FuelUsed;
        $scope.dto.FuelDensity = $scope.syncedFlight.FuelDensity;
        $scope.dto.FuelTotal = $scope.syncedFlight.FuelTotal;
        ////////////
        $scope.dto.PaxAdult = $scope.syncedFlight.PaxAdult;
        $scope.dto.PaxChild = $scope.syncedFlight.PaxChild;
        $scope.dto.PaxInfant = $scope.syncedFlight.PaxInfant;
        $scope.dto.PaxTotal = $scope.syncedFlight.PaxTotal;

        $scope.dto.BaggageWeight = $scope.syncedFlight.BaggageWeight;
        $scope.dto.CargoWeight = $scope.syncedFlight.CargoWeight;

        $scope.dto.SerialNo = $scope.syncedFlight.SerialNo;
        $scope.dto.LTR = $scope.syncedFlight.LTR;
        $scope.dto.PF = $scope.syncedFlight.PF;

        $scope.dto.RVSM_GND_CPT = $scope.syncedFlight.RVSM_GND_CPT;
        $scope.dto.RVSM_GND_STBY = $scope.syncedFlight.RVSM_GND_STBY;
        $scope.dto.RVSM_GND_FO = $scope.syncedFlight.RVSM_GND_FO;

        $scope.dto.RVSM_FLT_CPT = $scope.syncedFlight.RVSM_FLT_CPT;
        $scope.dto.RVSM_FLT_STBY = $scope.syncedFlight.RVSM_FLT_STBY;
        $scope.dto.RVSM_FLT_FO = $scope.syncedFlight.RVSM_FLT_FO;

        $scope.dto.CommanderNote = $scope.syncedFlight.CommanderNote;

        $scope.dto.AttRepositioning1 = $scope.syncedFlight.AttRepositioning1;
        $scope.dto.AttRepositioning1 = $scope.syncedFlight.AttRepositioning1;


        ///////////////
        //sook
        $scope.dto.JLUserId = $scope.syncedFlight.CrewId;
        $scope.dto.JLDate = momentUtcNow();
        $scope.dto.Version = $scope.syncedFlight.Version;
        $scope.loadingVisible = true;
        flightService.epSaveLogOverwriteServer($scope.dto).then(function (response) {
            $scope.loadingVisible = false;

            if (response.IsSuccess) {
                General.ShowNotify(Config.Text_SavedOk, 'success');
                $rootScope.$broadcast('onFlightLocgSaved', response.Data);

            }
            else {
                General.ShowNotify(response.Data, 'error');
            }
        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    $scope.popup_check2_visible = false;
    $scope.popup_check2 = {
        height: 200,
        width: 400,
        title: 'Alert',
        showTitle: true,

        toolbarItems: [



            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Update Server', onClick: function (e) {
                        $scope.overwriteServer();
                        $scope.popup_check2_visible = false;

                    }
                }, toolbar: 'bottom'
            },
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Update Local', onClick: function (e) {

                        $scope.overwriteLocal();
                        $scope.popup_check2_visible = false;
                    }
                }, toolbar: 'bottom'
            },

        ],

        visible: false,
        dragEnabled: true,
        closeOnOutsideClick: false,
        onShowing: function (e) {

        },
        onShown: function (e) {

        },
        onHiding: function () {

            //$scope.clearEntity();

            $scope.popup_check2_visible = false;

        },
        onContentReady: function (e) {

        },
        bindingOptions: {
            visible: 'popup_check2_visible',


        }
    };
    ///////////////////////////////
    $scope.showPdf = function (item) {
        var data = { url: item.url, caption: item.caption, hidden: item.hidden };

        $rootScope.$broadcast('InitPdfViewer', data);

    };
    //////////////////////////////
    $scope.rmClick = function (flt) {
        //$scope._reqfuel=$scope.selectedFlight.ALT5;

        $scope.popup_rm_visible = true;
    };

    $scope.btn_rm_dd = {
        text: 'Drift Down',
        type: 'default',
        //icon: 'search',
        width: '100%',

        onClick: function (e) {
            //var _url = 'https://apvaresh.ir/upload/clientsfiles/' + fileUrl;
            //$scope.showPdf({ url: _url, caption: 'Report' });
           
            
            var item = { url: routeManuals + 'DriftDown/' + ($scope.selectedFlight.FromAirportIATA + '-' + $scope.selectedFlight.ToAirportIATA)+'.pdf',caption:'DRIFT DOWN'};
            $scope.showPdf(item);
        },

    };

    $scope.btn_rm_dp = {
        text: 'De-Compression Procedure',
        type: 'default',
        //icon: 'search',
        width: '100%',

        onClick: function (e) {
            //DeCompressionProcedure
            var item = { url: routeManuals + 'DeCompressionProcedure/' + ($scope.selectedFlight.FromAirportIATA + '-' + $scope.selectedFlight.ToAirportIATA) + '.pdf', caption: 'DE-COMPRESSION PROCEDURE' };
            $scope.showPdf(item);
        },

    };

    $scope.btn_rm_cp = {
        text: 'CFDA Procedure',
        type: 'default',
        //icon: 'search',
        width: '100%',

        onClick: function (e) {
            //CFDAProcedure
            var item = { url: routeManuals + 'CFDAProcedure/' + ( $scope.selectedFlight.ToAirportIATA) + '.pdf', caption: 'CFDA PROCEDURE' };
            $scope.showPdf(item);
        },

    };

    $scope.btn_rm_ab = {
        text: 'Area Briefing',
        type: 'default',
        //icon: 'search',
        width: '100%',

        onClick: function (e) {
            //AreaBriefing
            var item = { url: routeManuals + 'AreaBriefing/' + ($scope.selectedFlight.FromAirportIATA ) + '.pdf', caption: 'AREA BRIEFING' };
            $scope.showPdf(item);
        },

    };


    $scope.popup_rm_visible = false;
    $scope.popup_rm = {
        height: 300,
        width: 280,
        title: 'Route Manual',
        showTitle: true,

        toolbarItems: [


            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'danger', text: 'Close', onClick: function (e) {


                        $scope.popup_rm_visible = false;
                    }
                }, toolbar: 'bottom'
            },

        ],

        visible: false,
        dragEnabled: true,
        closeOnOutsideClick: false,
        onShowing: function (e) {

        },
        onShown: function (e) {

        },
        onHiding: function () {

            //$scope.clearEntity();

            $scope.popup_rm_visible = false;

        },
        onContentReady: function (e) {

        },
        bindingOptions: {
            visible: 'popup_rm_visible',


        }
    };

    ////////////////////////////////////////
    $scope.reqFuelClick = function (flt) {
        //$scope._reqfuel=$scope.selectedFlight.ALT5;
         //console.log($scope.selectedFlight);
        $scope.popup_prf_visible = true;
    };
    $scope.popup_prf_visible = false;
    $scope.popup_prf = {
        height: 530,
        width: 450,
        title: 'Requested Fuel',
        showTitle: true,

        toolbarItems: [



            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Save', onClick: function (e) {
                        if (!$scope.selectedFlight.FuelPlanned)
                            return;
                        var dto = { FlightId: $scope.selectedFlight.FlightId
						, Due: $scope.selectedFlight.ALT3
						, Fuel: $scope.selectedFlight.FuelPlanned 
						,Tankering:$scope.selectedFlight.ACTUALTANKERINGFUEL
						};
                        $scope.loadingVisible = true;
                        flightService.saveRequestedFuel(dto).then(function (response) {
                            $scope.loadingVisible = false;


                            $scope.popup_prf_visible = false;

                        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });


                    }
                }, toolbar: 'bottom'
            },
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'danger', text: 'Close', onClick: function (e) {


                        $scope.popup_prf_visible = false;
                    }
                }, toolbar: 'bottom'
            },

        ],

        visible: false,
        dragEnabled: true,
        closeOnOutsideClick: false,
        onShowing: function (e) {
           $scope.ofp_total_fuel=$scope.selectedFlight.FPFuel+200;
        },
        onShown: function (e) {

        },
        onHiding: function () {

            //$scope.clearEntity();
            $scope._reqfuel = null;
            $scope.popup_prf_visible = false;

        },
        onContentReady: function (e) {

        },
        bindingOptions: {
            visible: 'popup_prf_visible',


        }
    };

	$scope.ofp_total_fuel=null;
    $scope.fuel_cfp = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 100,
        useLargeSpinButtons: true,
        min: 0,
        showSpinButtons: false,
        readOnly: true,
        bindingOptions: {
           // value: "selectedFlight.FPFuel"
			value:'ofp_total_fuel',
        },

    };
    $scope._reqfuel = null;
    $scope.fuel_prf = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 100,
        useLargeSpinButtons: true,
        min: 0,
        showSpinButtons: false,

        bindingOptions: {
            value: "selectedFlight.FuelPlanned"
        },

    };
    $scope.fuel_due = {
        height: 50,
        bindingOptions: {
            value: "selectedFlight.ALT3"
        }
    }
	
	
	$scope.fuel_acttankering = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 0,
        useLargeSpinButtons: true,
        min: 0,
        showSpinButtons: false,
         onValueChanged: function (arg) {
			 
			 $scope.selectedFlight.ACTUALTOTALFUEL=$scope.selectedFlight.OFPTOTALFUEL+($scope.selectedFlight.ACTUALTANKERINGFUEL-$scope.selectedFlight.OFPTANKERINGFUEL);
		 },
        bindingOptions: {
            value: "selectedFlight.ACTUALTANKERINGFUEL"
        },

    };
    ////////////////////////////
    $scope.popup_loading_visible = false;
    $scope.popup_loading = {
        height: 120,
        width: '100%',
        title: 'Message',
        showTitle: false,
        shading: true,
        toolbarItems: [



            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'danger', text: 'Cloas', onClick: function (e) {

                        $scope.popup_loading_visible = false;

                    }
                }, toolbar: 'bottom'
            },


        ],
        position: 'top',
        animation: { show: { type: 'fadeIn', duration: 400 }, hide: { type: 'fadeOut', duration: 400 } },
        visible: false,
        dragEnabled: true,
        closeOnOutsideClick: false,
        onShowing: function (e) {

        },
        onShown: function (e) {

        },
        onHiding: function () {

            //$scope.clearEntity();

            $scope.popup_loading_visible = false;

        },
        onContentReady: function (e) {

        },
        bindingOptions: {
            visible: 'popup_loading_visible',


        }
    };
    ////////////////////////////
    $scope.syncedFlight = null;
    //doolmah
    $scope.syncFlight = function (item) {
        if (!$rootScope.getOnlineStatus()) {
            alert('You are OFFLINE.Please check your internet connection.');
            return;
        }
        $rootScope.checkInternet(function (st) {
            if (st) {
                flightService.autoSyncLogsNew(function (data) {

                    console.log('Synced Log Result ', data);

                });
            }
            else {

                alert('The application cannot connect to the Server. Please check your internet connection.');
                return;
            }
        });

        //var fid = item.FlightId;
        //flightService.epGetFlightLocal(fid).then(function (response) {
        //    if (response.IsSuccess) {
        //        $scope.syncedFlight = response.Data;
        //        var dtoCheck = { JLDate: $scope.syncedFlight.JLDate, CrewId: $scope.syncedFlight.CrewId, FlightId: $scope.syncedFlight.FlightId };
        //        $scope.loadingVisible = true;
        //        flightService.epCheckLog(dtoCheck).then(function (response) {
        //            $scope.loadingVisible = false;
        //            $scope.checkResult = response.Data;

        //            if (($scope.checkResult.JLUserId && $scope.checkResult.JLUserId != $scope.syncedFlight.JLUserId)
        //                || ($scope.checkResult.JLUserId && getTimeForSync($scope.checkResult.JLDate) > getTimeForSync($scope.syncedFlight.JLDate))
        //            ) {
        //                $scope.checkResult.JLDate2 = moment($scope.checkResult.JLDate).format('YYYY-MMM-DD HH:mm');
        //                $scope.popup_check2_visible = true;
        //            }
        //            else {

        //                $scope.overwriteServer();
        //            }
        //        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

        //    }

        //}, function (err) { });
    };
    $scope.getDutyType = function (flt) {
        if (!flt)
            return "";
        return flt.DutyTypeTitle;

    };
    $scope.getTimeDuration = function (x) {
        var str1 = $rootScope.getTimeHHMM2(x, 'DutyStart');
        var str2 = $rootScope.getTimeHHMM2(x, 'DutyEnd');
        if (str1 == str2 && str1 == '0000')
            return 'all-day';
        return str1 + ' - ' + str2;
    };
    $scope.flights = null;
    $scope.groupedFlights = null;
    $scope.getInfoClass = function (g, obj) {
        return "hasInfo";
        return g[obj] && g[obj].length > 0 ? "hasInfo" : '';
    };
    $scope.getSIGWXClass = function (g, obj) {
        return '';
        return g[obj] ? "hasInfo" : '';
    };
    $scope.formatDateTime = function (dt) {
        return moment(dt).format('YYYY-MM-DD HH:mm');
    };
    //$scope._getTAF = async function (_g) {
    //    var deferred = $q.defer();
    //    flightService.getTAFs(_g.FDPId).then(function (_taf) {

    //       // if (_taf.IsSuccess)
    //       //     _g.TAF = _taf.Data;
    //        deferred.resolve(_taf);
    //    }, function (err) { deferred.reject({ IsSuccess:false }); });
    //    return deferred.promise;

    //};
    //$scope.getTAF = function (_g) {
    //    return $scope._getTAF(_g);
    //};
    var tabs = [
        { text: "AVIATION WEATHER CENTER", id: 'adds', visible_btn: false },
        { text: "AVMET WEATHER", id: 'avmet', visible_btn: false },
         { text: "IRIMO (IRAN)", id: 'irimo', visible_btn: false },


    ];
    $scope.tabs = tabs;
    $scope.selectedTabIndex = -1;
    $scope.$watch("selectedTabIndex", function (newValue) {

        try {
            $scope.selectedTab = tabs[newValue];
            $('.tab').hide();
            $('.' + $scope.selectedTab.id).fadeIn(100, function () {


            });




        }
        catch (e) {

        }

    });
    $scope.tabs_options = {


        onItemClick: function (arg) {
            //$scope.selectedTab = arg.itemData;

        },
        bindingOptions: {

            dataSource: { dataPath: "tabs", deep: true },
            selectedIndex: 'selectedTabIndex'
        }

    };


    $scope.scroll_folder_height = $(window).height() - 100;
    $scope.scroll_folder = {
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
            height: 'scroll_folder_height'
        }

    };
    $scope.popup_forlder_visible = false;
    $scope.popup_folder = {
        height: $(window).height() - 200,
        width: $(window).width() - 100,
        title: 'Folder',
        showTitle: true,

        toolbarItems: [




            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'danger', text: 'Close', onClick: function (e) {


                        $scope.popup_folder_visible = false;
                    }
                }, toolbar: 'bottom'
            },

        ],

        visible: false,
        dragEnabled: true,
        closeOnOutsideClick: false,
        onShowing: function (e) {
            $scope.selectedTabIndex = 0;
        },
        onShown: function (e) {
            $scope.updateDr();
        },
        onHiding: function () {

            //$scope.clearEntity();

            $scope.popup_folder_visible = false;

        },
        onContentReady: function (e) {

        },
        fullScreen: true,
        bindingOptions: {
            visible: 'popup_folder_visible',


        }
    };
	//////////////////////////////////////////////
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
    $scope.click_station_metar = function (x) {
        //var index = $scope.selectedStations.indexOf(x);
        //if (index != -1)
        //    $scope.selectedStations.splice(index, 1);
        //else
        //    $scope.selectedStations.push(x);
        $scope.selectedStations = [];
        $scope.selectedStations.push(x);

        $scope.filtered_metar = Enumerable.From($scope.fdp.METAR)
            .Where(function (x) { return $scope.selectedStations.indexOf(x.StationId) != -1; })
            .OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
                return Number(moment(new Date(x.observation_time)).format('YYMMDDHHmm'));

            }).Take(10).ToArray();

    };
	$scope.click_station_taf = function (x) {
        //var index = $scope.selectedStations.indexOf(x);
        //if (index != -1)
        //    $scope.selectedStations.splice(index, 1);
        //else
        //    $scope.selectedStations.push(x);
        $scope.selectedStations = [];
        $scope.selectedStations.push(x);

        $scope.filtered_taf = Enumerable.From($scope.fdp.TAF)
            .Where(function (x) { return $scope.selectedStations.indexOf(x.StationId) != -1; })
        .OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
            return Number(moment(new Date(x.IssueTime)).format('YYMMDDHHmm'));

        }).Take(10).ToArray();

    };
	
	$scope.click_station_notam = function (x) {
        
        $scope.selectedStations = [];
        $scope.selectedStations.push(x);

         $scope.filtered_notam = Enumerable.From($scope.fdp.NOTAM)
            .Where(function (x) { return $scope.selectedStations.indexOf(x.StationId) != -1; })
            .OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ToArray();

    };
	
	$scope.metar_update_date="";
	$scope.bind_metar = function (g) {
        $scope.fdp = g;
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
        //$scope.selectedStations = [];
		if ($scope.selectedStations.length==0)
          $scope.selectedStations.push(Enumerable.From($scope.stations).FirstOrDefault());
        $scope.filtered_metar = Enumerable.From($scope.fdp.METAR).OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
            return Number(moment(new Date(x.observation_time)).format('YYMMDDHHmm'));

        }).Take(10).ToArray();
		console.log( $scope.filtered_metar );

        /////////////////////
        //////////////////////
        //nool
         if ($rootScope.getOnlineStatus()) {
			 $scope.metar_update_date='updating....';
			 
            flightService.updateMETARs($scope.fdp.FDPId).then(function (response) {
                
                g.METAR = response.Data;
                $scope.fdp.METAR = response.Data;


                $scope.filtered_metar = Enumerable.From($scope.fdp.METAR)
                    .Where(function (x) { return $scope.selectedStations.indexOf(x.StationId) != -1; })
                    .OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
                        return Number(moment(new Date(x.observation_time)).format('YYMMDDHHmm'));

                    }).Take(10).ToArray();
					 
					$scope.metar_update_date='updated on '+moment(new Date()).format('YYYY-MM-DD HH:mm');
					 



            }, function (err) {   });
        } 
        /////////////////////
        /////////////////////

    };
	
	
	
	$scope.taf_update_date="";
	$scope.bind_taf = function (g) {
        $scope.fdp = g;
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
        //$scope.selectedStations = [];
		if ($scope.selectedStations.length==0)
          $scope.selectedStations.push(Enumerable.From($scope.stations).FirstOrDefault());
        $scope.filtered_taf = Enumerable.From($scope.fdp.TAF).OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
            return Number(moment(new Date(x.observation_time)).format('YYMMDDHHmm'));

        }).Take(10).ToArray();

        /////////////////////
        //////////////////////
        //nool
         if ($rootScope.getOnlineStatus()) {
			 $scope.taf_update_date='updating....';
            flightService.updateTAFs($scope.fdp.FDPId).then(function (response) {
                
                g.TAF = response.Data;
                $scope.fdp.TAF = response.Data;


                $scope.filtered_taf = Enumerable.From($scope.fdp.TAF)
                    .Where(function (x) { return $scope.selectedStations.indexOf(x.StationId) != -1; })
                    .OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
                        return Number(moment(new Date(x.observation_time)).format('YYMMDDHHmm'));

                    }).Take(10).ToArray();
					 
					$scope.taf_update_date='updated on '+moment(new Date()).format('YYYY-MM-DD HH:mm');
					



            }, function (err) {   });
        } 
        /////////////////////
        /////////////////////

    };
	
	
	$scope.notam_update_date="";
	$scope.bind_notam = function (g) {
        $scope.fdp = g;
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
        $scope.stations.push('OIIX');
		
		$scope.escapes = [];
        $.each($scope.fdp.items, function (_i, _d) {
			try{
            var ess =_d.ALT4? _d.ALT4.split(','):null;
			if (ess)
            $.each(ess, function (_j, _x) {
                $scope.escapes.push(_x);
            });
			} catch(eeee){}


        });
        
        $scope.escapes = Enumerable.From($scope.escapes).Where(function (x) { return x && x != '-' && $scope.stations.indexOf(x) == -1; }).Distinct().ToArray();
        $.each($scope.escapes, function (_i, _d) {
            $scope.stations.push(_d);
        });
        
        
       if ($scope.selectedStations.length==0)
          $scope.selectedStations.push(Enumerable.From($scope.stations).FirstOrDefault());
       
        $scope.filtered_notam = Enumerable.From($scope.fdp.NOTAM).OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ToArray();
        if ($rootScope.getOnlineStatus()) {
			 $scope.notam_update_date='updating....';
			flightService.updateNOTAMs($scope.fdp.FDPId).then(function (response) {
                            
                           
							
							 g.NOTAM = response.Data;
                             $scope.fdp.NOTAM = response.Data;


                            $scope.filtered_notam = Enumerable.From($scope.fdp.NOTAM)
                                .Where(function (x) { return $scope.selectedStations.indexOf(x.StationId) != -1; })
                                .OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ToArray();

                            $scope.notam_update_date='updated on '+moment(new Date()).format('YYYY-MM-DD HH:mm');

                        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

          };
			
			
		}
         
	
	
	
	
	///////////////////////////////////////////////
	$scope.scroll_f2_height = $(window).height() - 250;
    $scope.scroll_metar = {
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
            height: 'scroll_f2_height'
        }

    };
	$scope.scroll_taf = {
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
            height: 'scroll_f2_height'
        }

    };
	$scope.scroll_notam = {
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
            height: 'scroll_f2_height'
        }

    };
	 var f_tabs = [
        { text: "METAR", id: 'metar', visible_btn: false },
        { text: "TAF", id: 'taf', visible_btn: false },
        { text: "NOTAM", id: 'notam', visible_btn: false },
		{ text: "Significant Weather", id: 'sigwx', visible_btn: false },
		{ text: "Wind & Temperature", id: 'windt', visible_btn: false },
		{ text: "Weather", id: 'wxf', visible_btn: false },


    ];
    $scope.f_tabs = f_tabs;
    $scope.f_selectedTabIndex = -1;
    $scope.$watch("f_selectedTabIndex", function (newValue) {
        
        try {
            $scope.f_selectedTab = f_tabs[newValue];
            $('.ftab').hide();
            $('.' + $scope.f_selectedTab.id).fadeIn(100, function () {
                  if ($scope.f_selectedTab.id=='metar'){
					  
					   $scope.bind_metar($scope.selectedGroup);
				  }
				  if ($scope.f_selectedTab.id=='taf'){
					  
					   $scope.bind_taf($scope.selectedGroup);
				  }
				   if ($scope.f_selectedTab.id=='notam'){
					  
					   $scope.bind_notam($scope.selectedGroup);
				  }
				    if ($scope.f_selectedTab.id=='wxf'){
					  
					  // $scope.init_windy();
				  }
				  
				  

            });




        }
        catch (e) {

        }

    });
	
    $scope.folder_tabs = {


        onItemClick: function (arg) {
            //$scope.selectedTab = arg.itemData;

        },
        bindingOptions: {

            dataSource: { dataPath: "f_tabs", deep: true },
            selectedIndex: 'f_selectedTabIndex'
        }

    };
	
	
	
	
	
	
	 $scope.popup_folder2_visible = false;
    $scope.popup_folder2 = {
        height: $(window).height() - 200,
        width: $(window).width() - 100,
        title: 'Folder',
        showTitle: true,

        toolbarItems: [



 
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'danger', text: 'Close', onClick: function (e) {


                        $scope.popup_folder2_visible = false;
                    }
                }, toolbar: 'bottom'
            },

        ],

        visible: false,
        dragEnabled: true,
        closeOnOutsideClick: false,
        onShowing: function (e) {
            $scope.selectedTabIndex = 0;
        },
        onShown: function (e) {
			//$('<div id="windy"></div>').appendTo('#windy-box');
			$scope.f_selectedTabIndex = 0;
			
            //$scope.updateDr();
			$('#windy-box').height($(window).height()-300);
        },
        onHiding: function () {
            //$('#windy').remove();
 
            $scope.popup_folder2_visible = false;

        },
        onContentReady: function (e) {

        },
        fullScreen: true,
        bindingOptions: {
            visible: 'popup_folder2_visible',


        }
    };

    $scope.updateDr = function () {
        // console.log($scope.fdp);
        $.each($scope.selectedGroup.items, function (_i, _f) {
            flightService.epGetDRByFlight(_f.FlightId).then(function (response2) {
                var dr = response2.Data;
                if (!dr) {
                    dr = {
                        Id: -1,
                        ActualWXDSP: true,
                        ActualWXCPT: false,
                        WXForcastDSP: true,

                        WXForcastCPT: false,
                        SigxWXDSP: true,
                        SigxWXCPT: false,
                        WindChartDSP: true,
                        WindChartCPT: false,
                        NotamDSP: true,
                        NotamCPT: false,
                        ComputedFligthPlanDSP: true,
                        ComputedFligthPlanCPT: false,
                        ATCFlightPlanDSP: true,
                        ATCFlightPlanCPT: false,
                        PermissionsDSP: true,
                        PermissionsCPT: false,
                        JeppesenAirwayManualDSP: true,
                        JeppesenAirwayManualCPT: false,
                        MinFuelRequiredDSP: true,
                        MinFuelRequiredCPT: false,
                        GeneralDeclarationDSP: true,
                        GeneralDeclarationCPT: false,
                        FlightReportDSP: true,
                        FlightReportCPT: false,
                        TOLndCardsDSP: true,
                        TOLndCardsCPT: false,
                        LoadSheetDSP: true,
                        LoadSheetCPT: false,
                        FlightSafetyReportDSP: true,
                        FlightSafetyReportCPT: false,
                        AVSECIncidentReportDSP: true,
                        AVSECIncidentReportCPT: false,
                        OperationEngineeringDSP: true,
                        OperationEngineeringCPT: false,
                        VoyageReportDSP: true,
                        VoyageReportCPT: false,
                        PIFDSP: true,
                        PIFCPT: false,
                        GoodDeclarationDSP: true,
                        GoodDeclarationCPT: false,
                        IPADDSP: true,
                        IPADCPT: false,
                    };
                    dr.FlightId = _f.FlightId;
                    $scope.fillFuel(_f, dr);

                }
                if (dr) {
                    dr.NotamCPT = true;
                    dr.ActualWXCPT = true;
                    dr.WXForcastCPT = true;
                    dr.SigxWXCPT = true;
                    dr.WindChartCPT = true;

                    flightService.saveDR(dr).then(function (response2) {


                    }, function (err) {

                    });
                }
            }, function (err) { });
        });

    };
    $scope.fillFuel = function (flt, dr) {
        //$scope.flight 
        // alert($scope.flight.FuelRemaining);
        // alert($scope.flight.FuelUplift);
        if ((!flt.FuelRemaining && flt.FuelRemaining !== 0) || (!flt.FuelUplift && flt.FuelUplift !== 0)) {
            dr.MinFuelRequiredPilotReq = null;
            return;
        }
        var remaining = flt.FuelRemaining ? Number(flt.FuelRemaining) : 0;
        var uplift = flt.FuelUplift ? Number(flt.FuelUplift) : 0;
        var total = remaining + uplift;
        dr.MinFuelRequiredPilotReq = total;
    };




    $scope.showWind = function (lvl, valid) {
        var dt = moment(new Date($scope.selectedGroup.items[0].STADayLocal)).format('YYYYMMDD');
        //WIND_ADDS_20210823_FL180_VALID30
        var fn = 'WIND_ADDS_' + dt + '_FL' + lvl + '_VALID' + valid + '.png';
        var _url = staticFiles + 'Weather/WIND/ADDS/' + fn;
        $scope.showImage({ url: _url, caption: 'Wind & Temperature Level: ' + lvl + ' Valid: ' + valid });
    };
    $scope.showIRIMOSIGWX = function (valid, rem) {
        //SIGWX_IRIMO_20210824_VALID00LVLIRAN
        var dt = moment(new Date($scope.selectedGroup.items[0].STADayLocal)).format('YYYYMMDD');
        var fn = 'SIGWX_IRIMO_' + dt + '_VALID' + valid + 'LVL' + 'IRAN' + '.png';
        var _url = staticFiles + 'Weather/SIGWX/IRIMO/' + fn;
        $scope.showImage({ url: _url, caption: 'SIGWX Chart' + ' Valid: ' + rem });

    };
    $scope.showIRIMOFF = function (valid) {
        //FF_IRIMO_20210824_VALID00LVLIRAN
        var dt = moment(new Date($scope.selectedGroup.items[0].STADayLocal)).format('YYYYMMDD');
        var fn = 'FF_IRIMO_' + dt + '_VALID' + valid + 'LVL' + 'IRAN' + '.pdf';
        var _url = staticFiles + 'Weather/FF/IRIMO/' + fn;
        $scope.showPdf({ url: _url, caption: 'Wind & Temperature' + ' Valid: ' + valid });
    };
    $scope.showAVMETSIGWX = function (valid, rem) {
        //SIGWX_IRIMO_20210824_VALID00LVLIRAN
        var dt = moment(new Date($scope.selectedGroup.items[0].STADayLocal)).format('YYYYMMDD');
        var fn = dt + '-' + 'sig' + valid + '.png';
        var _url = staticFiles + 'Weather/AVMET/' + fn;

        $scope.showImage({ url: _url, caption: 'SIGWX Chart' + ' Valid: ' + rem });

    };
	 $scope.showSIGWX = function (valid ) {
		 //sigwx_20231203_0006
        //SIGWX_IRIMO_20210824_VALID00LVLIRAN
        var dt = moment(new Date($scope.selectedGroup.items[0].STADayLocal)).format('YYYYMMDD');
        var fn = 'sigwx_'+dt+'_'+valid + '.png';
        var _url = staticFiles + 'Weather/SIGWX/ADDS/' + fn;

        $scope.showImage({ url: _url, caption: 'SIGWX Chart' + ' Valid: ' + dt+' '+valid });

    };
    $scope.showImage = function (item) {
        var data = { url: item.url, caption: item.caption };

        $rootScope.$broadcast('InitImageViewer', data);
    };
    $scope.showPdf = function (item) {
        var data = { url: item.url, caption: item.caption, hidden: item.hidden };

        $rootScope.$broadcast('InitPdfViewer', data);

    };
    $scope.folderSIGWX = [];
    function replaceAll(str, find, replace) {
        return str.replace(new RegExp(find, 'g'), replace);
    }
    $scope.selectedGroup = null;
    $scope.folderClick = function (g) {
        $scope.selectedGroup = g;
        $scope.folderSIGWX = [];
        var dates = [];
        $.each(g.items, function (_i, _d) {
            dates.push(moment(new Date(_d.STDDayLocal)).format('YYYY-MM-DD'));
            dates.push(moment(new Date(_d.STADayLocal)).format('YYYY-MM-DD'));
        });
        dates = Enumerable.From(dates).Distinct().ToArray();
        $.each(dates, function (_i, _d) {
            var sigwx = {
                source: g,
                date: _d,
                items: [],
            };
            sigwx.items.push({ caption: 'SIGWX Chart', no: '2105', title: 'Current', url: staticFiles + 'Weather/SIGWX/ADDS/SIGWX_ADDS_' + replaceAll(_d, '-', '') + '_2105.png' });
            sigwx.items.push({ caption: 'SIGWX Chart', no: '3105', title: 'Previous', url: staticFiles + 'Weather/SIGWX/ADDS/SIGWX_ADDS_' + replaceAll(_d, '-', '') + '_3105.png' });
            $scope.folderSIGWX.push(sigwx);
        });
        $scope.popup_folder2_visible = true;
    };

    $scope.IsSJLVisible = function (g) {
        return true;
        var first = g.items[0];
        var last = g.items[g.items.length - 1];
        var diff = Math.abs((new Date()).getTime() - (new Date(last.STALocal)).getTime()) / 3600000;
        return diff <= 24 && ($scope.employeeId == first.PICId || $scope._user == 'bolandi');

    };
    $scope.drClick = function (g) {
        var first = g.items[0];
        var data = { FlightId: first.FlightId };

        $rootScope.$broadcast('InitDrAdd', data);
    };
	
	$scope.get_error_sign=function(e){
		
		if ( e)
			return '*';
		return '';
	};
	$scope.popup_validate_visible = false;
    $scope.popup_validate = {
        height: 300,
        width: 550,
        title: 'Validation',
        showTitle: true,

        toolbarItems: [




            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'danger', text: 'Close', onClick: function (e) {


                        $scope.popup_validate_visible = false;
                    }
                }, toolbar: 'bottom'
            },

        ],

        visible: false,
        dragEnabled: true,
        closeOnOutsideClick: false,
        onShowing: function (e) {
           
        },
        onShown: function (e) {

        },
        onHiding: function () {

            //$scope.clearEntity();

            $scope.popup_validate_visible = false;

        },
        onContentReady: function (e) {

        },
        fullScreen: false,
        bindingOptions: {
            visible: 'popup_validate_visible',


        }
    };
    $scope.signClick = function (g) {
        return;
		if ($rootScope.getOnlineStatus()) {
            flightService.checkInternet(function (st) {
                if (st) {
                    var ids = Enumerable.From(g.items).Select('$.FlightId').ToArray();
					
					var ids_str=ids.join('_');
					 
					flightService.validateOFPs(ids_str).then(function (ov_res) {
			           console.log('vallidate ofp',ov_res);
					    $scope.ds_validation=ov_res.Data?ov_res.Data:[];
						var has_error=Enumerable.From($scope.ds_validation).Where('$.has_error').ToArray();
						
					   if (!has_error || has_error.length==0){
						   //validate log
						   /////////
						    var data = { FlightId: ids_str, documentType: 'ofpsall' };

                            $rootScope.$broadcast('InitSignAdd', data);
						   
						   ////////
						   
					   }else
					   {
						   var ov_errs=[];
						   $.each(ov_res.Data,function(_u,_p){
							   ov_errs.push(_p.flight_no);
						   });
						   // General.ShowNotify("Please fill MANDATORY fields in OFPs of ("+ov_errs.join(', ')+")", 'error');
						  
						   $scope.popup_validate_visible=true;
							
							// var data = { FlightId: ids_str, documentType: 'ofpsall' };

                           // $rootScope.$broadcast('InitSignAdd', data);
							
							
					   }
					
					}, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
					
					
                    


                }
                else {
                    General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                }

            });
        }
	}
	
	
    $scope.sjlClick = function (g) {

        if ($rootScope.getOnlineStatus()) {
            flightService.checkInternet(function (st) {
                if (st) {
                    var ids = Enumerable.From(g.items).Select('$.FlightId').ToArray();
                    var data = { FlightId: ids, documentType: 'jlog' };

                    $rootScope.$broadcast('InitSignAdd', data);


                }
                else {
                    General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                }

            });
        }

    };

    $scope.jlClick = function (g) {

        if ($rootScope.getOnlineStatus()) {
            flightService.checkInternet(function (st) {
                if (st) {
                    var first = g.items[0];
                    var last = g.items[g.items.length - 1];
                    var id = first.FlightId;
                    var ids = Enumerable.From(g.items).Select('$.FlightId').ToArray();
                    var data = { FlightId: id, LastSTA: last.STALocal, PICId: first.PICId, FlightIds: ids };

                    $rootScope.$broadcast('InitJLAdd', data);


                }
                else {
                    General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                }

            });
        } else {
            General.ShowNotify("You are OFFLINE.This feature can not be used in OFFLINE mode", 'error');
        }

    };

    $scope.sofplClick = function (g) {
        //flightService.transferOPFProps(Enumerable.From(g.items).Select('$.FlightId').ToArray());
        //return;
        if ($rootScope.getOnlineStatus()) {
            flightService.checkInternet(function (st) {
                if (st) {
                    var ids = Enumerable.From(g.items).Select('$.FlightId').ToArray();
                    var data = { FlightId: ids, documentType: 'ofpsall' };

                    $rootScope.$broadcast('InitSignAdd', data);

                }
                else {
                    General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                }

            });
        }
        else {
            General.ShowNotify("You are OFFLINE.This feature can not be used in OFFLINE mode", 'error');
        }

    };

    //12-05
    function _getWindCharts(grps) {
        var lvls = ['340', '300', '240', '180'];
        var valids = ['06', '12', '18', '24', '30', '36'];
        var arr = [];
        $.each(grps, function (_k, _g) {
            var firstSTD = new Date(_g.items[0].STDLocal);
            var lastSTA = new Date(_g.items[_g.items.length - 1].STALocal);
            var diffSTD = Math.abs((new Date()).getTime() - (firstSTD).getTime()) / 3600000;
            var diffSTA = Math.abs((new Date()).getTime() - (lastSTA).getTime()) / 3600000;
            var std = moment(firstSTD).format('YYYYMMDD');
            var std_dd = Number(moment(firstSTD).format('DD'));
            var sta = moment(lastSTA).format('YYYYMMDD');
            var sta_dd = Number(moment(lastSTA).format('DD'));
            var now_dd = Number(moment(new Date()).format('DD'));

            // var arr = [];
            if (diffSTA <= 24 && sta_dd <= now_dd)
                arr.push(sta);
            if (diffSTD <= 24 && std_dd <= now_dd)
                arr.push(std);








        });
        ////////////
        arr = Enumerable.From(arr).Distinct().ToArray();
        console.log('wind dates', arr);
        $.each(arr, function (_i, dt) {

            //var dt = moment(new Date(_g.items[0].STADayLocal)).format('YYYYMMDD')
            $.each(lvls, function (_i, lvl) {
                $.each(valids, function (_j, valid) {
                    console.log('get wind ', dt + '  ' + lvl + '  ' + valid);
                    var fn = 'WIND_ADDS_' + dt + '_FL' + lvl + '_VALID' + valid + '.png';
                    var _url = staticFiles + 'Weather/WIND/ADDS/' + fn;
                    $http.get(_url).then(res => { console.log(_url); });

                });
            });
        });

        ///////////////////////////

    }
    //12-05 
    function _getIRIMOSigwx(grps) {
        //SIGWX_IRIMO_20210824_VALID12LVLIRAN
        var lvls = ['IRAN'];
        var valids = ['00', '06', '12', '18'];
        var arr = [];
        $.each(grps, function (_k, _g) {
            var firstSTD = new Date(_g.items[0].STDLocal);
            var lastSTA = new Date(_g.items[_g.items.length - 1].STALocal);
            var diffSTD = Math.abs((new Date()).getTime() - (firstSTD).getTime()) / 3600000;
            var diffSTA = Math.abs((new Date()).getTime() - (lastSTA).getTime()) / 3600000;

            var std = moment(firstSTD).format('YYYYMMDD');
            var std_dd = Number(moment(firstSTD).format('DD'));
            var sta = moment(lastSTA).format('YYYYMMDD');
            var sta_dd = Number(moment(lastSTA).format('DD'));
            var now_dd = Number(moment(new Date()).format('DD'));


            if (diffSTA <= 24 && sta_dd <= now_dd)
                arr.push(sta);
            if (diffSTD <= 24 && std_dd <= now_dd)
                arr.push(std);
            ////
            //var dt = moment(new Date(_g.items[0].STADayLocal)).format('YYYYMMDD')
            //$.each(lvls, function (_i, lvl) {
            //    $.each(valids, function (_j, valid) {
            //        var fn = 'SIGWX_IRIMO_' + dt  + '_VALID' + valid +'LVL'+lvl+ '.png';
            //        var _url = staticFiles + 'Weather/SIGWX/IRIMO/' + fn;
            //        $http.get(_url).then(res => { console.log(_url); });

            //    });
            //});
            /////

        });
        ///////////////
        arr = Enumerable.From(arr).Distinct().ToArray();
        console.log('wx irimo dates', arr);
        $.each(arr, function (_i, dt) {

            // var dt = moment(new Date(_g.items[0].STADayLocal)).format('YYYYMMDD')
            $.each(lvls, function (_i, lvl) {
                $.each(valids, function (_j, valid) {
                    console.log('get irimo ', dt + '  ' + lvl + '   ' + valid);
                    var fn = 'SIGWX_IRIMO_' + dt + '_VALID' + valid + 'LVL' + lvl + '.png';
                    var _url = staticFiles + 'Weather/SIGWX/IRIMO/' + fn;
                    $http.get(_url).then(res => { console.log(_url); });

                });
            });
        });

        ///////////////


    }
    function _getIRIMOFF(grps) {
        //FF_IRIMO_20210824_VALID00LVLIRAN
        //var lvls = ['IRAN'];
        //var valids = ['00', '06',/* '12', '18'*/  ]; 
        //$.each(grps, function (_k, _g) {
        //    var dt = moment(new Date(_g.items[0].STADayLocal)).format('YYYYMMDD')
        //    $.each(lvls, function (_i, lvl) {
        //        $.each(valids, function (_j, valid) {
        //            var fn = 'FF_IRIMO_' + dt + '_VALID' + valid + 'LVL' + lvl + '.pdf';
        //            var _url = staticFiles + 'Weather/FF/IRIMO/' + fn;
        //            var _url0 = clientBase + 'pdfjsmodule/viewer.html?file=' + _url;
        //            $http.get(_url0).then(res => {
        //                console.log(_url0);  
        //                if (valid == '06')
        //                    $scope.showPdf({ url: _url, caption: '', hidden: false });
        //            });

        //        });
        //    });

        //});

        //////////////////////////////
        var _g = grps[0];
        var dt = moment(new Date(_g.items[0].STADayLocal)).format('YYYYMMDD');
        var _url1 = clientBase + 'pdfjsmodule/viewer.html?file=' + staticFiles + 'Weather/FF/IRIMO/' + 'FF_IRIMO_' + dt + '_VALID' + '00' + 'LVL' + 'IRAN' + '.pdf';
        $http.get(_url1)
            .then(function (res1) {
                var _url2 = clientBase + 'pdfjsmodule/viewer.html?file=' + staticFiles + 'Weather/FF/IRIMO/' + 'FF_IRIMO_' + dt + '_VALID' + '06' + 'LVL' + 'IRAN' + '.pdf';
                $http.get(_url2)
                    .then(function (res2) { $scope.showPdf({ url: _url2, caption: '06', hidden: false }); })
            }, function (err1) { });


        ///////////////////////////////


    }

    function _getWeatherCharts(grps) {
		var firstSTD = new Date(grps[0].items[0].STDLocal);
		var std = moment(firstSTD).format('YYYYMMDD');
		
		//https://fbpocket.ir/Upload/Weather/SIGWX/ADDS/sigwx_20231203_0006.png
		$http.get(staticFiles + 'Weather/SIGWX/ADDS/sigwx_' + std + '_0006.png').then(
                                //function (xres) { console.log('get avmet 00'); }
        );
		$http.get(staticFiles + 'Weather/SIGWX/ADDS/sigwx_' + std + '_0000.png').then(
                                //function (xres) { console.log('get avmet 00'); }
        );
		$http.get(staticFiles + 'Weather/SIGWX/ADDS/sigwx_' + std + '_0012.png').then(
                                //function (xres) { console.log('get avmet 00'); }
        );
		$http.get(staticFiles + 'Weather/SIGWX/ADDS/sigwx_' + std + '_0018.png').then(
                                //function (xres) { console.log('get avmet 00'); }
        );
		
		                    /*$http.get(staticFiles + 'Weather/AVMET/' + std + '-sig00.png').then(
                                function (xres) { console.log('get avmet 00'); }
                            );
                            $http.get(staticFiles + 'Weather/AVMET/' + std + '-sig06.png').then(
                                function (xres) { console.log('get avmet 06'); }
                            );
                            $http.get(staticFiles + 'Weather/AVMET/' + std + '-sig12.png').then(
                                function (xres) { console.log('get avmet 12'); }
                            );
                            $http.get(staticFiles + 'Weather/AVMET/' + std + '-sig18.png').then(
                                function (xres) { console.log('get avmet 18'); }
                            );*/
		
		return;

        // var lastSTA = moment(new Date(_g.items[_g.items.length - 1].STADayLocal)).format('YYYYMMDD');
        //var firstSTD = moment(new Date(_g.items[0].STDDayLocal)).format('YYYYMMDD'); 
        var arr = [];
        $.each(grps, function (_d, _g) {
            //12-05
            _g.SIGWX2105 = false;
            _g.SIGWX3105 = false;

            var firstSTD = new Date(_g.items[0].STDLocal);
            var lastSTA = new Date(_g.items[_g.items.length - 1].STALocal);
            var diffSTD = Math.abs((new Date()).getTime() - (firstSTD).getTime()) / 3600000;
            var diffSTA = Math.abs((new Date()).getTime() - (lastSTA).getTime()) / 3600000;



            //var std = moment(new Date(_g.items[0].STDDayLocal)).format('YYYYMMDD');

            //var sta = moment(new Date(_g.items[0].STADayLocal)).format('YYYYMMDD');
            var std = moment(firstSTD).format('YYYYMMDD');
            var std_dd = Number(moment(firstSTD).format('DD'));
            var sta = moment(lastSTA).format('YYYYMMDD');
            var sta_dd = Number(moment(lastSTA).format('DD'));
            var now_dd = Number(moment(new Date()).format('DD'));

            // var arr = [];
            if (diffSTA <= 24 && sta_dd <= now_dd)
                arr.push(sta);
            if (diffSTD <= 24 && std_dd <= now_dd)
                arr.push(std);

            //var _dt = arr[0];



        });
        arr = Enumerable.From(arr).Distinct().ToArray();
        console.log('wx dates', arr);
        $.each(arr, function (_i, _dt) {
            console.log('get sigwx_adds ', _dt);
            $http.get(staticFiles + 'Weather/SIGWX/ADDS/SIGWX_ADDS_' + _dt + '_2105.png').then(
                function (response) {
                    //_g.SIGWX2105 = true;
                    $http.get(staticFiles + 'Weather/SIGWX/ADDS/SIGWX_ADDS_' + _dt + '_3105.png').then(
                        function (response) {
                            $http.get(staticFiles + 'Weather/AVMET/' + _dt + '-sig00.png').then(
                                function (xres) { console.log('get avmet 00'); }
                            );
                            $http.get(staticFiles + 'Weather/AVMET/' + _dt + '-sig06.png').then(
                                function (xres) { console.log('get avmet 06'); }
                            );
                            $http.get(staticFiles + 'Weather/AVMET/' + _dt + '-sig12.png').then(
                                function (xres) { console.log('get avmet 12'); }
                            );
                            $http.get(staticFiles + 'Weather/AVMET/' + _dt + '-sig18.png').then(
                                function (xres) { console.log('get avmet 18'); }
                            );
                        }
                    );

                }

            );
        });

    }

    var _tafcnt = 0;
    function _getTAF(_g, grps) {
        _g.tafLoading = true;

        flightService.getTAFs(_g.FDPId, _g.doInfo).then(function (_taf) {

            _g.tafLoading = false;
            _tafcnt++;
            if (_taf.IsSuccess) { _g.TAF = _taf.Data; }

            if (_tafcnt < grps.length) { _getTAF(grps[_tafcnt], grps); }
            else {
                _metarcnt = 0;
                _getMETAR(grps[0], grps);
            }
        }, function (err) { });

    }

    var _metarcnt = 0;
    function _getMETAR(_g, grps) {
        _g.metarLoading = true;
        flightService.getMETARs(_g.FDPId, _g.doInfo).then(function (_taf) {
            _g.metarLoading = false;
            _metarcnt++;
            if (_taf.IsSuccess)
                _g.METAR = _taf.Data;

            if (_metarcnt < grps.length) { _getMETAR(grps[_metarcnt], grps); }
            else {
                _notamcnt = 0;
                _getNOTAM(grps[0], grps);
            }
        }, function (err) { });

    }

    var _notamcnt = 0;
    function _getNOTAM(_g, grps) {
        _g.notamLoading = true;
        flightService.getNOTAMs(_g.FDPId, _g.doInfo).then(function (_taf) {

            _g.notamLoading = false;
            _notamcnt++;
            if (_taf.IsSuccess)
                _g.NOTAM = _taf.Data;

            if (_notamcnt < grps.length) { _getNOTAM(grps[_notamcnt], grps); }

        }, function (err) { });

    }





    $scope.getTAF = function (_g, callback) {
        //var _g = Enumerable.From($scope.groupedFlights).Where('$.FDPId==' + fdpId).FirstOrDefault();
        if (_g) {
            _g.tafLoading = true;
            flightService.getTAFs(_g.FDPId, _g.doInfo).then(function (_taf) {
                _g.tafLoading = false;

                if (_taf.IsSuccess) { _g.TAF = _taf.Data; }
                else
                    _g.TAF = null;
                callback();

            }, function (err) { });
        }
        else
            callback();

    };
    $scope.getMETAR = function (_g, callback) {
        //var _g = Enumerable.From($scope.groupedFlights).Where('$.FDPId==' + fdpId).FirstOrDefault();
        if (_g) {
            _g.metarLoading = true;
            flightService.getMETARs(_g.FDPId, _g.doInfo).then(function (_taf) {
                _g.metarLoading = false;

                if (_taf.IsSuccess) { _g.METAR = _taf.Data; }
                else
                    _g.METAR = null;
                callback();

            }, function (err) { });
        }
        else
            callback();
    };
    $scope.getNOTAM = function (_g, callback) {
        //var _g = Enumerable.From($scope.groupedFlights).Where('$.FDPId==' + fdpId).FirstOrDefault();
        if (_g) {
            _g.notamLoading = true;
            flightService.getNOTAMs(_g.FDPId, _g.doInfo).then(function (_taf) {
                _g.notamLoading = false;

                if (_taf.IsSuccess) { _g.NOTAM = _taf.Data; }
                else
                    _g.NOTAM = null;
                callback();

            }, function (err) { });
        }
        else
            callback();
    };

    $scope.showTAF = function (g) {

        $rootScope.$broadcast('InitTAF', g);
    };
    $scope.showMETAR = function (g) {
        $rootScope.$broadcast('InitMETAR', g);
    };
    $scope.showNOTAM = function (g) {
        $rootScope.$broadcast('InitNOTAM', g);
    };
    $scope.infoClick = function (id, type, obj) {
        switch (type) {
            case 'TAF':
                if (obj[type] && obj[type].length > 0) {
                    $scope.showTAF(obj);
                }
                else {
                    obj.doInfo = 1;
                    $scope.getTAF(obj, function () { obj.doInfo = 0; $scope.showTAF(obj); });
                }
                break;
            case 'METAR':
                if (obj[type] && obj[type].length > 0) {
                    $scope.showMETAR(obj);
                }
                else {
                    obj.doInfo = 1;
                    $scope.getMETAR(obj, function () { obj.doInfo = 0; $scope.showMETAR(obj); });
                }
                break;
            case 'NOTAM':
                if (obj[type] && obj[type].length > 0) {
                    $scope.showNOTAM(obj);
                }
                else {
                    obj.doInfo = 1;
                    $scope.getNOTAM(obj, function () { obj.doInfo = 0; $scope.showNOTAM(obj); });
                }
                break;
            default:
                break;
        }
    };
    $scope.bindInfo = function (grps) {

        var _grps = [];
        $.each(grps, function (_i, _g) {
            if (_g.DutyType == 1165) {
                var isScheduled = Enumerable.From(_g.items).Where(function (x) {
                    return x.FlightStatusId == 1;
                }).FirstOrDefault();
                var today = moment((new Date())).format('YYYYMMDD');
                var lastSTA = moment(new Date(_g.items[_g.items.length - 1].STADayLocal)).format('YYYYMMDD');
                var firstSTD = moment(new Date(_g.items[0].STDDayLocal)).format('YYYYMMDD');
                if (isScheduled && (Number(lastSTA) == Number(today) || Number(firstSTD) == Number(today))) {
                    _g.doInfo = 1;
                    _grps.push(_g);
                }
                else {
                    _g.doInfo = 0;
                    _grps.push(_g);
                }
            }

        });


        _tafcnt = 0;
        //9-18
        // _getTAF(_grps[0], _grps);


        if ($rootScope.getOnlineStatus()) {
            $rootScope.checkInternet(function (st) {
                if (st) {
                    _getTAF(_grps[0], _grps);
                    if (grps && grps.length > 0) {

                        var grpsFlightIds = [];
                        $.each(grps, function (_i, _g) {
                            $.each(_g.items, function (_j, _flt) {
								if (_flt && _flt.FlightId)
                                grpsFlightIds.push(_flt.FlightId);
                            });
                        });
                        var _fdto = { ids: grpsFlightIds };


                        flightService.epGetOFPByFlights(_fdto, function () {  /*$scope.popup_loading_visible = true;*/ }).then(function (_taf) {
                            /*$scope.popup_loading_visible = false;*/




                        }, function (err) { });

                        flightService.epGetDRsByFlights(_fdto).then(function (_taf) {



                        }, function (err) { });

                        //12-05

                        _getWeatherCharts(grps);
                        _getWindCharts(grps);
                        _getIRIMOSigwx(grps);
                        ///////////////////////////


                        //_getWeatherCharts(grps);
                        //_getWindCharts(grps);
                        //_getIRIMOSigwx(grps);

                    }
                    else {
                        //  _getTAF(_grps[0], _grps);
                    }
                }
            });
            // _tafcnt = 0;
            // _getTAF(_grps[0], _grps);


        }


    };

    $scope.bind = function (show) {
        if (!authService.isAuthorized())
            return;

        //flightService.epGetOFPProps(114).then(function (response3) {
        //}, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

        //return;
        //var _d1 = moment($scope.dt_from).format('YYYY-MM-DDTHH:mm:ss');

        //var _d2 = moment($scope.dt_to).format('YYYY-MM-DDTHH:mm:ss');
        var _d1 = moment($scope.dt_from).format('YYYY-MM-DDT00:00:00');

        var _d2 = moment($scope.dt_to).format('YYYY-MM-DDT00:00:00');


        if ($rootScope.userName == 'fazeli') {
            //alert('test1'); 
        }

        $scope.loadingVisible = true;
        flightService.epGetCrewFlights(_d1, _d2).then(function (response) {

            $scope.loadingVisible = false;

            if (response.IsSuccess) {

                flightService.epGetCrewDuties(GlobalUserId, _d1, _d2).then(function (response2) {
                    if (response2.IsSuccess) {

                        $.each(response2.Data, function (_k, _dty) {
                            response.Data.push(_dty);
                        });
                        //response.Data = Enumerable.From(response.Data).OrderBy(function(x) { return DateTimeToNumber(x.IStart);}).ToArray(); 
                    }

                    $scope.flights = response.Data;
                    $scope.groupedFlights = Enumerable.From(response.Data)

                        .GroupBy(function (item) { return item.FDPId + '_' + item.DutyTypeTitle + '_' + item.DutyType; }, null, (key, g) => {
                            var _item = {
                                FDPId: Number(key.split('_')[0]),
                                DutyTypeTitle: key.split('_')[1],
                                DutyType: Number(key.split('_')[2]),
                                METAR: null,
                                TAF: null,
                                NOTAM: null,
                                tafLoading: false,
                                metarLoading: false,
                                notamLoading: false,
                                items: Enumerable.From(g.source).OrderBy(function (x) {
                                    return x.DutyType == 1165 ? DateTimeToNumber(new Date(x.STD)) : 1;
                                }).ToArray(),



                            };
                            _item.IStart = (_item.items[0].DutyType == 1165) ? _item.items[0].STD : _item.items[0].IStart;
                            return _item;
                        }).OrderBy(function (x) {

                            return DateTimeToNumber(x.IStart);

                        }).ToArray();


                    if ($scope.groupedFlights && $scope.groupedFlights.length > 0) {
                        // $.each($scope.groupedFlights, function (_i, _d) {
                        //     _d.IStart = (_d.items[0].DutyType == 1165) ? _d.items[0].STD : _d.items[0].IStart;
                        // });
                        // $scope.groupedFlights = Enumerable.From($scope.groupedFlights).OrderBy(function (x) { return DateTimeToNumber(x.IStart); }).ToArray();

                        $scope.showFlight($scope.groupedFlights[0].items[0], $scope.groupedFlights[0].items, -1);

                       // $scope.bindInfo($scope.groupedFlights);
                    }
                }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });


                //12-04
                //flightService.checkUnsignedOFPs();
            }
            else
                $rootScope.processErorrs(response);

        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    $scope.selectedFlightCrews = [];
    $scope.bindCrews = function (flightId) {
        
        //$scope.loadingVisible = true;
        flightService.epGetFlightCrews(flightId).then(function (response) {
            //$scope.loadingVisible = false;

            if (response.IsSuccess) {
                $scope.selectedFlightCrews = response.Data;

            }
            else
                $rootScope.processErorrs(response);

        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };



    $scope.getFlightClass = function (flt) {
        // var prop = 'FlightId';
        // if (flt.DutyType != 1165)
        //    prop = 'Id';
        if (!$scope.selectedFlight || $scope.selectedFlight.Id != flt.Id)
            return "lib-flight main-bkcolor2-light-imp";
        else
            return "lib-flight main-bkcolor2-light-imp selected";
        //return flt.FlightStatus.toLowerCase();
    }
    /////////////////
    //tolnd
    $scope.btn_to = {
        text: 'T/O',
        type: 'default',
        //icon: 'search',
        width: 150,

        onClick: function (e) {
            //if (!$rootScope.getOnlineStatus()) {
            //    alert('You are OFFLINE.Please check your internet connection.');
            //    return;
            //}
            var data = { FlightId: $scope.selectedFlight.FlightId };

            $rootScope.$broadcast('InitTOAdd', data);

        },
        bindingOptions: {
            disabled: 'IsLegLocked'
        }
    };

    $scope.btn_lnd = {
        text: 'LND',
        type: 'default',
        //icon: 'search',
        width: 150,

        onClick: function (e) {
            //if (!$rootScope.getOnlineStatus()) {
            //    alert('You are OFFLINE.Please check your internet connection.');
            //    return;
            //}
            var data = { FlightId: $scope.selectedFlight.FlightId };

            $rootScope.$broadcast('InitLdgAdd', data);

        },
        bindingOptions: {
            disabled: 'IsLegLocked'
        }
    };

    /////////////////////////////////
    $scope.btn_atc = {
        text: 'AFP',
        type: 'default',
        //icon: 'search',
        width: 120,

        onClick: function (e) {

            if ($scope.selectedFlight.ATCPlan) {
                var _url = staticFiles2 + 'atc/' + $scope.selectedFlight.ATCPlan;
                console.log(_url);
                $scope.showPdf({ url: _url, caption: 'ATC Flight Plan (' + $scope.selectedFlight.FlightNumber + ')' });
            }


        },
        bindingOptions: {
            disabled: 'IsLegLocked'
        }
    };
    $scope.atltitle = 'ATL';
    $scope.btn_atl = {
        text: 'ATL',
        type: 'default',
        //icon: 'search',
        width: 120,

        onClick: function (e) {
            // console.log($scope.selectedFlight);
            // $rootScope.$broadcast('InitCamera', { type: 'ATL', flight: /*$scope.selectedFlight.FlightId*/-1, fdp: $scope.selectedFlight.FDPId});


            flightService.epGetATL($scope.selectedFlight.FDPId).then(function (response) {
                //$scope.loadingVisible = false;
                console.log('ATL', response);
                if (response.IsSuccess) {
                    var data = response.Data;
                    //if (data)
                    var imgdata = { url: data ? data.Data : null, caption: 'ATL', type: 'ATL', flight: -1, fdp: $scope.selectedFlight.FDPId, camera: true };

                    $rootScope.$broadcast('InitImageViewer', imgdata);

                    //  else
                    //      $rootScope.$broadcast('InitCamera', { type: 'ATL', flight: /*$scope.selectedFlight.FlightId*/-1, fdp: $scope.selectedFlight.FDPId });

                }
                else
                    $rootScope.processErorrs(response);

            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });




            //if ($scope.selectedFlight.ATL) {
            //    var _url = staticFiles2+'/atc/'+ $scope.selectedFlight.ATL;
            //    $scope.showPdf({ url: _url, caption: 'ATL (' + $scope.selectedFlight.FlightNumber + ')' });

            //    db.DeleteSeenHistory($scope.selectedFlight.FlightId, 'ATL', function () {
            //        db.AddSeenHistory({ FlightId: $scope.selectedFlight.FlightId, Type: 'ATL' }, function () { $scope.atltitle = 'ATL (✓)'; });
            //    });
            //}

            //db.DeleteSeenHistory($scope.selectedFlight.FlightId, 'ATL', function () {
            //    db.AddSeenHistory({ FlightId: $scope.selectedFlight.FlightId, Type: 'ATL' }, function () { $scope.atltitle = 'ATL (✓)'; });
            //});
        },
        bindingOptions: {
            disabled: 'IsLegLocked',
            text: 'atltitle'
        }
    };
    $scope.permissionClick = function (g) {

    };
	
		$scope.popup_atc_visible = false;
    $scope.popup_atc = {
        height: $(window).height() - 200,
        width: $(window).width() - 100,
        title: 'ATC FLIGHT PLAN',
        showTitle: true,

        toolbarItems: [




            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'danger', text: 'Close', onClick: function (e) {


                        $scope.popup_atc_visible = false;
                    }
                }, toolbar: 'bottom'
            },

        ],

        visible: false,
        dragEnabled: true,
        closeOnOutsideClick: false,
        onShowing: function (e) {
           
        },
        onShown: function (e) {

        },
        onHiding: function () {

            //$scope.clearEntity();

            $scope.popup_atc_visible = false;

        },
        onContentReady: function (e) {

        },
        fullScreen: true,
        bindingOptions: {
            visible: 'popup_atc_visible',


        }
    };
	$scope.atc_area={
        
        bindingOptions: {
        height: '300',
            value: "ATCHtml"
        }
    };
	$scope.atctitle = 'ATC';
    $scope.atcClick = function (g) {
        if (!$scope.selectedFlight)
            return;


        //////////////////////////

       /* if ($scope.selectedFlight.ATCPlan) {
            var _url = staticFiles2 + 'atc/' + $scope.selectedFlight.ATCPlan;

            $scope.showPdf({ url: _url, caption: 'ATC Flight Plan (' + $scope.selectedFlight.FlightNumber + ')' });

            $scope.updateDrByField($scope.selectedFlight, 'ATCFlightPlanCPT');
        }*/
        //////////////////////////
		console.log('ATC',$scope.selectedFlight.ATCPlan);
		  if ($scope.selectedFlight.ATCPlan) {
				 
				if (!$scope.selectedFlight.ATCPlan.includes('atc-')) {
					 
					 $scope.ATCHtml = $scope.selectedFlight.ATCPlan; // $sce.trustAsHtml($scope.selectedFlight.ATCPlan);
					 
					$scope.popup_atc_visible=true;
					$scope.isATCTXT=true;
				}
				else
				{
						$scope.isATCTXT=false;
                     //  var _url = staticFiles2 + '/atc/' + +  $scope.selectedFlight.ATCPlan;
                     //  $scope.showPdf({ url: _url, caption: 'ATC Flight Plan (' + $scope.selectedFlight.FlightNumber + ')' });
			         var _url = 'https://files.airpocket.online/varesh/atc/' +  $scope.selectedFlight.ATCPlan.replace('"', '').replace('"', '').replace("'", "").replace("'", "");
                      window.open(_url);
				}
            }
		
		
		/////////////////////////////

    };

    $scope.updateDrByField = function (flight, field) {
        // console.log($scope.fdp);

        flightService.epGetDRByFlight(flight.FlightId).then(function (response2) {
            var dr = response2.Data;
            if (!dr) {
                dr = {
                    Id: -1,
                    ActualWXDSP: true,
                    ActualWXCPT: false,
                    WXForcastDSP: true,

                    WXForcastCPT: false,
                    SigxWXDSP: true,
                    SigxWXCPT: false,
                    WindChartDSP: true,
                    WindChartCPT: false,
                    NotamDSP: true,
                    NotamCPT: false,
                    ComputedFligthPlanDSP: true,
                    ComputedFligthPlanCPT: false,
                    ATCFlightPlanDSP: true,
                    ATCFlightPlanCPT: false,
                    PermissionsDSP: true,
                    PermissionsCPT: false,
                    JeppesenAirwayManualDSP: true,
                    JeppesenAirwayManualCPT: false,
                    MinFuelRequiredDSP: true,
                    MinFuelRequiredCPT: false,
                    GeneralDeclarationDSP: true,
                    GeneralDeclarationCPT: false,
                    FlightReportDSP: true,
                    FlightReportCPT: false,
                    TOLndCardsDSP: true,
                    TOLndCardsCPT: false,
                    LoadSheetDSP: true,
                    LoadSheetCPT: false,
                    FlightSafetyReportDSP: true,
                    FlightSafetyReportCPT: false,
                    AVSECIncidentReportDSP: true,
                    AVSECIncidentReportCPT: false,
                    OperationEngineeringDSP: true,
                    OperationEngineeringCPT: false,
                    VoyageReportDSP: true,
                    VoyageReportCPT: false,
                    PIFDSP: true,
                    PIFCPT: false,
                    GoodDeclarationDSP: true,
                    GoodDeclarationCPT: false,
                    IPADDSP: true,
                    IPADCPT: false,
                };
                dr.FlightId = flight.FlightId;
                $scope.fillFuel(flight, dr);

            }
            if (dr && !dr[field]) {
                dr[field] = true;
                flightService.saveDR(dr).then(function (response2) {


                }, function (err) {

                });
            }
        }, function (err) { });


    };
    $scope.fillFuel = function (flt, dr) {
        //$scope.flight 
        // alert($scope.flight.FuelRemaining);
        // alert($scope.flight.FuelUplift);
        if ((!flt.FuelRemaining && flt.FuelRemaining !== 0) || (!flt.FuelUplift && flt.FuelUplift !== 0)) {
            dr.MinFuelRequiredPilotReq = null;
            return;
        }
        var remaining = flt.FuelRemaining ? Number(flt.FuelRemaining) : 0;
        var uplift = flt.FuelUplift ? Number(flt.FuelUplift) : 0;
        var total = remaining + uplift;
        dr.MinFuelRequiredPilotReq = total;
    };



    $scope.atlClick = function (g) {
        if (!$scope.selectedFlight)
            return;
        if (!$scope.lastFlight)
            return;
        flightService.epGetATL($scope.selectedFlight.FDPId).then(function (response) {
            //$scope.loadingVisible = false;
            console.log('ATL', response);
            if (response.IsSuccess) {
                var data = response.Data;
                //if (data)
                var imgdata = { url: data ? data.Data : null, caption: 'ATL', type: 'ATL', flight: -1, fdp: $scope.selectedFlight.FDPId, camera: true };

                $rootScope.$broadcast('InitImageViewer', imgdata);

                //  else
                //      $rootScope.$broadcast('InitCamera', { type: 'ATL', flight: /*$scope.selectedFlight.FlightId*/-1, fdp: $scope.selectedFlight.FDPId });

            }
            else
                $rootScope.processErorrs(response);

        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });


    };

    $scope.loadClick = function (g) {
        if (!$scope.selectedFlight)
            return;
        flightService.epGetLoadSheet($scope.selectedFlight.FlightId).then(function (response) {
            //$scope.loadingVisible = false;
            console.log('ATL', response);
            if (response.IsSuccess) {
                var data = response.Data;
                //if (data)
                var imgdata = { url: data ? data.Data : null, caption: 'Load & Trim Sheet', type: 'LOADSHEET', flight: $scope.selectedFlight.FlightId, fdp: -1, camera: true };

                $rootScope.$broadcast('InitImageViewer', imgdata);
                $scope.updateDrByField($scope.selectedFlight, 'LoadSheetCPT');
                //  else
                //      $rootScope.$broadcast('InitCamera', { type: 'ATL', flight: /*$scope.selectedFlight.FlightId*/-1, fdp: $scope.selectedFlight.FDPId });

            }
            else
                $rootScope.processErorrs(response);

        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });


    };
    $scope.fcClick = function (g) {
        if (!$scope.selectedFlight)
            return;
        if ($rootScope.getOnlineStatus()) {
            $rootScope.checkInternet(function (st) {
                if (st) {
                    $scope.loadingVisible = true;
                    var dt = moment(new Date($scope.selectedFlight.STDDay)).format('YYYY-MM-DD');
                    flightService.getFC($scope.selectedFlight.FlightNumber, dt).then(function (response) {
                        //console.log(response);
                        $scope.loadingVisible = false;
                        if (response && response.length > 0) {
                            var _url = staticFiles2 + 'atc/' + response[0];
                            $scope.showPdf({ url: _url, caption: 'Flight Card' });
                        }
                        else {
                            General.ShowNotify("Flight card not found.", 'error');
                        }

                    }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
                }
                else {
                    General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                }
            });
        }
        else
            General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');


    };
	
	///////////////////////////
	var mpln=[];
	
	$scope.levels=[];
	$scope.onMarkerClick=function(e){};
	
	 var polyline_x=null;
	 var markers=[];
	 
	$scope.wx_flight_click=function(flt){
		 
		$scope.map.remove();
		$('#windy').html('').removeClass('paid-model');
		windyInit(windy_options, windyAPI => {
			//alert('x');
			$scope.windy_api=windyAPI;
			const { map,picker, utils, broadcast, } = windyAPI;
			$scope.map=map;
	        const { store } = windyAPI;
			$scope.levels = store.getAllowed('availLevels');
			store.set('level', '300h');
			
	
			
			
			
			
			/////END 
			
		});
return;		
	 var marker_dep,marker_arr,marker_toc,marker_tod;
	 var plan_points;
	
	 $.get("https://xpi.sbvaresh.ir/api/ofp/points/flight/"+flt.FlightId, function(data, status){
         
		 plan_points=data;
		 mpln=[];
		 $.each(data,function(_j,_q){ mpln.push([_q.Lat,_q.Long]); });
		 console.log($scope.map);
		 console.log(mpln);
		 // $scope.map.setView(mpln[0], 15);
	     var latlngs = mpln;
		 if ( polyline_x)
		 {  $scope.map.removeLayer(polyline_x);  }
	 
	     $.each(markers,function(_i,_m){$scope.map.removeLayer(_m);});
		 
          polyline_x=L.polyline(latlngs, {color: 'white',weight:3}).addTo($scope.map); 
		  console.log(polyline_x);
         $scope.map.fitBounds(polyline_x.getBounds());
	 
	     $.each(latlngs,function(_i,_d){
			 var point=plan_points[_i];
			 var _tooltip=point.WAP;
			 var _color='white';
			 var _radius=4;
			 if (point.WAP=='TOC'){ _radius=6; _color='blue';}
			 if (point.WAP=='TOD'){_radius=6; _color='blue';}
			 if (_i==0){_radius=8; _color='green';}
			 if (_i==latlngs.length-1){_radius=8; _color='green';}
             var cm=  L.circleMarker(_d, {radius: _radius,color:_color }).on('click', $scope.onMarkerClick ) .addTo($scope.map);//.bindTooltip(_tooltip) ;
			 
			 var content=point.WAP;
			 
			  if (point.WAP=='TOC'){
				  //marker_toc=cm; cm.openTooltip();
				 // L.popup().setLatLng({lat:point.Lat,lng:point.Long}).setContent(content).openOn(map);
				  cm.bindPopup(content, {closeOnClick: false, autoClose: false}) ;
				  
		      } 
			 else if (point.WAP=='TOD'){
				  //marker_tod=cm;cm.openTooltip();
				 // L.popup().setLatLng({lat:point.Lat,lng:point.Long}).setContent(content).openOn(map);
				  cm.bindPopup(content, {closeOnClick: false, autoClose: false}) ;
			 }
			 else if (_i==0){
				// marker_dep=cm;cm.openTooltip();
				//L.popup().setLatLng({lat:point.Lat,lng:point.Long}).setContent(content).openOn(map);
				 cm.bindPopup(content, {closeOnClick: false, autoClose: false}) ;
			 }
			 else if (_i==latlngs.length-1){
				// marker_arr=cm;cm.openTooltip();
				//L.popup().setLatLng({lat:point.Lat,lng:point.Long}).setContent(content).openOn(map);
				 cm.bindPopup(content, {closeOnClick: false, autoClose: false})  ;
			}
			else  cm.bindPopup(content, {closeOnClick: false, autoClose: false});
			 
			 
             markers.push(cm);
	
	
        }); 
		 
     });
	}
	
	$scope.map;
	$scope.windy_api=null;
	$scope.init_windy=function(){
	 // if (!$scope.windy_api)
	if ($rootScope._xmap==0){
		$rootScope._xmap=1;
		windyInit(windy_options, windyAPI => {
			//alert('x');
			$scope.windy_api=windyAPI;
			const { map,picker, utils, broadcast, } = windyAPI;
			$scope.map=map;
	        const { store } = windyAPI;
			$scope.levels = store.getAllowed('availLevels');
			store.set('level', '300h');
			
	
			
			
			
			
			/////END 
			
		});
		
	}
	else
		console.log($scope.windy_api);
		
		
		//////////
		
		
		//END OF WINDY
		/////////////////
    };





    //////// NEERJA
    $scope.pfcClick = function (g) {

       // alert($scope.selectedFlight.FlightId);
        var data = { Id: $scope.selectedFlight.FlightId, crewId: $scope.selectedFlight.CrewId };

        $rootScope.$broadcast('InitPFCAdd', data);
    };

    $scope.sccClick = function (g) {
        var data = { Id: $scope.selectedFlight.FlightId, crewId: $scope.selectedFlight.CrewId, crews: $scope.selectedFlightCrews,   };

        $rootScope.$broadcast('InitSCCAdd', data);
    }

    $scope.evaClick = function (g) {
        var data = { Id: $scope.selectedFlight.FlightId, crewId: $scope.selectedFlight.CrewId, crews: $scope.selectedFlightCrews, };

        $rootScope.$broadcast('InitEvalAdd', data);
    }

    ////////////////////
    var appWindow = angular.element($window);
    appWindow.bind('resize', function () {
        //alert('w: '+$(window).width());
        $('#windy-box').height($(window).height()-300);
        $scope.$apply(function () {
            $scope.leftHeight = $(window).height() - 190;
            $scope.rightHeight = $(window).height() - 235;
            $scope.scroll_folder_height = $(window).height() - 100;
			
			$scope.scroll_f2_height = $(window).height() - 250;
        });
    });


    // $rootScope.$broadcast('AppLibraryLoaded', null);
    $rootScope.$broadcast('ActiveFooterItem', 'footerflightcalendar');
    $scope.$on('$viewContentLoaded', function () {
        
        $scope.bind();
    });
    $scope.$on('onFlightLocgSaved', function (evt, data) {

        // flightService.epGetFlightLocal(fid).then(function (response) {
        //    if (response.IsSuccess) {
        //        //var grp = Enumerable.From($scope.groupedFlights).Where('$.FDPId==' + response.Data.FDPId).FirstOrDefault();
        //        //if (grp) {
        //        //    var gf = Enumerable.From(grp.items).Where('$.FlightId==' + fid).FirstOrDefault();
        //        //    gf = response;
        //        //}
        //    }

        //}, function (err) {  });    });

        var grp = Enumerable.From($scope.groupedFlights).Where('$.FDPId==' + data.FDPId).FirstOrDefault();
        if (grp) {
            var gf = Enumerable.From(grp.items).Where('$.FlightId==' + data.FlightId).FirstOrDefault();
            // gf.FlightNumber = 'kir'; //JSON.parse(JSON.stringify( data));
            JSON.copy(data, gf);
            if ($scope.selectedFlight)
                $scope.showFlight($scope.selectedFlight, grp.items, -1);
        }
    });

    $scope.$on('onCalendarSelected', function (evt, data) {
        var _d = new Date(data);
        var date = new Date(_d.getFullYear(), _d.getMonth(), _d.getDate());
        $scope.dt_from = date;
        $scope.dt_to = date;

        $scope.bind();
    });
    $scope.$on('COMMAND', function (evt, data) {
        if (data.title == 'BIND_FLIGHTS') {

            $scope.bind();
        };

    });

    $('.main-button').click(function () {
        $('.main-button').removeClass('day-selected');
        $(this).addClass('day-selected');
    });
    //$scope.$on('_onSign', function (event, prms) {

    //    $rootScope.$broadcast('onSign', prms);
    //    alert('broadcast');
    //});

}]);