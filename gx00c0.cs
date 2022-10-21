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
   public class gx00c0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00c0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx00c0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pTableroId ,
                           out short aP1_pRegistroInvitadoId )
      {
         this.AV12pTableroId = 0 ;
         this.AV13pRegistroInvitadoId = 0 ;
         executePrivate();
         aP0_pTableroId=this.AV12pTableroId;
         aP1_pRegistroInvitadoId=this.AV13pRegistroInvitadoId;
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
               AV12pTableroId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV12pTableroId", StringUtil.LTrimStr( (decimal)(AV12pTableroId), 4, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pRegistroInvitadoId = (short)(NumberUtil.Val( GetPar( "pRegistroInvitadoId"), "."));
                  AssignAttri("", false, "AV13pRegistroInvitadoId", StringUtil.LTrimStr( (decimal)(AV13pRegistroInvitadoId), 4, 0));
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
         nRC_GXsfl_74 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."));
         nGXsfl_74_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."));
         sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
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
         AV7cRegistroInvitadoId = (short)(NumberUtil.Val( GetPar( "cRegistroInvitadoId"), "."));
         AV8cRegistroInvitadoUsuario = (short)(NumberUtil.Val( GetPar( "cRegistroInvitadoUsuario"), "."));
         AV9cRegistroInvitadoEmail = GetPar( "cRegistroInvitadoEmail");
         AV10cInvitadoRolId = (short)(NumberUtil.Val( GetPar( "cInvitadoRolId"), "."));
         AV11cRegistroInvitadoFecha = context.localUtil.ParseDTimeParm( GetPar( "cRegistroInvitadoFecha"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cRegistroInvitadoId, AV8cRegistroInvitadoUsuario, AV9cRegistroInvitadoEmail, AV10cInvitadoRolId, AV11cRegistroInvitadoFecha) ;
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
         PA0R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0R2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00c0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pTableroId,4,0)),UrlEncode(StringUtil.LTrimStr(AV13pRegistroInvitadoId,4,0))}, new string[] {"pTableroId","pRegistroInvitadoId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCREGISTROINVITADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cRegistroInvitadoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCREGISTROINVITADOUSUARIO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cRegistroInvitadoUsuario), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCREGISTROINVITADOEMAIL", AV9cRegistroInvitadoEmail);
         GxWebStd.gx_hidden_field( context, "GXH_vCINVITADOROLID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cInvitadoRolId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCREGISTROINVITADOFECHA", context.localUtil.TToC( AV11cRegistroInvitadoFecha, 10, 8, 0, 3, "/", ":", " "));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPTABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pTableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPREGISTROINVITADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pRegistroInvitadoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "TABLEROIDFILTERCONTAINER_Class", StringUtil.RTrim( divTableroidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "REGISTROINVITADOIDFILTERCONTAINER_Class", StringUtil.RTrim( divRegistroinvitadoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "REGISTROINVITADOUSUARIOFILTERCONTAINER_Class", StringUtil.RTrim( divRegistroinvitadousuariofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "REGISTROINVITADOEMAILFILTERCONTAINER_Class", StringUtil.RTrim( divRegistroinvitadoemailfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVITADOROLIDFILTERCONTAINER_Class", StringUtil.RTrim( divInvitadorolidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "REGISTROINVITADOFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divRegistroinvitadofechafiltercontainer_Class));
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
            WE0R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0R2( ) ;
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
         return formatLink("gx00c0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pTableroId,4,0)),UrlEncode(StringUtil.LTrimStr(AV13pRegistroInvitadoId,4,0))}, new string[] {"pTableroId","pRegistroInvitadoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00C0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List  T10" ;
      }

      protected void WB0R0( )
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
            GxWebStd.gx_label_ctrl( context, lblLbltableroidfilter_Internalname, "Tablero Id", "", "", lblLbltableroidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtableroid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTableroId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCtableroid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cTableroId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cTableroId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtableroid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtableroid_Visible, edtavCtableroid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divRegistroinvitadoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRegistroinvitadoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblregistroinvitadoidfilter_Internalname, "Registro Invitado Id", "", "", lblLblregistroinvitadoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCregistroinvitadoid_Internalname, "Registro Invitado Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCregistroinvitadoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cRegistroInvitadoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCregistroinvitadoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cRegistroInvitadoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cRegistroInvitadoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCregistroinvitadoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCregistroinvitadoid_Visible, edtavCregistroinvitadoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divRegistroinvitadousuariofiltercontainer_Internalname, 1, 0, "px", 0, "px", divRegistroinvitadousuariofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblregistroinvitadousuariofilter_Internalname, "Registro Invitado Usuario", "", "", lblLblregistroinvitadousuariofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCregistroinvitadousuario_Internalname, "Registro Invitado Usuario", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCregistroinvitadousuario_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cRegistroInvitadoUsuario), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCregistroinvitadousuario_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cRegistroInvitadoUsuario), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cRegistroInvitadoUsuario), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCregistroinvitadousuario_Jsonclick, 0, "Attribute", "", "", "", "", edtavCregistroinvitadousuario_Visible, edtavCregistroinvitadousuario_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divRegistroinvitadoemailfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRegistroinvitadoemailfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblregistroinvitadoemailfilter_Internalname, "Registro Invitado Email", "", "", lblLblregistroinvitadoemailfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCregistroinvitadoemail_Internalname, "Registro Invitado Email", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCregistroinvitadoemail_Internalname, AV9cRegistroInvitadoEmail, StringUtil.RTrim( context.localUtil.Format( AV9cRegistroInvitadoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCregistroinvitadoemail_Jsonclick, 0, "Attribute", "", "", "", "", edtavCregistroinvitadoemail_Visible, edtavCregistroinvitadoemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divInvitadorolidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvitadorolidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvitadorolidfilter_Internalname, "Invitado Rol Id", "", "", lblLblinvitadorolidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvitadorolid_Internalname, "Invitado Rol Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvitadorolid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cInvitadoRolId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCinvitadorolid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cInvitadoRolId), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cInvitadoRolId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvitadorolid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvitadorolid_Visible, edtavCinvitadorolid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divRegistroinvitadofechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divRegistroinvitadofechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblregistroinvitadofechafilter_Internalname, "Registro Invitado Fecha", "", "", lblLblregistroinvitadofechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160r1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCregistroinvitadofecha_Internalname, "Registro Invitado Fecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCregistroinvitadofecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCregistroinvitadofecha_Internalname, context.localUtil.TToC( AV11cRegistroInvitadoFecha, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV11cRegistroInvitadoFecha, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCregistroinvitadofecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCregistroinvitadofecha_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e170r1_client"+"'", TempTags, "", 2, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl74( ) ;
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 74 )
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

      protected void START0R2( )
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
            Form.Meta.addItem("description", "Selection List  T10", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0R0( ) ;
      }

      protected void WS0R2( )
      {
         START0R2( ) ;
         EVT0R2( ) ;
      }

      protected void EVT0R2( )
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
                              nGXsfl_74_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A9TableroId = (short)(context.localUtil.CToN( cgiGet( edtTableroId_Internalname), ",", "."));
                              A40RegistroInvitadoId = (short)(context.localUtil.CToN( cgiGet( edtRegistroInvitadoId_Internalname), ",", "."));
                              A43RegistroInvitadoUsuario = (short)(context.localUtil.CToN( cgiGet( edtRegistroInvitadoUsuario_Internalname), ",", "."));
                              A41InvitadoRolId = (short)(context.localUtil.CToN( cgiGet( edtInvitadoRolId_Internalname), ",", "."));
                              A45RegistroInvitadoFecha = context.localUtil.CToT( cgiGet( edtRegistroInvitadoFecha_Internalname), 0);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E180R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E190R2 ();
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
                                       /* Set Refresh If Cregistroinvitadoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREGISTROINVITADOID"), ",", ".") != Convert.ToDecimal( AV7cRegistroInvitadoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cregistroinvitadousuario Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREGISTROINVITADOUSUARIO"), ",", ".") != Convert.ToDecimal( AV8cRegistroInvitadoUsuario )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cregistroinvitadoemail Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCREGISTROINVITADOEMAIL"), AV9cRegistroInvitadoEmail) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinvitadorolid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVITADOROLID"), ",", ".") != Convert.ToDecimal( AV10cInvitadoRolId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cregistroinvitadofecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCREGISTROINVITADOFECHA"), 0) != AV11cRegistroInvitadoFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E200R2 ();
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

      protected void WE0R2( )
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

      protected void PA0R2( )
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
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cTableroId ,
                                        short AV7cRegistroInvitadoId ,
                                        short AV8cRegistroInvitadoUsuario ,
                                        string AV9cRegistroInvitadoEmail ,
                                        short AV10cInvitadoRolId ,
                                        DateTime AV11cRegistroInvitadoFecha )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_REGISTROINVITADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A40RegistroInvitadoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "REGISTROINVITADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40RegistroInvitadoId), 4, 0, ".", "")));
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
         RF0R2( ) ;
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

      protected void RF0R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
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
            SubsflControlProps_742( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8cRegistroInvitadoUsuario ,
                                                 AV9cRegistroInvitadoEmail ,
                                                 AV10cInvitadoRolId ,
                                                 AV11cRegistroInvitadoFecha ,
                                                 A43RegistroInvitadoUsuario ,
                                                 A44RegistroInvitadoEmail ,
                                                 A41InvitadoRolId ,
                                                 A45RegistroInvitadoFecha ,
                                                 AV6cTableroId ,
                                                 AV7cRegistroInvitadoId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV9cRegistroInvitadoEmail = StringUtil.Concat( StringUtil.RTrim( AV9cRegistroInvitadoEmail), "%", "");
            /* Using cursor H000R2 */
            pr_default.execute(0, new Object[] {AV6cTableroId, AV7cRegistroInvitadoId, AV8cRegistroInvitadoUsuario, lV9cRegistroInvitadoEmail, AV10cInvitadoRolId, AV11cRegistroInvitadoFecha, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A44RegistroInvitadoEmail = H000R2_A44RegistroInvitadoEmail[0];
               A45RegistroInvitadoFecha = H000R2_A45RegistroInvitadoFecha[0];
               A41InvitadoRolId = H000R2_A41InvitadoRolId[0];
               A43RegistroInvitadoUsuario = H000R2_A43RegistroInvitadoUsuario[0];
               A40RegistroInvitadoId = H000R2_A40RegistroInvitadoId[0];
               A9TableroId = H000R2_A9TableroId[0];
               /* Execute user event: Load */
               E190R2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB0R0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0R2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_REGISTROINVITADOID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A40RegistroInvitadoId), "ZZZ9"), context));
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
                                              AV8cRegistroInvitadoUsuario ,
                                              AV9cRegistroInvitadoEmail ,
                                              AV10cInvitadoRolId ,
                                              AV11cRegistroInvitadoFecha ,
                                              A43RegistroInvitadoUsuario ,
                                              A44RegistroInvitadoEmail ,
                                              A41InvitadoRolId ,
                                              A45RegistroInvitadoFecha ,
                                              AV6cTableroId ,
                                              AV7cRegistroInvitadoId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV9cRegistroInvitadoEmail = StringUtil.Concat( StringUtil.RTrim( AV9cRegistroInvitadoEmail), "%", "");
         /* Using cursor H000R3 */
         pr_default.execute(1, new Object[] {AV6cTableroId, AV7cRegistroInvitadoId, AV8cRegistroInvitadoUsuario, lV9cRegistroInvitadoEmail, AV10cInvitadoRolId, AV11cRegistroInvitadoFecha});
         GRID1_nRecordCount = H000R3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cRegistroInvitadoId, AV8cRegistroInvitadoUsuario, AV9cRegistroInvitadoEmail, AV10cInvitadoRolId, AV11cRegistroInvitadoFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cRegistroInvitadoId, AV8cRegistroInvitadoUsuario, AV9cRegistroInvitadoEmail, AV10cInvitadoRolId, AV11cRegistroInvitadoFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cRegistroInvitadoId, AV8cRegistroInvitadoUsuario, AV9cRegistroInvitadoEmail, AV10cInvitadoRolId, AV11cRegistroInvitadoFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cRegistroInvitadoId, AV8cRegistroInvitadoUsuario, AV9cRegistroInvitadoEmail, AV10cInvitadoRolId, AV11cRegistroInvitadoFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTableroId, AV7cRegistroInvitadoId, AV8cRegistroInvitadoUsuario, AV9cRegistroInvitadoEmail, AV10cInvitadoRolId, AV11cRegistroInvitadoFecha) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E180R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), ",", "."));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCregistroinvitadoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCregistroinvitadoid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCREGISTROINVITADOID");
               GX_FocusControl = edtavCregistroinvitadoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cRegistroInvitadoId = 0;
               AssignAttri("", false, "AV7cRegistroInvitadoId", StringUtil.LTrimStr( (decimal)(AV7cRegistroInvitadoId), 4, 0));
            }
            else
            {
               AV7cRegistroInvitadoId = (short)(context.localUtil.CToN( cgiGet( edtavCregistroinvitadoid_Internalname), ",", "."));
               AssignAttri("", false, "AV7cRegistroInvitadoId", StringUtil.LTrimStr( (decimal)(AV7cRegistroInvitadoId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCregistroinvitadousuario_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCregistroinvitadousuario_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCREGISTROINVITADOUSUARIO");
               GX_FocusControl = edtavCregistroinvitadousuario_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cRegistroInvitadoUsuario = 0;
               AssignAttri("", false, "AV8cRegistroInvitadoUsuario", StringUtil.LTrimStr( (decimal)(AV8cRegistroInvitadoUsuario), 4, 0));
            }
            else
            {
               AV8cRegistroInvitadoUsuario = (short)(context.localUtil.CToN( cgiGet( edtavCregistroinvitadousuario_Internalname), ",", "."));
               AssignAttri("", false, "AV8cRegistroInvitadoUsuario", StringUtil.LTrimStr( (decimal)(AV8cRegistroInvitadoUsuario), 4, 0));
            }
            AV9cRegistroInvitadoEmail = cgiGet( edtavCregistroinvitadoemail_Internalname);
            AssignAttri("", false, "AV9cRegistroInvitadoEmail", AV9cRegistroInvitadoEmail);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinvitadorolid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinvitadorolid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVITADOROLID");
               GX_FocusControl = edtavCinvitadorolid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cInvitadoRolId = 0;
               AssignAttri("", false, "AV10cInvitadoRolId", StringUtil.LTrimStr( (decimal)(AV10cInvitadoRolId), 4, 0));
            }
            else
            {
               AV10cInvitadoRolId = (short)(context.localUtil.CToN( cgiGet( edtavCinvitadorolid_Internalname), ",", "."));
               AssignAttri("", false, "AV10cInvitadoRolId", StringUtil.LTrimStr( (decimal)(AV10cInvitadoRolId), 4, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCregistroinvitadofecha_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Registro Invitado Fecha"}), 1, "vCREGISTROINVITADOFECHA");
               GX_FocusControl = edtavCregistroinvitadofecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cRegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV11cRegistroInvitadoFecha", context.localUtil.TToC( AV11cRegistroInvitadoFecha, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV11cRegistroInvitadoFecha = context.localUtil.CToT( cgiGet( edtavCregistroinvitadofecha_Internalname));
               AssignAttri("", false, "AV11cRegistroInvitadoFecha", context.localUtil.TToC( AV11cRegistroInvitadoFecha, 8, 5, 0, 3, "/", ":", " "));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTABLEROID"), ",", ".") != Convert.ToDecimal( AV6cTableroId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREGISTROINVITADOID"), ",", ".") != Convert.ToDecimal( AV7cRegistroInvitadoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREGISTROINVITADOUSUARIO"), ",", ".") != Convert.ToDecimal( AV8cRegistroInvitadoUsuario )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCREGISTROINVITADOEMAIL"), AV9cRegistroInvitadoEmail) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVITADOROLID"), ",", ".") != Convert.ToDecimal( AV10cInvitadoRolId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCREGISTROINVITADOFECHA")) != AV11cRegistroInvitadoFecha )
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
         E180R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E180R2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", " T10", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E190R2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_742( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
         {
            context.DoAjaxLoad(74, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E200R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E200R2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pTableroId = A9TableroId;
         AssignAttri("", false, "AV12pTableroId", StringUtil.LTrimStr( (decimal)(AV12pTableroId), 4, 0));
         AV13pRegistroInvitadoId = A40RegistroInvitadoId;
         AssignAttri("", false, "AV13pRegistroInvitadoId", StringUtil.LTrimStr( (decimal)(AV13pRegistroInvitadoId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV12pTableroId,(short)AV13pRegistroInvitadoId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pTableroId","AV13pRegistroInvitadoId"});
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
         AV13pRegistroInvitadoId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV13pRegistroInvitadoId", StringUtil.LTrimStr( (decimal)(AV13pRegistroInvitadoId), 4, 0));
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
         PA0R2( ) ;
         WS0R2( ) ;
         WE0R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202210161247596", true, true);
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
         context.AddJavascriptSource("gx00c0.js", "?202210161247596", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtTableroId_Internalname = "TABLEROID_"+sGXsfl_74_idx;
         edtRegistroInvitadoId_Internalname = "REGISTROINVITADOID_"+sGXsfl_74_idx;
         edtRegistroInvitadoUsuario_Internalname = "REGISTROINVITADOUSUARIO_"+sGXsfl_74_idx;
         edtInvitadoRolId_Internalname = "INVITADOROLID_"+sGXsfl_74_idx;
         edtRegistroInvitadoFecha_Internalname = "REGISTROINVITADOFECHA_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtTableroId_Internalname = "TABLEROID_"+sGXsfl_74_fel_idx;
         edtRegistroInvitadoId_Internalname = "REGISTROINVITADOID_"+sGXsfl_74_fel_idx;
         edtRegistroInvitadoUsuario_Internalname = "REGISTROINVITADOUSUARIO_"+sGXsfl_74_fel_idx;
         edtInvitadoRolId_Internalname = "INVITADOROLID_"+sGXsfl_74_fel_idx;
         edtRegistroInvitadoFecha_Internalname = "REGISTROINVITADOFECHA_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         SubsflControlProps_742( ) ;
         WB0R0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_74_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A40RegistroInvitadoId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTableroId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTableroId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRegistroInvitadoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A40RegistroInvitadoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A40RegistroInvitadoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRegistroInvitadoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRegistroInvitadoUsuario_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A43RegistroInvitadoUsuario), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A43RegistroInvitadoUsuario), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRegistroInvitadoUsuario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvitadoRolId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A41InvitadoRolId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A41InvitadoRolId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvitadoRolId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRegistroInvitadoFecha_Internalname,context.localUtil.TToC( A45RegistroInvitadoFecha, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A45RegistroInvitadoFecha, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRegistroInvitadoFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0R2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl74( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"74\">") ;
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
            context.SendWebValue( "Invitado Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Invitado Usuario") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Rol Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Invitado Fecha") ;
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
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40RegistroInvitadoId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A43RegistroInvitadoUsuario), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41InvitadoRolId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A45RegistroInvitadoFecha, 10, 8, 0, 3, "/", ":", " "));
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
         lblLblregistroinvitadoidfilter_Internalname = "LBLREGISTROINVITADOIDFILTER";
         edtavCregistroinvitadoid_Internalname = "vCREGISTROINVITADOID";
         divRegistroinvitadoidfiltercontainer_Internalname = "REGISTROINVITADOIDFILTERCONTAINER";
         lblLblregistroinvitadousuariofilter_Internalname = "LBLREGISTROINVITADOUSUARIOFILTER";
         edtavCregistroinvitadousuario_Internalname = "vCREGISTROINVITADOUSUARIO";
         divRegistroinvitadousuariofiltercontainer_Internalname = "REGISTROINVITADOUSUARIOFILTERCONTAINER";
         lblLblregistroinvitadoemailfilter_Internalname = "LBLREGISTROINVITADOEMAILFILTER";
         edtavCregistroinvitadoemail_Internalname = "vCREGISTROINVITADOEMAIL";
         divRegistroinvitadoemailfiltercontainer_Internalname = "REGISTROINVITADOEMAILFILTERCONTAINER";
         lblLblinvitadorolidfilter_Internalname = "LBLINVITADOROLIDFILTER";
         edtavCinvitadorolid_Internalname = "vCINVITADOROLID";
         divInvitadorolidfiltercontainer_Internalname = "INVITADOROLIDFILTERCONTAINER";
         lblLblregistroinvitadofechafilter_Internalname = "LBLREGISTROINVITADOFECHAFILTER";
         edtavCregistroinvitadofecha_Internalname = "vCREGISTROINVITADOFECHA";
         divRegistroinvitadofechafiltercontainer_Internalname = "REGISTROINVITADOFECHAFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtTableroId_Internalname = "TABLEROID";
         edtRegistroInvitadoId_Internalname = "REGISTROINVITADOID";
         edtRegistroInvitadoUsuario_Internalname = "REGISTROINVITADOUSUARIO";
         edtInvitadoRolId_Internalname = "INVITADOROLID";
         edtRegistroInvitadoFecha_Internalname = "REGISTROINVITADOFECHA";
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
         edtRegistroInvitadoFecha_Jsonclick = "";
         edtInvitadoRolId_Jsonclick = "";
         edtRegistroInvitadoUsuario_Jsonclick = "";
         edtRegistroInvitadoId_Jsonclick = "";
         edtTableroId_Jsonclick = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCregistroinvitadofecha_Jsonclick = "";
         edtavCregistroinvitadofecha_Enabled = 1;
         edtavCinvitadorolid_Jsonclick = "";
         edtavCinvitadorolid_Enabled = 1;
         edtavCinvitadorolid_Visible = 1;
         edtavCregistroinvitadoemail_Jsonclick = "";
         edtavCregistroinvitadoemail_Enabled = 1;
         edtavCregistroinvitadoemail_Visible = 1;
         edtavCregistroinvitadousuario_Jsonclick = "";
         edtavCregistroinvitadousuario_Enabled = 1;
         edtavCregistroinvitadousuario_Visible = 1;
         edtavCregistroinvitadoid_Jsonclick = "";
         edtavCregistroinvitadoid_Enabled = 1;
         edtavCregistroinvitadoid_Visible = 1;
         edtavCtableroid_Jsonclick = "";
         edtavCtableroid_Enabled = 1;
         edtavCtableroid_Visible = 1;
         divRegistroinvitadofechafiltercontainer_Class = "AdvancedContainerItem";
         divInvitadorolidfiltercontainer_Class = "AdvancedContainerItem";
         divRegistroinvitadoemailfiltercontainer_Class = "AdvancedContainerItem";
         divRegistroinvitadousuariofiltercontainer_Class = "AdvancedContainerItem";
         divRegistroinvitadoidfiltercontainer_Class = "AdvancedContainerItem";
         divTableroidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List  T10";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cRegistroInvitadoId',fld:'vCREGISTROINVITADOID',pic:'ZZZ9'},{av:'AV8cRegistroInvitadoUsuario',fld:'vCREGISTROINVITADOUSUARIO',pic:'ZZZ9'},{av:'AV9cRegistroInvitadoEmail',fld:'vCREGISTROINVITADOEMAIL',pic:''},{av:'AV10cInvitadoRolId',fld:'vCINVITADOROLID',pic:'ZZZ9'},{av:'AV11cRegistroInvitadoFecha',fld:'vCREGISTROINVITADOFECHA',pic:'99/99/99 99:99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E170R1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLTABLEROIDFILTER.CLICK","{handler:'E110R1',iparms:[{av:'divTableroidfiltercontainer_Class',ctrl:'TABLEROIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTABLEROIDFILTER.CLICK",",oparms:[{av:'divTableroidfiltercontainer_Class',ctrl:'TABLEROIDFILTERCONTAINER',prop:'Class'},{av:'edtavCtableroid_Visible',ctrl:'vCTABLEROID',prop:'Visible'}]}");
         setEventMetadata("LBLREGISTROINVITADOIDFILTER.CLICK","{handler:'E120R1',iparms:[{av:'divRegistroinvitadoidfiltercontainer_Class',ctrl:'REGISTROINVITADOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLREGISTROINVITADOIDFILTER.CLICK",",oparms:[{av:'divRegistroinvitadoidfiltercontainer_Class',ctrl:'REGISTROINVITADOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCregistroinvitadoid_Visible',ctrl:'vCREGISTROINVITADOID',prop:'Visible'}]}");
         setEventMetadata("LBLREGISTROINVITADOUSUARIOFILTER.CLICK","{handler:'E130R1',iparms:[{av:'divRegistroinvitadousuariofiltercontainer_Class',ctrl:'REGISTROINVITADOUSUARIOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLREGISTROINVITADOUSUARIOFILTER.CLICK",",oparms:[{av:'divRegistroinvitadousuariofiltercontainer_Class',ctrl:'REGISTROINVITADOUSUARIOFILTERCONTAINER',prop:'Class'},{av:'edtavCregistroinvitadousuario_Visible',ctrl:'vCREGISTROINVITADOUSUARIO',prop:'Visible'}]}");
         setEventMetadata("LBLREGISTROINVITADOEMAILFILTER.CLICK","{handler:'E140R1',iparms:[{av:'divRegistroinvitadoemailfiltercontainer_Class',ctrl:'REGISTROINVITADOEMAILFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLREGISTROINVITADOEMAILFILTER.CLICK",",oparms:[{av:'divRegistroinvitadoemailfiltercontainer_Class',ctrl:'REGISTROINVITADOEMAILFILTERCONTAINER',prop:'Class'},{av:'edtavCregistroinvitadoemail_Visible',ctrl:'vCREGISTROINVITADOEMAIL',prop:'Visible'}]}");
         setEventMetadata("LBLINVITADOROLIDFILTER.CLICK","{handler:'E150R1',iparms:[{av:'divInvitadorolidfiltercontainer_Class',ctrl:'INVITADOROLIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVITADOROLIDFILTER.CLICK",",oparms:[{av:'divInvitadorolidfiltercontainer_Class',ctrl:'INVITADOROLIDFILTERCONTAINER',prop:'Class'},{av:'edtavCinvitadorolid_Visible',ctrl:'vCINVITADOROLID',prop:'Visible'}]}");
         setEventMetadata("LBLREGISTROINVITADOFECHAFILTER.CLICK","{handler:'E160R1',iparms:[{av:'divRegistroinvitadofechafiltercontainer_Class',ctrl:'REGISTROINVITADOFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLREGISTROINVITADOFECHAFILTER.CLICK",",oparms:[{av:'divRegistroinvitadofechafiltercontainer_Class',ctrl:'REGISTROINVITADOFECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("ENTER","{handler:'E200R2',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9',hsh:true},{av:'A40RegistroInvitadoId',fld:'REGISTROINVITADOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pTableroId',fld:'vPTABLEROID',pic:'ZZZ9'},{av:'AV13pRegistroInvitadoId',fld:'vPREGISTROINVITADOID',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cRegistroInvitadoId',fld:'vCREGISTROINVITADOID',pic:'ZZZ9'},{av:'AV8cRegistroInvitadoUsuario',fld:'vCREGISTROINVITADOUSUARIO',pic:'ZZZ9'},{av:'AV9cRegistroInvitadoEmail',fld:'vCREGISTROINVITADOEMAIL',pic:''},{av:'AV10cInvitadoRolId',fld:'vCINVITADOROLID',pic:'ZZZ9'},{av:'AV11cRegistroInvitadoFecha',fld:'vCREGISTROINVITADOFECHA',pic:'99/99/99 99:99'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cRegistroInvitadoId',fld:'vCREGISTROINVITADOID',pic:'ZZZ9'},{av:'AV8cRegistroInvitadoUsuario',fld:'vCREGISTROINVITADOUSUARIO',pic:'ZZZ9'},{av:'AV9cRegistroInvitadoEmail',fld:'vCREGISTROINVITADOEMAIL',pic:''},{av:'AV10cInvitadoRolId',fld:'vCINVITADOROLID',pic:'ZZZ9'},{av:'AV11cRegistroInvitadoFecha',fld:'vCREGISTROINVITADOFECHA',pic:'99/99/99 99:99'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cRegistroInvitadoId',fld:'vCREGISTROINVITADOID',pic:'ZZZ9'},{av:'AV8cRegistroInvitadoUsuario',fld:'vCREGISTROINVITADOUSUARIO',pic:'ZZZ9'},{av:'AV9cRegistroInvitadoEmail',fld:'vCREGISTROINVITADOEMAIL',pic:''},{av:'AV10cInvitadoRolId',fld:'vCINVITADOROLID',pic:'ZZZ9'},{av:'AV11cRegistroInvitadoFecha',fld:'vCREGISTROINVITADOFECHA',pic:'99/99/99 99:99'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTableroId',fld:'vCTABLEROID',pic:'ZZZ9'},{av:'AV7cRegistroInvitadoId',fld:'vCREGISTROINVITADOID',pic:'ZZZ9'},{av:'AV8cRegistroInvitadoUsuario',fld:'vCREGISTROINVITADOUSUARIO',pic:'ZZZ9'},{av:'AV9cRegistroInvitadoEmail',fld:'vCREGISTROINVITADOEMAIL',pic:''},{av:'AV10cInvitadoRolId',fld:'vCINVITADOROLID',pic:'ZZZ9'},{av:'AV11cRegistroInvitadoFecha',fld:'vCREGISTROINVITADOFECHA',pic:'99/99/99 99:99'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CREGISTROINVITADOEMAIL","{handler:'Validv_Cregistroinvitadoemail',iparms:[]");
         setEventMetadata("VALIDV_CREGISTROINVITADOEMAIL",",oparms:[]}");
         setEventMetadata("VALIDV_CREGISTROINVITADOFECHA","{handler:'Validv_Cregistroinvitadofecha',iparms:[]");
         setEventMetadata("VALIDV_CREGISTROINVITADOFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Registroinvitadofecha',iparms:[]");
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
         AV9cRegistroInvitadoEmail = "";
         AV11cRegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLbltableroidfilter_Jsonclick = "";
         TempTags = "";
         lblLblregistroinvitadoidfilter_Jsonclick = "";
         lblLblregistroinvitadousuariofilter_Jsonclick = "";
         lblLblregistroinvitadoemailfilter_Jsonclick = "";
         lblLblinvitadorolidfilter_Jsonclick = "";
         lblLblregistroinvitadofechafilter_Jsonclick = "";
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
         A45RegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV9cRegistroInvitadoEmail = "";
         A44RegistroInvitadoEmail = "";
         H000R2_A44RegistroInvitadoEmail = new string[] {""} ;
         H000R2_A45RegistroInvitadoFecha = new DateTime[] {DateTime.MinValue} ;
         H000R2_A41InvitadoRolId = new short[1] ;
         H000R2_A43RegistroInvitadoUsuario = new short[1] ;
         H000R2_A40RegistroInvitadoId = new short[1] ;
         H000R2_A9TableroId = new short[1] ;
         H000R3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00c0__default(),
            new Object[][] {
                new Object[] {
               H000R2_A44RegistroInvitadoEmail, H000R2_A45RegistroInvitadoFecha, H000R2_A41InvitadoRolId, H000R2_A43RegistroInvitadoUsuario, H000R2_A40RegistroInvitadoId, H000R2_A9TableroId
               }
               , new Object[] {
               H000R3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12pTableroId ;
      private short AV13pRegistroInvitadoId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cTableroId ;
      private short AV7cRegistroInvitadoId ;
      private short AV8cRegistroInvitadoUsuario ;
      private short AV10cInvitadoRolId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A9TableroId ;
      private short A40RegistroInvitadoId ;
      private short A43RegistroInvitadoUsuario ;
      private short A41InvitadoRolId ;
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
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCtableroid_Enabled ;
      private int edtavCtableroid_Visible ;
      private int edtavCregistroinvitadoid_Enabled ;
      private int edtavCregistroinvitadoid_Visible ;
      private int edtavCregistroinvitadousuario_Enabled ;
      private int edtavCregistroinvitadousuario_Visible ;
      private int edtavCregistroinvitadoemail_Visible ;
      private int edtavCregistroinvitadoemail_Enabled ;
      private int edtavCinvitadorolid_Enabled ;
      private int edtavCinvitadorolid_Visible ;
      private int edtavCregistroinvitadofecha_Enabled ;
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
      private string divRegistroinvitadoidfiltercontainer_Class ;
      private string divRegistroinvitadousuariofiltercontainer_Class ;
      private string divRegistroinvitadoemailfiltercontainer_Class ;
      private string divInvitadorolidfiltercontainer_Class ;
      private string divRegistroinvitadofechafiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
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
      private string divRegistroinvitadoidfiltercontainer_Internalname ;
      private string lblLblregistroinvitadoidfilter_Internalname ;
      private string lblLblregistroinvitadoidfilter_Jsonclick ;
      private string edtavCregistroinvitadoid_Internalname ;
      private string edtavCregistroinvitadoid_Jsonclick ;
      private string divRegistroinvitadousuariofiltercontainer_Internalname ;
      private string lblLblregistroinvitadousuariofilter_Internalname ;
      private string lblLblregistroinvitadousuariofilter_Jsonclick ;
      private string edtavCregistroinvitadousuario_Internalname ;
      private string edtavCregistroinvitadousuario_Jsonclick ;
      private string divRegistroinvitadoemailfiltercontainer_Internalname ;
      private string lblLblregistroinvitadoemailfilter_Internalname ;
      private string lblLblregistroinvitadoemailfilter_Jsonclick ;
      private string edtavCregistroinvitadoemail_Internalname ;
      private string edtavCregistroinvitadoemail_Jsonclick ;
      private string divInvitadorolidfiltercontainer_Internalname ;
      private string lblLblinvitadorolidfilter_Internalname ;
      private string lblLblinvitadorolidfilter_Jsonclick ;
      private string edtavCinvitadorolid_Internalname ;
      private string edtavCinvitadorolid_Jsonclick ;
      private string divRegistroinvitadofechafiltercontainer_Internalname ;
      private string lblLblregistroinvitadofechafilter_Internalname ;
      private string lblLblregistroinvitadofechafilter_Jsonclick ;
      private string edtavCregistroinvitadofecha_Internalname ;
      private string edtavCregistroinvitadofecha_Jsonclick ;
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
      private string edtRegistroInvitadoId_Internalname ;
      private string edtRegistroInvitadoUsuario_Internalname ;
      private string edtInvitadoRolId_Internalname ;
      private string edtRegistroInvitadoFecha_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtTableroId_Jsonclick ;
      private string edtRegistroInvitadoId_Jsonclick ;
      private string edtRegistroInvitadoUsuario_Jsonclick ;
      private string edtInvitadoRolId_Jsonclick ;
      private string edtRegistroInvitadoFecha_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV11cRegistroInvitadoFecha ;
      private DateTime A45RegistroInvitadoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV9cRegistroInvitadoEmail ;
      private string AV17Linkselection_GXI ;
      private string lV9cRegistroInvitadoEmail ;
      private string A44RegistroInvitadoEmail ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000R2_A44RegistroInvitadoEmail ;
      private DateTime[] H000R2_A45RegistroInvitadoFecha ;
      private short[] H000R2_A41InvitadoRolId ;
      private short[] H000R2_A43RegistroInvitadoUsuario ;
      private short[] H000R2_A40RegistroInvitadoId ;
      private short[] H000R2_A9TableroId ;
      private long[] H000R3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pTableroId ;
      private short aP1_pRegistroInvitadoId ;
      private GXWebForm Form ;
   }

   public class gx00c0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000R2( IGxContext context ,
                                             short AV8cRegistroInvitadoUsuario ,
                                             string AV9cRegistroInvitadoEmail ,
                                             short AV10cInvitadoRolId ,
                                             DateTime AV11cRegistroInvitadoFecha ,
                                             short A43RegistroInvitadoUsuario ,
                                             string A44RegistroInvitadoEmail ,
                                             short A41InvitadoRolId ,
                                             DateTime A45RegistroInvitadoFecha ,
                                             short AV6cTableroId ,
                                             short AV7cRegistroInvitadoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [RegistroInvitadoEmail], [RegistroInvitadoFecha], [InvitadoRolId], [RegistroInvitadoUsuario], [RegistroInvitadoId], [TableroId]";
         sFromString = " FROM [Invitados]";
         sOrderString = "";
         AddWhere(sWhereString, "([TableroId] >= @AV6cTableroId and [RegistroInvitadoId] >= @AV7cRegistroInvitadoId)");
         if ( ! (0==AV8cRegistroInvitadoUsuario) )
         {
            AddWhere(sWhereString, "([RegistroInvitadoUsuario] >= @AV8cRegistroInvitadoUsuario)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cRegistroInvitadoEmail)) )
         {
            AddWhere(sWhereString, "([RegistroInvitadoEmail] like @lV9cRegistroInvitadoEmail)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cInvitadoRolId) )
         {
            AddWhere(sWhereString, "([InvitadoRolId] >= @AV10cInvitadoRolId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cRegistroInvitadoFecha) )
         {
            AddWhere(sWhereString, "([RegistroInvitadoFecha] >= @AV11cRegistroInvitadoFecha)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [TableroId], [RegistroInvitadoId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000R3( IGxContext context ,
                                             short AV8cRegistroInvitadoUsuario ,
                                             string AV9cRegistroInvitadoEmail ,
                                             short AV10cInvitadoRolId ,
                                             DateTime AV11cRegistroInvitadoFecha ,
                                             short A43RegistroInvitadoUsuario ,
                                             string A44RegistroInvitadoEmail ,
                                             short A41InvitadoRolId ,
                                             DateTime A45RegistroInvitadoFecha ,
                                             short AV6cTableroId ,
                                             short AV7cRegistroInvitadoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Invitados]";
         AddWhere(sWhereString, "([TableroId] >= @AV6cTableroId and [RegistroInvitadoId] >= @AV7cRegistroInvitadoId)");
         if ( ! (0==AV8cRegistroInvitadoUsuario) )
         {
            AddWhere(sWhereString, "([RegistroInvitadoUsuario] >= @AV8cRegistroInvitadoUsuario)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cRegistroInvitadoEmail)) )
         {
            AddWhere(sWhereString, "([RegistroInvitadoEmail] like @lV9cRegistroInvitadoEmail)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cInvitadoRolId) )
         {
            AddWhere(sWhereString, "([InvitadoRolId] >= @AV10cInvitadoRolId)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cRegistroInvitadoFecha) )
         {
            AddWhere(sWhereString, "([RegistroInvitadoFecha] >= @AV11cRegistroInvitadoFecha)");
         }
         else
         {
            GXv_int3[5] = 1;
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
                     return conditional_H000R2(context, (short)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (DateTime)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] );
               case 1 :
                     return conditional_H000R3(context, (short)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (DateTime)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] );
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
          Object[] prmH000R2;
          prmH000R2 = new Object[] {
          new ParDef("@AV6cTableroId",GXType.Int16,4,0) ,
          new ParDef("@AV7cRegistroInvitadoId",GXType.Int16,4,0) ,
          new ParDef("@AV8cRegistroInvitadoUsuario",GXType.Int16,4,0) ,
          new ParDef("@lV9cRegistroInvitadoEmail",GXType.NVarChar,100,0) ,
          new ParDef("@AV10cInvitadoRolId",GXType.Int16,4,0) ,
          new ParDef("@AV11cRegistroInvitadoFecha",GXType.DateTime,8,5) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000R3;
          prmH000R3 = new Object[] {
          new ParDef("@AV6cTableroId",GXType.Int16,4,0) ,
          new ParDef("@AV7cRegistroInvitadoId",GXType.Int16,4,0) ,
          new ParDef("@AV8cRegistroInvitadoUsuario",GXType.Int16,4,0) ,
          new ParDef("@lV9cRegistroInvitadoEmail",GXType.NVarChar,100,0) ,
          new ParDef("@AV10cInvitadoRolId",GXType.Int16,4,0) ,
          new ParDef("@AV11cRegistroInvitadoFecha",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H000R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000R2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000R3,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
