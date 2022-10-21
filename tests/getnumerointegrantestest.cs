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
   public class getnumerointegrantestest : GXProcedure
   {
      public getnumerointegrantestest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getnumerointegrantestest( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         getnumerointegrantestest objgetnumerointegrantestest;
         objgetnumerointegrantestest = new getnumerointegrantestest();
         objgetnumerointegrantestest.context.SetSubmitInitialConfig(context);
         objgetnumerointegrantestest.initialize();
         Submit( executePrivateCatch,objgetnumerointegrantestest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getnumerointegrantestest)stateInfo).executePrivate();
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
         AV12GXV2 = 1;
         GXt_objcol_SdtgetNumeroIntegrantesTestSDT1 = AV11GXV1;
         new GeneXus.Programs.tests.getnumerointegrantestestdata(context ).execute( out  GXt_objcol_SdtgetNumeroIntegrantesTestSDT1) ;
         AV11GXV1 = GXt_objcol_SdtgetNumeroIntegrantesTestSDT1;
         while ( AV12GXV2 <= AV11GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT)AV11GXV1.Item(AV12GXV2));
            GXt_int2 = 0;
            new getnumerointegrantes(context ).execute(  AV8TestCaseData.gxTpr_Tableroid, out  GXt_int2) ;
            AV8TestCaseData.gxTpr_Count = GXt_int2;
            new GeneXus.Programs.gxtest.assertnumericequals(context ).execute(  (decimal)(AV8TestCaseData.gxTpr_Expectedcount),  (decimal)(AV8TestCaseData.gxTpr_Count),  StringUtil.Format( "%1.Expectedcount: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgcount, "", "", "", "", "", "", "")) ;
            AV12GXV2 = (int)(AV12GXV2+1);
         }
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
         AV11GXV1 = new GXBaseCollection<GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT>( context, "getNumeroIntegrantesTestSDT", "ProyectoUMG");
         GXt_objcol_SdtgetNumeroIntegrantesTestSDT1 = new GXBaseCollection<GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT>( context, "getNumeroIntegrantesTestSDT", "ProyectoUMG");
         AV8TestCaseData = new GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GXt_int2 ;
      private int AV12GXV2 ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT> AV11GXV1 ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT> GXt_objcol_SdtgetNumeroIntegrantesTestSDT1 ;
      private GeneXus.Programs.tests.SdtgetNumeroIntegrantesTestSDT AV8TestCaseData ;
   }

}
