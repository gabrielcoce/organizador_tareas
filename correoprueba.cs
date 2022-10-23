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
   public class correoprueba : GXProcedure
   {
      public correoprueba( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public correoprueba( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_TableroId ,
                           ref string aP1_UsuarioEmail )
      {
         this.AV43TableroId = aP0_TableroId;
         this.AV42UsuarioEmail = aP1_UsuarioEmail;
         initialize();
         executePrivate();
         aP0_TableroId=this.AV43TableroId;
         aP1_UsuarioEmail=this.AV42UsuarioEmail;
      }

      public string executeUdp( ref short aP0_TableroId )
      {
         execute(ref aP0_TableroId, ref aP1_UsuarioEmail);
         return AV42UsuarioEmail ;
      }

      public void executeSubmit( ref short aP0_TableroId ,
                                 ref string aP1_UsuarioEmail )
      {
         correoprueba objcorreoprueba;
         objcorreoprueba = new correoprueba();
         objcorreoprueba.AV43TableroId = aP0_TableroId;
         objcorreoprueba.AV42UsuarioEmail = aP1_UsuarioEmail;
         objcorreoprueba.context.SetSubmitInitialConfig(context);
         objcorreoprueba.initialize();
         Submit( executePrivateCatch,objcorreoprueba);
         aP0_TableroId=this.AV43TableroId;
         aP1_UsuarioEmail=this.AV42UsuarioEmail;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((correoprueba)stateInfo).executePrivate();
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
         AV40Usuarios.Load((short)(NumberUtil.Val( AV41websession.Get("UsuarioId"), ".")));
         AV45Tableros.Load(AV43TableroId);
         AV37subject = "Te han invitado a participar en un tablero";
         AV23message = "<h2>Solicitud para colaborar</h2><p>Acepta la invitación para poder participar en el tablero.  Haz click en el siguiente #enlace</p></strong>";
         /* Using cursor P00272 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A52CorreoNombre = P00272_A52CorreoNombre[0];
            A55CorreoUsuario = P00272_A55CorreoUsuario[0];
            A56CorreoContrasena = P00272_A56CorreoContrasena[0];
            A54CorreoPuerto = P00272_A54CorreoPuerto[0];
            A53CorreoServidor = P00272_A53CorreoServidor[0];
            A57CorreoPlantilla = P00272_A57CorreoPlantilla[0];
            n57CorreoPlantilla = P00272_n57CorreoPlantilla[0];
            A50CorreoId = P00272_A50CorreoId[0];
            AV27NombreRemitente = A52CorreoNombre;
            AV15CorreoRemitente = A55CorreoUsuario;
            AV12Contrasena = A56CorreoContrasena;
            AV29Puerto = A54CorreoPuerto;
            AV34Servidor = A53CorreoServidor;
            AV44plantilla = A57CorreoPlantilla;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV26NombreDestinatario = AV40Usuarios.gxTpr_Usuarionombre + " " + AV40Usuarios.gxTpr_Usuarioapellido;
         AV39url = AV19Httprequest.BaseURL;
         AV17data = AV39url + "aceptarinvitacion.aspx?TableroId=" + StringUtil.Trim( StringUtil.Str( (decimal)(AV43TableroId), 4, 0)) + "&UsuarioEmail=" + StringUtil.Trim( AV42UsuarioEmail);
         AV44plantilla = StringUtil.StringReplace( AV44plantilla, "#NOMBRE", AV26NombreDestinatario);
         AV44plantilla = StringUtil.StringReplace( AV44plantilla, "#TABLERO", StringUtil.Trim( AV45Tableros.gxTpr_Tableronombre));
         AV44plantilla = StringUtil.StringReplace( AV44plantilla, "#LINK", StringUtil.Trim( AV17data));
         AV44plantilla = StringUtil.StringReplace( AV44plantilla, "#INVITADO", AV42UsuarioEmail);
         AV21MailRecipient.Name = StringUtil.Trim( AV26NombreDestinatario);
         AV21MailRecipient.Address = StringUtil.Trim( AV42UsuarioEmail);
         AV20MailMessage.To.Clear();
         AV20MailMessage.To.Add(AV21MailRecipient);
         AV20MailMessage.Subject = AV37subject;
         AV20MailMessage.HTMLText = AV44plantilla;
         AV36SMTPSession.Host = AV34Servidor;
         AV36SMTPSession.Port = AV29Puerto;
         AV36SMTPSession.Sender.Name = AV27NombreRemitente;
         AV36SMTPSession.Sender.Address = AV15CorreoRemitente;
         AV36SMTPSession.Timeout = 60;
         AV36SMTPSession.Authentication = 1;
         AV36SMTPSession.Secure = 1;
         AV36SMTPSession.UserName = AV15CorreoRemitente;
         AV36SMTPSession.Password = AV12Contrasena;
         AV31resultEmail = 0;
         AV36SMTPSession.Login();
         AV31resultEmail = (short)(AV31resultEmail+AV36SMTPSession.ErrCode);
         GX_msglist.addItem(StringUtil.Str( (decimal)(AV36SMTPSession.ErrCode), 10, 0)+" 1 "+AV36SMTPSession.ErrDescription);
         AV36SMTPSession.Send(AV20MailMessage);
         AV31resultEmail = (short)(AV31resultEmail+AV36SMTPSession.ErrCode);
         GX_msglist.addItem(StringUtil.Str( (decimal)(AV36SMTPSession.ErrCode), 10, 0)+" 2 "+AV36SMTPSession.ErrDescription);
         AV36SMTPSession.Logout();
         AV31resultEmail = (short)(AV31resultEmail+AV36SMTPSession.ErrCode);
         GX_msglist.addItem(StringUtil.Str( (decimal)(AV36SMTPSession.ErrCode), 10, 0)+" 3 "+AV36SMTPSession.ErrDescription);
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
         AV40Usuarios = new SdtUsuarios(context);
         AV41websession = context.GetSession();
         AV45Tableros = new SdtTableros(context);
         AV37subject = "";
         AV23message = "";
         scmdbuf = "";
         P00272_A52CorreoNombre = new string[] {""} ;
         P00272_A55CorreoUsuario = new string[] {""} ;
         P00272_A56CorreoContrasena = new string[] {""} ;
         P00272_A54CorreoPuerto = new short[1] ;
         P00272_A53CorreoServidor = new string[] {""} ;
         P00272_A57CorreoPlantilla = new string[] {""} ;
         P00272_n57CorreoPlantilla = new bool[] {false} ;
         P00272_A50CorreoId = new short[1] ;
         A52CorreoNombre = "";
         A55CorreoUsuario = "";
         A56CorreoContrasena = "";
         A53CorreoServidor = "";
         A57CorreoPlantilla = "";
         AV27NombreRemitente = "";
         AV15CorreoRemitente = "";
         AV12Contrasena = "";
         AV34Servidor = "";
         AV44plantilla = "";
         AV26NombreDestinatario = "";
         AV39url = "";
         AV19Httprequest = new GxHttpRequest( context);
         AV17data = "";
         AV21MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV20MailMessage = new GeneXus.Mail.GXMailMessage();
         AV36SMTPSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.correoprueba__default(),
            new Object[][] {
                new Object[] {
               P00272_A52CorreoNombre, P00272_A55CorreoUsuario, P00272_A56CorreoContrasena, P00272_A54CorreoPuerto, P00272_A53CorreoServidor, P00272_A57CorreoPlantilla, P00272_n57CorreoPlantilla, P00272_A50CorreoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV43TableroId ;
      private short A54CorreoPuerto ;
      private short A50CorreoId ;
      private short AV29Puerto ;
      private short AV31resultEmail ;
      private string AV37subject ;
      private string scmdbuf ;
      private string A52CorreoNombre ;
      private string A56CorreoContrasena ;
      private string A53CorreoServidor ;
      private string AV27NombreRemitente ;
      private string AV12Contrasena ;
      private string AV34Servidor ;
      private string AV26NombreDestinatario ;
      private string AV39url ;
      private bool n57CorreoPlantilla ;
      private string AV23message ;
      private string A57CorreoPlantilla ;
      private string AV44plantilla ;
      private string AV17data ;
      private string AV42UsuarioEmail ;
      private string A55CorreoUsuario ;
      private string AV15CorreoRemitente ;
      private IGxSession AV41websession ;
      private IGxDataStore dsDefault ;
      private short aP0_TableroId ;
      private string aP1_UsuarioEmail ;
      private IDataStoreProvider pr_default ;
      private string[] P00272_A52CorreoNombre ;
      private string[] P00272_A55CorreoUsuario ;
      private string[] P00272_A56CorreoContrasena ;
      private short[] P00272_A54CorreoPuerto ;
      private string[] P00272_A53CorreoServidor ;
      private string[] P00272_A57CorreoPlantilla ;
      private bool[] P00272_n57CorreoPlantilla ;
      private short[] P00272_A50CorreoId ;
      private GxHttpRequest AV19Httprequest ;
      private GeneXus.Mail.GXMailMessage AV20MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV21MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV36SMTPSession ;
      private SdtUsuarios AV40Usuarios ;
      private SdtTableros AV45Tableros ;
   }

   public class correoprueba__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00272;
          prmP00272 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00272", "SELECT TOP 1 [CorreoNombre], [CorreoUsuario], [CorreoContrasena], [CorreoPuerto], [CorreoServidor], [CorreoPlantilla], [CorreoId] FROM [Correo] ORDER BY [CorreoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00272,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 22);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
