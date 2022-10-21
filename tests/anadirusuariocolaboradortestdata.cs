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
   public class anadirusuariocolaboradortestdata : GXProcedure
   {
      public anadirusuariocolaboradortestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public anadirusuariocolaboradortestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT>( context, "AnadirUsuarioColaboradorTestSDT", "ProyectoUMG") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT> aP0_Gxm2rootcol )
      {
         anadirusuariocolaboradortestdata objanadirusuariocolaboradortestdata;
         objanadirusuariocolaboradortestdata = new anadirusuariocolaboradortestdata();
         objanadirusuariocolaboradortestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT>( context, "AnadirUsuarioColaboradorTestSDT", "ProyectoUMG") ;
         objanadirusuariocolaboradortestdata.context.SetSubmitInitialConfig(context);
         objanadirusuariocolaboradortestdata.initialize();
         Submit( executePrivateCatch,objanadirusuariocolaboradortestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((anadirusuariocolaboradortestdata)stateInfo).executePrivate();
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
         Gxm1anadirusuariocolaboradortestsdt = new GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT(context);
         Gxm2rootcol.Add(Gxm1anadirusuariocolaboradortestsdt, 0);
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Testcaseid = "1";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Tableroid = 1;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedtableroid = 1;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgtableroid = "El tablero indicado no existe";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Registroinvitadoid = 1;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedregistroinvitadoid = 1;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgregistroinvitadoid = "El invitado indicado no existe";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Result = false;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedresult = false;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgresult = "El resultado esperado no es correcto";
         Gxm1anadirusuariocolaboradortestsdt = new GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT(context);
         Gxm2rootcol.Add(Gxm1anadirusuariocolaboradortestsdt, 0);
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Testcaseid = "2";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Tableroid = 2;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedtableroid = 2;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgtableroid = "El tablero indicado no existe";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Registroinvitadoid = 2;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedregistroinvitadoid = 2;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgregistroinvitadoid = "El invitado indicado no existe";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Result = false;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedresult = false;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgresult = "El resultado esperado no es correcto";
         Gxm1anadirusuariocolaboradortestsdt = new GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT(context);
         Gxm2rootcol.Add(Gxm1anadirusuariocolaboradortestsdt, 0);
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Testcaseid = "3";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Tableroid = 3;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedtableroid = 3;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgtableroid = "El tablero indicado no existe";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Registroinvitadoid = 3;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedregistroinvitadoid = 3;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgregistroinvitadoid = "El invitado indicado no existe";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Result = false;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedresult = false;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgresult = "El resultado esperado no es correcto";
         Gxm1anadirusuariocolaboradortestsdt = new GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT(context);
         Gxm2rootcol.Add(Gxm1anadirusuariocolaboradortestsdt, 0);
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Testcaseid = "4";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Tableroid = 4;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedtableroid = 4;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgtableroid = "El tablero indicado no existe";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Registroinvitadoid = 4;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedregistroinvitadoid = 4;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgregistroinvitadoid = "El invitado indicado no existe";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Result = false;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedresult = false;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgresult = "El resultado esperado no es correcto";
         Gxm1anadirusuariocolaboradortestsdt = new GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT(context);
         Gxm2rootcol.Add(Gxm1anadirusuariocolaboradortestsdt, 0);
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Testcaseid = "5";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Tableroid = 5;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedtableroid = 5;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgtableroid = "El tablero indicado no existe";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Registroinvitadoid = 5;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedregistroinvitadoid = 5;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgregistroinvitadoid = "El invitado indicado no existe";
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Result = false;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Expectedresult = false;
         Gxm1anadirusuariocolaboradortestsdt.gxTpr_Msgresult = "El resultado esperado no es correcto";
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
         Gxm1anadirusuariocolaboradortestsdt = new GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.tests.SdtAnadirUsuarioColaboradorTestSDT Gxm1anadirusuariocolaboradortestsdt ;
   }

}
