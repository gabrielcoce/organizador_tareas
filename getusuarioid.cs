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
   public class getusuarioid : GXProcedure
   {
      public getusuarioid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getusuarioid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_UsuarioId )
      {
         this.AV8UsuarioId = 0 ;
         initialize();
         executePrivate();
         aP0_UsuarioId=this.AV8UsuarioId;
      }

      public short executeUdp( )
      {
         execute(out aP0_UsuarioId);
         return AV8UsuarioId ;
      }

      public void executeSubmit( out short aP0_UsuarioId )
      {
         getusuarioid objgetusuarioid;
         objgetusuarioid = new getusuarioid();
         objgetusuarioid.AV8UsuarioId = 0 ;
         objgetusuarioid.context.SetSubmitInitialConfig(context);
         objgetusuarioid.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetusuarioid);
         aP0_UsuarioId=this.AV8UsuarioId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getusuarioid)stateInfo).executePrivate();
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
         AV8UsuarioId = 0;
         /* Using cursor P000C2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A3UsuarioId = P000C2_A3UsuarioId[0];
            AV8UsuarioId = A3UsuarioId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8UsuarioId = (short)(AV8UsuarioId+1);
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
         P000C2_A3UsuarioId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getusuarioid__default(),
            new Object[][] {
                new Object[] {
               P000C2_A3UsuarioId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8UsuarioId ;
      private short A3UsuarioId ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000C2_A3UsuarioId ;
      private short aP0_UsuarioId ;
   }

   public class getusuarioid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000C2;
          prmP000C2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000C2", "SELECT TOP 1 [UsuarioId] FROM [Usuarios] ORDER BY [UsuarioId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000C2,1, GxCacheFrequency.OFF ,false,true )
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
