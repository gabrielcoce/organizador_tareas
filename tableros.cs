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
   public class tableros : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A17PropietarioId = (short)(NumberUtil.Val( GetPar( "PropietarioId"), "."));
            AssignAttri("", false, "A17PropietarioId", StringUtil.LTrimStr( (decimal)(A17PropietarioId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A17PropietarioId) ;
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
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_8-158023", 0) ;
            }
            Form.Meta.addItem("description", "Tableros", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tableros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public tableros( IGxContext context )
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
         chkTableroEstado = new GXCheckbox();
         chkTableroVisibilidad = new GXCheckbox();
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
         A34TableroEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A34TableroEstado));
         AssignAttri("", false, "A34TableroEstado", A34TableroEstado);
         A35TableroVisibilidad = StringUtil.StrToBool( StringUtil.BoolToStr( A35TableroVisibilidad));
         AssignAttri("", false, "A35TableroVisibilidad", A35TableroVisibilidad);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tableros", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Tableros.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TABLEROID"+"'), id:'"+"TABLEROID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Tableros.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTableroId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTableroId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTableroId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")), StringUtil.LTrim( ((edtTableroId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9") : context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTableroId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTableroId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Tableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTableroNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTableroNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTableroNombre_Internalname, StringUtil.RTrim( A10TableroNombre), StringUtil.RTrim( context.localUtil.Format( A10TableroNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTableroNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTableroNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Tableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTableroFechaCreacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTableroFechaCreacion_Internalname, "Fecha Creacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTableroFechaCreacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTableroFechaCreacion_Internalname, context.localUtil.TToC( A11TableroFechaCreacion, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A11TableroFechaCreacion, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTableroFechaCreacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTableroFechaCreacion_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Tableros.htm");
         GxWebStd.gx_bitmap( context, edtTableroFechaCreacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTableroFechaCreacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Tableros.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPropietarioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropietarioId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropietarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17PropietarioId), 4, 0, ",", "")), StringUtil.LTrim( ((edtPropietarioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A17PropietarioId), "ZZZ9") : context.localUtil.Format( (decimal)(A17PropietarioId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropietarioId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPropietarioId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Tableros.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_17_Internalname, sImgUrl, imgprompt_17_Link, "", "", context.GetTheme( ), imgprompt_17_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Tableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkTableroEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTableroEstado_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTableroEstado_Internalname, StringUtil.BoolToStr( A34TableroEstado), "", "Estado", 1, chkTableroEstado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(54, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,54);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkTableroVisibilidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTableroVisibilidad_Internalname, "Visibilidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTableroVisibilidad_Internalname, StringUtil.BoolToStr( A35TableroVisibilidad), "", "Visibilidad", 1, chkTableroVisibilidad.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tableros.htm");
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
            Z9TableroId = (short)(context.localUtil.CToN( cgiGet( "Z9TableroId"), ",", "."));
            Z10TableroNombre = cgiGet( "Z10TableroNombre");
            Z11TableroFechaCreacion = context.localUtil.CToT( cgiGet( "Z11TableroFechaCreacion"), 0);
            Z34TableroEstado = StringUtil.StrToBool( cgiGet( "Z34TableroEstado"));
            Z35TableroVisibilidad = StringUtil.StrToBool( cgiGet( "Z35TableroVisibilidad"));
            Z17PropietarioId = (short)(context.localUtil.CToN( cgiGet( "Z17PropietarioId"), ",", "."));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTableroId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTableroId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TABLEROID");
               AnyError = 1;
               GX_FocusControl = edtTableroId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A9TableroId = 0;
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            }
            else
            {
               A9TableroId = (short)(context.localUtil.CToN( cgiGet( edtTableroId_Internalname), ",", "."));
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            }
            A10TableroNombre = cgiGet( edtTableroNombre_Internalname);
            AssignAttri("", false, "A10TableroNombre", A10TableroNombre);
            if ( context.localUtil.VCDateTime( cgiGet( edtTableroFechaCreacion_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Tablero Fecha Creacion"}), 1, "TABLEROFECHACREACION");
               AnyError = 1;
               GX_FocusControl = edtTableroFechaCreacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A11TableroFechaCreacion = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A11TableroFechaCreacion", context.localUtil.TToC( A11TableroFechaCreacion, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A11TableroFechaCreacion = context.localUtil.CToT( cgiGet( edtTableroFechaCreacion_Internalname));
               AssignAttri("", false, "A11TableroFechaCreacion", context.localUtil.TToC( A11TableroFechaCreacion, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPropietarioId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropietarioId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPIETARIOID");
               AnyError = 1;
               GX_FocusControl = edtPropietarioId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A17PropietarioId = 0;
               AssignAttri("", false, "A17PropietarioId", StringUtil.LTrimStr( (decimal)(A17PropietarioId), 4, 0));
            }
            else
            {
               A17PropietarioId = (short)(context.localUtil.CToN( cgiGet( edtPropietarioId_Internalname), ",", "."));
               AssignAttri("", false, "A17PropietarioId", StringUtil.LTrimStr( (decimal)(A17PropietarioId), 4, 0));
            }
            A34TableroEstado = StringUtil.StrToBool( cgiGet( chkTableroEstado_Internalname));
            AssignAttri("", false, "A34TableroEstado", A34TableroEstado);
            A35TableroVisibilidad = StringUtil.StrToBool( cgiGet( chkTableroVisibilidad_Internalname));
            AssignAttri("", false, "A35TableroVisibilidad", A35TableroVisibilidad);
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
               A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
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
               InitAll033( ) ;
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
         DisableAttributes033( ) ;
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

      protected void ResetCaption030( )
      {
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z10TableroNombre = T00033_A10TableroNombre[0];
               Z11TableroFechaCreacion = T00033_A11TableroFechaCreacion[0];
               Z34TableroEstado = T00033_A34TableroEstado[0];
               Z35TableroVisibilidad = T00033_A35TableroVisibilidad[0];
               Z17PropietarioId = T00033_A17PropietarioId[0];
            }
            else
            {
               Z10TableroNombre = A10TableroNombre;
               Z11TableroFechaCreacion = A11TableroFechaCreacion;
               Z34TableroEstado = A34TableroEstado;
               Z35TableroVisibilidad = A35TableroVisibilidad;
               Z17PropietarioId = A17PropietarioId;
            }
         }
         if ( GX_JID == -3 )
         {
            Z9TableroId = A9TableroId;
            Z10TableroNombre = A10TableroNombre;
            Z11TableroFechaCreacion = A11TableroFechaCreacion;
            Z34TableroEstado = A34TableroEstado;
            Z35TableroVisibilidad = A35TableroVisibilidad;
            Z17PropietarioId = A17PropietarioId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_17_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROPIETARIOID"+"'), id:'"+"PROPIETARIOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load033( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
            A10TableroNombre = T00035_A10TableroNombre[0];
            AssignAttri("", false, "A10TableroNombre", A10TableroNombre);
            A11TableroFechaCreacion = T00035_A11TableroFechaCreacion[0];
            AssignAttri("", false, "A11TableroFechaCreacion", context.localUtil.TToC( A11TableroFechaCreacion, 8, 5, 0, 3, "/", ":", " "));
            A34TableroEstado = T00035_A34TableroEstado[0];
            AssignAttri("", false, "A34TableroEstado", A34TableroEstado);
            A35TableroVisibilidad = T00035_A35TableroVisibilidad[0];
            AssignAttri("", false, "A35TableroVisibilidad", A35TableroVisibilidad);
            A17PropietarioId = T00035_A17PropietarioId[0];
            AssignAttri("", false, "A17PropietarioId", StringUtil.LTrimStr( (decimal)(A17PropietarioId), 4, 0));
            ZM033( -3) ;
         }
         pr_default.close(3);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A11TableroFechaCreacion) || ( A11TableroFechaCreacion >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Tablero Fecha Creacion fuera de rango", "OutOfRange", 1, "TABLEROFECHACREACION");
            AnyError = 1;
            GX_FocusControl = edtTableroFechaCreacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A17PropietarioId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Propietario'.", "ForeignKeyNotFound", 1, "PROPIETARIOID");
            AnyError = 1;
            GX_FocusControl = edtPropietarioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( A11TableroFechaCreacion < Gx_date )
         {
            GX_msglist.addItem("La fecha del tablero no puede ser menor al dia de hoy", 1, "TABLEROFECHACREACION");
            AnyError = 1;
            GX_FocusControl = edtTableroFechaCreacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors033( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( short A17PropietarioId )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A17PropietarioId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Propietario'.", "ForeignKeyNotFound", 1, "PROPIETARIOID");
            AnyError = 1;
            GX_FocusControl = edtPropietarioId_Internalname;
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

      protected void GetKey033( )
      {
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 3) ;
            RcdFound3 = 1;
            A9TableroId = T00033_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A10TableroNombre = T00033_A10TableroNombre[0];
            AssignAttri("", false, "A10TableroNombre", A10TableroNombre);
            A11TableroFechaCreacion = T00033_A11TableroFechaCreacion[0];
            AssignAttri("", false, "A11TableroFechaCreacion", context.localUtil.TToC( A11TableroFechaCreacion, 8, 5, 0, 3, "/", ":", " "));
            A34TableroEstado = T00033_A34TableroEstado[0];
            AssignAttri("", false, "A34TableroEstado", A34TableroEstado);
            A35TableroVisibilidad = T00033_A35TableroVisibilidad[0];
            AssignAttri("", false, "A35TableroVisibilidad", A35TableroVisibilidad);
            A17PropietarioId = T00033_A17PropietarioId[0];
            AssignAttri("", false, "A17PropietarioId", StringUtil.LTrimStr( (decimal)(A17PropietarioId), 4, 0));
            Z9TableroId = A9TableroId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
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
         RcdFound3 = 0;
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00038_A9TableroId[0] < A9TableroId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00038_A9TableroId[0] > A9TableroId ) ) )
            {
               A9TableroId = T00038_A9TableroId[0];
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00039_A9TableroId[0] > A9TableroId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00039_A9TableroId[0] < A9TableroId ) ) )
            {
               A9TableroId = T00039_A9TableroId[0];
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A9TableroId != Z9TableroId )
               {
                  A9TableroId = Z9TableroId;
                  AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TABLEROID");
                  AnyError = 1;
                  GX_FocusControl = edtTableroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTableroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update033( ) ;
                  GX_FocusControl = edtTableroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A9TableroId != Z9TableroId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTableroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TABLEROID");
                     AnyError = 1;
                     GX_FocusControl = edtTableroId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTableroId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert033( ) ;
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
         if ( A9TableroId != Z9TableroId )
         {
            A9TableroId = Z9TableroId;
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTableroId_Internalname;
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
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTableroNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTableroNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd033( ) ;
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
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTableroNombre_Internalname;
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
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTableroNombre_Internalname;
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
         ScanStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound3 != 0 )
            {
               ScanNext033( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTableroNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd033( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tableros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z10TableroNombre, T00032_A10TableroNombre[0]) != 0 ) || ( Z11TableroFechaCreacion != T00032_A11TableroFechaCreacion[0] ) || ( Z34TableroEstado != T00032_A34TableroEstado[0] ) || ( Z35TableroVisibilidad != T00032_A35TableroVisibilidad[0] ) || ( Z17PropietarioId != T00032_A17PropietarioId[0] ) )
            {
               if ( StringUtil.StrCmp(Z10TableroNombre, T00032_A10TableroNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("tableros:[seudo value changed for attri]"+"TableroNombre");
                  GXUtil.WriteLogRaw("Old: ",Z10TableroNombre);
                  GXUtil.WriteLogRaw("Current: ",T00032_A10TableroNombre[0]);
               }
               if ( Z11TableroFechaCreacion != T00032_A11TableroFechaCreacion[0] )
               {
                  GXUtil.WriteLog("tableros:[seudo value changed for attri]"+"TableroFechaCreacion");
                  GXUtil.WriteLogRaw("Old: ",Z11TableroFechaCreacion);
                  GXUtil.WriteLogRaw("Current: ",T00032_A11TableroFechaCreacion[0]);
               }
               if ( Z34TableroEstado != T00032_A34TableroEstado[0] )
               {
                  GXUtil.WriteLog("tableros:[seudo value changed for attri]"+"TableroEstado");
                  GXUtil.WriteLogRaw("Old: ",Z34TableroEstado);
                  GXUtil.WriteLogRaw("Current: ",T00032_A34TableroEstado[0]);
               }
               if ( Z35TableroVisibilidad != T00032_A35TableroVisibilidad[0] )
               {
                  GXUtil.WriteLog("tableros:[seudo value changed for attri]"+"TableroVisibilidad");
                  GXUtil.WriteLogRaw("Old: ",Z35TableroVisibilidad);
                  GXUtil.WriteLogRaw("Current: ",T00032_A35TableroVisibilidad[0]);
               }
               if ( Z17PropietarioId != T00032_A17PropietarioId[0] )
               {
                  GXUtil.WriteLog("tableros:[seudo value changed for attri]"+"PropietarioId");
                  GXUtil.WriteLogRaw("Old: ",Z17PropietarioId);
                  GXUtil.WriteLogRaw("Current: ",T00032_A17PropietarioId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Tableros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000310 */
                     pr_default.execute(8, new Object[] {A9TableroId, A10TableroNombre, A11TableroFechaCreacion, A34TableroEstado, A35TableroVisibilidad, A17PropietarioId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Tableros");
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
                           ResetCaption030( ) ;
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000311 */
                     pr_default.execute(9, new Object[] {A10TableroNombre, A11TableroFechaCreacion, A34TableroEstado, A35TableroVisibilidad, A17PropietarioId, A9TableroId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Tableros");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tableros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption030( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000312 */
                  pr_default.execute(10, new Object[] {A9TableroId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("Tableros");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound3 == 0 )
                        {
                           InitAll033( ) ;
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
                        ResetCaption030( ) ;
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000313 */
            pr_default.execute(11, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {" T10"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000314 */
            pr_default.execute(12, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Participantes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000315 */
            pr_default.execute(13, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tableros Etiquetas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000316 */
            pr_default.execute(14, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Actividades"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000317 */
            pr_default.execute(15, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tareas Comentarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000318 */
            pr_default.execute(16, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Listas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tableros",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tableros",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Using cursor T000319 */
         pr_default.execute(17);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound3 = 1;
            A9TableroId = T000319_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound3 = 1;
            A9TableroId = T000319_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtTableroId_Enabled = 0;
         AssignProp("", false, edtTableroId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTableroId_Enabled), 5, 0), true);
         edtTableroNombre_Enabled = 0;
         AssignProp("", false, edtTableroNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTableroNombre_Enabled), 5, 0), true);
         edtTableroFechaCreacion_Enabled = 0;
         AssignProp("", false, edtTableroFechaCreacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTableroFechaCreacion_Enabled), 5, 0), true);
         edtPropietarioId_Enabled = 0;
         AssignProp("", false, edtPropietarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropietarioId_Enabled), 5, 0), true);
         chkTableroEstado.Enabled = 0;
         AssignProp("", false, chkTableroEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTableroEstado.Enabled), 5, 0), true);
         chkTableroVisibilidad.Enabled = 0;
         AssignProp("", false, chkTableroVisibilidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTableroVisibilidad.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1940340), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20229920474221", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 1940340), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tableros.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z9TableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z10TableroNombre", StringUtil.RTrim( Z10TableroNombre));
         GxWebStd.gx_hidden_field( context, "Z11TableroFechaCreacion", context.localUtil.TToC( Z11TableroFechaCreacion, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z34TableroEstado", Z34TableroEstado);
         GxWebStd.gx_boolean_hidden_field( context, "Z35TableroVisibilidad", Z35TableroVisibilidad);
         GxWebStd.gx_hidden_field( context, "Z17PropietarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17PropietarioId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
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
         return formatLink("tableros.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Tableros" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tableros" ;
      }

      protected void InitializeNonKey033( )
      {
         A10TableroNombre = "";
         AssignAttri("", false, "A10TableroNombre", A10TableroNombre);
         A11TableroFechaCreacion = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A11TableroFechaCreacion", context.localUtil.TToC( A11TableroFechaCreacion, 8, 5, 0, 3, "/", ":", " "));
         A17PropietarioId = 0;
         AssignAttri("", false, "A17PropietarioId", StringUtil.LTrimStr( (decimal)(A17PropietarioId), 4, 0));
         A34TableroEstado = false;
         AssignAttri("", false, "A34TableroEstado", A34TableroEstado);
         A35TableroVisibilidad = false;
         AssignAttri("", false, "A35TableroVisibilidad", A35TableroVisibilidad);
         Z10TableroNombre = "";
         Z11TableroFechaCreacion = (DateTime)(DateTime.MinValue);
         Z34TableroEstado = false;
         Z35TableroVisibilidad = false;
         Z17PropietarioId = 0;
      }

      protected void InitAll033( )
      {
         A9TableroId = 0;
         AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
         InitializeNonKey033( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20229920474224", true, true);
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
         context.AddJavascriptSource("tableros.js", "?20229920474224", false, true);
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
         edtTableroId_Internalname = "TABLEROID";
         edtTableroNombre_Internalname = "TABLERONOMBRE";
         edtTableroFechaCreacion_Internalname = "TABLEROFECHACREACION";
         edtPropietarioId_Internalname = "PROPIETARIOID";
         chkTableroEstado_Internalname = "TABLEROESTADO";
         chkTableroVisibilidad_Internalname = "TABLEROVISIBILIDAD";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_17_Internalname = "PROMPT_17";
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
         Form.Caption = "Tableros";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkTableroVisibilidad.Enabled = 1;
         chkTableroEstado.Enabled = 1;
         imgprompt_17_Visible = 1;
         imgprompt_17_Link = "";
         edtPropietarioId_Jsonclick = "";
         edtPropietarioId_Enabled = 1;
         edtTableroFechaCreacion_Jsonclick = "";
         edtTableroFechaCreacion_Enabled = 1;
         edtTableroNombre_Jsonclick = "";
         edtTableroNombre_Enabled = 1;
         edtTableroId_Jsonclick = "";
         edtTableroId_Enabled = 1;
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
         chkTableroEstado.Name = "TABLEROESTADO";
         chkTableroEstado.WebTags = "";
         chkTableroEstado.Caption = "";
         AssignProp("", false, chkTableroEstado_Internalname, "TitleCaption", chkTableroEstado.Caption, true);
         chkTableroEstado.CheckedValue = "false";
         A34TableroEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A34TableroEstado));
         AssignAttri("", false, "A34TableroEstado", A34TableroEstado);
         chkTableroVisibilidad.Name = "TABLEROVISIBILIDAD";
         chkTableroVisibilidad.WebTags = "";
         chkTableroVisibilidad.Caption = "";
         AssignProp("", false, chkTableroVisibilidad_Internalname, "TitleCaption", chkTableroVisibilidad.Caption, true);
         chkTableroVisibilidad.CheckedValue = "false";
         A35TableroVisibilidad = StringUtil.StrToBool( StringUtil.BoolToStr( A35TableroVisibilidad));
         AssignAttri("", false, "A35TableroVisibilidad", A35TableroVisibilidad);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTableroNombre_Internalname;
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

      public void Valid_Tableroid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A34TableroEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A34TableroEstado));
         A35TableroVisibilidad = StringUtil.StrToBool( StringUtil.BoolToStr( A35TableroVisibilidad));
         /*  Sending validation outputs */
         AssignAttri("", false, "A10TableroNombre", StringUtil.RTrim( A10TableroNombre));
         AssignAttri("", false, "A11TableroFechaCreacion", context.localUtil.TToC( A11TableroFechaCreacion, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A17PropietarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A17PropietarioId), 4, 0, ".", "")));
         AssignAttri("", false, "A34TableroEstado", A34TableroEstado);
         AssignAttri("", false, "A35TableroVisibilidad", A35TableroVisibilidad);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z9TableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9TableroId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10TableroNombre", StringUtil.RTrim( Z10TableroNombre));
         GxWebStd.gx_hidden_field( context, "Z11TableroFechaCreacion", context.localUtil.TToC( Z11TableroFechaCreacion, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z17PropietarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17PropietarioId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z34TableroEstado", StringUtil.BoolToStr( Z34TableroEstado));
         GxWebStd.gx_hidden_field( context, "Z35TableroVisibilidad", StringUtil.BoolToStr( Z35TableroVisibilidad));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Propietarioid( )
      {
         /* Using cursor T000320 */
         pr_default.execute(18, new Object[] {A17PropietarioId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Propietario'.", "ForeignKeyNotFound", 1, "PROPIETARIOID");
            AnyError = 1;
            GX_FocusControl = edtPropietarioId_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A34TableroEstado',fld:'TABLEROESTADO',pic:''},{av:'A35TableroVisibilidad',fld:'TABLEROVISIBILIDAD',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A34TableroEstado',fld:'TABLEROESTADO',pic:''},{av:'A35TableroVisibilidad',fld:'TABLEROVISIBILIDAD',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A34TableroEstado',fld:'TABLEROESTADO',pic:''},{av:'A35TableroVisibilidad',fld:'TABLEROVISIBILIDAD',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A34TableroEstado',fld:'TABLEROESTADO',pic:''},{av:'A35TableroVisibilidad',fld:'TABLEROVISIBILIDAD',pic:''}]}");
         setEventMetadata("VALID_TABLEROID","{handler:'Valid_Tableroid',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A34TableroEstado',fld:'TABLEROESTADO',pic:''},{av:'A35TableroVisibilidad',fld:'TABLEROVISIBILIDAD',pic:''}]");
         setEventMetadata("VALID_TABLEROID",",oparms:[{av:'A10TableroNombre',fld:'TABLERONOMBRE',pic:''},{av:'A11TableroFechaCreacion',fld:'TABLEROFECHACREACION',pic:'99/99/99 99:99'},{av:'A17PropietarioId',fld:'PROPIETARIOID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z9TableroId'},{av:'Z10TableroNombre'},{av:'Z11TableroFechaCreacion'},{av:'Z17PropietarioId'},{av:'Z34TableroEstado'},{av:'Z35TableroVisibilidad'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A34TableroEstado',fld:'TABLEROESTADO',pic:''},{av:'A35TableroVisibilidad',fld:'TABLEROVISIBILIDAD',pic:''}]}");
         setEventMetadata("VALID_TABLEROFECHACREACION","{handler:'Valid_Tablerofechacreacion',iparms:[{av:'A34TableroEstado',fld:'TABLEROESTADO',pic:''},{av:'A35TableroVisibilidad',fld:'TABLEROVISIBILIDAD',pic:''}]");
         setEventMetadata("VALID_TABLEROFECHACREACION",",oparms:[{av:'A34TableroEstado',fld:'TABLEROESTADO',pic:''},{av:'A35TableroVisibilidad',fld:'TABLEROVISIBILIDAD',pic:''}]}");
         setEventMetadata("VALID_PROPIETARIOID","{handler:'Valid_Propietarioid',iparms:[{av:'A17PropietarioId',fld:'PROPIETARIOID',pic:'ZZZ9'},{av:'A34TableroEstado',fld:'TABLEROESTADO',pic:''},{av:'A35TableroVisibilidad',fld:'TABLEROVISIBILIDAD',pic:''}]");
         setEventMetadata("VALID_PROPIETARIOID",",oparms:[{av:'A34TableroEstado',fld:'TABLEROESTADO',pic:''},{av:'A35TableroVisibilidad',fld:'TABLEROVISIBILIDAD',pic:''}]}");
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
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z10TableroNombre = "";
         Z11TableroFechaCreacion = (DateTime)(DateTime.MinValue);
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
         A10TableroNombre = "";
         A11TableroFechaCreacion = (DateTime)(DateTime.MinValue);
         sImgUrl = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         Gx_date = DateTime.MinValue;
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T00035_A9TableroId = new short[1] ;
         T00035_A10TableroNombre = new string[] {""} ;
         T00035_A11TableroFechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00035_A34TableroEstado = new bool[] {false} ;
         T00035_A35TableroVisibilidad = new bool[] {false} ;
         T00035_A17PropietarioId = new short[1] ;
         T00034_A17PropietarioId = new short[1] ;
         T00036_A17PropietarioId = new short[1] ;
         T00037_A9TableroId = new short[1] ;
         T00033_A9TableroId = new short[1] ;
         T00033_A10TableroNombre = new string[] {""} ;
         T00033_A11TableroFechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00033_A34TableroEstado = new bool[] {false} ;
         T00033_A35TableroVisibilidad = new bool[] {false} ;
         T00033_A17PropietarioId = new short[1] ;
         sMode3 = "";
         T00038_A9TableroId = new short[1] ;
         T00039_A9TableroId = new short[1] ;
         T00032_A9TableroId = new short[1] ;
         T00032_A10TableroNombre = new string[] {""} ;
         T00032_A11TableroFechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00032_A34TableroEstado = new bool[] {false} ;
         T00032_A35TableroVisibilidad = new bool[] {false} ;
         T00032_A17PropietarioId = new short[1] ;
         T000313_A9TableroId = new short[1] ;
         T000313_A40RegistroInvitadoId = new short[1] ;
         T000314_A9TableroId = new short[1] ;
         T000314_A18ParticipanteTableroId = new short[1] ;
         T000315_A9TableroId = new short[1] ;
         T000315_A36EtiquetaId = new short[1] ;
         T000316_A9TableroId = new short[1] ;
         T000316_A12TareaId = new short[1] ;
         T000316_A30ActividadId = new short[1] ;
         T000317_A9TableroId = new short[1] ;
         T000317_A12TareaId = new short[1] ;
         T000317_A27ComentarioId = new short[1] ;
         T000318_A9TableroId = new short[1] ;
         T000318_A21ListaId = new short[1] ;
         T000319_A9TableroId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ10TableroNombre = "";
         ZZ11TableroFechaCreacion = (DateTime)(DateTime.MinValue);
         T000320_A17PropietarioId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tableros__default(),
            new Object[][] {
                new Object[] {
               T00032_A9TableroId, T00032_A10TableroNombre, T00032_A11TableroFechaCreacion, T00032_A34TableroEstado, T00032_A35TableroVisibilidad, T00032_A17PropietarioId
               }
               , new Object[] {
               T00033_A9TableroId, T00033_A10TableroNombre, T00033_A11TableroFechaCreacion, T00033_A34TableroEstado, T00033_A35TableroVisibilidad, T00033_A17PropietarioId
               }
               , new Object[] {
               T00034_A17PropietarioId
               }
               , new Object[] {
               T00035_A9TableroId, T00035_A10TableroNombre, T00035_A11TableroFechaCreacion, T00035_A34TableroEstado, T00035_A35TableroVisibilidad, T00035_A17PropietarioId
               }
               , new Object[] {
               T00036_A17PropietarioId
               }
               , new Object[] {
               T00037_A9TableroId
               }
               , new Object[] {
               T00038_A9TableroId
               }
               , new Object[] {
               T00039_A9TableroId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000313_A9TableroId, T000313_A40RegistroInvitadoId
               }
               , new Object[] {
               T000314_A9TableroId, T000314_A18ParticipanteTableroId
               }
               , new Object[] {
               T000315_A9TableroId, T000315_A36EtiquetaId
               }
               , new Object[] {
               T000316_A9TableroId, T000316_A12TareaId, T000316_A30ActividadId
               }
               , new Object[] {
               T000317_A9TableroId, T000317_A12TareaId, T000317_A27ComentarioId
               }
               , new Object[] {
               T000318_A9TableroId, T000318_A21ListaId
               }
               , new Object[] {
               T000319_A9TableroId
               }
               , new Object[] {
               T000320_A17PropietarioId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
      }

      private short Z9TableroId ;
      private short Z17PropietarioId ;
      private short GxWebError ;
      private short A17PropietarioId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A9TableroId ;
      private short GX_JID ;
      private short RcdFound3 ;
      private short nIsDirty_3 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ9TableroId ;
      private short ZZ17PropietarioId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTableroId_Enabled ;
      private int edtTableroNombre_Enabled ;
      private int edtTableroFechaCreacion_Enabled ;
      private int edtPropietarioId_Enabled ;
      private int imgprompt_17_Visible ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z10TableroNombre ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTableroId_Internalname ;
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
      private string edtTableroId_Jsonclick ;
      private string edtTableroNombre_Internalname ;
      private string A10TableroNombre ;
      private string edtTableroNombre_Jsonclick ;
      private string edtTableroFechaCreacion_Internalname ;
      private string edtTableroFechaCreacion_Jsonclick ;
      private string edtPropietarioId_Internalname ;
      private string edtPropietarioId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_17_Internalname ;
      private string imgprompt_17_Link ;
      private string chkTableroEstado_Internalname ;
      private string chkTableroVisibilidad_Internalname ;
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
      private string sMode3 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ10TableroNombre ;
      private DateTime Z11TableroFechaCreacion ;
      private DateTime A11TableroFechaCreacion ;
      private DateTime ZZ11TableroFechaCreacion ;
      private DateTime Gx_date ;
      private bool Z34TableroEstado ;
      private bool Z35TableroVisibilidad ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A34TableroEstado ;
      private bool A35TableroVisibilidad ;
      private bool ZZ34TableroEstado ;
      private bool ZZ35TableroVisibilidad ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkTableroEstado ;
      private GXCheckbox chkTableroVisibilidad ;
      private IDataStoreProvider pr_default ;
      private short[] T00035_A9TableroId ;
      private string[] T00035_A10TableroNombre ;
      private DateTime[] T00035_A11TableroFechaCreacion ;
      private bool[] T00035_A34TableroEstado ;
      private bool[] T00035_A35TableroVisibilidad ;
      private short[] T00035_A17PropietarioId ;
      private short[] T00034_A17PropietarioId ;
      private short[] T00036_A17PropietarioId ;
      private short[] T00037_A9TableroId ;
      private short[] T00033_A9TableroId ;
      private string[] T00033_A10TableroNombre ;
      private DateTime[] T00033_A11TableroFechaCreacion ;
      private bool[] T00033_A34TableroEstado ;
      private bool[] T00033_A35TableroVisibilidad ;
      private short[] T00033_A17PropietarioId ;
      private short[] T00038_A9TableroId ;
      private short[] T00039_A9TableroId ;
      private short[] T00032_A9TableroId ;
      private string[] T00032_A10TableroNombre ;
      private DateTime[] T00032_A11TableroFechaCreacion ;
      private bool[] T00032_A34TableroEstado ;
      private bool[] T00032_A35TableroVisibilidad ;
      private short[] T00032_A17PropietarioId ;
      private short[] T000313_A9TableroId ;
      private short[] T000313_A40RegistroInvitadoId ;
      private short[] T000314_A9TableroId ;
      private short[] T000314_A18ParticipanteTableroId ;
      private short[] T000315_A9TableroId ;
      private short[] T000315_A36EtiquetaId ;
      private short[] T000316_A9TableroId ;
      private short[] T000316_A12TareaId ;
      private short[] T000316_A30ActividadId ;
      private short[] T000317_A9TableroId ;
      private short[] T000317_A12TareaId ;
      private short[] T000317_A27ComentarioId ;
      private short[] T000318_A9TableroId ;
      private short[] T000318_A21ListaId ;
      private short[] T000319_A9TableroId ;
      private short[] T000320_A17PropietarioId ;
      private GXWebForm Form ;
   }

   public class tableros__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00035;
          prmT00035 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT00034;
          prmT00034 = new Object[] {
          new ParDef("@PropietarioId",GXType.Int16,4,0)
          };
          Object[] prmT00036;
          prmT00036 = new Object[] {
          new ParDef("@PropietarioId",GXType.Int16,4,0)
          };
          Object[] prmT00037;
          prmT00037 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT00033;
          prmT00033 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT00038;
          prmT00038 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT00039;
          prmT00039 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT00032;
          prmT00032 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000310;
          prmT000310 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TableroNombre",GXType.NChar,100,0) ,
          new ParDef("@TableroFechaCreacion",GXType.DateTime,8,5) ,
          new ParDef("@TableroEstado",GXType.Boolean,4,0) ,
          new ParDef("@TableroVisibilidad",GXType.Boolean,1,0) ,
          new ParDef("@PropietarioId",GXType.Int16,4,0)
          };
          Object[] prmT000311;
          prmT000311 = new Object[] {
          new ParDef("@TableroNombre",GXType.NChar,100,0) ,
          new ParDef("@TableroFechaCreacion",GXType.DateTime,8,5) ,
          new ParDef("@TableroEstado",GXType.Boolean,4,0) ,
          new ParDef("@TableroVisibilidad",GXType.Boolean,1,0) ,
          new ParDef("@PropietarioId",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000312;
          prmT000312 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000313;
          prmT000313 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000314;
          prmT000314 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000315;
          prmT000315 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000316;
          prmT000316 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000317;
          prmT000317 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000318;
          prmT000318 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000319;
          prmT000319 = new Object[] {
          };
          Object[] prmT000320;
          prmT000320 = new Object[] {
          new ParDef("@PropietarioId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [TableroId], [TableroNombre], [TableroFechaCreacion], [TableroEstado], [TableroVisibilidad], [PropietarioId] AS PropietarioId FROM [Tableros] WITH (UPDLOCK) WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00033", "SELECT [TableroId], [TableroNombre], [TableroFechaCreacion], [TableroEstado], [TableroVisibilidad], [PropietarioId] AS PropietarioId FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00034", "SELECT [UsuarioId] AS PropietarioId FROM [Usuarios] WHERE [UsuarioId] = @PropietarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00035", "SELECT TM1.[TableroId], TM1.[TableroNombre], TM1.[TableroFechaCreacion], TM1.[TableroEstado], TM1.[TableroVisibilidad], TM1.[PropietarioId] AS PropietarioId FROM [Tableros] TM1 WHERE TM1.[TableroId] = @TableroId ORDER BY TM1.[TableroId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00036", "SELECT [UsuarioId] AS PropietarioId FROM [Usuarios] WHERE [UsuarioId] = @PropietarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00037", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00038", "SELECT TOP 1 [TableroId] FROM [Tableros] WHERE ( [TableroId] > @TableroId) ORDER BY [TableroId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00039", "SELECT TOP 1 [TableroId] FROM [Tableros] WHERE ( [TableroId] < @TableroId) ORDER BY [TableroId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000310", "INSERT INTO [Tableros]([TableroId], [TableroNombre], [TableroFechaCreacion], [TableroEstado], [TableroVisibilidad], [PropietarioId]) VALUES(@TableroId, @TableroNombre, @TableroFechaCreacion, @TableroEstado, @TableroVisibilidad, @PropietarioId)", GxErrorMask.GX_NOMASK,prmT000310)
             ,new CursorDef("T000311", "UPDATE [Tableros] SET [TableroNombre]=@TableroNombre, [TableroFechaCreacion]=@TableroFechaCreacion, [TableroEstado]=@TableroEstado, [TableroVisibilidad]=@TableroVisibilidad, [PropietarioId]=@PropietarioId  WHERE [TableroId] = @TableroId", GxErrorMask.GX_NOMASK,prmT000311)
             ,new CursorDef("T000312", "DELETE FROM [Tableros]  WHERE [TableroId] = @TableroId", GxErrorMask.GX_NOMASK,prmT000312)
             ,new CursorDef("T000313", "SELECT TOP 1 [TableroId], [RegistroInvitadoId] FROM [Invitados] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000313,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000314", "SELECT TOP 1 [TableroId], [ParticipanteTableroId] FROM [Participantes] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000315", "SELECT TOP 1 [TableroId], [EtiquetaId] FROM [TablerosEtiquetas] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000316", "SELECT TOP 1 [TableroId], [TareaId], [ActividadId] FROM [Actividades] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000317", "SELECT TOP 1 [TableroId], [TareaId], [ComentarioId] FROM [TareasComentarios] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000317,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000318", "SELECT TOP 1 [TableroId], [ListaId] FROM [Listas] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000318,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000319", "SELECT [TableroId] FROM [Tableros] ORDER BY [TableroId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000319,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000320", "SELECT [UsuarioId] AS PropietarioId FROM [Usuarios] WHERE [UsuarioId] = @PropietarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000320,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
