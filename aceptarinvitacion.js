gx.evt.autoSkip=!1;gx.define("aceptarinvitacion",!1,function(){var n,t;this.ServerClass="aceptarinvitacion";this.PackageName="GeneXus.Programs";this.ServerFullClass="aceptarinvitacion.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A9TableroId=gx.fn.getIntegerValue("TABLEROID",".");this.AV13sdt_sa=gx.fn.getControlValue("vSDT_SA")};this.e120s2_client=function(){return this.executeServerEvent("'REGISTRO'",!1,null,!1,!1)};this.e140s2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e150s2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46];this.GXLastCtrlId=46;this.RAMP_ADDONS_SWEETALERT1Container=gx.uc.getNew(this,47,21,"RAMP_AddOns_SweetAlert","RAMP_ADDONS_SWEETALERT1Container","Ramp_addons_sweetalert1","RAMP_ADDONS_SWEETALERT1");t=this.RAMP_ADDONS_SWEETALERT1Container;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Version","Version","build 1.5.00","str");t.setProp("By","About","by RAMP (irodo@protonmail.com)","str");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLE1",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"IMAGE1",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TEXTBLOCK1",format:1,grid:0,ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSUARIONOMBRE",gxz:"ZV5UsuarioNombre",gxold:"OV5UsuarioNombre",gxvar:"AV5UsuarioNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5UsuarioNombre=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5UsuarioNombre=n)},v2c:function(){gx.fn.setControlValue("vUSUARIONOMBRE",gx.O.AV5UsuarioNombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5UsuarioNombre=this.val())},val:function(){return gx.fn.getControlValue("vUSUARIONOMBRE")},nac:gx.falseFn};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSUARIOAPELLIDO",gxz:"ZV6UsuarioApellido",gxold:"OV6UsuarioApellido",gxvar:"AV6UsuarioApellido",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6UsuarioApellido=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6UsuarioApellido=n)},v2c:function(){gx.fn.setControlValue("vUSUARIOAPELLIDO",gx.O.AV6UsuarioApellido,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6UsuarioApellido=this.val())},val:function(){return gx.fn.getControlValue("vUSUARIOAPELLIDO")},nac:gx.falseFn};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSUARIOEMAIL",gxz:"ZV7UsuarioEmail",gxold:"OV7UsuarioEmail",gxvar:"AV7UsuarioEmail",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7UsuarioEmail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7UsuarioEmail=n)},v2c:function(){gx.fn.setControlValue("vUSUARIOEMAIL",gx.O.AV7UsuarioEmail,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7UsuarioEmail=this.val())},val:function(){return gx.fn.getControlValue("vUSUARIOEMAIL")},nac:gx.falseFn};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"char",len:200,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSUARIOPASSWORD",gxz:"ZV8UsuarioPassword",gxold:"OV8UsuarioPassword",gxvar:"AV8UsuarioPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8UsuarioPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8UsuarioPassword=n)},v2c:function(){gx.fn.setControlValue("vUSUARIOPASSWORD",gx.O.AV8UsuarioPassword,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8UsuarioPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSUARIOPASSWORD")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,lvl:0,type:"char",len:200,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPASSWORD",gxz:"ZV9Password",gxold:"OV9Password",gxvar:"AV9Password",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9Password=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9Password=n)},v2c:function(){gx.fn.setControlValue("vPASSWORD",gx.O.AV9Password,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9Password=this.val())},val:function(){return gx.fn.getControlValue("vPASSWORD")},nac:gx.falseFn};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"ACEPTAR",grid:0,evt:"e120s2_client"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"CANCELAR",grid:0,evt:"e160s1_client"};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};this.AV5UsuarioNombre="";this.ZV5UsuarioNombre="";this.OV5UsuarioNombre="";this.AV6UsuarioApellido="";this.ZV6UsuarioApellido="";this.OV6UsuarioApellido="";this.AV7UsuarioEmail="";this.ZV7UsuarioEmail="";this.OV7UsuarioEmail="";this.AV8UsuarioPassword="";this.ZV8UsuarioPassword="";this.OV8UsuarioPassword="";this.AV9Password="";this.ZV9Password="";this.OV9Password="";this.AV5UsuarioNombre="";this.AV6UsuarioApellido="";this.AV7UsuarioEmail="";this.AV8UsuarioPassword="";this.AV9Password="";this.A9TableroId=0;this.AV13sdt_sa={title:"",type:"",html:"",iconColor:"",iconHtml:"",footer:"",backdrop:"",toast:"",grow:"",width:"",padding:"",background:"",position:"",timer:0,showCloseButton:!1,allowEnterKey:!1,allowOutsideClick:!1,showConfirmButton:!1,confirmButtonText:"",confirmButtonColor:"",confirmButtonUrl:"",focusConfirm:!1,showCancelButton:!1,cancelButtonText:"",cancelButtonUrl:"",showDenyButton:!1,denyButtonText:"",denyBurronUrl:"",imageUrl:"",imageWidth:0,imageHeight:0};this.Events={e120s2_client:["'REGISTRO'",!0],e140s2_client:["ENTER",!0],e150s2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.START=[[{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("TEXTBLOCK1","Caption")',ctrl:"TEXTBLOCK1",prop:"Caption"}]];this.EvtParms["'REGISTRO'"]=[[{av:"AV5UsuarioNombre",fld:"vUSUARIONOMBRE",pic:""},{av:"AV6UsuarioApellido",fld:"vUSUARIOAPELLIDO",pic:""},{av:"AV7UsuarioEmail",fld:"vUSUARIOEMAIL",pic:""},{av:"AV8UsuarioPassword",fld:"vUSUARIOPASSWORD",pic:""},{av:"AV9Password",fld:"vPASSWORD",pic:""},{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0},{av:"AV13sdt_sa",fld:"vSDT_SA",pic:""}],[{av:"AV13sdt_sa",fld:"vSDT_SA",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("A9TableroId","TABLEROID",0,"int",4,0);this.setVCMap("AV13sdt_sa","vSDT_SA",0,"SDT_SweetAlert",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.aceptarinvitacion)})