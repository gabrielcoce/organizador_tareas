gx.evt.autoSkip=!1;gx.define("enprocesowc",!0,function(n){var i,t,r;this.ServerClass="enprocesowc";this.PackageName="GeneXus.Programs";this.ServerFullClass="enprocesowc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A9TableroId=gx.fn.getIntegerValue("TABLEROID",".");this.A18ParticipanteTableroId=gx.fn.getIntegerValue("PARTICIPANTETABLEROID",".");this.Gx_date=gx.fn.getDateValue("vTODAY");this.AV16sdt_sa=gx.fn.getControlValue("vSDT_SA");this.AV19estadoComentarios=gx.fn.getControlValue("vESTADOCOMENTARIOS");this.A9TableroId=gx.fn.getIntegerValue("TABLEROID",".");this.A18ParticipanteTableroId=gx.fn.getIntegerValue("PARTICIPANTETABLEROID",".");this.Gx_date=gx.fn.getDateValue("vTODAY")};this.Valid_Tareaid=function(){var n=gx.fn.currentGridRowImpl(15);return this.validCliEvt("Valid_Tareaid",15,function(){try{if(gx.fn.currentGridRowImpl(15)===0)return!0;var n=gx.util.balloon.getNew("TAREAID",gx.fn.currentGridRowImpl(15));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e15102_client=function(){return this.executeServerEvent("'ASIGNAR'",!0,arguments[0],!1,!1)};this.e16102_client=function(){return this.executeServerEvent("'ANADIRASIGNACION'",!0,arguments[0],!1,!1)};this.e17102_client=function(){return this.executeServerEvent("'FINALIZARTAREA'",!0,arguments[0],!1,!1)};this.e18102_client=function(){return this.executeServerEvent("'CANCELAR'",!0,arguments[0],!1,!1)};this.e19102_client=function(){return this.executeServerEvent("'MOSTRARCOMENTARIOS'",!0,arguments[0],!1,!1)};this.e20102_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e21102_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,16,19,20,21,22,25,26,28,29,31,32,33,34,35,38,39,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,59,60,61,62,63,64,68,69,70,71,72,73,74,75,76];this.GXLastCtrlId=76;this.Gridtareas2Container=new gx.grid.grid(this,2,"WbpLvl2",15,"Gridtareas2","Gridtareas2","Gridtareas2Container",this.CmpContext,this.IsMasterPage,"enprocesowc",[],!0,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!1,!1,!1,null,null,!1,"",!0,[1,1,1,1],!1,0,!1,!1);t=this.Gridtareas2Container;t.startTable("Gridtareas2table1",16,"0px");t.startRow("","","","","","");t.startCell("","","","","","","","","","");t.startDiv(19,"Table7","0px","0px");t.startDiv(20,"","0px","0px");t.startDiv(21,"","0px","0px");t.startTable("Table10",22,"0px");t.startRow("","","","","","");t.startCell("","","","","","","","","","");t.startDiv(25,"","0px","0px");t.addLabel();t.addBitmap("&Finalizar","vFINALIZAR",26,30,"px",30,"px","e17102_client","","Finalizar tarea","Image","");t.endDiv();t.endCell();t.startCell("","Center","Middle","","","","","","","");t.startDiv(28,"","0px","0px");t.addLabel();t.addBitmap("&Asignar","vASIGNAR",29,30,"px",30,"px","e15102_client","","Asignar o eliminar responsable","Image","");t.endDiv();t.endCell();t.startCell("","Center","Middle","","","","","","","");t.startDiv(31,"","0px","0px");t.addLabel();t.addBitmap("&Comentarios","vCOMENTARIOS",32,30,"px",30,"px","e19102_client","","Comentarios","Image","");t.endDiv();t.endCell();t.endRow();t.endTable();t.endDiv();t.endDiv();t.startDiv(33,"","0px","0px");t.startDiv(34,"","0px","0px");t.startTable("Asignacion",35,"0px");t.startRow("","","","","","");t.startCell("","","Middle","","","","","","","");t.startDiv(38,"","0px","0px");t.addComboBox("Participantetableroid",39,"vPARTICIPANTETABLEROID","","ParticipanteTableroId","int",null,0,!0,!1,4,"chr","");t.endDiv();t.endCell();t.startCell("","","","","","","","","","");t.startDiv(41,"Table12","0px","0px");t.startDiv(42,"","0px","0px");t.addBitmap("Image7","IMAGE7",43,15,"px",15,"px","e16102_client","","","Image","");t.endDiv();t.startDiv(44,"","0px","0px");t.addBitmap("Image8","IMAGE8",45,15,"px",15,"px","e18102_client","","","Image","");t.endDiv();t.endDiv();t.endCell();t.endRow();t.endTable();t.endDiv();t.endDiv();t.startDiv(46,"","0px","0px");t.startDiv(47,"","0px","0px");t.addTextBlock("NOMBRE2",null,48);t.endDiv();t.endDiv();t.startDiv(49,"","0px","0px");t.startDiv(50,"","0px","0px");t.startDiv(51,"","0px","0px");t.addLabel();t.addSingleLineEdit(12,52,"TAREAID","","","TareaId","int",4,"chr",4,4,"right",null,[],12,"TareaId",!0,0,!1,!1,"Attribute",1,"");t.endDiv();t.endDiv();t.endDiv();t.startDiv(53,"","0px","0px");t.startDiv(54,"","0px","0px");t.startTable("Table1",55,"0px");t.startRow("","","","","","");t.startCell("","","","","","","","","","");t.addWebComponent("Listadocomentarios");t.endCell();t.endRow();t.endTable();t.endDiv();t.endDiv();t.startDiv(59,"","0px","0px");t.startDiv(60,"","0px","0px");t.addTextBlock("ADVISOR2",null,61);t.endDiv();t.endDiv();t.startDiv(62,"","0px","0px");t.startDiv(63,"","0px","0px");t.startTable("Table13",64,"0px");t.startRow("","","","","","");t.startCell("","","","","","","","","","");t.addWebComponent("Component1");t.endCell();t.endRow();t.endTable();t.endDiv();t.endDiv();t.startDiv(68,"","0px","0px");t.startDiv(69,"","0px","0px");t.startDiv(70,"Table14","0px","0px");t.startDiv(71,"","0px","0px");t.addTextBlock("INICIA2",null,72);t.endDiv();t.startDiv(73,"","0px","0px");t.addTextBlock("FINALIZA2",null,74);t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.endCell();t.endRow();t.endTable();this.Gridtareas2Container.emptyText="No hay tareas sin iniciar";this.setGrid(t);this.RAMP_ADDONS_SWEETALERT1Container=gx.uc.getNew(this,77,26,"RAMP_AddOns_SweetAlert",this.CmpContext+"RAMP_ADDONS_SWEETALERT1Container","Ramp_addons_sweetalert1","RAMP_ADDONS_SWEETALERT1");r=this.RAMP_ADDONS_SWEETALERT1Container;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Version","Version","build 1.5.00","str");r.setProp("By","About","by RAMP (irodo@protonmail.com)","str");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"MAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};i[6]={id:6,fld:"T2",grid:0};i[7]={id:7,fld:"",grid:0};i[8]={id:8,fld:"",grid:0};i[9]={id:9,fld:"IMAGE3",grid:0};i[10]={id:10,fld:"",grid:0};i[11]={id:11,fld:"",grid:0};i[12]={id:12,fld:"TITULO2",format:1,grid:0,ctrltype:"textblock"};i[13]={id:13,fld:"",grid:0};i[14]={id:14,fld:"",grid:0};i[16]={id:16,fld:"GRIDTAREAS2TABLE1",grid:15};i[19]={id:19,fld:"TABLE7",grid:15};i[20]={id:20,fld:"",grid:15};i[21]={id:21,fld:"",grid:15};i[22]={id:22,fld:"TABLE10",grid:15};i[25]={id:25,fld:"",grid:15};i[26]={id:26,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.Gridtareas2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFINALIZAR",fmt:0,gxz:"ZV8finalizar",gxold:"OV8finalizar",gxvar:"AV8finalizar",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV8finalizar=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8finalizar=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vFINALIZAR",n||gx.fn.currentGridRowImpl(15),gx.O.AV8finalizar,gx.O.AV28Finalizar_GXI)},c2v:function(n){gx.O.AV28Finalizar_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV8finalizar=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vFINALIZAR",n||gx.fn.currentGridRowImpl(15))},val_GXI:function(n){return gx.fn.getGridControlValue("vFINALIZAR_GXI",n||gx.fn.currentGridRowImpl(15))},gxvar_GXI:"AV28Finalizar_GXI",nac:gx.falseFn,evt:"e17102_client"};i[28]={id:28,fld:"",grid:15};i[29]={id:29,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.Gridtareas2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vASIGNAR",fmt:0,gxz:"ZV5asignar",gxold:"OV5asignar",gxvar:"AV5asignar",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5asignar=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5asignar=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vASIGNAR",n||gx.fn.currentGridRowImpl(15),gx.O.AV5asignar,gx.O.AV27Asignar_GXI)},c2v:function(n){gx.O.AV27Asignar_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5asignar=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vASIGNAR",n||gx.fn.currentGridRowImpl(15))},val_GXI:function(n){return gx.fn.getGridControlValue("vASIGNAR_GXI",n||gx.fn.currentGridRowImpl(15))},gxvar_GXI:"AV27Asignar_GXI",nac:gx.falseFn,evt:"e15102_client"};i[31]={id:31,fld:"",grid:15};i[32]={id:32,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.Gridtareas2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMENTARIOS",fmt:0,gxz:"ZV6comentarios",gxold:"OV6comentarios",gxvar:"AV6comentarios",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV6comentarios=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6comentarios=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vCOMENTARIOS",n||gx.fn.currentGridRowImpl(15),gx.O.AV6comentarios,gx.O.AV25Comentarios_GXI)},c2v:function(n){gx.O.AV25Comentarios_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV6comentarios=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vCOMENTARIOS",n||gx.fn.currentGridRowImpl(15))},val_GXI:function(n){return gx.fn.getGridControlValue("vCOMENTARIOS_GXI",n||gx.fn.currentGridRowImpl(15))},gxvar_GXI:"AV25Comentarios_GXI",nac:gx.falseFn,evt:"e19102_client"};i[33]={id:33,fld:"",grid:15};i[34]={id:34,fld:"",grid:15};i[35]={id:35,fld:"ASIGNACION",grid:15};i[38]={id:38,fld:"",grid:15};i[39]={id:39,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:15,gxgrid:this.Gridtareas2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPARTICIPANTETABLEROID",fmt:0,gxz:"ZV9ParticipanteTableroId",gxold:"OV9ParticipanteTableroId",gxvar:"AV9ParticipanteTableroId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV9ParticipanteTableroId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV9ParticipanteTableroId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("vPARTICIPANTETABLEROID",n||gx.fn.currentGridRowImpl(15),gx.O.AV9ParticipanteTableroId)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV9ParticipanteTableroId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vPARTICIPANTETABLEROID",n||gx.fn.currentGridRowImpl(15),".")},nac:gx.falseFn};i[41]={id:41,fld:"TABLE12",grid:15};i[42]={id:42,fld:"",grid:15};i[43]={id:43,fld:"IMAGE7",grid:15,evt:"e16102_client"};i[44]={id:44,fld:"",grid:15};i[45]={id:45,fld:"IMAGE8",grid:15,evt:"e18102_client"};i[46]={id:46,fld:"",grid:15};i[47]={id:47,fld:"",grid:15};i[48]={id:48,fld:"NOMBRE2",format:1,grid:15,ctrltype:"textblock"};i[49]={id:49,fld:"",grid:15};i[50]={id:50,fld:"",grid:15};i[51]={id:51,fld:"",grid:15};i[52]={id:52,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:15,gxgrid:this.Gridtareas2Container,fnc:this.Valid_Tareaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TAREAID",fmt:0,gxz:"Z12TareaId",gxold:"O12TareaId",gxvar:"A12TareaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A12TareaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12TareaId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("TAREAID",n||gx.fn.currentGridRowImpl(15),gx.O.A12TareaId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A12TareaId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("TAREAID",n||gx.fn.currentGridRowImpl(15),".")},nac:gx.falseFn};i[53]={id:53,fld:"",grid:15};i[54]={id:54,fld:"",grid:15};i[55]={id:55,fld:"TABLE1",grid:15};i[59]={id:59,fld:"",grid:15};i[60]={id:60,fld:"",grid:15};i[61]={id:61,fld:"ADVISOR2",format:1,grid:15,ctrltype:"textblock"};i[62]={id:62,fld:"",grid:15};i[63]={id:63,fld:"",grid:15};i[64]={id:64,fld:"TABLE13",grid:15};i[68]={id:68,fld:"",grid:15};i[69]={id:69,fld:"",grid:15};i[70]={id:70,fld:"TABLE14",grid:15};i[71]={id:71,fld:"",grid:15};i[72]={id:72,fld:"INICIA2",format:1,grid:15,ctrltype:"textblock"};i[73]={id:73,fld:"",grid:15};i[74]={id:74,fld:"FINALIZA2",format:1,grid:15,ctrltype:"textblock"};i[75]={id:75,fld:"",grid:0};i[76]={id:76,fld:"",grid:0};this.ZV8finalizar="";this.OV8finalizar="";this.ZV5asignar="";this.OV5asignar="";this.ZV6comentarios="";this.OV6comentarios="";this.ZV9ParticipanteTableroId=0;this.OV9ParticipanteTableroId=0;this.Z12TareaId=0;this.O12TareaId=0;this.A9TableroId=0;this.A46TareaEstado=0;this.A24TareaFechaInicio=gx.date.nullDate();this.AV8finalizar="";this.AV5asignar="";this.AV6comentarios="";this.AV9ParticipanteTableroId=0;this.A12TareaId=0;this.A18ParticipanteTableroId=0;this.Gx_date=gx.date.nullDate();this.AV16sdt_sa={title:"",type:"",html:"",iconColor:"",iconHtml:"",footer:"",backdrop:"",toast:"",grow:"",width:"",padding:"",background:"",position:"",timer:0,showCloseButton:!1,allowEnterKey:!1,allowOutsideClick:!1,showConfirmButton:!1,confirmButtonText:"",confirmButtonColor:"",confirmButtonUrl:"",focusConfirm:!1,showCancelButton:!1,cancelButtonText:"",cancelButtonUrl:"",showDenyButton:!1,denyButtonText:"",denyBurronUrl:"",imageUrl:"",imageWidth:0,imageHeight:0};this.AV19estadoComentarios=!1;this.Events={e15102_client:["'ASIGNAR'",!0],e16102_client:["'ANADIRASIGNACION'",!0],e17102_client:["'FINALIZARTAREA'",!0],e18102_client:["'CANCELAR'",!0],e19102_client:["'MOSTRARCOMENTARIOS'",!0],e20102_client:["ENTER",!0],e21102_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRIDTAREAS2_nFirstRecordOnPage"},{av:"GRIDTAREAS2_nEOF"},{av:"sPrefix"},{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9"},{av:"A18ParticipanteTableroId",fld:"PARTICIPANTETABLEROID",pic:"ZZZ9"},{ctrl:"vPARTICIPANTETABLEROID"},{av:"AV9ParticipanteTableroId",fld:"vPARTICIPANTETABLEROID",pic:"ZZZ9"},{av:"Gx_date",fld:"vTODAY",pic:"",hsh:!0}],[{ctrl:"vPARTICIPANTETABLEROID"},{av:"AV9ParticipanteTableroId",fld:"vPARTICIPANTETABLEROID",pic:"ZZZ9"}]];this.EvtParms["GRIDTAREAS2.LOAD"]=[[{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9"},{av:"A12TareaId",fld:"TAREAID",pic:"ZZZ9",hsh:!0},{av:"Gx_date",fld:"vTODAY",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("ASIGNACION","Visible")',ctrl:"ASIGNACION",prop:"Visible"},{av:"AV6comentarios",fld:"vCOMENTARIOS",pic:""},{av:'gx.fn.getCtrlProperty("vCOMENTARIOS","Tooltiptext")',ctrl:"vCOMENTARIOS",prop:"Tooltiptext"},{av:"AV5asignar",fld:"vASIGNAR",pic:""},{av:"AV8finalizar",fld:"vFINALIZAR",pic:""},{av:'gx.fn.getCtrlProperty("ADVISOR2","Caption")',ctrl:"ADVISOR2",prop:"Caption"},{av:'gx.fn.getCtrlProperty("NOMBRE2","Caption")',ctrl:"NOMBRE2",prop:"Caption"},{av:'gx.fn.getCtrlProperty("INICIA2","Caption")',ctrl:"INICIA2",prop:"Caption"},{av:'gx.fn.getCtrlProperty("FINALIZA2","Caption")',ctrl:"FINALIZA2",prop:"Caption"}]];this.EvtParms["GRIDTAREAS2.REFRESH"]=[[{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9"},{av:"A12TareaId",fld:"TAREAID",pic:"ZZZ9",hsh:!0},{av:"Gx_date",fld:"vTODAY",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("ASIGNACION","Visible")',ctrl:"ASIGNACION",prop:"Visible"},{av:"AV6comentarios",fld:"vCOMENTARIOS",pic:""},{av:'gx.fn.getCtrlProperty("vCOMENTARIOS","Tooltiptext")',ctrl:"vCOMENTARIOS",prop:"Tooltiptext"},{av:"AV5asignar",fld:"vASIGNAR",pic:""},{av:"AV8finalizar",fld:"vFINALIZAR",pic:""},{av:'gx.fn.getCtrlProperty("ADVISOR2","Caption")',ctrl:"ADVISOR2",prop:"Caption"},{av:'gx.fn.getCtrlProperty("NOMBRE2","Caption")',ctrl:"NOMBRE2",prop:"Caption"},{av:'gx.fn.getCtrlProperty("INICIA2","Caption")',ctrl:"INICIA2",prop:"Caption"},{av:'gx.fn.getCtrlProperty("FINALIZA2","Caption")',ctrl:"FINALIZA2",prop:"Caption"}]];this.EvtParms["'ASIGNAR'"]=[[{av:"GRIDTAREAS2_nFirstRecordOnPage"},{av:"GRIDTAREAS2_nEOF"},{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9"},{av:"A18ParticipanteTableroId",fld:"PARTICIPANTETABLEROID",pic:"ZZZ9"},{ctrl:"vPARTICIPANTETABLEROID"},{av:"AV9ParticipanteTableroId",fld:"vPARTICIPANTETABLEROID",pic:"ZZZ9"},{av:"Gx_date",fld:"vTODAY",pic:"",hsh:!0},{av:"sPrefix"},{av:"A12TareaId",fld:"TAREAID",pic:"ZZZ9",hsh:!0},{av:"AV16sdt_sa",fld:"vSDT_SA",pic:""}],[{av:'gx.fn.getCtrlProperty("ASIGNACION","Visible")',ctrl:"ASIGNACION",prop:"Visible"},{ctrl:"vPARTICIPANTETABLEROID"},{av:"AV9ParticipanteTableroId",fld:"vPARTICIPANTETABLEROID",pic:"ZZZ9"},{av:"AV16sdt_sa",fld:"vSDT_SA",pic:""}]];this.EvtParms["'ANADIRASIGNACION'"]=[[{av:"GRIDTAREAS2_nFirstRecordOnPage"},{av:"GRIDTAREAS2_nEOF"},{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9"},{av:"A18ParticipanteTableroId",fld:"PARTICIPANTETABLEROID",pic:"ZZZ9"},{ctrl:"vPARTICIPANTETABLEROID"},{av:"AV9ParticipanteTableroId",fld:"vPARTICIPANTETABLEROID",pic:"ZZZ9"},{av:"Gx_date",fld:"vTODAY",pic:"",hsh:!0},{av:"sPrefix"},{av:"A12TareaId",fld:"TAREAID",pic:"ZZZ9",hsh:!0},{av:"AV16sdt_sa",fld:"vSDT_SA",pic:""}],[{ctrl:"vPARTICIPANTETABLEROID"},{av:"AV9ParticipanteTableroId",fld:"vPARTICIPANTETABLEROID",pic:"ZZZ9"},{av:"AV16sdt_sa",fld:"vSDT_SA",pic:""}]];this.EvtParms["'FINALIZARTAREA'"]=[[{av:"GRIDTAREAS2_nFirstRecordOnPage"},{av:"GRIDTAREAS2_nEOF"},{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9"},{av:"A18ParticipanteTableroId",fld:"PARTICIPANTETABLEROID",pic:"ZZZ9"},{ctrl:"vPARTICIPANTETABLEROID"},{av:"AV9ParticipanteTableroId",fld:"vPARTICIPANTETABLEROID",pic:"ZZZ9"},{av:"Gx_date",fld:"vTODAY",pic:"",hsh:!0},{av:"sPrefix"},{av:"A12TareaId",fld:"TAREAID",pic:"ZZZ9",hsh:!0},{av:"AV16sdt_sa",fld:"vSDT_SA",pic:""}],[{av:"AV16sdt_sa",fld:"vSDT_SA",pic:""},{ctrl:"vPARTICIPANTETABLEROID"},{av:"AV9ParticipanteTableroId",fld:"vPARTICIPANTETABLEROID",pic:"ZZZ9"}]];this.EvtParms["'CANCELAR'"]=[[{av:"GRIDTAREAS2_nFirstRecordOnPage"},{av:"GRIDTAREAS2_nEOF"},{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9"},{av:"A18ParticipanteTableroId",fld:"PARTICIPANTETABLEROID",pic:"ZZZ9"},{ctrl:"vPARTICIPANTETABLEROID"},{av:"AV9ParticipanteTableroId",fld:"vPARTICIPANTETABLEROID",pic:"ZZZ9"},{av:"Gx_date",fld:"vTODAY",pic:"",hsh:!0},{av:"sPrefix"}],[{ctrl:"vPARTICIPANTETABLEROID"},{av:"AV9ParticipanteTableroId",fld:"vPARTICIPANTETABLEROID",pic:"ZZZ9"}]];this.EvtParms["'MOSTRARCOMENTARIOS'"]=[[{av:"AV19estadoComentarios",fld:"vESTADOCOMENTARIOS",pic:""},{av:"A9TableroId",fld:"TABLEROID",pic:"ZZZ9"},{av:"A12TareaId",fld:"TAREAID",pic:"ZZZ9",hsh:!0}],[{ctrl:"LISTADOCOMENTARIOS"},{av:"AV19estadoComentarios",fld:"vESTADOCOMENTARIOS",pic:""}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_TAREAID=[[],[]];this.setVCMap("A9TableroId","TABLEROID",0,"int",4,0);this.setVCMap("A18ParticipanteTableroId","PARTICIPANTETABLEROID",0,"int",4,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("AV16sdt_sa","vSDT_SA",0,"SDT_SweetAlert",0,0);this.setVCMap("AV19estadoComentarios","vESTADOCOMENTARIOS",0,"boolean",4,0);this.setVCMap("A9TableroId","TABLEROID",0,"int",4,0);this.setVCMap("A18ParticipanteTableroId","PARTICIPANTETABLEROID",0,"int",4,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("A9TableroId","TABLEROID",0,"int",4,0);this.setVCMap("A18ParticipanteTableroId","PARTICIPANTETABLEROID",0,"int",4,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);t.addRefreshingVar({rfrVar:"A9TableroId"});t.addRefreshingVar({rfrVar:"A18ParticipanteTableroId"});t.addRefreshingVar({rfrVar:"AV9ParticipanteTableroId",rfrProp:"Value",gxAttId:"Participantetableroid"});t.addRefreshingVar({rfrVar:"Gx_date"});t.addRefreshingParm({rfrVar:"A9TableroId"});t.addRefreshingParm({rfrVar:"A18ParticipanteTableroId"});t.addRefreshingParm({rfrVar:"AV9ParticipanteTableroId",rfrProp:"Value",gxAttId:"Participantetableroid"});t.addRefreshingParm({rfrVar:"Gx_date"});this.Initialize();this.setComponent({id:"GX_PROCESS",GXClass:null,Prefix:"W00-1",lvl:1});this.setComponent({id:"LISTADOCOMENTARIOS",GXClass:"comentarioswc",Prefix:"W0058",lvl:2});this.setComponent({id:"COMPONENT1",GXClass:"listadoactividades",Prefix:"W0067",lvl:2})})