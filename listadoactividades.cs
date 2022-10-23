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
   public class listadoactividades : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public listadoactividades( )
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

      public listadoactividades( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref short aP1_TareaId )
      {
         this.A9TableroId = aP0_TableroId;
         this.A12TareaId = aP1_TareaId;
         executePrivate();
         aP0_TableroId=this.A9TableroId;
         aP1_TareaId=this.A12TareaId;
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
                  A12TareaId = (short)(NumberUtil.Val( GetPar( "TareaId"), "."));
                  AssignAttri(sPrefix, false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A9TableroId,(short)A12TareaId});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridactividades") == 0 )
               {
                  gxnrGridactividades_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridactividades") == 0 )
               {
                  gxgrGridactividades_refresh_invoke( ) ;
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

      protected void gxnrGridactividades_newrow_invoke( )
      {
         nRC_GXsfl_24 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_24"), "."));
         nGXsfl_24_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_24_idx"), "."));
         sGXsfl_24_idx = GetPar( "sGXsfl_24_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridactividades_newrow( ) ;
         /* End function gxnrGridactividades_newrow_invoke */
      }

      protected void gxgrGridactividades_refresh_invoke( )
      {
         A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
         A12TareaId = (short)(NumberUtil.Val( GetPar( "TareaId"), "."));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV33T1);
         A33ActividadEstado = StringUtil.StrToBool( GetPar( "ActividadEstado"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridactividades_refresh( A9TableroId, A12TareaId, AV33T1, A33ActividadEstado, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridactividades_refresh_invoke */
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
            PA0V2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtActividadId_Visible = 0;
               AssignProp(sPrefix, false, edtActividadId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtActividadId_Visible), 5, 0), !bGXsfl_24_Refreshing);
               edtavActividadnombre_Invitemessage = "Crear nueva actividad";
               AssignProp(sPrefix, false, edtavActividadnombre_Internalname, "Invitemessage", edtavActividadnombre_Invitemessage, true);
               WS0V2( ) ;
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
            context.SendWebValue( "Listado Actividades") ;
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
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("listadoactividades.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0)),UrlEncode(StringUtil.LTrimStr(A12TareaId,4,0))}, new string[] {"TableroId","TareaId"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vT1", GetSecureSignedToken( sPrefix, AV33T1, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_24", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_24), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA9TableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA12TareaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA12TareaId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vT1", AV33T1);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vT1", AV33T1);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vT1", GetSecureSignedToken( sPrefix, AV33T1, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TAREAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"ACTIVIDADESTADO", A33ActividadEstado);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_SA", AV32sdt_sa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_SA", AV32sdt_sa);
         }
      }

      protected void RenderHtmlCloseForm0V2( )
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
         return "ListadoActividades" ;
      }

      public override string GetPgmdesc( )
      {
         return "Listado Actividades" ;
      }

      protected void WB0V0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "listadoactividades.aspx");
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 100, "%", 100, "%", "Table", "left", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto auto auto auto auto auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEstadisticas_Internalname, lblEstadisticas_Caption, "", "", lblEstadisticas_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 1, "HLP_ListadoActividades.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSubtitulo_Internalname, lblSubtitulo_Caption, "", "", lblSubtitulo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ListadoActividades.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavActividadnombre_Internalname, "Añadir actividad", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'" + sGXsfl_24_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavActividadnombre_Internalname, StringUtil.RTrim( AV24ActividadNombre), StringUtil.RTrim( context.localUtil.Format( AV24ActividadNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", edtavActividadnombre_Invitemessage, edtavActividadnombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavActividadnombre_Enabled, 0, "text", "", 100, "%", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ListadoActividades.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "Center", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "37af6e8e-5105-40d2-94ea-61da60f7a7ab", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 15, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'NUEVO\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ListadoActividades.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:center;", "div");
            /*  Grid Control  */
            GridactividadesContainer.SetWrapped(nGXWrapped);
            StartGridControl24( ) ;
         }
         if ( wbEnd == 24 )
         {
            wbEnd = 0;
            nRC_GXsfl_24 = (int)(nGXsfl_24_idx-1);
            if ( GridactividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridactividadesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridactividades", GridactividadesContainer, subGridactividades_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridactividadesContainerData", GridactividadesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridactividadesContainerData"+"V", GridactividadesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridactividadesContainerData"+"V"+"\" value='"+GridactividadesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            /* User Defined Control */
            ucRamp_addons_sweetalert1.Render(context, "ramp_addons_sweetalert", Ramp_addons_sweetalert1_Internalname, sPrefix+"RAMP_ADDONS_SWEETALERT1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 24 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridactividadesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridactividadesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridactividades", GridactividadesContainer, subGridactividades_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridactividadesContainerData", GridactividadesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridactividadesContainerData"+"V", GridactividadesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridactividadesContainerData"+"V"+"\" value='"+GridactividadesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0V2( )
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
               Form.Meta.addItem("description", "Listado Actividades", 0) ;
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
               STRUP0V0( ) ;
            }
         }
      }

      protected void WS0V2( )
      {
         START0V2( ) ;
         EVT0V2( ) ;
      }

      protected void EVT0V2( )
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
                                 STRUP0V0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'NUEVO'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Nuevo' */
                                    E110V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavActividadnombre_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "GRIDACTIVIDADES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'ELIMINAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'ESTADO'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'ELIMINAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'ESTADO'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0V0( ) ;
                              }
                              nGXsfl_24_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
                              SubsflControlProps_242( ) ;
                              A30ActividadId = (short)(context.localUtil.CToN( cgiGet( edtActividadId_Internalname), ",", "."));
                              AV26eliminar = cgiGet( edtavEliminar_Internalname);
                              AssignProp(sPrefix, false, edtavEliminar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV26eliminar)) ? AV38Eliminar_GXI : context.convertURL( context.PathToRelativeUrl( AV26eliminar))), !bGXsfl_24_Refreshing);
                              AssignProp(sPrefix, false, edtavEliminar_Internalname, "SrcSet", context.GetImageSrcSet( AV26eliminar), true);
                              A31ActividadNombre = cgiGet( edtActividadNombre_Internalname);
                              AV8state = cgiGet( edtavState_Internalname);
                              AssignProp(sPrefix, false, edtavState_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8state)) ? AV41State_GXI : context.convertURL( context.PathToRelativeUrl( AV8state))), !bGXsfl_24_Refreshing);
                              AssignProp(sPrefix, false, edtavState_Internalname, "SrcSet", context.GetImageSrcSet( AV8state), true);
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
                                          GX_FocusControl = edtavActividadnombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E120V2 ();
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
                                          GX_FocusControl = edtavActividadnombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E130V2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDACTIVIDADES.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavActividadnombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E140V2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'ELIMINAR'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavActividadnombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Eliminar' */
                                          E150V2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'ESTADO'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavActividadnombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Estado' */
                                          E160V2 ();
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
                                       STRUP0V0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavActividadnombre_Internalname;
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0V2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0V2( ) ;
            }
         }
      }

      protected void PA0V2( )
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
               GX_FocusControl = edtavActividadnombre_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridactividades_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_242( ) ;
         while ( nGXsfl_24_idx <= nRC_GXsfl_24 )
         {
            sendrow_242( ) ;
            nGXsfl_24_idx = ((subGridactividades_Islastpage==1)&&(nGXsfl_24_idx+1>subGridactividades_fnc_Recordsperpage( )) ? 1 : nGXsfl_24_idx+1);
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_242( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridactividadesContainer)) ;
         /* End function gxnrGridactividades_newrow */
      }

      protected void gxgrGridactividades_refresh( short A9TableroId ,
                                                  short A12TareaId ,
                                                  SdtTareas AV33T1 ,
                                                  bool A33ActividadEstado ,
                                                  string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E130V2 ();
         GRIDACTIVIDADES_nCurrentRecord = 0;
         RF0V2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridactividades_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ACTIVIDADID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A30ActividadId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"ACTIVIDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30ActividadId), 4, 0, ".", "")));
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
         RF0V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtActividadId_Visible = 0;
         AssignProp(sPrefix, false, edtActividadId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtActividadId_Visible), 5, 0), !bGXsfl_24_Refreshing);
         edtavActividadnombre_Invitemessage = "Crear nueva actividad";
         AssignProp(sPrefix, false, edtavActividadnombre_Internalname, "Invitemessage", edtavActividadnombre_Invitemessage, true);
      }

      protected void RF0V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridactividadesContainer.ClearRows();
         }
         wbStart = 24;
         /* Execute user event: Refresh */
         E130V2 ();
         nGXsfl_24_idx = 1;
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_242( ) ;
         bGXsfl_24_Refreshing = true;
         GridactividadesContainer.AddObjectProperty("GridName", "Gridactividades");
         GridactividadesContainer.AddObjectProperty("CmpContext", sPrefix);
         GridactividadesContainer.AddObjectProperty("InMasterPage", "false");
         GridactividadesContainer.AddObjectProperty("Class", "WorkWithSelection");
         GridactividadesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridactividadesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridactividadesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridactividades_Backcolorstyle), 1, 0, ".", "")));
         GridactividadesContainer.PageSize = subGridactividades_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_242( ) ;
            /* Using cursor H000V2 */
            pr_default.execute(0, new Object[] {A9TableroId, A12TareaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A31ActividadNombre = H000V2_A31ActividadNombre[0];
               A30ActividadId = H000V2_A30ActividadId[0];
               E140V2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 24;
            WB0V0( ) ;
         }
         bGXsfl_24_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0V2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vT1", AV33T1);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vT1", AV33T1);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vT1", GetSecureSignedToken( sPrefix, AV33T1, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ACTIVIDADID"+"_"+sGXsfl_24_idx, GetSecureSignedToken( sPrefix+sGXsfl_24_idx, context.localUtil.Format( (decimal)(A30ActividadId), "ZZZ9"), context));
      }

      protected int subGridactividades_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridactividades_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridactividades_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridactividades_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtActividadId_Visible = 0;
         AssignProp(sPrefix, false, edtActividadId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtActividadId_Visible), 5, 0), !bGXsfl_24_Refreshing);
         edtavActividadnombre_Invitemessage = "Crear nueva actividad";
         AssignProp(sPrefix, false, edtavActividadnombre_Internalname, "Invitemessage", edtavActividadnombre_Invitemessage, true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120V2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_24 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_24"), ",", "."));
            wcpOA9TableroId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA9TableroId"), ",", "."));
            wcpOA12TareaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA12TareaId"), ",", "."));
            /* Read variables values. */
            AV24ActividadNombre = cgiGet( edtavActividadnombre_Internalname);
            AssignAttri(sPrefix, false, "AV24ActividadNombre", AV24ActividadNombre);
            /* Read subfile selected row values. */
            nGXsfl_24_idx = (int)(context.localUtil.CToN( cgiGet( subGridactividades_Internalname+"_ROW"), ",", "."));
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_242( ) ;
            if ( nGXsfl_24_idx > 0 )
            {
               A30ActividadId = (short)(context.localUtil.CToN( cgiGet( edtActividadId_Internalname), ",", "."));
               AV26eliminar = cgiGet( edtavEliminar_Internalname);
               A31ActividadNombre = cgiGet( edtActividadNombre_Internalname);
               AV8state = cgiGet( edtavState_Internalname);
            }
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
         E120V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120V2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblEstadisticas_Caption = "";
         AssignProp(sPrefix, false, lblEstadisticas_Internalname, "Caption", lblEstadisticas_Caption, true);
         lblSubtitulo_Caption = "<h2><strong><center>Actividades</center></strong></h2>";
         AssignProp(sPrefix, false, lblSubtitulo_Internalname, "Caption", lblSubtitulo_Caption, true);
         AV21contador = 0;
         /* Optimized group. */
         /* Using cursor H000V3 */
         pr_default.execute(1, new Object[] {A9TableroId, A12TareaId});
         cV21contador = H000V3_AV21contador[0];
         pr_default.close(1);
         AV21contador = (short)(AV21contador+cV21contador*1);
         /* End optimized group. */
         AV23avance = 0;
         AV22completados = 0;
         /* Optimized group. */
         /* Using cursor H000V4 */
         pr_default.execute(2, new Object[] {A9TableroId, A12TareaId});
         cV22completados = H000V4_AV22completados[0];
         pr_default.close(2);
         AV22completados = (short)(AV22completados+cV22completados*1);
         /* End optimized group. */
         if ( ( AV22completados == 0 ) && ( AV21contador == 0 ) )
         {
            AV23avance = 0;
            lblEstadisticas_Caption = "<div class=\"progress\" style=\"height:25px;\">"+StringUtil.NewLine( )+"<div class=\"progress-bar\" role=\"progressbar\" style=\"width: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV23avance), 4, 0))+"%; height:25px;\" aria-valuenow=\"25\" aria-valuemin=\"0\" aria-valuemax=\"100\">"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23avance), 4, 0))+"%</div>"+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblEstadisticas_Internalname, "Caption", lblEstadisticas_Caption, true);
         }
         else
         {
            AV23avance = (short)((100/ (decimal)(AV21contador))*AV22completados);
            lblEstadisticas_Caption = "<div class=\"progress\" style=\"height:25px;\">"+StringUtil.NewLine( )+"<div class=\"progress-bar\" role=\"progressbar\" style=\"width: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV23avance), 4, 0))+"%; height:25px;\" aria-valuenow=\"25\" aria-valuemin=\"0\" aria-valuemax=\"100\">"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23avance), 4, 0))+"%</div>"+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblEstadisticas_Internalname, "Caption", lblEstadisticas_Caption, true);
         }
      }

      protected void E130V2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         if ( AV33T1.gxTpr_Tareaestado == 3 )
         {
            edtavEliminar_Visible = 0;
            AssignProp(sPrefix, false, edtavEliminar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEliminar_Visible), 5, 0), !bGXsfl_24_Refreshing);
         }
         else
         {
            AV26eliminar = context.GetImagePath( "6223fef3-3dcc-4cb5-990c-8733d6fa82e5", "", context.GetTheme( ));
            AssignProp(sPrefix, false, edtavEliminar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV26eliminar)) ? AV38Eliminar_GXI : context.convertURL( context.PathToRelativeUrl( AV26eliminar))), !bGXsfl_24_Refreshing);
            AssignProp(sPrefix, false, edtavEliminar_Internalname, "SrcSet", context.GetImageSrcSet( AV26eliminar), true);
            AV38Eliminar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6223fef3-3dcc-4cb5-990c-8733d6fa82e5", "", context.GetTheme( )));
            AssignProp(sPrefix, false, edtavEliminar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV26eliminar)) ? AV38Eliminar_GXI : context.convertURL( context.PathToRelativeUrl( AV26eliminar))), !bGXsfl_24_Refreshing);
            AssignProp(sPrefix, false, edtavEliminar_Internalname, "SrcSet", context.GetImageSrcSet( AV26eliminar), true);
            edtavEliminar_Visible = 1;
            AssignProp(sPrefix, false, edtavEliminar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEliminar_Visible), 5, 0), !bGXsfl_24_Refreshing);
         }
         AV21contador = 0;
         AV23avance = 0;
         /* Optimized group. */
         /* Using cursor H000V5 */
         pr_default.execute(3, new Object[] {A9TableroId, A12TareaId});
         cV21contador = H000V5_AV21contador[0];
         pr_default.close(3);
         AV21contador = (short)(AV21contador+cV21contador*1);
         /* End optimized group. */
         AV22completados = 0;
         /* Optimized group. */
         /* Using cursor H000V6 */
         pr_default.execute(4, new Object[] {A9TableroId, A12TareaId});
         cV22completados = H000V6_AV22completados[0];
         pr_default.close(4);
         AV22completados = (short)(AV22completados+cV22completados*1);
         /* End optimized group. */
         if ( ( AV22completados == 0 ) && ( AV21contador == 0 ) )
         {
            AV23avance = 0;
            lblEstadisticas_Caption = "<div class=\"progress\" style=\"height:25px;\">"+StringUtil.NewLine( )+"<div class=\"progress-bar\" role=\"progressbar\" style=\"width: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV23avance), 4, 0))+"%; height:25px;\" aria-valuenow=\"25\" aria-valuemin=\"0\" aria-valuemax=\"100\">"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23avance), 4, 0))+"%</div>"+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblEstadisticas_Internalname, "Caption", lblEstadisticas_Caption, true);
         }
         else
         {
            AV23avance = (short)((100/ (decimal)(AV21contador))*AV22completados);
            lblEstadisticas_Caption = "<div class=\"progress\" style=\"height:25px;\">"+StringUtil.NewLine( )+"<div class=\"progress-bar\" role=\"progressbar\" style=\"width: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV23avance), 4, 0))+"%; height:25px;\" aria-valuenow=\"25\" aria-valuemin=\"0\" aria-valuemax=\"100\">"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23avance), 4, 0))+"%</div>"+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblEstadisticas_Internalname, "Caption", lblEstadisticas_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      private void E140V2( )
      {
         /* Gridactividades_Load Routine */
         returnInSub = false;
         if ( AV33T1.gxTpr_Tareaestado == 3 )
         {
            edtavEliminar_Visible = 0;
         }
         else
         {
            AV26eliminar = context.GetImagePath( "6223fef3-3dcc-4cb5-990c-8733d6fa82e5", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavEliminar_Internalname, AV26eliminar);
            AV38Eliminar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6223fef3-3dcc-4cb5-990c-8733d6fa82e5", "", context.GetTheme( )));
            edtavEliminar_Visible = 1;
         }
         AV20ActividadesBC.Load(A9TableroId, A12TareaId, A30ActividadId);
         if ( ! AV20ActividadesBC.gxTpr_Actividadestado )
         {
            AV8state = context.GetImagePath( "e97153e5-fdfe-4896-8af9-b327afd8b4ca", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState_Internalname, AV8state);
            AV41State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "e97153e5-fdfe-4896-8af9-b327afd8b4ca", "", context.GetTheme( )));
         }
         else
         {
            AV8state = context.GetImagePath( "3f7ba65e-0fdf-490b-becb-38b1a57b8eaf", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState_Internalname, AV8state);
            AV41State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3f7ba65e-0fdf-490b-becb-38b1a57b8eaf", "", context.GetTheme( )));
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 24;
         }
         sendrow_242( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_24_Refreshing )
         {
            context.DoAjaxLoad(24, GridactividadesRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E110V2( )
      {
         /* 'Nuevo' Routine */
         returnInSub = false;
         AV5count = 0;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24ActividadNombre)) )
         {
            AV5count = (short)(AV5count+1);
         }
         if ( AV5count == 0 )
         {
            GXt_int1 = AV28ActividadId;
            new getactividadid(context ).execute( ref  A9TableroId, ref  A12TareaId, out  GXt_int1) ;
            AssignAttri(sPrefix, false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            AssignAttri(sPrefix, false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
            AV28ActividadId = GXt_int1;
            AV29TableroId = A9TableroId;
            AV30TareaId = A12TareaId;
            AV31Act = new SdtActividades(context);
            AV31Act.gxTpr_Tableroid = AV29TableroId;
            AV31Act.gxTpr_Tareaid = AV30TareaId;
            AV31Act.gxTpr_Actividadid = AV28ActividadId;
            AV31Act.gxTpr_Actividadnombre = AV24ActividadNombre;
            AV31Act.gxTpr_Actividadavance = 0;
            AV31Act.gxTpr_Actividadestado = false;
            AV31Act.Insert();
            if ( AV31Act.Success() )
            {
               context.CommitDataStores("listadoactividades",pr_default);
               AV24ActividadNombre = "";
               AssignAttri(sPrefix, false, "AV24ActividadNombre", AV24ActividadNombre);
               AV32sdt_sa.gxTpr_Title = "Actividad creada correctamente";
               AV32sdt_sa.gxTpr_Html = "Haz creado una nueva actividad.";
               AV32sdt_sa.gxTpr_Timer = 4000;
               AV32sdt_sa.gxTpr_Allowoutsideclick = true;
               AV32sdt_sa.gxTpr_Type = "success";
               this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV32sdt_sa});
               gxgrGridactividades_refresh( A9TableroId, A12TareaId, AV33T1, A33ActividadEstado, sPrefix) ;
            }
            else
            {
               context.RollbackDataStores("listadoactividades",pr_default);
               GX_msglist.addItem(AV12Tareas.GetMessages().ToJSonString(false));
               AV32sdt_sa.gxTpr_Title = "Ha ocurrido un error";
               AV32sdt_sa.gxTpr_Html = "Ha ocurrido un error, por favor intentelo nuevamente";
               AV32sdt_sa.gxTpr_Timer = 4000;
               AV32sdt_sa.gxTpr_Allowoutsideclick = true;
               AV32sdt_sa.gxTpr_Type = "error";
               this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV32sdt_sa});
            }
         }
         else
         {
            AV32sdt_sa.gxTpr_Title = "Debes indicar un nombre";
            AV32sdt_sa.gxTpr_Html = "Debes indicar un nombre para tu actividad";
            AV32sdt_sa.gxTpr_Timer = 4000;
            AV32sdt_sa.gxTpr_Allowoutsideclick = true;
            AV32sdt_sa.gxTpr_Type = "error";
            this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV32sdt_sa});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32sdt_sa", AV32sdt_sa);
      }

      protected void E150V2( )
      {
         /* 'Eliminar' Routine */
         returnInSub = false;
         AV25ActividadesBC2.Load(A9TableroId, A12TareaId, A30ActividadId);
         AV25ActividadesBC2.Delete();
         if ( AV25ActividadesBC2.Success() )
         {
            context.CommitDataStores("listadoactividades",pr_default);
         }
         else
         {
            context.RollbackDataStores("listadoactividades",pr_default);
         }
         gxgrGridactividades_refresh( A9TableroId, A12TareaId, AV33T1, A33ActividadEstado, sPrefix) ;
         /*  Sending Event outputs  */
      }

      protected void E160V2( )
      {
         /* 'Estado' Routine */
         returnInSub = false;
         AV12Tareas.Load(A9TableroId, A12TareaId);
         if ( AV12Tareas.gxTpr_Tareaestado == 1 )
         {
            AV32sdt_sa.gxTpr_Title = "Inicia la tarea";
            AV32sdt_sa.gxTpr_Html = "Para completar actividades, debes iniciar la tarea";
            AV32sdt_sa.gxTpr_Timer = 4000;
            AV32sdt_sa.gxTpr_Allowoutsideclick = true;
            AV32sdt_sa.gxTpr_Type = "error";
            this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV32sdt_sa});
         }
         else if ( AV12Tareas.gxTpr_Tareaestado == 3 )
         {
            AV32sdt_sa.gxTpr_Title = "La tarea ha finalizado";
            AV32sdt_sa.gxTpr_Html = "No puedes cambiar el estado de las actividades en tareas completadas";
            AV32sdt_sa.gxTpr_Timer = 4000;
            AV32sdt_sa.gxTpr_Allowoutsideclick = true;
            AV32sdt_sa.gxTpr_Type = "info";
            this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV32sdt_sa});
         }
         else if ( AV12Tareas.gxTpr_Tareaestado == 4 )
         {
            AV32sdt_sa.gxTpr_Title = "La tarea está en pausa";
            AV32sdt_sa.gxTpr_Html = "Debes reanudar la tarea para seguir completando actividades";
            AV32sdt_sa.gxTpr_Timer = 4000;
            AV32sdt_sa.gxTpr_Allowoutsideclick = true;
            AV32sdt_sa.gxTpr_Type = "error";
            this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV32sdt_sa});
         }
         else
         {
            AV25ActividadesBC2.Load(A9TableroId, A12TareaId, A30ActividadId);
            if ( ! AV25ActividadesBC2.gxTpr_Actividadestado )
            {
               AV25ActividadesBC2.gxTpr_Actividadestado = true;
               AV25ActividadesBC2.Save();
               if ( AV25ActividadesBC2.Success() )
               {
                  context.CommitDataStores("listadoactividades",pr_default);
                  gxgrGridactividades_refresh( A9TableroId, A12TareaId, AV33T1, A33ActividadEstado, sPrefix) ;
               }
               else
               {
                  context.RollbackDataStores("listadoactividades",pr_default);
               }
            }
            else
            {
               AV25ActividadesBC2.gxTpr_Actividadestado = false;
               AV25ActividadesBC2.Save();
               if ( AV25ActividadesBC2.Success() )
               {
                  context.CommitDataStores("listadoactividades",pr_default);
                  gxgrGridactividades_refresh( A9TableroId, A12TareaId, AV33T1, A33ActividadEstado, sPrefix) ;
               }
               else
               {
                  context.RollbackDataStores("listadoactividades",pr_default);
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32sdt_sa", AV32sdt_sa);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A9TableroId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
         A12TareaId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
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
         PA0V2( ) ;
         WS0V2( ) ;
         WE0V2( ) ;
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
         sCtrlA12TareaId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0V2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "listadoactividades", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0V2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A9TableroId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A12TareaId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
         }
         wcpOA9TableroId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA9TableroId"), ",", "."));
         wcpOA12TareaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA12TareaId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A9TableroId != wcpOA9TableroId ) || ( A12TareaId != wcpOA12TareaId ) ) )
         {
            setjustcreated();
         }
         wcpOA9TableroId = A9TableroId;
         wcpOA12TareaId = A12TareaId;
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
         sCtrlA12TareaId = cgiGet( sPrefix+"A12TareaId_CTRL");
         if ( StringUtil.Len( sCtrlA12TareaId) > 0 )
         {
            A12TareaId = (short)(context.localUtil.CToN( cgiGet( sCtrlA12TareaId), ",", "."));
            AssignAttri(sPrefix, false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
         }
         else
         {
            A12TareaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A12TareaId_PARM"), ",", "."));
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
         PA0V2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0V2( ) ;
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
         WS0V2( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"A12TareaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA12TareaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A12TareaId_CTRL", StringUtil.RTrim( sCtrlA12TareaId));
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
         WE0V2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20221022911355", true, true);
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
            context.AddJavascriptSource("listadoactividades.js", "?20221022911356", false, true);
            context.AddJavascriptSource("RAMP/sweetAlert/js/sweetalert2.min.js", "", false, true);
            context.AddJavascriptSource("RAMP/shared/js/jquery-3.5.1.min.js", "", false, true);
            context.AddJavascriptSource("RAMP/shared/js/popper.js", "", false, true);
            context.AddJavascriptSource("RAMP/shared/js/bootstrap.min.js", "", false, true);
            context.AddJavascriptSource("RAMP/sweetAlert/RAMP_AddOns_SweetAlertRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_242( )
      {
         edtActividadId_Internalname = sPrefix+"ACTIVIDADID_"+sGXsfl_24_idx;
         edtavEliminar_Internalname = sPrefix+"vELIMINAR_"+sGXsfl_24_idx;
         edtActividadNombre_Internalname = sPrefix+"ACTIVIDADNOMBRE_"+sGXsfl_24_idx;
         edtavState_Internalname = sPrefix+"vSTATE_"+sGXsfl_24_idx;
      }

      protected void SubsflControlProps_fel_242( )
      {
         edtActividadId_Internalname = sPrefix+"ACTIVIDADID_"+sGXsfl_24_fel_idx;
         edtavEliminar_Internalname = sPrefix+"vELIMINAR_"+sGXsfl_24_fel_idx;
         edtActividadNombre_Internalname = sPrefix+"ACTIVIDADNOMBRE_"+sGXsfl_24_fel_idx;
         edtavState_Internalname = sPrefix+"vSTATE_"+sGXsfl_24_fel_idx;
      }

      protected void sendrow_242( )
      {
         SubsflControlProps_242( ) ;
         WB0V0( ) ;
         GridactividadesRow = GXWebRow.GetNew(context,GridactividadesContainer);
         if ( subGridactividades_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridactividades_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridactividades_Class, "") != 0 )
            {
               subGridactividades_Linesclass = subGridactividades_Class+"Odd";
            }
         }
         else if ( subGridactividades_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridactividades_Backstyle = 0;
            subGridactividades_Backcolor = subGridactividades_Allbackcolor;
            if ( StringUtil.StrCmp(subGridactividades_Class, "") != 0 )
            {
               subGridactividades_Linesclass = subGridactividades_Class+"Uniform";
            }
         }
         else if ( subGridactividades_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridactividades_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridactividades_Class, "") != 0 )
            {
               subGridactividades_Linesclass = subGridactividades_Class+"Odd";
            }
            subGridactividades_Backcolor = (int)(0x0);
         }
         else if ( subGridactividades_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridactividades_Backstyle = 1;
            if ( ((int)((nGXsfl_24_idx) % (2))) == 0 )
            {
               subGridactividades_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridactividades_Class, "") != 0 )
               {
                  subGridactividades_Linesclass = subGridactividades_Class+"Even";
               }
            }
            else
            {
               subGridactividades_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridactividades_Class, "") != 0 )
               {
                  subGridactividades_Linesclass = subGridactividades_Class+"Odd";
               }
            }
         }
         if ( GridactividadesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"WorkWithSelection"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_24_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridactividadesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtActividadId_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridactividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtActividadId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A30ActividadId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A30ActividadId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtActividadId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtActividadId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridactividadesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavEliminar_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavEliminar_Enabled!=0)&&(edtavEliminar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 26,'"+sPrefix+"',false,'',24)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV26eliminar_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV26eliminar))&&String.IsNullOrEmpty(StringUtil.RTrim( AV38Eliminar_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV26eliminar)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV26eliminar)) ? AV38Eliminar_GXI : context.PathToRelativeUrl( AV26eliminar));
         GridactividadesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavEliminar_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavEliminar_Visible,(short)1,(string)"",(string)"",(short)0,(short)1,(short)15,(string)"px",(short)15,(string)"px",(short)0,(short)0,(short)5,(string)edtavEliminar_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ELIMINAR\\'."+sGXsfl_24_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV26eliminar_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridactividadesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridactividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtActividadNombre_Internalname,StringUtil.RTrim( A31ActividadNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtActividadNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridactividadesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavState_Enabled!=0)&&(edtavState_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 28,'"+sPrefix+"',false,'',24)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV8state_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV8state))&&String.IsNullOrEmpty(StringUtil.RTrim( AV41State_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV8state)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV8state)) ? AV41State_GXI : context.PathToRelativeUrl( AV8state));
         GridactividadesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavState_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)1,(short)15,(string)"px",(short)15,(string)"px",(short)0,(short)0,(short)5,(string)edtavState_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ESTADO\\'."+sGXsfl_24_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV8state_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes0V2( ) ;
         GridactividadesContainer.AddRow(GridactividadesRow);
         nGXsfl_24_idx = ((subGridactividades_Islastpage==1)&&(nGXsfl_24_idx+1>subGridactividades_fnc_Recordsperpage( )) ? 1 : nGXsfl_24_idx+1);
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_242( ) ;
         /* End function sendrow_242 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl24( )
      {
         if ( GridactividadesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridactividadesContainer"+"DivS\" data-gxgridid=\"24\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridactividades_Internalname, subGridactividades_Internalname, "", "WorkWithSelection", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridactividades_Backcolorstyle == 0 )
            {
               subGridactividades_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridactividades_Class) > 0 )
               {
                  subGridactividades_Linesclass = subGridactividades_Class+"Title";
               }
            }
            else
            {
               subGridactividades_Titlebackstyle = 1;
               if ( subGridactividades_Backcolorstyle == 1 )
               {
                  subGridactividades_Titlebackcolor = subGridactividades_Allbackcolor;
                  if ( StringUtil.Len( subGridactividades_Class) > 0 )
                  {
                     subGridactividades_Linesclass = subGridactividades_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridactividades_Class) > 0 )
                  {
                     subGridactividades_Linesclass = subGridactividades_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtActividadId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(15), 4, 0)+"px"+" class=\""+"Image"+"\" "+" style=\""+((edtavEliminar_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(15), 4, 0)+"px"+" class=\""+"Image"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridactividadesContainer.AddObjectProperty("GridName", "Gridactividades");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridactividadesContainer = new GXWebGrid( context);
            }
            else
            {
               GridactividadesContainer.Clear();
            }
            GridactividadesContainer.SetWrapped(nGXWrapped);
            GridactividadesContainer.AddObjectProperty("GridName", "Gridactividades");
            GridactividadesContainer.AddObjectProperty("Header", subGridactividades_Header);
            GridactividadesContainer.AddObjectProperty("Class", "WorkWithSelection");
            GridactividadesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridactividadesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridactividadesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridactividades_Backcolorstyle), 1, 0, ".", "")));
            GridactividadesContainer.AddObjectProperty("CmpContext", sPrefix);
            GridactividadesContainer.AddObjectProperty("InMasterPage", "false");
            GridactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridactividadesColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30ActividadId), 4, 0, ".", "")));
            GridactividadesColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtActividadId_Visible), 5, 0, ".", "")));
            GridactividadesContainer.AddColumnProperties(GridactividadesColumn);
            GridactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridactividadesColumn.AddObjectProperty("Value", context.convertURL( AV26eliminar));
            GridactividadesColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEliminar_Visible), 5, 0, ".", "")));
            GridactividadesContainer.AddColumnProperties(GridactividadesColumn);
            GridactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridactividadesColumn.AddObjectProperty("Value", StringUtil.RTrim( A31ActividadNombre));
            GridactividadesContainer.AddColumnProperties(GridactividadesColumn);
            GridactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridactividadesColumn.AddObjectProperty("Value", context.convertURL( AV8state));
            GridactividadesContainer.AddColumnProperties(GridactividadesColumn);
            GridactividadesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridactividades_Selectedindex), 4, 0, ".", "")));
            GridactividadesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridactividades_Allowselection), 1, 0, ".", "")));
            GridactividadesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridactividades_Selectioncolor), 9, 0, ".", "")));
            GridactividadesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridactividades_Allowhovering), 1, 0, ".", "")));
            GridactividadesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridactividades_Hoveringcolor), 9, 0, ".", "")));
            GridactividadesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridactividades_Allowcollapsing), 1, 0, ".", "")));
            GridactividadesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridactividades_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblEstadisticas_Internalname = sPrefix+"ESTADISTICAS";
         divTable2_Internalname = sPrefix+"TABLE2";
         divTable1_Internalname = sPrefix+"TABLE1";
         lblSubtitulo_Internalname = sPrefix+"SUBTITULO";
         edtavActividadnombre_Internalname = sPrefix+"vACTIVIDADNOMBRE";
         imgImage1_Internalname = sPrefix+"IMAGE1";
         divTable4_Internalname = sPrefix+"TABLE4";
         divTable3_Internalname = sPrefix+"TABLE3";
         edtActividadId_Internalname = sPrefix+"ACTIVIDADID";
         edtavEliminar_Internalname = sPrefix+"vELIMINAR";
         edtActividadNombre_Internalname = sPrefix+"ACTIVIDADNOMBRE";
         edtavState_Internalname = sPrefix+"vSTATE";
         Ramp_addons_sweetalert1_Internalname = sPrefix+"RAMP_ADDONS_SWEETALERT1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridactividades_Internalname = sPrefix+"GRIDACTIVIDADES";
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
         subGridactividades_Allowcollapsing = 0;
         subGridactividades_Allowhovering = -1;
         subGridactividades_Allowselection = 1;
         subGridactividades_Header = "";
         edtavState_Jsonclick = "";
         edtavState_Visible = -1;
         edtavState_Enabled = 1;
         edtActividadNombre_Jsonclick = "";
         edtavEliminar_Jsonclick = "";
         edtavEliminar_Enabled = 1;
         edtActividadId_Jsonclick = "";
         subGridactividades_Class = "WorkWithSelection";
         subGridactividades_Backcolorstyle = 0;
         edtavEliminar_Visible = -1;
         edtavActividadnombre_Jsonclick = "";
         edtavActividadnombre_Invitemessage = "";
         edtavActividadnombre_Enabled = 1;
         lblSubtitulo_Caption = "Text Block";
         lblEstadisticas_Jsonclick = "";
         lblEstadisticas_Caption = "Estadisticas";
         edtActividadId_Visible = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDACTIVIDADES_nFirstRecordOnPage'},{av:'GRIDACTIVIDADES_nEOF'},{av:'sPrefix'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9'},{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''},{av:'AV33T1',fld:'vT1',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV26eliminar',fld:'vELIMINAR',pic:''},{av:'edtavEliminar_Visible',ctrl:'vELIMINAR',prop:'Visible'},{av:'lblEstadisticas_Caption',ctrl:'ESTADISTICAS',prop:'Caption'}]}");
         setEventMetadata("GRIDACTIVIDADES.LOAD","{handler:'E140V2',iparms:[{av:'AV33T1',fld:'vT1',pic:'',hsh:true},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9'},{av:'A30ActividadId',fld:'ACTIVIDADID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("GRIDACTIVIDADES.LOAD",",oparms:[{av:'AV26eliminar',fld:'vELIMINAR',pic:''},{av:'edtavEliminar_Visible',ctrl:'vELIMINAR',prop:'Visible'},{av:'AV8state',fld:'vSTATE',pic:''}]}");
         setEventMetadata("'NUEVO'","{handler:'E110V2',iparms:[{av:'GRIDACTIVIDADES_nFirstRecordOnPage'},{av:'GRIDACTIVIDADES_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9'},{av:'AV33T1',fld:'vT1',pic:'',hsh:true},{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''},{av:'sPrefix'},{av:'AV24ActividadNombre',fld:'vACTIVIDADNOMBRE',pic:''},{av:'AV32sdt_sa',fld:'vSDT_SA',pic:''}]");
         setEventMetadata("'NUEVO'",",oparms:[{av:'AV24ActividadNombre',fld:'vACTIVIDADNOMBRE',pic:''},{av:'AV32sdt_sa',fld:'vSDT_SA',pic:''},{av:'AV26eliminar',fld:'vELIMINAR',pic:''},{av:'edtavEliminar_Visible',ctrl:'vELIMINAR',prop:'Visible'},{av:'lblEstadisticas_Caption',ctrl:'ESTADISTICAS',prop:'Caption'}]}");
         setEventMetadata("'ELIMINAR'","{handler:'E150V2',iparms:[{av:'GRIDACTIVIDADES_nFirstRecordOnPage'},{av:'GRIDACTIVIDADES_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9'},{av:'AV33T1',fld:'vT1',pic:'',hsh:true},{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''},{av:'sPrefix'},{av:'A30ActividadId',fld:'ACTIVIDADID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'ELIMINAR'",",oparms:[{av:'AV26eliminar',fld:'vELIMINAR',pic:''},{av:'edtavEliminar_Visible',ctrl:'vELIMINAR',prop:'Visible'},{av:'lblEstadisticas_Caption',ctrl:'ESTADISTICAS',prop:'Caption'}]}");
         setEventMetadata("'ESTADO'","{handler:'E160V2',iparms:[{av:'GRIDACTIVIDADES_nFirstRecordOnPage'},{av:'GRIDACTIVIDADES_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9'},{av:'AV33T1',fld:'vT1',pic:'',hsh:true},{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''},{av:'sPrefix'},{av:'AV32sdt_sa',fld:'vSDT_SA',pic:''},{av:'A30ActividadId',fld:'ACTIVIDADID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'ESTADO'",",oparms:[{av:'AV32sdt_sa',fld:'vSDT_SA',pic:''},{av:'AV26eliminar',fld:'vELIMINAR',pic:''},{av:'edtavEliminar_Visible',ctrl:'vELIMINAR',prop:'Visible'},{av:'lblEstadisticas_Caption',ctrl:'ESTADISTICAS',prop:'Caption'}]}");
         setEventMetadata("NULL","{handler:'Validv_State',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         AV33T1 = new SdtTareas(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV32sdt_sa = new SdtSDT_SweetAlert(context);
         GX_FocusControl = "";
         lblSubtitulo_Jsonclick = "";
         TempTags = "";
         AV24ActividadNombre = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         imgImage1_Jsonclick = "";
         GridactividadesContainer = new GXWebGrid( context);
         sStyleString = "";
         ucRamp_addons_sweetalert1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV26eliminar = "";
         AV38Eliminar_GXI = "";
         A31ActividadNombre = "";
         AV8state = "";
         AV41State_GXI = "";
         scmdbuf = "";
         H000V2_A9TableroId = new short[1] ;
         H000V2_A12TareaId = new short[1] ;
         H000V2_A31ActividadNombre = new string[] {""} ;
         H000V2_A30ActividadId = new short[1] ;
         H000V3_AV21contador = new short[1] ;
         H000V4_AV22completados = new short[1] ;
         H000V5_AV21contador = new short[1] ;
         H000V6_AV22completados = new short[1] ;
         AV20ActividadesBC = new SdtActividades(context);
         GridactividadesRow = new GXWebRow();
         AV31Act = new SdtActividades(context);
         AV12Tareas = new SdtTareas(context);
         AV25ActividadesBC2 = new SdtActividades(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA9TableroId = "";
         sCtrlA12TareaId = "";
         subGridactividades_Linesclass = "";
         ROClassString = "";
         GridactividadesColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listadoactividades__default(),
            new Object[][] {
                new Object[] {
               H000V2_A9TableroId, H000V2_A12TareaId, H000V2_A31ActividadNombre, H000V2_A30ActividadId
               }
               , new Object[] {
               H000V3_AV21contador
               }
               , new Object[] {
               H000V4_AV22completados
               }
               , new Object[] {
               H000V5_AV21contador
               }
               , new Object[] {
               H000V6_AV22completados
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtActividadId_Visible = 0;
         edtavActividadnombre_Invitemessage = "Crear nueva actividad";
      }

      private short A9TableroId ;
      private short A12TareaId ;
      private short wcpOA9TableroId ;
      private short wcpOA12TareaId ;
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
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A30ActividadId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridactividades_Backcolorstyle ;
      private short AV21contador ;
      private short cV21contador ;
      private short AV23avance ;
      private short AV22completados ;
      private short cV22completados ;
      private short GRIDACTIVIDADES_nEOF ;
      private short AV5count ;
      private short AV28ActividadId ;
      private short GXt_int1 ;
      private short AV29TableroId ;
      private short AV30TareaId ;
      private short subGridactividades_Backstyle ;
      private short subGridactividades_Titlebackstyle ;
      private short subGridactividades_Allowselection ;
      private short subGridactividades_Allowhovering ;
      private short subGridactividades_Allowcollapsing ;
      private short subGridactividades_Collapsed ;
      private int nRC_GXsfl_24 ;
      private int nGXsfl_24_idx=1 ;
      private int edtActividadId_Visible ;
      private int edtavActividadnombre_Enabled ;
      private int subGridactividades_Islastpage ;
      private int edtavEliminar_Visible ;
      private int idxLst ;
      private int subGridactividades_Backcolor ;
      private int subGridactividades_Allbackcolor ;
      private int edtavEliminar_Enabled ;
      private int edtavState_Enabled ;
      private int edtavState_Visible ;
      private int subGridactividades_Titlebackcolor ;
      private int subGridactividades_Selectedindex ;
      private int subGridactividades_Selectioncolor ;
      private int subGridactividades_Hoveringcolor ;
      private long GRIDACTIVIDADES_nCurrentRecord ;
      private long GRIDACTIVIDADES_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_24_idx="0001" ;
      private string edtActividadId_Internalname ;
      private string edtavActividadnombre_Invitemessage ;
      private string edtavActividadnombre_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string divTable2_Internalname ;
      private string lblEstadisticas_Internalname ;
      private string lblEstadisticas_Caption ;
      private string lblEstadisticas_Jsonclick ;
      private string lblSubtitulo_Internalname ;
      private string lblSubtitulo_Caption ;
      private string lblSubtitulo_Jsonclick ;
      private string divTable4_Internalname ;
      private string TempTags ;
      private string AV24ActividadNombre ;
      private string edtavActividadnombre_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage1_Internalname ;
      private string imgImage1_Jsonclick ;
      private string divTable3_Internalname ;
      private string sStyleString ;
      private string subGridactividades_Internalname ;
      private string Ramp_addons_sweetalert1_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavEliminar_Internalname ;
      private string A31ActividadNombre ;
      private string edtActividadNombre_Internalname ;
      private string edtavState_Internalname ;
      private string scmdbuf ;
      private string sCtrlA9TableroId ;
      private string sCtrlA12TareaId ;
      private string sGXsfl_24_fel_idx="0001" ;
      private string subGridactividades_Class ;
      private string subGridactividades_Linesclass ;
      private string ROClassString ;
      private string edtActividadId_Jsonclick ;
      private string edtavEliminar_Jsonclick ;
      private string edtActividadNombre_Jsonclick ;
      private string edtavState_Jsonclick ;
      private string subGridactividades_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A33ActividadEstado ;
      private bool bGXsfl_24_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV26eliminar_IsBlob ;
      private bool AV8state_IsBlob ;
      private string AV38Eliminar_GXI ;
      private string AV41State_GXI ;
      private string AV26eliminar ;
      private string AV8state ;
      private GXWebGrid GridactividadesContainer ;
      private GXWebRow GridactividadesRow ;
      private GXWebColumn GridactividadesColumn ;
      private GXUserControl ucRamp_addons_sweetalert1 ;
      private GXWebForm Form ;
      private SdtTareas AV12Tareas ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private short aP1_TareaId ;
      private IDataStoreProvider pr_default ;
      private short[] H000V2_A9TableroId ;
      private short[] H000V2_A12TareaId ;
      private string[] H000V2_A31ActividadNombre ;
      private short[] H000V2_A30ActividadId ;
      private short[] H000V3_AV21contador ;
      private short[] H000V4_AV22completados ;
      private short[] H000V5_AV21contador ;
      private short[] H000V6_AV22completados ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private SdtActividades AV20ActividadesBC ;
      private SdtActividades AV31Act ;
      private SdtActividades AV25ActividadesBC2 ;
      private SdtSDT_SweetAlert AV32sdt_sa ;
      private SdtTareas AV33T1 ;
   }

   public class listadoactividades__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000V2;
          prmH000V2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmH000V3;
          prmH000V3 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmH000V4;
          prmH000V4 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmH000V5;
          prmH000V5 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmH000V6;
          prmH000V6 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000V2", "SELECT [TableroId], [TareaId], [ActividadNombre], [ActividadId] FROM [Actividades] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ORDER BY [TableroId], [TareaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000V3", "SELECT COUNT(*) FROM [Actividades] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000V4", "SELECT COUNT(*) FROM [Actividades] WHERE ([TableroId] = @TableroId and [TareaId] = @TareaId) AND ([ActividadEstado] = 1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000V5", "SELECT COUNT(*) FROM [Actividades] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000V6", "SELECT COUNT(*) FROM [Actividades] WHERE ([TableroId] = @TableroId and [TareaId] = @TareaId) AND ([ActividadEstado] = 1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V6,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
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
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
