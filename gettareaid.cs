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
   public class gettareaid : GXProcedure
   {
      public gettareaid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gettareaid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           out short aP1_TareaId )
      {
         this.A9TableroId = aP0_TableroId;
         this.AV9TareaId = 0 ;
         initialize();
         executePrivate();
         aP0_TableroId=this.A9TableroId;
         aP1_TareaId=this.AV9TareaId;
      }

      public short executeUdp( ref short aP0_TableroId )
      {
         execute(ref aP0_TableroId, out aP1_TareaId);
         return AV9TareaId ;
      }

      public void executeSubmit( ref short aP0_TableroId ,
                                 out short aP1_TareaId )
      {
         gettareaid objgettareaid;
         objgettareaid = new gettareaid();
         objgettareaid.A9TableroId = aP0_TableroId;
         objgettareaid.AV9TareaId = 0 ;
         objgettareaid.context.SetSubmitInitialConfig(context);
         objgettareaid.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgettareaid);
         aP0_TableroId=this.A9TableroId;
         aP1_TareaId=this.AV9TareaId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gettareaid)stateInfo).executePrivate();
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
         /* Using cursor P000M2 */
         pr_default.execute(0, new Object[] {A9TableroId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A12TareaId = P000M2_A12TareaId[0];
            AV9TareaId = A12TareaId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV9TareaId = (short)(AV9TareaId+1);
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
         P000M2_A9TableroId = new short[1] ;
         P000M2_A12TareaId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gettareaid__default(),
            new Object[][] {
                new Object[] {
               P000M2_A9TableroId, P000M2_A12TareaId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A9TableroId ;
      private short AV9TareaId ;
      private short A12TareaId ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private IDataStoreProvider pr_default ;
      private short[] P000M2_A9TableroId ;
      private short[] P000M2_A12TareaId ;
      private short aP1_TareaId ;
   }

   public class gettareaid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000M2;
          prmP000M2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000M2", "SELECT TOP 1 [TableroId], [TareaId] FROM [Tareas] WHERE [TableroId] = @TableroId ORDER BY [TableroId], [TareaId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000M2,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
