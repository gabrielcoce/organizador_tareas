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
   public class centropruebas : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public centropruebas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public centropruebas( IGxContext context )
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
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
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
         PA132( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START132( ) ;
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("centropruebas.aspx") +"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
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
            WE132( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT132( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("centropruebas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CentroPruebas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Centro Pruebas" ;
      }

      protected void WB130( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "TableWidget", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Pruebas para obtener ID", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTableroid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTableroid_Internalname, "Tablero Id", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTableroid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5TableroId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavTableroid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5TableroId), "ZZZ9") : context.localUtil.Format( (decimal)(AV5TableroId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTableroid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTableroid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTareaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTareaid_Internalname, "Tarea Id", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTareaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6TareaId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavTareaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6TareaId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6TareaId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTareaid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTareaid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavActividadid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavActividadid_Internalname, "Actividad Id", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavActividadid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ActividadId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavActividadid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7ActividadId), "ZZZ9") : context.localUtil.Format( (decimal)(AV7ActividadId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavActividadid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavActividadid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavComentarioid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavComentarioid_Internalname, "Comentario Id", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavComentarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ComentarioId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavComentarioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8ComentarioId), "ZZZ9") : context.localUtil.Format( (decimal)(AV8ComentarioId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComentarioid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavComentarioid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuarioid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarioid_Internalname, "Usuario Id", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9UsuarioId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavUsuarioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9UsuarioId), "ZZZ9") : context.localUtil.Format( (decimal)(AV9UsuarioId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarioid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuarioid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "TableWhite", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttObtener_Internalname, "", "Prueba1", bttObtener_Jsonclick, 5, "Prueba1", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'PRUEBA1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavValor1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValor1_Internalname, "ID Tablero", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValor1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10valor1), 4, 0, ",", "")), StringUtil.LTrim( ((edtavValor1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10valor1), "ZZZ9") : context.localUtil.Format( (decimal)(AV10valor1), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValor1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavValor1_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttObtener1_Internalname, "", "Prueba2", bttObtener1_Jsonclick, 5, "Prueba2", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'PRUEBA2\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavValor2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValor2_Internalname, "ID Tarea", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValor2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11valor2), 4, 0, ",", "")), StringUtil.LTrim( ((edtavValor2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11valor2), "ZZZ9") : context.localUtil.Format( (decimal)(AV11valor2), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValor2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavValor2_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttObtener2_Internalname, "", "Prueba3", bttObtener2_Jsonclick, 5, "Prueba3", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'PRUEBA3\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavValor3_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValor3_Internalname, "ID Actividad", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValor3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12valor3), 4, 0, ",", "")), StringUtil.LTrim( ((edtavValor3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12valor3), "ZZZ9") : context.localUtil.Format( (decimal)(AV12valor3), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValor3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavValor3_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttObtener3_Internalname, "", "Prueba4", bttObtener3_Jsonclick, 5, "Prueba4", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'PRUEBA4\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavValor4_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValor4_Internalname, "ID Comentario", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValor4_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13valor4), 4, 0, ",", "")), StringUtil.LTrim( ((edtavValor4_Enabled!=0) ? context.localUtil.Format( (decimal)(AV13valor4), "ZZZ9") : context.localUtil.Format( (decimal)(AV13valor4), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValor4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavValor4_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttObtener4_Internalname, "", "Prueba5", bttObtener4_Jsonclick, 5, "Prueba5", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'PRUEBA5\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavValor5_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValor5_Internalname, "ID Usuario", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValor5_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14valor5), 4, 0, ",", "")), StringUtil.LTrim( ((edtavValor5_Enabled!=0) ? context.localUtil.Format( (decimal)(AV14valor5), "ZZZ9") : context.localUtil.Format( (decimal)(AV14valor5), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValor5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavValor5_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Interfaces Tablero Usuarios", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "TableWhite", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttPrueba6_Internalname, "", "Prueba6", bttPrueba6_Jsonclick, 5, "Prueba6", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'PRUEBA6\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavValor6_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValor6_Internalname, "valor6", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValor6_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15valor6), 4, 0, ",", "")), StringUtil.LTrim( ((edtavValor6_Enabled!=0) ? context.localUtil.Format( (decimal)(AV15valor6), "ZZZ9") : context.localUtil.Format( (decimal)(AV15valor6), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValor6_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavValor6_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CentroPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START132( )
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
            Form.Meta.addItem("description", "Centro Pruebas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP130( ) ;
      }

      protected void WS132( )
      {
         START132( ) ;
         EVT132( ) ;
      }

      protected void EVT132( )
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
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PRUEBA1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Prueba1' */
                              E11132 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PRUEBA2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Prueba2' */
                              E12132 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PRUEBA3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Prueba3' */
                              E13132 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PRUEBA4'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Prueba4' */
                              E14132 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PRUEBA5'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Prueba5' */
                              E15132 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PRUEBA6'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Prueba6' */
                              E16132 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E17132 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE132( )
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

      protected void PA132( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
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
               GX_FocusControl = edtavTableroid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         RF132( ) ;
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

      protected void RF132( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E17132 ();
            WB130( ) ;
         }
      }

      protected void send_integrity_lvl_hashes132( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP130( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTableroid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTableroid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTABLEROID");
               GX_FocusControl = edtavTableroid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5TableroId = 0;
               AssignAttri("", false, "AV5TableroId", StringUtil.LTrimStr( (decimal)(AV5TableroId), 4, 0));
            }
            else
            {
               AV5TableroId = (short)(context.localUtil.CToN( cgiGet( edtavTableroid_Internalname), ",", "."));
               AssignAttri("", false, "AV5TableroId", StringUtil.LTrimStr( (decimal)(AV5TableroId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTareaid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTareaid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTAREAID");
               GX_FocusControl = edtavTareaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6TareaId = 0;
               AssignAttri("", false, "AV6TareaId", StringUtil.LTrimStr( (decimal)(AV6TareaId), 4, 0));
            }
            else
            {
               AV6TareaId = (short)(context.localUtil.CToN( cgiGet( edtavTareaid_Internalname), ",", "."));
               AssignAttri("", false, "AV6TareaId", StringUtil.LTrimStr( (decimal)(AV6TareaId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavActividadid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavActividadid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vACTIVIDADID");
               GX_FocusControl = edtavActividadid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7ActividadId = 0;
               AssignAttri("", false, "AV7ActividadId", StringUtil.LTrimStr( (decimal)(AV7ActividadId), 4, 0));
            }
            else
            {
               AV7ActividadId = (short)(context.localUtil.CToN( cgiGet( edtavActividadid_Internalname), ",", "."));
               AssignAttri("", false, "AV7ActividadId", StringUtil.LTrimStr( (decimal)(AV7ActividadId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavComentarioid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavComentarioid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOMENTARIOID");
               GX_FocusControl = edtavComentarioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8ComentarioId = 0;
               AssignAttri("", false, "AV8ComentarioId", StringUtil.LTrimStr( (decimal)(AV8ComentarioId), 4, 0));
            }
            else
            {
               AV8ComentarioId = (short)(context.localUtil.CToN( cgiGet( edtavComentarioid_Internalname), ",", "."));
               AssignAttri("", false, "AV8ComentarioId", StringUtil.LTrimStr( (decimal)(AV8ComentarioId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuarioid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuarioid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSUARIOID");
               GX_FocusControl = edtavUsuarioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9UsuarioId = 0;
               AssignAttri("", false, "AV9UsuarioId", StringUtil.LTrimStr( (decimal)(AV9UsuarioId), 4, 0));
            }
            else
            {
               AV9UsuarioId = (short)(context.localUtil.CToN( cgiGet( edtavUsuarioid_Internalname), ",", "."));
               AssignAttri("", false, "AV9UsuarioId", StringUtil.LTrimStr( (decimal)(AV9UsuarioId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValor1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValor1_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALOR1");
               GX_FocusControl = edtavValor1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10valor1 = 0;
               AssignAttri("", false, "AV10valor1", StringUtil.LTrimStr( (decimal)(AV10valor1), 4, 0));
            }
            else
            {
               AV10valor1 = (short)(context.localUtil.CToN( cgiGet( edtavValor1_Internalname), ",", "."));
               AssignAttri("", false, "AV10valor1", StringUtil.LTrimStr( (decimal)(AV10valor1), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValor2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValor2_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALOR2");
               GX_FocusControl = edtavValor2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11valor2 = 0;
               AssignAttri("", false, "AV11valor2", StringUtil.LTrimStr( (decimal)(AV11valor2), 4, 0));
            }
            else
            {
               AV11valor2 = (short)(context.localUtil.CToN( cgiGet( edtavValor2_Internalname), ",", "."));
               AssignAttri("", false, "AV11valor2", StringUtil.LTrimStr( (decimal)(AV11valor2), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValor3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValor3_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALOR3");
               GX_FocusControl = edtavValor3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12valor3 = 0;
               AssignAttri("", false, "AV12valor3", StringUtil.LTrimStr( (decimal)(AV12valor3), 4, 0));
            }
            else
            {
               AV12valor3 = (short)(context.localUtil.CToN( cgiGet( edtavValor3_Internalname), ",", "."));
               AssignAttri("", false, "AV12valor3", StringUtil.LTrimStr( (decimal)(AV12valor3), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValor4_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValor4_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALOR4");
               GX_FocusControl = edtavValor4_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13valor4 = 0;
               AssignAttri("", false, "AV13valor4", StringUtil.LTrimStr( (decimal)(AV13valor4), 4, 0));
            }
            else
            {
               AV13valor4 = (short)(context.localUtil.CToN( cgiGet( edtavValor4_Internalname), ",", "."));
               AssignAttri("", false, "AV13valor4", StringUtil.LTrimStr( (decimal)(AV13valor4), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValor5_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValor5_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALOR5");
               GX_FocusControl = edtavValor5_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14valor5 = 0;
               AssignAttri("", false, "AV14valor5", StringUtil.LTrimStr( (decimal)(AV14valor5), 4, 0));
            }
            else
            {
               AV14valor5 = (short)(context.localUtil.CToN( cgiGet( edtavValor5_Internalname), ",", "."));
               AssignAttri("", false, "AV14valor5", StringUtil.LTrimStr( (decimal)(AV14valor5), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValor6_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValor6_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALOR6");
               GX_FocusControl = edtavValor6_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15valor6 = 0;
               AssignAttri("", false, "AV15valor6", StringUtil.LTrimStr( (decimal)(AV15valor6), 4, 0));
            }
            else
            {
               AV15valor6 = (short)(context.localUtil.CToN( cgiGet( edtavValor6_Internalname), ",", "."));
               AssignAttri("", false, "AV15valor6", StringUtil.LTrimStr( (decimal)(AV15valor6), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E11132( )
      {
         /* 'Prueba1' Routine */
         returnInSub = false;
         GXt_int1 = AV10valor1;
         new gettableroid(context ).execute( out  GXt_int1) ;
         AV10valor1 = GXt_int1;
         AssignAttri("", false, "AV10valor1", StringUtil.LTrimStr( (decimal)(AV10valor1), 4, 0));
         /*  Sending Event outputs  */
      }

      protected void E12132( )
      {
         /* 'Prueba2' Routine */
         returnInSub = false;
         GXt_int1 = AV11valor2;
         new gettareaid(context ).execute( ref  AV5TableroId, out  GXt_int1) ;
         AssignAttri("", false, "AV5TableroId", StringUtil.LTrimStr( (decimal)(AV5TableroId), 4, 0));
         AV11valor2 = GXt_int1;
         AssignAttri("", false, "AV11valor2", StringUtil.LTrimStr( (decimal)(AV11valor2), 4, 0));
         /*  Sending Event outputs  */
      }

      protected void E13132( )
      {
         /* 'Prueba3' Routine */
         returnInSub = false;
         GXt_int1 = AV12valor3;
         new getactividadid(context ).execute( ref  AV5TableroId, ref  AV6TareaId, out  GXt_int1) ;
         AssignAttri("", false, "AV5TableroId", StringUtil.LTrimStr( (decimal)(AV5TableroId), 4, 0));
         AssignAttri("", false, "AV6TareaId", StringUtil.LTrimStr( (decimal)(AV6TareaId), 4, 0));
         AV12valor3 = GXt_int1;
         AssignAttri("", false, "AV12valor3", StringUtil.LTrimStr( (decimal)(AV12valor3), 4, 0));
         /*  Sending Event outputs  */
      }

      protected void E14132( )
      {
         /* 'Prueba4' Routine */
         returnInSub = false;
         GXt_int1 = AV13valor4;
         new getcomentarioid(context ).execute( ref  AV5TableroId, ref  AV6TareaId, ref  GXt_int1) ;
         AssignAttri("", false, "AV5TableroId", StringUtil.LTrimStr( (decimal)(AV5TableroId), 4, 0));
         AssignAttri("", false, "AV6TareaId", StringUtil.LTrimStr( (decimal)(AV6TareaId), 4, 0));
         AV13valor4 = GXt_int1;
         AssignAttri("", false, "AV13valor4", StringUtil.LTrimStr( (decimal)(AV13valor4), 4, 0));
         /*  Sending Event outputs  */
      }

      protected void E15132( )
      {
         /* 'Prueba5' Routine */
         returnInSub = false;
         GXt_int1 = AV14valor5;
         new getusuarioid(context ).execute( out  GXt_int1) ;
         AV14valor5 = GXt_int1;
         AssignAttri("", false, "AV14valor5", StringUtil.LTrimStr( (decimal)(AV14valor5), 4, 0));
         /*  Sending Event outputs  */
      }

      protected void E16132( )
      {
         /* 'Prueba6' Routine */
         returnInSub = false;
         GXt_int1 = AV15valor6;
         new getnumerointegrantes(context ).execute(  AV5TableroId, out  GXt_int1) ;
         AV15valor6 = GXt_int1;
         AssignAttri("", false, "AV15valor6", StringUtil.LTrimStr( (decimal)(AV15valor6), 4, 0));
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E17132( )
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
         PA132( ) ;
         WS132( ) ;
         WE132( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202210161311926", true, true);
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
         context.AddJavascriptSource("centropruebas.js", "?202210161311927", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavTableroid_Internalname = "vTABLEROID";
         edtavTareaid_Internalname = "vTAREAID";
         edtavActividadid_Internalname = "vACTIVIDADID";
         edtavComentarioid_Internalname = "vCOMENTARIOID";
         edtavUsuarioid_Internalname = "vUSUARIOID";
         bttObtener_Internalname = "OBTENER";
         edtavValor1_Internalname = "vVALOR1";
         bttObtener1_Internalname = "OBTENER1";
         edtavValor2_Internalname = "vVALOR2";
         bttObtener2_Internalname = "OBTENER2";
         edtavValor3_Internalname = "vVALOR3";
         bttObtener3_Internalname = "OBTENER3";
         edtavValor4_Internalname = "vVALOR4";
         bttObtener4_Internalname = "OBTENER4";
         edtavValor5_Internalname = "vVALOR5";
         divTable2_Internalname = "TABLE2";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         bttPrueba6_Internalname = "PRUEBA6";
         edtavValor6_Internalname = "vVALOR6";
         divTable3_Internalname = "TABLE3";
         divTable1_Internalname = "TABLE1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavValor6_Jsonclick = "";
         edtavValor6_Enabled = 1;
         edtavValor5_Jsonclick = "";
         edtavValor5_Enabled = 1;
         edtavValor4_Jsonclick = "";
         edtavValor4_Enabled = 1;
         edtavValor3_Jsonclick = "";
         edtavValor3_Enabled = 1;
         edtavValor2_Jsonclick = "";
         edtavValor2_Enabled = 1;
         edtavValor1_Jsonclick = "";
         edtavValor1_Enabled = 1;
         edtavUsuarioid_Jsonclick = "";
         edtavUsuarioid_Enabled = 1;
         edtavComentarioid_Jsonclick = "";
         edtavComentarioid_Enabled = 1;
         edtavActividadid_Jsonclick = "";
         edtavActividadid_Enabled = 1;
         edtavTareaid_Jsonclick = "";
         edtavTareaid_Enabled = 1;
         edtavTableroid_Jsonclick = "";
         edtavTableroid_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Centro Pruebas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'PRUEBA1'","{handler:'E11132',iparms:[]");
         setEventMetadata("'PRUEBA1'",",oparms:[{av:'AV10valor1',fld:'vVALOR1',pic:'ZZZ9'}]}");
         setEventMetadata("'PRUEBA2'","{handler:'E12132',iparms:[{av:'AV5TableroId',fld:'vTABLEROID',pic:'ZZZ9'}]");
         setEventMetadata("'PRUEBA2'",",oparms:[{av:'AV11valor2',fld:'vVALOR2',pic:'ZZZ9'}]}");
         setEventMetadata("'PRUEBA3'","{handler:'E13132',iparms:[{av:'AV5TableroId',fld:'vTABLEROID',pic:'ZZZ9'},{av:'AV6TareaId',fld:'vTAREAID',pic:'ZZZ9'}]");
         setEventMetadata("'PRUEBA3'",",oparms:[{av:'AV12valor3',fld:'vVALOR3',pic:'ZZZ9'}]}");
         setEventMetadata("'PRUEBA4'","{handler:'E14132',iparms:[{av:'AV5TableroId',fld:'vTABLEROID',pic:'ZZZ9'},{av:'AV6TareaId',fld:'vTAREAID',pic:'ZZZ9'}]");
         setEventMetadata("'PRUEBA4'",",oparms:[{av:'AV13valor4',fld:'vVALOR4',pic:'ZZZ9'}]}");
         setEventMetadata("'PRUEBA5'","{handler:'E15132',iparms:[]");
         setEventMetadata("'PRUEBA5'",",oparms:[{av:'AV14valor5',fld:'vVALOR5',pic:'ZZZ9'}]}");
         setEventMetadata("'PRUEBA6'","{handler:'E16132',iparms:[{av:'AV5TableroId',fld:'vTABLEROID',pic:'ZZZ9'}]");
         setEventMetadata("'PRUEBA6'",",oparms:[{av:'AV15valor6',fld:'vVALOR6',pic:'ZZZ9'}]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttObtener_Jsonclick = "";
         bttObtener1_Jsonclick = "";
         bttObtener2_Jsonclick = "";
         bttObtener3_Jsonclick = "";
         bttObtener4_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         bttPrueba6_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV5TableroId ;
      private short AV6TareaId ;
      private short AV7ActividadId ;
      private short AV8ComentarioId ;
      private short AV9UsuarioId ;
      private short AV10valor1 ;
      private short AV11valor2 ;
      private short AV12valor3 ;
      private short AV13valor4 ;
      private short AV14valor5 ;
      private short AV15valor6 ;
      private short nDonePA ;
      private short GXt_int1 ;
      private short nGXWrapped ;
      private int edtavTableroid_Enabled ;
      private int edtavTareaid_Enabled ;
      private int edtavActividadid_Enabled ;
      private int edtavComentarioid_Enabled ;
      private int edtavUsuarioid_Enabled ;
      private int edtavValor1_Enabled ;
      private int edtavValor2_Enabled ;
      private int edtavValor3_Enabled ;
      private int edtavValor4_Enabled ;
      private int edtavValor5_Enabled ;
      private int edtavValor6_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string edtavTableroid_Internalname ;
      private string TempTags ;
      private string edtavTableroid_Jsonclick ;
      private string edtavTareaid_Internalname ;
      private string edtavTareaid_Jsonclick ;
      private string edtavActividadid_Internalname ;
      private string edtavActividadid_Jsonclick ;
      private string edtavComentarioid_Internalname ;
      private string edtavComentarioid_Jsonclick ;
      private string edtavUsuarioid_Internalname ;
      private string edtavUsuarioid_Jsonclick ;
      private string divTable2_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttObtener_Internalname ;
      private string bttObtener_Jsonclick ;
      private string edtavValor1_Internalname ;
      private string edtavValor1_Jsonclick ;
      private string bttObtener1_Internalname ;
      private string bttObtener1_Jsonclick ;
      private string edtavValor2_Internalname ;
      private string edtavValor2_Jsonclick ;
      private string bttObtener2_Internalname ;
      private string bttObtener2_Jsonclick ;
      private string edtavValor3_Internalname ;
      private string edtavValor3_Jsonclick ;
      private string bttObtener3_Internalname ;
      private string bttObtener3_Jsonclick ;
      private string edtavValor4_Internalname ;
      private string edtavValor4_Jsonclick ;
      private string bttObtener4_Internalname ;
      private string bttObtener4_Jsonclick ;
      private string edtavValor5_Internalname ;
      private string edtavValor5_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string divTable3_Internalname ;
      private string bttPrueba6_Internalname ;
      private string bttPrueba6_Jsonclick ;
      private string edtavValor6_Internalname ;
      private string edtavValor6_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

}
