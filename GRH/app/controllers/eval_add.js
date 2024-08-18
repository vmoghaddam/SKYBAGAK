'use strict';
app.controller('eval_add_controller', ['$scope', '$location', 'flightService', 'neerjaService', 'authService', '$routeParams', '$rootScope', '$window', '$q'

    , function ($scope, $location, flightService, neerjaService, authService, $routeParams, $rootScope, $window, $q) {

        $scope.main_ds = { flight_id: null, reporter_id: $rootScope.employeeId, scores: [] };


        $scope.isFullScreen = false;
        var detector = new MobileDetect(window.navigator.userAgent);

        if (detector.mobile() && !detector.tablet())
            $scope.isFullScreen = true;

        $scope.table_width = $(window).width();



        $scope.popup_add_visible = false;
        $scope.popup_add_title = 'Evaluation Form';
        $scope.popup_instance = null;
        $scope.popup_width = 500;
        $scope.popup_height = 700;



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

                            $scope.loadingVisible = true;
                            neerjaService.save_eval($scope.main_ds).then(function (response) {
                                if (response.IsSuccess) {
                                    General.ShowNotify(Config.Text_SavedOk, 'success');
                                    $scope.selected_crew_index = -1;
                                    $scope.popup_add_visible = false;
                                    $scope.loadingVisible = false;
                                    $scope.selected_crew_index = -1;
                                    $scope.entity.total = 0;
                                    $scope.main_ds = { flight_id: null, reporter_id: $rootScope.employeeId, scores: [] };
                                    $scope.current_row = [{ score: 0 }, { score: 0 }, { score: 0 }, { score: 0 }, { score: 0 }]
                                    $scope.entity.crew = null;
                                    $scope.ds_crew = null;
                                }


                            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

                        }
                    }, toolbar: 'bottom'
                },
                {
                    widget: 'dxButton', location: 'after', options: {
                        type: 'danger', text: 'Close', icon: 'remove', onClick: function (e) {
                           
                            $scope.selected_crew_index = -1;
                            $scope.entity.total = 0;
                            $scope.main_ds = { flight_id: null, reporter_id: $rootScope.employeeId, scores: [] };
                            $scope.current_row = [{ score: 0 }, { score: 0 }, { score: 0 }, { score: 0 }, { score: 0 }]
                            $scope.entity.crew = null;
                            $scope.ds_crew = null;

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
                $scope.selectedTabIndex = 0;
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


        $scope.ds_crew = [];

        $scope.fill = function (data) {

            $scope.main_ds.scores = data;
            console.log("fill", $scope.main_ds);
        }

        $scope.bindCrews = function (flightId) {

            flightService.epGetFlightCrews(flightId).then(function (response) {

                if (response.IsSuccess) {

                    // $.each(response.Data, function (_i, _d) {
                    //     if (_d.JobGroup == "CCM")
                    //         $scope.ds_crew.push(_d);

                    //});
                    $scope.ds_crew = Enumerable.From(response.Data).Where(function (x) {
                        return
                        1 == 1 || ['CCM', 'SCCM', 'ISCCM'].indexOf(x.JobGroup) != -1;
                    }).ToArray();
                    $scope.ds_crew = response.Data;
                    //$scope.main_ds = { flight_id: flightId, reporter_id: $rootScope.employeeId, scores: [] };
                    $.each($scope.items, function (_i, _item) {
                        $.each($scope.ds_crew, function (_j, _crew) {

                            if ($scope.main_ds.scores == []) {
                                var obj = {
                                    item_id: _item.id,
                                    crew_id: _crew.CrewId,
                                    item_title: _item.title,
                                    flight_id: flightId,
                                    position: _crew.Position,
                                    score: 0,
                                };
                                $scope.main_ds.scores.push(obj);
                            }
                            //else {
                            //    Enumerable.From($scope.main_ds.scores).Where("$.crew_id==" + _crew.CrewId && "$.item_id==" + _item.id).score = ;
                            //}
                        });


                    })

                    // $scope.selectedFlightCrews = response.Data;

                }
                else
                    $rootScope.processErorrs(response);

            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
        };

        $scope.bind = function () {

            console.log("Bind")
            neerjaService.get_eval($scope.tempData.flight_id, $rootScope.employeeId).then(function (res) {
                $scope.fill(res.Data);
            });
        }



        //////////////////////////

        $scope.entity = {
            briefing: 0,
            team: 0,
            safety: 0,
            duty: 0,
            service: 0,
            total: 0
        };


        $scope.items = [

            { id: 1, title: 'وضعیت حضور در بریفینگ' },
            { id: 2, title: 'نحوه انجام وظایف قبل و هنگام ورود مسافران' },
            { id: 3, title: 'کیفیت ارایه خدمات و جذب رضایت مسافران' },
            { id: 4, title: 'کیفیت وظایف ایمنی' },
            { id: 5, title: 'روحیه همکاری تیمی و حفظ اموال شرکت' },
        ];

        $scope.scores = [0, 0, 0, 0, 0];

        $scope.ds = [];

        $scope.sl_briefing = {
            min: 0,
            max: 20,
            value: 0,

            tooltip: {
                enabled: true,
                showMode: 'always',
                position: 'bottom',
                format: function (value) {
                    return value;
                },
                customizeTooltip: function (arg) {
                    return {
                        text: arg.valueText
                    };
                }
            },


            onValueChanged: function (e) {
                $scope.entity.total = $scope.current_row[0].score + $scope.current_row[1].score + $scope.current_row[2].score + $scope.current_row[3].score + $scope.current_row[4].score;
            },
            bindingOptions: {

                //value: 'entity.briefing'
                value: 'current_row[0].score'
            }
        };

        $scope.sl_duty = {
            min: 0,
            max: 20,
            value: 0,

            tooltip: {
                enabled: true,
                showMode: 'always',
                position: 'bottom',
                format: function (value) {
                    return value;
                },
                customizeTooltip: function (arg) {
                    return {
                        text: arg.valueText
                    };
                }
            },


            onValueChanged: function (e) {
                $scope.entity.total = $scope.current_row[0].score + $scope.current_row[1].score + $scope.current_row[2].score + $scope.current_row[3].score + $scope.current_row[4].score;
            },
            bindingOptions: {

                //value: 'entity.duty'
                value: 'current_row[1].score'
            }
        };

        $scope.sl_service = {
            min: 0,
            max: 20,
            value: 0,

            tooltip: {
                enabled: true,
                showMode: 'always',
                position: 'bottom',
                format: function (value) {
                    return value;
                },
                customizeTooltip: function (arg) {
                    return {
                        text: arg.valueText
                    };
                }
            },


            onValueChanged: function (e) {
                $scope.entity.total = $scope.current_row[0].score + $scope.current_row[1].score + $scope.current_row[2].score + $scope.current_row[3].score + $scope.current_row[4].score;
            },
            bindingOptions: {

                //value: 'entity.service'
                value: 'current_row[2].score'
            }
        };

        $scope.sl_safety = {
            min: 0,
            max: 20,
            value: 0,

            tooltip: {
                enabled: true,
                showMode: 'always',
                position: 'bottom',
                format: function (value) {
                    return value;
                },
                customizeTooltip: function (arg) {
                    return {
                        text: arg.valueText
                    };
                }
            },


            onValueChanged: function (e) {
                $scope.entity.total = $scope.current_row[0].score + $scope.current_row[1].score + $scope.current_row[2].score + $scope.current_row[3].score + $scope.current_row[4].score;
            },
            bindingOptions: {

                //value: 'entity.safety'
                value: 'current_row[3].score'
            }
        };

        $scope.sl_team = {
            min: 0,
            max: 20,
            value: 0,

            tooltip: {
                enabled: true,
                showMode: 'always',
                position: 'bottom',
                format: function (value) {
                    return value;
                },
                customizeTooltip: function (arg) {
                    return {
                        text: arg.valueText
                    };
                }
            },


            onValueChanged: function (e) {
                $scope.entity.total = $scope.current_row[0].score + $scope.current_row[1].score + $scope.current_row[2].score + $scope.current_row[3].score + $scope.current_row[4].score;
            },
            bindingOptions: {

                //value: 'entity.team'
                value: 'current_row[4].score'
            }
        };

        $scope.num_total = {

            bindingOptions: {

                value: 'entity.total'
            }
        };

        /////////////////////////
        $scope.selected_crew_index = -1;
       
        $scope.sb_cabin = {
            placeholder: "Cabin Crew",
            displayExpr: 'Name',
            valueExpr: 'CrewId',
            onSelectionChanged: function (e) {
                try {
                    $scope.selected_crew_index = $scope.ds_crew.indexOf(e.selectedItem);
                    var crew_id = e.selectedItem.CrewId;
                    $scope.current_row = Enumerable.From($scope.main_ds.scores).Where('$.crew_id==' + crew_id).ToArray();
                }
                catch (ee) { console.log('____error', ee); }
            },
            bindingOptions: {
                value: 'entity.crew',
                dataSource: 'ds_crew',

            }
        }






        $scope.tempData = {};
        $scope.$on("InitEvalAdd", function (event, prms) {
            $scope.tempData.flight_id = prms.Id
            $scope.bindCrews(prms.Id);
            $scope.bind();
          
            console.log("Init Eval");
            $scope.popup_add_visible = true;
        });

    }]);