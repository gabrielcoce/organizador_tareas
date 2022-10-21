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
   public class getinvitadosid : GXProcedure
   {
      public getinvitadosid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getinvitadosid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref short aP1_id )
      {
         this.A9TableroId = aP0_TableroId;
         this.AV8id = aP1_id;
         initialize();
         executePrivate();
         aP0_TableroId=this.A9TableroId;
         aP1_id=this.AV8id;
      }

      public short executeUdp( ref short aP0_TableroId )
      {
         execute(ref aP0_TableroId, ref aP1_id);
         return AV8id ;
      }

      public void executeSubmit( ref short aP0_TableroId ,
                                 ref short aP1_id )
      {
         getinvitadosid objgetinvitadosid;
         objgetinvitadosid = new getinvitadosid();
         objgetinvitadosid.A9TableroId = aP0_TableroId;
         objgetinvitadosid.AV8id = aP1_id;
         objgetinvitadosid.context.SetSubmitInitialConfig(context);
         objgetinvitadosid.initialize();
         Submit( executePrivateCatch,objgetinvitadosid);
         aP0_TableroId=this.A9TableroId;
         aP1_id=this.AV8id;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getinvitadosid)stateInfo).executePrivate();
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
         AV8id = 0;
         /* Using cursor P000I2 */
         pr_default.execute(0, new Object[] {A9TableroId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A40RegistroInvitadoId = P000I2_A40RegistroInvitadoId[0];
            AV8id = A40RegistroInvitadoId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8id = (short)(AV8id+1);
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
         P000I2_A9TableroId = new short[1] ;
         P000I2_A40RegistroInvitadoId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getinvitadosid__default(),
            new Object[][] {
                new Object[] {
               P000I2_A9TableroId, P000I2_A40RegistroInvitadoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A9TableroId ;
      private short AV8id ;
      private short A40RegistroInvitadoId ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private short aP1_id ;
      private IDataStoreProvider pr_default ;
      private short[] P000I2_A9TableroId ;
      private short[] P000I2_A40RegistroInvitadoId ;
   }

   public class getinvitadosid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000I2;
          prmP000I2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000I2", "SELECT TOP 1 [TableroId], [RegistroInvitadoId] FROM [Invitados] WHERE [TableroId] = @TableroId ORDER BY [TableroId], [RegistroInvitadoId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000I2,1, GxCacheFrequency.OFF ,false,true )
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
