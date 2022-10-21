using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class webuitest1 : GXProcedure
   {
      public webuitest1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public webuitest1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.gxtest.SdtWebdriver aP0_driver )
      {
         this.AV8driver = aP0_driver;
         initialize();
         executePrivate();
      }

      public void executeSubmit( GeneXus.Programs.gxtest.SdtWebdriver aP0_driver )
      {
         webuitest1 objwebuitest1;
         objwebuitest1 = new webuitest1();
         objwebuitest1.AV8driver = aP0_driver;
         objwebuitest1.context.SetSubmitInitialConfig(context);
         objwebuitest1.initialize();
         Submit( executePrivateCatch,objwebuitest1);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((webuitest1)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8driver.setbrowser( "Edge");
         AV8driver.start();
         AV8driver.maximize();
         AV8driver.go( "http://localhost/ProyectoUMG.NETFrameworkEnvironment/listadotareas.aspx?wWwU2VqLK6KpKjlJtisUZtusc9i6tqQPqTkYSWhDzEI");
         AV8driver.clickbyid( "W0044vTAREANOMBRE");
         AV8driver.typebyid( "W0044vTAREANOMBRE",  "Tarea 1");
         AV8driver.clickbyid( "W0044vRESPONSABLE");
         AV8driver.clickbyid( "W0044vRESPONSABLE");
         AV8driver.clickbyid( "W0044GUARDAR");
         new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  "Error en la información ingresada",  AV8driver.gettextbyid("swal2-title"),  "'swal2-title' not matching Error en la información ingresada") ;
         AV8driver.clickbycss( "div[class='gxwebcomponent-body form-horizontal Form-fx'] > div > span.gx_ev");
         new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  "No puedes crear una tarea con fechas pasadas",  AV8driver.gettextbycss("div.gx-warning-message"),  "'div.gx-warning-message' not matching No puedes crear una tarea con fechas pasadas") ;
         AV8driver.typebyid( "W0044vTAREAFECHAINICIO",  "16/10/22");
         AV8driver.clickbyid( "W0044GUARDAR");
         AV8driver.clickbycss( "div[class='swal2-container swal2-center swal2-backdrop-show']");
         AV8driver.clickbycss( "div.gx-warning-message");
         new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  "La fecha de finalización es inválida",  AV8driver.gettextbycss("div.gx-warning-message"),  "'div.gx-warning-message' not matching La fecha de finalización es inválida") ;
         AV8driver.typebyid( "W0044vTAREAFECHAFIN",  "18/10/22");
         AV8driver.clickbyid( "W0044GUARDAR");
         AV8driver.clickbycss( "#W0047MAINTABLE > div.row > div.col-xs-12");
         AV8driver.clickbyid( "W0047vPARTICIPANTETABLEROID_0001");
         AV8driver.selectbyid( "W0047vPARTICIPANTETABLEROID_0001",  "Usuario Diez");
         new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  "Responsable asignado",  AV8driver.gettextbycss("div.swal2-header"),  "'div.swal2-header' not matching Responsable asignado") ;
         AV8driver.clickbyid( "W0047W00670001vACTIVIDADNOMBRE");
         new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  "Debes indicar un nombre",  AV8driver.gettextbyid("swal2-title"),  "'swal2-title' not matching Debes indicar un nombre") ;
         AV8driver.clickbycss( "div[class='swal2-container swal2-center swal2-backdrop-show']");
         AV8driver.clickbyid( "W0047W00670001vACTIVIDADNOMBRE");
         AV8driver.typebyid( "W0047W00670001vACTIVIDADNOMBRE",  "Actividad 1");
         AV8driver.clickbycss( "div[class='swal2-container swal2-center swal2-backdrop-show']");
         AV8driver.clickbyid( "W0047W00670001vACTIVIDADNOMBRE");
         AV8driver.typebyid( "W0047W00670001vACTIVIDADNOMBRE",  "Actividad 2");
         AV8driver.clickbycss( "div[class='swal2-container swal2-center swal2-backdrop-show']");
         AV8driver.clickbyid( "W0047W00670001vACTIVIDADNOMBRE");
         AV8driver.typebyid( "W0047W00670001vACTIVIDADNOMBRE",  "Actividad 3");
         AV8driver.clickbycss( "div[class='swal2-container swal2-center swal2-backdrop-show']");
         new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  "33%",  AV8driver.gettextbycss("#W0049W00670002ESTADISTICAS > div.progress > div.progress-bar"),  "'#W0049W00670002ESTADISTICAS > div.progress > div.progress-bar' not matching 33%") ;
         new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  "No se puede completar la tarea",  AV8driver.gettextbycss("div.swal2-header"),  "'div.swal2-header' not matching No se puede completar la tarea") ;
         AV8driver.clickbycss( "div[class='swal2-container swal2-center swal2-backdrop-hide']");
         AV8driver.clickbycss( "div[class='swal2-container swal2-center swal2-backdrop-show']");
         AV8driver.clickbycss( "#W0049TABLE7_0002 > div.row:nth-child(3) > div.col-xs-12");
         new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  "Sin responsable asignado",  AV8driver.gettextbycss("#W0049NOMBRE2_0002 > center > h4"),  "'#W0049NOMBRE2_0002 > center > h4' not matching Sin responsable asignado") ;
         AV8driver.clickbycss( "#W0049TABLE7_0002 > div.row:nth-child(4) > div.col-xs-12");
         AV8driver.clickbycss( "#W0049W00670002ESTADISTICAS > div.progress > div.progress-bar");
         new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  "100%",  AV8driver.gettextbycss("#W0049W00670002ESTADISTICAS > div.progress > div.progress-bar"),  "'#W0049W00670002ESTADISTICAS > div.progress > div.progress-bar' not matching 100%") ;
         AV8driver.clickbycss( "#W0049TABLE7_0002 > div.row:nth-child(7) > div.col-xs-12");
         AV8driver.clickbyid( "swal2-title");
         new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  "No puedes finalizar la tarea sin un responsable asignado",  AV8driver.gettextbyid("swal2-title"),  "'swal2-title' not matching No puedes finalizar la tarea sin un responsable asignado") ;
         AV8driver.clickbycss( "div[class='swal2-container swal2-center swal2-backdrop-show']");
         AV8driver.clickbycss( "div[class='swal2-container swal2-center swal2-backdrop-show']");
         AV8driver.clickbycss( "#W0049NOMBRE2_0002 > center > h4");
         new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  "juanpa.ingen@gmail.com - Juan Pablo Sagastume",  AV8driver.gettextbycss("#W0049NOMBRE2_0002 > center > h4"),  "'#W0049NOMBRE2_0002 > center > h4' not matching juanpa.ingen@gmail.com - Juan Pablo Sagastume") ;
         AV8driver.clickbycss( "div.swal2-header");
         new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  "Tarea completada",  AV8driver.gettextbyid("swal2-title"),  "'swal2-title' not matching Tarea completada") ;
         AV8driver.clickbycss( "div[class='col-xs-12 col-sm-4']:nth-child(2)");
         AV8driver.end();
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GeneXus.Programs.gxtest.SdtWebdriver AV8driver ;
   }

}
