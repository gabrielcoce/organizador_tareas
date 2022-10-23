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
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class enviocorreo : GXProcedure
   {
      public enviocorreo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public enviocorreo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref string aP1_UsuarioEmail )
      {
         this.AV47TableroId = aP0_TableroId;
         this.AV46UsuarioEmail = aP1_UsuarioEmail;
         initialize();
         executePrivate();
         aP0_TableroId=this.AV47TableroId;
         aP1_UsuarioEmail=this.AV46UsuarioEmail;
      }

      public string executeUdp( ref short aP0_TableroId )
      {
         execute(ref aP0_TableroId, ref aP1_UsuarioEmail);
         return AV46UsuarioEmail ;
      }

      public void executeSubmit( ref short aP0_TableroId ,
                                 ref string aP1_UsuarioEmail )
      {
         enviocorreo objenviocorreo;
         objenviocorreo = new enviocorreo();
         objenviocorreo.AV47TableroId = aP0_TableroId;
         objenviocorreo.AV46UsuarioEmail = aP1_UsuarioEmail;
         objenviocorreo.context.SetSubmitInitialConfig(context);
         objenviocorreo.initialize();
         Submit( executePrivateCatch,objenviocorreo);
         aP0_TableroId=this.AV47TableroId;
         aP1_UsuarioEmail=this.AV46UsuarioEmail;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((enviocorreo)stateInfo).executePrivate();
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
         AV8Usuarios.Load((short)(NumberUtil.Val( AV10websession.Get("UsuarioId"), ".")));
         AV38subject = "Te han invitado a participar en un tablero";
         AV24message = "<h2>Solicitud para colaborar</h2><p>Acepta la invitación para poder participar en el tablero.  Haz click en el siguiente #enlace</p></strong>";
         /* Using cursor P00262 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A50CorreoId = P00262_A50CorreoId[0];
            A52CorreoNombre = P00262_A52CorreoNombre[0];
            A55CorreoUsuario = P00262_A55CorreoUsuario[0];
            A56CorreoContrasena = P00262_A56CorreoContrasena[0];
            A54CorreoPuerto = P00262_A54CorreoPuerto[0];
            A53CorreoServidor = P00262_A53CorreoServidor[0];
            AV28NombreRemitente = A52CorreoNombre;
            AV16CorreoRemitente = A55CorreoUsuario;
            AV43Contrasena = A56CorreoContrasena;
            AV30Puerto = A54CorreoPuerto;
            AV35Servidor = A53CorreoServidor;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV27NombreDestinatario = AV8Usuarios.gxTpr_Usuarionombre + " " + AV8Usuarios.gxTpr_Usuarioapellido;
         AV40url = AV20Httprequest.BaseURL;
         /* User Code */
          AV36sitekey = Crypto.GetSiteKey();
         AV39toenc = "verificar.aspx" + StringUtil.Trim( StringUtil.Str( (decimal)(AV47TableroId), 4, 0)) + AV46UsuarioEmail;
         /* User Code */
          AV14chksum = Crypto.CheckSum( AV39toenc, 6);
         AV18data = AV40url + "aceptarinvitacion.aspx?" + Encrypt64( AV39toenc+AV14chksum, AV36sitekey);
         AV22MailRecipient.Name = StringUtil.Trim( AV27NombreDestinatario);
         AV22MailRecipient.Address = StringUtil.Trim( AV46UsuarioEmail);
         AV21MailMessage.To.Clear();
         AV21MailMessage.To.Add(AV22MailRecipient);
         AV21MailMessage.Subject = AV38subject;
         AV24message = StringUtil.StringReplace( AV24message, "#enlace", StringUtil.Trim( AV18data));
         AV21MailMessage.HTMLText = AV24message;
         AV37SMTPSession.Host = AV35Servidor;
         AV37SMTPSession.Port = AV30Puerto;
         AV37SMTPSession.Sender.Name = AV28NombreRemitente;
         AV37SMTPSession.Sender.Address = AV16CorreoRemitente;
         AV37SMTPSession.Timeout = 60;
         AV37SMTPSession.Authentication = 1;
         AV37SMTPSession.Secure = 1;
         AV37SMTPSession.UserName = AV16CorreoRemitente;
         AV37SMTPSession.Password = AV43Contrasena;
         AV32resultEmail = 0;
         AV37SMTPSession.Login();
         AV32resultEmail = (short)(AV32resultEmail+AV37SMTPSession.ErrCode);
         AV37SMTPSession.Send(AV21MailMessage);
         AV32resultEmail = (short)(AV32resultEmail+AV37SMTPSession.ErrCode);
         AV37SMTPSession.Logout();
         AV32resultEmail = (short)(AV32resultEmail+AV37SMTPSession.ErrCode);
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
         AV8Usuarios = new SdtUsuarios(context);
         AV10websession = context.GetSession();
         AV38subject = "";
         AV24message = "";
         scmdbuf = "";
         P00262_A50CorreoId = new short[1] ;
         P00262_A52CorreoNombre = new string[] {""} ;
         P00262_A55CorreoUsuario = new string[] {""} ;
         P00262_A56CorreoContrasena = new string[] {""} ;
         P00262_A54CorreoPuerto = new short[1] ;
         P00262_A53CorreoServidor = new string[] {""} ;
         A52CorreoNombre = "";
         A55CorreoUsuario = "";
         A56CorreoContrasena = "";
         A53CorreoServidor = "";
         AV28NombreRemitente = "";
         AV16CorreoRemitente = "";
         AV43Contrasena = "";
         AV35Servidor = "";
         AV27NombreDestinatario = "";
         AV40url = "";
         AV20Httprequest = new GxHttpRequest( context);
         AV36sitekey = "";
         AV39toenc = "";
         AV14chksum = "";
         AV18data = "";
         AV22MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV21MailMessage = new GeneXus.Mail.GXMailMessage();
         AV37SMTPSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.enviocorreo__default(),
            new Object[][] {
                new Object[] {
               P00262_A50CorreoId, P00262_A52CorreoNombre, P00262_A55CorreoUsuario, P00262_A56CorreoContrasena, P00262_A54CorreoPuerto, P00262_A53CorreoServidor
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV47TableroId ;
      private short A50CorreoId ;
      private short A54CorreoPuerto ;
      private short AV30Puerto ;
      private short AV32resultEmail ;
      private string AV38subject ;
      private string scmdbuf ;
      private string A52CorreoNombre ;
      private string A56CorreoContrasena ;
      private string A53CorreoServidor ;
      private string AV28NombreRemitente ;
      private string AV43Contrasena ;
      private string AV35Servidor ;
      private string AV27NombreDestinatario ;
      private string AV40url ;
      private string AV36sitekey ;
      private string AV39toenc ;
      private string AV14chksum ;
      private string AV24message ;
      private string AV18data ;
      private string AV46UsuarioEmail ;
      private string A55CorreoUsuario ;
      private string AV16CorreoRemitente ;
      private IGxSession AV10websession ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private string aP1_UsuarioEmail ;
      private IDataStoreProvider pr_default ;
      private short[] P00262_A50CorreoId ;
      private string[] P00262_A52CorreoNombre ;
      private string[] P00262_A55CorreoUsuario ;
      private string[] P00262_A56CorreoContrasena ;
      private short[] P00262_A54CorreoPuerto ;
      private string[] P00262_A53CorreoServidor ;
      private GxHttpRequest AV20Httprequest ;
      private GeneXus.Mail.GXMailMessage AV21MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV22MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV37SMTPSession ;
      private SdtUsuarios AV8Usuarios ;
   }

   public class enviocorreo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00262;
          prmP00262 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00262", "SELECT TOP 1 [CorreoId], [CorreoNombre], [CorreoUsuario], [CorreoContrasena], [CorreoPuerto], [CorreoServidor] FROM [Correo] WHERE [CorreoId] = 3 ORDER BY [CorreoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00262,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 22);
                return;
       }
    }

 }

}
