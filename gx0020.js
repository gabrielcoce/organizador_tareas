gx.evt.autoSkip=!1;gx.define("gx0020",!1,function(){var n,t;this.ServerClass="gx0020";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0020.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV12pUsuarioId=gx.fn.getIntegerValue("vPUSUARIOID",".")};this.Validv_Cusuarioemail=function(){return this.validCliEvt("Validv_Cusuarioemail",0,function(){try{var n=gx.util.balloon.getNew("vCUSUARIOEMAIL");if(this.AnyError=0,!(gx.util.regExp.isMatch(this.AV9cUsuarioEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$")||gx.text.compare("",this.AV9cUsuarioEmail)===0))try{n.setError("El valor de Usuario Email no coincide con el patrón especificado");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e17071_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e11071_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("USUARIOIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("USUARIOIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCUSUARIOID","Visible",!0)):(gx.fn.setCtrlProperty("USUARIOIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCUSUARIOID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("USUARIOIDFILTERCONTAINER","Class")',ctrl:"USUARIOIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCUSUARIOID","Visible")',ctrl:"vCUSUARIOID",prop:"Visible"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12071_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("USUARIONOMBREFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("USUARIONOMBREFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCUSUARIONOMBRE","Visible",!0)):(gx.fn.setCtrlProperty("USUARIONOMBREFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCUSUARIONOMBRE","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("USUARIONOMBREFILTERCONTAINER","Class")',ctrl:"USUARIONOMBREFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCUSUARIONOMBRE","Visible")',ctrl:"vCUSUARIONOMBRE",prop:"Visible"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e13071_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("USUARIOAPELLIDOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("USUARIOAPELLIDOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCUSUARIOAPELLIDO","Visible",!0)):(gx.fn.setCtrlProperty("USUARIOAPELLIDOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCUSUARIOAPELLIDO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("USUARIOAPELLIDOFILTERCONTAINER","Class")',ctrl:"USUARIOAPELLIDOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCUSUARIOAPELLIDO","Visible")',ctrl:"vCUSUARIOAPELLIDO",prop:"Visible"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e14071_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("USUARIOEMAILFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("USUARIOEMAILFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCUSUARIOEMAIL","Visible",!0)):(gx.fn.setCtrlProperty("USUARIOEMAILFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCUSUARIOEMAIL","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("USUARIOEMAILFILTERCONTAINER","Class")',ctrl:"USUARIOEMAILFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCUSUARIOEMAIL","Visible")',ctrl:"vCUSUARIOEMAIL",prop:"Visible"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e15071_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("USUARIOESTADOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("USUARIOESTADOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCUSUARIOESTADO","Visible",!0)):(gx.fn.setCtrlProperty("USUARIOESTADOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCUSUARIOESTADO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("USUARIOESTADOFILTERCONTAINER","Class")',ctrl:"USUARIOESTADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCUSUARIOESTADO","Visible")',ctrl:"vCUSUARIOESTADO",prop:"Visible"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e16071_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ROLIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ROLIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCROLID","Visible",!0)):(gx.fn.setCtrlProperty("ROLIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCROLID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ROLIDFILTERCONTAINER","Class")',ctrl:"ROLIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCROLID","Visible")',ctrl:"vCROLID",prop:"Visible"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e20072_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e21071_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,75,76,77,78,79,80,81,82,83];this.GXLastCtrlId=83;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",74,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0020",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",75,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(3,76,"USUARIOID","Id","","UsuarioId","int",0,"px",4,4,"right",null,[],3,"UsuarioId",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(4,77,"USUARIONOMBRE","Nombre","","UsuarioNombre","char",0,"px",20,20,"left",null,[],4,"UsuarioNombre",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(5,78,"USUARIOAPELLIDO","Apellido","","UsuarioApellido","char",0,"px",20,20,"left",null,[],5,"UsuarioApellido",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addCheckBox(8,79,"USUARIOESTADO","Estado","","UsuarioEstado","boolean","true","false",null,!0,!1,0,"px","WWColumn OptionalColumn");t.addSingleLineEdit(1,80,"ROLID","Rol Id","","RolId","int",0,"px",4,4,"right",null,[],1,"RolId",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"USUARIOIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLUSUARIOIDFILTER",format:1,grid:0,evt:"e11071_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCUSUARIOID",gxz:"ZV6cUsuarioId",gxold:"OV6cUsuarioId",gxvar:"AV6cUsuarioId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cUsuarioId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cUsuarioId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCUSUARIOID",gx.O.AV6cUsuarioId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cUsuarioId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCUSUARIOID",".")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"USUARIONOMBREFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLUSUARIONOMBREFILTER",format:1,grid:0,evt:"e12071_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCUSUARIONOMBRE",gxz:"ZV7cUsuarioNombre",gxold:"OV7cUsuarioNombre",gxvar:"AV7cUsuarioNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cUsuarioNombre=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cUsuarioNombre=n)},v2c:function(){gx.fn.setControlValue("vCUSUARIONOMBRE",gx.O.AV7cUsuarioNombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cUsuarioNombre=this.val())},val:function(){return gx.fn.getControlValue("vCUSUARIONOMBRE")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"USUARIOAPELLIDOFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLUSUARIOAPELLIDOFILTER",format:1,grid:0,evt:"e13071_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCUSUARIOAPELLIDO",gxz:"ZV8cUsuarioApellido",gxold:"OV8cUsuarioApellido",gxvar:"AV8cUsuarioApellido",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cUsuarioApellido=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8cUsuarioApellido=n)},v2c:function(){gx.fn.setControlValue("vCUSUARIOAPELLIDO",gx.O.AV8cUsuarioApellido,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cUsuarioApellido=this.val())},val:function(){return gx.fn.getControlValue("vCUSUARIOAPELLIDO")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"USUARIOEMAILFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLUSUARIOEMAILFILTER",format:1,grid:0,evt:"e14071_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Cusuarioemail,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCUSUARIOEMAIL",gxz:"ZV9cUsuarioEmail",gxold:"OV9cUsuarioEmail",gxvar:"AV9cUsuarioEmail",ucs:[],op:[46],ip:[46],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cUsuarioEmail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9cUsuarioEmail=n)},v2c:function(){gx.fn.setControlValue("vCUSUARIOEMAIL",gx.O.AV9cUsuarioEmail,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cUsuarioEmail=this.val())},val:function(){return gx.fn.getControlValue("vCUSUARIOEMAIL")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"USUARIOESTADOFILTERCONTAINER",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"LBLUSUARIOESTADOFILTER",format:1,grid:0,evt:"e15071_client",ctrltype:"textblock"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCUSUARIOESTADO",gxz:"ZV10cUsuarioEstado",gxold:"OV10cUsuarioEstado",gxvar:"AV10cUsuarioEstado",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV10cUsuarioEstado=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10cUsuarioEstado=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vCUSUARIOESTADO",gx.O.AV10cUsuarioEstado,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10cUsuarioEstado=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vCUSUARIOESTADO")},nac:gx.falseFn,values:["true","false"]};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"ROLIDFILTERCONTAINER",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"LBLROLIDFILTER",format:1,grid:0,evt:"e16071_client",ctrltype:"textblock"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCROLID",gxz:"ZV11cRolId",gxold:"OV11cRolId",gxvar:"AV11cRolId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11cRolId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11cRolId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCROLID",gx.O.AV11cRolId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11cRolId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCROLID",".")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"GRIDTABLE",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"BTNTOGGLE",grid:0,evt:"e17071_client"};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[75]={id:75,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(74),gx.O.AV5LinkSelection,gx.O.AV16Linkselection_GXI)},c2v:function(n){gx.O.AV16Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(74))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(74))},gxvar_GXI:"AV16Linkselection_GXI",nac:gx.falseFn};n[76]={id:76,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOID",gxz:"Z3UsuarioId",gxold:"O3UsuarioId",gxvar:"A3UsuarioId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A3UsuarioId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z3UsuarioId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("USUARIOID",n||gx.fn.currentGridRowImpl(74),gx.O.A3UsuarioId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A3UsuarioId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("USUARIOID",n||gx.fn.currentGridRowImpl(74),".")},nac:gx.falseFn};n[77]={id:77,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIONOMBRE",gxz:"Z4UsuarioNombre",gxold:"O4UsuarioNombre",gxvar:"A4UsuarioNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A4UsuarioNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z4UsuarioNombre=n)},v2c:function(n){gx.fn.setGridControlValue("USUARIONOMBRE",n||gx.fn.currentGridRowImpl(74),gx.O.A4UsuarioNombre,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4UsuarioNombre=this.val(n))},val:function(n){return gx.fn.getGridControlValue("USUARIONOMBRE",n||gx.fn.currentGridRowImpl(74))},nac:gx.falseFn};n[78]={id:78,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOAPELLIDO",gxz:"Z5UsuarioApellido",gxold:"O5UsuarioApellido",gxvar:"A5UsuarioApellido",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A5UsuarioApellido=n)},v2z:function(n){n!==undefined&&(gx.O.Z5UsuarioApellido=n)},v2c:function(n){gx.fn.setGridControlValue("USUARIOAPELLIDO",n||gx.fn.currentGridRowImpl(74),gx.O.A5UsuarioApellido,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5UsuarioApellido=this.val(n))},val:function(n){return gx.fn.getGridControlValue("USUARIOAPELLIDO",n||gx.fn.currentGridRowImpl(74))},nac:gx.falseFn};n[79]={id:79,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOESTADO",gxz:"Z8UsuarioEstado",gxold:"O8UsuarioEstado",gxvar:"A8UsuarioEstado",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A8UsuarioEstado=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z8UsuarioEstado=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("USUARIOESTADO",n||gx.fn.currentGridRowImpl(74),gx.O.A8UsuarioEstado,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A8UsuarioEstado=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("USUARIOESTADO",n||gx.fn.currentGridRowImpl(74))},nac:gx.falseFn,values:["true","false"]};n[80]={id:80,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ROLID",gxz:"Z1RolId",gxold:"O1RolId",gxvar:"A1RolId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1RolId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1RolId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ROLID",n||gx.fn.currentGridRowImpl(74),gx.O.A1RolId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1RolId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ROLID",n||gx.fn.currentGridRowImpl(74),".")},nac:gx.falseFn};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"BTN_CANCEL",grid:0,evt:"e21071_client"};this.AV6cUsuarioId=0;this.ZV6cUsuarioId=0;this.OV6cUsuarioId=0;this.AV7cUsuarioNombre="";this.ZV7cUsuarioNombre="";this.OV7cUsuarioNombre="";this.AV8cUsuarioApellido="";this.ZV8cUsuarioApellido="";this.OV8cUsuarioApellido="";this.AV9cUsuarioEmail="";this.ZV9cUsuarioEmail="";this.OV9cUsuarioEmail="";this.AV10cUsuarioEstado=!1;this.ZV10cUsuarioEstado=!1;this.OV10cUsuarioEstado=!1;this.AV11cRolId=0;this.ZV11cRolId=0;this.OV11cRolId=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z3UsuarioId=0;this.O3UsuarioId=0;this.Z4UsuarioNombre="";this.O4UsuarioNombre="";this.Z5UsuarioApellido="";this.O5UsuarioApellido="";this.Z8UsuarioEstado=!1;this.O8UsuarioEstado=!1;this.Z1RolId=0;this.O1RolId=0;this.AV6cUsuarioId=0;this.AV7cUsuarioNombre="";this.AV8cUsuarioApellido="";this.AV9cUsuarioEmail="";this.AV10cUsuarioEstado=!1;this.AV11cRolId=0;this.AV12pUsuarioId=0;this.A6UsuarioEmail="";this.AV5LinkSelection="";this.A3UsuarioId=0;this.A4UsuarioNombre="";this.A5UsuarioApellido="";this.A8UsuarioEstado=!1;this.A1RolId=0;this.Events={e20072_client:["ENTER",!0],e21071_client:["CANCEL",!0],e17071_client:["'TOGGLE'",!1],e11071_client:["LBLUSUARIOIDFILTER.CLICK",!1],e12071_client:["LBLUSUARIONOMBREFILTER.CLICK",!1],e13071_client:["LBLUSUARIOAPELLIDOFILTER.CLICK",!1],e14071_client:["LBLUSUARIOEMAILFILTER.CLICK",!1],e15071_client:["LBLUSUARIOESTADOFILTER.CLICK",!1],e16071_client:["LBLROLIDFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cUsuarioId",fld:"vCUSUARIOID",pic:"ZZZ9"},{av:"AV7cUsuarioNombre",fld:"vCUSUARIONOMBRE",pic:""},{av:"AV8cUsuarioApellido",fld:"vCUSUARIOAPELLIDO",pic:""},{av:"AV9cUsuarioEmail",fld:"vCUSUARIOEMAIL",pic:""},{av:"AV11cRolId",fld:"vCROLID",pic:"ZZZ9"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms.START=[[{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{ctrl:"FORM",prop:"Caption"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms["LBLUSUARIOIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("USUARIOIDFILTERCONTAINER","Class")',ctrl:"USUARIOIDFILTERCONTAINER",prop:"Class"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:'gx.fn.getCtrlProperty("USUARIOIDFILTERCONTAINER","Class")',ctrl:"USUARIOIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCUSUARIOID","Visible")',ctrl:"vCUSUARIOID",prop:"Visible"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms["LBLUSUARIONOMBREFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("USUARIONOMBREFILTERCONTAINER","Class")',ctrl:"USUARIONOMBREFILTERCONTAINER",prop:"Class"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:'gx.fn.getCtrlProperty("USUARIONOMBREFILTERCONTAINER","Class")',ctrl:"USUARIONOMBREFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCUSUARIONOMBRE","Visible")',ctrl:"vCUSUARIONOMBRE",prop:"Visible"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms["LBLUSUARIOAPELLIDOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("USUARIOAPELLIDOFILTERCONTAINER","Class")',ctrl:"USUARIOAPELLIDOFILTERCONTAINER",prop:"Class"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:'gx.fn.getCtrlProperty("USUARIOAPELLIDOFILTERCONTAINER","Class")',ctrl:"USUARIOAPELLIDOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCUSUARIOAPELLIDO","Visible")',ctrl:"vCUSUARIOAPELLIDO",prop:"Visible"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms["LBLUSUARIOEMAILFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("USUARIOEMAILFILTERCONTAINER","Class")',ctrl:"USUARIOEMAILFILTERCONTAINER",prop:"Class"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:'gx.fn.getCtrlProperty("USUARIOEMAILFILTERCONTAINER","Class")',ctrl:"USUARIOEMAILFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCUSUARIOEMAIL","Visible")',ctrl:"vCUSUARIOEMAIL",prop:"Visible"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms["LBLUSUARIOESTADOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("USUARIOESTADOFILTERCONTAINER","Class")',ctrl:"USUARIOESTADOFILTERCONTAINER",prop:"Class"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:'gx.fn.getCtrlProperty("USUARIOESTADOFILTERCONTAINER","Class")',ctrl:"USUARIOESTADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCUSUARIOESTADO","Visible")',ctrl:"vCUSUARIOESTADO",prop:"Visible"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms["LBLROLIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ROLIDFILTERCONTAINER","Class")',ctrl:"ROLIDFILTERCONTAINER",prop:"Class"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:'gx.fn.getCtrlProperty("ROLIDFILTERCONTAINER","Class")',ctrl:"ROLIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCROLID","Visible")',ctrl:"vCROLID",prop:"Visible"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms.LOAD=[[{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:"AV5LinkSelection",fld:"vLINKSELECTION",pic:""},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms.ENTER=[[{av:"A3UsuarioId",fld:"USUARIOID",pic:"ZZZ9",hsh:!0},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:"AV12pUsuarioId",fld:"vPUSUARIOID",pic:"ZZZ9"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cUsuarioId",fld:"vCUSUARIOID",pic:"ZZZ9"},{av:"AV7cUsuarioNombre",fld:"vCUSUARIONOMBRE",pic:""},{av:"AV8cUsuarioApellido",fld:"vCUSUARIOAPELLIDO",pic:""},{av:"AV9cUsuarioEmail",fld:"vCUSUARIOEMAIL",pic:""},{av:"AV11cRolId",fld:"vCROLID",pic:"ZZZ9"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cUsuarioId",fld:"vCUSUARIOID",pic:"ZZZ9"},{av:"AV7cUsuarioNombre",fld:"vCUSUARIONOMBRE",pic:""},{av:"AV8cUsuarioApellido",fld:"vCUSUARIOAPELLIDO",pic:""},{av:"AV9cUsuarioEmail",fld:"vCUSUARIOEMAIL",pic:""},{av:"AV11cRolId",fld:"vCROLID",pic:"ZZZ9"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cUsuarioId",fld:"vCUSUARIOID",pic:"ZZZ9"},{av:"AV7cUsuarioNombre",fld:"vCUSUARIONOMBRE",pic:""},{av:"AV8cUsuarioApellido",fld:"vCUSUARIOAPELLIDO",pic:""},{av:"AV9cUsuarioEmail",fld:"vCUSUARIOEMAIL",pic:""},{av:"AV11cRolId",fld:"vCROLID",pic:"ZZZ9"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cUsuarioId",fld:"vCUSUARIOID",pic:"ZZZ9"},{av:"AV7cUsuarioNombre",fld:"vCUSUARIONOMBRE",pic:""},{av:"AV8cUsuarioApellido",fld:"vCUSUARIOAPELLIDO",pic:""},{av:"AV9cUsuarioEmail",fld:"vCUSUARIOEMAIL",pic:""},{av:"AV11cRolId",fld:"vCROLID",pic:"ZZZ9"},{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.EvtParms.VALIDV_CUSUARIOEMAIL=[[{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}],[{av:"AV10cUsuarioEstado",fld:"vCUSUARIOESTADO",pic:""}]];this.setVCMap("AV12pUsuarioId","vPUSUARIOID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[56]);t.addRefreshingVar(this.GXValidFnc[66]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[56]);t.addRefreshingParm(this.GXValidFnc[66]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0020)})