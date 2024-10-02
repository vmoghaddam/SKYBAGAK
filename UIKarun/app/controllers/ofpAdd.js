'use strict';
app.controller('ofpAddController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window', '$compile', '$sce', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window, $compile, $sce) {
    $scope.isNew = true;
    $scope.isContentVisible = false;
    $scope.isFullScreen = true;
    $scope.isEditable = false;
    $scope.isLockVisible = false;
    var detector = new MobileDetect(window.navigator.userAgent);

    if (detector.mobile() && !detector.tablet())
        $scope.isFullScreen = true;

    $scope.entity = {
        Id: -1,

    };


    ////////////////////////
    $scope.bindEvents = function () {
        $("#ofp-doc").on("click", ".prop", function () {
            $('.prop').removeClass('selected');
            $(this).addClass('selected');
            // $(this).val(10);
            $scope.propClick($(this).attr('id'), $(this).val());
        });

        $("#ofp-doc").on('focusin', ".prop", function () {

            $(this).data('val', $(this).val());
        });

        $("#ofp-doc").on("change", ".prop", function () {
            if ($(this).attr('id').includes('y_rem_')) {
                try {
                    var ofp = $(this).data('ofp');

                }
                catch (ex) {
                }
            }
            //nilo
            if ($(this).attr('id').includes('_rem_')) {
                try {

                    var diff = $scope.fuel_total - Number($(this).val());
                    var remid = $(this).attr('id');
                    var usedId = $(this).attr('id').replace('_rem_', '_usd_');
                    $('#' + usedId).val(diff);


                    var ofp = $('#' + remid).data('ofp');

                    var diff_rem = Number($(this).val()) - ofp;

                    var drem_elem_id = $(this).attr('id').replace('_rem_', '_drem_');
                    $('#' + drem_elem_id).val(diff_rem);

                    var prev = $('#' + usedId).data('val');
                    // $scope.onBlur($('#' + remId).attr('id'), $('#' + remId).val(), prev);

                    $scope.onBlur($('#' + usedId).attr('id'), $('#' + usedId).val(), prev);


                    // var dusdid=$(this).attr('id').replace('_rem_', '_dusd_');
                    // var ofpused = $('#' + remid).data('ofpused');
                    /// var diff_used=-1*diff_rem+ofpused;
                    // $('#' + dusdid).val(diff_used);
                    // var prev2 = $('#' + dusedid).data('val');
                    // $scope.onBlur($('#' + dusedid).attr('id'), $('#' + dusedid).val(), prev2);

                }
                catch (ex) {
                }


            }

            if ($(this).attr('id').includes('_a1rem_')) {
                try {
                    var remid = $(this).attr('id');
                    var ofpused = $('#' + remid).data('ofpused');
                    var diff = $scope.fuel_total - Number($(this).val());




                    var ofp = $('#' + remid).data('ofp');

                    var diff_rem = Number($(this).val()) - ofp;

                    var usedId = $(this).attr('id').replace('_a1rem_', '_a1usd_');
                    $('#' + usedId).val(-diff_rem + Number(ofpused));

                    var drem_elem_id = $(this).attr('id').replace('_a1rem_', '_a1drem_');
                    $('#' + drem_elem_id).val(diff_rem);

                    var prev = $('#' + usedId).data('val');
                    // $scope.onBlur($('#' + remId).attr('id'), $('#' + remId).val(), prev);

                    $scope.onBlur($('#' + usedId).attr('id'), $('#' + usedId).val(), prev);



                }
                catch (ex) {
                }


            }


            if ($(this).attr('id').includes('_a2rem_')) {
                try {
                    var remid = $(this).attr('id');
                    var ofpused = $('#' + remid).data('ofpused');
                    var diff = $scope.fuel_total - Number($(this).val());



                    var ofp = $('#' + remid).data('ofp');

                    var diff_rem = Number($(this).val()) - ofp;

                    var usedId = $(this).attr('id').replace('_a2rem_', '_a2usd_');
                    $('#' + usedId).val(-diff_rem + Number(ofpused));


                    var drem_elem_id = $(this).attr('id').replace('_a2rem_', '_a2drem_');
                    $('#' + drem_elem_id).val(diff_rem);

                    var prev = $('#' + usedId).data('val');
                    // $scope.onBlur($('#' + remId).attr('id'), $('#' + remId).val(), prev);

                    $scope.onBlur($('#' + usedId).attr('id'), $('#' + usedId).val(), prev);



                }
                catch (ex) {
                }


            }


            if ($(this).attr('id').includes('_usd_')) {
                try {
                    //alert('x');
                    var diff = $scope.fuel_total - Number($(this).val());
                    var diffId = $(this).attr('id').replace('_usd_', '_rem_');
                    $('#' + diffId).val(diff);


                    // var ofp = $('#' + diffId).data('ofp');
                    var ofp = $(this).data('ofp');
                    var diff_used = Number($(this).val()) - ofp;
                    var dusd_elem_id = $(this).attr('id').replace('_usd_', '_dusd_');
                    $('#' + dusd_elem_id).val(diff_used);

                    var prev = $('#' + diffId).data('val');
                    $scope.onBlur($('#' + diffId).attr('id'), $('#' + diffId).val(), prev);

                }
                catch (ex) {
                }


            }

            //if ($(this).attr('id').includes('_usd_')) {
            //    try {
            //        var ofp = $(this).data('ofp');
            //        var diff = Number($(this).val()) - Number(ofp);


            //        var diffId = $(this).attr('id').replace('_usd_', '_dusd_');
            //        $('#' + diffId).val(diff);
            //    }
            //    catch (ex) {

            //    }

            //}

            var prev = $(this).data('val');
            $scope.onBlur($(this).attr('id'), $(this).val(), prev);
        });
    };
    ////////////////////////
    $scope.popup_add_visible = false;
    $scope.popup_height = '100%';
    $scope.popup_width = '100%';
    $scope.popup_add_title = 'Operational Flight Plan (2.10)';
    $scope.popup_instance = null;

    $scope.popup_add = {


        showTitle: true,

        toolbarItems: [
            {
                widget: 'dxButton', location: 'before', options: {
                    type: 'default', text: 'Sign', icon: 'fas fa-signature', onClick: function (e) {
                        if ($rootScope.getOnlineStatus()) {
                            $rootScope.checkInternet(function (st) {
                                if (st) {
                                    var data = { FlightId: $scope.entity.FlightId, documentType: 'ofp' };

                                    $rootScope.$broadcast('InitSignAdd', data);
                                }
                                else {
                                    General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                                }
                            });
                            //$scope.entity.Id

                        }
                        else {
                            General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                        }

                    }
                }, toolbar: 'bottom'
            },
            /*{
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Save All', icon: 'check', onClick: function (e) {
                        if (!$rootScope.getOnlineStatus()) {
                            alert('You are OFFLINE.Please check your internet connection.');
                            return;
                        }
                        $rootScope.checkInternet(function (st) {
                            if (st) {
                                $scope.bind(function () {
                                    //syncOFPProps
                                    $scope.loadingVisible = true;
                                    flightService.syncOFPProps($scope.entity.Id, true, function () { }).then(function (response2) {

                                        $scope.loadingVisible = false;
                                        General.ShowNotify(Config.Text_SavedOk, 'success');

                                    }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
                                });
                            }
                            else {

                                alert('The application cannot connect to the Server. Please check your internet connection.');
                                return;
                            }
                        });





                    }
                }, toolbar: 'bottom'
            },*/
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


            //$("#ofp-doc").on("click", ".prop", function () {
            //    $('.prop').removeClass('selected');
            //    $(this).addClass('selected');
            //    $scope.propClick($(this).attr('id'), $(this).val());
            //});

            //$("#ofp-doc").on("change", ".prop", function () {

            //    $scope.onBlur($(this).attr('id'), $(this).val());
            //});
            $scope.bindEvents();

        },
        onHiding: function () {
            $rootScope.IsRootSyncEnabled = true;
            $("#ofp-doc")
                .off("click", ".prop");
            $("#ofp-doc")
                .off("change", ".prop");
            $scope.props = [];
            $('.prop').val('');
            $scope.OFPHtml = '';
            $scope.popup_add_visible = false;
            //$rootScope.$broadcast('onDrAddHide', null);
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
            //'toolbarItems[1].visible': 'isEditable',
            'toolbarItems[0].visible': 'isLockVisible',

        }
    };

    $scope.propType = 'number';
    $scope.propValueStr = null;
    $scope.propValueNum = null;
    $scope.propName = null;
    $scope.props = [];
    $scope.txtIns = null;
    $scope.txt_prop = {
        onInitialized: function (e) {
            if (!$scope.txtIns)
                $scope.txtIns = e.component;
            //setTimeout(function () {
            //    e.component.focus();
            //}, 0);
        },
        bindingOptions: {
            value: 'propValueStr',
        }
    };
    $scope.num_prop = {
        bindingOptions: {
            value: 'propValueNum',
        }
    };

    $scope.popup_value_instance = null;
    $scope.popup_value_visible = false;
    $scope.popup_value = {

        shadingColor: 'rgba(255,255,255,0.1)',
        showTitle: true,

        toolbarItems: [

            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Save', icon: 'check', onClick: function (e) {

                        var dto = { OFPId: $scope.entity.Id, PropName: $scope.propName, User: $rootScope.userTitle };
                        if ($scope.propType == 'number') {
                            if ($scope.propValueNum === 0)
                                dto.PropValue = '0';
                            else
                                dto.PropValue = $scope.propValueNum ? $scope.propValueNum.toString() : '...';
                        }
                        else {
                            dto.PropValue = $scope.propValueStr ? $scope.propValueStr : '...';
                        }
                        $scope.loadingVisible = true;
                        flightService.saveOFPProp(dto).then(function (response2) {

                            $scope.loadingVisible = false;
                            // General.ShowNotify(Config.Text_SavedOk, 'success');
                            $('#' + $scope.propName).html(dto.PropValue);
                            $scope.popup_value_visible = false;

                        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
                        //if (!result.isValid) {
                        //    General.ShowNotify(Config.Text_FillRequired, 'error');
                        //    return;
                        //}

                        //$scope.loadingVisible = true;
                        //flightService.saveDR($scope.entity).then(function (response2) {
                        //    $scope.loadingVisible = false;
                        //    if (response2.IsSuccess) {
                        //        General.ShowNotify(Config.Text_SavedOk, 'success');
                        //        console.log('DR', response2.Data);
                        //        $scope.popup_add_visible = false;
                        //    }


                        //}, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });



                    }
                }, toolbar: 'bottom'
            },
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'danger', text: 'Close', icon: 'remove', onClick: function (e) {
                        $scope.popup_value_visible = false;
                    }
                }, toolbar: 'bottom'
            }
        ],
        // position:'left top',
        //position: { my: 'right', at: 'right', of: window, offset: '-15 0' },
        position: {
            my: "right top",
            at: "right top",
            offset: '-15 60'
        },
        visible: false,
        dragEnabled: true,
        closeOnOutsideClick: false,
        onShowing: function (e) {
            $scope.popup_instance.repaint();
        },
        onShown: function (e) {
            $scope.txtIns.focus();
        },
        onHiding: function () {
            $('.prop').removeClass('selected');
            $scope.propType = 'number';
            $scope.propValueStr = null;
            $scope.propValueNum = null;
            $scope.propName = null;

            $scope.popup_value_visible = false;

        },
        onContentReady: function (e) {
            if (!$scope.popup_value_instance) {
                $scope.popup_value_instance = e.component;
            }
        },
        title: 'Value',
        height: 200,
        width: 300,
        bindingOptions: {
            visible: 'popup_value_visible',


        }
    };

    /////////////////////////////////
    function _replaceAll(str, find, replace) {
        return str.replace(new RegExp(find, 'g'), replace);
    }
    $scope.flight = null;
    var _toNum = function (v) {
        try {
            return !v ? 0 : Number(v);
        }
        catch (e) {
            return 0;
        }
    };
    var str_to_num = function (str) {
        if (!str) {
            if (str == '0')
                return 0;

            return null;
        }
        else
            return Number(str);
    }
    var correct_number = function (str) {
        if (!str)
            return "";
        str = str.toString();
        str = str.replaceAll(" ", "");
        if (str == "")
            return str;

        try {
            var n = Number(str);
            if (isNaN(n))
                return "";
            return n.toString();
        }
        catch (e) {
            return "";
        }
    }
    $scope.getPropClass = function (id) {

        if (id.includes('fuel_req'))
            return 'prop noborder';
        return 'prop';
    };

    //08-11
    $scope.fillSOB = function () {
        // alert(Number($scope.entity.root.pax_adult));
        //alert(Number($scope.entity.root.pax_child));
        // alert(Number($scope.entity.root.pax_infant));
        var _sob = ($scope.entity.root.pax_adult ? Number($scope.entity.root.pax_adult) : 0)
            + ($scope.entity.root.pax_child ? Number($scope.entity.root.pax_child) : 0)
            + ($scope.entity.root.pax_infant ? Number($scope.entity.root.pax_infant) : 0)

            + ($scope.entity.root.crew_cockpit ? Number($scope.entity.root.crew_cockpit) : 0)
            + ($scope.entity.root.crew_cabin ? Number($scope.entity.root.crew_cabin) : 0)
            + ($scope.entity.root.crew_fsg ? Number($scope.entity.root.crew_fsg) : 0)
            //+ ($scope.entity.root.crew_fm ? Number($scope.entity.root.crew_fm) : 0)
            //+ ($scope.entity.root.crew_dh ? Number($scope.entity.root.crew_dh) : 0)
            ;

        // alert(_sob);

        $('#prop-root-sob').val(_sob);
        return _sob;
    }
    $scope.update_entity = function (dto) {
        var prts = dto.PropName.split('-');
        var property = prts[2];
        var tbl_part = prts[1];
        switch (tbl_part) {
            case "root":
                $scope.entity.root[property] = dto.PropValue;
                break;
            case "nav":
                var prop_parts = property.split('_');

                var pk = prop_parts[1];
                property = prop_parts[0];
                var obj = Enumerable.From($scope.init_data.routes).Where(function (x) { return x.Id == Number(pk) }).FirstOrDefault();
                if (obj) {
                    var coll = $scope.entity.main_route;
                    if (obj.NavType == "ALT1")
                        coll = $scope.entity.alt1_route;
                    if (obj.NavType == "ALT2")
                        coll = $scope.entity.alt2_route;

                    var objx = Enumerable.From(coll).Where(function (x) { return x.Id == Number(pk) }).FirstOrDefault();
                    // objx.WayPoint = 'dool';


                    objx[property] = dto.PropValue;

                }



                break;
            default:
                break;
        }
    }
    //08-29
    $scope.updateValue = function (propId, value, callback, prev, norecal) {
        //12-04
        if (propId.includes('undefined'))
            return;
        if (propId == sobId) {

            return;
        }
        var dto = { OFPId: $scope.entity.Id, PropName: propId, User: $rootScope.userTitle, FlightId: $scope.entity.FlightId };



        if (propId.toLowerCase().includes('fuel') || propId.toLowerCase().includes('payload_actual')) {

            value = correct_number(value);
            $('#' + propId).val(value);
        }

        if (propId.toLowerCase().includes('nav-ata')) {
            value = value.replaceAll(" ", "");
            if (value != "") {
                if (value.length < 4) {
                    $('#' + propId).val(prev);
                    return;
                }
                // var to = _toNum(tos.substr(0, 2)) * 60 + _toNum(tos.substr(2, 2));
                var p1 = value.substr(0, 2);
                var p2 = value.substr(2, 2);
                if (Number(p1) > 24 || Number(p2) > 59) {
                    $('#' + propId).val(prev);
                    return;
                }


            }
            //value = correct_number(value);
            //  $('#' + propId).val(value);
        }
        dto.PropValue = value;
        // $scope.loadingVisible = true;

        //   console.log('prop_dto', dto);

        //flightService.saveOFPPropB(dto).then(function (response2) {
        flightService.updateOFPB(dto).then(function (response2) {
            $scope.update_entity(dto);
            if (propId.toLowerCase().includes('_corr') && !propId.toLowerCase().includes('fuel_req_corr') && !propId.toLowerCase().includes('fuel_total_corr') && !norecal) {
                $scope.corr_fuel_all($scope.entity);
            }

            if (propId.toLowerCase().includes('fuel_req_corr') && !norecal) {
                $scope.corr_fuel_req($scope.entity);
            }

            if (!norecal && propId.toLowerCase().includes('payload_actual') /*|| propId.toLowerCase().includes('_corr')*/ || propId.toLowerCase().includes('dow_actual')) {
                $scope.calculate_wb($scope.entity);
            }

            if (propId.toLowerCase().includes('fuel_trip_corr') && !norecal) {
                $scope.calculate_wb($scope.entity);
            }
            if (propId.toLowerCase().includes('fuel_total_corr') && !norecal) {
                $scope.set_ref_fuel();
                $scope.recalculate_fuel($scope.entity, function () {
                   

                });
                $scope.calculate_wb($scope.entity);
            }





            if (propId.includes('pax') || propId.includes('crew')) {
                var _sob = $scope.fillSOB();
                $scope.updateValue('prop-root-sob', _sob, null);

            }


            if (propId.toLowerCase().includes('nav-ata')) {
                var xs = propId.split('_');
                var xid = Number(xs[xs.length - 1]);

                var rt = Enumerable.From($scope.init_data.routes).Where(function (x) { return Number(x.Id) == xid; }).FirstOrDefault();
                if (rt) {
                    var type = "main";
                    var coll = null;
                    if (rt.NavType == "MAIN")
                        coll = $scope.entity.main_route;
                    if (rt.NavType == "ALT1") { coll = $scope.entity.alt1_route; type = "alt"; }
                    if (rt.NavType == "ALT2") { coll = $scope.entity.alt2_route; type = "alt"; }
                    if ($scope.recal_eta)
                        $scope.fill_eta(coll, type, function () {

                            $scope.save_eta();
                        }, true);
                }

            }

            if (propId.includes('prop-nav-FuelRemainedActual')) {
                var xs = propId.split('_');
                var xid = Number(xs[xs.length - 1]);
                var rt = Enumerable.From($scope.init_data.routes).Where(function (x) { return Number(x.Id) == xid; }).FirstOrDefault();
                if (rt) {
                    var _diff_rem = 'prop-nav-DiffFuelRemained_' + xid;
                    var _diff_used = 'prop-nav-DiffFuelUsed_' + xid;
                    var _act_used = 'prop-nav-FuelUsedActual_' + xid;
                    var _used = null;
                    if (value == '') {
                        $('#' + _diff_rem).val('').removeClass('orange').removeClass('green');
                        $('#' + _diff_used).val('');
                        $('#' + _act_used).val('');
                        rt.DiffFuelRemained = '';

                    }
                    else {
                        var _rem = Number(value) - Number(rt.FuelRemained2);
                        rt.DiffFuelRemained = _rem;
                        var cls = 'green';
                        if (_rem < 0)
                            cls = 'orange';
                        $('#' + _diff_rem).val(_rem).removeClass('orange').removeClass('green').addClass(cls);
                        _used = Number(rt.FuelUsed2) - _rem;
                        $('#' + _act_used).val(_used);
                        $scope.entity.root.FuelUsedActual = _used;

                        var _used_diff = Number(rt.FuelUsed2) - _used;
                        $('#' + _diff_used).val(_used_diff);

                    }

                    $scope.updateValue(_act_used, _used, null);

                }
            }
            if (callback)
                callback();

            //$scope.fillSOB();

            //if (propId.includes('_ata_'))
            //    $scope.fillETA();
            //if (propId.includes('_a1ata_'))
            //    $scope.fillETAAlt1();
            //if (propId.includes('_a2ata_'))
            //    $scope.fillETAAlt2();




        }, function (err) {

            $scope.loadingVisible = false; General.ShowNotify(JSON.stringify(err), 'error');
        });
    };
    //12-04
    $scope.onBlur = function (propId, value, prev) {

        $scope.updateValue(propId, value, null, prev);
        return;
        var _v = (value === undefined || (!value && value !== 0)) ? value : value.toString().replace(/\s/g, '');
        if ((!_v && _v !== 0) || _v === undefined) {
            $('#' + propId).val(prev);
            return;


        }
        else {
            //qqww
            $scope.updateValue(propId, value);
        }


    };
    $scope.propClick = function (propId, value) {
        return;


        $scope.$apply(function () {
            value = _replaceAll(value, ' ', '');


            $scope.propName = propId;
            $scope.propType = 'number';
            //if (propId.startsWith('prop_ofbcpt'))
            //    $scope.propType = 'string';
            //if (propId.startsWith('prop_ofbfo'))
            //    $scope.propType = 'string';
            //if (propId.startsWith('prop_clearance'))
            //    $scope.propType = 'string';



            //if ($scope.propType == 'string')
            //    $scope.propValueStr = value;
            //else
            //    $scope.propValueNum = value;
            $scope.propType = 'string';
            $scope.propValueStr = value;
            // $scope.popup_value_visible = true;
            // alert($scope.propName);
        });

    };
    //$scope.propClick = function (event) {
    //    alert('x  '+ $(event.target).attr("id") ); 
    //};

    $scope._COR = function (r) {
        if (!r.COR)
            return '-';

        //°
        var res = r.COR.replaceAll("D", "°").replaceAll("M", "'").replaceAll("S", '"');
        return res;
    }

    $scope._Empty = function (d) {
        if (d == 0)
            return '';
        return d;
    }

    $scope._Time = function (d) {
        if (!d)
            return d;
        return d.substr(0, 5);
    }

    $scope._Time2 = function (d) {
        if (!d)
            return d;
        return d.replace('.', ':');
    }



    $scope.OFPHtml = '';
    var crewAId = null;
    var crewBId = null;
    var crewCId = null;
    var sobId = null;

    $scope.fuel_total = 0;
    $scope.plan_fuel_offblock = 0;
    $scope.plan_fuel_takeoff = 0;
    $scope.getPlannedFuelValue = function (x) {

        if (x.prm == 'TOF') {
            var p_tof = Enumerable.From($scope.entity.JFuel).Where('$._key=="fuel_tof"').FirstOrDefault();
            return p_tof.pvalue;
        }
        else if (x.prm == 'OFF BLK') {
            var p_offblock = Enumerable.From($scope.entity.JFuel).Where('$._key=="fuel_offblk"').FirstOrDefault();
            return p_offblock.pvalue;
        }
        else
            return x.value;
    };


    $scope.get_main_route = function () {

    };


    $scope.convert_nav_time = function (pts) {

        $.each(pts, function (_i, _d) {
            if (_d.ZoneTime) {
                var prts = _d.ZoneTime.split(':');
                _d.ZoneTimeInt = Number(prts[0]) * 60 + Number(prts[1]);
            }
            else
                _d.ZoneTimeInt = 0;

            if (_d.CumulativeTime) {
                var prtsc = _d.CumulativeTime.split(':');
                _d.CumulativeTimeInt = Number(prtsc[0]) * 60 + Number(prtsc[1]);
            }
            else _d.CumulativeTimeInt = 0;

        })
    }


    $scope.init_data = null;
    $scope.offblock = null;
    $scope.takeoff = null;
    $scope.landing = null;
    $scope.onblock = null;

   
    $scope.fillETA = function () {
        if ($scope.flight.TakeOff) {
            var tos = moment(CreateDate($scope.flight.TakeOff)).format('HHmm');
            var to = _toNum(tos.substr(0, 2)) * 60 + _toNum(tos.substr(2, 2));

            $.each($scope.entity.JPlan, function (_i, _d) {
                var mm = _toNum(_d.TTM.split(':')[0]) * 60 + _toNum(_d.TTM.split(':')[1]);

                if (_i == 0) {
                    var n = mm + to;
                    $('#prop_' + _d._key + '_eta_' + _i).val(time_convert(n));
                    _d.eta = time_convert(n);
                }
                else {
                    var pre = $scope.entity.JPlan[_i - 1];
                    //var pre_eta = $('#prop_' + _d._key + '_eta_' + (_i - 1).toString()).val();
                    var pre_eta = pre.eta;
                    var pre_ata = $('#prop_' + pre._key + '_ata_' + (_i - 1).toString()).val();
                    var _t = pre_ata ? pre_ata : pre_eta;

                    var _tn = _toNum(_t.substr(0, 2)) * 60 + _toNum(_t.substr(2, 2));
                    _tn += _toNum(_d.TME.split(':')[0]) * 60 + _toNum(_d.TME.split(':')[1]);
                    $('#prop_' + _d._key + '_eta_' + _i).val(time_convert(_tn));
                    _d.eta = time_convert(_tn);
                }

                //var _base = CreateDate($scope.flight.TakeOff);
                //var _eta = new Date(_base.addMinutes(mm));
                // $('#prop_' + _d._key + '_eta_' + _i).val(toTime(_eta));
            });
        }
    }
    function time_convert(num) {
        var hours = Math.floor(num / 60);
        var minutes = num % 60;
        return hours.toString().padStart(2, '0') + minutes.toString().padStart(2, '0');
    }


    $scope.nowClick2 = function (key) {

        var _id = key;
        var $elem = $('#' + _id);
        var dt = new Date();
        var _val = String(dt.getUTCHours()).padStart(2, '0') + String(dt.getUTCMinutes()).padStart(2, '0');
        $scope.entity.root[_id.replace("prop-root-", "")] = _val;
        $elem.val(_val);
        $scope.updateValue(_id, _val, function () {

            //  $scope.fill_eta(coll, type, function () { },true);
        });
    };

    $scope.now_ata = function (id, type) {

        var coll = null;
        if (type == 'main')
            coll = $scope.entity.main_route;
        if (type == 'alt1')
            coll = $scope.entity.alt1_route;
        if (type == 'alt2')
            coll = $scope.entity.alt2_route;

        var rec = Enumerable.From(coll).Where(function (x) { return Number(x.Id) == id; }).FirstOrDefault();
        var rec_x = Enumerable.From($scope.init_data.routes).Where(function (x) { return Number(x.Id) == id; }).FirstOrDefault();

        var dt = new Date();
        var _val = String(dt.getUTCHours()).padStart(2, '0') + String(dt.getUTCMinutes()).padStart(2, '0');

        rec.ATA = _val;
        rec_x.ATA = _val;
        var $elem = $('#prop-nav-ATA_' + id);
        $elem.val(_val);
        $scope.updateValue('#prop-nav-ATA_' + id, _val, function () {

            //  $scope.fill_eta(coll, type, function () { },true);
        });






    };
    //08-12
    $scope.recalculate_fuel_diff = function (callback) {
        var points = ($scope.entity.main_route.concat($scope.entity.alt1_route)).concat($scope.entity.alt2_route);

        $.each(points, function (_i, _p) {
            if (_p.FuelRemainedActual) {
                _p.DiffFuelRemained = +_p.FuelRemainedActual - _p.FuelRemained2;
                _p.FuelUsedActual = Number(_p.FuelUsed2) - _p.DiffFuelRemained;


                var upd_dto_rec = {
                    key: Number(_p.Id),
                    changes: {
                        //DiffFuelRemained: _p.DiffFuelRemained,
                        FuelUsedActual: _p.FuelUsedActual,
                        IsFuelUsedActual: true,

                    }
                };
                $scope.navlog_upd_dto.push(upd_dto_rec);

            }


        });


        callback();
    }
    $scope.fill_route_fuel = function (route, type, callback, refresh) {
      
        var first_fuel = Number($scope.ref_fuel);
        var diff_used = 0;
        if (type == "main") {
            var taxi = Number(  $scope.entity.root.fuel_taxiout);
            diff_used = taxi - Number($scope.entity.root.fuel_taxiout);
            first_fuel = first_fuel - taxi;

           // diff_used = 0;
           // first_fuel = first_fuel - 0;

            route[0].ZoneFuel = taxi;
            route[0].CumulativeFuel = taxi;


            route[0].FuelUsed2 = Number(route[0].FuelUsed) + diff_used;
            route[0].CumulativeFuel2 = Number(route[0].CumulativeFuel) + diff_used;

          //  console.log('ZZZZSSSS', route[0]);
            

        }
        if (type == "alt") {
            var taxi = Number($scope.entity.root.fuel_taxi_corr ? $scope.entity.root.fuel_taxi_corr : $scope.entity.root.fuel_taxiout);
            var trip = Number($scope.entity.root.fuel_trip_corr ? $scope.entity.root.fuel_trip_corr : $scope.entity.root.fuel_trip);


            first_fuel = Number($scope.ref_fuel) - trip - taxi;
            route[0].FuelUsed2 = trip + taxi;
            route[0].CumulativeFuel2 = trip + taxi;




        }
        var diff = first_fuel - route[0].FuelRemained;


        $.each(route, function (_i, _p) {


            _p.FuelRemained2 = Number(_p.FuelRemained) + diff;
            if (_i > 0) {
                _p.FuelUsed2 = _p.FuelUsed;
                _p.CumulativeFuel2 = _p.CumulativeFuel;
            }

            var upd_dto_rec = {
                key: Number(_p.Id),
                changes: {
                    FuelUsed2: _p.FuelUsed,
                    CumulativeFuel2: _p.CumulativeFuel2,
                    FuelRemained2: _p.FuelRemained2,
                    IsFuelUsed2: true,
                    IsFuelRemained2: true,
                    IsCumulativeFuel2: true,

                }
            };
            $scope.navlog_upd_dto.push(upd_dto_rec);

        });
        callback();
        return;
        var first_fuel = Number($scope.ref_fuel);
        var diff_used = 0;
        if (type == "main") {
            var taxi = Number($scope.entity.root.fuel_taxi_corr ? $scope.entity.root.fuel_taxi_corr : $scope.entity.root.fuel_taxiout);
            diff_used = taxi - Number($scope.entity.root.fuel_taxiout);
            first_fuel = first_fuel - taxi;
            route[0].FuelUsed2 = Number(route[0].FuelUsed) + diff_used;
            route[0].CumulativeFuel2 = Number(route[0].CumulativeFuel) + diff_used;
            
        }
        if (type == "alt") {
            var taxi = Number($scope.entity.root.fuel_taxi_corr ? $scope.entity.root.fuel_taxi_corr : $scope.entity.root.fuel_taxiout);
            var trip = Number($scope.entity.root.fuel_trip_corr ? $scope.entity.root.fuel_trip_corr : $scope.entity.root.fuel_trip);


            first_fuel = Number($scope.ref_fuel) - trip - taxi;
            route[0].FuelUsed2 = trip + taxi;
            route[0].CumulativeFuel2 = trip + taxi;




        }
        var diff = first_fuel - route[0].FuelRemained;

        $.each(route, function (_i, _p) {


            _p.FuelRemained2 = Number(_p.FuelRemained) + diff;
            if (_i > 0) {
                _p.FuelUsed2 = _p.FuelUsed;
                _p.CumulativeFuel2 = _p.CumulativeFuel;
            }
           
            var upd_dto_rec = {
                key: Number(_p.Id),
                changes: {
                    FuelUsed2: _p.FuelUsed,
                    CumulativeFuel2: _p.CumulativeFuel2,
                    FuelRemained2: _p.FuelRemained2,
                    IsFuelUsed2: true,
                    IsFuelRemained2: true,
                    IsCumulativeFuel2:true,

                }
            };
            $scope.navlog_upd_dto.push(upd_dto_rec);

        });

        callback();

    }

    $scope.recalculate_fuel = function (data, callback) {
        $scope.navlog_upd_dto = [];

        $scope.fill_route_fuel(data.main_route, 'main', function () {
            $scope.fill_route_fuel(data.alt1_route, 'alt', function () {




                $scope.recalculate_fuel_diff(function () {

                  //  flightService.updateOFPB_Nav_Fuel_Bulk('OFPB_MainNavLog', $scope.navlog_upd_dto).then(function (sdata) {
                        $.each(data.main_route, function (_i, _w) {
                            $('#prop-nav-ETA_' + _w.Id).val(_w.ETA);
                            $('#prop-nav-ATA_' + _w.Id).val(_w.ATA);
                            //prop-nav-FuelRemainedActual_
                            $('#prop-nav-FuelRemainedActual_' + _w.Id).val(_w.FuelRemainedActual);
                            //prop-nav-FuelUsedActual_
                            $('#prop-nav-FuelUsedActual_' + _w.Id).val(_w.FuelUsedActual);
                            var cls = '';
                            if (_w.DiffFuelRemained) {

                                if (Number(_w.DiffFuelRemained) < 0)
                                    cls = 'orange';
                                else
                                    cls = 'green';
                            }

                            $('#prop-nav-DiffFuelRemained_' + _w.Id).val(_w.DiffFuelRemained).removeClass('orange').removeClass('green').addClass(cls);


                        });
                        $.each(data.alt1_route, function (_i, _w) {
                            $('#prop-nav-ETA_' + _w.Id).val(_w.ETA);
                            $('#prop-nav-ATA_' + _w.Id).val(_w.ATA);
                            //prop-nav-FuelRemainedActual_
                            $('#prop-nav-FuelRemainedActual_' + _w.Id).val(_w.FuelRemainedActual);
                            //prop-nav-FuelUsedActual_
                            $('#prop-nav-FuelUsedActual_' + _w.Id).val(_w.FuelUsedActual);
                            var cls = '';
                            if (_w.DiffFuelRemained) {
                                if (Number(_w.DiffFuelRemained) < 0)
                                    cls = 'orange';
                                else
                                    cls = 'green';
                            }
                            $('#prop-nav-DiffFuelRemained_' + _w.Id).val(_w.DiffFuelRemained).removeClass('orange').removeClass('green').addClass(cls);;
                        });

                        $.each(data.alt2_route, function (_i, _w) {
                            $('#prop-nav-ETA_' + _w.Id).val(_w.ETA);
                            $('#prop-nav-ATA_' + _w.Id).val(_w.ATA);
                            //prop-nav-FuelRemainedActual_
                            $('#prop-nav-FuelRemainedActual_' + _w.Id).val(_w.FuelRemainedActual);
                            //prop-nav-FuelUsedActual_
                            $('#prop-nav-FuelUsedActual_' + _w.Id).val(_w.FuelUsedActual);
                            var cls = '';
                            if (_w.DiffFuelRemained) {
                                if (Number(_w.DiffFuelRemained) < 0)
                                    cls = 'orange';
                                else
                                    cls = 'green';
                            }
                            $('#prop-nav-DiffFuelRemained_' + _w.Id).val(_w.DiffFuelRemained).removeClass('orange').removeClass('green').addClass(cls);;
                        });


                        if (callback)
                            callback();



                  //  });



                });



            });


        });



        /////////////////////

    }


    $scope.save_eta = function () {

        flightService.updateOFPBBulk('OFPB_MainNavLog', $scope.eta_upd_dto).then(function (sdata) {

            $scope.eta_upd_dto = [];
        });
    }

    $scope.get_eta = function (x, type, idx) {
        if (idx == 0)
            return x.ETA;

        var eta = x.ETA;
        var fp = null;
        if (type == 'main' && $scope.entity.main_route && $scope.entity.main_route.length > 0 && $scope.entity.main_route[0].ATA) {
            fp = $scope.entity.main_route[0];
            var f_eta = _toNum(fp.ETA.substr(0, 2)) * 60 + _toNum(fp.ETA.substr(2, 2));
            var f_ata = _toNum(fp.ATA.substr(0, 2)) * 60 + _toNum(fp.ATA.substr(2, 2));
            var diff = f_ata - f_eta;
            var x_eta = _toNum(x.ETA.substr(0, 2)) * 60 + _toNum(x.ETA.substr(2, 2));
            x_eta = x_eta + diff;
            eta = time_convert(x_eta);
        }
        

        return eta;
    }
    $scope.get_cum_act_used = function (x) {
       // if (x.WayPoint == 'DEKBA')
       // console.log('cum_act',x.WayPoint + '   ' + x.CumulativeFuel + '    ' + x.ZoneFuel + '    ' + x.FuelUsedActual);
       // return Number(x.CumulativeFuel) + (-Number(x.ZoneFuel) + Number(x.FuelUsedActual));
        if ($scope.ref_fuel && x.FuelRemainedActual)
            return $scope.ref_fuel - x.FuelRemainedActual;
        else return null;
    };
    $scope.eta_upd_dto = [];
    $scope.recal_eta = false;
    $scope.fill_eta = function (route, type, callback, refresh) {

        var c = 0;
        var start = $scope.flight.TakeOff
            ? moment(CreateDate($scope.flight.TakeOff)).format('HHmm')
            : moment(CreateDate($scope.flight.STD)).format('HHmm');
        var start_time = $scope.flight.TakeOff ? $scope.flight.TakeOff : $scope.flight.STD;
        if (type != 'main') {
            var trip_time = $scope.entity.root.time_trip;
            start = moment(CreateDate(start_time).addMinutes(Number(trip_time))).format('HHmm');


            //start = moment($scope.entity.root.ETA).format('HHmm');
        }
        //alert(moment($scope.entity.root.ETA).format('HHmm'));
        // alert(start+'   '+route.length);
        $.each(route, function (_i, _p) {
            var upd_dto_rec = {
                key: Number(_p.Id),
                changes: {}
            };
            if (_i == 0) {
                _p.ETA = start;
            }
            else {
                var pre = route[_i - 1];
                var pre_eta = $scope.recal_eta ? (pre.ATA ? pre.ATA : pre.ETA) : pre.ETA;

                var _tn = _toNum(pre_eta.substr(0, 2)) * 60 + _toNum(pre_eta.substr(2, 2));

                var dt = _toNum($scope._Time2(_p.ZoneTime).split(':')[0]) * 60 + _toNum($scope._Time2(_p.ZoneTime).split(':')[1]);

                var eta = _tn + dt;

                _p.ETA = time_convert(eta)

            }
            upd_dto_rec.changes.ETA = _p.ETA;
            $scope.eta_upd_dto.push(upd_dto_rec);
        });


        if (refresh) {
            $.each(route, function (_i, _p) {
                $('#prop-nav-ETA_' + _p.Id).val(_p.ETA);

            });
        }
       
       
        callback();



        // console.log(upd_dto);


    };
    $scope.set_ref_fuel = function () {
        $scope.ref_fuel = $scope.entity.root.fuel_total_corr;
        if (!$scope.ref_fuel)
            $scope.ref_fuel = $scope.entity.root.fuel_total;


       // $scope.ref_fuel = $scope.entity.root.fuel_total_actual;
       // if (!$scope.ref_fuel)
       //     $scope.ref_fuel = $scope.entity.root.fuel_total_corr;
       // if (!$scope.ref_fuel)
       //     $scope.ref_fuel = $scope.entity.root.fuel_total;


       // alert($scope.ref_fuel);

        // alert($scope.ref_fuel);
        //$scope.ref_fuel = $scope.requested_fuel ? $scope.requested_fuel
    };
    $scope.corr_fuel_all = function (data) {
        var trip = Number(data.root.fuel_trip_corr ? data.root.fuel_trip_corr : data.root.fuel_trip);

        var alt1 = Number(data.root.fuel_alt1_corr ? data.root.fuel_alt1_corr : data.root.fuel_alt);

        var alt2 = Number(data.root.fuel_alt2_corr ? data.root.fuel_alt2_corr : data.root.fuel_alt2);

        var hold = Number(data.root.fuel_hld_corr ? data.root.fuel_hld_corr : data.root.fuel_holding);

        var res = 0;

        var cont = Number(data.root.fuel_cont_corr ? data.root.fuel_cont_corr : data.root.fuel_contigency);

        var taxi = Number(data.root.fuel_taxi_corr ? data.root.fuel_taxi_corr : data.root.fuel_taxiout);

        var min_req = trip + alt1 + alt2 + hold + res + cont + taxi;
        data.root.fuel_req_corr = min_req;
        $scope.updateValue('prop-root-fuel_req_corr', min_req, null, null, true);
        //propId, value, callback, prev,norecal

        //prop-root-fuel_req_corr

        var xtra = Number(data.root.fuel_xtra_corr ? data.root.fuel_xtra_corr : data.root.fuel_extra);

        var add = Number(data.root.fuel_add_corr ? data.root.fuel_add_corr : data.root.fuel_additional);

        var total = min_req + xtra + add;
        data.root.fuel_total_corr = total;
        $scope.set_ref_fuel();
        $scope.recalculate_fuel(data, function () {
            $scope.updateValue('prop-root-fuel_total_corr', total, null, null, false);

        });

        //prop-root-fuel_total_corr

    }
    $scope.corr_fuel_req = function (data) {
        var min_req = Number(data.root.fuel_req_corr ? data.root.fuel_req_corr : data.root.fuel_min_required);
        var xtra = Number(data.root.fuel_xtra_corr ? data.root.fuel_xtra_corr : data.root.fuel_extra);

        var add = Number(data.root.fuel_add_corr ? data.root.fuel_add_corr : data.root.fuel_additional);

        var total = min_req + xtra + add;
        $scope.set_ref_fuel();
        $scope.recalculate_fuel(data, function () {
            $scope.updateValue('prop-root-fuel_total_corr', total, null, null, false);

        });


    }
    $scope.calculate_wb = function (data) {

        data.root.EstimatedZeroFuelWeight = Number(data.root.Payload) + Number(data.root.DryOperatingWeight);

        data.root.EstimatedTaxiWeight = Number(data.root.EstimatedZeroFuelWeight) + Number(data.root.fuel_total);

        data.root.EstimatedTakeoffWeight = Number(data.root.EstimatedTaxiWeight) - Number(data.root.fuel_taxiout);

        data.root.EstimatedLandingWeight = Number(data.root.EstimatedTakeoffWeight) - Number(data.root.fuel_trip);

        data.root.zfw_actual = Number(data.root.payload_actual ? data.root.payload_actual : data.root.Payload)
            + Number(data.root.dow_actual ? data.root.dow_actual : data.root.DryOperatingWeight);

        $scope.actual_fob = data.root.fuel_total_actual;
        if (!data.root.fuel_total_actual)
            $scope.actual_fob = data.root.fuel_total_corr ? data.root.fuel_total_corr : data.root.fuel_total;

        $scope.actual_burn = data.root.fuel_used_actual;
        //alert($scope.actual_burn);
        if (!data.root.fuel_used_actual)
            $scope.actual_burn = data.root.fuel_trip_corr ? data.root.fuel_trip_corr : data.root.fuel_trip;


        data.root.tow_actual = Number(data.root.zfw_actual) + Number($scope.actual_fob)
            - Number(data.root.fuel_taxi_corr ? data.root.fuel_taxi_corr : data.root.fuel_taxiout);
        data.root.txw_actual = Number(data.root.zfw_actual) + Number($scope.actual_fob);

        data.root.lgw_actual = Number(data.root.tow_actual) - Number($scope.actual_burn);

        return;
        data.root.DOW = data.root.DryOperatingWeight ? Number(data.root.DryOperatingWeight) : 0;


        var _payload = data.root.Payload;
        if (data.root.payload_actual)
            _payload = data.root.payload_actual;

        var _zfw = data.root.EstimatedZeroFuelWeight;
        if (data.root.zfw_actual)
            _zfw = data.root.zfw_actual;

        // var _tow=
        //zfw_actual

        data.root.PLYD = _payload ? Number(_payload) : 0;
        data.root.EstimatedZeroFuelWeight = data.root.PLYD + data.root.DOW;

        data.root.ZFW = data.root.EstimatedZeroFuelWeight ? Number(data.root.EstimatedZeroFuelWeight) : 0; //_zfw ? Number(_zfw) : 0; 


        var _fuel_total = data.root.fuel_total;
        if (data.root.fuel_total_corr)
            _fuel_total = data.root.fuel_total_corr;
        data.root.FOB = _fuel_total ? Number(_fuel_total) : 0;

        data.root.TXWT = data.root.DOW + data.root.PLYD + data.root.FOB;


        var _taxi = data.root.fuel_taxiout;
        if (data.root.fuel_taxi_corr)
            _taxi = data.root.fuel_taxi_corr;
        data.root.TOW = data.root.TXWT - (_taxi ? Number(_taxi) : 0);

        var _trip = data.root.fuel_trip;
        if (data.root.fuel_trip_corr)
            _trip = data.root.fuel_trip_corr;
        data.root.BURN = _trip ? Number(_trip) : 0;

        data.root.LGW = data.root.TOW - data.root.BURN;
    };
    $scope.get_ldg_remaining_fuel = function () {
        //approcah1
        //var sum = Enumerable.From($scope.entity.main_route).Select(function (x) { return x.FuelUsedActual ? Number(x.FuelUsedActual) : Number(x.FuelUsed2); }).Sum('$');
        
       // return $scope.get_off_remaining_fuel() - sum;

        //approach2
        if (!$scope.entity || !$scope.entity.main_route)
            return null;
        var idx = $scope.entity.main_route.length - 1;
        if ($scope.entity.main_route[idx].FuelRemainedActual)
            return $scope.entity.main_route[idx].FuelRemainedActual - $scope.entity.root.ManeuveringFuel;
        //return $scope.entity.main_route[idx].FuelRemained2;
        return null;
    };

    $scope.get_ldg_remaining_fuel_final = function () {
        //approcah1
        //var sum = Enumerable.From($scope.entity.main_route).Select(function (x) { return x.FuelUsedActual ? Number(x.FuelUsedActual) : Number(x.FuelUsed2); }).Sum('$');

        // return $scope.get_off_remaining_fuel() - sum;

        //approach2
        if (!$scope.entity || !$scope.entity.main_route)
            return null;
        var idx = $scope.entity.main_route.length - 1;
        if ($scope.entity.main_route[idx].FuelRemainedActual)
            return $scope.entity.main_route[idx].FuelRemainedActual - $scope.entity.root.ManeuveringFuel;
        //return $scope.entity.main_route[idx].FuelRemained2 - $scope.entity.root.ManeuveringFuel;
        return null;
    };


    $scope.get_to_remaining_fuel = function () {
        if (!$scope.entity || !$scope.entity.main_route)
            return null;
        if ($scope.entity.main_route[0].FuelRemainedActual)
            return $scope.entity.main_route[0].FuelRemainedActual;
       // return $scope.entity.main_route[0].FuelRemained2
        return null;
    };
    $scope.get_off_remaining_fuel = function () {
       // if ($scope.entity.root.fuel_total_actual)
       //     return $scope.entity.root.fuel_total_actual;
        if (!$scope.entity || !$scope.entity.root)
            return null;
        if ($scope.entity.root.fuel_total_corr)
            return $scope.entity.root.fuel_total_corr;
        return $scope.entity.root.fuel_total
       
    };
    $scope.get_on_remaining_fuel = function () {
        if (!$scope.entity || !$scope.entity.root)
            return null;
        return $scope.entity.root.fuel_remain_actual ;

    };
    $scope.get_final_arr = function () {
        if (!$scope.entity || !$scope.entity.root || !$scope.entity.main_route)
            return null;
        var last_point = $scope.entity.main_route[$scope.entity.main_route.length - 1];
        if (!last_point)
            return null;
        
        if (last_point.ATA) {
            var _arr = _toNum(last_point.ATA.toString().substr(0, 2)) * 60 + _toNum(last_point.ATA.toString().substr(2, 2)) + Number($scope.entity.root.ManeuveringTime);
           // alert(last_point.ATA + '    ' + $scope.entity.ManeuveringTime);
            return $scope.int_to_time( _arr);
        }
        else {
            if (!last_point.ETA)
                return null;
           // console.log('last point', last_point.ETA);
            var _arr = _toNum(last_point.ETA.toString().substr(0, 2)) * 60 + _toNum(last_point.ETA.toString().substr(2, 2)) + Number($scope.entity.root.ManeuveringTime);
            return $scope.int_to_time(_arr);

        }
    };

    $scope.get_flight_used_fuel = function () {
        if ($scope.get_to_remaining_fuel() && $scope.get_ldg_remaining_fuel())
            return $scope.get_to_remaining_fuel() - $scope.get_ldg_remaining_fuel();
        return null;
        //return $scope.get_to_remaining_fuel() - $scope.get_ldg_remaining_fuel();
    };
    $scope.get_block_used_fuel = function () {
        if ($scope.get_off_remaining_fuel() && $scope.get_on_remaining_fuel())
            return $scope.get_off_remaining_fuel() - $scope.get_on_remaining_fuel();
        return null;
        //return $scope.get_on_remaining_fuel() - $scope.get_off_remaining_fuel();
    };


    $scope.get_flight_used_fuel_pln = function () {
        return $scope.entity.root.fuel_total - $scope.entity.root.fuel_taxiout - get_ldg_remaining_fuel();
    };
    $scope.get_block_used_fuel_pln = function () {

        return $scope.entity.root.fuel_total - $scope.get_ldg_remaining_fuel_final();
    };

    //pilot_click('Pilot1','pf')
    $scope.pilot_click = function (pilot,pfpm) {
        if (pilot == 'Pilot1') {
            $scope.entity.root.Pilot1_FPFM = pfpm;
            if (pfpm == 'pf')
                $scope.entity.root.Pilot2_FPFM = 'pm';
            else
                $scope.entity.root.Pilot2_FPFM = 'pf';

        }
        if (pilot == 'Pilot2') {
            $scope.entity.root.Pilot2_FPFM = pfpm;
            if (pfpm == 'pf')
                $scope.entity.root.Pilot1_FPFM = 'pm';
            else
                $scope.entity.root.Pilot1_FPFM = 'pf';

        }
        var dto1 = { OFPId: $scope.entity.Id, PropName: 'prop-root-Pilot1_FPFM', User: $rootScope.userTitle, FlightId: $scope.entity.FlightId, PropValue: $scope.entity.root.Pilot1_FPFM};
        flightService.updateOFPB(dto1).then(function (res1) {
            var dto2 = { OFPId: $scope.entity.Id, PropName: 'prop-root-Pilot2_FPFM', User: $rootScope.userTitle, FlightId: $scope.entity.FlightId, PropValue: $scope.entity.root.Pilot2_FPFM };
            flightService.updateOFPB(dto2);
        }, function (err) {

            $scope.loadingVisible = false; General.ShowNotify(JSON.stringify(err), 'error');
        });
        //alert($scope.entity.root.Pilot1_FPFM);
        //alert($scope.entity.root.Pilot2_FPFM);

    }
    $scope.getMinutesDiff = function (first, second) {
        if (!first || !second)
            return null;
        var diff = Math.abs(new Date(second) - new Date(first));
        var minutes = Math.floor((diff / 1000) / 60);
        return minutes;
    };
    $scope.get_pilot_class = function (pilot, pfpm) {
        if (!$scope.entity || !$scope.entity.root)
            return;
        
        if ($scope.entity.root[pilot] == pfpm)
            return 'selectd_pfpm';
        else
            return '';

    }  //('Pilot2', 'pf')

    
    $scope.fill = function (data, callback) {
        //09-30
      //  console.log('fill flight', $scope.flight);

        $scope.requested_fuel = $scope.flight.FuelPlanned;


        data.root.cargo = $scope.flight.Freight;
        data.root.pax_adult = $scope.flight.PaxAdult;
        data.root.pax_child = $scope.flight.PaxChild;
        data.root.pax_infant = $scope.flight.PaxInfant;

        data.root.fuel_total_actual = $scope.flight.FuelTotal;
        data.root.fuel_used_actual = $scope.flight.BlockOn ? $scope.flight.FuelUsed : Number(data.root.fuel_trip_corr ? data.root.fuel_trip_corr : data.root.fuel_trip);

        data.root.fuel_remain_actual = $scope.flight.FuelTotal && $scope.flight.FuelUsed ? Number($scope.flight.FuelTotal) - Number($scope.flight.FuelUsed) : null;
        data.root.fuel_saved_actual = $scope.flight.FuelTotal && $scope.flight.FuelUsed ? Number(data.root.fuel_trip) + Number(data.root.fuel_taxiout) - Number($scope.flight.FuelUsed) : null;


        data.root.time_saved = $scope.flight.FlightTime ? Number(data.root.time_trip) - Number($scope.flight.FlightTime) : null;

        //$scope.flight
        $scope.init_data = data;

        var first_main = Enumerable.From(data.routes).Where(function (x) { return x.NavType == "MAIN" }).FirstOrDefault();
        first_main.FuelUsed = data.root.fuel_taxiout;
        first_main.CumulativeFuel = first_main.FuelUsed;

        var first_alt1 = Enumerable.From(data.routes).Where(function (x) { return x.NavType == "ALT1" }).FirstOrDefault();
        if (first_alt1) {
            first_alt1.FuelUsed = data.root.fuel_trip + data.root.fuel_taxiout;
            first_alt1.CumulativeFuel = first_alt1.FuelUsed;

        }

        var first_alt2 = Enumerable.From(data.routes).Where(function (x) { return x.NavType == "ALT2" }).FirstOrDefault();
        if (first_alt2) {
            first_alt2.FuelUsed = data.root.fuel_trip + data.root.fuel_taxiout;
            first_alt2.CumulativeFuel = first_alt2.FuelUsed;
        }


        //$.each(data.routes, function (_i, _d) {
        //    _d.DiffFuelRemained = null;
        //    if (_d.FuelRemainedActual) {
        //        _d.DiffFuelRemained  = Number(_d.FuelRemainedActual) - Number(_d.FuelRemained);
        //    }

        //});



        data.main_route = Enumerable.From(data.routes).Where(function (x) { return x.NavType == "MAIN" }).ToArray();
        $scope.convert_nav_time(data.main_route);
        data.alt1_route = Enumerable.From(data.routes).Where(function (x) { return x.NavType == "ALT1" }).ToArray();
        $scope.convert_nav_time(data.alt1_route);
        data.alt2_route = Enumerable.From(data.routes).Where(function (x) { return x.NavType == "ALT2" }).ToArray();
        $scope.convert_nav_time(data.alt2_route);
        data.main_wts = Enumerable.From(data.wts).Where(function (x) { return x.Type == "MAIN" }).ToArray();
        data.alt1_wts = Enumerable.From(data.wts).Where(function (x) { return x.Type == "ALT1" }).ToArray();
        data.alt2_wts = Enumerable.From(data.wts).Where(function (x) { return x.Type == "ALT2" }).ToArray();





        data.main_wts_grp = Enumerable.From(data.main_wts)

            .GroupBy(function (item) { return item.WayPoint; }, null, (key, g) => {
                var _item = {

                    WayPoint: key,

                    items: Enumerable.From(g.source).Where(function (y) { return y.WindTemprature && y.FlightLevel; }).OrderBy(function (x) {
                        return x.FlightLevel;
                    }).ToArray(),



                };

                return _item;
            }).OrderBy(function (x) {
                return 1;

            }).ToArray();

        data.alt1_wts_grp = Enumerable.From(data.alt1_wts)

            .GroupBy(function (item) { return item.WayPoint; }, null, (key, g) => {
                var _item = {

                    WayPoint: key,

                    items: Enumerable.From(g.source).Where(function (y) { return y.WindTemprature && y.FlightLevel; }).OrderBy(function (x) {
                        return x.FlightLevel;
                    }).ToArray(),



                };

                return _item;
            }).OrderBy(function (x) {
                return 1;

            }).ToArray();

        data.alt2_wts_grp = Enumerable.From(data.alt2_wts)

            .GroupBy(function (item) { return item.WayPoint; }, null, (key, g) => {
                var _item = {

                    WayPoint: key,

                    items: Enumerable.From(g.source).Where(function (y) { return y.WindTemprature && y.FlightLevel; }).OrderBy(function (x) {
                        return x.FlightLevel;
                    }).ToArray(),



                };

                return _item;
            }).OrderBy(function (x) {
                return 1;

            }).ToArray();


        if (!data.root.fuel_total_corr && $scope.requested_fuel) {
            data.root.fuel_total_corr = $scope.requested_fuel;
            $scope.updateValue('prop-root-fuel_total_corr', data.root.fuel_total_corr, null, null, false);
        }

        $scope.entity = data;
        $scope.set_ref_fuel();



        $scope.calculate_wb(data);




        //data.root.fuel_trip_corr = str_to_num(data.root.fuel_trip_corr);
        //alert(data.root.fuel_trip_corr);
        //data.root.fuel_alt1_corr = str_to_num(data.root.fuel_alt1_corr);
        //data.root.fuel_alt2_corr = str_to_num(data.root.fuel_alt2_corr);
        //data.root.fuel_hld_corr = str_to_num(data.root.fuel_hld_corr);
        //data.root.fuel_res_corr = str_to_num(data.root.fuel_res_corr);
        //data.root.fuel_cont_corr = str_to_num(data.root.fuel_cont_corr);
        //data.root.fuel_taxi_corr = str_to_num(data.root.fuel_taxi_corr);
        //data.root.fuel_req_corr = str_to_num(data.root.fuel_req_corr);
        //data.root.fuel_xtra_corr = str_to_num(data.root.fuel_xtra_corr);
        //data.root.fuel_add_corr = str_to_num(data.root.fuel_add_corr);



        $scope.entity.FlightId = data.flight_id;
        $scope.entity.Id = data.ofp_id;
        $scope.entity.root.ETA = new Date((new Date($scope.flight.STD)).addMinutes(data.root.time_trip));




        //alert($scope.entity.root.ETA);




        setTimeout(function () {
            $scope.eta_upd_dto = [];
            // $('#prop-root-fuel_trip_corr').val(data.root.fuel_trip_corr);
            $scope.fill_eta(data.main_route, 'main', function () {
                $scope.fill_eta(data.alt1_route, 'alt', function () {
                    $scope.fill_eta(data.alt2_route, 'alt', function () {

                       // flightService.updateOFPBBulk('OFPB_MainNavLog', $scope.eta_upd_dto).then(function (sdata) {
                            $scope.eta_upd_dto = [];
                            var keys_root = Object.keys(data.root);
                            var exs = ['pax_adult', 'pax_child', 'pax_infant'];
                            $.each(keys_root, function (_i, _k) {
                                if (!exs.includes(_k)) {
                                 //   $('#prop-root-' + _k).val(data.root[_k]);
                                    $("[id=prop-root-" + _k + "]").val(data.root[_k]); 

                                }
                                else {

                                }

                            });


                            $scope.recalculate_fuel(data, function () {
                                var _sob = $scope.fillSOB();
                                $scope.updateValue('prop-root-sob', _sob, null);
                                callback();
                            });

                   //     });
                        ////////////////////////













                        /////////////////


                    });

                });
            });

        }, 100);








        //      data.JPlan = data.JPlan ? JSON.parse(data.JPlan) : [];
        //      data.JAPlan1 = data.JAPlan1 ? JSON.parse(data.JAPlan1) : [];
        //      data.JAPlan2 = data.JAPlan2 ? JSON.parse(data.JAPlan2) : [];
        //data.JFuel = data.JFuel ? JSON.parse(data.JFuel) : [];
        //if (data.JFuel.length>0)
        //{

        //	data.JFuel.splice(data.JFuel.length-2, 0, {prm:'EXTRA',value:0,_key:'fuel_extra'});
        //}

        //      var _ejf=['HOLD','ZFW','TOW','LW','REQ','EZFW','ETOW','ELW'];
        //data.JFuel=Enumerable.From( data.JFuel).Where(function(x){return _ejf.indexOf(x.prm)==-1;}).ToArray();
        //data.FuelACTUALTANKERING=$scope.TNK; 
        //$.each(data.JFuel,function(_n,_p){

        //	if (_p.prm=='TANKERING')
        //	{
        //		_p.value=data.FuelACTUALTANKERING;

        //    }
        //	if (_p.prm=='TOTAL FUEL'){

        //		_p.value=data.FuelTOTALFUEL+( data.FuelACTUALTANKERING-data.FuelTANKERING);
        //	}
        //});

        //      data.JCSTBL = data.JCSTBL ? JSON.parse(data.JCSTBL) : [];
        //      data.JALDRF = data.JALDRF ? JSON.parse(data.JALDRF) : [];

        // data.JALDRF_FL = Enumerable.From(data.JALDRF).Where('$.FL =="'+data.FLL+'"').FirstOrDefault();
        //      data.JALDRF = Enumerable.From(data.JALDRF).Where('$.FL !="'+data.FLL+'"').ToArray();

        //      data.JWTDRF = data.JWTDRF ? JSON.parse(data.JWTDRF) : [];

        //      $scope.plan_fuel_offblock = 0;
        //      $scope.plan_fuel_takeoff = 0;

        //try {

        //          $scope.fuel_total = $scope.flight.FuelRemaining + $scope.flight.FuelUplift;
        //	console.log('total fuel',$scope.fuel_total);
        //          var p_offblock = Enumerable.From(data.JFuel).Where(  '$._key=="fuel_totalfuel"').FirstOrDefault();




        //	p_offblock.pvalue=p_offblock.value;

        //          if (p_offblock)
        //              $scope.plan_fuel_offblock = p_offblock.value;


        //          var p_tof = Enumerable.From(data.JFuel).Where('$._key=="fuel_tof"').FirstOrDefault();
        //	console.log('----a4');
        //          if (p_tof)
        //	  $scope.plan_fuel_takeoff = p_tof.value;



        //	if (p_tof)
        //          p_tof.pvalue=p_tof.value;
        //	 if (p_tof)
        //	p_tof.value = $scope.fuel_total - 200;
        //	console.log('----a7');
        //          p_offblock.value = $scope.fuel_total;
        //	console.log('----a8');

        //          $.each(data.JPlan, function (_i, _d) {
        //		console.log(_d.FRE,_d.FUS);
        //              _d._FRE = _d.FRE;
        //              _d.FRE = $scope.fuel_total - _d.FUS;
        //		console.log('----end-----');
        //          });
        //	console.log('total fuel2',$scope.fuel_total);
        //	var _alt_remain=Number($scope.fuel_total)-Number(data.FPTripFuel)-200;
        //	var _extra=$scope.fuel_total -data.FuelTOTALFUEL; 
        //	var _rem_for_alt=$scope.fuel_total -(Number(data.FPTripFuel)+Number(data.FuelTAXI));
        //	console.log('alt fuel2',_extra);
        //	console.log('alt fuel2',data.FPTripFuel);
        //	console.log('alt fuel2',data.FuelTAXI);
        //	$.each(data.JAPlan1, function (_i, _d) {
        //              _d._FRE = _d.FRE;
        //              _d.FRE =_rem_for_alt-Number(_d.FUS);  
        //          });
        //	$.each(data.JAPlan2, function (_i, _d) {
        //              _d._FRE = _d.FRE;
        //              _d.FRE =_rem_for_alt-Number(_d.FUS);  
        //          });

        //      }
        //      catch (e_f) {
        //	console.log('ERROR',e_f);
        //      }








        //      try {

        //          var lst = data.JPlan[data.JPlan.length - 1].TTM;
        //          var mm = _toNum(lst.split(':')[0]) * 60 + _toNum(lst.split(':')[1]);

        //          var _base = $scope.flight.TakeOff ? CreateDate($scope.flight.TakeOff) : CreateDate($scope.flight.STD);




        //	 var eta_nu=_toNum(data.ETA.replace(':',''));
        //	 var etd_nu=_toNum(data.ETD.replace(':',''));
        //	 console.log('ETA',eta_nu);
        //	 console.log('ETD',etd_nu);

        //	 var eta_prts=data.ETA.split(':');
        //	 var etd_prts=data.ETD.split(':');

        //	 var eta_dt=CreateDate($scope.flight.STDDay).addHours(eta_prts[0]).addMinutes(eta_prts[1])
        //	  console.log(eta_dt);

        //          $scope.ETA = eta_dt;//new Date(_base.addMinutes(mm));
        //	 console.log($scope.ETA);

        //      }
        //      catch (eer) {

        //      }

        //try{

        //	 $scope.DIST=data.JPlan[data.JPlan.length-1].TDS;

        //}
        //catch(e_a1){
        //}

        //   data.WDCLB_DS=data.WDCLB ? data.WDCLB.split('*'):[];
        //data.WDDES_DS=data.WDDES ? data.WDDES.split('*'):[];

        //var WDTMP_p1=data.WDTMP ? (data.WDTMP.split('^')[0]).split('_'):[];
        //var WDTMP_p2=data.WDTMP? (data.WDTMP.split('^')[1]).replaceAll('_','').replaceAll('FL', '<span class="spfl">FL').replaceAll(':', '</span>').split('*'):[];
        //data.WDTMP_DS1=WDTMP_p1;
        //data.WDTMP_DS2=[];
        //$.each(WDTMP_p2,function(_h,_k){
        //	data.WDTMP_DS2.push(
        //	{
        //		id:_h,
        //		txt:_k
        //	}
        //	);

        //});




        //      $scope.entity = data;
        //      setTimeout(function () {
        //          callback();
        //      }, 100);




        //     console.log('JFUEl',$scope.entity.JFuel);

    };
    $scope.isLockVisible = false;

    var toTime = function (dt) {
        if (!dt)
            return "";

        var result = moment(new Date(dt)).format('HHmm');



        return moment(new Date(dt)).format('HHmm');
    };
    $scope.toDate = function (dt) {
        if (!dt)
            return "";

        var result = moment(new Date(dt)).format('YYYY-MM-DD');



        return moment(new Date(dt)).format('YYYY-MM-DD');
    };
    //YYYY-MM-DD HH:mm
    $scope.toDateTime = function (dt) {

        if (!dt)
            return "";

        var result = moment(new Date(dt)).format('YYYY-MM-DD HH:mm');



        return moment(new Date(dt)).format('YYYY-MM-DD HH:mm');
    };
    $scope.int_to_time = function (num) {
        if (!num)
            return "";
        var ch = "";
        if (num < 0)
            ch = "-";
        num = Math.abs(num);
        var hours = Math.floor(num / 60);
        var minutes = num % 60;
        return ch + hours.toString().padStart(2, '0') + ':' + minutes.toString().padStart(2, '0');
    }
    function parseISOString(s) {
        s = s.toString();
        var prts = s.split('T');
        var dts = prts[0].split('-');
        var tms = prts[1].split(':');
        var dt = new Date(dts[0], dts[1] - 1, dts[2], tms[0], tms[1], tms[2]);
        // var b = s.split(/\D+/);
        // return new Date(Date.UTC(b[0], --b[1], b[2], b[3], b[4], b[5], b[6]));
        return dt;
    }

    $scope.checkSign = function (ofpid, flightid) {
         
        //console.log('check sign');
        flightService.getOFPCheckSign(ofpid).then(function (data) {
           
            if (data && data.JLSignedBy) {
                $scope.url_sign = signFiles + data.JLSignedBy + ".png";

                $scope.PIC = data.PIC;
                $scope.PIC_Lic = data.LicNo;
                $scope.signDate = moment(new Date(data.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
                //$('#sig_pic_img').attr('src', $scope.url_sign);

                flightService.signOFPLocal(flightid, data);
            }
        });
    };
    $scope.hold = function (key, index) {
        return;
        var _id = 'prop_' + key + '_ata_' + index;
        var $elem = $('#' + _id);
        var dt = new Date();
        var _val = String(dt.getUTCHours()).padStart(2, '0') + String(dt.getUTCMinutes()).padStart(2, '0');
        $elem.val(_val);
        //var prev = $(this).data('val');
        $scope.onBlur(_id, _val, null);
    };
    $scope.getMetar = function (stn, _id) {
        if (stn == 'dep')
            stn = $scope.flight.FromAirportIATA;
        else
            stn = $scope.flight.ToAirportIATA;

        flightService.getLastMetar(stn).then(function (response) {
            var metar = response.Data.RawText;
            var $elem = $('.' + _id);
            $elem.val(metar);
            $scope.onBlur(_id, metar, null);
        }, function (err) { });
    };
    $scope.nowClick = function (key, index) {

        var _id = 'prop_' + key + '_ata_' + index;
        var $elem = $('#' + _id);
        var dt = new Date();
        var _val = String(dt.getUTCHours()).padStart(2, '0') + String(dt.getUTCMinutes()).padStart(2, '0');
        $elem.val(_val);
        //var prev = $(this).data('val');
        $scope.onBlur(_id, _val, null);
    };

    $scope.dr = null;
    function isNumeric(str) {
        if (typeof str != "string") return false // we only process strings!  
        return !isNaN(str) && // use type coercion to parse the _entirety_ of the string (`parseFloat` alone does not do this)...
            !isNaN(parseFloat(str)) // ...and ensure strings of whitespace fail
    }
    $scope.bind = function (callback) {

        $scope.entity.FlightId = $scope.tempData.FlightId;
        $scope.TNK = $scope.tempData.TNK;
        //if ($rootScope.getOnlineStatus()) {

        //    flightService.checkLock($scope.entity.FlightId, 'ofp').then(function (response) {
        //        $scope.isLockVisible = false;
        //        if (response.IsSuccess && response.Data.canLock) {
        //            $scope.isLockVisible = true;
        //        }
        //    }, function (err) { });
        //}

        $scope.loadingVisible = true;

        flightService.epGetFlightLocal($scope.entity.FlightId).then(function (response) {

            $scope.loadingVisible = false;
            $scope.loadingVisible = true;

            // flightService.epGetDRByFlight($scope.entity.FlightId).then(function (resdr) {
            //    $scope.loadingVisible = false;
            //   if (resdr.Data) {
            //       $scope.dr = resdr.Data;
            //  alert($scope.dr.MinFuelRequiredPilotReq);
            //  }
            //   else {
            //  alert('no dr');
            //  }
            var diff = Math.abs((new Date()).getTime() - (new Date(response.Data.STALocal)).getTime()) / 3600000;

            $scope.flight = response.Data;
            $scope.mass_unit = $rootScope.isLbs($scope.flight.Register) ? 'LBS' : 'KG';

            $scope.loadingVisible = true;

            flightService.epGetOFPByFlight_B($scope.entity.FlightId).then(function (response2) {
                $scope.isEditable = (diff <= 24);
               
                //console.log('OFP_B_ROOT', response2);
                if (response2.Data.root && response2.Data.root.JLSignedBy) {
                    // $scope.isEditable = false;
                    console.log('SIGN', response2.Data.root);
                    $scope.url_sign = signFiles + response2.Data.root.PICId + ".png";
                    $scope.PIC = response2.Data.root.JLSignedBy;
                    $scope.PIC_Lic = response2.Data.root.LicNo;
                    //alert(response.Data.JLDatePICApproved);
                    //console.log();
                    $scope.signDate = moment(new Date(response2.Data.root.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
                }
                else {
                    $scope.url_sign = null;
                    $scope.PIC = null;
                    $scope.signDate = null;
                }

                $scope.loadingVisible = false;


                if (!response2.Data.root) {

                    $scope.isNew = true;
                    $scope.entity = {
                        Id: -1,

                    };
                    $scope.entity.FlightId = $scope.tempData.FlightId;

                }
                else {

                    $scope.isNew = false;
                    //07-23
                    $scope.fill(response2.Data, function () {

                        // alert('version');
                        // console.log('fill entity', $scope.entity);
                        flightService.epCheckOFBVersion_B($scope.entity.FlightId, $scope.entity.Id).then(function (resCheck) {

                            if (resCheck.Data) {
                                flightService.deleteOFP_B($scope.entity.FlightId, $scope.entity.Id, function () {
                                    alert("The OPF has been changed by Dispatchers. Please reopen the from to load new OFP.");
                                    $scope.popup_add_visible = false;
                                    return;
                                });

                            }
                            else {
                                 
                                  if (!$scope.url_sign)
                                      $scope.checkSign($scope.entity.Id, $scope.entity.FlightId);
                                ////// GET PROPS ///////////////

                                //$scope.loadingVisible = true;

                                //flightService.epGetOFPProps($scope.entity.Id).then(function (response3) {
                                //    try {

                                //        $scope.loadingVisible = false;


                                //        //12-04

                                //        if (!$scope.url_sign)
                                //            $scope.checkSign($scope.entity.Id, $scope.entity.FlightId);




                                //        $scope.props = response3.Data;

                                //        // console.log($scope.props);




                                //        //9-11
                                //        var updates = [];
                                //        var takeOffChanged = false;
                                //        var sob = 0;
                                //        var sobValue = null;
                                //        var sobprops = ['prop_pax_adult', 'prop_pax_child', 'prop_pax_infant', crewAId, crewBId, crewCId];


                                //        //here
                                //        $('#prop_fuel_req').attr('readonly', true).addClass('noborder');

                                //        $.each($scope.props, function (_i, _d) {


                                //            if (_d.PropName == 'prop_fuel_extra' || _d.PropName == 'prop_fuel_ops.extra') {
                                //                //$scope.plan_fuel_offblock
                                //                if ($scope.fuel_total) {
                                //                    //console.log('fuel_extra',$scope.fuel_total - $scope.plan_fuel_offblock);  
                                //                    $('#prop_fuel_extra').val($scope.fuel_total - $scope.plan_fuel_offblock);
                                //                }
                                //                else
                                //                    $('#' + _d.PropName).val(0);
                                //                $('#' + _d.PropName + '_due').val($scope.flight.ALT3);
                                //            }

                                //            else
                                //                if (_d.PropValue)
                                //                    $('#' + _d.PropName).val(_d.PropValue);
                                //            //nilo
                                //            if (_d.PropName.includes('x_usd_') && isNumeric(_d.PropValue)) {

                                //                try {
                                //                    var ofp = $('#' + _d.PropName).data('ofp');
                                //                    var diff = Number($('#' + _d.PropName).val()) - Number(ofp);


                                //                    var diffId = $('#' + _d.PropName).attr('id').replace('_usd_', '_dusd_');
                                //                    $('#' + diffId).val(diff);
                                //                }
                                //                catch (ex) {

                                //                }

                                //            }

                                //            if (_d.PropName.includes('_rem_') && isNumeric(_d.PropValue)) {

                                //                try {
                                //                    var ofp = $('#' + _d.PropName).data('ofp');
                                //                    var diff = Number($('#' + _d.PropName).val()) - Number(ofp);


                                //                    var diffId = $('#' + _d.PropName).attr('id').replace('_rem_', '_drem_');
                                //                    $('#' + diffId).val(diff);
                                //                }
                                //                catch (ex) {

                                //                }

                                //            }

                                //            if (_d.PropName.includes('_a1rem_') && isNumeric(_d.PropValue)) {

                                //                try {
                                //                    var ofp = $('#' + _d.PropName).data('ofp');
                                //                    var diff = Number($('#' + _d.PropName).val()) - Number(ofp);


                                //                    var diffId = $('#' + _d.PropName).attr('id').replace('_a1rem_', '_a1drem_');
                                //                    $('#' + diffId).val(diff);
                                //                }
                                //                catch (ex) {

                                //                }

                                //            }


                                //            if (_d.PropName.includes('_a2rem_') && isNumeric(_d.PropValue)) {

                                //                try {
                                //                    var ofp = $('#' + _d.PropName).data('ofp');
                                //                    var diff = Number($('#' + _d.PropName).val()) - Number(ofp);


                                //                    var diffId = $('#' + _d.PropName).attr('id').replace('_a2rem_', '_a2drem_');
                                //                    $('#' + diffId).val(diff);
                                //                }
                                //                catch (ex) {

                                //                }

                                //            }

                                //            if (_d.PropName == 'prop_fuel_req' && $scope.dr) {
                                //                $('#' + _d.PropName).val($scope.dr.MinFuelRequiredPilotReq);
                                //                updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: $scope.flight.PaxAdult });
                                //            }


                                //            if (_d.PropName == 'prop_pax_adult' /*&& $scope.flight.PaxAdult != _d.PropValue*/) {
                                //                $('#' + _d.PropName).val($scope.flight.PaxAdult);
                                //                updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: $scope.flight.PaxAdult });
                                //                //var dto = { OFPId: $scope.entity.Id, PropName: _d.propName, User: $rootScope.userTitle, PropValue: $scope.flight.PaxAdult };
                                //                //flightService.saveOFPProp(dto);
                                //            }
                                //            if (_d.PropName == 'prop_pax_child' /*&& $scope.flight.PaxChild != _d.PropValue*/) {
                                //                $('#' + _d.PropName).val($scope.flight.PaxChild);
                                //                updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: $scope.flight.PaxChild });
                                //            }
                                //            if (_d.PropName == 'prop_pax_infant' /*&& $scope.flight.PaxInfant != _d.PropValue*/) {
                                //                $('#' + _d.PropName).val($scope.flight.PaxInfant);
                                //                updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: $scope.flight.PaxInfant });
                                //            }
                                //            //prop_offblock

                                //            if (_d.PropName == 'prop_offblock' /*&& toTime(CreateDate($scope.flight.BlockOff)) != _d.PropValue*/) {
                                //                $('#' + _d.PropName).val(toTime(CreateDate($scope.flight.BlockOff)));
                                //                updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: toTime(CreateDate($scope.flight.BlockOff)) });
                                //            }
                                //            //prop_takeoff
                                //            if (_d.PropName == 'prop_takeoff' /*&& toTime(CreateDate($scope.flight.TakeOff)) != _d.PropValue*/) {
                                //                takeOffChanged = true;
                                //                $('#' + _d.PropName).val(toTime(CreateDate($scope.flight.TakeOff)));
                                //                updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: toTime(CreateDate($scope.flight.TakeOff)) });
                                //            }
                                //            //prop_landing
                                //            if (_d.PropName == 'prop_landing' /*&& toTime(CreateDate($scope.flight.Landing)) != _d.PropValue*/) {
                                //                $('#' + _d.PropName).val(toTime(CreateDate($scope.flight.Landing)));
                                //                updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: toTime(CreateDate($scope.flight.Landing)) });
                                //            }
                                //            //prop_onblock
                                //            if (_d.PropName == 'prop_onblock' /*&& toTime(CreateDate($scope.flight.BlockOn)) != _d.PropValue*/) {
                                //                $('#' + _d.PropName).val(toTime(CreateDate($scope.flight.BlockOn)));
                                //                updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: toTime(CreateDate($scope.flight.BlockOn)) });
                                //            }



                                //        });


                                //        $scope.fillSOB();


                                //        $scope.fillETA();

                                //        $scope.fillETAAlt1();

                                //        $scope.fillETAAlt2();


                                //        if ($scope.url_sign)
                                //            $('#sig_pic_img').attr('src', $scope.url_sign);


                                //    }
                                //    catch (e) {
                                //        alert(e);
                                //    }

                                //}, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

                                ////////// END OF GET PROPS //////////////

                            }

                            ////// END OF OFP VERSION CHECK /////////////
                        });



                    });


                }


                if (callback)
                    callback();

            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });






            //  }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

            //end of get dr


        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };


    //2023
    $scope.fillETAAlt1 = function () {
        var loop = true;
        if (!$scope.ETA)
            return;
        $.each($scope.entity.JAPlan1, function (_i, _d) {
            if (loop) {
                if (_i == 0) {
                    var first_eta = $('#prop_' + _d._key + '_a1eta_' + _i).val();
                    if (!first_eta) {
                        //$scope.formatDateTime
                        var _time = toTime($scope.ETA);
                        $('#prop_' + _d._key + '_a1eta_' + _i).val(_time);
                        _d.eta = _time;//_toNum(_time.substr(0, 2)) * 60 + _toNum(_time.substr(2, 2));

                    }

                }
                else {
                    var pre = $scope.entity.JAPlan1[_i - 1];

                    var pre_eta = pre.eta;
                    var pre_ata = $('#prop_' + pre._key + '_a1ata_' + (_i - 1).toString()).val();
                    var _t = pre_ata ? pre_ata : pre_eta;

                    var _tn = _toNum(_t.substr(0, 2)) * 60 + _toNum(_t.substr(2, 2));
                    _tn += _toNum(_d.TME.split(':')[0]) * 60 + _toNum(_d.TME.split(':')[1]);
                    $('#prop_' + _d._key + '_a1eta_' + _i).val(time_convert(_tn));
                    _d.eta = time_convert(_tn);
                }




            }


        });

    }
    $scope.fillETAAlt2 = function () {
        var loop = true;
        if (!$scope.ETA)
            return;
        $.each($scope.entity.JAPlan2, function (_i, _d) {
            if (loop) {
                if (_i == 0) {
                    var first_eta = $('#prop_' + _d._key + '_a2eta_' + _i).val();
                    if (!first_eta) {
                        //$scope.formatDateTime
                        var _time = toTime($scope.ETA);
                        $('#prop_' + _d._key + '_a2eta_' + _i).val(_time);
                        _d.eta = _time;//_toNum(_time.substr(0, 2)) * 60 + _toNum(_time.substr(2, 2));

                    }

                }
                else {
                    var pre = $scope.entity.JAPlan2[_i - 1];

                    var pre_eta = pre.eta;
                    var pre_ata = $('#prop_' + pre._key + '_a2ata_' + (_i - 1).toString()).val();
                    var _t = pre_ata ? pre_ata : pre_eta;

                    var _tn = _toNum(_t.substr(0, 2)) * 60 + _toNum(_t.substr(2, 2));
                    _tn += _toNum(_d.TME.split(':')[0]) * 60 + _toNum(_d.TME.split(':')[1]);
                    $('#prop_' + _d._key + '_a2eta_' + _i).val(time_convert(_tn));
                    _d.eta = time_convert(_tn);
                }




            }


        });

    }

    ////////////////////////////////
    $scope.scroll_dradd_height = $(window).height() - 100;
    var appWindow = angular.element($window);
    appWindow.bind('resize', function () {
        //alert('w: '+$(window).width());

        $scope.$apply(function () {
            $scope.scroll_dradd_height = $(window).height() - 100;
        });
    });
    $scope.scroll_dradd = {
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
            height: 'scroll_dradd_height'
        }

    };

    $scope.formatDate = function (dt) {
        return moment(new Date(dt)).format('MMM DD yyyy');
    };
    $scope.formatDateTime = function (dt) {
        return moment(new Date(dt)).format('HH:mm');
    };
    /////////////////////////////////
    $scope.tempData = null;
    $scope.$on('onSign', function (event, prms) {

        if (prms.doc == 'ofp')
            flightService.signDocLocal(prms, prms.doc).then(function (response) {

                // $scope.isEditable = false;
                //$scope.isLockVisible = false;
                $scope.url_sign = signFiles + prms.PICId + ".png";
                $scope.PIC = prms.PIC;
                $scope.signDate = moment(new Date(prms.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
                if ($scope.url_sign)
                    $('#sig_pic_img').attr('src', $scope.url_sign);
            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

    });
    $scope.$on('InitOFPAdd', function (event, prms) {



        $scope.tempData = null;

        $scope.tempData = prms;


        $scope.popup_add_visible = true;

    });

}]);