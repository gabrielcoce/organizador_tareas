gx.evt.autoSkip=!1;gx.define("actividades",!1,function(){this.ServerClass="actividades";this.PackageName="GeneXus.Programs";this.ServerFullClass="actividades.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Tableroid=function(){return this.validCliEvt("Valid_Tableroid",0,function(){try{var n=gx.util.balloon.getNew("TABLEROID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Tareaid=function(){return this.validSrvEvt("Valid_Tareaid",0).then(function(n){return n}.closure(this))};this.Valid_Actividadid=function(){return this.validSrvEvt("Valid_Actividadid",0).then(function(n){return n}.closure(this))};this.e11099_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e12099_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74];this.GXLastCtrlId=74;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e13099_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e14099_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e15099_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e16099_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e17099_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tableroid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TABLEROID",fmt:0,gxz:"Z9TableroId",gxold:"O9TableroId",gxvar:"A9TableroId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9TableroId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z9TableroId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TABLEROID",gx.O.A9TableroId,0)},c2v:function(){this.val()!==undefined&&(gx.O.A9TableroId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TABLEROID",".")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tareaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TAREAID",fmt:0,gxz:"Z12TareaId",gxold:"O12TareaId",gxvar:"A12TareaId",ucs:[],op:[],ip:[39,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A12TareaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12TareaId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TAREAID",gx.O.A12TareaId,0)},c2v:function(){this.val()!==undefined&&(gx.O.A12TareaId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TAREAID",".")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Actividadid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTIVIDADID",fmt:0,gxz:"Z30ActividadId",gxold:"O30ActividadId",gxvar:"A30ActividadId",ucs:[],op:[64,59,54,49],ip:[64,59,54,49,44,39,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A30ActividadId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z30ActividadId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ACTIVIDADID",gx.O.A30ActividadId,0)},c2v:function(){this.val()!==undefined&&(gx.O.A30ActividadId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ACTIVIDADID",".")},nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTIVIDADNOMBRE",fmt:0,gxz:"Z31ActividadNombre",gxold:"O31ActividadNombre",gxvar:"A31ActividadNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A31ActividadNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z31ActividadNombre=n)},v2c:function(){gx.fn.setControlValue("ACTIVIDADNOMBRE",gx.O.A31ActividadNombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.A31ActividadNombre=this.val())},val:function(){return gx.fn.getControlValue("ACTIVIDADNOMBRE")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"int",len:3,dec:0,sign:!1,pic:"ZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTIVIDADAVANCE",fmt:0,gxz:"Z32ActividadAvance",gxold:"O32ActividadAvance",gxvar:"A32ActividadAvance",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A32ActividadAvance=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z32ActividadAvance=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ACTIVIDADAVANCE",gx.O.A32ActividadAvance,0)},c2v:function(){this.val()!==undefined&&(gx.O.A32ActividadAvance=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ACTIVIDADAVANCE",".")},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"boolean",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTIVIDADESTADO",fmt:0,gxz:"Z33ActividadEstado",gxold:"O33ActividadEstado",gxvar:"A33ActividadEstado",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.A33ActividadEstado=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z33ActividadEstado=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("ACTIVIDADESTADO",gx.O.A33ActividadEstado,!0)},c2v:function(){this.val()!==undefined&&(gx.O.A33ActividadEstado=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("ACTIVIDADESTADO")},nac:gx.falseFn,values:["true","false"]};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTIVIDADPASO",fmt:0,gxz:"Z49ActividadPaso",gxold:"O49ActividadPaso",gxvar:"A49ActividadPaso",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A49ActividadPaso=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z49ActividadPaso=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ACTIVIDADPASO",gx.O.A49ActividadPaso,0)},c2v:function(){this.val()!==undefined&&(gx.O.A49ActividadPaso=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ACTIVIDADPASO",".")},nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"BTN_ENTER",grid:0,evt:"e11099_client",std:"ENTER"};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"BTN_CANCEL",grid:0,evt:"e12099_client"};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"BTN_DELETE",grid:0,evt:"e18099_client",std:"DELETE"};n[74]={id:74,fld:"PROMPT_9_12",grid:9};this.A9TableroId=0;this.Z9TableroId=0;this.O9TableroId=0;this.A12TareaId=0;this.Z12TareaId=0;this.O12TareaId=0;this.A30ActividadId=0;this.Z30ActividadId=0;this.O30ActividadId=0;this.A31ActividadNombre="";this.Z31ActividadNombre="";this.O31ActividadNombre="";this.A32ActividadAvance=0;this.Z32ActividadAvance=0;this.O32ActividadAvance=0;this.A33ActividadEstado=!1;this.Z33ActividadEstado=!1;this.O33ActividadEstado=!1;this.A49ActividadPaso=0;this.Z49ActividadPaso=0;this.O49ActividadPaso=0;this.A9TableroId=0;this.A12TareaId=0;this.A30ActividadId=0;this.A31ActividadNombre="";this.A32ActividadAvance=0;this.A33ActividadEstado=!1;this.A49ActividadPaso=0;this.Events={e11099_client:["ENTER",!0],e12099_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"A33ActividadEstado",fld:"ACTIVIDADESTADO",pic:""}],[{av:"A33ActividadEstado",fld:"ACTIVIDADESTADO",pic:""}]];this.EvtParms.REFRESH=[[{av:"A33ActividadEstado",fld:"ACTIVIDADESTADO",pic:""}],[{av:"A33ActividadEstado",fld:"ACTIVIDADESTADO",pic:""}]];this.EvtParms.VALID_TABLEROID=[[{av:"A33ActividadEstado",fld:"ACTIVIDADESTADO",pic:""}],[{av:"A33ActividadEstado",fld:"ACTIVIDADESTADO",pic:""}]];this.EvtParms.VALID_TAREAID=[[{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9"},{av:"A12TareaId",fld:"TAREAID",pic:"ZZZ9"},{av:"A33ActividadEstado",fld:"ACTIVIDADESTADO",pic:""}],[{av:"A33ActividadEstado",fld:"ACTIVIDADESTADO",pic:""}]];this.EvtParms.VALID_ACTIVIDADID=[[{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9"},{av:"A12TareaId",fld:"TAREAID",pic:"ZZZ9"},{av:"A30ActividadId",fld:"ACTIVIDADID",pic:"ZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"A33ActividadEstado",fld:"ACTIVIDADESTADO",pic:""}],[{av:"A31ActividadNombre",fld:"ACTIVIDADNOMBRE",pic:""},{av:"A32ActividadAvance",fld:"ACTIVIDADAVANCE",pic:"ZZ9"},{av:"A49ActividadPaso",fld:"ACTIVIDADPASO",pic:"ZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z9TableroId"},{av:"Z12TareaId"},{av:"Z30ActividadId"},{av:"Z31ActividadNombre"},{av:"Z32ActividadAvance"},{av:"Z33ActividadEstado"},{av:"Z49ActividadPaso"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{av:"A33ActividadEstado",fld:"ACTIVIDADESTADO",pic:""}]];this.setPrompt("PROMPT_9_12",[34,39]);this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.actividades)})