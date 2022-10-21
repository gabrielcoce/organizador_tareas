using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "Usuarios" )]
   [XmlType(TypeName =  "Usuarios" , Namespace = "ProyectoUMG" )]
   [Serializable]
   public class SdtUsuarios : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtUsuarios( )
      {
      }

      public SdtUsuarios( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV3UsuarioId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV3UsuarioId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"UsuarioId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Usuarios");
         metadata.Set("BT", "Usuarios");
         metadata.Set("PK", "[ \"UsuarioId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"RolId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Usuarioid_Z");
         state.Add("gxTpr_Usuarionombre_Z");
         state.Add("gxTpr_Usuarioapellido_Z");
         state.Add("gxTpr_Usuarioemail_Z");
         state.Add("gxTpr_Usuariopassword_Z");
         state.Add("gxTpr_Usuarioestado_Z");
         state.Add("gxTpr_Rolid_Z");
         state.Add("gxTpr_Usuarionombre_N");
         state.Add("gxTpr_Usuarioapellido_N");
         state.Add("gxTpr_Usuariopassword_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtUsuarios sdt;
         sdt = (SdtUsuarios)(source);
         gxTv_SdtUsuarios_Usuarioid = sdt.gxTv_SdtUsuarios_Usuarioid ;
         gxTv_SdtUsuarios_Usuarionombre = sdt.gxTv_SdtUsuarios_Usuarionombre ;
         gxTv_SdtUsuarios_Usuarioapellido = sdt.gxTv_SdtUsuarios_Usuarioapellido ;
         gxTv_SdtUsuarios_Usuarioemail = sdt.gxTv_SdtUsuarios_Usuarioemail ;
         gxTv_SdtUsuarios_Usuariopassword = sdt.gxTv_SdtUsuarios_Usuariopassword ;
         gxTv_SdtUsuarios_Usuarioestado = sdt.gxTv_SdtUsuarios_Usuarioestado ;
         gxTv_SdtUsuarios_Rolid = sdt.gxTv_SdtUsuarios_Rolid ;
         gxTv_SdtUsuarios_Mode = sdt.gxTv_SdtUsuarios_Mode ;
         gxTv_SdtUsuarios_Initialized = sdt.gxTv_SdtUsuarios_Initialized ;
         gxTv_SdtUsuarios_Usuarioid_Z = sdt.gxTv_SdtUsuarios_Usuarioid_Z ;
         gxTv_SdtUsuarios_Usuarionombre_Z = sdt.gxTv_SdtUsuarios_Usuarionombre_Z ;
         gxTv_SdtUsuarios_Usuarioapellido_Z = sdt.gxTv_SdtUsuarios_Usuarioapellido_Z ;
         gxTv_SdtUsuarios_Usuarioemail_Z = sdt.gxTv_SdtUsuarios_Usuarioemail_Z ;
         gxTv_SdtUsuarios_Usuariopassword_Z = sdt.gxTv_SdtUsuarios_Usuariopassword_Z ;
         gxTv_SdtUsuarios_Usuarioestado_Z = sdt.gxTv_SdtUsuarios_Usuarioestado_Z ;
         gxTv_SdtUsuarios_Rolid_Z = sdt.gxTv_SdtUsuarios_Rolid_Z ;
         gxTv_SdtUsuarios_Usuarionombre_N = sdt.gxTv_SdtUsuarios_Usuarionombre_N ;
         gxTv_SdtUsuarios_Usuarioapellido_N = sdt.gxTv_SdtUsuarios_Usuarioapellido_N ;
         gxTv_SdtUsuarios_Usuariopassword_N = sdt.gxTv_SdtUsuarios_Usuariopassword_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("UsuarioId", gxTv_SdtUsuarios_Usuarioid, false, includeNonInitialized);
         AddObjectProperty("UsuarioNombre", gxTv_SdtUsuarios_Usuarionombre, false, includeNonInitialized);
         AddObjectProperty("UsuarioNombre_N", gxTv_SdtUsuarios_Usuarionombre_N, false, includeNonInitialized);
         AddObjectProperty("UsuarioApellido", gxTv_SdtUsuarios_Usuarioapellido, false, includeNonInitialized);
         AddObjectProperty("UsuarioApellido_N", gxTv_SdtUsuarios_Usuarioapellido_N, false, includeNonInitialized);
         AddObjectProperty("UsuarioEmail", gxTv_SdtUsuarios_Usuarioemail, false, includeNonInitialized);
         AddObjectProperty("UsuarioPassword", gxTv_SdtUsuarios_Usuariopassword, false, includeNonInitialized);
         AddObjectProperty("UsuarioPassword_N", gxTv_SdtUsuarios_Usuariopassword_N, false, includeNonInitialized);
         AddObjectProperty("UsuarioEstado", gxTv_SdtUsuarios_Usuarioestado, false, includeNonInitialized);
         AddObjectProperty("RolId", gxTv_SdtUsuarios_Rolid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtUsuarios_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtUsuarios_Initialized, false, includeNonInitialized);
            AddObjectProperty("UsuarioId_Z", gxTv_SdtUsuarios_Usuarioid_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioNombre_Z", gxTv_SdtUsuarios_Usuarionombre_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioApellido_Z", gxTv_SdtUsuarios_Usuarioapellido_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioEmail_Z", gxTv_SdtUsuarios_Usuarioemail_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioPassword_Z", gxTv_SdtUsuarios_Usuariopassword_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioEstado_Z", gxTv_SdtUsuarios_Usuarioestado_Z, false, includeNonInitialized);
            AddObjectProperty("RolId_Z", gxTv_SdtUsuarios_Rolid_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioNombre_N", gxTv_SdtUsuarios_Usuarionombre_N, false, includeNonInitialized);
            AddObjectProperty("UsuarioApellido_N", gxTv_SdtUsuarios_Usuarioapellido_N, false, includeNonInitialized);
            AddObjectProperty("UsuarioPassword_N", gxTv_SdtUsuarios_Usuariopassword_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtUsuarios sdt )
      {
         if ( sdt.IsDirty("UsuarioId") )
         {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarioid = sdt.gxTv_SdtUsuarios_Usuarioid ;
         }
         if ( sdt.IsDirty("UsuarioNombre") )
         {
            gxTv_SdtUsuarios_Usuarionombre_N = (short)(sdt.gxTv_SdtUsuarios_Usuarionombre_N);
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarionombre = sdt.gxTv_SdtUsuarios_Usuarionombre ;
         }
         if ( sdt.IsDirty("UsuarioApellido") )
         {
            gxTv_SdtUsuarios_Usuarioapellido_N = (short)(sdt.gxTv_SdtUsuarios_Usuarioapellido_N);
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarioapellido = sdt.gxTv_SdtUsuarios_Usuarioapellido ;
         }
         if ( sdt.IsDirty("UsuarioEmail") )
         {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarioemail = sdt.gxTv_SdtUsuarios_Usuarioemail ;
         }
         if ( sdt.IsDirty("UsuarioPassword") )
         {
            gxTv_SdtUsuarios_Usuariopassword_N = (short)(sdt.gxTv_SdtUsuarios_Usuariopassword_N);
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuariopassword = sdt.gxTv_SdtUsuarios_Usuariopassword ;
         }
         if ( sdt.IsDirty("UsuarioEstado") )
         {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarioestado = sdt.gxTv_SdtUsuarios_Usuarioestado ;
         }
         if ( sdt.IsDirty("RolId") )
         {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Rolid = sdt.gxTv_SdtUsuarios_Rolid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "UsuarioId" )]
      [  XmlElement( ElementName = "UsuarioId"   )]
      public short gxTpr_Usuarioid
      {
         get {
            return gxTv_SdtUsuarios_Usuarioid ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            if ( gxTv_SdtUsuarios_Usuarioid != value )
            {
               gxTv_SdtUsuarios_Mode = "INS";
               this.gxTv_SdtUsuarios_Usuarioid_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuarionombre_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuarioapellido_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuarioemail_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariopassword_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuarioestado_Z_SetNull( );
               this.gxTv_SdtUsuarios_Rolid_Z_SetNull( );
            }
            gxTv_SdtUsuarios_Usuarioid = value;
            SetDirty("Usuarioid");
         }

      }

      [  SoapElement( ElementName = "UsuarioNombre" )]
      [  XmlElement( ElementName = "UsuarioNombre"   )]
      public string gxTpr_Usuarionombre
      {
         get {
            return gxTv_SdtUsuarios_Usuarionombre ;
         }

         set {
            gxTv_SdtUsuarios_Usuarionombre_N = 0;
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarionombre = value;
            SetDirty("Usuarionombre");
         }

      }

      public void gxTv_SdtUsuarios_Usuarionombre_SetNull( )
      {
         gxTv_SdtUsuarios_Usuarionombre_N = 1;
         gxTv_SdtUsuarios_Usuarionombre = "";
         SetDirty("Usuarionombre");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuarionombre_IsNull( )
      {
         return (gxTv_SdtUsuarios_Usuarionombre_N==1) ;
      }

      [  SoapElement( ElementName = "UsuarioApellido" )]
      [  XmlElement( ElementName = "UsuarioApellido"   )]
      public string gxTpr_Usuarioapellido
      {
         get {
            return gxTv_SdtUsuarios_Usuarioapellido ;
         }

         set {
            gxTv_SdtUsuarios_Usuarioapellido_N = 0;
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarioapellido = value;
            SetDirty("Usuarioapellido");
         }

      }

      public void gxTv_SdtUsuarios_Usuarioapellido_SetNull( )
      {
         gxTv_SdtUsuarios_Usuarioapellido_N = 1;
         gxTv_SdtUsuarios_Usuarioapellido = "";
         SetDirty("Usuarioapellido");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuarioapellido_IsNull( )
      {
         return (gxTv_SdtUsuarios_Usuarioapellido_N==1) ;
      }

      [  SoapElement( ElementName = "UsuarioEmail" )]
      [  XmlElement( ElementName = "UsuarioEmail"   )]
      public string gxTpr_Usuarioemail
      {
         get {
            return gxTv_SdtUsuarios_Usuarioemail ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarioemail = value;
            SetDirty("Usuarioemail");
         }

      }

      [  SoapElement( ElementName = "UsuarioPassword" )]
      [  XmlElement( ElementName = "UsuarioPassword"   )]
      public string gxTpr_Usuariopassword
      {
         get {
            return gxTv_SdtUsuarios_Usuariopassword ;
         }

         set {
            gxTv_SdtUsuarios_Usuariopassword_N = 0;
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuariopassword = value;
            SetDirty("Usuariopassword");
         }

      }

      public void gxTv_SdtUsuarios_Usuariopassword_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariopassword_N = 1;
         gxTv_SdtUsuarios_Usuariopassword = "";
         SetDirty("Usuariopassword");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariopassword_IsNull( )
      {
         return (gxTv_SdtUsuarios_Usuariopassword_N==1) ;
      }

      [  SoapElement( ElementName = "UsuarioEstado" )]
      [  XmlElement( ElementName = "UsuarioEstado"   )]
      public bool gxTpr_Usuarioestado
      {
         get {
            return gxTv_SdtUsuarios_Usuarioestado ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarioestado = value;
            SetDirty("Usuarioestado");
         }

      }

      [  SoapElement( ElementName = "RolId" )]
      [  XmlElement( ElementName = "RolId"   )]
      public short gxTpr_Rolid
      {
         get {
            return gxTv_SdtUsuarios_Rolid ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Rolid = value;
            SetDirty("Rolid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtUsuarios_Mode ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtUsuarios_Mode_SetNull( )
      {
         gxTv_SdtUsuarios_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtUsuarios_Initialized ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtUsuarios_Initialized_SetNull( )
      {
         gxTv_SdtUsuarios_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioId_Z" )]
      [  XmlElement( ElementName = "UsuarioId_Z"   )]
      public short gxTpr_Usuarioid_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuarioid_Z ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarioid_Z = value;
            SetDirty("Usuarioid_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuarioid_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuarioid_Z = 0;
         SetDirty("Usuarioid_Z");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuarioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioNombre_Z" )]
      [  XmlElement( ElementName = "UsuarioNombre_Z"   )]
      public string gxTpr_Usuarionombre_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuarionombre_Z ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarionombre_Z = value;
            SetDirty("Usuarionombre_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuarionombre_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuarionombre_Z = "";
         SetDirty("Usuarionombre_Z");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuarionombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioApellido_Z" )]
      [  XmlElement( ElementName = "UsuarioApellido_Z"   )]
      public string gxTpr_Usuarioapellido_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuarioapellido_Z ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarioapellido_Z = value;
            SetDirty("Usuarioapellido_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuarioapellido_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuarioapellido_Z = "";
         SetDirty("Usuarioapellido_Z");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuarioapellido_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioEmail_Z" )]
      [  XmlElement( ElementName = "UsuarioEmail_Z"   )]
      public string gxTpr_Usuarioemail_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuarioemail_Z ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarioemail_Z = value;
            SetDirty("Usuarioemail_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuarioemail_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuarioemail_Z = "";
         SetDirty("Usuarioemail_Z");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuarioemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioPassword_Z" )]
      [  XmlElement( ElementName = "UsuarioPassword_Z"   )]
      public string gxTpr_Usuariopassword_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariopassword_Z ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuariopassword_Z = value;
            SetDirty("Usuariopassword_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariopassword_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariopassword_Z = "";
         SetDirty("Usuariopassword_Z");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariopassword_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioEstado_Z" )]
      [  XmlElement( ElementName = "UsuarioEstado_Z"   )]
      public bool gxTpr_Usuarioestado_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuarioestado_Z ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarioestado_Z = value;
            SetDirty("Usuarioestado_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuarioestado_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuarioestado_Z = false;
         SetDirty("Usuarioestado_Z");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuarioestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RolId_Z" )]
      [  XmlElement( ElementName = "RolId_Z"   )]
      public short gxTpr_Rolid_Z
      {
         get {
            return gxTv_SdtUsuarios_Rolid_Z ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Rolid_Z = value;
            SetDirty("Rolid_Z");
         }

      }

      public void gxTv_SdtUsuarios_Rolid_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Rolid_Z = 0;
         SetDirty("Rolid_Z");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Rolid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioNombre_N" )]
      [  XmlElement( ElementName = "UsuarioNombre_N"   )]
      public short gxTpr_Usuarionombre_N
      {
         get {
            return gxTv_SdtUsuarios_Usuarionombre_N ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarionombre_N = value;
            SetDirty("Usuarionombre_N");
         }

      }

      public void gxTv_SdtUsuarios_Usuarionombre_N_SetNull( )
      {
         gxTv_SdtUsuarios_Usuarionombre_N = 0;
         SetDirty("Usuarionombre_N");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuarionombre_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioApellido_N" )]
      [  XmlElement( ElementName = "UsuarioApellido_N"   )]
      public short gxTpr_Usuarioapellido_N
      {
         get {
            return gxTv_SdtUsuarios_Usuarioapellido_N ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuarioapellido_N = value;
            SetDirty("Usuarioapellido_N");
         }

      }

      public void gxTv_SdtUsuarios_Usuarioapellido_N_SetNull( )
      {
         gxTv_SdtUsuarios_Usuarioapellido_N = 0;
         SetDirty("Usuarioapellido_N");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuarioapellido_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioPassword_N" )]
      [  XmlElement( ElementName = "UsuarioPassword_N"   )]
      public short gxTpr_Usuariopassword_N
      {
         get {
            return gxTv_SdtUsuarios_Usuariopassword_N ;
         }

         set {
            gxTv_SdtUsuarios_N = 0;
            gxTv_SdtUsuarios_Usuariopassword_N = value;
            SetDirty("Usuariopassword_N");
         }

      }

      public void gxTv_SdtUsuarios_Usuariopassword_N_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariopassword_N = 0;
         SetDirty("Usuariopassword_N");
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariopassword_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtUsuarios_N = 1;
         gxTv_SdtUsuarios_Usuarionombre = "";
         gxTv_SdtUsuarios_Usuarioapellido = "";
         gxTv_SdtUsuarios_Usuarioemail = "";
         gxTv_SdtUsuarios_Usuariopassword = "";
         gxTv_SdtUsuarios_Mode = "";
         gxTv_SdtUsuarios_Usuarionombre_Z = "";
         gxTv_SdtUsuarios_Usuarioapellido_Z = "";
         gxTv_SdtUsuarios_Usuarioemail_Z = "";
         gxTv_SdtUsuarios_Usuariopassword_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "usuarios", "GeneXus.Programs.usuarios_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtUsuarios_N ;
      }

      private short gxTv_SdtUsuarios_Usuarioid ;
      private short gxTv_SdtUsuarios_N ;
      private short gxTv_SdtUsuarios_Rolid ;
      private short gxTv_SdtUsuarios_Initialized ;
      private short gxTv_SdtUsuarios_Usuarioid_Z ;
      private short gxTv_SdtUsuarios_Rolid_Z ;
      private short gxTv_SdtUsuarios_Usuarionombre_N ;
      private short gxTv_SdtUsuarios_Usuarioapellido_N ;
      private short gxTv_SdtUsuarios_Usuariopassword_N ;
      private string gxTv_SdtUsuarios_Usuarionombre ;
      private string gxTv_SdtUsuarios_Usuarioapellido ;
      private string gxTv_SdtUsuarios_Usuariopassword ;
      private string gxTv_SdtUsuarios_Mode ;
      private string gxTv_SdtUsuarios_Usuarionombre_Z ;
      private string gxTv_SdtUsuarios_Usuarioapellido_Z ;
      private string gxTv_SdtUsuarios_Usuariopassword_Z ;
      private bool gxTv_SdtUsuarios_Usuarioestado ;
      private bool gxTv_SdtUsuarios_Usuarioestado_Z ;
      private string gxTv_SdtUsuarios_Usuarioemail ;
      private string gxTv_SdtUsuarios_Usuarioemail_Z ;
   }

   [DataContract(Name = @"Usuarios", Namespace = "ProyectoUMG")]
   public class SdtUsuarios_RESTInterface : GxGenericCollectionItem<SdtUsuarios>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtUsuarios_RESTInterface( ) : base()
      {
      }

      public SdtUsuarios_RESTInterface( SdtUsuarios psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UsuarioId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Usuarioid
      {
         get {
            return sdt.gxTpr_Usuarioid ;
         }

         set {
            sdt.gxTpr_Usuarioid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UsuarioNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Usuarionombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuarionombre) ;
         }

         set {
            sdt.gxTpr_Usuarionombre = value;
         }

      }

      [DataMember( Name = "UsuarioApellido" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Usuarioapellido
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuarioapellido) ;
         }

         set {
            sdt.gxTpr_Usuarioapellido = value;
         }

      }

      [DataMember( Name = "UsuarioEmail" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Usuarioemail
      {
         get {
            return sdt.gxTpr_Usuarioemail ;
         }

         set {
            sdt.gxTpr_Usuarioemail = value;
         }

      }

      [DataMember( Name = "UsuarioPassword" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Usuariopassword
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariopassword) ;
         }

         set {
            sdt.gxTpr_Usuariopassword = value;
         }

      }

      [DataMember( Name = "UsuarioEstado" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Usuarioestado
      {
         get {
            return sdt.gxTpr_Usuarioestado ;
         }

         set {
            sdt.gxTpr_Usuarioestado = value;
         }

      }

      [DataMember( Name = "RolId" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Rolid
      {
         get {
            return sdt.gxTpr_Rolid ;
         }

         set {
            sdt.gxTpr_Rolid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtUsuarios sdt
      {
         get {
            return (SdtUsuarios)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtUsuarios() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 7 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Usuarios", Namespace = "ProyectoUMG")]
   public class SdtUsuarios_RESTLInterface : GxGenericCollectionItem<SdtUsuarios>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtUsuarios_RESTLInterface( ) : base()
      {
      }

      public SdtUsuarios_RESTLInterface( SdtUsuarios psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UsuarioNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Usuarionombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuarionombre) ;
         }

         set {
            sdt.gxTpr_Usuarionombre = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtUsuarios sdt
      {
         get {
            return (SdtUsuarios)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtUsuarios() ;
         }
      }

   }

}
