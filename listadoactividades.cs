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
   public class listadoactividades : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public listadoactividades( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public listadoactividades( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref short aP1_TareaId )
      {
         this.A9TableroId = aP0_TableroId;
         this.A12TareaId = aP1_TareaId;
         executePrivate();
         aP0_TableroId=this.A9TableroId;
         aP1_TareaId=this.A12TareaId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynParticipanteRolId = new GXCombobox();
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
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridparticipantes") == 0 )
            {
               A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
               A23ResponsableId = (short)(NumberUtil.Val( GetPar( "ResponsableId"), "."));
               n23ResponsableId = false;
               Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridparticipantes_refresh( A9TableroId, A23ResponsableId, Gx_date) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridtareas") == 0 )
            {
               nRC_GXsfl_50 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_50"), "."));
               nGXsfl_50_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_50_idx"), "."));
               sGXsfl_50_idx = GetPar( "sGXsfl_50_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridtareas_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridtareas") == 0 )
            {
               A9TableroId = (short)(NumberUtil.Val( GetPar( "TableroId"), "."));
               A12TareaId = (short)(NumberUtil.Val( GetPar( "TareaId"), "."));
               Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridtareas_refresh( A9TableroId, A12TareaId, Gx_date) ;
               AddString( context.getJSONResponse( )) ;
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
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  A12TareaId = (short)(NumberUtil.Val( GetPar( "TareaId"), "."));
               }
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
         PA0V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0V2( ) ;
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1940340), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202291619471532", false, true);
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("listadoactividades.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0)),UrlEncode(StringUtil.LTrimStr(A12TareaId,4,0))}, new string[] {"TableroId","TareaId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_18", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_18), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_50", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_50), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TABLEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "RESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23ResponsableId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE0V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0V2( ) ;
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
         return formatLink("listadoactividades.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0)),UrlEncode(StringUtil.LTrimStr(A12TareaId,4,0))}, new string[] {"TableroId","TareaId"})  ;
      }

      public override string GetPgmname( )
      {
         return "ListadoActividades" ;
      }

      public override string GetPgmdesc( )
      {
         return "Listado Actividades" ;
      }

      protected void WB0V0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitulo_Internalname, lblTitulo_Caption, "", "", lblTitulo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ListadoActividades.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Participantes", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ListadoActividades.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridparticipantesContainer.SetIsFreestyle(true);
            GridparticipantesContainer.SetWrapped(nGXWrapped);
            if ( GridparticipantesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridparticipantesContainer"+"DivS\" data-gxgridid=\"18\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridparticipantes_Internalname, subGridparticipantes_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesColumn.AddObjectProperty("Value", StringUtil.RTrim( AV6nombre));
               GridparticipantesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNombre_Enabled), 5, 0, ".", "")));
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesColumn.AddObjectProperty("Value", context.localUtil.TToC( A20RegistroFecha, 10, 8, 0, 3, "/", ":", " "));
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A39ParticipanteRolId), 4, 0, ".", "")));
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesContainer.AddColumnProperties(GridparticipantesColumn);
               GridparticipantesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridparticipantesColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10t), 4, 0, ".", "")));
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
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridparticipantes", GridparticipantesContainer);
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
            GxWebStd.gx_label_ctrl( context, lblSubtitulo_Internalname, lblSubtitulo_Caption, "", "", lblSubtitulo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ListadoActividades.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "37af6e8e-5105-40d2-94ea-61da60f7a7ab", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 35, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'NUEVO\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ListadoActividades.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridtareasContainer.SetIsFreestyle(true);
            GridtareasContainer.SetWrapped(nGXWrapped);
            if ( GridtareasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridtareasContainer"+"DivS\" data-gxgridid=\"50\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridtareas_Internalname, subGridtareas_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               GridtareasContainer.AddObjectProperty("GridName", "Gridtareas");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridtareasContainer = new GXWebGrid( context);
               }
               else
               {
                  GridtareasContainer.Clear();
               }
               GridtareasContainer.SetIsFreestyle(true);
               GridtareasContainer.SetWrapped(nGXWrapped);
               GridtareasContainer.AddObjectProperty("GridName", "Gridtareas");
               GridtareasContainer.AddObjectProperty("Header", subGridtareas_Header);
               GridtareasContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               GridtareasContainer.AddObjectProperty("Class", "FreeStyleGrid");
               GridtareasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridtareasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridtareasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas_Backcolorstyle), 1, 0, ".", "")));
               GridtareasContainer.AddObjectProperty("CmpContext", "");
               GridtareasContainer.AddObjectProperty("InMasterPage", "false");
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ".", "")));
               GridtareasColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTareaId_Visible), 5, 0, ".", "")));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasColumn.AddObjectProperty("Value", lblAdvisor_Caption);
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasColumn.AddObjectProperty("Value", StringUtil.RTrim( A13TareaNombre));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasColumn.AddObjectProperty("Value", context.convertURL( AV9state2));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasColumn.AddObjectProperty("Value", context.convertURL( AV17stop));
               GridtareasColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavStop_Visible), 5, 0, ".", "")));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasColumn.AddObjectProperty("Value", context.localUtil.Format(A24TareaFechaInicio, "99/99/99"));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasColumn.AddObjectProperty("Value", context.localUtil.Format(A25TareaFechaFin, "99/99/99"));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasColumn.AddObjectProperty("Value", StringUtil.RTrim( AV7Responsable));
               GridtareasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResponsable_Enabled), 5, 0, ".", "")));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasColumn.AddObjectProperty("Value", context.convertURL( AV8state));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridtareasColumn.AddObjectProperty("Value", context.convertURL( AV19actividades));
               GridtareasContainer.AddColumnProperties(GridtareasColumn);
               GridtareasContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas_Selectedindex), 4, 0, ".", "")));
               GridtareasContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas_Allowselection), 1, 0, ".", "")));
               GridtareasContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas_Selectioncolor), 9, 0, ".", "")));
               GridtareasContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas_Allowhovering), 1, 0, ".", "")));
               GridtareasContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas_Hoveringcolor), 9, 0, ".", "")));
               GridtareasContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas_Allowcollapsing), 1, 0, ".", "")));
               GridtareasContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 50 )
         {
            wbEnd = 0;
            nRC_GXsfl_50 = (int)(nGXsfl_50_idx-1);
            if ( GridtareasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridtareasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridtareas", GridtareasContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridtareasContainerData", GridtareasContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridtareasContainerData"+"V", GridtareasContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridtareasContainerData"+"V"+"\" value='"+GridtareasContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridparticipantes", GridparticipantesContainer);
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
         if ( wbEnd == 50 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridtareasContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridtareasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridtareas", GridtareasContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridtareasContainerData", GridtareasContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridtareasContainerData"+"V", GridtareasContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridtareasContainerData"+"V"+"\" value='"+GridtareasContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0V2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_8-158023", 0) ;
            }
            Form.Meta.addItem("description", "Listado Actividades", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0V0( ) ;
      }

      protected void WS0V2( )
      {
         START0V2( ) ;
         EVT0V2( ) ;
      }

      protected void EVT0V2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'NUEVO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Nuevo' */
                              E110V2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRIDPARTICIPANTES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_18_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
                              SubsflControlProps_182( ) ;
                              A18ParticipanteTableroId = (short)(context.localUtil.CToN( cgiGet( edtParticipanteTableroId_Internalname), ",", "."));
                              AV6nombre = cgiGet( edtavNombre_Internalname);
                              AssignAttri("", false, edtavNombre_Internalname, AV6nombre);
                              A20RegistroFecha = context.localUtil.CToT( cgiGet( edtRegistroFecha_Internalname), 0);
                              dynParticipanteRolId.Name = dynParticipanteRolId_Internalname;
                              dynParticipanteRolId.CurrentValue = cgiGet( dynParticipanteRolId_Internalname);
                              A39ParticipanteRolId = (short)(NumberUtil.Val( cgiGet( dynParticipanteRolId_Internalname), "."));
                              AV10t = (short)(context.localUtil.CToN( cgiGet( edtavT_Internalname), ",", "."));
                              AssignAttri("", false, edtavT_Internalname, StringUtil.LTrimStr( (decimal)(AV10t), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E120V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDPARTICIPANTES.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E130V2 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "GRIDTAREAS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'PAUSAPLAY'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'INICIAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'INICIAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'PAUSAPLAY'") == 0 ) )
                           {
                              nGXsfl_50_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
                              SubsflControlProps_504( ) ;
                              A12TareaId = (short)(context.localUtil.CToN( cgiGet( edtTareaId_Internalname), ",", "."));
                              A13TareaNombre = cgiGet( edtTareaNombre_Internalname);
                              AV9state2 = cgiGet( edtavState2_Internalname);
                              AssignProp("", false, edtavState2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV9state2)) ? AV26State2_GXI : context.convertURL( context.PathToRelativeUrl( AV9state2))), !bGXsfl_50_Refreshing);
                              AssignProp("", false, edtavState2_Internalname, "SrcSet", context.GetImageSrcSet( AV9state2), true);
                              AV17stop = cgiGet( edtavStop_Internalname);
                              AssignProp("", false, edtavStop_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV17stop)) ? AV27Stop_GXI : context.convertURL( context.PathToRelativeUrl( AV17stop))), !bGXsfl_50_Refreshing);
                              AssignProp("", false, edtavStop_Internalname, "SrcSet", context.GetImageSrcSet( AV17stop), true);
                              A24TareaFechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTareaFechaInicio_Internalname), 0));
                              A25TareaFechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTareaFechaFin_Internalname), 0));
                              AV7Responsable = cgiGet( edtavResponsable_Internalname);
                              AssignAttri("", false, edtavResponsable_Internalname, AV7Responsable);
                              AV8state = cgiGet( edtavState_Internalname);
                              AssignProp("", false, edtavState_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8state)) ? AV25State_GXI : context.convertURL( context.PathToRelativeUrl( AV8state))), !bGXsfl_50_Refreshing);
                              AssignProp("", false, edtavState_Internalname, "SrcSet", context.GetImageSrcSet( AV8state), true);
                              AV19actividades = cgiGet( edtavActividades_Internalname);
                              AssignProp("", false, edtavActividades_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV19actividades)) ? AV24Actividades_GXI : context.convertURL( context.PathToRelativeUrl( AV19actividades))), !bGXsfl_50_Refreshing);
                              AssignProp("", false, edtavActividades_Internalname, "SrcSet", context.GetImageSrcSet( AV19actividades), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDTAREAS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E140V4 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'PAUSAPLAY'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'PausaPlay' */
                                    E150V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'INICIAR'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Iniciar' */
                                    E160V2 ();
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

      protected void WE0V2( )
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

      protected void PA0V2( )
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

      protected void gxnrGridtareas_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_504( ) ;
         while ( nGXsfl_50_idx <= nRC_GXsfl_50 )
         {
            sendrow_504( ) ;
            nGXsfl_50_idx = ((subGridtareas_Islastpage==1)&&(nGXsfl_50_idx+1>subGridtareas_fnc_Recordsperpage( )) ? 1 : nGXsfl_50_idx+1);
            sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
            SubsflControlProps_504( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridtareasContainer)) ;
         /* End function gxnrGridtareas_newrow */
      }

      protected void gxgrGridparticipantes_refresh( short A9TableroId ,
                                                    short A23ResponsableId ,
                                                    DateTime Gx_date )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDPARTICIPANTES_nCurrentRecord = 0;
         RF0V2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridparticipantes_refresh */
      }

      protected void gxgrGridtareas_refresh( short A9TableroId ,
                                             short A12TareaId ,
                                             DateTime Gx_date )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDTAREAS_nCurrentRecord = 0;
         RF0V4( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridtareas_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TAREAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TAREAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ".", "")));
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
         RF0V2( ) ;
         RF0V4( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
         edtParticipanteTableroId_Visible = 0;
         AssignProp("", false, edtParticipanteTableroId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParticipanteTableroId_Visible), 5, 0), !bGXsfl_18_Refreshing);
         edtTareaId_Visible = 0;
         AssignProp("", false, edtTareaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTareaId_Visible), 5, 0), !bGXsfl_50_Refreshing);
         edtavNombre_Enabled = 0;
         AssignProp("", false, edtavNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNombre_Enabled), 5, 0), !bGXsfl_18_Refreshing);
         edtavResponsable_Enabled = 0;
         AssignProp("", false, edtavResponsable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsable_Enabled), 5, 0), !bGXsfl_50_Refreshing);
      }

      protected void RF0V2( )
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
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_182( ) ;
            /* Using cursor H000V2 */
            pr_default.execute(0, new Object[] {A9TableroId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A18ParticipanteTableroId = H000V2_A18ParticipanteTableroId[0];
               A39ParticipanteRolId = H000V2_A39ParticipanteRolId[0];
               A20RegistroFecha = H000V2_A20RegistroFecha[0];
               E130V2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 18;
            WB0V0( ) ;
         }
         bGXsfl_18_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0V2( )
      {
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
      }

      protected void RF0V4( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridtareasContainer.ClearRows();
         }
         wbStart = 50;
         nGXsfl_50_idx = 1;
         sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
         SubsflControlProps_504( ) ;
         bGXsfl_50_Refreshing = true;
         GridtareasContainer.AddObjectProperty("GridName", "Gridtareas");
         GridtareasContainer.AddObjectProperty("CmpContext", "");
         GridtareasContainer.AddObjectProperty("InMasterPage", "false");
         GridtareasContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridtareasContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridtareasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridtareasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridtareasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtareas_Backcolorstyle), 1, 0, ".", "")));
         GridtareasContainer.PageSize = subGridtareas_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_504( ) ;
            /* Using cursor H000V3 */
            pr_default.execute(1, new Object[] {A9TableroId, A12TareaId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A25TareaFechaFin = H000V3_A25TareaFechaFin[0];
               A24TareaFechaInicio = H000V3_A24TareaFechaInicio[0];
               A13TareaNombre = H000V3_A13TareaNombre[0];
               E140V4 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            wbEnd = 50;
            WB0V0( ) ;
         }
         bGXsfl_50_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0V4( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TAREAID"+"_"+sGXsfl_50_idx, GetSecureSignedToken( sGXsfl_50_idx, context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9"), context));
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

      protected int subGridtareas_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridtareas_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridtareas_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridtareas_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
         edtParticipanteTableroId_Visible = 0;
         AssignProp("", false, edtParticipanteTableroId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParticipanteTableroId_Visible), 5, 0), !bGXsfl_18_Refreshing);
         edtTareaId_Visible = 0;
         AssignProp("", false, edtTareaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTareaId_Visible), 5, 0), !bGXsfl_50_Refreshing);
         edtavNombre_Enabled = 0;
         AssignProp("", false, edtavNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNombre_Enabled), 5, 0), !bGXsfl_18_Refreshing);
         edtavResponsable_Enabled = 0;
         AssignProp("", false, edtavResponsable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsable_Enabled), 5, 0), !bGXsfl_50_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_18 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_18"), ",", "."));
            nRC_GXsfl_50 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_50"), ",", "."));
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
         E120V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120V2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV12Tareas.Load(A9TableroId, A12TareaId);
         lblTitulo_Caption = "<h1><strong><center>"+StringUtil.Trim( AV12Tareas.gxTpr_Tareanombre)+"</center></strong></h1>";
         AssignProp("", false, lblTitulo_Internalname, "Caption", lblTitulo_Caption, true);
         lblSubtitulo_Caption = "<h2><strong><center>Actividades</center></strong></h2>";
         AssignProp("", false, lblSubtitulo_Internalname, "Caption", lblSubtitulo_Caption, true);
      }

      private void E130V2( )
      {
         /* Gridparticipantes_Load Routine */
         returnInSub = false;
         AV5count = 0;
         AV13Usuarios.Load(A18ParticipanteTableroId);
         AV6nombre = AV13Usuarios.gxTpr_Usuarioemail + " - " + AV13Usuarios.gxTpr_Usuarionombre + " " + AV13Usuarios.gxTpr_Usuarioapellido;
         AssignAttri("", false, edtavNombre_Internalname, AV6nombre);
         /* Optimized group. */
         /* Using cursor H000V4 */
         pr_default.execute(2, new Object[] {A9TableroId, A12TareaId, A18ParticipanteTableroId});
         cV5count = H000V4_AV5count[0];
         pr_default.close(2);
         AV5count = (short)(AV5count+cV5count*1);
         /* End optimized group. */
         AV10t = AV5count;
         AssignAttri("", false, edtavT_Internalname, StringUtil.LTrimStr( (decimal)(AV10t), 4, 0));
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

      protected void E110V2( )
      {
         /* 'Nuevo' Routine */
         returnInSub = false;
         context.PopUp(formatLink("anadirtarea.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0))}, new string[] {"TableroId"}) , new Object[] {"A9TableroId"});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E150V2( )
      {
         /* 'PausaPlay' Routine */
         returnInSub = false;
         AV15Tareas2.Load(A9TableroId, A12TareaId);
         AV12Tareas.Load(A9TableroId, A12TareaId);
         if ( AV15Tareas2.gxTpr_Tareaestado == 2 )
         {
            AV12Tareas.gxTpr_Tareaestado = 4;
         }
         else if ( AV15Tareas2.gxTpr_Tareaestado == 4 )
         {
            AV12Tareas.gxTpr_Tareaestado = 2;
         }
         AV12Tareas.Save();
         if ( AV12Tareas.Success() )
         {
            context.CommitDataStores("listadoactividades",pr_default);
            context.DoAjaxRefresh();
         }
         else
         {
            context.RollbackDataStores("listadoactividades",pr_default);
         }
      }

      protected void E160V2( )
      {
         /* 'Iniciar' Routine */
         returnInSub = false;
         AV15Tareas2.Load(A9TableroId, A12TareaId);
         AV12Tareas.Load(A9TableroId, A12TareaId);
         if ( AV15Tareas2.gxTpr_Tareaestado == 1 )
         {
            AV12Tareas.gxTpr_Tareaestado = 2;
         }
         AV12Tareas.Save();
         if ( AV12Tareas.Success() )
         {
            context.CommitDataStores("listadoactividades",pr_default);
            context.DoAjaxRefresh();
         }
         else
         {
            context.RollbackDataStores("listadoactividades",pr_default);
         }
      }

      private void E140V4( )
      {
         /* Gridtareas_Load Routine */
         returnInSub = false;
         AV19actividades = context.GetImagePath( "50c20d82-0a7d-418e-8e91-2520156ff8df", "", context.GetTheme( ));
         AssignAttri("", false, edtavActividades_Internalname, AV19actividades);
         AV24Actividades_GXI = GXDbFile.PathToUrl( context.GetImagePath( "50c20d82-0a7d-418e-8e91-2520156ff8df", "", context.GetTheme( )));
         AV12Tareas.Load(A9TableroId, A12TareaId);
         if ( AV12Tareas.gxTpr_Responsableid != 0 )
         {
            AV8state = context.GetImagePath( "31259d64-c015-4774-9b0a-b45a79c24159", "", context.GetTheme( ));
            AssignAttri("", false, edtavState_Internalname, AV8state);
            AV25State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "31259d64-c015-4774-9b0a-b45a79c24159", "", context.GetTheme( )));
            AV14Usuarios2.Load(AV12Tareas.gxTpr_Responsableid);
            AV7Responsable = StringUtil.Trim( AV14Usuarios2.gxTpr_Usuarioemail) + " - " + AV14Usuarios2.gxTpr_Usuarionombre + " " + AV14Usuarios2.gxTpr_Usuarioapellido;
            AssignAttri("", false, edtavResponsable_Internalname, AV7Responsable);
         }
         else
         {
            AV8state = context.GetImagePath( "af695a2d-efff-4893-90bc-55652acff52a", "", context.GetTheme( ));
            AssignAttri("", false, edtavState_Internalname, AV8state);
            AV25State_GXI = GXDbFile.PathToUrl( context.GetImagePath( "af695a2d-efff-4893-90bc-55652acff52a", "", context.GetTheme( )));
            AV7Responsable = "Sin responsable asignado";
            AssignAttri("", false, edtavResponsable_Internalname, AV7Responsable);
         }
         if ( AV12Tareas.gxTpr_Tareaestado == 1 )
         {
            AV9state2 = context.GetImagePath( "1ecaff01-3fe8-49d0-9094-76c163a69ce8", "", context.GetTheme( ));
            AssignAttri("", false, edtavState2_Internalname, AV9state2);
            AV26State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "1ecaff01-3fe8-49d0-9094-76c163a69ce8", "", context.GetTheme( )));
            edtavStop_Visible = 0;
         }
         else if ( AV12Tareas.gxTpr_Tareaestado == 2 )
         {
            AV9state2 = context.GetImagePath( "9eed16cc-502d-4c66-a4e5-f47a9713bab0", "", context.GetTheme( ));
            AssignAttri("", false, edtavState2_Internalname, AV9state2);
            AV26State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "9eed16cc-502d-4c66-a4e5-f47a9713bab0", "", context.GetTheme( )));
            edtavStop_Visible = 1;
            AV17stop = context.GetImagePath( "2ac86f64-1ec7-466f-b8c7-066988857016", "", context.GetTheme( ));
            AssignAttri("", false, edtavStop_Internalname, AV17stop);
            AV27Stop_GXI = GXDbFile.PathToUrl( context.GetImagePath( "2ac86f64-1ec7-466f-b8c7-066988857016", "", context.GetTheme( )));
         }
         else if ( AV12Tareas.gxTpr_Tareaestado == 3 )
         {
            AV9state2 = context.GetImagePath( "63552255-35ba-4e00-8b53-9539f5d32760", "", context.GetTheme( ));
            AssignAttri("", false, edtavState2_Internalname, AV9state2);
            AV26State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "63552255-35ba-4e00-8b53-9539f5d32760", "", context.GetTheme( )));
            edtavStop_Visible = 0;
         }
         else if ( AV12Tareas.gxTpr_Tareaestado == 4 )
         {
            AV9state2 = context.GetImagePath( "cef39daf-d9a8-462d-9b0c-f8b6056364e8", "", context.GetTheme( ));
            AssignAttri("", false, edtavState2_Internalname, AV9state2);
            AV26State2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "cef39daf-d9a8-462d-9b0c-f8b6056364e8", "", context.GetTheme( )));
            edtavStop_Visible = 1;
            AV17stop = context.GetImagePath( "e18fac27-0e75-4842-8560-9dfaa60d377c", "", context.GetTheme( ));
            AssignAttri("", false, edtavStop_Internalname, AV17stop);
            AV27Stop_GXI = GXDbFile.PathToUrl( context.GetImagePath( "e18fac27-0e75-4842-8560-9dfaa60d377c", "", context.GetTheme( )));
         }
         if ( ( DateTimeUtil.ResetTime ( AV12Tareas.gxTpr_Tareafechainicio ) <= DateTimeUtil.ResetTime ( Gx_date ) ) && ( AV12Tareas.gxTpr_Tareaestado == 1 ) && ( DateTimeUtil.ResetTime ( AV12Tareas.gxTpr_Tareafechafin ) > DateTimeUtil.ResetTime ( Gx_date ) ) )
         {
            lblAdvisor_Caption = "<div class=\"alert alert-warning\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>Debes iniciar y terminar la tarea antes de la fecha de finalización."+StringUtil.NewLine( )+"</div>";
         }
         else if ( DateTimeUtil.ResetTime ( AV12Tareas.gxTpr_Tareafechafin ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            lblAdvisor_Caption = "<div class=\"alert alert-danger\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>La tarea ha vencido.  Completala o cambia las fechas de finalización"+StringUtil.NewLine( )+"</div>";
         }
         else if ( DateTimeUtil.ResetTime ( AV12Tareas.gxTpr_Tareafechafin ) == DateTimeUtil.ResetTime ( Gx_date ) )
         {
            lblAdvisor_Caption = "<div class=\"alert alert-info\" role=\"alert\">"+StringUtil.NewLine( )+"<strong>Atención: </strong>La tarea se vencerá hoy.  Debes completar esta tarea antes de la fecha de finalización"+StringUtil.NewLine( )+"</div>";
         }
         else
         {
            lblAdvisor_Caption = "";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 50;
         }
         sendrow_504( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_50_Refreshing )
         {
            context.DoAjaxLoad(50, GridtareasRow);
         }
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A9TableroId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "A9TableroId", StringUtil.LTrimStr( (decimal)(A9TableroId), 4, 0));
         A12TareaId = Convert.ToInt16(getParm(obj,1));
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
         PA0V2( ) ;
         WS0V2( ) ;
         WE0V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202291619471561", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("listadoactividades.js", "?202291619471561", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_182( )
      {
         edtParticipanteTableroId_Internalname = "PARTICIPANTETABLEROID_"+sGXsfl_18_idx;
         edtavNombre_Internalname = "vNOMBRE_"+sGXsfl_18_idx;
         edtRegistroFecha_Internalname = "REGISTROFECHA_"+sGXsfl_18_idx;
         dynParticipanteRolId_Internalname = "PARTICIPANTEROLID_"+sGXsfl_18_idx;
         edtavT_Internalname = "vT_"+sGXsfl_18_idx;
      }

      protected void SubsflControlProps_fel_182( )
      {
         edtParticipanteTableroId_Internalname = "PARTICIPANTETABLEROID_"+sGXsfl_18_fel_idx;
         edtavNombre_Internalname = "vNOMBRE_"+sGXsfl_18_fel_idx;
         edtRegistroFecha_Internalname = "REGISTROFECHA_"+sGXsfl_18_fel_idx;
         dynParticipanteRolId_Internalname = "PARTICIPANTEROLID_"+sGXsfl_18_fel_idx;
         edtavT_Internalname = "vT_"+sGXsfl_18_fel_idx;
      }

      protected void sendrow_182( )
      {
         SubsflControlProps_182( ) ;
         WB0V0( ) ;
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
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtavNombre_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridparticipantesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavNombre_Internalname,(string)"Nombre",(string)"col-xs-12 AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GridparticipantesRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavNombre_Internalname,StringUtil.RTrim( AV6nombre),(string)"",(string)"",(short)0,(short)1,(int)edtavNombre_Enabled,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtRegistroFecha_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridparticipantesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtRegistroFecha_Internalname,(string)"Colabora desde",(string)"col-xs-12 AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridparticipantesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRegistroFecha_Internalname,context.localUtil.TToC( A20RegistroFecha, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A20RegistroFecha, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRegistroFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)14,(string)"chr",(short)1,(string)"row",(short)14,(short)0,(short)0,(short)18,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+dynParticipanteRolId_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridparticipantesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)dynParticipanteRolId_Internalname,(string)"Rol",(string)"col-xs-12 AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         if ( ( dynParticipanteRolId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "PARTICIPANTEROLID_" + sGXsfl_18_idx;
            dynParticipanteRolId.Name = GXCCtl;
            dynParticipanteRolId.WebTags = "";
            dynParticipanteRolId.removeAllItems();
            /* Using cursor H000V5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               dynParticipanteRolId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000V5_A1RolId[0]), 4, 0)), H000V5_A2RolNombre[0], 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( dynParticipanteRolId.ItemCount > 0 )
            {
               A39ParticipanteRolId = (short)(NumberUtil.Val( dynParticipanteRolId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A39ParticipanteRolId), 4, 0))), "."));
            }
         }
         /* ComboBox */
         GridparticipantesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynParticipanteRolId,(string)dynParticipanteRolId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A39ParticipanteRolId), 4, 0)),(short)1,(string)dynParticipanteRolId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)1,(short)0,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"Attribute",(string)"",(string)"",(string)"",(string)"",(bool)true,(short)1});
         dynParticipanteRolId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A39ParticipanteRolId), 4, 0));
         AssignProp("", false, dynParticipanteRolId_Internalname, "Values", (string)(dynParticipanteRolId.ToJavascriptSource()), !bGXsfl_18_Refreshing);
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtavT_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridparticipantesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavT_Internalname,(string)"Tareas asignadas",(string)"col-xs-12 AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         GridparticipantesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridparticipantesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavT_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10t), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10t), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavT_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)18,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridparticipantesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes0V2( ) ;
         /* End of Columns property logic. */
         GridparticipantesContainer.AddRow(GridparticipantesRow);
         nGXsfl_18_idx = ((subGridparticipantes_Islastpage==1)&&(nGXsfl_18_idx+1>subGridparticipantes_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1);
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
         SubsflControlProps_182( ) ;
         /* End function sendrow_182 */
      }

      protected void SubsflControlProps_504( )
      {
         edtTareaId_Internalname = "TAREAID_"+sGXsfl_50_idx;
         lblAdvisor_Internalname = "ADVISOR_"+sGXsfl_50_idx;
         edtTareaNombre_Internalname = "TAREANOMBRE_"+sGXsfl_50_idx;
         edtavState2_Internalname = "vSTATE2_"+sGXsfl_50_idx;
         edtavStop_Internalname = "vSTOP_"+sGXsfl_50_idx;
         edtTareaFechaInicio_Internalname = "TAREAFECHAINICIO_"+sGXsfl_50_idx;
         edtTareaFechaFin_Internalname = "TAREAFECHAFIN_"+sGXsfl_50_idx;
         edtavResponsable_Internalname = "vRESPONSABLE_"+sGXsfl_50_idx;
         edtavState_Internalname = "vSTATE_"+sGXsfl_50_idx;
         edtavActividades_Internalname = "vACTIVIDADES_"+sGXsfl_50_idx;
      }

      protected void SubsflControlProps_fel_504( )
      {
         edtTareaId_Internalname = "TAREAID_"+sGXsfl_50_fel_idx;
         lblAdvisor_Internalname = "ADVISOR_"+sGXsfl_50_fel_idx;
         edtTareaNombre_Internalname = "TAREANOMBRE_"+sGXsfl_50_fel_idx;
         edtavState2_Internalname = "vSTATE2_"+sGXsfl_50_fel_idx;
         edtavStop_Internalname = "vSTOP_"+sGXsfl_50_fel_idx;
         edtTareaFechaInicio_Internalname = "TAREAFECHAINICIO_"+sGXsfl_50_fel_idx;
         edtTareaFechaFin_Internalname = "TAREAFECHAFIN_"+sGXsfl_50_fel_idx;
         edtavResponsable_Internalname = "vRESPONSABLE_"+sGXsfl_50_fel_idx;
         edtavState_Internalname = "vSTATE_"+sGXsfl_50_fel_idx;
         edtavActividades_Internalname = "vACTIVIDADES_"+sGXsfl_50_fel_idx;
      }

      protected void sendrow_504( )
      {
         SubsflControlProps_504( ) ;
         WB0V0( ) ;
         GridtareasRow = GXWebRow.GetNew(context,GridtareasContainer);
         if ( subGridtareas_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridtareas_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridtareas_Class, "") != 0 )
            {
               subGridtareas_Linesclass = subGridtareas_Class+"Odd";
            }
         }
         else if ( subGridtareas_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridtareas_Backstyle = 0;
            subGridtareas_Backcolor = subGridtareas_Allbackcolor;
            if ( StringUtil.StrCmp(subGridtareas_Class, "") != 0 )
            {
               subGridtareas_Linesclass = subGridtareas_Class+"Uniform";
            }
         }
         else if ( subGridtareas_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridtareas_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridtareas_Class, "") != 0 )
            {
               subGridtareas_Linesclass = subGridtareas_Class+"Odd";
            }
            subGridtareas_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridtareas_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridtareas_Backstyle = 1;
            if ( ((int)((nGXsfl_50_idx) % (2))) == 0 )
            {
               subGridtareas_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtareas_Class, "") != 0 )
               {
                  subGridtareas_Linesclass = subGridtareas_Class+"Even";
               }
            }
            else
            {
               subGridtareas_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridtareas_Class, "") != 0 )
               {
                  subGridtareas_Linesclass = subGridtareas_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridtareasContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridtareas_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_50_idx+"\">") ;
         }
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table1_Internalname+"_"+sGXsfl_50_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"TableWidget",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridtareasRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtTareaId_Internalname,(string)"Tarea Id",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         GridtareasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTareaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TareaId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12TareaId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTareaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtTareaId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)50,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         GridtareasRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblAdvisor_Internalname,(string)lblAdvisor_Caption,(string)"",(string)"",(string)lblAdvisor_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridtareasRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtTareaNombre_Internalname,(string)"Tarea Nombre",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         GridtareasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTareaNombre_Internalname,StringUtil.RTrim( A13TareaNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTareaNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)20,(string)"chr",(short)1,(string)"row",(short)20,(short)0,(short)0,(short)50,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2 col-md-1",(string)"left",(string)"Middle",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridtareasRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"state2",(string)"col-sm-3 ImageLabel",(short)0,(bool)true,(string)""});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavState2_Enabled!=0)&&(edtavState2_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 66,'',false,'',50)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV9state2_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV9state2))&&String.IsNullOrEmpty(StringUtil.RTrim( AV26State2_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV9state2)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV9state2)) ? AV26State2_GXI : context.PathToRelativeUrl( AV9state2));
         GridtareasRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavState2_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)5,(string)edtavState2_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'INICIAR\\'."+sGXsfl_50_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV9state2_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"Middle",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2 col-md-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridtareasRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"stop",(string)"col-sm-3 ImageLabel",(short)0,(bool)true,(string)""});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavStop_Enabled!=0)&&(edtavStop_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 69,'',false,'',50)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV17stop_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV17stop))&&String.IsNullOrEmpty(StringUtil.RTrim( AV27Stop_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV17stop)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV17stop)) ? AV27Stop_GXI : context.PathToRelativeUrl( AV17stop));
         GridtareasRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavStop_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavStop_Visible,(short)1,(string)"",(string)"",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)5,(string)edtavStop_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'PAUSAPLAY\\'."+sGXsfl_50_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV17stop_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtTareaFechaInicio_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridtareasRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtTareaFechaInicio_Internalname,(string)"Inicia",(string)"col-xs-12 AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridtareasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTareaFechaInicio_Internalname,context.localUtil.Format(A24TareaFechaInicio, "99/99/99"),context.localUtil.Format( A24TareaFechaInicio, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTareaFechaInicio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)8,(string)"chr",(short)1,(string)"row",(short)8,(short)0,(short)0,(short)50,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtTareaFechaFin_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridtareasRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtTareaFechaFin_Internalname,(string)"Finaliza",(string)"col-xs-12 AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridtareasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTareaFechaFin_Internalname,context.localUtil.Format(A25TareaFechaFin, "99/99/99"),context.localUtil.Format( A25TareaFechaFin, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTareaFechaFin_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)8,(string)"chr",(short)1,(string)"row",(short)8,(short)0,(short)0,(short)50,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2 col-md-5",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtavResponsable_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridtareasRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavResponsable_Internalname,(string)"Responsable",(string)"col-xs-12 AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridtareasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResponsable_Internalname,StringUtil.RTrim( AV7Responsable),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResponsable_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavResponsable_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)50,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         sendrow_50430( ) ;
      }

      protected void sendrow_50430( )
      {
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"Middle",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridtareasRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"state",(string)"col-sm-3 ImageLabel",(short)0,(bool)true,(string)""});
         /* Static Bitmap Variable */
         ClassString = "Image";
         StyleString = "";
         AV8state_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV8state))&&String.IsNullOrEmpty(StringUtil.RTrim( AV25State_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV8state)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV8state)) ? AV25State_GXI : context.PathToRelativeUrl( AV8state));
         GridtareasRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavState_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV8state_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"Middle",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridtareasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridtareasRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"actividades",(string)"col-sm-3 ImageLabel",(short)0,(bool)true,(string)""});
         /* Static Bitmap Variable */
         ClassString = "Image";
         StyleString = "";
         AV19actividades_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV19actividades))&&String.IsNullOrEmpty(StringUtil.RTrim( AV24Actividades_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV19actividades)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV19actividades)) ? AV24Actividades_GXI : context.PathToRelativeUrl( AV19actividades));
         GridtareasRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavActividades_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV19actividades_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridtareasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes0V4( ) ;
         /* End of Columns property logic. */
         GridtareasContainer.AddRow(GridtareasRow);
         nGXsfl_50_idx = ((subGridtareas_Islastpage==1)&&(nGXsfl_50_idx+1>subGridtareas_fnc_Recordsperpage( )) ? 1 : nGXsfl_50_idx+1);
         sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
         SubsflControlProps_504( ) ;
         /* End function sendrow_504 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "PARTICIPANTEROLID_" + sGXsfl_18_idx;
         dynParticipanteRolId.Name = GXCCtl;
         dynParticipanteRolId.WebTags = "";
         dynParticipanteRolId.removeAllItems();
         /* Using cursor H000V6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            dynParticipanteRolId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000V6_A1RolId[0]), 4, 0)), H000V6_A2RolNombre[0], 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         if ( dynParticipanteRolId.ItemCount > 0 )
         {
            A39ParticipanteRolId = (short)(NumberUtil.Val( dynParticipanteRolId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A39ParticipanteRolId), 4, 0))), "."));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitulo_Internalname = "TITULO";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtParticipanteTableroId_Internalname = "PARTICIPANTETABLEROID";
         edtavNombre_Internalname = "vNOMBRE";
         edtRegistroFecha_Internalname = "REGISTROFECHA";
         dynParticipanteRolId_Internalname = "PARTICIPANTEROLID";
         edtavT_Internalname = "vT";
         divGrid1table_Internalname = "GRID1TABLE";
         divTable2_Internalname = "TABLE2";
         divTable1_Internalname = "TABLE1";
         lblSubtitulo_Internalname = "SUBTITULO";
         imgImage1_Internalname = "IMAGE1";
         edtTareaId_Internalname = "TAREAID";
         lblAdvisor_Internalname = "ADVISOR";
         edtTareaNombre_Internalname = "TAREANOMBRE";
         edtavState2_Internalname = "vSTATE2";
         edtavStop_Internalname = "vSTOP";
         edtTareaFechaInicio_Internalname = "TAREAFECHAINICIO";
         edtTareaFechaFin_Internalname = "TAREAFECHAFIN";
         edtavResponsable_Internalname = "vRESPONSABLE";
         edtavState_Internalname = "vSTATE";
         edtavActividades_Internalname = "vACTIVIDADES";
         divGrid1table1_Internalname = "GRID1TABLE1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridparticipantes_Internalname = "GRIDPARTICIPANTES";
         subGridtareas_Internalname = "GRIDTAREAS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavResponsable_Jsonclick = "";
         edtTareaFechaFin_Jsonclick = "";
         edtTareaFechaInicio_Jsonclick = "";
         edtavStop_Jsonclick = "";
         edtavStop_Enabled = 1;
         edtavState2_Jsonclick = "";
         edtavState2_Visible = 1;
         edtavState2_Enabled = 1;
         edtTareaNombre_Jsonclick = "";
         lblAdvisor_Caption = "";
         edtTareaId_Jsonclick = "";
         subGridtareas_Class = "FreeStyleGrid";
         edtavT_Jsonclick = "";
         dynParticipanteRolId_Jsonclick = "";
         edtRegistroFecha_Jsonclick = "";
         edtParticipanteTableroId_Jsonclick = "";
         subGridparticipantes_Class = "FreeStyleGrid";
         subGridtareas_Allowcollapsing = 0;
         edtavResponsable_Enabled = 0;
         edtavStop_Visible = 1;
         lblAdvisor_Caption = "";
         edtTareaId_Visible = 1;
         subGridtareas_Backcolorstyle = 0;
         lblSubtitulo_Caption = "Text Block";
         subGridparticipantes_Allowcollapsing = 0;
         edtavNombre_Enabled = 0;
         edtParticipanteTableroId_Visible = 1;
         subGridparticipantes_Backcolorstyle = 0;
         lblTitulo_Caption = "Text Block";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Listado Actividades";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDPARTICIPANTES_nFirstRecordOnPage'},{av:'GRIDPARTICIPANTES_nEOF'},{av:'A23ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9'},{av:'GRIDTAREAS_nFirstRecordOnPage'},{av:'GRIDTAREAS_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDPARTICIPANTES.LOAD","{handler:'E130V2',iparms:[{av:'A18ParticipanteTableroId',fld:'PARTICIPANTETABLEROID',pic:'ZZZ9'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A23ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9'}]");
         setEventMetadata("GRIDPARTICIPANTES.LOAD",",oparms:[{av:'AV6nombre',fld:'vNOMBRE',pic:''},{av:'AV10t',fld:'vT',pic:'ZZZ9'}]}");
         setEventMetadata("GRIDTAREAS.LOAD","{handler:'E140V4',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("GRIDTAREAS.LOAD",",oparms:[{av:'AV19actividades',fld:'vACTIVIDADES',pic:''},{av:'AV8state',fld:'vSTATE',pic:''},{av:'AV7Responsable',fld:'vRESPONSABLE',pic:''},{av:'AV9state2',fld:'vSTATE2',pic:''},{av:'edtavStop_Visible',ctrl:'vSTOP',prop:'Visible'},{av:'AV17stop',fld:'vSTOP',pic:''},{av:'lblAdvisor_Caption',ctrl:'ADVISOR',prop:'Caption'}]}");
         setEventMetadata("'NUEVO'","{handler:'E110V2',iparms:[{av:'GRIDPARTICIPANTES_nFirstRecordOnPage'},{av:'GRIDPARTICIPANTES_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A23ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'GRIDTAREAS_nFirstRecordOnPage'},{av:'GRIDTAREAS_nEOF'},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'NUEVO'",",oparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("'PAUSAPLAY'","{handler:'E150V2',iparms:[{av:'GRIDPARTICIPANTES_nFirstRecordOnPage'},{av:'GRIDPARTICIPANTES_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A23ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'GRIDTAREAS_nFirstRecordOnPage'},{av:'GRIDTAREAS_nEOF'}]");
         setEventMetadata("'PAUSAPLAY'",",oparms:[]}");
         setEventMetadata("'INICIAR'","{handler:'E160V2',iparms:[{av:'GRIDPARTICIPANTES_nFirstRecordOnPage'},{av:'GRIDPARTICIPANTES_nEOF'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'},{av:'A23ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'A12TareaId',fld:'TAREAID',pic:'ZZZ9',hsh:true},{av:'GRIDTAREAS_nFirstRecordOnPage'},{av:'GRIDTAREAS_nEOF'}]");
         setEventMetadata("'INICIAR'",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_T',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALID_TAREAID","{handler:'Valid_Tareaid',iparms:[]");
         setEventMetadata("VALID_TAREAID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Actividades',iparms:[]");
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
         Gx_date = DateTime.MinValue;
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
         subGridparticipantes_Header = "";
         GridparticipantesColumn = new GXWebColumn();
         AV6nombre = "";
         A20RegistroFecha = (DateTime)(DateTime.MinValue);
         lblSubtitulo_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         imgImage1_Jsonclick = "";
         GridtareasContainer = new GXWebGrid( context);
         subGridtareas_Header = "";
         GridtareasColumn = new GXWebColumn();
         A13TareaNombre = "";
         AV9state2 = "";
         AV17stop = "";
         A24TareaFechaInicio = DateTime.MinValue;
         A25TareaFechaFin = DateTime.MinValue;
         AV7Responsable = "";
         AV8state = "";
         AV19actividades = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV26State2_GXI = "";
         AV27Stop_GXI = "";
         AV25State_GXI = "";
         AV24Actividades_GXI = "";
         scmdbuf = "";
         H000V2_A9TableroId = new short[1] ;
         H000V2_A18ParticipanteTableroId = new short[1] ;
         H000V2_A39ParticipanteRolId = new short[1] ;
         H000V2_A20RegistroFecha = new DateTime[] {DateTime.MinValue} ;
         H000V3_A9TableroId = new short[1] ;
         H000V3_A12TareaId = new short[1] ;
         H000V3_A25TareaFechaFin = new DateTime[] {DateTime.MinValue} ;
         H000V3_A24TareaFechaInicio = new DateTime[] {DateTime.MinValue} ;
         H000V3_A13TareaNombre = new string[] {""} ;
         AV12Tareas = new SdtTareas(context);
         AV13Usuarios = new SdtUsuarios(context);
         H000V4_AV5count = new short[1] ;
         GridparticipantesRow = new GXWebRow();
         AV15Tareas2 = new SdtTareas(context);
         AV14Usuarios2 = new SdtUsuarios(context);
         GridtareasRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridparticipantes_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         H000V5_A1RolId = new short[1] ;
         H000V5_A2RolNombre = new string[] {""} ;
         subGridtareas_Linesclass = "";
         lblAdvisor_Jsonclick = "";
         H000V6_A1RolId = new short[1] ;
         H000V6_A2RolNombre = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listadoactividades__default(),
            new Object[][] {
                new Object[] {
               H000V2_A9TableroId, H000V2_A18ParticipanteTableroId, H000V2_A39ParticipanteRolId, H000V2_A20RegistroFecha
               }
               , new Object[] {
               H000V3_A9TableroId, H000V3_A12TareaId, H000V3_A25TareaFechaFin, H000V3_A24TareaFechaInicio, H000V3_A13TareaNombre
               }
               , new Object[] {
               H000V4_AV5count
               }
               , new Object[] {
               H000V5_A1RolId, H000V5_A2RolNombre
               }
               , new Object[] {
               H000V6_A1RolId, H000V6_A2RolNombre
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
         edtParticipanteTableroId_Visible = 0;
         edtTareaId_Visible = 0;
         edtavNombre_Enabled = 0;
         edtavResponsable_Enabled = 0;
      }

      private short A9TableroId ;
      private short A12TareaId ;
      private short wcpOA9TableroId ;
      private short wcpOA12TareaId ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short A23ResponsableId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridparticipantes_Backcolorstyle ;
      private short A18ParticipanteTableroId ;
      private short A39ParticipanteRolId ;
      private short AV10t ;
      private short subGridparticipantes_Allowselection ;
      private short subGridparticipantes_Allowhovering ;
      private short subGridparticipantes_Allowcollapsing ;
      private short subGridparticipantes_Collapsed ;
      private short subGridtareas_Backcolorstyle ;
      private short subGridtareas_Allowselection ;
      private short subGridtareas_Allowhovering ;
      private short subGridtareas_Allowcollapsing ;
      private short subGridtareas_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV5count ;
      private short cV5count ;
      private short GRIDPARTICIPANTES_nEOF ;
      private short GRIDTAREAS_nEOF ;
      private short subGridparticipantes_Backstyle ;
      private short subGridtareas_Backstyle ;
      private int nRC_GXsfl_18 ;
      private int nRC_GXsfl_50 ;
      private int nGXsfl_18_idx=1 ;
      private int nGXsfl_50_idx=1 ;
      private int edtParticipanteTableroId_Visible ;
      private int edtavNombre_Enabled ;
      private int subGridparticipantes_Selectedindex ;
      private int subGridparticipantes_Selectioncolor ;
      private int subGridparticipantes_Hoveringcolor ;
      private int edtTareaId_Visible ;
      private int edtavStop_Visible ;
      private int edtavResponsable_Enabled ;
      private int subGridtareas_Selectedindex ;
      private int subGridtareas_Selectioncolor ;
      private int subGridtareas_Hoveringcolor ;
      private int subGridparticipantes_Islastpage ;
      private int subGridtareas_Islastpage ;
      private int idxLst ;
      private int subGridparticipantes_Backcolor ;
      private int subGridparticipantes_Allbackcolor ;
      private int subGridtareas_Backcolor ;
      private int subGridtareas_Allbackcolor ;
      private int edtavState2_Enabled ;
      private int edtavState2_Visible ;
      private int edtavStop_Enabled ;
      private long GRIDPARTICIPANTES_nCurrentRecord ;
      private long GRIDTAREAS_nCurrentRecord ;
      private long GRIDPARTICIPANTES_nFirstRecordOnPage ;
      private long GRIDTAREAS_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_18_idx="0001" ;
      private string sGXsfl_50_idx="0001" ;
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
      private string subGridparticipantes_Header ;
      private string AV6nombre ;
      private string lblSubtitulo_Internalname ;
      private string lblSubtitulo_Caption ;
      private string lblSubtitulo_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage1_Internalname ;
      private string imgImage1_Jsonclick ;
      private string subGridtareas_Internalname ;
      private string subGridtareas_Header ;
      private string lblAdvisor_Caption ;
      private string A13TareaNombre ;
      private string AV7Responsable ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtParticipanteTableroId_Internalname ;
      private string edtavNombre_Internalname ;
      private string edtRegistroFecha_Internalname ;
      private string dynParticipanteRolId_Internalname ;
      private string edtavT_Internalname ;
      private string edtTareaId_Internalname ;
      private string edtTareaNombre_Internalname ;
      private string edtavState2_Internalname ;
      private string edtavStop_Internalname ;
      private string edtTareaFechaInicio_Internalname ;
      private string edtTareaFechaFin_Internalname ;
      private string edtavResponsable_Internalname ;
      private string edtavState_Internalname ;
      private string edtavActividades_Internalname ;
      private string scmdbuf ;
      private string sGXsfl_18_fel_idx="0001" ;
      private string subGridparticipantes_Class ;
      private string subGridparticipantes_Linesclass ;
      private string divGrid1table_Internalname ;
      private string ROClassString ;
      private string edtParticipanteTableroId_Jsonclick ;
      private string edtRegistroFecha_Jsonclick ;
      private string GXCCtl ;
      private string dynParticipanteRolId_Jsonclick ;
      private string edtavT_Jsonclick ;
      private string lblAdvisor_Internalname ;
      private string sGXsfl_50_fel_idx="0001" ;
      private string subGridtareas_Class ;
      private string subGridtareas_Linesclass ;
      private string divGrid1table1_Internalname ;
      private string edtTareaId_Jsonclick ;
      private string lblAdvisor_Jsonclick ;
      private string edtTareaNombre_Jsonclick ;
      private string edtavState2_Jsonclick ;
      private string edtavStop_Jsonclick ;
      private string edtTareaFechaInicio_Jsonclick ;
      private string edtTareaFechaFin_Jsonclick ;
      private string edtavResponsable_Jsonclick ;
      private DateTime A20RegistroFecha ;
      private DateTime Gx_date ;
      private DateTime A24TareaFechaInicio ;
      private DateTime A25TareaFechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n23ResponsableId ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_50_Refreshing=false ;
      private bool bGXsfl_18_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9state2_IsBlob ;
      private bool AV17stop_IsBlob ;
      private bool AV8state_IsBlob ;
      private bool AV19actividades_IsBlob ;
      private string AV26State2_GXI ;
      private string AV27Stop_GXI ;
      private string AV25State_GXI ;
      private string AV24Actividades_GXI ;
      private string AV9state2 ;
      private string AV17stop ;
      private string AV8state ;
      private string AV19actividades ;
      private GXWebGrid GridparticipantesContainer ;
      private GXWebGrid GridtareasContainer ;
      private GXWebRow GridparticipantesRow ;
      private GXWebRow GridtareasRow ;
      private GXWebColumn GridparticipantesColumn ;
      private GXWebColumn GridtareasColumn ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private short aP1_TareaId ;
      private GXCombobox dynParticipanteRolId ;
      private IDataStoreProvider pr_default ;
      private short[] H000V2_A9TableroId ;
      private short[] H000V2_A18ParticipanteTableroId ;
      private short[] H000V2_A39ParticipanteRolId ;
      private DateTime[] H000V2_A20RegistroFecha ;
      private short[] H000V3_A9TableroId ;
      private short[] H000V3_A12TareaId ;
      private DateTime[] H000V3_A25TareaFechaFin ;
      private DateTime[] H000V3_A24TareaFechaInicio ;
      private string[] H000V3_A13TareaNombre ;
      private short[] H000V4_AV5count ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] H000V5_A1RolId ;
      private string[] H000V5_A2RolNombre ;
      private short[] H000V6_A1RolId ;
      private string[] H000V6_A2RolNombre ;
      private GXWebForm Form ;
      private SdtTareas AV12Tareas ;
      private SdtTareas AV15Tareas2 ;
      private SdtUsuarios AV13Usuarios ;
      private SdtUsuarios AV14Usuarios2 ;
   }

   public class listadoactividades__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000V2;
          prmH000V2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmH000V3;
          prmH000V3 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmH000V4;
          prmH000V4 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmH000V5;
          prmH000V5 = new Object[] {
          };
          Object[] prmH000V6;
          prmH000V6 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H000V2", "SELECT [TableroId], [ParticipanteTableroId], [ParticipanteRolId], [RegistroFecha] FROM [Participantes] WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000V3", "SELECT [TableroId], [TareaId], [TareaFechaFin], [TareaFechaInicio], [TareaNombre] FROM [Tareas] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ORDER BY [TableroId], [TareaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H000V4", "SELECT COUNT(*) FROM [Tareas] WHERE ([TableroId] = @TableroId and [TareaId] = @TareaId) AND ([ResponsableId] = @ParticipanteTableroId) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000V5", "SELECT [RolId], [RolNombre] FROM [Roles] ORDER BY [RolNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000V6", "SELECT [RolId], [RolNombre] FROM [Roles] ORDER BY [RolNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V6,0, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
       }
    }

 }

}
