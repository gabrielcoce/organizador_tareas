gx.evt.autoSkip=!1;gx.define("anadiractividad",!1,function(){var n,t;this.ServerClass="anadiractividad";this.PackageName="GeneXus.Programs";this.ServerFullClass="anadiractividad.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A12TareaId=gx.fn.getIntegerValue("TAREAID",".");this.A9TableroId=gx.fn.getIntegerValue("TABLEROID",".");this.AV11TableroId=gx.fn.getIntegerValue("vTABLEROID",".");this.AV17TareaId=gx.fn.getIntegerValue("vTAREAID",".");this.AV10sdt_sa=gx.fn.getControlValue("vSDT_SA")};this.e120w2_client=function(){return this.executeServerEvent("'CANCELAR'",!1,null,!1,!1)};this.e130w2_client=function(){return this.executeServerEvent("'GUARDAR'",!1,null,!1,!1)};this.e150w2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e160w2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24];this.GXLastCtrlId=24;this.RAMP_ADDONS_SWEETALERT1Container=gx.uc.getNew(this,25,17,"RAMP_AddOns_SweetAlert","RAMP_ADDONS_SWEETALERT1Container","Ramp_addons_sweetalert1","RAMP_ADDONS_SWEETALERT1");t=this.RAMP_ADDONS_SWEETALERT1Container;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Version","Version","build 1.5.00","str");t.setProp("By","About","by RAMP (irodo@protonmail.com)","str");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"IMAGE1",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TEXTBLOCK1",format:1,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLE1",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vACTIVIDADNOMBRE",fmt:0,gxz:"ZV23ActividadNombre",gxold:"OV23ActividadNombre",gxvar:"AV23ActividadNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV23ActividadNombre=n)},v2z:function(n){n!==undefined&&(gx.O.ZV23ActividadNombre=n)},v2c:function(){gx.fn.setControlValue("vACTIVIDADNOMBRE",gx.O.AV23ActividadNombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV23ActividadNombre=this.val())},val:function(){return gx.fn.getControlValue("vACTIVIDADNOMBRE")},nac:gx.falseFn};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"SECTION1",grid:0};n[21]={id:21,fld:"GUARDAR",grid:0,evt:"e130w2_client"};n[22]={id:22,fld:"CANCELAR",grid:0,evt:"e120w2_client"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};this.AV23ActividadNombre="";this.ZV23ActividadNombre="";this.OV23ActividadNombre="";this.AV23ActividadNombre="";this.A9TableroId=0;this.A12TareaId=0;this.AV11TableroId=0;this.AV17TareaId=0;this.AV10sdt_sa={title:"",type:"",html:"",iconColor:"",iconHtml:"",footer:"",backdrop:"",toast:"",grow:"",width:"",padding:"",background:"",position:"",timer:0,showCloseButton:!1,allowEnterKey:!1,allowOutsideClick:!1,showConfirmButton:!1,confirmButtonText:"",confirmButtonColor:"",confirmButtonUrl:"",focusConfirm:!1,showCancelButton:!1,cancelButtonText:"",cancelButtonUrl:"",showDenyButton:!1,denyButtonText:"",denyBurronUrl:"",imageUrl:"",imageWidth:0,imageHeight:0};this.Events={e120w2_client:["'CANCELAR'",!0],e130w2_client:["'GUARDAR'",!0],e150w2_client:["ENTER",!0],e160w2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV11TableroId",fld:"vTABLEROID",pic:"ZZZ9",hsh:!0},{av:"AV17TareaId",fld:"vTAREAID",pic:"ZZZ9",hsh:!0},{av:"A12TareaId",fld:"TAREAID",pic:"ZZZ9",hsh:!0},{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms["'CANCELAR'"]=[[{av:"A12TareaId",fld:"TAREAID",pic:"ZZZ9",hsh:!0},{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms["'GUARDAR'"]=[[{av:"AV23ActividadNombre",fld:"vACTIVIDADNOMBRE",pic:""},{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0},{av:"A12TareaId",fld:"TAREAID",pic:"ZZZ9",hsh:!0},{av:"AV11TableroId",fld:"vTABLEROID",pic:"ZZZ9",hsh:!0},{av:"AV17TareaId",fld:"vTAREAID",pic:"ZZZ9",hsh:!0},{av:"AV10sdt_sa",fld:"vSDT_SA",pic:""}],[{av:"AV10sdt_sa",fld:"vSDT_SA",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("A12TareaId","TAREAID",0,"int",4,0);this.setVCMap("A9TableroId","TABLEROID",0,"int",4,0);this.setVCMap("AV11TableroId","vTABLEROID",0,"int",4,0);this.setVCMap("AV17TareaId","vTAREAID",0,"int",4,0);this.setVCMap("AV10sdt_sa","vSDT_SA",0,"SDT_SweetAlert",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.anadiractividad)})