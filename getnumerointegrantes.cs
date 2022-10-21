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
   public class getnumerointegrantes : GXProcedure
   {
      public getnumerointegrantes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getnumerointegrantes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_TableroId ,
                           out short aP1_count )
      {
         this.A9TableroId = aP0_TableroId;
         this.AV8count = 0 ;
         initialize();
         executePrivate();
         aP1_count=this.AV8count;
      }

      public short executeUdp( short aP0_TableroId )
      {
         execute(aP0_TableroId, out aP1_count);
         return AV8count ;
      }

      public void executeSubmit( short aP0_TableroId ,
                                 out short aP1_count )
      {
         getnumerointegrantes objgetnumerointegrantes;
         objgetnumerointegrantes = new getnumerointegrantes();
         objgetnumerointegrantes.A9TableroId = aP0_TableroId;
         objgetnumerointegrantes.AV8count = 0 ;
         objgetnumerointegrantes.context.SetSubmitInitialConfig(context);
         objgetnumerointegrantes.initialize();
         Submit( executePrivateCatch,objgetnumerointegrantes);
         aP1_count=this.AV8count;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getnumerointegrantes)stateInfo).executePrivate();
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
         AV8count = 0;
         /* Optimized group. */
         /* Using cursor P000E2 */
         pr_default.execute(0, new Object[] {A9TableroId});
         cV8count = P000E2_AV8count[0];
         pr_default.close(0);
         AV8count = (short)(AV8count+cV8count*1);
         /* End optimized group. */
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
         P000E2_AV8count = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getnumerointegrantes__default(),
            new Object[][] {
                new Object[] {
               P000E2_AV8count
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A9TableroId ;
      private short AV8count ;
      private short cV8count ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000E2_AV8count ;
      private short aP1_count ;
   }

   public class getnumerointegrantes__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000E2;
          prmP000E2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000E2", "SELECT COUNT(*) FROM [Participantes] WHERE ([TableroId] = @TableroId) AND ([ParticipanteRolId] <> 1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000E2,1, GxCacheFrequency.OFF ,true,false )
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
