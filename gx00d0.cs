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
   public class gx00d0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00d0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx00d0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pCorreoId )
      {
         this.AV13pCorreoId = 0 ;
         executePrivate();
         aP0_pCorreoId=this.AV13pCorreoId;
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
            gxfirstwebparm = GetFirstPar( "pCorreoId");
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
               gxfirstwebparm = GetFirstPar( "pCorreoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pCorreoId");
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
               AV13pCorreoId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pCorreoId", StringUtil.LTrimStr( (decimal)(AV13pCorreoId), 4, 0));
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
         AV6cCorreoId = (short)(NumberUtil.Val( GetPar( "cCorreoId"), "."));
         AV7cCorreoIdentificador = GetPar( "cCorreoIdentificador");
         AV8cCorreoNombre = GetPar( "cCorreoNombre");
         AV9cCorreoServidor = GetPar( "cCorreoServidor");
         AV10cCorreoPuerto = (short)(NumberUtil.Val( GetPar( "cCorreoPuerto"), "."));
         AV11cCorreoUsuario = GetPar( "cCorreoUsuario");
         AV12cCorreoContrasena = GetPar( "cCorreoContrasena");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCorreoId, AV7cCorreoIdentificador, AV8cCorreoNombre, AV9cCorreoServidor, AV10cCorreoPuerto, AV11cCorreoUsuario, AV12cCorreoContrasena) ;
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
         PA172( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START172( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00d0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pCorreoId,4,0))}, new string[] {"pCorreoId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCORREOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCorreoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCORREOIDENTIFICADOR", StringUtil.RTrim( AV7cCorreoIdentificador));
         GxWebStd.gx_hidden_field( context, "GXH_vCCORREONOMBRE", StringUtil.RTrim( AV8cCorreoNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCCORREOSERVIDOR", StringUtil.RTrim( AV9cCorreoServidor));
         GxWebStd.gx_hidden_field( context, "GXH_vCCORREOPUERTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cCorreoPuerto), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCORREOUSUARIO", AV11cCorreoUsuario);
         GxWebStd.gx_hidden_field( context, "GXH_vCCORREOCONTRASENA", StringUtil.RTrim( AV12cCorreoContrasena));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCORREOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pCorreoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CORREOIDFILTERCONTAINER_Class", StringUtil.RTrim( divCorreoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CORREOIDENTIFICADORFILTERCONTAINER_Class", StringUtil.RTrim( divCorreoidentificadorfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CORREONOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divCorreonombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CORREOSERVIDORFILTERCONTAINER_Class", StringUtil.RTrim( divCorreoservidorfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CORREOPUERTOFILTERCONTAINER_Class", StringUtil.RTrim( divCorreopuertofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CORREOUSUARIOFILTERCONTAINER_Class", StringUtil.RTrim( divCorreousuariofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CORREOCONTRASENAFILTERCONTAINER_Class", StringUtil.RTrim( divCorreocontrasenafiltercontainer_Class));
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
            WE172( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT172( ) ;
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
         return formatLink("gx00d0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pCorreoId,4,0))}, new string[] {"pCorreoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00D0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Correo" ;
      }

      protected void WB170( )
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
            GxWebStd.gx_div_start( context, divCorreoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCorreoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcorreoidfilter_Internalname, "Correo Id", "", "", lblLblcorreoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11171_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcorreoid_Internalname, "Correo Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcorreoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCorreoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcorreoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cCorreoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cCorreoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcorreoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcorreoid_Visible, edtavCcorreoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_div_start( context, divCorreoidentificadorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCorreoidentificadorfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcorreoidentificadorfilter_Internalname, "Correo Identificador", "", "", lblLblcorreoidentificadorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12171_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcorreoidentificador_Internalname, "Correo Identificador", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcorreoidentificador_Internalname, StringUtil.RTrim( AV7cCorreoIdentificador), StringUtil.RTrim( context.localUtil.Format( AV7cCorreoIdentificador, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcorreoidentificador_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcorreoidentificador_Visible, edtavCcorreoidentificador_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_div_start( context, divCorreonombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCorreonombrefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcorreonombrefilter_Internalname, "Correo Nombre", "", "", lblLblcorreonombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13171_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcorreonombre_Internalname, "Correo Nombre", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcorreonombre_Internalname, StringUtil.RTrim( AV8cCorreoNombre), StringUtil.RTrim( context.localUtil.Format( AV8cCorreoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcorreonombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcorreonombre_Visible, edtavCcorreonombre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_div_start( context, divCorreoservidorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCorreoservidorfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcorreoservidorfilter_Internalname, "Correo Servidor", "", "", lblLblcorreoservidorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14171_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcorreoservidor_Internalname, "Correo Servidor", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcorreoservidor_Internalname, StringUtil.RTrim( AV9cCorreoServidor), StringUtil.RTrim( context.localUtil.Format( AV9cCorreoServidor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcorreoservidor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcorreoservidor_Visible, edtavCcorreoservidor_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_div_start( context, divCorreopuertofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCorreopuertofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcorreopuertofilter_Internalname, "Correo Puerto", "", "", lblLblcorreopuertofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15171_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcorreopuerto_Internalname, "Correo Puerto", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcorreopuerto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cCorreoPuerto), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcorreopuerto_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cCorreoPuerto), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cCorreoPuerto), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcorreopuerto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcorreopuerto_Visible, edtavCcorreopuerto_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_div_start( context, divCorreousuariofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCorreousuariofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcorreousuariofilter_Internalname, "Correo Usuario", "", "", lblLblcorreousuariofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16171_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcorreousuario_Internalname, "Correo Usuario", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcorreousuario_Internalname, AV11cCorreoUsuario, StringUtil.RTrim( context.localUtil.Format( AV11cCorreoUsuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcorreousuario_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcorreousuario_Visible, edtavCcorreousuario_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_div_start( context, divCorreocontrasenafiltercontainer_Internalname, 1, 0, "px", 0, "px", divCorreocontrasenafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcorreocontrasenafilter_Internalname, "Correo Contrasena", "", "", lblLblcorreocontrasenafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17171_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcorreocontrasena_Internalname, "Correo Contrasena", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcorreocontrasena_Internalname, StringUtil.RTrim( AV12cCorreoContrasena), StringUtil.RTrim( context.localUtil.Format( AV12cCorreoContrasena, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcorreocontrasena_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcorreocontrasena_Visible, edtavCcorreocontrasena_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18171_client"+"'", TempTags, "", 2, "HLP_Gx00D0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00D0.htm");
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

      protected void START172( )
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
            Form.Meta.addItem("description", "Selection List Correo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP170( ) ;
      }

      protected void WS172( )
      {
         START172( ) ;
         EVT172( ) ;
      }

      protected void EVT172( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A50CorreoId = (short)(context.localUtil.CToN( cgiGet( edtCorreoId_Internalname), ",", "."));
                              A51CorreoIdentificador = cgiGet( edtCorreoIdentificador_Internalname);
                              A52CorreoNombre = cgiGet( edtCorreoNombre_Internalname);
                              A53CorreoServidor = cgiGet( edtCorreoServidor_Internalname);
                              A54CorreoPuerto = (short)(context.localUtil.CToN( cgiGet( edtCorreoPuerto_Internalname), ",", "."));
                              A56CorreoContrasena = cgiGet( edtCorreoContrasena_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19172 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20172 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccorreoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCORREOID"), ",", ".") != Convert.ToDecimal( AV6cCorreoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccorreoidentificador Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCORREOIDENTIFICADOR"), AV7cCorreoIdentificador) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccorreonombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCORREONOMBRE"), AV8cCorreoNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccorreoservidor Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCORREOSERVIDOR"), AV9cCorreoServidor) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccorreopuerto Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCORREOPUERTO"), ",", ".") != Convert.ToDecimal( AV10cCorreoPuerto )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccorreousuario Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCORREOUSUARIO"), AV11cCorreoUsuario) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccorreocontrasena Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCORREOCONTRASENA"), AV12cCorreoContrasena) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21172 ();
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

      protected void WE172( )
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

      protected void PA172( )
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
                                        short AV6cCorreoId ,
                                        string AV7cCorreoIdentificador ,
                                        string AV8cCorreoNombre ,
                                        string AV9cCorreoServidor ,
                                        short AV10cCorreoPuerto ,
                                        string AV11cCorreoUsuario ,
                                        string AV12cCorreoContrasena )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF172( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CORREOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A50CorreoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CORREOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50CorreoId), 4, 0, ".", "")));
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
         RF172( ) ;
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

      protected void RF172( )
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
                                                 AV7cCorreoIdentificador ,
                                                 AV8cCorreoNombre ,
                                                 AV9cCorreoServidor ,
                                                 AV10cCorreoPuerto ,
                                                 AV11cCorreoUsuario ,
                                                 AV12cCorreoContrasena ,
                                                 A51CorreoIdentificador ,
                                                 A52CorreoNombre ,
                                                 A53CorreoServidor ,
                                                 A54CorreoPuerto ,
                                                 A55CorreoUsuario ,
                                                 A56CorreoContrasena ,
                                                 AV6cCorreoId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cCorreoIdentificador = StringUtil.PadR( StringUtil.RTrim( AV7cCorreoIdentificador), 20, "%");
            lV8cCorreoNombre = StringUtil.PadR( StringUtil.RTrim( AV8cCorreoNombre), 20, "%");
            lV9cCorreoServidor = StringUtil.PadR( StringUtil.RTrim( AV9cCorreoServidor), 22, "%");
            lV11cCorreoUsuario = StringUtil.Concat( StringUtil.RTrim( AV11cCorreoUsuario), "%", "");
            lV12cCorreoContrasena = StringUtil.PadR( StringUtil.RTrim( AV12cCorreoContrasena), 20, "%");
            /* Using cursor H00172 */
            pr_default.execute(0, new Object[] {AV6cCorreoId, lV7cCorreoIdentificador, lV8cCorreoNombre, lV9cCorreoServidor, AV10cCorreoPuerto, lV11cCorreoUsuario, lV12cCorreoContrasena, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A55CorreoUsuario = H00172_A55CorreoUsuario[0];
               A56CorreoContrasena = H00172_A56CorreoContrasena[0];
               A54CorreoPuerto = H00172_A54CorreoPuerto[0];
               A53CorreoServidor = H00172_A53CorreoServidor[0];
               A52CorreoNombre = H00172_A52CorreoNombre[0];
               A51CorreoIdentificador = H00172_A51CorreoIdentificador[0];
               A50CorreoId = H00172_A50CorreoId[0];
               /* Execute user event: Load */
               E20172 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB170( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes172( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CORREOID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A50CorreoId), "ZZZ9"), context));
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
                                              AV7cCorreoIdentificador ,
                                              AV8cCorreoNombre ,
                                              AV9cCorreoServidor ,
                                              AV10cCorreoPuerto ,
                                              AV11cCorreoUsuario ,
                                              AV12cCorreoContrasena ,
                                              A51CorreoIdentificador ,
                                              A52CorreoNombre ,
                                              A53CorreoServidor ,
                                              A54CorreoPuerto ,
                                              A55CorreoUsuario ,
                                              A56CorreoContrasena ,
                                              AV6cCorreoId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cCorreoIdentificador = StringUtil.PadR( StringUtil.RTrim( AV7cCorreoIdentificador), 20, "%");
         lV8cCorreoNombre = StringUtil.PadR( StringUtil.RTrim( AV8cCorreoNombre), 20, "%");
         lV9cCorreoServidor = StringUtil.PadR( StringUtil.RTrim( AV9cCorreoServidor), 22, "%");
         lV11cCorreoUsuario = StringUtil.Concat( StringUtil.RTrim( AV11cCorreoUsuario), "%", "");
         lV12cCorreoContrasena = StringUtil.PadR( StringUtil.RTrim( AV12cCorreoContrasena), 20, "%");
         /* Using cursor H00173 */
         pr_default.execute(1, new Object[] {AV6cCorreoId, lV7cCorreoIdentificador, lV8cCorreoNombre, lV9cCorreoServidor, AV10cCorreoPuerto, lV11cCorreoUsuario, lV12cCorreoContrasena});
         GRID1_nRecordCount = H00173_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCorreoId, AV7cCorreoIdentificador, AV8cCorreoNombre, AV9cCorreoServidor, AV10cCorreoPuerto, AV11cCorreoUsuario, AV12cCorreoContrasena) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCorreoId, AV7cCorreoIdentificador, AV8cCorreoNombre, AV9cCorreoServidor, AV10cCorreoPuerto, AV11cCorreoUsuario, AV12cCorreoContrasena) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCorreoId, AV7cCorreoIdentificador, AV8cCorreoNombre, AV9cCorreoServidor, AV10cCorreoPuerto, AV11cCorreoUsuario, AV12cCorreoContrasena) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCorreoId, AV7cCorreoIdentificador, AV8cCorreoNombre, AV9cCorreoServidor, AV10cCorreoPuerto, AV11cCorreoUsuario, AV12cCorreoContrasena) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCorreoId, AV7cCorreoIdentificador, AV8cCorreoNombre, AV9cCorreoServidor, AV10cCorreoPuerto, AV11cCorreoUsuario, AV12cCorreoContrasena) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP170( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19172 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcorreoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcorreoid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCORREOID");
               GX_FocusControl = edtavCcorreoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCorreoId = 0;
               AssignAttri("", false, "AV6cCorreoId", StringUtil.LTrimStr( (decimal)(AV6cCorreoId), 4, 0));
            }
            else
            {
               AV6cCorreoId = (short)(context.localUtil.CToN( cgiGet( edtavCcorreoid_Internalname), ",", "."));
               AssignAttri("", false, "AV6cCorreoId", StringUtil.LTrimStr( (decimal)(AV6cCorreoId), 4, 0));
            }
            AV7cCorreoIdentificador = cgiGet( edtavCcorreoidentificador_Internalname);
            AssignAttri("", false, "AV7cCorreoIdentificador", AV7cCorreoIdentificador);
            AV8cCorreoNombre = cgiGet( edtavCcorreonombre_Internalname);
            AssignAttri("", false, "AV8cCorreoNombre", AV8cCorreoNombre);
            AV9cCorreoServidor = cgiGet( edtavCcorreoservidor_Internalname);
            AssignAttri("", false, "AV9cCorreoServidor", AV9cCorreoServidor);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcorreopuerto_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcorreopuerto_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCORREOPUERTO");
               GX_FocusControl = edtavCcorreopuerto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cCorreoPuerto = 0;
               AssignAttri("", false, "AV10cCorreoPuerto", StringUtil.LTrimStr( (decimal)(AV10cCorreoPuerto), 4, 0));
            }
            else
            {
               AV10cCorreoPuerto = (short)(context.localUtil.CToN( cgiGet( edtavCcorreopuerto_Internalname), ",", "."));
               AssignAttri("", false, "AV10cCorreoPuerto", StringUtil.LTrimStr( (decimal)(AV10cCorreoPuerto), 4, 0));
            }
            AV11cCorreoUsuario = cgiGet( edtavCcorreousuario_Internalname);
            AssignAttri("", false, "AV11cCorreoUsuario", AV11cCorreoUsuario);
            AV12cCorreoContrasena = cgiGet( edtavCcorreocontrasena_Internalname);
            AssignAttri("", false, "AV12cCorreoContrasena", AV12cCorreoContrasena);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCORREOID"), ",", ".") != Convert.ToDecimal( AV6cCorreoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCORREOIDENTIFICADOR"), AV7cCorreoIdentificador) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCORREONOMBRE"), AV8cCorreoNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCORREOSERVIDOR"), AV9cCorreoServidor) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCORREOPUERTO"), ",", ".") != Convert.ToDecimal( AV10cCorreoPuerto )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCORREOUSUARIO"), AV11cCorreoUsuario) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCORREOCONTRASENA"), AV12cCorreoContrasena) != 0 )
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
         E19172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19172( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selecci�n %1", "Correo", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20172( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
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
         E21172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21172( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pCorreoId = A50CorreoId;
         AssignAttri("", false, "AV13pCorreoId", StringUtil.LTrimStr( (decimal)(AV13pCorreoId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pCorreoId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pCorreoId"});
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
         AV13pCorreoId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV13pCorreoId", StringUtil.LTrimStr( (decimal)(AV13pCorreoId), 4, 0));
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
         PA172( ) ;
         WS172( ) ;
         WE172( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202210201740078", true, true);
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
         context.AddJavascriptSource("gx00d0.js", "?202210201740078", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtCorreoId_Internalname = "CORREOID_"+sGXsfl_84_idx;
         edtCorreoIdentificador_Internalname = "CORREOIDENTIFICADOR_"+sGXsfl_84_idx;
         edtCorreoNombre_Internalname = "CORREONOMBRE_"+sGXsfl_84_idx;
         edtCorreoServidor_Internalname = "CORREOSERVIDOR_"+sGXsfl_84_idx;
         edtCorreoPuerto_Internalname = "CORREOPUERTO_"+sGXsfl_84_idx;
         edtCorreoContrasena_Internalname = "CORREOCONTRASENA_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtCorreoId_Internalname = "CORREOID_"+sGXsfl_84_fel_idx;
         edtCorreoIdentificador_Internalname = "CORREOIDENTIFICADOR_"+sGXsfl_84_fel_idx;
         edtCorreoNombre_Internalname = "CORREONOMBRE_"+sGXsfl_84_fel_idx;
         edtCorreoServidor_Internalname = "CORREOSERVIDOR_"+sGXsfl_84_fel_idx;
         edtCorreoPuerto_Internalname = "CORREOPUERTO_"+sGXsfl_84_fel_idx;
         edtCorreoContrasena_Internalname = "CORREOCONTRASENA_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB170( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A50CorreoId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCorreoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A50CorreoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A50CorreoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCorreoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtCorreoIdentificador_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A50CorreoId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtCorreoIdentificador_Internalname, "Link", edtCorreoIdentificador_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCorreoIdentificador_Internalname,StringUtil.RTrim( A51CorreoIdentificador),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCorreoIdentificador_Link,(string)"",(string)"",(string)"",(string)edtCorreoIdentificador_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCorreoNombre_Internalname,StringUtil.RTrim( A52CorreoNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCorreoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCorreoServidor_Internalname,StringUtil.RTrim( A53CorreoServidor),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCorreoServidor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)22,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCorreoPuerto_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A54CorreoPuerto), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A54CorreoPuerto), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCorreoPuerto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCorreoContrasena_Internalname,StringUtil.RTrim( A56CorreoContrasena),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCorreoContrasena_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes172( ) ;
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
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Identificador") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nombre") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Servidor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Puerto") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Contrasena") ;
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
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50CorreoId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A51CorreoIdentificador));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtCorreoIdentificador_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A52CorreoNombre));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A53CorreoServidor));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A54CorreoPuerto), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A56CorreoContrasena));
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
         lblLblcorreoidfilter_Internalname = "LBLCORREOIDFILTER";
         edtavCcorreoid_Internalname = "vCCORREOID";
         divCorreoidfiltercontainer_Internalname = "CORREOIDFILTERCONTAINER";
         lblLblcorreoidentificadorfilter_Internalname = "LBLCORREOIDENTIFICADORFILTER";
         edtavCcorreoidentificador_Internalname = "vCCORREOIDENTIFICADOR";
         divCorreoidentificadorfiltercontainer_Internalname = "CORREOIDENTIFICADORFILTERCONTAINER";
         lblLblcorreonombrefilter_Internalname = "LBLCORREONOMBREFILTER";
         edtavCcorreonombre_Internalname = "vCCORREONOMBRE";
         divCorreonombrefiltercontainer_Internalname = "CORREONOMBREFILTERCONTAINER";
         lblLblcorreoservidorfilter_Internalname = "LBLCORREOSERVIDORFILTER";
         edtavCcorreoservidor_Internalname = "vCCORREOSERVIDOR";
         divCorreoservidorfiltercontainer_Internalname = "CORREOSERVIDORFILTERCONTAINER";
         lblLblcorreopuertofilter_Internalname = "LBLCORREOPUERTOFILTER";
         edtavCcorreopuerto_Internalname = "vCCORREOPUERTO";
         divCorreopuertofiltercontainer_Internalname = "CORREOPUERTOFILTERCONTAINER";
         lblLblcorreousuariofilter_Internalname = "LBLCORREOUSUARIOFILTER";
         edtavCcorreousuario_Internalname = "vCCORREOUSUARIO";
         divCorreousuariofiltercontainer_Internalname = "CORREOUSUARIOFILTERCONTAINER";
         lblLblcorreocontrasenafilter_Internalname = "LBLCORREOCONTRASENAFILTER";
         edtavCcorreocontrasena_Internalname = "vCCORREOCONTRASENA";
         divCorreocontrasenafiltercontainer_Internalname = "CORREOCONTRASENAFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCorreoId_Internalname = "CORREOID";
         edtCorreoIdentificador_Internalname = "CORREOIDENTIFICADOR";
         edtCorreoNombre_Internalname = "CORREONOMBRE";
         edtCorreoServidor_Internalname = "CORREOSERVIDOR";
         edtCorreoPuerto_Internalname = "CORREOPUERTO";
         edtCorreoContrasena_Internalname = "CORREOCONTRASENA";
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
         edtCorreoContrasena_Jsonclick = "";
         edtCorreoPuerto_Jsonclick = "";
         edtCorreoServidor_Jsonclick = "";
         edtCorreoNombre_Jsonclick = "";
         edtCorreoIdentificador_Jsonclick = "";
         edtCorreoIdentificador_Link = "";
         edtCorreoId_Jsonclick = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCcorreocontrasena_Jsonclick = "";
         edtavCcorreocontrasena_Enabled = 1;
         edtavCcorreocontrasena_Visible = 1;
         edtavCcorreousuario_Jsonclick = "";
         edtavCcorreousuario_Enabled = 1;
         edtavCcorreousuario_Visible = 1;
         edtavCcorreopuerto_Jsonclick = "";
         edtavCcorreopuerto_Enabled = 1;
         edtavCcorreopuerto_Visible = 1;
         edtavCcorreoservidor_Jsonclick = "";
         edtavCcorreoservidor_Enabled = 1;
         edtavCcorreoservidor_Visible = 1;
         edtavCcorreonombre_Jsonclick = "";
         edtavCcorreonombre_Enabled = 1;
         edtavCcorreonombre_Visible = 1;
         edtavCcorreoidentificador_Jsonclick = "";
         edtavCcorreoidentificador_Enabled = 1;
         edtavCcorreoidentificador_Visible = 1;
         edtavCcorreoid_Jsonclick = "";
         edtavCcorreoid_Enabled = 1;
         edtavCcorreoid_Visible = 1;
         divCorreocontrasenafiltercontainer_Class = "AdvancedContainerItem";
         divCorreousuariofiltercontainer_Class = "AdvancedContainerItem";
         divCorreopuertofiltercontainer_Class = "AdvancedContainerItem";
         divCorreoservidorfiltercontainer_Class = "AdvancedContainerItem";
         divCorreonombrefiltercontainer_Class = "AdvancedContainerItem";
         divCorreoidentificadorfiltercontainer_Class = "AdvancedContainerItem";
         divCorreoidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Correo";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCorreoId',fld:'vCCORREOID',pic:'ZZZ9'},{av:'AV7cCorreoIdentificador',fld:'vCCORREOIDENTIFICADOR',pic:''},{av:'AV8cCorreoNombre',fld:'vCCORREONOMBRE',pic:''},{av:'AV9cCorreoServidor',fld:'vCCORREOSERVIDOR',pic:''},{av:'AV10cCorreoPuerto',fld:'vCCORREOPUERTO',pic:'ZZZ9'},{av:'AV11cCorreoUsuario',fld:'vCCORREOUSUARIO',pic:''},{av:'AV12cCorreoContrasena',fld:'vCCORREOCONTRASENA',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18171',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCORREOIDFILTER.CLICK","{handler:'E11171',iparms:[{av:'divCorreoidfiltercontainer_Class',ctrl:'CORREOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORREOIDFILTER.CLICK",",oparms:[{av:'divCorreoidfiltercontainer_Class',ctrl:'CORREOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcorreoid_Visible',ctrl:'vCCORREOID',prop:'Visible'}]}");
         setEventMetadata("LBLCORREOIDENTIFICADORFILTER.CLICK","{handler:'E12171',iparms:[{av:'divCorreoidentificadorfiltercontainer_Class',ctrl:'CORREOIDENTIFICADORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORREOIDENTIFICADORFILTER.CLICK",",oparms:[{av:'divCorreoidentificadorfiltercontainer_Class',ctrl:'CORREOIDENTIFICADORFILTERCONTAINER',prop:'Class'},{av:'edtavCcorreoidentificador_Visible',ctrl:'vCCORREOIDENTIFICADOR',prop:'Visible'}]}");
         setEventMetadata("LBLCORREONOMBREFILTER.CLICK","{handler:'E13171',iparms:[{av:'divCorreonombrefiltercontainer_Class',ctrl:'CORREONOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORREONOMBREFILTER.CLICK",",oparms:[{av:'divCorreonombrefiltercontainer_Class',ctrl:'CORREONOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCcorreonombre_Visible',ctrl:'vCCORREONOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLCORREOSERVIDORFILTER.CLICK","{handler:'E14171',iparms:[{av:'divCorreoservidorfiltercontainer_Class',ctrl:'CORREOSERVIDORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORREOSERVIDORFILTER.CLICK",",oparms:[{av:'divCorreoservidorfiltercontainer_Class',ctrl:'CORREOSERVIDORFILTERCONTAINER',prop:'Class'},{av:'edtavCcorreoservidor_Visible',ctrl:'vCCORREOSERVIDOR',prop:'Visible'}]}");
         setEventMetadata("LBLCORREOPUERTOFILTER.CLICK","{handler:'E15171',iparms:[{av:'divCorreopuertofiltercontainer_Class',ctrl:'CORREOPUERTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORREOPUERTOFILTER.CLICK",",oparms:[{av:'divCorreopuertofiltercontainer_Class',ctrl:'CORREOPUERTOFILTERCONTAINER',prop:'Class'},{av:'edtavCcorreopuerto_Visible',ctrl:'vCCORREOPUERTO',prop:'Visible'}]}");
         setEventMetadata("LBLCORREOUSUARIOFILTER.CLICK","{handler:'E16171',iparms:[{av:'divCorreousuariofiltercontainer_Class',ctrl:'CORREOUSUARIOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORREOUSUARIOFILTER.CLICK",",oparms:[{av:'divCorreousuariofiltercontainer_Class',ctrl:'CORREOUSUARIOFILTERCONTAINER',prop:'Class'},{av:'edtavCcorreousuario_Visible',ctrl:'vCCORREOUSUARIO',prop:'Visible'}]}");
         setEventMetadata("LBLCORREOCONTRASENAFILTER.CLICK","{handler:'E17171',iparms:[{av:'divCorreocontrasenafiltercontainer_Class',ctrl:'CORREOCONTRASENAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORREOCONTRASENAFILTER.CLICK",",oparms:[{av:'divCorreocontrasenafiltercontainer_Class',ctrl:'CORREOCONTRASENAFILTERCONTAINER',prop:'Class'},{av:'edtavCcorreocontrasena_Visible',ctrl:'vCCORREOCONTRASENA',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21172',iparms:[{av:'A50CorreoId',fld:'CORREOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pCorreoId',fld:'vPCORREOID',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCorreoId',fld:'vCCORREOID',pic:'ZZZ9'},{av:'AV7cCorreoIdentificador',fld:'vCCORREOIDENTIFICADOR',pic:''},{av:'AV8cCorreoNombre',fld:'vCCORREONOMBRE',pic:''},{av:'AV9cCorreoServidor',fld:'vCCORREOSERVIDOR',pic:''},{av:'AV10cCorreoPuerto',fld:'vCCORREOPUERTO',pic:'ZZZ9'},{av:'AV11cCorreoUsuario',fld:'vCCORREOUSUARIO',pic:''},{av:'AV12cCorreoContrasena',fld:'vCCORREOCONTRASENA',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCorreoId',fld:'vCCORREOID',pic:'ZZZ9'},{av:'AV7cCorreoIdentificador',fld:'vCCORREOIDENTIFICADOR',pic:''},{av:'AV8cCorreoNombre',fld:'vCCORREONOMBRE',pic:''},{av:'AV9cCorreoServidor',fld:'vCCORREOSERVIDOR',pic:''},{av:'AV10cCorreoPuerto',fld:'vCCORREOPUERTO',pic:'ZZZ9'},{av:'AV11cCorreoUsuario',fld:'vCCORREOUSUARIO',pic:''},{av:'AV12cCorreoContrasena',fld:'vCCORREOCONTRASENA',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCorreoId',fld:'vCCORREOID',pic:'ZZZ9'},{av:'AV7cCorreoIdentificador',fld:'vCCORREOIDENTIFICADOR',pic:''},{av:'AV8cCorreoNombre',fld:'vCCORREONOMBRE',pic:''},{av:'AV9cCorreoServidor',fld:'vCCORREOSERVIDOR',pic:''},{av:'AV10cCorreoPuerto',fld:'vCCORREOPUERTO',pic:'ZZZ9'},{av:'AV11cCorreoUsuario',fld:'vCCORREOUSUARIO',pic:''},{av:'AV12cCorreoContrasena',fld:'vCCORREOCONTRASENA',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCorreoId',fld:'vCCORREOID',pic:'ZZZ9'},{av:'AV7cCorreoIdentificador',fld:'vCCORREOIDENTIFICADOR',pic:''},{av:'AV8cCorreoNombre',fld:'vCCORREONOMBRE',pic:''},{av:'AV9cCorreoServidor',fld:'vCCORREOSERVIDOR',pic:''},{av:'AV10cCorreoPuerto',fld:'vCCORREOPUERTO',pic:'ZZZ9'},{av:'AV11cCorreoUsuario',fld:'vCCORREOUSUARIO',pic:''},{av:'AV12cCorreoContrasena',fld:'vCCORREOCONTRASENA',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CCORREOUSUARIO","{handler:'Validv_Ccorreousuario',iparms:[]");
         setEventMetadata("VALIDV_CCORREOUSUARIO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Correocontrasena',iparms:[]");
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
         AV7cCorreoIdentificador = "";
         AV8cCorreoNombre = "";
         AV9cCorreoServidor = "";
         AV11cCorreoUsuario = "";
         AV12cCorreoContrasena = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcorreoidfilter_Jsonclick = "";
         TempTags = "";
         lblLblcorreoidentificadorfilter_Jsonclick = "";
         lblLblcorreonombrefilter_Jsonclick = "";
         lblLblcorreoservidorfilter_Jsonclick = "";
         lblLblcorreopuertofilter_Jsonclick = "";
         lblLblcorreousuariofilter_Jsonclick = "";
         lblLblcorreocontrasenafilter_Jsonclick = "";
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
         AV17Linkselection_GXI = "";
         A51CorreoIdentificador = "";
         A52CorreoNombre = "";
         A53CorreoServidor = "";
         A56CorreoContrasena = "";
         scmdbuf = "";
         lV7cCorreoIdentificador = "";
         lV8cCorreoNombre = "";
         lV9cCorreoServidor = "";
         lV11cCorreoUsuario = "";
         lV12cCorreoContrasena = "";
         A55CorreoUsuario = "";
         H00172_A55CorreoUsuario = new string[] {""} ;
         H00172_A56CorreoContrasena = new string[] {""} ;
         H00172_A54CorreoPuerto = new short[1] ;
         H00172_A53CorreoServidor = new string[] {""} ;
         H00172_A52CorreoNombre = new string[] {""} ;
         H00172_A51CorreoIdentificador = new string[] {""} ;
         H00172_A50CorreoId = new short[1] ;
         H00173_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00d0__default(),
            new Object[][] {
                new Object[] {
               H00172_A55CorreoUsuario, H00172_A56CorreoContrasena, H00172_A54CorreoPuerto, H00172_A53CorreoServidor, H00172_A52CorreoNombre, H00172_A51CorreoIdentificador, H00172_A50CorreoId
               }
               , new Object[] {
               H00173_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13pCorreoId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cCorreoId ;
      private short AV10cCorreoPuerto ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A50CorreoId ;
      private short A54CorreoPuerto ;
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
      private int edtavCcorreoid_Enabled ;
      private int edtavCcorreoid_Visible ;
      private int edtavCcorreoidentificador_Visible ;
      private int edtavCcorreoidentificador_Enabled ;
      private int edtavCcorreonombre_Visible ;
      private int edtavCcorreonombre_Enabled ;
      private int edtavCcorreoservidor_Visible ;
      private int edtavCcorreoservidor_Enabled ;
      private int edtavCcorreopuerto_Enabled ;
      private int edtavCcorreopuerto_Visible ;
      private int edtavCcorreousuario_Visible ;
      private int edtavCcorreousuario_Enabled ;
      private int edtavCcorreocontrasena_Visible ;
      private int edtavCcorreocontrasena_Enabled ;
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
      private string divCorreoidfiltercontainer_Class ;
      private string divCorreoidentificadorfiltercontainer_Class ;
      private string divCorreonombrefiltercontainer_Class ;
      private string divCorreoservidorfiltercontainer_Class ;
      private string divCorreopuertofiltercontainer_Class ;
      private string divCorreousuariofiltercontainer_Class ;
      private string divCorreocontrasenafiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV7cCorreoIdentificador ;
      private string AV8cCorreoNombre ;
      private string AV9cCorreoServidor ;
      private string AV12cCorreoContrasena ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divCorreoidfiltercontainer_Internalname ;
      private string lblLblcorreoidfilter_Internalname ;
      private string lblLblcorreoidfilter_Jsonclick ;
      private string edtavCcorreoid_Internalname ;
      private string TempTags ;
      private string edtavCcorreoid_Jsonclick ;
      private string divCorreoidentificadorfiltercontainer_Internalname ;
      private string lblLblcorreoidentificadorfilter_Internalname ;
      private string lblLblcorreoidentificadorfilter_Jsonclick ;
      private string edtavCcorreoidentificador_Internalname ;
      private string edtavCcorreoidentificador_Jsonclick ;
      private string divCorreonombrefiltercontainer_Internalname ;
      private string lblLblcorreonombrefilter_Internalname ;
      private string lblLblcorreonombrefilter_Jsonclick ;
      private string edtavCcorreonombre_Internalname ;
      private string edtavCcorreonombre_Jsonclick ;
      private string divCorreoservidorfiltercontainer_Internalname ;
      private string lblLblcorreoservidorfilter_Internalname ;
      private string lblLblcorreoservidorfilter_Jsonclick ;
      private string edtavCcorreoservidor_Internalname ;
      private string edtavCcorreoservidor_Jsonclick ;
      private string divCorreopuertofiltercontainer_Internalname ;
      private string lblLblcorreopuertofilter_Internalname ;
      private string lblLblcorreopuertofilter_Jsonclick ;
      private string edtavCcorreopuerto_Internalname ;
      private string edtavCcorreopuerto_Jsonclick ;
      private string divCorreousuariofiltercontainer_Internalname ;
      private string lblLblcorreousuariofilter_Internalname ;
      private string lblLblcorreousuariofilter_Jsonclick ;
      private string edtavCcorreousuario_Internalname ;
      private string edtavCcorreousuario_Jsonclick ;
      private string divCorreocontrasenafiltercontainer_Internalname ;
      private string lblLblcorreocontrasenafilter_Internalname ;
      private string lblLblcorreocontrasenafilter_Jsonclick ;
      private string edtavCcorreocontrasena_Internalname ;
      private string edtavCcorreocontrasena_Jsonclick ;
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
      private string edtCorreoId_Internalname ;
      private string A51CorreoIdentificador ;
      private string edtCorreoIdentificador_Internalname ;
      private string A52CorreoNombre ;
      private string edtCorreoNombre_Internalname ;
      private string A53CorreoServidor ;
      private string edtCorreoServidor_Internalname ;
      private string edtCorreoPuerto_Internalname ;
      private string A56CorreoContrasena ;
      private string edtCorreoContrasena_Internalname ;
      private string scmdbuf ;
      private string lV7cCorreoIdentificador ;
      private string lV8cCorreoNombre ;
      private string lV9cCorreoServidor ;
      private string lV12cCorreoContrasena ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCorreoId_Jsonclick ;
      private string edtCorreoIdentificador_Link ;
      private string edtCorreoIdentificador_Jsonclick ;
      private string edtCorreoNombre_Jsonclick ;
      private string edtCorreoServidor_Jsonclick ;
      private string edtCorreoPuerto_Jsonclick ;
      private string edtCorreoContrasena_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV11cCorreoUsuario ;
      private string AV17Linkselection_GXI ;
      private string lV11cCorreoUsuario ;
      private string A55CorreoUsuario ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H00172_A55CorreoUsuario ;
      private string[] H00172_A56CorreoContrasena ;
      private short[] H00172_A54CorreoPuerto ;
      private string[] H00172_A53CorreoServidor ;
      private string[] H00172_A52CorreoNombre ;
      private string[] H00172_A51CorreoIdentificador ;
      private short[] H00172_A50CorreoId ;
      private long[] H00173_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pCorreoId ;
      private GXWebForm Form ;
   }

   public class gx00d0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00172( IGxContext context ,
                                             string AV7cCorreoIdentificador ,
                                             string AV8cCorreoNombre ,
                                             string AV9cCorreoServidor ,
                                             short AV10cCorreoPuerto ,
                                             string AV11cCorreoUsuario ,
                                             string AV12cCorreoContrasena ,
                                             string A51CorreoIdentificador ,
                                             string A52CorreoNombre ,
                                             string A53CorreoServidor ,
                                             short A54CorreoPuerto ,
                                             string A55CorreoUsuario ,
                                             string A56CorreoContrasena ,
                                             short AV6cCorreoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CorreoUsuario], [CorreoContrasena], [CorreoPuerto], [CorreoServidor], [CorreoNombre], [CorreoIdentificador], [CorreoId]";
         sFromString = " FROM [Correo]";
         sOrderString = "";
         AddWhere(sWhereString, "([CorreoId] >= @AV6cCorreoId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cCorreoIdentificador)) )
         {
            AddWhere(sWhereString, "([CorreoIdentificador] like @lV7cCorreoIdentificador)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cCorreoNombre)) )
         {
            AddWhere(sWhereString, "([CorreoNombre] like @lV8cCorreoNombre)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cCorreoServidor)) )
         {
            AddWhere(sWhereString, "([CorreoServidor] like @lV9cCorreoServidor)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cCorreoPuerto) )
         {
            AddWhere(sWhereString, "([CorreoPuerto] >= @AV10cCorreoPuerto)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cCorreoUsuario)) )
         {
            AddWhere(sWhereString, "([CorreoUsuario] like @lV11cCorreoUsuario)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cCorreoContrasena)) )
         {
            AddWhere(sWhereString, "([CorreoContrasena] like @lV12cCorreoContrasena)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [CorreoId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00173( IGxContext context ,
                                             string AV7cCorreoIdentificador ,
                                             string AV8cCorreoNombre ,
                                             string AV9cCorreoServidor ,
                                             short AV10cCorreoPuerto ,
                                             string AV11cCorreoUsuario ,
                                             string AV12cCorreoContrasena ,
                                             string A51CorreoIdentificador ,
                                             string A52CorreoNombre ,
                                             string A53CorreoServidor ,
                                             short A54CorreoPuerto ,
                                             string A55CorreoUsuario ,
                                             string A56CorreoContrasena ,
                                             short AV6cCorreoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Correo]";
         AddWhere(sWhereString, "([CorreoId] >= @AV6cCorreoId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cCorreoIdentificador)) )
         {
            AddWhere(sWhereString, "([CorreoIdentificador] like @lV7cCorreoIdentificador)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cCorreoNombre)) )
         {
            AddWhere(sWhereString, "([CorreoNombre] like @lV8cCorreoNombre)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cCorreoServidor)) )
         {
            AddWhere(sWhereString, "([CorreoServidor] like @lV9cCorreoServidor)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cCorreoPuerto) )
         {
            AddWhere(sWhereString, "([CorreoPuerto] >= @AV10cCorreoPuerto)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cCorreoUsuario)) )
         {
            AddWhere(sWhereString, "([CorreoUsuario] like @lV11cCorreoUsuario)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cCorreoContrasena)) )
         {
            AddWhere(sWhereString, "([CorreoContrasena] like @lV12cCorreoContrasena)");
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
                     return conditional_H00172(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_H00173(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] );
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
          Object[] prmH00172;
          prmH00172 = new Object[] {
          new ParDef("@AV6cCorreoId",GXType.Int16,4,0) ,
          new ParDef("@lV7cCorreoIdentificador",GXType.NChar,20,0) ,
          new ParDef("@lV8cCorreoNombre",GXType.NChar,20,0) ,
          new ParDef("@lV9cCorreoServidor",GXType.NChar,22,0) ,
          new ParDef("@AV10cCorreoPuerto",GXType.Int16,4,0) ,
          new ParDef("@lV11cCorreoUsuario",GXType.NVarChar,100,0) ,
          new ParDef("@lV12cCorreoContrasena",GXType.NChar,20,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00173;
          prmH00173 = new Object[] {
          new ParDef("@AV6cCorreoId",GXType.Int16,4,0) ,
          new ParDef("@lV7cCorreoIdentificador",GXType.NChar,20,0) ,
          new ParDef("@lV8cCorreoNombre",GXType.NChar,20,0) ,
          new ParDef("@lV9cCorreoServidor",GXType.NChar,22,0) ,
          new ParDef("@AV10cCorreoPuerto",GXType.Int16,4,0) ,
          new ParDef("@lV11cCorreoUsuario",GXType.NVarChar,100,0) ,
          new ParDef("@lV12cCorreoContrasena",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00172", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00172,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00173", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00173,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 22);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
