gx.evt.autoSkip=!1;gx.define("anadirtarea",!1,function(){var n,t;this.ServerClass="anadirtarea";this.PackageName="GeneXus.Programs";this.ServerFullClass="anadirtarea.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A9TableroId=gx.fn.getIntegerValue("TABLEROID",".");this.Gx_date=gx.fn.getDateValue("vTODAY");this.AV8TableroId=gx.fn.getIntegerValue("vTABLEROID",".");this.AV7sdt_sa=gx.fn.getControlValue("vSDT_SA")};this.Validv_Tareafechainicio=function(){return this.validCliEvt("Validv_Tareafechainicio",0,function(){try{var n=gx.util.balloon.getNew("vTAREAFECHAINICIO");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV14TareaFechaInicio)===0||new gx.date.gxdate(this.AV14TareaFechaInicio).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Tarea Fecha Inicio fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Tareafechafin=function(){return this.validCliEvt("Validv_Tareafechafin",0,function(){try{var n=gx.util.balloon.getNew("vTAREAFECHAFIN");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV15TareaFechaFin)===0||new gx.date.gxdate(this.AV15TareaFechaFin).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Tarea Fecha Fin fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e120u2_client=function(){return this.executeServerEvent("'CANCELAR'",!1,null,!1,!1)};this.e130u2_client=function(){return this.executeServerEvent("'GUARDAR'",!1,null,!1,!1)};this.e150u2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e160u2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37];this.GXLastCtrlId=37;this.RAMP_ADDONS_SWEETALERT1Container=gx.uc.getNew(this,38,17,"RAMP_AddOns_SweetAlert","RAMP_ADDONS_SWEETALERT1Container","Ramp_addons_sweetalert1","RAMP_ADDONS_SWEETALERT1");t=this.RAMP_ADDONS_SWEETALERT1Container;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Version","Version","build 1.5.00","str");t.setProp("By","About","by RAMP (irodo@protonmail.com)","str");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"IMAGE1",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TEXTBLOCK1",format:1,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLE1",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTAREANOMBRE",gxz:"ZV13TareaNombre",gxold:"OV13TareaNombre",gxvar:"AV13TareaNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13TareaNombre=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13TareaNombre=n)},v2c:function(){gx.fn.setControlValue("vTAREANOMBRE",gx.O.AV13TareaNombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13TareaNombre=this.val())},val:function(){return gx.fn.getControlValue("vTAREANOMBRE")},nac:gx.falseFn};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Tareafechainicio,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTAREAFECHAINICIO",gxz:"ZV14TareaFechaInicio",gxold:"OV14TareaFechaInicio",gxvar:"AV14TareaFechaInicio",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[22],ip:[22],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14TareaFechaInicio=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV14TareaFechaInicio=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vTAREAFECHAINICIO",gx.O.AV14TareaFechaInicio,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV14TareaFechaInicio=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vTAREAFECHAINICIO")},nac:gx.falseFn};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Tareafechafin,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTAREAFECHAFIN",gxz:"ZV15TareaFechaFin",gxold:"OV15TareaFechaFin",gxvar:"AV15TareaFechaFin",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[26],ip:[26],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15TareaFechaFin=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV15TareaFechaFin=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vTAREAFECHAFIN",gx.O.AV15TareaFechaFin,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15TareaFechaFin=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vTAREAFECHAFIN")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESPONSABLE",gxz:"ZV16Responsable",gxold:"OV16Responsable",gxvar:"AV16Responsable",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV16Responsable=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV16Responsable=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vRESPONSABLE",gx.O.AV16Responsable)},c2v:function(){this.val()!==undefined&&(gx.O.AV16Responsable=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vRESPONSABLE",".")},nac:gx.falseFn};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"SECTION1",grid:0};n[34]={id:34,fld:"GUARDAR",grid:0,evt:"e130u2_client"};n[35]={id:35,fld:"CANCELAR",grid:0,evt:"e120u2_client"};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};this.AV13TareaNombre="";this.ZV13TareaNombre="";this.OV13TareaNombre="";this.AV14TareaFechaInicio=gx.date.nullDate();this.ZV14TareaFechaInicio=gx.date.nullDate();this.OV14TareaFechaInicio=gx.date.nullDate();this.AV15TareaFechaFin=gx.date.nullDate();this.ZV15TareaFechaFin=gx.date.nullDate();this.OV15TareaFechaFin=gx.date.nullDate();this.AV16Responsable=0;this.ZV16Responsable=0;this.OV16Responsable=0;this.AV13TareaNombre="";this.AV14TareaFechaInicio=gx.date.nullDate();this.AV15TareaFechaFin=gx.date.nullDate();this.AV16Responsable=0;this.A9TableroId=0;this.A18ParticipanteTableroId=0;this.Gx_date=gx.date.nullDate();this.AV8TableroId=0;this.AV7sdt_sa={title:"",type:"",html:"",iconColor:"",iconHtml:"",footer:"",backdrop:"",toast:"",grow:"",width:"",padding:"",background:"",position:"",timer:0,showCloseButton:!1,allowEnterKey:!1,allowOutsideClick:!1,showConfirmButton:!1,confirmButtonText:"",confirmButtonColor:"",confirmButtonUrl:"",focusConfirm:!1,showCancelButton:!1,cancelButtonText:"",cancelButtonUrl:"",showDenyButton:!1,denyButtonText:"",denyBurronUrl:"",imageUrl:"",imageWidth:0,imageHeight:0};this.Events={e120u2_client:["'CANCELAR'",!0],e130u2_client:["'GUARDAR'",!0],e150u2_client:["ENTER",!0],e160u2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"Gx_date",fld:"vTODAY",pic:"",hsh:!0},{av:"AV8TableroId",fld:"vTABLEROID",pic:"ZZZ9",hsh:!0},{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.START=[[{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0},{av:"A18ParticipanteTableroId",fld:"PARTICIPANTETABLEROID",pic:"ZZZ9"},{ctrl:"vRESPONSABLE"},{av:"AV16Responsable",fld:"vRESPONSABLE",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("TEXTBLOCK1","Caption")',ctrl:"TEXTBLOCK1",prop:"Caption"},{ctrl:"vRESPONSABLE"},{av:"AV16Responsable",fld:"vRESPONSABLE",pic:"ZZZ9"},{av:"AV8TableroId",fld:"vTABLEROID",pic:"ZZZ9",hsh:!0}]];this.EvtParms["'CANCELAR'"]=[[{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms["'GUARDAR'"]=[[{av:"AV13TareaNombre",fld:"vTAREANOMBRE",pic:""},{av:"AV14TareaFechaInicio",fld:"vTAREAFECHAINICIO",pic:""},{av:"Gx_date",fld:"vTODAY",pic:"",hsh:!0},{av:"AV15TareaFechaFin",fld:"vTAREAFECHAFIN",pic:""},{av:"AV8TableroId",fld:"vTABLEROID",pic:"ZZZ9",hsh:!0},{ctrl:"vRESPONSABLE"},{av:"AV16Responsable",fld:"vRESPONSABLE",pic:"ZZZ9"},{av:"AV7sdt_sa",fld:"vSDT_SA",pic:""},{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0}],[{av:"AV7sdt_sa",fld:"vSDT_SA",pic:""}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_TAREAFECHAINICIO=[[],[]];this.EvtParms.VALIDV_TAREAFECHAFIN=[[],[]];this.setVCMap("A9TableroId","TABLEROID",0,"int",4,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("AV8TableroId","vTABLEROID",0,"int",4,0);this.setVCMap("AV7sdt_sa","vSDT_SA",0,"SDT_SweetAlert",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.anadirtarea)})