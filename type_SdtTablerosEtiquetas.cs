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
   [XmlRoot(ElementName = "TablerosEtiquetas" )]
   [XmlType(TypeName =  "TablerosEtiquetas" , Namespace = "ProyectoUMG" )]
   [Serializable]
   public class SdtTablerosEtiquetas : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTablerosEtiquetas( )
      {
      }

      public SdtTablerosEtiquetas( IGxContext context )
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

      public void Load( short AV9TableroId ,
                        short AV36EtiquetaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV9TableroId,(short)AV36EtiquetaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TableroId", typeof(short)}, new Object[]{"EtiquetaId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "TablerosEtiquetas");
         metadata.Set("BT", "TablerosEtiquetas");
         metadata.Set("PK", "[ \"TableroId\",\"EtiquetaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"TableroId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Tableroid_Z");
         state.Add("gxTpr_Etiquetaid_Z");
         state.Add("gxTpr_Etiquetanombre_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTablerosEtiquetas sdt;
         sdt = (SdtTablerosEtiquetas)(source);
         gxTv_SdtTablerosEtiquetas_Tableroid = sdt.gxTv_SdtTablerosEtiquetas_Tableroid ;
         gxTv_SdtTablerosEtiquetas_Etiquetaid = sdt.gxTv_SdtTablerosEtiquetas_Etiquetaid ;
         gxTv_SdtTablerosEtiquetas_Etiquetanombre = sdt.gxTv_SdtTablerosEtiquetas_Etiquetanombre ;
         gxTv_SdtTablerosEtiquetas_Mode = sdt.gxTv_SdtTablerosEtiquetas_Mode ;
         gxTv_SdtTablerosEtiquetas_Initialized = sdt.gxTv_SdtTablerosEtiquetas_Initialized ;
         gxTv_SdtTablerosEtiquetas_Tableroid_Z = sdt.gxTv_SdtTablerosEtiquetas_Tableroid_Z ;
         gxTv_SdtTablerosEtiquetas_Etiquetaid_Z = sdt.gxTv_SdtTablerosEtiquetas_Etiquetaid_Z ;
         gxTv_SdtTablerosEtiquetas_Etiquetanombre_Z = sdt.gxTv_SdtTablerosEtiquetas_Etiquetanombre_Z ;
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
         AddObjectProperty("TableroId", gxTv_SdtTablerosEtiquetas_Tableroid, false, includeNonInitialized);
         AddObjectProperty("EtiquetaId", gxTv_SdtTablerosEtiquetas_Etiquetaid, false, includeNonInitialized);
         AddObjectProperty("EtiquetaNombre", gxTv_SdtTablerosEtiquetas_Etiquetanombre, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTablerosEtiquetas_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTablerosEtiquetas_Initialized, false, includeNonInitialized);
            AddObjectProperty("TableroId_Z", gxTv_SdtTablerosEtiquetas_Tableroid_Z, false, includeNonInitialized);
            AddObjectProperty("EtiquetaId_Z", gxTv_SdtTablerosEtiquetas_Etiquetaid_Z, false, includeNonInitialized);
            AddObjectProperty("EtiquetaNombre_Z", gxTv_SdtTablerosEtiquetas_Etiquetanombre_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTablerosEtiquetas sdt )
      {
         if ( sdt.IsDirty("TableroId") )
         {
            gxTv_SdtTablerosEtiquetas_N = 0;
            gxTv_SdtTablerosEtiquetas_Tableroid = sdt.gxTv_SdtTablerosEtiquetas_Tableroid ;
         }
         if ( sdt.IsDirty("EtiquetaId") )
         {
            gxTv_SdtTablerosEtiquetas_N = 0;
            gxTv_SdtTablerosEtiquetas_Etiquetaid = sdt.gxTv_SdtTablerosEtiquetas_Etiquetaid ;
         }
         if ( sdt.IsDirty("EtiquetaNombre") )
         {
            gxTv_SdtTablerosEtiquetas_N = 0;
            gxTv_SdtTablerosEtiquetas_Etiquetanombre = sdt.gxTv_SdtTablerosEtiquetas_Etiquetanombre ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TableroId" )]
      [  XmlElement( ElementName = "TableroId"   )]
      public short gxTpr_Tableroid
      {
         get {
            return gxTv_SdtTablerosEtiquetas_Tableroid ;
         }

         set {
            gxTv_SdtTablerosEtiquetas_N = 0;
            if ( gxTv_SdtTablerosEtiquetas_Tableroid != value )
            {
               gxTv_SdtTablerosEtiquetas_Mode = "INS";
               this.gxTv_SdtTablerosEtiquetas_Tableroid_Z_SetNull( );
               this.gxTv_SdtTablerosEtiquetas_Etiquetaid_Z_SetNull( );
               this.gxTv_SdtTablerosEtiquetas_Etiquetanombre_Z_SetNull( );
            }
            gxTv_SdtTablerosEtiquetas_Tableroid = value;
            SetDirty("Tableroid");
         }

      }

      [  SoapElement( ElementName = "EtiquetaId" )]
      [  XmlElement( ElementName = "EtiquetaId"   )]
      public short gxTpr_Etiquetaid
      {
         get {
            return gxTv_SdtTablerosEtiquetas_Etiquetaid ;
         }

         set {
            gxTv_SdtTablerosEtiquetas_N = 0;
            if ( gxTv_SdtTablerosEtiquetas_Etiquetaid != value )
            {
               gxTv_SdtTablerosEtiquetas_Mode = "INS";
               this.gxTv_SdtTablerosEtiquetas_Tableroid_Z_SetNull( );
               this.gxTv_SdtTablerosEtiquetas_Etiquetaid_Z_SetNull( );
               this.gxTv_SdtTablerosEtiquetas_Etiquetanombre_Z_SetNull( );
            }
            gxTv_SdtTablerosEtiquetas_Etiquetaid = value;
            SetDirty("Etiquetaid");
         }

      }

      [  SoapElement( ElementName = "EtiquetaNombre" )]
      [  XmlElement( ElementName = "EtiquetaNombre"   )]
      public string gxTpr_Etiquetanombre
      {
         get {
            return gxTv_SdtTablerosEtiquetas_Etiquetanombre ;
         }

         set {
            gxTv_SdtTablerosEtiquetas_N = 0;
            gxTv_SdtTablerosEtiquetas_Etiquetanombre = value;
            SetDirty("Etiquetanombre");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTablerosEtiquetas_Mode ;
         }

         set {
            gxTv_SdtTablerosEtiquetas_N = 0;
            gxTv_SdtTablerosEtiquetas_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTablerosEtiquetas_Mode_SetNull( )
      {
         gxTv_SdtTablerosEtiquetas_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTablerosEtiquetas_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTablerosEtiquetas_Initialized ;
         }

         set {
            gxTv_SdtTablerosEtiquetas_N = 0;
            gxTv_SdtTablerosEtiquetas_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTablerosEtiquetas_Initialized_SetNull( )
      {
         gxTv_SdtTablerosEtiquetas_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTablerosEtiquetas_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TableroId_Z" )]
      [  XmlElement( ElementName = "TableroId_Z"   )]
      public short gxTpr_Tableroid_Z
      {
         get {
            return gxTv_SdtTablerosEtiquetas_Tableroid_Z ;
         }

         set {
            gxTv_SdtTablerosEtiquetas_N = 0;
            gxTv_SdtTablerosEtiquetas_Tableroid_Z = value;
            SetDirty("Tableroid_Z");
         }

      }

      public void gxTv_SdtTablerosEtiquetas_Tableroid_Z_SetNull( )
      {
         gxTv_SdtTablerosEtiquetas_Tableroid_Z = 0;
         SetDirty("Tableroid_Z");
         return  ;
      }

      public bool gxTv_SdtTablerosEtiquetas_Tableroid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EtiquetaId_Z" )]
      [  XmlElement( ElementName = "EtiquetaId_Z"   )]
      public short gxTpr_Etiquetaid_Z
      {
         get {
            return gxTv_SdtTablerosEtiquetas_Etiquetaid_Z ;
         }

         set {
            gxTv_SdtTablerosEtiquetas_N = 0;
            gxTv_SdtTablerosEtiquetas_Etiquetaid_Z = value;
            SetDirty("Etiquetaid_Z");
         }

      }

      public void gxTv_SdtTablerosEtiquetas_Etiquetaid_Z_SetNull( )
      {
         gxTv_SdtTablerosEtiquetas_Etiquetaid_Z = 0;
         SetDirty("Etiquetaid_Z");
         return  ;
      }

      public bool gxTv_SdtTablerosEtiquetas_Etiquetaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EtiquetaNombre_Z" )]
      [  XmlElement( ElementName = "EtiquetaNombre_Z"   )]
      public string gxTpr_Etiquetanombre_Z
      {
         get {
            return gxTv_SdtTablerosEtiquetas_Etiquetanombre_Z ;
         }

         set {
            gxTv_SdtTablerosEtiquetas_N = 0;
            gxTv_SdtTablerosEtiquetas_Etiquetanombre_Z = value;
            SetDirty("Etiquetanombre_Z");
         }

      }

      public void gxTv_SdtTablerosEtiquetas_Etiquetanombre_Z_SetNull( )
      {
         gxTv_SdtTablerosEtiquetas_Etiquetanombre_Z = "";
         SetDirty("Etiquetanombre_Z");
         return  ;
      }

      public bool gxTv_SdtTablerosEtiquetas_Etiquetanombre_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTablerosEtiquetas_N = 1;
         gxTv_SdtTablerosEtiquetas_Etiquetanombre = "";
         gxTv_SdtTablerosEtiquetas_Mode = "";
         gxTv_SdtTablerosEtiquetas_Etiquetanombre_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tablerosetiquetas", "GeneXus.Programs.tablerosetiquetas_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtTablerosEtiquetas_N ;
      }

      private short gxTv_SdtTablerosEtiquetas_Tableroid ;
      private short gxTv_SdtTablerosEtiquetas_N ;
      private short gxTv_SdtTablerosEtiquetas_Etiquetaid ;
      private short gxTv_SdtTablerosEtiquetas_Initialized ;
      private short gxTv_SdtTablerosEtiquetas_Tableroid_Z ;
      private short gxTv_SdtTablerosEtiquetas_Etiquetaid_Z ;
      private string gxTv_SdtTablerosEtiquetas_Etiquetanombre ;
      private string gxTv_SdtTablerosEtiquetas_Mode ;
      private string gxTv_SdtTablerosEtiquetas_Etiquetanombre_Z ;
   }

   [DataContract(Name = @"TablerosEtiquetas", Namespace = "ProyectoUMG")]
   public class SdtTablerosEtiquetas_RESTInterface : GxGenericCollectionItem<SdtTablerosEtiquetas>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTablerosEtiquetas_RESTInterface( ) : base()
      {
      }

      public SdtTablerosEtiquetas_RESTInterface( SdtTablerosEtiquetas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TableroId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Tableroid
      {
         get {
            return sdt.gxTpr_Tableroid ;
         }

         set {
            sdt.gxTpr_Tableroid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EtiquetaId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Etiquetaid
      {
         get {
            return sdt.gxTpr_Etiquetaid ;
         }

         set {
            sdt.gxTpr_Etiquetaid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EtiquetaNombre" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Etiquetanombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Etiquetanombre) ;
         }

         set {
            sdt.gxTpr_Etiquetanombre = value;
         }

      }

      public SdtTablerosEtiquetas sdt
      {
         get {
            return (SdtTablerosEtiquetas)Sdt ;
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
            sdt = new SdtTablerosEtiquetas() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 3 )]
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

   [DataContract(Name = @"TablerosEtiquetas", Namespace = "ProyectoUMG")]
   public class SdtTablerosEtiquetas_RESTLInterface : GxGenericCollectionItem<SdtTablerosEtiquetas>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTablerosEtiquetas_RESTLInterface( ) : base()
      {
      }

      public SdtTablerosEtiquetas_RESTLInterface( SdtTablerosEtiquetas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EtiquetaNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Etiquetanombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Etiquetanombre) ;
         }

         set {
            sdt.gxTpr_Etiquetanombre = value;
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

      public SdtTablerosEtiquetas sdt
      {
         get {
            return (SdtTablerosEtiquetas)Sdt ;
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
            sdt = new SdtTablerosEtiquetas() ;
         }
      }

   }

}
