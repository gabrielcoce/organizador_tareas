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
   public class anadirtarea : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public anadirtarea( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavResponsable = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
                  AssignAttri(sPrefix, false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A9TableroId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0U2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               Gx_date = DateTimeUtil.Today( context);
               context.Gx_err = 0;
               WS0U2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Anadir Tarea") ;
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
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1848160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1848160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1848160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1848160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1848160), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 1848160), false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/js/sweetalert2.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/jquery-3.5.1.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/popper.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/bootstrap.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/RAMP_AddOns_SweetAlertRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "anadirtarea.aspx"+UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("anadirtarea.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTODAY", GetSecureSignedToken( sPrefix, Gx_date, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABLEROID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8TableroId), "ZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA9TableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTODAY", GetSecureSignedToken( sPrefix, Gx_date, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABLEROID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8TableroId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_SA", AV7sdt_sa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_SA", AV7sdt_sa);
         }
      }

      protected void RenderHtmlCloseForm0U2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "anadirtarea.aspx");
               context.AddJavascriptSource("RAMP/sweetAlert/js/sweetalert2.min.js", "", false, true);
               context.AddJavascriptSource("RAMP/shared/js/jquery-3.5.1.min.js", "", false, true);
               context.AddJavascriptSource("RAMP/shared/js/popper.js", "", false, true);
               context.AddJavascriptSource("RAMP/shared/js/bootstrap.min.js", "", false, true);
               context.AddJavascriptSource("RAMP/sweetAlert/RAMP_AddOns_SweetAlertRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "TableWhite", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, lblTextblock1_Caption, "", "", lblTextblock1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_AnadirTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTareanombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTareanombre_Internalname, "Nombre", "col-xs-12 AttributePaddingLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTareanombre_Internalname, StringUtil.RTrim( AV13TareaNombre), StringUtil.RTrim( context.localUtil.Format( AV13TareaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTareanombre_Jsonclick, 0, "AttributePadding", "", "", "", "", 1, edtavTareanombre_Enabled, 0, "text", "", 100, "%", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AnadirTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTareafechainicio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTareafechainicio_Internalname, "Fecha de inicio", "col-xs-12 AttributePaddingLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTareafechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTareafechainicio_Internalname, context.localUtil.Format(AV14TareaFechaInicio, "99/99/99"), context.localUtil.Format( AV14TareaFechaInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTareafechainicio_Jsonclick, 0, "AttributePadding", "", "", "", "", 1, edtavTareafechainicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AnadirTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTareafechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTareafechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AnadirTarea.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTareafechafin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTareafechafin_Internalname, "Fecha de finalización", "col-xs-12 AttributePaddingLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTareafechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTareafechafin_Internalname, context.localUtil.Format(AV15TareaFechaFin, "99/99/99"), context.localUtil.Format( AV15TareaFechaFin, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,22);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTareafechafin_Jsonclick, 0, "AttributePadding", "", "", "", "", 1, edtavTareafechafin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AnadirTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTareafechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTareafechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AnadirTarea.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavResponsable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavResponsable_Internalname, "Responsable", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResponsable, cmbavResponsable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16Responsable), 4, 0)), 1, cmbavResponsable_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavResponsable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 1, "HLP_AnadirTarea.htm");
            cmbavResponsable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16Responsable), 4, 0));
            AssignProp(sPrefix, false, cmbavResponsable_Internalname, "Values", (string)(cmbavResponsable.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGuardar_Internalname, "", "Guardar", bttGuardar_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'GUARDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AnadirTarea.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelar_Internalname, "", "Cancelar", bttCancelar_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'CANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AnadirTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucRamp_addons_sweetalert1.Render(context, "ramp_addons_sweetalert", Ramp_addons_sweetalert1_Internalname, sPrefix+"RAMP_ADDONS_SWEETALERT1Container");
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
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_11-163677", 0) ;
               }
               Form.Meta.addItem("description", "Anadir Tarea", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0U0( ) ;
            }
         }
      }

      protected void WS0U2( )
      {
         START0U2( ) ;
         EVT0U2( ) ;
      }

      protected void EVT0U2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E110U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELAR'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Cancelar' */
                                    E120U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GUARDAR'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Guardar' */
                                    E130U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavTareanombre_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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
               RenderHtmlCloseForm0U2( ) ;
            }
         }
      }

      protected void PA0U2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "anadirtarea.aspx")), "anadirtarea.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "anadirtarea.aspx")))) ;
                  }
                  else
                  {
                     GxWebError = 1;
                     context.HttpContext.Response.StatusDescription = 403.ToString();
                     context.HttpContext.Response.StatusCode = 403;
                     context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                     context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                     context.WriteHtmlText( "<p /><hr />") ;
                     GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  }
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "TableroId");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
                     }
                     if ( toggleJsOutput )
                     {
                        if ( context.isSpaRequest( ) )
                        {
                           enableJsOutput();
                        }
                     }
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavTareanombre_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
            AssignAttri(sPrefix, false, "AV16Responsable", StringUtil.LTrimStr( (decimal)(AV16Responsable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResponsable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16Responsable), 4, 0));
            AssignProp(sPrefix, false, cmbavResponsable_Internalname, "Values", cmbavResponsable.ToJavascriptSource(), true);
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTODAY", GetSecureSignedToken( sPrefix, Gx_date, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABLEROID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8TableroId), "ZZZ9"), context));
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
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA9TableroId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA9TableroId"), ",", "."));
            /* Read variables values. */
            AV13TareaNombre = cgiGet( edtavTareanombre_Internalname);
            AssignAttri(sPrefix, false, "AV13TareaNombre", AV13TareaNombre);
            if ( context.localUtil.VCDate( cgiGet( edtavTareafechainicio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tarea Fecha Inicio"}), 1, "vTAREAFECHAINICIO");
               GX_FocusControl = edtavTareafechainicio_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14TareaFechaInicio = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV14TareaFechaInicio", context.localUtil.Format(AV14TareaFechaInicio, "99/99/99"));
            }
            else
            {
               AV14TareaFechaInicio = context.localUtil.CToD( cgiGet( edtavTareafechainicio_Internalname), 2);
               AssignAttri(sPrefix, false, "AV14TareaFechaInicio", context.localUtil.Format(AV14TareaFechaInicio, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTareafechafin_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tarea Fecha Fin"}), 1, "vTAREAFECHAFIN");
               GX_FocusControl = edtavTareafechafin_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15TareaFechaFin = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV15TareaFechaFin", context.localUtil.Format(AV15TareaFechaFin, "99/99/99"));
            }
            else
            {
               AV15TareaFechaFin = context.localUtil.CToD( cgiGet( edtavTareafechafin_Internalname), 2);
               AssignAttri(sPrefix, false, "AV15TareaFechaFin", context.localUtil.Format(AV15TareaFechaFin, "99/99/99"));
            }
            cmbavResponsable.CurrentValue = cgiGet( cmbavResponsable_Internalname);
            AV16Responsable = (short)(NumberUtil.Val( cgiGet( cmbavResponsable_Internalname), "."));
            AssignAttri(sPrefix, false, "AV16Responsable", StringUtil.LTrimStr( (decimal)(AV16Responsable), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
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
         AssignProp(sPrefix, false, lblTextblock1_Internalname, "Caption", lblTextblock1_Caption, true);
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
         AssignAttri(sPrefix, false, "AV8TableroId", StringUtil.LTrimStr( (decimal)(AV8TableroId), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABLEROID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8TableroId), "ZZZ9"), context));
      }

      protected void E120U2( )
      {
         /* 'Cancelar' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "listadotareas.aspx"+UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0));
         CallWebObject(formatLink("listadotareas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
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
            AssignAttri(sPrefix, false, "AV8TableroId", StringUtil.LTrimStr( (decimal)(AV8TableroId), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABLEROID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8TableroId), "ZZZ9"), context));
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
               this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV7sdt_sa});
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "listadotareas.aspx"+UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0));
               CallWebObject(formatLink("listadotareas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
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
               this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV7sdt_sa});
            }
         }
         else
         {
            AV7sdt_sa.gxTpr_Title = "Error en la información ingresada";
            AV7sdt_sa.gxTpr_Html = "Por favor verifica los errores y corrígelos para continuar";
            AV7sdt_sa.gxTpr_Timer = 4000;
            AV7sdt_sa.gxTpr_Allowoutsideclick = true;
            AV7sdt_sa.gxTpr_Type = "error";
            this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV7sdt_sa});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV7sdt_sa", AV7sdt_sa);
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
         AssignAttri(sPrefix, false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
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
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA9TableroId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0U2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "anadirtarea", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0U2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A9TableroId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
         }
         wcpOA9TableroId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA9TableroId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A9TableroId != wcpOA9TableroId ) ) )
         {
            setjustcreated();
         }
         wcpOA9TableroId = A9TableroId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA9TableroId = cgiGet( sPrefix+"A9TableroId_CTRL");
         if ( StringUtil.Len( sCtrlA9TableroId) > 0 )
         {
            A9TableroId = (short)(context.localUtil.CToN( cgiGet( sCtrlA9TableroId), ",", "."));
            AssignAttri(sPrefix, false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
         }
         else
         {
            A9TableroId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A9TableroId_PARM"), ",", "."));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0U2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0U2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A9TableroId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA9TableroId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A9TableroId_CTRL", StringUtil.RTrim( sCtrlA9TableroId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0U2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022101613104959", true, true);
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
         context.AddJavascriptSource("anadirtarea.js", "?2022101613104959", false, true);
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
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1";
         edtavTareanombre_Internalname = sPrefix+"vTAREANOMBRE";
         edtavTareafechainicio_Internalname = sPrefix+"vTAREAFECHAINICIO";
         edtavTareafechafin_Internalname = sPrefix+"vTAREAFECHAFIN";
         cmbavResponsable_Internalname = sPrefix+"vRESPONSABLE";
         divTable2_Internalname = sPrefix+"TABLE2";
         bttGuardar_Internalname = sPrefix+"GUARDAR";
         bttCancelar_Internalname = sPrefix+"CANCELAR";
         divSection1_Internalname = sPrefix+"SECTION1";
         Ramp_addons_sweetalert1_Internalname = sPrefix+"RAMP_ADDONS_SWEETALERT1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'AV8TableroId',fld:'vTABLEROID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'CANCELAR'","{handler:'E120U2',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]");
         setEventMetadata("'CANCELAR'",",oparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("'GUARDAR'","{handler:'E130U2',iparms:[{av:'AV13TareaNombre',fld:'vTAREANOMBRE',pic:''},{av:'AV14TareaFechaInicio',fld:'vTAREAFECHAINICIO',pic:''},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'AV15TareaFechaFin',fld:'vTAREAFECHAFIN',pic:''},{av:'AV8TableroId',fld:'vTABLEROID',pic:'ZZZ9',hsh:true},{av:'cmbavResponsable'},{av:'AV16Responsable',fld:'vRESPONSABLE',pic:'ZZZ9'},{av:'AV7sdt_sa',fld:'vSDT_SA',pic:''},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]");
         setEventMetadata("'GUARDAR'",",oparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'AV7sdt_sa',fld:'vSDT_SA',pic:''}]}");
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
         sPrefix = "";
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV7sdt_sa = new SdtSDT_SweetAlert(context);
         GX_FocusControl = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         AV13TareaNombre = "";
         AV14TareaFechaInicio = DateTime.MinValue;
         AV15TareaFechaFin = DateTime.MinValue;
         ClassString = "";
         StyleString = "";
         bttGuardar_Jsonclick = "";
         bttCancelar_Jsonclick = "";
         ucRamp_addons_sweetalert1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H000U2_A9TableroId = new short[1] ;
         H000U3_A9TableroId = new short[1] ;
         H000U3_A18ParticipanteTableroId = new short[1] ;
         AV20Participantes2 = new SdtParticipantes(context);
         AV21Usuarios = new SdtUsuarios(context);
         AV18Tareas = new SdtTareas(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA9TableroId = "";
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
      private short nDynComponent ;
      private short initialized ;
      private short AV8TableroId ;
      private short wbEnd ;
      private short wbStart ;
      private short AV16Responsable ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
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
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Caption ;
      private string lblTextblock1_Jsonclick ;
      private string divTable2_Internalname ;
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
      private string ClassString ;
      private string StyleString ;
      private string bttGuardar_Internalname ;
      private string bttGuardar_Jsonclick ;
      private string bttCancelar_Internalname ;
      private string bttCancelar_Jsonclick ;
      private string Ramp_addons_sweetalert1_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string sCtrlA9TableroId ;
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
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private GXCombobox cmbavResponsable ;
      private IDataStoreProvider pr_default ;
      private short[] H000U2_A9TableroId ;
      private short[] H000U3_A9TableroId ;
      private short[] H000U3_A18ParticipanteTableroId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
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
