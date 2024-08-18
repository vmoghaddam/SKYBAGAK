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
				try
				{
					 var ofp=$(this).data('ofp');
					 
			    }
                catch (ex) {
                }
			}
			//nilo
            if ($(this).attr('id').includes('_rem_')) {
                try {
					
                    var diff = $scope.fuel_total  - Number($(this).val());
					var remid=$(this).attr('id');
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
					var remid=$(this).attr('id');
					var ofpused = $('#' + remid).data('ofpused');
                    var diff = $scope.fuel_total  - Number($(this).val());
					
                    

                   
                    var ofp = $('#' + remid).data('ofp');
					 
                    var diff_rem = Number($(this).val()) - ofp;
					
					var usedId = $(this).attr('id').replace('_a1rem_', '_a1usd_');
                    $('#' + usedId).val(-diff_rem+Number(ofpused));
					 
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
					var remid=$(this).attr('id');
					var ofpused = $('#' + remid).data('ofpused');
                    var diff = $scope.fuel_total  - Number($(this).val());
					
                    
                   
                    var ofp = $('#' + remid).data('ofp');
					 
                    var diff_rem = Number($(this).val()) - ofp;
					
					var usedId = $(this).attr('id').replace('_a2rem_', '_a2usd_');
                    $('#' + usedId).val(-diff_rem+Number(ofpused));

					 
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
				   var ofp=$(this).data('ofp');
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
    $scope.getPropClass = function (id) {

        if (id.includes('fuel_req'))
            return 'prop noborder';
        return 'prop';
    };
    $scope.updateValue = function (propId, value) {
        //12-04

        if (propId == sobId) {

            return;
        }
        var dto = { OFPId: $scope.entity.Id, PropName: propId, User: $rootScope.userTitle };

        dto.PropValue = value;
        // $scope.loadingVisible = true;
        flightService.saveOFPProp(dto).then(function (response2) {

            // $scope.loadingVisible = false;


            $scope.fillSOB();

            if (propId.includes('_ata_'))
                $scope.fillETA();
			 if (propId.includes('_a1ata_'))
                $scope.fillETAAlt1();
			 if (propId.includes('_a2ata_'))
                $scope.fillETAAlt2();
			



        }, function (err) {

            $scope.loadingVisible = false; General.ShowNotify(JSON.stringify(err), 'error');
        });
    };
    //12-04
    $scope.onBlur = function (propId, value, prev) {
        $scope.updateValue(propId, value);
        return;
        var _v = (value === undefined || (!value && value !== 0)) ? value : value.toString().replace(/\s/g, '');
        if ((!_v && _v !== 0) || _v === undefined) {
            $('#' + propId).val(prev);
            return;


        }
        else {

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
			var res=r.COR.replaceAll("D", "°").replaceAll("M", "'").replaceAll("S", '"');
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



    $scope.OFPHtml = '';
    var crewAId = null;
    var crewBId = null;
    var crewCId = null;
    var sobId = null;

    $scope.fuel_total = 0;
    $scope.plan_fuel_offblock = 0;
    $scope.plan_fuel_takeoff = 0;
    $scope.getPlannedFuelValue=function(x){
		
		if (x.prm=='TOF')
		{
			var p_tof = Enumerable.From($scope.entity.JFuel).Where('$._key=="fuel_tof"').FirstOrDefault();
			return p_tof.pvalue;
		}
		else if (x.prm=='OFF BLK'){
			var p_offblock = Enumerable.From($scope.entity.JFuel).Where('$._key=="fuel_offblk"').FirstOrDefault();
			return p_offblock.pvalue;
		}
		else
			return x.value;
	};
    $scope.fill = function (data, callback) {
       //09-30
        data.JPlan = data.JPlan ? JSON.parse(data.JPlan) : [];
        data.JAPlan1 = data.JAPlan1 ? JSON.parse(data.JAPlan1) : [];
        data.JAPlan2 = data.JAPlan2 ? JSON.parse(data.JAPlan2) : [];
		data.JFuel = data.JFuel ? JSON.parse(data.JFuel) : [];
		if (data.JFuel.length>0)
		{
			//data.JFuel.push({prm:'EXTRA',value:0,_key:'fuel_extra'});
			data.JFuel.splice(data.JFuel.length-2, 0, {prm:'EXTRA',value:0,_key:'fuel_extra'});
		}
		 
        var _ejf=['HOLD','ZFW','TOW','LW','REQ','EZFW','ETOW','ELW'];
		data.JFuel=Enumerable.From( data.JFuel).Where(function(x){return _ejf.indexOf(x.prm)==-1;}).ToArray();
		data.FuelACTUALTANKERING=$scope.TNK;//$scope.flight.ACTUALTANKERINGFUEL;
		$.each(data.JFuel,function(_n,_p){
			//console.log(_p);
			if (_p.prm=='TANKERING')
			{
				_p.value=data.FuelACTUALTANKERING;
				//console.log(data,_p.value);
		    }
			if (_p.prm=='TOTAL FUEL'){
				
				_p.value=data.FuelTOTALFUEL+( data.FuelACTUALTANKERING-data.FuelTANKERING);
			}
		});
		 
        data.JCSTBL = data.JCSTBL ? JSON.parse(data.JCSTBL) : [];
        data.JALDRF = data.JALDRF ? JSON.parse(data.JALDRF) : [];
         
		 data.JALDRF_FL = Enumerable.From(data.JALDRF).Where('$.FL =="'+data.FLL+'"').FirstOrDefault();
        data.JALDRF = Enumerable.From(data.JALDRF).Where('$.FL !="'+data.FLL+'"').ToArray();
        
        data.JWTDRF = data.JWTDRF ? JSON.parse(data.JWTDRF) : [];
		
        $scope.plan_fuel_offblock = 0;
        $scope.plan_fuel_takeoff = 0;
        
		try {
			
            $scope.fuel_total = $scope.flight.FuelRemaining + $scope.flight.FuelUplift;
			console.log('total fuel',$scope.fuel_total);
            var p_offblock = Enumerable.From(data.JFuel).Where(/*'$._key=="fuel_offblk"'*/ '$._key=="fuel_totalfuel"').FirstOrDefault();
			
			console.log('----a1');
			
			//data.JFuel.OFFPlanned=JSON.parse( JSON.stringify( p_offblock ));
			p_offblock.pvalue=p_offblock.value;
			console.log('----a2');
            if (p_offblock)
                $scope.plan_fuel_offblock = p_offblock.value;

console.log('----a3');
            var p_tof = Enumerable.From(data.JFuel).Where('$._key=="fuel_tof"').FirstOrDefault();
			console.log('----a4');
            if (p_tof)
			  $scope.plan_fuel_takeoff = p_tof.value;
             
			 
			//data.JFuel.TOFPlanned=JSON.parse( JSON.stringify( p_tof ));
			// 	console.log('pln fue',data.JFuel);
			if (p_tof)
            p_tof.pvalue=p_tof.value;
			 if (p_tof)
			p_tof.value = $scope.fuel_total - 200;
			console.log('----a7');
            p_offblock.value = $scope.fuel_total;
			console.log('----a8');

            $.each(data.JPlan, function (_i, _d) {
				console.log(_d.FRE,_d.FUS);
                _d._FRE = _d.FRE;
                _d.FRE = $scope.fuel_total - _d.FUS;
				console.log('----end-----');
            });
			console.log('total fuel2',$scope.fuel_total);
			var _alt_remain=Number($scope.fuel_total)-Number(data.FPTripFuel)-200;
			var _extra=$scope.fuel_total -data.FuelTOTALFUEL;// (Number(data.FPTripFuel)+Number(data.FuelTAXI)); //$scope.plan_fuel_offblock;
			var _rem_for_alt=$scope.fuel_total -(Number(data.FPTripFuel)+Number(data.FuelTAXI));
			console.log('alt fuel2',_extra);
			console.log('alt fuel2',data.FPTripFuel);
			console.log('alt fuel2',data.FuelTAXI);
			$.each(data.JAPlan1, function (_i, _d) {
                _d._FRE = _d.FRE;
                _d.FRE =_rem_for_alt-Number(_d.FUS); //Number(_d.FRE)+_extra;
            });
			$.each(data.JAPlan2, function (_i, _d) {
                _d._FRE = _d.FRE;
                _d.FRE =_rem_for_alt-Number(_d.FUS); //Number(_d.FRE)+_extra;
            });

        }
        catch (e_f) {
			console.log('ERROR',e_f);
        }

        
      
       


        
       // console.log('plan offblock   ASDASDASDASD ', $scope.plan_fuel_offblock);
        try {

            var lst = data.JPlan[data.JPlan.length - 1].TTM;
            var mm = _toNum(lst.split(':')[0]) * 60 + _toNum(lst.split(':')[1]);

            var _base = $scope.flight.TakeOff ? CreateDate($scope.flight.TakeOff) : CreateDate($scope.flight.STD);
             
			 //niloo2
			 
			
			 var eta_nu=_toNum(data.ETA.replace(':',''));
			 var etd_nu=_toNum(data.ETD.replace(':',''));
			 console.log('ETA',eta_nu);
			 console.log('ETD',etd_nu);
			 
			 var eta_prts=data.ETA.split(':');
			 var etd_prts=data.ETD.split(':');
			 
			 var eta_dt=CreateDate($scope.flight.STDDay).addHours(eta_prts[0]).addMinutes(eta_prts[1])
			  console.log(eta_dt);
			 
            $scope.ETA = eta_dt;//new Date(_base.addMinutes(mm));
			 console.log($scope.ETA);

        }
        catch (eer) {

        }
		
		try{
			//alert($scope.fuel_total);
			//alert(data.FPTripFuel);
			 $scope.DIST=data.JPlan[data.JPlan.length-1].TDS;
			
		}
		catch(e_a1){
		}
       
	    data.WDCLB_DS=data.WDCLB ? data.WDCLB.split('*'):[];
		data.WDDES_DS=data.WDDES ? data.WDDES.split('*'):[];
		
		var WDTMP_p1=data.WDTMP ? (data.WDTMP.split('^')[0]).split('_'):[];
		var WDTMP_p2=data.WDTMP? (data.WDTMP.split('^')[1]).replaceAll('_','').replaceAll('FL', '<span class="spfl">FL').replaceAll(':', '</span>').split('*'):[];
		data.WDTMP_DS1=WDTMP_p1;
		data.WDTMP_DS2=[];
		$.each(WDTMP_p2,function(_h,_k){
			data.WDTMP_DS2.push(
			{
				id:_h,
				txt:_k
			}
			);
			
		});
		
		//console.log('WDTMP');
	//	console.log(data.WDTMP_DS1);
		//console.log(data.WDTMP_DS2);
		
		
        $scope.entity = data;
        setTimeout(function () {
            callback();
        }, 100);

        //$scope.OFPHtml = $sce.trustAsHtml($scope.entity.TextOutput);

        //setTimeout(function () {


        //    $('#prop_pax_adult').attr('readonly', true).addClass('noborder');
        //    $('#prop_pax_child').attr('readonly', true).addClass('noborder');
        //    $('#prop_pax_infant').attr('readonly', true).addClass('noborder');
        //    $('#prop_offblock').attr('readonly', true);
        //    $('#prop_takeoff').attr('readonly', true);
        //    $('#prop_landing').attr('readonly', true);
        //    $('#prop_onblock').attr('readonly', true);


        //    var $clear = $("input[id^='prop_clearance']");
        //    $clear.width(600);

        //    var $adult = $clear.nextAll('.prop:first');
        //    crewAId = $adult.attr('id');

        //    var $child = $adult.nextAll('.prop:first');
        //    crewBId = $child.attr('id');

        //    var $infant = $child.nextAll('.prop:first');
        //    crewCId = $infant.attr('id');

        //    var $sob = $('#prop_pax_infant').nextAll('.prop:first');
        //    sobId = ($sob.attr('id'));
        //    callback();

        //}, 100);


       console.log('JFUEl',$scope.entity.JFuel);

    };
    $scope.isLockVisible = false;

    var toTime = function (dt) {
        if (!dt)
            return "";

        var result = moment(new Date(dt)).format('HHmm');



        return moment(new Date(dt)).format('HHmm');
    };
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
                $scope.signDate = moment(new Date(data.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
                $('#sig_pic_img').attr('src', $scope.url_sign);

                flightService.signOFPLocal(flightid, data);
            }
        });
    };
    $scope.hold = function (key, index) {

        var _id = 'prop_' + key + '_ata_' + index;
        var $elem = $('#' + _id);
        var dt = new Date();
        var _val = String(dt.getUTCHours()).padStart(2, '0') + String(dt.getUTCMinutes()).padStart(2, '0');
        $elem.val(_val);
        //var prev = $(this).data('val');
        $scope.onBlur(_id, _val, null);
    };
	$scope.getMetar=function(stn,_id){
		if (stn=='dep')
			stn=$scope.flight.FromAirportIATA;
		else
			stn=$scope.flight.ToAirportIATA;
		
		  flightService.getLastMetar(stn).then(function (response) {
             var metar=response.Data.RawText;
             var $elem = $('#' + _id);
              $elem.val(metar);
			   $scope.onBlur(_id, metar, null);
        }, function (err) {   });
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
	$scope.nowClick2 = function (key) {

        var _id = key;
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
        $scope.TNK=$scope.tempData.TNK;
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
               // $scope.loadingVisible = false;
               // if (resdr.Data) {
               //     $scope.dr = resdr.Data;
                   
               // }
               // else {
                   
               // }
                var diff = Math.abs((new Date()).getTime() - (new Date(response.Data.STALocal)).getTime()) / 3600000;

                $scope.flight = response.Data;
				$scope.mass_unit=$rootScope.isLbs($scope.flight.Register)?'LBS':'KG';

                $scope.loadingVisible = true;

                flightService.epGetOFPByFlight($scope.entity.FlightId).then(function (response2) {
                    $scope.isEditable = (diff <= 24);
                  //  console.log('OFP', response2.Data);
                    if (response2.Data && response2.Data.JLSignedBy) {
                        // $scope.isEditable = false;
                        $scope.url_sign = signFiles + response.Data.PICId + ".png";
                        $scope.PIC = response.Data.PIC;
                        $scope.signDate = moment(new Date(response.Data.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
                    }
                    else {
                        $scope.url_sign = null;
                        $scope.PIC = null;
                        $scope.signDate = null;
                    }

                    $scope.loadingVisible = false;

                        
                    if (!response2.Data) {

                        $scope.isNew = true;
                        $scope.entity = {
                            Id: -1,

                        };
                        $scope.entity.FlightId = $scope.tempData.FlightId;

                    }
                    else {

                        $scope.isNew = false;
                        $scope.fill(response2.Data, function () {


                            flightService.epCheckOFBVersion($scope.entity.FlightId, $scope.entity.Id).then(function (resCheck) {
                                if (resCheck.Data) {
                                    flightService.deleteOFP($scope.entity.FlightId, function () {
                                        alert("The OPF has been changed by Dispatchers. Please reopen the from to load new OFP.");
                                        $scope.popup_add_visible = false;
                                        return;
                                    });

                                }
                                else {
                                    ////// GET PROPS ///////////////

                                    $scope.loadingVisible = true;

                                    flightService.epGetOFPProps($scope.entity.Id).then(function (response3) {
                                        try {

                                            $scope.loadingVisible = false;


                                            //12-04

                                            if (!$scope.url_sign)
                                                $scope.checkSign($scope.entity.Id, $scope.entity.FlightId);




                                            $scope.props = response3.Data;

                                           // console.log($scope.props);


                                           

                                            //9-11
                                            var updates = [];
                                            var takeOffChanged = false;
                                            var sob = 0;
                                            var sobValue = null;
                                            var sobprops = ['prop_pax_adult', 'prop_pax_child', 'prop_pax_infant', crewAId, crewBId, crewCId];


                                            //here
                                            $('#prop_fuel_req').attr('readonly', true).addClass('noborder');

                                            $.each($scope.props, function (_i, _d) {

                                                //if (_d.PropName == sobId) {

                                                //    sobValue = _d.PropValue;
                                                //}
                                               //  console.log(_d.PropName);
                                                if (_d.PropName == 'prop_fuel_extra' || _d.PropName =='prop_fuel_ops.extra') {
                                                    //$scope.plan_fuel_offblock
                                                    if ($scope.fuel_total)
													{
														//console.log('fuel_extra',$scope.fuel_total - $scope.plan_fuel_offblock);  
														$('#prop_fuel_extra'  ).val($scope.fuel_total - $scope.plan_fuel_offblock);}
                                                    else
                                                       $('#' + _d.PropName).val(0);
                                                    $('#' + _d.PropName + '_due').val($scope.flight.ALT3);
                                                }

                                                else
                                                    if (_d.PropValue)
                                                        $('#' + _d.PropName).val(_d.PropValue);
//nilo
                                                if (_d.PropName.includes('x_usd_') && isNumeric(_d.PropValue)) {

                                                    try {
                                                        var ofp = $('#' + _d.PropName).data('ofp');
                                                        var diff = Number($('#' + _d.PropName).val()) - Number(ofp);

                                                        
                                                        var diffId = $('#' + _d.PropName).attr('id').replace('_usd_', '_dusd_');
                                                        $('#' + diffId).val(diff);
                                                    }
                                                    catch (ex) {

                                                    }

                                                }
												
												if (_d.PropName.includes('_rem_') && isNumeric(_d.PropValue)) {

                                                    try {
                                                        var ofp = $('#' + _d.PropName).data('ofp');
                                                        var diff = Number($('#' + _d.PropName).val()) - Number(ofp);

                                                        
                                                        var diffId = $('#' + _d.PropName).attr('id').replace('_rem_', '_drem_');
                                                        $('#' + diffId).val(diff);
                                                    }
                                                    catch (ex) {

                                                    }

                                                }
												
												if (_d.PropName.includes('_a1rem_') && isNumeric(_d.PropValue)) {

                                                    try {
                                                        var ofp = $('#' + _d.PropName).data('ofp');
                                                        var diff = Number($('#' + _d.PropName).val()) - Number(ofp);

                                                        
                                                        var diffId = $('#' + _d.PropName).attr('id').replace('_a1rem_', '_a1drem_');
                                                        $('#' + diffId).val(diff);
                                                    }
                                                    catch (ex) {

                                                    }

                                                }
												
												
												if (_d.PropName.includes('_a2rem_') && isNumeric(_d.PropValue)) {

                                                    try {
                                                        var ofp = $('#' + _d.PropName).data('ofp');
                                                        var diff = Number($('#' + _d.PropName).val()) - Number(ofp);

                                                        
                                                        var diffId = $('#' + _d.PropName).attr('id').replace('_a2rem_', '_a2drem_');
                                                        $('#' + diffId).val(diff);
                                                    }
                                                    catch (ex) {

                                                    }

                                                }

                                                if (_d.PropName == 'prop_fuel_req' && $scope.dr) {
                                                    $('#' + _d.PropName).val($scope.dr.MinFuelRequiredPilotReq);
                                                    updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: $scope.flight.PaxAdult });
                                                }


                                                if (_d.PropName == 'prop_pax_adult' /*&& $scope.flight.PaxAdult != _d.PropValue*/) {
                                                    $('#' + _d.PropName).val($scope.flight.PaxAdult);
                                                    updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: $scope.flight.PaxAdult });
                                                    //var dto = { OFPId: $scope.entity.Id, PropName: _d.propName, User: $rootScope.userTitle, PropValue: $scope.flight.PaxAdult };
                                                    //flightService.saveOFPProp(dto);
                                                }
                                                if (_d.PropName == 'prop_pax_child' /*&& $scope.flight.PaxChild != _d.PropValue*/) {
                                                    $('#' + _d.PropName).val($scope.flight.PaxChild);
                                                    updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: $scope.flight.PaxChild });
                                                }
                                                if (_d.PropName == 'prop_pax_infant' /*&& $scope.flight.PaxInfant != _d.PropValue*/) {
                                                    $('#' + _d.PropName).val($scope.flight.PaxInfant);
                                                    updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: $scope.flight.PaxInfant });
                                                }
                                                //prop_offblock

                                                if (_d.PropName == 'prop_offblock' /*&& toTime(CreateDate($scope.flight.BlockOff)) != _d.PropValue*/) {
                                                    $('#' + _d.PropName).val(toTime(CreateDate($scope.flight.BlockOff)));
                                                    updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: toTime(CreateDate($scope.flight.BlockOff)) });
                                                }
                                                //prop_takeoff
                                                if (_d.PropName == 'prop_takeoff' /*&& toTime(CreateDate($scope.flight.TakeOff)) != _d.PropValue*/) {
                                                    takeOffChanged = true;
                                                    $('#' + _d.PropName).val(toTime(CreateDate($scope.flight.TakeOff)));
                                                    updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: toTime(CreateDate($scope.flight.TakeOff)) });
                                                }
                                                //prop_landing
                                                if (_d.PropName == 'prop_landing' /*&& toTime(CreateDate($scope.flight.Landing)) != _d.PropValue*/) {
                                                    $('#' + _d.PropName).val(toTime(CreateDate($scope.flight.Landing)));
                                                    updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: toTime(CreateDate($scope.flight.Landing)) });
                                                }
                                                //prop_onblock
                                                if (_d.PropName == 'prop_onblock' /*&& toTime(CreateDate($scope.flight.BlockOn)) != _d.PropValue*/) {
                                                    $('#' + _d.PropName).val(toTime(CreateDate($scope.flight.BlockOn)));
                                                    updates.push({ OFPId: $scope.entity.Id, PropName: _d.PropName, User: $rootScope.userTitle, PropValue: toTime(CreateDate($scope.flight.BlockOn)) });
                                                }

                                                //if (sobprops.indexOf(_d.PropName) != -1) {
                                                //    var vlu = _toNum($('#' + _d.PropName).val());
                                                //    if (!isNaN(vlu))
                                                //        sob += vlu;
                                                //}

                                            });


                                            $scope.fillSOB();

                                            //if (sob != sobValue) {
                                            //    $('#' + sobId).val(sob);
                                            //    updates.push({ OFPId: $scope.entity.Id, PropName: sobId, User: $rootScope.userTitle, PropValue: sob });
                                            //}


                                            //if (takeOffChanged && $scope.flight.TakeOff) {
                                            //    var times = $("input[data-info^='time_']");
                                            //    var objs = [];
                                            //    $.each(times, function (_w, _t) {
                                            //        var data = $(_t).data('info');
                                            //        objs.push({ id: $(_t).attr('id'), index: Number(data.split('_')[1]), value: data.split('_')[2] });
                                            //    });
                                            //    objs = Enumerable.From(objs).OrderBy('$.index').ToArray();
                                            //    var to = CreateDate($scope.flight.TakeOff);
                                            //    $.each(objs, function (_w, _t) {
                                            //        to = new Date(to.addMinutes(_t.value));
                                            //        $('#' + _t.id).val(toTime(to));
                                            //        $('#' + _t.id).attr('readonly', true).addClass('noborder');

                                            //    });
                                            //}
                                            $scope.fillETA();
											
											$scope.fillETAAlt1();
											
											$scope.fillETAAlt2();


                                            if ($scope.url_sign)
                                                $('#sig_pic_img').attr('src', $scope.url_sign);
                                            //here





                                            //  $('#sig_disp_img').attr('src', signFiles + '3542.jpg');

                                            //  $('#sig_pic_img').attr('src', signFiles + '3542.jpg');

                                        }
                                        catch (e) {
                                            alert(e);
                                        }

                                    }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

                                    ////////// END OF GET PROPS //////////////

                                }

                                ////// END OF OFP VERSION CHECK /////////////
                            });



                        });


                    }

                     
                    if (callback)
                        callback();

                }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });






           // }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

            //end of get dr


        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    $scope.fillSOB = function () {
        var _sob = ($scope.flight.PaxAdult ? $scope.flight.PaxAdult : 0)
            + ($scope.flight.PaxChild ? $scope.flight.PaxChild : 0)
            + ($scope.flight.PaxInfant ? $scope.flight.PaxInfant : 0);
        var c1 = $('#prop_crew1').val();
        var c2 = $('#prop_crew2').val();
        var c3 = $('#prop_crew3').val();
        _sob += (c1 ? _toNum(c1) : 0) + (c2 ? _toNum(c2) : 0) + (c3 ? _toNum(c3) : 0);
        $('#prop_sob').val(_sob);
    }
    function time_convert(num) {
        var hours = Math.floor(num / 60);
        var minutes = num % 60;
        return hours.toString().padStart(2, '0') + minutes.toString().padStart(2, '0');
    }
	//2023
	$scope.fillETAAlt1=function(){
		var loop=true;
		if (!$scope.ETA)
			return;
		$.each($scope.entity.JAPlan1, function (_i, _d) {
			if (loop){
				if (_i==0){
				   var first_eta=$('#prop_' + _d._key + '_a1eta_' + _i).val();
				   if (!first_eta){
					   //$scope.formatDateTime
					   var _time=toTime($scope.ETA);
					   $('#prop_' + _d._key + '_a1eta_' + _i).val(_time);
					   _d.eta=_time;//_toNum(_time.substr(0, 2)) * 60 + _toNum(_time.substr(2, 2));
					   
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
	$scope.fillETAAlt2=function(){
		var loop=true;
		if (!$scope.ETA)
			return;
		$.each($scope.entity.JAPlan2, function (_i, _d) {
			if (loop){
				if (_i==0){
				   var first_eta=$('#prop_' + _d._key + '_a2eta_' + _i).val();
				   if (!first_eta){
					   //$scope.formatDateTime
					   var _time=toTime($scope.ETA);
					   $('#prop_' + _d._key + '_a2eta_' + _i).val(_time);
					   _d.eta=_time;//_toNum(_time.substr(0, 2)) * 60 + _toNum(_time.substr(2, 2));
					   
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