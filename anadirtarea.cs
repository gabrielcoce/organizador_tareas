using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class anadirtarea : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public anadirtarea( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public anadirtarea( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId )
      {
         this.A9TableroId = aP0_TableroId;
         executePrivate();
         aP0_TableroId=this.A9TableroId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavResponsable = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "TableroId");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TableroId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TableroId");
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               A9TableroId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA0U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0U2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1940340), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202291618523684", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/js/sweetalert2.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/jquery-3.5.1.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/popper.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/bootstrap.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/RAMP_AddOns_SweetAlertRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("anadirtarea.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0))}, new string[] {"TableroId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8TableroId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "vTABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8TableroId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_SA", AV7sdt_sa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_SA", AV7sdt_sa);
         }
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0U2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("anadirtarea.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0))}, new string[] {"TableroId"})  ;
      }

      public override string GetPgmname( )
      {
         return "AnadirTarea" ;
      }

      public override string GetPgmdesc( )
      {
         return "Anadir Tarea" ;
      }

      protected void WB0U0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "4e5cde33-ed10-4143-9ff4-72384d8ea839", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 75, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AnadirTarea.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, lblTextblock1_Caption, "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_AnadirTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTareanombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTareanombre_Internalname, "Nombre", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTareanombre_Internalname, StringUtil.RTrim( AV13TareaNombre), StringUtil.RTrim( context.localUtil.Format( AV13TareaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTareanombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTareanombre_Enabled, 0, "text", "", 100, "%", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AnadirTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTareafechainicio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTareafechainicio_Internalname, "Fecha de inicio", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTareafechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTareafechainicio_Internalname, context.localUtil.Format(AV14TareaFechaInicio, "99/99/99"), context.localUtil.Format( AV14TareaFechaInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTareafechainicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTareafechainicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AnadirTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTareafechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTareafechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AnadirTarea.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTareafechafin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTareafechafin_Internalname, "Fecha de finalización", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTareafechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTareafechafin_Internalname, context.localUtil.Format(AV15TareaFechaFin, "99/99/99"), context.localUtil.Format( AV15TareaFechaFin, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTareafechafin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTareafechafin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AnadirTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTareafechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTareafechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AnadirTarea.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavResponsable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavResponsable_Internalname, "Responsable", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResponsable, cmbavResponsable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16Responsable), 4, 0)), 1, cmbavResponsable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavResponsable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 1, "HLP_AnadirTarea.htm");
            cmbavResponsable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16Responsable), 4, 0));
            AssignProp("", false, cmbavResponsable_Internalname, "Values", (string)(cmbavResponsable.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection1_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGuardar_Internalname, "", "Guardar", bttGuardar_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GUARDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AnadirTarea.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelar_Internalname, "", "Cancelar", bttCancelar_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AnadirTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucRamp_addons_sweetalert1.Render(context, "ramp_addons_sweetalert", Ramp_addons_sweetalert1_Internalname, "RAMP_ADDONS_SWEETALERT1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0U2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_8-158023", 0) ;
            }
            Form.Meta.addItem("description", "Anadir Tarea", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0U0( ) ;
      }

      protected void WS0U2( )
      {
         START0U2( ) ;
         EVT0U2( ) ;
      }

      protected void EVT0U2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E110U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Cancelar' */
                              E120U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GUARDAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Guardar' */
                              E130U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E140U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0U2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0U2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavTareanombre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavResponsable.ItemCount > 0 )
         {
            AV16Responsable = (short)(NumberUtil.Val( cmbavResponsable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16Responsable), 4, 0))), "."));
            AssignAttri("", false, "AV16Responsable", StringUtil.LTrimStr( (decimal)(AV16Responsable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResponsable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16Responsable), 4, 0));
            AssignProp("", false, cmbavResponsable_Internalname, "Values", cmbavResponsable.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      protected void RF0U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000U2 */
            pr_default.execute(0, new Object[] {A9TableroId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               /* Execute user event: Load */
               E140U2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB0U0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0U2( )
      {
         GxWebStd.gx_hidden_field( context, "TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "vTABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8TableroId), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV13TareaNombre = cgiGet( edtavTareanombre_Internalname);
            AssignAttri("", false, "AV13TareaNombre", AV13TareaNombre);
            if ( context.localUtil.VCDate( cgiGet( edtavTareafechainicio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tarea Fecha Inicio"}), 1, "vTAREAFECHAINICIO");
               GX_FocusControl = edtavTareafechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14TareaFechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV14TareaFechaInicio", context.localUtil.Format(AV14TareaFechaInicio, "99/99/99"));
            }
            else
            {
               AV14TareaFechaInicio = context.localUtil.CToD( cgiGet( edtavTareafechainicio_Internalname), 2);
               AssignAttri("", false, "AV14TareaFechaInicio", context.localUtil.Format(AV14TareaFechaInicio, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTareafechafin_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tarea Fecha Fin"}), 1, "vTAREAFECHAFIN");
               GX_FocusControl = edtavTareafechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15TareaFechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV15TareaFechaFin", context.localUtil.Format(AV15TareaFechaFin, "99/99/99"));
            }
            else
            {
               AV15TareaFechaFin = context.localUtil.CToD( cgiGet( edtavTareafechafin_Internalname), 2);
               AssignAttri("", false, "AV15TareaFechaFin", context.localUtil.Format(AV15TareaFechaFin, "99/99/99"));
            }
            cmbavResponsable.CurrentValue = cgiGet( cmbavResponsable_Internalname);
            AV16Responsable = (short)(NumberUtil.Val( cgiGet( cmbavResponsable_Internalname), "."));
            AssignAttri("", false, "AV16Responsable", StringUtil.LTrimStr( (decimal)(AV16Responsable), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110U2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110U2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblTextblock1_Caption = "<h2><center></strong>Crea una nueva tarea</strong></center></h2>";
         AssignProp("", false, lblTextblock1_Internalname, "Caption", lblTextblock1_Caption, true);
         /* Using cursor H000U3 */
         pr_default.execute(1, new Object[] {A9TableroId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A18ParticipanteTableroId = H000U3_A18ParticipanteTableroId[0];
            AV20Participantes2.Load(A9TableroId, A18ParticipanteTableroId);
            AV21Usuarios.Load(AV20Participantes2.gxTpr_Participantetableroid);
            cmbavResponsable.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A18ParticipanteTableroId), 4, 0)), StringUtil.Trim( AV21Usuarios.gxTpr_Usuarioemail)+" - "+AV21Usuarios.gxTpr_Usuarionombre+" "+AV21Usuarios.gxTpr_Usuarioapellido, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV8TableroId = A9TableroId;
         AssignAttri("", false, "AV8TableroId", StringUtil.LTrimStr( (decimal)(AV8TableroId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8TableroId), "ZZZ9"), context));
      }

      protected void E120U2( )
      {
         /* 'Cancelar' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {(short)A9TableroId});
         context.setWebReturnParmsMetadata(new Object[] {"A9TableroId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E130U2( )
      {
         /* 'Guardar' Routine */
         returnInSub = false;
         AV5count = 0;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TareaNombre)) )
         {
            AV5count = (short)(AV5count+1);
            GX_msglist.addItem("Debes indicar un nombre para tu tarea");
         }
         if ( (DateTime.MinValue==AV14TareaFechaInicio) )
         {
            AV5count = (short)(AV5count+1);
            GX_msglist.addItem("Debes indicar una fecha de inicio");
         }
         if ( DateTimeUtil.ResetTime ( AV14TareaFechaInicio ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            AV5count = (short)(AV5count+1);
            GX_msglist.addItem("No puedes crear una tarea con fechas pasadas");
         }
         if ( (DateTime.MinValue==AV15TareaFechaFin) )
         {
            AV5count = (short)(AV5count+1);
            GX_msglist.addItem("Debes indicar una fecha de finalización");
         }
         if ( DateTimeUtil.ResetTime ( AV15TareaFechaFin ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            AV5count = (short)(AV5count+1);
            GX_msglist.addItem("La fecha de finalización es inválida");
         }
         if ( DateTimeUtil.ResetTime ( AV15TareaFechaFin ) < DateTimeUtil.ResetTime ( AV14TareaFechaInicio ) )
         {
            AV5count = (short)(AV5count+1);
            GX_msglist.addItem("La fecha de finalización debe ser mayor a la fecha de inicio");
         }
         if ( AV5count == 0 )
         {
            GXt_int1 = AV19TareaId;
            new gettareaid(context ).execute( ref  AV8TableroId, out  GXt_int1) ;
            AssignAttri("", false, "AV8TableroId", StringUtil.LTrimStr( (decimal)(AV8TableroId), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vTABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8TableroId), "ZZZ9"), context));
            AV19TareaId = GXt_int1;
            AV18Tareas = new SdtTareas(context);
            AV18Tareas.gxTpr_Tableroid = AV8TableroId;
            AV18Tareas.gxTpr_Tareaid = AV19TareaId;
            AV18Tareas.gxTpr_Tareanombre = AV13TareaNombre;
            AV18Tareas.gxTpr_Tareafechainicio = AV14TareaFechaInicio;
            AV18Tareas.gxTpr_Tareafechafin = AV15TareaFechaFin;
            AV18Tareas.gxTpr_Tareaestado = 1;
            if ( ( AV16Responsable == 0 ) || (0==AV16Responsable) )
            {
               AV18Tareas.gxTv_SdtTareas_Responsableid_SetNull();
            }
            else
            {
               AV18Tareas.gxTpr_Responsableid = AV16Responsable;
            }
            AV18Tareas.gxTpr_Tareaetiquetas = "";
            AV18Tareas.Insert();
            if ( AV18Tareas.Success() )
            {
               context.CommitDataStores("anadirtarea",pr_default);
               AV7sdt_sa.gxTpr_Title = "Tarea creada correctamente";
               AV7sdt_sa.gxTpr_Html = "Haz creado una nueva tarea.";
               AV7sdt_sa.gxTpr_Timer = 4000;
               AV7sdt_sa.gxTpr_Allowoutsideclick = true;
               AV7sdt_sa.gxTpr_Type = "success";
               this.executeUsercontrolMethod("", false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV7sdt_sa});
               context.setWebReturnParms(new Object[] {(short)A9TableroId});
               context.setWebReturnParmsMetadata(new Object[] {"A9TableroId"});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
            else
            {
               context.RollbackDataStores("anadirtarea",pr_default);
               GX_msglist.addItem(AV18Tareas.GetMessages().ToJSonString(false));
               AV7sdt_sa.gxTpr_Title = "Ha ocurrido un error";
               AV7sdt_sa.gxTpr_Html = "Ha ocurrido un error, por favor intentelo nuevamente";
               AV7sdt_sa.gxTpr_Timer = 4000;
               AV7sdt_sa.gxTpr_Allowoutsideclick = true;
               AV7sdt_sa.gxTpr_Type = "error";
               this.executeUsercontrolMethod("", false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV7sdt_sa});
            }
         }
         else
         {
            AV7sdt_sa.gxTpr_Title = "Error en la información ingresada";
            AV7sdt_sa.gxTpr_Html = "Por favor verifica los errores y corrígelos para continuar";
            AV7sdt_sa.gxTpr_Timer = 4000;
            AV7sdt_sa.gxTpr_Allowoutsideclick = true;
            AV7sdt_sa.gxTpr_Type = "error";
            this.executeUsercontrolMethod("", false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV7sdt_sa});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7sdt_sa", AV7sdt_sa);
      }

      protected void nextLoad( )
      {
      }

      protected void E140U2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A9TableroId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0U2( ) ;
         WS0U2( ) ;
         WE0U2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("RAMP/sweetAlert/css/sweetalert2.min.css", "");
         AddStyleSheetFile("RAMP/shared/css/font-awesome.min.css", "");
         AddStyleSheetFile("RAMP/shared/css/bootstrap.min.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20229161852370", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("anadirtarea.js", "?20229161852370", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/js/sweetalert2.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/jquery-3.5.1.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/popper.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/bootstrap.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/RAMP_AddOns_SweetAlertRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavResponsable.Name = "vRESPONSABLE";
         cmbavResponsable.WebTags = "";
         cmbavResponsable.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 4, 0)), "(Ninguno)", 0);
         if ( cmbavResponsable.ItemCount > 0 )
         {
            AV16Responsable = (short)(NumberUtil.Val( cmbavResponsable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16Responsable), 4, 0))), "."));
            AssignAttri("", false, "AV16Responsable", StringUtil.LTrimStr( (decimal)(AV16Responsable), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgImage1_Internalname = "IMAGE1";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavTareanombre_Internalname = "vTAREANOMBRE";
         edtavTareafechainicio_Internalname = "vTAREAFECHAINICIO";
         edtavTareafechafin_Internalname = "vTAREAFECHAFIN";
         cmbavResponsable_Internalname = "vRESPONSABLE";
         divTable1_Internalname = "TABLE1";
         bttGuardar_Internalname = "GUARDAR";
         bttCancelar_Internalname = "CANCELAR";
         divSection1_Internalname = "SECTION1";
         Ramp_addons_sweetalert1_Internalname = "RAMP_ADDONS_SWEETALERT1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         cmbavResponsable_Jsonclick = "";
         cmbavResponsable.Enabled = 1;
         edtavTareafechafin_Jsonclick = "";
         edtavTareafechafin_Enabled = 1;
         edtavTareafechainicio_Jsonclick = "";
         edtavTareafechainicio_Enabled = 1;
         edtavTareanombre_Jsonclick = "";
         edtavTareanombre_Enabled = 1;
         lblTextblock1_Caption = "Text Block";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Anadir Tarea";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'AV8TableroId',fld:'vTABLEROID',pic:'ZZZ9',hsh:true},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'CANCELAR'","{handler:'E120U2',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'CANCELAR'",",oparms:[]}");
         setEventMetadata("'GUARDAR'","{handler:'E130U2',iparms:[{av:'AV13TareaNombre',fld:'vTAREANOMBRE',pic:''},{av:'AV14TareaFechaInicio',fld:'vTAREAFECHAINICIO',pic:''},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'AV15TareaFechaFin',fld:'vTAREAFECHAFIN',pic:''},{av:'AV8TableroId',fld:'vTABLEROID',pic:'ZZZ9',hsh:true},{av:'cmbavResponsable'},{av:'AV16Responsable',fld:'vRESPONSABLE',pic:'ZZZ9'},{av:'AV7sdt_sa',fld:'vSDT_SA',pic:''},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'GUARDAR'",",oparms:[{av:'AV7sdt_sa',fld:'vSDT_SA',pic:''}]}");
         setEventMetadata("VALIDV_TAREAFECHAINICIO","{handler:'Validv_Tareafechainicio',iparms:[]");
         setEventMetadata("VALIDV_TAREAFECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_TAREAFECHAFIN","{handler:'Validv_Tareafechafin',iparms:[]");
         setEventMetadata("VALIDV_TAREAFECHAFIN",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gx_date = DateTime.MinValue;
         GXKey = "";
         AV7sdt_sa = new SdtSDT_SweetAlert(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         AV13TareaNombre = "";
         AV14TareaFechaInicio = DateTime.MinValue;
         AV15TareaFechaFin = DateTime.MinValue;
         bttGuardar_Jsonclick = "";
         bttCancelar_Jsonclick = "";
         ucRamp_addons_sweetalert1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H000U2_A9TableroId = new short[1] ;
         H000U3_A9TableroId = new short[1] ;
         H000U3_A18ParticipanteTableroId = new short[1] ;
         AV20Participantes2 = new SdtParticipantes(context);
         AV21Usuarios = new SdtUsuarios(context);
         AV18Tareas = new SdtTareas(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.anadirtarea__default(),
            new Object[][] {
                new Object[] {
               H000U2_A9TableroId
               }
               , new Object[] {
               H000U3_A9TableroId, H000U3_A18ParticipanteTableroId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short A9TableroId ;
      private short wcpOA9TableroId ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV8TableroId ;
      private short wbEnd ;
      private short wbStart ;
      private short AV16Responsable ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A18ParticipanteTableroId ;
      private short AV5count ;
      private short AV19TareaId ;
      private short GXt_int1 ;
      private short nGXWrapped ;
      private int edtavTareanombre_Enabled ;
      private int edtavTareafechainicio_Enabled ;
      private int edtavTareafechafin_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage1_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Caption ;
      private string lblTextblock1_Jsonclick ;
      private string divTable1_Internalname ;
      private string edtavTareanombre_Internalname ;
      private string TempTags ;
      private string AV13TareaNombre ;
      private string edtavTareanombre_Jsonclick ;
      private string edtavTareafechainicio_Internalname ;
      private string edtavTareafechainicio_Jsonclick ;
      private string edtavTareafechafin_Internalname ;
      private string edtavTareafechafin_Jsonclick ;
      private string cmbavResponsable_Internalname ;
      private string cmbavResponsable_Jsonclick ;
      private string divSection1_Internalname ;
      private string bttGuardar_Internalname ;
      private string bttGuardar_Jsonclick ;
      private string bttCancelar_Internalname ;
      private string bttCancelar_Jsonclick ;
      private string Ramp_addons_sweetalert1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private DateTime AV14TareaFechaInicio ;
      private DateTime AV15TareaFechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXUserControl ucRamp_addons_sweetalert1 ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private GXCombobox cmbavResponsable ;
      private IDataStoreProvider pr_default ;
      private short[] H000U2_A9TableroId ;
      private short[] H000U3_A9TableroId ;
      private short[] H000U3_A18ParticipanteTableroId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtParticipantes AV20Participantes2 ;
      private SdtSDT_SweetAlert AV7sdt_sa ;
      private SdtTareas AV18Tareas ;
      private SdtUsuarios AV21Usuarios ;
   }

   public class anadirtarea__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000U2;
          prmH000U2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmH000U3;
          prmH000U3 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000U2", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000U2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H000U3", "SELECT [TableroId], [ParticipanteTableroId] FROM [Participantes] WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000U3,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
