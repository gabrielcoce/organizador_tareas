using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class links : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("Carmine");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "route");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8route = (short)(NumberUtil.Val( gxfirstwebparm, "."));
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public links( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public links( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref short aP0_route )
      {
         this.AV8route = aP0_route;
         initialize();
         executePrivate();
         aP0_route=this.AV8route;
      }

      public short executeUdp( )
      {
         execute(ref aP0_route);
         return AV8route ;
      }

      public void executeSubmit( ref short aP0_route )
      {
         links objlinks;
         objlinks = new links();
         objlinks.AV8route = aP0_route;
         objlinks.context.SetSubmitInitialConfig(context);
         objlinks.initialize();
         Submit( executePrivateCatch,objlinks);
         aP0_route=this.AV8route;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((links)stateInfo).executePrivate();
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
         if ( AV8route == 1101 )
         {
            CallWebObject(formatLink("paginainicio.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else if ( AV8route == 1102 )
         {
            CallWebObject(formatLink("perfilusuario.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else if ( AV8route == 1103 )
         {
            CallWebObject(formatLink("dashboard.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else if ( AV8route == 1104 )
         {
            CallWebObject(formatLink("dashboardinvitado.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else if ( AV8route == 1105 )
         {
            CallWebObject(formatLink("ingreso.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            CallWebObject(formatLink("ingreso.aspx") );
            context.wjLocDisableFrm = 1;
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV8route ;
      private short GxWebError ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private short aP0_route ;
   }

}
