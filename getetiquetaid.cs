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
   public class getetiquetaid : GXProcedure
   {
      public getetiquetaid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getetiquetaid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref short aP1_EtiquetaId )
      {
         this.A9TableroId = aP0_TableroId;
         this.AV8EtiquetaId = aP1_EtiquetaId;
         initialize();
         executePrivate();
         aP0_TableroId=this.A9TableroId;
         aP1_EtiquetaId=this.AV8EtiquetaId;
      }

      public short executeUdp( ref short aP0_TableroId )
      {
         execute(ref aP0_TableroId, ref aP1_EtiquetaId);
         return AV8EtiquetaId ;
      }

      public void executeSubmit( ref short aP0_TableroId ,
                                 ref short aP1_EtiquetaId )
      {
         getetiquetaid objgetetiquetaid;
         objgetetiquetaid = new getetiquetaid();
         objgetetiquetaid.A9TableroId = aP0_TableroId;
         objgetetiquetaid.AV8EtiquetaId = aP1_EtiquetaId;
         objgetetiquetaid.context.SetSubmitInitialConfig(context);
         objgetetiquetaid.initialize();
         Submit( executePrivateCatch,objgetetiquetaid);
         aP0_TableroId=this.A9TableroId;
         aP1_EtiquetaId=this.AV8EtiquetaId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getetiquetaid)stateInfo).executePrivate();
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
         /* Using cursor P00282 */
         pr_default.execute(0, new Object[] {A9TableroId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A36EtiquetaId = P00282_A36EtiquetaId[0];
            AV8EtiquetaId = A36EtiquetaId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8EtiquetaId = (short)(AV8EtiquetaId+1);
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
         P00282_A9TableroId = new short[1] ;
         P00282_A36EtiquetaId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getetiquetaid__default(),
            new Object[][] {
                new Object[] {
               P00282_A9TableroId, P00282_A36EtiquetaId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A9TableroId ;
      private short AV8EtiquetaId ;
      private short A36EtiquetaId ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private short aP1_EtiquetaId ;
      private IDataStoreProvider pr_default ;
      private short[] P00282_A9TableroId ;
      private short[] P00282_A36EtiquetaId ;
   }

   public class getetiquetaid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00282;
          prmP00282 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00282", "SELECT TOP 1 [TableroId], [EtiquetaId] FROM [TablerosEtiquetas] WHERE [TableroId] = @TableroId ORDER BY [TableroId], [EtiquetaId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00282,1, GxCacheFrequency.OFF ,false,true )
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
