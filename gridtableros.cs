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
   public class gridtableros : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public gridtableros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
      }

      public gridtableros( IGxContext context )
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavTableroestado = new GXCombobox();
         chkTableroEstado = new GXCheckbox();
         chkTableroVisibilidad = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
               {
                  nRC_GXsfl_17 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_17"), "."));
                  nGXsfl_17_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_17_idx"), "."));
                  sGXsfl_17_idx = GetPar( "sGXsfl_17_idx");
                  sPrefix = GetPar( "sPrefix");
                  edtTableroFechaCreacion_Horizontalalignment = GetNextPar( );
                  AssignProp(sPrefix, false, edtTableroFechaCreacion_Internalname, "Horizontalalignment", edtTableroFechaCreacion_Horizontalalignment, !bGXsfl_17_Refreshing);
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrGrid1_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
               {
                  cmbavTableroestado.FromJSonString( GetNextPar( ));
                  AV11TableroEstado = StringUtil.StrToBool( GetPar( "TableroEstado"));
                  edtTableroFechaCreacion_Horizontalalignment = GetNextPar( );
                  AssignProp(sPrefix, false, edtTableroFechaCreacion_Internalname, "Horizontalalignment", edtTableroFechaCreacion_Horizontalalignment, !bGXsfl_17_Refreshing);
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid1_refresh( AV11TableroEstado, sPrefix) ;
                  GxWebStd.gx_hidden_field( context, sPrefix+"TABLEROFECHACREACION_Horizontalalignment", StringUtil.RTrim( edtTableroFechaCreacion_Horizontalalignment));
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
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0L2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS0L2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Grid Tableros") ;
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
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1940340), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20229920473932", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1940340), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 1940340), false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gridtableros.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTABLEROESTADO", StringUtil.BoolToStr( AV11TableroEstado));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_17", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_17), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABLEROFECHACREACION_Horizontalalignment", StringUtil.RTrim( edtTableroFechaCreacion_Horizontalalignment));
      }

      protected void RenderHtmlCloseForm0L2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "GridTableros" ;
      }

      public override string GetPgmdesc( )
      {
         return "Grid Tableros" ;
      }

      protected void WB0L0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "gridtableros.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tableros en los que soy propietario", "", "", lblTextblock1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_GridTableros.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "37af6e8e-5105-40d2-94ea-61da60f7a7ab", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Añadir nuevo tablero", 0, 0, 0, "px", 35, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'NUEVO\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_GridTableros.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavTableroestado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTableroestado_Internalname, "Tablero Estado", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'" + sGXsfl_17_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTableroestado, cmbavTableroestado_Internalname, StringUtil.BoolToStr( AV11TableroEstado), 1, cmbavTableroestado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavTableroestado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "", true, 1, "HLP_GridTableros.htm");
            cmbavTableroestado.CurrentValue = StringUtil.BoolToStr( AV11TableroEstado);
            AssignProp(sPrefix, false, cmbavTableroestado_Internalname, "Values", (string)(cmbavTableroestado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"Grid1Container"+"DivS\" data-gxgridid=\"17\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(35), 4, 0)+"px"+" class=\""+"Image"+"\" "+" style=\""+((edtavEditar_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(35), 4, 0)+"px"+" class=\""+"Image"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(5), 4, 0)+"%"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+edtTableroFechaCreacion_Horizontalalignment+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"%"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Creado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(60), 4, 0)+"%"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Propietario Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Tablero Estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Tablero Visibilidad") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(30), 4, 0)+"px"+" class=\""+"Image"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(35), 4, 0)+"px"+" class=\""+"Image"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(35), 4, 0)+"px"+" class=\""+"Image"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "WorkWith");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", sPrefix);
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV5editar));
               Grid1Column.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavEditar_Tooltiptext));
               Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEditar_Visible), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV6eliminar));
               Grid1Column.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavEliminar_Tooltiptext));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A11TableroFechaCreacion, 10, 8, 0, 3, "/", ":", " "));
               Grid1Column.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtTableroFechaCreacion_Horizontalalignment));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A10TableroNombre));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A17PropietarioId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A34TableroEstado));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A35TableroVisibilidad));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV13Tareas));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV7estado));
               Grid1Column.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavEstado_Tooltiptext));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV8equipo));
               Grid1Column.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavEquipo_Tooltiptext));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 17 )
         {
            wbEnd = 0;
            nRC_GXsfl_17 = (int)(nGXsfl_17_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid1", Grid1Container);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 17 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid1", Grid1Container);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0L2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_8-158023", 0) ;
               }
               Form.Meta.addItem("description", "Grid Tableros", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0L0( ) ;
            }
         }
      }

      protected void WS0L2( )
      {
         START0L2( ) ;
         EVT0L2( ) ;
      }

      protected void EVT0L2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'NUEVO'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Nuevo' */
                                    E110L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavTableroestado_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'EDITAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'ELIMINAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "'VISIBILIDAD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "'COLABORADORES'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'EDITAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'ELIMINAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "'VISIBILIDAD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "'COLABORADORES'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              nGXsfl_17_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_17_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_17_idx), 4, 0), 4, "0");
                              SubsflControlProps_172( ) ;
                              AV5editar = cgiGet( edtavEditar_Internalname);
                              AssignProp(sPrefix, false, edtavEditar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5editar)) ? AV18Editar_GXI : context.convertURL( context.PathToRelativeUrl( AV5editar))), !bGXsfl_17_Refreshing);
                              AssignProp(sPrefix, false, edtavEditar_Internalname, "SrcSet", context.GetImageSrcSet( AV5editar), true);
                              AV6eliminar = cgiGet( edtavEliminar_Internalname);
                              AssignProp(sPrefix, false, edtavEliminar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV6eliminar)) ? AV17Eliminar_GXI : context.convertURL( context.PathToRelativeUrl( AV6eliminar))), !bGXsfl_17_Refreshing);
                              AssignProp(sPrefix, false, edtavEliminar_Internalname, "SrcSet", context.GetImageSrcSet( AV6eliminar), true);
                              A9TableroId = (short)(context.localUtil.CToN( cgiGet( edtTableroId_Internalname), ",", "."));
                              A11TableroFechaCreacion = context.localUtil.CToT( cgiGet( edtTableroFechaCreacion_Internalname), 0);
                              A10TableroNombre = cgiGet( edtTableroNombre_Internalname);
                              A17PropietarioId = (short)(context.localUtil.CToN( cgiGet( edtPropietarioId_Internalname), ",", "."));
                              A34TableroEstado = StringUtil.StrToBool( cgiGet( chkTableroEstado_Internalname));
                              A35TableroVisibilidad = StringUtil.StrToBool( cgiGet( chkTableroVisibilidad_Internalname));
                              AV13Tareas = cgiGet( edtavTareas_Internalname);
                              AssignProp(sPrefix, false, edtavTareas_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13Tareas)) ? AV16Tareas_GXI : context.convertURL( context.PathToRelativeUrl( AV13Tareas))), !bGXsfl_17_Refreshing);
                              AssignProp(sPrefix, false, edtavTareas_Internalname, "SrcSet", context.GetImageSrcSet( AV13Tareas), true);
                              AV7estado = cgiGet( edtavEstado_Internalname);
                              AssignProp(sPrefix, false, edtavEstado_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV7estado)) ? AV20Estado_GXI : context.convertURL( context.PathToRelativeUrl( AV7estado))), !bGXsfl_17_Refreshing);
                              AssignProp(sPrefix, false, edtavEstado_Internalname, "SrcSet", context.GetImageSrcSet( AV7estado), true);
                              AV8equipo = cgiGet( edtavEquipo_Internalname);
                              AssignProp(sPrefix, false, edtavEquipo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8equipo)) ? AV19Equipo_GXI : context.convertURL( context.PathToRelativeUrl( AV8equipo))), !bGXsfl_17_Refreshing);
                              AssignProp(sPrefix, false, edtavEquipo_Internalname, "SrcSet", context.GetImageSrcSet( AV8equipo), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavTableroestado_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E120L2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavTableroestado_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Load */
                                          E130L2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'EDITAR'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavTableroestado_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Editar' */
                                          E140L2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'ELIMINAR'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavTableroestado_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Eliminar' */
                                          E150L2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'VISIBILIDAD'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavTableroestado_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Visibilidad' */
                                          E160L2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'COLABORADORES'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavTableroestado_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Colaboradores' */
                                          E170L2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Tableroestado Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vTABLEROESTADO")) != AV11TableroEstado )
                                             {
                                                Rfr0gs = true;
                                             }
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP0L0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavTableroestado_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
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

      protected void WE0L2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0L2( ) ;
            }
         }
      }

      protected void PA0L2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = cmbavTableroestado_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_172( ) ;
         while ( nGXsfl_17_idx <= nRC_GXsfl_17 )
         {
            sendrow_172( ) ;
            nGXsfl_17_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_17_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_17_idx+1);
            sGXsfl_17_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_17_idx), 4, 0), 4, "0");
            SubsflControlProps_172( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( bool AV11TableroEstado ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0L2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_TABLEROESTADO", GetSecureSignedToken( sPrefix, A34TableroEstado, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABLEROESTADO", StringUtil.BoolToStr( A34TableroEstado));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_TABLEROVISIBILIDAD", GetSecureSignedToken( sPrefix, A35TableroVisibilidad, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABLEROVISIBILIDAD", StringUtil.BoolToStr( A35TableroVisibilidad));
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
         if ( cmbavTableroestado.ItemCount > 0 )
         {
            AV11TableroEstado = StringUtil.StrToBool( cmbavTableroestado.getValidValue(StringUtil.BoolToStr( AV11TableroEstado)));
            AssignAttri(sPrefix, false, "AV11TableroEstado", AV11TableroEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTableroestado.CurrentValue = StringUtil.BoolToStr( AV11TableroEstado);
            AssignProp(sPrefix, false, cmbavTableroestado_Internalname, "Values", cmbavTableroestado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF0L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 17;
         nGXsfl_17_idx = 1;
         sGXsfl_17_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_17_idx), 4, 0), 4, "0");
         SubsflControlProps_172( ) ;
         bGXsfl_17_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", sPrefix);
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "WorkWith");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_172( ) ;
            /* Using cursor H000L2 */
            pr_default.execute(0, new Object[] {AV11TableroEstado});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A35TableroVisibilidad = H000L2_A35TableroVisibilidad[0];
               A34TableroEstado = H000L2_A34TableroEstado[0];
               A17PropietarioId = H000L2_A17PropietarioId[0];
               A10TableroNombre = H000L2_A10TableroNombre[0];
               A11TableroFechaCreacion = H000L2_A11TableroFechaCreacion[0];
               A9TableroId = H000L2_A9TableroId[0];
               /* Execute user event: Load */
               E130L2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 17;
            WB0L0( ) ;
         }
         bGXsfl_17_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0L2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_TABLEROESTADO"+"_"+sGXsfl_17_idx, GetSecureSignedToken( sPrefix+sGXsfl_17_idx, A34TableroEstado, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_TABLEROVISIBILIDAD"+"_"+sGXsfl_17_idx, GetSecureSignedToken( sPrefix+sGXsfl_17_idx, A35TableroVisibilidad, context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120L2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_17 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_17"), ",", "."));
            /* Read variables values. */
            cmbavTableroestado.Name = cmbavTableroestado_Internalname;
            cmbavTableroestado.CurrentValue = cgiGet( cmbavTableroestado_Internalname);
            AV11TableroEstado = StringUtil.StrToBool( cgiGet( cmbavTableroestado_Internalname));
            AssignAttri(sPrefix, false, "AV11TableroEstado", AV11TableroEstado);
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
         E120L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120L2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtTableroFechaCreacion_Horizontalalignment = "Left";
         AssignProp(sPrefix, false, edtTableroFechaCreacion_Internalname, "Horizontalalignment", edtTableroFechaCreacion_Horizontalalignment, !bGXsfl_17_Refreshing);
         AV11TableroEstado = true;
         AssignAttri(sPrefix, false, "AV11TableroEstado", AV11TableroEstado);
      }

      private void E130L2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV13Tareas = context.GetImagePath( "4e5cde33-ed10-4143-9ff4-72384d8ea839", "", context.GetTheme( ));
         AssignAttri(sPrefix, false, edtavTareas_Internalname, AV13Tareas);
         AV16Tareas_GXI = GXDbFile.PathToUrl( context.GetImagePath( "4e5cde33-ed10-4143-9ff4-72384d8ea839", "", context.GetTheme( )));
         if ( A34TableroEstado )
         {
            AV6eliminar = context.GetImagePath( "6223fef3-3dcc-4cb5-990c-8733d6fa82e5", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavEliminar_Internalname, AV6eliminar);
            AV17Eliminar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6223fef3-3dcc-4cb5-990c-8733d6fa82e5", "", context.GetTheme( )));
            edtavEliminar_Tooltiptext = "Eliminar tablero";
            AV5editar = context.GetImagePath( "233ba323-0fd2-45f9-9408-b63d9060ab9c", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavEditar_Internalname, AV5editar);
            AV18Editar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "233ba323-0fd2-45f9-9408-b63d9060ab9c", "", context.GetTheme( )));
            edtavEditar_Tooltiptext = "Editar tablero";
            edtavEditar_Visible = 1;
         }
         else
         {
            AV6eliminar = context.GetImagePath( "c8c2aa84-c3db-476f-9838-e40b83d21628", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavEliminar_Internalname, AV6eliminar);
            AV17Eliminar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "c8c2aa84-c3db-476f-9838-e40b83d21628", "", context.GetTheme( )));
            edtavEditar_Visible = 0;
         }
         AV8equipo = context.GetImagePath( "51c0fd32-f2ce-4ef7-8483-ca1228eb25fb", "", context.GetTheme( ));
         AssignAttri(sPrefix, false, edtavEquipo_Internalname, AV8equipo);
         AV19Equipo_GXI = GXDbFile.PathToUrl( context.GetImagePath( "51c0fd32-f2ce-4ef7-8483-ca1228eb25fb", "", context.GetTheme( )));
         GXt_int1 = AV9cantidadParticipantes;
         new getnumerointegrantes(context ).execute(  A9TableroId, out  GXt_int1) ;
         AV9cantidadParticipantes = GXt_int1;
         if ( AV9cantidadParticipantes == 0 )
         {
            edtavEquipo_Tooltiptext = "No tienes participantes en este tablero";
            AV8equipo = context.GetImagePath( "bb7a391f-c680-4dda-a5e1-eac294199777", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavEquipo_Internalname, AV8equipo);
            AV19Equipo_GXI = GXDbFile.PathToUrl( context.GetImagePath( "bb7a391f-c680-4dda-a5e1-eac294199777", "", context.GetTheme( )));
         }
         else
         {
            edtavEquipo_Tooltiptext = "Cuentas con "+StringUtil.Trim( StringUtil.Str( (decimal)(AV9cantidadParticipantes), 4, 0))+" participante(s) en este tablero";
            AV8equipo = context.GetImagePath( "51c0fd32-f2ce-4ef7-8483-ca1228eb25fb", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavEquipo_Internalname, AV8equipo);
            AV19Equipo_GXI = GXDbFile.PathToUrl( context.GetImagePath( "51c0fd32-f2ce-4ef7-8483-ca1228eb25fb", "", context.GetTheme( )));
         }
         if ( A35TableroVisibilidad )
         {
            edtavEstado_Tooltiptext = "Tu tablero es visible";
            AV7estado = context.GetImagePath( "834ab801-23a9-4314-84c2-01ace3feeb09", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavEstado_Internalname, AV7estado);
            AV20Estado_GXI = GXDbFile.PathToUrl( context.GetImagePath( "834ab801-23a9-4314-84c2-01ace3feeb09", "", context.GetTheme( )));
         }
         else if ( ! A35TableroVisibilidad )
         {
            edtavEstado_Tooltiptext = "Tu tablero no es visible";
            AV7estado = context.GetImagePath( "2772a59e-70b1-412e-b78c-00398bc01d2c", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavEstado_Internalname, AV7estado);
            AV20Estado_GXI = GXDbFile.PathToUrl( context.GetImagePath( "2772a59e-70b1-412e-b78c-00398bc01d2c", "", context.GetTheme( )));
         }
         sendrow_172( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_17_Refreshing )
         {
            context.DoAjaxLoad(17, Grid1Row);
         }
      }

      protected void E110L2( )
      {
         /* 'Nuevo' Routine */
         returnInSub = false;
         context.PopUp(formatLink("anadirtablero.aspx") , new Object[] {});
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void E140L2( )
      {
         /* 'Editar' Routine */
         returnInSub = false;
         context.PopUp(formatLink("editartablero.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0))}, new string[] {"TableroId"}) , new Object[] {"A9TableroId"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E150L2( )
      {
         /* 'Eliminar' Routine */
         returnInSub = false;
         if ( A34TableroEstado )
         {
            GXt_int1 = 1;
            new eliminartablero(context ).execute( ref  A9TableroId, ref  GXt_int1) ;
         }
         else if ( ! A34TableroEstado )
         {
            AV12dir = 1;
            GXt_int1 = 2;
            new eliminartablero(context ).execute( ref  A9TableroId, ref  GXt_int1) ;
         }
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E160L2( )
      {
         /* 'Visibilidad' Routine */
         returnInSub = false;
         if ( A35TableroVisibilidad )
         {
            GXt_int1 = 1;
            new visibilidadtablero(context ).execute( ref  A9TableroId, ref  GXt_int1) ;
         }
         else if ( ! A35TableroVisibilidad )
         {
            AV12dir = 1;
            GXt_int1 = 2;
            new visibilidadtablero(context ).execute( ref  A9TableroId, ref  GXt_int1) ;
         }
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E170L2( )
      {
         /* 'Colaboradores' Routine */
         returnInSub = false;
         CallWebObject(formatLink("anadircolaboradores.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9TableroId,4,0))}, new string[] {"TableroId"}) );
         context.wjLocDisableFrm = 1;
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA0L2( ) ;
         WS0L2( ) ;
         WE0L2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0L2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "gridtableros", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0L2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0L2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0L2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0L2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20229920473959", true, true);
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
         context.AddJavascriptSource("gridtableros.js", "?20229920473959", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_172( )
      {
         edtavEditar_Internalname = sPrefix+"vEDITAR_"+sGXsfl_17_idx;
         edtavEliminar_Internalname = sPrefix+"vELIMINAR_"+sGXsfl_17_idx;
         edtTableroId_Internalname = sPrefix+"TABLEROID_"+sGXsfl_17_idx;
         edtTableroFechaCreacion_Internalname = sPrefix+"TABLEROFECHACREACION_"+sGXsfl_17_idx;
         edtTableroNombre_Internalname = sPrefix+"TABLERONOMBRE_"+sGXsfl_17_idx;
         edtPropietarioId_Internalname = sPrefix+"PROPIETARIOID_"+sGXsfl_17_idx;
         chkTableroEstado_Internalname = sPrefix+"TABLEROESTADO_"+sGXsfl_17_idx;
         chkTableroVisibilidad_Internalname = sPrefix+"TABLEROVISIBILIDAD_"+sGXsfl_17_idx;
         edtavTareas_Internalname = sPrefix+"vTAREAS_"+sGXsfl_17_idx;
         edtavEstado_Internalname = sPrefix+"vESTADO_"+sGXsfl_17_idx;
         edtavEquipo_Internalname = sPrefix+"vEQUIPO_"+sGXsfl_17_idx;
      }

      protected void SubsflControlProps_fel_172( )
      {
         edtavEditar_Internalname = sPrefix+"vEDITAR_"+sGXsfl_17_fel_idx;
         edtavEliminar_Internalname = sPrefix+"vELIMINAR_"+sGXsfl_17_fel_idx;
         edtTableroId_Internalname = sPrefix+"TABLEROID_"+sGXsfl_17_fel_idx;
         edtTableroFechaCreacion_Internalname = sPrefix+"TABLEROFECHACREACION_"+sGXsfl_17_fel_idx;
         edtTableroNombre_Internalname = sPrefix+"TABLERONOMBRE_"+sGXsfl_17_fel_idx;
         edtPropietarioId_Internalname = sPrefix+"PROPIETARIOID_"+sGXsfl_17_fel_idx;
         chkTableroEstado_Internalname = sPrefix+"TABLEROESTADO_"+sGXsfl_17_fel_idx;
         chkTableroVisibilidad_Internalname = sPrefix+"TABLEROVISIBILIDAD_"+sGXsfl_17_fel_idx;
         edtavTareas_Internalname = sPrefix+"vTAREAS_"+sGXsfl_17_fel_idx;
         edtavEstado_Internalname = sPrefix+"vESTADO_"+sGXsfl_17_fel_idx;
         edtavEquipo_Internalname = sPrefix+"vEQUIPO_"+sGXsfl_17_fel_idx;
      }

      protected void sendrow_172( )
      {
         SubsflControlProps_172( ) ;
         WB0L0( ) ;
         Grid1Row = GXWebRow.GetNew(context,Grid1Container);
         if ( subGrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
         }
         else if ( subGrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid1_Backstyle = 0;
            subGrid1_Backcolor = subGrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Uniform";
            }
         }
         else if ( subGrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
            subGrid1_Backcolor = (int)(0x0);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_17_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_17_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavEditar_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavEditar_Enabled!=0)&&(edtavEditar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 18,'"+sPrefix+"',false,'',17)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV5editar_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5editar))&&String.IsNullOrEmpty(StringUtil.RTrim( AV18Editar_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5editar)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5editar)) ? AV18Editar_GXI : context.PathToRelativeUrl( AV5editar));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavEditar_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavEditar_Visible,(short)1,(string)"",(string)edtavEditar_Tooltiptext,(short)0,(short)1,(short)35,(string)"px",(short)35,(string)"px",(short)0,(short)0,(short)5,(string)edtavEditar_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'EDITAR\\'."+sGXsfl_17_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV5editar_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavEliminar_Enabled!=0)&&(edtavEliminar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 19,'"+sPrefix+"',false,'',17)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV6eliminar_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV6eliminar))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Eliminar_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV6eliminar)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV6eliminar)) ? AV17Eliminar_GXI : context.PathToRelativeUrl( AV6eliminar));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavEliminar_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavEliminar_Tooltiptext,(short)0,(short)1,(short)35,(string)"px",(short)35,(string)"px",(short)0,(short)0,(short)5,(string)edtavEliminar_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ELIMINAR\\'."+sGXsfl_17_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV6eliminar_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTableroId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TableroId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A9TableroId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTableroId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)5,(string)"%",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)17,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+edtTableroFechaCreacion_Horizontalalignment+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTableroFechaCreacion_Internalname,context.localUtil.TToC( A11TableroFechaCreacion, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A11TableroFechaCreacion, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTableroFechaCreacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)20,(string)"%",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)17,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)edtTableroFechaCreacion_Horizontalalignment,(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTableroNombre_Internalname,StringUtil.RTrim( A10TableroNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTableroNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)60,(string)"%",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)17,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropietarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A17PropietarioId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A17PropietarioId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropietarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)17,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Check box */
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "TABLEROESTADO_" + sGXsfl_17_idx;
         chkTableroEstado.Name = GXCCtl;
         chkTableroEstado.WebTags = "";
         chkTableroEstado.Caption = "";
         AssignProp(sPrefix, false, chkTableroEstado_Internalname, "TitleCaption", chkTableroEstado.Caption, !bGXsfl_17_Refreshing);
         chkTableroEstado.CheckedValue = "false";
         Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTableroEstado_Internalname,StringUtil.BoolToStr( A34TableroEstado),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Check box */
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "TABLEROVISIBILIDAD_" + sGXsfl_17_idx;
         chkTableroVisibilidad.Name = GXCCtl;
         chkTableroVisibilidad.WebTags = "";
         chkTableroVisibilidad.Caption = "";
         AssignProp(sPrefix, false, chkTableroVisibilidad_Internalname, "TitleCaption", chkTableroVisibilidad.Caption, !bGXsfl_17_Refreshing);
         chkTableroVisibilidad.CheckedValue = "false";
         Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTableroVisibilidad_Internalname,StringUtil.BoolToStr( A35TableroVisibilidad),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavTareas_Enabled!=0)&&(edtavTareas_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 26,'"+sPrefix+"',false,'',17)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV13Tareas_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV13Tareas))&&String.IsNullOrEmpty(StringUtil.RTrim( AV16Tareas_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV13Tareas)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV13Tareas)) ? AV16Tareas_GXI : context.PathToRelativeUrl( AV13Tareas));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavTareas_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)1,(short)30,(string)"px",(short)30,(string)"px",(short)0,(short)0,(short)7,(string)edtavTareas_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+"e180l2_client"+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV13Tareas_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavEstado_Enabled!=0)&&(edtavEstado_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 27,'"+sPrefix+"',false,'',17)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV7estado_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV7estado))&&String.IsNullOrEmpty(StringUtil.RTrim( AV20Estado_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV7estado)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV7estado)) ? AV20Estado_GXI : context.PathToRelativeUrl( AV7estado));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavEstado_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavEstado_Tooltiptext,(short)0,(short)1,(short)35,(string)"px",(short)35,(string)"px",(short)0,(short)0,(short)5,(string)edtavEstado_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'VISIBILIDAD\\'."+sGXsfl_17_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV7estado_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavEquipo_Enabled!=0)&&(edtavEquipo_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 28,'"+sPrefix+"',false,'',17)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV8equipo_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV8equipo))&&String.IsNullOrEmpty(StringUtil.RTrim( AV19Equipo_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV8equipo)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV8equipo)) ? AV19Equipo_GXI : context.PathToRelativeUrl( AV8equipo));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavEquipo_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavEquipo_Tooltiptext,(short)0,(short)1,(short)35,(string)"px",(short)35,(string)"px",(short)0,(short)0,(short)5,(string)edtavEquipo_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'COLABORADORES\\'."+sGXsfl_17_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV8equipo_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes0L2( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_17_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_17_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_17_idx+1);
         sGXsfl_17_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_17_idx), 4, 0), 4, "0");
         SubsflControlProps_172( ) ;
         /* End function sendrow_172 */
      }

      protected void init_web_controls( )
      {
         cmbavTableroestado.Name = "vTABLEROESTADO";
         cmbavTableroestado.WebTags = "";
         cmbavTableroestado.addItem(StringUtil.BoolToStr( true), "Activos", 0);
         cmbavTableroestado.addItem(StringUtil.BoolToStr( false), "Inactivos", 0);
         if ( cmbavTableroestado.ItemCount > 0 )
         {
         }
         GXCCtl = "TABLEROESTADO_" + sGXsfl_17_idx;
         chkTableroEstado.Name = GXCCtl;
         chkTableroEstado.WebTags = "";
         chkTableroEstado.Caption = "";
         AssignProp(sPrefix, false, chkTableroEstado_Internalname, "TitleCaption", chkTableroEstado.Caption, !bGXsfl_17_Refreshing);
         chkTableroEstado.CheckedValue = "false";
         GXCCtl = "TABLEROVISIBILIDAD_" + sGXsfl_17_idx;
         chkTableroVisibilidad.Name = GXCCtl;
         chkTableroVisibilidad.WebTags = "";
         chkTableroVisibilidad.Caption = "";
         AssignProp(sPrefix, false, chkTableroVisibilidad_Internalname, "TitleCaption", chkTableroVisibilidad.Caption, !bGXsfl_17_Refreshing);
         chkTableroVisibilidad.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1";
         imgImage1_Internalname = sPrefix+"IMAGE1";
         cmbavTableroestado_Internalname = sPrefix+"vTABLEROESTADO";
         edtavEditar_Internalname = sPrefix+"vEDITAR";
         edtavEliminar_Internalname = sPrefix+"vELIMINAR";
         edtTableroId_Internalname = sPrefix+"TABLEROID";
         edtTableroFechaCreacion_Internalname = sPrefix+"TABLEROFECHACREACION";
         edtTableroNombre_Internalname = sPrefix+"TABLERONOMBRE";
         edtPropietarioId_Internalname = sPrefix+"PROPIETARIOID";
         chkTableroEstado_Internalname = sPrefix+"TABLEROESTADO";
         chkTableroVisibilidad_Internalname = sPrefix+"TABLEROVISIBILIDAD";
         edtavTareas_Internalname = sPrefix+"vTAREAS";
         edtavEstado_Internalname = sPrefix+"vESTADO";
         edtavEquipo_Internalname = sPrefix+"vEQUIPO";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid1_Internalname = sPrefix+"GRID1";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtavEquipo_Jsonclick = "";
         edtavEquipo_Visible = -1;
         edtavEquipo_Enabled = 1;
         edtavEstado_Jsonclick = "";
         edtavEstado_Visible = -1;
         edtavEstado_Enabled = 1;
         edtavTareas_Jsonclick = "";
         edtavTareas_Visible = -1;
         edtavTareas_Enabled = 1;
         chkTableroVisibilidad.Caption = "";
         chkTableroEstado.Caption = "";
         edtPropietarioId_Jsonclick = "";
         edtTableroNombre_Jsonclick = "";
         edtTableroFechaCreacion_Jsonclick = "";
         edtTableroId_Jsonclick = "";
         edtavEliminar_Jsonclick = "";
         edtavEliminar_Visible = -1;
         edtavEliminar_Enabled = 1;
         edtavEditar_Jsonclick = "";
         edtavEditar_Enabled = 1;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavEquipo_Tooltiptext = "";
         edtavEstado_Tooltiptext = "";
         edtavEliminar_Tooltiptext = "";
         edtavEditar_Tooltiptext = "";
         subGrid1_Header = "";
         edtavEditar_Visible = -1;
         subGrid1_Class = "WorkWith";
         subGrid1_Backcolorstyle = 0;
         cmbavTableroestado_Jsonclick = "";
         cmbavTableroestado.Enabled = 1;
         edtTableroFechaCreacion_Horizontalalignment = "right";
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'cmbavTableroestado'},{av:'AV11TableroEstado',fld:'vTABLEROESTADO',pic:''},{av:'edtTableroFechaCreacion_Horizontalalignment',ctrl:'TABLEROFECHACREACION',prop:'Horizontalalignment'},{av:'sPrefix'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'NUEVO'","{handler:'E110L2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'cmbavTableroestado'},{av:'AV11TableroEstado',fld:'vTABLEROESTADO',pic:''},{av:'edtTableroFechaCreacion_Horizontalalignment',ctrl:'TABLEROFECHACREACION',prop:'Horizontalalignment'},{av:'sPrefix'}]");
         setEventMetadata("'NUEVO'",",oparms:[]}");
         setEventMetadata("'EDITAR'","{handler:'E140L2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'cmbavTableroestado'},{av:'AV11TableroEstado',fld:'vTABLEROESTADO',pic:''},{av:'edtTableroFechaCreacion_Horizontalalignment',ctrl:'TABLEROFECHACREACION',prop:'Horizontalalignment'},{av:'sPrefix'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]");
         setEventMetadata("'EDITAR'",",oparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("'ELIMINAR'","{handler:'E150L2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'cmbavTableroestado'},{av:'AV11TableroEstado',fld:'vTABLEROESTADO',pic:''},{av:'edtTableroFechaCreacion_Horizontalalignment',ctrl:'TABLEROFECHACREACION',prop:'Horizontalalignment'},{av:'sPrefix'},{av:'A34TableroEstado',fld:'TABLEROESTADO',pic:'',hsh:true},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]");
         setEventMetadata("'ELIMINAR'",",oparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("'VISIBILIDAD'","{handler:'E160L2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'cmbavTableroestado'},{av:'AV11TableroEstado',fld:'vTABLEROESTADO',pic:''},{av:'edtTableroFechaCreacion_Horizontalalignment',ctrl:'TABLEROFECHACREACION',prop:'Horizontalalignment'},{av:'sPrefix'},{av:'A35TableroVisibilidad',fld:'TABLEROVISIBILIDAD',pic:'',hsh:true},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]");
         setEventMetadata("'VISIBILIDAD'",",oparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("'COLABORADORES'","{handler:'E170L2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'cmbavTableroestado'},{av:'AV11TableroEstado',fld:'vTABLEROESTADO',pic:''},{av:'edtTableroFechaCreacion_Horizontalalignment',ctrl:'TABLEROFECHACREACION',prop:'Horizontalalignment'},{av:'sPrefix'},{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]");
         setEventMetadata("'COLABORADORES'",",oparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("'TAREAS'","{handler:'E180L2',iparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]");
         setEventMetadata("'TAREAS'",",oparms:[{av:'A9TableroId',fld:'TABLEROID',pic:'ZZZ9'}]}");
         setEventMetadata("NULL","{handler:'Validv_Equipo',iparms:[]");
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
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         imgImage1_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5editar = "";
         AV6eliminar = "";
         A11TableroFechaCreacion = (DateTime)(DateTime.MinValue);
         A10TableroNombre = "";
         AV13Tareas = "";
         AV7estado = "";
         AV8equipo = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV18Editar_GXI = "";
         AV17Eliminar_GXI = "";
         AV16Tareas_GXI = "";
         AV20Estado_GXI = "";
         AV19Equipo_GXI = "";
         scmdbuf = "";
         H000L2_A35TableroVisibilidad = new bool[] {false} ;
         H000L2_A34TableroEstado = new bool[] {false} ;
         H000L2_A17PropietarioId = new short[1] ;
         H000L2_A10TableroNombre = new string[] {""} ;
         H000L2_A11TableroFechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H000L2_A9TableroId = new short[1] ;
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gridtableros__default(),
            new Object[][] {
                new Object[] {
               H000L2_A35TableroVisibilidad, H000L2_A34TableroEstado, H000L2_A17PropietarioId, H000L2_A10TableroNombre, H000L2_A11TableroFechaCreacion, H000L2_A9TableroId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short A9TableroId ;
      private short A17PropietarioId ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV9cantidadParticipantes ;
      private short GRID1_nEOF ;
      private short AV12dir ;
      private short GXt_int1 ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_17 ;
      private int nGXsfl_17_idx=1 ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtavEditar_Visible ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int edtavEditar_Enabled ;
      private int edtavEliminar_Enabled ;
      private int edtavEliminar_Visible ;
      private int edtavTareas_Enabled ;
      private int edtavTareas_Visible ;
      private int edtavEstado_Enabled ;
      private int edtavEstado_Visible ;
      private int edtavEquipo_Enabled ;
      private int edtavEquipo_Visible ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private string edtTableroFechaCreacion_Horizontalalignment ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_17_idx="0001" ;
      private string edtTableroFechaCreacion_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage1_Internalname ;
      private string imgImage1_Jsonclick ;
      private string cmbavTableroestado_Internalname ;
      private string cmbavTableroestado_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string edtavEditar_Tooltiptext ;
      private string edtavEliminar_Tooltiptext ;
      private string A10TableroNombre ;
      private string edtavEstado_Tooltiptext ;
      private string edtavEquipo_Tooltiptext ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavEditar_Internalname ;
      private string edtavEliminar_Internalname ;
      private string edtTableroId_Internalname ;
      private string edtTableroNombre_Internalname ;
      private string edtPropietarioId_Internalname ;
      private string chkTableroEstado_Internalname ;
      private string chkTableroVisibilidad_Internalname ;
      private string edtavTareas_Internalname ;
      private string edtavEstado_Internalname ;
      private string edtavEquipo_Internalname ;
      private string scmdbuf ;
      private string sGXsfl_17_fel_idx="0001" ;
      private string edtavEditar_Jsonclick ;
      private string edtavEliminar_Jsonclick ;
      private string ROClassString ;
      private string edtTableroId_Jsonclick ;
      private string edtTableroFechaCreacion_Jsonclick ;
      private string edtTableroNombre_Jsonclick ;
      private string edtPropietarioId_Jsonclick ;
      private string GXCCtl ;
      private string edtavTareas_Jsonclick ;
      private string edtavEstado_Jsonclick ;
      private string edtavEquipo_Jsonclick ;
      private DateTime A11TableroFechaCreacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_17_Refreshing=false ;
      private bool AV11TableroEstado ;
      private bool wbLoad ;
      private bool A34TableroEstado ;
      private bool A35TableroVisibilidad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5editar_IsBlob ;
      private bool AV6eliminar_IsBlob ;
      private bool AV13Tareas_IsBlob ;
      private bool AV7estado_IsBlob ;
      private bool AV8equipo_IsBlob ;
      private string AV18Editar_GXI ;
      private string AV17Eliminar_GXI ;
      private string AV16Tareas_GXI ;
      private string AV20Estado_GXI ;
      private string AV19Equipo_GXI ;
      private string AV5editar ;
      private string AV6eliminar ;
      private string AV13Tareas ;
      private string AV7estado ;
      private string AV8equipo ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTableroestado ;
      private GXCheckbox chkTableroEstado ;
      private GXCheckbox chkTableroVisibilidad ;
      private IDataStoreProvider pr_default ;
      private bool[] H000L2_A35TableroVisibilidad ;
      private bool[] H000L2_A34TableroEstado ;
      private short[] H000L2_A17PropietarioId ;
      private string[] H000L2_A10TableroNombre ;
      private DateTime[] H000L2_A11TableroFechaCreacion ;
      private short[] H000L2_A9TableroId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class gridtableros__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000L2;
          prmH000L2 = new Object[] {
          new ParDef("@AV11TableroEstado",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000L2", "SELECT [TableroVisibilidad], [TableroEstado], [PropietarioId], [TableroNombre], [TableroFechaCreacion], [TableroId] FROM [Tableros] WHERE [TableroEstado] = @AV11TableroEstado ORDER BY [TableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L2,11, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
