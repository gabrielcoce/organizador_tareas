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
   public class anadirusuariocolaboradortest : GXProcedure
   {
      public anadirusuariocolaboradortest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public anadirusuariocolaboradortest( IGxContext context )
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
         anadirusuariocolaboradortest objanadirusuariocolaboradortest;
         objanadirusuariocolaboradortest = new anadirusuariocolaboradortest();
         objanadirusuariocolaboradortest.context.SetSubmitInitialConfig(context);
         objanadirusuariocolaboradortest.initialize();
         Submit( executePrivateCatch,objanadirusuariocolaboradortest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((anadirusuariocolaboradortest)stateInfo).executePrivate();
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
         GXt_objcol_SdtAnadirUsuarioColaboradorTestSDT1 = AV11GXV1;
         new GeneXus.Programs.tests.anadirusuariocolaboradortestdata(context ).execute( out  GXt_objcol_SdtAnadirUsuarioColaboradorTestSDT1) ;
         AV11GXV1 = GXt_objcol_SdtAnadirUsuarioColaboradorTestSDT1;
         while ( AV12GXV2 <= AV11GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT)AV11GXV1.Item(AV12GXV2));
            GXt_int2 = AV8TestCaseData.gxTpr_Tableroid;
            GXt_int3 = AV8TestCaseData.gxTpr_Registroinvitadoid;
            GXt_boolean4 = AV8TestCaseData.gxTpr_Result;
            new anadirusuariocolaborador(context ).execute( ref  GXt_int2, ref  GXt_int3, ref  GXt_boolean4) ;
            AV8TestCaseData.gxTpr_Tableroid = GXt_int2;
            AV8TestCaseData.gxTpr_Registroinvitadoid = GXt_int3;
            AV8TestCaseData.gxTpr_Result = GXt_boolean4;
            new GeneXus.Programs.gxtest.assertnumericequals(context ).execute(  (decimal)(AV8TestCaseData.gxTpr_Expectedtableroid),  (decimal)(AV8TestCaseData.gxTpr_Tableroid),  StringUtil.Format( "%1.ExpectedTableroId: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgtableroid, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertnumericequals(context ).execute(  (decimal)(AV8TestCaseData.gxTpr_Expectedregistroinvitadoid),  (decimal)(AV8TestCaseData.gxTpr_Registroinvitadoid),  StringUtil.Format( "%1.ExpectedRegistroInvitadoId: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgregistroinvitadoid, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertboolequals(context ).execute(  AV8TestCaseData.gxTpr_Expectedresult,  AV8TestCaseData.gxTpr_Result,  StringUtil.Format( "%1.Expectedresult: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgresult, "", "", "", "", "", "", "")) ;
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
         AV11GXV1 = new GXBaseCollection<GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT>( context, "AnadirUsuarioColaboradorTestSDT", "ProyectoUMG");
         GXt_objcol_SdtAnadirUsuarioColaboradorTestSDT1 = new GXBaseCollection<GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT>( context, "AnadirUsuarioColaboradorTestSDT", "ProyectoUMG");
         AV8TestCaseData = new GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GXt_int2 ;
      private short GXt_int3 ;
      private int AV12GXV2 ;
      private bool GXt_boolean4 ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT> AV11GXV1 ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT> GXt_objcol_SdtAnadirUsuarioColaboradorTestSDT1 ;
      private GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT AV8TestCaseData ;
   }

}
