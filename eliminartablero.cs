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
   public class eliminartablero : GXProcedure
   {
      public eliminartablero( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public eliminartablero( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref short aP1_dir )
      {
         this.A9TableroId = aP0_TableroId;
         this.AV8dir = aP1_dir;
         initialize();
         executePrivate();
         aP0_TableroId=this.A9TableroId;
         aP1_dir=this.AV8dir;
      }

      public short executeUdp( ref short aP0_TableroId )
      {
         execute(ref aP0_TableroId, ref aP1_dir);
         return AV8dir ;
      }

      public void executeSubmit( ref short aP0_TableroId ,
                                 ref short aP1_dir )
      {
         eliminartablero objeliminartablero;
         objeliminartablero = new eliminartablero();
         objeliminartablero.A9TableroId = aP0_TableroId;
         objeliminartablero.AV8dir = aP1_dir;
         objeliminartablero.context.SetSubmitInitialConfig(context);
         objeliminartablero.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objeliminartablero);
         aP0_TableroId=this.A9TableroId;
         aP1_dir=this.AV8dir;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((eliminartablero)stateInfo).executePrivate();
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
         if ( AV8dir == 1 )
         {
            /* Using cursor P000G2 */
            pr_default.execute(0, new Object[] {A9TableroId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A34TableroEstado = P000G2_A34TableroEstado[0];
               A34TableroEstado = false;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P000G3 */
               pr_default.execute(1, new Object[] {A34TableroEstado, A9TableroId});
               pr_default.close(1);
               dsDefault.SmartCacheProvider.SetUpdated("Tableros");
               if (true) break;
               /* Using cursor P000G4 */
               pr_default.execute(2, new Object[] {A34TableroEstado, A9TableroId});
               pr_default.close(2);
               dsDefault.SmartCacheProvider.SetUpdated("Tableros");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         else if ( AV8dir == 2 )
         {
            /* Using cursor P000G5 */
            pr_default.execute(3, new Object[] {A9TableroId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A34TableroEstado = P000G5_A34TableroEstado[0];
               A34TableroEstado = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P000G6 */
               pr_default.execute(4, new Object[] {A34TableroEstado, A9TableroId});
               pr_default.close(4);
               dsDefault.SmartCacheProvider.SetUpdated("Tableros");
               if (true) break;
               /* Using cursor P000G7 */
               pr_default.execute(5, new Object[] {A34TableroEstado, A9TableroId});
               pr_default.close(5);
               dsDefault.SmartCacheProvider.SetUpdated("Tableros");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("eliminartablero",pr_default);
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
         P000G2_A9TableroId = new short[1] ;
         P000G2_A34TableroEstado = new bool[] {false} ;
         P000G5_A9TableroId = new short[1] ;
         P000G5_A34TableroEstado = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.eliminartablero__default(),
            new Object[][] {
                new Object[] {
               P000G2_A9TableroId, P000G2_A34TableroEstado
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P000G5_A9TableroId, P000G5_A34TableroEstado
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
      private short AV8dir ;
      private string scmdbuf ;
      private bool A34TableroEstado ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private short aP1_dir ;
      private IDataStoreProvider pr_default ;
      private short[] P000G2_A9TableroId ;
      private bool[] P000G2_A34TableroEstado ;
      private short[] P000G5_A9TableroId ;
      private bool[] P000G5_A34TableroEstado ;
   }

   public class eliminartablero__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmP000G3;
          prmP000G3 = new Object[] {
          new ParDef("@TableroEstado",GXType.Boolean,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmP000G4;
          prmP000G4 = new Object[] {
          new ParDef("@TableroEstado",GXType.Boolean,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmP000G5;
          prmP000G5 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmP000G6;
          prmP000G6 = new Object[] {
          new ParDef("@TableroEstado",GXType.Boolean,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmP000G7;
          prmP000G7 = new Object[] {
          new ParDef("@TableroEstado",GXType.Boolean,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT TOP 1 [TableroId], [TableroEstado] FROM [Tableros] WITH (UPDLOCK) WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000G3", "UPDATE [Tableros] SET [TableroEstado]=@TableroEstado  WHERE [TableroId] = @TableroId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000G3)
             ,new CursorDef("P000G4", "UPDATE [Tableros] SET [TableroEstado]=@TableroEstado  WHERE [TableroId] = @TableroId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000G4)
             ,new CursorDef("P000G5", "SELECT TOP 1 [TableroId], [TableroEstado] FROM [Tableros] WITH (UPDLOCK) WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000G6", "UPDATE [Tableros] SET [TableroEstado]=@TableroEstado  WHERE [TableroId] = @TableroId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000G6)
             ,new CursorDef("P000G7", "UPDATE [Tableros] SET [TableroEstado]=@TableroEstado  WHERE [TableroId] = @TableroId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000G7)
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
       }
    }

 }

}
