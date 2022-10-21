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
   [XmlRoot(ElementName = "Correo" )]
   [XmlType(TypeName =  "Correo" , Namespace = "ProyectoUMG" )]
   [Serializable]
   public class SdtCorreo : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCorreo( )
      {
      }

      public SdtCorreo( IGxContext context )
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

      public void Load( short AV50CorreoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV50CorreoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CorreoId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Correo");
         metadata.Set("BT", "Correo");
         metadata.Set("PK", "[ \"CorreoId\" ]");
         metadata.Set("PKAssigned", "[ \"CorreoId\" ]");
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
         state.Add("gxTpr_Correoid_Z");
         state.Add("gxTpr_Correoidentificador_Z");
         state.Add("gxTpr_Correonombre_Z");
         state.Add("gxTpr_Correoservidor_Z");
         state.Add("gxTpr_Correopuerto_Z");
         state.Add("gxTpr_Correousuario_Z");
         state.Add("gxTpr_Correocontrasena_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCorreo sdt;
         sdt = (SdtCorreo)(source);
         gxTv_SdtCorreo_Correoid = sdt.gxTv_SdtCorreo_Correoid ;
         gxTv_SdtCorreo_Correoidentificador = sdt.gxTv_SdtCorreo_Correoidentificador ;
         gxTv_SdtCorreo_Correonombre = sdt.gxTv_SdtCorreo_Correonombre ;
         gxTv_SdtCorreo_Correoservidor = sdt.gxTv_SdtCorreo_Correoservidor ;
         gxTv_SdtCorreo_Correopuerto = sdt.gxTv_SdtCorreo_Correopuerto ;
         gxTv_SdtCorreo_Correousuario = sdt.gxTv_SdtCorreo_Correousuario ;
         gxTv_SdtCorreo_Correocontrasena = sdt.gxTv_SdtCorreo_Correocontrasena ;
         gxTv_SdtCorreo_Mode = sdt.gxTv_SdtCorreo_Mode ;
         gxTv_SdtCorreo_Initialized = sdt.gxTv_SdtCorreo_Initialized ;
         gxTv_SdtCorreo_Correoid_Z = sdt.gxTv_SdtCorreo_Correoid_Z ;
         gxTv_SdtCorreo_Correoidentificador_Z = sdt.gxTv_SdtCorreo_Correoidentificador_Z ;
         gxTv_SdtCorreo_Correonombre_Z = sdt.gxTv_SdtCorreo_Correonombre_Z ;
         gxTv_SdtCorreo_Correoservidor_Z = sdt.gxTv_SdtCorreo_Correoservidor_Z ;
         gxTv_SdtCorreo_Correopuerto_Z = sdt.gxTv_SdtCorreo_Correopuerto_Z ;
         gxTv_SdtCorreo_Correousuario_Z = sdt.gxTv_SdtCorreo_Correousuario_Z ;
         gxTv_SdtCorreo_Correocontrasena_Z = sdt.gxTv_SdtCorreo_Correocontrasena_Z ;
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
         AddObjectProperty("CorreoId", gxTv_SdtCorreo_Correoid, false, includeNonInitialized);
         AddObjectProperty("CorreoIdentificador", gxTv_SdtCorreo_Correoidentificador, false, includeNonInitialized);
         AddObjectProperty("CorreoNombre", gxTv_SdtCorreo_Correonombre, false, includeNonInitialized);
         AddObjectProperty("CorreoServidor", gxTv_SdtCorreo_Correoservidor, false, includeNonInitialized);
         AddObjectProperty("CorreoPuerto", gxTv_SdtCorreo_Correopuerto, false, includeNonInitialized);
         AddObjectProperty("CorreoUsuario", gxTv_SdtCorreo_Correousuario, false, includeNonInitialized);
         AddObjectProperty("CorreoContrasena", gxTv_SdtCorreo_Correocontrasena, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCorreo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCorreo_Initialized, false, includeNonInitialized);
            AddObjectProperty("CorreoId_Z", gxTv_SdtCorreo_Correoid_Z, false, includeNonInitialized);
            AddObjectProperty("CorreoIdentificador_Z", gxTv_SdtCorreo_Correoidentificador_Z, false, includeNonInitialized);
            AddObjectProperty("CorreoNombre_Z", gxTv_SdtCorreo_Correonombre_Z, false, includeNonInitialized);
            AddObjectProperty("CorreoServidor_Z", gxTv_SdtCorreo_Correoservidor_Z, false, includeNonInitialized);
            AddObjectProperty("CorreoPuerto_Z", gxTv_SdtCorreo_Correopuerto_Z, false, includeNonInitialized);
            AddObjectProperty("CorreoUsuario_Z", gxTv_SdtCorreo_Correousuario_Z, false, includeNonInitialized);
            AddObjectProperty("CorreoContrasena_Z", gxTv_SdtCorreo_Correocontrasena_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCorreo sdt )
      {
         if ( sdt.IsDirty("CorreoId") )
         {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correoid = sdt.gxTv_SdtCorreo_Correoid ;
         }
         if ( sdt.IsDirty("CorreoIdentificador") )
         {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correoidentificador = sdt.gxTv_SdtCorreo_Correoidentificador ;
         }
         if ( sdt.IsDirty("CorreoNombre") )
         {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correonombre = sdt.gxTv_SdtCorreo_Correonombre ;
         }
         if ( sdt.IsDirty("CorreoServidor") )
         {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correoservidor = sdt.gxTv_SdtCorreo_Correoservidor ;
         }
         if ( sdt.IsDirty("CorreoPuerto") )
         {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correopuerto = sdt.gxTv_SdtCorreo_Correopuerto ;
         }
         if ( sdt.IsDirty("CorreoUsuario") )
         {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correousuario = sdt.gxTv_SdtCorreo_Correousuario ;
         }
         if ( sdt.IsDirty("CorreoContrasena") )
         {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correocontrasena = sdt.gxTv_SdtCorreo_Correocontrasena ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CorreoId" )]
      [  XmlElement( ElementName = "CorreoId"   )]
      public short gxTpr_Correoid
      {
         get {
            return gxTv_SdtCorreo_Correoid ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            if ( gxTv_SdtCorreo_Correoid != value )
            {
               gxTv_SdtCorreo_Mode = "INS";
               this.gxTv_SdtCorreo_Correoid_Z_SetNull( );
               this.gxTv_SdtCorreo_Correoidentificador_Z_SetNull( );
               this.gxTv_SdtCorreo_Correonombre_Z_SetNull( );
               this.gxTv_SdtCorreo_Correoservidor_Z_SetNull( );
               this.gxTv_SdtCorreo_Correopuerto_Z_SetNull( );
               this.gxTv_SdtCorreo_Correousuario_Z_SetNull( );
               this.gxTv_SdtCorreo_Correocontrasena_Z_SetNull( );
            }
            gxTv_SdtCorreo_Correoid = value;
            SetDirty("Correoid");
         }

      }

      [  SoapElement( ElementName = "CorreoIdentificador" )]
      [  XmlElement( ElementName = "CorreoIdentificador"   )]
      public string gxTpr_Correoidentificador
      {
         get {
            return gxTv_SdtCorreo_Correoidentificador ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correoidentificador = value;
            SetDirty("Correoidentificador");
         }

      }

      [  SoapElement( ElementName = "CorreoNombre" )]
      [  XmlElement( ElementName = "CorreoNombre"   )]
      public string gxTpr_Correonombre
      {
         get {
            return gxTv_SdtCorreo_Correonombre ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correonombre = value;
            SetDirty("Correonombre");
         }

      }

      [  SoapElement( ElementName = "CorreoServidor" )]
      [  XmlElement( ElementName = "CorreoServidor"   )]
      public string gxTpr_Correoservidor
      {
         get {
            return gxTv_SdtCorreo_Correoservidor ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correoservidor = value;
            SetDirty("Correoservidor");
         }

      }

      [  SoapElement( ElementName = "CorreoPuerto" )]
      [  XmlElement( ElementName = "CorreoPuerto"   )]
      public short gxTpr_Correopuerto
      {
         get {
            return gxTv_SdtCorreo_Correopuerto ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correopuerto = value;
            SetDirty("Correopuerto");
         }

      }

      [  SoapElement( ElementName = "CorreoUsuario" )]
      [  XmlElement( ElementName = "CorreoUsuario"   )]
      public string gxTpr_Correousuario
      {
         get {
            return gxTv_SdtCorreo_Correousuario ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correousuario = value;
            SetDirty("Correousuario");
         }

      }

      [  SoapElement( ElementName = "CorreoContrasena" )]
      [  XmlElement( ElementName = "CorreoContrasena"   )]
      public string gxTpr_Correocontrasena
      {
         get {
            return gxTv_SdtCorreo_Correocontrasena ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correocontrasena = value;
            SetDirty("Correocontrasena");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCorreo_Mode ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCorreo_Mode_SetNull( )
      {
         gxTv_SdtCorreo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCorreo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCorreo_Initialized ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCorreo_Initialized_SetNull( )
      {
         gxTv_SdtCorreo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCorreo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CorreoId_Z" )]
      [  XmlElement( ElementName = "CorreoId_Z"   )]
      public short gxTpr_Correoid_Z
      {
         get {
            return gxTv_SdtCorreo_Correoid_Z ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correoid_Z = value;
            SetDirty("Correoid_Z");
         }

      }

      public void gxTv_SdtCorreo_Correoid_Z_SetNull( )
      {
         gxTv_SdtCorreo_Correoid_Z = 0;
         SetDirty("Correoid_Z");
         return  ;
      }

      public bool gxTv_SdtCorreo_Correoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CorreoIdentificador_Z" )]
      [  XmlElement( ElementName = "CorreoIdentificador_Z"   )]
      public string gxTpr_Correoidentificador_Z
      {
         get {
            return gxTv_SdtCorreo_Correoidentificador_Z ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correoidentificador_Z = value;
            SetDirty("Correoidentificador_Z");
         }

      }

      public void gxTv_SdtCorreo_Correoidentificador_Z_SetNull( )
      {
         gxTv_SdtCorreo_Correoidentificador_Z = "";
         SetDirty("Correoidentificador_Z");
         return  ;
      }

      public bool gxTv_SdtCorreo_Correoidentificador_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CorreoNombre_Z" )]
      [  XmlElement( ElementName = "CorreoNombre_Z"   )]
      public string gxTpr_Correonombre_Z
      {
         get {
            return gxTv_SdtCorreo_Correonombre_Z ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correonombre_Z = value;
            SetDirty("Correonombre_Z");
         }

      }

      public void gxTv_SdtCorreo_Correonombre_Z_SetNull( )
      {
         gxTv_SdtCorreo_Correonombre_Z = "";
         SetDirty("Correonombre_Z");
         return  ;
      }

      public bool gxTv_SdtCorreo_Correonombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CorreoServidor_Z" )]
      [  XmlElement( ElementName = "CorreoServidor_Z"   )]
      public string gxTpr_Correoservidor_Z
      {
         get {
            return gxTv_SdtCorreo_Correoservidor_Z ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correoservidor_Z = value;
            SetDirty("Correoservidor_Z");
         }

      }

      public void gxTv_SdtCorreo_Correoservidor_Z_SetNull( )
      {
         gxTv_SdtCorreo_Correoservidor_Z = "";
         SetDirty("Correoservidor_Z");
         return  ;
      }

      public bool gxTv_SdtCorreo_Correoservidor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CorreoPuerto_Z" )]
      [  XmlElement( ElementName = "CorreoPuerto_Z"   )]
      public short gxTpr_Correopuerto_Z
      {
         get {
            return gxTv_SdtCorreo_Correopuerto_Z ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correopuerto_Z = value;
            SetDirty("Correopuerto_Z");
         }

      }

      public void gxTv_SdtCorreo_Correopuerto_Z_SetNull( )
      {
         gxTv_SdtCorreo_Correopuerto_Z = 0;
         SetDirty("Correopuerto_Z");
         return  ;
      }

      public bool gxTv_SdtCorreo_Correopuerto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CorreoUsuario_Z" )]
      [  XmlElement( ElementName = "CorreoUsuario_Z"   )]
      public string gxTpr_Correousuario_Z
      {
         get {
            return gxTv_SdtCorreo_Correousuario_Z ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correousuario_Z = value;
            SetDirty("Correousuario_Z");
         }

      }

      public void gxTv_SdtCorreo_Correousuario_Z_SetNull( )
      {
         gxTv_SdtCorreo_Correousuario_Z = "";
         SetDirty("Correousuario_Z");
         return  ;
      }

      public bool gxTv_SdtCorreo_Correousuario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CorreoContrasena_Z" )]
      [  XmlElement( ElementName = "CorreoContrasena_Z"   )]
      public string gxTpr_Correocontrasena_Z
      {
         get {
            return gxTv_SdtCorreo_Correocontrasena_Z ;
         }

         set {
            gxTv_SdtCorreo_N = 0;
            gxTv_SdtCorreo_Correocontrasena_Z = value;
            SetDirty("Correocontrasena_Z");
         }

      }

      public void gxTv_SdtCorreo_Correocontrasena_Z_SetNull( )
      {
         gxTv_SdtCorreo_Correocontrasena_Z = "";
         SetDirty("Correocontrasena_Z");
         return  ;
      }

      public bool gxTv_SdtCorreo_Correocontrasena_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtCorreo_N = 1;
         gxTv_SdtCorreo_Correoidentificador = "";
         gxTv_SdtCorreo_Correonombre = "";
         gxTv_SdtCorreo_Correoservidor = "";
         gxTv_SdtCorreo_Correousuario = "";
         gxTv_SdtCorreo_Correocontrasena = "";
         gxTv_SdtCorreo_Mode = "";
         gxTv_SdtCorreo_Correoidentificador_Z = "";
         gxTv_SdtCorreo_Correonombre_Z = "";
         gxTv_SdtCorreo_Correoservidor_Z = "";
         gxTv_SdtCorreo_Correousuario_Z = "";
         gxTv_SdtCorreo_Correocontrasena_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "correo", "GeneXus.Programs.correo_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtCorreo_N ;
      }

      private short gxTv_SdtCorreo_Correoid ;
      private short gxTv_SdtCorreo_N ;
      private short gxTv_SdtCorreo_Correopuerto ;
      private short gxTv_SdtCorreo_Initialized ;
      private short gxTv_SdtCorreo_Correoid_Z ;
      private short gxTv_SdtCorreo_Correopuerto_Z ;
      private string gxTv_SdtCorreo_Correoidentificador ;
      private string gxTv_SdtCorreo_Correonombre ;
      private string gxTv_SdtCorreo_Correoservidor ;
      private string gxTv_SdtCorreo_Correocontrasena ;
      private string gxTv_SdtCorreo_Mode ;
      private string gxTv_SdtCorreo_Correoidentificador_Z ;
      private string gxTv_SdtCorreo_Correonombre_Z ;
      private string gxTv_SdtCorreo_Correoservidor_Z ;
      private string gxTv_SdtCorreo_Correocontrasena_Z ;
      private string gxTv_SdtCorreo_Correousuario ;
      private string gxTv_SdtCorreo_Correousuario_Z ;
   }

   [DataContract(Name = @"Correo", Namespace = "ProyectoUMG")]
   public class SdtCorreo_RESTInterface : GxGenericCollectionItem<SdtCorreo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCorreo_RESTInterface( ) : base()
      {
      }

      public SdtCorreo_RESTInterface( SdtCorreo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CorreoId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Correoid
      {
         get {
            return sdt.gxTpr_Correoid ;
         }

         set {
            sdt.gxTpr_Correoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CorreoIdentificador" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Correoidentificador
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Correoidentificador) ;
         }

         set {
            sdt.gxTpr_Correoidentificador = value;
         }

      }

      [DataMember( Name = "CorreoNombre" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Correonombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Correonombre) ;
         }

         set {
            sdt.gxTpr_Correonombre = value;
         }

      }

      [DataMember( Name = "CorreoServidor" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Correoservidor
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Correoservidor) ;
         }

         set {
            sdt.gxTpr_Correoservidor = value;
         }

      }

      [DataMember( Name = "CorreoPuerto" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Correopuerto
      {
         get {
            return sdt.gxTpr_Correopuerto ;
         }

         set {
            sdt.gxTpr_Correopuerto = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CorreoUsuario" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Correousuario
      {
         get {
            return sdt.gxTpr_Correousuario ;
         }

         set {
            sdt.gxTpr_Correousuario = value;
         }

      }

      [DataMember( Name = "CorreoContrasena" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Correocontrasena
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Correocontrasena) ;
         }

         set {
            sdt.gxTpr_Correocontrasena = value;
         }

      }

      public SdtCorreo sdt
      {
         get {
            return (SdtCorreo)Sdt ;
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
            sdt = new SdtCorreo() ;
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

   [DataContract(Name = @"Correo", Namespace = "ProyectoUMG")]
   public class SdtCorreo_RESTLInterface : GxGenericCollectionItem<SdtCorreo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCorreo_RESTLInterface( ) : base()
      {
      }

      public SdtCorreo_RESTLInterface( SdtCorreo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CorreoIdentificador" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Correoidentificador
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Correoidentificador) ;
         }

         set {
            sdt.gxTpr_Correoidentificador = value;
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

      public SdtCorreo sdt
      {
         get {
            return (SdtCorreo)Sdt ;
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
            sdt = new SdtCorreo() ;
         }
      }

   }

}
