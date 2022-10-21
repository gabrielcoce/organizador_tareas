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
namespace GeneXus.Programs.tests {
   public class getnumerointegrantestestdata : GXProcedure
   {
      public getnumerointegrantestestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getnumerointegrantestestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT>( context, "getNumeroIntegrantesTestSDT", "ProyectoUMG") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT> aP0_Gxm2rootcol )
      {
         getnumerointegrantestestdata objgetnumerointegrantestestdata;
         objgetnumerointegrantestestdata = new getnumerointegrantestestdata();
         objgetnumerointegrantestestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT>( context, "getNumeroIntegrantesTestSDT", "ProyectoUMG") ;
         objgetnumerointegrantestestdata.context.SetSubmitInitialConfig(context);
         objgetnumerointegrantestestdata.initialize();
         Submit( executePrivateCatch,objgetnumerointegrantestestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getnumerointegrantestestdata)stateInfo).executePrivate();
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
         Gxm1getnumerointegrantestestsdt = new GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT(context);
         Gxm2rootcol.Add(Gxm1getnumerointegrantestestsdt, 0);
         Gxm1getnumerointegrantestestsdt.gxTpr_Testcaseid = "1";
         Gxm1getnumerointegrantestestsdt.gxTpr_Tableroid = 1;
         Gxm1getnumerointegrantestestsdt.gxTpr_Expectedcount = 2;
         Gxm1getnumerointegrantestestsdt.gxTpr_Msgcount = "Numero retornado no es correcto";
         Gxm1getnumerointegrantestestsdt = new GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT(context);
         Gxm2rootcol.Add(Gxm1getnumerointegrantestestsdt, 0);
         Gxm1getnumerointegrantestestsdt.gxTpr_Testcaseid = "2";
         Gxm1getnumerointegrantestestsdt.gxTpr_Tableroid = 2;
         Gxm1getnumerointegrantestestsdt.gxTpr_Expectedcount = 5;
         Gxm1getnumerointegrantestestsdt.gxTpr_Msgcount = "Numero retornado no es correcto";
         Gxm1getnumerointegrantestestsdt = new GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT(context);
         Gxm2rootcol.Add(Gxm1getnumerointegrantestestsdt, 0);
         Gxm1getnumerointegrantestestsdt.gxTpr_Testcaseid = "3";
         Gxm1getnumerointegrantestestsdt.gxTpr_Tableroid = 3;
         Gxm1getnumerointegrantestestsdt.gxTpr_Expectedcount = 3;
         Gxm1getnumerointegrantestestsdt.gxTpr_Msgcount = "Numero retornado no es correcto";
         Gxm1getnumerointegrantestestsdt = new GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT(context);
         Gxm2rootcol.Add(Gxm1getnumerointegrantestestsdt, 0);
         Gxm1getnumerointegrantestestsdt.gxTpr_Testcaseid = "4";
         Gxm1getnumerointegrantestestsdt.gxTpr_Tableroid = 4;
         Gxm1getnumerointegrantestestsdt.gxTpr_Expectedcount = 1;
         Gxm1getnumerointegrantestestsdt.gxTpr_Msgcount = "Numero retornado no es correcto";
         Gxm1getnumerointegrantestestsdt = new GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT(context);
         Gxm2rootcol.Add(Gxm1getnumerointegrantestestsdt, 0);
         Gxm1getnumerointegrantestestsdt.gxTpr_Testcaseid = "5";
         Gxm1getnumerointegrantestestsdt.gxTpr_Tableroid = 5;
         Gxm1getnumerointegrantestestsdt.gxTpr_Expectedcount = 1;
         Gxm1getnumerointegrantestestsdt.gxTpr_Msgcount = "Numero retornado no es correcto";
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
         Gxm1getnumerointegrantestestsdt = new GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT Gxm1getnumerointegrantestestsdt ;
   }

}
