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
   public class getactividadescompletadas : GXProcedure
   {
      public getactividadescompletadas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getactividadescompletadas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref short aP1_TareaId ,
                           ref short aP2_contador )
      {
         this.A9TableroId = aP0_TableroId;
         this.A12TareaId = aP1_TareaId;
         this.AV8contador = aP2_contador;
         initialize();
         executePrivate();
         aP0_TableroId=this.A9TableroId;
         aP1_TareaId=this.A12TareaId;
         aP2_contador=this.AV8contador;
      }

      public short executeUdp( ref short aP0_TableroId ,
                               ref short aP1_TareaId )
      {
         execute(ref aP0_TableroId, ref aP1_TareaId, ref aP2_contador);
         return AV8contador ;
      }

      public void executeSubmit( ref short aP0_TableroId ,
                                 ref short aP1_TareaId ,
                                 ref short aP2_contador )
      {
         getactividadescompletadas objgetactividadescompletadas;
         objgetactividadescompletadas = new getactividadescompletadas();
         objgetactividadescompletadas.A9TableroId = aP0_TableroId;
         objgetactividadescompletadas.A12TareaId = aP1_TareaId;
         objgetactividadescompletadas.AV8contador = aP2_contador;
         objgetactividadescompletadas.context.SetSubmitInitialConfig(context);
         objgetactividadescompletadas.initialize();
         Submit( executePrivateCatch,objgetactividadescompletadas);
         aP0_TableroId=this.A9TableroId;
         aP1_TareaId=this.A12TareaId;
         aP2_contador=this.AV8contador;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getactividadescompletadas)stateInfo).executePrivate();
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
         AV8contador = 0;
         /* Optimized group. */
         /* Using cursor P000Q2 */
         pr_default.execute(0, new Object[] {A9TableroId, A12TareaId});
         cV8contador = P000Q2_AV8contador[0];
         pr_default.close(0);
         AV8contador = (short)(AV8contador+cV8contador*1);
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
         P000Q2_AV8contador = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getactividadescompletadas__default(),
            new Object[][] {
                new Object[] {
               P000Q2_AV8contador
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A9TableroId ;
      private short A12TareaId ;
      private short AV8contador ;
      private short cV8contador ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private short aP1_TareaId ;
      private short aP2_contador ;
      private IDataStoreProvider pr_default ;
      private short[] P000Q2_AV8contador ;
   }

   public class getactividadescompletadas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000Q2;
          prmP000Q2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000Q2", "SELECT COUNT(*) FROM [Actividades] WHERE ([TableroId] = @TableroId and [TareaId] = @TareaId) AND ([ActividadEstado] = 0) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Q2,1, GxCacheFrequency.OFF ,true,false )
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
