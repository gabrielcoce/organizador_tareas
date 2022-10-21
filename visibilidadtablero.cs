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
   public class visibilidadtablero : GXProcedure
   {
      public visibilidadtablero( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public visibilidadtablero( IGxContext context )
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
         visibilidadtablero objvisibilidadtablero;
         objvisibilidadtablero = new visibilidadtablero();
         objvisibilidadtablero.A9TableroId = aP0_TableroId;
         objvisibilidadtablero.AV8dir = aP1_dir;
         objvisibilidadtablero.context.SetSubmitInitialConfig(context);
         objvisibilidadtablero.initialize();
         Submit( executePrivateCatch,objvisibilidadtablero);
         aP0_TableroId=this.A9TableroId;
         aP1_dir=this.AV8dir;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((visibilidadtablero)stateInfo).executePrivate();
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
            /* Using cursor P000H2 */
            pr_default.execute(0, new Object[] {A9TableroId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A35TableroVisibilidad = P000H2_A35TableroVisibilidad[0];
               A35TableroVisibilidad = false;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P000H3 */
               pr_default.execute(1, new Object[] {A35TableroVisibilidad, A9TableroId});
               pr_default.close(1);
               dsDefault.SmartCacheProvider.SetUpdated("Tableros");
               if (true) break;
               /* Using cursor P000H4 */
               pr_default.execute(2, new Object[] {A35TableroVisibilidad, A9TableroId});
               pr_default.close(2);
               dsDefault.SmartCacheProvider.SetUpdated("Tableros");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         else if ( AV8dir == 2 )
         {
            /* Using cursor P000H5 */
            pr_default.execute(3, new Object[] {A9TableroId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A35TableroVisibilidad = P000H5_A35TableroVisibilidad[0];
               A35TableroVisibilidad = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P000H6 */
               pr_default.execute(4, new Object[] {A35TableroVisibilidad, A9TableroId});
               pr_default.close(4);
               dsDefault.SmartCacheProvider.SetUpdated("Tableros");
               if (true) break;
               /* Using cursor P000H7 */
               pr_default.execute(5, new Object[] {A35TableroVisibilidad, A9TableroId});
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
         context.CommitDataStores("visibilidadtablero",pr_default);
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
         P000H2_A9TableroId = new short[1] ;
         P000H2_A35TableroVisibilidad = new bool[] {false} ;
         P000H5_A9TableroId = new short[1] ;
         P000H5_A35TableroVisibilidad = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.visibilidadtablero__default(),
            new Object[][] {
                new Object[] {
               P000H2_A9TableroId, P000H2_A35TableroVisibilidad
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P000H5_A9TableroId, P000H5_A35TableroVisibilidad
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
      private bool A35TableroVisibilidad ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private short aP1_dir ;
      private IDataStoreProvider pr_default ;
      private short[] P000H2_A9TableroId ;
      private bool[] P000H2_A35TableroVisibilidad ;
      private short[] P000H5_A9TableroId ;
      private bool[] P000H5_A35TableroVisibilidad ;
   }

   public class visibilidadtablero__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000H2;
          prmP000H2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmP000H3;
          prmP000H3 = new Object[] {
          new ParDef("@TableroVisibilidad",GXType.Boolean,1,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmP000H4;
          prmP000H4 = new Object[] {
          new ParDef("@TableroVisibilidad",GXType.Boolean,1,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmP000H5;
          prmP000H5 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmP000H6;
          prmP000H6 = new Object[] {
          new ParDef("@TableroVisibilidad",GXType.Boolean,1,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmP000H7;
          prmP000H7 = new Object[] {
          new ParDef("@TableroVisibilidad",GXType.Boolean,1,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000H2", "SELECT TOP 1 [TableroId], [TableroVisibilidad] FROM [Tableros] WITH (UPDLOCK) WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000H3", "UPDATE [Tableros] SET [TableroVisibilidad]=@TableroVisibilidad  WHERE [TableroId] = @TableroId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000H3)
             ,new CursorDef("P000H4", "UPDATE [Tableros] SET [TableroVisibilidad]=@TableroVisibilidad  WHERE [TableroId] = @TableroId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000H4)
             ,new CursorDef("P000H5", "SELECT TOP 1 [TableroId], [TableroVisibilidad] FROM [Tableros] WITH (UPDLOCK) WHERE [TableroId] = @TableroId ORDER BY [TableroId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000H6", "UPDATE [Tableros] SET [TableroVisibilidad]=@TableroVisibilidad  WHERE [TableroId] = @TableroId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000H6)
             ,new CursorDef("P000H7", "UPDATE [Tableros] SET [TableroVisibilidad]=@TableroVisibilidad  WHERE [TableroId] = @TableroId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000H7)
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
