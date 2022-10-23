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
   public class anadircolaboradores : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public anadircolaboradores( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public anadircolaboradores( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId )
      {
         this.A9TableroId = aP0_TableroId;
         executePrivate();
         aP0_TableroId=this.A9TableroId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynParticipanteRolId = new GXCombobox();
         dynInvitadoRolId = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "TableroId");
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
               gxfirstwebparm = GetFirstPar( "TableroId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TableroId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridparticipantes") == 0 )
            {
               gxnrGridparticipantes_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridparticipantes") == 0 )
            {
               gxgrGridparticipantes_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridinvitados") == 0 )
            {
               gxnrGridinvitados_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridinvitados") == 0 )
            {
               gxgrGridinvitados_refresh_invoke( ) ;
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
               A9TableroId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
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

      protected void gxnrGridparticipantes_newrow_invoke( )
      {
         nRC_GXsfl_18 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_18"), "."));
         nGXsfl_18_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_18_idx"), "."));
         sGXsfl_18_idx = GetPar( "sGXsfl_18_idx");
         edtRegistroFecha_Horizontalalignment = GetNextPar( );
         AssignProp("", false, edtRegistroFecha_Internalname, "Horizontalalignment", edtRegistroFecha_Horizontalalignment, !bGXsfl_18_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridparticipantes_newrow( ) ;
         /* End function gxnrGridparticipantes_newrow_invoke */
      }

      protected void gxgrGridparticipantes_refresh_invoke( )
      {
         A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
         edtRegistroFecha_Horizontalalignment = GetNextPar( );
         AssignProp("", false, edtRegistroFecha_Internalname, "Horizontalalignment", edtRegistroFecha_Horizontalalignment, !bGXsfl_18_Refreshing);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV32Usuarios3);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridparticipantes_refresh( A9TableroId, AV32Usuarios3) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridparticipantes_refresh_invoke */
      }

      protected void gxnrGridinvitados_newrow_invoke( )
      {
         nRC_GXsfl_33 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_33"), "."));
         nGXsfl_33_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_33_idx"), "."));
         sGXsfl_33_idx = GetPar( "sGXsfl_33_idx");
         edtRegistroInvitadoFecha_Horizontalalignment = GetNextPar( );
         AssignProp("", false, edtRegistroInvitadoFecha_Internalname, "Horizontalalignment", edtRegistroInvitadoFecha_Horizontalalignment, !bGXsfl_33_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridinvitados_newrow( ) ;
         /* End function gxnrGridinvitados_newrow_invoke */
      }

      protected void gxgrGridinvitados_refresh_invoke( )
      {
         A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
         edtRegistroInvitadoFecha_Horizontalalignment = GetNextPar( );
         AssignProp("", false, edtRegistroInvitadoFecha_Internalname, "Horizontalalignment", edtRegistroInvitadoFecha_Horizontalalignment, !bGXsfl_33_Refreshing);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV32Usuarios3);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridinvitados_refresh( A9TableroId, AV32Usuarios3) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridinvitados_refresh_invoke */
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("masterpage", "GeneXus.Programs.masterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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
         PA0Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0Q2( ) ;
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
         context.AddJavascriptSource("RAMP/sweetAlert/js/sweetalert2.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/jquery-3.5.1.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/popper.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/bootstrap.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/RAMP_AddOns_SweetAlertRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("anadircolaboradores.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0))}, new string[] {"TableroId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOS3", GetSecureSignedToken( "", AV32Usuarios3, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_18", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_18), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_33", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_33), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIOS3", AV32Usuarios3);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIOS3", AV32Usuarios3);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOS3", GetSecureSignedToken( "", AV32Usuarios3, context));
         GxWebStd.gx_hidden_field( context, "USUARIOEMAIL", A6UsuarioEmail);
         GxWebStd.gx_hidden_field( context, "USUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3UsuarioId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11TableroId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_SA", AV34sdt_sa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_SA", AV34sdt_sa);
         }
         GxWebStd.gx_hidden_field( context, "REGISTROFECHA_Horizontalalignment", StringUtil.RTrim( edtRegistroFecha_Horizontalalignment));
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
            WE0Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0Q2( ) ;
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
         return formatLink("anadircolaboradores.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0))}, new string[] {"TableroId"})  ;
      }

      public override string GetPgmname( )
      {
         return "AnadirColaboradores" ;
      }

      public override string GetPgmdesc( )
      {
         return "Anadir Colaboradores" ;
      }

      protected void WB0Q0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuarioemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarioemail_Internalname, "Correo electrónico", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'" + sGXsfl_18_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarioemail_Internalname, AV8UsuarioEmail, StringUtil.RTrim( context.localUtil.Format( AV8UsuarioEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,8);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarioemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuarioemail_Enabled, 0, "text", "", 100, "%", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_AnadirColaboradores.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-1", "left", "Middle", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "37af6e8e-5105-40d2-94ea-61da60f7a7ab", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 30, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"EENTER."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AnadirColaboradores.htm");
            GxWebStd.gx_div_end( context, "left", "Middle", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Participantes", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AnadirColaboradores.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridparticipantesContainer.SetWrapped(nGXWrapped);
            StartGridControl18( ) ;
         }
         if ( wbEnd == 18 )
         {
            wbEnd = 0;
            nRC_GXsfl_18 = (int)(nGXsfl_18_idx-1);
            if ( GridparticipantesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridparticipantesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridparticipantes", GridparticipantesContainer, subGridparticipantes_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridparticipantesContainerData", GridparticipantesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridparticipantesContainerData"+"V", GridparticipantesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridparticipantesContainerData"+"V"+"\" value='"+GridparticipantesContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Invitados a colaborar", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AnadirColaboradores.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridinvitadosContainer.SetWrapped(nGXWrapped);
            StartGridControl33( ) ;
         }
         if ( wbEnd == 33 )
         {
            wbEnd = 0;
            nRC_GXsfl_33 = (int)(nGXsfl_33_idx-1);
            if ( GridinvitadosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridinvitadosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridinvitados", GridinvitadosContainer, subGridinvitados_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridinvitadosContainerData", GridinvitadosContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridinvitadosContainerData"+"V", GridinvitadosContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridinvitadosContainerData"+"V"+"\" value='"+GridinvitadosContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Right", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttEnviarinvitaciones_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(18), 2, 0)+","+"null"+");", "Enviar invitaciones", bttEnviarinvitaciones_Jsonclick, 5, "Enviar invitaciones", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'ENVIAR INVITACIONES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AnadirColaboradores.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(18), 2, 0)+","+"null"+");", "Cancelar", bttCancelar_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AnadirColaboradores.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucRamp_addons_sweetalert1.Render(context, "ramp_addons_sweetalert", Ramp_addons_sweetalert1_Internalname, "RAMP_ADDONS_SWEETALERT1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 18 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridparticipantesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridparticipantesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridparticipantes", GridparticipantesContainer, subGridparticipantes_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridparticipantesContainerData", GridparticipantesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridparticipantesContainerData"+"V", GridparticipantesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridparticipantesContainerData"+"V"+"\" value='"+GridparticipantesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 33 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridinvitadosContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridinvitadosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridinvitados", GridinvitadosContainer, subGridinvitados_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridinvitadosContainerData", GridinvitadosContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridinvitadosContainerData"+"V", GridinvitadosContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridinvitadosContainerData"+"V"+"\" value='"+GridinvitadosContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0Q2( )
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
            Form.Meta.addItem("description", "Anadir Colaboradores", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0Q0( ) ;
      }

      protected void WS0Q2( )
      {
         START0Q2( ) ;
         EVT0Q2( ) ;
      }

      protected void EVT0Q2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Cancelar' */
                              E110Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ENVIAR INVITACIONES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRIDPARTICIPANTES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "'ROL'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "'ROL'") == 0 ) )
                           {
                              nGXsfl_18_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
                              SubsflControlProps_182( ) ;
                              AV28quitar2 = cgiGet( edtavQuitar2_Internalname);
                              AssignProp("", false, edtavQuitar2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV28quitar2)) ? AV43Quitar2_GXI : context.convertURL( context.PathToRelativeUrl( AV28quitar2))), !bGXsfl_18_Refreshing);
                              AssignProp("", false, edtavQuitar2_Internalname, "SrcSet", context.GetImageSrcSet( AV28quitar2), true);
                              A9TableroId = (short)(context.localUtil.CToN( cgiGet( edtTableroId_Internalname), ",", "."));
                              A18ParticipanteTableroId = (short)(context.localUtil.CToN( cgiGet( edtParticipanteTableroId_Internalname), ",", "."));
                              A20RegistroFecha = context.localUtil.CToT( cgiGet( edtRegistroFecha_Internalname), 0);
                              AV26nombreParticipante = cgiGet( edtavNombreparticipante_Internalname);
                              AssignAttri("", false, edtavNombreparticipante_Internalname, AV26nombreParticipante);
                              dynParticipanteRolId.Name = dynParticipanteRolId_Internalname;
                              dynParticipanteRolId.CurrentValue = cgiGet( dynParticipanteRolId_Internalname);
                              A39ParticipanteRolId = (short)(NumberUtil.Val( cgiGet( dynParticipanteRolId_Internalname), "."));
                              AV38cambiarRol = cgiGet( edtavCambiarrol_Internalname);
                              AssignProp("", false, edtavCambiarrol_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV38cambiarRol)) ? AV44Cambiarrol_GXI : context.convertURL( context.PathToRelativeUrl( AV38cambiarRol))), !bGXsfl_18_Refreshing);
                              AssignProp("", false, edtavCambiarrol_Internalname, "SrcSet", context.GetImageSrcSet( AV38cambiarRol), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E120Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDPARTICIPANTES.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E130Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E140Q2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'ROL'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Rol' */
                                    E150Q2 ();
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "GRIDINVITADOS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'ELIMINAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'ELIMINAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'ACEPTAR'") == 0 ) )
                           {
                              nGXsfl_33_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
                              SubsflControlProps_333( ) ;
                              AV22quitar = cgiGet( edtavQuitar_Internalname);
                              AssignProp("", false, edtavQuitar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV22quitar)) ? AV47Quitar_GXI : context.convertURL( context.PathToRelativeUrl( AV22quitar))), !bGXsfl_33_Refreshing);
                              AssignProp("", false, edtavQuitar_Internalname, "SrcSet", context.GetImageSrcSet( AV22quitar), true);
                              A9TableroId = (short)(context.localUtil.CToN( cgiGet( edtTableroId_Internalname), ",", "."));
                              A40RegistroInvitadoId = (short)(context.localUtil.CToN( cgiGet( edtRegistroInvitadoId_Internalname), ",", "."));
                              A45RegistroInvitadoFecha = context.localUtil.CToT( cgiGet( edtRegistroInvitadoFecha_Internalname), 0);
                              A43RegistroInvitadoUsuario = (short)(context.localUtil.CToN( cgiGet( edtRegistroInvitadoUsuario_Internalname), ",", "."));
                              AV5nombre = cgiGet( edtavNombre_Internalname);
                              AssignAttri("", false, edtavNombre_Internalname, AV5nombre);
                              dynInvitadoRolId.Name = dynInvitadoRolId_Internalname;
                              dynInvitadoRolId.CurrentValue = cgiGet( dynInvitadoRolId_Internalname);
                              A41InvitadoRolId = (short)(NumberUtil.Val( cgiGet( dynInvitadoRolId_Internalname), "."));
                              AV37aceptar = cgiGet( edtavAceptar_Internalname);
                              AssignProp("", false, edtavAceptar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV37aceptar)) ? AV45Aceptar_GXI : context.convertURL( context.PathToRelativeUrl( AV37aceptar))), !bGXsfl_33_Refreshing);
                              AssignProp("", false, edtavAceptar_Internalname, "SrcSet", context.GetImageSrcSet( AV37aceptar), true);
                              AV35tieneusuario = cgiGet( edtavTieneusuario_Internalname);
                              AssignProp("", false, edtavTieneusuario_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV35tieneusuario)) ? AV46Tieneusuario_GXI : context.convertURL( context.PathToRelativeUrl( AV35tieneusuario))), !bGXsfl_33_Refreshing);
                              AssignProp("", false, edtavTieneusuario_Internalname, "SrcSet", context.GetImageSrcSet( AV35tieneusuario), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDINVITADOS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E160Q3 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'ELIMINAR'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Eliminar' */
                                    E170Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'ACEPTAR'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
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

      protected void WE0Q2( )
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

      protected void PA0Q2( )
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavUsuarioemail_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridparticipantes_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_182( ) ;
         while ( nGXsfl_18_idx <= nRC_GXsfl_18 )
         {
            sendrow_182( ) ;
            nGXsfl_18_idx = ((subGridparticipantes_Islastpage==1)&&(nGXsfl_18_idx+1>subGridparticipantes_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1);
            sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
            SubsflControlProps_182( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridparticipantesContainer)) ;
         /* End function gxnrGridparticipantes_newrow */
      }

      protected void gxnrGridinvitados_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_333( ) ;
         while ( nGXsfl_33_idx <= nRC_GXsfl_33 )
         {
            sendrow_333( ) ;
            nGXsfl_33_idx = ((subGridinvitados_Islastpage==1)&&(nGXsfl_33_idx+1>subGridinvitados_fnc_Recordsperpage( )) ? 1 : nGXsfl_33_idx+1);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
            SubsflControlProps_333( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridinvitadosContainer)) ;
         /* End function gxnrGridinvitados_newrow */
      }

      protected void gxgrGridparticipantes_refresh( short A9TableroId ,
                                                    SdtUsuarios AV32Usuarios3 )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDPARTICIPANTES_nCurrentRecord = 0;
         RF0Q2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridparticipantes_refresh */
      }

      protected void gxgrGridinvitados_refresh( short A9TableroId ,
                                                SdtUsuarios AV32Usuarios3 )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDINVITADOS_nCurrentRecord = 0;
         RF0Q3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridinvitados_refresh */
      }

      protected void send_integrity_hashes( )
      {
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
         RF0Q2( ) ;
         RF0Q3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavNombre_Enabled = 0;
         AssignProp("", false, edtavNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNombre_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtavNombreparticipante_Enabled = 0;
         AssignProp("", false, edtavNombreparticipante_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNombreparticipante_Enabled), 5, 0), !bGXsfl_18_Refreshing);
      }

      protected void RF0Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridparticipantesContainer.ClearRows();
         }
         wbStart = 18;
         nGXsfl_18_idx = 1;
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
         SubsflControlProps_182( ) ;
         bGXsfl_18_Refreshing = true;
         GridparticipantesContainer.AddObjectProperty("GridName", "Gridparticipantes");
         GridparticipantesContainer.AddObjectProperty("CmpContext", "");
         GridparticipantesContainer.AddObjectProperty("InMasterPage", "false");
         GridparticipantesContainer.AddObjectProperty("Class", "WorkWith");
         GridparticipantesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridparticipantesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridparticipantesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridparticipantes_Backcolorstyle), 1, 0, ".", "")));
         GridparticipantesContainer.PageSize = subGridparticipantes_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_182( ) ;
            /* Using cursor H000Q2 */
            pr_default.execute(0, new Object[] {A9TableroId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A39ParticipanteRolId = H000Q2_A39ParticipanteRolId[0];
               A20RegistroFecha = H000Q2_A20RegistroFecha[0];
               A18ParticipanteTableroId = H000Q2_A18ParticipanteTableroId[0];
               E130Q2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 18;
            WB0Q0( ) ;
         }
         bGXsfl_18_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Q2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIOS3", AV32Usuarios3);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIOS3", AV32Usuarios3);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOS3", GetSecureSignedToken( "", AV32Usuarios3, context));
      }

      protected void RF0Q3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridinvitadosContainer.ClearRows();
         }
         wbStart = 33;
         nGXsfl_33_idx = 1;
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_333( ) ;
         bGXsfl_33_Refreshing = true;
         GridinvitadosContainer.AddObjectProperty("GridName", "Gridinvitados");
         GridinvitadosContainer.AddObjectProperty("CmpContext", "");
         GridinvitadosContainer.AddObjectProperty("InMasterPage", "false");
         GridinvitadosContainer.AddObjectProperty("Class", "WorkWith");
         GridinvitadosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridinvitadosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridinvitadosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvitados_Backcolorstyle), 1, 0, ".", "")));
         GridinvitadosContainer.PageSize = subGridinvitados_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_333( ) ;
            /* Using cursor H000Q3 */
            pr_default.execute(1, new Object[] {A9TableroId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A41InvitadoRolId = H000Q3_A41InvitadoRolId[0];
               A43RegistroInvitadoUsuario = H000Q3_A43RegistroInvitadoUsuario[0];
               A45RegistroInvitadoFecha = H000Q3_A45RegistroInvitadoFecha[0];
               A40RegistroInvitadoId = H000Q3_A40RegistroInvitadoId[0];
               E160Q3 ();
               pr_default.readNext(1);
            }
            pr_default.close(1);
            wbEnd = 33;
            WB0Q0( ) ;
         }
         bGXsfl_33_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Q3( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_REGISTROINVITADOID"+"_"+sGXsfl_33_idx, GetSecureSignedToken( sGXsfl_33_idx, context.localUtil.Format( (decimal)(A40RegistroInvitadoId), "ZZZ9"), context));
      }

      protected int subGridparticipantes_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridparticipantes_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridparticipantes_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridparticipantes_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridinvitados_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridinvitados_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridinvitados_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridinvitados_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavNombre_Enabled = 0;
         AssignProp("", false, edtavNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNombre_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtavNombreparticipante_Enabled = 0;
         AssignProp("", false, edtavNombreparticipante_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNombreparticipante_Enabled), 5, 0), !bGXsfl_18_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_18 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_18"), ",", "."));
            nRC_GXsfl_33 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_33"), ",", "."));
            /* Read variables values. */
            AV8UsuarioEmail = cgiGet( edtavUsuarioemail_Internalname);
            AssignAttri("", false, "AV8UsuarioEmail", AV8UsuarioEmail);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E120Q2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV11TableroId = A9TableroId;
         AssignAttri("", false, "AV11TableroId", StringUtil.LTrimStr( (decimal)(AV11TableroId), 4, 0));
         AV17eliminar = context.GetImagePath( "6223fef3-3dcc-4cb5-990c-8733d6fa82e5", "", context.GetTheme( ));
         AV42Eliminar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6223fef3-3dcc-4cb5-990c-8733d6fa82e5", "", context.GetTheme( )));
         AV30Tableros.Load(A9TableroId);
         AV32Usuarios3.Load(AV30Tableros.gxTpr_Propietarioid);
         AV33propietario = AV32Usuarios3.gxTpr_Usuarioid;
         edtRegistroFecha_Horizontalalignment = "Left";
         AssignProp("", false, edtRegistroFecha_Internalname, "Horizontalalignment", edtRegistroFecha_Horizontalalignment, !bGXsfl_18_Refreshing);
         edtRegistroInvitadoFecha_Horizontalalignment = "Left";
         AssignProp("", false, edtRegistroInvitadoFecha_Internalname, "Horizontalalignment", edtRegistroInvitadoFecha_Horizontalalignment, !bGXsfl_33_Refreshing);
      }

      private void E130Q2( )
      {
         /* Gridparticipantes_Load Routine */
         returnInSub = false;
         edtRegistroFecha_Horizontalalignment = "Left";
         if ( A39ParticipanteRolId != 1 )
         {
            AV28quitar2 = context.GetImagePath( "6223fef3-3dcc-4cb5-990c-8733d6fa82e5", "", context.GetTheme( ));
            AssignAttri("", false, edtavQuitar2_Internalname, AV28quitar2);
            AV43Quitar2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6223fef3-3dcc-4cb5-990c-8733d6fa82e5", "", context.GetTheme( )));
            edtavQuitar2_Visible = 1;
            edtavQuitar2_Tooltiptext = "Eliminar participante";
            edtavCambiarrol_Visible = 1;
            edtavCambiarrol_Tooltiptext = "Cambiar rol";
            AV38cambiarRol = context.GetImagePath( "9738280c-8d46-4f74-84bc-af064c0dbc8f", "", context.GetTheme( ));
            AssignAttri("", false, edtavCambiarrol_Internalname, AV38cambiarRol);
            AV44Cambiarrol_GXI = GXDbFile.PathToUrl( context.GetImagePath( "9738280c-8d46-4f74-84bc-af064c0dbc8f", "", context.GetTheme( )));
         }
         else
         {
            edtavQuitar2_Visible = 0;
            edtavCambiarrol_Visible = 0;
         }
         AV27Participantes.Load(A9TableroId, A18ParticipanteTableroId);
         AV18Usuarios.Load(AV27Participantes.gxTpr_Participantetableroid);
         AV26nombreParticipante = AV18Usuarios.gxTpr_Usuarioemail + " - " + AV18Usuarios.gxTpr_Usuarionombre + " " + AV18Usuarios.gxTpr_Usuarioapellido;
         AssignAttri("", false, edtavNombreparticipante_Internalname, AV26nombreParticipante);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 18;
         }
         sendrow_182( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_18_Refreshing )
         {
            context.DoAjaxLoad(18, GridparticipantesRow);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E140Q2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E140Q2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV8UsuarioEmail, AV32Usuarios3.gxTpr_Usuarioemail) != 0 )
         {
            AV19ok = false;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8UsuarioEmail)) )
            {
               /* Using cursor H000Q4 */
               pr_default.execute(2, new Object[] {AV8UsuarioEmail});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A6UsuarioEmail = H000Q4_A6UsuarioEmail[0];
                  A3UsuarioId = H000Q4_A3UsuarioId[0];
                  AV19ok = true;
                  AV7UsuarioId = A3UsuarioId;
                  AV29Usuarios2.Load(AV7UsuarioId);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               if ( AV19ok )
               {
                  GXt_int1 = AV31IdInvitado;
                  new getinvitadosid(context ).execute( ref  AV11TableroId, ref  GXt_int1) ;
                  AssignAttri("", false, "AV11TableroId", StringUtil.LTrimStr( (decimal)(AV11TableroId), 4, 0));
                  AV31IdInvitado = GXt_int1;
                  AV25Invitados = new SdtInvitados(context);
                  AV25Invitados.gxTpr_Tableroid = AV11TableroId;
                  AV25Invitados.gxTpr_Registroinvitadoid = AV31IdInvitado;
                  AV25Invitados.gxTpr_Registroinvitadousuario = AV29Usuarios2.gxTpr_Usuarioid;
                  AV25Invitados.gxTpr_Registroinvitadoemail = AV29Usuarios2.gxTpr_Usuarioemail;
                  AV25Invitados.gxTpr_Invitadorolid = 3;
                  AV25Invitados.gxTpr_Registroinvitadofecha = DateTimeUtil.ServerNow( context, pr_default);
                  AV25Invitados.Insert();
                  if ( AV25Invitados.Success() )
                  {
                     context.CommitDataStores("anadircolaboradores",pr_default);
                     CallWebObject(formatLink("anadircolaboradores.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11TableroId,4,0))}, new string[] {"TableroId"}) );
                     context.wjLocDisableFrm = 1;
                  }
                  else
                  {
                     context.RollbackDataStores("anadircolaboradores",pr_default);
                  }
               }
               else
               {
                  GXt_int1 = AV31IdInvitado;
                  new getinvitadosid(context ).execute( ref  AV11TableroId, ref  GXt_int1) ;
                  AssignAttri("", false, "AV11TableroId", StringUtil.LTrimStr( (decimal)(AV11TableroId), 4, 0));
                  AV31IdInvitado = GXt_int1;
                  AV25Invitados = new SdtInvitados(context);
                  AV25Invitados.gxTpr_Tableroid = AV11TableroId;
                  AV25Invitados.gxTpr_Registroinvitadoid = AV31IdInvitado;
                  AV25Invitados.gxTpr_Registroinvitadousuario = 0;
                  AV25Invitados.gxTpr_Registroinvitadoemail = AV8UsuarioEmail;
                  AV25Invitados.gxTpr_Invitadorolid = 3;
                  AV25Invitados.gxTpr_Registroinvitadofecha = DateTimeUtil.ServerNow( context, pr_default);
                  AV25Invitados.Insert();
                  if ( AV25Invitados.Success() )
                  {
                     new correoprueba(context ).execute( ref  A9TableroId, ref  AV8UsuarioEmail) ;
                     AssignAttri("", false, "AV8UsuarioEmail", AV8UsuarioEmail);
                     context.CommitDataStores("anadircolaboradores",pr_default);
                     CallWebObject(formatLink("anadircolaboradores.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11TableroId,4,0))}, new string[] {"TableroId"}) );
                     context.wjLocDisableFrm = 1;
                  }
                  else
                  {
                     AV34sdt_sa.gxTpr_Title = "Ha ocurrido un error";
                     AV34sdt_sa.gxTpr_Html = "Ha ocurrido un error, por favor inténtelo nuevamente"+AV25Invitados.GetMessages().ToJSonString(false)+StringUtil.Str( (decimal)(AV11TableroId), 4, 0)+StringUtil.Str( (decimal)(AV31IdInvitado), 4, 0);
                     AV34sdt_sa.gxTpr_Timer = 4000;
                     AV34sdt_sa.gxTpr_Allowoutsideclick = true;
                     AV34sdt_sa.gxTpr_Type = "error";
                     this.executeUsercontrolMethod("", false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV34sdt_sa});
                     context.RollbackDataStores("anadircolaboradores",pr_default);
                  }
               }
            }
            else
            {
               AV34sdt_sa.gxTpr_Title = "Ha ocurrido un error";
               AV34sdt_sa.gxTpr_Html = "Debe indicar un correo electrónico válido";
               AV34sdt_sa.gxTpr_Timer = 4000;
               AV34sdt_sa.gxTpr_Allowoutsideclick = true;
               AV34sdt_sa.gxTpr_Type = "error";
               this.executeUsercontrolMethod("", false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV34sdt_sa});
            }
         }
         else
         {
            AV34sdt_sa.gxTpr_Title = "Ha ocurrido un error";
            AV34sdt_sa.gxTpr_Html = "No se puede agregar al propietario como participante";
            AV34sdt_sa.gxTpr_Timer = 4000;
            AV34sdt_sa.gxTpr_Allowoutsideclick = true;
            AV34sdt_sa.gxTpr_Type = "error";
            this.executeUsercontrolMethod("", false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV34sdt_sa});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34sdt_sa", AV34sdt_sa);
      }

      protected void E110Q2( )
      {
         /* 'Cancelar' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {(short)A9TableroId});
         context.setWebReturnParmsMetadata(new Object[] {"A9TableroId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E170Q2( )
      {
         /* 'Eliminar' Routine */
         returnInSub = false;
         AV36Invitados2.Load(AV11TableroId, A40RegistroInvitadoId);
         AV36Invitados2.Delete();
         if ( AV36Invitados2.Success() )
         {
            context.CommitDataStores("anadircolaboradores",pr_default);
            AV34sdt_sa.gxTpr_Title = "Invitación eliminada con éxito";
            AV34sdt_sa.gxTpr_Html = "Se ha eliminado a este usuario del listado";
            AV34sdt_sa.gxTpr_Timer = 4000;
            AV34sdt_sa.gxTpr_Allowoutsideclick = true;
            AV34sdt_sa.gxTpr_Type = "success";
            this.executeUsercontrolMethod("", false, "RAMP_ADDONS_SWEETALERT1Container", "msgSW", "", new Object[] {(SdtSDT_SweetAlert)AV34sdt_sa});
         }
         else
         {
            context.RollbackDataStores("anadircolaboradores",pr_default);
         }
         CallWebObject(formatLink("anadircolaboradores.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11TableroId,4,0))}, new string[] {"TableroId"}) );
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34sdt_sa", AV34sdt_sa);
      }

      protected void E150Q2( )
      {
         /* 'Rol' Routine */
         returnInSub = false;
         if ( A39ParticipanteRolId != 1 )
         {
            new intercalarrol(context ).execute( ref  AV11TableroId, ref  A18ParticipanteTableroId, ref  A39ParticipanteRolId) ;
            AssignAttri("", false, "AV11TableroId", StringUtil.LTrimStr( (decimal)(AV11TableroId), 4, 0));
            CallWebObject(formatLink("anadircolaboradores.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11TableroId,4,0))}, new string[] {"TableroId"}) );
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
         dynParticipanteRolId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A39ParticipanteRolId), 4, 0));
         AssignProp("", false, dynParticipanteRolId_Internalname, "Values", dynParticipanteRolId.ToJavascriptSource(), true);
      }

      private void E160Q3( )
      {
         /* Gridinvitados_Load Routine */
         returnInSub = false;
         edtRegistroInvitadoFecha_Horizontalalignment = "Left";
         AV37aceptar = context.GetImagePath( "4e6805a8-014d-4daf-b1ba-9825ad2ba516", "", context.GetTheme( ));
         AssignAttri("", false, edtavAceptar_Internalname, AV37aceptar);
         AV45Aceptar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "4e6805a8-014d-4daf-b1ba-9825ad2ba516", "", context.GetTheme( )));
         if ( A43RegistroInvitadoUsuario == 0 )
         {
            AV35tieneusuario = context.GetImagePath( "2d02171d-e0f4-445c-801a-868f0e6beed0", "", context.GetTheme( ));
            AssignAttri("", false, edtavTieneusuario_Internalname, AV35tieneusuario);
            AV46Tieneusuario_GXI = GXDbFile.PathToUrl( context.GetImagePath( "2d02171d-e0f4-445c-801a-868f0e6beed0", "", context.GetTheme( )));
            edtavTieneusuario_Tooltiptext = "No está registrado en el sistema";
         }
         else
         {
            AV35tieneusuario = context.GetImagePath( "fa82323c-c2ab-4e81-b0e0-1a08fd39275d", "", context.GetTheme( ));
            AssignAttri("", false, edtavTieneusuario_Internalname, AV35tieneusuario);
            AV46Tieneusuario_GXI = GXDbFile.PathToUrl( context.GetImagePath( "fa82323c-c2ab-4e81-b0e0-1a08fd39275d", "", context.GetTheme( )));
            edtavTieneusuario_Tooltiptext = "Posee cuenta activa en el sistema";
         }
         AV22quitar = context.GetImagePath( "6223fef3-3dcc-4cb5-990c-8733d6fa82e5", "", context.GetTheme( ));
         AssignAttri("", false, edtavQuitar_Internalname, AV22quitar);
         AV47Quitar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6223fef3-3dcc-4cb5-990c-8733d6fa82e5", "", context.GetTheme( )));
         AV25Invitados.Load(A9TableroId, A40RegistroInvitadoId);
         AV5nombre = AV25Invitados.gxTpr_Registroinvitadoemail + " - " + "Aún no ha aceptado invitación a colaborar";
         AssignAttri("", false, edtavNombre_Internalname, AV5nombre);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 33;
         }
         sendrow_333( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_33_Refreshing )
         {
            context.DoAjaxLoad(33, GridinvitadosRow);
         }
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A9TableroId = Convert.ToInt16(getParm(obj,0));
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
         PA0Q2( ) ;
         WS0Q2( ) ;
         WE0Q2( ) ;
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
         AddStyleSheetFile("RAMP/sweetAlert/css/sweetalert2.min.css", "");
         AddStyleSheetFile("RAMP/shared/css/font-awesome.min.css", "");
         AddStyleSheetFile("RAMP/shared/css/bootstrap.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022102211441323", true, true);
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
         context.AddJavascriptSource("anadircolaboradores.js", "?2022102211441323", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/js/sweetalert2.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/jquery-3.5.1.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/popper.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/bootstrap.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/RAMP_AddOns_SweetAlertRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_182( )
      {
         edtavQuitar2_Internalname = "vQUITAR2_"+sGXsfl_18_idx;
         edtTableroId_Internalname = "TABLEROID_"+sGXsfl_18_idx;
         edtParticipanteTableroId_Internalname = "PARTICIPANTETABLEROID_"+sGXsfl_18_idx;
         edtRegistroFecha_Internalname = "REGISTROFECHA_"+sGXsfl_18_idx;
         edtavNombreparticipante_Internalname = "vNOMBREPARTICIPANTE_"+sGXsfl_18_idx;
         dynParticipanteRolId_Internalname = "PARTICIPANTEROLID_"+sGXsfl_18_idx;
         edtavCambiarrol_Internalname = "vCAMBIARROL_"+sGXsfl_18_idx;
      }

      protected void SubsflControlProps_fel_182( )
      {
         edtavQuitar2_Internalname = "vQUITAR2_"+sGXsfl_18_fel_idx;
         edtTableroId_Internalname = "TABLEROID_"+sGXsfl_18_fel_idx;
         edtParticipanteTableroId_Internalname = "PARTICIPANTETABLEROID_"+sGXsfl_18_fel_idx;
         edtRegistroFecha_Internalname = "REGISTROFECHA_"+sGXsfl_18_fel_idx;
         edtavNombreparticipante_Internalname = "vNOMBREPARTICIPANTE_"+sGXsfl_18_fel_idx;
         dynParticipanteRolId_Internalname = "PARTICIPANTEROLID_"+sGXsfl_18_fel_idx;
         edtavCambiarrol_Internalname = "vCAMBIARROL_"+sGXsfl_18_fel_idx;
      }

      protected void sendrow_182( )
      {
         SubsflControlProps_182( ) ;
         WB0Q0( ) ;
         GridparticipantesRow = GXWebRow.GetNew(context,GridparticipantesContainer);
         if ( subGridparticipantes_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridparticipantes_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridparticipantes_Class, "") != 0 )
            {
               subGridparticipantes_Linesclass = subGridparticipantes_Class+"Odd";
            }
         }
         else if ( subGridparticipantes_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridparticipantes_Backstyle = 0;
            subGridparticipantes_Backcolor = subGridparticipantes_Allbackcolor;
            if ( StringUtil.StrCmp(subGridparticipantes_Class, "") != 0 )
            {
               subGridparticipantes_Linesclass = subGridparticipantes_Class+"Uniform";
            }
         }
         else if ( subGridparticipantes_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridparticipantes_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridparticipantes_Class, "") != 0 )
            {
               subGridparticipantes_Linesclass = subGridparticipantes_Class+"Odd";
            }
            subGridparticipantes_Backcolor = (int)(0x0);
         }
         else if ( subGridparticipantes_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridparticipantes_Backstyle = 1;
            if ( ((int)((nGXsfl_18_idx) % (2))) == 0 )
            {
               subGridparticipantes_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridparticipantes_Class, "") != 0 )
               {
                  subGridparticipantes_Linesclass = subGridparticipantes_Class+"Even";
               }
            }
            else
            {
               subGridparticipantes_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridparticipantes_Class, "") != 0 )
               {
                  subGridparticipantes_Linesclass = subGridparticipantes_Class+"Odd";
               }
            }
         }
         if ( GridparticipantesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_18_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridparticipantesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavQuitar2_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "Image";
         StyleString = "";
         AV28quitar2_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV28quitar2))&&String.IsNullOrEmpty(StringUtil.RTrim( AV43Quitar2_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV28quitar2)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV28quitar2)) ? AV43Quitar2_GXI : context.PathToRelativeUrl( AV28quitar2));
         GridparticipantesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavQuitar2_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavQuitar2_Visible,(short)0,(string)"",(string)edtavQuitar2_Tooltiptext,(short)0,(short)1,(short)30,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV28quitar2_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridparticipantesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridparticipantesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTableroId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTableroId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)18,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridparticipantesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridparticipantesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteTableroId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A18ParticipanteTableroId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A18ParticipanteTableroId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParticipanteTableroId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)5,(string)"%",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)18,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridparticipantesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+edtRegistroFecha_Horizontalalignment+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridparticipantesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRegistroFecha_Internalname,context.localUtil.TToC( A20RegistroFecha, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A20RegistroFecha, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRegistroFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)10,(string)"%",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)18,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)edtRegistroFecha_Horizontalalignment,(bool)false,(string)""});
         /* Subfile cell */
         if ( GridparticipantesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridparticipantesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNombreparticipante_Internalname,StringUtil.RTrim( AV26nombreParticipante),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNombreparticipante_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavNombreparticipante_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"%",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)18,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridparticipantesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         if ( ( dynParticipanteRolId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "PARTICIPANTEROLID_" + sGXsfl_18_idx;
            dynParticipanteRolId.Name = GXCCtl;
            dynParticipanteRolId.WebTags = "";
            dynParticipanteRolId.removeAllItems();
            /* Using cursor H000Q5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               dynParticipanteRolId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000Q5_A1RolId[0]), 4, 0)), H000Q5_A2RolNombre[0], 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( dynParticipanteRolId.ItemCount > 0 )
            {
               A39ParticipanteRolId = (short)(NumberUtil.Val( dynParticipanteRolId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A39ParticipanteRolId), 4, 0))), "."));
            }
         }
         /* ComboBox */
         GridparticipantesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynParticipanteRolId,(string)dynParticipanteRolId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A39ParticipanteRolId), 4, 0)),(short)1,(string)dynParticipanteRolId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",(string)"",(string)"",(bool)true,(short)1});
         dynParticipanteRolId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A39ParticipanteRolId), 4, 0));
         AssignProp("", false, dynParticipanteRolId_Internalname, "Values", (string)(dynParticipanteRolId.ToJavascriptSource()), !bGXsfl_18_Refreshing);
         /* Subfile cell */
         if ( GridparticipantesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavCambiarrol_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavCambiarrol_Enabled!=0)&&(edtavCambiarrol_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 25,'',false,'',18)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV38cambiarRol_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV38cambiarRol))&&String.IsNullOrEmpty(StringUtil.RTrim( AV44Cambiarrol_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV38cambiarRol)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV38cambiarRol)) ? AV44Cambiarrol_GXI : context.PathToRelativeUrl( AV38cambiarRol));
         GridparticipantesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavCambiarrol_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavCambiarrol_Visible,(short)1,(string)"",(string)edtavCambiarrol_Tooltiptext,(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)5,(string)edtavCambiarrol_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'ROL\\'."+sGXsfl_18_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV38cambiarRol_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes0Q2( ) ;
         GridparticipantesContainer.AddRow(GridparticipantesRow);
         nGXsfl_18_idx = ((subGridparticipantes_Islastpage==1)&&(nGXsfl_18_idx+1>subGridparticipantes_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1);
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
         SubsflControlProps_182( ) ;
         /* End function sendrow_182 */
      }

      protected void SubsflControlProps_333( )
      {
         edtavQuitar_Internalname = "vQUITAR_"+sGXsfl_33_idx;
         edtTableroId_Internalname = "TABLEROID_"+sGXsfl_18_idx;
         edtRegistroInvitadoId_Internalname = "REGISTROINVITADOID_"+sGXsfl_33_idx;
         edtRegistroInvitadoFecha_Internalname = "REGISTROINVITADOFECHA_"+sGXsfl_33_idx;
         edtRegistroInvitadoUsuario_Internalname = "REGISTROINVITADOUSUARIO_"+sGXsfl_33_idx;
         edtavNombre_Internalname = "vNOMBRE_"+sGXsfl_33_idx;
         dynInvitadoRolId_Internalname = "INVITADOROLID_"+sGXsfl_33_idx;
         edtavAceptar_Internalname = "vACEPTAR_"+sGXsfl_33_idx;
         edtavTieneusuario_Internalname = "vTIENEUSUARIO_"+sGXsfl_33_idx;
      }

      protected void SubsflControlProps_fel_333( )
      {
         edtavQuitar_Internalname = "vQUITAR_"+sGXsfl_33_fel_idx;
         edtTableroId_Internalname = "TABLEROID_"+sGXsfl_18_idx;
         edtRegistroInvitadoId_Internalname = "REGISTROINVITADOID_"+sGXsfl_33_fel_idx;
         edtRegistroInvitadoFecha_Internalname = "REGISTROINVITADOFECHA_"+sGXsfl_33_fel_idx;
         edtRegistroInvitadoUsuario_Internalname = "REGISTROINVITADOUSUARIO_"+sGXsfl_33_fel_idx;
         edtavNombre_Internalname = "vNOMBRE_"+sGXsfl_33_fel_idx;
         dynInvitadoRolId_Internalname = "INVITADOROLID_"+sGXsfl_33_fel_idx;
         edtavAceptar_Internalname = "vACEPTAR_"+sGXsfl_33_fel_idx;
         edtavTieneusuario_Internalname = "vTIENEUSUARIO_"+sGXsfl_33_fel_idx;
      }

      protected void sendrow_333( )
      {
         SubsflControlProps_333( ) ;
         WB0Q0( ) ;
         GridinvitadosRow = GXWebRow.GetNew(context,GridinvitadosContainer);
         if ( subGridinvitados_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridinvitados_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridinvitados_Class, "") != 0 )
            {
               subGridinvitados_Linesclass = subGridinvitados_Class+"Odd";
            }
         }
         else if ( subGridinvitados_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridinvitados_Backstyle = 0;
            subGridinvitados_Backcolor = subGridinvitados_Allbackcolor;
            if ( StringUtil.StrCmp(subGridinvitados_Class, "") != 0 )
            {
               subGridinvitados_Linesclass = subGridinvitados_Class+"Uniform";
            }
         }
         else if ( subGridinvitados_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridinvitados_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridinvitados_Class, "") != 0 )
            {
               subGridinvitados_Linesclass = subGridinvitados_Class+"Odd";
            }
            subGridinvitados_Backcolor = (int)(0x0);
         }
         else if ( subGridinvitados_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridinvitados_Backstyle = 1;
            if ( ((int)((nGXsfl_33_idx) % (2))) == 0 )
            {
               subGridinvitados_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridinvitados_Class, "") != 0 )
               {
                  subGridinvitados_Linesclass = subGridinvitados_Class+"Even";
               }
            }
            else
            {
               subGridinvitados_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridinvitados_Class, "") != 0 )
               {
                  subGridinvitados_Linesclass = subGridinvitados_Class+"Odd";
               }
            }
         }
         if ( GridinvitadosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_33_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridinvitadosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavQuitar_Enabled!=0)&&(edtavQuitar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 34,'',false,'',33)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV22quitar_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV22quitar))&&String.IsNullOrEmpty(StringUtil.RTrim( AV47Quitar_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV22quitar)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV22quitar)) ? AV47Quitar_GXI : context.PathToRelativeUrl( AV22quitar));
         GridinvitadosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavQuitar_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)5,(string)edtavQuitar_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'ELIMINAR\\'."+sGXsfl_33_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV22quitar_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridinvitadosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvitadosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTableroId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTableroId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)5,(string)"%",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)33,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvitadosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvitadosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRegistroInvitadoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A40RegistroInvitadoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A40RegistroInvitadoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRegistroInvitadoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)5,(string)"%",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)33,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvitadosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+edtRegistroInvitadoFecha_Horizontalalignment+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvitadosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRegistroInvitadoFecha_Internalname,context.localUtil.TToC( A45RegistroInvitadoFecha, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A45RegistroInvitadoFecha, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRegistroInvitadoFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)10,(string)"%",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)33,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)edtRegistroInvitadoFecha_Horizontalalignment,(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvitadosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvitadosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRegistroInvitadoUsuario_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A43RegistroInvitadoUsuario), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A43RegistroInvitadoUsuario), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRegistroInvitadoUsuario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)33,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvitadosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvitadosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNombre_Internalname,StringUtil.RTrim( AV5nombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavNombre_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"%",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)33,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridinvitadosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         if ( ( dynInvitadoRolId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "INVITADOROLID_" + sGXsfl_33_idx;
            dynInvitadoRolId.Name = GXCCtl;
            dynInvitadoRolId.WebTags = "";
            dynInvitadoRolId.removeAllItems();
            /* Using cursor H000Q6 */
            pr_default.execute(4);
            while ( (pr_default.getStatus(4) != 101) )
            {
               dynInvitadoRolId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000Q6_A1RolId[0]), 4, 0)), H000Q6_A2RolNombre[0], 0);
               pr_default.readNext(4);
            }
            pr_default.close(4);
            if ( dynInvitadoRolId.ItemCount > 0 )
            {
               A41InvitadoRolId = (short)(NumberUtil.Val( dynInvitadoRolId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A41InvitadoRolId), 4, 0))), "."));
            }
         }
         /* ComboBox */
         GridinvitadosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynInvitadoRolId,(string)dynInvitadoRolId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A41InvitadoRolId), 4, 0)),(short)1,(string)dynInvitadoRolId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",(string)"",(string)"",(bool)true,(short)1});
         dynInvitadoRolId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A41InvitadoRolId), 4, 0));
         AssignProp("", false, dynInvitadoRolId_Internalname, "Values", (string)(dynInvitadoRolId.ToJavascriptSource()), !bGXsfl_33_Refreshing);
         /* Subfile cell */
         if ( GridinvitadosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavAceptar_Enabled!=0)&&(edtavAceptar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 41,'',false,'',33)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV37aceptar_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV37aceptar))&&String.IsNullOrEmpty(StringUtil.RTrim( AV45Aceptar_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV37aceptar)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV37aceptar)) ? AV45Aceptar_GXI : context.PathToRelativeUrl( AV37aceptar));
         GridinvitadosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavAceptar_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)5,(string)edtavAceptar_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'ACEPTAR\\'."+sGXsfl_33_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV37aceptar_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridinvitadosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "Image";
         StyleString = "";
         AV35tieneusuario_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV35tieneusuario))&&String.IsNullOrEmpty(StringUtil.RTrim( AV46Tieneusuario_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV35tieneusuario)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV35tieneusuario)) ? AV46Tieneusuario_GXI : context.PathToRelativeUrl( AV35tieneusuario));
         GridinvitadosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavTieneusuario_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)edtavTieneusuario_Tooltiptext,(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV35tieneusuario_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes0Q3( ) ;
         GridinvitadosContainer.AddRow(GridinvitadosRow);
         nGXsfl_33_idx = ((subGridinvitados_Islastpage==1)&&(nGXsfl_33_idx+1>subGridinvitados_fnc_Recordsperpage( )) ? 1 : nGXsfl_33_idx+1);
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_333( ) ;
         /* End function sendrow_333 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "PARTICIPANTEROLID_" + sGXsfl_18_idx;
         dynParticipanteRolId.Name = GXCCtl;
         dynParticipanteRolId.WebTags = "";
         dynParticipanteRolId.removeAllItems();
         /* Using cursor H000Q7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            dynParticipanteRolId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000Q7_A1RolId[0]), 4, 0)), H000Q7_A2RolNombre[0], 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( dynParticipanteRolId.ItemCount > 0 )
         {
            A39ParticipanteRolId = (short)(NumberUtil.Val( dynParticipanteRolId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A39ParticipanteRolId), 4, 0))), "."));
         }
         GXCCtl = "INVITADOROLID_" + sGXsfl_33_idx;
         dynInvitadoRolId.Name = GXCCtl;
         dynInvitadoRolId.WebTags = "";
         dynInvitadoRolId.removeAllItems();
         /* Using cursor H000Q8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            dynInvitadoRolId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000Q8_A1RolId[0]), 4, 0)), H000Q8_A2RolNombre[0], 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         if ( dynInvitadoRolId.ItemCount > 0 )
         {
            A41InvitadoRolId = (short)(NumberUtil.Val( dynInvitadoRolId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A41InvitadoRolId), 4, 0))), "."));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl18( )
      {
         if ( GridparticipantesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridparticipantesContainer"+"DivS\" data-gxgridid=\"18\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridparticipantes_Internalname, subGridparticipantes_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridparticipantes_Backcolorstyle == 0 )
            {
               subGridparticipantes_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridparticipantes_Class) > 0 )
               {
                  subGridparticipantes_Linesclass = subGridparticipantes_Class+"Title";
               }
            }
            else
            {
               subGridparticipantes_Titlebackstyle = 1;
               if ( subGridparticipantes_Backcolorstyle == 1 )
               {
                  subGridparticipantes_Titlebackcolor = subGridparticipantes_Allbackcolor;
                  if ( StringUtil.Len( subGridparticipantes_Class) > 0 )
                  {
                     subGridparticipantes_Linesclass = subGridparticipantes_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridparticipantes_Class) > 0 )
                  {
                     subGridparticipantes_Linesclass = subGridparticipantes_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(30), 4, 0)+"px"+" class=\""+"Image"+"\" "+" style=\""+((edtavQuitar2_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Tablero Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(5), 4, 0)+"%"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+edtRegistroFecha_Horizontalalignment+"\" "+" width="+StringUtil.LTrimStr( (decimal)(10), 4, 0)+"%"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Fecha") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(60), 4, 0)+"%"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Participante") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Rol") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(30), 4, 0)+"px"+" class=\""+"Image"+"\" "+" style=\""+((edtavCambiarrol_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridparticipantesContainer.AddObjectProperty("GridName", "Gridparticipantes");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridparticipantesContainer = new GXWebGrid( context);
            }
            else
            {
               GridparticipantesContainer.Clear();
            }
            GridparticipantesContainer.SetWrapped(nGXWrapped);
            GridparticipantesContainer.AddObjectProperty("GridName", "Gridparticipantes");
            GridparticipantesContainer.AddObjectProperty("Header", subGridparticipantes_Header);
            GridparticipantesContainer.AddObjectProperty("Class", "WorkWith");
            GridparticipantesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridparticipantesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridparticipantesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridparticipantes_Backcolorstyle), 1, 0, ".", "")));
            GridparticipantesContainer.AddObjectProperty("CmpContext", "");
            GridparticipantesContainer.AddObjectProperty("InMasterPage", "false");
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesColumn.AddObjectProperty("Value", context.convertURL( AV28quitar2));
            GridparticipantesColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavQuitar2_Tooltiptext));
            GridparticipantesColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavQuitar2_Visible), 5, 0, ".", "")));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ".", "")));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18ParticipanteTableroId), 4, 0, ".", "")));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesColumn.AddObjectProperty("Value", context.localUtil.TToC( A20RegistroFecha, 10, 8, 0, 3, "/", ":", " "));
            GridparticipantesColumn.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtRegistroFecha_Horizontalalignment));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesColumn.AddObjectProperty("Value", StringUtil.RTrim( AV26nombreParticipante));
            GridparticipantesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNombreparticipante_Enabled), 5, 0, ".", "")));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A39ParticipanteRolId), 4, 0, ".", "")));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesColumn.AddObjectProperty("Value", context.convertURL( AV38cambiarRol));
            GridparticipantesColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavCambiarrol_Tooltiptext));
            GridparticipantesColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCambiarrol_Visible), 5, 0, ".", "")));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridparticipantes_Selectedindex), 4, 0, ".", "")));
            GridparticipantesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridparticipantes_Allowselection), 1, 0, ".", "")));
            GridparticipantesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridparticipantes_Selectioncolor), 9, 0, ".", "")));
            GridparticipantesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridparticipantes_Allowhovering), 1, 0, ".", "")));
            GridparticipantesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridparticipantes_Hoveringcolor), 9, 0, ".", "")));
            GridparticipantesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridparticipantes_Allowcollapsing), 1, 0, ".", "")));
            GridparticipantesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridparticipantes_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl33( )
      {
         if ( GridinvitadosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridinvitadosContainer"+"DivS\" data-gxgridid=\"33\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridinvitados_Internalname, subGridinvitados_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridinvitados_Backcolorstyle == 0 )
            {
               subGridinvitados_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridinvitados_Class) > 0 )
               {
                  subGridinvitados_Linesclass = subGridinvitados_Class+"Title";
               }
            }
            else
            {
               subGridinvitados_Titlebackstyle = 1;
               if ( subGridinvitados_Backcolorstyle == 1 )
               {
                  subGridinvitados_Titlebackcolor = subGridinvitados_Allbackcolor;
                  if ( StringUtil.Len( subGridinvitados_Class) > 0 )
                  {
                     subGridinvitados_Linesclass = subGridinvitados_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridinvitados_Class) > 0 )
                  {
                     subGridinvitados_Linesclass = subGridinvitados_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(30), 4, 0)+"px"+" class=\""+"Image"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(5), 4, 0)+"%"+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Tablero Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(5), 4, 0)+"%"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+edtRegistroInvitadoFecha_Horizontalalignment+"\" "+" width="+StringUtil.LTrimStr( (decimal)(10), 4, 0)+"%"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Fecha") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Registro Invitado Usuario") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(60), 4, 0)+"%"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Invitado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Rol") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(30), 4, 0)+"px"+" class=\""+"Image"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(30), 4, 0)+"px"+" class=\""+"Image"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridinvitadosContainer.AddObjectProperty("GridName", "Gridinvitados");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridinvitadosContainer = new GXWebGrid( context);
            }
            else
            {
               GridinvitadosContainer.Clear();
            }
            GridinvitadosContainer.SetWrapped(nGXWrapped);
            GridinvitadosContainer.AddObjectProperty("GridName", "Gridinvitados");
            GridinvitadosContainer.AddObjectProperty("Header", subGridinvitados_Header);
            GridinvitadosContainer.AddObjectProperty("Class", "WorkWith");
            GridinvitadosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridinvitadosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridinvitadosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvitados_Backcolorstyle), 1, 0, ".", "")));
            GridinvitadosContainer.AddObjectProperty("CmpContext", "");
            GridinvitadosContainer.AddObjectProperty("InMasterPage", "false");
            GridinvitadosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvitadosColumn.AddObjectProperty("Value", context.convertURL( AV22quitar));
            GridinvitadosContainer.AddColumnProperties(GridinvitadosColumn);
            GridinvitadosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvitadosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ".", "")));
            GridinvitadosContainer.AddColumnProperties(GridinvitadosColumn);
            GridinvitadosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvitadosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40RegistroInvitadoId), 4, 0, ".", "")));
            GridinvitadosContainer.AddColumnProperties(GridinvitadosColumn);
            GridinvitadosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvitadosColumn.AddObjectProperty("Value", context.localUtil.TToC( A45RegistroInvitadoFecha, 10, 8, 0, 3, "/", ":", " "));
            GridinvitadosColumn.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtRegistroInvitadoFecha_Horizontalalignment));
            GridinvitadosContainer.AddColumnProperties(GridinvitadosColumn);
            GridinvitadosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvitadosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A43RegistroInvitadoUsuario), 4, 0, ".", "")));
            GridinvitadosContainer.AddColumnProperties(GridinvitadosColumn);
            GridinvitadosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvitadosColumn.AddObjectProperty("Value", StringUtil.RTrim( AV5nombre));
            GridinvitadosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNombre_Enabled), 5, 0, ".", "")));
            GridinvitadosContainer.AddColumnProperties(GridinvitadosColumn);
            GridinvitadosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvitadosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41InvitadoRolId), 4, 0, ".", "")));
            GridinvitadosContainer.AddColumnProperties(GridinvitadosColumn);
            GridinvitadosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvitadosColumn.AddObjectProperty("Value", context.convertURL( AV37aceptar));
            GridinvitadosContainer.AddColumnProperties(GridinvitadosColumn);
            GridinvitadosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvitadosColumn.AddObjectProperty("Value", context.convertURL( AV35tieneusuario));
            GridinvitadosColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavTieneusuario_Tooltiptext));
            GridinvitadosContainer.AddColumnProperties(GridinvitadosColumn);
            GridinvitadosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvitados_Selectedindex), 4, 0, ".", "")));
            GridinvitadosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvitados_Allowselection), 1, 0, ".", "")));
            GridinvitadosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvitados_Selectioncolor), 9, 0, ".", "")));
            GridinvitadosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvitados_Allowhovering), 1, 0, ".", "")));
            GridinvitadosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvitados_Hoveringcolor), 9, 0, ".", "")));
            GridinvitadosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvitados_Allowcollapsing), 1, 0, ".", "")));
            GridinvitadosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvitados_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavUsuarioemail_Internalname = "vUSUARIOEMAIL";
         imgImage1_Internalname = "IMAGE1";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavQuitar2_Internalname = "vQUITAR2";
         edtTableroId_Internalname = "TABLEROID";
         edtParticipanteTableroId_Internalname = "PARTICIPANTETABLEROID";
         edtRegistroFecha_Internalname = "REGISTROFECHA";
         edtavNombreparticipante_Internalname = "vNOMBREPARTICIPANTE";
         dynParticipanteRolId_Internalname = "PARTICIPANTEROLID";
         edtavCambiarrol_Internalname = "vCAMBIARROL";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtavQuitar_Internalname = "vQUITAR";
         edtTableroId_Internalname = "TABLEROID";
         edtRegistroInvitadoId_Internalname = "REGISTROINVITADOID";
         edtRegistroInvitadoFecha_Internalname = "REGISTROINVITADOFECHA";
         edtRegistroInvitadoUsuario_Internalname = "REGISTROINVITADOUSUARIO";
         edtavNombre_Internalname = "vNOMBRE";
         dynInvitadoRolId_Internalname = "INVITADOROLID";
         edtavAceptar_Internalname = "vACEPTAR";
         edtavTieneusuario_Internalname = "vTIENEUSUARIO";
         bttEnviarinvitaciones_Internalname = "ENVIARINVITACIONES";
         bttCancelar_Internalname = "CANCELAR";
         Ramp_addons_sweetalert1_Internalname = "RAMP_ADDONS_SWEETALERT1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridparticipantes_Internalname = "GRIDPARTICIPANTES";
         subGridinvitados_Internalname = "GRIDINVITADOS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridinvitados_Allowcollapsing = 0;
         subGridinvitados_Allowselection = 0;
         subGridinvitados_Header = "";
         subGridparticipantes_Allowcollapsing = 0;
         subGridparticipantes_Allowselection = 0;
         subGridparticipantes_Header = "";
         edtavTieneusuario_Tooltiptext = "";
         edtavAceptar_Jsonclick = "";
         edtavAceptar_Visible = -1;
         edtavAceptar_Enabled = 1;
         dynInvitadoRolId_Jsonclick = "";
         edtavNombre_Jsonclick = "";
         edtavNombre_Enabled = 0;
         edtRegistroInvitadoUsuario_Jsonclick = "";
         edtRegistroInvitadoFecha_Jsonclick = "";
         edtRegistroInvitadoId_Jsonclick = "";
         edtavQuitar_Jsonclick = "";
         edtavQuitar_Visible = -1;
         edtavQuitar_Enabled = 1;
         subGridinvitados_Class = "WorkWith";
         subGridinvitados_Backcolorstyle = 0;
         edtavCambiarrol_Jsonclick = "";
         edtavCambiarrol_Enabled = 1;
         edtavCambiarrol_Tooltiptext = "";
         edtavCambiarrol_Visible = -1;
         dynParticipanteRolId_Jsonclick = "";
         edtavNombreparticipante_Jsonclick = "";
         edtavNombreparticipante_Enabled = 0;
         edtRegistroFecha_Jsonclick = "";
         edtParticipanteTableroId_Jsonclick = "";
         edtTableroId_Jsonclick = "";
         edtavQuitar2_Tooltiptext = "";
         edtavQuitar2_Visible = -1;
         subGridparticipantes_Class = "WorkWith";
         subGridparticipantes_Backcolorstyle = 0;
         edtavUsuarioemail_Jsonclick = "";
         edtavUsuarioemail_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Anadir Colaboradores";
         edtRegistroInvitadoFecha_Horizontalalignment = "right";
         edtRegistroFecha_Horizontalalignment = "right";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDPARTICIPANTES_nFirstRecordOnPage'},{av:'GRIDPARTICIPANTES_nEOF'},{av:'edtRegistroFecha_Horizontalalignment',ctrl:'REGISTROFECHA',prop:'Horizontalalignment'},{av:'GRIDINVITADOS_nFirstRecordOnPage'},{av:'GRIDINVITADOS_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'edtRegistroInvitadoFecha_Horizontalalignment',ctrl:'REGISTROINVITADOFECHA',prop:'Horizontalalignment'},{av:'AV32Usuarios3',fld:'vUSUARIOS3',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDPARTICIPANTES.LOAD","{handler:'E130Q2',iparms:[{av:'dynParticipanteRolId'},{av:'A39ParticipanteRolId',fld:'PARTICIPANTEROLID',pic:'ZZZ9'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'}]");
         setEventMetadata("GRIDPARTICIPANTES.LOAD",",oparms:[{av:'edtRegistroFecha_Horizontalalignment',ctrl:'REGISTROFECHA',prop:'Horizontalalignment'},{av:'AV28quitar2',fld:'vQUITAR2',pic:''},{av:'edtavQuitar2_Tooltiptext',ctrl:'vQUITAR2',prop:'Tooltiptext'},{av:'edtavCambiarrol_Tooltiptext',ctrl:'vCAMBIARROL',prop:'Tooltiptext'},{av:'AV38cambiarRol',fld:'vCAMBIARROL',pic:''},{av:'edtavQuitar2_Visible',ctrl:'vQUITAR2',prop:'Visible'},{av:'edtavCambiarrol_Visible',ctrl:'vCAMBIARROL',prop:'Visible'},{av:'AV26nombreParticipante',fld:'vNOMBREPARTICIPANTE',pic:''}]}");
         setEventMetadata("GRIDINVITADOS.LOAD","{handler:'E160Q3',iparms:[{av:'A43RegistroInvitadoUsuario',fld:'REGISTROINVITADOUSUARIO',pic:'ZZZ9'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A40RegistroInvitadoId',fld:'REGISTROINVITADOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("GRIDINVITADOS.LOAD",",oparms:[{av:'edtRegistroInvitadoFecha_Horizontalalignment',ctrl:'REGISTROINVITADOFECHA',prop:'Horizontalalignment'},{av:'AV37aceptar',fld:'vACEPTAR',pic:''},{av:'AV35tieneusuario',fld:'vTIENEUSUARIO',pic:''},{av:'edtavTieneusuario_Tooltiptext',ctrl:'vTIENEUSUARIO',prop:'Tooltiptext'},{av:'AV22quitar',fld:'vQUITAR',pic:''},{av:'AV5nombre',fld:'vNOMBRE',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E140Q2',iparms:[{av:'AV8UsuarioEmail',fld:'vUSUARIOEMAIL',pic:''},{av:'AV32Usuarios3',fld:'vUSUARIOS3',pic:'',hsh:true},{av:'A6UsuarioEmail',fld:'USUARIOEMAIL',pic:''},{av:'A3UsuarioId',fld:'USUARIOID',pic:'ZZZ9'},{av:'AV11TableroId',fld:'vTABLEROID',pic:'ZZZ9'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'AV34sdt_sa',fld:'vSDT_SA',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV11TableroId',fld:'vTABLEROID',pic:'ZZZ9'},{av:'AV8UsuarioEmail',fld:'vUSUARIOEMAIL',pic:''},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'AV34sdt_sa',fld:'vSDT_SA',pic:''}]}");
         setEventMetadata("'CANCELAR'","{handler:'E110Q2',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]");
         setEventMetadata("'CANCELAR'",",oparms:[]}");
         setEventMetadata("'ELIMINAR'","{handler:'E170Q2',iparms:[{av:'AV11TableroId',fld:'vTABLEROID',pic:'ZZZ9'},{av:'A40RegistroInvitadoId',fld:'REGISTROINVITADOID',pic:'ZZZ9',hsh:true},{av:'AV34sdt_sa',fld:'vSDT_SA',pic:''}]");
         setEventMetadata("'ELIMINAR'",",oparms:[{av:'AV34sdt_sa',fld:'vSDT_SA',pic:''},{av:'AV11TableroId',fld:'vTABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("'ROL'","{handler:'E150Q2',iparms:[{av:'dynParticipanteRolId'},{av:'A39ParticipanteRolId',fld:'PARTICIPANTEROLID',pic:'ZZZ9'},{av:'AV11TableroId',fld:'vTABLEROID',pic:'ZZZ9'},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'}]");
         setEventMetadata("'ROL'",",oparms:[{av:'dynParticipanteRolId'},{av:'A39ParticipanteRolId',fld:'PARTICIPANTEROLID',pic:'ZZZ9'},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'AV11TableroId',fld:'vTABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("VALIDV_USUARIOEMAIL","{handler:'Validv_Usuarioemail',iparms:[]");
         setEventMetadata("VALIDV_USUARIOEMAIL",",oparms:[]}");
         setEventMetadata("VALID_TABLEROID","{handler:'Valid_Tableroid',iparms:[]");
         setEventMetadata("VALID_TABLEROID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Cambiarrol',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALID_TABLEROID","{handler:'Valid_Tableroid',iparms:[]");
         setEventMetadata("VALID_TABLEROID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Tieneusuario',iparms:[]");
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
         AV32Usuarios3 = new SdtUsuarios(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         A6UsuarioEmail = "";
         AV34sdt_sa = new SdtSDT_SweetAlert(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         AV8UsuarioEmail = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         imgImage1_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         GridparticipantesContainer = new GXWebGrid( context);
         sStyleString = "";
         lblTextblock2_Jsonclick = "";
         GridinvitadosContainer = new GXWebGrid( context);
         bttEnviarinvitaciones_Jsonclick = "";
         bttCancelar_Jsonclick = "";
         ucRamp_addons_sweetalert1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV28quitar2 = "";
         AV43Quitar2_GXI = "";
         A20RegistroFecha = (DateTime)(DateTime.MinValue);
         AV26nombreParticipante = "";
         AV38cambiarRol = "";
         AV44Cambiarrol_GXI = "";
         AV22quitar = "";
         AV47Quitar_GXI = "";
         A45RegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
         AV5nombre = "";
         AV37aceptar = "";
         AV45Aceptar_GXI = "";
         AV35tieneusuario = "";
         AV46Tieneusuario_GXI = "";
         scmdbuf = "";
         H000Q2_A9TableroId = new short[1] ;
         H000Q2_A39ParticipanteRolId = new short[1] ;
         H000Q2_A20RegistroFecha = new DateTime[] {DateTime.MinValue} ;
         H000Q2_A18ParticipanteTableroId = new short[1] ;
         H000Q3_A9TableroId = new short[1] ;
         H000Q3_A41InvitadoRolId = new short[1] ;
         H000Q3_A43RegistroInvitadoUsuario = new short[1] ;
         H000Q3_A45RegistroInvitadoFecha = new DateTime[] {DateTime.MinValue} ;
         H000Q3_A40RegistroInvitadoId = new short[1] ;
         AV17eliminar = "";
         AV42Eliminar_GXI = "";
         AV30Tableros = new SdtTableros(context);
         AV27Participantes = new SdtParticipantes(context);
         AV18Usuarios = new SdtUsuarios(context);
         GridparticipantesRow = new GXWebRow();
         H000Q4_A6UsuarioEmail = new string[] {""} ;
         H000Q4_A3UsuarioId = new short[1] ;
         AV29Usuarios2 = new SdtUsuarios(context);
         AV25Invitados = new SdtInvitados(context);
         AV36Invitados2 = new SdtInvitados(context);
         GridinvitadosRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridparticipantes_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         H000Q5_A1RolId = new short[1] ;
         H000Q5_A2RolNombre = new string[] {""} ;
         subGridinvitados_Linesclass = "";
         H000Q6_A1RolId = new short[1] ;
         H000Q6_A2RolNombre = new string[] {""} ;
         H000Q7_A1RolId = new short[1] ;
         H000Q7_A2RolNombre = new string[] {""} ;
         H000Q8_A1RolId = new short[1] ;
         H000Q8_A2RolNombre = new string[] {""} ;
         GridparticipantesColumn = new GXWebColumn();
         GridinvitadosColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.anadircolaboradores__default(),
            new Object[][] {
                new Object[] {
               H000Q2_A9TableroId, H000Q2_A39ParticipanteRolId, H000Q2_A20RegistroFecha, H000Q2_A18ParticipanteTableroId
               }
               , new Object[] {
               H000Q3_A9TableroId, H000Q3_A41InvitadoRolId, H000Q3_A43RegistroInvitadoUsuario, H000Q3_A45RegistroInvitadoFecha, H000Q3_A40RegistroInvitadoId
               }
               , new Object[] {
               H000Q4_A6UsuarioEmail, H000Q4_A3UsuarioId
               }
               , new Object[] {
               H000Q5_A1RolId, H000Q5_A2RolNombre
               }
               , new Object[] {
               H000Q6_A1RolId, H000Q6_A2RolNombre
               }
               , new Object[] {
               H000Q7_A1RolId, H000Q7_A2RolNombre
               }
               , new Object[] {
               H000Q8_A1RolId, H000Q8_A2RolNombre
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavNombre_Enabled = 0;
         edtavNombreparticipante_Enabled = 0;
      }

      private short A9TableroId ;
      private short wcpOA9TableroId ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short A3UsuarioId ;
      private short AV11TableroId ;
      private short wbEnd ;
      private short wbStart ;
      private short A18ParticipanteTableroId ;
      private short A39ParticipanteRolId ;
      private short A40RegistroInvitadoId ;
      private short A43RegistroInvitadoUsuario ;
      private short A41InvitadoRolId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridparticipantes_Backcolorstyle ;
      private short subGridinvitados_Backcolorstyle ;
      private short AV33propietario ;
      private short AV7UsuarioId ;
      private short AV31IdInvitado ;
      private short GXt_int1 ;
      private short nGXWrapped ;
      private short subGridparticipantes_Backstyle ;
      private short subGridinvitados_Backstyle ;
      private short subGridparticipantes_Titlebackstyle ;
      private short subGridparticipantes_Allowselection ;
      private short subGridparticipantes_Allowhovering ;
      private short subGridparticipantes_Allowcollapsing ;
      private short subGridparticipantes_Collapsed ;
      private short subGridinvitados_Titlebackstyle ;
      private short subGridinvitados_Allowselection ;
      private short subGridinvitados_Allowhovering ;
      private short subGridinvitados_Allowcollapsing ;
      private short subGridinvitados_Collapsed ;
      private short GRIDPARTICIPANTES_nEOF ;
      private short GRIDINVITADOS_nEOF ;
      private int nRC_GXsfl_18 ;
      private int nRC_GXsfl_33 ;
      private int nGXsfl_18_idx=1 ;
      private int nGXsfl_33_idx=1 ;
      private int edtavUsuarioemail_Enabled ;
      private int subGridparticipantes_Islastpage ;
      private int subGridinvitados_Islastpage ;
      private int edtavNombre_Enabled ;
      private int edtavNombreparticipante_Enabled ;
      private int edtavQuitar2_Visible ;
      private int edtavCambiarrol_Visible ;
      private int idxLst ;
      private int subGridparticipantes_Backcolor ;
      private int subGridparticipantes_Allbackcolor ;
      private int edtavCambiarrol_Enabled ;
      private int subGridinvitados_Backcolor ;
      private int subGridinvitados_Allbackcolor ;
      private int edtavQuitar_Enabled ;
      private int edtavQuitar_Visible ;
      private int edtavAceptar_Enabled ;
      private int edtavAceptar_Visible ;
      private int subGridparticipantes_Titlebackcolor ;
      private int subGridparticipantes_Selectedindex ;
      private int subGridparticipantes_Selectioncolor ;
      private int subGridparticipantes_Hoveringcolor ;
      private int subGridinvitados_Titlebackcolor ;
      private int subGridinvitados_Selectedindex ;
      private int subGridinvitados_Selectioncolor ;
      private int subGridinvitados_Hoveringcolor ;
      private long GRIDPARTICIPANTES_nCurrentRecord ;
      private long GRIDINVITADOS_nCurrentRecord ;
      private long GRIDPARTICIPANTES_nFirstRecordOnPage ;
      private long GRIDINVITADOS_nFirstRecordOnPage ;
      private string edtRegistroFecha_Horizontalalignment ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_18_idx="0001" ;
      private string edtRegistroFecha_Internalname ;
      private string sGXsfl_33_idx="0001" ;
      private string edtRegistroInvitadoFecha_Horizontalalignment ;
      private string edtRegistroInvitadoFecha_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string edtavUsuarioemail_Internalname ;
      private string TempTags ;
      private string edtavUsuarioemail_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage1_Internalname ;
      private string imgImage1_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string sStyleString ;
      private string subGridparticipantes_Internalname ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string subGridinvitados_Internalname ;
      private string bttEnviarinvitaciones_Internalname ;
      private string bttEnviarinvitaciones_Jsonclick ;
      private string bttCancelar_Internalname ;
      private string bttCancelar_Jsonclick ;
      private string Ramp_addons_sweetalert1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavQuitar2_Internalname ;
      private string edtTableroId_Internalname ;
      private string edtParticipanteTableroId_Internalname ;
      private string AV26nombreParticipante ;
      private string edtavNombreparticipante_Internalname ;
      private string dynParticipanteRolId_Internalname ;
      private string edtavCambiarrol_Internalname ;
      private string edtavQuitar_Internalname ;
      private string edtRegistroInvitadoId_Internalname ;
      private string edtRegistroInvitadoUsuario_Internalname ;
      private string AV5nombre ;
      private string edtavNombre_Internalname ;
      private string dynInvitadoRolId_Internalname ;
      private string edtavAceptar_Internalname ;
      private string edtavTieneusuario_Internalname ;
      private string scmdbuf ;
      private string edtavQuitar2_Tooltiptext ;
      private string edtavCambiarrol_Tooltiptext ;
      private string edtavTieneusuario_Tooltiptext ;
      private string sGXsfl_18_fel_idx="0001" ;
      private string subGridparticipantes_Class ;
      private string subGridparticipantes_Linesclass ;
      private string ROClassString ;
      private string edtTableroId_Jsonclick ;
      private string edtParticipanteTableroId_Jsonclick ;
      private string edtRegistroFecha_Jsonclick ;
      private string edtavNombreparticipante_Jsonclick ;
      private string GXCCtl ;
      private string dynParticipanteRolId_Jsonclick ;
      private string edtavCambiarrol_Jsonclick ;
      private string sGXsfl_33_fel_idx="0001" ;
      private string subGridinvitados_Class ;
      private string subGridinvitados_Linesclass ;
      private string edtavQuitar_Jsonclick ;
      private string edtRegistroInvitadoId_Jsonclick ;
      private string edtRegistroInvitadoFecha_Jsonclick ;
      private string edtRegistroInvitadoUsuario_Jsonclick ;
      private string edtavNombre_Jsonclick ;
      private string dynInvitadoRolId_Jsonclick ;
      private string edtavAceptar_Jsonclick ;
      private string subGridparticipantes_Header ;
      private string subGridinvitados_Header ;
      private DateTime A20RegistroFecha ;
      private DateTime A45RegistroInvitadoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_18_Refreshing=false ;
      private bool bGXsfl_33_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV19ok ;
      private bool AV28quitar2_IsBlob ;
      private bool AV38cambiarRol_IsBlob ;
      private bool AV22quitar_IsBlob ;
      private bool AV37aceptar_IsBlob ;
      private bool AV35tieneusuario_IsBlob ;
      private string A6UsuarioEmail ;
      private string AV8UsuarioEmail ;
      private string AV43Quitar2_GXI ;
      private string AV44Cambiarrol_GXI ;
      private string AV47Quitar_GXI ;
      private string AV45Aceptar_GXI ;
      private string AV46Tieneusuario_GXI ;
      private string AV42Eliminar_GXI ;
      private string AV28quitar2 ;
      private string AV38cambiarRol ;
      private string AV22quitar ;
      private string AV37aceptar ;
      private string AV35tieneusuario ;
      private string AV17eliminar ;
      private GXWebGrid GridparticipantesContainer ;
      private GXWebGrid GridinvitadosContainer ;
      private GXWebRow GridparticipantesRow ;
      private GXWebRow GridinvitadosRow ;
      private GXWebColumn GridparticipantesColumn ;
      private GXWebColumn GridinvitadosColumn ;
      private GXUserControl ucRamp_addons_sweetalert1 ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private GXCombobox dynParticipanteRolId ;
      private GXCombobox dynInvitadoRolId ;
      private IDataStoreProvider pr_default ;
      private short[] H000Q2_A9TableroId ;
      private short[] H000Q2_A39ParticipanteRolId ;
      private DateTime[] H000Q2_A20RegistroFecha ;
      private short[] H000Q2_A18ParticipanteTableroId ;
      private short[] H000Q3_A9TableroId ;
      private short[] H000Q3_A41InvitadoRolId ;
      private short[] H000Q3_A43RegistroInvitadoUsuario ;
      private DateTime[] H000Q3_A45RegistroInvitadoFecha ;
      private short[] H000Q3_A40RegistroInvitadoId ;
      private string[] H000Q4_A6UsuarioEmail ;
      private short[] H000Q4_A3UsuarioId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] H000Q5_A1RolId ;
      private string[] H000Q5_A2RolNombre ;
      private short[] H000Q6_A1RolId ;
      private string[] H000Q6_A2RolNombre ;
      private short[] H000Q7_A1RolId ;
      private string[] H000Q7_A2RolNombre ;
      private short[] H000Q8_A1RolId ;
      private string[] H000Q8_A2RolNombre ;
      private GXWebForm Form ;
      private SdtInvitados AV25Invitados ;
      private SdtInvitados AV36Invitados2 ;
      private SdtParticipantes AV27Participantes ;
      private SdtSDT_SweetAlert AV34sdt_sa ;
      private SdtTableros AV30Tableros ;
      private SdtUsuarios AV32Usuarios3 ;
      private SdtUsuarios AV18Usuarios ;
      private SdtUsuarios AV29Usuarios2 ;
   }

   public class anadircolaboradores__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000Q2;
          prmH000Q2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmH000Q3;
          prmH000Q3 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmH000Q4;
          prmH000Q4 = new Object[] {
          new ParDef("@AV8UsuarioEmail",GXType.NVarChar,100,0)
          };
          Object[] prmH000Q5;
          prmH000Q5 = new Object[] {
          };
          Object[] prmH000Q6;
          prmH000Q6 = new Object[] {
          };
          Object[] prmH000Q7;
          prmH000Q7 = new Object[] {
          };
          Object[] prmH000Q8;
          prmH000Q8 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H000Q2", "SELECT [TableroId], [ParticipanteRolId], [RegistroFecha], [ParticipanteTableroId] FROM [Participantes] WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Q2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Q3", "SELECT [TableroId], [InvitadoRolId], [RegistroInvitadoUsuario], [RegistroInvitadoFecha], [RegistroInvitadoId] FROM [Invitados] WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Q3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Q4", "SELECT TOP 1 [UsuarioEmail], [UsuarioId] FROM [Usuarios] WHERE [UsuarioEmail] = @AV8UsuarioEmail ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Q4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H000Q5", "SELECT [RolId], [RolNombre] FROM [Roles] ORDER BY [RolNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Q5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Q6", "SELECT [RolId], [RolNombre] FROM [Roles] ORDER BY [RolNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Q6,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Q7", "SELECT [RolId], [RolNombre] FROM [Roles] ORDER BY [RolNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Q7,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Q8", "SELECT [RolId], [RolNombre] FROM [Roles] ORDER BY [RolNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Q8,0, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
       }
    }

 }

}
