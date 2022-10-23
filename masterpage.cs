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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class masterpage : GXMasterPage, System.Web.SessionState.IRequiresSessionState
   {
      public masterpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public masterpage( IGxContext context )
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
            PA0G2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS0G2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE0G2( ) ;
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
      }

      protected void RenderHtmlCloseForm0G2( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((string)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.AddJavascriptSource("masterpage.js", "?2022102212114566", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "MasterPage" ;
      }

      public override string GetPgmdesc( )
      {
         return "Master Page" ;
      }

      protected void WB0G0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
            }
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblScript1_Internalname, lblScript1_Caption, "", "", lblScript1_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlockMaster", 0, "", 1, 1, 0, 1, "HLP_MasterPage.htm");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblScript2_Internalname, lblScript2_Caption, "", "", lblScript2_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlockMaster", 0, "", 1, 1, 0, 1, "HLP_MasterPage.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJs_Internalname, lblJs_Caption, "", "", lblJs_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_MasterPage.htm");
         }
         wbLoad = true;
      }

      protected void START0G2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0G0( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WS0G2( )
      {
         START0G2( ) ;
         EVT0G2( ) ;
      }

      protected void EVT0G2( )
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
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110G2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E120G2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
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
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE0G2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0G2( ) ;
            }
         }
      }

      protected void PA0G2( )
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
         RF0G2( ) ;
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

      protected void RF0G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E120G2 ();
            WB0G0( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes0G2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
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
         E110G2 ();
         if (returnInSub) return;
      }

      protected void E110G2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblJs_Caption = "<script type='text/javascript'>"+StringUtil.NewLine( )+"(() => {"+StringUtil.NewLine( )+"if (window.localStorage) {"+StringUtil.NewLine( )+"if (!localStorage.getItem('reload')) {"+StringUtil.NewLine( )+"localStorage['reload'] = true;"+StringUtil.NewLine( )+"window.location.reload();"+StringUtil.NewLine( )+"} else {"+StringUtil.NewLine( )+"localStorage.removeItem('reload');"+StringUtil.NewLine( )+"}"+StringUtil.NewLine( )+"}"+StringUtil.NewLine( )+"})();"+StringUtil.NewLine( )+"</script>"+StringUtil.NewLine( );
         AssignProp("", true, lblJs_Internalname, "Caption", lblJs_Caption, true);
         AV28contador1 = 0;
         AV29contador2 = 0;
         AV30contador3 = 0;
         AV26Usuarios.Load((short)(NumberUtil.Val( AV24websession.Get("UsuarioId"), ".")));
         /* Optimized group. */
         /* Using cursor H000G2 */
         pr_default.execute(0, new Object[] {AV26Usuarios.gxTpr_Usuarioid});
         cV28contador1 = H000G2_AV28contador1[0];
         pr_default.close(0);
         AV28contador1 = (short)(AV28contador1+cV28contador1*1);
         /* End optimized group. */
         /* Optimized group. */
         /* Using cursor H000G3 */
         pr_default.execute(1, new Object[] {AV26Usuarios.gxTpr_Usuarioid});
         cV30contador3 = H000G3_AV30contador3[0];
         pr_default.close(1);
         AV30contador3 = (short)(AV30contador3+cV30contador3*1);
         /* End optimized group. */
         /* Optimized group. */
         /* Using cursor H000G4 */
         pr_default.execute(2, new Object[] {AV26Usuarios.gxTpr_Usuarioid});
         cV28contador1 = H000G4_AV28contador1[0];
         pr_default.close(2);
         AV28contador1 = (short)(AV28contador1+cV28contador1*1);
         /* End optimized group. */
         /* Optimized group. */
         /* Using cursor H000G5 */
         pr_default.execute(3, new Object[] {AV26Usuarios.gxTpr_Usuarioid});
         cV29contador2 = H000G5_AV29contador2[0];
         pr_default.close(3);
         AV29contador2 = (short)(AV29contador2+cV29contador2*1);
         /* End optimized group. */
         if ( StringUtil.StrCmp(AV24websession.Get("UsuarioId"), "") == 0 )
         {
            CallWebObject(formatLink("ingreso.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV19rolid = 1;
         AV5vRuta = AV6HttpRequest.BaseURL;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1, maximum-scale=1.4, user-scalable=no\">"+StringUtil.NewLine( )+"<meta name=\"theme-color\" content=\"#343a40\">"+StringUtil.NewLine( )+"<link rel=\"icon\" type=\"image/x-icon\" href=\"Resources/valogoxs.png\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&amp;display=fallback\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"plugins/fontawesome-free/css/all.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"plugins/icheck-bootstrap/icheck-bootstrap.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"plugins/jqvmap/jqvmap.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"dist/css/adminlte.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"plugins/overlayScrollbars/css/OverlayScrollbars.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"plugins/daterangepicker/daterangepicker.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"plugins/summernote/summernote-bs4.min.css\">"+StringUtil.NewLine( )+"<style type=\"text/css\">/* Chart.js */@keyframes chartjs-render-animation{from{opacity:.99}to{opacity:1}}.chartjs-render-monitor{animation:chartjs-render-animation 1ms}.chartjs-size-monitor,.chartjs-size-monitor-expand,.chartjs-size-monitor-shrink{position:absolute;direction:ltr;left:0;top:0;right:0;bottom:0;overflow:hidden;pointer-events:none;visibility:hidden;z-index:-1}.chartjs-size-monitor-expand>div{position:absolute;width:1000000px;height:1000000px;left:0;top:0}.chartjs-size-monitor-shrink>div{position:absolute;width:200%;height:200%;left:0;top:0}</style>";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add("https://cdnjs.cloudflare.com/ajax/libs/bodymovin/5.9.6/lottie.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"plugins/jquery/jquery.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"plugins/jquery-ui/jquery-ui.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"plugins/bootstrap/js/bootstrap.bundle.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"plugins/chart.js/Chart.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"plugins/sparklines/sparkline.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"plugins/jqvmap/jquery.vmap.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"plugins/jquery-knob/jquery.knob.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"plugins/moment/moment.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"plugins/daterangepicker/daterangepicker.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"plugins/summernote/summernote-bs4.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"dist/js/adminlte.js") ;
         AV7vScript = "<div class=\"wrapper\">" + StringUtil.NewLine( ) + "<nav class=\"main-header navbar navbar-expand navbar-dark navbar-light\" style=\"border-radius:0px; margin-bottom:0px;\">" + StringUtil.NewLine( ) + "<ul class=\"navbar-nav\">" + StringUtil.NewLine( ) + "<li class=\"nav-item\">" + StringUtil.NewLine( ) + "<a class=\"nav-link\" data-widget=\"pushmenu\" href=\"#\" role=\"button\"><i class=\"fas fa-bars\" style=\"margin-left:10px;\"></i></a>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "<li class=\"nav-item d-none d-sm-inline-block\">" + StringUtil.NewLine( ) + "<a href=\"https://umg.edu.gt\" class=\"nav-link\" target=\"_blank\">Portal Universidad Mariano Gálvez</a>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "<ul class=\"navbar-nav ml-auto\">" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</nav>" + StringUtil.NewLine( ) + "<aside class=\"main-sidebar sidebar-dark-primary elevation-4\">" + StringUtil.NewLine( ) + "<a href=\"index3.html\" class=\"brand-link\">" + StringUtil.NewLine( ) + "<img src=\"umg.png\" alt=\"Tableros\" class=\"brand-image\" style=\"opacity: .8\">" + StringUtil.NewLine( ) + "<span class=\"brand-text font-weight-light\">Tableros</span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "<div class=\"sidebar os-host os-theme-light os-host-overflow os-host-overflow-y os-host-resize-disabled os-host-scrollbar-horizontal-hidden os-host-transition\"><div class=\"os-resize-observer-host observed\"><div class=\"os-resize-observer\" style=\"left: 0px; right: auto;\"></div></div><div class=\"os-size-auto-observer observed\" style=\"height: calc(100% + 1px); float: left;\"><div class=\"os-resize-observer\"></div></div><div class=\"os-content-glue\" style=\"margin: 0px -8px; width: 249px; height: 871px;\"></div><div class=\"os-padding\"><div class=\"os-viewport os-viewport-native-scrollbars-invisible\" style=\"overflow-y: scroll;\"><div class=\"os-content\" style=\"padding: 0px 8px; height: 100%; width: 100%;\">" + StringUtil.NewLine( ) + "<div class=\"user-panel mt-3 pb-3 mb-3 d-flex\">" + StringUtil.NewLine( ) + "<div class=\"image\">" + StringUtil.NewLine( ) + "<img src=\"dist/img/avatar.png\" class=\"img-circle elevation-1\" style=\"height:3.1rem; width:3.1rem;\" alt=\"User Image\">" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "<div class=\"info\">" + StringUtil.NewLine( ) + "<a href=\"#\" class=\"d-block\">" + StringUtil.Trim( AV26Usuarios.gxTpr_Usuarionombre) + " " + StringUtil.Trim( AV26Usuarios.gxTpr_Usuarioapellido) + "</a>" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "<nav class=\"mt-2\">" + StringUtil.NewLine( ) + "<ul class=\"nav nav-pills nav-sidebar flex-column\" data-widget=\"treeview\" role=\"menu\" data-accordion=\"false\">" + StringUtil.NewLine( );
         if ( AV20Config.gxTpr_Version == 1 )
         {
            AV7vScript += StringUtil.NewLine( ) + "<li class=\"nav-item\">" + StringUtil.NewLine( ) + "<a href=\"" + AV5vRuta + formatLink("links.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(1101,4,0))}, new string[] {"route"})  + "\" class=\"nav-link\">" + StringUtil.NewLine( ) + "<i class=\"nav-icon fas fa-tachometer-alt\"></i>" + StringUtil.NewLine( ) + "<p>" + StringUtil.NewLine( ) + "Dashboard" + StringUtil.NewLine( ) + "</p>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "<li class=\"nav-item\">" + StringUtil.NewLine( ) + "<a href=\"#\" class=\"nav-link\">" + StringUtil.NewLine( ) + "<i class=\"nav-icon fas fa-user\"></i>" + StringUtil.NewLine( ) + "<p>" + StringUtil.NewLine( ) + "Mi cuenta" + StringUtil.NewLine( ) + "<i class=\"right fas fa-angle-left\"></i>" + StringUtil.NewLine( ) + "</p>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "<ul class=\"nav nav-treeview\">" + StringUtil.NewLine( ) + "<li class=\"nav-item\">" + StringUtil.NewLine( ) + "<a href=\"" + AV5vRuta + formatLink("links.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(1102,4,0))}, new string[] {"route"})  + "\" class=\"nav-link\">" + StringUtil.NewLine( ) + "<i class=\"far fa-address-card nav-icon\"></i>" + StringUtil.NewLine( ) + "<p>Perfil de Usuario</p>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "<li class=\"nav-header\">TABLEROS</li>" + StringUtil.NewLine( ) + "<li class=\"nav-item\">" + StringUtil.NewLine( ) + "<a href=\"#\" class=\"nav-link\">" + StringUtil.NewLine( ) + "<i class=\"nav-icon fas fa-arrow-alt-right\"></i>" + StringUtil.NewLine( ) + "<span class=\"badge badge-info right\">" + StringUtil.Str( (decimal)(AV28contador1), 4, 0) + " </span>" + StringUtil.NewLine( ) + "<p>" + StringUtil.NewLine( ) + "Todos los tableros" + StringUtil.NewLine( ) + "<i class=\"right fas fa-angle-left\"></i>" + StringUtil.NewLine( ) + "</p>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "<ul class=\"nav nav-treeview\">" + StringUtil.NewLine( ) + "<li class=\"nav-item\" style=\"margin-left:10px;\">" + StringUtil.NewLine( ) + "<a href=\"" + AV5vRuta + formatLink("links.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(1103,4,0))}, new string[] {"route"})  + "\" class=\"nav-link\">" + StringUtil.NewLine( ) + "<i class=\"fas fa-inbox nav-icon\"></i>" + StringUtil.NewLine( ) + "<p>Mis tableros</p>" + StringUtil.NewLine( ) + "<span class=\"badge badge-secondary right\">" + StringUtil.Str( (decimal)(AV30contador3), 4, 0) + "</span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "<li class=\"nav-item\" style=\"margin-left:10px;\">" + StringUtil.NewLine( ) + "<a href=\"" + AV5vRuta + formatLink("links.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(1104,4,0))}, new string[] {"route"})  + "\" class=\"nav-link\">" + StringUtil.NewLine( ) + "<i class=\"fas fa-star nav-icon\"></i>" + StringUtil.NewLine( ) + "<p>Tableros de invitado</p>" + StringUtil.NewLine( ) + "<span class=\"badge badge-secondary right\">" + StringUtil.Str( (decimal)(AV29contador2), 4, 0) + "</span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "<li class=\"nav-item\">" + StringUtil.NewLine( ) + "<a href=\"#\" class=\"nav-link\">" + StringUtil.NewLine( ) + "<i class=\"nav-icon fas fa-sign-out-alt\"></i>" + StringUtil.NewLine( ) + "<p>" + StringUtil.NewLine( ) + "Salir" + StringUtil.NewLine( ) + "<i class=\"right fas fa-angle-left\"></i>" + StringUtil.NewLine( ) + "</p>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "<ul class=\"nav nav-treeview\">" + StringUtil.NewLine( ) + "<li class=\"nav-item\" style=\"margin-left:10px;\">" + StringUtil.NewLine( ) + "<a href=\"" + AV5vRuta + formatLink("links.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(1105,4,0))}, new string[] {"route"})  + "\" class=\"nav-link\">" + StringUtil.NewLine( ) + "<i class=\"far fa-power-off nav-icon\"></i>" + StringUtil.NewLine( ) + "<p>Cerrar sesión</p>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( );
         }
         AV7vScript += StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</nav>" + StringUtil.NewLine( ) + "</div></div></div><div class=\"os-scrollbar os-scrollbar-horizontal os-scrollbar-unusable os-scrollbar-auto-hidden\"><div class=\"os-scrollbar-track\"><div class=\"os-scrollbar-handle\" style=\"width: 100%; transform: translate(0px, 0px);\"></div></div></div><div class=\"os-scrollbar os-scrollbar-vertical os-scrollbar-auto-hidden\"><div class=\"os-scrollbar-track\"><div class=\"os-scrollbar-handle\" style=\"height: 64.1648%; transform: translate(0px, 0px);\"></div></div></div><div class=\"os-scrollbar-corner\"></div></div>" + StringUtil.NewLine( ) + "</aside>" + StringUtil.NewLine( ) + "<div class=\"content-wrapper\" style=\"min-height: 815px;\">" + StringUtil.NewLine( ) + "<!-- Content Header (Page header) -->" + StringUtil.NewLine( ) + "<section class=\"content-header\">" + StringUtil.NewLine( ) + "<div class=\"container-fluid\">" + StringUtil.NewLine( ) + "<div class=\"row mb-2\">" + StringUtil.NewLine( ) + "<div class=\"col-sm-6\">" + StringUtil.NewLine( ) + "<h1>" + (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption + "</h1>" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "<div class=\"col-sm-6\">" + StringUtil.NewLine( ) + "<ol class=\"breadcrumb float-sm-right\">" + StringUtil.NewLine( ) + "<li class=\"breadcrumb-item\"><a href=\"paginadeinicio.aspx\"><i class=\"fas fa-home\"></i></a></li>" + StringUtil.NewLine( ) + "<li class=\"breadcrumb-item active\">" + (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption + "</li>" + StringUtil.NewLine( ) + "</ol>" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "</div><!-- /.container-fluid -->" + StringUtil.NewLine( ) + "</section>" + StringUtil.NewLine( ) + "<!-- Main content -->" + StringUtil.NewLine( ) + "<section class=\"content\">" + StringUtil.NewLine( ) + "<div class=\"container-fluid\">" + StringUtil.NewLine( ) + "<div class=\"row\">" + StringUtil.NewLine( );
         AV8vScript2 = "</div>" + StringUtil.NewLine( ) + "</section>" + StringUtil.NewLine( ) + "<!-- /.content -->" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "<footer class=\"main-footer\">" + StringUtil.NewLine( ) + "<strong><a href=\"https://umg.edu.gt\" target=\"_blank\">Universidad Mariano Gálvez de Guatemala</a> © 2022 </strong>" + StringUtil.NewLine( ) + "Todos los derechos reservados" + StringUtil.NewLine( ) + "<div class=\"float-right d-none d-sm-inline-block\">" + StringUtil.NewLine( ) + "<b>Version</b> 1.0.0" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "</footer>" + StringUtil.NewLine( );
         lblScript1_Caption = AV7vScript;
         AssignProp("", true, lblScript1_Internalname, "Caption", lblScript1_Caption, true);
         lblScript2_Caption = AV8vScript2;
         AssignProp("", true, lblScript2_Internalname, "Caption", lblScript2_Caption, true);
      }

      protected void nextLoad( )
      {
      }

      protected void E120G2( )
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
         PA0G2( ) ;
         WS0G2( ) ;
         WE0G2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
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
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?2022102212114572", true, true);
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
            context.AddJavascriptSource("masterpage.js", "?2022102212114572", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblScript1_Internalname = "SCRIPT1_MPAGE";
         lblScript2_Internalname = "SCRIPT2_MPAGE";
         lblJs_Internalname = "JS_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         lblJs_Caption = "js";
         lblScript2_Jsonclick = "";
         lblScript2_Caption = "Script2";
         lblScript1_Jsonclick = "";
         lblScript1_Caption = "Script1";
         Contholder1.setDataArea(getDataAreaObject());
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
         setEventMetadata("REFRESH_MPAGE","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH_MPAGE",",oparms:[]}");
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
         Contholder1 = new GXDataAreaControl();
         GXKey = "";
         sPrefix = "";
         lblJs_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV26Usuarios = new SdtUsuarios(context);
         AV24websession = context.GetSession();
         scmdbuf = "";
         H000G2_AV28contador1 = new short[1] ;
         H000G3_AV30contador3 = new short[1] ;
         H000G4_AV28contador1 = new short[1] ;
         H000G5_AV29contador2 = new short[1] ;
         AV5vRuta = "";
         AV6HttpRequest = new GxHttpRequest( context);
         AV7vScript = "";
         AV20Config = new SdtConfig(context);
         AV8vScript2 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.masterpage__default(),
            new Object[][] {
                new Object[] {
               H000G2_AV28contador1
               }
               , new Object[] {
               H000G3_AV30contador3
               }
               , new Object[] {
               H000G4_AV28contador1
               }
               , new Object[] {
               H000G5_AV29contador2
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short initialized ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV28contador1 ;
      private short AV29contador2 ;
      private short AV30contador3 ;
      private short cV28contador1 ;
      private short cV30contador3 ;
      private short cV29contador2 ;
      private short AV19rolid ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int idxLst ;
      private string GXKey ;
      private string sPrefix ;
      private string lblScript1_Internalname ;
      private string lblScript1_Caption ;
      private string lblScript1_Jsonclick ;
      private string lblScript2_Internalname ;
      private string lblScript2_Caption ;
      private string lblScript2_Jsonclick ;
      private string lblJs_Internalname ;
      private string lblJs_Caption ;
      private string lblJs_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string sDynURL ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV7vScript ;
      private string AV8vScript2 ;
      private string AV5vRuta ;
      private IGxSession AV24websession ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contholder1 ;
      private IDataStoreProvider pr_default ;
      private short[] H000G2_AV28contador1 ;
      private short[] H000G3_AV30contador3 ;
      private short[] H000G4_AV28contador1 ;
      private short[] H000G5_AV29contador2 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV6HttpRequest ;
      private GXWebForm Form ;
      private SdtConfig AV20Config ;
      private SdtUsuarios AV26Usuarios ;
   }

   public class masterpage__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000G2;
          prmH000G2 = new Object[] {
          new ParDef("@AV26Usuarios__Usuarioid",GXType.Int16,4,0)
          };
          Object[] prmH000G3;
          prmH000G3 = new Object[] {
          new ParDef("@AV26Usuarios__Usuarioid",GXType.Int16,4,0)
          };
          Object[] prmH000G4;
          prmH000G4 = new Object[] {
          new ParDef("@AV26Usuarios__Usuarioid",GXType.Int16,4,0)
          };
          Object[] prmH000G5;
          prmH000G5 = new Object[] {
          new ParDef("@AV26Usuarios__Usuarioid",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000G2", "SELECT COUNT(*) FROM [Tableros] WHERE [PropietarioId] = @AV26Usuarios__Usuarioid ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000G3", "SELECT COUNT(*) FROM [Tableros] WHERE [PropietarioId] = @AV26Usuarios__Usuarioid ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000G4", "SELECT COUNT(*) FROM [Participantes] WHERE [ParticipanteTableroId] = @AV26Usuarios__Usuarioid ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000G5", "SELECT COUNT(*) FROM [Participantes] WHERE [ParticipanteTableroId] = @AV26Usuarios__Usuarioid ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G5,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
