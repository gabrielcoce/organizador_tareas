gx.evt.autoSkip=!1;gx.define("webpanel1",!1,function(){this.ServerClass="webpanel1";this.PackageName="GeneXus.Programs";this.ServerFullClass="webpanel1.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e11191_client=function(){return this.clearMessages(),this.AV5window.Url=gx.http.formatLink("webpanel2.aspx",[]),this.AV5window.ReturnParms=[],this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e13192_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14192_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6];this.GXLastCtrlId=6;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"PRUEBA",grid:0,evt:"e11191_client"};this.AV5window={};this.Events={e13192_client:["ENTER",!0],e14192_client:["CANCEL",!0],e11191_client:["'PRUEBA'",!1]};this.EvtParms.REFRESH=[[],[]];this.EvtParms["'PRUEBA'"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.Initialize()});gx.wi(function(){gx.createParentObj(this.webpanel1)})