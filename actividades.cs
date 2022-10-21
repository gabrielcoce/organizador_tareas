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
   public class actividades : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A12TareaId = (short)(NumberUtil.Val( GetPar( "TareaId"), "."));
            AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A9TableroId, A12TareaId) ;
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
            Form.Meta.addItem("description", "Actividades", 0) ;
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

      public actividades( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public actividades( IGxContext context )
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
         chkActividadEstado = new GXCheckbox();
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
         A33ActividadEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A33ActividadEstado));
         AssignAttri("", false, "A33ActividadEstado", A33ActividadEstado);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Actividades", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Actividades.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Actividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Actividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Actividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Actividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0090.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TABLEROID"+"'), id:'"+"TABLEROID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TAREAID"+"'), id:'"+"TAREAID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"ACTIVIDADID"+"'), id:'"+"ACTIVIDADID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Actividades.htm");
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
         GxWebStd.gx_label_element( context, edtTableroId_Internalname, "Tablero Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTableroId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")), StringUtil.LTrim( ((edtTableroId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9") : context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTableroId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTableroId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Actividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTareaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTareaId_Internalname, "Tarea Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTareaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")), StringUtil.LTrim( ((edtTareaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9") : context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTareaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTareaId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Actividades.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_12_Internalname, sImgUrl, imgprompt_9_12_Link, "", "", context.GetTheme( ), imgprompt_9_12_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Actividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtActividadId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtActividadId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActividadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30ActividadId), 4, 0, ",", "")), StringUtil.LTrim( ((edtActividadId_Enabled!=0) ? context.localUtil.Format( (decimal)(A30ActividadId), "ZZZ9") : context.localUtil.Format( (decimal)(A30ActividadId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActividadId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActividadId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Actividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtActividadNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtActividadNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActividadNombre_Internalname, StringUtil.RTrim( A31ActividadNombre), StringUtil.RTrim( context.localUtil.Format( A31ActividadNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActividadNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActividadNombre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Actividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtActividadAvance_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtActividadAvance_Internalname, "Avance", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActividadAvance_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A32ActividadAvance), 3, 0, ",", "")), StringUtil.LTrim( ((edtActividadAvance_Enabled!=0) ? context.localUtil.Format( (decimal)(A32ActividadAvance), "ZZ9") : context.localUtil.Format( (decimal)(A32ActividadAvance), "ZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActividadAvance_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActividadAvance_Enabled, 0, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Actividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkActividadEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkActividadEstado_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkActividadEstado_Internalname, StringUtil.BoolToStr( A33ActividadEstado), "", "Estado", 1, chkActividadEstado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtActividadPaso_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtActividadPaso_Internalname, "Paso", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActividadPaso_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A49ActividadPaso), 4, 0, ",", "")), StringUtil.LTrim( ((edtActividadPaso_Enabled!=0) ? context.localUtil.Format( (decimal)(A49ActividadPaso), "ZZZ9") : context.localUtil.Format( (decimal)(A49ActividadPaso), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActividadPaso_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActividadPaso_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Actividades.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Actividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Actividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Actividades.htm");
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
            Z12TareaId = (short)(context.localUtil.CToN( cgiGet( "Z12TareaId"), ",", "."));
            Z30ActividadId = (short)(context.localUtil.CToN( cgiGet( "Z30ActividadId"), ",", "."));
            Z31ActividadNombre = cgiGet( "Z31ActividadNombre");
            Z32ActividadAvance = (short)(context.localUtil.CToN( cgiGet( "Z32ActividadAvance"), ",", "."));
            Z33ActividadEstado = StringUtil.StrToBool( cgiGet( "Z33ActividadEstado"));
            Z49ActividadPaso = (short)(context.localUtil.CToN( cgiGet( "Z49ActividadPaso"), ",", "."));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtTareaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTareaId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TAREAID");
               AnyError = 1;
               GX_FocusControl = edtTareaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A12TareaId = 0;
               AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
            }
            else
            {
               A12TareaId = (short)(context.localUtil.CToN( cgiGet( edtTareaId_Internalname), ",", "."));
               AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtActividadId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtActividadId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTIVIDADID");
               AnyError = 1;
               GX_FocusControl = edtActividadId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A30ActividadId = 0;
               AssignAttri("", false, "A30ActividadId", StringUtil.LTrimStr( (decimal)(A30ActividadId), 4, 0));
            }
            else
            {
               A30ActividadId = (short)(context.localUtil.CToN( cgiGet( edtActividadId_Internalname), ",", "."));
               AssignAttri("", false, "A30ActividadId", StringUtil.LTrimStr( (decimal)(A30ActividadId), 4, 0));
            }
            A31ActividadNombre = cgiGet( edtActividadNombre_Internalname);
            AssignAttri("", false, "A31ActividadNombre", A31ActividadNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtActividadAvance_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtActividadAvance_Internalname), ",", ".") > Convert.ToDecimal( 999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTIVIDADAVANCE");
               AnyError = 1;
               GX_FocusControl = edtActividadAvance_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A32ActividadAvance = 0;
               AssignAttri("", false, "A32ActividadAvance", StringUtil.LTrimStr( (decimal)(A32ActividadAvance), 3, 0));
            }
            else
            {
               A32ActividadAvance = (short)(context.localUtil.CToN( cgiGet( edtActividadAvance_Internalname), ",", "."));
               AssignAttri("", false, "A32ActividadAvance", StringUtil.LTrimStr( (decimal)(A32ActividadAvance), 3, 0));
            }
            A33ActividadEstado = StringUtil.StrToBool( cgiGet( chkActividadEstado_Internalname));
            AssignAttri("", false, "A33ActividadEstado", A33ActividadEstado);
            if ( ( ( context.localUtil.CToN( cgiGet( edtActividadPaso_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtActividadPaso_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTIVIDADPASO");
               AnyError = 1;
               GX_FocusControl = edtActividadPaso_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A49ActividadPaso = 0;
               AssignAttri("", false, "A49ActividadPaso", StringUtil.LTrimStr( (decimal)(A49ActividadPaso), 4, 0));
            }
            else
            {
               A49ActividadPaso = (short)(context.localUtil.CToN( cgiGet( edtActividadPaso_Internalname), ",", "."));
               AssignAttri("", false, "A49ActividadPaso", StringUtil.LTrimStr( (decimal)(A49ActividadPaso), 4, 0));
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
               A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               A12TareaId = (short)(NumberUtil.Val( GetPar( "TareaId"), "."));
               AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
               A30ActividadId = (short)(NumberUtil.Val( GetPar( "ActividadId"), "."));
               AssignAttri("", false, "A30ActividadId", StringUtil.LTrimStr( (decimal)(A30ActividadId), 4, 0));
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
               InitAll099( ) ;
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
         DisableAttributes099( ) ;
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

      protected void ResetCaption090( )
      {
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z31ActividadNombre = T00093_A31ActividadNombre[0];
               Z32ActividadAvance = T00093_A32ActividadAvance[0];
               Z33ActividadEstado = T00093_A33ActividadEstado[0];
               Z49ActividadPaso = T00093_A49ActividadPaso[0];
            }
            else
            {
               Z31ActividadNombre = A31ActividadNombre;
               Z32ActividadAvance = A32ActividadAvance;
               Z33ActividadEstado = A33ActividadEstado;
               Z49ActividadPaso = A49ActividadPaso;
            }
         }
         if ( GX_JID == -1 )
         {
            Z30ActividadId = A30ActividadId;
            Z31ActividadNombre = A31ActividadNombre;
            Z32ActividadAvance = A32ActividadAvance;
            Z33ActividadEstado = A33ActividadEstado;
            Z49ActividadPaso = A49ActividadPaso;
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_9_12_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TABLEROID"+"'), id:'"+"TABLEROID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TAREAID"+"'), id:'"+"TAREAID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load099( )
      {
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {A9TableroId, A12TareaId, A30ActividadId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
            A31ActividadNombre = T00095_A31ActividadNombre[0];
            AssignAttri("", false, "A31ActividadNombre", A31ActividadNombre);
            A32ActividadAvance = T00095_A32ActividadAvance[0];
            AssignAttri("", false, "A32ActividadAvance", StringUtil.LTrimStr( (decimal)(A32ActividadAvance), 3, 0));
            A33ActividadEstado = T00095_A33ActividadEstado[0];
            AssignAttri("", false, "A33ActividadEstado", A33ActividadEstado);
            A49ActividadPaso = T00095_A49ActividadPaso[0];
            AssignAttri("", false, "A49ActividadPaso", StringUtil.LTrimStr( (decimal)(A49ActividadPaso), 4, 0));
            ZM099( -1) ;
         }
         pr_default.close(3);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
      }

      protected void CheckExtendedTable099( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tareas'.", "ForeignKeyNotFound", 1, "TAREAID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors099( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( short A9TableroId ,
                               short A12TareaId )
      {
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Tareas'.", "ForeignKeyNotFound", 1, "TAREAID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
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

      protected void GetKey099( )
      {
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A9TableroId, A12TareaId, A30ActividadId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A9TableroId, A12TareaId, A30ActividadId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM099( 1) ;
            RcdFound9 = 1;
            A30ActividadId = T00093_A30ActividadId[0];
            AssignAttri("", false, "A30ActividadId", StringUtil.LTrimStr( (decimal)(A30ActividadId), 4, 0));
            A31ActividadNombre = T00093_A31ActividadNombre[0];
            AssignAttri("", false, "A31ActividadNombre", A31ActividadNombre);
            A32ActividadAvance = T00093_A32ActividadAvance[0];
            AssignAttri("", false, "A32ActividadAvance", StringUtil.LTrimStr( (decimal)(A32ActividadAvance), 3, 0));
            A33ActividadEstado = T00093_A33ActividadEstado[0];
            AssignAttri("", false, "A33ActividadEstado", A33ActividadEstado);
            A49ActividadPaso = T00093_A49ActividadPaso[0];
            AssignAttri("", false, "A49ActividadPaso", StringUtil.LTrimStr( (decimal)(A49ActividadPaso), 4, 0));
            A9TableroId = T00093_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A12TareaId = T00093_A12TareaId[0];
            AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
            Z30ActividadId = A30ActividadId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
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
         RcdFound9 = 0;
         /* Using cursor T00098 */
         pr_default.execute(6, new Object[] {A9TableroId, A12TareaId, A30ActividadId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00098_A9TableroId[0] < A9TableroId ) || ( T00098_A9TableroId[0] == A9TableroId ) && ( T00098_A12TareaId[0] < A12TareaId ) || ( T00098_A12TareaId[0] == A12TareaId ) && ( T00098_A9TableroId[0] == A9TableroId ) && ( T00098_A30ActividadId[0] < A30ActividadId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00098_A9TableroId[0] > A9TableroId ) || ( T00098_A9TableroId[0] == A9TableroId ) && ( T00098_A12TareaId[0] > A12TareaId ) || ( T00098_A12TareaId[0] == A12TareaId ) && ( T00098_A9TableroId[0] == A9TableroId ) && ( T00098_A30ActividadId[0] > A30ActividadId ) ) )
            {
               A9TableroId = T00098_A9TableroId[0];
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               A12TareaId = T00098_A12TareaId[0];
               AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
               A30ActividadId = T00098_A30ActividadId[0];
               AssignAttri("", false, "A30ActividadId", StringUtil.LTrimStr( (decimal)(A30ActividadId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {A9TableroId, A12TareaId, A30ActividadId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00099_A9TableroId[0] > A9TableroId ) || ( T00099_A9TableroId[0] == A9TableroId ) && ( T00099_A12TareaId[0] > A12TareaId ) || ( T00099_A12TareaId[0] == A12TareaId ) && ( T00099_A9TableroId[0] == A9TableroId ) && ( T00099_A30ActividadId[0] > A30ActividadId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00099_A9TableroId[0] < A9TableroId ) || ( T00099_A9TableroId[0] == A9TableroId ) && ( T00099_A12TareaId[0] < A12TareaId ) || ( T00099_A12TareaId[0] == A12TareaId ) && ( T00099_A9TableroId[0] == A9TableroId ) && ( T00099_A30ActividadId[0] < A30ActividadId ) ) )
            {
               A9TableroId = T00099_A9TableroId[0];
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               A12TareaId = T00099_A12TareaId[0];
               AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
               A30ActividadId = T00099_A30ActividadId[0];
               AssignAttri("", false, "A30ActividadId", StringUtil.LTrimStr( (decimal)(A30ActividadId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert099( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) || ( A30ActividadId != Z30ActividadId ) )
               {
                  A9TableroId = Z9TableroId;
                  AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
                  A12TareaId = Z12TareaId;
                  AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
                  A30ActividadId = Z30ActividadId;
                  AssignAttri("", false, "A30ActividadId", StringUtil.LTrimStr( (decimal)(A30ActividadId), 4, 0));
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
                  Update099( ) ;
                  GX_FocusControl = edtTableroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) || ( A30ActividadId != Z30ActividadId ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTableroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert099( ) ;
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
                     Insert099( ) ;
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
         if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) || ( A30ActividadId != Z30ActividadId ) )
         {
            A9TableroId = Z9TableroId;
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A12TareaId = Z12TareaId;
            AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
            A30ActividadId = Z30ActividadId;
            AssignAttri("", false, "A30ActividadId", StringUtil.LTrimStr( (decimal)(A30ActividadId), 4, 0));
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtActividadNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtActividadNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd099( ) ;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtActividadNombre_Internalname;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtActividadNombre_Internalname;
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
         ScanStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound9 != 0 )
            {
               ScanNext099( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtActividadNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd099( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A9TableroId, A12TareaId, A30ActividadId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Actividades"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z31ActividadNombre, T00092_A31ActividadNombre[0]) != 0 ) || ( Z32ActividadAvance != T00092_A32ActividadAvance[0] ) || ( Z33ActividadEstado != T00092_A33ActividadEstado[0] ) || ( Z49ActividadPaso != T00092_A49ActividadPaso[0] ) )
            {
               if ( StringUtil.StrCmp(Z31ActividadNombre, T00092_A31ActividadNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("actividades:[seudo value changed for attri]"+"ActividadNombre");
                  GXUtil.WriteLogRaw("Old: ",Z31ActividadNombre);
                  GXUtil.WriteLogRaw("Current: ",T00092_A31ActividadNombre[0]);
               }
               if ( Z32ActividadAvance != T00092_A32ActividadAvance[0] )
               {
                  GXUtil.WriteLog("actividades:[seudo value changed for attri]"+"ActividadAvance");
                  GXUtil.WriteLogRaw("Old: ",Z32ActividadAvance);
                  GXUtil.WriteLogRaw("Current: ",T00092_A32ActividadAvance[0]);
               }
               if ( Z33ActividadEstado != T00092_A33ActividadEstado[0] )
               {
                  GXUtil.WriteLog("actividades:[seudo value changed for attri]"+"ActividadEstado");
                  GXUtil.WriteLogRaw("Old: ",Z33ActividadEstado);
                  GXUtil.WriteLogRaw("Current: ",T00092_A33ActividadEstado[0]);
               }
               if ( Z49ActividadPaso != T00092_A49ActividadPaso[0] )
               {
                  GXUtil.WriteLog("actividades:[seudo value changed for attri]"+"ActividadPaso");
                  GXUtil.WriteLogRaw("Old: ",Z49ActividadPaso);
                  GXUtil.WriteLogRaw("Current: ",T00092_A49ActividadPaso[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Actividades"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000910 */
                     pr_default.execute(8, new Object[] {A30ActividadId, A31ActividadNombre, A32ActividadAvance, A33ActividadEstado, A49ActividadPaso, A9TableroId, A12TareaId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Actividades");
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
                           ResetCaption090( ) ;
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
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000911 */
                     pr_default.execute(9, new Object[] {A31ActividadNombre, A32ActividadAvance, A33ActividadEstado, A49ActividadPaso, A9TableroId, A12TareaId, A30ActividadId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Actividades");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Actividades"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption090( ) ;
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
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000912 */
                  pr_default.execute(10, new Object[] {A9TableroId, A12TareaId, A30ActividadId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("Actividades");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound9 == 0 )
                        {
                           InitAll099( ) ;
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
                        ResetCaption090( ) ;
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel099( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("actividades",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("actividades",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart099( )
      {
         /* Using cursor T000913 */
         pr_default.execute(11);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound9 = 1;
            A9TableroId = T000913_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A12TareaId = T000913_A12TareaId[0];
            AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
            A30ActividadId = T000913_A30ActividadId[0];
            AssignAttri("", false, "A30ActividadId", StringUtil.LTrimStr( (decimal)(A30ActividadId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound9 = 1;
            A9TableroId = T000913_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A12TareaId = T000913_A12TareaId[0];
            AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
            A30ActividadId = T000913_A30ActividadId[0];
            AssignAttri("", false, "A30ActividadId", StringUtil.LTrimStr( (decimal)(A30ActividadId), 4, 0));
         }
      }

      protected void ScanEnd099( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
         edtTableroId_Enabled = 0;
         AssignProp("", false, edtTableroId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTableroId_Enabled), 5, 0), true);
         edtTareaId_Enabled = 0;
         AssignProp("", false, edtTareaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTareaId_Enabled), 5, 0), true);
         edtActividadId_Enabled = 0;
         AssignProp("", false, edtActividadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActividadId_Enabled), 5, 0), true);
         edtActividadNombre_Enabled = 0;
         AssignProp("", false, edtActividadNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActividadNombre_Enabled), 5, 0), true);
         edtActividadAvance_Enabled = 0;
         AssignProp("", false, edtActividadAvance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActividadAvance_Enabled), 5, 0), true);
         chkActividadEstado.Enabled = 0;
         AssignProp("", false, chkActividadEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkActividadEstado.Enabled), 5, 0), true);
         edtActividadPaso_Enabled = 0;
         AssignProp("", false, edtActividadPaso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActividadPaso_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("actividades.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z9TableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z12TareaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12TareaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z30ActividadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30ActividadId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z31ActividadNombre", StringUtil.RTrim( Z31ActividadNombre));
         GxWebStd.gx_hidden_field( context, "Z32ActividadAvance", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32ActividadAvance), 3, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z33ActividadEstado", Z33ActividadEstado);
         GxWebStd.gx_hidden_field( context, "Z49ActividadPaso", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z49ActividadPaso), 4, 0, ",", "")));
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
         return formatLink("actividades.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Actividades" ;
      }

      public override string GetPgmdesc( )
      {
         return "Actividades" ;
      }

      protected void InitializeNonKey099( )
      {
         A31ActividadNombre = "";
         AssignAttri("", false, "A31ActividadNombre", A31ActividadNombre);
         A32ActividadAvance = 0;
         AssignAttri("", false, "A32ActividadAvance", StringUtil.LTrimStr( (decimal)(A32ActividadAvance), 3, 0));
         A33ActividadEstado = false;
         AssignAttri("", false, "A33ActividadEstado", A33ActividadEstado);
         A49ActividadPaso = 0;
         AssignAttri("", false, "A49ActividadPaso", StringUtil.LTrimStr( (decimal)(A49ActividadPaso), 4, 0));
         Z31ActividadNombre = "";
         Z32ActividadAvance = 0;
         Z33ActividadEstado = false;
         Z49ActividadPaso = 0;
      }

      protected void InitAll099( )
      {
         A9TableroId = 0;
         AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
         A12TareaId = 0;
         AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
         A30ActividadId = 0;
         AssignAttri("", false, "A30ActividadId", StringUtil.LTrimStr( (decimal)(A30ActividadId), 4, 0));
         InitializeNonKey099( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022101613111291", true, true);
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
         context.AddJavascriptSource("actividades.js", "?2022101613111291", false, true);
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
         edtTareaId_Internalname = "TAREAID";
         edtActividadId_Internalname = "ACTIVIDADID";
         edtActividadNombre_Internalname = "ACTIVIDADNOMBRE";
         edtActividadAvance_Internalname = "ACTIVIDADAVANCE";
         chkActividadEstado_Internalname = "ACTIVIDADESTADO";
         edtActividadPaso_Internalname = "ACTIVIDADPASO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_9_12_Internalname = "PROMPT_9_12";
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
         Form.Caption = "Actividades";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtActividadPaso_Jsonclick = "";
         edtActividadPaso_Enabled = 1;
         chkActividadEstado.Enabled = 1;
         edtActividadAvance_Jsonclick = "";
         edtActividadAvance_Enabled = 1;
         edtActividadNombre_Jsonclick = "";
         edtActividadNombre_Enabled = 1;
         edtActividadId_Jsonclick = "";
         edtActividadId_Enabled = 1;
         imgprompt_9_12_Visible = 1;
         imgprompt_9_12_Link = "";
         edtTareaId_Jsonclick = "";
         edtTareaId_Enabled = 1;
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
         chkActividadEstado.Name = "ACTIVIDADESTADO";
         chkActividadEstado.WebTags = "";
         chkActividadEstado.Caption = "";
         AssignProp("", false, chkActividadEstado_Internalname, "TitleCaption", chkActividadEstado.Caption, true);
         chkActividadEstado.CheckedValue = "false";
         A33ActividadEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A33ActividadEstado));
         AssignAttri("", false, "A33ActividadEstado", A33ActividadEstado);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T000914 */
         pr_default.execute(12, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Tareas'.", "ForeignKeyNotFound", 1, "TAREAID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtActividadNombre_Internalname;
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

      public void Valid_Tareaid( )
      {
         /* Using cursor T000914 */
         pr_default.execute(12, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Tareas'.", "ForeignKeyNotFound", 1, "TAREAID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Actividadid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A33ActividadEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A33ActividadEstado));
         /*  Sending validation outputs */
         AssignAttri("", false, "A31ActividadNombre", StringUtil.RTrim( A31ActividadNombre));
         AssignAttri("", false, "A32ActividadAvance", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32ActividadAvance), 3, 0, ".", "")));
         AssignAttri("", false, "A33ActividadEstado", A33ActividadEstado);
         AssignAttri("", false, "A49ActividadPaso", StringUtil.LTrim( StringUtil.NToC( (decimal)(A49ActividadPaso), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z9TableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9TableroId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z12TareaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12TareaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z30ActividadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30ActividadId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z31ActividadNombre", StringUtil.RTrim( Z31ActividadNombre));
         GxWebStd.gx_hidden_field( context, "Z32ActividadAvance", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32ActividadAvance), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z33ActividadEstado", StringUtil.BoolToStr( Z33ActividadEstado));
         GxWebStd.gx_hidden_field( context, "Z49ActividadPaso", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z49ActividadPaso), 4, 0, ".", "")));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''}]}");
         setEventMetadata("VALID_TABLEROID","{handler:'Valid_Tableroid',iparms:[{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''}]");
         setEventMetadata("VALID_TABLEROID",",oparms:[{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''}]}");
         setEventMetadata("VALID_TAREAID","{handler:'Valid_Tareaid',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9'},{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''}]");
         setEventMetadata("VALID_TAREAID",",oparms:[{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''}]}");
         setEventMetadata("VALID_ACTIVIDADID","{handler:'Valid_Actividadid',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9'},{av:'A30ActividadId',fld:'ACTIVIDADID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''}]");
         setEventMetadata("VALID_ACTIVIDADID",",oparms:[{av:'A31ActividadNombre',fld:'ACTIVIDADNOMBRE',pic:''},{av:'A32ActividadAvance',fld:'ACTIVIDADAVANCE',pic:'ZZ9'},{av:'A49ActividadPaso',fld:'ACTIVIDADPASO',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z9TableroId'},{av:'Z12TareaId'},{av:'Z30ActividadId'},{av:'Z31ActividadNombre'},{av:'Z32ActividadAvance'},{av:'Z33ActividadEstado'},{av:'Z49ActividadPaso'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A33ActividadEstado',fld:'ACTIVIDADESTADO',pic:''}]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z31ActividadNombre = "";
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
         sImgUrl = "";
         A31ActividadNombre = "";
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
         T00095_A30ActividadId = new short[1] ;
         T00095_A31ActividadNombre = new string[] {""} ;
         T00095_A32ActividadAvance = new short[1] ;
         T00095_A33ActividadEstado = new bool[] {false} ;
         T00095_A49ActividadPaso = new short[1] ;
         T00095_A9TableroId = new short[1] ;
         T00095_A12TareaId = new short[1] ;
         T00094_A9TableroId = new short[1] ;
         T00096_A9TableroId = new short[1] ;
         T00097_A9TableroId = new short[1] ;
         T00097_A12TareaId = new short[1] ;
         T00097_A30ActividadId = new short[1] ;
         T00093_A30ActividadId = new short[1] ;
         T00093_A31ActividadNombre = new string[] {""} ;
         T00093_A32ActividadAvance = new short[1] ;
         T00093_A33ActividadEstado = new bool[] {false} ;
         T00093_A49ActividadPaso = new short[1] ;
         T00093_A9TableroId = new short[1] ;
         T00093_A12TareaId = new short[1] ;
         sMode9 = "";
         T00098_A9TableroId = new short[1] ;
         T00098_A12TareaId = new short[1] ;
         T00098_A30ActividadId = new short[1] ;
         T00099_A9TableroId = new short[1] ;
         T00099_A12TareaId = new short[1] ;
         T00099_A30ActividadId = new short[1] ;
         T00092_A30ActividadId = new short[1] ;
         T00092_A31ActividadNombre = new string[] {""} ;
         T00092_A32ActividadAvance = new short[1] ;
         T00092_A33ActividadEstado = new bool[] {false} ;
         T00092_A49ActividadPaso = new short[1] ;
         T00092_A9TableroId = new short[1] ;
         T00092_A12TareaId = new short[1] ;
         T000913_A9TableroId = new short[1] ;
         T000913_A12TareaId = new short[1] ;
         T000913_A30ActividadId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000914_A9TableroId = new short[1] ;
         ZZ31ActividadNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actividades__default(),
            new Object[][] {
                new Object[] {
               T00092_A30ActividadId, T00092_A31ActividadNombre, T00092_A32ActividadAvance, T00092_A33ActividadEstado, T00092_A49ActividadPaso, T00092_A9TableroId, T00092_A12TareaId
               }
               , new Object[] {
               T00093_A30ActividadId, T00093_A31ActividadNombre, T00093_A32ActividadAvance, T00093_A33ActividadEstado, T00093_A49ActividadPaso, T00093_A9TableroId, T00093_A12TareaId
               }
               , new Object[] {
               T00094_A9TableroId
               }
               , new Object[] {
               T00095_A30ActividadId, T00095_A31ActividadNombre, T00095_A32ActividadAvance, T00095_A33ActividadEstado, T00095_A49ActividadPaso, T00095_A9TableroId, T00095_A12TareaId
               }
               , new Object[] {
               T00096_A9TableroId
               }
               , new Object[] {
               T00097_A9TableroId, T00097_A12TareaId, T00097_A30ActividadId
               }
               , new Object[] {
               T00098_A9TableroId, T00098_A12TareaId, T00098_A30ActividadId
               }
               , new Object[] {
               T00099_A9TableroId, T00099_A12TareaId, T00099_A30ActividadId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000913_A9TableroId, T000913_A12TareaId, T000913_A30ActividadId
               }
               , new Object[] {
               T000914_A9TableroId
               }
            }
         );
      }

      private short Z9TableroId ;
      private short Z12TareaId ;
      private short Z30ActividadId ;
      private short Z32ActividadAvance ;
      private short Z49ActividadPaso ;
      private short GxWebError ;
      private short A9TableroId ;
      private short A12TareaId ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A30ActividadId ;
      private short A32ActividadAvance ;
      private short A49ActividadPaso ;
      private short GX_JID ;
      private short RcdFound9 ;
      private short nIsDirty_9 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ9TableroId ;
      private short ZZ12TareaId ;
      private short ZZ30ActividadId ;
      private short ZZ32ActividadAvance ;
      private short ZZ49ActividadPaso ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTableroId_Enabled ;
      private int edtTareaId_Enabled ;
      private int imgprompt_9_12_Visible ;
      private int edtActividadId_Enabled ;
      private int edtActividadNombre_Enabled ;
      private int edtActividadAvance_Enabled ;
      private int edtActividadPaso_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z31ActividadNombre ;
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
      private string edtTareaId_Internalname ;
      private string edtTareaId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_9_12_Internalname ;
      private string imgprompt_9_12_Link ;
      private string edtActividadId_Internalname ;
      private string edtActividadId_Jsonclick ;
      private string edtActividadNombre_Internalname ;
      private string A31ActividadNombre ;
      private string edtActividadNombre_Jsonclick ;
      private string edtActividadAvance_Internalname ;
      private string edtActividadAvance_Jsonclick ;
      private string chkActividadEstado_Internalname ;
      private string edtActividadPaso_Internalname ;
      private string edtActividadPaso_Jsonclick ;
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
      private string sMode9 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ31ActividadNombre ;
      private bool Z33ActividadEstado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A33ActividadEstado ;
      private bool ZZ33ActividadEstado ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkActividadEstado ;
      private IDataStoreProvider pr_default ;
      private short[] T00095_A30ActividadId ;
      private string[] T00095_A31ActividadNombre ;
      private short[] T00095_A32ActividadAvance ;
      private bool[] T00095_A33ActividadEstado ;
      private short[] T00095_A49ActividadPaso ;
      private short[] T00095_A9TableroId ;
      private short[] T00095_A12TareaId ;
      private short[] T00094_A9TableroId ;
      private short[] T00096_A9TableroId ;
      private short[] T00097_A9TableroId ;
      private short[] T00097_A12TareaId ;
      private short[] T00097_A30ActividadId ;
      private short[] T00093_A30ActividadId ;
      private string[] T00093_A31ActividadNombre ;
      private short[] T00093_A32ActividadAvance ;
      private bool[] T00093_A33ActividadEstado ;
      private short[] T00093_A49ActividadPaso ;
      private short[] T00093_A9TableroId ;
      private short[] T00093_A12TareaId ;
      private short[] T00098_A9TableroId ;
      private short[] T00098_A12TareaId ;
      private short[] T00098_A30ActividadId ;
      private short[] T00099_A9TableroId ;
      private short[] T00099_A12TareaId ;
      private short[] T00099_A30ActividadId ;
      private short[] T00092_A30ActividadId ;
      private string[] T00092_A31ActividadNombre ;
      private short[] T00092_A32ActividadAvance ;
      private bool[] T00092_A33ActividadEstado ;
      private short[] T00092_A49ActividadPaso ;
      private short[] T00092_A9TableroId ;
      private short[] T00092_A12TareaId ;
      private short[] T000913_A9TableroId ;
      private short[] T000913_A12TareaId ;
      private short[] T000913_A30ActividadId ;
      private short[] T000914_A9TableroId ;
      private GXWebForm Form ;
   }

   public class actividades__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00095;
          prmT00095 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmT00094;
          prmT00094 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmT00096;
          prmT00096 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmT00097;
          prmT00097 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmT00093;
          prmT00093 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmT00098;
          prmT00098 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmT00099;
          prmT00099 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmT00092;
          prmT00092 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmT000910;
          prmT000910 = new Object[] {
          new ParDef("@ActividadId",GXType.Int16,4,0) ,
          new ParDef("@ActividadNombre",GXType.NChar,20,0) ,
          new ParDef("@ActividadAvance",GXType.Int16,3,0) ,
          new ParDef("@ActividadEstado",GXType.Boolean,1,0) ,
          new ParDef("@ActividadPaso",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmT000911;
          prmT000911 = new Object[] {
          new ParDef("@ActividadNombre",GXType.NChar,20,0) ,
          new ParDef("@ActividadAvance",GXType.Int16,3,0) ,
          new ParDef("@ActividadEstado",GXType.Boolean,1,0) ,
          new ParDef("@ActividadPaso",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmT000912;
          prmT000912 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmT000913;
          prmT000913 = new Object[] {
          };
          Object[] prmT000914;
          prmT000914 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00092", "SELECT [ActividadId], [ActividadNombre], [ActividadAvance], [ActividadEstado], [ActividadPaso], [TableroId], [TareaId] FROM [Actividades] WITH (UPDLOCK) WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ActividadId] = @ActividadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00093", "SELECT [ActividadId], [ActividadNombre], [ActividadAvance], [ActividadEstado], [ActividadPaso], [TableroId], [TareaId] FROM [Actividades] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ActividadId] = @ActividadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00094", "SELECT [TableroId] FROM [Tareas] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00095", "SELECT TM1.[ActividadId], TM1.[ActividadNombre], TM1.[ActividadAvance], TM1.[ActividadEstado], TM1.[ActividadPaso], TM1.[TableroId], TM1.[TareaId] FROM [Actividades] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[TareaId] = @TareaId and TM1.[ActividadId] = @ActividadId ORDER BY TM1.[TableroId], TM1.[TareaId], TM1.[ActividadId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00096", "SELECT [TableroId] FROM [Tareas] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00097", "SELECT [TableroId], [TareaId], [ActividadId] FROM [Actividades] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ActividadId] = @ActividadId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00098", "SELECT TOP 1 [TableroId], [TareaId], [ActividadId] FROM [Actividades] WHERE ( [TableroId] > @TableroId or [TableroId] = @TableroId and [TareaId] > @TareaId or [TareaId] = @TareaId and [TableroId] = @TableroId and [ActividadId] > @ActividadId) ORDER BY [TableroId], [TareaId], [ActividadId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00099", "SELECT TOP 1 [TableroId], [TareaId], [ActividadId] FROM [Actividades] WHERE ( [TableroId] < @TableroId or [TableroId] = @TableroId and [TareaId] < @TareaId or [TareaId] = @TareaId and [TableroId] = @TableroId and [ActividadId] < @ActividadId) ORDER BY [TableroId] DESC, [TareaId] DESC, [ActividadId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000910", "INSERT INTO [Actividades]([ActividadId], [ActividadNombre], [ActividadAvance], [ActividadEstado], [ActividadPaso], [TableroId], [TareaId]) VALUES(@ActividadId, @ActividadNombre, @ActividadAvance, @ActividadEstado, @ActividadPaso, @TableroId, @TareaId)", GxErrorMask.GX_NOMASK,prmT000910)
             ,new CursorDef("T000911", "UPDATE [Actividades] SET [ActividadNombre]=@ActividadNombre, [ActividadAvance]=@ActividadAvance, [ActividadEstado]=@ActividadEstado, [ActividadPaso]=@ActividadPaso  WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ActividadId] = @ActividadId", GxErrorMask.GX_NOMASK,prmT000911)
             ,new CursorDef("T000912", "DELETE FROM [Actividades]  WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ActividadId] = @ActividadId", GxErrorMask.GX_NOMASK,prmT000912)
             ,new CursorDef("T000913", "SELECT [TableroId], [TareaId], [ActividadId] FROM [Actividades] ORDER BY [TableroId], [TareaId], [ActividadId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000913,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000914", "SELECT [TableroId] FROM [Tareas] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000914,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
