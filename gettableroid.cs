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
   public class gettableroid : GXProcedure
   {
      public gettableroid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gettableroid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_TableroId )
      {
         this.AV8TableroId = 0 ;
         initialize();
         executePrivate();
         aP0_TableroId=this.AV8TableroId;
      }

      public short executeUdp( )
      {
         execute(out aP0_TableroId);
         return AV8TableroId ;
      }

      public void executeSubmit( out short aP0_TableroId )
      {
         gettableroid objgettableroid;
         objgettableroid = new gettableroid();
         objgettableroid.AV8TableroId = 0 ;
         objgettableroid.context.SetSubmitInitialConfig(context);
         objgettableroid.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgettableroid);
         aP0_TableroId=this.AV8TableroId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gettableroid)stateInfo).executePrivate();
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
         /* Using cursor P000F2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A9TableroId = P000F2_A9TableroId[0];
            AV8TableroId = A9TableroId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8TableroId = (short)(AV8TableroId+1);
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
         P000F2_A9TableroId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gettableroid__default(),
            new Object[][] {
                new Object[] {
               P000F2_A9TableroId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8TableroId ;
      private short A9TableroId ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000F2_A9TableroId ;
      private short aP0_TableroId ;
   }

   public class gettableroid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000F2;
          prmP000F2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000F2", "SELECT TOP 1 [TableroId] FROM [Tableros] ORDER BY [TableroId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F2,1, GxCacheFrequency.OFF ,false,true )
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
