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
   [XmlRoot(ElementName = "Roles" )]
   [XmlType(TypeName =  "Roles" , Namespace = "ProyectoUMG" )]
   [Serializable]
   public class SdtRoles : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRoles( )
      {
      }

      public SdtRoles( IGxContext context )
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

      public void Load( short AV1RolId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV1RolId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"RolId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Roles");
         metadata.Set("BT", "Roles");
         metadata.Set("PK", "[ \"RolId\" ]");
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
         state.Add("gxTpr_Rolid_Z");
         state.Add("gxTpr_Rolnombre_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtRoles sdt;
         sdt = (SdtRoles)(source);
         gxTv_SdtRoles_Rolid = sdt.gxTv_SdtRoles_Rolid ;
         gxTv_SdtRoles_Rolnombre = sdt.gxTv_SdtRoles_Rolnombre ;
         gxTv_SdtRoles_Mode = sdt.gxTv_SdtRoles_Mode ;
         gxTv_SdtRoles_Initialized = sdt.gxTv_SdtRoles_Initialized ;
         gxTv_SdtRoles_Rolid_Z = sdt.gxTv_SdtRoles_Rolid_Z ;
         gxTv_SdtRoles_Rolnombre_Z = sdt.gxTv_SdtRoles_Rolnombre_Z ;
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
         AddObjectProperty("RolId", gxTv_SdtRoles_Rolid, false, includeNonInitialized);
         AddObjectProperty("RolNombre", gxTv_SdtRoles_Rolnombre, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtRoles_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtRoles_Initialized, false, includeNonInitialized);
            AddObjectProperty("RolId_Z", gxTv_SdtRoles_Rolid_Z, false, includeNonInitialized);
            AddObjectProperty("RolNombre_Z", gxTv_SdtRoles_Rolnombre_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtRoles sdt )
      {
         if ( sdt.IsDirty("RolId") )
         {
            gxTv_SdtRoles_N = 0;
            gxTv_SdtRoles_Rolid = sdt.gxTv_SdtRoles_Rolid ;
         }
         if ( sdt.IsDirty("RolNombre") )
         {
            gxTv_SdtRoles_N = 0;
            gxTv_SdtRoles_Rolnombre = sdt.gxTv_SdtRoles_Rolnombre ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "RolId" )]
      [  XmlElement( ElementName = "RolId"   )]
      public short gxTpr_Rolid
      {
         get {
            return gxTv_SdtRoles_Rolid ;
         }

         set {
            gxTv_SdtRoles_N = 0;
            if ( gxTv_SdtRoles_Rolid != value )
            {
               gxTv_SdtRoles_Mode = "INS";
               this.gxTv_SdtRoles_Rolid_Z_SetNull( );
               this.gxTv_SdtRoles_Rolnombre_Z_SetNull( );
            }
            gxTv_SdtRoles_Rolid = value;
            SetDirty("Rolid");
         }

      }

      [  SoapElement( ElementName = "RolNombre" )]
      [  XmlElement( ElementName = "RolNombre"   )]
      public string gxTpr_Rolnombre
      {
         get {
            return gxTv_SdtRoles_Rolnombre ;
         }

         set {
            gxTv_SdtRoles_N = 0;
            gxTv_SdtRoles_Rolnombre = value;
            SetDirty("Rolnombre");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtRoles_Mode ;
         }

         set {
            gxTv_SdtRoles_N = 0;
            gxTv_SdtRoles_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtRoles_Mode_SetNull( )
      {
         gxTv_SdtRoles_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtRoles_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtRoles_Initialized ;
         }

         set {
            gxTv_SdtRoles_N = 0;
            gxTv_SdtRoles_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtRoles_Initialized_SetNull( )
      {
         gxTv_SdtRoles_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtRoles_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RolId_Z" )]
      [  XmlElement( ElementName = "RolId_Z"   )]
      public short gxTpr_Rolid_Z
      {
         get {
            return gxTv_SdtRoles_Rolid_Z ;
         }

         set {
            gxTv_SdtRoles_N = 0;
            gxTv_SdtRoles_Rolid_Z = value;
            SetDirty("Rolid_Z");
         }

      }

      public void gxTv_SdtRoles_Rolid_Z_SetNull( )
      {
         gxTv_SdtRoles_Rolid_Z = 0;
         SetDirty("Rolid_Z");
         return  ;
      }

      public bool gxTv_SdtRoles_Rolid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RolNombre_Z" )]
      [  XmlElement( ElementName = "RolNombre_Z"   )]
      public string gxTpr_Rolnombre_Z
      {
         get {
            return gxTv_SdtRoles_Rolnombre_Z ;
         }

         set {
            gxTv_SdtRoles_N = 0;
            gxTv_SdtRoles_Rolnombre_Z = value;
            SetDirty("Rolnombre_Z");
         }

      }

      public void gxTv_SdtRoles_Rolnombre_Z_SetNull( )
      {
         gxTv_SdtRoles_Rolnombre_Z = "";
         SetDirty("Rolnombre_Z");
         return  ;
      }

      public bool gxTv_SdtRoles_Rolnombre_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtRoles_N = 1;
         gxTv_SdtRoles_Rolnombre = "";
         gxTv_SdtRoles_Mode = "";
         gxTv_SdtRoles_Rolnombre_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "roles", "GeneXus.Programs.roles_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtRoles_N ;
      }

      private short gxTv_SdtRoles_Rolid ;
      private short gxTv_SdtRoles_N ;
      private short gxTv_SdtRoles_Initialized ;
      private short gxTv_SdtRoles_Rolid_Z ;
      private string gxTv_SdtRoles_Rolnombre ;
      private string gxTv_SdtRoles_Mode ;
      private string gxTv_SdtRoles_Rolnombre_Z ;
   }

   [DataContract(Name = @"Roles", Namespace = "ProyectoUMG")]
   public class SdtRoles_RESTInterface : GxGenericCollectionItem<SdtRoles>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRoles_RESTInterface( ) : base()
      {
      }

      public SdtRoles_RESTInterface( SdtRoles psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RolId" , Order = 0 )]
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

      [DataMember( Name = "RolNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Rolnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Rolnombre) ;
         }

         set {
            sdt.gxTpr_Rolnombre = value;
         }

      }

      public SdtRoles sdt
      {
         get {
            return (SdtRoles)Sdt ;
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
            sdt = new SdtRoles() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 2 )]
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

   [DataContract(Name = @"Roles", Namespace = "ProyectoUMG")]
   public class SdtRoles_RESTLInterface : GxGenericCollectionItem<SdtRoles>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRoles_RESTLInterface( ) : base()
      {
      }

      public SdtRoles_RESTLInterface( SdtRoles psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RolNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Rolnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Rolnombre) ;
         }

         set {
            sdt.gxTpr_Rolnombre = value;
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

      public SdtRoles sdt
      {
         get {
            return (SdtRoles)Sdt ;
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
            sdt = new SdtRoles() ;
         }
      }

   }

}
