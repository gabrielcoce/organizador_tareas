gx.evt.autoSkip=!1;gx.define("masterpage",!1,function(){this.ServerClass="masterpage";this.PackageName="GeneXus.Programs";this.ServerFullClass="masterpage.aspx";this.setObjectType("web");this.IsMasterPage=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e130g2_client=function(){return this.executeServerEvent("ENTER_MPAGE",!0,null,!1,!1)};this.e140g2_client=function(){return this.executeServerEvent("CANCEL_MPAGE",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,4,5];this.GXLastCtrlId=5;n[2]={id:2,fld:"SCRIPT1",format:1,grid:0,ctrltype:"textblock"};n[4]={id:4,fld:"SCRIPT2",format:1,grid:0,ctrltype:"textblock"};n[5]={id:5,fld:"JS",format:1,grid:0,ctrltype:"textblock"};this.A18ParticipanteTableroId=0;this.A17PropietarioId=0;this.Events={e130g2_client:["ENTER_MPAGE",!0],e140g2_client:["CANCEL_MPAGE",!0]};this.EvtParms.REFRESH_MPAGE=[[],[]];this.EvtParms.ENTER_MPAGE=[[],[]];this.Initialize()});gx.wi(function(){gx.createMasterPage(masterpage)})