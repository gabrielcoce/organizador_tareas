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
   public class intercalarroltest : GXProcedure
   {
      public intercalarroltest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public intercalarroltest( IGxContext context )
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
         intercalarroltest objintercalarroltest;
         objintercalarroltest = new intercalarroltest();
         objintercalarroltest.context.SetSubmitInitialConfig(context);
         objintercalarroltest.initialize();
         Submit( executePrivateCatch,objintercalarroltest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((intercalarroltest)stateInfo).executePrivate();
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
         GXt_objcol_SdtIntercalarRolTestSDT1 = AV11GXV1;
         new GeneXus.Programs.tests.intercalarroltestdata(context ).execute( out  GXt_objcol_SdtIntercalarRolTestSDT1) ;
         AV11GXV1 = GXt_objcol_SdtIntercalarRolTestSDT1;
         while ( AV12GXV2 <= AV11GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.tests.SdtIntercalarRolTestSDT)AV11GXV1.Item(AV12GXV2));
            GXt_int2 = AV8TestCaseData.gxTpr_Tableroid;
            GXt_int3 = AV8TestCaseData.gxTpr_Participantetableroid;
            GXt_int4 = AV8TestCaseData.gxTpr_Rol;
            new intercalarrol(context ).execute( ref  GXt_int2, ref  GXt_int3, ref  GXt_int4) ;
            AV8TestCaseData.gxTpr_Tableroid = GXt_int2;
            AV8TestCaseData.gxTpr_Participantetableroid = GXt_int3;
            AV8TestCaseData.gxTpr_Rol = GXt_int4;
            new GeneXus.Programs.gxtest.assertnumericequals(context ).execute(  (decimal)(AV8TestCaseData.gxTpr_Expectedtableroid),  (decimal)(AV8TestCaseData.gxTpr_Tableroid),  StringUtil.Format( "%1.ExpectedTableroId: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgtableroid, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertnumericequals(context ).execute(  (decimal)(AV8TestCaseData.gxTpr_Expectedparticipantetableroid),  (decimal)(AV8TestCaseData.gxTpr_Participantetableroid),  StringUtil.Format( "%1.ExpectedParticipanteTableroId: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgparticipantetableroid, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertnumericequals(context ).execute(  (decimal)(AV8TestCaseData.gxTpr_Expectedrol),  (decimal)(AV8TestCaseData.gxTpr_Rol),  StringUtil.Format( "%1.Expectedrol: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgrol, "", "", "", "", "", "", "")) ;
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
         AV11GXV1 = new GXBaseCollection<GeneXus.Programs.tests.SdtIntercalarRolTestSDT>( context, "IntercalarRolTestSDT", "ProyectoUMG");
         GXt_objcol_SdtIntercalarRolTestSDT1 = new GXBaseCollection<GeneXus.Programs.tests.SdtIntercalarRolTestSDT>( context, "IntercalarRolTestSDT", "ProyectoUMG");
         AV8TestCaseData = new GeneXus.Programs.tests.SdtIntercalarRolTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GXt_int2 ;
      private short GXt_int3 ;
      private short GXt_int4 ;
      private int AV12GXV2 ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtIntercalarRolTestSDT> AV11GXV1 ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtIntercalarRolTestSDT> GXt_objcol_SdtIntercalarRolTestSDT1 ;
      private GeneXus.Programs.tests.SdtIntercalarRolTestSDT AV8TestCaseData ;
   }

}
