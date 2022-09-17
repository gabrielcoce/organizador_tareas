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
   public class verificacioncuenta : GXProcedure
   {
      public verificacioncuenta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public verificacioncuenta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UsuarioEmail ,
                           string aP1_UsuarioPassword ,
                           out bool aP2_Result )
      {
         this.AV8UsuarioEmail = aP0_UsuarioEmail;
         this.AV9UsuarioPassword = aP1_UsuarioPassword;
         this.AV10Result = false ;
         initialize();
         executePrivate();
         aP2_Result=this.AV10Result;
      }

      public bool executeUdp( string aP0_UsuarioEmail ,
                              string aP1_UsuarioPassword )
      {
         execute(aP0_UsuarioEmail, aP1_UsuarioPassword, out aP2_Result);
         return AV10Result ;
      }

      public void executeSubmit( string aP0_UsuarioEmail ,
                                 string aP1_UsuarioPassword ,
                                 out bool aP2_Result )
      {
         verificacioncuenta objverificacioncuenta;
         objverificacioncuenta = new verificacioncuenta();
         objverificacioncuenta.AV8UsuarioEmail = aP0_UsuarioEmail;
         objverificacioncuenta.AV9UsuarioPassword = aP1_UsuarioPassword;
         objverificacioncuenta.AV10Result = false ;
         objverificacioncuenta.context.SetSubmitInitialConfig(context);
         objverificacioncuenta.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objverificacioncuenta);
         aP2_Result=this.AV10Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((verificacioncuenta)stateInfo).executePrivate();
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
         AV11ok1 = false;
         /* Using cursor P000D2 */
         pr_default.execute(0, new Object[] {AV8UsuarioEmail});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A6UsuarioEmail = P000D2_A6UsuarioEmail[0];
            A3UsuarioId = P000D2_A3UsuarioId[0];
            AV11ok1 = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV11ok1 )
         {
            AV12ok2 = false;
            /* Using cursor P000D3 */
            pr_default.execute(1, new Object[] {AV8UsuarioEmail});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A6UsuarioEmail = P000D3_A6UsuarioEmail[0];
               A7UsuarioPassword = P000D3_A7UsuarioPassword[0];
               n7UsuarioPassword = P000D3_n7UsuarioPassword[0];
               A3UsuarioId = P000D3_A3UsuarioId[0];
               if ( StringUtil.StrCmp(AV9UsuarioPassword, A7UsuarioPassword) == 0 )
               {
                  AV12ok2 = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( ( AV11ok1 ) && ( AV12ok2 ) )
         {
            AV10Result = true;
         }
         else
         {
            AV10Result = false;
         }
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
         P000D2_A6UsuarioEmail = new string[] {""} ;
         P000D2_A3UsuarioId = new short[1] ;
         A6UsuarioEmail = "";
         P000D3_A6UsuarioEmail = new string[] {""} ;
         P000D3_A7UsuarioPassword = new string[] {""} ;
         P000D3_n7UsuarioPassword = new bool[] {false} ;
         P000D3_A3UsuarioId = new short[1] ;
         A7UsuarioPassword = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.verificacioncuenta__default(),
            new Object[][] {
                new Object[] {
               P000D2_A6UsuarioEmail, P000D2_A3UsuarioId
               }
               , new Object[] {
               P000D3_A6UsuarioEmail, P000D3_A7UsuarioPassword, P000D3_n7UsuarioPassword, P000D3_A3UsuarioId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A3UsuarioId ;
      private string AV9UsuarioPassword ;
      private string scmdbuf ;
      private string A7UsuarioPassword ;
      private bool AV10Result ;
      private bool AV11ok1 ;
      private bool AV12ok2 ;
      private bool n7UsuarioPassword ;
      private string AV8UsuarioEmail ;
      private string A6UsuarioEmail ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P000D2_A6UsuarioEmail ;
      private short[] P000D2_A3UsuarioId ;
      private string[] P000D3_A6UsuarioEmail ;
      private string[] P000D3_A7UsuarioPassword ;
      private bool[] P000D3_n7UsuarioPassword ;
      private short[] P000D3_A3UsuarioId ;
      private bool aP2_Result ;
   }

   public class verificacioncuenta__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000D2;
          prmP000D2 = new Object[] {
          new ParDef("@AV8UsuarioEmail",GXType.NVarChar,100,0)
          };
          Object[] prmP000D3;
          prmP000D3 = new Object[] {
          new ParDef("@AV8UsuarioEmail",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000D2", "SELECT TOP 1 [UsuarioEmail], [UsuarioId] FROM [Usuarios] WHERE [UsuarioEmail] = @AV8UsuarioEmail ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000D2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P000D3", "SELECT TOP 1 [UsuarioEmail], [UsuarioPassword], [UsuarioId] FROM [Usuarios] WHERE [UsuarioEmail] = @AV8UsuarioEmail ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000D3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 200);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
