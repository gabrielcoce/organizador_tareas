gx.evt.autoSkip=!1;gx.define("editartablero",!1,function(){var n,t;this.ServerClass="editartablero";this.PackageName="GeneXus.Programs";this.ServerFullClass="editartablero.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A9TableroId=gx.fn.getIntegerValue("TABLEROID",".");this.AV9Tableros=gx.fn.getControlValue("vTABLEROS");this.AV6sdt_sa=gx.fn.getControlValue("vSDT_SA")};this.e120p2_client=function(){return this.executeServerEvent("'CANCELAR'",!1,null,!1,!1)};this.e130p2_client=function(){return this.executeServerEvent("'GUARDAR'",!1,null,!1,!1)};this.e150p2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e160p2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28];this.GXLastCtrlId=28;this.RAMP_ADDONS_SWEETALERT1Container=gx.uc.getNew(this,29,17,"RAMP_AddOns_SweetAlert","RAMP_ADDONS_SWEETALERT1Container","Ramp_addons_sweetalert1","RAMP_ADDONS_SWEETALERT1");t=this.RAMP_ADDONS_SWEETALERT1Container;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Version","Version","build 1.5.00","str");t.setProp("By","About","by RAMP (irodo@protonmail.com)","str");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"IMAGE1",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TEXTBLOCK1",format:1,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLE1",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTABLERONOMBRE",gxz:"ZV8TableroNombre",gxold:"OV8TableroNombre",gxvar:"AV8TableroNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8TableroNombre=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8TableroNombre=n)},v2c:function(){gx.fn.setControlValue("vTABLERONOMBRE",gx.O.AV8TableroNombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8TableroNombre=this.val())},val:function(){return gx.fn.getControlValue("vTABLERONOMBRE")},nac:gx.falseFn};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,lvl:0,type:"boolean",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTABLEROVISIBILIDAD",gxz:"ZV10TableroVisibilidad",gxold:"OV10TableroVisibilidad",gxvar:"AV10TableroVisibilidad",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV10TableroVisibilidad=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10TableroVisibilidad=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setComboBoxValue("vTABLEROVISIBILIDAD",gx.O.AV10TableroVisibilidad)},c2v:function(){this.val()!==undefined&&(gx.O.AV10TableroVisibilidad=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vTABLEROVISIBILIDAD")},nac:gx.falseFn};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"SECTION1",grid:0};n[25]={id:25,fld:"GUARDAR",grid:0,evt:"e130p2_client"};n[26]={id:26,fld:"CANCELAR",grid:0,evt:"e120p2_client"};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};this.AV8TableroNombre="";this.ZV8TableroNombre="";this.OV8TableroNombre="";this.AV10TableroVisibilidad=!1;this.ZV10TableroVisibilidad=!1;this.OV10TableroVisibilidad=!1;this.AV8TableroNombre="";this.AV10TableroVisibilidad=!1;this.A9TableroId=0;this.AV9Tableros={TableroId:0,TableroNombre:"",TableroFechaCreacion:gx.date.nullDate(),PropietarioId:0,TableroEstado:!1,TableroVisibilidad:!1,Mode:"",Initialized:0,TableroId_Z:0,TableroNombre_Z:"",TableroFechaCreacion_Z:gx.date.nullDate(),PropietarioId_Z:0,TableroEstado_Z:!1,TableroVisibilidad_Z:!1};this.AV6sdt_sa={title:"",type:"",html:"",iconColor:"",iconHtml:"",footer:"",backdrop:"",toast:"",grow:"",width:"",padding:"",background:"",position:"",timer:0,showCloseButton:!1,allowEnterKey:!1,allowOutsideClick:!1,showConfirmButton:!1,confirmButtonText:"",confirmButtonColor:"",confirmButtonUrl:"",focusConfirm:!1,showCancelButton:!1,cancelButtonText:"",cancelButtonUrl:"",showDenyButton:!1,denyButtonText:"",denyBurronUrl:"",imageUrl:"",imageWidth:0,imageHeight:0};this.Events={e120p2_client:["'CANCELAR'",!0],e130p2_client:["'GUARDAR'",!0],e150p2_client:["ENTER",!0],e160p2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.START=[[{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("TEXTBLOCK1","Caption")',ctrl:"TEXTBLOCK1",prop:"Caption"},{av:"AV9Tableros",fld:"vTABLEROS",pic:""},{av:"AV8TableroNombre",fld:"vTABLERONOMBRE",pic:""},{ctrl:"vTABLEROVISIBILIDAD"},{av:"AV10TableroVisibilidad",fld:"vTABLEROVISIBILIDAD",pic:""}]];this.EvtParms["'CANCELAR'"]=[[{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms["'GUARDAR'"]=[[{av:"AV8TableroNombre",fld:"vTABLERONOMBRE",pic:""},{av:"AV9Tableros",fld:"vTABLEROS",pic:""},{ctrl:"vTABLEROVISIBILIDAD"},{av:"AV10TableroVisibilidad",fld:"vTABLEROVISIBILIDAD",pic:""},{av:"AV6sdt_sa",fld:"vSDT_SA",pic:""},{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0}],[{av:"AV9Tableros",fld:"vTABLEROS",pic:""},{av:"AV6sdt_sa",fld:"vSDT_SA",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("A9TableroId","TABLEROID",0,"int",4,0);this.setVCMap("AV9Tableros","vTABLEROS",0,"Tableros",0,0);this.setVCMap("AV6sdt_sa","vSDT_SA",0,"SDT_SweetAlert",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.editartablero)})