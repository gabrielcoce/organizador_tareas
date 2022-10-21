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
   public class participantes : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A9TableroId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A18ParticipanteTableroId = (short)(NumberUtil.Val( GetPar( "ParticipanteTableroId"), "."));
            AssignAttri("", false, "A18ParticipanteTableroId", StringUtil.LTrimStr( (decimal)(A18ParticipanteTableroId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A18ParticipanteTableroId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A39ParticipanteRolId = (short)(NumberUtil.Val( GetPar( "ParticipanteRolId"), "."));
            AssignAttri("", false, "A39ParticipanteRolId", StringUtil.LTrimStr( (decimal)(A39ParticipanteRolId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A39ParticipanteRolId) ;
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
            Form.Meta.addItem("description", "Participantes", 0) ;
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

      public participantes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public participantes( IGxContext context )
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
         chkParticipanteTableroEstado = new GXCheckbox();
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
         A42ParticipanteTableroEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A42ParticipanteTableroEstado));
         AssignAttri("", false, "A42ParticipanteTableroEstado", A42ParticipanteTableroEstado);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Participantes", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Participantes.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Participantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Participantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Participantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Participantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00b0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TABLEROID"+"'), id:'"+"TABLEROID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"PARTICIPANTETABLEROID"+"'), id:'"+"PARTICIPANTETABLEROID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Participantes.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTableroId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")), StringUtil.LTrim( ((edtTableroId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9") : context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTableroId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTableroId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Participantes.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Participantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParticipanteTableroId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParticipanteTableroId_Internalname, "Tablero Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParticipanteTableroId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A18ParticipanteTableroId), 4, 0, ",", "")), StringUtil.LTrim( ((edtParticipanteTableroId_Enabled!=0) ? context.localUtil.Format( (decimal)(A18ParticipanteTableroId), "ZZZ9") : context.localUtil.Format( (decimal)(A18ParticipanteTableroId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParticipanteTableroId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParticipanteTableroId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Participantes.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_18_Internalname, sImgUrl, imgprompt_18_Link, "", "", context.GetTheme( ), imgprompt_18_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Participantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRegistroFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRegistroFecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtRegistroFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtRegistroFecha_Internalname, context.localUtil.TToC( A20RegistroFecha, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A20RegistroFecha, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRegistroFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRegistroFecha_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Participantes.htm");
         GxWebStd.gx_bitmap( context, edtRegistroFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtRegistroFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Participantes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParticipanteRolId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParticipanteRolId_Internalname, "Rol Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParticipanteRolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A39ParticipanteRolId), 4, 0, ",", "")), StringUtil.LTrim( ((edtParticipanteRolId_Enabled!=0) ? context.localUtil.Format( (decimal)(A39ParticipanteRolId), "ZZZ9") : context.localUtil.Format( (decimal)(A39ParticipanteRolId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParticipanteRolId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParticipanteRolId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Participantes.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_39_Internalname, sImgUrl, imgprompt_39_Link, "", "", context.GetTheme( ), imgprompt_39_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Participantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkParticipanteTableroEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkParticipanteTableroEstado_Internalname, "Tablero Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkParticipanteTableroEstado_Internalname, StringUtil.BoolToStr( A42ParticipanteTableroEstado), "", "Tablero Estado", 1, chkParticipanteTableroEstado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(54, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,54);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Participantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Participantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Participantes.htm");
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
            Z18ParticipanteTableroId = (short)(context.localUtil.CToN( cgiGet( "Z18ParticipanteTableroId"), ",", "."));
            Z20RegistroFecha = context.localUtil.CToT( cgiGet( "Z20RegistroFecha"), 0);
            Z42ParticipanteTableroEstado = StringUtil.StrToBool( cgiGet( "Z42ParticipanteTableroEstado"));
            Z39ParticipanteRolId = (short)(context.localUtil.CToN( cgiGet( "Z39ParticipanteRolId"), ",", "."));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtParticipanteTableroId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParticipanteTableroId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARTICIPANTETABLEROID");
               AnyError = 1;
               GX_FocusControl = edtParticipanteTableroId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A18ParticipanteTableroId = 0;
               AssignAttri("", false, "A18ParticipanteTableroId", StringUtil.LTrimStr( (decimal)(A18ParticipanteTableroId), 4, 0));
            }
            else
            {
               A18ParticipanteTableroId = (short)(context.localUtil.CToN( cgiGet( edtParticipanteTableroId_Internalname), ",", "."));
               AssignAttri("", false, "A18ParticipanteTableroId", StringUtil.LTrimStr( (decimal)(A18ParticipanteTableroId), 4, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtRegistroFecha_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Registro Fecha"}), 1, "REGISTROFECHA");
               AnyError = 1;
               GX_FocusControl = edtRegistroFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A20RegistroFecha = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A20RegistroFecha", context.localUtil.TToC( A20RegistroFecha, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A20RegistroFecha = context.localUtil.CToT( cgiGet( edtRegistroFecha_Internalname));
               AssignAttri("", false, "A20RegistroFecha", context.localUtil.TToC( A20RegistroFecha, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtParticipanteRolId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParticipanteRolId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARTICIPANTEROLID");
               AnyError = 1;
               GX_FocusControl = edtParticipanteRolId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A39ParticipanteRolId = 0;
               AssignAttri("", false, "A39ParticipanteRolId", StringUtil.LTrimStr( (decimal)(A39ParticipanteRolId), 4, 0));
            }
            else
            {
               A39ParticipanteRolId = (short)(context.localUtil.CToN( cgiGet( edtParticipanteRolId_Internalname), ",", "."));
               AssignAttri("", false, "A39ParticipanteRolId", StringUtil.LTrimStr( (decimal)(A39ParticipanteRolId), 4, 0));
            }
            A42ParticipanteTableroEstado = StringUtil.StrToBool( cgiGet( chkParticipanteTableroEstado_Internalname));
            AssignAttri("", false, "A42ParticipanteTableroEstado", A42ParticipanteTableroEstado);
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
               A18ParticipanteTableroId = (short)(NumberUtil.Val( GetPar( "ParticipanteTableroId"), "."));
               AssignAttri("", false, "A18ParticipanteTableroId", StringUtil.LTrimStr( (decimal)(A18ParticipanteTableroId), 4, 0));
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
               InitAll0611( ) ;
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
         DisableAttributes0611( ) ;
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

      protected void ResetCaption060( )
      {
      }

      protected void ZM0611( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z20RegistroFecha = T00063_A20RegistroFecha[0];
               Z42ParticipanteTableroEstado = T00063_A42ParticipanteTableroEstado[0];
               Z39ParticipanteRolId = T00063_A39ParticipanteRolId[0];
            }
            else
            {
               Z20RegistroFecha = A20RegistroFecha;
               Z42ParticipanteTableroEstado = A42ParticipanteTableroEstado;
               Z39ParticipanteRolId = A39ParticipanteRolId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z20RegistroFecha = A20RegistroFecha;
            Z42ParticipanteTableroEstado = A42ParticipanteTableroEstado;
            Z9TableroId = A9TableroId;
            Z18ParticipanteTableroId = A18ParticipanteTableroId;
            Z39ParticipanteRolId = A39ParticipanteRolId;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TABLEROID"+"'), id:'"+"TABLEROID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_18_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PARTICIPANTETABLEROID"+"'), id:'"+"PARTICIPANTETABLEROID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_39_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PARTICIPANTEROLID"+"'), id:'"+"PARTICIPANTEROLID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load0611( )
      {
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A9TableroId, A18ParticipanteTableroId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound11 = 1;
            A20RegistroFecha = T00067_A20RegistroFecha[0];
            AssignAttri("", false, "A20RegistroFecha", context.localUtil.TToC( A20RegistroFecha, 8, 5, 0, 3, "/", ":", " "));
            A42ParticipanteTableroEstado = T00067_A42ParticipanteTableroEstado[0];
            AssignAttri("", false, "A42ParticipanteTableroEstado", A42ParticipanteTableroEstado);
            A39ParticipanteRolId = T00067_A39ParticipanteRolId[0];
            AssignAttri("", false, "A39ParticipanteRolId", StringUtil.LTrimStr( (decimal)(A39ParticipanteRolId), 4, 0));
            ZM0611( -2) ;
         }
         pr_default.close(5);
         OnLoadActions0611( ) ;
      }

      protected void OnLoadActions0611( )
      {
      }

      protected void CheckExtendedTable0611( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A18ParticipanteTableroId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Participante Tablero'.", "ForeignKeyNotFound", 1, "PARTICIPANTETABLEROID");
            AnyError = 1;
            GX_FocusControl = edtParticipanteTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A20RegistroFecha) || ( A20RegistroFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Registro Fecha fuera de rango", "OutOfRange", 1, "REGISTROFECHA");
            AnyError = 1;
            GX_FocusControl = edtRegistroFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {A39ParticipanteRolId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles Participantes'.", "ForeignKeyNotFound", 1, "PARTICIPANTEROLID");
            AnyError = 1;
            GX_FocusControl = edtParticipanteRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0611( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( short A9TableroId )
      {
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
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

      protected void gxLoad_4( short A18ParticipanteTableroId )
      {
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {A18ParticipanteTableroId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Participante Tablero'.", "ForeignKeyNotFound", 1, "PARTICIPANTETABLEROID");
            AnyError = 1;
            GX_FocusControl = edtParticipanteTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_5( short A39ParticipanteRolId )
      {
         /* Using cursor T000610 */
         pr_default.execute(8, new Object[] {A39ParticipanteRolId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles Participantes'.", "ForeignKeyNotFound", 1, "PARTICIPANTEROLID");
            AnyError = 1;
            GX_FocusControl = edtParticipanteRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0611( )
      {
         /* Using cursor T000611 */
         pr_default.execute(9, new Object[] {A9TableroId, A18ParticipanteTableroId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A9TableroId, A18ParticipanteTableroId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0611( 2) ;
            RcdFound11 = 1;
            A20RegistroFecha = T00063_A20RegistroFecha[0];
            AssignAttri("", false, "A20RegistroFecha", context.localUtil.TToC( A20RegistroFecha, 8, 5, 0, 3, "/", ":", " "));
            A42ParticipanteTableroEstado = T00063_A42ParticipanteTableroEstado[0];
            AssignAttri("", false, "A42ParticipanteTableroEstado", A42ParticipanteTableroEstado);
            A9TableroId = T00063_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A18ParticipanteTableroId = T00063_A18ParticipanteTableroId[0];
            AssignAttri("", false, "A18ParticipanteTableroId", StringUtil.LTrimStr( (decimal)(A18ParticipanteTableroId), 4, 0));
            A39ParticipanteRolId = T00063_A39ParticipanteRolId[0];
            AssignAttri("", false, "A39ParticipanteRolId", StringUtil.LTrimStr( (decimal)(A39ParticipanteRolId), 4, 0));
            Z9TableroId = A9TableroId;
            Z18ParticipanteTableroId = A18ParticipanteTableroId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0611( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0611( ) ;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0611( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0611( ) ;
         if ( RcdFound11 == 0 )
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
         RcdFound11 = 0;
         /* Using cursor T000612 */
         pr_default.execute(10, new Object[] {A9TableroId, A18ParticipanteTableroId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000612_A9TableroId[0] < A9TableroId ) || ( T000612_A9TableroId[0] == A9TableroId ) && ( T000612_A18ParticipanteTableroId[0] < A18ParticipanteTableroId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000612_A9TableroId[0] > A9TableroId ) || ( T000612_A9TableroId[0] == A9TableroId ) && ( T000612_A18ParticipanteTableroId[0] > A18ParticipanteTableroId ) ) )
            {
               A9TableroId = T000612_A9TableroId[0];
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               A18ParticipanteTableroId = T000612_A18ParticipanteTableroId[0];
               AssignAttri("", false, "A18ParticipanteTableroId", StringUtil.LTrimStr( (decimal)(A18ParticipanteTableroId), 4, 0));
               RcdFound11 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound11 = 0;
         /* Using cursor T000613 */
         pr_default.execute(11, new Object[] {A9TableroId, A18ParticipanteTableroId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000613_A9TableroId[0] > A9TableroId ) || ( T000613_A9TableroId[0] == A9TableroId ) && ( T000613_A18ParticipanteTableroId[0] > A18ParticipanteTableroId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000613_A9TableroId[0] < A9TableroId ) || ( T000613_A9TableroId[0] == A9TableroId ) && ( T000613_A18ParticipanteTableroId[0] < A18ParticipanteTableroId ) ) )
            {
               A9TableroId = T000613_A9TableroId[0];
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               A18ParticipanteTableroId = T000613_A18ParticipanteTableroId[0];
               AssignAttri("", false, "A18ParticipanteTableroId", StringUtil.LTrimStr( (decimal)(A18ParticipanteTableroId), 4, 0));
               RcdFound11 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0611( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0611( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A18ParticipanteTableroId != Z18ParticipanteTableroId ) )
               {
                  A9TableroId = Z9TableroId;
                  AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
                  A18ParticipanteTableroId = Z18ParticipanteTableroId;
                  AssignAttri("", false, "A18ParticipanteTableroId", StringUtil.LTrimStr( (decimal)(A18ParticipanteTableroId), 4, 0));
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
                  Update0611( ) ;
                  GX_FocusControl = edtTableroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A18ParticipanteTableroId != Z18ParticipanteTableroId ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTableroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0611( ) ;
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
                     Insert0611( ) ;
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
         if ( ( A9TableroId != Z9TableroId ) || ( A18ParticipanteTableroId != Z18ParticipanteTableroId ) )
         {
            A9TableroId = Z9TableroId;
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A18ParticipanteTableroId = Z18ParticipanteTableroId;
            AssignAttri("", false, "A18ParticipanteTableroId", StringUtil.LTrimStr( (decimal)(A18ParticipanteTableroId), 4, 0));
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtRegistroFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0611( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRegistroFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0611( ) ;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRegistroFecha_Internalname;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRegistroFecha_Internalname;
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
         ScanStart0611( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound11 != 0 )
            {
               ScanNext0611( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRegistroFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0611( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0611( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A9TableroId, A18ParticipanteTableroId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Participantes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z20RegistroFecha != T00062_A20RegistroFecha[0] ) || ( Z42ParticipanteTableroEstado != T00062_A42ParticipanteTableroEstado[0] ) || ( Z39ParticipanteRolId != T00062_A39ParticipanteRolId[0] ) )
            {
               if ( Z20RegistroFecha != T00062_A20RegistroFecha[0] )
               {
                  GXUtil.WriteLog("participantes:[seudo value changed for attri]"+"RegistroFecha");
                  GXUtil.WriteLogRaw("Old: ",Z20RegistroFecha);
                  GXUtil.WriteLogRaw("Current: ",T00062_A20RegistroFecha[0]);
               }
               if ( Z42ParticipanteTableroEstado != T00062_A42ParticipanteTableroEstado[0] )
               {
                  GXUtil.WriteLog("participantes:[seudo value changed for attri]"+"ParticipanteTableroEstado");
                  GXUtil.WriteLogRaw("Old: ",Z42ParticipanteTableroEstado);
                  GXUtil.WriteLogRaw("Current: ",T00062_A42ParticipanteTableroEstado[0]);
               }
               if ( Z39ParticipanteRolId != T00062_A39ParticipanteRolId[0] )
               {
                  GXUtil.WriteLog("participantes:[seudo value changed for attri]"+"ParticipanteRolId");
                  GXUtil.WriteLogRaw("Old: ",Z39ParticipanteRolId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A39ParticipanteRolId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Participantes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0611( )
      {
         BeforeValidate0611( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0611( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0611( 0) ;
            CheckOptimisticConcurrency0611( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0611( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0611( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000614 */
                     pr_default.execute(12, new Object[] {A20RegistroFecha, A42ParticipanteTableroEstado, A9TableroId, A18ParticipanteTableroId, A39ParticipanteRolId});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("Participantes");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ResetCaption060( ) ;
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
               Load0611( ) ;
            }
            EndLevel0611( ) ;
         }
         CloseExtendedTableCursors0611( ) ;
      }

      protected void Update0611( )
      {
         BeforeValidate0611( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0611( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0611( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0611( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0611( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000615 */
                     pr_default.execute(13, new Object[] {A20RegistroFecha, A42ParticipanteTableroEstado, A39ParticipanteRolId, A9TableroId, A18ParticipanteTableroId});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("Participantes");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Participantes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0611( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption060( ) ;
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
            EndLevel0611( ) ;
         }
         CloseExtendedTableCursors0611( ) ;
      }

      protected void DeferredUpdate0611( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0611( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0611( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0611( ) ;
            AfterConfirm0611( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0611( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000616 */
                  pr_default.execute(14, new Object[] {A9TableroId, A18ParticipanteTableroId});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("Participantes");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound11 == 0 )
                        {
                           InitAll0611( ) ;
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
                        ResetCaption060( ) ;
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0611( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0611( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0611( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0611( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("participantes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("participantes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0611( )
      {
         /* Using cursor T000617 */
         pr_default.execute(15);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound11 = 1;
            A9TableroId = T000617_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A18ParticipanteTableroId = T000617_A18ParticipanteTableroId[0];
            AssignAttri("", false, "A18ParticipanteTableroId", StringUtil.LTrimStr( (decimal)(A18ParticipanteTableroId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0611( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound11 = 1;
            A9TableroId = T000617_A9TableroId[0];
            AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
            A18ParticipanteTableroId = T000617_A18ParticipanteTableroId[0];
            AssignAttri("", false, "A18ParticipanteTableroId", StringUtil.LTrimStr( (decimal)(A18ParticipanteTableroId), 4, 0));
         }
      }

      protected void ScanEnd0611( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0611( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0611( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0611( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0611( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0611( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0611( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0611( )
      {
         edtTableroId_Enabled = 0;
         AssignProp("", false, edtTableroId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTableroId_Enabled), 5, 0), true);
         edtParticipanteTableroId_Enabled = 0;
         AssignProp("", false, edtParticipanteTableroId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParticipanteTableroId_Enabled), 5, 0), true);
         edtRegistroFecha_Enabled = 0;
         AssignProp("", false, edtRegistroFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegistroFecha_Enabled), 5, 0), true);
         edtParticipanteRolId_Enabled = 0;
         AssignProp("", false, edtParticipanteRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParticipanteRolId_Enabled), 5, 0), true);
         chkParticipanteTableroEstado.Enabled = 0;
         AssignProp("", false, chkParticipanteTableroEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkParticipanteTableroEstado.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0611( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("participantes.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z18ParticipanteTableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18ParticipanteTableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z20RegistroFecha", context.localUtil.TToC( Z20RegistroFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z42ParticipanteTableroEstado", Z42ParticipanteTableroEstado);
         GxWebStd.gx_hidden_field( context, "Z39ParticipanteRolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z39ParticipanteRolId), 4, 0, ",", "")));
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
         return formatLink("participantes.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Participantes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Participantes" ;
      }

      protected void InitializeNonKey0611( )
      {
         A20RegistroFecha = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A20RegistroFecha", context.localUtil.TToC( A20RegistroFecha, 8, 5, 0, 3, "/", ":", " "));
         A39ParticipanteRolId = 0;
         AssignAttri("", false, "A39ParticipanteRolId", StringUtil.LTrimStr( (decimal)(A39ParticipanteRolId), 4, 0));
         A42ParticipanteTableroEstado = false;
         AssignAttri("", false, "A42ParticipanteTableroEstado", A42ParticipanteTableroEstado);
         Z20RegistroFecha = (DateTime)(DateTime.MinValue);
         Z42ParticipanteTableroEstado = false;
         Z39ParticipanteRolId = 0;
      }

      protected void InitAll0611( )
      {
         A9TableroId = 0;
         AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
         A18ParticipanteTableroId = 0;
         AssignAttri("", false, "A18ParticipanteTableroId", StringUtil.LTrimStr( (decimal)(A18ParticipanteTableroId), 4, 0));
         InitializeNonKey0611( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022101612475673", true, true);
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
         context.AddJavascriptSource("participantes.js", "?2022101612475673", false, true);
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
         edtParticipanteTableroId_Internalname = "PARTICIPANTETABLEROID";
         edtRegistroFecha_Internalname = "REGISTROFECHA";
         edtParticipanteRolId_Internalname = "PARTICIPANTEROLID";
         chkParticipanteTableroEstado_Internalname = "PARTICIPANTETABLEROESTADO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_9_Internalname = "PROMPT_9";
         imgprompt_18_Internalname = "PROMPT_18";
         imgprompt_39_Internalname = "PROMPT_39";
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
         Form.Caption = "Participantes";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkParticipanteTableroEstado.Enabled = 1;
         imgprompt_39_Visible = 1;
         imgprompt_39_Link = "";
         edtParticipanteRolId_Jsonclick = "";
         edtParticipanteRolId_Enabled = 1;
         edtRegistroFecha_Jsonclick = "";
         edtRegistroFecha_Enabled = 1;
         imgprompt_18_Visible = 1;
         imgprompt_18_Link = "";
         edtParticipanteTableroId_Jsonclick = "";
         edtParticipanteTableroId_Enabled = 1;
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
         chkParticipanteTableroEstado.Name = "PARTICIPANTETABLEROESTADO";
         chkParticipanteTableroEstado.WebTags = "";
         chkParticipanteTableroEstado.Caption = "";
         AssignProp("", false, chkParticipanteTableroEstado_Internalname, "TitleCaption", chkParticipanteTableroEstado.Caption, true);
         chkParticipanteTableroEstado.CheckedValue = "false";
         A42ParticipanteTableroEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A42ParticipanteTableroEstado));
         AssignAttri("", false, "A42ParticipanteTableroEstado", A42ParticipanteTableroEstado);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T000618 */
         pr_default.execute(16, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
            GX_FocusControl = edtTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         /* Using cursor T000619 */
         pr_default.execute(17, new Object[] {A18ParticipanteTableroId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Participante Tablero'.", "ForeignKeyNotFound", 1, "PARTICIPANTETABLEROID");
            AnyError = 1;
            GX_FocusControl = edtParticipanteTableroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(17);
         GX_FocusControl = edtRegistroFecha_Internalname;
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
         /* Using cursor T000618 */
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

      public void Valid_Participantetableroid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000619 */
         pr_default.execute(17, new Object[] {A18ParticipanteTableroId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Participante Tablero'.", "ForeignKeyNotFound", 1, "PARTICIPANTETABLEROID");
            AnyError = 1;
            GX_FocusControl = edtParticipanteTableroId_Internalname;
         }
         pr_default.close(17);
         dynload_actions( ) ;
         A42ParticipanteTableroEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A42ParticipanteTableroEstado));
         /*  Sending validation outputs */
         AssignAttri("", false, "A20RegistroFecha", context.localUtil.TToC( A20RegistroFecha, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A39ParticipanteRolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A39ParticipanteRolId), 4, 0, ".", "")));
         AssignAttri("", false, "A42ParticipanteTableroEstado", A42ParticipanteTableroEstado);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z9TableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9TableroId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z18ParticipanteTableroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18ParticipanteTableroId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z20RegistroFecha", context.localUtil.TToC( Z20RegistroFecha, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z39ParticipanteRolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z39ParticipanteRolId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z42ParticipanteTableroEstado", StringUtil.BoolToStr( Z42ParticipanteTableroEstado));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Participanterolid( )
      {
         /* Using cursor T000620 */
         pr_default.execute(18, new Object[] {A39ParticipanteRolId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles Participantes'.", "ForeignKeyNotFound", 1, "PARTICIPANTEROLID");
            AnyError = 1;
            GX_FocusControl = edtParticipanteRolId_Internalname;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A42ParticipanteTableroEstado',fld:'PARTICIPANTETABLEROESTADO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A42ParticipanteTableroEstado',fld:'PARTICIPANTETABLEROESTADO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A42ParticipanteTableroEstado',fld:'PARTICIPANTETABLEROESTADO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A42ParticipanteTableroEstado',fld:'PARTICIPANTETABLEROESTADO',pic:''}]}");
         setEventMetadata("VALID_TABLEROID","{handler:'Valid_Tableroid',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A42ParticipanteTableroEstado',fld:'PARTICIPANTETABLEROESTADO',pic:''}]");
         setEventMetadata("VALID_TABLEROID",",oparms:[{av:'A42ParticipanteTableroEstado',fld:'PARTICIPANTETABLEROESTADO',pic:''}]}");
         setEventMetadata("VALID_PARTICIPANTETABLEROID","{handler:'Valid_Participantetableroid',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A42ParticipanteTableroEstado',fld:'PARTICIPANTETABLEROESTADO',pic:''}]");
         setEventMetadata("VALID_PARTICIPANTETABLEROID",",oparms:[{av:'A20RegistroFecha',fld:'REGISTROFECHA',pic:'99/99/99 99:99'},{av:'A39ParticipanteRolId',fld:'PARTICIPANTEROLID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z9TableroId'},{av:'Z18ParticipanteTableroId'},{av:'Z20RegistroFecha'},{av:'Z39ParticipanteRolId'},{av:'Z42ParticipanteTableroEstado'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A42ParticipanteTableroEstado',fld:'PARTICIPANTETABLEROESTADO',pic:''}]}");
         setEventMetadata("VALID_REGISTROFECHA","{handler:'Valid_Registrofecha',iparms:[{av:'A42ParticipanteTableroEstado',fld:'PARTICIPANTETABLEROESTADO',pic:''}]");
         setEventMetadata("VALID_REGISTROFECHA",",oparms:[{av:'A42ParticipanteTableroEstado',fld:'PARTICIPANTETABLEROESTADO',pic:''}]}");
         setEventMetadata("VALID_PARTICIPANTEROLID","{handler:'Valid_Participanterolid',iparms:[{av:'A39ParticipanteRolId',fld:'PARTICIPANTEROLID',pic:'ZZZ9'},{av:'A42ParticipanteTableroEstado',fld:'PARTICIPANTETABLEROESTADO',pic:''}]");
         setEventMetadata("VALID_PARTICIPANTEROLID",",oparms:[{av:'A42ParticipanteTableroEstado',fld:'PARTICIPANTETABLEROESTADO',pic:''}]}");
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
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z20RegistroFecha = (DateTime)(DateTime.MinValue);
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
         A20RegistroFecha = (DateTime)(DateTime.MinValue);
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
         T00067_A20RegistroFecha = new DateTime[] {DateTime.MinValue} ;
         T00067_A42ParticipanteTableroEstado = new bool[] {false} ;
         T00067_A9TableroId = new short[1] ;
         T00067_A18ParticipanteTableroId = new short[1] ;
         T00067_A39ParticipanteRolId = new short[1] ;
         T00064_A9TableroId = new short[1] ;
         T00065_A18ParticipanteTableroId = new short[1] ;
         T00066_A39ParticipanteRolId = new short[1] ;
         T00068_A9TableroId = new short[1] ;
         T00069_A18ParticipanteTableroId = new short[1] ;
         T000610_A39ParticipanteRolId = new short[1] ;
         T000611_A9TableroId = new short[1] ;
         T000611_A18ParticipanteTableroId = new short[1] ;
         T00063_A20RegistroFecha = new DateTime[] {DateTime.MinValue} ;
         T00063_A42ParticipanteTableroEstado = new bool[] {false} ;
         T00063_A9TableroId = new short[1] ;
         T00063_A18ParticipanteTableroId = new short[1] ;
         T00063_A39ParticipanteRolId = new short[1] ;
         sMode11 = "";
         T000612_A9TableroId = new short[1] ;
         T000612_A18ParticipanteTableroId = new short[1] ;
         T000613_A9TableroId = new short[1] ;
         T000613_A18ParticipanteTableroId = new short[1] ;
         T00062_A20RegistroFecha = new DateTime[] {DateTime.MinValue} ;
         T00062_A42ParticipanteTableroEstado = new bool[] {false} ;
         T00062_A9TableroId = new short[1] ;
         T00062_A18ParticipanteTableroId = new short[1] ;
         T00062_A39ParticipanteRolId = new short[1] ;
         T000617_A9TableroId = new short[1] ;
         T000617_A18ParticipanteTableroId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000618_A9TableroId = new short[1] ;
         T000619_A18ParticipanteTableroId = new short[1] ;
         ZZ20RegistroFecha = (DateTime)(DateTime.MinValue);
         T000620_A39ParticipanteRolId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.participantes__default(),
            new Object[][] {
                new Object[] {
               T00062_A20RegistroFecha, T00062_A42ParticipanteTableroEstado, T00062_A9TableroId, T00062_A18ParticipanteTableroId, T00062_A39ParticipanteRolId
               }
               , new Object[] {
               T00063_A20RegistroFecha, T00063_A42ParticipanteTableroEstado, T00063_A9TableroId, T00063_A18ParticipanteTableroId, T00063_A39ParticipanteRolId
               }
               , new Object[] {
               T00064_A9TableroId
               }
               , new Object[] {
               T00065_A18ParticipanteTableroId
               }
               , new Object[] {
               T00066_A39ParticipanteRolId
               }
               , new Object[] {
               T00067_A20RegistroFecha, T00067_A42ParticipanteTableroEstado, T00067_A9TableroId, T00067_A18ParticipanteTableroId, T00067_A39ParticipanteRolId
               }
               , new Object[] {
               T00068_A9TableroId
               }
               , new Object[] {
               T00069_A18ParticipanteTableroId
               }
               , new Object[] {
               T000610_A39ParticipanteRolId
               }
               , new Object[] {
               T000611_A9TableroId, T000611_A18ParticipanteTableroId
               }
               , new Object[] {
               T000612_A9TableroId, T000612_A18ParticipanteTableroId
               }
               , new Object[] {
               T000613_A9TableroId, T000613_A18ParticipanteTableroId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000617_A9TableroId, T000617_A18ParticipanteTableroId
               }
               , new Object[] {
               T000618_A9TableroId
               }
               , new Object[] {
               T000619_A18ParticipanteTableroId
               }
               , new Object[] {
               T000620_A39ParticipanteRolId
               }
            }
         );
      }

      private short Z9TableroId ;
      private short Z18ParticipanteTableroId ;
      private short Z39ParticipanteRolId ;
      private short GxWebError ;
      private short A9TableroId ;
      private short A18ParticipanteTableroId ;
      private short A39ParticipanteRolId ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short RcdFound11 ;
      private short nIsDirty_11 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ9TableroId ;
      private short ZZ18ParticipanteTableroId ;
      private short ZZ39ParticipanteRolId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTableroId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtParticipanteTableroId_Enabled ;
      private int imgprompt_18_Visible ;
      private int edtRegistroFecha_Enabled ;
      private int edtParticipanteRolId_Enabled ;
      private int imgprompt_39_Visible ;
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
      private string edtParticipanteTableroId_Internalname ;
      private string edtParticipanteTableroId_Jsonclick ;
      private string imgprompt_18_Internalname ;
      private string imgprompt_18_Link ;
      private string edtRegistroFecha_Internalname ;
      private string edtRegistroFecha_Jsonclick ;
      private string edtParticipanteRolId_Internalname ;
      private string edtParticipanteRolId_Jsonclick ;
      private string imgprompt_39_Internalname ;
      private string imgprompt_39_Link ;
      private string chkParticipanteTableroEstado_Internalname ;
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
      private string sMode11 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z20RegistroFecha ;
      private DateTime A20RegistroFecha ;
      private DateTime ZZ20RegistroFecha ;
      private bool Z42ParticipanteTableroEstado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A42ParticipanteTableroEstado ;
      private bool ZZ42ParticipanteTableroEstado ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkParticipanteTableroEstado ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T00067_A20RegistroFecha ;
      private bool[] T00067_A42ParticipanteTableroEstado ;
      private short[] T00067_A9TableroId ;
      private short[] T00067_A18ParticipanteTableroId ;
      private short[] T00067_A39ParticipanteRolId ;
      private short[] T00064_A9TableroId ;
      private short[] T00065_A18ParticipanteTableroId ;
      private short[] T00066_A39ParticipanteRolId ;
      private short[] T00068_A9TableroId ;
      private short[] T00069_A18ParticipanteTableroId ;
      private short[] T000610_A39ParticipanteRolId ;
      private short[] T000611_A9TableroId ;
      private short[] T000611_A18ParticipanteTableroId ;
      private DateTime[] T00063_A20RegistroFecha ;
      private bool[] T00063_A42ParticipanteTableroEstado ;
      private short[] T00063_A9TableroId ;
      private short[] T00063_A18ParticipanteTableroId ;
      private short[] T00063_A39ParticipanteRolId ;
      private short[] T000612_A9TableroId ;
      private short[] T000612_A18ParticipanteTableroId ;
      private short[] T000613_A9TableroId ;
      private short[] T000613_A18ParticipanteTableroId ;
      private DateTime[] T00062_A20RegistroFecha ;
      private bool[] T00062_A42ParticipanteTableroEstado ;
      private short[] T00062_A9TableroId ;
      private short[] T00062_A18ParticipanteTableroId ;
      private short[] T00062_A39ParticipanteRolId ;
      private short[] T000617_A9TableroId ;
      private short[] T000617_A18ParticipanteTableroId ;
      private short[] T000618_A9TableroId ;
      private short[] T000619_A18ParticipanteTableroId ;
      private short[] T000620_A39ParticipanteRolId ;
      private GXWebForm Form ;
   }

   public class participantes__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
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
          Object[] prmT00067;
          prmT00067 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmT00064;
          prmT00064 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT00065;
          prmT00065 = new Object[] {
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmT00066;
          prmT00066 = new Object[] {
          new ParDef("@ParticipanteRolId",GXType.Int16,4,0)
          };
          Object[] prmT00068;
          prmT00068 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT00069;
          prmT00069 = new Object[] {
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmT000610;
          prmT000610 = new Object[] {
          new ParDef("@ParticipanteRolId",GXType.Int16,4,0)
          };
          Object[] prmT000611;
          prmT000611 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmT00063;
          prmT00063 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmT000612;
          prmT000612 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmT000613;
          prmT000613 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmT00062;
          prmT00062 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmT000614;
          prmT000614 = new Object[] {
          new ParDef("@RegistroFecha",GXType.DateTime,8,5) ,
          new ParDef("@ParticipanteTableroEstado",GXType.Boolean,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteRolId",GXType.Int16,4,0)
          };
          Object[] prmT000615;
          prmT000615 = new Object[] {
          new ParDef("@RegistroFecha",GXType.DateTime,8,5) ,
          new ParDef("@ParticipanteTableroEstado",GXType.Boolean,4,0) ,
          new ParDef("@ParticipanteRolId",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmT000616;
          prmT000616 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmT000617;
          prmT000617 = new Object[] {
          };
          Object[] prmT000618;
          prmT000618 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmT000619;
          prmT000619 = new Object[] {
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmT000620;
          prmT000620 = new Object[] {
          new ParDef("@ParticipanteRolId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00062", "SELECT [RegistroFecha], [ParticipanteTableroEstado], [TableroId], [ParticipanteTableroId] AS ParticipanteTableroId, [ParticipanteRolId] AS ParticipanteRolId FROM [Participantes] WITH (UPDLOCK) WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00063", "SELECT [RegistroFecha], [ParticipanteTableroEstado], [TableroId], [ParticipanteTableroId] AS ParticipanteTableroId, [ParticipanteRolId] AS ParticipanteRolId FROM [Participantes] WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00064", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00065", "SELECT [UsuarioId] AS ParticipanteTableroId FROM [Usuarios] WHERE [UsuarioId] = @ParticipanteTableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00066", "SELECT [RolId] AS ParticipanteRolId FROM [Roles] WHERE [RolId] = @ParticipanteRolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00067", "SELECT TM1.[RegistroFecha], TM1.[ParticipanteTableroEstado], TM1.[TableroId], TM1.[ParticipanteTableroId] AS ParticipanteTableroId, TM1.[ParticipanteRolId] AS ParticipanteRolId FROM [Participantes] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[ParticipanteTableroId] = @ParticipanteTableroId ORDER BY TM1.[TableroId], TM1.[ParticipanteTableroId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00068", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00069", "SELECT [UsuarioId] AS ParticipanteTableroId FROM [Usuarios] WHERE [UsuarioId] = @ParticipanteTableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000610", "SELECT [RolId] AS ParticipanteRolId FROM [Roles] WHERE [RolId] = @ParticipanteRolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000611", "SELECT [TableroId], [ParticipanteTableroId] AS ParticipanteTableroId FROM [Participantes] WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000612", "SELECT TOP 1 [TableroId], [ParticipanteTableroId] AS ParticipanteTableroId FROM [Participantes] WHERE ( [TableroId] > @TableroId or [TableroId] = @TableroId and [ParticipanteTableroId] > @ParticipanteTableroId) ORDER BY [TableroId], [ParticipanteTableroId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000612,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000613", "SELECT TOP 1 [TableroId], [ParticipanteTableroId] AS ParticipanteTableroId FROM [Participantes] WHERE ( [TableroId] < @TableroId or [TableroId] = @TableroId and [ParticipanteTableroId] < @ParticipanteTableroId) ORDER BY [TableroId] DESC, [ParticipanteTableroId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000614", "INSERT INTO [Participantes]([RegistroFecha], [ParticipanteTableroEstado], [TableroId], [ParticipanteTableroId], [ParticipanteRolId]) VALUES(@RegistroFecha, @ParticipanteTableroEstado, @TableroId, @ParticipanteTableroId, @ParticipanteRolId)", GxErrorMask.GX_NOMASK,prmT000614)
             ,new CursorDef("T000615", "UPDATE [Participantes] SET [RegistroFecha]=@RegistroFecha, [ParticipanteTableroEstado]=@ParticipanteTableroEstado, [ParticipanteRolId]=@ParticipanteRolId  WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId", GxErrorMask.GX_NOMASK,prmT000615)
             ,new CursorDef("T000616", "DELETE FROM [Participantes]  WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId", GxErrorMask.GX_NOMASK,prmT000616)
             ,new CursorDef("T000617", "SELECT [TableroId], [ParticipanteTableroId] AS ParticipanteTableroId FROM [Participantes] ORDER BY [TableroId], [ParticipanteTableroId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000617,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000618", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000618,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000619", "SELECT [UsuarioId] AS ParticipanteTableroId FROM [Usuarios] WHERE [UsuarioId] = @ParticipanteTableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000619,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000620", "SELECT [RolId] AS ParticipanteRolId FROM [Roles] WHERE [RolId] = @ParticipanteRolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000620,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
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
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
