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
   public class usuarios : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A1RolId = (short)(NumberUtil.Val( GetPar( "RolId"), "."));
            AssignAttri("", false, "A1RolId", StringUtil.LTrimStr( (decimal)(A1RolId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A1RolId) ;
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_11-163677", 0) ;
            }
            Form.Meta.addItem("description", "Usuarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtUsuarioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public usuarios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public usuarios( IGxContext context )
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
         chkUsuarioEstado = new GXCheckbox();
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
         A8UsuarioEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A8UsuarioEstado));
         AssignAttri("", false, "A8UsuarioEstado", A8UsuarioEstado);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Usuarios", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Usuarios.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"USUARIOID"+"'), id:'"+"USUARIOID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Usuarios.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuarioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3UsuarioId), 4, 0, ",", "")), StringUtil.LTrim( ((edtUsuarioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A3UsuarioId), "ZZZ9") : context.localUtil.Format( (decimal)(A3UsuarioId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuarioNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombre_Internalname, StringUtil.RTrim( A4UsuarioNombre), StringUtil.RTrim( context.localUtil.Format( A4UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNombre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuarioApellido_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioApellido_Internalname, "Apellido", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioApellido_Internalname, StringUtil.RTrim( A5UsuarioApellido), StringUtil.RTrim( context.localUtil.Format( A5UsuarioApellido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioApellido_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioApellido_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuarioEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioEmail_Internalname, "Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioEmail_Internalname, A6UsuarioEmail, StringUtil.RTrim( context.localUtil.Format( A6UsuarioEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A6UsuarioEmail, "", "", "", edtUsuarioEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuarioPassword_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioPassword_Internalname, "Password", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUsuarioPassword_Internalname, StringUtil.RTrim( A7UsuarioPassword), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtUsuarioPassword_Enabled, 0, 80, "chr", 3, "row", 1, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuarioEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuarioEstado_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuarioEstado_Internalname, StringUtil.BoolToStr( A8UsuarioEstado), "", "Estado", 1, chkUsuarioEstado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRolId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRolId_Internalname, "Rol Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1RolId), 4, 0, ",", "")), StringUtil.LTrim( ((edtRolId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1RolId), "ZZZ9") : context.localUtil.Format( (decimal)(A1RolId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRolId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRolId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Usuarios.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Usuarios.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
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
            Z3UsuarioId = (short)(context.localUtil.CToN( cgiGet( "Z3UsuarioId"), ",", "."));
            Z4UsuarioNombre = cgiGet( "Z4UsuarioNombre");
            n4UsuarioNombre = (String.IsNullOrEmpty(StringUtil.RTrim( A4UsuarioNombre)) ? true : false);
            Z5UsuarioApellido = cgiGet( "Z5UsuarioApellido");
            n5UsuarioApellido = (String.IsNullOrEmpty(StringUtil.RTrim( A5UsuarioApellido)) ? true : false);
            Z6UsuarioEmail = cgiGet( "Z6UsuarioEmail");
            Z7UsuarioPassword = cgiGet( "Z7UsuarioPassword");
            n7UsuarioPassword = (String.IsNullOrEmpty(StringUtil.RTrim( A7UsuarioPassword)) ? true : false);
            Z8UsuarioEstado = StringUtil.StrToBool( cgiGet( "Z8UsuarioEstado"));
            Z1RolId = (short)(context.localUtil.CToN( cgiGet( "Z1RolId"), ",", "."));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOID");
               AnyError = 1;
               GX_FocusControl = edtUsuarioId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A3UsuarioId = 0;
               AssignAttri("", false, "A3UsuarioId", StringUtil.LTrimStr( (decimal)(A3UsuarioId), 4, 0));
            }
            else
            {
               A3UsuarioId = (short)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ",", "."));
               AssignAttri("", false, "A3UsuarioId", StringUtil.LTrimStr( (decimal)(A3UsuarioId), 4, 0));
            }
            A4UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
            n4UsuarioNombre = false;
            AssignAttri("", false, "A4UsuarioNombre", A4UsuarioNombre);
            n4UsuarioNombre = (String.IsNullOrEmpty(StringUtil.RTrim( A4UsuarioNombre)) ? true : false);
            A5UsuarioApellido = cgiGet( edtUsuarioApellido_Internalname);
            n5UsuarioApellido = false;
            AssignAttri("", false, "A5UsuarioApellido", A5UsuarioApellido);
            n5UsuarioApellido = (String.IsNullOrEmpty(StringUtil.RTrim( A5UsuarioApellido)) ? true : false);
            A6UsuarioEmail = cgiGet( edtUsuarioEmail_Internalname);
            AssignAttri("", false, "A6UsuarioEmail", A6UsuarioEmail);
            A7UsuarioPassword = cgiGet( edtUsuarioPassword_Internalname);
            n7UsuarioPassword = false;
            AssignAttri("", false, "A7UsuarioPassword", A7UsuarioPassword);
            n7UsuarioPassword = (String.IsNullOrEmpty(StringUtil.RTrim( A7UsuarioPassword)) ? true : false);
            A8UsuarioEstado = StringUtil.StrToBool( cgiGet( chkUsuarioEstado_Internalname));
            AssignAttri("", false, "A8UsuarioEstado", A8UsuarioEstado);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRolId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRolId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ROLID");
               AnyError = 1;
               GX_FocusControl = edtRolId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1RolId = 0;
               AssignAttri("", false, "A1RolId", StringUtil.LTrimStr( (decimal)(A1RolId), 4, 0));
            }
            else
            {
               A1RolId = (short)(context.localUtil.CToN( cgiGet( edtRolId_Internalname), ",", "."));
               AssignAttri("", false, "A1RolId", StringUtil.LTrimStr( (decimal)(A1RolId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A3UsuarioId = (short)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
               AssignAttri("", false, "A3UsuarioId", StringUtil.LTrimStr( (decimal)(A3UsuarioId), 4, 0));
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
               InitAll022( ) ;
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
         DisableAttributes022( ) ;
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

      protected void ResetCaption020( )
      {
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z4UsuarioNombre = T00023_A4UsuarioNombre[0];
               Z5UsuarioApellido = T00023_A5UsuarioApellido[0];
               Z6UsuarioEmail = T00023_A6UsuarioEmail[0];
               Z7UsuarioPassword = T00023_A7UsuarioPassword[0];
               Z8UsuarioEstado = T00023_A8UsuarioEstado[0];
               Z1RolId = T00023_A1RolId[0];
            }
            else
            {
               Z4UsuarioNombre = A4UsuarioNombre;
               Z5UsuarioApellido = A5UsuarioApellido;
               Z6UsuarioEmail = A6UsuarioEmail;
               Z7UsuarioPassword = A7UsuarioPassword;
               Z8UsuarioEstado = A8UsuarioEstado;
               Z1RolId = A1RolId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z3UsuarioId = A3UsuarioId;
            Z4UsuarioNombre = A4UsuarioNombre;
            Z5UsuarioApellido = A5UsuarioApellido;
            Z6UsuarioEmail = A6UsuarioEmail;
            Z7UsuarioPassword = A7UsuarioPassword;
            Z8UsuarioEstado = A8UsuarioEstado;
            Z1RolId = A1RolId;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ROLID"+"'), id:'"+"ROLID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load022( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A3UsuarioId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
            A4UsuarioNombre = T00025_A4UsuarioNombre[0];
            n4UsuarioNombre = T00025_n4UsuarioNombre[0];
            AssignAttri("", false, "A4UsuarioNombre", A4UsuarioNombre);
            A5UsuarioApellido = T00025_A5UsuarioApellido[0];
            n5UsuarioApellido = T00025_n5UsuarioApellido[0];
            AssignAttri("", false, "A5UsuarioApellido", A5UsuarioApellido);
            A6UsuarioEmail = T00025_A6UsuarioEmail[0];
            AssignAttri("", false, "A6UsuarioEmail", A6UsuarioEmail);
            A7UsuarioPassword = T00025_A7UsuarioPassword[0];
            n7UsuarioPassword = T00025_n7UsuarioPassword[0];
            AssignAttri("", false, "A7UsuarioPassword", A7UsuarioPassword);
            A8UsuarioEstado = T00025_A8UsuarioEstado[0];
            AssignAttri("", false, "A8UsuarioEstado", A8UsuarioEstado);
            A1RolId = T00025_A1RolId[0];
            AssignAttri("", false, "A1RolId", StringUtil.LTrimStr( (decimal)(A1RolId), 4, 0));
            ZM022( -2) ;
         }
         pr_default.close(3);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A6UsuarioEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de Usuario Email no coincide con el patrón especificado", "OutOfRange", 1, "USUARIOEMAIL");
            AnyError = 1;
            GX_FocusControl = edtUsuarioEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A1RolId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, "ROLID");
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( short A1RolId )
      {
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A1RolId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, "ROLID");
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey022( )
      {
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A3UsuarioId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A3UsuarioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 2) ;
            RcdFound2 = 1;
            A3UsuarioId = T00023_A3UsuarioId[0];
            AssignAttri("", false, "A3UsuarioId", StringUtil.LTrimStr( (decimal)(A3UsuarioId), 4, 0));
            A4UsuarioNombre = T00023_A4UsuarioNombre[0];
            n4UsuarioNombre = T00023_n4UsuarioNombre[0];
            AssignAttri("", false, "A4UsuarioNombre", A4UsuarioNombre);
            A5UsuarioApellido = T00023_A5UsuarioApellido[0];
            n5UsuarioApellido = T00023_n5UsuarioApellido[0];
            AssignAttri("", false, "A5UsuarioApellido", A5UsuarioApellido);
            A6UsuarioEmail = T00023_A6UsuarioEmail[0];
            AssignAttri("", false, "A6UsuarioEmail", A6UsuarioEmail);
            A7UsuarioPassword = T00023_A7UsuarioPassword[0];
            n7UsuarioPassword = T00023_n7UsuarioPassword[0];
            AssignAttri("", false, "A7UsuarioPassword", A7UsuarioPassword);
            A8UsuarioEstado = T00023_A8UsuarioEstado[0];
            AssignAttri("", false, "A8UsuarioEstado", A8UsuarioEstado);
            A1RolId = T00023_A1RolId[0];
            AssignAttri("", false, "A1RolId", StringUtil.LTrimStr( (decimal)(A1RolId), 4, 0));
            Z3UsuarioId = A3UsuarioId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
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
         RcdFound2 = 0;
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {A3UsuarioId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00028_A3UsuarioId[0] < A3UsuarioId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00028_A3UsuarioId[0] > A3UsuarioId ) ) )
            {
               A3UsuarioId = T00028_A3UsuarioId[0];
               AssignAttri("", false, "A3UsuarioId", StringUtil.LTrimStr( (decimal)(A3UsuarioId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {A3UsuarioId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00029_A3UsuarioId[0] > A3UsuarioId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00029_A3UsuarioId[0] < A3UsuarioId ) ) )
            {
               A3UsuarioId = T00029_A3UsuarioId[0];
               AssignAttri("", false, "A3UsuarioId", StringUtil.LTrimStr( (decimal)(A3UsuarioId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuarioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A3UsuarioId != Z3UsuarioId )
               {
                  A3UsuarioId = Z3UsuarioId;
                  AssignAttri("", false, "A3UsuarioId", StringUtil.LTrimStr( (decimal)(A3UsuarioId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "USUARIOID");
                  AnyError = 1;
                  GX_FocusControl = edtUsuarioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUsuarioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtUsuarioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A3UsuarioId != Z3UsuarioId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUsuarioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "USUARIOID");
                     AnyError = 1;
                     GX_FocusControl = edtUsuarioId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtUsuarioId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( A3UsuarioId != Z3UsuarioId )
         {
            A3UsuarioId = Z3UsuarioId;
            AssignAttri("", false, "A3UsuarioId", StringUtil.LTrimStr( (decimal)(A3UsuarioId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUsuarioId_Internalname;
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
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtUsuarioNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd022( ) ;
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
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioNombre_Internalname;
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
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioNombre_Internalname;
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
         ScanStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound2 != 0 )
            {
               ScanNext022( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd022( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A3UsuarioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuarios"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z4UsuarioNombre, T00022_A4UsuarioNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z5UsuarioApellido, T00022_A5UsuarioApellido[0]) != 0 ) || ( StringUtil.StrCmp(Z6UsuarioEmail, T00022_A6UsuarioEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z7UsuarioPassword, T00022_A7UsuarioPassword[0]) != 0 ) || ( Z8UsuarioEstado != T00022_A8UsuarioEstado[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1RolId != T00022_A1RolId[0] ) )
            {
               if ( StringUtil.StrCmp(Z4UsuarioNombre, T00022_A4UsuarioNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuarioNombre");
                  GXUtil.WriteLogRaw("Old: ",Z4UsuarioNombre);
                  GXUtil.WriteLogRaw("Current: ",T00022_A4UsuarioNombre[0]);
               }
               if ( StringUtil.StrCmp(Z5UsuarioApellido, T00022_A5UsuarioApellido[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuarioApellido");
                  GXUtil.WriteLogRaw("Old: ",Z5UsuarioApellido);
                  GXUtil.WriteLogRaw("Current: ",T00022_A5UsuarioApellido[0]);
               }
               if ( StringUtil.StrCmp(Z6UsuarioEmail, T00022_A6UsuarioEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuarioEmail");
                  GXUtil.WriteLogRaw("Old: ",Z6UsuarioEmail);
                  GXUtil.WriteLogRaw("Current: ",T00022_A6UsuarioEmail[0]);
               }
               if ( StringUtil.StrCmp(Z7UsuarioPassword, T00022_A7UsuarioPassword[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuarioPassword");
                  GXUtil.WriteLogRaw("Old: ",Z7UsuarioPassword);
                  GXUtil.WriteLogRaw("Current: ",T00022_A7UsuarioPassword[0]);
               }
               if ( Z8UsuarioEstado != T00022_A8UsuarioEstado[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuarioEstado");
                  GXUtil.WriteLogRaw("Old: ",Z8UsuarioEstado);
                  GXUtil.WriteLogRaw("Current: ",T00022_A8UsuarioEstado[0]);
               }
               if ( Z1RolId != T00022_A1RolId[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"RolId");
                  GXUtil.WriteLogRaw("Old: ",Z1RolId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A1RolId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Usuarios"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000210 */
                     pr_default.execute(8, new Object[] {A3UsuarioId, n4UsuarioNombre, A4UsuarioNombre, n5UsuarioApellido, A5UsuarioApellido, A6UsuarioEmail, n7UsuarioPassword, A7UsuarioPassword, A8UsuarioEstado, A1RolId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Usuarios");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000211 */
                     pr_default.execute(9, new Object[] {n4UsuarioNombre, A4UsuarioNombre, n5UsuarioApellido, A5UsuarioApellido, A6UsuarioEmail, n7UsuarioPassword, A7UsuarioPassword, A8UsuarioEstado, A1RolId, A3UsuarioId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Usuarios");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuarios"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption020( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000212 */
                  pr_default.execute(10, new Object[] {A3UsuarioId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("Usuarios");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound2 == 0 )
                        {
                           InitAll022( ) ;
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
                        ResetCaption020( ) ;
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000213 */
            pr_default.execute(11, new Object[] {A3UsuarioId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tareas Comentarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000214 */
            pr_default.execute(12, new Object[] {A3UsuarioId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tareas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000215 */
            pr_default.execute(13, new Object[] {A3UsuarioId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Participantes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000216 */
            pr_default.execute(14, new Object[] {A3UsuarioId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tableros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("usuarios",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("usuarios",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Using cursor T000217 */
         pr_default.execute(15);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound2 = 1;
            A3UsuarioId = T000217_A3UsuarioId[0];
            AssignAttri("", false, "A3UsuarioId", StringUtil.LTrimStr( (decimal)(A3UsuarioId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound2 = 1;
            A3UsuarioId = T000217_A3UsuarioId[0];
            AssignAttri("", false, "A3UsuarioId", StringUtil.LTrimStr( (decimal)(A3UsuarioId), 4, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtUsuarioId_Enabled = 0;
         AssignProp("", false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         edtUsuarioNombre_Enabled = 0;
         AssignProp("", false, edtUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Enabled), 5, 0), true);
         edtUsuarioApellido_Enabled = 0;
         AssignProp("", false, edtUsuarioApellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioApellido_Enabled), 5, 0), true);
         edtUsuarioEmail_Enabled = 0;
         AssignProp("", false, edtUsuarioEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioEmail_Enabled), 5, 0), true);
         edtUsuarioPassword_Enabled = 0;
         AssignProp("", false, edtUsuarioPassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioPassword_Enabled), 5, 0), true);
         chkUsuarioEstado.Enabled = 0;
         AssignProp("", false, chkUsuarioEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuarioEstado.Enabled), 5, 0), true);
         edtRolId_Enabled = 0;
         AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("usuarios.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z3UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3UsuarioId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z4UsuarioNombre", StringUtil.RTrim( Z4UsuarioNombre));
         GxWebStd.gx_hidden_field( context, "Z5UsuarioApellido", StringUtil.RTrim( Z5UsuarioApellido));
         GxWebStd.gx_hidden_field( context, "Z6UsuarioEmail", Z6UsuarioEmail);
         GxWebStd.gx_hidden_field( context, "Z7UsuarioPassword", StringUtil.RTrim( Z7UsuarioPassword));
         GxWebStd.gx_boolean_hidden_field( context, "Z8UsuarioEstado", Z8UsuarioEstado);
         GxWebStd.gx_hidden_field( context, "Z1RolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1RolId), 4, 0, ",", "")));
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
         return formatLink("usuarios.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Usuarios" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuarios" ;
      }

      protected void InitializeNonKey022( )
      {
         A4UsuarioNombre = "";
         n4UsuarioNombre = false;
         AssignAttri("", false, "A4UsuarioNombre", A4UsuarioNombre);
         n4UsuarioNombre = (String.IsNullOrEmpty(StringUtil.RTrim( A4UsuarioNombre)) ? true : false);
         A5UsuarioApellido = "";
         n5UsuarioApellido = false;
         AssignAttri("", false, "A5UsuarioApellido", A5UsuarioApellido);
         n5UsuarioApellido = (String.IsNullOrEmpty(StringUtil.RTrim( A5UsuarioApellido)) ? true : false);
         A6UsuarioEmail = "";
         AssignAttri("", false, "A6UsuarioEmail", A6UsuarioEmail);
         A7UsuarioPassword = "";
         n7UsuarioPassword = false;
         AssignAttri("", false, "A7UsuarioPassword", A7UsuarioPassword);
         n7UsuarioPassword = (String.IsNullOrEmpty(StringUtil.RTrim( A7UsuarioPassword)) ? true : false);
         A8UsuarioEstado = false;
         AssignAttri("", false, "A8UsuarioEstado", A8UsuarioEstado);
         A1RolId = 0;
         AssignAttri("", false, "A1RolId", StringUtil.LTrimStr( (decimal)(A1RolId), 4, 0));
         Z4UsuarioNombre = "";
         Z5UsuarioApellido = "";
         Z6UsuarioEmail = "";
         Z7UsuarioPassword = "";
         Z8UsuarioEstado = false;
         Z1RolId = 0;
      }

      protected void InitAll022( )
      {
         A3UsuarioId = 0;
         AssignAttri("", false, "A3UsuarioId", StringUtil.LTrimStr( (decimal)(A3UsuarioId), 4, 0));
         InitializeNonKey022( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022101612475422", true, true);
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
         context.AddJavascriptSource("usuarios.js", "?2022101612475422", false, true);
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
         edtUsuarioId_Internalname = "USUARIOID";
         edtUsuarioNombre_Internalname = "USUARIONOMBRE";
         edtUsuarioApellido_Internalname = "USUARIOAPELLIDO";
         edtUsuarioEmail_Internalname = "USUARIOEMAIL";
         edtUsuarioPassword_Internalname = "USUARIOPASSWORD";
         chkUsuarioEstado_Internalname = "USUARIOESTADO";
         edtRolId_Internalname = "ROLID";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_1_Internalname = "PROMPT_1";
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
         Form.Caption = "Usuarios";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtRolId_Jsonclick = "";
         edtRolId_Enabled = 1;
         chkUsuarioEstado.Enabled = 1;
         edtUsuarioPassword_Enabled = 1;
         edtUsuarioEmail_Jsonclick = "";
         edtUsuarioEmail_Enabled = 1;
         edtUsuarioApellido_Jsonclick = "";
         edtUsuarioApellido_Enabled = 1;
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioNombre_Enabled = 1;
         edtUsuarioId_Jsonclick = "";
         edtUsuarioId_Enabled = 1;
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
         chkUsuarioEstado.Name = "USUARIOESTADO";
         chkUsuarioEstado.WebTags = "";
         chkUsuarioEstado.Caption = "";
         AssignProp("", false, chkUsuarioEstado_Internalname, "TitleCaption", chkUsuarioEstado.Caption, true);
         chkUsuarioEstado.CheckedValue = "false";
         A8UsuarioEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A8UsuarioEstado));
         AssignAttri("", false, "A8UsuarioEstado", A8UsuarioEstado);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtUsuarioNombre_Internalname;
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

      public void Valid_Usuarioid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A8UsuarioEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A8UsuarioEstado));
         /*  Sending validation outputs */
         AssignAttri("", false, "A4UsuarioNombre", StringUtil.RTrim( A4UsuarioNombre));
         AssignAttri("", false, "A5UsuarioApellido", StringUtil.RTrim( A5UsuarioApellido));
         AssignAttri("", false, "A6UsuarioEmail", A6UsuarioEmail);
         AssignAttri("", false, "A7UsuarioPassword", StringUtil.RTrim( A7UsuarioPassword));
         AssignAttri("", false, "A8UsuarioEstado", A8UsuarioEstado);
         AssignAttri("", false, "A1RolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1RolId), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z3UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3UsuarioId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4UsuarioNombre", StringUtil.RTrim( Z4UsuarioNombre));
         GxWebStd.gx_hidden_field( context, "Z5UsuarioApellido", StringUtil.RTrim( Z5UsuarioApellido));
         GxWebStd.gx_hidden_field( context, "Z6UsuarioEmail", Z6UsuarioEmail);
         GxWebStd.gx_hidden_field( context, "Z7UsuarioPassword", StringUtil.RTrim( Z7UsuarioPassword));
         GxWebStd.gx_hidden_field( context, "Z8UsuarioEstado", StringUtil.BoolToStr( Z8UsuarioEstado));
         GxWebStd.gx_hidden_field( context, "Z1RolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1RolId), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Rolid( )
      {
         /* Using cursor T000218 */
         pr_default.execute(16, new Object[] {A1RolId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, "ROLID");
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A8UsuarioEstado',fld:'USUARIOESTADO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A8UsuarioEstado',fld:'USUARIOESTADO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A8UsuarioEstado',fld:'USUARIOESTADO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A8UsuarioEstado',fld:'USUARIOESTADO',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'A3UsuarioId',fld:'USUARIOID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A8UsuarioEstado',fld:'USUARIOESTADO',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'A4UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'A5UsuarioApellido',fld:'USUARIOAPELLIDO',pic:''},{av:'A6UsuarioEmail',fld:'USUARIOEMAIL',pic:''},{av:'A7UsuarioPassword',fld:'USUARIOPASSWORD',pic:''},{av:'A1RolId',fld:'ROLID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z3UsuarioId'},{av:'Z4UsuarioNombre'},{av:'Z5UsuarioApellido'},{av:'Z6UsuarioEmail'},{av:'Z7UsuarioPassword'},{av:'Z8UsuarioEstado'},{av:'Z1RolId'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A8UsuarioEstado',fld:'USUARIOESTADO',pic:''}]}");
         setEventMetadata("VALID_USUARIOEMAIL","{handler:'Valid_Usuarioemail',iparms:[{av:'A8UsuarioEstado',fld:'USUARIOESTADO',pic:''}]");
         setEventMetadata("VALID_USUARIOEMAIL",",oparms:[{av:'A8UsuarioEstado',fld:'USUARIOESTADO',pic:''}]}");
         setEventMetadata("VALID_ROLID","{handler:'Valid_Rolid',iparms:[{av:'A1RolId',fld:'ROLID',pic:'ZZZ9'},{av:'A8UsuarioEstado',fld:'USUARIOESTADO',pic:''}]");
         setEventMetadata("VALID_ROLID",",oparms:[{av:'A8UsuarioEstado',fld:'USUARIOESTADO',pic:''}]}");
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
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z4UsuarioNombre = "";
         Z5UsuarioApellido = "";
         Z6UsuarioEmail = "";
         Z7UsuarioPassword = "";
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
         A4UsuarioNombre = "";
         A5UsuarioApellido = "";
         A6UsuarioEmail = "";
         A7UsuarioPassword = "";
         sImgUrl = "";
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
         T00025_A3UsuarioId = new short[1] ;
         T00025_A4UsuarioNombre = new string[] {""} ;
         T00025_n4UsuarioNombre = new bool[] {false} ;
         T00025_A5UsuarioApellido = new string[] {""} ;
         T00025_n5UsuarioApellido = new bool[] {false} ;
         T00025_A6UsuarioEmail = new string[] {""} ;
         T00025_A7UsuarioPassword = new string[] {""} ;
         T00025_n7UsuarioPassword = new bool[] {false} ;
         T00025_A8UsuarioEstado = new bool[] {false} ;
         T00025_A1RolId = new short[1] ;
         T00024_A1RolId = new short[1] ;
         T00026_A1RolId = new short[1] ;
         T00027_A3UsuarioId = new short[1] ;
         T00023_A3UsuarioId = new short[1] ;
         T00023_A4UsuarioNombre = new string[] {""} ;
         T00023_n4UsuarioNombre = new bool[] {false} ;
         T00023_A5UsuarioApellido = new string[] {""} ;
         T00023_n5UsuarioApellido = new bool[] {false} ;
         T00023_A6UsuarioEmail = new string[] {""} ;
         T00023_A7UsuarioPassword = new string[] {""} ;
         T00023_n7UsuarioPassword = new bool[] {false} ;
         T00023_A8UsuarioEstado = new bool[] {false} ;
         T00023_A1RolId = new short[1] ;
         sMode2 = "";
         T00028_A3UsuarioId = new short[1] ;
         T00029_A3UsuarioId = new short[1] ;
         T00022_A3UsuarioId = new short[1] ;
         T00022_A4UsuarioNombre = new string[] {""} ;
         T00022_n4UsuarioNombre = new bool[] {false} ;
         T00022_A5UsuarioApellido = new string[] {""} ;
         T00022_n5UsuarioApellido = new bool[] {false} ;
         T00022_A6UsuarioEmail = new string[] {""} ;
         T00022_A7UsuarioPassword = new string[] {""} ;
         T00022_n7UsuarioPassword = new bool[] {false} ;
         T00022_A8UsuarioEstado = new bool[] {false} ;
         T00022_A1RolId = new short[1] ;
         T000213_A9TableroId = new short[1] ;
         T000213_A12TareaId = new short[1] ;
         T000213_A27ComentarioId = new short[1] ;
         T000214_A9TableroId = new short[1] ;
         T000214_A12TareaId = new short[1] ;
         T000215_A9TableroId = new short[1] ;
         T000215_A18ParticipanteTableroId = new short[1] ;
         T000216_A9TableroId = new short[1] ;
         T000217_A3UsuarioId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ4UsuarioNombre = "";
         ZZ5UsuarioApellido = "";
         ZZ6UsuarioEmail = "";
         ZZ7UsuarioPassword = "";
         T000218_A1RolId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuarios__default(),
            new Object[][] {
                new Object[] {
               T00022_A3UsuarioId, T00022_A4UsuarioNombre, T00022_n4UsuarioNombre, T00022_A5UsuarioApellido, T00022_n5UsuarioApellido, T00022_A6UsuarioEmail, T00022_A7UsuarioPassword, T00022_n7UsuarioPassword, T00022_A8UsuarioEstado, T00022_A1RolId
               }
               , new Object[] {
               T00023_A3UsuarioId, T00023_A4UsuarioNombre, T00023_n4UsuarioNombre, T00023_A5UsuarioApellido, T00023_n5UsuarioApellido, T00023_A6UsuarioEmail, T00023_A7UsuarioPassword, T00023_n7UsuarioPassword, T00023_A8UsuarioEstado, T00023_A1RolId
               }
               , new Object[] {
               T00024_A1RolId
               }
               , new Object[] {
               T00025_A3UsuarioId, T00025_A4UsuarioNombre, T00025_n4UsuarioNombre, T00025_A5UsuarioApellido, T00025_n5UsuarioApellido, T00025_A6UsuarioEmail, T00025_A7UsuarioPassword, T00025_n7UsuarioPassword, T00025_A8UsuarioEstado, T00025_A1RolId
               }
               , new Object[] {
               T00026_A1RolId
               }
               , new Object[] {
               T00027_A3UsuarioId
               }
               , new Object[] {
               T00028_A3UsuarioId
               }
               , new Object[] {
               T00029_A3UsuarioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000213_A9TableroId, T000213_A12TareaId, T000213_A27ComentarioId
               }
               , new Object[] {
               T000214_A9TableroId, T000214_A12TareaId
               }
               , new Object[] {
               T000215_A9TableroId, T000215_A18ParticipanteTableroId
               }
               , new Object[] {
               T000216_A9TableroId
               }
               , new Object[] {
               T000217_A3UsuarioId
               }
               , new Object[] {
               T000218_A1RolId
               }
            }
         );
      }

      private short Z3UsuarioId ;
      private short Z1RolId ;
      private short GxWebError ;
      private short A1RolId ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A3UsuarioId ;
      private short GX_JID ;
      private short RcdFound2 ;
      private short nIsDirty_2 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ3UsuarioId ;
      private short ZZ1RolId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtUsuarioId_Enabled ;
      private int edtUsuarioNombre_Enabled ;
      private int edtUsuarioApellido_Enabled ;
      private int edtUsuarioEmail_Enabled ;
      private int edtUsuarioPassword_Enabled ;
      private int edtRolId_Enabled ;
      private int imgprompt_1_Visible ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z4UsuarioNombre ;
      private string Z5UsuarioApellido ;
      private string Z7UsuarioPassword ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtUsuarioId_Internalname ;
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
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioNombre_Internalname ;
      private string A4UsuarioNombre ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioApellido_Internalname ;
      private string A5UsuarioApellido ;
      private string edtUsuarioApellido_Jsonclick ;
      private string edtUsuarioEmail_Internalname ;
      private string edtUsuarioEmail_Jsonclick ;
      private string edtUsuarioPassword_Internalname ;
      private string A7UsuarioPassword ;
      private string chkUsuarioEstado_Internalname ;
      private string edtRolId_Internalname ;
      private string edtRolId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
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
      private string sMode2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ4UsuarioNombre ;
      private string ZZ5UsuarioApellido ;
      private string ZZ7UsuarioPassword ;
      private bool Z8UsuarioEstado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A8UsuarioEstado ;
      private bool n4UsuarioNombre ;
      private bool n5UsuarioApellido ;
      private bool n7UsuarioPassword ;
      private bool Gx_longc ;
      private bool ZZ8UsuarioEstado ;
      private string Z6UsuarioEmail ;
      private string A6UsuarioEmail ;
      private string ZZ6UsuarioEmail ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkUsuarioEstado ;
      private IDataStoreProvider pr_default ;
      private short[] T00025_A3UsuarioId ;
      private string[] T00025_A4UsuarioNombre ;
      private bool[] T00025_n4UsuarioNombre ;
      private string[] T00025_A5UsuarioApellido ;
      private bool[] T00025_n5UsuarioApellido ;
      private string[] T00025_A6UsuarioEmail ;
      private string[] T00025_A7UsuarioPassword ;
      private bool[] T00025_n7UsuarioPassword ;
      private bool[] T00025_A8UsuarioEstado ;
      private short[] T00025_A1RolId ;
      private short[] T00024_A1RolId ;
      private short[] T00026_A1RolId ;
      private short[] T00027_A3UsuarioId ;
      private short[] T00023_A3UsuarioId ;
      private string[] T00023_A4UsuarioNombre ;
      private bool[] T00023_n4UsuarioNombre ;
      private string[] T00023_A5UsuarioApellido ;
      private bool[] T00023_n5UsuarioApellido ;
      private string[] T00023_A6UsuarioEmail ;
      private string[] T00023_A7UsuarioPassword ;
      private bool[] T00023_n7UsuarioPassword ;
      private bool[] T00023_A8UsuarioEstado ;
      private short[] T00023_A1RolId ;
      private short[] T00028_A3UsuarioId ;
      private short[] T00029_A3UsuarioId ;
      private short[] T00022_A3UsuarioId ;
      private string[] T00022_A4UsuarioNombre ;
      private bool[] T00022_n4UsuarioNombre ;
      private string[] T00022_A5UsuarioApellido ;
      private bool[] T00022_n5UsuarioApellido ;
      private string[] T00022_A6UsuarioEmail ;
      private string[] T00022_A7UsuarioPassword ;
      private bool[] T00022_n7UsuarioPassword ;
      private bool[] T00022_A8UsuarioEstado ;
      private short[] T00022_A1RolId ;
      private short[] T000213_A9TableroId ;
      private short[] T000213_A12TareaId ;
      private short[] T000213_A27ComentarioId ;
      private short[] T000214_A9TableroId ;
      private short[] T000214_A12TareaId ;
      private short[] T000215_A9TableroId ;
      private short[] T000215_A18ParticipanteTableroId ;
      private short[] T000216_A9TableroId ;
      private short[] T000217_A3UsuarioId ;
      private short[] T000218_A1RolId ;
      private GXWebForm Form ;
   }

   public class usuarios__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00025;
          prmT00025 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmT00024;
          prmT00024 = new Object[] {
          new ParDef("@RolId",GXType.Int16,4,0)
          };
          Object[] prmT00026;
          prmT00026 = new Object[] {
          new ParDef("@RolId",GXType.Int16,4,0)
          };
          Object[] prmT00027;
          prmT00027 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmT00028;
          prmT00028 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmT00029;
          prmT00029 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmT000210;
          prmT000210 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0) ,
          new ParDef("@UsuarioNombre",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@UsuarioApellido",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@UsuarioEmail",GXType.NVarChar,100,0) ,
          new ParDef("@UsuarioPassword",GXType.NChar,200,0){Nullable=true} ,
          new ParDef("@UsuarioEstado",GXType.Boolean,4,0) ,
          new ParDef("@RolId",GXType.Int16,4,0)
          };
          Object[] prmT000211;
          prmT000211 = new Object[] {
          new ParDef("@UsuarioNombre",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@UsuarioApellido",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@UsuarioEmail",GXType.NVarChar,100,0) ,
          new ParDef("@UsuarioPassword",GXType.NChar,200,0){Nullable=true} ,
          new ParDef("@UsuarioEstado",GXType.Boolean,4,0) ,
          new ParDef("@RolId",GXType.Int16,4,0) ,
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmT000212;
          prmT000212 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmT000213;
          prmT000213 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmT000214;
          prmT000214 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmT000215;
          prmT000215 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmT000216;
          prmT000216 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmT000217;
          prmT000217 = new Object[] {
          };
          Object[] prmT000218;
          prmT000218 = new Object[] {
          new ParDef("@RolId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [UsuarioId], [UsuarioNombre], [UsuarioApellido], [UsuarioEmail], [UsuarioPassword], [UsuarioEstado], [RolId] FROM [Usuarios] WITH (UPDLOCK) WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [UsuarioId], [UsuarioNombre], [UsuarioApellido], [UsuarioEmail], [UsuarioPassword], [UsuarioEstado], [RolId] FROM [Usuarios] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT [RolId] FROM [Roles] WHERE [RolId] = @RolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT TM1.[UsuarioId], TM1.[UsuarioNombre], TM1.[UsuarioApellido], TM1.[UsuarioEmail], TM1.[UsuarioPassword], TM1.[UsuarioEstado], TM1.[RolId] FROM [Usuarios] TM1 WHERE TM1.[UsuarioId] = @UsuarioId ORDER BY TM1.[UsuarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT [RolId] FROM [Roles] WHERE [RolId] = @RolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00027", "SELECT [UsuarioId] FROM [Usuarios] WHERE [UsuarioId] = @UsuarioId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00028", "SELECT TOP 1 [UsuarioId] FROM [Usuarios] WHERE ( [UsuarioId] > @UsuarioId) ORDER BY [UsuarioId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00029", "SELECT TOP 1 [UsuarioId] FROM [Usuarios] WHERE ( [UsuarioId] < @UsuarioId) ORDER BY [UsuarioId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000210", "INSERT INTO [Usuarios]([UsuarioId], [UsuarioNombre], [UsuarioApellido], [UsuarioEmail], [UsuarioPassword], [UsuarioEstado], [RolId]) VALUES(@UsuarioId, @UsuarioNombre, @UsuarioApellido, @UsuarioEmail, @UsuarioPassword, @UsuarioEstado, @RolId)", GxErrorMask.GX_NOMASK,prmT000210)
             ,new CursorDef("T000211", "UPDATE [Usuarios] SET [UsuarioNombre]=@UsuarioNombre, [UsuarioApellido]=@UsuarioApellido, [UsuarioEmail]=@UsuarioEmail, [UsuarioPassword]=@UsuarioPassword, [UsuarioEstado]=@UsuarioEstado, [RolId]=@RolId  WHERE [UsuarioId] = @UsuarioId", GxErrorMask.GX_NOMASK,prmT000211)
             ,new CursorDef("T000212", "DELETE FROM [Usuarios]  WHERE [UsuarioId] = @UsuarioId", GxErrorMask.GX_NOMASK,prmT000212)
             ,new CursorDef("T000213", "SELECT TOP 1 [TableroId], [TareaId], [ComentarioId] FROM [TareasComentarios] WHERE [ComentaristaId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000214", "SELECT TOP 1 [TableroId], [TareaId] FROM [Tareas] WHERE [ResponsableId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000215", "SELECT TOP 1 [TableroId], [ParticipanteTableroId] FROM [Participantes] WHERE [ParticipanteTableroId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000216", "SELECT TOP 1 [TableroId] FROM [Tableros] WHERE [PropietarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000217", "SELECT [UsuarioId] FROM [Usuarios] ORDER BY [UsuarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000218", "SELECT [RolId] FROM [Roles] WHERE [RolId] = @RolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 200);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((short[]) buf[9])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 200);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((short[]) buf[9])[0] = rslt.getShort(7);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 200);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((short[]) buf[9])[0] = rslt.getShort(7);
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
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
