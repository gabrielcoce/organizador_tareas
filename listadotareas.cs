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
   public class listadotareas : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public listadotareas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public listadotareas( IGxContext context )
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
               AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
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
         A23ResponsableId = (short)(NumberUtil.Val( GetPar( "ResponsableId"), "."));
         n23ResponsableId = false;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridparticipantes_refresh( A9TableroId, A23ResponsableId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridparticipantes_refresh_invoke */
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
         PA0T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0T2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("listadotareas.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0))}, new string[] {"TableroId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_18", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_18), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23ResponsableId), 4, 0, ",", "")));
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
         if ( ! ( WebComp_Tareasanadir == null ) )
         {
            WebComp_Tareasanadir.componentjscripts();
         }
         if ( ! ( WebComp_Sininiciar == null ) )
         {
            WebComp_Sininiciar.componentjscripts();
         }
         if ( ! ( WebComp_Enproceso == null ) )
         {
            WebComp_Enproceso.componentjscripts();
         }
         if ( ! ( WebComp_Finalizado == null ) )
         {
            WebComp_Finalizado.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0T2( ) ;
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
         return formatLink("listadotareas.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0))}, new string[] {"TableroId"})  ;
      }

      public override string GetPgmname( )
      {
         return "ListadoTareas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Listado Tareas" ;
      }

      protected void WB0T0( )
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitulo_Internalname, lblTitulo_Caption, "", "", lblTitulo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ListadoTareas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Participantes", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ListadoTareas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridparticipantesContainer.SetIsFreestyle(true);
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
            GxWebStd.gx_label_ctrl( context, lblSubtitulo_Internalname, lblSubtitulo_Caption, "", "", lblSubtitulo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ListadoTareas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "37af6e8e-5105-40d2-94ea-61da60f7a7ab", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 35, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110t1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ListadoTareas.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "Middle", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0044"+"", StringUtil.RTrim( WebComp_Tareasanadir_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0044"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_18_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Tareasanadir_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldTareasanadir), StringUtil.Lower( WebComp_Tareasanadir_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0044"+"");
                     }
                     WebComp_Tareasanadir.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldTareasanadir), StringUtil.Lower( WebComp_Tareasanadir_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "Center", "Middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0047"+"", StringUtil.RTrim( WebComp_Sininiciar_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0047"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_18_Refreshing )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSininiciar), StringUtil.Lower( WebComp_Sininiciar_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0047"+"");
                  }
                  WebComp_Sininiciar.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSininiciar), StringUtil.Lower( WebComp_Sininiciar_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0049"+"", StringUtil.RTrim( WebComp_Enproceso_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0049"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_18_Refreshing )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldEnproceso), StringUtil.Lower( WebComp_Enproceso_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0049"+"");
                  }
                  WebComp_Enproceso.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldEnproceso), StringUtil.Lower( WebComp_Enproceso_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0051"+"", StringUtil.RTrim( WebComp_Finalizado_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0051"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_18_Refreshing )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldFinalizado), StringUtil.Lower( WebComp_Finalizado_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0051"+"");
                  }
                  WebComp_Finalizado.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldFinalizado), StringUtil.Lower( WebComp_Finalizado_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
         wbLoad = true;
      }

      protected void START0T2( )
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
            Form.Meta.addItem("description", "Listado Tareas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0T0( ) ;
      }

      protected void WS0T2( )
      {
         START0T2( ) ;
         EVT0T2( ) ;
      }

      protected void EVT0T2( )
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRIDPARTICIPANTES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRIDPARTICIPANTES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_18_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
                              SubsflControlProps_182( ) ;
                              A18ParticipanteTableroId = (short)(context.localUtil.CToN( cgiGet( edtParticipanteTableroId_Internalname), ",", "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E120T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDPARTICIPANTES.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E130T2 ();
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
                                 }
                              }
                              else
                              {
                                 sEvtType = StringUtil.Right( sEvt, 4);
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                                 if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRIDPARTICIPANTES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                                 {
                                    nGXsfl_18_idx = (int)(NumberUtil.Val( sEvtType, "."));
                                    sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
                                    SubsflControlProps_182( ) ;
                                    A18ParticipanteTableroId = (short)(context.localUtil.CToN( cgiGet( edtParticipanteTableroId_Internalname), ",", "."));
                                    sEvtType = StringUtil.Right( sEvt, 1);
                                    if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                                    {
                                       sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                       if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                       {
                                          context.wbHandled = 1;
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E120T2 ();
                                       }
                                       else if ( StringUtil.StrCmp(sEvt, "GRIDPARTICIPANTES.LOAD") == 0 )
                                       {
                                          context.wbHandled = 1;
                                          dynload_actions( ) ;
                                          E130T2 ();
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
                                       }
                                    }
                                    else
                                    {
                                    }
                                 }
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 44 )
                        {
                           OldTareasanadir = cgiGet( "W0044");
                           if ( ( StringUtil.Len( OldTareasanadir) == 0 ) || ( StringUtil.StrCmp(OldTareasanadir, WebComp_Tareasanadir_Component) != 0 ) )
                           {
                              WebComp_Tareasanadir = getWebComponent(GetType(), "GeneXus.Programs", OldTareasanadir, new Object[] {context} );
                              WebComp_Tareasanadir.ComponentInit();
                              WebComp_Tareasanadir.Name = "OldTareasanadir";
                              WebComp_Tareasanadir_Component = OldTareasanadir;
                           }
                           if ( StringUtil.Len( WebComp_Tareasanadir_Component) != 0 )
                           {
                              WebComp_Tareasanadir.componentprocess("W0044", "", sEvt);
                           }
                           WebComp_Tareasanadir_Component = OldTareasanadir;
                        }
                        else if ( nCmpId == 47 )
                        {
                           OldSininiciar = cgiGet( "W0047");
                           if ( ( StringUtil.Len( OldSininiciar) == 0 ) || ( StringUtil.StrCmp(OldSininiciar, WebComp_Sininiciar_Component) != 0 ) )
                           {
                              WebComp_Sininiciar = getWebComponent(GetType(), "GeneXus.Programs", OldSininiciar, new Object[] {context} );
                              WebComp_Sininiciar.ComponentInit();
                              WebComp_Sininiciar.Name = "OldSininiciar";
                              WebComp_Sininiciar_Component = OldSininiciar;
                           }
                           WebComp_Sininiciar.componentprocess("W0047", "", sEvt);
                           WebComp_Sininiciar_Component = OldSininiciar;
                        }
                        else if ( nCmpId == 49 )
                        {
                           OldEnproceso = cgiGet( "W0049");
                           if ( ( StringUtil.Len( OldEnproceso) == 0 ) || ( StringUtil.StrCmp(OldEnproceso, WebComp_Enproceso_Component) != 0 ) )
                           {
                              WebComp_Enproceso = getWebComponent(GetType(), "GeneXus.Programs", OldEnproceso, new Object[] {context} );
                              WebComp_Enproceso.ComponentInit();
                              WebComp_Enproceso.Name = "OldEnproceso";
                              WebComp_Enproceso_Component = OldEnproceso;
                           }
                           WebComp_Enproceso.componentprocess("W0049", "", sEvt);
                           WebComp_Enproceso_Component = OldEnproceso;
                        }
                        else if ( nCmpId == 51 )
                        {
                           OldFinalizado = cgiGet( "W0051");
                           if ( ( StringUtil.Len( OldFinalizado) == 0 ) || ( StringUtil.StrCmp(OldFinalizado, WebComp_Finalizado_Component) != 0 ) )
                           {
                              WebComp_Finalizado = getWebComponent(GetType(), "GeneXus.Programs", OldFinalizado, new Object[] {context} );
                              WebComp_Finalizado.ComponentInit();
                              WebComp_Finalizado.Name = "OldFinalizado";
                              WebComp_Finalizado_Component = OldFinalizado;
                           }
                           WebComp_Finalizado.componentprocess("W0051", "", sEvt);
                           WebComp_Finalizado_Component = OldFinalizado;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0T2( )
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

      protected void PA0T2( )
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

      protected void gxgrGridparticipantes_refresh( short A9TableroId ,
                                                    short A23ResponsableId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDPARTICIPANTES_nCurrentRecord = 0;
         RF0T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridparticipantes_refresh */
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
         RF0T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtParticipanteTableroId_Visible = 0;
         AssignProp("", false, edtParticipanteTableroId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParticipanteTableroId_Visible), 5, 0), !bGXsfl_18_Refreshing);
      }

      protected void RF0T2( )
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
         GridparticipantesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridparticipantesContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridparticipantesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridparticipantesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridparticipantesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridparticipantes_Backcolorstyle), 1, 0, ".", "")));
         GridparticipantesContainer.PageSize = subGridparticipantes_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Tareasanadir_Component) != 0 )
               {
                  WebComp_Tareasanadir.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Sininiciar_Component, "") == 0 )
            {
               WebComp_Sininiciar = getWebComponent(GetType(), "GeneXus.Programs", "sininiciarwc", new Object[] {context} );
               WebComp_Sininiciar.ComponentInit();
               WebComp_Sininiciar.Name = "SinIniciarWC";
               WebComp_Sininiciar_Component = "SinIniciarWC";
            }
            WebComp_Sininiciar.setjustcreated();
            WebComp_Sininiciar.componentprepare(new Object[] {(string)"W0047",(string)"",(short)A9TableroId});
            WebComp_Sininiciar.componentbind(new Object[] {(string)""});
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Sininiciar )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0047"+"");
               WebComp_Sininiciar.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Sininiciar.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Enproceso_Component, "") == 0 )
            {
               WebComp_Enproceso = getWebComponent(GetType(), "GeneXus.Programs", "enprocesowc", new Object[] {context} );
               WebComp_Enproceso.ComponentInit();
               WebComp_Enproceso.Name = "EnProcesoWC";
               WebComp_Enproceso_Component = "EnProcesoWC";
            }
            WebComp_Enproceso.setjustcreated();
            WebComp_Enproceso.componentprepare(new Object[] {(string)"W0049",(string)"",(short)A9TableroId});
            WebComp_Enproceso.componentbind(new Object[] {(string)""});
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Enproceso )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0049"+"");
               WebComp_Enproceso.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Enproceso.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Finalizado_Component, "") == 0 )
            {
               WebComp_Finalizado = getWebComponent(GetType(), "GeneXus.Programs", "finalizadowc", new Object[] {context} );
               WebComp_Finalizado.ComponentInit();
               WebComp_Finalizado.Name = "FinalizadoWC";
               WebComp_Finalizado_Component = "FinalizadoWC";
            }
            WebComp_Finalizado.setjustcreated();
            WebComp_Finalizado.componentprepare(new Object[] {(string)"W0051",(string)"",(short)A9TableroId});
            WebComp_Finalizado.componentbind(new Object[] {(string)""});
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Finalizado )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0051"+"");
               WebComp_Finalizado.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Finalizado.componentstart();
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_182( ) ;
            /* Using cursor H000T2 */
            pr_default.execute(0, new Object[] {A9TableroId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A18ParticipanteTableroId = H000T2_A18ParticipanteTableroId[0];
               E130T2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 18;
            WB0T0( ) ;
         }
         bGXsfl_18_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0T2( )
      {
         GxWebStd.gx_hidden_field( context, "TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
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

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtParticipanteTableroId_Visible = 0;
         AssignProp("", false, edtParticipanteTableroId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParticipanteTableroId_Visible), 5, 0), !bGXsfl_18_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_18 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_18"), ",", "."));
            A9TableroId = (short)(context.localUtil.CToN( cgiGet( "TABLEROID"), ",", "."));
            /* Read variables values. */
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
         E120T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120T2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV5Tableros.Load(A9TableroId);
         lblTitulo_Caption = "<h1><strong><center>"+StringUtil.Trim( AV5Tableros.gxTpr_Tableronombre)+"</center></strong></h1>";
         AssignProp("", false, lblTitulo_Internalname, "Caption", lblTitulo_Caption, true);
         lblSubtitulo_Caption = "<h2><strong><center>Tareas</center></strong></h2>";
         AssignProp("", false, lblSubtitulo_Internalname, "Caption", lblSubtitulo_Caption, true);
      }

      private void E130T2( )
      {
         /* Gridparticipantes_Load Routine */
         returnInSub = false;
         AV25Participantes.Load(A9TableroId, A18ParticipanteTableroId);
         AV26Roles.Load(AV25Participantes.gxTpr_Participanterolid);
         AV10count = 0;
         AV7Usuarios.Load(A18ParticipanteTableroId);
         AV6nombre = StringUtil.Trim( AV7Usuarios.gxTpr_Usuarioemail) + " - " + StringUtil.Trim( AV7Usuarios.gxTpr_Usuarionombre) + " " + StringUtil.Trim( AV7Usuarios.gxTpr_Usuarioapellido);
         /* Optimized group. */
         /* Using cursor H000T3 */
         pr_default.execute(1, new Object[] {A9TableroId, A18ParticipanteTableroId});
         cV10count = H000T3_AV10count[0];
         pr_default.close(1);
         AV10count = (short)(AV10count+cV10count*1);
         /* End optimized group. */
         AV8t = AV10count;
         lblNombrecol_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         lblNombrecol_Caption = StringUtil.StringReplace( lblNombrecol_Caption, "#LABEL", "Nombre");
         lblNombrecol_Caption = StringUtil.StringReplace( lblNombrecol_Caption, "#VALUE", AV6nombre);
         lblFechacol_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         lblFechacol_Caption = StringUtil.StringReplace( lblFechacol_Caption, "#LABEL", "Colabora desde");
         lblFechacol_Caption = StringUtil.StringReplace( lblFechacol_Caption, "#VALUE", context.localUtil.TToC( AV25Participantes.gxTpr_Registrofecha, 8, 5, 0, 3, "/", ":", " "));
         lblRolcol_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         lblRolcol_Caption = StringUtil.StringReplace( lblRolcol_Caption, "#LABEL", "Rol");
         lblRolcol_Caption = StringUtil.StringReplace( lblRolcol_Caption, "#VALUE", AV26Roles.gxTpr_Rolnombre);
         lblTareascol_Caption = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
         lblTareascol_Caption = StringUtil.StringReplace( lblTareascol_Caption, "#LABEL", "Asignadas");
         lblTareascol_Caption = StringUtil.StringReplace( lblTareascol_Caption, "#VALUE", StringUtil.Trim( StringUtil.Str( (decimal)(AV8t), 4, 0)));
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

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A9TableroId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_TABLEROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9"), context));
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
         PA0T2( ) ;
         WS0T2( ) ;
         WE0T2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Tareasanadir == null ) )
         {
            if ( StringUtil.Len( WebComp_Tareasanadir_Component) != 0 )
            {
               WebComp_Tareasanadir.componentthemes();
            }
         }
         if ( StringUtil.StrCmp(WebComp_Sininiciar_Component, "") == 0 )
         {
            WebComp_Sininiciar = getWebComponent(GetType(), "GeneXus.Programs", "sininiciarwc", new Object[] {context} );
            WebComp_Sininiciar.ComponentInit();
            WebComp_Sininiciar.Name = "SinIniciarWC";
            WebComp_Sininiciar_Component = "SinIniciarWC";
         }
         if ( ! ( WebComp_Sininiciar == null ) )
         {
            WebComp_Sininiciar.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Enproceso_Component, "") == 0 )
         {
            WebComp_Enproceso = getWebComponent(GetType(), "GeneXus.Programs", "enprocesowc", new Object[] {context} );
            WebComp_Enproceso.ComponentInit();
            WebComp_Enproceso.Name = "EnProcesoWC";
            WebComp_Enproceso_Component = "EnProcesoWC";
         }
         if ( ! ( WebComp_Enproceso == null ) )
         {
            WebComp_Enproceso.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Finalizado_Component, "") == 0 )
         {
            WebComp_Finalizado = getWebComponent(GetType(), "GeneXus.Programs", "finalizadowc", new Object[] {context} );
            WebComp_Finalizado.ComponentInit();
            WebComp_Finalizado.Name = "FinalizadoWC";
            WebComp_Finalizado_Component = "FinalizadoWC";
         }
         if ( ! ( WebComp_Finalizado == null ) )
         {
            WebComp_Finalizado.componentthemes();
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202210229112030", true, true);
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
         context.AddJavascriptSource("listadotareas.js", "?202210229112030", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/js/sweetalert2.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/jquery-3.5.1.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/popper.js", "", false, true);
         context.AddJavascriptSource("RAMP/shared/js/bootstrap.min.js", "", false, true);
         context.AddJavascriptSource("RAMP/sweetAlert/RAMP_AddOns_SweetAlertRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_182( )
      {
         edtParticipanteTableroId_Internalname = "PARTICIPANTETABLEROID_"+sGXsfl_18_idx;
         lblNombrecol_Internalname = "NOMBRECOL_"+sGXsfl_18_idx;
         lblRolcol_Internalname = "ROLCOL_"+sGXsfl_18_idx;
         lblFechacol_Internalname = "FECHACOL_"+sGXsfl_18_idx;
         lblTareascol_Internalname = "TAREASCOL_"+sGXsfl_18_idx;
         subGridparticipantes_Internalname = "GRIDPARTICIPANTES";
      }

      protected void SubsflControlProps_fel_182( )
      {
         edtParticipanteTableroId_Internalname = "PARTICIPANTETABLEROID_"+sGXsfl_18_fel_idx;
         lblNombrecol_Internalname = "NOMBRECOL_"+sGXsfl_18_fel_idx;
         lblRolcol_Internalname = "ROLCOL_"+sGXsfl_18_fel_idx;
         lblFechacol_Internalname = "FECHACOL_"+sGXsfl_18_fel_idx;
         lblTareascol_Internalname = "TAREASCOL_"+sGXsfl_18_fel_idx;
         subGridparticipantes_Internalname = "GRIDPARTICIPANTES";
      }

      protected void sendrow_182( )
      {
         SubsflControlProps_182( ) ;
         WB0T0( ) ;
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
            subGridparticipantes_Backcolor = (int)(0xFFFFFF);
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
               subGridparticipantes_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridparticipantes_Class, "") != 0 )
               {
                  subGridparticipantes_Linesclass = subGridparticipantes_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridparticipantesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridparticipantes_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_18_idx+"\">") ;
         }
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table_Internalname+"_"+sGXsfl_18_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"TableWidget",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(int)edtParticipanteTableroId_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtParticipanteTableroId_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridparticipantesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteTableroId_Internalname,(string)"Participante Tablero Id",(string)"col-sm-3 AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridparticipantesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteTableroId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A18ParticipanteTableroId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A18ParticipanteTableroId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParticipanteTableroId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtParticipanteTableroId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)18,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-md-9",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         GridparticipantesRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNombrecol_Internalname,(string)lblNombrecol_Caption,(string)"",(string)"",(string)lblNombrecol_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         GridparticipantesRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblRolcol_Internalname,(string)lblRolcol_Caption,(string)"",(string)"",(string)lblRolcol_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         GridparticipantesRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblFechacol_Internalname,(string)lblFechacol_Caption,(string)"",(string)"",(string)lblFechacol_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         GridparticipantesRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTareascol_Internalname,(string)lblTareascol_Caption,(string)"",(string)"",(string)lblTareascol_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes0T2( ) ;
         /* End of Columns property logic. */
         GridparticipantesContainer.AddRow(GridparticipantesRow);
         nGXsfl_18_idx = ((subGridparticipantes_Islastpage==1)&&(nGXsfl_18_idx+1>subGridparticipantes_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1);
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
         SubsflControlProps_182( ) ;
         /* End function sendrow_182 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl18( )
      {
         if ( GridparticipantesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridparticipantesContainer"+"DivS\" data-gxgridid=\"18\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridparticipantes_Internalname, subGridparticipantes_Internalname, " "+"sdsmartgrid_scrolldirection=\"horizontal\""+" "+"sdsmartgrid_itemspercolumn=\"4\""+" "+"sdsmartgrid_snaptogrid=\"True\""+" "+"sdsmartgrid_multipleitems=\"multiple_quantity\""+" ", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            GridparticipantesContainer.SetIsFreestyle(true);
            GridparticipantesContainer.SetWrapped(nGXWrapped);
            GridparticipantesContainer.AddObjectProperty("GridName", "Gridparticipantes");
            GridparticipantesContainer.AddObjectProperty("Header", subGridparticipantes_Header);
            GridparticipantesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridparticipantesContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridparticipantesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridparticipantesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridparticipantesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridparticipantes_Backcolorstyle), 1, 0, ".", "")));
            GridparticipantesContainer.AddObjectProperty("CmpContext", "");
            GridparticipantesContainer.AddObjectProperty("InMasterPage", "false");
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18ParticipanteTableroId), 4, 0, ".", "")));
            GridparticipantesColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParticipanteTableroId_Visible), 5, 0, ".", "")));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesColumn.AddObjectProperty("Value", lblNombrecol_Caption);
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesColumn.AddObjectProperty("Value", lblRolcol_Caption);
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesColumn.AddObjectProperty("Value", lblFechacol_Caption);
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
            GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridparticipantesColumn.AddObjectProperty("Value", lblTareascol_Caption);
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

      protected void init_default_properties( )
      {
         lblTitulo_Internalname = "TITULO";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtParticipanteTableroId_Internalname = "PARTICIPANTETABLEROID";
         lblNombrecol_Internalname = "NOMBRECOL";
         lblRolcol_Internalname = "ROLCOL";
         lblFechacol_Internalname = "FECHACOL";
         lblTareascol_Internalname = "TAREASCOL";
         divGrid1table_Internalname = "GRID1TABLE";
         divTable2_Internalname = "TABLE2";
         divTable1_Internalname = "TABLE1";
         lblSubtitulo_Internalname = "SUBTITULO";
         imgImage1_Internalname = "IMAGE1";
         Ramp_addons_sweetalert1_Internalname = "RAMP_ADDONS_SWEETALERT1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridparticipantes_Internalname = "GRIDPARTICIPANTES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridparticipantes_Allowcollapsing = 0;
         lblTareascol_Caption = "TareasCol";
         lblFechacol_Caption = "FechaCol";
         lblRolcol_Caption = "RolCol";
         lblNombrecol_Caption = "NombreCol";
         edtParticipanteTableroId_Jsonclick = "";
         subGridparticipantes_Class = "FreeStyleGrid";
         lblTareascol_Caption = "TareasCol";
         lblRolcol_Caption = "RolCol";
         lblFechacol_Caption = "FechaCol";
         lblNombrecol_Caption = "NombreCol";
         subGridparticipantes_Backcolorstyle = 0;
         edtParticipanteTableroId_Visible = 1;
         lblSubtitulo_Caption = "Text Block";
         lblTitulo_Caption = "Text Block";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Listado Tareas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDPARTICIPANTES_nFirstRecordOnPage'},{av:'GRIDPARTICIPANTES_nEOF'},{av:'A23ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDPARTICIPANTES.LOAD","{handler:'E130T2',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9',hsh:true},{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'A23ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9'}]");
         setEventMetadata("GRIDPARTICIPANTES.LOAD",",oparms:[{av:'lblNombrecol_Caption',ctrl:'NOMBRECOL',prop:'Caption'},{av:'lblFechacol_Caption',ctrl:'FECHACOL',prop:'Caption'},{av:'lblRolcol_Caption',ctrl:'ROLCOL',prop:'Caption'},{av:'lblTareascol_Caption',ctrl:'TAREASCOL',prop:'Caption'}]}");
         setEventMetadata("'NUEVO'","{handler:'E110T1',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'NUEVO'",",oparms:[{ctrl:'TAREASANADIR'}]}");
         setEventMetadata("NULL","{handler:'Valid_Participantetableroid',iparms:[]");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitulo_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         GridparticipantesContainer = new GXWebGrid( context);
         sStyleString = "";
         lblSubtitulo_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         imgImage1_Jsonclick = "";
         WebComp_Tareasanadir_Component = "";
         OldTareasanadir = "";
         WebComp_Sininiciar_Component = "";
         OldSininiciar = "";
         WebComp_Enproceso_Component = "";
         OldEnproceso = "";
         WebComp_Finalizado_Component = "";
         OldFinalizado = "";
         ucRamp_addons_sweetalert1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H000T2_A9TableroId = new short[1] ;
         H000T2_A18ParticipanteTableroId = new short[1] ;
         AV5Tableros = new SdtTableros(context);
         AV25Participantes = new SdtParticipantes(context);
         AV26Roles = new SdtRoles(context);
         AV7Usuarios = new SdtUsuarios(context);
         AV6nombre = "";
         H000T3_AV10count = new short[1] ;
         GridparticipantesRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridparticipantes_Linesclass = "";
         ROClassString = "";
         lblNombrecol_Jsonclick = "";
         lblRolcol_Jsonclick = "";
         lblFechacol_Jsonclick = "";
         lblTareascol_Jsonclick = "";
         subGridparticipantes_Header = "";
         GridparticipantesColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listadotareas__default(),
            new Object[][] {
                new Object[] {
               H000T2_A9TableroId, H000T2_A18ParticipanteTableroId
               }
               , new Object[] {
               H000T3_AV10count
               }
            }
         );
         WebComp_Tareasanadir = new GeneXus.Http.GXNullWebComponent();
         WebComp_Sininiciar = new GeneXus.Http.GXNullWebComponent();
         WebComp_Enproceso = new GeneXus.Http.GXNullWebComponent();
         WebComp_Finalizado = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtParticipanteTableroId_Visible = 0;
      }

      private short A9TableroId ;
      private short wcpOA9TableroId ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short A23ResponsableId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A18ParticipanteTableroId ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridparticipantes_Backcolorstyle ;
      private short AV10count ;
      private short cV10count ;
      private short AV8t ;
      private short nGXWrapped ;
      private short subGridparticipantes_Backstyle ;
      private short subGridparticipantes_Allowselection ;
      private short subGridparticipantes_Allowhovering ;
      private short subGridparticipantes_Allowcollapsing ;
      private short subGridparticipantes_Collapsed ;
      private short GRIDPARTICIPANTES_nEOF ;
      private int nRC_GXsfl_18 ;
      private int nGXsfl_18_idx=1 ;
      private int subGridparticipantes_Islastpage ;
      private int edtParticipanteTableroId_Visible ;
      private int idxLst ;
      private int subGridparticipantes_Backcolor ;
      private int subGridparticipantes_Allbackcolor ;
      private int subGridparticipantes_Selectedindex ;
      private int subGridparticipantes_Selectioncolor ;
      private int subGridparticipantes_Hoveringcolor ;
      private long GRIDPARTICIPANTES_nCurrentRecord ;
      private long GRIDPARTICIPANTES_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_18_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTitulo_Internalname ;
      private string lblTitulo_Caption ;
      private string lblTitulo_Jsonclick ;
      private string divTable1_Internalname ;
      private string divTable2_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string sStyleString ;
      private string subGridparticipantes_Internalname ;
      private string lblSubtitulo_Internalname ;
      private string lblSubtitulo_Caption ;
      private string lblSubtitulo_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage1_Internalname ;
      private string imgImage1_Jsonclick ;
      private string WebComp_Tareasanadir_Component ;
      private string OldTareasanadir ;
      private string WebComp_Sininiciar_Component ;
      private string OldSininiciar ;
      private string WebComp_Enproceso_Component ;
      private string OldEnproceso ;
      private string WebComp_Finalizado_Component ;
      private string OldFinalizado ;
      private string Ramp_addons_sweetalert1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtParticipanteTableroId_Internalname ;
      private string scmdbuf ;
      private string AV6nombre ;
      private string lblNombrecol_Caption ;
      private string lblFechacol_Caption ;
      private string lblRolcol_Caption ;
      private string lblTareascol_Caption ;
      private string lblNombrecol_Internalname ;
      private string lblRolcol_Internalname ;
      private string lblFechacol_Internalname ;
      private string lblTareascol_Internalname ;
      private string sGXsfl_18_fel_idx="0001" ;
      private string subGridparticipantes_Class ;
      private string subGridparticipantes_Linesclass ;
      private string divGrid1table_Internalname ;
      private string ROClassString ;
      private string edtParticipanteTableroId_Jsonclick ;
      private string lblNombrecol_Jsonclick ;
      private string lblRolcol_Jsonclick ;
      private string lblFechacol_Jsonclick ;
      private string lblTareascol_Jsonclick ;
      private string subGridparticipantes_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n23ResponsableId ;
      private bool wbLoad ;
      private bool bGXsfl_18_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bDynCreated_Sininiciar ;
      private bool bDynCreated_Enproceso ;
      private bool bDynCreated_Finalizado ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXWebComponent WebComp_Tareasanadir ;
      private GXWebComponent WebComp_Sininiciar ;
      private GXWebComponent WebComp_Enproceso ;
      private GXWebComponent WebComp_Finalizado ;
      private GXWebGrid GridparticipantesContainer ;
      private GXWebRow GridparticipantesRow ;
      private GXWebColumn GridparticipantesColumn ;
      private GXUserControl ucRamp_addons_sweetalert1 ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private IDataStoreProvider pr_default ;
      private short[] H000T2_A9TableroId ;
      private short[] H000T2_A18ParticipanteTableroId ;
      private short[] H000T3_AV10count ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtParticipantes AV25Participantes ;
      private SdtRoles AV26Roles ;
      private SdtTableros AV5Tableros ;
      private SdtUsuarios AV7Usuarios ;
   }

   public class listadotareas__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH000T2;
          prmH000T2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmH000T3;
          prmH000T3 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000T2", "SELECT [TableroId], [ParticipanteTableroId] FROM [Participantes] WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000T2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000T3", "SELECT COUNT(*) FROM [Tareas] WHERE ([TableroId] = @TableroId) AND ([ResponsableId] = @ParticipanteTableroId) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000T3,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
