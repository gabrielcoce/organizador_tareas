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
   public class enprocesowc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public enprocesowc( )
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

      public enprocesowc( IGxContext context )
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridtareas2") == 0 )
               {
                  gxnrGridtareas2_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridtareas2") == 0 )
               {
                  gxgrGridtareas2_refresh_invoke( ) ;
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

      protected void gxnrGridtareas2_newrow_invoke( )
      {
         nRC_GXsfl_15 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_15"), "."));
         nGXsfl_15_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_15_idx"), "."));
         sGXsfl_15_idx = GetPar( "sGXsfl_15_idx");
         sPrefix = GetPar( "sPrefix");
         AV9ParticipanteTableroId = (short)(NumberUtil.Val( GetPar( "ParticipanteTableroId"), "."));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridtareas2_newrow( ) ;
         /* End function gxnrGridtareas2_newrow_invoke */
      }

      protected void gxgrGridtareas2_refresh_invoke( )
      {
         A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
         A18ParticipanteTableroId = (short)(NumberUtil.Val( GetPar( "ParticipanteTableroId"), "."));
         cmbavParticipantetableroid.FromJSonString( GetNextPar( ));
         AV9ParticipanteTableroId = (short)(NumberUtil.Val( GetPar( "ParticipanteTableroId"), "."));
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridtareas2_refresh( A9TableroId, A18ParticipanteTableroId, AV9ParticipanteTableroId, Gx_date, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridtareas2_refresh_invoke */
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
            PA102( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               Gx_date = DateTimeUtil.Today( context);
               context.Gx_err = 0;
               edtTareaId_Visible = 0;
               AssignProp(sPrefix, false, edtTareaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTareaId_Visible), 5, 0), !bGXsfl_15_Refreshing);
               WS102( ) ;
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
            context.SendWebValue( "En Proceso WC") ;
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
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "enprocesowc.aspx"+UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("enprocesowc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA9TableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PARTICIPANTETABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18ParticipanteTableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTODAY", GetSecureSignedToken( sPrefix, Gx_date, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_SA", AV16sdt_sa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_SA", AV16sdt_sa);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vESTADOCOMENTARIOS", AV19estadoComentarios);
      }

      protected void RenderHtmlCloseForm102( )
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
            if ( ! ( WebComp_Listadocomentarios == null ) )
            {
               WebComp_Listadocomentarios.componentjscripts();
            }
            if ( ! ( WebComp_Component1 == null ) )
            {
               WebComp_Component1.componentjscripts();
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
         return "EnProcesoWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "En Proceso WC" ;
      }

      protected void WB100( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "enprocesowc.aspx");
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
            GxWebStd.gx_div_start( context, divT2_Internalname, 1, 0, "px", 0, "px", divT2_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "7ebe37c3-562f-45b7-a44a-c2d66ccacb50", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 50, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_EnProcesoWC.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitulo2_Internalname, lblTitulo2_Caption, "", "", lblTitulo2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_EnProcesoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Gridtareas2Container.SetIsFreestyle(true);
            Gridtareas2Container.SetWrapped(nGXWrapped);
            StartGridControl15( ) ;
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
            if ( Gridtareas2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Gridtareas2Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridtareas2", Gridtareas2Container, subGridtareas2_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridtareas2ContainerData", Gridtareas2Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridtareas2ContainerData"+"V", Gridtareas2Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridtareas2ContainerData"+"V"+"\" value='"+Gridtareas2Container.GridValuesHidden()+"'/>") ;
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
               if ( Gridtareas2Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Gridtareas2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridtareas2", Gridtareas2Container, subGridtareas2_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridtareas2ContainerData", Gridtareas2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridtareas2ContainerData"+"V", Gridtareas2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridtareas2ContainerData"+"V"+"\" value='"+Gridtareas2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START102( )
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
               Form.Meta.addItem("description", "En Proceso WC", 0) ;
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
               STRUP100( ) ;
            }
         }
      }

      protected void WS102( )
      {
         START102( ) ;
         EVT102( ) ;
      }

      protected void EVT102( )
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
                                 STRUP100( ) ;
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
                                 STRUP100( ) ;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "GRIDTAREAS2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "GRIDTAREAS2.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'ASIGNAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'ANADIRASIGNACION'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "'FINALIZARTAREA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'CANCELAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "'MOSTRARCOMENTARIOS'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "'FINALIZARTAREA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'ASIGNAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "'MOSTRARCOMENTARIOS'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'ANADIRASIGNACION'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'CANCELAR'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP100( ) ;
                              }
                              nGXsfl_15_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              AV8finalizar = cgiGet( edtavFinalizar_Internalname);
                              AssignProp(sPrefix, false, edtavFinalizar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8finalizar)) ? AV28Finalizar_GXI : context.convertURL( context.PathToRelativeUrl( AV8finalizar))), !bGXsfl_15_Refreshing);
                              AssignProp(sPrefix, false, edtavFinalizar_Internalname, "SrcSet", context.GetImageSrcSet( AV8finalizar), true);
                              AV5asignar = cgiGet( edtavAsignar_Internalname);
                              AssignProp(sPrefix, false, edtavAsignar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)) ? AV27Asignar_GXI : context.convertURL( context.PathToRelativeUrl( AV5asignar))), !bGXsfl_15_Refreshing);
                              AssignProp(sPrefix, false, edtavAsignar_Internalname, "SrcSet", context.GetImageSrcSet( AV5asignar), true);
                              AV6comentarios = cgiGet( edtavComentarios_Internalname);
                              AssignProp(sPrefix, false, edtavComentarios_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV25Comentarios_GXI : context.convertURL( context.PathToRelativeUrl( AV6comentarios))), !bGXsfl_15_Refreshing);
                              AssignProp(sPrefix, false, edtavComentarios_Internalname, "SrcSet", context.GetImageSrcSet( AV6comentarios), true);
                              cmbavParticipantetableroid.Name = cmbavParticipantetableroid_Internalname;
                              cmbavParticipantetableroid.CurrentValue = cgiGet( cmbavParticipantetableroid_Internalname);
                              AV9ParticipanteTableroId = (short)(NumberUtil.Val( cgiGet( cmbavParticipantetableroid_Internalname), "."));
                              AssignAttri(sPrefix, false, cmbavParticipantetableroid_Internalname, StringUtil.LTrimStr( (decimal)(AV9ParticipanteTableroId), 4, 0));
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
                                          E11102 ();
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
                                          E12102 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDTAREAS2.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E13102 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDTAREAS2.REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E14102 ();
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
                                          E15102 ();
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
                                          E16102 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'FINALIZARTAREA'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'FinalizarTarea' */
                                          E17102 ();
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
                                          E18102 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'MOSTRARCOMENTARIOS'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavParticipantetableroid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'MostrarComentarios' */
                                          E19102 ();
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
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP100( ) ;
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
                        if ( nCmpId == 58 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0058" + sEvtType;
                           OldListadocomentarios = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldListadocomentarios) == 0 ) || ( StringUtil.StrCmp(OldListadocomentarios, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldListadocomentarios, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldListadocomentarios";
                              WebComp_GX_Process_Component = OldListadocomentarios;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0058", sEvtType, sEvt);
                           }
                           nGXsfl_15_webc_idx = (int)(NumberUtil.Val( sEvtType, "."));
                           WebCompHandler = "Listadocomentarios";
                           WebComp_GX_Process_Component = OldListadocomentarios;
                        }
                        else if ( nCmpId == 67 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0067" + sEvtType;
                           OldComponent1 = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldComponent1) == 0 ) || ( StringUtil.StrCmp(OldComponent1, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldComponent1, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldComponent1";
                              WebComp_GX_Process_Component = OldComponent1;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0067", sEvtType, sEvt);
                           }
                           nGXsfl_15_webc_idx = (int)(NumberUtil.Val( sEvtType, "."));
                           WebCompHandler = "Component1";
                           WebComp_GX_Process_Component = OldComponent1;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE102( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm102( ) ;
            }
         }
      }

      protected void PA102( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "enprocesowc.aspx")), "enprocesowc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "enprocesowc.aspx")))) ;
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridtareas2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subGridtareas2_Islastpage==1)&&(nGXsfl_15_idx+1>subGridtareas2_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridtareas2Container)) ;
         /* End function gxnrGridtareas2_newrow */
      }

      protected void gxgrGridtareas2_refresh( short A9TableroId ,
                                              short A18ParticipanteTableroId ,
                                              short AV9ParticipanteTableroId ,
                                              DateTime Gx_date ,
                                              string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E12102 ();
         GRIDTAREAS2_nCurrentRecord = 0;
         RF102( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridtareas2_refresh */
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
         E12102 ();
         RF102( ) ;
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

      protected void RF102( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridtareas2Container.ClearRows();
         }
         wbStart = 15;
         E14102 ();
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
         Gridtareas2Container.AddObjectProperty("GridName", "Gridtareas2");
         Gridtareas2Container.AddObjectProperty("CmpContext", sPrefix);
         Gridtareas2Container.AddObjectProperty("InMasterPage", "false");
         Gridtareas2Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Gridtareas2Container.AddObjectProperty("Class", "FreeStyleGrid");
         Gridtareas2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridtareas2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridtareas2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas2_Backcolorstyle), 1, 0, ".", "")));
         Gridtareas2Container.PageSize = subGridtareas2_fnc_Recordsperpage( );
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
            if ( StringUtil.StrCmp(WebComp_Listadocomentarios_Component, "") == 0 )
            {
               WebComp_Listadocomentarios = getWebComponent(GetType(), "GeneXus.Programs", "comentarioswc", new Object[] {context} );
               WebComp_Listadocomentarios.ComponentInit();
               WebComp_Listadocomentarios.Name = "ComentariosWC";
               WebComp_Listadocomentarios_Component = "ComentariosWC";
            }
            if ( ( StringUtil.Len( WebComp_Listadocomentarios_Component) != 0 ) && ( StringUtil.StrCmp(WebComp_Listadocomentarios_Component, "ComentariosWC") == 0 ) )
            {
               WebComp_Listadocomentarios.setjustcreated();
               WebComp_Listadocomentarios.componentprepare(new Object[] {(string)sPrefix+"W0058",(string)sGXsfl_15_idx,(short)A9TableroId,(short)A12TareaId});
               WebComp_Listadocomentarios.componentbind(new Object[] {(string)"",(string)""});
            }
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Listadocomentarios_Component) != 0 )
               {
                  WebComp_Listadocomentarios.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Component1_Component, "") == 0 )
            {
               WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", "listadoactividades", new Object[] {context} );
               WebComp_Component1.ComponentInit();
               WebComp_Component1.Name = "ListadoActividades";
               WebComp_Component1_Component = "ListadoActividades";
            }
            WebComp_Component1.setjustcreated();
            WebComp_Component1.componentprepare(new Object[] {(string)sPrefix+"W0067",(string)sGXsfl_15_idx,(short)A9TableroId,(short)A12TareaId});
            WebComp_Component1.componentbind(new Object[] {(string)"",(string)""});
            if ( 1 != 0 )
            {
               WebComp_Component1.componentstart();
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_152( ) ;
            /* Using cursor H00102 */
            pr_default.execute(0, new Object[] {A9TableroId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A46TareaEstado = H00102_A46TareaEstado[0];
               A12TareaId = H00102_A12TareaId[0];
               A24TareaFechaInicio = H00102_A24TareaFechaInicio[0];
               E13102 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 15;
            WB100( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes102( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTODAY", GetSecureSignedToken( sPrefix, Gx_date, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_TAREAID"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9"), context));
      }

      protected int subGridtareas2_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridtareas2_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridtareas2_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridtareas2_fnc_Currentpage( )
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

      protected void STRUP100( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11102 ();
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
         E11102 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11102( )
      {
         /* Start Routine */
         returnInSub = false;
         lblTitulo2_Caption = "<h3><center><strong><font color=\"white\">En proceso</font></strong></center></h3>";
         AssignProp(sPrefix, false, lblTitulo2_Internalname, "Caption", lblTitulo2_Caption, true);
         divT2_Class = "TablaProgress";
         AssignProp(sPrefix, false, divT2_Internalname, "Class", divT2_Class, true);
         tblAsignacion_Visible = 0;
         AssignProp(sPrefix, false, tblAsignacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblAsignacion_Visible), 5, 0), !bGXsfl_15_Refreshing);
         /* Using cursor H00103 */
         pr_default.execute(1, new Object[] {A9TableroId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A18ParticipanteTableroId = H00103_A18ParticipanteTableroId[0];
            AV15Usuarios.Load(A18ParticipanteTableroId);
            cmbavParticipantetableroid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV15Usuarios.gxTpr_Usuarioid), 4, 0)), AV15Usuarios.gxTpr_Usuarionombre+" "+AV15Usuarios.gxTpr_Usuarioapellido, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Listadocomentarios = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Listadocomentarios_Component), StringUtil.Lower( "Vacio")) != 0 )
         {
            WebComp_Listadocomentarios = getWebComponent(GetType(), "GeneXus.Programs", "vacio", new Object[] {context} );
            WebComp_Listadocomentarios.ComponentInit();
            WebComp_Listadocomentarios.Name = "Vacio";
            WebComp_Listadocomentarios_Component = "Vacio";
         }
         if ( StringUtil.Len( WebComp_Listadocomentarios_Component) != 0 )
         {
            WebComp_Listadocomentarios.setjustcreated();
            WebComp_Listadocomentarios.componentprepare(new Object[] {(string)sPrefix+"W0058",(string)sGXsfl_15_idx});
            WebComp_Listadocomentarios.componentbind(new Object[] {});
         }
         AV19estadoComentarios = false;
         AssignAttri(sPrefix, false, "AV19estadoComentarios", AV19estadoComentarios);
      }

      protected void E12102( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Using cursor H00104 */
         pr_default.execute(2, new Object[] {A9TableroId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A18ParticipanteTableroId = H00104_A18ParticipanteTableroId[0];
            AV15Usuarios.Load(A18ParticipanteTableroId);
            cmbavParticipantetableroid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV15Usuarios.gxTpr_Usuarioid), 4, 0)), AV15Usuarios.gxTpr_Usuarionombre+" "+AV15Usuarios.gxTpr_Usuarioapellido, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /*  Sending Event outputs  */
         cmbavParticipantetableroid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ParticipanteTableroId), 4, 0));
         AssignProp(sPrefix, false, cmbavParticipantetableroid_Internalname, "Values", cmbavParticipantetableroid.ToJavascriptSource(), true);
      }

      private void E13102( )
      {
         /* Gridtareas2_Load Routine */
         returnInSub = false;
         tblAsignacion_Visible = 0;
         AssignProp(sPrefix, false, tblAsignacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblAsignacion_Visible), 5, 0), !bGXsfl_15_Refreshing);
         AV13T2.Load(A9TableroId, A12TareaId);
         AV7contador = 0;
         /* Optimized group. */
         /* Using cursor H00105 */
         pr_default.execute(3, new Object[] {A9TableroId, A12TareaId});
         cV7contador = H00105_AV7contador[0];
         pr_default.close(3);
         AV7contador = (short)(AV7contador+cV7contador*1);
         /* End optimized group. */
         if ( AV7contador == 0 )
         {
            AV6comentarios = context.GetImagePath( "5a6feed5-8387-48bc-85cf-286b0f156319", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavComentarios_Internalname, AV6comentarios);
            AV25Comentarios_GXI = GXDbFile.PathToUrl( context.GetImagePath( "5a6feed5-8387-48bc-85cf-286b0f156319", "", context.GetTheme( )));
            edtavComentarios_Tooltiptext = "No tienes comentarios en esta tarea";
         }
         else
         {
            AV6comentarios = context.GetImagePath( "35c79c23-07c3-4fb0-9ce5-01610bd903e5", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavComentarios_Internalname, AV6comentarios);
            AV25Comentarios_GXI = GXDbFile.PathToUrl( context.GetImagePath( "35c79c23-07c3-4fb0-9ce5-01610bd903e5", "", context.GetTheme( )));
            edtavComentarios_Tooltiptext = "Tienes "+StringUtil.Trim( StringUtil.Str( (decimal)(AV7contador), 4, 0))+" comentario(s) en esta tarea";
         }
         if ( AV13T2.gxTpr_Responsableid != 0 )
         {
            AV11state = context.GetImagePath( "31259d64-c015-4774-9b0a-b45a79c24159", "", context.GetTheme( ));
            AV26State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "31259d64-c015-4774-9b0a-b45a79c24159", "", context.GetTheme( )));
            AV14U2.Load(AV13T2.gxTpr_Responsableid);
            AV10Responsable = StringUtil.Trim( AV14U2.gxTpr_Usuarioemail) + " - " + AV14U2.gxTpr_Usuarionombre + " " + AV14U2.gxTpr_Usuarioapellido;
         }
         else
         {
            AV11state = context.GetImagePath( "af695a2d-efff-4893-90bc-55652acff52a", "", context.GetTheme( ));
            AV26State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "af695a2d-efff-4893-90bc-55652acff52a", "", context.GetTheme( )));
            AV10Responsable = "Sin responsable asignado";
         }
         if ( (0==AV13T2.gxTpr_Responsableid) )
         {
            AV5asignar = context.GetImagePath( "20877732-78d2-44fd-ba33-6513f758b3b0", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavAsignar_Internalname, AV5asignar);
            AV27Asignar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "20877732-78d2-44fd-ba33-6513f758b3b0", "", context.GetTheme( )));
         }
         else
         {
            AV5asignar = context.GetImagePath( "949e9232-fe17-4603-8cb8-0a57d2612676", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavAsignar_Internalname, AV5asignar);
            AV27Asignar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "949e9232-fe17-4603-8cb8-0a57d2612676", "", context.GetTheme( )));
         }
         if ( AV13T2.gxTpr_Tareaestado == 1 )
         {
            AV8finalizar = context.GetImagePath( "1ecaff01-3fe8-49d0-9094-76c163a69ce8", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavFinalizar_Internalname, AV8finalizar);
            AV28Finalizar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "1ecaff01-3fe8-49d0-9094-76c163a69ce8", "", context.GetTheme( )));
         }
         else if ( AV13T2.gxTpr_Tareaestado == 2 )
         {
            AV8finalizar = context.GetImagePath( "9eed16cc-502d-4c66-a4e5-f47a9713bab0", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavFinalizar_Internalname, AV8finalizar);
            AV28Finalizar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "9eed16cc-502d-4c66-a4e5-f47a9713bab0", "", context.GetTheme( )));
         }
         else if ( AV13T2.gxTpr_Tareaestado == 3 )
         {
            AV8finalizar = context.GetImagePath( "63552255-35ba-4e00-8b53-9539f5d32760", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavFinalizar_Internalname, AV8finalizar);
            AV28Finalizar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "63552255-35ba-4e00-8b53-9539f5d32760", "", context.GetTheme( )));
         }
         else if ( AV13T2.gxTpr_Tareaestado == 4 )
         {
            AV8finalizar = context.GetImagePath( "cef39daf-d9a8-462d-9b0c-f8b6056364e8", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavFinalizar_Internalname, AV8finalizar);
            AV28Finalizar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "cef39daf-d9a8-462d-9b0c-f8b6056364e8", "", context.GetTheme( )));
         }
         if ( ( DateTimeUtil.ResetTime ( AV13T2.gxTpr_Tareafechainicio ) <= DateTimeUtil.ResetTime ( Gx_date ) ) && ( AV13T2.gxTpr_Tareaestado == 1 ) && ( DateTimeUtil.ResetTime ( AV13T2.gxTpr_Tareafechafin ) > DateTimeUtil.ResetTime ( Gx_date ) ) )
         {
            lblAdvisor2_Caption = "<div class=\"alert alert-warning\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>Debes iniciar y terminar la tarea antes de la fecha de finalización."+StringUtil.NewLine( )+"</div>";
         }
         else if ( DateTimeUtil.ResetTime ( AV13T2.gxTpr_Tareafechafin ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            lblAdvisor2_Caption = "<div class=\"alert alert-danger\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>La tarea ha vencido.  Completala o cambia las fechas de finalización"+StringUtil.NewLine( )+"</div>";
         }
         else if ( DateTimeUtil.ResetTime ( AV13T2.gxTpr_Tareafechafin ) == DateTimeUtil.ResetTime ( Gx_date ) )
         {
            lblAdvisor2_Caption = "<div class=\"alert alert-info\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>La tarea se vencerá hoy.  Debes completar esta tarea antes de la fecha de finalización"+StringUtil.NewLine( )+"</div>";
         }
         else
         {
            lblAdvisor2_Caption = "";
         }
         lblNombre2_Caption = "<center><h3><strong>"+StringUtil.Trim( AV13T2.gxTpr_Tareanombre)+"</strong></h3><h4>"+StringUtil.Trim( AV10Responsable)+"</h4></center>";
         lblInicia2_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         lblInicia2_Caption = StringUtil.StringReplace( lblInicia2_Caption, "#VALUE", context.localUtil.DToC( AV13T2.gxTpr_Tareafechainicio, 2, "/"));
         lblInicia2_Caption = StringUtil.StringReplace( lblInicia2_Caption, "#LABEL", "Inicia");
         lblFinaliza2_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         lblFinaliza2_Caption = StringUtil.StringReplace( lblFinaliza2_Caption, "#VALUE", context.localUtil.DToC( AV13T2.gxTpr_Tareafechafin, 2, "/"));
         lblFinaliza2_Caption = StringUtil.StringReplace( lblFinaliza2_Caption, "#LABEL", "Finaliza");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            context.DoAjaxLoad(15, Gridtareas2Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E14102( )
      {
         /* Gridtareas2_Refresh Routine */
         returnInSub = false;
         tblAsignacion_Visible = 0;
         AssignProp(sPrefix, false, tblAsignacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblAsignacion_Visible), 5, 0), !bGXsfl_15_Refreshing);
         AV13T2.Load(A9TableroId, A12TareaId);
         AV7contador = 0;
         /* Optimized group. */
         /* Using cursor H00106 */
         pr_default.execute(4, new Object[] {A9TableroId, A12TareaId});
         cV7contador = H00106_AV7contador[0];
         pr_default.close(4);
         AV7contador = (short)(AV7contador+cV7contador*1);
         /* End optimized group. */
         if ( AV7contador == 0 )
         {
            AV6comentarios = context.GetImagePath( "5a6feed5-8387-48bc-85cf-286b0f156319", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV25Comentarios_GXI : context.convertURL( context.PathToRelativeUrl( AV6comentarios))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "SrcSet", context.GetImageSrcSet( AV6comentarios), true);
            AV25Comentarios_GXI = GXDbFile.PathToUrl( context.GetImagePath( "5a6feed5-8387-48bc-85cf-286b0f156319", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV25Comentarios_GXI : context.convertURL( context.PathToRelativeUrl( AV6comentarios))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "SrcSet", context.GetImageSrcSet( AV6comentarios), true);
            edtavComentarios_Tooltiptext = "No tienes comentarios en esta tarea";
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "Tooltiptext", edtavComentarios_Tooltiptext, !bGXsfl_15_Refreshing);
         }
         else
         {
            AV6comentarios = context.GetImagePath( "35c79c23-07c3-4fb0-9ce5-01610bd903e5", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV25Comentarios_GXI : context.convertURL( context.PathToRelativeUrl( AV6comentarios))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "SrcSet", context.GetImageSrcSet( AV6comentarios), true);
            AV25Comentarios_GXI = GXDbFile.PathToUrl( context.GetImagePath( "35c79c23-07c3-4fb0-9ce5-01610bd903e5", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV25Comentarios_GXI : context.convertURL( context.PathToRelativeUrl( AV6comentarios))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "SrcSet", context.GetImageSrcSet( AV6comentarios), true);
            edtavComentarios_Tooltiptext = "Tienes "+StringUtil.Trim( StringUtil.Str( (decimal)(AV7contador), 4, 0))+" comentario(s) en esta tarea";
            AssignProp(sPrefix, false, edtavComentarios_Internalname, "Tooltiptext", edtavComentarios_Tooltiptext, !bGXsfl_15_Refreshing);
         }
         if ( (0==AV13T2.gxTpr_Responsableid) )
         {
            AV5asignar = context.GetImagePath( "20877732-78d2-44fd-ba33-6513f758b3b0", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)) ? AV27Asignar_GXI : context.convertURL( context.PathToRelativeUrl( AV5asignar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "SrcSet", context.GetImageSrcSet( AV5asignar), true);
            AV27Asignar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "20877732-78d2-44fd-ba33-6513f758b3b0", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)) ? AV27Asignar_GXI : context.convertURL( context.PathToRelativeUrl( AV5asignar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "SrcSet", context.GetImageSrcSet( AV5asignar), true);
         }
         else
         {
            AV5asignar = context.GetImagePath( "949e9232-fe17-4603-8cb8-0a57d2612676", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)) ? AV27Asignar_GXI : context.convertURL( context.PathToRelativeUrl( AV5asignar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "SrcSet", context.GetImageSrcSet( AV5asignar), true);
            AV27Asignar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "949e9232-fe17-4603-8cb8-0a57d2612676", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)) ? AV27Asignar_GXI : context.convertURL( context.PathToRelativeUrl( AV5asignar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavAsignar_Internalname, "SrcSet", context.GetImageSrcSet( AV5asignar), true);
         }
         if ( AV13T2.gxTpr_Responsableid != 0 )
         {
            AV11state = context.GetImagePath( "31259d64-c015-4774-9b0a-b45a79c24159", "", context.GetTheme( ));
            AV26State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "31259d64-c015-4774-9b0a-b45a79c24159", "", context.GetTheme( )));
            AV14U2.Load(AV13T2.gxTpr_Responsableid);
            AV10Responsable = StringUtil.Trim( AV14U2.gxTpr_Usuarioemail) + " - " + AV14U2.gxTpr_Usuarionombre + " " + AV14U2.gxTpr_Usuarioapellido;
         }
         else
         {
            AV11state = context.GetImagePath( "af695a2d-efff-4893-90bc-55652acff52a", "", context.GetTheme( ));
            AV26State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "af695a2d-efff-4893-90bc-55652acff52a", "", context.GetTheme( )));
            AV10Responsable = "Sin responsable asignado";
         }
         if ( AV13T2.gxTpr_Tareaestado == 1 )
         {
            AV8finalizar = context.GetImagePath( "1ecaff01-3fe8-49d0-9094-76c163a69ce8", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8finalizar)) ? AV28Finalizar_GXI : context.convertURL( context.PathToRelativeUrl( AV8finalizar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "SrcSet", context.GetImageSrcSet( AV8finalizar), true);
            AV28Finalizar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "1ecaff01-3fe8-49d0-9094-76c163a69ce8", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8finalizar)) ? AV28Finalizar_GXI : context.convertURL( context.PathToRelativeUrl( AV8finalizar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "SrcSet", context.GetImageSrcSet( AV8finalizar), true);
         }
         else if ( AV13T2.gxTpr_Tareaestado == 2 )
         {
            AV8finalizar = context.GetImagePath( "9eed16cc-502d-4c66-a4e5-f47a9713bab0", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8finalizar)) ? AV28Finalizar_GXI : context.convertURL( context.PathToRelativeUrl( AV8finalizar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "SrcSet", context.GetImageSrcSet( AV8finalizar), true);
            AV28Finalizar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "9eed16cc-502d-4c66-a4e5-f47a9713bab0", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8finalizar)) ? AV28Finalizar_GXI : context.convertURL( context.PathToRelativeUrl( AV8finalizar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "SrcSet", context.GetImageSrcSet( AV8finalizar), true);
         }
         else if ( AV13T2.gxTpr_Tareaestado == 3 )
         {
            AV8finalizar = context.GetImagePath( "63552255-35ba-4e00-8b53-9539f5d32760", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8finalizar)) ? AV28Finalizar_GXI : context.convertURL( context.PathToRelativeUrl( AV8finalizar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "SrcSet", context.GetImageSrcSet( AV8finalizar), true);
            AV28Finalizar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "63552255-35ba-4e00-8b53-9539f5d32760", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8finalizar)) ? AV28Finalizar_GXI : context.convertURL( context.PathToRelativeUrl( AV8finalizar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "SrcSet", context.GetImageSrcSet( AV8finalizar), true);
         }
         else if ( AV13T2.gxTpr_Tareaestado == 4 )
         {
            AV8finalizar = context.GetImagePath( "cef39daf-d9a8-462d-9b0c-f8b6056364e8", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8finalizar)) ? AV28Finalizar_GXI : context.convertURL( context.PathToRelativeUrl( AV8finalizar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "SrcSet", context.GetImageSrcSet( AV8finalizar), true);
            AV28Finalizar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "cef39daf-d9a8-462d-9b0c-f8b6056364e8", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8finalizar)) ? AV28Finalizar_GXI : context.convertURL( context.PathToRelativeUrl( AV8finalizar))), !bGXsfl_15_Refreshing);
            AssignProp(sPrefix, false, edtavFinalizar_Internalname, "SrcSet", context.GetImageSrcSet( AV8finalizar), true);
         }
         if ( ( DateTimeUtil.ResetTime ( AV13T2.gxTpr_Tareafechainicio ) <= DateTimeUtil.ResetTime ( Gx_date ) ) && ( AV13T2.gxTpr_Tareaestado == 1 ) && ( DateTimeUtil.ResetTime ( AV13T2.gxTpr_Tareafechafin ) > DateTimeUtil.ResetTime ( Gx_date ) ) )
         {
            lblAdvisor2_Caption = "<div class=\"alert alert-warning\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>Debes iniciar y terminar la tarea antes de la fecha de finalización."+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblAdvisor2_Internalname, "Caption", lblAdvisor2_Caption, !bGXsfl_15_Refreshing);
         }
         else if ( DateTimeUtil.ResetTime ( AV13T2.gxTpr_Tareafechafin ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            lblAdvisor2_Caption = "<div class=\"alert alert-danger\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>La tarea ha vencido.  Completala o cambia las fechas de finalización"+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblAdvisor2_Internalname, "Caption", lblAdvisor2_Caption, !bGXsfl_15_Refreshing);
         }
         else if ( DateTimeUtil.ResetTime ( AV13T2.gxTpr_Tareafechafin ) == DateTimeUtil.ResetTime ( Gx_date ) )
         {
            lblAdvisor2_Caption = "<div class=\"alert alert-info\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>La tarea se vencerá hoy.  Debes completar esta tarea antes de la fecha de finalización"+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblAdvisor2_Internalname, "Caption", lblAdvisor2_Caption, !bGXsfl_15_Refreshing);
         }
         else
         {
            lblAdvisor2_Caption = "";
            AssignProp(sPrefix, false, lblAdvisor2_Internalname, "Caption", lblAdvisor2_Caption, !bGXsfl_15_Refreshing);
         }
         lblNombre2_Caption = "<center><h3><strong>"+StringUtil.Trim( AV13T2.gxTpr_Tareanombre)+"</strong></h3><h4>"+StringUtil.Trim( AV10Responsable)+"</h4></center>";
         AssignProp(sPrefix, false, lblNombre2_Internalname, "Caption", lblNombre2_Caption, !bGXsfl_15_Refreshing);
         lblInicia2_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         AssignProp(sPrefix, false, lblInicia2_Internalname, "Caption", lblInicia2_Caption, !bGXsfl_15_Refreshing);
         lblInicia2_Caption = StringUtil.StringReplace( lblInicia2_Caption, "#VALUE", context.localUtil.DToC( AV13T2.gxTpr_Tareafechainicio, 2, "/"));
         AssignProp(sPrefix, false, lblInicia2_Internalname, "Caption", lblInicia2_Caption, !bGXsfl_15_Refreshing);
         lblInicia2_Caption = StringUtil.StringReplace( lblInicia2_Caption, "#LABEL", "Inicia");
         AssignProp(sPrefix, false, lblInicia2_Internalname, "Caption", lblInicia2_Caption, !bGXsfl_15_Refreshing);
         lblFinaliza2_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         AssignProp(sPrefix, false, lblFinaliza2_Internalname, "Caption", lblFinaliza2_Caption, !bGXsfl_15_Refreshing);
         lblFinaliza2_Caption = StringUtil.StringReplace( lblFinaliza2_Caption, "#VALUE", context.localUtil.DToC( AV13T2.gxTpr_Tareafechafin, 2, "/"));
         AssignProp(sPrefix, false, lblFinaliza2_Internalname, "Caption", lblFinaliza2_Caption, !bGXsfl_15_Refreshing);
         lblFinaliza2_Caption = StringUtil.StringReplace( lblFinaliza2_Caption, "#LABEL", "Finaliza");
         AssignProp(sPrefix, false, lblFinaliza2_Internalname, "Caption", lblFinaliza2_Caption, !bGXsfl_15_Refreshing);
         /*  Sending Event outputs  */
      }

      protected void E15102( )
      {
         /* 'Asignar' Routine */
         returnInSub = false;
         AV13T2.Load(A9TableroId, A12TareaId);
         if ( (0==AV13T2.gxTpr_Responsableid) )
         {
            tblAsignacion_Visible = 1;
            AssignProp(sPrefix, false, tblAsignacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblAsignacion_Visible), 5, 0), !bGXsfl_15_Refreshing);
         }
         else
         {
            AV13T2.gxTv_SdtTareas_Responsableid_SetNull();
            AV13T2.Save();
            if ( AV13T2.Success() )
            {
               context.CommitDataStores("enprocesowc",pr_default);
               AV16sdt_sa.gxTpr_Title = "Responsable eliminado";
               AV16sdt_sa.gxTpr_Html = "Se ha eliminado el responsable de esta tarea.";
               AV16sdt_sa.gxTpr_Timer = 4000;
               AV16sdt_sa.gxTpr_Allowoutsideclick = true;
               AV16sdt_sa.gxTpr_Type = "info";
               this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV16sdt_sa});
               cmbavParticipantetableroid.removeAllItems();
               context.DoAjaxRefreshCmp(sPrefix);
            }
            else
            {
               context.RollbackDataStores("enprocesowc",pr_default);
               AV16sdt_sa.gxTpr_Title = "Ha ocurrido un error";
               AV16sdt_sa.gxTpr_Html = "Ha ocurrido un error en la asignación.  Por favor inténtelo nuevamente.";
               AV16sdt_sa.gxTpr_Timer = 4000;
               AV16sdt_sa.gxTpr_Allowoutsideclick = true;
               AV16sdt_sa.gxTpr_Type = "success";
               this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV16sdt_sa});
            }
         }
         /*  Sending Event outputs  */
         cmbavParticipantetableroid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ParticipanteTableroId), 4, 0));
         AssignProp(sPrefix, false, cmbavParticipantetableroid_Internalname, "Values", cmbavParticipantetableroid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV16sdt_sa", AV16sdt_sa);
      }

      protected void E16102( )
      {
         /* 'AnadirAsignacion' Routine */
         returnInSub = false;
         AV13T2.Load(A9TableroId, A12TareaId);
         AV13T2.gxTpr_Responsableid = AV9ParticipanteTableroId;
         AV13T2.Save();
         if ( AV13T2.Success() )
         {
            context.CommitDataStores("enprocesowc",pr_default);
            AV16sdt_sa.gxTpr_Title = "Responsable asignado";
            AV16sdt_sa.gxTpr_Html = "Se ha asignado el responsable de esta tarea.";
            AV16sdt_sa.gxTpr_Timer = 4000;
            AV16sdt_sa.gxTpr_Allowoutsideclick = true;
            AV16sdt_sa.gxTpr_Type = "success";
            this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV16sdt_sa});
            cmbavParticipantetableroid.removeAllItems();
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            AV16sdt_sa.gxTpr_Title = "Ha ocurrido un error";
            AV16sdt_sa.gxTpr_Html = "Ha ocurrido un error en la asignación.  Por favor inténtelo nuevamente.";
            AV16sdt_sa.gxTpr_Timer = 4000;
            AV16sdt_sa.gxTpr_Allowoutsideclick = true;
            AV16sdt_sa.gxTpr_Type = "success";
            this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV16sdt_sa});
            context.RollbackDataStores("enprocesowc",pr_default);
         }
         /*  Sending Event outputs  */
         cmbavParticipantetableroid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ParticipanteTableroId), 4, 0));
         AssignProp(sPrefix, false, cmbavParticipantetableroid_Internalname, "Values", cmbavParticipantetableroid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV16sdt_sa", AV16sdt_sa);
      }

      protected void E17102( )
      {
         /* 'FinalizarTarea' Routine */
         returnInSub = false;
         AV13T2.Load(A9TableroId, A12TareaId);
         if ( (0==AV13T2.gxTpr_Responsableid) || AV13T2.gxTv_SdtTareas_Responsableid_IsNull( ) )
         {
            AV16sdt_sa.gxTpr_Title = "No puedes finalizar la tarea sin un responsable asignado";
            AV16sdt_sa.gxTpr_Html = "Debes asignar un responsable para poder finalizar una tarea";
            AV16sdt_sa.gxTpr_Timer = 4000;
            AV16sdt_sa.gxTpr_Allowoutsideclick = true;
            AV16sdt_sa.gxTpr_Type = "error";
            this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV16sdt_sa});
         }
         else
         {
            GXt_int1 = AV17contadorActividades;
            GXt_int2 = AV13T2.gxTpr_Tableroid;
            GXt_int3 = AV13T2.gxTpr_Tareaid;
            new getactividadescompletadas(context ).execute( ref  GXt_int2, ref  GXt_int3, ref  GXt_int1) ;
            AV13T2.gxTpr_Tableroid = GXt_int2;
            AV13T2.gxTpr_Tareaid = GXt_int3;
            AV17contadorActividades = GXt_int1;
            if ( AV17contadorActividades != 0 )
            {
               AV16sdt_sa.gxTpr_Title = "No se puede completar la tarea";
               AV16sdt_sa.gxTpr_Html = "Aún tienes actividades pendientes por completar antes de poder finalizar esta tarea.";
               AV16sdt_sa.gxTpr_Timer = 4000;
               AV16sdt_sa.gxTpr_Allowoutsideclick = true;
               AV16sdt_sa.gxTpr_Type = "error";
               this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV16sdt_sa});
            }
            else
            {
               AV13T2.gxTpr_Tareaestado = 3;
               AV13T2.Save();
               if ( AV13T2.Success() )
               {
                  context.CommitDataStores("enprocesowc",pr_default);
                  AV16sdt_sa.gxTpr_Title = "Tarea completada";
                  AV16sdt_sa.gxTpr_Html = "Se ha completado la tarea exitosamente.";
                  AV16sdt_sa.gxTpr_Timer = 4000;
                  AV16sdt_sa.gxTpr_Allowoutsideclick = true;
                  AV16sdt_sa.gxTpr_Type = "success";
                  this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV16sdt_sa});
                  context.DoAjaxRefreshCmp(sPrefix);
               }
               else
               {
                  AV16sdt_sa.gxTpr_Title = "Ha ocurrido un error";
                  AV16sdt_sa.gxTpr_Html = "Ha ocurrido un error al completar la tarea.  Por favor inténtelo nuevamente.";
                  AV16sdt_sa.gxTpr_Timer = 4000;
                  AV16sdt_sa.gxTpr_Allowoutsideclick = true;
                  AV16sdt_sa.gxTpr_Type = "error";
                  this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV16sdt_sa});
                  context.RollbackDataStores("enprocesowc",pr_default);
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV16sdt_sa", AV16sdt_sa);
         cmbavParticipantetableroid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ParticipanteTableroId), 4, 0));
         AssignProp(sPrefix, false, cmbavParticipantetableroid_Internalname, "Values", cmbavParticipantetableroid.ToJavascriptSource(), true);
      }

      protected void E18102( )
      {
         /* 'Cancelar' Routine */
         returnInSub = false;
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         cmbavParticipantetableroid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ParticipanteTableroId), 4, 0));
         AssignProp(sPrefix, false, cmbavParticipantetableroid_Internalname, "Values", cmbavParticipantetableroid.ToJavascriptSource(), true);
      }

      protected void E19102( )
      {
         /* 'MostrarComentarios' Routine */
         returnInSub = false;
         if ( ! AV19estadoComentarios )
         {
            /* Object Property */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               bDynCreated_Listadocomentarios = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Listadocomentarios_Component), StringUtil.Lower( "ComentariosWC")) != 0 )
            {
               WebComp_Listadocomentarios = getWebComponent(GetType(), "GeneXus.Programs", "comentarioswc", new Object[] {context} );
               WebComp_Listadocomentarios.ComponentInit();
               WebComp_Listadocomentarios.Name = "ComentariosWC";
               WebComp_Listadocomentarios_Component = "ComentariosWC";
            }
            if ( StringUtil.Len( WebComp_Listadocomentarios_Component) != 0 )
            {
               WebComp_Listadocomentarios.setjustcreated();
               WebComp_Listadocomentarios.componentprepare(new Object[] {(string)sPrefix+"W0058",(string)sGXsfl_15_idx,(short)A9TableroId,(short)A12TareaId});
               WebComp_Listadocomentarios.componentbind(new Object[] {(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Listadocomentarios )
            {
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0058"+sGXsfl_15_idx);
               WebComp_Listadocomentarios.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            AV19estadoComentarios = true;
            AssignAttri(sPrefix, false, "AV19estadoComentarios", AV19estadoComentarios);
         }
         else if ( AV19estadoComentarios )
         {
            /* Object Property */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               bDynCreated_Listadocomentarios = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Listadocomentarios_Component), StringUtil.Lower( "Vacio")) != 0 )
            {
               WebComp_Listadocomentarios = getWebComponent(GetType(), "GeneXus.Programs", "vacio", new Object[] {context} );
               WebComp_Listadocomentarios.ComponentInit();
               WebComp_Listadocomentarios.Name = "Vacio";
               WebComp_Listadocomentarios_Component = "Vacio";
            }
            if ( StringUtil.Len( WebComp_Listadocomentarios_Component) != 0 )
            {
               WebComp_Listadocomentarios.setjustcreated();
               WebComp_Listadocomentarios.componentprepare(new Object[] {(string)sPrefix+"W0058",(string)sGXsfl_15_idx});
               WebComp_Listadocomentarios.componentbind(new Object[] {});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Listadocomentarios )
            {
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0058"+sGXsfl_15_idx);
               WebComp_Listadocomentarios.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            AV19estadoComentarios = false;
            AssignAttri(sPrefix, false, "AV19estadoComentarios", AV19estadoComentarios);
         }
         /*  Sending Event outputs  */
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
         PA102( ) ;
         WS102( ) ;
         WE102( ) ;
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
         PA102( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "enprocesowc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA102( ) ;
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
         PA102( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS102( ) ;
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
         WS102( ) ;
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
         WE102( ) ;
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
         if ( ! ( WebComp_Listadocomentarios == null ) )
         {
            WebComp_Listadocomentarios.componentjscripts();
         }
         if ( ! ( WebComp_Component1 == null ) )
         {
            WebComp_Component1.componentjscripts();
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
         if ( StringUtil.StrCmp(WebComp_Listadocomentarios_Component, "") == 0 )
         {
            WebComp_Listadocomentarios = getWebComponent(GetType(), "GeneXus.Programs", "comentarioswc", new Object[] {context} );
            WebComp_Listadocomentarios.ComponentInit();
            WebComp_Listadocomentarios.Name = "ComentariosWC";
            WebComp_Listadocomentarios_Component = "ComentariosWC";
         }
         if ( ! ( WebComp_Listadocomentarios == null ) )
         {
            if ( StringUtil.Len( WebComp_Listadocomentarios_Component) != 0 )
            {
               WebComp_Listadocomentarios.componentthemes();
            }
         }
         if ( StringUtil.StrCmp(WebComp_Component1_Component, "") == 0 )
         {
            WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", "listadoactividades", new Object[] {context} );
            WebComp_Component1.ComponentInit();
            WebComp_Component1.Name = "ListadoActividades";
            WebComp_Component1_Component = "ListadoActividades";
         }
         if ( ! ( WebComp_Component1 == null ) )
         {
            WebComp_Component1.componentthemes();
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022101613105433", true, true);
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
         context.AddJavascriptSource("enprocesowc.js", "?2022101613105433", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/js/sweetalert2.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/jquery-3.5.1.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/popper.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/bootstrap.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/RAMP_AddOns_SweetAlertRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_152( )
      {
         edtavFinalizar_Internalname = sPrefix+"vFINALIZAR_"+sGXsfl_15_idx;
         edtavAsignar_Internalname = sPrefix+"vASIGNAR_"+sGXsfl_15_idx;
         edtavComentarios_Internalname = sPrefix+"vCOMENTARIOS_"+sGXsfl_15_idx;
         cmbavParticipantetableroid_Internalname = sPrefix+"vPARTICIPANTETABLEROID_"+sGXsfl_15_idx;
         imgImage7_Internalname = sPrefix+"IMAGE7_"+sGXsfl_15_idx;
         imgImage8_Internalname = sPrefix+"IMAGE8_"+sGXsfl_15_idx;
         lblNombre2_Internalname = sPrefix+"NOMBRE2_"+sGXsfl_15_idx;
         edtTareaId_Internalname = sPrefix+"TAREAID_"+sGXsfl_15_idx;
         lblAdvisor2_Internalname = sPrefix+"ADVISOR2_"+sGXsfl_15_idx;
         lblInicia2_Internalname = sPrefix+"INICIA2_"+sGXsfl_15_idx;
         lblFinaliza2_Internalname = sPrefix+"FINALIZA2_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtavFinalizar_Internalname = sPrefix+"vFINALIZAR_"+sGXsfl_15_fel_idx;
         edtavAsignar_Internalname = sPrefix+"vASIGNAR_"+sGXsfl_15_fel_idx;
         edtavComentarios_Internalname = sPrefix+"vCOMENTARIOS_"+sGXsfl_15_fel_idx;
         cmbavParticipantetableroid_Internalname = sPrefix+"vPARTICIPANTETABLEROID_"+sGXsfl_15_fel_idx;
         imgImage7_Internalname = sPrefix+"IMAGE7_"+sGXsfl_15_fel_idx;
         imgImage8_Internalname = sPrefix+"IMAGE8_"+sGXsfl_15_fel_idx;
         lblNombre2_Internalname = sPrefix+"NOMBRE2_"+sGXsfl_15_fel_idx;
         edtTareaId_Internalname = sPrefix+"TAREAID_"+sGXsfl_15_fel_idx;
         lblAdvisor2_Internalname = sPrefix+"ADVISOR2_"+sGXsfl_15_fel_idx;
         lblInicia2_Internalname = sPrefix+"INICIA2_"+sGXsfl_15_fel_idx;
         lblFinaliza2_Internalname = sPrefix+"FINALIZA2_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         SubsflControlProps_152( ) ;
         WB100( ) ;
         Gridtareas2Row = GXWebRow.GetNew(context,Gridtareas2Container);
         if ( subGridtareas2_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridtareas2_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridtareas2_Class, "") != 0 )
            {
               subGridtareas2_Linesclass = subGridtareas2_Class+"Odd";
            }
         }
         else if ( subGridtareas2_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridtareas2_Backstyle = 0;
            subGridtareas2_Backcolor = subGridtareas2_Allbackcolor;
            if ( StringUtil.StrCmp(subGridtareas2_Class, "") != 0 )
            {
               subGridtareas2_Linesclass = subGridtareas2_Class+"Uniform";
            }
         }
         else if ( subGridtareas2_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridtareas2_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridtareas2_Class, "") != 0 )
            {
               subGridtareas2_Linesclass = subGridtareas2_Class+"Odd";
            }
            subGridtareas2_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridtareas2_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridtareas2_Backstyle = 1;
            if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
            {
               subGridtareas2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtareas2_Class, "") != 0 )
               {
                  subGridtareas2_Linesclass = subGridtareas2_Class+"Even";
               }
            }
            else
            {
               subGridtareas2_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridtareas2_Class, "") != 0 )
               {
                  subGridtareas2_Linesclass = subGridtareas2_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridtareas2_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_15_idx+"\">") ;
         }
         /* Table start */
         Gridtareas2Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblGridtareas2table1_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"TableWidget",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Gridtareas2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Gridtareas2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTable7_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Gridtareas2Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTable10_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Gridtareas2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Gridtareas2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"finalizar",(string)"gx-form-item ImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavFinalizar_Enabled!=0)&&(edtavFinalizar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 26,'"+sPrefix+"',false,'',15)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV8finalizar_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV8finalizar))&&String.IsNullOrEmpty(StringUtil.RTrim( AV28Finalizar_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV8finalizar)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV8finalizar)) ? AV28Finalizar_GXI : context.PathToRelativeUrl( AV8finalizar));
         Gridtareas2Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavFinalizar_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"Finalizar tarea",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)5,(string)edtavFinalizar_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'FINALIZARTAREA\\'."+sGXsfl_15_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV8finalizar_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("cell");
         }
         Gridtareas2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"asignar",(string)"gx-form-item ImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavAsignar_Enabled!=0)&&(edtavAsignar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 29,'"+sPrefix+"',false,'',15)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV5asignar_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar))&&String.IsNullOrEmpty(StringUtil.RTrim( AV27Asignar_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5asignar)) ? AV27Asignar_GXI : context.PathToRelativeUrl( AV5asignar));
         Gridtareas2Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavAsignar_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"Asignar o eliminar responsable",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)5,(string)edtavAsignar_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ASIGNAR\\'."+sGXsfl_15_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV5asignar_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("cell");
         }
         Gridtareas2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"comentarios",(string)"gx-form-item ImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavComentarios_Enabled!=0)&&(edtavComentarios_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 32,'"+sPrefix+"',false,'',15)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV6comentarios_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios))&&String.IsNullOrEmpty(StringUtil.RTrim( AV25Comentarios_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV25Comentarios_GXI : context.PathToRelativeUrl( AV6comentarios));
         Gridtareas2Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavComentarios_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)edtavComentarios_Tooltiptext,(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)5,(string)edtavComentarios_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'MOSTRARCOMENTARIOS\\'."+sGXsfl_15_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV6comentarios_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("cell");
         }
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("row");
         }
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("table");
         }
         /* End of table */
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Gridtareas2Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblAsignacion_Internalname+"_"+sGXsfl_15_idx,(int)tblAsignacion_Visible,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Gridtareas2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Gridtareas2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = " " + ((cmbavParticipantetableroid.Enabled!=0)&&(cmbavParticipantetableroid.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 39,'"+sPrefix+"',false,'"+sGXsfl_15_idx+"',15)\"" : " ");
         if ( ( cmbavParticipantetableroid.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vPARTICIPANTETABLEROID_" + sGXsfl_15_idx;
            cmbavParticipantetableroid.Name = GXCCtl;
            cmbavParticipantetableroid.WebTags = "";
            if ( cmbavParticipantetableroid.ItemCount > 0 )
            {
               AV9ParticipanteTableroId = (short)(NumberUtil.Val( cmbavParticipantetableroid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9ParticipanteTableroId), 4, 0))), "."));
               AssignAttri(sPrefix, false, cmbavParticipantetableroid_Internalname, StringUtil.LTrimStr( (decimal)(AV9ParticipanteTableroId), 4, 0));
            }
         }
         /* ComboBox */
         Gridtareas2Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavParticipantetableroid,(string)cmbavParticipantetableroid_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV9ParticipanteTableroId), 4, 0)),(short)1,(string)cmbavParticipantetableroid_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)1,(short)1,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavParticipantetableroid.Enabled!=0)&&(cmbavParticipantetableroid.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,39);\"" : " "),(string)"",(bool)true,(short)1});
         cmbavParticipantetableroid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ParticipanteTableroId), 4, 0));
         AssignProp(sPrefix, false, cmbavParticipantetableroid_Internalname, "Values", (string)(cmbavParticipantetableroid.ToJavascriptSource()), !bGXsfl_15_Refreshing);
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("cell");
         }
         Gridtareas2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTable12_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Active images/pictures */
         TempTags = " " + ((imgImage7_Enabled!=0)&&(imgImage7_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 43,'"+sPrefix+"',false,'',0)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "37af6e8e-5105-40d2-94ea-61da60f7a7ab", "", context.GetTheme( )));
         Gridtareas2Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgImage7_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"",(short)0,(short)0,(short)15,(string)"px",(short)15,(string)"px",(short)0,(short)0,(short)5,(string)imgImage7_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ANADIRASIGNACION\\'."+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)" "+"data-gx-image"+" "+TempTags,(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Active images/pictures */
         TempTags = " " + ((imgImage8_Enabled!=0)&&(imgImage8_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 45,'"+sPrefix+"',false,'',0)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "ec15b36c-8f5a-4ad5-be9c-712eec67d653", "", context.GetTheme( )));
         Gridtareas2Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgImage8_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"",(short)0,(short)0,(short)15,(string)"px",(short)15,(string)"px",(short)0,(short)0,(short)5,(string)imgImage8_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'CANCELAR\\'."+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)" "+"data-gx-image"+" "+TempTags,(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("cell");
         }
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("row");
         }
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("table");
         }
         /* End of table */
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         sendrow_15230( ) ;
      }

      protected void sendrow_15230( )
      {
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Gridtareas2Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNombre2_Internalname,(string)lblNombre2_Caption,(string)"",(string)"",(string)lblNombre2_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtTareaId_Internalname,(string)"Tarea Id",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Gridtareas2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTareaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTareaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtTareaId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)15,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Gridtareas2Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTable1_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Gridtareas2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Gridtareas2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0058"+sGXsfl_15_idx, StringUtil.RTrim( WebComp_Listadocomentarios_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0058"+sGXsfl_15_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_15_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Listadocomentarios_Component) != 0 )
            {
               if ( StringUtil.StrCmp(WebComp_Listadocomentarios_Component, "") == 0 )
               {
                  WebComp_Listadocomentarios = getWebComponent(GetType(), "GeneXus.Programs", "comentarioswc", new Object[] {context} );
                  WebComp_Listadocomentarios.ComponentInit();
                  WebComp_Listadocomentarios.Name = "ComentariosWC";
                  WebComp_Listadocomentarios_Component = "ComentariosWC";
               }
               if ( ( StringUtil.Len( WebComp_Listadocomentarios_Component) != 0 ) && ( StringUtil.StrCmp(WebComp_Listadocomentarios_Component, "ComentariosWC") == 0 ) )
               {
                  WebComp_Listadocomentarios.setjustcreated();
                  WebComp_Listadocomentarios.componentprepare(new Object[] {(string)sPrefix+"W0058",(string)sGXsfl_15_idx,(short)A9TableroId,(short)A12TareaId});
                  WebComp_Listadocomentarios.componentbind(new Object[] {(string)"",(string)""});
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0058"+sGXsfl_15_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Listadocomentarios_Component) != 0 )
                     {
                        WebComp_Listadocomentarios.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldListadocomentarios), StringUtil.Lower( WebComp_Listadocomentarios_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0058"+sGXsfl_15_idx);
               }
               WebComp_Listadocomentarios.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldListadocomentarios), StringUtil.Lower( WebComp_Listadocomentarios_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Listadocomentarios_Component = "";
         WebComp_Listadocomentarios.componentjscripts();
         Gridtareas2Row.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Listadocomentarios"});
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("cell");
         }
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("row");
         }
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("table");
         }
         /* End of table */
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Gridtareas2Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblAdvisor2_Internalname,(string)lblAdvisor2_Caption,(string)"",(string)"",(string)lblAdvisor2_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Gridtareas2Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTable13_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Gridtareas2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Gridtareas2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0067"+sGXsfl_15_idx, StringUtil.RTrim( WebComp_Component1_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0067"+sGXsfl_15_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_15_Refreshing )
         {
            if ( StringUtil.StrCmp(WebComp_Component1_Component, "") == 0 )
            {
               WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", "listadoactividades", new Object[] {context} );
               WebComp_Component1.ComponentInit();
               WebComp_Component1.Name = "ListadoActividades";
               WebComp_Component1_Component = "ListadoActividades";
            }
            WebComp_Component1.setjustcreated();
            WebComp_Component1.componentprepare(new Object[] {(string)sPrefix+"W0067",(string)sGXsfl_15_idx,(short)A9TableroId,(short)A12TareaId});
            WebComp_Component1.componentbind(new Object[] {(string)"",(string)""});
            if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0067"+sGXsfl_15_idx, cgiGet( "_EventName"), 1) != 0 ) )
            {
               if ( 1 != 0 )
               {
                  WebComp_Component1.componentstart();
               }
            }
            if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldComponent1), StringUtil.Lower( WebComp_Component1_Component)) != 0 ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0067"+sGXsfl_15_idx);
            }
            WebComp_Component1.componentdraw();
            if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldComponent1), StringUtil.Lower( WebComp_Component1_Component)) != 0 ) )
            {
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Component1_Component = "";
         WebComp_Component1.componentjscripts();
         Gridtareas2Row.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Component1"});
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("cell");
         }
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("row");
         }
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("table");
         }
         /* End of table */
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTable14_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Text block */
         Gridtareas2Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblInicia2_Internalname,(string)lblInicia2_Caption,(string)"",(string)"",(string)lblInicia2_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Text block */
         Gridtareas2Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblFinaliza2_Internalname,(string)lblFinaliza2_Caption,(string)"",(string)"",(string)lblFinaliza2_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("cell");
         }
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("row");
         }
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            Gridtareas2Container.CloseTag("table");
         }
         /* End of table */
         send_integrity_lvl_hashes102( ) ;
         /* End of Columns property logic. */
         Gridtareas2Container.AddRow(Gridtareas2Row);
         nGXsfl_15_idx = ((subGridtareas2_Islastpage==1)&&(nGXsfl_15_idx+1>subGridtareas2_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
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
         if ( Gridtareas2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Gridtareas2Container"+"DivS\" data-gxgridid=\"15\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridtareas2_Internalname, subGridtareas2_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Gridtareas2Container.AddObjectProperty("GridName", "Gridtareas2");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Gridtareas2Container = new GXWebGrid( context);
            }
            else
            {
               Gridtareas2Container.Clear();
            }
            Gridtareas2Container.SetIsFreestyle(true);
            Gridtareas2Container.SetWrapped(nGXWrapped);
            Gridtareas2Container.AddObjectProperty("GridName", "Gridtareas2");
            Gridtareas2Container.AddObjectProperty("Header", subGridtareas2_Header);
            Gridtareas2Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Gridtareas2Container.AddObjectProperty("Class", "FreeStyleGrid");
            Gridtareas2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridtareas2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridtareas2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas2_Backcolorstyle), 1, 0, ".", "")));
            Gridtareas2Container.AddObjectProperty("CmpContext", sPrefix);
            Gridtareas2Container.AddObjectProperty("InMasterPage", "false");
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Column.AddObjectProperty("Value", context.convertURL( AV8finalizar));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Column.AddObjectProperty("Value", context.convertURL( AV5asignar));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Column.AddObjectProperty("Value", context.convertURL( AV6comentarios));
            Gridtareas2Column.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavComentarios_Tooltiptext));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ParticipanteTableroId), 4, 0, ".", "")));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Column.AddObjectProperty("Value", context.convertURL( context.GetImagePath( "37af6e8e-5105-40d2-94ea-61da60f7a7ab", "", context.GetTheme( ))));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Column.AddObjectProperty("Value", context.convertURL( context.GetImagePath( "ec15b36c-8f5a-4ad5-be9c-712eec67d653", "", context.GetTheme( ))));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Column.AddObjectProperty("Value", lblNombre2_Caption);
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ".", "")));
            Gridtareas2Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTareaId_Visible), 5, 0, ".", "")));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Column.AddObjectProperty("Value", lblAdvisor2_Caption);
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Column.AddObjectProperty("Value", lblInicia2_Caption);
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas2Column.AddObjectProperty("Value", lblFinaliza2_Caption);
            Gridtareas2Container.AddColumnProperties(Gridtareas2Column);
            Gridtareas2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas2_Selectedindex), 4, 0, ".", "")));
            Gridtareas2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas2_Allowselection), 1, 0, ".", "")));
            Gridtareas2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas2_Selectioncolor), 9, 0, ".", "")));
            Gridtareas2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas2_Allowhovering), 1, 0, ".", "")));
            Gridtareas2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas2_Hoveringcolor), 9, 0, ".", "")));
            Gridtareas2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas2_Allowcollapsing), 1, 0, ".", "")));
            Gridtareas2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas2_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         imgImage3_Internalname = sPrefix+"IMAGE3";
         lblTitulo2_Internalname = sPrefix+"TITULO2";
         edtavFinalizar_Internalname = sPrefix+"vFINALIZAR";
         edtavAsignar_Internalname = sPrefix+"vASIGNAR";
         edtavComentarios_Internalname = sPrefix+"vCOMENTARIOS";
         tblTable10_Internalname = sPrefix+"TABLE10";
         cmbavParticipantetableroid_Internalname = sPrefix+"vPARTICIPANTETABLEROID";
         imgImage7_Internalname = sPrefix+"IMAGE7";
         imgImage8_Internalname = sPrefix+"IMAGE8";
         divTable12_Internalname = sPrefix+"TABLE12";
         tblAsignacion_Internalname = sPrefix+"ASIGNACION";
         lblNombre2_Internalname = sPrefix+"NOMBRE2";
         edtTareaId_Internalname = sPrefix+"TAREAID";
         tblTable1_Internalname = sPrefix+"TABLE1";
         lblAdvisor2_Internalname = sPrefix+"ADVISOR2";
         tblTable13_Internalname = sPrefix+"TABLE13";
         lblInicia2_Internalname = sPrefix+"INICIA2";
         lblFinaliza2_Internalname = sPrefix+"FINALIZA2";
         divTable14_Internalname = sPrefix+"TABLE14";
         divTable7_Internalname = sPrefix+"TABLE7";
         tblGridtareas2table1_Internalname = sPrefix+"GRIDTAREAS2TABLE1";
         divT2_Internalname = sPrefix+"T2";
         Ramp_addons_sweetalert1_Internalname = sPrefix+"RAMP_ADDONS_SWEETALERT1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridtareas2_Internalname = sPrefix+"GRIDTAREAS2";
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
         subGridtareas2_Allowcollapsing = 0;
         lblFinaliza2_Caption = "Finaliza";
         lblInicia2_Caption = "Inicia";
         lblAdvisor2_Caption = "";
         edtTareaId_Jsonclick = "";
         lblNombre2_Jsonclick = "";
         cmbavParticipantetableroid_Jsonclick = "";
         cmbavParticipantetableroid.Visible = 1;
         cmbavParticipantetableroid.Enabled = 1;
         edtavComentarios_Jsonclick = "";
         edtavComentarios_Visible = 1;
         edtavComentarios_Enabled = 1;
         edtavAsignar_Jsonclick = "";
         edtavAsignar_Visible = 1;
         edtavAsignar_Enabled = 1;
         edtavFinalizar_Jsonclick = "";
         edtavFinalizar_Visible = 1;
         edtavFinalizar_Enabled = 1;
         subGridtareas2_Class = "FreeStyleGrid";
         lblNombre2_Caption = "Nombre2";
         lblAdvisor2_Caption = "";
         edtavComentarios_Tooltiptext = "Comentarios";
         lblFinaliza2_Caption = "Finaliza";
         lblInicia2_Caption = "Inicia";
         tblAsignacion_Visible = 1;
         subGridtareas2_Backcolorstyle = 0;
         lblTitulo2_Jsonclick = "";
         lblTitulo2_Caption = "Titulo2";
         divT2_Class = "Table";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDTAREAS2_nFirstRecordOnPage'},{av:'GRIDTAREAS2_nEOF'},{av:'sPrefix'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'cmbavParticipantetableroid'},{av:'AV9ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavParticipantetableroid'},{av:'AV9ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("GRIDTAREAS2.LOAD","{handler:'E13102',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("GRIDTAREAS2.LOAD",",oparms:[{av:'tblAsignacion_Visible',ctrl:'ASIGNACION',prop:'Visible'},{av:'AV6comentarios',fld:'vCOMENTARIOS',pic:''},{av:'edtavComentarios_Tooltiptext',ctrl:'vCOMENTARIOS',prop:'Tooltiptext'},{av:'AV5asignar',fld:'vASIGNAR',pic:''},{av:'AV8finalizar',fld:'vFINALIZAR',pic:''},{av:'lblAdvisor2_Caption',ctrl:'ADVISOR2',prop:'Caption'},{av:'lblNombre2_Caption',ctrl:'NOMBRE2',prop:'Caption'},{av:'lblInicia2_Caption',ctrl:'INICIA2',prop:'Caption'},{av:'lblFinaliza2_Caption',ctrl:'FINALIZA2',prop:'Caption'}]}");
         setEventMetadata("GRIDTAREAS2.REFRESH","{handler:'E14102',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("GRIDTAREAS2.REFRESH",",oparms:[{av:'tblAsignacion_Visible',ctrl:'ASIGNACION',prop:'Visible'},{av:'AV6comentarios',fld:'vCOMENTARIOS',pic:''},{av:'edtavComentarios_Tooltiptext',ctrl:'vCOMENTARIOS',prop:'Tooltiptext'},{av:'AV5asignar',fld:'vASIGNAR',pic:''},{av:'AV8finalizar',fld:'vFINALIZAR',pic:''},{av:'lblAdvisor2_Caption',ctrl:'ADVISOR2',prop:'Caption'},{av:'lblNombre2_Caption',ctrl:'NOMBRE2',prop:'Caption'},{av:'lblInicia2_Caption',ctrl:'INICIA2',prop:'Caption'},{av:'lblFinaliza2_Caption',ctrl:'FINALIZA2',prop:'Caption'}]}");
         setEventMetadata("'ASIGNAR'","{handler:'E15102',iparms:[{av:'GRIDTAREAS2_nFirstRecordOnPage'},{av:'GRIDTAREAS2_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'cmbavParticipantetableroid'},{av:'AV9ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'sPrefix'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'AV16sdt_sa',fld:'vSDT_SA',pic:''}]");
         setEventMetadata("'ASIGNAR'",",oparms:[{av:'tblAsignacion_Visible',ctrl:'ASIGNACION',prop:'Visible'},{av:'cmbavParticipantetableroid'},{av:'AV9ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'AV16sdt_sa',fld:'vSDT_SA',pic:''}]}");
         setEventMetadata("'ANADIRASIGNACION'","{handler:'E16102',iparms:[{av:'GRIDTAREAS2_nFirstRecordOnPage'},{av:'GRIDTAREAS2_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'cmbavParticipantetableroid'},{av:'AV9ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'sPrefix'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'AV16sdt_sa',fld:'vSDT_SA',pic:''}]");
         setEventMetadata("'ANADIRASIGNACION'",",oparms:[{av:'cmbavParticipantetableroid'},{av:'AV9ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'AV16sdt_sa',fld:'vSDT_SA',pic:''}]}");
         setEventMetadata("'FINALIZARTAREA'","{handler:'E17102',iparms:[{av:'GRIDTAREAS2_nFirstRecordOnPage'},{av:'GRIDTAREAS2_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'cmbavParticipantetableroid'},{av:'AV9ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'sPrefix'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'AV16sdt_sa',fld:'vSDT_SA',pic:''}]");
         setEventMetadata("'FINALIZARTAREA'",",oparms:[{av:'AV16sdt_sa',fld:'vSDT_SA',pic:''},{av:'cmbavParticipantetableroid'},{av:'AV9ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("'CANCELAR'","{handler:'E18102',iparms:[{av:'GRIDTAREAS2_nFirstRecordOnPage'},{av:'GRIDTAREAS2_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'cmbavParticipantetableroid'},{av:'AV9ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("'CANCELAR'",",oparms:[{av:'cmbavParticipantetableroid'},{av:'AV9ParticipanteTableroId',fld:'vPARTICIPANTETABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("'MOSTRARCOMENTARIOS'","{handler:'E19102',iparms:[{av:'AV19estadoComentarios',fld:'vESTADOCOMENTARIOS',pic:''},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'MOSTRARCOMENTARIOS'",",oparms:[{ctrl:'LISTADOCOMENTARIOS'},{av:'AV19estadoComentarios',fld:'vESTADOCOMENTARIOS',pic:''}]}");
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
         GXEncryptionTmp = "";
         AV16sdt_sa = new SdtSDT_SweetAlert(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         Gridtareas2Container = new GXWebGrid( context);
         sStyleString = "";
         ucRamp_addons_sweetalert1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV8finalizar = "";
         AV28Finalizar_GXI = "";
         AV5asignar = "";
         AV27Asignar_GXI = "";
         AV6comentarios = "";
         AV25Comentarios_GXI = "";
         OldListadocomentarios = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         OldComponent1 = "";
         GXDecQS = "";
         WebComp_Listadocomentarios_Component = "";
         WebComp_Component1_Component = "";
         scmdbuf = "";
         H00102_A9TableroId = new short[1] ;
         H00102_A46TareaEstado = new short[1] ;
         H00102_A12TareaId = new short[1] ;
         H00102_A24TareaFechaInicio = new DateTime[] {DateTime.MinValue} ;
         A24TareaFechaInicio = DateTime.MinValue;
         H00103_A9TableroId = new short[1] ;
         H00103_A18ParticipanteTableroId = new short[1] ;
         AV15Usuarios = new SdtUsuarios(context);
         H00104_A9TableroId = new short[1] ;
         H00104_A18ParticipanteTableroId = new short[1] ;
         AV13T2 = new SdtTareas(context);
         H00105_AV7contador = new short[1] ;
         AV11state = "";
         AV26State_GXI = "";
         AV14U2 = new SdtUsuarios(context);
         AV10Responsable = "";
         Gridtareas2Row = new GXWebRow();
         H00106_AV7contador = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA9TableroId = "";
         subGridtareas2_Linesclass = "";
         TempTags = "";
         GXCCtl = "";
         imgImage7_Jsonclick = "";
         imgImage8_Jsonclick = "";
         ROClassString = "";
         lblAdvisor2_Jsonclick = "";
         lblInicia2_Jsonclick = "";
         lblFinaliza2_Jsonclick = "";
         subGridtareas2_Header = "";
         Gridtareas2Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.enprocesowc__default(),
            new Object[][] {
                new Object[] {
               H00102_A9TableroId, H00102_A46TareaEstado, H00102_A12TareaId, H00102_A24TareaFechaInicio
               }
               , new Object[] {
               H00103_A9TableroId, H00103_A18ParticipanteTableroId
               }
               , new Object[] {
               H00104_A9TableroId, H00104_A18ParticipanteTableroId
               }
               , new Object[] {
               H00105_AV7contador
               }
               , new Object[] {
               H00106_AV7contador
               }
            }
         );
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Listadocomentarios = new GeneXus.Http.GXNullWebComponent();
         WebComp_Component1 = new GeneXus.Http.GXNullWebComponent();
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
      private short AV9ParticipanteTableroId ;
      private short A18ParticipanteTableroId ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A12TareaId ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGridtareas2_Backcolorstyle ;
      private short A46TareaEstado ;
      private short GRIDTAREAS2_nEOF ;
      private short AV7contador ;
      private short cV7contador ;
      private short AV17contadorActividades ;
      private short GXt_int1 ;
      private short GXt_int2 ;
      private short GXt_int3 ;
      private short nGXWrapped ;
      private short subGridtareas2_Backstyle ;
      private short subGridtareas2_Allowselection ;
      private short subGridtareas2_Allowhovering ;
      private short subGridtareas2_Allowcollapsing ;
      private short subGridtareas2_Collapsed ;
      private int nRC_GXsfl_15 ;
      private int nGXsfl_15_idx=1 ;
      private int edtTareaId_Visible ;
      private int nGXsfl_15_webc_idx=0 ;
      private int subGridtareas2_Islastpage ;
      private int tblAsignacion_Visible ;
      private int idxLst ;
      private int subGridtareas2_Backcolor ;
      private int subGridtareas2_Allbackcolor ;
      private int edtavFinalizar_Enabled ;
      private int edtavFinalizar_Visible ;
      private int edtavAsignar_Enabled ;
      private int edtavAsignar_Visible ;
      private int edtavComentarios_Enabled ;
      private int edtavComentarios_Visible ;
      private int imgImage7_Enabled ;
      private int imgImage7_Visible ;
      private int imgImage8_Enabled ;
      private int imgImage8_Visible ;
      private int subGridtareas2_Selectedindex ;
      private int subGridtareas2_Selectioncolor ;
      private int subGridtareas2_Hoveringcolor ;
      private long GRIDTAREAS2_nCurrentRecord ;
      private long GRIDTAREAS2_nFirstRecordOnPage ;
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
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string divT2_Internalname ;
      private string divT2_Class ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage3_Internalname ;
      private string lblTitulo2_Internalname ;
      private string lblTitulo2_Caption ;
      private string lblTitulo2_Jsonclick ;
      private string sStyleString ;
      private string subGridtareas2_Internalname ;
      private string Ramp_addons_sweetalert1_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavParticipantetableroid_Internalname ;
      private string edtavFinalizar_Internalname ;
      private string edtavAsignar_Internalname ;
      private string edtavComentarios_Internalname ;
      private string OldListadocomentarios ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string OldComponent1 ;
      private string GXDecQS ;
      private string WebComp_Listadocomentarios_Component ;
      private string WebComp_Component1_Component ;
      private string scmdbuf ;
      private string tblAsignacion_Internalname ;
      private string edtavComentarios_Tooltiptext ;
      private string AV10Responsable ;
      private string lblAdvisor2_Caption ;
      private string lblNombre2_Caption ;
      private string lblInicia2_Caption ;
      private string lblFinaliza2_Caption ;
      private string lblAdvisor2_Internalname ;
      private string lblNombre2_Internalname ;
      private string lblInicia2_Internalname ;
      private string lblFinaliza2_Internalname ;
      private string sCtrlA9TableroId ;
      private string imgImage7_Internalname ;
      private string imgImage8_Internalname ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subGridtareas2_Class ;
      private string subGridtareas2_Linesclass ;
      private string tblGridtareas2table1_Internalname ;
      private string divTable7_Internalname ;
      private string tblTable10_Internalname ;
      private string TempTags ;
      private string edtavFinalizar_Jsonclick ;
      private string edtavAsignar_Jsonclick ;
      private string edtavComentarios_Jsonclick ;
      private string GXCCtl ;
      private string cmbavParticipantetableroid_Jsonclick ;
      private string divTable12_Internalname ;
      private string imgImage7_Jsonclick ;
      private string imgImage8_Jsonclick ;
      private string lblNombre2_Jsonclick ;
      private string ROClassString ;
      private string edtTareaId_Jsonclick ;
      private string tblTable1_Internalname ;
      private string lblAdvisor2_Jsonclick ;
      private string tblTable13_Internalname ;
      private string divTable14_Internalname ;
      private string lblInicia2_Jsonclick ;
      private string lblFinaliza2_Jsonclick ;
      private string subGridtareas2_Header ;
      private DateTime Gx_date ;
      private DateTime A24TareaFechaInicio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool AV19estadoComentarios ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Listadocomentarios ;
      private bool gx_refresh_fired ;
      private bool AV8finalizar_IsBlob ;
      private bool AV5asignar_IsBlob ;
      private bool AV6comentarios_IsBlob ;
      private string AV28Finalizar_GXI ;
      private string AV27Asignar_GXI ;
      private string AV25Comentarios_GXI ;
      private string AV26State_GXI ;
      private string AV8finalizar ;
      private string AV5asignar ;
      private string AV6comentarios ;
      private string AV11state ;
      private GXWebComponent WebComp_Listadocomentarios ;
      private GXWebComponent WebComp_Component1 ;
      private GXWebGrid Gridtareas2Container ;
      private GXWebRow Gridtareas2Row ;
      private GXWebColumn Gridtareas2Column ;
      private GXUserControl ucRamp_addons_sweetalert1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private GXCombobox cmbavParticipantetableroid ;
      private GXWebComponent WebComp_GX_Process ;
      private IDataStoreProvider pr_default ;
      private short[] H00102_A9TableroId ;
      private short[] H00102_A46TareaEstado ;
      private short[] H00102_A12TareaId ;
      private DateTime[] H00102_A24TareaFechaInicio ;
      private short[] H00103_A9TableroId ;
      private short[] H00103_A18ParticipanteTableroId ;
      private short[] H00104_A9TableroId ;
      private short[] H00104_A18ParticipanteTableroId ;
      private short[] H00105_AV7contador ;
      private short[] H00106_AV7contador ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private SdtSDT_SweetAlert AV16sdt_sa ;
      private SdtTareas AV13T2 ;
      private SdtUsuarios AV15Usuarios ;
      private SdtUsuarios AV14U2 ;
   }

   public class enprocesowc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00102;
          prmH00102 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmH00103;
          prmH00103 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmH00104;
          prmH00104 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmH00105;
          prmH00105 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmH00106;
          prmH00106 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00102", "SELECT [TableroId], [TareaEstado], [TareaId], [TareaFechaInicio] FROM [Tareas] WHERE ([TableroId] = @TableroId) AND ([TareaEstado] = 2) ORDER BY [TareaFechaInicio] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00102,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00103", "SELECT [TableroId], [ParticipanteTableroId] FROM [Participantes] WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00103,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00104", "SELECT [TableroId], [ParticipanteTableroId] FROM [Participantes] WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00104,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00105", "SELECT COUNT(*) FROM [TareasComentarios] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00105,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00106", "SELECT COUNT(*) FROM [TareasComentarios] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00106,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
