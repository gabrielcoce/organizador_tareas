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
   public class aceptarinvitacion : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public aceptarinvitacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aceptarinvitacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref string aP1_UsuarioEmail )
      {
         this.A9TableroId = aP0_TableroId;
         this.AV7UsuarioEmail = aP1_UsuarioEmail;
         executePrivate();
         aP0_TableroId=this.A9TableroId;
         aP1_UsuarioEmail=this.AV7UsuarioEmail;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7UsuarioEmail = GetPar( "UsuarioEmail");
                  AssignAttri("", false, "AV7UsuarioEmail", AV7UsuarioEmail);
               }
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
            ValidateSpaRequest();
            PA0S2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavUsuarioemail_Enabled = 0;
               AssignProp("", false, edtavUsuarioemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuarioemail_Enabled), 5, 0), true);
               WS0S2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE0S2( ) ;
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
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Aceptar Invitacion") ;
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
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1940340), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20229920474598", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("RAMP/sweetAlert/js/sweetalert2.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/jquery-3.5.1.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/popper.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/bootstrap.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/RAMP_AddOns_SweetAlertRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("aceptarinvitacion.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0)),UrlEncode(StringUtil.RTrim(AV7UsuarioEmail))}, new string[] {"TableroId","UsuarioEmail"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_SA", AV13sdt_sa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_SA", AV13sdt_sa);
         }
      }

      protected void RenderHtmlCloseForm0S2( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "AceptarInvitacion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aceptar Invitacion" ;
      }

      protected void WB0S0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "0fb80292-c642-416d-86bd-eb6746a7bff9", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 150, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AceptarInvitacion.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, lblTextblock1_Caption, "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_AceptarInvitacion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuarionombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarionombre_Internalname, "Nombre", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, StringUtil.RTrim( AV5UsuarioNombre), StringUtil.RTrim( context.localUtil.Format( AV5UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 100, "%", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AceptarInvitacion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuarioapellido_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarioapellido_Internalname, "Apellido", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarioapellido_Internalname, StringUtil.RTrim( AV6UsuarioApellido), StringUtil.RTrim( context.localUtil.Format( AV6UsuarioApellido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarioapellido_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuarioapellido_Enabled, 0, "text", "", 100, "%", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AceptarInvitacion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuarioemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarioemail_Internalname, "Email", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavUsuarioemail_Internalname, AV7UsuarioEmail, StringUtil.RTrim( context.localUtil.Format( AV7UsuarioEmail, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarioemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuarioemail_Enabled, 0, "text", "", 100, "%", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_AceptarInvitacion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuariopassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariopassword_Internalname, "Contraseña", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuariopassword_Internalname, StringUtil.RTrim( AV8UsuarioPassword), StringUtil.RTrim( context.localUtil.Format( AV8UsuarioPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuariopassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuariopassword_Enabled, 0, "text", "", 80, "chr", 1, "row", 200, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AceptarInvitacion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPassword_Internalname, "Verifica tu contraseña", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPassword_Internalname, StringUtil.RTrim( AV9Password), StringUtil.RTrim( context.localUtil.Format( AV9Password, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPassword_Enabled, 0, "text", "", 80, "chr", 1, "row", 200, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AceptarInvitacion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Right", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAceptar_Internalname, "", "Aceptar", bttAceptar_Jsonclick, 5, "Aceptar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'REGISTRO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AceptarInvitacion.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelar_Internalname, "", "Cancelar", bttCancelar_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AceptarInvitacion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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

      protected void START0S2( )
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
            Form.Meta.addItem("description", "Aceptar Invitacion", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0S0( ) ;
      }

      protected void WS0S2( )
      {
         START0S2( ) ;
         EVT0S2( ) ;
      }

      protected void EVT0S2( )
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
                           E110S2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'REGISTRO'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'Registro' */
                           E120S2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E130S2 ();
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
                        else if ( StringUtil.StrCmp(sEvt, "'CANCELAR'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
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

      protected void WE0S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0S2( ) ;
            }
         }
      }

      protected void PA0S2( )
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
               GX_FocusControl = edtavUsuarionombre_Internalname;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF0S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000S2 */
            pr_default.execute(0, new Object[] {A9TableroId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               /* Execute user event: Load */
               E130S2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB0S0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0S2( )
      {
         GxWebStd.gx_hidden_field( context, "TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavUsuarioemail_Enabled = 0;
         AssignProp("", false, edtavUsuarioemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuarioemail_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV5UsuarioNombre = cgiGet( edtavUsuarionombre_Internalname);
            AssignAttri("", false, "AV5UsuarioNombre", AV5UsuarioNombre);
            AV6UsuarioApellido = cgiGet( edtavUsuarioapellido_Internalname);
            AssignAttri("", false, "AV6UsuarioApellido", AV6UsuarioApellido);
            AV8UsuarioPassword = cgiGet( edtavUsuariopassword_Internalname);
            AssignAttri("", false, "AV8UsuarioPassword", AV8UsuarioPassword);
            AV9Password = cgiGet( edtavPassword_Internalname);
            AssignAttri("", false, "AV9Password", AV9Password);
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
         E110S2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110S2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV17Tableros.Load(A9TableroId);
         AV18Usuarios2.Load(AV17Tableros.gxTpr_Propietarioid);
         lblTextblock1_Caption = "<h2><center><strong>"+StringUtil.Trim( AV18Usuarios2.gxTpr_Usuarionombre)+" "+StringUtil.Trim( AV18Usuarios2.gxTpr_Usuarioapellido)+"te ha invitado a colaborar.  Registrate para aceptar la invitación</strong></center></h2>";
         AssignProp("", false, lblTextblock1_Internalname, "Caption", lblTextblock1_Caption, true);
         AV14CryptoHash.Algorithm = "SHA1";
      }

      protected void E120S2( )
      {
         /* 'Registro' Routine */
         returnInSub = false;
         AV16ResultSHA = "";
         AV12validacion = 0;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5UsuarioNombre)) )
         {
            AV12validacion = (short)(AV12validacion+1);
            GX_msglist.addItem("Debes ingresar el nombre");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6UsuarioApellido)) )
         {
            AV12validacion = (short)(AV12validacion+1);
            GX_msglist.addItem("Debes ingresar el apellido");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7UsuarioEmail)) )
         {
            AV12validacion = (short)(AV12validacion+1);
            GX_msglist.addItem("Debes ingresar el Email");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8UsuarioPassword)) )
         {
            AV12validacion = (short)(AV12validacion+1);
            GX_msglist.addItem("Debes ingresar el Password");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9Password)) )
         {
            AV12validacion = (short)(AV12validacion+1);
            GX_msglist.addItem("Debes verificar tu password");
         }
         else if ( StringUtil.StrCmp(AV9Password, AV8UsuarioPassword) != 0 )
         {
            AV12validacion = (short)(AV12validacion+1);
            GX_msglist.addItem("Las contraseñas no coinciden");
         }
         if ( AV12validacion == 0 )
         {
            AV16ResultSHA = AV14CryptoHash.Compute(StringUtil.Trim( AV8UsuarioPassword), "");
            GXt_int1 = AV11UsuarioId;
            new getusuarioid(context ).execute( out  GXt_int1) ;
            AV11UsuarioId = GXt_int1;
            AV10Usuarios = new SdtUsuarios(context);
            AV10Usuarios.gxTpr_Usuarioid = AV11UsuarioId;
            AV10Usuarios.gxTpr_Usuarionombre = AV5UsuarioNombre;
            AV10Usuarios.gxTpr_Usuarioapellido = AV6UsuarioApellido;
            AV10Usuarios.gxTpr_Usuarioemail = AV7UsuarioEmail;
            AV10Usuarios.gxTpr_Usuariopassword = AV16ResultSHA;
            AV10Usuarios.gxTpr_Rolid = 1;
            AV10Usuarios.gxTpr_Usuarioestado = Convert.ToBoolean( 1);
            AV10Usuarios.Insert();
            if ( AV10Usuarios.Success() )
            {
               GXt_boolean2 = AV21Result;
               new cambiarparticipantesinvitados(context ).execute( ref  A9TableroId, ref  AV11UsuarioId, ref  GXt_boolean2) ;
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
               AV21Result = GXt_boolean2;
               if ( AV21Result )
               {
                  context.CommitDataStores("aceptarinvitacion",pr_default);
                  AV13sdt_sa.gxTpr_Title = "Usuario registrado correctamente";
                  AV13sdt_sa.gxTpr_Html = "El usuario ha sido registrado correctamente.  Ya puedes iniciar sesion";
                  AV13sdt_sa.gxTpr_Timer = 4000;
                  AV13sdt_sa.gxTpr_Allowoutsideclick = true;
                  AV13sdt_sa.gxTpr_Type = "success";
                  this.executeUsercontrolMethod("", false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV13sdt_sa});
                  context.setWebReturnParms(new Object[] {(short)A9TableroId,(string)AV7UsuarioEmail});
                  context.setWebReturnParmsMetadata(new Object[] {"A9TableroId","AV7UsuarioEmail"});
                  context.wjLocDisableFrm = 1;
                  context.nUserReturn = 1;
                  returnInSub = true;
                  if (true) return;
               }
               else
               {
                  AV13sdt_sa.gxTpr_Title = "Ha ocurrido un error";
                  AV13sdt_sa.gxTpr_Html = "Ha ocurrido un error, por favor intentelo nuevamente";
                  AV13sdt_sa.gxTpr_Timer = 4000;
                  AV13sdt_sa.gxTpr_Allowoutsideclick = true;
                  AV13sdt_sa.gxTpr_Type = "error";
                  this.executeUsercontrolMethod("", false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV13sdt_sa});
               }
            }
            else
            {
               context.RollbackDataStores("aceptarinvitacion",pr_default);
               AV13sdt_sa.gxTpr_Title = "Ha ocurrido un error";
               AV13sdt_sa.gxTpr_Html = "Ha ocurrido un error, por favor intentelo nuevamente";
               AV13sdt_sa.gxTpr_Timer = 4000;
               AV13sdt_sa.gxTpr_Allowoutsideclick = true;
               AV13sdt_sa.gxTpr_Type = "error";
               this.executeUsercontrolMethod("", false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV13sdt_sa});
            }
         }
         else
         {
            AV13sdt_sa.gxTpr_Title = "Ha ocurrido un error";
            AV13sdt_sa.gxTpr_Html = "Ha ocurrido un error, por favor intentelo nuevamente";
            AV13sdt_sa.gxTpr_Timer = 4000;
            AV13sdt_sa.gxTpr_Allowoutsideclick = true;
            AV13sdt_sa.gxTpr_Type = "error";
            this.executeUsercontrolMethod("", false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV13sdt_sa});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13sdt_sa", AV13sdt_sa);
      }

      protected void nextLoad( )
      {
      }

      protected void E130S2( )
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
         AV7UsuarioEmail = (string)getParm(obj,1);
         AssignAttri("", false, "AV7UsuarioEmail", AV7UsuarioEmail);
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
         PA0S2( ) ;
         WS0S2( ) ;
         WE0S2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20229920474621", true, true);
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
         context.AddJavascriptSource("aceptarinvitacion.js", "?20229920474621", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/js/sweetalert2.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/jquery-3.5.1.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/popper.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/bootstrap.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/RAMP_AddOns_SweetAlertRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgImage1_Internalname = "IMAGE1";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavUsuarionombre_Internalname = "vUSUARIONOMBRE";
         edtavUsuarioapellido_Internalname = "vUSUARIOAPELLIDO";
         edtavUsuarioemail_Internalname = "vUSUARIOEMAIL";
         edtavUsuariopassword_Internalname = "vUSUARIOPASSWORD";
         edtavPassword_Internalname = "vPASSWORD";
         bttAceptar_Internalname = "ACEPTAR";
         bttCancelar_Internalname = "CANCELAR";
         divTable1_Internalname = "TABLE1";
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
         edtavPassword_Jsonclick = "";
         edtavPassword_Enabled = 1;
         edtavUsuariopassword_Jsonclick = "";
         edtavUsuariopassword_Enabled = 1;
         edtavUsuarioemail_Jsonclick = "";
         edtavUsuarioemail_Enabled = 0;
         edtavUsuarioapellido_Jsonclick = "";
         edtavUsuarioapellido_Enabled = 1;
         edtavUsuarionombre_Jsonclick = "";
         edtavUsuarionombre_Enabled = 1;
         lblTextblock1_Caption = "Text Block";
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'REGISTRO'","{handler:'E120S2',iparms:[{av:'AV5UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV6UsuarioApellido',fld:'vUSUARIOAPELLIDO',pic:''},{av:'AV7UsuarioEmail',fld:'vUSUARIOEMAIL',pic:''},{av:'AV8UsuarioPassword',fld:'vUSUARIOPASSWORD',pic:''},{av:'AV9Password',fld:'vPASSWORD',pic:''},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9',hsh:true},{av:'AV13sdt_sa',fld:'vSDT_SA',pic:''}]");
         setEventMetadata("'REGISTRO'",",oparms:[{av:'AV13sdt_sa',fld:'vSDT_SA',pic:''}]}");
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
         wcpOAV7UsuarioEmail = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV13sdt_sa = new SdtSDT_SweetAlert(context);
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         AV5UsuarioNombre = "";
         AV6UsuarioApellido = "";
         AV8UsuarioPassword = "";
         AV9Password = "";
         bttAceptar_Jsonclick = "";
         bttCancelar_Jsonclick = "";
         ucRamp_addons_sweetalert1 = new GXUserControl();
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H000S2_A9TableroId = new short[1] ;
         AV17Tableros = new SdtTableros(context);
         AV18Usuarios2 = new SdtUsuarios(context);
         AV14CryptoHash = new GXHashing();
         AV16ResultSHA = "";
         AV10Usuarios = new SdtUsuarios(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aceptarinvitacion__default(),
            new Object[][] {
                new Object[] {
               H000S2_A9TableroId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A9TableroId ;
      private short wcpOA9TableroId ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV12validacion ;
      private short AV11UsuarioId ;
      private short GXt_int1 ;
      private short nGXWrapped ;
      private int edtavUsuarioemail_Enabled ;
      private int edtavUsuarionombre_Enabled ;
      private int edtavUsuarioapellido_Enabled ;
      private int edtavUsuariopassword_Enabled ;
      private int edtavPassword_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string edtavUsuarioemail_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage1_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Caption ;
      private string lblTextblock1_Jsonclick ;
      private string edtavUsuarionombre_Internalname ;
      private string TempTags ;
      private string AV5UsuarioNombre ;
      private string edtavUsuarionombre_Jsonclick ;
      private string edtavUsuarioapellido_Internalname ;
      private string AV6UsuarioApellido ;
      private string edtavUsuarioapellido_Jsonclick ;
      private string edtavUsuarioemail_Jsonclick ;
      private string edtavUsuariopassword_Internalname ;
      private string AV8UsuarioPassword ;
      private string edtavUsuariopassword_Jsonclick ;
      private string edtavPassword_Internalname ;
      private string AV9Password ;
      private string edtavPassword_Jsonclick ;
      private string bttAceptar_Internalname ;
      private string bttAceptar_Jsonclick ;
      private string bttCancelar_Internalname ;
      private string bttCancelar_Jsonclick ;
      private string Ramp_addons_sweetalert1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string AV16ResultSHA ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV21Result ;
      private bool GXt_boolean2 ;
      private string AV7UsuarioEmail ;
      private string wcpOAV7UsuarioEmail ;
      private GXUserControl ucRamp_addons_sweetalert1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private string aP1_UsuarioEmail ;
      private IDataStoreProvider pr_default ;
      private short[] H000S2_A9TableroId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXHashing AV14CryptoHash ;
      private SdtSDT_SweetAlert AV13sdt_sa ;
      private SdtUsuarios AV18Usuarios2 ;
      private SdtUsuarios AV10Usuarios ;
      private SdtTableros AV17Tableros ;
   }

   public class aceptarinvitacion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000S2;
          prmH000S2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000S2", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000S2,1, GxCacheFrequency.OFF ,true,true )
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
       }
    }

 }

}
