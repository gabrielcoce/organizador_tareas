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
   public class anadirusuariocolaborador : GXProcedure
   {
      public anadirusuariocolaborador( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public anadirusuariocolaborador( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref short aP1_RegistroInvitadoId ,
                           ref bool aP2_result )
      {
         this.A9TableroId = aP0_TableroId;
         this.AV10RegistroInvitadoId = aP1_RegistroInvitadoId;
         this.AV14result = aP2_result;
         initialize();
         executePrivate();
         aP0_TableroId=this.A9TableroId;
         aP1_RegistroInvitadoId=this.AV10RegistroInvitadoId;
         aP2_result=this.AV14result;
      }

      public bool executeUdp( ref short aP0_TableroId ,
                              ref short aP1_RegistroInvitadoId )
      {
         execute(ref aP0_TableroId, ref aP1_RegistroInvitadoId, ref aP2_result);
         return AV14result ;
      }

      public void executeSubmit( ref short aP0_TableroId ,
                                 ref short aP1_RegistroInvitadoId ,
                                 ref bool aP2_result )
      {
         anadirusuariocolaborador objanadirusuariocolaborador;
         objanadirusuariocolaborador = new anadirusuariocolaborador();
         objanadirusuariocolaborador.A9TableroId = aP0_TableroId;
         objanadirusuariocolaborador.AV10RegistroInvitadoId = aP1_RegistroInvitadoId;
         objanadirusuariocolaborador.AV14result = aP2_result;
         objanadirusuariocolaborador.context.SetSubmitInitialConfig(context);
         objanadirusuariocolaborador.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objanadirusuariocolaborador);
         aP0_TableroId=this.A9TableroId;
         aP1_RegistroInvitadoId=this.AV10RegistroInvitadoId;
         aP2_result=this.AV14result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((anadirusuariocolaborador)stateInfo).executePrivate();
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
         /* Using cursor P000N2 */
         pr_default.execute(0, new Object[] {AV10RegistroInvitadoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A3UsuarioId = P000N2_A3UsuarioId[0];
            AV16UsuarioId = A3UsuarioId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV14result = false;
         AV12TableroId = A9TableroId;
         AV8Participantes = new SdtParticipantes(context);
         AV8Participantes.gxTpr_Tableroid = AV12TableroId;
         AV8Participantes.gxTpr_Participantetableroid = AV10RegistroInvitadoId;
         AV8Participantes.gxTpr_Registrofecha = DateTimeUtil.ServerNow( context, pr_default);
         AV8Participantes.gxTpr_Participanterolid = 3;
         AV8Participantes.gxTpr_Participantetableroestado = true;
         AV8Participantes.Insert();
         if ( AV8Participantes.Success() )
         {
            context.CommitDataStores("anadirusuariocolaborador",pr_default);
            AV14result = true;
         }
         else
         {
            GX_msglist.addItem(AV8Participantes.GetMessages().ToJSonString(false));
            context.RollbackDataStores("anadirusuariocolaborador",pr_default);
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
         scmdbuf = "";
         P000N2_A3UsuarioId = new short[1] ;
         AV8Participantes = new SdtParticipantes(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.anadirusuariocolaborador__default(),
            new Object[][] {
                new Object[] {
               P000N2_A3UsuarioId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A9TableroId ;
      private short AV10RegistroInvitadoId ;
      private short A3UsuarioId ;
      private short AV16UsuarioId ;
      private short AV12TableroId ;
      private string scmdbuf ;
      private bool AV14result ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private short aP1_RegistroInvitadoId ;
      private bool aP2_result ;
      private IDataStoreProvider pr_default ;
      private short[] P000N2_A3UsuarioId ;
      private SdtParticipantes AV8Participantes ;
   }

   public class anadirusuariocolaborador__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000N2;
          prmP000N2 = new Object[] {
          new ParDef("@AV10RegistroInvitadoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000N2", "SELECT TOP 1 [UsuarioId] FROM [Usuarios] WHERE [UsuarioId] = @AV10RegistroInvitadoId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000N2,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
