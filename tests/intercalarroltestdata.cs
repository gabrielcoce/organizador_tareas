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
   public class intercalarroltestdata : GXProcedure
   {
      public intercalarroltestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public intercalarroltestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.tests.SdtIntercalarRolTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.tests.SdtIntercalarRolTestSDT>( context, "IntercalarRolTestSDT", "ProyectoUMG") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.tests.SdtIntercalarRolTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.tests.SdtIntercalarRolTestSDT> aP0_Gxm2rootcol )
      {
         intercalarroltestdata objintercalarroltestdata;
         objintercalarroltestdata = new intercalarroltestdata();
         objintercalarroltestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.tests.SdtIntercalarRolTestSDT>( context, "IntercalarRolTestSDT", "ProyectoUMG") ;
         objintercalarroltestdata.context.SetSubmitInitialConfig(context);
         objintercalarroltestdata.initialize();
         Submit( executePrivateCatch,objintercalarroltestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((intercalarroltestdata)stateInfo).executePrivate();
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
         Gxm1intercalarroltestsdt = new GeneXus.Programs.tests.SdtIntercalarRolTestSDT(context);
         Gxm2rootcol.Add(Gxm1intercalarroltestsdt, 0);
         Gxm1intercalarroltestsdt.gxTpr_Testcaseid = "1";
         Gxm1intercalarroltestsdt.gxTpr_Tableroid = 1;
         Gxm1intercalarroltestsdt.gxTpr_Expectedtableroid = 1;
         Gxm1intercalarroltestsdt.gxTpr_Msgtableroid = "El tablero especificado no existe";
         Gxm1intercalarroltestsdt.gxTpr_Participantetableroid = 7;
         Gxm1intercalarroltestsdt.gxTpr_Expectedparticipantetableroid = 7;
         Gxm1intercalarroltestsdt.gxTpr_Msgparticipantetableroid = "El usuario especificado no existe";
         Gxm1intercalarroltestsdt.gxTpr_Rol = 2;
         Gxm1intercalarroltestsdt.gxTpr_Expectedrol = 2;
         Gxm1intercalarroltestsdt.gxTpr_Msgrol = "El rol especificado no existe";
         Gxm1intercalarroltestsdt = new GeneXus.Programs.tests.SdtIntercalarRolTestSDT(context);
         Gxm2rootcol.Add(Gxm1intercalarroltestsdt, 0);
         Gxm1intercalarroltestsdt.gxTpr_Testcaseid = "2";
         Gxm1intercalarroltestsdt.gxTpr_Tableroid = 8;
         Gxm1intercalarroltestsdt.gxTpr_Expectedtableroid = 8;
         Gxm1intercalarroltestsdt.gxTpr_Msgtableroid = "El tablero especificado no existe";
         Gxm1intercalarroltestsdt.gxTpr_Participantetableroid = 6;
         Gxm1intercalarroltestsdt.gxTpr_Expectedparticipantetableroid = 6;
         Gxm1intercalarroltestsdt.gxTpr_Msgparticipantetableroid = "El usuario especificado no existe";
         Gxm1intercalarroltestsdt.gxTpr_Rol = 3;
         Gxm1intercalarroltestsdt.gxTpr_Expectedrol = 3;
         Gxm1intercalarroltestsdt.gxTpr_Msgrol = "El rol especificado no existe";
         Gxm1intercalarroltestsdt = new GeneXus.Programs.tests.SdtIntercalarRolTestSDT(context);
         Gxm2rootcol.Add(Gxm1intercalarroltestsdt, 0);
         Gxm1intercalarroltestsdt.gxTpr_Testcaseid = "3";
         Gxm1intercalarroltestsdt.gxTpr_Tableroid = 4;
         Gxm1intercalarroltestsdt.gxTpr_Expectedtableroid = 4;
         Gxm1intercalarroltestsdt.gxTpr_Msgtableroid = "El tablero especificado no existe";
         Gxm1intercalarroltestsdt.gxTpr_Participantetableroid = 13;
         Gxm1intercalarroltestsdt.gxTpr_Expectedparticipantetableroid = 13;
         Gxm1intercalarroltestsdt.gxTpr_Msgparticipantetableroid = "El usuario especificado no existe";
         Gxm1intercalarroltestsdt.gxTpr_Rol = 2;
         Gxm1intercalarroltestsdt.gxTpr_Expectedrol = 2;
         Gxm1intercalarroltestsdt.gxTpr_Msgrol = "El rol especificado no existe";
         Gxm1intercalarroltestsdt = new GeneXus.Programs.tests.SdtIntercalarRolTestSDT(context);
         Gxm2rootcol.Add(Gxm1intercalarroltestsdt, 0);
         Gxm1intercalarroltestsdt.gxTpr_Testcaseid = "4";
         Gxm1intercalarroltestsdt.gxTpr_Tableroid = 2;
         Gxm1intercalarroltestsdt.gxTpr_Expectedtableroid = 2;
         Gxm1intercalarroltestsdt.gxTpr_Msgtableroid = "El tablero especificado no existe";
         Gxm1intercalarroltestsdt.gxTpr_Participantetableroid = 8;
         Gxm1intercalarroltestsdt.gxTpr_Expectedparticipantetableroid = 8;
         Gxm1intercalarroltestsdt.gxTpr_Msgparticipantetableroid = "El usuario especificado no existe";
         Gxm1intercalarroltestsdt.gxTpr_Rol = 1;
         Gxm1intercalarroltestsdt.gxTpr_Expectedrol = 1;
         Gxm1intercalarroltestsdt.gxTpr_Msgrol = "El rol especificado no existe";
         Gxm1intercalarroltestsdt = new GeneXus.Programs.tests.SdtIntercalarRolTestSDT(context);
         Gxm2rootcol.Add(Gxm1intercalarroltestsdt, 0);
         Gxm1intercalarroltestsdt.gxTpr_Testcaseid = "5";
         Gxm1intercalarroltestsdt.gxTpr_Tableroid = 5;
         Gxm1intercalarroltestsdt.gxTpr_Expectedtableroid = 5;
         Gxm1intercalarroltestsdt.gxTpr_Msgtableroid = "El tablero especificado no existe";
         Gxm1intercalarroltestsdt.gxTpr_Participantetableroid = 10;
         Gxm1intercalarroltestsdt.gxTpr_Expectedparticipantetableroid = 10;
         Gxm1intercalarroltestsdt.gxTpr_Msgparticipantetableroid = "El usuario especificado no existe";
         Gxm1intercalarroltestsdt.gxTpr_Rol = 3;
         Gxm1intercalarroltestsdt.gxTpr_Expectedrol = 3;
         Gxm1intercalarroltestsdt.gxTpr_Msgrol = "El rol especificado no existe";
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
         Gxm1intercalarroltestsdt = new GeneXus.Programs.tests.SdtIntercalarRolTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.tests.SdtIntercalarRolTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtIntercalarRolTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.tests.SdtIntercalarRolTestSDT Gxm1intercalarroltestsdt ;
   }

}
