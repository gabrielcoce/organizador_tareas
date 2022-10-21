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
   public class gx0090 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0090( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx0090( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pTableroId ,
                           out short aP1_pTareaId ,
                           out short aP2_pActividadId )
      {
         this.AV12pTableroId = 0 ;
         this.AV13pTareaId = 0 ;
         this.AV14pActividadId = 0 ;
         executePrivate();
         aP0_pTableroId=this.AV12pTableroId;
         aP1_pTareaId=this.AV13pTareaId;
         aP2_pActividadId=this.AV14pActividadId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCactividadestado = new GXCheckbox();
         chkActividadEstado = new GXCheckbox();
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
               AV12pTableroId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV12pTableroId", StringUtil.LTrimStr( (decimal)(AV12pTableroId), 4, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pTareaId = (short)(NumberUtil.Val( GetPar( "pTareaId"), "."));
                  AssignAttri("", false, "AV13pTareaId", StringUtil.LTrimStr( (decimal)(AV13pTareaId), 4, 0));
                  AV14pActividadId = (short)(NumberUtil.Val( GetPar( "pActividadId"), "."));
                  AssignAttri("", false, "AV14pActividadId", StringUtil.LTrimStr( (decimal)(AV14pActividadId), 4, 0));
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
         AV8cActividadId = (short)(NumberUtil.Val( GetPar( "cActividadId"), "."));
         AV9cActividadNombre = GetPar( "cActividadNombre");
         AV10cActividadAvance = (short)(NumberUtil.Val( GetPar( "cActividadAvance"), "."));
         AV11cActividadEstado = StringUtil.StrToBool( GetPar( "cActividadEstado"));
         AV16cActividadPaso = (short)(NumberUtil.Val( GetPar( "cActividadPaso"), "."));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cTareaId, AV8cActividadId, AV9cActividadNombre, AV10cActividadAvance, AV11cActividadEstado, AV16cActividadPaso) ;
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
         PA0E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0E2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0090.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pTableroId,4,0)),UrlEncode(StringUtil.LTrimStr(AV13pTareaId,4,0)),UrlEncode(StringUtil.LTrimStr(AV14pActividadId,4,0))}, new string[] {"pTableroId","pTareaId","pActividadId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCACTIVIDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cActividadId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCACTIVIDADNOMBRE", StringUtil.RTrim( AV9cActividadNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCACTIVIDADAVANCE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cActividadAvance), 3, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCACTIVIDADESTADO", StringUtil.BoolToStr( AV11cActividadEstado));
         GxWebStd.gx_hidden_field( context, "GXH_vCACTIVIDADPASO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16cActividadPaso), 4, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPTABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pTableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPTAREAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pTareaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPACTIVIDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pActividadId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "TABLEROIDFILTERCONTAINER_Class", StringUtil.RTrim( divTableroidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TAREAIDFILTERCONTAINER_Class", StringUtil.RTrim( divTareaidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ACTIVIDADIDFILTERCONTAINER_Class", StringUtil.RTrim( divActividadidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ACTIVIDADNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divActividadnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ACTIVIDADAVANCEFILTERCONTAINER_Class", StringUtil.RTrim( divActividadavancefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ACTIVIDADESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divActividadestadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ACTIVIDADPASOFILTERCONTAINER_Class", StringUtil.RTrim( divActividadpasofiltercontainer_Class));
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
            WE0E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0E2( ) ;
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
         return formatLink("gx0090.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pTableroId,4,0)),UrlEncode(StringUtil.LTrimStr(AV13pTareaId,4,0)),UrlEncode(StringUtil.LTrimStr(AV14pActividadId,4,0))}, new string[] {"pTableroId","pTareaId","pActividadId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0090" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Actividades" ;
      }

      protected void WB0E0( )
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
            GxWebStd.gx_label_ctrl( context, lblLbltableroidfilter_Internalname, "Tablero Id", "", "", lblLbltableroidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCtableroid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTableroId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCtableroid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cTableroId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cTableroId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtableroid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtableroid_Visible, edtavCtableroid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLbltareaidfilter_Internalname, "Tarea Id", "", "", lblLbltareaidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCtareaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cTareaId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCtareaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cTareaId), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cTareaId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtareaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtareaid_Visible, edtavCtareaid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divActividadidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divActividadidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblactividadidfilter_Internalname, "Actividad Id", "", "", lblLblactividadidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCactividadid_Internalname, "Actividad Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCactividadid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cActividadId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCactividadid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cActividadId), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cActividadId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCactividadid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCactividadid_Visible, edtavCactividadid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divActividadnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divActividadnombrefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblactividadnombrefilter_Internalname, "Actividad Nombre", "", "", lblLblactividadnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCactividadnombre_Internalname, "Actividad Nombre", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCactividadnombre_Internalname, StringUtil.RTrim( AV9cActividadNombre), StringUtil.RTrim( context.localUtil.Format( AV9cActividadNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCactividadnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCactividadnombre_Visible, edtavCactividadnombre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divActividadavancefiltercontainer_Internalname, 1, 0, "px", 0, "px", divActividadavancefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblactividadavancefilter_Internalname, "Actividad Avance", "", "", lblLblactividadavancefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCactividadavance_Internalname, "Actividad Avance", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCactividadavance_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cActividadAvance), 3, 0, ",", "")), StringUtil.LTrim( ((edtavCactividadavance_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cActividadAvance), "ZZ9") : context.localUtil.Format( (decimal)(AV10cActividadAvance), "ZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCactividadavance_Jsonclick, 0, "Attribute", "", "", "", "", edtavCactividadavance_Visible, edtavCactividadavance_Enabled, 0, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divActividadestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divActividadestadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblactividadestadofilter_Internalname, "Actividad Estado", "", "", lblLblactividadestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCactividadestado_Internalname, "Actividad Estado", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCactividadestado_Internalname, StringUtil.BoolToStr( AV11cActividadEstado), "", "Actividad Estado", chkavCactividadestado.Visible, chkavCactividadestado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(66, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,66);\"");
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
            GxWebStd.gx_div_start( context, divActividadpasofiltercontainer_Internalname, 1, 0, "px", 0, "px", divActividadpasofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblactividadpasofilter_Internalname, "Actividad Paso", "", "", lblLblactividadpasofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCactividadpaso_Internalname, "Actividad Paso", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCactividadpaso_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16cActividadPaso), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCactividadpaso_Enabled!=0) ? context.localUtil.Format( (decimal)(AV16cActividadPaso), "ZZZ9") : context.localUtil.Format( (decimal)(AV16cActividadPaso), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCactividadpaso_Jsonclick, 0, "Attribute", "", "", "", "", edtavCactividadpaso_Visible, edtavCactividadpaso_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180e1_client"+"'", TempTags, "", 2, "HLP_Gx0090.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0090.htm");
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

      protected void START0E2( )
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
            Form.Meta.addItem("description", "Selection List Actividades", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0E0( ) ;
      }

      protected void WS0E2( )
      {
         START0E2( ) ;
         EVT0E2( ) ;
      }

      protected void EVT0E2( )
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
                              A30ActividadId = (short)(context.localUtil.CToN( cgiGet( edtActividadId_Internalname), ",", "."));
                              A31ActividadNombre = cgiGet( edtActividadNombre_Internalname);
                              A32ActividadAvance = (short)(context.localUtil.CToN( cgiGet( edtActividadAvance_Internalname), ",", "."));
                              A33ActividadEstado = StringUtil.StrToBool( cgiGet( chkActividadEstado_Internalname));
                              A49ActividadPaso = (short)(context.localUtil.CToN( cgiGet( edtActividadPaso_Internalname), ",", "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200E2 ();
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
                                       /* Set Refresh If Cactividadid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCACTIVIDADID"), ",", ".") != Convert.ToDecimal( AV8cActividadId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cactividadnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCACTIVIDADNOMBRE"), AV9cActividadNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cactividadavance Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCACTIVIDADAVANCE"), ",", ".") != Convert.ToDecimal( AV10cActividadAvance )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cactividadestado Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCACTIVIDADESTADO")) != AV11cActividadEstado )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cactividadpaso Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCACTIVIDADPASO"), ",", ".") != Convert.ToDecimal( AV16cActividadPaso )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210E2 ();
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

      protected void WE0E2( )
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

      protected void PA0E2( )
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
                                        short AV8cActividadId ,
                                        string AV9cActividadNombre ,
                                        short AV10cActividadAvance ,
                                        bool AV11cActividadEstado ,
                                        short AV16cActividadPaso )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0E2( ) ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_ACTIVIDADID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A30ActividadId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ACTIVIDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30ActividadId), 4, 0, ".", "")));
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
         AV11cActividadEstado = StringUtil.StrToBool( StringUtil.BoolToStr( AV11cActividadEstado));
         AssignAttri("", false, "AV11cActividadEstado", AV11cActividadEstado);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0E2( ) ;
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

      protected void RF0E2( )
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
                                                 AV9cActividadNombre ,
                                                 AV10cActividadAvance ,
                                                 AV11cActividadEstado ,
                                                 AV16cActividadPaso ,
                                                 A31ActividadNombre ,
                                                 A32ActividadAvance ,
                                                 A33ActividadEstado ,
                                                 A49ActividadPaso ,
                                                 AV6cTableroId ,
                                                 AV7cTareaId ,
                                                 AV8cActividadId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV9cActividadNombre = StringUtil.PadR( StringUtil.RTrim( AV9cActividadNombre), 20, "%");
            /* Using cursor H000E2 */
            pr_default.execute(0, new Object[] {AV6cTableroId, AV7cTareaId, AV8cActividadId, lV9cActividadNombre, AV10cActividadAvance, AV11cActividadEstado, AV16cActividadPaso, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A49ActividadPaso = H000E2_A49ActividadPaso[0];
               A33ActividadEstado = H000E2_A33ActividadEstado[0];
               A32ActividadAvance = H000E2_A32ActividadAvance[0];
               A31ActividadNombre = H000E2_A31ActividadNombre[0];
               A30ActividadId = H000E2_A30ActividadId[0];
               A12TareaId = H000E2_A12TareaId[0];
               A9TableroId = H000E2_A9TableroId[0];
               /* Execute user event: Load */
               E200E2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0E0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0E2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TAREAID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_ACTIVIDADID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A30ActividadId), "ZZZ9"), context));
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
                                              AV9cActividadNombre ,
                                              AV10cActividadAvance ,
                                              AV11cActividadEstado ,
                                              AV16cActividadPaso ,
                                              A31ActividadNombre ,
                                              A32ActividadAvance ,
                                              A33ActividadEstado ,
                                              A49ActividadPaso ,
                                              AV6cTableroId ,
                                              AV7cTareaId ,
                                              AV8cActividadId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV9cActividadNombre = StringUtil.PadR( StringUtil.RTrim( AV9cActividadNombre), 20, "%");
         /* Using cursor H000E3 */
         pr_default.execute(1, new Object[] {AV6cTableroId, AV7cTareaId, AV8cActividadId, lV9cActividadNombre, AV10cActividadAvance, AV11cActividadEstado, AV16cActividadPaso});
         GRID1_nRecordCount = H000E3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cTareaId, AV8cActividadId, AV9cActividadNombre, AV10cActividadAvance, AV11cActividadEstado, AV16cActividadPaso) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cTareaId, AV8cActividadId, AV9cActividadNombre, AV10cActividadAvance, AV11cActividadEstado, AV16cActividadPaso) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cTareaId, AV8cActividadId, AV9cActividadNombre, AV10cActividadAvance, AV11cActividadEstado, AV16cActividadPaso) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cTareaId, AV8cActividadId, AV9cActividadNombre, AV10cActividadAvance, AV11cActividadEstado, AV16cActividadPaso) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cTareaId, AV8cActividadId, AV9cActividadNombre, AV10cActividadAvance, AV11cActividadEstado, AV16cActividadPaso) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190E2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCactividadid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCactividadid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCACTIVIDADID");
               GX_FocusControl = edtavCactividadid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cActividadId = 0;
               AssignAttri("", false, "AV8cActividadId", StringUtil.LTrimStr( (decimal)(AV8cActividadId), 4, 0));
            }
            else
            {
               AV8cActividadId = (short)(context.localUtil.CToN( cgiGet( edtavCactividadid_Internalname), ",", "."));
               AssignAttri("", false, "AV8cActividadId", StringUtil.LTrimStr( (decimal)(AV8cActividadId), 4, 0));
            }
            AV9cActividadNombre = cgiGet( edtavCactividadnombre_Internalname);
            AssignAttri("", false, "AV9cActividadNombre", AV9cActividadNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCactividadavance_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCactividadavance_Internalname), ",", ".") > Convert.ToDecimal( 999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCACTIVIDADAVANCE");
               GX_FocusControl = edtavCactividadavance_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cActividadAvance = 0;
               AssignAttri("", false, "AV10cActividadAvance", StringUtil.LTrimStr( (decimal)(AV10cActividadAvance), 3, 0));
            }
            else
            {
               AV10cActividadAvance = (short)(context.localUtil.CToN( cgiGet( edtavCactividadavance_Internalname), ",", "."));
               AssignAttri("", false, "AV10cActividadAvance", StringUtil.LTrimStr( (decimal)(AV10cActividadAvance), 3, 0));
            }
            AV11cActividadEstado = StringUtil.StrToBool( cgiGet( chkavCactividadestado_Internalname));
            AssignAttri("", false, "AV11cActividadEstado", AV11cActividadEstado);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCactividadpaso_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCactividadpaso_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCACTIVIDADPASO");
               GX_FocusControl = edtavCactividadpaso_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16cActividadPaso = 0;
               AssignAttri("", false, "AV16cActividadPaso", StringUtil.LTrimStr( (decimal)(AV16cActividadPaso), 4, 0));
            }
            else
            {
               AV16cActividadPaso = (short)(context.localUtil.CToN( cgiGet( edtavCactividadpaso_Internalname), ",", "."));
               AssignAttri("", false, "AV16cActividadPaso", StringUtil.LTrimStr( (decimal)(AV16cActividadPaso), 4, 0));
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCACTIVIDADID"), ",", ".") != Convert.ToDecimal( AV8cActividadId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCACTIVIDADNOMBRE"), AV9cActividadNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCACTIVIDADAVANCE"), ",", ".") != Convert.ToDecimal( AV10cActividadAvance )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCACTIVIDADESTADO")) != AV11cActividadEstado )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCACTIVIDADPASO"), ",", ".") != Convert.ToDecimal( AV16cActividadPaso )) )
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
         E190E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190E2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Actividades", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV15ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200E2( )
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
         E210E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210E2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pTableroId = A9TableroId;
         AssignAttri("", false, "AV12pTableroId", StringUtil.LTrimStr( (decimal)(AV12pTableroId), 4, 0));
         AV13pTareaId = A12TareaId;
         AssignAttri("", false, "AV13pTareaId", StringUtil.LTrimStr( (decimal)(AV13pTareaId), 4, 0));
         AV14pActividadId = A30ActividadId;
         AssignAttri("", false, "AV14pActividadId", StringUtil.LTrimStr( (decimal)(AV14pActividadId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV12pTableroId,(short)AV13pTareaId,(short)AV14pActividadId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pTableroId","AV13pTareaId","AV14pActividadId"});
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
         AV12pTableroId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV12pTableroId", StringUtil.LTrimStr( (decimal)(AV12pTableroId), 4, 0));
         AV13pTareaId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV13pTareaId", StringUtil.LTrimStr( (decimal)(AV13pTareaId), 4, 0));
         AV14pActividadId = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV14pActividadId", StringUtil.LTrimStr( (decimal)(AV14pActividadId), 4, 0));
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
         PA0E2( ) ;
         WS0E2( ) ;
         WE0E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022101613111499", true, true);
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
         context.AddJavascriptSource("gx0090.js", "?2022101613111499", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtTableroId_Internalname = "TABLEROID_"+sGXsfl_84_idx;
         edtTareaId_Internalname = "TAREAID_"+sGXsfl_84_idx;
         edtActividadId_Internalname = "ACTIVIDADID_"+sGXsfl_84_idx;
         edtActividadNombre_Internalname = "ACTIVIDADNOMBRE_"+sGXsfl_84_idx;
         edtActividadAvance_Internalname = "ACTIVIDADAVANCE_"+sGXsfl_84_idx;
         chkActividadEstado_Internalname = "ACTIVIDADESTADO_"+sGXsfl_84_idx;
         edtActividadPaso_Internalname = "ACTIVIDADPASO_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtTableroId_Internalname = "TABLEROID_"+sGXsfl_84_fel_idx;
         edtTareaId_Internalname = "TAREAID_"+sGXsfl_84_fel_idx;
         edtActividadId_Internalname = "ACTIVIDADID_"+sGXsfl_84_fel_idx;
         edtActividadNombre_Internalname = "ACTIVIDADNOMBRE_"+sGXsfl_84_fel_idx;
         edtActividadAvance_Internalname = "ACTIVIDADAVANCE_"+sGXsfl_84_fel_idx;
         chkActividadEstado_Internalname = "ACTIVIDADESTADO_"+sGXsfl_84_fel_idx;
         edtActividadPaso_Internalname = "ACTIVIDADPASO_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0E0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A30ActividadId), 4, 0, ",", "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTareaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTareaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtActividadId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A30ActividadId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A30ActividadId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtActividadId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtActividadNombre_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A30ActividadId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtActividadNombre_Internalname, "Link", edtActividadNombre_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtActividadNombre_Internalname,StringUtil.RTrim( A31ActividadNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtActividadNombre_Link,(string)"",(string)"",(string)"",(string)edtActividadNombre_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtActividadAvance_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A32ActividadAvance), 3, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A32ActividadAvance), "ZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtActividadAvance_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "ACTIVIDADESTADO_" + sGXsfl_84_idx;
            chkActividadEstado.Name = GXCCtl;
            chkActividadEstado.WebTags = "";
            chkActividadEstado.Caption = "";
            AssignProp("", false, chkActividadEstado_Internalname, "TitleCaption", chkActividadEstado.Caption, !bGXsfl_84_Refreshing);
            chkActividadEstado.CheckedValue = "false";
            A33ActividadEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A33ActividadEstado));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkActividadEstado_Internalname,StringUtil.BoolToStr( A33ActividadEstado),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtActividadPaso_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A49ActividadPaso), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A49ActividadPaso), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtActividadPaso_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0E2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         chkavCactividadestado.Name = "vCACTIVIDADESTADO";
         chkavCactividadestado.WebTags = "";
         chkavCactividadestado.Caption = "";
         AssignProp("", false, chkavCactividadestado_Internalname, "TitleCaption", chkavCactividadestado.Caption, true);
         chkavCactividadestado.CheckedValue = "false";
         AV11cActividadEstado = StringUtil.StrToBool( StringUtil.BoolToStr( AV11cActividadEstado));
         AssignAttri("", false, "AV11cActividadEstado", AV11cActividadEstado);
         GXCCtl = "ACTIVIDADESTADO_" + sGXsfl_84_idx;
         chkActividadEstado.Name = GXCCtl;
         chkActividadEstado.WebTags = "";
         chkActividadEstado.Caption = "";
         AssignProp("", false, chkActividadEstado_Internalname, "TitleCaption", chkActividadEstado.Caption, !bGXsfl_84_Refreshing);
         chkActividadEstado.CheckedValue = "false";
         A33ActividadEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A33ActividadEstado));
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
            context.SendWebValue( "Tarea Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nombre") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Avance") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Estado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Paso") ;
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
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30ActividadId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A31ActividadNombre));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtActividadNombre_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32ActividadAvance), 3, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A33ActividadEstado));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A49ActividadPaso), 4, 0, ".", "")));
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
         lblLblactividadidfilter_Internalname = "LBLACTIVIDADIDFILTER";
         edtavCactividadid_Internalname = "vCACTIVIDADID";
         divActividadidfiltercontainer_Internalname = "ACTIVIDADIDFILTERCONTAINER";
         lblLblactividadnombrefilter_Internalname = "LBLACTIVIDADNOMBREFILTER";
         edtavCactividadnombre_Internalname = "vCACTIVIDADNOMBRE";
         divActividadnombrefiltercontainer_Internalname = "ACTIVIDADNOMBREFILTERCONTAINER";
         lblLblactividadavancefilter_Internalname = "LBLACTIVIDADAVANCEFILTER";
         edtavCactividadavance_Internalname = "vCACTIVIDADAVANCE";
         divActividadavancefiltercontainer_Internalname = "ACTIVIDADAVANCEFILTERCONTAINER";
         lblLblactividadestadofilter_Internalname = "LBLACTIVIDADESTADOFILTER";
         chkavCactividadestado_Internalname = "vCACTIVIDADESTADO";
         divActividadestadofiltercontainer_Internalname = "ACTIVIDADESTADOFILTERCONTAINER";
         lblLblactividadpasofilter_Internalname = "LBLACTIVIDADPASOFILTER";
         edtavCactividadpaso_Internalname = "vCACTIVIDADPASO";
         divActividadpasofiltercontainer_Internalname = "ACTIVIDADPASOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtTableroId_Internalname = "TABLEROID";
         edtTareaId_Internalname = "TAREAID";
         edtActividadId_Internalname = "ACTIVIDADID";
         edtActividadNombre_Internalname = "ACTIVIDADNOMBRE";
         edtActividadAvance_Internalname = "ACTIVIDADAVANCE";
         chkActividadEstado_Internalname = "ACTIVIDADESTADO";
         edtActividadPaso_Internalname = "ACTIVIDADPASO";
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
         chkavCactividadestado.Caption = "Actividad Estado";
         edtActividadPaso_Jsonclick = "";
         chkActividadEstado.Caption = "";
         edtActividadAvance_Jsonclick = "";
         edtActividadNombre_Jsonclick = "";
         edtActividadNombre_Link = "";
         edtActividadId_Jsonclick = "";
         edtTareaId_Jsonclick = "";
         edtTableroId_Jsonclick = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCactividadpaso_Jsonclick = "";
         edtavCactividadpaso_Enabled = 1;
         edtavCactividadpaso_Visible = 1;
         chkavCactividadestado.Enabled = 1;
         chkavCactividadestado.Visible = 1;
         edtavCactividadavance_Jsonclick = "";
         edtavCactividadavance_Enabled = 1;
         edtavCactividadavance_Visible = 1;
         edtavCactividadnombre_Jsonclick = "";
         edtavCactividadnombre_Enabled = 1;
         edtavCactividadnombre_Visible = 1;
         edtavCactividadid_Jsonclick = "";
         edtavCactividadid_Enabled = 1;
         edtavCactividadid_Visible = 1;
         edtavCtareaid_Jsonclick = "";
         edtavCtareaid_Enabled = 1;
         edtavCtareaid_Visible = 1;
         edtavCtableroid_Jsonclick = "";
         edtavCtableroid_Enabled = 1;
         edtavCtableroid_Visible = 1;
         divActividadpasofiltercontainer_Class = "AdvancedContainerItem";
         divActividadestadofiltercontainer_Class = "AdvancedContainerItem";
         divActividadavancefiltercontainer_Class = "AdvancedContainerItem";
         divActividadnombrefiltercontainer_Class = "AdvancedContainerItem";
         divActividadidfiltercontainer_Class = "AdvancedContainerItem";
         divTareaidfiltercontainer_Class = "AdvancedContainerItem";
         divTableroidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Actividades";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cTareaId',fld:'vCTAREAID',pic:'ZZZ9'},{av:'AV8cActividadId',fld:'vCACTIVIDADID',pic:'ZZZ9'},{av:'AV9cActividadNombre',fld:'vCACTIVIDADNOMBRE',pic:''},{av:'AV10cActividadAvance',fld:'vCACTIVIDADAVANCE',pic:'ZZ9'},{av:'AV16cActividadPaso',fld:'vCACTIVIDADPASO',pic:'ZZZ9'},{av:'AV11cActividadEstado',fld:'vCACTIVIDADESTADO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E180E1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLTABLEROIDFILTER.CLICK","{handler:'E110E1',iparms:[{av:'divTableroidfiltercontainer_Class',ctrl:'TABLEROIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTABLEROIDFILTER.CLICK",",oparms:[{av:'divTableroidfiltercontainer_Class',ctrl:'TABLEROIDFILTERCONTAINER',prop:'Class'},{av:'edtavCtableroid_Visible',ctrl:'vCTABLEROID',prop:'Visible'}]}");
         setEventMetadata("LBLTAREAIDFILTER.CLICK","{handler:'E120E1',iparms:[{av:'divTareaidfiltercontainer_Class',ctrl:'TAREAIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTAREAIDFILTER.CLICK",",oparms:[{av:'divTareaidfiltercontainer_Class',ctrl:'TAREAIDFILTERCONTAINER',prop:'Class'},{av:'edtavCtareaid_Visible',ctrl:'vCTAREAID',prop:'Visible'}]}");
         setEventMetadata("LBLACTIVIDADIDFILTER.CLICK","{handler:'E130E1',iparms:[{av:'divActividadidfiltercontainer_Class',ctrl:'ACTIVIDADIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLACTIVIDADIDFILTER.CLICK",",oparms:[{av:'divActividadidfiltercontainer_Class',ctrl:'ACTIVIDADIDFILTERCONTAINER',prop:'Class'},{av:'edtavCactividadid_Visible',ctrl:'vCACTIVIDADID',prop:'Visible'}]}");
         setEventMetadata("LBLACTIVIDADNOMBREFILTER.CLICK","{handler:'E140E1',iparms:[{av:'divActividadnombrefiltercontainer_Class',ctrl:'ACTIVIDADNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLACTIVIDADNOMBREFILTER.CLICK",",oparms:[{av:'divActividadnombrefiltercontainer_Class',ctrl:'ACTIVIDADNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCactividadnombre_Visible',ctrl:'vCACTIVIDADNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLACTIVIDADAVANCEFILTER.CLICK","{handler:'E150E1',iparms:[{av:'divActividadavancefiltercontainer_Class',ctrl:'ACTIVIDADAVANCEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLACTIVIDADAVANCEFILTER.CLICK",",oparms:[{av:'divActividadavancefiltercontainer_Class',ctrl:'ACTIVIDADAVANCEFILTERCONTAINER',prop:'Class'},{av:'edtavCactividadavance_Visible',ctrl:'vCACTIVIDADAVANCE',prop:'Visible'}]}");
         setEventMetadata("LBLACTIVIDADESTADOFILTER.CLICK","{handler:'E160E1',iparms:[{av:'divActividadestadofiltercontainer_Class',ctrl:'ACTIVIDADESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLACTIVIDADESTADOFILTER.CLICK",",oparms:[{av:'divActividadestadofiltercontainer_Class',ctrl:'ACTIVIDADESTADOFILTERCONTAINER',prop:'Class'},{av:'chkavCactividadestado.Visible',ctrl:'vCACTIVIDADESTADO',prop:'Visible'}]}");
         setEventMetadata("LBLACTIVIDADPASOFILTER.CLICK","{handler:'E170E1',iparms:[{av:'divActividadpasofiltercontainer_Class',ctrl:'ACTIVIDADPASOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLACTIVIDADPASOFILTER.CLICK",",oparms:[{av:'divActividadpasofiltercontainer_Class',ctrl:'ACTIVIDADPASOFILTERCONTAINER',prop:'Class'},{av:'edtavCactividadpaso_Visible',ctrl:'vCACTIVIDADPASO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E210E2',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9',hsh:true},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'A30ActividadId',fld:'ACTIVIDADID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pTableroId',fld:'vPTABLEROID',pic:'ZZZ9'},{av:'AV13pTareaId',fld:'vPTAREAID',pic:'ZZZ9'},{av:'AV14pActividadId',fld:'vPACTIVIDADID',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cTareaId',fld:'vCTAREAID',pic:'ZZZ9'},{av:'AV8cActividadId',fld:'vCACTIVIDADID',pic:'ZZZ9'},{av:'AV9cActividadNombre',fld:'vCACTIVIDADNOMBRE',pic:''},{av:'AV10cActividadAvance',fld:'vCACTIVIDADAVANCE',pic:'ZZ9'},{av:'AV16cActividadPaso',fld:'vCACTIVIDADPASO',pic:'ZZZ9'},{av:'AV11cActividadEstado',fld:'vCACTIVIDADESTADO',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cTareaId',fld:'vCTAREAID',pic:'ZZZ9'},{av:'AV8cActividadId',fld:'vCACTIVIDADID',pic:'ZZZ9'},{av:'AV9cActividadNombre',fld:'vCACTIVIDADNOMBRE',pic:''},{av:'AV10cActividadAvance',fld:'vCACTIVIDADAVANCE',pic:'ZZ9'},{av:'AV16cActividadPaso',fld:'vCACTIVIDADPASO',pic:'ZZZ9'},{av:'AV11cActividadEstado',fld:'vCACTIVIDADESTADO',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cTareaId',fld:'vCTAREAID',pic:'ZZZ9'},{av:'AV8cActividadId',fld:'vCACTIVIDADID',pic:'ZZZ9'},{av:'AV9cActividadNombre',fld:'vCACTIVIDADNOMBRE',pic:''},{av:'AV10cActividadAvance',fld:'vCACTIVIDADAVANCE',pic:'ZZ9'},{av:'AV16cActividadPaso',fld:'vCACTIVIDADPASO',pic:'ZZZ9'},{av:'AV11cActividadEstado',fld:'vCACTIVIDADESTADO',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cTareaId',fld:'vCTAREAID',pic:'ZZZ9'},{av:'AV8cActividadId',fld:'vCACTIVIDADID',pic:'ZZZ9'},{av:'AV9cActividadNombre',fld:'vCACTIVIDADNOMBRE',pic:''},{av:'AV10cActividadAvance',fld:'vCACTIVIDADAVANCE',pic:'ZZ9'},{av:'AV16cActividadPaso',fld:'vCACTIVIDADPASO',pic:'ZZZ9'},{av:'AV11cActividadEstado',fld:'vCACTIVIDADESTADO',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Actividadpaso',iparms:[]");
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
         AV9cActividadNombre = "";
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
         lblLblactividadidfilter_Jsonclick = "";
         lblLblactividadnombrefilter_Jsonclick = "";
         lblLblactividadavancefilter_Jsonclick = "";
         lblLblactividadestadofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLblactividadpasofilter_Jsonclick = "";
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
         A31ActividadNombre = "";
         scmdbuf = "";
         lV9cActividadNombre = "";
         H000E2_A49ActividadPaso = new short[1] ;
         H000E2_A33ActividadEstado = new bool[] {false} ;
         H000E2_A32ActividadAvance = new short[1] ;
         H000E2_A31ActividadNombre = new string[] {""} ;
         H000E2_A30ActividadId = new short[1] ;
         H000E2_A12TareaId = new short[1] ;
         H000E2_A9TableroId = new short[1] ;
         H000E3_AGRID1_nRecordCount = new long[1] ;
         AV15ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0090__default(),
            new Object[][] {
                new Object[] {
               H000E2_A49ActividadPaso, H000E2_A33ActividadEstado, H000E2_A32ActividadAvance, H000E2_A31ActividadNombre, H000E2_A30ActividadId, H000E2_A12TareaId, H000E2_A9TableroId
               }
               , new Object[] {
               H000E3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12pTableroId ;
      private short AV13pTareaId ;
      private short AV14pActividadId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cTableroId ;
      private short AV7cTareaId ;
      private short AV8cActividadId ;
      private short AV10cActividadAvance ;
      private short AV16cActividadPaso ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A9TableroId ;
      private short A12TareaId ;
      private short A30ActividadId ;
      private short A32ActividadAvance ;
      private short A49ActividadPaso ;
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
      private int edtavCactividadid_Enabled ;
      private int edtavCactividadid_Visible ;
      private int edtavCactividadnombre_Visible ;
      private int edtavCactividadnombre_Enabled ;
      private int edtavCactividadavance_Enabled ;
      private int edtavCactividadavance_Visible ;
      private int edtavCactividadpaso_Enabled ;
      private int edtavCactividadpaso_Visible ;
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
      private string divActividadidfiltercontainer_Class ;
      private string divActividadnombrefiltercontainer_Class ;
      private string divActividadavancefiltercontainer_Class ;
      private string divActividadestadofiltercontainer_Class ;
      private string divActividadpasofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV9cActividadNombre ;
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
      private string divActividadidfiltercontainer_Internalname ;
      private string lblLblactividadidfilter_Internalname ;
      private string lblLblactividadidfilter_Jsonclick ;
      private string edtavCactividadid_Internalname ;
      private string edtavCactividadid_Jsonclick ;
      private string divActividadnombrefiltercontainer_Internalname ;
      private string lblLblactividadnombrefilter_Internalname ;
      private string lblLblactividadnombrefilter_Jsonclick ;
      private string edtavCactividadnombre_Internalname ;
      private string edtavCactividadnombre_Jsonclick ;
      private string divActividadavancefiltercontainer_Internalname ;
      private string lblLblactividadavancefilter_Internalname ;
      private string lblLblactividadavancefilter_Jsonclick ;
      private string edtavCactividadavance_Internalname ;
      private string edtavCactividadavance_Jsonclick ;
      private string divActividadestadofiltercontainer_Internalname ;
      private string lblLblactividadestadofilter_Internalname ;
      private string lblLblactividadestadofilter_Jsonclick ;
      private string chkavCactividadestado_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divActividadpasofiltercontainer_Internalname ;
      private string lblLblactividadpasofilter_Internalname ;
      private string lblLblactividadpasofilter_Jsonclick ;
      private string edtavCactividadpaso_Internalname ;
      private string edtavCactividadpaso_Jsonclick ;
      private string divGridtable_Internalname ;
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
      private string edtActividadId_Internalname ;
      private string A31ActividadNombre ;
      private string edtActividadNombre_Internalname ;
      private string edtActividadAvance_Internalname ;
      private string chkActividadEstado_Internalname ;
      private string edtActividadPaso_Internalname ;
      private string scmdbuf ;
      private string lV9cActividadNombre ;
      private string AV15ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtTableroId_Jsonclick ;
      private string edtTareaId_Jsonclick ;
      private string edtActividadId_Jsonclick ;
      private string edtActividadNombre_Link ;
      private string edtActividadNombre_Jsonclick ;
      private string edtActividadAvance_Jsonclick ;
      private string GXCCtl ;
      private string edtActividadPaso_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11cActividadEstado ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool A33ActividadEstado ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV19Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCactividadestado ;
      private GXCheckbox chkActividadEstado ;
      private IDataStoreProvider pr_default ;
      private short[] H000E2_A49ActividadPaso ;
      private bool[] H000E2_A33ActividadEstado ;
      private short[] H000E2_A32ActividadAvance ;
      private string[] H000E2_A31ActividadNombre ;
      private short[] H000E2_A30ActividadId ;
      private short[] H000E2_A12TareaId ;
      private short[] H000E2_A9TableroId ;
      private long[] H000E3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pTableroId ;
      private short aP1_pTareaId ;
      private short aP2_pActividadId ;
      private GXWebForm Form ;
   }

   public class gx0090__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000E2( IGxContext context ,
                                             string AV9cActividadNombre ,
                                             short AV10cActividadAvance ,
                                             bool AV11cActividadEstado ,
                                             short AV16cActividadPaso ,
                                             string A31ActividadNombre ,
                                             short A32ActividadAvance ,
                                             bool A33ActividadEstado ,
                                             short A49ActividadPaso ,
                                             short AV6cTableroId ,
                                             short AV7cTareaId ,
                                             short AV8cActividadId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ActividadPaso], [ActividadEstado], [ActividadAvance], [ActividadNombre], [ActividadId], [TareaId], [TableroId]";
         sFromString = " FROM [Actividades]";
         sOrderString = "";
         AddWhere(sWhereString, "([TableroId] >= @AV6cTableroId and [TareaId] >= @AV7cTareaId and [ActividadId] >= @AV8cActividadId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cActividadNombre)) )
         {
            AddWhere(sWhereString, "([ActividadNombre] like @lV9cActividadNombre)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cActividadAvance) )
         {
            AddWhere(sWhereString, "([ActividadAvance] >= @AV10cActividadAvance)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (false==AV11cActividadEstado) )
         {
            AddWhere(sWhereString, "([ActividadEstado] >= @AV11cActividadEstado)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV16cActividadPaso) )
         {
            AddWhere(sWhereString, "([ActividadPaso] >= @AV16cActividadPaso)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [TableroId], [TareaId], [ActividadId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000E3( IGxContext context ,
                                             string AV9cActividadNombre ,
                                             short AV10cActividadAvance ,
                                             bool AV11cActividadEstado ,
                                             short AV16cActividadPaso ,
                                             string A31ActividadNombre ,
                                             short A32ActividadAvance ,
                                             bool A33ActividadEstado ,
                                             short A49ActividadPaso ,
                                             short AV6cTableroId ,
                                             short AV7cTareaId ,
                                             short AV8cActividadId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Actividades]";
         AddWhere(sWhereString, "([TableroId] >= @AV6cTableroId and [TareaId] >= @AV7cTareaId and [ActividadId] >= @AV8cActividadId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cActividadNombre)) )
         {
            AddWhere(sWhereString, "([ActividadNombre] like @lV9cActividadNombre)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cActividadAvance) )
         {
            AddWhere(sWhereString, "([ActividadAvance] >= @AV10cActividadAvance)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (false==AV11cActividadEstado) )
         {
            AddWhere(sWhereString, "([ActividadEstado] >= @AV11cActividadEstado)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV16cActividadPaso) )
         {
            AddWhere(sWhereString, "([ActividadPaso] >= @AV16cActividadPaso)");
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
                     return conditional_H000E2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H000E3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmH000E2;
          prmH000E2 = new Object[] {
          new ParDef("@AV6cTableroId",GXType.Int16,4,0) ,
          new ParDef("@AV7cTareaId",GXType.Int16,4,0) ,
          new ParDef("@AV8cActividadId",GXType.Int16,4,0) ,
          new ParDef("@lV9cActividadNombre",GXType.NChar,20,0) ,
          new ParDef("@AV10cActividadAvance",GXType.Int16,3,0) ,
          new ParDef("@AV11cActividadEstado",GXType.Boolean,1,0) ,
          new ParDef("@AV16cActividadPaso",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000E3;
          prmH000E3 = new Object[] {
          new ParDef("@AV6cTableroId",GXType.Int16,4,0) ,
          new ParDef("@AV7cTareaId",GXType.Int16,4,0) ,
          new ParDef("@AV8cActividadId",GXType.Int16,4,0) ,
          new ParDef("@lV9cActividadNombre",GXType.NChar,20,0) ,
          new ParDef("@AV10cActividadAvance",GXType.Int16,3,0) ,
          new ParDef("@AV11cActividadEstado",GXType.Boolean,1,0) ,
          new ParDef("@AV16cActividadPaso",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000E2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000E3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
