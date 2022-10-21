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
   public class getactividadid : GXProcedure
   {
      public getactividadid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getactividadid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref short aP1_TareaId ,
                           out short aP2_ActividadId )
      {
         this.A9TableroId = aP0_TableroId;
         this.A12TareaId = aP1_TareaId;
         this.AV11ActividadId = 0 ;
         initialize();
         executePrivate();
         aP0_TableroId=this.A9TableroId;
         aP1_TareaId=this.A12TareaId;
         aP2_ActividadId=this.AV11ActividadId;
      }

      public short executeUdp( ref short aP0_TableroId ,
                               ref short aP1_TareaId )
      {
         execute(ref aP0_TableroId, ref aP1_TareaId, out aP2_ActividadId);
         return AV11ActividadId ;
      }

      public void executeSubmit( ref short aP0_TableroId ,
                                 ref short aP1_TareaId ,
                                 out short aP2_ActividadId )
      {
         getactividadid objgetactividadid;
         objgetactividadid = new getactividadid();
         objgetactividadid.A9TableroId = aP0_TableroId;
         objgetactividadid.A12TareaId = aP1_TareaId;
         objgetactividadid.AV11ActividadId = 0 ;
         objgetactividadid.context.SetSubmitInitialConfig(context);
         objgetactividadid.initialize();
         Submit( executePrivateCatch,objgetactividadid);
         aP0_TableroId=this.A9TableroId;
         aP1_TareaId=this.A12TareaId;
         aP2_ActividadId=this.AV11ActividadId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getactividadid)stateInfo).executePrivate();
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
         /* Using cursor P000O2 */
         pr_default.execute(0, new Object[] {A9TableroId, A12TareaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A30ActividadId = P000O2_A30ActividadId[0];
            AV11ActividadId = A30ActividadId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV11ActividadId = (short)(AV11ActividadId+1);
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
         P000O2_A9TableroId = new short[1] ;
         P000O2_A12TareaId = new short[1] ;
         P000O2_A30ActividadId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getactividadid__default(),
            new Object[][] {
                new Object[] {
               P000O2_A9TableroId, P000O2_A12TareaId, P000O2_A30ActividadId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A9TableroId ;
      private short A12TareaId ;
      private short AV11ActividadId ;
      private short A30ActividadId ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private short aP1_TareaId ;
      private IDataStoreProvider pr_default ;
      private short[] P000O2_A9TableroId ;
      private short[] P000O2_A12TareaId ;
      private short[] P000O2_A30ActividadId ;
      private short aP2_ActividadId ;
   }

   public class getactividadid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000O2;
          prmP000O2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000O2", "SELECT TOP 1 [TableroId], [TareaId], [ActividadId] FROM [Actividades] WHERE [TableroId] = @TableroId and [TareaId] = @TareaId ORDER BY [TableroId], [TareaId], [ActividadId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000O2,1, GxCacheFrequency.OFF ,false,true )
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
