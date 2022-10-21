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
   public class getcomentarioid : GXProcedure
   {
      public getcomentarioid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getcomentarioid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref short aP1_TareaId ,
                           ref short aP2_ComentarioId )
      {
         this.A9TableroId = aP0_TableroId;
         this.A12TareaId = aP1_TareaId;
         this.AV8ComentarioId = aP2_ComentarioId;
         initialize();
         executePrivate();
         aP0_TableroId=this.A9TableroId;
         aP1_TareaId=this.A12TareaId;
         aP2_ComentarioId=this.AV8ComentarioId;
      }

      public short executeUdp( ref short aP0_TableroId ,
                               ref short aP1_TareaId )
      {
         execute(ref aP0_TableroId, ref aP1_TareaId, ref aP2_ComentarioId);
         return AV8ComentarioId ;
      }

      public void executeSubmit( ref short aP0_TableroId ,
                                 ref short aP1_TareaId ,
                                 ref short aP2_ComentarioId )
      {
         getcomentarioid objgetcomentarioid;
         objgetcomentarioid = new getcomentarioid();
         objgetcomentarioid.A9TableroId = aP0_TableroId;
         objgetcomentarioid.A12TareaId = aP1_TareaId;
         objgetcomentarioid.AV8ComentarioId = aP2_ComentarioId;
         objgetcomentarioid.context.SetSubmitInitialConfig(context);
         objgetcomentarioid.initialize();
         Submit( executePrivateCatch,objgetcomentarioid);
         aP0_TableroId=this.A9TableroId;
         aP1_TareaId=this.A12TareaId;
         aP2_ComentarioId=this.AV8ComentarioId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getcomentarioid)stateInfo).executePrivate();
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
         /* Using cursor P001O2 */
         pr_default.execute(0, new Object[] {A9TableroId, A12TareaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A27ComentarioId = P001O2_A27ComentarioId[0];
            AV8ComentarioId = A27ComentarioId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8ComentarioId = (short)(AV8ComentarioId+1);
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
         P001O2_A9TableroId = new short[1] ;
         P001O2_A12TareaId = new short[1] ;
         P001O2_A27ComentarioId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getcomentarioid__default(),
            new Object[][] {
                new Object[] {
               P001O2_A9TableroId, P001O2_A12TareaId, P001O2_A27ComentarioId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A9TableroId ;
      private short A12TareaId ;
      private short AV8ComentarioId ;
      private short A27ComentarioId ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private short aP1_TareaId ;
      private short aP2_ComentarioId ;
      private IDataStoreProvider pr_default ;
      private short[] P001O2_A9TableroId ;
      private short[] P001O2_A12TareaId ;
      private short[] P001O2_A27ComentarioId ;
   }

   public class getcomentarioid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001O2;
          prmP001O2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001O2", "SELECT TOP 1 [TableroId], [TareaId], [ComentarioId] FROM [TareasComentarios] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ORDER BY [TableroId], [TareaId], [ComentarioId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001O2,1, GxCacheFrequency.OFF ,false,true )
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
       }
    }

 }

}
