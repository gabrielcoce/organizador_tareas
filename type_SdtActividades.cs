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
   [XmlRoot(ElementName = "Actividades" )]
   [XmlType(TypeName =  "Actividades" , Namespace = "ProyectoUMG" )]
   [Serializable]
   public class SdtActividades : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtActividades( )
      {
      }

      public SdtActividades( IGxContext context )
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
                        short AV12TareaId ,
                        short AV30ActividadId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV9TableroId,(short)AV12TareaId,(short)AV30ActividadId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TableroId", typeof(short)}, new Object[]{"TareaId", typeof(short)}, new Object[]{"ActividadId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Actividades");
         metadata.Set("BT", "Actividades");
         metadata.Set("PK", "[ \"TableroId\",\"TareaId\",\"ActividadId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"TableroId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TableroId\",\"TareaId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Tareaid_Z");
         state.Add("gxTpr_Actividadid_Z");
         state.Add("gxTpr_Actividadnombre_Z");
         state.Add("gxTpr_Actividadavance_Z");
         state.Add("gxTpr_Actividadestado_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtActividades sdt;
         sdt = (SdtActividades)(source);
         gxTv_SdtActividades_Tableroid = sdt.gxTv_SdtActividades_Tableroid ;
         gxTv_SdtActividades_Tareaid = sdt.gxTv_SdtActividades_Tareaid ;
         gxTv_SdtActividades_Actividadid = sdt.gxTv_SdtActividades_Actividadid ;
         gxTv_SdtActividades_Actividadnombre = sdt.gxTv_SdtActividades_Actividadnombre ;
         gxTv_SdtActividades_Actividadavance = sdt.gxTv_SdtActividades_Actividadavance ;
         gxTv_SdtActividades_Actividadestado = sdt.gxTv_SdtActividades_Actividadestado ;
         gxTv_SdtActividades_Mode = sdt.gxTv_SdtActividades_Mode ;
         gxTv_SdtActividades_Initialized = sdt.gxTv_SdtActividades_Initialized ;
         gxTv_SdtActividades_Tableroid_Z = sdt.gxTv_SdtActividades_Tableroid_Z ;
         gxTv_SdtActividades_Tareaid_Z = sdt.gxTv_SdtActividades_Tareaid_Z ;
         gxTv_SdtActividades_Actividadid_Z = sdt.gxTv_SdtActividades_Actividadid_Z ;
         gxTv_SdtActividades_Actividadnombre_Z = sdt.gxTv_SdtActividades_Actividadnombre_Z ;
         gxTv_SdtActividades_Actividadavance_Z = sdt.gxTv_SdtActividades_Actividadavance_Z ;
         gxTv_SdtActividades_Actividadestado_Z = sdt.gxTv_SdtActividades_Actividadestado_Z ;
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
         AddObjectProperty("TableroId", gxTv_SdtActividades_Tableroid, false, includeNonInitialized);
         AddObjectProperty("TareaId", gxTv_SdtActividades_Tareaid, false, includeNonInitialized);
         AddObjectProperty("ActividadId", gxTv_SdtActividades_Actividadid, false, includeNonInitialized);
         AddObjectProperty("ActividadNombre", gxTv_SdtActividades_Actividadnombre, false, includeNonInitialized);
         AddObjectProperty("ActividadAvance", gxTv_SdtActividades_Actividadavance, false, includeNonInitialized);
         AddObjectProperty("ActividadEstado", gxTv_SdtActividades_Actividadestado, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtActividades_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtActividades_Initialized, false, includeNonInitialized);
            AddObjectProperty("TableroId_Z", gxTv_SdtActividades_Tableroid_Z, false, includeNonInitialized);
            AddObjectProperty("TareaId_Z", gxTv_SdtActividades_Tareaid_Z, false, includeNonInitialized);
            AddObjectProperty("ActividadId_Z", gxTv_SdtActividades_Actividadid_Z, false, includeNonInitialized);
            AddObjectProperty("ActividadNombre_Z", gxTv_SdtActividades_Actividadnombre_Z, false, includeNonInitialized);
            AddObjectProperty("ActividadAvance_Z", gxTv_SdtActividades_Actividadavance_Z, false, includeNonInitialized);
            AddObjectProperty("ActividadEstado_Z", gxTv_SdtActividades_Actividadestado_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtActividades sdt )
      {
         if ( sdt.IsDirty("TableroId") )
         {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Tableroid = sdt.gxTv_SdtActividades_Tableroid ;
         }
         if ( sdt.IsDirty("TareaId") )
         {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Tareaid = sdt.gxTv_SdtActividades_Tareaid ;
         }
         if ( sdt.IsDirty("ActividadId") )
         {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Actividadid = sdt.gxTv_SdtActividades_Actividadid ;
         }
         if ( sdt.IsDirty("ActividadNombre") )
         {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Actividadnombre = sdt.gxTv_SdtActividades_Actividadnombre ;
         }
         if ( sdt.IsDirty("ActividadAvance") )
         {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Actividadavance = sdt.gxTv_SdtActividades_Actividadavance ;
         }
         if ( sdt.IsDirty("ActividadEstado") )
         {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Actividadestado = sdt.gxTv_SdtActividades_Actividadestado ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TableroId" )]
      [  XmlElement( ElementName = "TableroId"   )]
      public short gxTpr_Tableroid
      {
         get {
            return gxTv_SdtActividades_Tableroid ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            if ( gxTv_SdtActividades_Tableroid != value )
            {
               gxTv_SdtActividades_Mode = "INS";
               this.gxTv_SdtActividades_Tableroid_Z_SetNull( );
               this.gxTv_SdtActividades_Tareaid_Z_SetNull( );
               this.gxTv_SdtActividades_Actividadid_Z_SetNull( );
               this.gxTv_SdtActividades_Actividadnombre_Z_SetNull( );
               this.gxTv_SdtActividades_Actividadavance_Z_SetNull( );
               this.gxTv_SdtActividades_Actividadestado_Z_SetNull( );
            }
            gxTv_SdtActividades_Tableroid = value;
            SetDirty("Tableroid");
         }

      }

      [  SoapElement( ElementName = "TareaId" )]
      [  XmlElement( ElementName = "TareaId"   )]
      public short gxTpr_Tareaid
      {
         get {
            return gxTv_SdtActividades_Tareaid ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            if ( gxTv_SdtActividades_Tareaid != value )
            {
               gxTv_SdtActividades_Mode = "INS";
               this.gxTv_SdtActividades_Tableroid_Z_SetNull( );
               this.gxTv_SdtActividades_Tareaid_Z_SetNull( );
               this.gxTv_SdtActividades_Actividadid_Z_SetNull( );
               this.gxTv_SdtActividades_Actividadnombre_Z_SetNull( );
               this.gxTv_SdtActividades_Actividadavance_Z_SetNull( );
               this.gxTv_SdtActividades_Actividadestado_Z_SetNull( );
            }
            gxTv_SdtActividades_Tareaid = value;
            SetDirty("Tareaid");
         }

      }

      [  SoapElement( ElementName = "ActividadId" )]
      [  XmlElement( ElementName = "ActividadId"   )]
      public short gxTpr_Actividadid
      {
         get {
            return gxTv_SdtActividades_Actividadid ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            if ( gxTv_SdtActividades_Actividadid != value )
            {
               gxTv_SdtActividades_Mode = "INS";
               this.gxTv_SdtActividades_Tableroid_Z_SetNull( );
               this.gxTv_SdtActividades_Tareaid_Z_SetNull( );
               this.gxTv_SdtActividades_Actividadid_Z_SetNull( );
               this.gxTv_SdtActividades_Actividadnombre_Z_SetNull( );
               this.gxTv_SdtActividades_Actividadavance_Z_SetNull( );
               this.gxTv_SdtActividades_Actividadestado_Z_SetNull( );
            }
            gxTv_SdtActividades_Actividadid = value;
            SetDirty("Actividadid");
         }

      }

      [  SoapElement( ElementName = "ActividadNombre" )]
      [  XmlElement( ElementName = "ActividadNombre"   )]
      public string gxTpr_Actividadnombre
      {
         get {
            return gxTv_SdtActividades_Actividadnombre ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Actividadnombre = value;
            SetDirty("Actividadnombre");
         }

      }

      [  SoapElement( ElementName = "ActividadAvance" )]
      [  XmlElement( ElementName = "ActividadAvance"   )]
      public short gxTpr_Actividadavance
      {
         get {
            return gxTv_SdtActividades_Actividadavance ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Actividadavance = value;
            SetDirty("Actividadavance");
         }

      }

      [  SoapElement( ElementName = "ActividadEstado" )]
      [  XmlElement( ElementName = "ActividadEstado"   )]
      public short gxTpr_Actividadestado
      {
         get {
            return gxTv_SdtActividades_Actividadestado ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Actividadestado = value;
            SetDirty("Actividadestado");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtActividades_Mode ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtActividades_Mode_SetNull( )
      {
         gxTv_SdtActividades_Mode = "";
         return  ;
      }

      public bool gxTv_SdtActividades_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtActividades_Initialized ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtActividades_Initialized_SetNull( )
      {
         gxTv_SdtActividades_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtActividades_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TableroId_Z" )]
      [  XmlElement( ElementName = "TableroId_Z"   )]
      public short gxTpr_Tableroid_Z
      {
         get {
            return gxTv_SdtActividades_Tableroid_Z ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Tableroid_Z = value;
            SetDirty("Tableroid_Z");
         }

      }

      public void gxTv_SdtActividades_Tableroid_Z_SetNull( )
      {
         gxTv_SdtActividades_Tableroid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtActividades_Tableroid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TareaId_Z" )]
      [  XmlElement( ElementName = "TareaId_Z"   )]
      public short gxTpr_Tareaid_Z
      {
         get {
            return gxTv_SdtActividades_Tareaid_Z ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Tareaid_Z = value;
            SetDirty("Tareaid_Z");
         }

      }

      public void gxTv_SdtActividades_Tareaid_Z_SetNull( )
      {
         gxTv_SdtActividades_Tareaid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtActividades_Tareaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ActividadId_Z" )]
      [  XmlElement( ElementName = "ActividadId_Z"   )]
      public short gxTpr_Actividadid_Z
      {
         get {
            return gxTv_SdtActividades_Actividadid_Z ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Actividadid_Z = value;
            SetDirty("Actividadid_Z");
         }

      }

      public void gxTv_SdtActividades_Actividadid_Z_SetNull( )
      {
         gxTv_SdtActividades_Actividadid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtActividades_Actividadid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ActividadNombre_Z" )]
      [  XmlElement( ElementName = "ActividadNombre_Z"   )]
      public string gxTpr_Actividadnombre_Z
      {
         get {
            return gxTv_SdtActividades_Actividadnombre_Z ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Actividadnombre_Z = value;
            SetDirty("Actividadnombre_Z");
         }

      }

      public void gxTv_SdtActividades_Actividadnombre_Z_SetNull( )
      {
         gxTv_SdtActividades_Actividadnombre_Z = "";
         return  ;
      }

      public bool gxTv_SdtActividades_Actividadnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ActividadAvance_Z" )]
      [  XmlElement( ElementName = "ActividadAvance_Z"   )]
      public short gxTpr_Actividadavance_Z
      {
         get {
            return gxTv_SdtActividades_Actividadavance_Z ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Actividadavance_Z = value;
            SetDirty("Actividadavance_Z");
         }

      }

      public void gxTv_SdtActividades_Actividadavance_Z_SetNull( )
      {
         gxTv_SdtActividades_Actividadavance_Z = 0;
         return  ;
      }

      public bool gxTv_SdtActividades_Actividadavance_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ActividadEstado_Z" )]
      [  XmlElement( ElementName = "ActividadEstado_Z"   )]
      public short gxTpr_Actividadestado_Z
      {
         get {
            return gxTv_SdtActividades_Actividadestado_Z ;
         }

         set {
            gxTv_SdtActividades_N = 0;
            gxTv_SdtActividades_Actividadestado_Z = value;
            SetDirty("Actividadestado_Z");
         }

      }

      public void gxTv_SdtActividades_Actividadestado_Z_SetNull( )
      {
         gxTv_SdtActividades_Actividadestado_Z = 0;
         return  ;
      }

      public bool gxTv_SdtActividades_Actividadestado_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtActividades_N = 1;
         gxTv_SdtActividades_Actividadnombre = "";
         gxTv_SdtActividades_Mode = "";
         gxTv_SdtActividades_Actividadnombre_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "actividades", "GeneXus.Programs.actividades_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtActividades_N ;
      }

      private short gxTv_SdtActividades_Tableroid ;
      private short gxTv_SdtActividades_N ;
      private short gxTv_SdtActividades_Tareaid ;
      private short gxTv_SdtActividades_Actividadid ;
      private short gxTv_SdtActividades_Actividadavance ;
      private short gxTv_SdtActividades_Actividadestado ;
      private short gxTv_SdtActividades_Initialized ;
      private short gxTv_SdtActividades_Tableroid_Z ;
      private short gxTv_SdtActividades_Tareaid_Z ;
      private short gxTv_SdtActividades_Actividadid_Z ;
      private short gxTv_SdtActividades_Actividadavance_Z ;
      private short gxTv_SdtActividades_Actividadestado_Z ;
      private string gxTv_SdtActividades_Actividadnombre ;
      private string gxTv_SdtActividades_Mode ;
      private string gxTv_SdtActividades_Actividadnombre_Z ;
   }

   [DataContract(Name = @"Actividades", Namespace = "ProyectoUMG")]
   public class SdtActividades_RESTInterface : GxGenericCollectionItem<SdtActividades>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtActividades_RESTInterface( ) : base()
      {
      }

      public SdtActividades_RESTInterface( SdtActividades psdt ) : base(psdt)
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

      [DataMember( Name = "TareaId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Tareaid
      {
         get {
            return sdt.gxTpr_Tareaid ;
         }

         set {
            sdt.gxTpr_Tareaid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ActividadId" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Actividadid
      {
         get {
            return sdt.gxTpr_Actividadid ;
         }

         set {
            sdt.gxTpr_Actividadid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ActividadNombre" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Actividadnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Actividadnombre) ;
         }

         set {
            sdt.gxTpr_Actividadnombre = value;
         }

      }

      [DataMember( Name = "ActividadAvance" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Actividadavance
      {
         get {
            return sdt.gxTpr_Actividadavance ;
         }

         set {
            sdt.gxTpr_Actividadavance = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ActividadEstado" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Actividadestado
      {
         get {
            return sdt.gxTpr_Actividadestado ;
         }

         set {
            sdt.gxTpr_Actividadestado = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtActividades sdt
      {
         get {
            return (SdtActividades)Sdt ;
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
            sdt = new SdtActividades() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 6 )]
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

   [DataContract(Name = @"Actividades", Namespace = "ProyectoUMG")]
   public class SdtActividades_RESTLInterface : GxGenericCollectionItem<SdtActividades>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtActividades_RESTLInterface( ) : base()
      {
      }

      public SdtActividades_RESTLInterface( SdtActividades psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ActividadNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Actividadnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Actividadnombre) ;
         }

         set {
            sdt.gxTpr_Actividadnombre = value;
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

      public SdtActividades sdt
      {
         get {
            return (SdtActividades)Sdt ;
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
            sdt = new SdtActividades() ;
         }
      }

   }

}
