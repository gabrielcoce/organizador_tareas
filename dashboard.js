gx.evt.autoSkip=!1;gx.define("dashboard",!1,function(){this.ServerClass="dashboard";this.PackageName="GeneXus.Programs";this.ServerFullClass="dashboard.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e130k2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140k2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11];this.GXLastCtrlId=11;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"IMAGE1",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TEXTBLOCK1",format:1,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};this.A17PropietarioId=0;this.Events={e130k2_client:["ENTER",!0],e140k2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms.START=[[{av:"A17PropietarioId",fld:"PROPIETARIOID",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("TEXTBLOCK1","Caption")',ctrl:"TEXTBLOCK1",prop:"Caption"},{ctrl:"COMPONENT1"}]];this.EvtParms.ENTER=[[],[]];this.Initialize();this.setComponent({id:"COMPONENT1",GXClass:null,Prefix:"W0012",lvl:1})});gx.wi(function(){gx.createParentObj(this.dashboard)})