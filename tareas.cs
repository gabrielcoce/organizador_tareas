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
   public class tareas : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A9TableroId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A23ResponsableId = (short)(NumberUtil.Val( GetPar( "ResponsableId"), "."));
            n23ResponsableId = false;
            AssignAttri("", false, "A23ResponsableId", StringUtil.LTrimStr( (decimal)(A23ResponsableId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A23ResponsableId) ;
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
            Form.Meta.addItem("description", "Tareas", 0) ;
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

      public tareas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public tareas( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tareas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Tareas.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TABLEROID"+"'), id:'"+"TABLEROID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TAREAID"+"'), id:'"+"TAREAID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Tareas.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTableroId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")), StringUtil.LTrim( ((edtTableroId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9") : context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTableroId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTableroId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Tareas.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Tareas.htm");
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
         GxWebStd.gx_label_element( context, edtTareaId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTareaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")), StringUtil.LTrim( ((edtTareaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9") : context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTareaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTareaId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Tareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTareaNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTareaNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTareaNombre_Internalname, StringUtil.RTrim( A13TareaNombre), StringUtil.RTrim( context.localUtil.Format( A13TareaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTareaNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTareaNombre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Tareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtResponsableId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResponsableId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResponsableId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23ResponsableId), 4, 0, ",", "")), StringUtil.LTrim( ((edtResponsableId_Enabled!=0) ? context.localUtil.Format( (decimal)(A23ResponsableId), "ZZZ9") : context.localUtil.Format( (decimal)(A23ResponsableId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResponsableId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResponsableId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Tareas.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_23_Internalname, sImgUrl, imgprompt_23_Link, "", "", context.GetTheme( ), imgprompt_23_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Tareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTareaFechaInicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTareaFechaInicio_Internalname, "Fecha Inicio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTareaFechaInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTareaFechaInicio_Internalname, context.localUtil.Format(A24TareaFechaInicio, "99/99/99"), context.localUtil.Format( A24TareaFechaInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTareaFechaInicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTareaFechaInicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Tareas.htm");
         GxWebStd.gx_bitmap( context, edtTareaFechaInicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTareaFechaInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Tareas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTareaFechaFin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTareaFechaFin_Internalname, "Fecha Fin", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTareaFechaFin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTareaFechaFin_Internalname, context.localUtil.Format(A25TareaFechaFin, "99/99/99"), context.localUtil.Format( A25TareaFechaFin, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTareaFechaFin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTareaFechaFin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Tareas.htm");
         GxWebStd.gx_bitmap( context, edtTareaFechaFin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTareaFechaFin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Tareas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTareaEtiquetas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTareaEtiquetas_Internalname, "Etiquetas", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTareaEtiquetas_Internalname, A38TareaEtiquetas, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtTareaEtiquetas_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Tareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTareaEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTareaEstado_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTareaEstado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A46TareaEstado), 4, 0, ",", "")), StringUtil.LTrim( ((edtTareaEstado_Enabled!=0) ? context.localUtil.Format( (decimal)(A46TareaEstado), "ZZZ9") : context.localUtil.Format( (decimal)(A46TareaEstado), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTareaEstado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTareaEstado_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Tareas.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tareas.htm");
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
            Z13TareaNombre = cgiGet( "Z13TareaNombre");
            Z24TareaFechaInicio = context.localUtil.CToD( cgiGet( "Z24TareaFechaInicio"), 0);
            Z25TareaFechaFin = context.localUtil.CToD( cgiGet( "Z25TareaFechaFin"), 0);
            Z46TareaEstado = (short)(context.localUtil.CToN( cgiGet( "Z46TareaEstado"), ",", "."));
            Z23ResponsableId = (short)(context.localUtil.CToN( cgiGet( "Z23ResponsableId"), ",", "."));
            n23ResponsableId = ((0==A23ResponsableId) ? true : false);
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
            A13TareaNombre = cgiGet( edtTareaNombre_Internalname);
            AssignAttri("", false, "A13TareaNombre", A13TareaNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtResponsableId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtResponsableId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RESPONSABLEID");
               AnyError = 1;
               GX_FocusControl = edtResponsableId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A23ResponsableId = 0;
               n23ResponsableId = false;
               AssignAttri("", false, "A23ResponsableId", StringUtil.LTrimStr( (decimal)(A23ResponsableId), 4, 0));
            }
            else
            {
               A23ResponsableId = (short)(context.localUtil.CToN( cgiGet( edtResponsableId_Internalname), ",", "."));
               n23ResponsableId = false;
               AssignAttri("", false, "A23ResponsableId", StringUtil.LTrimStr( (decimal)(A23ResponsableId), 4, 0));
            }
            n23ResponsableId = ((0==A23ResponsableId) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTareaFechaInicio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tarea Fecha Inicio"}), 1, "TAREAFECHAINICIO");
               AnyError = 1;
               GX_FocusControl = edtTareaFechaInicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A24TareaFechaInicio = DateTime.MinValue;
               AssignAttri("", false, "A24TareaFechaInicio", context.localUtil.Format(A24TareaFechaInicio, "99/99/99"));
            }
            else
            {
               A24TareaFechaInicio = context.localUtil.CToD( cgiGet( edtTareaFechaInicio_Internalname), 2);
               AssignAttri("", false, "A24TareaFechaInicio", context.localUtil.Format(A24TareaFechaInicio, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtTareaFechaFin_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tarea Fecha Fin"}), 1, "TAREAFECHAFIN");
               AnyError = 1;
               GX_FocusControl = edtTareaFechaFin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A25TareaFechaFin = DateTime.MinValue;
               AssignAttri("", false, "A25TareaFechaFin", context.localUtil.Format(A25TareaFechaFin, "99/99/99"));
            }
            else
            {
               A25TareaFechaFin = context.localUtil.CToD( cgiGet( edtTareaFechaFin_Internalname), 2);
               AssignAttri("", false, "A25TareaFechaFin", context.localUtil.Format(A25TareaFechaFin, "99/99/99"));
            }
            A38TareaEtiquetas = cgiGet( edtTareaEtiquetas_Internalname);
            AssignAttri("", false, "A38TareaEtiquetas", A38TareaEtiquetas);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTareaEstado_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTareaEstado_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TAREAESTADO");
               AnyError = 1;
               GX_FocusControl = edtTareaEstado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A46TareaEstado = 0;
               AssignAttri("", false, "A46TareaEstado", StringUtil.LTrimStr( (decimal)(A46TareaEstado), 4, 0));
            }
            else
            {
               A46TareaEstado = (short)(context.localUtil.CToN( cgiGet( edtTareaEstado_Internalname), ",", "."));
               AssignAttri("", false, "A46TareaEstado", StringUtil.LTrimStr( (decimal)(A46TareaEstado), 4, 0));
            }
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
               A12TareaId = (short)(NumberUtil.Val( GetPar( "TareaId"), "."));
               AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
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
               InitAll044( ) ;
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
         DisableAttributes044( ) ;
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

      protected void ResetCaption040( )
      {
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z13TareaNombre = T00043_A13TareaNombre[0];
               Z24TareaFechaInicio = T00043_A24TareaFechaInicio[0];
               Z25TareaFechaFin = T00043_A25TareaFechaFin[0];
               Z46TareaEstado = T00043_A46TareaEstado[0];
               Z23ResponsableId = T00043_A23ResponsableId[0];
            }
            else
            {
               Z13TareaNombre = A13TareaNombre;
               Z24TareaFechaInicio = A24TareaFechaInicio;
               Z25TareaFechaFin = A25TareaFechaFin;
               Z46TareaEstado = A46TareaEstado;
               Z23ResponsableId = A23ResponsableId;
            }
         }
         if ( GX_JID == -3 )
         {
            Z12TareaId = A12TareaId;
            Z13TareaNombre = A13TareaNombre;
            Z24TareaFechaInicio = A24TareaFechaInicio;
            Z25TareaFechaFin = A25TareaFechaFin;
            Z38TareaEtiquetas = A38TareaEtiquetas;
            Z46TareaEstado = A46TareaEstado;
            Z9TableroId = A9TableroId;
            Z23ResponsableId = A23ResponsableId;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TABLEROID"+"'), id:'"+"TABLEROID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_23_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"RESPONSABLEID"+"'), id:'"+"RESPONSABLEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load044( )
      {
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound4 = 1;
            A13TareaNombre = T00046_A13TareaNombre[0];
            AssignAttri("", false, "A13TareaNombre", A13TareaNombre);
            A24TareaFechaInicio = T00046_A24TareaFechaInicio[0];
            AssignAttri("", false, "A24TareaFechaInicio", context.localUtil.Format(A24TareaFechaInicio, "99/99/99"));
            A25TareaFechaFin = T00046_A25TareaFechaFin[0];
            AssignAttri("", false, "A25TareaFechaFin", context.localUtil.Format(A25TareaFechaFin, "99/99/99"));
            A38TareaEtiquetas = T00046_A38TareaEtiquetas[0];
            AssignAttri("", false, "A38TareaEtiquetas", A38TareaEtiquetas);
            A46TareaEstado = T00046_A46TareaEstado[0];
            AssignAttri("", false, "A46TareaEstado", StringUtil.LTrimStr( (decimal)(A46TareaEstado), 4, 0));
            A23ResponsableId = T00046_A23ResponsableId[0];
            n23ResponsableId = T00046_n23ResponsableId[0];
            AssignAttri("", false, "A23ResponsableId", StringUtil.LTrimStr( (decimal)(A23ResponsableId), 4, 0));
            ZM044( -3) ;
         }
         pr_default.close(4);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         nIsDirty_4 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {n23ResponsableId, A23ResponsableId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A23ResponsableId) ) )
            {
               GX_msglist.addItem("No existe 'Responsable'.", "ForeignKeyNotFound", 1, "RESPONSABLEID");
               AnyError = 1;
               GX_FocusControl = edtResponsableId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A24TareaFechaInicio) || ( DateTimeUtil.ResetTime ( A24TareaFechaInicio ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Tarea Fecha Inicio fuera de rango", "OutOfRange", 1, "TAREAFECHAINICIO");
            AnyError = 1;
            GX_FocusControl = edtTareaFechaInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A25TareaFechaFin) || ( DateTimeUtil.ResetTime ( A25TareaFechaFin ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Tarea Fecha Fin fuera de rango", "OutOfRange", 1, "TAREAFECHAFIN");
            AnyError = 1;
            GX_FocusControl = edtTareaFechaFin_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( short A9TableroId )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_5( short A23ResponsableId )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {n23ResponsableId, A23ResponsableId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A23ResponsableId) ) )
            {
               GX_msglist.addItem("No existe 'Responsable'.", "ForeignKeyNotFound", 1, "RESPONSABLEID");
               AnyError = 1;
               GX_FocusControl = edtResponsableId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey044( )
      {
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 3) ;
            RcdFound4 = 1;
            A12TareaId = T00043_A12TareaId[0];
            AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
            A13TareaNombre = T00043_A13TareaNombre[0];
            AssignAttri("", false, "A13TareaNombre", A13TareaNombre);
            A24TareaFechaInicio = T00043_A24TareaFechaInicio[0];
            AssignAttri("", false, "A24TareaFechaInicio", context.localUtil.Format(A24TareaFechaInicio, "99/99/99"));
            A25TareaFechaFin = T00043_A25TareaFechaFin[0];
            AssignAttri("", false, "A25TareaFechaFin", context.localUtil.Format(A25TareaFechaFin, "99/99/99"));
            A38TareaEtiquetas = T00043_A38TareaEtiquetas[0];
            AssignAttri("", false, "A38TareaEtiquetas", A38TareaEtiquetas);
            A46TareaEstado = T00043_A46TareaEstado[0];
            AssignAttri("", false, "A46TareaEstado", StringUtil.LTrimStr( (decimal)(A46TareaEstado), 4, 0));
            A9TableroId = T00043_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A23ResponsableId = T00043_A23ResponsableId[0];
            n23ResponsableId = T00043_n23ResponsableId[0];
            AssignAttri("", false, "A23ResponsableId", StringUtil.LTrimStr( (decimal)(A23ResponsableId), 4, 0));
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
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
         RcdFound4 = 0;
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000410_A9TableroId[0] < A9TableroId ) || ( T000410_A9TableroId[0] == A9TableroId ) && ( T000410_A12TareaId[0] < A12TareaId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000410_A9TableroId[0] > A9TableroId ) || ( T000410_A9TableroId[0] == A9TableroId ) && ( T000410_A12TareaId[0] > A12TareaId ) ) )
            {
               A9TableroId = T000410_A9TableroId[0];
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               A12TareaId = T000410_A12TareaId[0];
               AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T000411 */
         pr_default.execute(9, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000411_A9TableroId[0] > A9TableroId ) || ( T000411_A9TableroId[0] == A9TableroId ) && ( T000411_A12TareaId[0] > A12TareaId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000411_A9TableroId[0] < A9TableroId ) || ( T000411_A9TableroId[0] == A9TableroId ) && ( T000411_A12TareaId[0] < A12TareaId ) ) )
            {
               A9TableroId = T000411_A9TableroId[0];
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               A12TareaId = T000411_A12TareaId[0];
               AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert044( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) )
               {
                  A9TableroId = Z9TableroId;
                  AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
                  A12TareaId = Z12TareaId;
                  AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
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
                  Update044( ) ;
                  GX_FocusControl = edtTableroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTableroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert044( ) ;
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
                     Insert044( ) ;
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
         if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) )
         {
            A9TableroId = Z9TableroId;
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A12TareaId = Z12TareaId;
            AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTareaNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTareaNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd044( ) ;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTareaNombre_Internalname;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTareaNombre_Internalname;
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
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound4 != 0 )
            {
               ScanNext044( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTareaNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd044( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A9TableroId, A12TareaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tareas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z13TareaNombre, T00042_A13TareaNombre[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z24TareaFechaInicio ) != DateTimeUtil.ResetTime ( T00042_A24TareaFechaInicio[0] ) ) || ( DateTimeUtil.ResetTime ( Z25TareaFechaFin ) != DateTimeUtil.ResetTime ( T00042_A25TareaFechaFin[0] ) ) || ( Z46TareaEstado != T00042_A46TareaEstado[0] ) || ( Z23ResponsableId != T00042_A23ResponsableId[0] ) )
            {
               if ( StringUtil.StrCmp(Z13TareaNombre, T00042_A13TareaNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("tareas:[seudo value changed for attri]"+"TareaNombre");
                  GXUtil.WriteLogRaw("Old: ",Z13TareaNombre);
                  GXUtil.WriteLogRaw("Current: ",T00042_A13TareaNombre[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z24TareaFechaInicio ) != DateTimeUtil.ResetTime ( T00042_A24TareaFechaInicio[0] ) )
               {
                  GXUtil.WriteLog("tareas:[seudo value changed for attri]"+"TareaFechaInicio");
                  GXUtil.WriteLogRaw("Old: ",Z24TareaFechaInicio);
                  GXUtil.WriteLogRaw("Current: ",T00042_A24TareaFechaInicio[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z25TareaFechaFin ) != DateTimeUtil.ResetTime ( T00042_A25TareaFechaFin[0] ) )
               {
                  GXUtil.WriteLog("tareas:[seudo value changed for attri]"+"TareaFechaFin");
                  GXUtil.WriteLogRaw("Old: ",Z25TareaFechaFin);
                  GXUtil.WriteLogRaw("Current: ",T00042_A25TareaFechaFin[0]);
               }
               if ( Z46TareaEstado != T00042_A46TareaEstado[0] )
               {
                  GXUtil.WriteLog("tareas:[seudo value changed for attri]"+"TareaEstado");
                  GXUtil.WriteLogRaw("Old: ",Z46TareaEstado);
                  GXUtil.WriteLogRaw("Current: ",T00042_A46TareaEstado[0]);
               }
               if ( Z23ResponsableId != T00042_A23ResponsableId[0] )
               {
                  GXUtil.WriteLog("tareas:[seudo value changed for attri]"+"ResponsableId");
                  GXUtil.WriteLogRaw("Old: ",Z23ResponsableId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A23ResponsableId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Tareas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000412 */
                     pr_default.execute(10, new Object[] {A12TareaId, A13TareaNombre, A24TareaFechaInicio, A25TareaFechaFin, A38TareaEtiquetas, A46TareaEstado, A9TableroId, n23ResponsableId, A23ResponsableId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Tareas");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption040( ) ;
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000413 */
                     pr_default.execute(11, new Object[] {A13TareaNombre, A24TareaFechaInicio, A25TareaFechaFin, A38TareaEtiquetas, A46TareaEstado, n23ResponsableId, A23ResponsableId, A9TableroId, A12TareaId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Tareas");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tareas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption040( ) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000414 */
                  pr_default.execute(12, new Object[] {A9TableroId, A12TareaId});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("Tareas");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound4 == 0 )
                        {
                           InitAll044( ) ;
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
                        ResetCaption040( ) ;
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel044( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000415 */
            pr_default.execute(13, new Object[] {A9TableroId, A12TareaId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Actividades"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000416 */
            pr_default.execute(14, new Object[] {A9TableroId, A12TareaId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tareas Comentarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tareas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tareas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart044( )
      {
         /* Using cursor T000417 */
         pr_default.execute(15);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound4 = 1;
            A9TableroId = T000417_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A12TareaId = T000417_A12TareaId[0];
            AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound4 = 1;
            A9TableroId = T000417_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A12TareaId = T000417_A12TareaId[0];
            AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
         }
      }

      protected void ScanEnd044( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
         edtTableroId_Enabled = 0;
         AssignProp("", false, edtTableroId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTableroId_Enabled), 5, 0), true);
         edtTareaId_Enabled = 0;
         AssignProp("", false, edtTareaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTareaId_Enabled), 5, 0), true);
         edtTareaNombre_Enabled = 0;
         AssignProp("", false, edtTareaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTareaNombre_Enabled), 5, 0), true);
         edtResponsableId_Enabled = 0;
         AssignProp("", false, edtResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableId_Enabled), 5, 0), true);
         edtTareaFechaInicio_Enabled = 0;
         AssignProp("", false, edtTareaFechaInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTareaFechaInicio_Enabled), 5, 0), true);
         edtTareaFechaFin_Enabled = 0;
         AssignProp("", false, edtTareaFechaFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTareaFechaFin_Enabled), 5, 0), true);
         edtTareaEtiquetas_Enabled = 0;
         AssignProp("", false, edtTareaEtiquetas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTareaEtiquetas_Enabled), 5, 0), true);
         edtTareaEstado_Enabled = 0;
         AssignProp("", false, edtTareaEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTareaEstado_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
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
         context.AddJavascriptSource("gxcfg.js", "?202291618443891", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tareas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z12TareaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12TareaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z13TareaNombre", StringUtil.RTrim( Z13TareaNombre));
         GxWebStd.gx_hidden_field( context, "Z24TareaFechaInicio", context.localUtil.DToC( Z24TareaFechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z25TareaFechaFin", context.localUtil.DToC( Z25TareaFechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z46TareaEstado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z46TareaEstado), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z23ResponsableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23ResponsableId), 4, 0, ",", "")));
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
         return formatLink("tareas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Tareas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tareas" ;
      }

      protected void InitializeNonKey044( )
      {
         A13TareaNombre = "";
         AssignAttri("", false, "A13TareaNombre", A13TareaNombre);
         A23ResponsableId = 0;
         n23ResponsableId = false;
         AssignAttri("", false, "A23ResponsableId", StringUtil.LTrimStr( (decimal)(A23ResponsableId), 4, 0));
         n23ResponsableId = ((0==A23ResponsableId) ? true : false);
         A24TareaFechaInicio = DateTime.MinValue;
         AssignAttri("", false, "A24TareaFechaInicio", context.localUtil.Format(A24TareaFechaInicio, "99/99/99"));
         A25TareaFechaFin = DateTime.MinValue;
         AssignAttri("", false, "A25TareaFechaFin", context.localUtil.Format(A25TareaFechaFin, "99/99/99"));
         A38TareaEtiquetas = "";
         AssignAttri("", false, "A38TareaEtiquetas", A38TareaEtiquetas);
         A46TareaEstado = 0;
         AssignAttri("", false, "A46TareaEstado", StringUtil.LTrimStr( (decimal)(A46TareaEstado), 4, 0));
         Z13TareaNombre = "";
         Z24TareaFechaInicio = DateTime.MinValue;
         Z25TareaFechaFin = DateTime.MinValue;
         Z46TareaEstado = 0;
         Z23ResponsableId = 0;
      }

      protected void InitAll044( )
      {
         A9TableroId = 0;
         AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
         A12TareaId = 0;
         AssignAttri("", false, "A12TareaId", StringUtil.LTrimStr( (decimal)(A12TareaId), 4, 0));
         InitializeNonKey044( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202291618443893", true, true);
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
         context.AddJavascriptSource("tareas.js", "?202291618443893", false, true);
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
         edtTareaNombre_Internalname = "TAREANOMBRE";
         edtResponsableId_Internalname = "RESPONSABLEID";
         edtTareaFechaInicio_Internalname = "TAREAFECHAINICIO";
         edtTareaFechaFin_Internalname = "TAREAFECHAFIN";
         edtTareaEtiquetas_Internalname = "TAREAETIQUETAS";
         edtTareaEstado_Internalname = "TAREAESTADO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_9_Internalname = "PROMPT_9";
         imgprompt_23_Internalname = "PROMPT_23";
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
         Form.Caption = "Tareas";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTareaEstado_Jsonclick = "";
         edtTareaEstado_Enabled = 1;
         edtTareaEtiquetas_Enabled = 1;
         edtTareaFechaFin_Jsonclick = "";
         edtTareaFechaFin_Enabled = 1;
         edtTareaFechaInicio_Jsonclick = "";
         edtTareaFechaInicio_Enabled = 1;
         imgprompt_23_Visible = 1;
         imgprompt_23_Link = "";
         edtResponsableId_Jsonclick = "";
         edtResponsableId_Enabled = 1;
         edtTareaNombre_Jsonclick = "";
         edtTareaNombre_Enabled = 1;
         edtTareaId_Jsonclick = "";
         edtTareaId_Enabled = 1;
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T000418 */
         pr_default.execute(16, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         GX_FocusControl = edtTareaNombre_Internalname;
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
         /* Using cursor T000418 */
         pr_default.execute(16, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tareaid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A13TareaNombre", StringUtil.RTrim( A13TareaNombre));
         AssignAttri("", false, "A23ResponsableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23ResponsableId), 4, 0, ".", "")));
         AssignAttri("", false, "A24TareaFechaInicio", context.localUtil.Format(A24TareaFechaInicio, "99/99/99"));
         AssignAttri("", false, "A25TareaFechaFin", context.localUtil.Format(A25TareaFechaFin, "99/99/99"));
         AssignAttri("", false, "A38TareaEtiquetas", A38TareaEtiquetas);
         AssignAttri("", false, "A46TareaEstado", StringUtil.LTrim( StringUtil.NToC( (decimal)(A46TareaEstado), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z9TableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9TableroId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z12TareaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12TareaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z13TareaNombre", StringUtil.RTrim( Z13TareaNombre));
         GxWebStd.gx_hidden_field( context, "Z23ResponsableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23ResponsableId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24TareaFechaInicio", context.localUtil.Format(Z24TareaFechaInicio, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z25TareaFechaFin", context.localUtil.Format(Z25TareaFechaFin, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z38TareaEtiquetas", Z38TareaEtiquetas);
         GxWebStd.gx_hidden_field( context, "Z46TareaEstado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z46TareaEstado), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Responsableid( )
      {
         n23ResponsableId = false;
         /* Using cursor T000419 */
         pr_default.execute(17, new Object[] {n23ResponsableId, A23ResponsableId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A23ResponsableId) ) )
            {
               GX_msglist.addItem("No existe 'Responsable'.", "ForeignKeyNotFound", 1, "RESPONSABLEID");
               AnyError = 1;
               GX_FocusControl = edtResponsableId_Internalname;
            }
         }
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
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
         setEventMetadata("VALID_TABLEROID","{handler:'Valid_Tableroid',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_TABLEROID",",oparms:[]}");
         setEventMetadata("VALID_TAREAID","{handler:'Valid_Tareaid',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TAREAID",",oparms:[{av:'A13TareaNombre',fld:'TAREANOMBRE',pic:''},{av:'A23ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9'},{av:'A24TareaFechaInicio',fld:'TAREAFECHAINICIO',pic:''},{av:'A25TareaFechaFin',fld:'TAREAFECHAFIN',pic:''},{av:'A38TareaEtiquetas',fld:'TAREAETIQUETAS',pic:''},{av:'A46TareaEstado',fld:'TAREAESTADO',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z9TableroId'},{av:'Z12TareaId'},{av:'Z13TareaNombre'},{av:'Z23ResponsableId'},{av:'Z24TareaFechaInicio'},{av:'Z25TareaFechaFin'},{av:'Z38TareaEtiquetas'},{av:'Z46TareaEstado'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_RESPONSABLEID","{handler:'Valid_Responsableid',iparms:[{av:'A23ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_RESPONSABLEID",",oparms:[]}");
         setEventMetadata("VALID_TAREAFECHAINICIO","{handler:'Valid_Tareafechainicio',iparms:[]");
         setEventMetadata("VALID_TAREAFECHAINICIO",",oparms:[]}");
         setEventMetadata("VALID_TAREAFECHAFIN","{handler:'Valid_Tareafechafin',iparms:[]");
         setEventMetadata("VALID_TAREAFECHAFIN",",oparms:[]}");
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
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z13TareaNombre = "";
         Z24TareaFechaInicio = DateTime.MinValue;
         Z25TareaFechaFin = DateTime.MinValue;
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
         A13TareaNombre = "";
         A24TareaFechaInicio = DateTime.MinValue;
         A25TareaFechaFin = DateTime.MinValue;
         A38TareaEtiquetas = "";
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
         Z38TareaEtiquetas = "";
         T00046_A12TareaId = new short[1] ;
         T00046_A13TareaNombre = new string[] {""} ;
         T00046_A24TareaFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00046_A25TareaFechaFin = new DateTime[] {DateTime.MinValue} ;
         T00046_A38TareaEtiquetas = new string[] {""} ;
         T00046_A46TareaEstado = new short[1] ;
         T00046_A9TableroId = new short[1] ;
         T00046_A23ResponsableId = new short[1] ;
         T00046_n23ResponsableId = new bool[] {false} ;
         T00044_A9TableroId = new short[1] ;
         T00045_A23ResponsableId = new short[1] ;
         T00045_n23ResponsableId = new bool[] {false} ;
         T00047_A9TableroId = new short[1] ;
         T00048_A23ResponsableId = new short[1] ;
         T00048_n23ResponsableId = new bool[] {false} ;
         T00049_A9TableroId = new short[1] ;
         T00049_A12TareaId = new short[1] ;
         T00043_A12TareaId = new short[1] ;
         T00043_A13TareaNombre = new string[] {""} ;
         T00043_A24TareaFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00043_A25TareaFechaFin = new DateTime[] {DateTime.MinValue} ;
         T00043_A38TareaEtiquetas = new string[] {""} ;
         T00043_A46TareaEstado = new short[1] ;
         T00043_A9TableroId = new short[1] ;
         T00043_A23ResponsableId = new short[1] ;
         T00043_n23ResponsableId = new bool[] {false} ;
         sMode4 = "";
         T000410_A9TableroId = new short[1] ;
         T000410_A12TareaId = new short[1] ;
         T000411_A9TableroId = new short[1] ;
         T000411_A12TareaId = new short[1] ;
         T00042_A12TareaId = new short[1] ;
         T00042_A13TareaNombre = new string[] {""} ;
         T00042_A24TareaFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00042_A25TareaFechaFin = new DateTime[] {DateTime.MinValue} ;
         T00042_A38TareaEtiquetas = new string[] {""} ;
         T00042_A46TareaEstado = new short[1] ;
         T00042_A9TableroId = new short[1] ;
         T00042_A23ResponsableId = new short[1] ;
         T00042_n23ResponsableId = new bool[] {false} ;
         T000415_A9TableroId = new short[1] ;
         T000415_A12TareaId = new short[1] ;
         T000415_A30ActividadId = new short[1] ;
         T000416_A9TableroId = new short[1] ;
         T000416_A12TareaId = new short[1] ;
         T000416_A27ComentarioId = new short[1] ;
         T000417_A9TableroId = new short[1] ;
         T000417_A12TareaId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000418_A9TableroId = new short[1] ;
         ZZ13TareaNombre = "";
         ZZ24TareaFechaInicio = DateTime.MinValue;
         ZZ25TareaFechaFin = DateTime.MinValue;
         ZZ38TareaEtiquetas = "";
         T000419_A23ResponsableId = new short[1] ;
         T000419_n23ResponsableId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tareas__default(),
            new Object[][] {
                new Object[] {
               T00042_A12TareaId, T00042_A13TareaNombre, T00042_A24TareaFechaInicio, T00042_A25TareaFechaFin, T00042_A38TareaEtiquetas, T00042_A46TareaEstado, T00042_A9TableroId, T00042_A23ResponsableId, T00042_n23ResponsableId
               }
               , new Object[] {
               T00043_A12TareaId, T00043_A13TareaNombre, T00043_A24TareaFechaInicio, T00043_A25TareaFechaFin, T00043_A38TareaEtiquetas, T00043_A46TareaEstado, T00043_A9TableroId, T00043_A23ResponsableId, T00043_n23ResponsableId
               }
               , new Object[] {
               T00044_A9TableroId
               }
               , new Object[] {
               T00045_A23ResponsableId
               }
               , new Object[] {
               T00046_A12TareaId, T00046_A13TareaNombre, T00046_A24TareaFechaInicio, T00046_A25TareaFechaFin, T00046_A38TareaEtiquetas, T00046_A46TareaEstado, T00046_A9TableroId, T00046_A23ResponsableId, T00046_n23ResponsableId
               }
               , new Object[] {
               T00047_A9TableroId
               }
               , new Object[] {
               T00048_A23ResponsableId
               }
               , new Object[] {
               T00049_A9TableroId, T00049_A12TareaId
               }
               , new Object[] {
               T000410_A9TableroId, T000410_A12TareaId
               }
               , new Object[] {
               T000411_A9TableroId, T000411_A12TareaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000415_A9TableroId, T000415_A12TareaId, T000415_A30ActividadId
               }
               , new Object[] {
               T000416_A9TableroId, T000416_A12TareaId, T000416_A27ComentarioId
               }
               , new Object[] {
               T000417_A9TableroId, T000417_A12TareaId
               }
               , new Object[] {
               T000418_A9TableroId
               }
               , new Object[] {
               T000419_A23ResponsableId
               }
            }
         );
      }

      private short Z9TableroId ;
      private short Z12TareaId ;
      private short Z46TareaEstado ;
      private short Z23ResponsableId ;
      private short GxWebError ;
      private short A9TableroId ;
      private short A23ResponsableId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A12TareaId ;
      private short A46TareaEstado ;
      private short GX_JID ;
      private short RcdFound4 ;
      private short nIsDirty_4 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ9TableroId ;
      private short ZZ12TareaId ;
      private short ZZ23ResponsableId ;
      private short ZZ46TareaEstado ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTableroId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtTareaId_Enabled ;
      private int edtTareaNombre_Enabled ;
      private int edtResponsableId_Enabled ;
      private int imgprompt_23_Visible ;
      private int edtTareaFechaInicio_Enabled ;
      private int edtTareaFechaFin_Enabled ;
      private int edtTareaEtiquetas_Enabled ;
      private int edtTareaEstado_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z13TareaNombre ;
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
      private string sImgUrl ;
      private string imgprompt_9_Internalname ;
      private string imgprompt_9_Link ;
      private string edtTareaId_Internalname ;
      private string edtTareaId_Jsonclick ;
      private string edtTareaNombre_Internalname ;
      private string A13TareaNombre ;
      private string edtTareaNombre_Jsonclick ;
      private string edtResponsableId_Internalname ;
      private string edtResponsableId_Jsonclick ;
      private string imgprompt_23_Internalname ;
      private string imgprompt_23_Link ;
      private string edtTareaFechaInicio_Internalname ;
      private string edtTareaFechaInicio_Jsonclick ;
      private string edtTareaFechaFin_Internalname ;
      private string edtTareaFechaFin_Jsonclick ;
      private string edtTareaEtiquetas_Internalname ;
      private string edtTareaEstado_Internalname ;
      private string edtTareaEstado_Jsonclick ;
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
      private string sMode4 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ13TareaNombre ;
      private DateTime Z24TareaFechaInicio ;
      private DateTime Z25TareaFechaFin ;
      private DateTime A24TareaFechaInicio ;
      private DateTime A25TareaFechaFin ;
      private DateTime ZZ24TareaFechaInicio ;
      private DateTime ZZ25TareaFechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n23ResponsableId ;
      private bool wbErr ;
      private string A38TareaEtiquetas ;
      private string Z38TareaEtiquetas ;
      private string ZZ38TareaEtiquetas ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00046_A12TareaId ;
      private string[] T00046_A13TareaNombre ;
      private DateTime[] T00046_A24TareaFechaInicio ;
      private DateTime[] T00046_A25TareaFechaFin ;
      private string[] T00046_A38TareaEtiquetas ;
      private short[] T00046_A46TareaEstado ;
      private short[] T00046_A9TableroId ;
      private short[] T00046_A23ResponsableId ;
      private bool[] T00046_n23ResponsableId ;
      private short[] T00044_A9TableroId ;
      private short[] T00045_A23ResponsableId ;
      private bool[] T00045_n23ResponsableId ;
      private short[] T00047_A9TableroId ;
      private short[] T00048_A23ResponsableId ;
      private bool[] T00048_n23ResponsableId ;
      private short[] T00049_A9TableroId ;
      private short[] T00049_A12TareaId ;
      private short[] T00043_A12TareaId ;
      private string[] T00043_A13TareaNombre ;
      private DateTime[] T00043_A24TareaFechaInicio ;
      private DateTime[] T00043_A25TareaFechaFin ;
      private string[] T00043_A38TareaEtiquetas ;
      private short[] T00043_A46TareaEstado ;
      private short[] T00043_A9TableroId ;
      private short[] T00043_A23ResponsableId ;
      private bool[] T00043_n23ResponsableId ;
      private short[] T000410_A9TableroId ;
      private short[] T000410_A12TareaId ;
      private short[] T000411_A9TableroId ;
      private short[] T000411_A12TareaId ;
      private short[] T00042_A12TareaId ;
      private string[] T00042_A13TareaNombre ;
      private DateTime[] T00042_A24TareaFechaInicio ;
      private DateTime[] T00042_A25TareaFechaFin ;
      private string[] T00042_A38TareaEtiquetas ;
      private short[] T00042_A46TareaEstado ;
      private short[] T00042_A9TableroId ;
      private short[] T00042_A23ResponsableId ;
      private bool[] T00042_n23ResponsableId ;
      private short[] T000415_A9TableroId ;
      private short[] T000415_A12TareaId ;
      private short[] T000415_A30ActividadId ;
      private short[] T000416_A9TableroId ;
      private short[] T000416_A12TareaId ;
      private short[] T000416_A27ComentarioId ;
      private short[] T000417_A9TableroId ;
      private short[] T000417_A12TareaId ;
      private short[] T000418_A9TableroId ;
      private short[] T000419_A23ResponsableId ;
      private bool[] T000419_n23ResponsableId ;
      private GXWebForm Form ;
   }

   public class tareas__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00046;
          prmT00046 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmT00044;
          prmT00044 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT00045;
          prmT00045 = new Object[] {
          new ParDef("@ResponsableId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00047;
          prmT00047 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT00048;
          prmT00048 = new Object[] {
          new ParDef("@ResponsableId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00049;
          prmT00049 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmT00043;
          prmT00043 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmT000410;
          prmT000410 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmT000411;
          prmT000411 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmT00042;
          prmT00042 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmT000412;
          prmT000412 = new Object[] {
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@TareaNombre",GXType.NChar,20,0) ,
          new ParDef("@TareaFechaInicio",GXType.Date,8,0) ,
          new ParDef("@TareaFechaFin",GXType.Date,8,0) ,
          new ParDef("@TareaEtiquetas",GXType.NVarChar,2097152,0) ,
          new ParDef("@TareaEstado",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ResponsableId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000413;
          prmT000413 = new Object[] {
          new ParDef("@TareaNombre",GXType.NChar,20,0) ,
          new ParDef("@TareaFechaInicio",GXType.Date,8,0) ,
          new ParDef("@TareaFechaFin",GXType.Date,8,0) ,
          new ParDef("@TareaEtiquetas",GXType.NVarChar,2097152,0) ,
          new ParDef("@TareaEstado",GXType.Int16,4,0) ,
          new ParDef("@ResponsableId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmT000414;
          prmT000414 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmT000415;
          prmT000415 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmT000416;
          prmT000416 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmT000417;
          prmT000417 = new Object[] {
          };
          Object[] prmT000418;
          prmT000418 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000419;
          prmT000419 = new Object[] {
          new ParDef("@ResponsableId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00042", "SELECT [TareaId], [TareaNombre], [TareaFechaInicio], [TareaFechaFin], [TareaEtiquetas], [TareaEstado], [TableroId], [ResponsableId] AS ResponsableId FROM [Tareas] WITH (UPDLOCK) WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00043", "SELECT [TareaId], [TareaNombre], [TareaFechaInicio], [TareaFechaFin], [TareaEtiquetas], [TareaEstado], [TableroId], [ResponsableId] AS ResponsableId FROM [Tareas] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00044", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00045", "SELECT [UsuarioId] AS ResponsableId FROM [Usuarios] WHERE [UsuarioId] = @ResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00046", "SELECT TM1.[TareaId], TM1.[TareaNombre], TM1.[TareaFechaInicio], TM1.[TareaFechaFin], TM1.[TareaEtiquetas], TM1.[TareaEstado], TM1.[TableroId], TM1.[ResponsableId] AS ResponsableId FROM [Tareas] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[TareaId] = @TareaId ORDER BY TM1.[TableroId], TM1.[TareaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00047", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00048", "SELECT [UsuarioId] AS ResponsableId FROM [Usuarios] WHERE [UsuarioId] = @ResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00049", "SELECT [TableroId], [TareaId] FROM [Tareas] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000410", "SELECT TOP 1 [TableroId], [TareaId] FROM [Tareas] WHERE ( [TableroId] > @TableroId or [TableroId] = @TableroId and [TareaId] > @TareaId) ORDER BY [TableroId], [TareaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000411", "SELECT TOP 1 [TableroId], [TareaId] FROM [Tareas] WHERE ( [TableroId] < @TableroId or [TableroId] = @TableroId and [TareaId] < @TareaId) ORDER BY [TableroId] DESC, [TareaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000412", "INSERT INTO [Tareas]([TareaId], [TareaNombre], [TareaFechaInicio], [TareaFechaFin], [TareaEtiquetas], [TareaEstado], [TableroId], [ResponsableId]) VALUES(@TareaId, @TareaNombre, @TareaFechaInicio, @TareaFechaFin, @TareaEtiquetas, @TareaEstado, @TableroId, @ResponsableId)", GxErrorMask.GX_NOMASK,prmT000412)
             ,new CursorDef("T000413", "UPDATE [Tareas] SET [TareaNombre]=@TareaNombre, [TareaFechaInicio]=@TareaFechaInicio, [TareaFechaFin]=@TareaFechaFin, [TareaEtiquetas]=@TareaEtiquetas, [TareaEstado]=@TareaEstado, [ResponsableId]=@ResponsableId  WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId", GxErrorMask.GX_NOMASK,prmT000413)
             ,new CursorDef("T000414", "DELETE FROM [Tareas]  WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId", GxErrorMask.GX_NOMASK,prmT000414)
             ,new CursorDef("T000415", "SELECT TOP 1 [TableroId], [TareaId], [ActividadId] FROM [Actividades] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000416", "SELECT TOP 1 [TableroId], [TareaId], [ComentarioId] FROM [TareasComentarios] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000417", "SELECT [TableroId], [TareaId] FROM [Tareas] ORDER BY [TableroId], [TareaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000418", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000418,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000419", "SELECT [UsuarioId] AS ResponsableId FROM [Usuarios] WHERE [UsuarioId] = @ResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000419,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
