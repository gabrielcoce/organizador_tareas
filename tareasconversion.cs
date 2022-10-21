using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class tareasconversion : GXProcedure
   {
      public tareasconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public tareasconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         tareasconversion objtareasconversion;
         objtareasconversion = new tareasconversion();
         objtareasconversion.context.SetSubmitInitialConfig(context);
         objtareasconversion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtareasconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tareasconversion)stateInfo).executePrivate();
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
         /* Using cursor TAREASCONV2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A46TareaEstado = TAREASCONV2_A46TareaEstado[0];
            A38TareaEtiquetas = TAREASCONV2_A38TareaEtiquetas[0];
            A25TareaFechaFin = TAREASCONV2_A25TareaFechaFin[0];
            A24TareaFechaInicio = TAREASCONV2_A24TareaFechaInicio[0];
            A23ResponsableId = TAREASCONV2_A23ResponsableId[0];
            n23ResponsableId = TAREASCONV2_n23ResponsableId[0];
            A13TareaNombre = TAREASCONV2_A13TareaNombre[0];
            A12TareaId = TAREASCONV2_A12TareaId[0];
            A9TableroId = TAREASCONV2_A9TableroId[0];
            /*
               INSERT RECORD ON TABLE GXA0004

            */
            AV2TableroId = A9TableroId;
            AV3TareaId = A12TareaId;
            AV4TareaNombre = A13TareaNombre;
            if ( TAREASCONV2_n23ResponsableId[0] )
            {
               AV5ResponsableId = 0;
            }
            else
            {
               AV5ResponsableId = A23ResponsableId;
            }
            AV6TareaFechaInicio = A24TareaFechaInicio;
            AV7TareaFechaFin = A25TareaFechaFin;
            AV8TareaEtiquetas = A38TareaEtiquetas;
            AV9TareaEstado = A46TareaEstado;
            /* Using cursor TAREASCONV3 */
            pr_default.execute(1, new Object[] {AV2TableroId, AV3TareaId, AV4TareaNombre, AV5ResponsableId, AV6TareaFechaInicio, AV7TareaFechaFin, AV8TareaEtiquetas, AV9TareaEstado});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("GXA0004");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         TAREASCONV2_A46TareaEstado = new short[1] ;
         TAREASCONV2_A38TareaEtiquetas = new string[] {""} ;
         TAREASCONV2_A25TareaFechaFin = new DateTime[] {DateTime.MinValue} ;
         TAREASCONV2_A24TareaFechaInicio = new DateTime[] {DateTime.MinValue} ;
         TAREASCONV2_A23ResponsableId = new short[1] ;
         TAREASCONV2_n23ResponsableId = new bool[] {false} ;
         TAREASCONV2_A13TareaNombre = new string[] {""} ;
         TAREASCONV2_A12TareaId = new short[1] ;
         TAREASCONV2_A9TableroId = new short[1] ;
         A38TareaEtiquetas = "";
         A25TareaFechaFin = DateTime.MinValue;
         A24TareaFechaInicio = DateTime.MinValue;
         A13TareaNombre = "";
         AV4TareaNombre = "";
         AV6TareaFechaInicio = DateTime.MinValue;
         AV7TareaFechaFin = DateTime.MinValue;
         AV8TareaEtiquetas = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tareasconversion__default(),
            new Object[][] {
                new Object[] {
               TAREASCONV2_A46TareaEstado, TAREASCONV2_A38TareaEtiquetas, TAREASCONV2_A25TareaFechaFin, TAREASCONV2_A24TareaFechaInicio, TAREASCONV2_A23ResponsableId, TAREASCONV2_n23ResponsableId, TAREASCONV2_A13TareaNombre, TAREASCONV2_A12TareaId, TAREASCONV2_A9TableroId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A46TareaEstado ;
      private short A23ResponsableId ;
      private short A12TareaId ;
      private short A9TableroId ;
      private short AV2TableroId ;
      private short AV3TareaId ;
      private short AV5ResponsableId ;
      private short AV9TareaEstado ;
      private int GIGXA0004 ;
      private string scmdbuf ;
      private string A13TareaNombre ;
      private string AV4TareaNombre ;
      private string Gx_emsg ;
      private DateTime A25TareaFechaFin ;
      private DateTime A24TareaFechaInicio ;
      private DateTime AV6TareaFechaInicio ;
      private DateTime AV7TareaFechaFin ;
      private bool n23ResponsableId ;
      private string A38TareaEtiquetas ;
      private string AV8TareaEtiquetas ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] TAREASCONV2_A46TareaEstado ;
      private string[] TAREASCONV2_A38TareaEtiquetas ;
      private DateTime[] TAREASCONV2_A25TareaFechaFin ;
      private DateTime[] TAREASCONV2_A24TareaFechaInicio ;
      private short[] TAREASCONV2_A23ResponsableId ;
      private bool[] TAREASCONV2_n23ResponsableId ;
      private string[] TAREASCONV2_A13TareaNombre ;
      private short[] TAREASCONV2_A12TareaId ;
      private short[] TAREASCONV2_A9TableroId ;
   }

   public class tareasconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTAREASCONV2;
          prmTAREASCONV2 = new Object[] {
          };
          Object[] prmTAREASCONV3;
          prmTAREASCONV3 = new Object[] {
          new ParDef("@AV2TableroId",GXType.Int16,4,0) ,
          new ParDef("@AV3TareaId",GXType.Int16,4,0) ,
          new ParDef("@AV4TareaNombre",GXType.Char,20,0) ,
          new ParDef("@AV5ResponsableId",GXType.Int16,4,0) ,
          new ParDef("@AV6TareaFechaInicio",GXType.Date,8,0) ,
          new ParDef("@AV7TareaFechaFin",GXType.Date,8,0) ,
          new ParDef("@AV8TareaEtiquetas",GXType.VarChar,2097152,0) ,
          new ParDef("@AV9TareaEstado",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("TAREASCONV2", "SELECT [TareaEstado], [TareaEtiquetas], [TareaFechaFin], [TareaFechaInicio], [ResponsableId], [TareaNombre], [TareaId], [TableroId] FROM [Tareas] ORDER BY [TableroId], [TareaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTAREASCONV2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TAREASCONV3", "INSERT INTO [GXA0004]([TableroId], [TareaId], [TareaNombre], [ResponsableId], [TareaFechaInicio], [TareaFechaFin], [TareaEtiquetas], [TareaEstado]) VALUES(@AV2TableroId, @AV3TareaId, @AV4TareaNombre, @AV5ResponsableId, @AV6TareaFechaInicio, @AV7TareaFechaFin, @AV8TareaEtiquetas, @AV9TareaEstado)", GxErrorMask.GX_NOMASK,prmTAREASCONV3)
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
