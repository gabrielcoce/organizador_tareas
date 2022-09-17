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
   public class intercalarrol : GXProcedure
   {
      public intercalarrol( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public intercalarrol( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref short aP1_ParticipanteTableroId ,
                           ref short aP2_rol )
      {
         this.A9TableroId = aP0_TableroId;
         this.A18ParticipanteTableroId = aP1_ParticipanteTableroId;
         this.AV8rol = aP2_rol;
         initialize();
         executePrivate();
         aP0_TableroId=this.A9TableroId;
         aP1_ParticipanteTableroId=this.A18ParticipanteTableroId;
         aP2_rol=this.AV8rol;
      }

      public short executeUdp( ref short aP0_TableroId ,
                               ref short aP1_ParticipanteTableroId )
      {
         execute(ref aP0_TableroId, ref aP1_ParticipanteTableroId, ref aP2_rol);
         return AV8rol ;
      }

      public void executeSubmit( ref short aP0_TableroId ,
                                 ref short aP1_ParticipanteTableroId ,
                                 ref short aP2_rol )
      {
         intercalarrol objintercalarrol;
         objintercalarrol = new intercalarrol();
         objintercalarrol.A9TableroId = aP0_TableroId;
         objintercalarrol.A18ParticipanteTableroId = aP1_ParticipanteTableroId;
         objintercalarrol.AV8rol = aP2_rol;
         objintercalarrol.context.SetSubmitInitialConfig(context);
         objintercalarrol.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objintercalarrol);
         aP0_TableroId=this.A9TableroId;
         aP1_ParticipanteTableroId=this.A18ParticipanteTableroId;
         aP2_rol=this.AV8rol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((intercalarrol)stateInfo).executePrivate();
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
         if ( AV8rol == 2 )
         {
            /* Using cursor P000L2 */
            pr_default.execute(0, new Object[] {A9TableroId, A18ParticipanteTableroId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A39ParticipanteRolId = P000L2_A39ParticipanteRolId[0];
               A39ParticipanteRolId = 3;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P000L3 */
               pr_default.execute(1, new Object[] {A39ParticipanteRolId, A9TableroId, A18ParticipanteTableroId});
               pr_default.close(1);
               dsDefault.SmartCacheProvider.SetUpdated("Participantes");
               if (true) break;
               /* Using cursor P000L4 */
               pr_default.execute(2, new Object[] {A39ParticipanteRolId, A9TableroId, A18ParticipanteTableroId});
               pr_default.close(2);
               dsDefault.SmartCacheProvider.SetUpdated("Participantes");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         else if ( AV8rol == 3 )
         {
            /* Using cursor P000L5 */
            pr_default.execute(3, new Object[] {A9TableroId, A18ParticipanteTableroId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A39ParticipanteRolId = P000L5_A39ParticipanteRolId[0];
               A39ParticipanteRolId = 2;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P000L6 */
               pr_default.execute(4, new Object[] {A39ParticipanteRolId, A9TableroId, A18ParticipanteTableroId});
               pr_default.close(4);
               dsDefault.SmartCacheProvider.SetUpdated("Participantes");
               if (true) break;
               /* Using cursor P000L7 */
               pr_default.execute(5, new Object[] {A39ParticipanteRolId, A9TableroId, A18ParticipanteTableroId});
               pr_default.close(5);
               dsDefault.SmartCacheProvider.SetUpdated("Participantes");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("intercalarrol",pr_default);
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
         P000L2_A9TableroId = new short[1] ;
         P000L2_A18ParticipanteTableroId = new short[1] ;
         P000L2_A39ParticipanteRolId = new short[1] ;
         P000L5_A9TableroId = new short[1] ;
         P000L5_A18ParticipanteTableroId = new short[1] ;
         P000L5_A39ParticipanteRolId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.intercalarrol__default(),
            new Object[][] {
                new Object[] {
               P000L2_A9TableroId, P000L2_A18ParticipanteTableroId, P000L2_A39ParticipanteRolId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P000L5_A9TableroId, P000L5_A18ParticipanteTableroId, P000L5_A39ParticipanteRolId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A9TableroId ;
      private short A18ParticipanteTableroId ;
      private short AV8rol ;
      private short A39ParticipanteRolId ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private short aP1_ParticipanteTableroId ;
      private short aP2_rol ;
      private IDataStoreProvider pr_default ;
      private short[] P000L2_A9TableroId ;
      private short[] P000L2_A18ParticipanteTableroId ;
      private short[] P000L2_A39ParticipanteRolId ;
      private short[] P000L5_A9TableroId ;
      private short[] P000L5_A18ParticipanteTableroId ;
      private short[] P000L5_A39ParticipanteRolId ;
   }

   public class intercalarrol__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new UpdateCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000L2;
          prmP000L2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmP000L3;
          prmP000L3 = new Object[] {
          new ParDef("@ParticipanteRolId",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmP000L4;
          prmP000L4 = new Object[] {
          new ParDef("@ParticipanteRolId",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmP000L5;
          prmP000L5 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmP000L6;
          prmP000L6 = new Object[] {
          new ParDef("@ParticipanteRolId",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmP000L7;
          prmP000L7 = new Object[] {
          new ParDef("@ParticipanteRolId",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000L2", "SELECT TOP 1 [TableroId], [ParticipanteTableroId], [ParticipanteRolId] FROM [Participantes] WITH (UPDLOCK) WHERE [TableroId] = @TableroId and [ParticipanteTableroId] = @ParticipanteTableroId ORDER BY [TableroId], [ParticipanteTableroId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000L2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000L3", "UPDATE [Participantes] SET [ParticipanteRolId]=@ParticipanteRolId  WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000L3)
             ,new CursorDef("P000L4", "UPDATE [Participantes] SET [ParticipanteRolId]=@ParticipanteRolId  WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000L4)
             ,new CursorDef("P000L5", "SELECT TOP 1 [TableroId], [ParticipanteTableroId], [ParticipanteRolId] FROM [Participantes] WITH (UPDLOCK) WHERE [TableroId] = @TableroId and [ParticipanteTableroId] = @ParticipanteTableroId ORDER BY [TableroId], [ParticipanteTableroId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000L5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000L6", "UPDATE [Participantes] SET [ParticipanteRolId]=@ParticipanteRolId  WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000L6)
             ,new CursorDef("P000L7", "UPDATE [Participantes] SET [ParticipanteRolId]=@ParticipanteRolId  WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000L7)
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
