gx.evt.autoSkip=!1;gx.define("gx0090",!1,function(){var n,t;this.ServerClass="gx0090";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0090.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV12pTableroId=gx.fn.getIntegerValue("vPTABLEROID",".");this.AV13pTareaId=gx.fn.getIntegerValue("vPTAREAID",".");this.AV14pActividadId=gx.fn.getIntegerValue("vPACTIVIDADID",".")};this.e180e1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e110e1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("TABLEROIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("TABLEROIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCTABLEROID","Visible",!0)):(gx.fn.setCtrlProperty("TABLEROIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCTABLEROID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TABLEROIDFILTERCONTAINER","Class")',ctrl:"TABLEROIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTABLEROID","Visible")',ctrl:"vCTABLEROID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120e1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("TAREAIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("TAREAIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCTAREAID","Visible",!0)):(gx.fn.setCtrlProperty("TAREAIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCTAREAID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TAREAIDFILTERCONTAINER","Class")',ctrl:"TAREAIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTAREAID","Visible")',ctrl:"vCTAREAID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e130e1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ACTIVIDADIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ACTIVIDADIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCACTIVIDADID","Visible",!0)):(gx.fn.setCtrlProperty("ACTIVIDADIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCACTIVIDADID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ACTIVIDADIDFILTERCONTAINER","Class")',ctrl:"ACTIVIDADIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCACTIVIDADID","Visible")',ctrl:"vCACTIVIDADID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e140e1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ACTIVIDADNOMBREFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ACTIVIDADNOMBREFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCACTIVIDADNOMBRE","Visible",!0)):(gx.fn.setCtrlProperty("ACTIVIDADNOMBREFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCACTIVIDADNOMBRE","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ACTIVIDADNOMBREFILTERCONTAINER","Class")',ctrl:"ACTIVIDADNOMBREFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCACTIVIDADNOMBRE","Visible")',ctrl:"vCACTIVIDADNOMBRE",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e150e1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ACTIVIDADAVANCEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ACTIVIDADAVANCEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCACTIVIDADAVANCE","Visible",!0)):(gx.fn.setCtrlProperty("ACTIVIDADAVANCEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCACTIVIDADAVANCE","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ACTIVIDADAVANCEFILTERCONTAINER","Class")',ctrl:"ACTIVIDADAVANCEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCACTIVIDADAVANCE","Visible")',ctrl:"vCACTIVIDADAVANCE",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e160e1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ACTIVIDADESTADOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ACTIVIDADESTADOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCACTIVIDADESTADO","Visible",!0)):(gx.fn.setCtrlProperty("ACTIVIDADESTADOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCACTIVIDADESTADO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ACTIVIDADESTADOFILTERCONTAINER","Class")',ctrl:"ACTIVIDADESTADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCACTIVIDADESTADO","Visible")',ctrl:"vCACTIVIDADESTADO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e170e1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ACTIVIDADPASOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ACTIVIDADPASOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCACTIVIDADPASO","Visible",!0)):(gx.fn.setCtrlProperty("ACTIVIDADPASOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCACTIVIDADPASO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ACTIVIDADPASOFILTERCONTAINER","Class")',ctrl:"ACTIVIDADPASOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCACTIVIDADPASO","Visible")',ctrl:"vCACTIVIDADPASO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e210e2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e220e1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,85,86,87,88,89,90,91,92,93,94,95];this.GXLastCtrlId=95;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",84,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0090",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",85,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(9,86,"TABLEROID","Tablero Id","","TableroId","int",0,"px",4,4,"right",null,[],9,"TableroId",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(12,87,"TAREAID","Tarea Id","","TareaId","int",0,"px",4,4,"right",null,[],12,"TareaId",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(30,88,"ACTIVIDADID","Id","","ActividadId","int",0,"px",4,4,"right",null,[],30,"ActividadId",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(31,89,"ACTIVIDADNOMBRE","Nombre","","ActividadNombre","char",0,"px",20,20,"left",null,[],31,"ActividadNombre",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(32,90,"ACTIVIDADAVANCE","Avance","","ActividadAvance","int",0,"px",3,3,"right",null,[],32,"ActividadAvance",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addCheckBox(33,91,"ACTIVIDADESTADO","Estado","","ActividadEstado","boolean","true","false",null,!0,!1,0,"px","WWColumn OptionalColumn");t.addSingleLineEdit(49,92,"ACTIVIDADPASO","Paso","","ActividadPaso","int",0,"px",4,4,"right",null,[],49,"ActividadPaso",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLEROIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLTABLEROIDFILTER",format:1,grid:0,evt:"e110e1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTABLEROID",fmt:0,gxz:"ZV6cTableroId",gxold:"OV6cTableroId",gxvar:"AV6cTableroId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cTableroId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cTableroId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCTABLEROID",gx.O.AV6cTableroId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cTableroId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCTABLEROID",".")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"TAREAIDFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLTAREAIDFILTER",format:1,grid:0,evt:"e120e1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTAREAID",fmt:0,gxz:"ZV7cTareaId",gxold:"OV7cTareaId",gxvar:"AV7cTareaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cTareaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7cTareaId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCTAREAID",gx.O.AV7cTareaId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cTareaId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCTAREAID",".")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"ACTIVIDADIDFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLACTIVIDADIDFILTER",format:1,grid:0,evt:"e130e1_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCACTIVIDADID",fmt:0,gxz:"ZV8cActividadId",gxold:"OV8cActividadId",gxvar:"AV8cActividadId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cActividadId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cActividadId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCACTIVIDADID",gx.O.AV8cActividadId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cActividadId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCACTIVIDADID",".")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"ACTIVIDADNOMBREFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLACTIVIDADNOMBREFILTER",format:1,grid:0,evt:"e140e1_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCACTIVIDADNOMBRE",fmt:0,gxz:"ZV9cActividadNombre",gxold:"OV9cActividadNombre",gxvar:"AV9cActividadNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cActividadNombre=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9cActividadNombre=n)},v2c:function(){gx.fn.setControlValue("vCACTIVIDADNOMBRE",gx.O.AV9cActividadNombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cActividadNombre=this.val())},val:function(){return gx.fn.getControlValue("vCACTIVIDADNOMBRE")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"ACTIVIDADAVANCEFILTERCONTAINER",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"LBLACTIVIDADAVANCEFILTER",format:1,grid:0,evt:"e150e1_client",ctrltype:"textblock"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"int",len:3,dec:0,sign:!1,pic:"ZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCACTIVIDADAVANCE",fmt:0,gxz:"ZV10cActividadAvance",gxold:"OV10cActividadAvance",gxvar:"AV10cActividadAvance",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10cActividadAvance=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10cActividadAvance=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCACTIVIDADAVANCE",gx.O.AV10cActividadAvance,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10cActividadAvance=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCACTIVIDADAVANCE",".")},nac:gx.falseFn};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"ACTIVIDADESTADOFILTERCONTAINER",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"LBLACTIVIDADESTADOFILTER",format:1,grid:0,evt:"e160e1_client",ctrltype:"textblock"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"boolean",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCACTIVIDADESTADO",fmt:0,gxz:"ZV11cActividadEstado",gxold:"OV11cActividadEstado",gxvar:"AV11cActividadEstado",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV11cActividadEstado=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11cActividadEstado=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vCACTIVIDADESTADO",gx.O.AV11cActividadEstado,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11cActividadEstado=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vCACTIVIDADESTADO")},nac:gx.falseFn,values:["true","false"]};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"ACTIVIDADPASOFILTERCONTAINER",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"LBLACTIVIDADPASOFILTER",format:1,grid:0,evt:"e170e1_client",ctrltype:"textblock"};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCACTIVIDADPASO",fmt:0,gxz:"ZV16cActividadPaso",gxold:"OV16cActividadPaso",gxvar:"AV16cActividadPaso",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16cActividadPaso=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV16cActividadPaso=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCACTIVIDADPASO",gx.O.AV16cActividadPaso,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV16cActividadPaso=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCACTIVIDADPASO",".")},nac:gx.falseFn};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"GRIDTABLE",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"BTNTOGGLE",grid:0,evt:"e180e1_client"};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[85]={id:85,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84),gx.O.AV5LinkSelection,gx.O.AV19Linkselection_GXI)},c2v:function(n){gx.O.AV19Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(84))},gxvar_GXI:"AV19Linkselection_GXI",nac:gx.falseFn};n[86]={id:86,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TABLEROID",fmt:0,gxz:"Z9TableroId",gxold:"O9TableroId",gxvar:"A9TableroId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A9TableroId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z9TableroId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("TABLEROID",n||gx.fn.currentGridRowImpl(84),gx.O.A9TableroId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A9TableroId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("TABLEROID",n||gx.fn.currentGridRowImpl(84),".")},nac:gx.falseFn};n[87]={id:87,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TAREAID",fmt:0,gxz:"Z12TareaId",gxold:"O12TareaId",gxvar:"A12TareaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A12TareaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12TareaId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("TAREAID",n||gx.fn.currentGridRowImpl(84),gx.O.A12TareaId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A12TareaId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("TAREAID",n||gx.fn.currentGridRowImpl(84),".")},nac:gx.falseFn};n[88]={id:88,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTIVIDADID",fmt:0,gxz:"Z30ActividadId",gxold:"O30ActividadId",gxvar:"A30ActividadId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A30ActividadId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z30ActividadId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ACTIVIDADID",n||gx.fn.currentGridRowImpl(84),gx.O.A30ActividadId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A30ActividadId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ACTIVIDADID",n||gx.fn.currentGridRowImpl(84),".")},nac:gx.falseFn};n[89]={id:89,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTIVIDADNOMBRE",fmt:0,gxz:"Z31ActividadNombre",gxold:"O31ActividadNombre",gxvar:"A31ActividadNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A31ActividadNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z31ActividadNombre=n)},v2c:function(n){gx.fn.setGridControlValue("ACTIVIDADNOMBRE",n||gx.fn.currentGridRowImpl(84),gx.O.A31ActividadNombre,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A31ActividadNombre=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ACTIVIDADNOMBRE",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[90]={id:90,lvl:2,type:"int",len:3,dec:0,sign:!1,pic:"ZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTIVIDADAVANCE",fmt:0,gxz:"Z32ActividadAvance",gxold:"O32ActividadAvance",gxvar:"A32ActividadAvance",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A32ActividadAvance=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z32ActividadAvance=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ACTIVIDADAVANCE",n||gx.fn.currentGridRowImpl(84),gx.O.A32ActividadAvance,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A32ActividadAvance=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ACTIVIDADAVANCE",n||gx.fn.currentGridRowImpl(84),".")},nac:gx.falseFn};n[91]={id:91,lvl:2,type:"boolean",len:1,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTIVIDADESTADO",fmt:0,gxz:"Z33ActividadEstado",gxold:"O33ActividadEstado",gxvar:"A33ActividadEstado",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A33ActividadEstado=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z33ActividadEstado=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("ACTIVIDADESTADO",n||gx.fn.currentGridRowImpl(84),gx.O.A33ActividadEstado,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A33ActividadEstado=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("ACTIVIDADESTADO",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn,values:["true","false"]};n[92]={id:92,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTIVIDADPASO",fmt:0,gxz:"Z49ActividadPaso",gxold:"O49ActividadPaso",gxvar:"A49ActividadPaso",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A49ActividadPaso=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z49ActividadPaso=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ACTIVIDADPASO",n||gx.fn.currentGridRowImpl(84),gx.O.A49ActividadPaso,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A49ActividadPaso=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ACTIVIDADPASO",n||gx.fn.currentGridRowImpl(84),".")},nac:gx.falseFn};n[93]={id:93,fld:"",grid:0};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"BTN_CANCEL",grid:0,evt:"e220e1_client"};this.AV6cTableroId=0;this.ZV6cTableroId=0;this.OV6cTableroId=0;this.AV7cTareaId=0;this.ZV7cTareaId=0;this.OV7cTareaId=0;this.AV8cActividadId=0;this.ZV8cActividadId=0;this.OV8cActividadId=0;this.AV9cActividadNombre="";this.ZV9cActividadNombre="";this.OV9cActividadNombre="";this.AV10cActividadAvance=0;this.ZV10cActividadAvance=0;this.OV10cActividadAvance=0;this.AV11cActividadEstado=!1;this.ZV11cActividadEstado=!1;this.OV11cActividadEstado=!1;this.AV16cActividadPaso=0;this.ZV16cActividadPaso=0;this.OV16cActividadPaso=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z9TableroId=0;this.O9TableroId=0;this.Z12TareaId=0;this.O12TareaId=0;this.Z30ActividadId=0;this.O30ActividadId=0;this.Z31ActividadNombre="";this.O31ActividadNombre="";this.Z32ActividadAvance=0;this.O32ActividadAvance=0;this.Z33ActividadEstado=!1;this.O33ActividadEstado=!1;this.Z49ActividadPaso=0;this.O49ActividadPaso=0;this.AV6cTableroId=0;this.AV7cTareaId=0;this.AV8cActividadId=0;this.AV9cActividadNombre="";this.AV10cActividadAvance=0;this.AV11cActividadEstado=!1;this.AV16cActividadPaso=0;this.AV12pTableroId=0;this.AV13pTareaId=0;this.AV14pActividadId=0;this.AV5LinkSelection="";this.A9TableroId=0;this.A12TareaId=0;this.A30ActividadId=0;this.A31ActividadNombre="";this.A32ActividadAvance=0;this.A33ActividadEstado=!1;this.A49ActividadPaso=0;this.Events={e210e2_client:["ENTER",!0],e220e1_client:["CANCEL",!0],e180e1_client:["'TOGGLE'",!1],e110e1_client:["LBLTABLEROIDFILTER.CLICK",!1],e120e1_client:["LBLTAREAIDFILTER.CLICK",!1],e130e1_client:["LBLACTIVIDADIDFILTER.CLICK",!1],e140e1_client:["LBLACTIVIDADNOMBREFILTER.CLICK",!1],e150e1_client:["LBLACTIVIDADAVANCEFILTER.CLICK",!1],e160e1_client:["LBLACTIVIDADESTADOFILTER.CLICK",!1],e170e1_client:["LBLACTIVIDADPASOFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTableroId",fld:"vCTABLEROID",pic:"ZZZ9"},{av:"AV7cTareaId",fld:"vCTAREAID",pic:"ZZZ9"},{av:"AV8cActividadId",fld:"vCACTIVIDADID",pic:"ZZZ9"},{av:"AV9cActividadNombre",fld:"vCACTIVIDADNOMBRE",pic:""},{av:"AV10cActividadAvance",fld:"vCACTIVIDADAVANCE",pic:"ZZ9"},{av:"AV16cActividadPaso",fld:"vCACTIVIDADPASO",pic:"ZZZ9"},{av:"AV11cActividadEstado",fld:"vCACTIVIDADESTADO",pic:""}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLTABLEROIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TABLEROIDFILTERCONTAINER","Class")',ctrl:"TABLEROIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TABLEROIDFILTERCONTAINER","Class")',ctrl:"TABLEROIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTABLEROID","Visible")',ctrl:"vCTABLEROID",prop:"Visible"}]];this.EvtParms["LBLTAREAIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TAREAIDFILTERCONTAINER","Class")',ctrl:"TAREAIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TAREAIDFILTERCONTAINER","Class")',ctrl:"TAREAIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTAREAID","Visible")',ctrl:"vCTAREAID",prop:"Visible"}]];this.EvtParms["LBLACTIVIDADIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ACTIVIDADIDFILTERCONTAINER","Class")',ctrl:"ACTIVIDADIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ACTIVIDADIDFILTERCONTAINER","Class")',ctrl:"ACTIVIDADIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCACTIVIDADID","Visible")',ctrl:"vCACTIVIDADID",prop:"Visible"}]];this.EvtParms["LBLACTIVIDADNOMBREFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ACTIVIDADNOMBREFILTERCONTAINER","Class")',ctrl:"ACTIVIDADNOMBREFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ACTIVIDADNOMBREFILTERCONTAINER","Class")',ctrl:"ACTIVIDADNOMBREFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCACTIVIDADNOMBRE","Visible")',ctrl:"vCACTIVIDADNOMBRE",prop:"Visible"}]];this.EvtParms["LBLACTIVIDADAVANCEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ACTIVIDADAVANCEFILTERCONTAINER","Class")',ctrl:"ACTIVIDADAVANCEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ACTIVIDADAVANCEFILTERCONTAINER","Class")',ctrl:"ACTIVIDADAVANCEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCACTIVIDADAVANCE","Visible")',ctrl:"vCACTIVIDADAVANCE",prop:"Visible"}]];this.EvtParms["LBLACTIVIDADESTADOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ACTIVIDADESTADOFILTERCONTAINER","Class")',ctrl:"ACTIVIDADESTADOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ACTIVIDADESTADOFILTERCONTAINER","Class")',ctrl:"ACTIVIDADESTADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCACTIVIDADESTADO","Visible")',ctrl:"vCACTIVIDADESTADO",prop:"Visible"}]];this.EvtParms["LBLACTIVIDADPASOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ACTIVIDADPASOFILTERCONTAINER","Class")',ctrl:"ACTIVIDADPASOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ACTIVIDADPASOFILTERCONTAINER","Class")',ctrl:"ACTIVIDADPASOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCACTIVIDADPASO","Visible")',ctrl:"vCACTIVIDADPASO",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9",hsh:!0},{av:"A12TareaId",fld:"TAREAID",pic:"ZZZ9",hsh:!0},{av:"A30ActividadId",fld:"ACTIVIDADID",pic:"ZZZ9",hsh:!0}],[{av:"AV12pTableroId",fld:"vPTABLEROID",pic:"ZZZ9"},{av:"AV13pTareaId",fld:"vPTAREAID",pic:"ZZZ9"},{av:"AV14pActividadId",fld:"vPACTIVIDADID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTableroId",fld:"vCTABLEROID",pic:"ZZZ9"},{av:"AV7cTareaId",fld:"vCTAREAID",pic:"ZZZ9"},{av:"AV8cActividadId",fld:"vCACTIVIDADID",pic:"ZZZ9"},{av:"AV9cActividadNombre",fld:"vCACTIVIDADNOMBRE",pic:""},{av:"AV10cActividadAvance",fld:"vCACTIVIDADAVANCE",pic:"ZZ9"},{av:"AV16cActividadPaso",fld:"vCACTIVIDADPASO",pic:"ZZZ9"},{av:"AV11cActividadEstado",fld:"vCACTIVIDADESTADO",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTableroId",fld:"vCTABLEROID",pic:"ZZZ9"},{av:"AV7cTareaId",fld:"vCTAREAID",pic:"ZZZ9"},{av:"AV8cActividadId",fld:"vCACTIVIDADID",pic:"ZZZ9"},{av:"AV9cActividadNombre",fld:"vCACTIVIDADNOMBRE",pic:""},{av:"AV10cActividadAvance",fld:"vCACTIVIDADAVANCE",pic:"ZZ9"},{av:"AV16cActividadPaso",fld:"vCACTIVIDADPASO",pic:"ZZZ9"},{av:"AV11cActividadEstado",fld:"vCACTIVIDADESTADO",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTableroId",fld:"vCTABLEROID",pic:"ZZZ9"},{av:"AV7cTareaId",fld:"vCTAREAID",pic:"ZZZ9"},{av:"AV8cActividadId",fld:"vCACTIVIDADID",pic:"ZZZ9"},{av:"AV9cActividadNombre",fld:"vCACTIVIDADNOMBRE",pic:""},{av:"AV10cActividadAvance",fld:"vCACTIVIDADAVANCE",pic:"ZZ9"},{av:"AV16cActividadPaso",fld:"vCACTIVIDADPASO",pic:"ZZZ9"},{av:"AV11cActividadEstado",fld:"vCACTIVIDADESTADO",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTableroId",fld:"vCTABLEROID",pic:"ZZZ9"},{av:"AV7cTareaId",fld:"vCTAREAID",pic:"ZZZ9"},{av:"AV8cActividadId",fld:"vCACTIVIDADID",pic:"ZZZ9"},{av:"AV9cActividadNombre",fld:"vCACTIVIDADNOMBRE",pic:""},{av:"AV10cActividadAvance",fld:"vCACTIVIDADAVANCE",pic:"ZZ9"},{av:"AV16cActividadPaso",fld:"vCACTIVIDADPASO",pic:"ZZZ9"},{av:"AV11cActividadEstado",fld:"vCACTIVIDADESTADO",pic:""}],[]];this.setVCMap("AV12pTableroId","vPTABLEROID",0,"int",4,0);this.setVCMap("AV13pTareaId","vPTAREAID",0,"int",4,0);this.setVCMap("AV14pActividadId","vPACTIVIDADID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[56]);t.addRefreshingVar(this.GXValidFnc[66]);t.addRefreshingVar(this.GXValidFnc[76]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[56]);t.addRefreshingParm(this.GXValidFnc[66]);t.addRefreshingParm(this.GXValidFnc[76]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0090)})