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
   public class sininiciarwc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public sininiciarwc( )
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

      public sininiciarwc( IGxContext context )
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
         cmbavParticipantetableroid = new GXCombobox();
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridtareas1") == 0 )
               {
                  gxnrGridtareas1_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridtareas1") == 0 )
               {
                  gxgrGridtareas1_refresh_invoke( ) ;
                  return  ;
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

      protected void gxnrGridtareas1_newrow_invoke( )
      {
         nRC_GXsfl_15 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_15"), "."));
         nGXsfl_15_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_15_idx"), "."));
         sGXsfl_15_idx = GetPar( "sGXsfl_15_idx");
         sPrefix = GetPar( "sPrefix");
         AV8ParticipanteTableroId = (short)(NumberUtil.Val( GetPar( "ParticipanteTableroId"), "."));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridtareas1_newrow( ) ;
         /* End function gxnrGridtareas1_newrow_invoke */
      }

      protected void gxgrGridtareas1_refresh_invoke( )
      {
         A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
         A18ParticipanteTableroId = (short)(NumberUtil.Val( GetPar( "ParticipanteTableroId"), "."));
         cmbavParticipantetableroid.FromJSonString( GetNextPar( ));
         AV8ParticipanteTableroId = (short)(NumberUtil.Val( GetPar( "ParticipanteTableroId"), "."));
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridtareas1_refresh( A9TableroId, A18ParticipanteTableroId, AV8ParticipanteTableroId, Gx_date, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridtareas1_refresh_invoke */
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
            PA0Z2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               Gx_date = DateTimeUtil.Today( context);
               context.Gx_err = 0;
               edtTareaId_Visible = 0;
               AssignProp(sPrefix, false, edtTareaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTareaId_Visible), 5, 0), !bGXsfl_15_Refreshing);
               WS0Z2( ) ;
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
            context.SendWebValue( "Sin Iniciar WC") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sininiciarwc.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0))}, new string[] {"TableroId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA9TableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTODAY", GetSecureSignedToken( sPrefix, Gx_date, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_SA", AV10sdt_sa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_SA", AV10sdt_sa);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"PARTICIPANTETABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18ParticipanteTableroId), 4, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm0Z2( )
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
            if ( ! ( WebComp_Tareas1 == null ) )
            {
               WebComp_Tareas1.componentjscripts();
            }
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
         return "SinIniciarWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Sin Iniciar WC" ;
      }

      protected void WB0Z0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "sininiciarwc.aspx");
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divT1_Internalname, 1, 0, "px", 0, "px", divT1_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "92d529e9-27c5-4aa5-ba80-12d22ecdf0fc", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 50, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SinIniciarWC.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitulo1_Internalname, lblTitulo1_Caption, "", "", lblTitulo1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_SinIniciarWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Gridtareas1Container.SetIsFreestyle(true);
            Gridtareas1Container.SetWrapped(nGXWrapped);
            StartGridControl15( ) ;
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
            if ( Gridtareas1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Gridtareas1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridtareas1", Gridtareas1Container, subGridtareas1_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridtareas1ContainerData", Gridtareas1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridtareas1ContainerData"+"V", Gridtareas1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridtareas1ContainerData"+"V"+"\" value='"+Gridtareas1Container.GridValuesHidden()+"'/>") ;
               }
            }
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
            ucRamp_addons_sweetalert1.Render(context, "ramp_addons_sweetalert", Ramp_addons_sweetalert1_Internalname, sPrefix+"RAMP_ADDONS_SWEETALERT1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridtareas1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Gridtareas1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridtareas1", Gridtareas1Container, subGridtareas1_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridtareas1ContainerData", Gridtareas1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridtareas1ContainerData"+"V", Gridtareas1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridtareas1ContainerData"+"V"+"\" value='"+Gridtareas1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0Z2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_11-163677", 0) ;
               }
               Form.Meta.addItem("description", "Sin Iniciar WC", 0) ;
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
               STRUP0Z0( ) ;
            }
         }
      }

      protected void WS0Z2( )
      {
         START0Z2( ) ;
         EVT0Z2( ) ;
      }

      protected void EVT0Z2( )
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
                                 STRUP0Z0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "GRIDTAREAS1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "GRIDTAREAS1.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'INICIAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'ASIGNAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'ANADIRASIGNACION'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'CANCELAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'INICIAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'ASIGNAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'PAUSAPLAY'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'ANADIRASIGNACION'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'CANCELAR'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Z0( ) ;
                              }
                              nGXsfl_15_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              AV12state2 = cgiGet( edtavState2_Internalname);
                              AssignProp(sPrefix, false, edtavState2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12state2)) ? AV25State2_GXI : context.convertURL( context.PathToRelativeUrl( AV12state2))), !bGXsfl_15_Refreshing);
                              AssignProp(sPrefix, false, edtavState2_Internalname, "SrcSet", context.GetImageSrcSet( AV12state2), true);
                              AV11state = cgiGet( edtavState_Internalname);
                              AssignProp(sPrefix, false, edtavState_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV11state)) ? AV24State_GXI : context.convertURL( context.PathToRelativeUrl( AV11state))), !bGXsfl_15_Refreshing);
                              AssignProp(sPrefix, false, edtavState_Internalname, "SrcSet", context.GetImageSrcSet( AV11state), true);
                              AV5asignar = cgiGet( edtavAsignar_Internalname);
                              AssignProp(sPrefix, false, edtavAsignar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)) ? AV23Asignar_GXI : context.convertURL( context.PathToRelativeUrl( AV5asignar))), !bGXsfl_15_Refreshing);
                              AssignProp(sPrefix, false, edtavAsignar_Internalname, "SrcSet", context.GetImageSrcSet( AV5asignar), true);
                              AV6comentarios = cgiGet( edtavComentarios_Internalname);
                              AssignProp(sPrefix, false, edtavComentarios_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV22Comentarios_GXI : context.convertURL( context.PathToRelativeUrl( AV6comentarios))), !bGXsfl_15_Refreshing);
                              AssignProp(sPrefix, false, edtavComentarios_Internalname, "SrcSet", context.GetImageSrcSet( AV6comentarios), true);
                              AV13stop = cgiGet( edtavStop_Internalname);
                              AssignProp(sPrefix, false, edtavStop_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13stop)) ? AV26Stop_GXI : context.convertURL( context.PathToRelativeUrl( AV13stop))), !bGXsfl_15_Refreshing);
                              AssignProp(sPrefix, false, edtavStop_Internalname, "SrcSet", context.GetImageSrcSet( AV13stop), true);
                              cmbavParticipantetableroid.Name = cmbavParticipantetableroid_Internalname;
                              cmbavParticipantetableroid.CurrentValue = cgiGet( cmbavParticipantetableroid_Internalname);
                              AV8ParticipanteTableroId = (short)(NumberUtil.Val( cgiGet( cmbavParticipantetableroid_Internalname), "."));
                              AssignAttri(sPrefix, false, cmbavParticipantetableroid_Internalname, StringUtil.LTrimStr( (decimal)(AV8ParticipanteTableroId), 4, 0));
                              A12TareaId = (short)(context.localUtil.CToN( cgiGet( edtTareaId_Internalname), ",", "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E110Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDTAREAS1.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E120Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDTAREAS1.REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E130Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'INICIAR'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Iniciar' */
                                          E140Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'ASIGNAR'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Asignar' */
                                          E150Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E160Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'ANADIRASIGNACION'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'AnadirAsignacion' */
                                          E170Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'CANCELAR'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Cancelar' */
                                          E180Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
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
                                 else if ( StringUtil.StrCmp(sEvt, "'PAUSAPLAY'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP0Z0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 67 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0067" + sEvtType;
                           OldTareas1 = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldTareas1) == 0 ) || ( StringUtil.StrCmp(OldTareas1, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldTareas1, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldTareas1";
                              WebComp_GX_Process_Component = OldTareas1;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0067", sEvtType, sEvt);
                           }
                           nGXsfl_15_webc_idx = (int)(NumberUtil.Val( sEvtType, "."));
                           WebCompHandler = "Tareas1";
                           WebComp_GX_Process_Component = OldTareas1;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0Z2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0Z2( ) ;
            }
         }
      }

      protected void PA0Z2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridtareas1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subGridtareas1_Islastpage==1)&&(nGXsfl_15_idx+1>subGridtareas1_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridtareas1Container)) ;
         /* End function gxnrGridtareas1_newrow */
      }

      protected void gxgrGridtareas1_refresh( short A9TableroId ,
                                              short A18ParticipanteTableroId ,
                                              short AV8ParticipanteTableroId ,
                                              DateTime Gx_date ,
                                              string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E160Z2 ();
         GRIDTAREAS1_nCurrentRecord = 0;
         RF0Z2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridtareas1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_TAREAID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"TAREAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ".", "")));
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
         /* Execute user event: Refresh */
         E160Z2 ();
         RF0Z2( ) ;
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
         edtTareaId_Visible = 0;
         AssignProp(sPrefix, false, edtTareaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTareaId_Visible), 5, 0), !bGXsfl_15_Refreshing);
      }

      protected void RF0Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridtareas1Container.ClearRows();
         }
         wbStart = 15;
         E130Z2 ();
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
         Gridtareas1Container.AddObjectProperty("GridName", "Gridtareas1");
         Gridtareas1Container.AddObjectProperty("CmpContext", sPrefix);
         Gridtareas1Container.AddObjectProperty("InMasterPage", "false");
         Gridtareas1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Gridtareas1Container.AddObjectProperty("Class", "FreeStyleGrid");
         Gridtareas1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridtareas1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridtareas1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas1_Backcolorstyle), 1, 0, ".", "")));
         Gridtareas1Container.PageSize = subGridtareas1_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Tareas1_Component, "") == 0 )
            {
               WebComp_Tareas1 = getWebComponent(GetType(), "GeneXus.Programs", "listadoactividades", new Object[] {context} );
               WebComp_Tareas1.ComponentInit();
               WebComp_Tareas1.Name = "ListadoActividades";
               WebComp_Tareas1_Component = "ListadoActividades";
            }
            WebComp_Tareas1.setjustcreated();
            WebComp_Tareas1.componentprepare(new Object[] {(string)sPrefix+"W0067",(string)sGXsfl_15_idx,(short)A9TableroId,(short)A12TareaId});
            WebComp_Tareas1.componentbind(new Object[] {(string)"",(string)""});
            if ( 1 != 0 )
            {
               WebComp_Tareas1.componentstart();
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_152( ) ;
            /* Using cursor H000Z2 */
            pr_default.execute(0, new Object[] {A9TableroId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A46TareaEstado = H000Z2_A46TareaEstado[0];
               A12TareaId = H000Z2_A12TareaId[0];
               A24TareaFechaInicio = H000Z2_A24TareaFechaInicio[0];
               E120Z2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 15;
            WB0Z0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Z2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTODAY", GetSecureSignedToken( sPrefix, Gx_date, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_TAREAID"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9"), context));
      }

      protected int subGridtareas1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridtareas1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridtareas1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridtareas1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
         edtTareaId_Visible = 0;
         AssignProp(sPrefix, false, edtTareaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTareaId_Visible), 5, 0), !bGXsfl_15_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110Z2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), ",", "."));
            wcpOA9TableroId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA9TableroId"), ",", "."));
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
         E110Z2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblTitulo1_Caption = "<h3><center><strong><font color=\"white\">Sin iniciar</font></strong></center></h3>";
         AssignProp(sPrefix, false, lblTitulo1_Internalname, "Caption", lblTitulo1_Caption, true);
         divT1_Class = "TablaDo";
         AssignProp(sPrefix, false, divT1_Internalname, "Class", divT1_Class, true);
         tblAsignacion_Visible = 0;
         AssignProp(sPrefix, false, tblAsignacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblAsignacion_Visible), 5, 0), !bGXsfl_15_Refreshing);
         /* Using cursor H000Z3 */
         pr_default.execute(1, new Object[] {A9TableroId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A18ParticipanteTableroId = H000Z3_A18ParticipanteTableroId[0];
            AV17U2.Load(A18ParticipanteTableroId);
            cmbavParticipantetableroid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV17U2.gxTpr_Usuarioid), 4, 0)), AV17U2.gxTpr_Usuarionombre+" "+AV17U2.gxTpr_Usuarioapellido, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      private void E120Z2( )
      {
         /* Gridtareas1_Load Routine */
         returnInSub = false;
         tblAsignacion_Visible = 0;
         AssignProp(sPrefix, false, tblAsignacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblAsignacion_Visible), 5, 0), !bGXsfl_15_Refreshing);
         AV14T1.Load(A9TableroId, A12TareaId);
         AV7contador = 0;
         /* Optimized group. */
         /* Using cursor H000Z4 */
         pr_default.execute(2, new Object[] {A9TableroId, A12TareaId});
         cV7contador = H000Z4_AV7contador[0];
         pr_default.close(2);
         AV7contador = (short)(AV7contador+cV7contador*1);
         /* End optimized group. */
         if ( AV7contador == 0 )
         {
            AV6comentarios = context.GetImagePath( "5a6feed5-8387-48bc-85cf-286b0f156319", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavComentarios_Internalname, AV6comentarios);
            AV22Comentarios_GXI = GXDbFile.PathToUrl( context.GetImagePath( "5a6feed5-8387-48bc-85cf-286b0f156319", "", context.GetTheme( )));
            edtavComentarios_Tooltiptext = "No tienes comentarios en esta tarea";
         }
         else
         {
            AV6comentarios = context.GetImagePath( "35c79c23-07c3-4fb0-9ce5-01610bd903e5", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavComentarios_Internalname, AV6comentarios);
            AV22Comentarios_GXI = GXDbFile.PathToUrl( context.GetImagePath( "35c79c23-07c3-4fb0-9ce5-01610bd903e5", "", context.GetTheme( )));
            edtavComentarios_Tooltiptext = "Tienes "+StringUtil.Trim( StringUtil.Str( (decimal)(AV7contador), 4, 0))+" comentario(s) en esta tarea";
         }
         if ( (0==AV14T1.gxTpr_Responsableid) )
         {
            AV5asignar = context.GetImagePath( "20877732-78d2-44fd-ba33-6513f758b3b0", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavAsignar_Internalname, AV5asignar);
            AV23Asignar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "20877732-78d2-44fd-ba33-6513f758b3b0", "", context.GetTheme( )));
         }
         else
         {
            AV5asignar = context.GetImagePath( "949e9232-fe17-4603-8cb8-0a57d2612676", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavAsignar_Internalname, AV5asignar);
            AV23Asignar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "949e9232-fe17-4603-8cb8-0a57d2612676", "", context.GetTheme( )));
         }
         if ( AV14T1.gxTpr_Responsableid != 0 )
         {
            AV11state = context.GetImagePath( "31259d64-c015-4774-9b0a-b45a79c24159", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState_Internalname, AV11state);
            AV24State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "31259d64-c015-4774-9b0a-b45a79c24159", "", context.GetTheme( )));
            AV16U1.Load(AV14T1.gxTpr_Responsableid);
            AV9responsable = StringUtil.Trim( AV16U1.gxTpr_Usuarioemail) + " - " + StringUtil.Trim( AV16U1.gxTpr_Usuarionombre) + " " + StringUtil.Trim( AV16U1.gxTpr_Usuarioapellido);
         }
         else
         {
            AV11state = context.GetImagePath( "af695a2d-efff-4893-90bc-55652acff52a", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState_Internalname, AV11state);
            AV24State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "af695a2d-efff-4893-90bc-55652acff52a", "", context.GetTheme( )));
            AV9responsable = "Sin responsable asignado";
         }
         if ( AV14T1.gxTpr_Tareaestado == 1 )
         {
            AV12state2 = context.GetImagePath( "1ecaff01-3fe8-49d0-9094-76c163a69ce8", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState2_Internalname, AV12state2);
            AV25State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "1ecaff01-3fe8-49d0-9094-76c163a69ce8", "", context.GetTheme( )));
            edtavStop_Visible = 0;
         }
         else if ( AV14T1.gxTpr_Tareaestado == 2 )
         {
            AV12state2 = context.GetImagePath( "9eed16cc-502d-4c66-a4e5-f47a9713bab0", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState2_Internalname, AV12state2);
            AV25State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "9eed16cc-502d-4c66-a4e5-f47a9713bab0", "", context.GetTheme( )));
            edtavStop_Visible = 1;
            AV13stop = context.GetImagePath( "2ac86f64-1ec7-466f-b8c7-066988857016", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavStop_Internalname, AV13stop);
            AV26Stop_GXI = GXDbFile.PathToUrl( context.GetImagePath( "2ac86f64-1ec7-466f-b8c7-066988857016", "", context.GetTheme( )));
         }
         else if ( AV14T1.gxTpr_Tareaestado == 3 )
         {
            AV12state2 = context.GetImagePath( "63552255-35ba-4e00-8b53-9539f5d32760", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState2_Internalname, AV12state2);
            AV25State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "63552255-35ba-4e00-8b53-9539f5d32760", "", context.GetTheme( )));
            edtavStop_Visible = 0;
         }
         else if ( AV14T1.gxTpr_Tareaestado == 4 )
         {
            AV12state2 = context.GetImagePath( "cef39daf-d9a8-462d-9b0c-f8b6056364e8", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState2_Internalname, AV12state2);
            AV25State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "cef39daf-d9a8-462d-9b0c-f8b6056364e8", "", context.GetTheme( )));
            edtavStop_Visible = 1;
            AV13stop = context.GetImagePath( "e18fac27-0e75-4842-8560-9dfaa60d377c", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavStop_Internalname, AV13stop);
            AV26Stop_GXI = GXDbFile.PathToUrl( context.GetImagePath( "e18fac27-0e75-4842-8560-9dfaa60d377c", "", context.GetTheme( )));
         }
         if ( ( DateTimeUtil.ResetTime ( AV14T1.gxTpr_Tareafechainicio ) <= DateTimeUtil.ResetTime ( Gx_date ) ) && ( AV14T1.gxTpr_Tareaestado == 1 ) && ( DateTimeUtil.ResetTime ( AV14T1.gxTpr_Tareafechafin ) > DateTimeUtil.ResetTime ( Gx_date ) ) )
         {
            lblAdvisor_Caption = "<div class=\"alert alert-warning\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>Debes iniciar y terminar la tarea antes de la fecha de finalización."+StringUtil.NewLine( )+"</div>";
         }
         else if ( DateTimeUtil.ResetTime ( AV14T1.gxTpr_Tareafechafin ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            lblAdvisor_Caption = "<div class=\"alert alert-danger\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>La tarea ha vencido.  Completala o cambia las fechas de finalización"+StringUtil.NewLine( )+"</div>";
         }
         else if ( DateTimeUtil.ResetTime ( AV14T1.gxTpr_Tareafechafin ) == DateTimeUtil.ResetTime ( Gx_date ) )
         {
            lblAdvisor_Caption = "<div class=\"alert alert-info\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>La tarea se vencerá hoy.  Debes completar esta tarea antes de la fecha de finalización"+StringUtil.NewLine( )+"</div>";
         }
         else
         {
            lblAdvisor_Caption = "";
         }
         lblNombre1_Caption = "<center><h3><strong>"+StringUtil.Trim( AV14T1.gxTpr_Tareanombre)+"</strong></h3><h5>"+StringUtil.Trim( AV9responsable)+"</h5></center>";
         lblInicia_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         lblInicia_Caption = StringUtil.StringReplace( lblInicia_Caption, "#VALUE", context.localUtil.DToC( AV14T1.gxTpr_Tareafechainicio, 2, "/"));
         lblInicia_Caption = StringUtil.StringReplace( lblInicia_Caption, "#LABEL", "Inicia");
         lblFinaliza_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         lblFinaliza_Caption = StringUtil.StringReplace( lblFinaliza_Caption, "#VALUE", context.localUtil.DToC( AV14T1.gxTpr_Tareafechafin, 2, "/"));
         lblFinaliza_Caption = StringUtil.StringReplace( lblFinaliza_Caption, "#LABEL", "Finaliza");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            context.DoAjaxLoad(15, Gridtareas1Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E130Z2( )
      {
         /* Gridtareas1_Refresh Routine */
         returnInSub = false;
         tblAsignacion_Visible = 0;
         AssignProp(sPrefix, false, tblAsignacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblAsignacion_Visible), 5, 0), !bGXsfl_15_Refreshing);
         AV14T1.Load(A9TableroId, A12TareaId);
         AV7contador = 0;
         /* Optimized group. */
         /* Using cursor H000Z5 */
         pr_default.execute(3, new Object[] {A9TableroId, A12TareaId});
         cV7contador = H000Z5_AV7contador[0];
         pr_default.close(3);
         AV7contador = (short)(AV7contador+cV7contador*1);
         /* End optimized group. */
         if ( AV7contador == 0 )
         {
            AV6comentarios = context.GetImagePath( "5a6feed5-8387-48bc-85cf-286b0f156319", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV22Comentarios_GXI : context.convertURL( context.PathToRelativeUrl( AV6comentarios))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "SrcSet", context.GetImageSrcSet( AV6comentarios), true);
            AV22Comentarios_GXI = GXDbFile.PathToUrl( context.GetImagePath( "5a6feed5-8387-48bc-85cf-286b0f156319", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV22Comentarios_GXI : context.convertURL( context.PathToRelativeUrl( AV6comentarios))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "SrcSet", context.GetImageSrcSet( AV6comentarios), true);
            edtavComentarios_Tooltiptext = "No tienes comentarios en esta tarea";
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "Tooltiptext", edtavComentarios_Tooltiptext, !bGXsfl_15_Refreshing);
         }
         else
         {
            AV6comentarios = context.GetImagePath( "35c79c23-07c3-4fb0-9ce5-01610bd903e5", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV22Comentarios_GXI : context.convertURL( context.PathToRelativeUrl( AV6comentarios))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "SrcSet", context.GetImageSrcSet( AV6comentarios), true);
            AV22Comentarios_GXI = GXDbFile.PathToUrl( context.GetImagePath( "35c79c23-07c3-4fb0-9ce5-01610bd903e5", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV22Comentarios_GXI : context.convertURL( context.PathToRelativeUrl( AV6comentarios))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "SrcSet", context.GetImageSrcSet( AV6comentarios), true);
            edtavComentarios_Tooltiptext = "Tienes "+StringUtil.Trim( StringUtil.Str( (decimal)(AV7contador), 4, 0))+" comentario(s) en esta tarea";
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "Tooltiptext", edtavComentarios_Tooltiptext, !bGXsfl_15_Refreshing);
         }
         if ( (0==AV14T1.gxTpr_Responsableid) )
         {
            AV5asignar = context.GetImagePath( "20877732-78d2-44fd-ba33-6513f758b3b0", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)) ? AV23Asignar_GXI : context.convertURL( context.PathToRelativeUrl( AV5asignar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "SrcSet", context.GetImageSrcSet( AV5asignar), true);
            AV23Asignar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "20877732-78d2-44fd-ba33-6513f758b3b0", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)) ? AV23Asignar_GXI : context.convertURL( context.PathToRelativeUrl( AV5asignar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "SrcSet", context.GetImageSrcSet( AV5asignar), true);
         }
         else
         {
            AV5asignar = context.GetImagePath( "949e9232-fe17-4603-8cb8-0a57d2612676", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)) ? AV23Asignar_GXI : context.convertURL( context.PathToRelativeUrl( AV5asignar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "SrcSet", context.GetImageSrcSet( AV5asignar), true);
            AV23Asignar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "949e9232-fe17-4603-8cb8-0a57d2612676", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)) ? AV23Asignar_GXI : context.convertURL( context.PathToRelativeUrl( AV5asignar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "SrcSet", context.GetImageSrcSet( AV5asignar), true);
         }
         if ( AV14T1.gxTpr_Responsableid != 0 )
         {
            AV11state = context.GetImagePath( "31259d64-c015-4774-9b0a-b45a79c24159", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavState_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV11state)) ? AV24State_GXI : context.convertURL( context.PathToRelativeUrl( AV11state))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavState_Internalname, "SrcSet", context.GetImageSrcSet( AV11state), true);
            AV24State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "31259d64-c015-4774-9b0a-b45a79c24159", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavState_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV11state)) ? AV24State_GXI : context.convertURL( context.PathToRelativeUrl( AV11state))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavState_Internalname, "SrcSet", context.GetImageSrcSet( AV11state), true);
            AV16U1.Load(AV14T1.gxTpr_Responsableid);
            AV9responsable = StringUtil.Trim( AV16U1.gxTpr_Usuarioemail) + " - " + StringUtil.Trim( AV16U1.gxTpr_Usuarionombre) + " " + StringUtil.Trim( AV16U1.gxTpr_Usuarioapellido);
         }
         else
         {
            AV11state = context.GetImagePath( "af695a2d-efff-4893-90bc-55652acff52a", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavState_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV11state)) ? AV24State_GXI : context.convertURL( context.PathToRelativeUrl( AV11state))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavState_Internalname, "SrcSet", context.GetImageSrcSet( AV11state), true);
            AV24State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "af695a2d-efff-4893-90bc-55652acff52a", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavState_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV11state)) ? AV24State_GXI : context.convertURL( context.PathToRelativeUrl( AV11state))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavState_Internalname, "SrcSet", context.GetImageSrcSet( AV11state), true);
            AV9responsable = "Sin responsable asignado";
         }
         if ( AV14T1.gxTpr_Tareaestado == 1 )
         {
            AV12state2 = context.GetImagePath( "1ecaff01-3fe8-49d0-9094-76c163a69ce8", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavState2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12state2)) ? AV25State2_GXI : context.convertURL( context.PathToRelativeUrl( AV12state2))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavState2_Internalname, "SrcSet", context.GetImageSrcSet( AV12state2), true);
            AV25State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "1ecaff01-3fe8-49d0-9094-76c163a69ce8", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavState2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12state2)) ? AV25State2_GXI : context.convertURL( context.PathToRelativeUrl( AV12state2))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavState2_Internalname, "SrcSet", context.GetImageSrcSet( AV12state2), true);
            edtavStop_Visible = 0;
            AssignProp(sPrefix, false, edtavStop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStop_Visible), 5, 0), !bGXsfl_15_Refreshing);
         }
         else if ( AV14T1.gxTpr_Tareaestado == 2 )
         {
            AV12state2 = context.GetImagePath( "9eed16cc-502d-4c66-a4e5-f47a9713bab0", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavState2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12state2)) ? AV25State2_GXI : context.convertURL( context.PathToRelativeUrl( AV12state2))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavState2_Internalname, "SrcSet", context.GetImageSrcSet( AV12state2), true);
            AV25State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "9eed16cc-502d-4c66-a4e5-f47a9713bab0", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavState2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12state2)) ? AV25State2_GXI : context.convertURL( context.PathToRelativeUrl( AV12state2))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavState2_Internalname, "SrcSet", context.GetImageSrcSet( AV12state2), true);
            edtavStop_Visible = 1;
            AssignProp(sPrefix, false, edtavStop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStop_Visible), 5, 0), !bGXsfl_15_Refreshing);
            AV13stop = context.GetImagePath( "2ac86f64-1ec7-466f-b8c7-066988857016", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavStop_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13stop)) ? AV26Stop_GXI : context.convertURL( context.PathToRelativeUrl( AV13stop))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavStop_Internalname, "SrcSet", context.GetImageSrcSet( AV13stop), true);
            AV26Stop_GXI = GXDbFile.PathToUrl( context.GetImagePath( "2ac86f64-1ec7-466f-b8c7-066988857016", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavStop_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13stop)) ? AV26Stop_GXI : context.convertURL( context.PathToRelativeUrl( AV13stop))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavStop_Internalname, "SrcSet", context.GetImageSrcSet( AV13stop), true);
         }
         else if ( AV14T1.gxTpr_Tareaestado == 3 )
         {
            AV12state2 = context.GetImagePath( "63552255-35ba-4e00-8b53-9539f5d32760", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavState2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12state2)) ? AV25State2_GXI : context.convertURL( context.PathToRelativeUrl( AV12state2))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavState2_Internalname, "SrcSet", context.GetImageSrcSet( AV12state2), true);
            AV25State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "63552255-35ba-4e00-8b53-9539f5d32760", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavState2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12state2)) ? AV25State2_GXI : context.convertURL( context.PathToRelativeUrl( AV12state2))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavState2_Internalname, "SrcSet", context.GetImageSrcSet( AV12state2), true);
            edtavStop_Visible = 0;
            AssignProp(sPrefix, false, edtavStop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStop_Visible), 5, 0), !bGXsfl_15_Refreshing);
         }
         else if ( AV14T1.gxTpr_Tareaestado == 4 )
         {
            AV12state2 = context.GetImagePath( "cef39daf-d9a8-462d-9b0c-f8b6056364e8", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavState2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12state2)) ? AV25State2_GXI : context.convertURL( context.PathToRelativeUrl( AV12state2))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavState2_Internalname, "SrcSet", context.GetImageSrcSet( AV12state2), true);
            AV25State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "cef39daf-d9a8-462d-9b0c-f8b6056364e8", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavState2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12state2)) ? AV25State2_GXI : context.convertURL( context.PathToRelativeUrl( AV12state2))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavState2_Internalname, "SrcSet", context.GetImageSrcSet( AV12state2), true);
            edtavStop_Visible = 1;
            AssignProp(sPrefix, false, edtavStop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStop_Visible), 5, 0), !bGXsfl_15_Refreshing);
            AV13stop = context.GetImagePath( "e18fac27-0e75-4842-8560-9dfaa60d377c", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavStop_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13stop)) ? AV26Stop_GXI : context.convertURL( context.PathToRelativeUrl( AV13stop))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavStop_Internalname, "SrcSet", context.GetImageSrcSet( AV13stop), true);
            AV26Stop_GXI = GXDbFile.PathToUrl( context.GetImagePath( "e18fac27-0e75-4842-8560-9dfaa60d377c", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavStop_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13stop)) ? AV26Stop_GXI : context.convertURL( context.PathToRelativeUrl( AV13stop))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavStop_Internalname, "SrcSet", context.GetImageSrcSet( AV13stop), true);
         }
         if ( ( DateTimeUtil.ResetTime ( AV14T1.gxTpr_Tareafechainicio ) <= DateTimeUtil.ResetTime ( Gx_date ) ) && ( AV14T1.gxTpr_Tareaestado == 1 ) && ( DateTimeUtil.ResetTime ( AV14T1.gxTpr_Tareafechafin ) > DateTimeUtil.ResetTime ( Gx_date ) ) )
         {
            lblAdvisor_Caption = "<div class=\"alert alert-warning\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>Debes iniciar y terminar la tarea antes de la fecha de finalización."+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblAdvisor_Internalname, "Caption", lblAdvisor_Caption, !bGXsfl_15_Refreshing);
         }
         else if ( DateTimeUtil.ResetTime ( AV14T1.gxTpr_Tareafechafin ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            lblAdvisor_Caption = "<div class=\"alert alert-danger\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>La tarea ha vencido.  Completala o cambia las fechas de finalización"+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblAdvisor_Internalname, "Caption", lblAdvisor_Caption, !bGXsfl_15_Refreshing);
         }
         else if ( DateTimeUtil.ResetTime ( AV14T1.gxTpr_Tareafechafin ) == DateTimeUtil.ResetTime ( Gx_date ) )
         {
            lblAdvisor_Caption = "<div class=\"alert alert-info\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>La tarea se vencerá hoy.  Debes completar esta tarea antes de la fecha de finalización"+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblAdvisor_Internalname, "Caption", lblAdvisor_Caption, !bGXsfl_15_Refreshing);
         }
         else
         {
            lblAdvisor_Caption = "";
            AssignProp(sPrefix, false, lblAdvisor_Internalname, "Caption", lblAdvisor_Caption, !bGXsfl_15_Refreshing);
         }
         lblNombre1_Caption = "<center><h3><strong>"+StringUtil.Trim( AV14T1.gxTpr_Tareanombre)+"</strong></h3><h5>"+StringUtil.Trim( AV9responsable)+"</h5></center>";
         AssignProp(sPrefix, false, lblNombre1_Internalname, "Caption", lblNombre1_Caption, !bGXsfl_15_Refreshing);
         lblInicia_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         AssignProp(sPrefix, false, lblInicia_Internalname, "Caption", lblInicia_Caption, !bGXsfl_15_Refreshing);
         lblInicia_Caption = StringUtil.StringReplace( lblInicia_Caption, "#VALUE", context.localUtil.DToC( AV14T1.gxTpr_Tareafechainicio, 2, "/"));
         AssignProp(sPrefix, false, lblInicia_Internalname, "Caption", lblInicia_Caption, !bGXsfl_15_Refreshing);
         lblInicia_Caption = StringUtil.StringReplace( lblInicia_Caption, "#LABEL", "Inicia");
         AssignProp(sPrefix, false, lblInicia_Internalname, "Caption", lblInicia_Caption, !bGXsfl_15_Refreshing);
         lblFinaliza_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         AssignProp(sPrefix, false, lblFinaliza_Internalname, "Caption", lblFinaliza_Caption, !bGXsfl_15_Refreshing);
         lblFinaliza_Caption = StringUtil.StringReplace( lblFinaliza_Caption, "#VALUE", context.localUtil.DToC( AV14T1.gxTpr_Tareafechafin, 2, "/"));
         AssignProp(sPrefix, false, lblFinaliza_Internalname, "Caption", lblFinaliza_Caption, !bGXsfl_15_Refreshing);
         lblFinaliza_Caption = StringUtil.StringReplace( lblFinaliza_Caption, "#LABEL", "Finaliza");
         AssignProp(sPrefix, false, lblFinaliza_Internalname, "Caption", lblFinaliza_Caption, !bGXsfl_15_Refreshing);
         /*  Sending Event outputs  */
      }

      protected void E140Z2( )
      {
         /* 'Iniciar' Routine */
         returnInSub = false;
         AV14T1.Load(A9TableroId, A12TareaId);
         AV15T4.Load(A9TableroId, A12TareaId);
         if ( (0==AV14T1.gxTpr_Responsableid) )
         {
            AV10sdt_sa.gxTpr_Title = "No hay responsable asignado";
            AV10sdt_sa.gxTpr_Html = "Debes asignar un responsable a la tarea antes de iniciarla";
            AV10sdt_sa.gxTpr_Timer = 4000;
            AV10sdt_sa.gxTpr_Allowoutsideclick = true;
            AV10sdt_sa.gxTpr_Type = "error";
            this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV10sdt_sa});
         }
         else
         {
            if ( AV14T1.gxTpr_Tareaestado == 1 )
            {
               AV15T4.gxTpr_Tareaestado = 2;
            }
            AV15T4.Save();
            if ( AV15T4.Success() )
            {
               context.CommitDataStores("sininiciarwc",pr_default);
               CallWebObject(formatLink("listadotareas.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0))}, new string[] {"TableroId"}) );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               context.RollbackDataStores("sininiciarwc",pr_default);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10sdt_sa", AV10sdt_sa);
      }

      protected void E150Z2( )
      {
         /* 'Asignar' Routine */
         returnInSub = false;
         AV15T4.Load(A9TableroId, A12TareaId);
         if ( (0==AV15T4.gxTpr_Responsableid) )
         {
            tblAsignacion_Visible = 1;
            AssignProp(sPrefix, false, tblAsignacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblAsignacion_Visible), 5, 0), !bGXsfl_15_Refreshing);
         }
         else
         {
            AV15T4.gxTv_SdtTareas_Responsableid_SetNull();
            AV15T4.Save();
            if ( AV15T4.Success() )
            {
               context.CommitDataStores("sininiciarwc",pr_default);
               AV10sdt_sa.gxTpr_Title = "Responsable eliminado";
               AV10sdt_sa.gxTpr_Html = "Se ha eliminado el responsable de esta tarea.";
               AV10sdt_sa.gxTpr_Timer = 4000;
               AV10sdt_sa.gxTpr_Allowoutsideclick = true;
               AV10sdt_sa.gxTpr_Type = "info";
               this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV10sdt_sa});
               cmbavParticipantetableroid.removeAllItems();
               context.DoAjaxRefreshCmp(sPrefix);
            }
            else
            {
               context.RollbackDataStores("sininiciarwc",pr_default);
               AV10sdt_sa.gxTpr_Title = "Ha ocurrido un error";
               AV10sdt_sa.gxTpr_Html = "Ha ocurrido un error en la asignación.  Por favor inténtelo nuevamente.";
               AV10sdt_sa.gxTpr_Timer = 4000;
               AV10sdt_sa.gxTpr_Allowoutsideclick = true;
               AV10sdt_sa.gxTpr_Type = "success";
               this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV10sdt_sa});
            }
         }
         /*  Sending Event outputs  */
         cmbavParticipantetableroid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ParticipanteTableroId), 4, 0));
         AssignProp(sPrefix, false, cmbavParticipantetableroid_Internalname, "Values", cmbavParticipantetableroid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10sdt_sa", AV10sdt_sa);
      }

      protected void E160Z2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Using cursor H000Z6 */
         pr_default.execute(4, new Object[] {A9TableroId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A18ParticipanteTableroId = H000Z6_A18ParticipanteTableroId[0];
            AV17U2.Load(A18ParticipanteTableroId);
            cmbavParticipantetableroid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV17U2.gxTpr_Usuarioid), 4, 0)), AV17U2.gxTpr_Usuarionombre+" "+AV17U2.gxTpr_Usuarioapellido, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /*  Sending Event outputs  */
         cmbavParticipantetableroid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ParticipanteTableroId), 4, 0));
         AssignProp(sPrefix, false, cmbavParticipantetableroid_Internalname, "Values", cmbavParticipantetableroid.ToJavascriptSource(), true);
      }

      protected void E170Z2( )
      {
         /* 'AnadirAsignacion' Routine */
         returnInSub = false;
         AV15T4.Load(A9TableroId, A12TareaId);
         AV15T4.gxTpr_Responsableid = AV8ParticipanteTableroId;
         AV15T4.Save();
         if ( AV15T4.Success() )
         {
            context.CommitDataStores("sininiciarwc",pr_default);
            AV10sdt_sa.gxTpr_Title = "Responsable asignado";
            AV10sdt_sa.gxTpr_Html = "Se ha asignado el responsable de esta tarea.";
            AV10sdt_sa.gxTpr_Timer = 4000;
            AV10sdt_sa.gxTpr_Allowoutsideclick = true;
            AV10sdt_sa.gxTpr_Type = "success";
            this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV10sdt_sa});
            cmbavParticipantetableroid.removeAllItems();
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            AV10sdt_sa.gxTpr_Title = "Ha ocurrido un error";
            AV10sdt_sa.gxTpr_Html = "Ha ocurrido un error en la asignación.  Por favor inténtelo nuevamente.";
            AV10sdt_sa.gxTpr_Timer = 4000;
            AV10sdt_sa.gxTpr_Allowoutsideclick = true;
            AV10sdt_sa.gxTpr_Type = "success";
            this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV10sdt_sa});
            context.RollbackDataStores("sininiciarwc",pr_default);
         }
         /*  Sending Event outputs  */
         cmbavParticipantetableroid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ParticipanteTableroId), 4, 0));
         AssignProp(sPrefix, false, cmbavParticipantetableroid_Internalname, "Values", cmbavParticipantetableroid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10sdt_sa", AV10sdt_sa);
      }

      protected void E180Z2( )
      {
         /* 'Cancelar' Routine */
         returnInSub = false;
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         cmbavParticipantetableroid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ParticipanteTableroId), 4, 0));
         AssignProp(sPrefix, false, cmbavParticipantetableroid_Internalname, "Values", cmbavParticipantetableroid.ToJavascriptSource(), true);
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
         PA0Z2( ) ;
         WS0Z2( ) ;
         WE0Z2( ) ;
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
         PA0Z2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "sininiciarwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0Z2( ) ;
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
         PA0Z2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0Z2( ) ;
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
         WS0Z2( ) ;
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
         WE0Z2( ) ;
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
         if ( ! ( WebComp_GX_Process == null ) )
         {
            WebComp_GX_Process.componentjscripts();
         }
         if ( ! ( WebComp_Tareas1 == null ) )
         {
            WebComp_Tareas1.componentjscripts();
         }
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( StringUtil.StrCmp(WebComp_Tareas1_Component, "") == 0 )
         {
            WebComp_Tareas1 = getWebComponent(GetType(), "GeneXus.Programs", "listadoactividades", new Object[] {context} );
            WebComp_Tareas1.ComponentInit();
            WebComp_Tareas1.Name = "ListadoActividades";
            WebComp_Tareas1_Component = "ListadoActividades";
         }
         if ( ! ( WebComp_Tareas1 == null ) )
         {
            WebComp_Tareas1.componentthemes();
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20221022911190", true, true);
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
         context.AddJavascriptSource("sininiciarwc.js", "?20221022911191", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/js/sweetalert2.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/jquery-3.5.1.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/popper.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/bootstrap.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/RAMP_AddOns_SweetAlertRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_152( )
      {
         edtavState2_Internalname = sPrefix+"vSTATE2_"+sGXsfl_15_idx;
         edtavState_Internalname = sPrefix+"vSTATE_"+sGXsfl_15_idx;
         edtavAsignar_Internalname = sPrefix+"vASIGNAR_"+sGXsfl_15_idx;
         edtavComentarios_Internalname = sPrefix+"vCOMENTARIOS_"+sGXsfl_15_idx;
         edtavStop_Internalname = sPrefix+"vSTOP_"+sGXsfl_15_idx;
         cmbavParticipantetableroid_Internalname = sPrefix+"vPARTICIPANTETABLEROID_"+sGXsfl_15_idx;
         imgImage5_Internalname = sPrefix+"IMAGE5_"+sGXsfl_15_idx;
         imgImage6_Internalname = sPrefix+"IMAGE6_"+sGXsfl_15_idx;
         lblNombre1_Internalname = sPrefix+"NOMBRE1_"+sGXsfl_15_idx;
         edtTareaId_Internalname = sPrefix+"TAREAID_"+sGXsfl_15_idx;
         lblAdvisor_Internalname = sPrefix+"ADVISOR_"+sGXsfl_15_idx;
         lblInicia_Internalname = sPrefix+"INICIA_"+sGXsfl_15_idx;
         lblFinaliza_Internalname = sPrefix+"FINALIZA_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtavState2_Internalname = sPrefix+"vSTATE2_"+sGXsfl_15_fel_idx;
         edtavState_Internalname = sPrefix+"vSTATE_"+sGXsfl_15_fel_idx;
         edtavAsignar_Internalname = sPrefix+"vASIGNAR_"+sGXsfl_15_fel_idx;
         edtavComentarios_Internalname = sPrefix+"vCOMENTARIOS_"+sGXsfl_15_fel_idx;
         edtavStop_Internalname = sPrefix+"vSTOP_"+sGXsfl_15_fel_idx;
         cmbavParticipantetableroid_Internalname = sPrefix+"vPARTICIPANTETABLEROID_"+sGXsfl_15_fel_idx;
         imgImage5_Internalname = sPrefix+"IMAGE5_"+sGXsfl_15_fel_idx;
         imgImage6_Internalname = sPrefix+"IMAGE6_"+sGXsfl_15_fel_idx;
         lblNombre1_Internalname = sPrefix+"NOMBRE1_"+sGXsfl_15_fel_idx;
         edtTareaId_Internalname = sPrefix+"TAREAID_"+sGXsfl_15_fel_idx;
         lblAdvisor_Internalname = sPrefix+"ADVISOR_"+sGXsfl_15_fel_idx;
         lblInicia_Internalname = sPrefix+"INICIA_"+sGXsfl_15_fel_idx;
         lblFinaliza_Internalname = sPrefix+"FINALIZA_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         SubsflControlProps_152( ) ;
         WB0Z0( ) ;
         Gridtareas1Row = GXWebRow.GetNew(context,Gridtareas1Container);
         if ( subGridtareas1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridtareas1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridtareas1_Class, "") != 0 )
            {
               subGridtareas1_Linesclass = subGridtareas1_Class+"Odd";
            }
         }
         else if ( subGridtareas1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridtareas1_Backstyle = 0;
            subGridtareas1_Backcolor = subGridtareas1_Allbackcolor;
            if ( StringUtil.StrCmp(subGridtareas1_Class, "") != 0 )
            {
               subGridtareas1_Linesclass = subGridtareas1_Class+"Uniform";
            }
         }
         else if ( subGridtareas1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridtareas1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridtareas1_Class, "") != 0 )
            {
               subGridtareas1_Linesclass = subGridtareas1_Class+"Odd";
            }
            subGridtareas1_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridtareas1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridtareas1_Backstyle = 1;
            if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
            {
               subGridtareas1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtareas1_Class, "") != 0 )
               {
                  subGridtareas1_Linesclass = subGridtareas1_Class+"Even";
               }
            }
            else
            {
               subGridtareas1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridtareas1_Class, "") != 0 )
               {
                  subGridtareas1_Linesclass = subGridtareas1_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridtareas1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_15_idx+"\">") ;
         }
         /* Table start */
         Gridtareas1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblGridtareas1table1_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"TableWidget",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Gridtareas1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Gridtareas1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTable4_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Gridtareas1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTable6_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Gridtareas1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Gridtareas1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"state2",(string)"gx-form-item ImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavState2_Enabled!=0)&&(edtavState2_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 26,'"+sPrefix+"',false,'',15)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV12state2_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV12state2))&&String.IsNullOrEmpty(StringUtil.RTrim( AV25State2_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV12state2)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV12state2)) ? AV25State2_GXI : context.PathToRelativeUrl( AV12state2));
         Gridtareas1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavState2_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"Iniciar tarea",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)5,(string)edtavState2_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'INICIAR\\'."+sGXsfl_15_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV12state2_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("cell");
         }
         Gridtareas1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"state",(string)"gx-form-item ImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Static Bitmap Variable */
         ClassString = "Image";
         StyleString = "";
         AV11state_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV11state))&&String.IsNullOrEmpty(StringUtil.RTrim( AV24State_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV11state)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV11state)) ? AV24State_GXI : context.PathToRelativeUrl( AV11state));
         Gridtareas1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavState_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"Estado",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV11state_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("cell");
         }
         Gridtareas1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"asignar",(string)"gx-form-item ImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavAsignar_Enabled!=0)&&(edtavAsignar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 32,'"+sPrefix+"',false,'',15)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV5asignar_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar))&&String.IsNullOrEmpty(StringUtil.RTrim( AV23Asignar_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)) ? AV23Asignar_GXI : context.PathToRelativeUrl( AV5asignar));
         Gridtareas1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavAsignar_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"Asignar o eliminar responsable",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)5,(string)edtavAsignar_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ASIGNAR\\'."+sGXsfl_15_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV5asignar_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("cell");
         }
         Gridtareas1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"comentarios",(string)"gx-form-item ImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Static Bitmap Variable */
         ClassString = "Image";
         StyleString = "";
         AV6comentarios_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios))&&String.IsNullOrEmpty(StringUtil.RTrim( AV22Comentarios_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV22Comentarios_GXI : context.PathToRelativeUrl( AV6comentarios));
         Gridtareas1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavComentarios_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)edtavComentarios_Tooltiptext,(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV6comentarios_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("cell");
         }
         Gridtareas1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"stop",(string)"gx-form-item ImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavStop_Enabled!=0)&&(edtavStop_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 38,'"+sPrefix+"',false,'',15)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV13stop_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV13stop))&&String.IsNullOrEmpty(StringUtil.RTrim( AV26Stop_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV13stop)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV13stop)) ? AV26Stop_GXI : context.PathToRelativeUrl( AV13stop));
         Gridtareas1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavStop_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavStop_Visible,(short)1,(string)"",(string)"",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)5,(string)edtavStop_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'PAUSAPLAY\\'."+sGXsfl_15_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV13stop_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("cell");
         }
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("row");
         }
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("table");
         }
         /* End of table */
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Gridtareas1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblAsignacion_Internalname+"_"+sGXsfl_15_idx,(int)tblAsignacion_Visible,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Gridtareas1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Gridtareas1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = " " + ((cmbavParticipantetableroid.Enabled!=0)&&(cmbavParticipantetableroid.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 45,'"+sPrefix+"',false,'"+sGXsfl_15_idx+"',15)\"" : " ");
         if ( ( cmbavParticipantetableroid.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vPARTICIPANTETABLEROID_" + sGXsfl_15_idx;
            cmbavParticipantetableroid.Name = GXCCtl;
            cmbavParticipantetableroid.WebTags = "";
            if ( cmbavParticipantetableroid.ItemCount > 0 )
            {
               AV8ParticipanteTableroId = (short)(NumberUtil.Val( cmbavParticipantetableroid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8ParticipanteTableroId), 4, 0))), "."));
               AssignAttri(sPrefix, false, cmbavParticipantetableroid_Internalname, StringUtil.LTrimStr( (decimal)(AV8ParticipanteTableroId), 4, 0));
            }
         }
         /* ComboBox */
         Gridtareas1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavParticipantetableroid,(string)cmbavParticipantetableroid_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV8ParticipanteTableroId), 4, 0)),(short)1,(string)cmbavParticipantetableroid_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)1,(short)1,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavParticipantetableroid.Enabled!=0)&&(cmbavParticipantetableroid.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,45);\"" : " "),(string)"",(bool)true,(short)1});
         cmbavParticipantetableroid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ParticipanteTableroId), 4, 0));
         AssignProp(sPrefix, false, cmbavParticipantetableroid_Internalname, "Values", (string)(cmbavParticipantetableroid.ToJavascriptSource()), !bGXsfl_15_Refreshing);
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("cell");
         }
         Gridtareas1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         sendrow_15230( ) ;
      }

      protected void sendrow_15230( )
      {
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTable9_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Active images/pictures */
         TempTags = " " + ((imgImage5_Enabled!=0)&&(imgImage5_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 49,'"+sPrefix+"',false,'',0)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "37af6e8e-5105-40d2-94ea-61da60f7a7ab", "", context.GetTheme( )));
         Gridtareas1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgImage5_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"Agregar responsable",(short)0,(short)0,(short)15,(string)"px",(short)15,(string)"px",(short)0,(short)0,(short)5,(string)imgImage5_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ANADIRASIGNACION\\'."+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)" "+"data-gx-image"+" "+TempTags,(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Active images/pictures */
         TempTags = " " + ((imgImage6_Enabled!=0)&&(imgImage6_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 51,'"+sPrefix+"',false,'',0)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "ec15b36c-8f5a-4ad5-be9c-712eec67d653", "", context.GetTheme( )));
         Gridtareas1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgImage6_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"Cancelar",(short)0,(short)0,(short)15,(string)"px",(short)15,(string)"px",(short)0,(short)0,(short)5,(string)imgImage6_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'CANCELAR\\'."+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)" "+"data-gx-image"+" "+TempTags,(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("cell");
         }
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("row");
         }
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("table");
         }
         /* End of table */
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Gridtareas1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNombre1_Internalname,(string)lblNombre1_Caption,(string)"",(string)"",(string)lblNombre1_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtTareaId_Internalname,(string)"Tarea Id",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Gridtareas1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTareaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTareaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtTareaId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)15,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Gridtareas1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblAdvisor_Internalname,(string)lblAdvisor_Caption,(string)"",(string)"",(string)lblAdvisor_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Gridtareas1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTable3_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Gridtareas1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Gridtareas1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0067"+sGXsfl_15_idx, StringUtil.RTrim( WebComp_Tareas1_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0067"+sGXsfl_15_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_15_Refreshing )
         {
            if ( StringUtil.StrCmp(WebComp_Tareas1_Component, "") == 0 )
            {
               WebComp_Tareas1 = getWebComponent(GetType(), "GeneXus.Programs", "listadoactividades", new Object[] {context} );
               WebComp_Tareas1.ComponentInit();
               WebComp_Tareas1.Name = "ListadoActividades";
               WebComp_Tareas1_Component = "ListadoActividades";
            }
            WebComp_Tareas1.setjustcreated();
            WebComp_Tareas1.componentprepare(new Object[] {(string)sPrefix+"W0067",(string)sGXsfl_15_idx,(short)A9TableroId,(short)A12TareaId});
            WebComp_Tareas1.componentbind(new Object[] {(string)"",(string)""});
            if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0067"+sGXsfl_15_idx, cgiGet( "_EventName"), 1) != 0 ) )
            {
               if ( 1 != 0 )
               {
                  WebComp_Tareas1.componentstart();
               }
            }
            if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldTareas1), StringUtil.Lower( WebComp_Tareas1_Component)) != 0 ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0067"+sGXsfl_15_idx);
            }
            WebComp_Tareas1.componentdraw();
            if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldTareas1), StringUtil.Lower( WebComp_Tareas1_Component)) != 0 ) )
            {
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Tareas1_Component = "";
         WebComp_Tareas1.componentjscripts();
         Gridtareas1Row.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Tareas1"});
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("cell");
         }
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("row");
         }
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("table");
         }
         /* End of table */
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTable5_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Text block */
         Gridtareas1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblInicia_Internalname,(string)lblInicia_Caption,(string)"",(string)"",(string)lblInicia_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Text block */
         Gridtareas1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblFinaliza_Internalname,(string)lblFinaliza_Caption,(string)"",(string)"",(string)lblFinaliza_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("cell");
         }
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("row");
         }
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            Gridtareas1Container.CloseTag("table");
         }
         /* End of table */
         send_integrity_lvl_hashes0Z2( ) ;
         /* End of Columns property logic. */
         Gridtareas1Container.AddRow(Gridtareas1Row);
         nGXsfl_15_idx = ((subGridtareas1_Islastpage==1)&&(nGXsfl_15_idx+1>subGridtareas1_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vPARTICIPANTETABLEROID_" + sGXsfl_15_idx;
         cmbavParticipantetableroid.Name = GXCCtl;
         cmbavParticipantetableroid.WebTags = "";
         if ( cmbavParticipantetableroid.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl15( )
      {
         if ( Gridtareas1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Gridtareas1Container"+"DivS\" data-gxgridid=\"15\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridtareas1_Internalname, subGridtareas1_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Gridtareas1Container.AddObjectProperty("GridName", "Gridtareas1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Gridtareas1Container = new GXWebGrid( context);
            }
            else
            {
               Gridtareas1Container.Clear();
            }
            Gridtareas1Container.SetIsFreestyle(true);
            Gridtareas1Container.SetWrapped(nGXWrapped);
            Gridtareas1Container.AddObjectProperty("GridName", "Gridtareas1");
            Gridtareas1Container.AddObjectProperty("Header", subGridtareas1_Header);
            Gridtareas1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Gridtareas1Container.AddObjectProperty("Class", "FreeStyleGrid");
            Gridtareas1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridtareas1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridtareas1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas1_Backcolorstyle), 1, 0, ".", "")));
            Gridtareas1Container.AddObjectProperty("CmpContext", sPrefix);
            Gridtareas1Container.AddObjectProperty("InMasterPage", "false");
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Column.AddObjectProperty("Value", context.convertURL( AV12state2));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Column.AddObjectProperty("Value", context.convertURL( AV11state));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Column.AddObjectProperty("Value", context.convertURL( AV5asignar));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Column.AddObjectProperty("Value", context.convertURL( AV6comentarios));
            Gridtareas1Column.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavComentarios_Tooltiptext));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Column.AddObjectProperty("Value", context.convertURL( AV13stop));
            Gridtareas1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavStop_Visible), 5, 0, ".", "")));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ParticipanteTableroId), 4, 0, ".", "")));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Column.AddObjectProperty("Value", context.convertURL( context.GetImagePath( "37af6e8e-5105-40d2-94ea-61da60f7a7ab", "", context.GetTheme( ))));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Column.AddObjectProperty("Value", context.convertURL( context.GetImagePath( "ec15b36c-8f5a-4ad5-be9c-712eec67d653", "", context.GetTheme( ))));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Column.AddObjectProperty("Value", lblNombre1_Caption);
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ".", "")));
            Gridtareas1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTareaId_Visible), 5, 0, ".", "")));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Column.AddObjectProperty("Value", lblAdvisor_Caption);
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Column.AddObjectProperty("Value", lblInicia_Caption);
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas1Column.AddObjectProperty("Value", lblFinaliza_Caption);
            Gridtareas1Container.AddColumnProperties(Gridtareas1Column);
            Gridtareas1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas1_Selectedindex), 4, 0, ".", "")));
            Gridtareas1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas1_Allowselection), 1, 0, ".", "")));
            Gridtareas1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas1_Selectioncolor), 9, 0, ".", "")));
            Gridtareas1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas1_Allowhovering), 1, 0, ".", "")));
            Gridtareas1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas1_Hoveringcolor), 9, 0, ".", "")));
            Gridtareas1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas1_Allowcollapsing), 1, 0, ".", "")));
            Gridtareas1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         imgImage2_Internalname = sPrefix+"IMAGE2";
         lblTitulo1_Internalname = sPrefix+"TITULO1";
         edtavState2_Internalname = sPrefix+"vSTATE2";
         edtavState_Internalname = sPrefix+"vSTATE";
         edtavAsignar_Internalname = sPrefix+"vASIGNAR";
         edtavComentarios_Internalname = sPrefix+"vCOMENTARIOS";
         edtavStop_Internalname = sPrefix+"vSTOP";
         tblTable6_Internalname = sPrefix+"TABLE6";
         cmbavParticipantetableroid_Internalname = sPrefix+"vPARTICIPANTETABLEROID";
         imgImage5_Internalname = sPrefix+"IMAGE5";
         imgImage6_Internalname = sPrefix+"IMAGE6";
         divTable9_Internalname = sPrefix+"TABLE9";
         tblAsignacion_Internalname = sPrefix+"ASIGNACION";
         lblNombre1_Internalname = sPrefix+"NOMBRE1";
         edtTareaId_Internalname = sPrefix+"TAREAID";
         lblAdvisor_Internalname = sPrefix+"ADVISOR";
         tblTable3_Internalname = sPrefix+"TABLE3";
         lblInicia_Internalname = sPrefix+"INICIA";
         lblFinaliza_Internalname = sPrefix+"FINALIZA";
         divTable5_Internalname = sPrefix+"TABLE5";
         divTable4_Internalname = sPrefix+"TABLE4";
         tblGridtareas1table1_Internalname = sPrefix+"GRIDTAREAS1TABLE1";
         divT1_Internalname = sPrefix+"T1";
         Ramp_addons_sweetalert1_Internalname = sPrefix+"RAMP_ADDONS_SWEETALERT1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridtareas1_Internalname = sPrefix+"GRIDTAREAS1";
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
         subGridtareas1_Allowcollapsing = 0;
         lblAdvisor_Caption = "";
         lblFinaliza_Jsonclick = "";
         lblInicia_Jsonclick = "";
         edtTareaId_Jsonclick = "";
         lblNombre1_Jsonclick = "";
         cmbavParticipantetableroid_Jsonclick = "";
         cmbavParticipantetableroid.Visible = 1;
         cmbavParticipantetableroid.Enabled = 1;
         edtavStop_Jsonclick = "";
         edtavStop_Enabled = 1;
         edtavAsignar_Jsonclick = "";
         edtavAsignar_Visible = 1;
         edtavAsignar_Enabled = 1;
         edtavState2_Jsonclick = "";
         edtavState2_Visible = 1;
         edtavState2_Enabled = 1;
         subGridtareas1_Class = "FreeStyleGrid";
         lblNombre1_Caption = "Nombre1";
         lblAdvisor_Caption = "";
         edtavStop_Visible = 1;
         edtavComentarios_Tooltiptext = "Comentarios";
         lblFinaliza_Caption = "Finaliza";
         lblInicia_Caption = "Inicia";
         tblAsignacion_Visible = 1;
         subGridtareas1_Backcolorstyle = 0;
         lblTitulo1_Jsonclick = "";
         lblTitulo1_Caption = "Titulo1";
         divT1_Class = "Table";
         edtTareaId_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDTAREAS1_nFirstRecordOnPage'},{av:'GRIDTAREAS1_nEOF'},{av:'sPrefix'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'cmbavParticipantetableroid'},{av:'AV8ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavParticipantetableroid'},{av:'AV8ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("GRIDTAREAS1.LOAD","{handler:'E120Z2',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("GRIDTAREAS1.LOAD",",oparms:[{av:'tblAsignacion_Visible',ctrl:'ASIGNACION',prop:'Visible'},{av:'AV6comentarios',fld:'vCOMENTARIOS',pic:''},{av:'edtavComentarios_Tooltiptext',ctrl:'vCOMENTARIOS',prop:'Tooltiptext'},{av:'AV5asignar',fld:'vASIGNAR',pic:''},{av:'AV11state',fld:'vSTATE',pic:''},{av:'AV12state2',fld:'vSTATE2',pic:''},{av:'edtavStop_Visible',ctrl:'vSTOP',prop:'Visible'},{av:'AV13stop',fld:'vSTOP',pic:''},{av:'lblAdvisor_Caption',ctrl:'ADVISOR',prop:'Caption'},{av:'lblNombre1_Caption',ctrl:'NOMBRE1',prop:'Caption'},{av:'lblInicia_Caption',ctrl:'INICIA',prop:'Caption'},{av:'lblFinaliza_Caption',ctrl:'FINALIZA',prop:'Caption'}]}");
         setEventMetadata("GRIDTAREAS1.REFRESH","{handler:'E130Z2',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("GRIDTAREAS1.REFRESH",",oparms:[{av:'tblAsignacion_Visible',ctrl:'ASIGNACION',prop:'Visible'},{av:'AV6comentarios',fld:'vCOMENTARIOS',pic:''},{av:'edtavComentarios_Tooltiptext',ctrl:'vCOMENTARIOS',prop:'Tooltiptext'},{av:'AV5asignar',fld:'vASIGNAR',pic:''},{av:'AV11state',fld:'vSTATE',pic:''},{av:'AV12state2',fld:'vSTATE2',pic:''},{av:'edtavStop_Visible',ctrl:'vSTOP',prop:'Visible'},{av:'AV13stop',fld:'vSTOP',pic:''},{av:'lblAdvisor_Caption',ctrl:'ADVISOR',prop:'Caption'},{av:'lblNombre1_Caption',ctrl:'NOMBRE1',prop:'Caption'},{av:'lblInicia_Caption',ctrl:'INICIA',prop:'Caption'},{av:'lblFinaliza_Caption',ctrl:'FINALIZA',prop:'Caption'}]}");
         setEventMetadata("'INICIAR'","{handler:'E140Z2',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'AV10sdt_sa',fld:'vSDT_SA',pic:''}]");
         setEventMetadata("'INICIAR'",",oparms:[{av:'AV10sdt_sa',fld:'vSDT_SA',pic:''},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("'ASIGNAR'","{handler:'E150Z2',iparms:[{av:'GRIDTAREAS1_nFirstRecordOnPage'},{av:'GRIDTAREAS1_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'cmbavParticipantetableroid'},{av:'AV8ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'sPrefix'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'AV10sdt_sa',fld:'vSDT_SA',pic:''}]");
         setEventMetadata("'ASIGNAR'",",oparms:[{av:'tblAsignacion_Visible',ctrl:'ASIGNACION',prop:'Visible'},{av:'cmbavParticipantetableroid'},{av:'AV8ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'AV10sdt_sa',fld:'vSDT_SA',pic:''}]}");
         setEventMetadata("'ANADIRASIGNACION'","{handler:'E170Z2',iparms:[{av:'GRIDTAREAS1_nFirstRecordOnPage'},{av:'GRIDTAREAS1_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'cmbavParticipantetableroid'},{av:'AV8ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'sPrefix'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'AV10sdt_sa',fld:'vSDT_SA',pic:''}]");
         setEventMetadata("'ANADIRASIGNACION'",",oparms:[{av:'cmbavParticipantetableroid'},{av:'AV8ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'AV10sdt_sa',fld:'vSDT_SA',pic:''}]}");
         setEventMetadata("'CANCELAR'","{handler:'E180Z2',iparms:[{av:'GRIDTAREAS1_nFirstRecordOnPage'},{av:'GRIDTAREAS1_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'cmbavParticipantetableroid'},{av:'AV8ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("'CANCELAR'",",oparms:[{av:'cmbavParticipantetableroid'},{av:'AV8ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_TAREAID","{handler:'Valid_Tareaid',iparms:[]");
         setEventMetadata("VALID_TAREAID",",oparms:[]}");
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
         AV10sdt_sa = new SdtSDT_SweetAlert(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         Gridtareas1Container = new GXWebGrid( context);
         sStyleString = "";
         ucRamp_addons_sweetalert1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV12state2 = "";
         AV25State2_GXI = "";
         AV11state = "";
         AV24State_GXI = "";
         AV5asignar = "";
         AV23Asignar_GXI = "";
         AV6comentarios = "";
         AV22Comentarios_GXI = "";
         AV13stop = "";
         AV26Stop_GXI = "";
         OldTareas1 = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         WebComp_Tareas1_Component = "";
         scmdbuf = "";
         H000Z2_A9TableroId = new short[1] ;
         H000Z2_A46TareaEstado = new short[1] ;
         H000Z2_A12TareaId = new short[1] ;
         H000Z2_A24TareaFechaInicio = new DateTime[] {DateTime.MinValue} ;
         A24TareaFechaInicio = DateTime.MinValue;
         H000Z3_A9TableroId = new short[1] ;
         H000Z3_A18ParticipanteTableroId = new short[1] ;
         AV17U2 = new SdtUsuarios(context);
         AV14T1 = new SdtTareas(context);
         H000Z4_AV7contador = new short[1] ;
         AV16U1 = new SdtUsuarios(context);
         AV9responsable = "";
         Gridtareas1Row = new GXWebRow();
         H000Z5_AV7contador = new short[1] ;
         AV15T4 = new SdtTareas(context);
         H000Z6_A9TableroId = new short[1] ;
         H000Z6_A18ParticipanteTableroId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA9TableroId = "";
         subGridtareas1_Linesclass = "";
         TempTags = "";
         GXCCtl = "";
         imgImage5_Jsonclick = "";
         imgImage6_Jsonclick = "";
         ROClassString = "";
         lblAdvisor_Jsonclick = "";
         subGridtareas1_Header = "";
         Gridtareas1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sininiciarwc__default(),
            new Object[][] {
                new Object[] {
               H000Z2_A9TableroId, H000Z2_A46TareaEstado, H000Z2_A12TareaId, H000Z2_A24TareaFechaInicio
               }
               , new Object[] {
               H000Z3_A9TableroId, H000Z3_A18ParticipanteTableroId
               }
               , new Object[] {
               H000Z4_AV7contador
               }
               , new Object[] {
               H000Z5_AV7contador
               }
               , new Object[] {
               H000Z6_A9TableroId, H000Z6_A18ParticipanteTableroId
               }
            }
         );
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Tareas1 = new GeneXus.Http.GXNullWebComponent();
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
         edtTareaId_Visible = 0;
      }

      private short A9TableroId ;
      private short wcpOA9TableroId ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV8ParticipanteTableroId ;
      private short A18ParticipanteTableroId ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A12TareaId ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridtareas1_Backcolorstyle ;
      private short A46TareaEstado ;
      private short AV7contador ;
      private short cV7contador ;
      private short GRIDTAREAS1_nEOF ;
      private short nGXWrapped ;
      private short subGridtareas1_Backstyle ;
      private short subGridtareas1_Allowselection ;
      private short subGridtareas1_Allowhovering ;
      private short subGridtareas1_Allowcollapsing ;
      private short subGridtareas1_Collapsed ;
      private int nRC_GXsfl_15 ;
      private int nGXsfl_15_idx=1 ;
      private int edtTareaId_Visible ;
      private int nGXsfl_15_webc_idx=0 ;
      private int subGridtareas1_Islastpage ;
      private int tblAsignacion_Visible ;
      private int edtavStop_Visible ;
      private int idxLst ;
      private int subGridtareas1_Backcolor ;
      private int subGridtareas1_Allbackcolor ;
      private int edtavState2_Enabled ;
      private int edtavState2_Visible ;
      private int edtavAsignar_Enabled ;
      private int edtavAsignar_Visible ;
      private int edtavStop_Enabled ;
      private int imgImage5_Enabled ;
      private int imgImage5_Visible ;
      private int imgImage6_Enabled ;
      private int imgImage6_Visible ;
      private int subGridtareas1_Selectedindex ;
      private int subGridtareas1_Selectioncolor ;
      private int subGridtareas1_Hoveringcolor ;
      private long GRIDTAREAS1_nCurrentRecord ;
      private long GRIDTAREAS1_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_15_idx="0001" ;
      private string edtTareaId_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string divT1_Internalname ;
      private string divT1_Class ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage2_Internalname ;
      private string lblTitulo1_Internalname ;
      private string lblTitulo1_Caption ;
      private string lblTitulo1_Jsonclick ;
      private string sStyleString ;
      private string subGridtareas1_Internalname ;
      private string Ramp_addons_sweetalert1_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavParticipantetableroid_Internalname ;
      private string edtavState2_Internalname ;
      private string edtavState_Internalname ;
      private string edtavAsignar_Internalname ;
      private string edtavComentarios_Internalname ;
      private string edtavStop_Internalname ;
      private string OldTareas1 ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string WebComp_Tareas1_Component ;
      private string scmdbuf ;
      private string tblAsignacion_Internalname ;
      private string edtavComentarios_Tooltiptext ;
      private string AV9responsable ;
      private string lblAdvisor_Caption ;
      private string lblNombre1_Caption ;
      private string lblInicia_Caption ;
      private string lblFinaliza_Caption ;
      private string lblAdvisor_Internalname ;
      private string lblNombre1_Internalname ;
      private string lblInicia_Internalname ;
      private string lblFinaliza_Internalname ;
      private string sCtrlA9TableroId ;
      private string imgImage5_Internalname ;
      private string imgImage6_Internalname ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subGridtareas1_Class ;
      private string subGridtareas1_Linesclass ;
      private string tblGridtareas1table1_Internalname ;
      private string divTable4_Internalname ;
      private string tblTable6_Internalname ;
      private string TempTags ;
      private string edtavState2_Jsonclick ;
      private string edtavAsignar_Jsonclick ;
      private string edtavStop_Jsonclick ;
      private string GXCCtl ;
      private string cmbavParticipantetableroid_Jsonclick ;
      private string divTable9_Internalname ;
      private string imgImage5_Jsonclick ;
      private string imgImage6_Jsonclick ;
      private string lblNombre1_Jsonclick ;
      private string ROClassString ;
      private string edtTareaId_Jsonclick ;
      private string lblAdvisor_Jsonclick ;
      private string tblTable3_Internalname ;
      private string divTable5_Internalname ;
      private string lblInicia_Jsonclick ;
      private string lblFinaliza_Jsonclick ;
      private string subGridtareas1_Header ;
      private DateTime Gx_date ;
      private DateTime A24TareaFechaInicio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV12state2_IsBlob ;
      private bool AV11state_IsBlob ;
      private bool AV5asignar_IsBlob ;
      private bool AV6comentarios_IsBlob ;
      private bool AV13stop_IsBlob ;
      private string AV25State2_GXI ;
      private string AV24State_GXI ;
      private string AV23Asignar_GXI ;
      private string AV22Comentarios_GXI ;
      private string AV26Stop_GXI ;
      private string AV12state2 ;
      private string AV11state ;
      private string AV5asignar ;
      private string AV6comentarios ;
      private string AV13stop ;
      private GXWebComponent WebComp_Tareas1 ;
      private GXWebGrid Gridtareas1Container ;
      private GXWebRow Gridtareas1Row ;
      private GXWebColumn Gridtareas1Column ;
      private GXUserControl ucRamp_addons_sweetalert1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private GXCombobox cmbavParticipantetableroid ;
      private GXWebComponent WebComp_GX_Process ;
      private IDataStoreProvider pr_default ;
      private short[] H000Z2_A9TableroId ;
      private short[] H000Z2_A46TareaEstado ;
      private short[] H000Z2_A12TareaId ;
      private DateTime[] H000Z2_A24TareaFechaInicio ;
      private short[] H000Z3_A9TableroId ;
      private short[] H000Z3_A18ParticipanteTableroId ;
      private short[] H000Z4_AV7contador ;
      private short[] H000Z5_AV7contador ;
      private short[] H000Z6_A9TableroId ;
      private short[] H000Z6_A18ParticipanteTableroId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private SdtSDT_SweetAlert AV10sdt_sa ;
      private SdtTareas AV14T1 ;
      private SdtTareas AV15T4 ;
      private SdtUsuarios AV17U2 ;
      private SdtUsuarios AV16U1 ;
   }

   public class sininiciarwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000Z2;
          prmH000Z2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmH000Z3;
          prmH000Z3 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmH000Z4;
          prmH000Z4 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmH000Z5;
          prmH000Z5 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmH000Z6;
          prmH000Z6 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000Z2", "SELECT [TableroId], [TareaEstado], [TareaId], [TareaFechaInicio] FROM [Tareas] WHERE ([TableroId] = @TableroId) AND ([TareaEstado] = 1) ORDER BY [TareaFechaInicio] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Z2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Z3", "SELECT [TableroId], [ParticipanteTableroId] FROM [Participantes] WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Z3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Z4", "SELECT COUNT(*) FROM [TareasComentarios] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Z4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Z5", "SELECT COUNT(*) FROM [TareasComentarios] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Z5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Z6", "SELECT [TableroId], [ParticipanteTableroId] FROM [Participantes] WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Z6,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
