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
   public class cambiarparticipantesinvitados : GXProcedure
   {
      public cambiarparticipantesinvitados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public cambiarparticipantesinvitados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref short aP1_UsuarioId ,
                           ref bool aP2_Result )
      {
         this.A9TableroId = aP0_TableroId;
         this.AV11UsuarioId = aP1_UsuarioId;
         this.AV16Result = aP2_Result;
         initialize();
         executePrivate();
         aP0_TableroId=this.A9TableroId;
         aP1_UsuarioId=this.AV11UsuarioId;
         aP2_Result=this.AV16Result;
      }

      public bool executeUdp( ref short aP0_TableroId ,
                              ref short aP1_UsuarioId )
      {
         execute(ref aP0_TableroId, ref aP1_UsuarioId, ref aP2_Result);
         return AV16Result ;
      }

      public void executeSubmit( ref short aP0_TableroId ,
                                 ref short aP1_UsuarioId ,
                                 ref bool aP2_Result )
      {
         cambiarparticipantesinvitados objcambiarparticipantesinvitados;
         objcambiarparticipantesinvitados = new cambiarparticipantesinvitados();
         objcambiarparticipantesinvitados.A9TableroId = aP0_TableroId;
         objcambiarparticipantesinvitados.AV11UsuarioId = aP1_UsuarioId;
         objcambiarparticipantesinvitados.AV16Result = aP2_Result;
         objcambiarparticipantesinvitados.context.SetSubmitInitialConfig(context);
         objcambiarparticipantesinvitados.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcambiarparticipantesinvitados);
         aP0_TableroId=this.A9TableroId;
         aP1_UsuarioId=this.AV11UsuarioId;
         aP2_Result=this.AV16Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cambiarparticipantesinvitados)stateInfo).executePrivate();
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
         AV16Result = false;
         AV13TableroId = A9TableroId;
         AV9Participantes = new SdtParticipantes(context);
         AV9Participantes.gxTpr_Tableroid = AV13TableroId;
         AV9Participantes.gxTpr_Participantetableroid = AV11UsuarioId;
         AV9Participantes.gxTpr_Registrofecha = DateTimeUtil.ServerNow( context, pr_default);
         AV9Participantes.gxTpr_Participanterolid = 3;
         AV9Participantes.gxTpr_Participantetableroestado = true;
         AV9Participantes.Save();
         AV14Usuarios.Load(AV11UsuarioId);
         /* Using cursor P000K2 */
         pr_default.execute(0, new Object[] {A9TableroId, AV14Usuarios.gxTpr_Usuarioemail});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A44RegistroInvitadoEmail = P000K2_A44RegistroInvitadoEmail[0];
            A40RegistroInvitadoId = P000K2_A40RegistroInvitadoId[0];
            AV15RegistroInvitadoId = A40RegistroInvitadoId;
            AV10Invitados.Load(A9TableroId, AV15RegistroInvitadoId);
            AV10Invitados.Delete();
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV9Participantes.Success() && AV10Invitados.Success() )
         {
            context.CommitDataStores("cambiarparticipantesinvitados",pr_default);
            AV16Result = true;
         }
         else
         {
            context.RollbackDataStores("cambiarparticipantesinvitados",pr_default);
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
         AV9Participantes = new SdtParticipantes(context);
         AV14Usuarios = new SdtUsuarios(context);
         scmdbuf = "";
         P000K2_A9TableroId = new short[1] ;
         P000K2_A44RegistroInvitadoEmail = new string[] {""} ;
         P000K2_A40RegistroInvitadoId = new short[1] ;
         A44RegistroInvitadoEmail = "";
         AV10Invitados = new SdtInvitados(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cambiarparticipantesinvitados__default(),
            new Object[][] {
                new Object[] {
               P000K2_A9TableroId, P000K2_A44RegistroInvitadoEmail, P000K2_A40RegistroInvitadoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A9TableroId ;
      private short AV11UsuarioId ;
      private short AV13TableroId ;
      private short A40RegistroInvitadoId ;
      private short AV15RegistroInvitadoId ;
      private string scmdbuf ;
      private bool AV16Result ;
      private string A44RegistroInvitadoEmail ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private short aP1_UsuarioId ;
      private bool aP2_Result ;
      private IDataStoreProvider pr_default ;
      private short[] P000K2_A9TableroId ;
      private string[] P000K2_A44RegistroInvitadoEmail ;
      private short[] P000K2_A40RegistroInvitadoId ;
      private SdtParticipantes AV9Participantes ;
      private SdtInvitados AV10Invitados ;
      private SdtUsuarios AV14Usuarios ;
   }

   public class cambiarparticipantesinvitados__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000K2;
          prmP000K2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@AV14Usuarios__Usuarioemail",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000K2", "SELECT TOP 1 [TableroId], [RegistroInvitadoEmail], [RegistroInvitadoId] FROM [Invitados] WHERE ([TableroId] = @TableroId) AND ([RegistroInvitadoEmail] = @AV14Usuarios__Usuarioemail) ORDER BY [TableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000K2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
