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
   public class inicio : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public inicio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public inicio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
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
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
            PA0X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS0X2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE0X2( ) ;
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
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Inicio") ;
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1848160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1848160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1848160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"FormLogin\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"FormLogin\" data-gx-class=\"FormLogin\" novalidate action=\""+formatLink("inicio.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "FormLogin", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
      }

      protected void RenderHtmlCloseForm0X2( )
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
         return "Inicio" ;
      }

      public override string GetPgmdesc( )
      {
         return "Inicio" ;
      }

      protected void WB0X0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblScript1_Internalname, lblScript1_Caption, "", "", lblScript1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Inicio.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 3,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarioemail_Internalname, AV6UsuarioEmail, StringUtil.RTrim( context.localUtil.Format( AV6UsuarioEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,3);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarioemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, false, "", "left", true, "", "HLP_Inicio.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblScript2_Internalname, lblScript2_Caption, "", "", lblScript2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Inicio.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 5,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuariopassword_Internalname, StringUtil.RTrim( AV7UsuarioPassword), StringUtil.RTrim( context.localUtil.Format( AV7UsuarioPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,5);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuariopassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 80, "chr", 1, "row", 200, 0, 0, 0, 1, -1, -1, false, "", "left", true, "", "HLP_Inicio.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblScript3_Internalname, lblScript3_Caption, "", "", lblScript3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Inicio.htm");
         }
         wbLoad = true;
      }

      protected void START0X2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_11-163677", 0) ;
            }
            Form.Meta.addItem("description", "Inicio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0X0( ) ;
      }

      protected void WS0X2( )
      {
         START0X2( ) ;
         EVT0X2( ) ;
      }

      protected void EVT0X2( )
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
                           E110X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E120X2 ();
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

      protected void WE0X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0X2( ) ;
            }
         }
      }

      protected void PA0X2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
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
               GX_FocusControl = edtavUsuarioemail_Internalname;
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
         RF0X2( ) ;
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

      protected void RF0X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E120X2 ();
            WB0X0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0X2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
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
         E110X2 ();
         if (returnInSub) return;
      }

      protected void E110X2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Headerrawhtml = "<meta charset=\"UTF-8\" />"+StringUtil.NewLine( )+"<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"style.css\" />";
         Form.Jscriptsrc.Add("https://kit.fontawesome.com/64d58efce2.js") ;
         lblScript1_Caption = "<div class=\"container\">"+StringUtil.NewLine( )+"<div class=\"forms-container-new\">"+StringUtil.NewLine( )+" <div class=\"signin-signup\">"+StringUtil.NewLine( )+"<form action=\"#\" class=\"sign-in-form\">"+StringUtil.NewLine( )+"<h2 class=\"title\">Sign in</h2>"+StringUtil.NewLine( )+"<div class=\"input-field\">"+StringUtil.NewLine( )+"<i class=\"fas fa-user\"></i>"+StringUtil.NewLine( );
         AssignProp("", false, lblScript1_Internalname, "Caption", lblScript1_Caption, true);
         lblScript2_Caption = "</div>"+StringUtil.NewLine( )+"<div class=\"input-field\">"+StringUtil.NewLine( )+"<i class=\"fas fa-lock\"></i>"+StringUtil.NewLine( );
         AssignProp("", false, lblScript2_Internalname, "Caption", lblScript2_Caption, true);
         lblScript3_Caption = "</div>"+StringUtil.NewLine( )+"<input type=\"submit\" value=\"Login\" class=\"btn solid\" />"+StringUtil.NewLine( )+"<p class=\"social-text\">Or Sign in with social platforms</p>"+StringUtil.NewLine( )+"<div class=\"social-media\">"+StringUtil.NewLine( )+"<a href=\"#\" class=\"social-icon\">"+StringUtil.NewLine( )+"<i class=\"fab fa-facebook-f\"></i>"+StringUtil.NewLine( )+"</a>"+StringUtil.NewLine( )+"<a href=\"#\" class=\"social-icon\">"+StringUtil.NewLine( )+"<i class=\"fab fa-twitter\"></i>"+StringUtil.NewLine( )+"</a>"+StringUtil.NewLine( )+"<a href=\"#\" class=\"social-icon\">"+StringUtil.NewLine( )+"<i class=\"fab fa-google\"></i>"+StringUtil.NewLine( )+"</a>"+StringUtil.NewLine( )+"<a href=\"#\" class=\"social-icon\">"+StringUtil.NewLine( )+"<i class=\"fab fa-linkedin-in\"></i>"+StringUtil.NewLine( )+"</a>"+StringUtil.NewLine( )+"</div>"+StringUtil.NewLine( )+" </form>"+StringUtil.NewLine( )+"<form action=\"#\" class=\"sign-up-form\">"+StringUtil.NewLine( )+"<h2 class=\"title\">Sign up</h2>"+StringUtil.NewLine( )+"<div class=\"input-field\">"+StringUtil.NewLine( )+" <i class=\"fas fa-user\"></i>"+StringUtil.NewLine( )+" <input type=\"text\" placeholder=\"Username\" />"+StringUtil.NewLine( )+" </div>"+StringUtil.NewLine( )+" <div class=\"input-field\">"+StringUtil.NewLine( )+" <i class=\"fas fa-envelope\"></i>"+StringUtil.NewLine( )+" <input type=\"email\" placeholder=\"Email\" />"+StringUtil.NewLine( )+" </div>"+StringUtil.NewLine( )+"<div class=\"input-field\">"+StringUtil.NewLine( )+"<i class=\"fas fa-lock\"></i>"+StringUtil.NewLine( )+" <input type=\"password\" placeholder=\"Password\" />"+StringUtil.NewLine( )+"</div>"+StringUtil.NewLine( )+"<input type=\"submit\" class=\"btn\" value=\"Sign up\" />"+StringUtil.NewLine( )+" <p class=\"social-text\">Or Sign up with social platforms</p>"+StringUtil.NewLine( )+" <div class=\"social-media\">"+StringUtil.NewLine( )+"<a href=\"#\" class=\"social-icon\">"+StringUtil.NewLine( )+" <i class=\"fab fa-facebook-f\"></i>"+StringUtil.NewLine( )+"</a>"+StringUtil.NewLine( )+" <a href=\"#\" class=\"social-icon\">"+StringUtil.NewLine( )+" <i class=\"fab fa-twitter\"></i>"+StringUtil.NewLine( )+"</a>"+StringUtil.NewLine( )+" <a href=\"#\" class=\"social-icon\">"+StringUtil.NewLine( )+"<i class=\"fab fa-google\"></i>"+StringUtil.NewLine( )+"</a>"+StringUtil.NewLine( )+" <a href=\"#\" class=\"social-icon\">"+StringUtil.NewLine( )+"<i class=\"fab fa-linkedin-in\"></i>"+StringUtil.NewLine( )+" </a>"+StringUtil.NewLine( )+" </div>"+StringUtil.NewLine( )+"</form>"+StringUtil.NewLine( )+"</div>"+StringUtil.NewLine( )+" </div>"+StringUtil.NewLine( )+" <div class=\"panels-container\">"+StringUtil.NewLine( )+" <div class=\"panel left-panel\">"+StringUtil.NewLine( )+" <div class=\"content\">"+StringUtil.NewLine( )+" <h3>New here ?</h3>"+StringUtil.NewLine( )+"<p>"+StringUtil.NewLine( )+" Lorem ipsum, dolor sit amet consectetur adipisicing elit. Debitis,"+StringUtil.NewLine( )+" ex ratione. Aliquid!"+StringUtil.NewLine( )+" </p>"+StringUtil.NewLine( )+" <button class=\"btn transparent\" id=\"sign-up-btn\">"+StringUtil.NewLine( )+" Sign up"+StringUtil.NewLine( )+" </button>"+StringUtil.NewLine( )+"</div>"+StringUtil.NewLine( )+" <img src=\"img/log.svg\" class=\"image\" alt=\"\" />"+StringUtil.NewLine( )+" </div>"+StringUtil.NewLine( )+" <div class=\"panel right-panel\">"+StringUtil.NewLine( )+" <div class=\"content\">"+StringUtil.NewLine( )+" <h3>One of us ?</h3>"+StringUtil.NewLine( )+" <p>"+StringUtil.NewLine( )+" Lorem ipsum dolor sit amet consectetur adipisicing elit. Nostrum"+StringUtil.NewLine( )+" laboriosam ad deleniti."+StringUtil.NewLine( )+" </p>"+StringUtil.NewLine( )+" <button class=\"btn transparent\" id=\"sign-in-btn\">"+StringUtil.NewLine( )+"  Sign in"+StringUtil.NewLine( )+" </button>"+StringUtil.NewLine( )+" </div>"+StringUtil.NewLine( )+" <img src=\"img/register.svg\" class=\"image\" alt=\"\" />"+StringUtil.NewLine( )+" </div>"+StringUtil.NewLine( )+" </div>"+StringUtil.NewLine( )+" </div>"+StringUtil.NewLine( )+"<script src=\"app.js\"></script>"+StringUtil.NewLine( );
         AssignProp("", false, lblScript3_Internalname, "Caption", lblScript3_Caption, true);
      }

      protected void nextLoad( )
      {
      }

      protected void E120X2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA0X2( ) ;
         WS0X2( ) ;
         WE0X2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202210161311691", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("inicio.js", "?202210161311692", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblScript1_Internalname = "SCRIPT1";
         edtavUsuarioemail_Internalname = "vUSUARIOEMAIL";
         lblScript2_Internalname = "SCRIPT2";
         edtavUsuariopassword_Internalname = "vUSUARIOPASSWORD";
         lblScript3_Internalname = "SCRIPT3";
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
         lblScript3_Caption = "script3";
         edtavUsuariopassword_Jsonclick = "";
         lblScript2_Caption = "script2";
         edtavUsuarioemail_Jsonclick = "";
         lblScript1_Caption = "script1";
         Form.Headerrawhtml = "";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALIDV_USUARIOEMAIL","{handler:'Validv_Usuarioemail',iparms:[]");
         setEventMetadata("VALIDV_USUARIOEMAIL",",oparms:[]}");
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
         GXKey = "";
         GX_FocusControl = "";
         sPrefix = "";
         lblScript1_Jsonclick = "";
         TempTags = "";
         AV6UsuarioEmail = "";
         lblScript2_Jsonclick = "";
         AV7UsuarioPassword = "";
         lblScript3_Jsonclick = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string lblScript1_Internalname ;
      private string lblScript1_Caption ;
      private string lblScript1_Jsonclick ;
      private string TempTags ;
      private string edtavUsuarioemail_Internalname ;
      private string edtavUsuarioemail_Jsonclick ;
      private string lblScript2_Internalname ;
      private string lblScript2_Caption ;
      private string lblScript2_Jsonclick ;
      private string edtavUsuariopassword_Internalname ;
      private string AV7UsuarioPassword ;
      private string edtavUsuariopassword_Jsonclick ;
      private string lblScript3_Internalname ;
      private string lblScript3_Caption ;
      private string lblScript3_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV6UsuarioEmail ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
