using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class participantesconversion : GXProcedure
   {
      public participantesconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public participantesconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         participantesconversion objparticipantesconversion;
         objparticipantesconversion = new participantesconversion();
         objparticipantesconversion.context.SetSubmitInitialConfig(context);
         objparticipantesconversion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objparticipantesconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((participantesconversion)stateInfo).executePrivate();
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
         /* Using cursor PARTICIPAN2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A17PropietarioId = PARTICIPAN2_A17PropietarioId[0];
            A1RolId = PARTICIPAN2_A1RolId[0];
            n1RolId = PARTICIPAN2_n1RolId[0];
            A20RegistroFecha = PARTICIPAN2_A20RegistroFecha[0];
            A18ParticipanteTableroId = PARTICIPAN2_A18ParticipanteTableroId[0];
            A9TableroId = PARTICIPAN2_A9TableroId[0];
            A17PropietarioId = PARTICIPAN2_A17PropietarioId[0];
            A1RolId = PARTICIPAN2_A1RolId[0];
            n1RolId = PARTICIPAN2_n1RolId[0];
            /*
               INSERT RECORD ON TABLE GXA0011

            */
            AV2TableroId = A9TableroId;
            AV3ParticipanteTableroId = A18ParticipanteTableroId;
            AV4RegistroFecha = A20RegistroFecha;
            if ( PARTICIPAN2_n1RolId[0] )
            {
               AV5ParticipanteRolId = 0;
            }
            else
            {
               AV5ParticipanteRolId = A1RolId;
            }
            /* Using cursor PARTICIPAN3 */
            pr_default.execute(1, new Object[] {AV2TableroId, AV3ParticipanteTableroId, AV4RegistroFecha, AV5ParticipanteRolId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("GXA0011");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         PARTICIPAN2_A17PropietarioId = new short[1] ;
         PARTICIPAN2_A1RolId = new short[1] ;
         PARTICIPAN2_n1RolId = new bool[] {false} ;
         PARTICIPAN2_A20RegistroFecha = new DateTime[] {DateTime.MinValue} ;
         PARTICIPAN2_A18ParticipanteTableroId = new short[1] ;
         PARTICIPAN2_A9TableroId = new short[1] ;
         A20RegistroFecha = (DateTime)(DateTime.MinValue);
         AV4RegistroFecha = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.participantesconversion__default(),
            new Object[][] {
                new Object[] {
               PARTICIPAN2_A17PropietarioId, PARTICIPAN2_A1RolId, PARTICIPAN2_n1RolId, PARTICIPAN2_A20RegistroFecha, PARTICIPAN2_A18ParticipanteTableroId, PARTICIPAN2_A9TableroId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A17PropietarioId ;
      private short A1RolId ;
      private short A18ParticipanteTableroId ;
      private short A9TableroId ;
      private short AV2TableroId ;
      private short AV3ParticipanteTableroId ;
      private short AV5ParticipanteRolId ;
      private int GIGXA0011 ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A20RegistroFecha ;
      private DateTime AV4RegistroFecha ;
      private bool n1RolId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] PARTICIPAN2_A17PropietarioId ;
      private short[] PARTICIPAN2_A1RolId ;
      private bool[] PARTICIPAN2_n1RolId ;
      private DateTime[] PARTICIPAN2_A20RegistroFecha ;
      private short[] PARTICIPAN2_A18ParticipanteTableroId ;
      private short[] PARTICIPAN2_A9TableroId ;
   }

   public class participantesconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmPARTICIPAN2;
          prmPARTICIPAN2 = new Object[] {
          };
          Object[] prmPARTICIPAN3;
          prmPARTICIPAN3 = new Object[] {
          new ParDef("@AV2TableroId",GXType.Int16,4,0) ,
          new ParDef("@AV3ParticipanteTableroId",GXType.Int16,4,0) ,
          new ParDef("@AV4RegistroFecha",GXType.DateTime,8,5) ,
          new ParDef("@AV5ParticipanteRolId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("PARTICIPAN2", "SELECT T2.[PropietarioId] AS PropietarioId, T3.[RolId], T1.[RegistroFecha], T1.[ParticipanteTableroId], T1.[TableroId] FROM (([Participantes] T1 INNER JOIN [Tableros] T2 ON T2.[TableroId] = T1.[TableroId]) INNER JOIN [Usuarios] T3 ON T3.[UsuarioId] = T2.[PropietarioId]) ORDER BY T1.[TableroId], T1.[ParticipanteTableroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmPARTICIPAN2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("PARTICIPAN3", "INSERT INTO [GXA0011]([TableroId], [ParticipanteTableroId], [RegistroFecha], [ParticipanteRolId]) VALUES(@AV2TableroId, @AV3ParticipanteTableroId, @AV4RegistroFecha, @AV5ParticipanteRolId)", GxErrorMask.GX_NOMASK,prmPARTICIPAN3)
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
