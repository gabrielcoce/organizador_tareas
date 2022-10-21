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
   public class invitados : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A41InvitadoRolId = (short)(NumberUtil.Val( GetPar( "InvitadoRolId"), "."));
            AssignAttri("", false, "A41InvitadoRolId", StringUtil.LTrimStr( (decimal)(A41InvitadoRolId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A41InvitadoRolId) ;
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
            Form.Meta.addItem("description", "Invitados", 0) ;
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

      public invitados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public invitados( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Invitados", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Invitados.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00c0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TABLEROID"+"'), id:'"+"TABLEROID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"REGISTROINVITADOID"+"'), id:'"+"REGISTROINVITADOID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Invitados.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTableroId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")), StringUtil.LTrim( ((edtTableroId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9") : context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTableroId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTableroId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Invitados.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Invitados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRegistroInvitadoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRegistroInvitadoId_Internalname, "Invitado Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRegistroInvitadoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A40RegistroInvitadoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtRegistroInvitadoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A40RegistroInvitadoId), "ZZZ9") : context.localUtil.Format( (decimal)(A40RegistroInvitadoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRegistroInvitadoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRegistroInvitadoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Invitados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRegistroInvitadoUsuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRegistroInvitadoUsuario_Internalname, "Invitado Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRegistroInvitadoUsuario_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A43RegistroInvitadoUsuario), 4, 0, ",", "")), StringUtil.LTrim( ((edtRegistroInvitadoUsuario_Enabled!=0) ? context.localUtil.Format( (decimal)(A43RegistroInvitadoUsuario), "ZZZ9") : context.localUtil.Format( (decimal)(A43RegistroInvitadoUsuario), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRegistroInvitadoUsuario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRegistroInvitadoUsuario_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Invitados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRegistroInvitadoEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRegistroInvitadoEmail_Internalname, "Invitado Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRegistroInvitadoEmail_Internalname, A44RegistroInvitadoEmail, StringUtil.RTrim( context.localUtil.Format( A44RegistroInvitadoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A44RegistroInvitadoEmail, "", "", "", edtRegistroInvitadoEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRegistroInvitadoEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Invitados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvitadoRolId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvitadoRolId_Internalname, "Rol Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInvitadoRolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41InvitadoRolId), 4, 0, ",", "")), StringUtil.LTrim( ((edtInvitadoRolId_Enabled!=0) ? context.localUtil.Format( (decimal)(A41InvitadoRolId), "ZZZ9") : context.localUtil.Format( (decimal)(A41InvitadoRolId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvitadoRolId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvitadoRolId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Invitados.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_41_Internalname, sImgUrl, imgprompt_41_Link, "", "", context.GetTheme( ), imgprompt_41_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Invitados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRegistroInvitadoFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRegistroInvitadoFecha_Internalname, "Invitado Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtRegistroInvitadoFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtRegistroInvitadoFecha_Internalname, context.localUtil.TToC( A45RegistroInvitadoFecha, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A45RegistroInvitadoFecha, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRegistroInvitadoFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRegistroInvitadoFecha_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Invitados.htm");
         GxWebStd.gx_bitmap( context, edtRegistroInvitadoFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtRegistroInvitadoFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Invitados.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitados.htm");
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
            Z40RegistroInvitadoId = (short)(context.localUtil.CToN( cgiGet( "Z40RegistroInvitadoId"), ",", "."));
            Z43RegistroInvitadoUsuario = (short)(context.localUtil.CToN( cgiGet( "Z43RegistroInvitadoUsuario"), ",", "."));
            Z44RegistroInvitadoEmail = cgiGet( "Z44RegistroInvitadoEmail");
            Z45RegistroInvitadoFecha = context.localUtil.CToT( cgiGet( "Z45RegistroInvitadoFecha"), 0);
            Z41InvitadoRolId = (short)(context.localUtil.CToN( cgiGet( "Z41InvitadoRolId"), ",", "."));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtRegistroInvitadoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRegistroInvitadoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REGISTROINVITADOID");
               AnyError = 1;
               GX_FocusControl = edtRegistroInvitadoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A40RegistroInvitadoId = 0;
               AssignAttri("", false, "A40RegistroInvitadoId", StringUtil.LTrimStr( (decimal)(A40RegistroInvitadoId), 4, 0));
            }
            else
            {
               A40RegistroInvitadoId = (short)(context.localUtil.CToN( cgiGet( edtRegistroInvitadoId_Internalname), ",", "."));
               AssignAttri("", false, "A40RegistroInvitadoId", StringUtil.LTrimStr( (decimal)(A40RegistroInvitadoId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtRegistroInvitadoUsuario_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRegistroInvitadoUsuario_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REGISTROINVITADOUSUARIO");
               AnyError = 1;
               GX_FocusControl = edtRegistroInvitadoUsuario_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A43RegistroInvitadoUsuario = 0;
               AssignAttri("", false, "A43RegistroInvitadoUsuario", StringUtil.LTrimStr( (decimal)(A43RegistroInvitadoUsuario), 4, 0));
            }
            else
            {
               A43RegistroInvitadoUsuario = (short)(context.localUtil.CToN( cgiGet( edtRegistroInvitadoUsuario_Internalname), ",", "."));
               AssignAttri("", false, "A43RegistroInvitadoUsuario", StringUtil.LTrimStr( (decimal)(A43RegistroInvitadoUsuario), 4, 0));
            }
            A44RegistroInvitadoEmail = cgiGet( edtRegistroInvitadoEmail_Internalname);
            AssignAttri("", false, "A44RegistroInvitadoEmail", A44RegistroInvitadoEmail);
            if ( ( ( context.localUtil.CToN( cgiGet( edtInvitadoRolId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvitadoRolId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "INVITADOROLID");
               AnyError = 1;
               GX_FocusControl = edtInvitadoRolId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A41InvitadoRolId = 0;
               AssignAttri("", false, "A41InvitadoRolId", StringUtil.LTrimStr( (decimal)(A41InvitadoRolId), 4, 0));
            }
            else
            {
               A41InvitadoRolId = (short)(context.localUtil.CToN( cgiGet( edtInvitadoRolId_Internalname), ",", "."));
               AssignAttri("", false, "A41InvitadoRolId", StringUtil.LTrimStr( (decimal)(A41InvitadoRolId), 4, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtRegistroInvitadoFecha_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Registro Invitado Fecha"}), 1, "REGISTROINVITADOFECHA");
               AnyError = 1;
               GX_FocusControl = edtRegistroInvitadoFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A45RegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A45RegistroInvitadoFecha", context.localUtil.TToC( A45RegistroInvitadoFecha, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A45RegistroInvitadoFecha = context.localUtil.CToT( cgiGet( edtRegistroInvitadoFecha_Internalname));
               AssignAttri("", false, "A45RegistroInvitadoFecha", context.localUtil.TToC( A45RegistroInvitadoFecha, 8, 5, 0, 3, "/", ":", " "));
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
               A40RegistroInvitadoId = (short)(NumberUtil.Val( GetPar( "RegistroInvitadoId"), "."));
               AssignAttri("", false, "A40RegistroInvitadoId", StringUtil.LTrimStr( (decimal)(A40RegistroInvitadoId), 4, 0));
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
               InitAll0B12( ) ;
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
         DisableAttributes0B12( ) ;
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

      protected void ResetCaption0B0( )
      {
      }

      protected void ZM0B12( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z43RegistroInvitadoUsuario = T000B3_A43RegistroInvitadoUsuario[0];
               Z44RegistroInvitadoEmail = T000B3_A44RegistroInvitadoEmail[0];
               Z45RegistroInvitadoFecha = T000B3_A45RegistroInvitadoFecha[0];
               Z41InvitadoRolId = T000B3_A41InvitadoRolId[0];
            }
            else
            {
               Z43RegistroInvitadoUsuario = A43RegistroInvitadoUsuario;
               Z44RegistroInvitadoEmail = A44RegistroInvitadoEmail;
               Z45RegistroInvitadoFecha = A45RegistroInvitadoFecha;
               Z41InvitadoRolId = A41InvitadoRolId;
            }
         }
         if ( GX_JID == -3 )
         {
            Z40RegistroInvitadoId = A40RegistroInvitadoId;
            Z43RegistroInvitadoUsuario = A43RegistroInvitadoUsuario;
            Z44RegistroInvitadoEmail = A44RegistroInvitadoEmail;
            Z45RegistroInvitadoFecha = A45RegistroInvitadoFecha;
            Z9TableroId = A9TableroId;
            Z41InvitadoRolId = A41InvitadoRolId;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TABLEROID"+"'), id:'"+"TABLEROID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_41_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INVITADOROLID"+"'), id:'"+"INVITADOROLID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load0B12( )
      {
         /* Using cursor T000B6 */
         pr_default.execute(4, new Object[] {A9TableroId, A40RegistroInvitadoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound12 = 1;
            A43RegistroInvitadoUsuario = T000B6_A43RegistroInvitadoUsuario[0];
            AssignAttri("", false, "A43RegistroInvitadoUsuario", StringUtil.LTrimStr( (decimal)(A43RegistroInvitadoUsuario), 4, 0));
            A44RegistroInvitadoEmail = T000B6_A44RegistroInvitadoEmail[0];
            AssignAttri("", false, "A44RegistroInvitadoEmail", A44RegistroInvitadoEmail);
            A45RegistroInvitadoFecha = T000B6_A45RegistroInvitadoFecha[0];
            AssignAttri("", false, "A45RegistroInvitadoFecha", context.localUtil.TToC( A45RegistroInvitadoFecha, 8, 5, 0, 3, "/", ":", " "));
            A41InvitadoRolId = T000B6_A41InvitadoRolId[0];
            AssignAttri("", false, "A41InvitadoRolId", StringUtil.LTrimStr( (decimal)(A41InvitadoRolId), 4, 0));
            ZM0B12( -3) ;
         }
         pr_default.close(4);
         OnLoadActions0B12( ) ;
      }

      protected void OnLoadActions0B12( )
      {
      }

      protected void CheckExtendedTable0B12( )
      {
         nIsDirty_12 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000B4 */
         pr_default.execute(2, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A44RegistroInvitadoEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de Registro Invitado Email no coincide con el patrón especificado", "OutOfRange", 1, "REGISTROINVITADOEMAIL");
            AnyError = 1;
            GX_FocusControl = edtRegistroInvitadoEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000B5 */
         pr_default.execute(3, new Object[] {A41InvitadoRolId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Invitado Rol'.", "ForeignKeyNotFound", 1, "INVITADOROLID");
            AnyError = 1;
            GX_FocusControl = edtInvitadoRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A45RegistroInvitadoFecha) || ( A45RegistroInvitadoFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Registro Invitado Fecha fuera de rango", "OutOfRange", 1, "REGISTROINVITADOFECHA");
            AnyError = 1;
            GX_FocusControl = edtRegistroInvitadoFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0B12( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( short A9TableroId )
      {
         /* Using cursor T000B7 */
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

      protected void gxLoad_5( short A41InvitadoRolId )
      {
         /* Using cursor T000B8 */
         pr_default.execute(6, new Object[] {A41InvitadoRolId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Invitado Rol'.", "ForeignKeyNotFound", 1, "INVITADOROLID");
            AnyError = 1;
            GX_FocusControl = edtInvitadoRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void GetKey0B12( )
      {
         /* Using cursor T000B9 */
         pr_default.execute(7, new Object[] {A9TableroId, A40RegistroInvitadoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000B3 */
         pr_default.execute(1, new Object[] {A9TableroId, A40RegistroInvitadoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B12( 3) ;
            RcdFound12 = 1;
            A40RegistroInvitadoId = T000B3_A40RegistroInvitadoId[0];
            AssignAttri("", false, "A40RegistroInvitadoId", StringUtil.LTrimStr( (decimal)(A40RegistroInvitadoId), 4, 0));
            A43RegistroInvitadoUsuario = T000B3_A43RegistroInvitadoUsuario[0];
            AssignAttri("", false, "A43RegistroInvitadoUsuario", StringUtil.LTrimStr( (decimal)(A43RegistroInvitadoUsuario), 4, 0));
            A44RegistroInvitadoEmail = T000B3_A44RegistroInvitadoEmail[0];
            AssignAttri("", false, "A44RegistroInvitadoEmail", A44RegistroInvitadoEmail);
            A45RegistroInvitadoFecha = T000B3_A45RegistroInvitadoFecha[0];
            AssignAttri("", false, "A45RegistroInvitadoFecha", context.localUtil.TToC( A45RegistroInvitadoFecha, 8, 5, 0, 3, "/", ":", " "));
            A9TableroId = T000B3_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A41InvitadoRolId = T000B3_A41InvitadoRolId[0];
            AssignAttri("", false, "A41InvitadoRolId", StringUtil.LTrimStr( (decimal)(A41InvitadoRolId), 4, 0));
            Z9TableroId = A9TableroId;
            Z40RegistroInvitadoId = A40RegistroInvitadoId;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0B12( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0B12( ) ;
            }
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0B12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B12( ) ;
         if ( RcdFound12 == 0 )
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
         RcdFound12 = 0;
         /* Using cursor T000B10 */
         pr_default.execute(8, new Object[] {A9TableroId, A40RegistroInvitadoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000B10_A9TableroId[0] < A9TableroId ) || ( T000B10_A9TableroId[0] == A9TableroId ) && ( T000B10_A40RegistroInvitadoId[0] < A40RegistroInvitadoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000B10_A9TableroId[0] > A9TableroId ) || ( T000B10_A9TableroId[0] == A9TableroId ) && ( T000B10_A40RegistroInvitadoId[0] > A40RegistroInvitadoId ) ) )
            {
               A9TableroId = T000B10_A9TableroId[0];
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               A40RegistroInvitadoId = T000B10_A40RegistroInvitadoId[0];
               AssignAttri("", false, "A40RegistroInvitadoId", StringUtil.LTrimStr( (decimal)(A40RegistroInvitadoId), 4, 0));
               RcdFound12 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound12 = 0;
         /* Using cursor T000B11 */
         pr_default.execute(9, new Object[] {A9TableroId, A40RegistroInvitadoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000B11_A9TableroId[0] > A9TableroId ) || ( T000B11_A9TableroId[0] == A9TableroId ) && ( T000B11_A40RegistroInvitadoId[0] > A40RegistroInvitadoId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000B11_A9TableroId[0] < A9TableroId ) || ( T000B11_A9TableroId[0] == A9TableroId ) && ( T000B11_A40RegistroInvitadoId[0] < A40RegistroInvitadoId ) ) )
            {
               A9TableroId = T000B11_A9TableroId[0];
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               A40RegistroInvitadoId = T000B11_A40RegistroInvitadoId[0];
               AssignAttri("", false, "A40RegistroInvitadoId", StringUtil.LTrimStr( (decimal)(A40RegistroInvitadoId), 4, 0));
               RcdFound12 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0B12( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0B12( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A40RegistroInvitadoId != Z40RegistroInvitadoId ) )
               {
                  A9TableroId = Z9TableroId;
                  AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
                  A40RegistroInvitadoId = Z40RegistroInvitadoId;
                  AssignAttri("", false, "A40RegistroInvitadoId", StringUtil.LTrimStr( (decimal)(A40RegistroInvitadoId), 4, 0));
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
                  Update0B12( ) ;
                  GX_FocusControl = edtTableroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A40RegistroInvitadoId != Z40RegistroInvitadoId ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTableroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0B12( ) ;
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
                     Insert0B12( ) ;
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
         if ( ( A9TableroId != Z9TableroId ) || ( A40RegistroInvitadoId != Z40RegistroInvitadoId ) )
         {
            A9TableroId = Z9TableroId;
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A40RegistroInvitadoId = Z40RegistroInvitadoId;
            AssignAttri("", false, "A40RegistroInvitadoId", StringUtil.LTrimStr( (decimal)(A40RegistroInvitadoId), 4, 0));
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
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtRegistroInvitadoUsuario_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRegistroInvitadoUsuario_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0B12( ) ;
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
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRegistroInvitadoUsuario_Internalname;
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
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRegistroInvitadoUsuario_Internalname;
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
         ScanStart0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound12 != 0 )
            {
               ScanNext0B12( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRegistroInvitadoUsuario_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0B12( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0B12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B2 */
            pr_default.execute(0, new Object[] {A9TableroId, A40RegistroInvitadoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitados"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z43RegistroInvitadoUsuario != T000B2_A43RegistroInvitadoUsuario[0] ) || ( StringUtil.StrCmp(Z44RegistroInvitadoEmail, T000B2_A44RegistroInvitadoEmail[0]) != 0 ) || ( Z45RegistroInvitadoFecha != T000B2_A45RegistroInvitadoFecha[0] ) || ( Z41InvitadoRolId != T000B2_A41InvitadoRolId[0] ) )
            {
               if ( Z43RegistroInvitadoUsuario != T000B2_A43RegistroInvitadoUsuario[0] )
               {
                  GXUtil.WriteLog("invitados:[seudo value changed for attri]"+"RegistroInvitadoUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z43RegistroInvitadoUsuario);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A43RegistroInvitadoUsuario[0]);
               }
               if ( StringUtil.StrCmp(Z44RegistroInvitadoEmail, T000B2_A44RegistroInvitadoEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("invitados:[seudo value changed for attri]"+"RegistroInvitadoEmail");
                  GXUtil.WriteLogRaw("Old: ",Z44RegistroInvitadoEmail);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A44RegistroInvitadoEmail[0]);
               }
               if ( Z45RegistroInvitadoFecha != T000B2_A45RegistroInvitadoFecha[0] )
               {
                  GXUtil.WriteLog("invitados:[seudo value changed for attri]"+"RegistroInvitadoFecha");
                  GXUtil.WriteLogRaw("Old: ",Z45RegistroInvitadoFecha);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A45RegistroInvitadoFecha[0]);
               }
               if ( Z41InvitadoRolId != T000B2_A41InvitadoRolId[0] )
               {
                  GXUtil.WriteLog("invitados:[seudo value changed for attri]"+"InvitadoRolId");
                  GXUtil.WriteLogRaw("Old: ",Z41InvitadoRolId);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A41InvitadoRolId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Invitados"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B12( 0) ;
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B12 */
                     pr_default.execute(10, new Object[] {A40RegistroInvitadoId, A43RegistroInvitadoUsuario, A44RegistroInvitadoEmail, A45RegistroInvitadoFecha, A9TableroId, A41InvitadoRolId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Invitados");
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
                           ResetCaption0B0( ) ;
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
               Load0B12( ) ;
            }
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void Update0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B13 */
                     pr_default.execute(11, new Object[] {A43RegistroInvitadoUsuario, A44RegistroInvitadoEmail, A45RegistroInvitadoFecha, A41InvitadoRolId, A9TableroId, A40RegistroInvitadoId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Invitados");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitados"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B12( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0B0( ) ;
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
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void DeferredUpdate0B12( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B12( ) ;
            AfterConfirm0B12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000B14 */
                  pr_default.execute(12, new Object[] {A9TableroId, A40RegistroInvitadoId});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("Invitados");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound12 == 0 )
                        {
                           InitAll0B12( ) ;
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
                        ResetCaption0B0( ) ;
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
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0B12( ) ;
         Gx_mode = sMode12;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B12( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0B12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("invitados",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("invitados",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B12( )
      {
         /* Using cursor T000B15 */
         pr_default.execute(13);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound12 = 1;
            A9TableroId = T000B15_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A40RegistroInvitadoId = T000B15_A40RegistroInvitadoId[0];
            AssignAttri("", false, "A40RegistroInvitadoId", StringUtil.LTrimStr( (decimal)(A40RegistroInvitadoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B12( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound12 = 1;
            A9TableroId = T000B15_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A40RegistroInvitadoId = T000B15_A40RegistroInvitadoId[0];
            AssignAttri("", false, "A40RegistroInvitadoId", StringUtil.LTrimStr( (decimal)(A40RegistroInvitadoId), 4, 0));
         }
      }

      protected void ScanEnd0B12( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0B12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B12( )
      {
         edtTableroId_Enabled = 0;
         AssignProp("", false, edtTableroId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTableroId_Enabled), 5, 0), true);
         edtRegistroInvitadoId_Enabled = 0;
         AssignProp("", false, edtRegistroInvitadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegistroInvitadoId_Enabled), 5, 0), true);
         edtRegistroInvitadoUsuario_Enabled = 0;
         AssignProp("", false, edtRegistroInvitadoUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegistroInvitadoUsuario_Enabled), 5, 0), true);
         edtRegistroInvitadoEmail_Enabled = 0;
         AssignProp("", false, edtRegistroInvitadoEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegistroInvitadoEmail_Enabled), 5, 0), true);
         edtInvitadoRolId_Enabled = 0;
         AssignProp("", false, edtInvitadoRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitadoRolId_Enabled), 5, 0), true);
         edtRegistroInvitadoFecha_Enabled = 0;
         AssignProp("", false, edtRegistroInvitadoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegistroInvitadoFecha_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0B12( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0B0( )
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("invitados.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z40RegistroInvitadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40RegistroInvitadoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z43RegistroInvitadoUsuario", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z43RegistroInvitadoUsuario), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z44RegistroInvitadoEmail", Z44RegistroInvitadoEmail);
         GxWebStd.gx_hidden_field( context, "Z45RegistroInvitadoFecha", context.localUtil.TToC( Z45RegistroInvitadoFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z41InvitadoRolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41InvitadoRolId), 4, 0, ",", "")));
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
         return formatLink("invitados.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Invitados" ;
      }

      public override string GetPgmdesc( )
      {
         return "Invitados" ;
      }

      protected void InitializeNonKey0B12( )
      {
         A43RegistroInvitadoUsuario = 0;
         AssignAttri("", false, "A43RegistroInvitadoUsuario", StringUtil.LTrimStr( (decimal)(A43RegistroInvitadoUsuario), 4, 0));
         A44RegistroInvitadoEmail = "";
         AssignAttri("", false, "A44RegistroInvitadoEmail", A44RegistroInvitadoEmail);
         A41InvitadoRolId = 0;
         AssignAttri("", false, "A41InvitadoRolId", StringUtil.LTrimStr( (decimal)(A41InvitadoRolId), 4, 0));
         A45RegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A45RegistroInvitadoFecha", context.localUtil.TToC( A45RegistroInvitadoFecha, 8, 5, 0, 3, "/", ":", " "));
         Z43RegistroInvitadoUsuario = 0;
         Z44RegistroInvitadoEmail = "";
         Z45RegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
         Z41InvitadoRolId = 0;
      }

      protected void InitAll0B12( )
      {
         A9TableroId = 0;
         AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
         A40RegistroInvitadoId = 0;
         AssignAttri("", false, "A40RegistroInvitadoId", StringUtil.LTrimStr( (decimal)(A40RegistroInvitadoId), 4, 0));
         InitializeNonKey0B12( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022101612475290", true, true);
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
         context.AddJavascriptSource("invitados.js", "?2022101612475290", false, true);
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
         edtRegistroInvitadoId_Internalname = "REGISTROINVITADOID";
         edtRegistroInvitadoUsuario_Internalname = "REGISTROINVITADOUSUARIO";
         edtRegistroInvitadoEmail_Internalname = "REGISTROINVITADOEMAIL";
         edtInvitadoRolId_Internalname = "INVITADOROLID";
         edtRegistroInvitadoFecha_Internalname = "REGISTROINVITADOFECHA";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_9_Internalname = "PROMPT_9";
         imgprompt_41_Internalname = "PROMPT_41";
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
         Form.Caption = "Invitados";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtRegistroInvitadoFecha_Jsonclick = "";
         edtRegistroInvitadoFecha_Enabled = 1;
         imgprompt_41_Visible = 1;
         imgprompt_41_Link = "";
         edtInvitadoRolId_Jsonclick = "";
         edtInvitadoRolId_Enabled = 1;
         edtRegistroInvitadoEmail_Jsonclick = "";
         edtRegistroInvitadoEmail_Enabled = 1;
         edtRegistroInvitadoUsuario_Jsonclick = "";
         edtRegistroInvitadoUsuario_Enabled = 1;
         edtRegistroInvitadoId_Jsonclick = "";
         edtRegistroInvitadoId_Enabled = 1;
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
         /* Using cursor T000B16 */
         pr_default.execute(14, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         GX_FocusControl = edtRegistroInvitadoUsuario_Internalname;
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
         /* Using cursor T000B16 */
         pr_default.execute(14, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Registroinvitadoid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A43RegistroInvitadoUsuario", StringUtil.LTrim( StringUtil.NToC( (decimal)(A43RegistroInvitadoUsuario), 4, 0, ".", "")));
         AssignAttri("", false, "A44RegistroInvitadoEmail", A44RegistroInvitadoEmail);
         AssignAttri("", false, "A41InvitadoRolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41InvitadoRolId), 4, 0, ".", "")));
         AssignAttri("", false, "A45RegistroInvitadoFecha", context.localUtil.TToC( A45RegistroInvitadoFecha, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z9TableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9TableroId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z40RegistroInvitadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40RegistroInvitadoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z43RegistroInvitadoUsuario", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z43RegistroInvitadoUsuario), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z44RegistroInvitadoEmail", Z44RegistroInvitadoEmail);
         GxWebStd.gx_hidden_field( context, "Z41InvitadoRolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41InvitadoRolId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z45RegistroInvitadoFecha", context.localUtil.TToC( Z45RegistroInvitadoFecha, 10, 8, 0, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Invitadorolid( )
      {
         /* Using cursor T000B17 */
         pr_default.execute(15, new Object[] {A41InvitadoRolId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Invitado Rol'.", "ForeignKeyNotFound", 1, "INVITADOROLID");
            AnyError = 1;
            GX_FocusControl = edtInvitadoRolId_Internalname;
         }
         pr_default.close(15);
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
         setEventMetadata("VALID_REGISTROINVITADOID","{handler:'Valid_Registroinvitadoid',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A40RegistroInvitadoId',fld:'REGISTROINVITADOID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_REGISTROINVITADOID",",oparms:[{av:'A43RegistroInvitadoUsuario',fld:'REGISTROINVITADOUSUARIO',pic:'ZZZ9'},{av:'A44RegistroInvitadoEmail',fld:'REGISTROINVITADOEMAIL',pic:''},{av:'A41InvitadoRolId',fld:'INVITADOROLID',pic:'ZZZ9'},{av:'A45RegistroInvitadoFecha',fld:'REGISTROINVITADOFECHA',pic:'99/99/99 99:99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z9TableroId'},{av:'Z40RegistroInvitadoId'},{av:'Z43RegistroInvitadoUsuario'},{av:'Z44RegistroInvitadoEmail'},{av:'Z41InvitadoRolId'},{av:'Z45RegistroInvitadoFecha'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_REGISTROINVITADOEMAIL","{handler:'Valid_Registroinvitadoemail',iparms:[]");
         setEventMetadata("VALID_REGISTROINVITADOEMAIL",",oparms:[]}");
         setEventMetadata("VALID_INVITADOROLID","{handler:'Valid_Invitadorolid',iparms:[{av:'A41InvitadoRolId',fld:'INVITADOROLID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_INVITADOROLID",",oparms:[]}");
         setEventMetadata("VALID_REGISTROINVITADOFECHA","{handler:'Valid_Registroinvitadofecha',iparms:[]");
         setEventMetadata("VALID_REGISTROINVITADOFECHA",",oparms:[]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z44RegistroInvitadoEmail = "";
         Z45RegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
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
         A44RegistroInvitadoEmail = "";
         A45RegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
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
         T000B6_A40RegistroInvitadoId = new short[1] ;
         T000B6_A43RegistroInvitadoUsuario = new short[1] ;
         T000B6_A44RegistroInvitadoEmail = new string[] {""} ;
         T000B6_A45RegistroInvitadoFecha = new DateTime[] {DateTime.MinValue} ;
         T000B6_A9TableroId = new short[1] ;
         T000B6_A41InvitadoRolId = new short[1] ;
         T000B4_A9TableroId = new short[1] ;
         T000B5_A41InvitadoRolId = new short[1] ;
         T000B7_A9TableroId = new short[1] ;
         T000B8_A41InvitadoRolId = new short[1] ;
         T000B9_A9TableroId = new short[1] ;
         T000B9_A40RegistroInvitadoId = new short[1] ;
         T000B3_A40RegistroInvitadoId = new short[1] ;
         T000B3_A43RegistroInvitadoUsuario = new short[1] ;
         T000B3_A44RegistroInvitadoEmail = new string[] {""} ;
         T000B3_A45RegistroInvitadoFecha = new DateTime[] {DateTime.MinValue} ;
         T000B3_A9TableroId = new short[1] ;
         T000B3_A41InvitadoRolId = new short[1] ;
         sMode12 = "";
         T000B10_A9TableroId = new short[1] ;
         T000B10_A40RegistroInvitadoId = new short[1] ;
         T000B11_A9TableroId = new short[1] ;
         T000B11_A40RegistroInvitadoId = new short[1] ;
         T000B2_A40RegistroInvitadoId = new short[1] ;
         T000B2_A43RegistroInvitadoUsuario = new short[1] ;
         T000B2_A44RegistroInvitadoEmail = new string[] {""} ;
         T000B2_A45RegistroInvitadoFecha = new DateTime[] {DateTime.MinValue} ;
         T000B2_A9TableroId = new short[1] ;
         T000B2_A41InvitadoRolId = new short[1] ;
         T000B15_A9TableroId = new short[1] ;
         T000B15_A40RegistroInvitadoId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000B16_A9TableroId = new short[1] ;
         ZZ44RegistroInvitadoEmail = "";
         ZZ45RegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
         T000B17_A41InvitadoRolId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invitados__default(),
            new Object[][] {
                new Object[] {
               T000B2_A40RegistroInvitadoId, T000B2_A43RegistroInvitadoUsuario, T000B2_A44RegistroInvitadoEmail, T000B2_A45RegistroInvitadoFecha, T000B2_A9TableroId, T000B2_A41InvitadoRolId
               }
               , new Object[] {
               T000B3_A40RegistroInvitadoId, T000B3_A43RegistroInvitadoUsuario, T000B3_A44RegistroInvitadoEmail, T000B3_A45RegistroInvitadoFecha, T000B3_A9TableroId, T000B3_A41InvitadoRolId
               }
               , new Object[] {
               T000B4_A9TableroId
               }
               , new Object[] {
               T000B5_A41InvitadoRolId
               }
               , new Object[] {
               T000B6_A40RegistroInvitadoId, T000B6_A43RegistroInvitadoUsuario, T000B6_A44RegistroInvitadoEmail, T000B6_A45RegistroInvitadoFecha, T000B6_A9TableroId, T000B6_A41InvitadoRolId
               }
               , new Object[] {
               T000B7_A9TableroId
               }
               , new Object[] {
               T000B8_A41InvitadoRolId
               }
               , new Object[] {
               T000B9_A9TableroId, T000B9_A40RegistroInvitadoId
               }
               , new Object[] {
               T000B10_A9TableroId, T000B10_A40RegistroInvitadoId
               }
               , new Object[] {
               T000B11_A9TableroId, T000B11_A40RegistroInvitadoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B15_A9TableroId, T000B15_A40RegistroInvitadoId
               }
               , new Object[] {
               T000B16_A9TableroId
               }
               , new Object[] {
               T000B17_A41InvitadoRolId
               }
            }
         );
      }

      private short Z9TableroId ;
      private short Z40RegistroInvitadoId ;
      private short Z43RegistroInvitadoUsuario ;
      private short Z41InvitadoRolId ;
      private short GxWebError ;
      private short A9TableroId ;
      private short A41InvitadoRolId ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A40RegistroInvitadoId ;
      private short A43RegistroInvitadoUsuario ;
      private short GX_JID ;
      private short RcdFound12 ;
      private short nIsDirty_12 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ9TableroId ;
      private short ZZ40RegistroInvitadoId ;
      private short ZZ43RegistroInvitadoUsuario ;
      private short ZZ41InvitadoRolId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTableroId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtRegistroInvitadoId_Enabled ;
      private int edtRegistroInvitadoUsuario_Enabled ;
      private int edtRegistroInvitadoEmail_Enabled ;
      private int edtInvitadoRolId_Enabled ;
      private int imgprompt_41_Visible ;
      private int edtRegistroInvitadoFecha_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
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
      private string edtRegistroInvitadoId_Internalname ;
      private string edtRegistroInvitadoId_Jsonclick ;
      private string edtRegistroInvitadoUsuario_Internalname ;
      private string edtRegistroInvitadoUsuario_Jsonclick ;
      private string edtRegistroInvitadoEmail_Internalname ;
      private string edtRegistroInvitadoEmail_Jsonclick ;
      private string edtInvitadoRolId_Internalname ;
      private string edtInvitadoRolId_Jsonclick ;
      private string imgprompt_41_Internalname ;
      private string imgprompt_41_Link ;
      private string edtRegistroInvitadoFecha_Internalname ;
      private string edtRegistroInvitadoFecha_Jsonclick ;
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
      private string sMode12 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z45RegistroInvitadoFecha ;
      private DateTime A45RegistroInvitadoFecha ;
      private DateTime ZZ45RegistroInvitadoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z44RegistroInvitadoEmail ;
      private string A44RegistroInvitadoEmail ;
      private string ZZ44RegistroInvitadoEmail ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T000B6_A40RegistroInvitadoId ;
      private short[] T000B6_A43RegistroInvitadoUsuario ;
      private string[] T000B6_A44RegistroInvitadoEmail ;
      private DateTime[] T000B6_A45RegistroInvitadoFecha ;
      private short[] T000B6_A9TableroId ;
      private short[] T000B6_A41InvitadoRolId ;
      private short[] T000B4_A9TableroId ;
      private short[] T000B5_A41InvitadoRolId ;
      private short[] T000B7_A9TableroId ;
      private short[] T000B8_A41InvitadoRolId ;
      private short[] T000B9_A9TableroId ;
      private short[] T000B9_A40RegistroInvitadoId ;
      private short[] T000B3_A40RegistroInvitadoId ;
      private short[] T000B3_A43RegistroInvitadoUsuario ;
      private string[] T000B3_A44RegistroInvitadoEmail ;
      private DateTime[] T000B3_A45RegistroInvitadoFecha ;
      private short[] T000B3_A9TableroId ;
      private short[] T000B3_A41InvitadoRolId ;
      private short[] T000B10_A9TableroId ;
      private short[] T000B10_A40RegistroInvitadoId ;
      private short[] T000B11_A9TableroId ;
      private short[] T000B11_A40RegistroInvitadoId ;
      private short[] T000B2_A40RegistroInvitadoId ;
      private short[] T000B2_A43RegistroInvitadoUsuario ;
      private string[] T000B2_A44RegistroInvitadoEmail ;
      private DateTime[] T000B2_A45RegistroInvitadoFecha ;
      private short[] T000B2_A9TableroId ;
      private short[] T000B2_A41InvitadoRolId ;
      private short[] T000B15_A9TableroId ;
      private short[] T000B15_A40RegistroInvitadoId ;
      private short[] T000B16_A9TableroId ;
      private short[] T000B17_A41InvitadoRolId ;
      private GXWebForm Form ;
   }

   public class invitados__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000B6;
          prmT000B6 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmT000B4;
          prmT000B4 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000B5;
          prmT000B5 = new Object[] {
          new ParDef("@InvitadoRolId",GXType.Int16,4,0)
          };
          Object[] prmT000B7;
          prmT000B7 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000B8;
          prmT000B8 = new Object[] {
          new ParDef("@InvitadoRolId",GXType.Int16,4,0)
          };
          Object[] prmT000B9;
          prmT000B9 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmT000B3;
          prmT000B3 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmT000B10;
          prmT000B10 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmT000B11;
          prmT000B11 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmT000B2;
          prmT000B2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmT000B12;
          prmT000B12 = new Object[] {
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoUsuario",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoEmail",GXType.NVarChar,100,0) ,
          new ParDef("@RegistroInvitadoFecha",GXType.DateTime,8,5) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@InvitadoRolId",GXType.Int16,4,0)
          };
          Object[] prmT000B13;
          prmT000B13 = new Object[] {
          new ParDef("@RegistroInvitadoUsuario",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoEmail",GXType.NVarChar,100,0) ,
          new ParDef("@RegistroInvitadoFecha",GXType.DateTime,8,5) ,
          new ParDef("@InvitadoRolId",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmT000B14;
          prmT000B14 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmT000B15;
          prmT000B15 = new Object[] {
          };
          Object[] prmT000B16;
          prmT000B16 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000B17;
          prmT000B17 = new Object[] {
          new ParDef("@InvitadoRolId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000B2", "SELECT [RegistroInvitadoId], [RegistroInvitadoUsuario], [RegistroInvitadoEmail], [RegistroInvitadoFecha], [TableroId], [InvitadoRolId] AS InvitadoRolId FROM [Invitados] WITH (UPDLOCK) WHERE [TableroId] = @TableroId AND [RegistroInvitadoId] = @RegistroInvitadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B3", "SELECT [RegistroInvitadoId], [RegistroInvitadoUsuario], [RegistroInvitadoEmail], [RegistroInvitadoFecha], [TableroId], [InvitadoRolId] AS InvitadoRolId FROM [Invitados] WHERE [TableroId] = @TableroId AND [RegistroInvitadoId] = @RegistroInvitadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B4", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B5", "SELECT [RolId] AS InvitadoRolId FROM [Roles] WHERE [RolId] = @InvitadoRolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B6", "SELECT TM1.[RegistroInvitadoId], TM1.[RegistroInvitadoUsuario], TM1.[RegistroInvitadoEmail], TM1.[RegistroInvitadoFecha], TM1.[TableroId], TM1.[InvitadoRolId] AS InvitadoRolId FROM [Invitados] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[RegistroInvitadoId] = @RegistroInvitadoId ORDER BY TM1.[TableroId], TM1.[RegistroInvitadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B7", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B8", "SELECT [RolId] AS InvitadoRolId FROM [Roles] WHERE [RolId] = @InvitadoRolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B9", "SELECT [TableroId], [RegistroInvitadoId] FROM [Invitados] WHERE [TableroId] = @TableroId AND [RegistroInvitadoId] = @RegistroInvitadoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B10", "SELECT TOP 1 [TableroId], [RegistroInvitadoId] FROM [Invitados] WHERE ( [TableroId] > @TableroId or [TableroId] = @TableroId and [RegistroInvitadoId] > @RegistroInvitadoId) ORDER BY [TableroId], [RegistroInvitadoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000B11", "SELECT TOP 1 [TableroId], [RegistroInvitadoId] FROM [Invitados] WHERE ( [TableroId] < @TableroId or [TableroId] = @TableroId and [RegistroInvitadoId] < @RegistroInvitadoId) ORDER BY [TableroId] DESC, [RegistroInvitadoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000B12", "INSERT INTO [Invitados]([RegistroInvitadoId], [RegistroInvitadoUsuario], [RegistroInvitadoEmail], [RegistroInvitadoFecha], [TableroId], [InvitadoRolId]) VALUES(@RegistroInvitadoId, @RegistroInvitadoUsuario, @RegistroInvitadoEmail, @RegistroInvitadoFecha, @TableroId, @InvitadoRolId)", GxErrorMask.GX_NOMASK,prmT000B12)
             ,new CursorDef("T000B13", "UPDATE [Invitados] SET [RegistroInvitadoUsuario]=@RegistroInvitadoUsuario, [RegistroInvitadoEmail]=@RegistroInvitadoEmail, [RegistroInvitadoFecha]=@RegistroInvitadoFecha, [InvitadoRolId]=@InvitadoRolId  WHERE [TableroId] = @TableroId AND [RegistroInvitadoId] = @RegistroInvitadoId", GxErrorMask.GX_NOMASK,prmT000B13)
             ,new CursorDef("T000B14", "DELETE FROM [Invitados]  WHERE [TableroId] = @TableroId AND [RegistroInvitadoId] = @RegistroInvitadoId", GxErrorMask.GX_NOMASK,prmT000B14)
             ,new CursorDef("T000B15", "SELECT [TableroId], [RegistroInvitadoId] FROM [Invitados] ORDER BY [TableroId], [RegistroInvitadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B16", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B17", "SELECT [RolId] AS InvitadoRolId FROM [Roles] WHERE [RolId] = @InvitadoRolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B17,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
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
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
