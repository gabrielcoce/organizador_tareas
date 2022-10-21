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
   public class finalizadowc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public finalizadowc( )
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

      public finalizadowc( IGxContext context )
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridtareas3") == 0 )
               {
                  gxnrGridtareas3_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridtareas3") == 0 )
               {
                  gxgrGridtareas3_refresh_invoke( ) ;
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

      protected void gxnrGridtareas3_newrow_invoke( )
      {
         nRC_GXsfl_15 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_15"), "."));
         nGXsfl_15_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_15_idx"), "."));
         sGXsfl_15_idx = GetPar( "sGXsfl_15_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridtareas3_newrow( ) ;
         /* End function gxnrGridtareas3_newrow_invoke */
      }

      protected void gxgrGridtareas3_refresh_invoke( )
      {
         A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridtareas3_refresh( A9TableroId, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridtareas3_refresh_invoke */
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
            PA0Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtTareaId_Visible = 0;
               AssignProp(sPrefix, false, edtTareaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTareaId_Visible), 5, 0), !bGXsfl_15_Refreshing);
               WS0Y2( ) ;
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
            context.SendWebValue( "Finalizado WC") ;
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
            GXEncryptionTmp = "finalizadowc.aspx"+UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("finalizadowc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vESTADOCOMENTARIOS", AV15estadoComentarios);
      }

      protected void RenderHtmlCloseForm0Y2( )
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
         return "FinalizadoWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Finalizado WC" ;
      }

      protected void WB0Y0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "finalizadowc.aspx");
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
            GxWebStd.gx_div_start( context, divT3_Internalname, 1, 0, "px", 0, "px", divT3_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "86d11c30-27b2-402d-9d48-cbca53dd980b", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage4_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 50, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_FinalizadoWC.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitulo3_Internalname, lblTitulo3_Caption, "", "", lblTitulo3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_FinalizadoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Gridtareas3Container.SetIsFreestyle(true);
            Gridtareas3Container.SetWrapped(nGXWrapped);
            StartGridControl15( ) ;
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
            if ( Gridtareas3Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Gridtareas3Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridtareas3", Gridtareas3Container, subGridtareas3_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridtareas3ContainerData", Gridtareas3Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridtareas3ContainerData"+"V", Gridtareas3Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridtareas3ContainerData"+"V"+"\" value='"+Gridtareas3Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
               if ( Gridtareas3Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Gridtareas3Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridtareas3", Gridtareas3Container, subGridtareas3_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridtareas3ContainerData", Gridtareas3Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridtareas3ContainerData"+"V", Gridtareas3Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridtareas3ContainerData"+"V"+"\" value='"+Gridtareas3Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0Y2( )
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
               Form.Meta.addItem("description", "Finalizado WC", 0) ;
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
               STRUP0Y0( ) ;
            }
         }
      }

      protected void WS0Y2( )
      {
         START0Y2( ) ;
         EVT0Y2( ) ;
      }

      protected void EVT0Y2( )
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
                                 STRUP0Y0( ) ;
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
                                 STRUP0Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "GRIDTAREAS3.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "'MOSTRARCOMENTARIOS'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'INICIAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "'MOSTRARCOMENTARIOS'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Y0( ) ;
                              }
                              nGXsfl_15_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              AV8state2 = cgiGet( edtavState2_Internalname);
                              AssignProp(sPrefix, false, edtavState2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8state2)) ? AV21State2_GXI : context.convertURL( context.PathToRelativeUrl( AV8state2))), !bGXsfl_15_Refreshing);
                              AssignProp(sPrefix, false, edtavState2_Internalname, "SrcSet", context.GetImageSrcSet( AV8state2), true);
                              AV7state = cgiGet( edtavState_Internalname);
                              AssignProp(sPrefix, false, edtavState_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV7state)) ? AV20State_GXI : context.convertURL( context.PathToRelativeUrl( AV7state))), !bGXsfl_15_Refreshing);
                              AssignProp(sPrefix, false, edtavState_Internalname, "SrcSet", context.GetImageSrcSet( AV7state), true);
                              AV6comentarios = cgiGet( edtavComentarios_Internalname);
                              AssignProp(sPrefix, false, edtavComentarios_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV19Comentarios_GXI : context.convertURL( context.PathToRelativeUrl( AV6comentarios))), !bGXsfl_15_Refreshing);
                              AssignProp(sPrefix, false, edtavComentarios_Internalname, "SrcSet", context.GetImageSrcSet( AV6comentarios), true);
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
                                          /* Execute user event: Start */
                                          E110Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDTAREAS3.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          E120Y2 ();
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
                                          /* Execute user event: 'MostrarComentarios' */
                                          E130Y2 ();
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
                                 else if ( StringUtil.StrCmp(sEvt, "'INICIAR'") == 0 )
                                 {
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
                                       STRUP0Y0( ) ;
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
                        if ( nCmpId == 45 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0045" + sEvtType;
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
                              WebComp_GX_Process.componentprocess(sPrefix+"W0045", sEvtType, sEvt);
                           }
                           nGXsfl_15_webc_idx = (int)(NumberUtil.Val( sEvtType, "."));
                           WebCompHandler = "Listadocomentarios";
                           WebComp_GX_Process_Component = OldListadocomentarios;
                        }
                        else if ( nCmpId == 51 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0051" + sEvtType;
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
                              WebComp_GX_Process.componentprocess(sPrefix+"W0051", sEvtType, sEvt);
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

      protected void WE0Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0Y2( ) ;
            }
         }
      }

      protected void PA0Y2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "finalizadowc.aspx")), "finalizadowc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "finalizadowc.aspx")))) ;
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

      protected void gxnrGridtareas3_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subGridtareas3_Islastpage==1)&&(nGXsfl_15_idx+1>subGridtareas3_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridtareas3Container)) ;
         /* End function gxnrGridtareas3_newrow */
      }

      protected void gxgrGridtareas3_refresh( short A9TableroId ,
                                              string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDTAREAS3_nCurrentRecord = 0;
         RF0Y2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridtareas3_refresh */
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
         RF0Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtTareaId_Visible = 0;
         AssignProp(sPrefix, false, edtTareaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTareaId_Visible), 5, 0), !bGXsfl_15_Refreshing);
      }

      protected void RF0Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridtareas3Container.ClearRows();
         }
         wbStart = 15;
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
         Gridtareas3Container.AddObjectProperty("GridName", "Gridtareas3");
         Gridtareas3Container.AddObjectProperty("CmpContext", sPrefix);
         Gridtareas3Container.AddObjectProperty("InMasterPage", "false");
         Gridtareas3Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Gridtareas3Container.AddObjectProperty("Class", "FreeStyleGrid");
         Gridtareas3Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridtareas3Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridtareas3Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas3_Backcolorstyle), 1, 0, ".", "")));
         Gridtareas3Container.PageSize = subGridtareas3_fnc_Recordsperpage( );
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
               WebComp_Listadocomentarios.componentprepare(new Object[] {(string)sPrefix+"W0045",(string)sGXsfl_15_idx,(short)A9TableroId,(short)A12TareaId});
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
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
               {
                  WebComp_Component1.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_152( ) ;
            /* Using cursor H000Y2 */
            pr_default.execute(0, new Object[] {A9TableroId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A46TareaEstado = H000Y2_A46TareaEstado[0];
               A12TareaId = H000Y2_A12TareaId[0];
               A24TareaFechaInicio = H000Y2_A24TareaFechaInicio[0];
               E120Y2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 15;
            WB0Y0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Y2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_TAREAID"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9"), context));
      }

      protected int subGridtareas3_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridtareas3_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridtareas3_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridtareas3_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtTareaId_Visible = 0;
         AssignProp(sPrefix, false, edtTareaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTareaId_Visible), 5, 0), !bGXsfl_15_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110Y2 ();
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
         E110Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblTitulo3_Caption = "<h3><center><strong><font color=\"white\">Finalizados</font></strong></center></h3>";
         AssignProp(sPrefix, false, lblTitulo3_Internalname, "Caption", lblTitulo3_Caption, true);
         divT3_Class = "TablaDone";
         AssignProp(sPrefix, false, divT3_Internalname, "Class", divT3_Class, true);
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
            WebComp_Listadocomentarios.componentprepare(new Object[] {(string)sPrefix+"W0045",(string)sGXsfl_15_idx});
            WebComp_Listadocomentarios.componentbind(new Object[] {});
         }
         AV15estadoComentarios = false;
         AssignAttri(sPrefix, false, "AV15estadoComentarios", AV15estadoComentarios);
      }

      private void E120Y2( )
      {
         /* Gridtareas3_Load Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Component1 = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Component1_Component), StringUtil.Lower( "ListadoActividadesF")) != 0 )
         {
            WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", "listadoactividadesf", new Object[] {context} );
            WebComp_Component1.ComponentInit();
            WebComp_Component1.Name = "ListadoActividadesF";
            WebComp_Component1_Component = "ListadoActividadesF";
         }
         if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
         {
            WebComp_Component1.setjustcreated();
            WebComp_Component1.componentprepare(new Object[] {(string)sPrefix+"W0051",(string)sGXsfl_15_idx,(short)A9TableroId,(short)A12TareaId});
            WebComp_Component1.componentbind(new Object[] {(string)"",(string)""});
         }
         AV10T3.Load(A9TableroId, A12TareaId);
         AV11contador = 0;
         /* Optimized group. */
         /* Using cursor H000Y3 */
         pr_default.execute(1, new Object[] {A9TableroId, A12TareaId});
         cV11contador = H000Y3_AV11contador[0];
         pr_default.close(1);
         AV11contador = (short)(AV11contador+cV11contador*1);
         /* End optimized group. */
         if ( AV11contador == 0 )
         {
            AV6comentarios = context.GetImagePath( "5a6feed5-8387-48bc-85cf-286b0f156319", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavComentarios_Internalname, AV6comentarios);
            AV19Comentarios_GXI = GXDbFile.PathToUrl( context.GetImagePath( "5a6feed5-8387-48bc-85cf-286b0f156319", "", context.GetTheme( )));
            edtavComentarios_Tooltiptext = "No tienes comentarios en esta tarea";
         }
         else
         {
            AV6comentarios = context.GetImagePath( "35c79c23-07c3-4fb0-9ce5-01610bd903e5", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavComentarios_Internalname, AV6comentarios);
            AV19Comentarios_GXI = GXDbFile.PathToUrl( context.GetImagePath( "35c79c23-07c3-4fb0-9ce5-01610bd903e5", "", context.GetTheme( )));
            edtavComentarios_Tooltiptext = "Tienes "+StringUtil.Trim( StringUtil.Str( (decimal)(AV11contador), 4, 0))+" comentario(s) en esta tarea";
         }
         if ( AV10T3.gxTpr_Responsableid != 0 )
         {
            AV7state = context.GetImagePath( "86d11c30-27b2-402d-9d48-cbca53dd980b", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState_Internalname, AV7state);
            AV20State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "86d11c30-27b2-402d-9d48-cbca53dd980b", "", context.GetTheme( )));
            AV12U3.Load(AV10T3.gxTpr_Responsableid);
            AV13Responsable = StringUtil.Trim( AV12U3.gxTpr_Usuarioemail) + " - " + AV12U3.gxTpr_Usuarionombre + " " + AV12U3.gxTpr_Usuarioapellido;
         }
         else
         {
            AV7state = context.GetImagePath( "af695a2d-efff-4893-90bc-55652acff52a", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState_Internalname, AV7state);
            AV20State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "af695a2d-efff-4893-90bc-55652acff52a", "", context.GetTheme( )));
            AV13Responsable = "Sin responsable asignado";
         }
         if ( AV10T3.gxTpr_Tareaestado == 1 )
         {
            AV8state2 = context.GetImagePath( "1ecaff01-3fe8-49d0-9094-76c163a69ce8", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState2_Internalname, AV8state2);
            AV21State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "1ecaff01-3fe8-49d0-9094-76c163a69ce8", "", context.GetTheme( )));
         }
         else if ( AV10T3.gxTpr_Tareaestado == 2 )
         {
            AV8state2 = context.GetImagePath( "9eed16cc-502d-4c66-a4e5-f47a9713bab0", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState2_Internalname, AV8state2);
            AV21State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "9eed16cc-502d-4c66-a4e5-f47a9713bab0", "", context.GetTheme( )));
         }
         else if ( AV10T3.gxTpr_Tareaestado == 3 )
         {
            AV8state2 = context.GetImagePath( "63552255-35ba-4e00-8b53-9539f5d32760", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState2_Internalname, AV8state2);
            AV21State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "63552255-35ba-4e00-8b53-9539f5d32760", "", context.GetTheme( )));
         }
         else if ( AV10T3.gxTpr_Tareaestado == 4 )
         {
            AV8state2 = context.GetImagePath( "cef39daf-d9a8-462d-9b0c-f8b6056364e8", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState2_Internalname, AV8state2);
            AV21State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "cef39daf-d9a8-462d-9b0c-f8b6056364e8", "", context.GetTheme( )));
         }
         lblNombre3_Caption = "<center><h3><strong>"+StringUtil.Trim( AV10T3.gxTpr_Tareanombre)+"</strong></h3><h4>"+StringUtil.Trim( AV13Responsable)+"</h4></center>";
         lblInicia3_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         lblInicia3_Caption = StringUtil.StringReplace( lblInicia3_Caption, "#VALUE", context.localUtil.DToC( AV10T3.gxTpr_Tareafechainicio, 2, "/"));
         lblInicia3_Caption = StringUtil.StringReplace( lblInicia3_Caption, "#LABEL", "Inicia");
         lblFinaliza3_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         lblFinaliza3_Caption = StringUtil.StringReplace( lblFinaliza3_Caption, "#VALUE", context.localUtil.DToC( AV10T3.gxTpr_Tareafechafin, 2, "/"));
         lblFinaliza3_Caption = StringUtil.StringReplace( lblFinaliza3_Caption, "#LABEL", "Finaliza");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            context.DoAjaxLoad(15, Gridtareas3Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E130Y2( )
      {
         /* 'MostrarComentarios' Routine */
         returnInSub = false;
         if ( ! AV15estadoComentarios )
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
               WebComp_Listadocomentarios.componentprepare(new Object[] {(string)sPrefix+"W0045",(string)sGXsfl_15_idx,(short)A9TableroId,(short)A12TareaId});
               WebComp_Listadocomentarios.componentbind(new Object[] {(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Listadocomentarios )
            {
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0045"+sGXsfl_15_idx);
               WebComp_Listadocomentarios.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            AV15estadoComentarios = true;
            AssignAttri(sPrefix, false, "AV15estadoComentarios", AV15estadoComentarios);
         }
         else if ( AV15estadoComentarios )
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
               WebComp_Listadocomentarios.componentprepare(new Object[] {(string)sPrefix+"W0045",(string)sGXsfl_15_idx});
               WebComp_Listadocomentarios.componentbind(new Object[] {});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Listadocomentarios )
            {
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0045"+sGXsfl_15_idx);
               WebComp_Listadocomentarios.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            AV15estadoComentarios = false;
            AssignAttri(sPrefix, false, "AV15estadoComentarios", AV15estadoComentarios);
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
         PA0Y2( ) ;
         WS0Y2( ) ;
         WE0Y2( ) ;
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
         PA0Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "finalizadowc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0Y2( ) ;
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
         PA0Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0Y2( ) ;
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
         WS0Y2( ) ;
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
         WE0Y2( ) ;
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
         if ( ! ( WebComp_Component1 == null ) )
         {
            if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
            {
               WebComp_Component1.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202210161310481", true, true);
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
         context.AddJavascriptSource("finalizadowc.js", "?202210161310481", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_152( )
      {
         edtavState2_Internalname = sPrefix+"vSTATE2_"+sGXsfl_15_idx;
         edtavState_Internalname = sPrefix+"vSTATE_"+sGXsfl_15_idx;
         edtavComentarios_Internalname = sPrefix+"vCOMENTARIOS_"+sGXsfl_15_idx;
         lblNombre3_Internalname = sPrefix+"NOMBRE3_"+sGXsfl_15_idx;
         edtTareaId_Internalname = sPrefix+"TAREAID_"+sGXsfl_15_idx;
         lblTextblock7_Internalname = sPrefix+"TEXTBLOCK7_"+sGXsfl_15_idx;
         lblInicia3_Internalname = sPrefix+"INICIA3_"+sGXsfl_15_idx;
         lblFinaliza3_Internalname = sPrefix+"FINALIZA3_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtavState2_Internalname = sPrefix+"vSTATE2_"+sGXsfl_15_fel_idx;
         edtavState_Internalname = sPrefix+"vSTATE_"+sGXsfl_15_fel_idx;
         edtavComentarios_Internalname = sPrefix+"vCOMENTARIOS_"+sGXsfl_15_fel_idx;
         lblNombre3_Internalname = sPrefix+"NOMBRE3_"+sGXsfl_15_fel_idx;
         edtTareaId_Internalname = sPrefix+"TAREAID_"+sGXsfl_15_fel_idx;
         lblTextblock7_Internalname = sPrefix+"TEXTBLOCK7_"+sGXsfl_15_fel_idx;
         lblInicia3_Internalname = sPrefix+"INICIA3_"+sGXsfl_15_fel_idx;
         lblFinaliza3_Internalname = sPrefix+"FINALIZA3_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         SubsflControlProps_152( ) ;
         WB0Y0( ) ;
         Gridtareas3Row = GXWebRow.GetNew(context,Gridtareas3Container);
         if ( subGridtareas3_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridtareas3_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridtareas3_Class, "") != 0 )
            {
               subGridtareas3_Linesclass = subGridtareas3_Class+"Odd";
            }
         }
         else if ( subGridtareas3_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridtareas3_Backstyle = 0;
            subGridtareas3_Backcolor = subGridtareas3_Allbackcolor;
            if ( StringUtil.StrCmp(subGridtareas3_Class, "") != 0 )
            {
               subGridtareas3_Linesclass = subGridtareas3_Class+"Uniform";
            }
         }
         else if ( subGridtareas3_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridtareas3_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridtareas3_Class, "") != 0 )
            {
               subGridtareas3_Linesclass = subGridtareas3_Class+"Odd";
            }
            subGridtareas3_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridtareas3_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridtareas3_Backstyle = 1;
            if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
            {
               subGridtareas3_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtareas3_Class, "") != 0 )
               {
                  subGridtareas3_Linesclass = subGridtareas3_Class+"Even";
               }
            }
            else
            {
               subGridtareas3_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridtareas3_Class, "") != 0 )
               {
                  subGridtareas3_Linesclass = subGridtareas3_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridtareas3_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_15_idx+"\">") ;
         }
         /* Table start */
         Gridtareas3Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblGridtareas3table_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"TableWidget",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Gridtareas3Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Gridtareas3Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTable1_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Gridtareas3Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTable8_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Gridtareas3Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Gridtareas3Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas3Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"state2",(string)"gx-form-item ImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavState2_Enabled!=0)&&(edtavState2_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 26,'"+sPrefix+"',false,'',15)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV8state2_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV8state2))&&String.IsNullOrEmpty(StringUtil.RTrim( AV21State2_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV8state2)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV8state2)) ? AV21State2_GXI : context.PathToRelativeUrl( AV8state2));
         Gridtareas3Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavState2_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"Tarea finalizada",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)5,(string)edtavState2_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'INICIAR\\'."+sGXsfl_15_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV8state2_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("cell");
         }
         Gridtareas3Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas3Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"state",(string)"gx-form-item ImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Static Bitmap Variable */
         ClassString = "Image";
         StyleString = "";
         AV7state_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV7state))&&String.IsNullOrEmpty(StringUtil.RTrim( AV20State_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV7state)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV7state)) ? AV20State_GXI : context.PathToRelativeUrl( AV7state));
         Gridtareas3Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavState_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"Estado",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV7state_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("cell");
         }
         Gridtareas3Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas3Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"comentarios",(string)"gx-form-item ImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavComentarios_Enabled!=0)&&(edtavComentarios_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 32,'"+sPrefix+"',false,'',15)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV6comentarios_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios))&&String.IsNullOrEmpty(StringUtil.RTrim( AV19Comentarios_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV6comentarios)) ? AV19Comentarios_GXI : context.PathToRelativeUrl( AV6comentarios));
         Gridtareas3Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavComentarios_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)edtavComentarios_Tooltiptext,(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)5,(string)edtavComentarios_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'MOSTRARCOMENTARIOS\\'."+sGXsfl_15_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV6comentarios_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("cell");
         }
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("row");
         }
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("table");
         }
         /* End of table */
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Gridtareas3Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNombre3_Internalname,(string)lblNombre3_Caption,(string)"",(string)"",(string)lblNombre3_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridtareas3Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtTareaId_Internalname,(string)"Tarea Id",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Gridtareas3Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTareaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTareaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtTareaId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)15,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Gridtareas3Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblLc_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Gridtareas3Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Gridtareas3Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0045"+sGXsfl_15_idx, StringUtil.RTrim( WebComp_Listadocomentarios_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0045"+sGXsfl_15_idx+"\""+"") ;
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
                  WebComp_Listadocomentarios.componentprepare(new Object[] {(string)sPrefix+"W0045",(string)sGXsfl_15_idx,(short)A9TableroId,(short)A12TareaId});
                  WebComp_Listadocomentarios.componentbind(new Object[] {(string)"",(string)""});
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0045"+sGXsfl_15_idx, cgiGet( "_EventName"), 1) != 0 ) )
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
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0045"+sGXsfl_15_idx);
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
         Gridtareas3Row.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Listadocomentarios"});
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("cell");
         }
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("row");
         }
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("table");
         }
         /* End of table */
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         sendrow_15230( ) ;
      }

      protected void sendrow_15230( )
      {
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Gridtareas3Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTable3_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Gridtareas3Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Gridtareas3Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0051"+sGXsfl_15_idx, StringUtil.RTrim( WebComp_Component1_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0051"+sGXsfl_15_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_15_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0051"+sGXsfl_15_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
                     {
                        WebComp_Component1.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldComponent1), StringUtil.Lower( WebComp_Component1_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0051"+sGXsfl_15_idx);
               }
               WebComp_Component1.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldComponent1), StringUtil.Lower( WebComp_Component1_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Component1_Component = "";
         WebComp_Component1.componentjscripts();
         Gridtareas3Row.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Component1"});
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("cell");
         }
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("row");
         }
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("table");
         }
         /* End of table */
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Gridtareas3Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTextblock7_Internalname,(string)"",(string)"",(string)"",(string)lblTextblock7_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTable2_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Text block */
         Gridtareas3Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblInicia3_Internalname,(string)lblInicia3_Caption,(string)"",(string)"",(string)lblInicia3_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Gridtareas3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Text block */
         Gridtareas3Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblFinaliza3_Internalname,(string)lblFinaliza3_Caption,(string)"",(string)"",(string)lblFinaliza3_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Gridtareas3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("cell");
         }
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("row");
         }
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            Gridtareas3Container.CloseTag("table");
         }
         /* End of table */
         send_integrity_lvl_hashes0Y2( ) ;
         /* End of Columns property logic. */
         Gridtareas3Container.AddRow(Gridtareas3Row);
         nGXsfl_15_idx = ((subGridtareas3_Islastpage==1)&&(nGXsfl_15_idx+1>subGridtareas3_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl15( )
      {
         if ( Gridtareas3Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Gridtareas3Container"+"DivS\" data-gxgridid=\"15\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridtareas3_Internalname, subGridtareas3_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Gridtareas3Container.AddObjectProperty("GridName", "Gridtareas3");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Gridtareas3Container = new GXWebGrid( context);
            }
            else
            {
               Gridtareas3Container.Clear();
            }
            Gridtareas3Container.SetIsFreestyle(true);
            Gridtareas3Container.SetWrapped(nGXWrapped);
            Gridtareas3Container.AddObjectProperty("GridName", "Gridtareas3");
            Gridtareas3Container.AddObjectProperty("Header", subGridtareas3_Header);
            Gridtareas3Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Gridtareas3Container.AddObjectProperty("Class", "FreeStyleGrid");
            Gridtareas3Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridtareas3Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridtareas3Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas3_Backcolorstyle), 1, 0, ".", "")));
            Gridtareas3Container.AddObjectProperty("CmpContext", sPrefix);
            Gridtareas3Container.AddObjectProperty("InMasterPage", "false");
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Column.AddObjectProperty("Value", context.convertURL( AV8state2));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Column.AddObjectProperty("Value", context.convertURL( AV7state));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Column.AddObjectProperty("Value", context.convertURL( AV6comentarios));
            Gridtareas3Column.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavComentarios_Tooltiptext));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Column.AddObjectProperty("Value", lblNombre3_Caption);
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ".", "")));
            Gridtareas3Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTareaId_Visible), 5, 0, ".", "")));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Column.AddObjectProperty("Value", lblTextblock7_Caption);
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Column.AddObjectProperty("Value", lblInicia3_Caption);
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridtareas3Column.AddObjectProperty("Value", lblFinaliza3_Caption);
            Gridtareas3Container.AddColumnProperties(Gridtareas3Column);
            Gridtareas3Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas3_Selectedindex), 4, 0, ".", "")));
            Gridtareas3Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas3_Allowselection), 1, 0, ".", "")));
            Gridtareas3Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas3_Selectioncolor), 9, 0, ".", "")));
            Gridtareas3Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas3_Allowhovering), 1, 0, ".", "")));
            Gridtareas3Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas3_Hoveringcolor), 9, 0, ".", "")));
            Gridtareas3Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas3_Allowcollapsing), 1, 0, ".", "")));
            Gridtareas3Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas3_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         imgImage4_Internalname = sPrefix+"IMAGE4";
         lblTitulo3_Internalname = sPrefix+"TITULO3";
         edtavState2_Internalname = sPrefix+"vSTATE2";
         edtavState_Internalname = sPrefix+"vSTATE";
         edtavComentarios_Internalname = sPrefix+"vCOMENTARIOS";
         tblTable8_Internalname = sPrefix+"TABLE8";
         lblNombre3_Internalname = sPrefix+"NOMBRE3";
         edtTareaId_Internalname = sPrefix+"TAREAID";
         tblLc_Internalname = sPrefix+"LC";
         tblTable3_Internalname = sPrefix+"TABLE3";
         lblTextblock7_Internalname = sPrefix+"TEXTBLOCK7";
         lblInicia3_Internalname = sPrefix+"INICIA3";
         lblFinaliza3_Internalname = sPrefix+"FINALIZA3";
         divTable2_Internalname = sPrefix+"TABLE2";
         divTable1_Internalname = sPrefix+"TABLE1";
         tblGridtareas3table_Internalname = sPrefix+"GRIDTAREAS3TABLE";
         divT3_Internalname = sPrefix+"T3";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridtareas3_Internalname = sPrefix+"GRIDTAREAS3";
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
         subGridtareas3_Allowcollapsing = 0;
         lblTextblock7_Caption = "";
         lblFinaliza3_Jsonclick = "";
         lblInicia3_Jsonclick = "";
         edtTareaId_Jsonclick = "";
         lblNombre3_Jsonclick = "";
         lblNombre3_Caption = "Nombre3";
         edtavComentarios_Jsonclick = "";
         edtavComentarios_Visible = 1;
         edtavComentarios_Enabled = 1;
         edtavComentarios_Tooltiptext = "Comentarios";
         edtavState2_Jsonclick = "";
         edtavState2_Visible = 1;
         edtavState2_Enabled = 1;
         subGridtareas3_Class = "FreeStyleGrid";
         lblFinaliza3_Caption = "Finaliza3";
         lblInicia3_Caption = "Inicia3";
         subGridtareas3_Backcolorstyle = 0;
         lblTitulo3_Jsonclick = "";
         lblTitulo3_Caption = "Titulo3";
         divT3_Class = "Table";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDTAREAS3_nFirstRecordOnPage'},{av:'GRIDTAREAS3_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'sPrefix'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDTAREAS3.LOAD","{handler:'E120Y2',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("GRIDTAREAS3.LOAD",",oparms:[{ctrl:'COMPONENT1'},{av:'AV6comentarios',fld:'vCOMENTARIOS',pic:''},{av:'edtavComentarios_Tooltiptext',ctrl:'vCOMENTARIOS',prop:'Tooltiptext'},{av:'AV7state',fld:'vSTATE',pic:''},{av:'AV8state2',fld:'vSTATE2',pic:''},{av:'lblNombre3_Caption',ctrl:'NOMBRE3',prop:'Caption'},{av:'lblInicia3_Caption',ctrl:'INICIA3',prop:'Caption'},{av:'lblFinaliza3_Caption',ctrl:'FINALIZA3',prop:'Caption'}]}");
         setEventMetadata("'MOSTRARCOMENTARIOS'","{handler:'E130Y2',iparms:[{av:'AV15estadoComentarios',fld:'vESTADOCOMENTARIOS',pic:''},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'MOSTRARCOMENTARIOS'",",oparms:[{ctrl:'LISTADOCOMENTARIOS'},{av:'AV15estadoComentarios',fld:'vESTADOCOMENTARIOS',pic:''}]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         Gridtareas3Container = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV8state2 = "";
         AV21State2_GXI = "";
         AV7state = "";
         AV20State_GXI = "";
         AV6comentarios = "";
         AV19Comentarios_GXI = "";
         OldListadocomentarios = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         OldComponent1 = "";
         GXDecQS = "";
         WebComp_Listadocomentarios_Component = "";
         WebComp_Component1_Component = "";
         scmdbuf = "";
         H000Y2_A9TableroId = new short[1] ;
         H000Y2_A46TareaEstado = new short[1] ;
         H000Y2_A12TareaId = new short[1] ;
         H000Y2_A24TareaFechaInicio = new DateTime[] {DateTime.MinValue} ;
         A24TareaFechaInicio = DateTime.MinValue;
         AV10T3 = new SdtTareas(context);
         H000Y3_AV11contador = new short[1] ;
         AV12U3 = new SdtUsuarios(context);
         AV13Responsable = "";
         Gridtareas3Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA9TableroId = "";
         subGridtareas3_Linesclass = "";
         TempTags = "";
         ROClassString = "";
         lblTextblock7_Jsonclick = "";
         subGridtareas3_Header = "";
         Gridtareas3Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.finalizadowc__default(),
            new Object[][] {
                new Object[] {
               H000Y2_A9TableroId, H000Y2_A46TareaEstado, H000Y2_A12TareaId, H000Y2_A24TareaFechaInicio
               }
               , new Object[] {
               H000Y3_AV11contador
               }
            }
         );
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Listadocomentarios = new GeneXus.Http.GXNullWebComponent();
         WebComp_Component1 = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtTareaId_Visible = 0;
      }

      private short A9TableroId ;
      private short wcpOA9TableroId ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A12TareaId ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGridtareas3_Backcolorstyle ;
      private short A46TareaEstado ;
      private short AV11contador ;
      private short cV11contador ;
      private short nGXWrapped ;
      private short subGridtareas3_Backstyle ;
      private short subGridtareas3_Allowselection ;
      private short subGridtareas3_Allowhovering ;
      private short subGridtareas3_Allowcollapsing ;
      private short subGridtareas3_Collapsed ;
      private short GRIDTAREAS3_nEOF ;
      private int nRC_GXsfl_15 ;
      private int nGXsfl_15_idx=1 ;
      private int edtTareaId_Visible ;
      private int nGXsfl_15_webc_idx=0 ;
      private int subGridtareas3_Islastpage ;
      private int idxLst ;
      private int subGridtareas3_Backcolor ;
      private int subGridtareas3_Allbackcolor ;
      private int edtavState2_Enabled ;
      private int edtavState2_Visible ;
      private int edtavComentarios_Enabled ;
      private int edtavComentarios_Visible ;
      private int subGridtareas3_Selectedindex ;
      private int subGridtareas3_Selectioncolor ;
      private int subGridtareas3_Hoveringcolor ;
      private long GRIDTAREAS3_nCurrentRecord ;
      private long GRIDTAREAS3_nFirstRecordOnPage ;
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
      private string divT3_Internalname ;
      private string divT3_Class ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage4_Internalname ;
      private string lblTitulo3_Internalname ;
      private string lblTitulo3_Caption ;
      private string lblTitulo3_Jsonclick ;
      private string sStyleString ;
      private string subGridtareas3_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavState2_Internalname ;
      private string edtavState_Internalname ;
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
      private string edtavComentarios_Tooltiptext ;
      private string AV13Responsable ;
      private string lblNombre3_Caption ;
      private string lblInicia3_Caption ;
      private string lblFinaliza3_Caption ;
      private string sCtrlA9TableroId ;
      private string lblNombre3_Internalname ;
      private string lblTextblock7_Internalname ;
      private string lblInicia3_Internalname ;
      private string lblFinaliza3_Internalname ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subGridtareas3_Class ;
      private string subGridtareas3_Linesclass ;
      private string tblGridtareas3table_Internalname ;
      private string divTable1_Internalname ;
      private string tblTable8_Internalname ;
      private string TempTags ;
      private string edtavState2_Jsonclick ;
      private string edtavComentarios_Jsonclick ;
      private string lblNombre3_Jsonclick ;
      private string ROClassString ;
      private string edtTareaId_Jsonclick ;
      private string tblLc_Internalname ;
      private string tblTable3_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string divTable2_Internalname ;
      private string lblInicia3_Jsonclick ;
      private string lblFinaliza3_Jsonclick ;
      private string subGridtareas3_Header ;
      private string lblTextblock7_Caption ;
      private DateTime A24TareaFechaInicio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool AV15estadoComentarios ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Listadocomentarios ;
      private bool bDynCreated_Component1 ;
      private bool AV8state2_IsBlob ;
      private bool AV7state_IsBlob ;
      private bool AV6comentarios_IsBlob ;
      private string AV21State2_GXI ;
      private string AV20State_GXI ;
      private string AV19Comentarios_GXI ;
      private string AV8state2 ;
      private string AV7state ;
      private string AV6comentarios ;
      private GXWebComponent WebComp_Listadocomentarios ;
      private GXWebComponent WebComp_Component1 ;
      private GXWebGrid Gridtareas3Container ;
      private GXWebRow Gridtareas3Row ;
      private GXWebColumn Gridtareas3Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private GXWebComponent WebComp_GX_Process ;
      private IDataStoreProvider pr_default ;
      private short[] H000Y2_A9TableroId ;
      private short[] H000Y2_A46TareaEstado ;
      private short[] H000Y2_A12TareaId ;
      private DateTime[] H000Y2_A24TareaFechaInicio ;
      private short[] H000Y3_AV11contador ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private SdtTareas AV10T3 ;
      private SdtUsuarios AV12U3 ;
   }

   public class finalizadowc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000Y2;
          prmH000Y2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmH000Y3;
          prmH000Y3 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000Y2", "SELECT [TableroId], [TareaEstado], [TareaId], [TareaFechaInicio] FROM [Tareas] WHERE ([TableroId] = @TableroId) AND ([TareaEstado] = 3) ORDER BY [TareaFechaInicio] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Y3", "SELECT COUNT(*) FROM [TareasComentarios] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y3,1, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
