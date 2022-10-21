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
   public class gx0040 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0040( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx0040( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pTableroId ,
                           out short aP1_pTareaId )
      {
         this.AV13pTableroId = 0 ;
         this.AV14pTareaId = 0 ;
         executePrivate();
         aP0_pTableroId=this.AV13pTableroId;
         aP1_pTareaId=this.AV14pTareaId;
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
            gxfirstwebparm = GetFirstPar( "pTableroId");
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
               gxfirstwebparm = GetFirstPar( "pTableroId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pTableroId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV13pTableroId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pTableroId", StringUtil.LTrimStr( (decimal)(AV13pTableroId), 4, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pTareaId = (short)(NumberUtil.Val( GetPar( "pTareaId"), "."));
                  AssignAttri("", false, "AV14pTareaId", StringUtil.LTrimStr( (decimal)(AV14pTareaId), 4, 0));
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_84 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."));
         nGXsfl_84_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."));
         AV6cTableroId = (short)(NumberUtil.Val( GetPar( "cTableroId"), "."));
         AV7cTareaId = (short)(NumberUtil.Val( GetPar( "cTareaId"), "."));
         AV8cTareaNombre = GetPar( "cTareaNombre");
         AV10cResponsableId = (short)(NumberUtil.Val( GetPar( "cResponsableId"), "."));
         AV11cTareaFechaInicio = context.localUtil.ParseDateParm( GetPar( "cTareaFechaInicio"));
         AV12cTareaFechaFin = context.localUtil.ParseDateParm( GetPar( "cTareaFechaFin"));
         AV16cTareaEstado = (short)(NumberUtil.Val( GetPar( "cTareaEstado"), "."));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cTareaId, AV8cTareaNombre, AV10cResponsableId, AV11cTareaFechaInicio, AV12cTareaFechaFin, AV16cTareaEstado) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdpromptmasterpage", "GeneXus.Programs.rwdpromptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
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
         PA082( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START082( ) ;
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0040.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pTableroId,4,0)),UrlEncode(StringUtil.LTrimStr(AV14pTareaId,4,0))}, new string[] {"pTableroId","pTareaId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCTABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTAREAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cTareaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTAREANOMBRE", StringUtil.RTrim( AV8cTareaNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cResponsableId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTAREAFECHAINICIO", context.localUtil.Format(AV11cTareaFechaInicio, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTAREAFECHAFIN", context.localUtil.Format(AV12cTareaFechaFin, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTAREAESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16cTareaEstado), 4, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPTABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pTableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPTAREAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pTareaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "TABLEROIDFILTERCONTAINER_Class", StringUtil.RTrim( divTableroidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TAREAIDFILTERCONTAINER_Class", StringUtil.RTrim( divTareaidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TAREANOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divTareanombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESPONSABLEIDFILTERCONTAINER_Class", StringUtil.RTrim( divResponsableidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TAREAFECHAINICIOFILTERCONTAINER_Class", StringUtil.RTrim( divTareafechainiciofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TAREAFECHAFINFILTERCONTAINER_Class", StringUtil.RTrim( divTareafechafinfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TAREAESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divTareaestadofiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE082( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT082( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx0040.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pTableroId,4,0)),UrlEncode(StringUtil.LTrimStr(AV14pTareaId,4,0))}, new string[] {"pTableroId","pTareaId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0040" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Tareas" ;
      }

      protected void WB080( )
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
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableroidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTableroidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltableroidfilter_Internalname, "Tablero Id", "", "", lblLbltableroidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtableroid_Internalname, "Tablero Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtableroid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTableroId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCtableroid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cTableroId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cTableroId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtableroid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtableroid_Visible, edtavCtableroid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTareaidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTareaidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltareaidfilter_Internalname, "Tarea Id", "", "", lblLbltareaidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtareaid_Internalname, "Tarea Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtareaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cTareaId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCtareaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cTareaId), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cTareaId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtareaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtareaid_Visible, edtavCtareaid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTareanombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divTareanombrefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltareanombrefilter_Internalname, "Tarea Nombre", "", "", lblLbltareanombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtareanombre_Internalname, "Tarea Nombre", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtareanombre_Internalname, StringUtil.RTrim( AV8cTareaNombre), StringUtil.RTrim( context.localUtil.Format( AV8cTareaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtareanombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtareanombre_Visible, edtavCtareanombre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsableidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResponsableidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresponsableidfilter_Internalname, "Responsable Id", "", "", lblLblresponsableidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresponsableid_Internalname, "Responsable Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresponsableid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cResponsableId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCresponsableid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cResponsableId), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cResponsableId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresponsableid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresponsableid_Visible, edtavCresponsableid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTareafechainiciofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTareafechainiciofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltareafechainiciofilter_Internalname, "Tarea Fecha Inicio", "", "", lblLbltareafechainiciofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15081_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtareafechainicio_Internalname, "Tarea Fecha Inicio", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtareafechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtareafechainicio_Internalname, context.localUtil.Format(AV11cTareaFechaInicio, "99/99/99"), context.localUtil.Format( AV11cTareaFechaInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtareafechainicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtareafechainicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTareafechafinfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTareafechafinfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltareafechafinfilter_Internalname, "Tarea Fecha Fin", "", "", lblLbltareafechafinfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16081_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtareafechafin_Internalname, "Tarea Fecha Fin", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtareafechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtareafechafin_Internalname, context.localUtil.Format(AV12cTareaFechaFin, "99/99/99"), context.localUtil.Format( AV12cTareaFechaFin, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtareafechafin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtareafechafin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTareaestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTareaestadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltareaestadofilter_Internalname, "Tarea Estado", "", "", lblLbltareaestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtareaestado_Internalname, "Tarea Estado", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtareaestado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16cTareaEstado), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCtareaestado_Enabled!=0) ? context.localUtil.Format( (decimal)(AV16cTareaEstado), "ZZZ9") : context.localUtil.Format( (decimal)(AV16cTareaEstado), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtareaestado_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtareaestado_Visible, edtavCtareaestado_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18081_client"+"'", TempTags, "", 2, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START082( )
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
            Form.Meta.addItem("description", "Selection List Tareas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP080( ) ;
      }

      protected void WS082( )
      {
         START082( ) ;
         EVT082( ) ;
      }

      protected void EVT082( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV19Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A9TableroId = (short)(context.localUtil.CToN( cgiGet( edtTableroId_Internalname), ",", "."));
                              A12TareaId = (short)(context.localUtil.CToN( cgiGet( edtTareaId_Internalname), ",", "."));
                              A13TareaNombre = cgiGet( edtTareaNombre_Internalname);
                              A23ResponsableId = (short)(context.localUtil.CToN( cgiGet( edtResponsableId_Internalname), ",", "."));
                              n23ResponsableId = false;
                              A24TareaFechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTareaFechaInicio_Internalname), 0));
                              A25TareaFechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTareaFechaFin_Internalname), 0));
                              A46TareaEstado = (short)(context.localUtil.CToN( cgiGet( edtTareaEstado_Internalname), ",", "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19082 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20082 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ctableroid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTABLEROID"), ",", ".") != Convert.ToDecimal( AV6cTableroId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctareaid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTAREAID"), ",", ".") != Convert.ToDecimal( AV7cTareaId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctareanombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCTAREANOMBRE"), AV8cTareaNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresponsableid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESPONSABLEID"), ",", ".") != Convert.ToDecimal( AV10cResponsableId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctareafechainicio Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTAREAFECHAINICIO"), 0) != AV11cTareaFechaInicio )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctareafechafin Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTAREAFECHAFIN"), 0) != AV12cTareaFechaFin )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctareaestado Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTAREAESTADO"), ",", ".") != Convert.ToDecimal( AV16cTareaEstado )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21082 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
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

      protected void WE082( )
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

      protected void PA082( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cTableroId ,
                                        short AV7cTareaId ,
                                        string AV8cTareaNombre ,
                                        short AV10cResponsableId ,
                                        DateTime AV11cTareaFechaInicio ,
                                        DateTime AV12cTareaFechaFin ,
                                        short AV16cTareaEstado )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF082( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TAREAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TAREAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ".", "")));
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
         RF082( ) ;
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

      protected void RF082( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8cTareaNombre ,
                                                 AV10cResponsableId ,
                                                 AV11cTareaFechaInicio ,
                                                 AV12cTareaFechaFin ,
                                                 AV16cTareaEstado ,
                                                 A13TareaNombre ,
                                                 A23ResponsableId ,
                                                 A24TareaFechaInicio ,
                                                 A25TareaFechaFin ,
                                                 A46TareaEstado ,
                                                 AV6cTableroId ,
                                                 AV7cTareaId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.SHORT
                                                 }
            });
            lV8cTareaNombre = StringUtil.PadR( StringUtil.RTrim( AV8cTareaNombre), 20, "%");
            /* Using cursor H00082 */
            pr_default.execute(0, new Object[] {AV6cTableroId, AV7cTareaId, lV8cTareaNombre, AV10cResponsableId, AV11cTareaFechaInicio, AV12cTareaFechaFin, AV16cTareaEstado, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A46TareaEstado = H00082_A46TareaEstado[0];
               A25TareaFechaFin = H00082_A25TareaFechaFin[0];
               A24TareaFechaInicio = H00082_A24TareaFechaInicio[0];
               A23ResponsableId = H00082_A23ResponsableId[0];
               n23ResponsableId = H00082_n23ResponsableId[0];
               A13TareaNombre = H00082_A13TareaNombre[0];
               A12TareaId = H00082_A12TareaId[0];
               A9TableroId = H00082_A9TableroId[0];
               /* Execute user event: Load */
               E20082 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB080( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes082( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TAREAID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV8cTareaNombre ,
                                              AV10cResponsableId ,
                                              AV11cTareaFechaInicio ,
                                              AV12cTareaFechaFin ,
                                              AV16cTareaEstado ,
                                              A13TareaNombre ,
                                              A23ResponsableId ,
                                              A24TareaFechaInicio ,
                                              A25TareaFechaFin ,
                                              A46TareaEstado ,
                                              AV6cTableroId ,
                                              AV7cTareaId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV8cTareaNombre = StringUtil.PadR( StringUtil.RTrim( AV8cTareaNombre), 20, "%");
         /* Using cursor H00083 */
         pr_default.execute(1, new Object[] {AV6cTableroId, AV7cTareaId, lV8cTareaNombre, AV10cResponsableId, AV11cTareaFechaInicio, AV12cTareaFechaFin, AV16cTareaEstado});
         GRID1_nRecordCount = H00083_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cTareaId, AV8cTareaNombre, AV10cResponsableId, AV11cTareaFechaInicio, AV12cTareaFechaFin, AV16cTareaEstado) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cTareaId, AV8cTareaNombre, AV10cResponsableId, AV11cTareaFechaInicio, AV12cTareaFechaFin, AV16cTareaEstado) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cTareaId, AV8cTareaNombre, AV10cResponsableId, AV11cTareaFechaInicio, AV12cTareaFechaFin, AV16cTareaEstado) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cTareaId, AV8cTareaNombre, AV10cResponsableId, AV11cTareaFechaInicio, AV12cTareaFechaFin, AV16cTareaEstado) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cTareaId, AV8cTareaNombre, AV10cResponsableId, AV11cTareaFechaInicio, AV12cTareaFechaFin, AV16cTareaEstado) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP080( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19082 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ",", "."));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtableroid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtableroid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTABLEROID");
               GX_FocusControl = edtavCtableroid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cTableroId = 0;
               AssignAttri("", false, "AV6cTableroId", StringUtil.LTrimStr( (decimal)(AV6cTableroId), 4, 0));
            }
            else
            {
               AV6cTableroId = (short)(context.localUtil.CToN( cgiGet( edtavCtableroid_Internalname), ",", "."));
               AssignAttri("", false, "AV6cTableroId", StringUtil.LTrimStr( (decimal)(AV6cTableroId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtareaid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtareaid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTAREAID");
               GX_FocusControl = edtavCtareaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cTareaId = 0;
               AssignAttri("", false, "AV7cTareaId", StringUtil.LTrimStr( (decimal)(AV7cTareaId), 4, 0));
            }
            else
            {
               AV7cTareaId = (short)(context.localUtil.CToN( cgiGet( edtavCtareaid_Internalname), ",", "."));
               AssignAttri("", false, "AV7cTareaId", StringUtil.LTrimStr( (decimal)(AV7cTareaId), 4, 0));
            }
            AV8cTareaNombre = cgiGet( edtavCtareanombre_Internalname);
            AssignAttri("", false, "AV8cTareaNombre", AV8cTareaNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCresponsableid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCresponsableid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRESPONSABLEID");
               GX_FocusControl = edtavCresponsableid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cResponsableId = 0;
               AssignAttri("", false, "AV10cResponsableId", StringUtil.LTrimStr( (decimal)(AV10cResponsableId), 4, 0));
            }
            else
            {
               AV10cResponsableId = (short)(context.localUtil.CToN( cgiGet( edtavCresponsableid_Internalname), ",", "."));
               AssignAttri("", false, "AV10cResponsableId", StringUtil.LTrimStr( (decimal)(AV10cResponsableId), 4, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtareafechainicio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tarea Fecha Inicio"}), 1, "vCTAREAFECHAINICIO");
               GX_FocusControl = edtavCtareafechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cTareaFechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV11cTareaFechaInicio", context.localUtil.Format(AV11cTareaFechaInicio, "99/99/99"));
            }
            else
            {
               AV11cTareaFechaInicio = context.localUtil.CToD( cgiGet( edtavCtareafechainicio_Internalname), 2);
               AssignAttri("", false, "AV11cTareaFechaInicio", context.localUtil.Format(AV11cTareaFechaInicio, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtareafechafin_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tarea Fecha Fin"}), 1, "vCTAREAFECHAFIN");
               GX_FocusControl = edtavCtareafechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cTareaFechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV12cTareaFechaFin", context.localUtil.Format(AV12cTareaFechaFin, "99/99/99"));
            }
            else
            {
               AV12cTareaFechaFin = context.localUtil.CToD( cgiGet( edtavCtareafechafin_Internalname), 2);
               AssignAttri("", false, "AV12cTareaFechaFin", context.localUtil.Format(AV12cTareaFechaFin, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtareaestado_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtareaestado_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTAREAESTADO");
               GX_FocusControl = edtavCtareaestado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16cTareaEstado = 0;
               AssignAttri("", false, "AV16cTareaEstado", StringUtil.LTrimStr( (decimal)(AV16cTareaEstado), 4, 0));
            }
            else
            {
               AV16cTareaEstado = (short)(context.localUtil.CToN( cgiGet( edtavCtareaestado_Internalname), ",", "."));
               AssignAttri("", false, "AV16cTareaEstado", StringUtil.LTrimStr( (decimal)(AV16cTareaEstado), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTABLEROID"), ",", ".") != Convert.ToDecimal( AV6cTableroId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTAREAID"), ",", ".") != Convert.ToDecimal( AV7cTareaId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCTAREANOMBRE"), AV8cTareaNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESPONSABLEID"), ",", ".") != Convert.ToDecimal( AV10cResponsableId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCTAREAFECHAINICIO"), 2) ) != DateTimeUtil.ResetTime ( AV11cTareaFechaInicio ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCTAREAFECHAFIN"), 2) ) != DateTimeUtil.ResetTime ( AV12cTareaFechaFin ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTAREAESTADO"), ",", ".") != Convert.ToDecimal( AV16cTareaEstado )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E19082 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19082( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Tareas", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV15ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20082( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV19Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E21082 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21082( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pTableroId = A9TableroId;
         AssignAttri("", false, "AV13pTableroId", StringUtil.LTrimStr( (decimal)(AV13pTableroId), 4, 0));
         AV14pTareaId = A12TareaId;
         AssignAttri("", false, "AV14pTareaId", StringUtil.LTrimStr( (decimal)(AV14pTareaId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pTableroId,(short)AV14pTareaId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pTableroId","AV14pTareaId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pTableroId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV13pTableroId", StringUtil.LTrimStr( (decimal)(AV13pTableroId), 4, 0));
         AV14pTareaId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV14pTareaId", StringUtil.LTrimStr( (decimal)(AV14pTareaId), 4, 0));
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
         PA082( ) ;
         WS082( ) ;
         WE082( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022101613111058", true, true);
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
         context.AddJavascriptSource("gx0040.js", "?2022101613111058", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtTableroId_Internalname = "TABLEROID_"+sGXsfl_84_idx;
         edtTareaId_Internalname = "TAREAID_"+sGXsfl_84_idx;
         edtTareaNombre_Internalname = "TAREANOMBRE_"+sGXsfl_84_idx;
         edtResponsableId_Internalname = "RESPONSABLEID_"+sGXsfl_84_idx;
         edtTareaFechaInicio_Internalname = "TAREAFECHAINICIO_"+sGXsfl_84_idx;
         edtTareaFechaFin_Internalname = "TAREAFECHAFIN_"+sGXsfl_84_idx;
         edtTareaEstado_Internalname = "TAREAESTADO_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtTableroId_Internalname = "TABLEROID_"+sGXsfl_84_fel_idx;
         edtTareaId_Internalname = "TAREAID_"+sGXsfl_84_fel_idx;
         edtTareaNombre_Internalname = "TAREANOMBRE_"+sGXsfl_84_fel_idx;
         edtResponsableId_Internalname = "RESPONSABLEID_"+sGXsfl_84_fel_idx;
         edtTareaFechaInicio_Internalname = "TAREAFECHAINICIO_"+sGXsfl_84_fel_idx;
         edtTareaFechaFin_Internalname = "TAREAFECHAFIN_"+sGXsfl_84_fel_idx;
         edtTareaEstado_Internalname = "TAREAESTADO_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB080( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV19Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV19Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTableroId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTableroId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTareaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTareaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtTareaNombre_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtTareaNombre_Internalname, "Link", edtTareaNombre_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTareaNombre_Internalname,StringUtil.RTrim( A13TareaNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTareaNombre_Link,(string)"",(string)"",(string)"",(string)edtTareaNombre_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A23ResponsableId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A23ResponsableId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsableId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTareaFechaInicio_Internalname,context.localUtil.Format(A24TareaFechaInicio, "99/99/99"),context.localUtil.Format( A24TareaFechaInicio, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTareaFechaInicio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTareaFechaFin_Internalname,context.localUtil.Format(A25TareaFechaFin, "99/99/99"),context.localUtil.Format( A25TareaFechaFin, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTareaFechaFin_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTareaEstado_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A46TareaEstado), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A46TareaEstado), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTareaEstado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes082( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tablero Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nombre") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Fecha Inicio") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Fecha Fin") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Estado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A13TareaNombre));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtTareaNombre_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23ResponsableId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A24TareaFechaInicio, "99/99/99"));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A25TareaFechaFin, "99/99/99"));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A46TareaEstado), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLbltableroidfilter_Internalname = "LBLTABLEROIDFILTER";
         edtavCtableroid_Internalname = "vCTABLEROID";
         divTableroidfiltercontainer_Internalname = "TABLEROIDFILTERCONTAINER";
         lblLbltareaidfilter_Internalname = "LBLTAREAIDFILTER";
         edtavCtareaid_Internalname = "vCTAREAID";
         divTareaidfiltercontainer_Internalname = "TAREAIDFILTERCONTAINER";
         lblLbltareanombrefilter_Internalname = "LBLTAREANOMBREFILTER";
         edtavCtareanombre_Internalname = "vCTAREANOMBRE";
         divTareanombrefiltercontainer_Internalname = "TAREANOMBREFILTERCONTAINER";
         lblLblresponsableidfilter_Internalname = "LBLRESPONSABLEIDFILTER";
         edtavCresponsableid_Internalname = "vCRESPONSABLEID";
         divResponsableidfiltercontainer_Internalname = "RESPONSABLEIDFILTERCONTAINER";
         lblLbltareafechainiciofilter_Internalname = "LBLTAREAFECHAINICIOFILTER";
         edtavCtareafechainicio_Internalname = "vCTAREAFECHAINICIO";
         divTareafechainiciofiltercontainer_Internalname = "TAREAFECHAINICIOFILTERCONTAINER";
         lblLbltareafechafinfilter_Internalname = "LBLTAREAFECHAFINFILTER";
         edtavCtareafechafin_Internalname = "vCTAREAFECHAFIN";
         divTareafechafinfiltercontainer_Internalname = "TAREAFECHAFINFILTERCONTAINER";
         lblLbltareaestadofilter_Internalname = "LBLTAREAESTADOFILTER";
         edtavCtareaestado_Internalname = "vCTAREAESTADO";
         divTareaestadofiltercontainer_Internalname = "TAREAESTADOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtTableroId_Internalname = "TABLEROID";
         edtTareaId_Internalname = "TAREAID";
         edtTareaNombre_Internalname = "TAREANOMBRE";
         edtResponsableId_Internalname = "RESPONSABLEID";
         edtTareaFechaInicio_Internalname = "TAREAFECHAINICIO";
         edtTareaFechaFin_Internalname = "TAREAFECHAFIN";
         edtTareaEstado_Internalname = "TAREAESTADO";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtTareaEstado_Jsonclick = "";
         edtTareaFechaFin_Jsonclick = "";
         edtTareaFechaInicio_Jsonclick = "";
         edtResponsableId_Jsonclick = "";
         edtTareaNombre_Jsonclick = "";
         edtTareaNombre_Link = "";
         edtTareaId_Jsonclick = "";
         edtTableroId_Jsonclick = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCtareaestado_Jsonclick = "";
         edtavCtareaestado_Enabled = 1;
         edtavCtareaestado_Visible = 1;
         edtavCtareafechafin_Jsonclick = "";
         edtavCtareafechafin_Enabled = 1;
         edtavCtareafechainicio_Jsonclick = "";
         edtavCtareafechainicio_Enabled = 1;
         edtavCresponsableid_Jsonclick = "";
         edtavCresponsableid_Enabled = 1;
         edtavCresponsableid_Visible = 1;
         edtavCtareanombre_Jsonclick = "";
         edtavCtareanombre_Enabled = 1;
         edtavCtareanombre_Visible = 1;
         edtavCtareaid_Jsonclick = "";
         edtavCtareaid_Enabled = 1;
         edtavCtareaid_Visible = 1;
         edtavCtableroid_Jsonclick = "";
         edtavCtableroid_Enabled = 1;
         edtavCtableroid_Visible = 1;
         divTareaestadofiltercontainer_Class = "AdvancedContainerItem";
         divTareafechafinfiltercontainer_Class = "AdvancedContainerItem";
         divTareafechainiciofiltercontainer_Class = "AdvancedContainerItem";
         divResponsableidfiltercontainer_Class = "AdvancedContainerItem";
         divTareanombrefiltercontainer_Class = "AdvancedContainerItem";
         divTareaidfiltercontainer_Class = "AdvancedContainerItem";
         divTableroidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Tareas";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cTareaId',fld:'vCTAREAID',pic:'ZZZ9'},{av:'AV8cTareaNombre',fld:'vCTAREANOMBRE',pic:''},{av:'AV10cResponsableId',fld:'vCRESPONSABLEID',pic:'ZZZ9'},{av:'AV11cTareaFechaInicio',fld:'vCTAREAFECHAINICIO',pic:''},{av:'AV12cTareaFechaFin',fld:'vCTAREAFECHAFIN',pic:''},{av:'AV16cTareaEstado',fld:'vCTAREAESTADO',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18081',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLTABLEROIDFILTER.CLICK","{handler:'E11081',iparms:[{av:'divTableroidfiltercontainer_Class',ctrl:'TABLEROIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTABLEROIDFILTER.CLICK",",oparms:[{av:'divTableroidfiltercontainer_Class',ctrl:'TABLEROIDFILTERCONTAINER',prop:'Class'},{av:'edtavCtableroid_Visible',ctrl:'vCTABLEROID',prop:'Visible'}]}");
         setEventMetadata("LBLTAREAIDFILTER.CLICK","{handler:'E12081',iparms:[{av:'divTareaidfiltercontainer_Class',ctrl:'TAREAIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTAREAIDFILTER.CLICK",",oparms:[{av:'divTareaidfiltercontainer_Class',ctrl:'TAREAIDFILTERCONTAINER',prop:'Class'},{av:'edtavCtareaid_Visible',ctrl:'vCTAREAID',prop:'Visible'}]}");
         setEventMetadata("LBLTAREANOMBREFILTER.CLICK","{handler:'E13081',iparms:[{av:'divTareanombrefiltercontainer_Class',ctrl:'TAREANOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTAREANOMBREFILTER.CLICK",",oparms:[{av:'divTareanombrefiltercontainer_Class',ctrl:'TAREANOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCtareanombre_Visible',ctrl:'vCTAREANOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLRESPONSABLEIDFILTER.CLICK","{handler:'E14081',iparms:[{av:'divResponsableidfiltercontainer_Class',ctrl:'RESPONSABLEIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRESPONSABLEIDFILTER.CLICK",",oparms:[{av:'divResponsableidfiltercontainer_Class',ctrl:'RESPONSABLEIDFILTERCONTAINER',prop:'Class'},{av:'edtavCresponsableid_Visible',ctrl:'vCRESPONSABLEID',prop:'Visible'}]}");
         setEventMetadata("LBLTAREAFECHAINICIOFILTER.CLICK","{handler:'E15081',iparms:[{av:'divTareafechainiciofiltercontainer_Class',ctrl:'TAREAFECHAINICIOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTAREAFECHAINICIOFILTER.CLICK",",oparms:[{av:'divTareafechainiciofiltercontainer_Class',ctrl:'TAREAFECHAINICIOFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTAREAFECHAFINFILTER.CLICK","{handler:'E16081',iparms:[{av:'divTareafechafinfiltercontainer_Class',ctrl:'TAREAFECHAFINFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTAREAFECHAFINFILTER.CLICK",",oparms:[{av:'divTareafechafinfiltercontainer_Class',ctrl:'TAREAFECHAFINFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTAREAESTADOFILTER.CLICK","{handler:'E17081',iparms:[{av:'divTareaestadofiltercontainer_Class',ctrl:'TAREAESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTAREAESTADOFILTER.CLICK",",oparms:[{av:'divTareaestadofiltercontainer_Class',ctrl:'TAREAESTADOFILTERCONTAINER',prop:'Class'},{av:'edtavCtareaestado_Visible',ctrl:'vCTAREAESTADO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21082',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9',hsh:true},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pTableroId',fld:'vPTABLEROID',pic:'ZZZ9'},{av:'AV14pTareaId',fld:'vPTAREAID',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cTareaId',fld:'vCTAREAID',pic:'ZZZ9'},{av:'AV8cTareaNombre',fld:'vCTAREANOMBRE',pic:''},{av:'AV10cResponsableId',fld:'vCRESPONSABLEID',pic:'ZZZ9'},{av:'AV11cTareaFechaInicio',fld:'vCTAREAFECHAINICIO',pic:''},{av:'AV12cTareaFechaFin',fld:'vCTAREAFECHAFIN',pic:''},{av:'AV16cTareaEstado',fld:'vCTAREAESTADO',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cTareaId',fld:'vCTAREAID',pic:'ZZZ9'},{av:'AV8cTareaNombre',fld:'vCTAREANOMBRE',pic:''},{av:'AV10cResponsableId',fld:'vCRESPONSABLEID',pic:'ZZZ9'},{av:'AV11cTareaFechaInicio',fld:'vCTAREAFECHAINICIO',pic:''},{av:'AV12cTareaFechaFin',fld:'vCTAREAFECHAFIN',pic:''},{av:'AV16cTareaEstado',fld:'vCTAREAESTADO',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cTareaId',fld:'vCTAREAID',pic:'ZZZ9'},{av:'AV8cTareaNombre',fld:'vCTAREANOMBRE',pic:''},{av:'AV10cResponsableId',fld:'vCRESPONSABLEID',pic:'ZZZ9'},{av:'AV11cTareaFechaInicio',fld:'vCTAREAFECHAINICIO',pic:''},{av:'AV12cTareaFechaFin',fld:'vCTAREAFECHAFIN',pic:''},{av:'AV16cTareaEstado',fld:'vCTAREAESTADO',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cTareaId',fld:'vCTAREAID',pic:'ZZZ9'},{av:'AV8cTareaNombre',fld:'vCTAREANOMBRE',pic:''},{av:'AV10cResponsableId',fld:'vCRESPONSABLEID',pic:'ZZZ9'},{av:'AV11cTareaFechaInicio',fld:'vCTAREAFECHAINICIO',pic:''},{av:'AV12cTareaFechaFin',fld:'vCTAREAFECHAFIN',pic:''},{av:'AV16cTareaEstado',fld:'vCTAREAESTADO',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CTAREAFECHAINICIO","{handler:'Validv_Ctareafechainicio',iparms:[]");
         setEventMetadata("VALIDV_CTAREAFECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_CTAREAFECHAFIN","{handler:'Validv_Ctareafechafin',iparms:[]");
         setEventMetadata("VALIDV_CTAREAFECHAFIN",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Tareaestado',iparms:[]");
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
         AV8cTareaNombre = "";
         AV11cTareaFechaInicio = DateTime.MinValue;
         AV12cTareaFechaFin = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLbltableroidfilter_Jsonclick = "";
         TempTags = "";
         lblLbltareaidfilter_Jsonclick = "";
         lblLbltareanombrefilter_Jsonclick = "";
         lblLblresponsableidfilter_Jsonclick = "";
         lblLbltareafechainiciofilter_Jsonclick = "";
         lblLbltareafechafinfilter_Jsonclick = "";
         lblLbltareaestadofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV19Linkselection_GXI = "";
         A13TareaNombre = "";
         A24TareaFechaInicio = DateTime.MinValue;
         A25TareaFechaFin = DateTime.MinValue;
         scmdbuf = "";
         lV8cTareaNombre = "";
         H00082_A46TareaEstado = new short[1] ;
         H00082_A25TareaFechaFin = new DateTime[] {DateTime.MinValue} ;
         H00082_A24TareaFechaInicio = new DateTime[] {DateTime.MinValue} ;
         H00082_A23ResponsableId = new short[1] ;
         H00082_n23ResponsableId = new bool[] {false} ;
         H00082_A13TareaNombre = new string[] {""} ;
         H00082_A12TareaId = new short[1] ;
         H00082_A9TableroId = new short[1] ;
         H00083_AGRID1_nRecordCount = new long[1] ;
         AV15ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0040__default(),
            new Object[][] {
                new Object[] {
               H00082_A46TareaEstado, H00082_A25TareaFechaFin, H00082_A24TareaFechaInicio, H00082_A23ResponsableId, H00082_n23ResponsableId, H00082_A13TareaNombre, H00082_A12TareaId, H00082_A9TableroId
               }
               , new Object[] {
               H00083_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13pTableroId ;
      private short AV14pTareaId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cTableroId ;
      private short AV7cTareaId ;
      private short AV10cResponsableId ;
      private short AV16cTareaEstado ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A9TableroId ;
      private short A12TareaId ;
      private short A23ResponsableId ;
      private short A46TareaEstado ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int edtavCtableroid_Enabled ;
      private int edtavCtableroid_Visible ;
      private int edtavCtareaid_Enabled ;
      private int edtavCtareaid_Visible ;
      private int edtavCtareanombre_Visible ;
      private int edtavCtareanombre_Enabled ;
      private int edtavCresponsableid_Enabled ;
      private int edtavCresponsableid_Visible ;
      private int edtavCtareafechainicio_Enabled ;
      private int edtavCtareafechafin_Enabled ;
      private int edtavCtareaestado_Enabled ;
      private int edtavCtareaestado_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divTableroidfiltercontainer_Class ;
      private string divTareaidfiltercontainer_Class ;
      private string divTareanombrefiltercontainer_Class ;
      private string divResponsableidfiltercontainer_Class ;
      private string divTareafechainiciofiltercontainer_Class ;
      private string divTareafechafinfiltercontainer_Class ;
      private string divTareaestadofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV8cTareaNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divTableroidfiltercontainer_Internalname ;
      private string lblLbltableroidfilter_Internalname ;
      private string lblLbltableroidfilter_Jsonclick ;
      private string edtavCtableroid_Internalname ;
      private string TempTags ;
      private string edtavCtableroid_Jsonclick ;
      private string divTareaidfiltercontainer_Internalname ;
      private string lblLbltareaidfilter_Internalname ;
      private string lblLbltareaidfilter_Jsonclick ;
      private string edtavCtareaid_Internalname ;
      private string edtavCtareaid_Jsonclick ;
      private string divTareanombrefiltercontainer_Internalname ;
      private string lblLbltareanombrefilter_Internalname ;
      private string lblLbltareanombrefilter_Jsonclick ;
      private string edtavCtareanombre_Internalname ;
      private string edtavCtareanombre_Jsonclick ;
      private string divResponsableidfiltercontainer_Internalname ;
      private string lblLblresponsableidfilter_Internalname ;
      private string lblLblresponsableidfilter_Jsonclick ;
      private string edtavCresponsableid_Internalname ;
      private string edtavCresponsableid_Jsonclick ;
      private string divTareafechainiciofiltercontainer_Internalname ;
      private string lblLbltareafechainiciofilter_Internalname ;
      private string lblLbltareafechainiciofilter_Jsonclick ;
      private string edtavCtareafechainicio_Internalname ;
      private string edtavCtareafechainicio_Jsonclick ;
      private string divTareafechafinfiltercontainer_Internalname ;
      private string lblLbltareafechafinfilter_Internalname ;
      private string lblLbltareafechafinfilter_Jsonclick ;
      private string edtavCtareafechafin_Internalname ;
      private string edtavCtareafechafin_Jsonclick ;
      private string divTareaestadofiltercontainer_Internalname ;
      private string lblLbltareaestadofilter_Internalname ;
      private string lblLbltareaestadofilter_Jsonclick ;
      private string edtavCtareaestado_Internalname ;
      private string edtavCtareaestado_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtTableroId_Internalname ;
      private string edtTareaId_Internalname ;
      private string A13TareaNombre ;
      private string edtTareaNombre_Internalname ;
      private string edtResponsableId_Internalname ;
      private string edtTareaFechaInicio_Internalname ;
      private string edtTareaFechaFin_Internalname ;
      private string edtTareaEstado_Internalname ;
      private string scmdbuf ;
      private string lV8cTareaNombre ;
      private string AV15ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtTableroId_Jsonclick ;
      private string edtTareaId_Jsonclick ;
      private string edtTareaNombre_Link ;
      private string edtTareaNombre_Jsonclick ;
      private string edtResponsableId_Jsonclick ;
      private string edtTareaFechaInicio_Jsonclick ;
      private string edtTareaFechaFin_Jsonclick ;
      private string edtTareaEstado_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV11cTareaFechaInicio ;
      private DateTime AV12cTareaFechaFin ;
      private DateTime A24TareaFechaInicio ;
      private DateTime A25TareaFechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n23ResponsableId ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV19Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00082_A46TareaEstado ;
      private DateTime[] H00082_A25TareaFechaFin ;
      private DateTime[] H00082_A24TareaFechaInicio ;
      private short[] H00082_A23ResponsableId ;
      private bool[] H00082_n23ResponsableId ;
      private string[] H00082_A13TareaNombre ;
      private short[] H00082_A12TareaId ;
      private short[] H00082_A9TableroId ;
      private long[] H00083_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pTableroId ;
      private short aP1_pTareaId ;
      private GXWebForm Form ;
   }

   public class gx0040__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00082( IGxContext context ,
                                             string AV8cTareaNombre ,
                                             short AV10cResponsableId ,
                                             DateTime AV11cTareaFechaInicio ,
                                             DateTime AV12cTareaFechaFin ,
                                             short AV16cTareaEstado ,
                                             string A13TareaNombre ,
                                             short A23ResponsableId ,
                                             DateTime A24TareaFechaInicio ,
                                             DateTime A25TareaFechaFin ,
                                             short A46TareaEstado ,
                                             short AV6cTableroId ,
                                             short AV7cTareaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [TareaEstado], [TareaFechaFin], [TareaFechaInicio], [ResponsableId], [TareaNombre], [TareaId], [TableroId]";
         sFromString = " FROM [Tareas]";
         sOrderString = "";
         AddWhere(sWhereString, "([TableroId] >= @AV6cTableroId and [TareaId] >= @AV7cTareaId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cTareaNombre)) )
         {
            AddWhere(sWhereString, "([TareaNombre] like @lV8cTareaNombre)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV10cResponsableId) )
         {
            AddWhere(sWhereString, "([ResponsableId] >= @AV10cResponsableId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cTareaFechaInicio) )
         {
            AddWhere(sWhereString, "([TareaFechaInicio] >= @AV11cTareaFechaInicio)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cTareaFechaFin) )
         {
            AddWhere(sWhereString, "([TareaFechaFin] >= @AV12cTareaFechaFin)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV16cTareaEstado) )
         {
            AddWhere(sWhereString, "([TareaEstado] >= @AV16cTareaEstado)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [TableroId], [TareaId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00083( IGxContext context ,
                                             string AV8cTareaNombre ,
                                             short AV10cResponsableId ,
                                             DateTime AV11cTareaFechaInicio ,
                                             DateTime AV12cTareaFechaFin ,
                                             short AV16cTareaEstado ,
                                             string A13TareaNombre ,
                                             short A23ResponsableId ,
                                             DateTime A24TareaFechaInicio ,
                                             DateTime A25TareaFechaFin ,
                                             short A46TareaEstado ,
                                             short AV6cTableroId ,
                                             short AV7cTareaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Tareas]";
         AddWhere(sWhereString, "([TableroId] >= @AV6cTableroId and [TareaId] >= @AV7cTareaId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cTareaNombre)) )
         {
            AddWhere(sWhereString, "([TareaNombre] like @lV8cTareaNombre)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV10cResponsableId) )
         {
            AddWhere(sWhereString, "([ResponsableId] >= @AV10cResponsableId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cTareaFechaInicio) )
         {
            AddWhere(sWhereString, "([TareaFechaInicio] >= @AV11cTareaFechaInicio)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cTareaFechaFin) )
         {
            AddWhere(sWhereString, "([TareaFechaFin] >= @AV12cTareaFechaFin)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV16cTareaEstado) )
         {
            AddWhere(sWhereString, "([TareaEstado] >= @AV16cTareaEstado)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00082(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
               case 1 :
                     return conditional_H00083(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH00082;
          prmH00082 = new Object[] {
          new ParDef("@AV6cTableroId",GXType.Int16,4,0) ,
          new ParDef("@AV7cTareaId",GXType.Int16,4,0) ,
          new ParDef("@lV8cTareaNombre",GXType.NChar,20,0) ,
          new ParDef("@AV10cResponsableId",GXType.Int16,4,0) ,
          new ParDef("@AV11cTareaFechaInicio",GXType.Date,8,0) ,
          new ParDef("@AV12cTareaFechaFin",GXType.Date,8,0) ,
          new ParDef("@AV16cTareaEstado",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00083;
          prmH00083 = new Object[] {
          new ParDef("@AV6cTableroId",GXType.Int16,4,0) ,
          new ParDef("@AV7cTareaId",GXType.Int16,4,0) ,
          new ParDef("@lV8cTareaNombre",GXType.NChar,20,0) ,
          new ParDef("@AV10cResponsableId",GXType.Int16,4,0) ,
          new ParDef("@AV11cTareaFechaInicio",GXType.Date,8,0) ,
          new ParDef("@AV12cTareaFechaFin",GXType.Date,8,0) ,
          new ParDef("@AV16cTareaEstado",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00082", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00082,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00083", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00083,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
