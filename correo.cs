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
   public class correo : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_11-163677", 0) ;
            }
            Form.Meta.addItem("description", "Correo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCorreoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public correo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public correo( IGxContext context )
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

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Correo", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00d0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CORREOID"+"'), id:'"+"CORREOID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorreoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorreoId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorreoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A50CorreoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtCorreoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A50CorreoId), "ZZZ9") : context.localUtil.Format( (decimal)(A50CorreoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorreoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorreoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorreoIdentificador_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorreoIdentificador_Internalname, "Identificador", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorreoIdentificador_Internalname, StringUtil.RTrim( A51CorreoIdentificador), StringUtil.RTrim( context.localUtil.Format( A51CorreoIdentificador, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorreoIdentificador_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorreoIdentificador_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorreoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorreoNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorreoNombre_Internalname, StringUtil.RTrim( A52CorreoNombre), StringUtil.RTrim( context.localUtil.Format( A52CorreoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorreoNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorreoNombre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorreoServidor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorreoServidor_Internalname, "Servidor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorreoServidor_Internalname, StringUtil.RTrim( A53CorreoServidor), StringUtil.RTrim( context.localUtil.Format( A53CorreoServidor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorreoServidor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorreoServidor_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorreoPuerto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorreoPuerto_Internalname, "Puerto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorreoPuerto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A54CorreoPuerto), 4, 0, ",", "")), StringUtil.LTrim( ((edtCorreoPuerto_Enabled!=0) ? context.localUtil.Format( (decimal)(A54CorreoPuerto), "ZZZ9") : context.localUtil.Format( (decimal)(A54CorreoPuerto), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorreoPuerto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorreoPuerto_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorreoUsuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorreoUsuario_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorreoUsuario_Internalname, A55CorreoUsuario, StringUtil.RTrim( context.localUtil.Format( A55CorreoUsuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A55CorreoUsuario, "", "", "", edtCorreoUsuario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorreoUsuario_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorreoContrasena_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorreoContrasena_Internalname, "Contrasena", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorreoContrasena_Internalname, StringUtil.RTrim( A56CorreoContrasena), StringUtil.RTrim( context.localUtil.Format( A56CorreoContrasena, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorreoContrasena_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorreoContrasena_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorreoPlantilla_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorreoPlantilla_Internalname, "Plantilla", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCorreoPlantilla_Internalname, A57CorreoPlantilla, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtCorreoPlantilla_Enabled, 0, 80, "chr", 10, "row", 1, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Correo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Correo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z50CorreoId = (short)(context.localUtil.CToN( cgiGet( "Z50CorreoId"), ",", "."));
            Z51CorreoIdentificador = cgiGet( "Z51CorreoIdentificador");
            Z52CorreoNombre = cgiGet( "Z52CorreoNombre");
            Z53CorreoServidor = cgiGet( "Z53CorreoServidor");
            Z54CorreoPuerto = (short)(context.localUtil.CToN( cgiGet( "Z54CorreoPuerto"), ",", "."));
            Z55CorreoUsuario = cgiGet( "Z55CorreoUsuario");
            Z56CorreoContrasena = cgiGet( "Z56CorreoContrasena");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtCorreoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCorreoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CORREOID");
               AnyError = 1;
               GX_FocusControl = edtCorreoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A50CorreoId = 0;
               AssignAttri("", false, "A50CorreoId", StringUtil.LTrimStr( (decimal)(A50CorreoId), 4, 0));
            }
            else
            {
               A50CorreoId = (short)(context.localUtil.CToN( cgiGet( edtCorreoId_Internalname), ",", "."));
               AssignAttri("", false, "A50CorreoId", StringUtil.LTrimStr( (decimal)(A50CorreoId), 4, 0));
            }
            A51CorreoIdentificador = cgiGet( edtCorreoIdentificador_Internalname);
            AssignAttri("", false, "A51CorreoIdentificador", A51CorreoIdentificador);
            A52CorreoNombre = cgiGet( edtCorreoNombre_Internalname);
            AssignAttri("", false, "A52CorreoNombre", A52CorreoNombre);
            A53CorreoServidor = cgiGet( edtCorreoServidor_Internalname);
            AssignAttri("", false, "A53CorreoServidor", A53CorreoServidor);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCorreoPuerto_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCorreoPuerto_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CORREOPUERTO");
               AnyError = 1;
               GX_FocusControl = edtCorreoPuerto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A54CorreoPuerto = 0;
               AssignAttri("", false, "A54CorreoPuerto", StringUtil.LTrimStr( (decimal)(A54CorreoPuerto), 4, 0));
            }
            else
            {
               A54CorreoPuerto = (short)(context.localUtil.CToN( cgiGet( edtCorreoPuerto_Internalname), ",", "."));
               AssignAttri("", false, "A54CorreoPuerto", StringUtil.LTrimStr( (decimal)(A54CorreoPuerto), 4, 0));
            }
            A55CorreoUsuario = cgiGet( edtCorreoUsuario_Internalname);
            AssignAttri("", false, "A55CorreoUsuario", A55CorreoUsuario);
            A56CorreoContrasena = cgiGet( edtCorreoContrasena_Internalname);
            AssignAttri("", false, "A56CorreoContrasena", A56CorreoContrasena);
            A57CorreoPlantilla = cgiGet( edtCorreoPlantilla_Internalname);
            n57CorreoPlantilla = false;
            AssignAttri("", false, "A57CorreoPlantilla", A57CorreoPlantilla);
            n57CorreoPlantilla = (String.IsNullOrEmpty(StringUtil.RTrim( A57CorreoPlantilla)) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A50CorreoId = (short)(NumberUtil.Val( GetPar( "CorreoId"), "."));
               AssignAttri("", false, "A50CorreoId", StringUtil.LTrimStr( (decimal)(A50CorreoId), 4, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0C13( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes0C13( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption0C0( )
      {
      }

      protected void ZM0C13( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z51CorreoIdentificador = T000C3_A51CorreoIdentificador[0];
               Z52CorreoNombre = T000C3_A52CorreoNombre[0];
               Z53CorreoServidor = T000C3_A53CorreoServidor[0];
               Z54CorreoPuerto = T000C3_A54CorreoPuerto[0];
               Z55CorreoUsuario = T000C3_A55CorreoUsuario[0];
               Z56CorreoContrasena = T000C3_A56CorreoContrasena[0];
            }
            else
            {
               Z51CorreoIdentificador = A51CorreoIdentificador;
               Z52CorreoNombre = A52CorreoNombre;
               Z53CorreoServidor = A53CorreoServidor;
               Z54CorreoPuerto = A54CorreoPuerto;
               Z55CorreoUsuario = A55CorreoUsuario;
               Z56CorreoContrasena = A56CorreoContrasena;
            }
         }
         if ( GX_JID == -2 )
         {
            Z50CorreoId = A50CorreoId;
            Z51CorreoIdentificador = A51CorreoIdentificador;
            Z52CorreoNombre = A52CorreoNombre;
            Z53CorreoServidor = A53CorreoServidor;
            Z54CorreoPuerto = A54CorreoPuerto;
            Z55CorreoUsuario = A55CorreoUsuario;
            Z56CorreoContrasena = A56CorreoContrasena;
            Z57CorreoPlantilla = A57CorreoPlantilla;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0C13( )
      {
         /* Using cursor T000C4 */
         pr_default.execute(2, new Object[] {A50CorreoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound13 = 1;
            A51CorreoIdentificador = T000C4_A51CorreoIdentificador[0];
            AssignAttri("", false, "A51CorreoIdentificador", A51CorreoIdentificador);
            A52CorreoNombre = T000C4_A52CorreoNombre[0];
            AssignAttri("", false, "A52CorreoNombre", A52CorreoNombre);
            A53CorreoServidor = T000C4_A53CorreoServidor[0];
            AssignAttri("", false, "A53CorreoServidor", A53CorreoServidor);
            A54CorreoPuerto = T000C4_A54CorreoPuerto[0];
            AssignAttri("", false, "A54CorreoPuerto", StringUtil.LTrimStr( (decimal)(A54CorreoPuerto), 4, 0));
            A55CorreoUsuario = T000C4_A55CorreoUsuario[0];
            AssignAttri("", false, "A55CorreoUsuario", A55CorreoUsuario);
            A56CorreoContrasena = T000C4_A56CorreoContrasena[0];
            AssignAttri("", false, "A56CorreoContrasena", A56CorreoContrasena);
            A57CorreoPlantilla = T000C4_A57CorreoPlantilla[0];
            n57CorreoPlantilla = T000C4_n57CorreoPlantilla[0];
            AssignAttri("", false, "A57CorreoPlantilla", A57CorreoPlantilla);
            ZM0C13( -2) ;
         }
         pr_default.close(2);
         OnLoadActions0C13( ) ;
      }

      protected void OnLoadActions0C13( )
      {
      }

      protected void CheckExtendedTable0C13( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A55CorreoUsuario,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de Correo Usuario no coincide con el patrón especificado", "OutOfRange", 1, "CORREOUSUARIO");
            AnyError = 1;
            GX_FocusControl = edtCorreoUsuario_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0C13( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C13( )
      {
         /* Using cursor T000C5 */
         pr_default.execute(3, new Object[] {A50CorreoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C3 */
         pr_default.execute(1, new Object[] {A50CorreoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C13( 2) ;
            RcdFound13 = 1;
            A50CorreoId = T000C3_A50CorreoId[0];
            AssignAttri("", false, "A50CorreoId", StringUtil.LTrimStr( (decimal)(A50CorreoId), 4, 0));
            A51CorreoIdentificador = T000C3_A51CorreoIdentificador[0];
            AssignAttri("", false, "A51CorreoIdentificador", A51CorreoIdentificador);
            A52CorreoNombre = T000C3_A52CorreoNombre[0];
            AssignAttri("", false, "A52CorreoNombre", A52CorreoNombre);
            A53CorreoServidor = T000C3_A53CorreoServidor[0];
            AssignAttri("", false, "A53CorreoServidor", A53CorreoServidor);
            A54CorreoPuerto = T000C3_A54CorreoPuerto[0];
            AssignAttri("", false, "A54CorreoPuerto", StringUtil.LTrimStr( (decimal)(A54CorreoPuerto), 4, 0));
            A55CorreoUsuario = T000C3_A55CorreoUsuario[0];
            AssignAttri("", false, "A55CorreoUsuario", A55CorreoUsuario);
            A56CorreoContrasena = T000C3_A56CorreoContrasena[0];
            AssignAttri("", false, "A56CorreoContrasena", A56CorreoContrasena);
            A57CorreoPlantilla = T000C3_A57CorreoPlantilla[0];
            n57CorreoPlantilla = T000C3_n57CorreoPlantilla[0];
            AssignAttri("", false, "A57CorreoPlantilla", A57CorreoPlantilla);
            Z50CorreoId = A50CorreoId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0C13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0C13( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0C13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound13 = 0;
         /* Using cursor T000C6 */
         pr_default.execute(4, new Object[] {A50CorreoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000C6_A50CorreoId[0] < A50CorreoId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000C6_A50CorreoId[0] > A50CorreoId ) ) )
            {
               A50CorreoId = T000C6_A50CorreoId[0];
               AssignAttri("", false, "A50CorreoId", StringUtil.LTrimStr( (decimal)(A50CorreoId), 4, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T000C7 */
         pr_default.execute(5, new Object[] {A50CorreoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000C7_A50CorreoId[0] > A50CorreoId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000C7_A50CorreoId[0] < A50CorreoId ) ) )
            {
               A50CorreoId = T000C7_A50CorreoId[0];
               AssignAttri("", false, "A50CorreoId", StringUtil.LTrimStr( (decimal)(A50CorreoId), 4, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCorreoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0C13( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A50CorreoId != Z50CorreoId )
               {
                  A50CorreoId = Z50CorreoId;
                  AssignAttri("", false, "A50CorreoId", StringUtil.LTrimStr( (decimal)(A50CorreoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CORREOID");
                  AnyError = 1;
                  GX_FocusControl = edtCorreoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCorreoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0C13( ) ;
                  GX_FocusControl = edtCorreoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A50CorreoId != Z50CorreoId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCorreoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0C13( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CORREOID");
                     AnyError = 1;
                     GX_FocusControl = edtCorreoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCorreoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0C13( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A50CorreoId != Z50CorreoId )
         {
            A50CorreoId = Z50CorreoId;
            AssignAttri("", false, "A50CorreoId", StringUtil.LTrimStr( (decimal)(A50CorreoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CORREOID");
            AnyError = 1;
            GX_FocusControl = edtCorreoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCorreoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CORREOID");
            AnyError = 1;
            GX_FocusControl = edtCorreoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCorreoIdentificador_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCorreoIdentificador_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0C13( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCorreoIdentificador_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCorreoIdentificador_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound13 != 0 )
            {
               ScanNext0C13( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCorreoIdentificador_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0C13( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0C13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_default.execute(0, new Object[] {A50CorreoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Correo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z51CorreoIdentificador, T000C2_A51CorreoIdentificador[0]) != 0 ) || ( StringUtil.StrCmp(Z52CorreoNombre, T000C2_A52CorreoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z53CorreoServidor, T000C2_A53CorreoServidor[0]) != 0 ) || ( Z54CorreoPuerto != T000C2_A54CorreoPuerto[0] ) || ( StringUtil.StrCmp(Z55CorreoUsuario, T000C2_A55CorreoUsuario[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z56CorreoContrasena, T000C2_A56CorreoContrasena[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z51CorreoIdentificador, T000C2_A51CorreoIdentificador[0]) != 0 )
               {
                  GXUtil.WriteLog("correo:[seudo value changed for attri]"+"CorreoIdentificador");
                  GXUtil.WriteLogRaw("Old: ",Z51CorreoIdentificador);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A51CorreoIdentificador[0]);
               }
               if ( StringUtil.StrCmp(Z52CorreoNombre, T000C2_A52CorreoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("correo:[seudo value changed for attri]"+"CorreoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z52CorreoNombre);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A52CorreoNombre[0]);
               }
               if ( StringUtil.StrCmp(Z53CorreoServidor, T000C2_A53CorreoServidor[0]) != 0 )
               {
                  GXUtil.WriteLog("correo:[seudo value changed for attri]"+"CorreoServidor");
                  GXUtil.WriteLogRaw("Old: ",Z53CorreoServidor);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A53CorreoServidor[0]);
               }
               if ( Z54CorreoPuerto != T000C2_A54CorreoPuerto[0] )
               {
                  GXUtil.WriteLog("correo:[seudo value changed for attri]"+"CorreoPuerto");
                  GXUtil.WriteLogRaw("Old: ",Z54CorreoPuerto);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A54CorreoPuerto[0]);
               }
               if ( StringUtil.StrCmp(Z55CorreoUsuario, T000C2_A55CorreoUsuario[0]) != 0 )
               {
                  GXUtil.WriteLog("correo:[seudo value changed for attri]"+"CorreoUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z55CorreoUsuario);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A55CorreoUsuario[0]);
               }
               if ( StringUtil.StrCmp(Z56CorreoContrasena, T000C2_A56CorreoContrasena[0]) != 0 )
               {
                  GXUtil.WriteLog("correo:[seudo value changed for attri]"+"CorreoContrasena");
                  GXUtil.WriteLogRaw("Old: ",Z56CorreoContrasena);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A56CorreoContrasena[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Correo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C13( 0) ;
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C8 */
                     pr_default.execute(6, new Object[] {A51CorreoIdentificador, A52CorreoNombre, A53CorreoServidor, A54CorreoPuerto, A55CorreoUsuario, A56CorreoContrasena, n57CorreoPlantilla, A57CorreoPlantilla});
                     A50CorreoId = T000C8_A50CorreoId[0];
                     AssignAttri("", false, "A50CorreoId", StringUtil.LTrimStr( (decimal)(A50CorreoId), 4, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Correo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0C0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0C13( ) ;
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void Update0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C9 */
                     pr_default.execute(7, new Object[] {A51CorreoIdentificador, A52CorreoNombre, A53CorreoServidor, A54CorreoPuerto, A55CorreoUsuario, A56CorreoContrasena, n57CorreoPlantilla, A57CorreoPlantilla, A50CorreoId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Correo");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Correo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0C0( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void DeferredUpdate0C13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C13( ) ;
            AfterConfirm0C13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C10 */
                  pr_default.execute(8, new Object[] {A50CorreoId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Correo");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound13 == 0 )
                        {
                           InitAll0C13( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption0C0( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0C13( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C13( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0C13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("correo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("correo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C13( )
      {
         /* Using cursor T000C11 */
         pr_default.execute(9);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound13 = 1;
            A50CorreoId = T000C11_A50CorreoId[0];
            AssignAttri("", false, "A50CorreoId", StringUtil.LTrimStr( (decimal)(A50CorreoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C13( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound13 = 1;
            A50CorreoId = T000C11_A50CorreoId[0];
            AssignAttri("", false, "A50CorreoId", StringUtil.LTrimStr( (decimal)(A50CorreoId), 4, 0));
         }
      }

      protected void ScanEnd0C13( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0C13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C13( )
      {
         edtCorreoId_Enabled = 0;
         AssignProp("", false, edtCorreoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorreoId_Enabled), 5, 0), true);
         edtCorreoIdentificador_Enabled = 0;
         AssignProp("", false, edtCorreoIdentificador_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorreoIdentificador_Enabled), 5, 0), true);
         edtCorreoNombre_Enabled = 0;
         AssignProp("", false, edtCorreoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorreoNombre_Enabled), 5, 0), true);
         edtCorreoServidor_Enabled = 0;
         AssignProp("", false, edtCorreoServidor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorreoServidor_Enabled), 5, 0), true);
         edtCorreoPuerto_Enabled = 0;
         AssignProp("", false, edtCorreoPuerto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorreoPuerto_Enabled), 5, 0), true);
         edtCorreoUsuario_Enabled = 0;
         AssignProp("", false, edtCorreoUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorreoUsuario_Enabled), 5, 0), true);
         edtCorreoContrasena_Enabled = 0;
         AssignProp("", false, edtCorreoContrasena_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorreoContrasena_Enabled), 5, 0), true);
         edtCorreoPlantilla_Enabled = 0;
         AssignProp("", false, edtCorreoPlantilla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorreoPlantilla_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0C13( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0C0( )
      {
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
         MasterPageObj.master_styles();
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("correo.aspx") +"\">") ;
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
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z50CorreoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50CorreoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z51CorreoIdentificador", StringUtil.RTrim( Z51CorreoIdentificador));
         GxWebStd.gx_hidden_field( context, "Z52CorreoNombre", StringUtil.RTrim( Z52CorreoNombre));
         GxWebStd.gx_hidden_field( context, "Z53CorreoServidor", StringUtil.RTrim( Z53CorreoServidor));
         GxWebStd.gx_hidden_field( context, "Z54CorreoPuerto", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z54CorreoPuerto), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z55CorreoUsuario", Z55CorreoUsuario);
         GxWebStd.gx_hidden_field( context, "Z56CorreoContrasena", StringUtil.RTrim( Z56CorreoContrasena));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("correo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Correo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Correo" ;
      }

      protected void InitializeNonKey0C13( )
      {
         A51CorreoIdentificador = "";
         AssignAttri("", false, "A51CorreoIdentificador", A51CorreoIdentificador);
         A52CorreoNombre = "";
         AssignAttri("", false, "A52CorreoNombre", A52CorreoNombre);
         A53CorreoServidor = "";
         AssignAttri("", false, "A53CorreoServidor", A53CorreoServidor);
         A54CorreoPuerto = 0;
         AssignAttri("", false, "A54CorreoPuerto", StringUtil.LTrimStr( (decimal)(A54CorreoPuerto), 4, 0));
         A55CorreoUsuario = "";
         AssignAttri("", false, "A55CorreoUsuario", A55CorreoUsuario);
         A56CorreoContrasena = "";
         AssignAttri("", false, "A56CorreoContrasena", A56CorreoContrasena);
         A57CorreoPlantilla = "";
         n57CorreoPlantilla = false;
         AssignAttri("", false, "A57CorreoPlantilla", A57CorreoPlantilla);
         n57CorreoPlantilla = (String.IsNullOrEmpty(StringUtil.RTrim( A57CorreoPlantilla)) ? true : false);
         Z51CorreoIdentificador = "";
         Z52CorreoNombre = "";
         Z53CorreoServidor = "";
         Z54CorreoPuerto = 0;
         Z55CorreoUsuario = "";
         Z56CorreoContrasena = "";
      }

      protected void InitAll0C13( )
      {
         A50CorreoId = 0;
         AssignAttri("", false, "A50CorreoId", StringUtil.LTrimStr( (decimal)(A50CorreoId), 4, 0));
         InitializeNonKey0C13( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202210221311505", true, true);
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
         context.AddJavascriptSource("correo.js", "?202210221311505", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtCorreoId_Internalname = "CORREOID";
         edtCorreoIdentificador_Internalname = "CORREOIDENTIFICADOR";
         edtCorreoNombre_Internalname = "CORREONOMBRE";
         edtCorreoServidor_Internalname = "CORREOSERVIDOR";
         edtCorreoPuerto_Internalname = "CORREOPUERTO";
         edtCorreoUsuario_Internalname = "CORREOUSUARIO";
         edtCorreoContrasena_Internalname = "CORREOCONTRASENA";
         edtCorreoPlantilla_Internalname = "CORREOPLANTILLA";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Correo";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCorreoPlantilla_Enabled = 1;
         edtCorreoContrasena_Jsonclick = "";
         edtCorreoContrasena_Enabled = 1;
         edtCorreoUsuario_Jsonclick = "";
         edtCorreoUsuario_Enabled = 1;
         edtCorreoPuerto_Jsonclick = "";
         edtCorreoPuerto_Enabled = 1;
         edtCorreoServidor_Jsonclick = "";
         edtCorreoServidor_Enabled = 1;
         edtCorreoNombre_Jsonclick = "";
         edtCorreoNombre_Enabled = 1;
         edtCorreoIdentificador_Jsonclick = "";
         edtCorreoIdentificador_Enabled = 1;
         edtCorreoId_Jsonclick = "";
         edtCorreoId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtCorreoIdentificador_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Correoid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A51CorreoIdentificador", StringUtil.RTrim( A51CorreoIdentificador));
         AssignAttri("", false, "A52CorreoNombre", StringUtil.RTrim( A52CorreoNombre));
         AssignAttri("", false, "A53CorreoServidor", StringUtil.RTrim( A53CorreoServidor));
         AssignAttri("", false, "A54CorreoPuerto", StringUtil.LTrim( StringUtil.NToC( (decimal)(A54CorreoPuerto), 4, 0, ".", "")));
         AssignAttri("", false, "A55CorreoUsuario", A55CorreoUsuario);
         AssignAttri("", false, "A56CorreoContrasena", StringUtil.RTrim( A56CorreoContrasena));
         AssignAttri("", false, "A57CorreoPlantilla", A57CorreoPlantilla);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z50CorreoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50CorreoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z51CorreoIdentificador", StringUtil.RTrim( Z51CorreoIdentificador));
         GxWebStd.gx_hidden_field( context, "Z52CorreoNombre", StringUtil.RTrim( Z52CorreoNombre));
         GxWebStd.gx_hidden_field( context, "Z53CorreoServidor", StringUtil.RTrim( Z53CorreoServidor));
         GxWebStd.gx_hidden_field( context, "Z54CorreoPuerto", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z54CorreoPuerto), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z55CorreoUsuario", Z55CorreoUsuario);
         GxWebStd.gx_hidden_field( context, "Z56CorreoContrasena", StringUtil.RTrim( Z56CorreoContrasena));
         GxWebStd.gx_hidden_field( context, "Z57CorreoPlantilla", Z57CorreoPlantilla);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_CORREOID","{handler:'Valid_Correoid',iparms:[{av:'A50CorreoId',fld:'CORREOID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CORREOID",",oparms:[{av:'A51CorreoIdentificador',fld:'CORREOIDENTIFICADOR',pic:''},{av:'A52CorreoNombre',fld:'CORREONOMBRE',pic:''},{av:'A53CorreoServidor',fld:'CORREOSERVIDOR',pic:''},{av:'A54CorreoPuerto',fld:'CORREOPUERTO',pic:'ZZZ9'},{av:'A55CorreoUsuario',fld:'CORREOUSUARIO',pic:''},{av:'A56CorreoContrasena',fld:'CORREOCONTRASENA',pic:''},{av:'A57CorreoPlantilla',fld:'CORREOPLANTILLA',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z50CorreoId'},{av:'Z51CorreoIdentificador'},{av:'Z52CorreoNombre'},{av:'Z53CorreoServidor'},{av:'Z54CorreoPuerto'},{av:'Z55CorreoUsuario'},{av:'Z56CorreoContrasena'},{av:'Z57CorreoPlantilla'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CORREOUSUARIO","{handler:'Valid_Correousuario',iparms:[]");
         setEventMetadata("VALID_CORREOUSUARIO",",oparms:[]}");
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z51CorreoIdentificador = "";
         Z52CorreoNombre = "";
         Z53CorreoServidor = "";
         Z55CorreoUsuario = "";
         Z56CorreoContrasena = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A51CorreoIdentificador = "";
         A52CorreoNombre = "";
         A53CorreoServidor = "";
         A55CorreoUsuario = "";
         A56CorreoContrasena = "";
         A57CorreoPlantilla = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z57CorreoPlantilla = "";
         T000C4_A50CorreoId = new short[1] ;
         T000C4_A51CorreoIdentificador = new string[] {""} ;
         T000C4_A52CorreoNombre = new string[] {""} ;
         T000C4_A53CorreoServidor = new string[] {""} ;
         T000C4_A54CorreoPuerto = new short[1] ;
         T000C4_A55CorreoUsuario = new string[] {""} ;
         T000C4_A56CorreoContrasena = new string[] {""} ;
         T000C4_A57CorreoPlantilla = new string[] {""} ;
         T000C4_n57CorreoPlantilla = new bool[] {false} ;
         T000C5_A50CorreoId = new short[1] ;
         T000C3_A50CorreoId = new short[1] ;
         T000C3_A51CorreoIdentificador = new string[] {""} ;
         T000C3_A52CorreoNombre = new string[] {""} ;
         T000C3_A53CorreoServidor = new string[] {""} ;
         T000C3_A54CorreoPuerto = new short[1] ;
         T000C3_A55CorreoUsuario = new string[] {""} ;
         T000C3_A56CorreoContrasena = new string[] {""} ;
         T000C3_A57CorreoPlantilla = new string[] {""} ;
         T000C3_n57CorreoPlantilla = new bool[] {false} ;
         sMode13 = "";
         T000C6_A50CorreoId = new short[1] ;
         T000C7_A50CorreoId = new short[1] ;
         T000C2_A50CorreoId = new short[1] ;
         T000C2_A51CorreoIdentificador = new string[] {""} ;
         T000C2_A52CorreoNombre = new string[] {""} ;
         T000C2_A53CorreoServidor = new string[] {""} ;
         T000C2_A54CorreoPuerto = new short[1] ;
         T000C2_A55CorreoUsuario = new string[] {""} ;
         T000C2_A56CorreoContrasena = new string[] {""} ;
         T000C2_A57CorreoPlantilla = new string[] {""} ;
         T000C2_n57CorreoPlantilla = new bool[] {false} ;
         T000C8_A50CorreoId = new short[1] ;
         T000C11_A50CorreoId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ51CorreoIdentificador = "";
         ZZ52CorreoNombre = "";
         ZZ53CorreoServidor = "";
         ZZ55CorreoUsuario = "";
         ZZ56CorreoContrasena = "";
         ZZ57CorreoPlantilla = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.correo__default(),
            new Object[][] {
                new Object[] {
               T000C2_A50CorreoId, T000C2_A51CorreoIdentificador, T000C2_A52CorreoNombre, T000C2_A53CorreoServidor, T000C2_A54CorreoPuerto, T000C2_A55CorreoUsuario, T000C2_A56CorreoContrasena, T000C2_A57CorreoPlantilla, T000C2_n57CorreoPlantilla
               }
               , new Object[] {
               T000C3_A50CorreoId, T000C3_A51CorreoIdentificador, T000C3_A52CorreoNombre, T000C3_A53CorreoServidor, T000C3_A54CorreoPuerto, T000C3_A55CorreoUsuario, T000C3_A56CorreoContrasena, T000C3_A57CorreoPlantilla, T000C3_n57CorreoPlantilla
               }
               , new Object[] {
               T000C4_A50CorreoId, T000C4_A51CorreoIdentificador, T000C4_A52CorreoNombre, T000C4_A53CorreoServidor, T000C4_A54CorreoPuerto, T000C4_A55CorreoUsuario, T000C4_A56CorreoContrasena, T000C4_A57CorreoPlantilla, T000C4_n57CorreoPlantilla
               }
               , new Object[] {
               T000C5_A50CorreoId
               }
               , new Object[] {
               T000C6_A50CorreoId
               }
               , new Object[] {
               T000C7_A50CorreoId
               }
               , new Object[] {
               T000C8_A50CorreoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C11_A50CorreoId
               }
            }
         );
      }

      private short Z50CorreoId ;
      private short Z54CorreoPuerto ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A50CorreoId ;
      private short A54CorreoPuerto ;
      private short GX_JID ;
      private short RcdFound13 ;
      private short nIsDirty_13 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ50CorreoId ;
      private short ZZ54CorreoPuerto ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCorreoId_Enabled ;
      private int edtCorreoIdentificador_Enabled ;
      private int edtCorreoNombre_Enabled ;
      private int edtCorreoServidor_Enabled ;
      private int edtCorreoPuerto_Enabled ;
      private int edtCorreoUsuario_Enabled ;
      private int edtCorreoContrasena_Enabled ;
      private int edtCorreoPlantilla_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z51CorreoIdentificador ;
      private string Z52CorreoNombre ;
      private string Z53CorreoServidor ;
      private string Z56CorreoContrasena ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCorreoId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtCorreoId_Jsonclick ;
      private string edtCorreoIdentificador_Internalname ;
      private string A51CorreoIdentificador ;
      private string edtCorreoIdentificador_Jsonclick ;
      private string edtCorreoNombre_Internalname ;
      private string A52CorreoNombre ;
      private string edtCorreoNombre_Jsonclick ;
      private string edtCorreoServidor_Internalname ;
      private string A53CorreoServidor ;
      private string edtCorreoServidor_Jsonclick ;
      private string edtCorreoPuerto_Internalname ;
      private string edtCorreoPuerto_Jsonclick ;
      private string edtCorreoUsuario_Internalname ;
      private string edtCorreoUsuario_Jsonclick ;
      private string edtCorreoContrasena_Internalname ;
      private string A56CorreoContrasena ;
      private string edtCorreoContrasena_Jsonclick ;
      private string edtCorreoPlantilla_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode13 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ51CorreoIdentificador ;
      private string ZZ52CorreoNombre ;
      private string ZZ53CorreoServidor ;
      private string ZZ56CorreoContrasena ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n57CorreoPlantilla ;
      private bool Gx_longc ;
      private string A57CorreoPlantilla ;
      private string Z57CorreoPlantilla ;
      private string ZZ57CorreoPlantilla ;
      private string Z55CorreoUsuario ;
      private string A55CorreoUsuario ;
      private string ZZ55CorreoUsuario ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T000C4_A50CorreoId ;
      private string[] T000C4_A51CorreoIdentificador ;
      private string[] T000C4_A52CorreoNombre ;
      private string[] T000C4_A53CorreoServidor ;
      private short[] T000C4_A54CorreoPuerto ;
      private string[] T000C4_A55CorreoUsuario ;
      private string[] T000C4_A56CorreoContrasena ;
      private string[] T000C4_A57CorreoPlantilla ;
      private bool[] T000C4_n57CorreoPlantilla ;
      private short[] T000C5_A50CorreoId ;
      private short[] T000C3_A50CorreoId ;
      private string[] T000C3_A51CorreoIdentificador ;
      private string[] T000C3_A52CorreoNombre ;
      private string[] T000C3_A53CorreoServidor ;
      private short[] T000C3_A54CorreoPuerto ;
      private string[] T000C3_A55CorreoUsuario ;
      private string[] T000C3_A56CorreoContrasena ;
      private string[] T000C3_A57CorreoPlantilla ;
      private bool[] T000C3_n57CorreoPlantilla ;
      private short[] T000C6_A50CorreoId ;
      private short[] T000C7_A50CorreoId ;
      private short[] T000C2_A50CorreoId ;
      private string[] T000C2_A51CorreoIdentificador ;
      private string[] T000C2_A52CorreoNombre ;
      private string[] T000C2_A53CorreoServidor ;
      private short[] T000C2_A54CorreoPuerto ;
      private string[] T000C2_A55CorreoUsuario ;
      private string[] T000C2_A56CorreoContrasena ;
      private string[] T000C2_A57CorreoPlantilla ;
      private bool[] T000C2_n57CorreoPlantilla ;
      private short[] T000C8_A50CorreoId ;
      private short[] T000C11_A50CorreoId ;
      private GXWebForm Form ;
   }

   public class correo__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000C4;
          prmT000C4 = new Object[] {
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmT000C5;
          prmT000C5 = new Object[] {
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmT000C3;
          prmT000C3 = new Object[] {
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmT000C6;
          prmT000C6 = new Object[] {
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmT000C7;
          prmT000C7 = new Object[] {
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmT000C2;
          prmT000C2 = new Object[] {
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmT000C8;
          prmT000C8 = new Object[] {
          new ParDef("@CorreoIdentificador",GXType.NChar,20,0) ,
          new ParDef("@CorreoNombre",GXType.NChar,20,0) ,
          new ParDef("@CorreoServidor",GXType.NChar,22,0) ,
          new ParDef("@CorreoPuerto",GXType.Int16,4,0) ,
          new ParDef("@CorreoUsuario",GXType.NVarChar,100,0) ,
          new ParDef("@CorreoContrasena",GXType.NChar,20,0) ,
          new ParDef("@CorreoPlantilla",GXType.NVarChar,2097152,0){Nullable=true}
          };
          Object[] prmT000C9;
          prmT000C9 = new Object[] {
          new ParDef("@CorreoIdentificador",GXType.NChar,20,0) ,
          new ParDef("@CorreoNombre",GXType.NChar,20,0) ,
          new ParDef("@CorreoServidor",GXType.NChar,22,0) ,
          new ParDef("@CorreoPuerto",GXType.Int16,4,0) ,
          new ParDef("@CorreoUsuario",GXType.NVarChar,100,0) ,
          new ParDef("@CorreoContrasena",GXType.NChar,20,0) ,
          new ParDef("@CorreoPlantilla",GXType.NVarChar,2097152,0){Nullable=true} ,
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmT000C10;
          prmT000C10 = new Object[] {
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmT000C11;
          prmT000C11 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000C2", "SELECT [CorreoId], [CorreoIdentificador], [CorreoNombre], [CorreoServidor], [CorreoPuerto], [CorreoUsuario], [CorreoContrasena], [CorreoPlantilla] FROM [Correo] WITH (UPDLOCK) WHERE [CorreoId] = @CorreoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C3", "SELECT [CorreoId], [CorreoIdentificador], [CorreoNombre], [CorreoServidor], [CorreoPuerto], [CorreoUsuario], [CorreoContrasena], [CorreoPlantilla] FROM [Correo] WHERE [CorreoId] = @CorreoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C4", "SELECT TM1.[CorreoId], TM1.[CorreoIdentificador], TM1.[CorreoNombre], TM1.[CorreoServidor], TM1.[CorreoPuerto], TM1.[CorreoUsuario], TM1.[CorreoContrasena], TM1.[CorreoPlantilla] FROM [Correo] TM1 WHERE TM1.[CorreoId] = @CorreoId ORDER BY TM1.[CorreoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C5", "SELECT [CorreoId] FROM [Correo] WHERE [CorreoId] = @CorreoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C6", "SELECT TOP 1 [CorreoId] FROM [Correo] WHERE ( [CorreoId] > @CorreoId) ORDER BY [CorreoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C7", "SELECT TOP 1 [CorreoId] FROM [Correo] WHERE ( [CorreoId] < @CorreoId) ORDER BY [CorreoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C8", "INSERT INTO [Correo]([CorreoIdentificador], [CorreoNombre], [CorreoServidor], [CorreoPuerto], [CorreoUsuario], [CorreoContrasena], [CorreoPlantilla]) VALUES(@CorreoIdentificador, @CorreoNombre, @CorreoServidor, @CorreoPuerto, @CorreoUsuario, @CorreoContrasena, @CorreoPlantilla); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000C8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C9", "UPDATE [Correo] SET [CorreoIdentificador]=@CorreoIdentificador, [CorreoNombre]=@CorreoNombre, [CorreoServidor]=@CorreoServidor, [CorreoPuerto]=@CorreoPuerto, [CorreoUsuario]=@CorreoUsuario, [CorreoContrasena]=@CorreoContrasena, [CorreoPlantilla]=@CorreoPlantilla  WHERE [CorreoId] = @CorreoId", GxErrorMask.GX_NOMASK,prmT000C9)
             ,new CursorDef("T000C10", "DELETE FROM [Correo]  WHERE [CorreoId] = @CorreoId", GxErrorMask.GX_NOMASK,prmT000C10)
             ,new CursorDef("T000C11", "SELECT [CorreoId] FROM [Correo] ORDER BY [CorreoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C11,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 22);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 22);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 22);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
