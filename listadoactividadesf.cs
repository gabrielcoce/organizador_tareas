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
   public class listadoactividadesf : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public listadoactividadesf( )
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

      public listadoactividadesf( IGxContext context )
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
         gxnrGridactividades_newrow( ) ;
         /* End function gxnrGridactividades_newrow_invoke */
      }

      protected void gxgrGridactividades_refresh_invoke( )
      {
         A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
         A12TareaId = (short)(NumberUtil.Val( GetPar( "TareaId"), "."));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV30T1);
         A33ActividadEstado = StringUtil.StrToBool( GetPar( "ActividadEstado"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridactividades_refresh( A9TableroId, A12TareaId, AV30T1, A33ActividadEstado, sPrefix) ;
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
            PA122( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtActividadId_Visible = 0;
               AssignProp(sPrefix, false, edtActividadId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtActividadId_Visible), 5, 0), !bGXsfl_15_Refreshing);
               WS122( ) ;
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
            context.SendWebValue( "Listado Actividades F") ;
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
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("listadoactividadesf.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0)),UrlEncode(StringUtil.LTrimStr(A12TareaId,4,0))}, new string[] {"TableroId","TareaId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vT1", GetSecureSignedToken( sPrefix, AV30T1, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA9TableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA12TareaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA12TareaId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vT1", AV30T1);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vT1", AV30T1);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vT1", GetSecureSignedToken( sPrefix, AV30T1, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TAREAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"ACTIVIDADESTADO", A33ActividadEstado);
         GxWebStd.gx_hidden_field( context, sPrefix+"vACTIVIDADNOMBRE", StringUtil.RTrim( AV10ActividadNombre));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_SA", AV19sdt_sa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_SA", AV19sdt_sa);
         }
      }

      protected void RenderHtmlCloseForm122( )
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
         return "ListadoActividadesF" ;
      }

      public override string GetPgmdesc( )
      {
         return "Listado Actividades F" ;
      }

      protected void WB120( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "listadoactividadesf.aspx");
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 100, "%", 100, "%", "Table", "left", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto auto auto auto;", "div");
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
            GxWebStd.gx_label_ctrl( context, lblEstadisticas_Internalname, lblEstadisticas_Caption, "", "", lblEstadisticas_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 1, "HLP_ListadoActividadesF.htm");
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
            GxWebStd.gx_label_ctrl( context, lblSubtitulo_Internalname, lblSubtitulo_Caption, "", "", lblSubtitulo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ListadoActividadesF.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:center;", "div");
            /*  Grid Control  */
            GridactividadesContainer.SetWrapped(nGXWrapped);
            StartGridControl15( ) ;
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
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
         if ( wbEnd == 15 )
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

      protected void START122( )
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
               Form.Meta.addItem("description", "Listado Actividades F", 0) ;
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
               STRUP120( ) ;
            }
         }
      }

      protected void WS122( )
      {
         START122( ) ;
         EVT122( ) ;
      }

      protected void EVT122( )
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
                                 STRUP120( ) ;
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
                                 STRUP120( ) ;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "GRIDACTIVIDADES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "'NUEVO'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'ELIMINAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              nGXsfl_15_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              A30ActividadId = (short)(context.localUtil.CToN( cgiGet( edtActividadId_Internalname), ",", "."));
                              A31ActividadNombre = cgiGet( edtActividadNombre_Internalname);
                              AV20state = cgiGet( edtavState_Internalname);
                              AssignProp(sPrefix, false, edtavState_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20state)) ? AV39State_GXI : context.convertURL( context.PathToRelativeUrl( AV20state))), !bGXsfl_15_Refreshing);
                              AssignProp(sPrefix, false, edtavState_Internalname, "SrcSet", context.GetImageSrcSet( AV20state), true);
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
                                          E11122 ();
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
                                          /* Execute user event: Refresh */
                                          E12122 ();
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
                                          E13122 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'NUEVO'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: 'Nuevo' */
                                          E14122 ();
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
                                          /* Execute user event: 'Eliminar' */
                                          E15122 ();
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
                                       STRUP120( ) ;
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE122( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm122( ) ;
            }
         }
      }

      protected void PA122( )
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

      protected void gxnrGridactividades_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subGridactividades_Islastpage==1)&&(nGXsfl_15_idx+1>subGridactividades_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridactividadesContainer)) ;
         /* End function gxnrGridactividades_newrow */
      }

      protected void gxgrGridactividades_refresh( short A9TableroId ,
                                                  short A12TareaId ,
                                                  SdtTareas AV30T1 ,
                                                  bool A33ActividadEstado ,
                                                  string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E12122 ();
         GRIDACTIVIDADES_nCurrentRecord = 0;
         RF122( ) ;
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
         RF122( ) ;
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
         AssignProp(sPrefix, false, edtActividadId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtActividadId_Visible), 5, 0), !bGXsfl_15_Refreshing);
      }

      protected void RF122( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridactividadesContainer.ClearRows();
         }
         wbStart = 15;
         /* Execute user event: Refresh */
         E12122 ();
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
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
            SubsflControlProps_152( ) ;
            /* Using cursor H00122 */
            pr_default.execute(0, new Object[] {A9TableroId, A12TareaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A31ActividadNombre = H00122_A31ActividadNombre[0];
               A30ActividadId = H00122_A30ActividadId[0];
               E13122 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 15;
            WB120( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes122( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vT1", AV30T1);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vT1", AV30T1);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vT1", GetSecureSignedToken( sPrefix, AV30T1, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ACTIVIDADID"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, context.localUtil.Format( (decimal)(A30ActividadId), "ZZZ9"), context));
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
         AssignProp(sPrefix, false, edtActividadId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtActividadId_Visible), 5, 0), !bGXsfl_15_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP120( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11122 ();
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
            wcpOA12TareaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA12TareaId"), ",", "."));
            /* Read variables values. */
            /* Read subfile selected row values. */
            nGXsfl_15_idx = (int)(context.localUtil.CToN( cgiGet( subGridactividades_Internalname+"_ROW"), ",", "."));
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
            if ( nGXsfl_15_idx > 0 )
            {
               A30ActividadId = (short)(context.localUtil.CToN( cgiGet( edtActividadId_Internalname), ",", "."));
               A31ActividadNombre = cgiGet( edtActividadNombre_Internalname);
               AV20state = cgiGet( edtavState_Internalname);
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
         E11122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11122( )
      {
         /* Start Routine */
         returnInSub = false;
         lblEstadisticas_Caption = "";
         AssignProp(sPrefix, false, lblEstadisticas_Internalname, "Caption", lblEstadisticas_Caption, true);
         lblSubtitulo_Caption = "<h2><strong><center>Actividades</center></strong></h2>";
         AssignProp(sPrefix, false, lblSubtitulo_Internalname, "Caption", lblSubtitulo_Caption, true);
         AV13contador = 0;
         /* Optimized group. */
         /* Using cursor H00123 */
         pr_default.execute(1, new Object[] {A9TableroId, A12TareaId});
         cV13contador = H00123_AV13contador[0];
         pr_default.close(1);
         AV13contador = (short)(AV13contador+cV13contador*1);
         /* End optimized group. */
         AV11avance = 0;
         AV12completados = 0;
         /* Optimized group. */
         /* Using cursor H00124 */
         pr_default.execute(2, new Object[] {A9TableroId, A12TareaId});
         cV12completados = H00124_AV12completados[0];
         pr_default.close(2);
         AV12completados = (short)(AV12completados+cV12completados*1);
         /* End optimized group. */
         if ( ( AV12completados == 0 ) && ( AV13contador == 0 ) )
         {
            AV11avance = 0;
            lblEstadisticas_Caption = "<div class=\"progress\" style=\"height:25px;\">"+StringUtil.NewLine( )+"<div class=\"progress-bar\" role=\"progressbar\" style=\"width: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV11avance), 4, 0))+"%; height:25px;\" aria-valuenow=\"25\" aria-valuemin=\"0\" aria-valuemax=\"100\">"+StringUtil.Trim( StringUtil.Str( (decimal)(AV11avance), 4, 0))+"%</div>"+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblEstadisticas_Internalname, "Caption", lblEstadisticas_Caption, true);
         }
         else
         {
            AV11avance = (short)((100/ (decimal)(AV13contador))*AV12completados);
            lblEstadisticas_Caption = "<div class=\"progress\" style=\"height:25px;\">"+StringUtil.NewLine( )+"<div class=\"progress-bar\" role=\"progressbar\" style=\"width: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV11avance), 4, 0))+"%; height:25px;\" aria-valuenow=\"25\" aria-valuemin=\"0\" aria-valuemax=\"100\">"+StringUtil.Trim( StringUtil.Str( (decimal)(AV11avance), 4, 0))+"%</div>"+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblEstadisticas_Internalname, "Caption", lblEstadisticas_Caption, true);
         }
      }

      protected void E12122( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         if ( AV30T1.gxTpr_Tareaestado == 3 )
         {
         }
         else
         {
         }
         AV13contador = 0;
         AV11avance = 0;
         /* Optimized group. */
         /* Using cursor H00125 */
         pr_default.execute(3, new Object[] {A9TableroId, A12TareaId});
         cV13contador = H00125_AV13contador[0];
         pr_default.close(3);
         AV13contador = (short)(AV13contador+cV13contador*1);
         /* End optimized group. */
         AV12completados = 0;
         /* Optimized group. */
         /* Using cursor H00126 */
         pr_default.execute(4, new Object[] {A9TableroId, A12TareaId});
         cV12completados = H00126_AV12completados[0];
         pr_default.close(4);
         AV12completados = (short)(AV12completados+cV12completados*1);
         /* End optimized group. */
         if ( ( AV12completados == 0 ) && ( AV13contador == 0 ) )
         {
            AV11avance = 0;
            lblEstadisticas_Caption = "<div class=\"progress\" style=\"height:25px;\">"+StringUtil.NewLine( )+"<div class=\"progress-bar\" role=\"progressbar\" style=\"width: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV11avance), 4, 0))+"%; height:25px;\" aria-valuenow=\"25\" aria-valuemin=\"0\" aria-valuemax=\"100\">"+StringUtil.Trim( StringUtil.Str( (decimal)(AV11avance), 4, 0))+"%</div>"+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblEstadisticas_Internalname, "Caption", lblEstadisticas_Caption, true);
         }
         else
         {
            AV11avance = (short)((100/ (decimal)(AV13contador))*AV12completados);
            lblEstadisticas_Caption = "<div class=\"progress\" style=\"height:25px;\">"+StringUtil.NewLine( )+"<div class=\"progress-bar\" role=\"progressbar\" style=\"width: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV11avance), 4, 0))+"%; height:25px;\" aria-valuenow=\"25\" aria-valuemin=\"0\" aria-valuemax=\"100\">"+StringUtil.Trim( StringUtil.Str( (decimal)(AV11avance), 4, 0))+"%</div>"+StringUtil.NewLine( )+"</div>";
            AssignProp(sPrefix, false, lblEstadisticas_Internalname, "Caption", lblEstadisticas_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      private void E13122( )
      {
         /* Gridactividades_Load Routine */
         returnInSub = false;
         if ( AV30T1.gxTpr_Tareaestado == 3 )
         {
         }
         else
         {
         }
         AV7ActividadesBC.Load(A9TableroId, A12TareaId, A30ActividadId);
         if ( ! AV7ActividadesBC.gxTpr_Actividadestado )
         {
            AV20state = context.GetImagePath( "e97153e5-fdfe-4896-8af9-b327afd8b4ca", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState_Internalname, AV20state);
            AV39State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "e97153e5-fdfe-4896-8af9-b327afd8b4ca", "", context.GetTheme( )));
         }
         else
         {
            AV20state = context.GetImagePath( "3f7ba65e-0fdf-490b-becb-38b1a57b8eaf", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavState_Internalname, AV20state);
            AV39State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3f7ba65e-0fdf-490b-becb-38b1a57b8eaf", "", context.GetTheme( )));
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            context.DoAjaxLoad(15, GridactividadesRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E14122( )
      {
         /* 'Nuevo' Routine */
         returnInSub = false;
         AV14count = 0;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10ActividadNombre)) )
         {
            AV14count = (short)(AV14count+1);
         }
         if ( AV14count == 0 )
         {
            GXt_int1 = AV9ActividadId;
            new getactividadid(context ).execute( ref  A9TableroId, ref  A12TareaId, out  GXt_int1) ;
            AssignAttri(sPrefix, false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            AssignAttri(sPrefix, false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
            AV9ActividadId = GXt_int1;
            AV31TableroId = A9TableroId;
            AV32TareaId = A12TareaId;
            AV5Act = new SdtActividades(context);
            AV5Act.gxTpr_Tableroid = AV31TableroId;
            AV5Act.gxTpr_Tareaid = AV32TareaId;
            AV5Act.gxTpr_Actividadid = AV9ActividadId;
            AV5Act.gxTpr_Actividadnombre = AV10ActividadNombre;
            AV5Act.gxTpr_Actividadavance = 0;
            AV5Act.gxTpr_Actividadestado = false;
            AV5Act.Insert();
            if ( AV5Act.Success() )
            {
               context.CommitDataStores("listadoactividadesf",pr_default);
               AV10ActividadNombre = "";
               AssignAttri(sPrefix, false, "AV10ActividadNombre", AV10ActividadNombre);
               AV19sdt_sa.gxTpr_Title = "Actividad creada correctamente";
               AV19sdt_sa.gxTpr_Html = "Haz creado una nueva actividad.";
               AV19sdt_sa.gxTpr_Timer = 4000;
               AV19sdt_sa.gxTpr_Allowoutsideclick = true;
               AV19sdt_sa.gxTpr_Type = "success";
               this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV19sdt_sa});
               gxgrGridactividades_refresh( A9TableroId, A12TareaId, AV30T1, A33ActividadEstado, sPrefix) ;
            }
            else
            {
               context.RollbackDataStores("listadoactividadesf",pr_default);
               GX_msglist.addItem(AV26Tareas.GetMessages().ToJSonString(false));
               AV19sdt_sa.gxTpr_Title = "Ha ocurrido un error";
               AV19sdt_sa.gxTpr_Html = "Ha ocurrido un error, por favor intentelo nuevamente";
               AV19sdt_sa.gxTpr_Timer = 4000;
               AV19sdt_sa.gxTpr_Allowoutsideclick = true;
               AV19sdt_sa.gxTpr_Type = "error";
               this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV19sdt_sa});
            }
         }
         else
         {
            AV19sdt_sa.gxTpr_Title = "Debes indicar un nombre";
            AV19sdt_sa.gxTpr_Html = "Debes indicar un nombre para tu actividad";
            AV19sdt_sa.gxTpr_Timer = 4000;
            AV19sdt_sa.gxTpr_Allowoutsideclick = true;
            AV19sdt_sa.gxTpr_Type = "error";
            this.executeUsercontrolMethod(sPrefix, false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV19sdt_sa});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19sdt_sa", AV19sdt_sa);
      }

      protected void E15122( )
      {
         /* 'Eliminar' Routine */
         returnInSub = false;
         AV8ActividadesBC2.Load(A9TableroId, A12TareaId, A30ActividadId);
         AV8ActividadesBC2.Delete();
         if ( AV8ActividadesBC2.Success() )
         {
            context.CommitDataStores("listadoactividadesf",pr_default);
         }
         else
         {
            context.RollbackDataStores("listadoactividadesf",pr_default);
         }
         gxgrGridactividades_refresh( A9TableroId, A12TareaId, AV30T1, A33ActividadEstado, sPrefix) ;
         /*  Sending Event outputs  */
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
         PA122( ) ;
         WS122( ) ;
         WE122( ) ;
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
         PA122( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "listadoactividadesf", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA122( ) ;
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
         PA122( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS122( ) ;
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
         WS122( ) ;
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
         WE122( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20221022911298", true, true);
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
            context.AddJavascriptSource("listadoactividadesf.js", "?20221022911299", false, true);
            context.AddJavascriptSource("RAMP/sweetAlert/js/sweetalert2.min.js", "", false, true);
            context.AddJavascriptSource("RAMP/shared/js/jquery-3.5.1.min.js", "", false, true);
            context.AddJavascriptSource("RAMP/shared/js/popper.js", "", false, true);
            context.AddJavascriptSource("RAMP/shared/js/bootstrap.min.js", "", false, true);
            context.AddJavascriptSource("RAMP/sweetAlert/RAMP_AddOns_SweetAlertRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_152( )
      {
         edtActividadId_Internalname = sPrefix+"ACTIVIDADID_"+sGXsfl_15_idx;
         edtActividadNombre_Internalname = sPrefix+"ACTIVIDADNOMBRE_"+sGXsfl_15_idx;
         edtavState_Internalname = sPrefix+"vSTATE_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtActividadId_Internalname = sPrefix+"ACTIVIDADID_"+sGXsfl_15_fel_idx;
         edtActividadNombre_Internalname = sPrefix+"ACTIVIDADNOMBRE_"+sGXsfl_15_fel_idx;
         edtavState_Internalname = sPrefix+"vSTATE_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         SubsflControlProps_152( ) ;
         WB120( ) ;
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
            if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_15_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridactividadesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtActividadId_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridactividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtActividadId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A30ActividadId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A30ActividadId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtActividadId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtActividadId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)15,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridactividadesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridactividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtActividadNombre_Internalname,StringUtil.RTrim( A31ActividadNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtActividadNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)15,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridactividadesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "Image";
         StyleString = "";
         AV20state_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV20state))&&String.IsNullOrEmpty(StringUtil.RTrim( AV39State_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV20state)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV20state)) ? AV39State_GXI : context.PathToRelativeUrl( AV20state));
         GridactividadesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavState_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)1,(short)20,(string)"px",(short)20,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV20state_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes122( ) ;
         GridactividadesContainer.AddRow(GridactividadesRow);
         nGXsfl_15_idx = ((subGridactividades_Islastpage==1)&&(nGXsfl_15_idx+1>subGridactividades_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
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
         if ( GridactividadesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridactividadesContainer"+"DivS\" data-gxgridid=\"15\">") ;
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
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image"+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridactividadesColumn.AddObjectProperty("Value", StringUtil.RTrim( A31ActividadNombre));
            GridactividadesContainer.AddColumnProperties(GridactividadesColumn);
            GridactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridactividadesColumn.AddObjectProperty("Value", context.convertURL( AV20state));
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
         edtActividadId_Internalname = sPrefix+"ACTIVIDADID";
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
         edtActividadNombre_Jsonclick = "";
         edtActividadId_Jsonclick = "";
         subGridactividades_Class = "WorkWithSelection";
         subGridactividades_Backcolorstyle = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDACTIVIDADES_nFirstRecordOnPage'},{av:'GRIDACTIVIDADES_nEOF'},{av:'sPrefix'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9'},{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''},{av:'AV30T1',fld:'vT1',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblEstadisticas_Caption',ctrl:'ESTADISTICAS',prop:'Caption'}]}");
         setEventMetadata("GRIDACTIVIDADES.LOAD","{handler:'E13122',iparms:[{av:'AV30T1',fld:'vT1',pic:'',hsh:true},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9'},{av:'A30ActividadId',fld:'ACTIVIDADID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("GRIDACTIVIDADES.LOAD",",oparms:[{av:'AV20state',fld:'vSTATE',pic:''}]}");
         setEventMetadata("'NUEVO'","{handler:'E14122',iparms:[{av:'GRIDACTIVIDADES_nFirstRecordOnPage'},{av:'GRIDACTIVIDADES_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9'},{av:'AV30T1',fld:'vT1',pic:'',hsh:true},{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''},{av:'sPrefix'},{av:'AV10ActividadNombre',fld:'vACTIVIDADNOMBRE',pic:''},{av:'AV19sdt_sa',fld:'vSDT_SA',pic:''}]");
         setEventMetadata("'NUEVO'",",oparms:[{av:'AV10ActividadNombre',fld:'vACTIVIDADNOMBRE',pic:''},{av:'AV19sdt_sa',fld:'vSDT_SA',pic:''},{av:'lblEstadisticas_Caption',ctrl:'ESTADISTICAS',prop:'Caption'}]}");
         setEventMetadata("'ELIMINAR'","{handler:'E15122',iparms:[{av:'GRIDACTIVIDADES_nFirstRecordOnPage'},{av:'GRIDACTIVIDADES_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9'},{av:'AV30T1',fld:'vT1',pic:'',hsh:true},{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''},{av:'sPrefix'},{av:'A30ActividadId',fld:'ACTIVIDADID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'ELIMINAR'",",oparms:[{av:'lblEstadisticas_Caption',ctrl:'ESTADISTICAS',prop:'Caption'}]}");
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
         AV30T1 = new SdtTareas(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV10ActividadNombre = "";
         AV19sdt_sa = new SdtSDT_SweetAlert(context);
         GX_FocusControl = "";
         lblSubtitulo_Jsonclick = "";
         GridactividadesContainer = new GXWebGrid( context);
         sStyleString = "";
         ucRamp_addons_sweetalert1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A31ActividadNombre = "";
         AV20state = "";
         AV39State_GXI = "";
         scmdbuf = "";
         H00122_A9TableroId = new short[1] ;
         H00122_A12TareaId = new short[1] ;
         H00122_A31ActividadNombre = new string[] {""} ;
         H00122_A30ActividadId = new short[1] ;
         H00123_AV13contador = new short[1] ;
         H00124_AV12completados = new short[1] ;
         H00125_AV13contador = new short[1] ;
         H00126_AV12completados = new short[1] ;
         AV7ActividadesBC = new SdtActividades(context);
         GridactividadesRow = new GXWebRow();
         AV5Act = new SdtActividades(context);
         AV26Tareas = new SdtTareas(context);
         AV8ActividadesBC2 = new SdtActividades(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA9TableroId = "";
         sCtrlA12TareaId = "";
         subGridactividades_Linesclass = "";
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         GridactividadesColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listadoactividadesf__default(),
            new Object[][] {
                new Object[] {
               H00122_A9TableroId, H00122_A12TareaId, H00122_A31ActividadNombre, H00122_A30ActividadId
               }
               , new Object[] {
               H00123_AV13contador
               }
               , new Object[] {
               H00124_AV12completados
               }
               , new Object[] {
               H00125_AV13contador
               }
               , new Object[] {
               H00126_AV12completados
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtActividadId_Visible = 0;
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
      private short AV13contador ;
      private short cV13contador ;
      private short AV11avance ;
      private short AV12completados ;
      private short cV12completados ;
      private short GRIDACTIVIDADES_nEOF ;
      private short AV14count ;
      private short AV9ActividadId ;
      private short GXt_int1 ;
      private short AV31TableroId ;
      private short AV32TareaId ;
      private short subGridactividades_Backstyle ;
      private short subGridactividades_Titlebackstyle ;
      private short subGridactividades_Allowselection ;
      private short subGridactividades_Allowhovering ;
      private short subGridactividades_Allowcollapsing ;
      private short subGridactividades_Collapsed ;
      private int nRC_GXsfl_15 ;
      private int nGXsfl_15_idx=1 ;
      private int edtActividadId_Visible ;
      private int subGridactividades_Islastpage ;
      private int idxLst ;
      private int subGridactividades_Backcolor ;
      private int subGridactividades_Allbackcolor ;
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
      private string sGXsfl_15_idx="0001" ;
      private string edtActividadId_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV10ActividadNombre ;
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
      private string sStyleString ;
      private string subGridactividades_Internalname ;
      private string Ramp_addons_sweetalert1_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string A31ActividadNombre ;
      private string edtActividadNombre_Internalname ;
      private string edtavState_Internalname ;
      private string scmdbuf ;
      private string sCtrlA9TableroId ;
      private string sCtrlA12TareaId ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subGridactividades_Class ;
      private string subGridactividades_Linesclass ;
      private string ROClassString ;
      private string edtActividadId_Jsonclick ;
      private string edtActividadNombre_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string subGridactividades_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A33ActividadEstado ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV20state_IsBlob ;
      private string AV39State_GXI ;
      private string AV20state ;
      private GXWebGrid GridactividadesContainer ;
      private GXWebRow GridactividadesRow ;
      private GXWebColumn GridactividadesColumn ;
      private GXUserControl ucRamp_addons_sweetalert1 ;
      private GXWebForm Form ;
      private SdtTareas AV26Tareas ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private short aP1_TareaId ;
      private IDataStoreProvider pr_default ;
      private short[] H00122_A9TableroId ;
      private short[] H00122_A12TareaId ;
      private string[] H00122_A31ActividadNombre ;
      private short[] H00122_A30ActividadId ;
      private short[] H00123_AV13contador ;
      private short[] H00124_AV12completados ;
      private short[] H00125_AV13contador ;
      private short[] H00126_AV12completados ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private SdtActividades AV7ActividadesBC ;
      private SdtActividades AV5Act ;
      private SdtActividades AV8ActividadesBC2 ;
      private SdtSDT_SweetAlert AV19sdt_sa ;
      private SdtTareas AV30T1 ;
   }

   public class listadoactividadesf__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00122;
          prmH00122 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmH00123;
          prmH00123 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmH00124;
          prmH00124 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmH00125;
          prmH00125 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmH00126;
          prmH00126 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00122", "SELECT [TableroId], [TareaId], [ActividadNombre], [ActividadId] FROM [Actividades] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ORDER BY [TableroId], [TareaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00122,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00123", "SELECT COUNT(*) FROM [Actividades] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00123,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00124", "SELECT COUNT(*) FROM [Actividades] WHERE ([TableroId] = @TableroId and [TareaId] = @TareaId) AND ([ActividadEstado] = 1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00124,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00125", "SELECT COUNT(*) FROM [Actividades] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00125,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00126", "SELECT COUNT(*) FROM [Actividades] WHERE ([TableroId] = @TableroId and [TareaId] = @TareaId) AND ([ActividadEstado] = 1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00126,1, GxCacheFrequency.OFF ,true,false )
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
