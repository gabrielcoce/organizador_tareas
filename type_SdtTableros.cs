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
   [XmlRoot(ElementName = "Tableros" )]
   [XmlType(TypeName =  "Tableros" , Namespace = "ProyectoUMG" )]
   [Serializable]
   public class SdtTableros : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTableros( )
      {
      }

      public SdtTableros( IGxContext context )
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

      public void Load( short AV9TableroId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV9TableroId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TableroId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Tableros");
         metadata.Set("BT", "Tableros");
         metadata.Set("PK", "[ \"TableroId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"UsuarioId\" ],\"FKMap\":[ \"PropietarioId-UsuarioId\" ] } ]");
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
         state.Add("gxTpr_Tableronombre_Z");
         state.Add("gxTpr_Tablerofechacreacion_Z_Nullable");
         state.Add("gxTpr_Propietarioid_Z");
         state.Add("gxTpr_Tableroestado_Z");
         state.Add("gxTpr_Tablerovisibilidad_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTableros sdt;
         sdt = (SdtTableros)(source);
         gxTv_SdtTableros_Tableroid = sdt.gxTv_SdtTableros_Tableroid ;
         gxTv_SdtTableros_Tableronombre = sdt.gxTv_SdtTableros_Tableronombre ;
         gxTv_SdtTableros_Tablerofechacreacion = sdt.gxTv_SdtTableros_Tablerofechacreacion ;
         gxTv_SdtTableros_Propietarioid = sdt.gxTv_SdtTableros_Propietarioid ;
         gxTv_SdtTableros_Tableroestado = sdt.gxTv_SdtTableros_Tableroestado ;
         gxTv_SdtTableros_Tablerovisibilidad = sdt.gxTv_SdtTableros_Tablerovisibilidad ;
         gxTv_SdtTableros_Mode = sdt.gxTv_SdtTableros_Mode ;
         gxTv_SdtTableros_Initialized = sdt.gxTv_SdtTableros_Initialized ;
         gxTv_SdtTableros_Tableroid_Z = sdt.gxTv_SdtTableros_Tableroid_Z ;
         gxTv_SdtTableros_Tableronombre_Z = sdt.gxTv_SdtTableros_Tableronombre_Z ;
         gxTv_SdtTableros_Tablerofechacreacion_Z = sdt.gxTv_SdtTableros_Tablerofechacreacion_Z ;
         gxTv_SdtTableros_Propietarioid_Z = sdt.gxTv_SdtTableros_Propietarioid_Z ;
         gxTv_SdtTableros_Tableroestado_Z = sdt.gxTv_SdtTableros_Tableroestado_Z ;
         gxTv_SdtTableros_Tablerovisibilidad_Z = sdt.gxTv_SdtTableros_Tablerovisibilidad_Z ;
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
         AddObjectProperty("TableroId", gxTv_SdtTableros_Tableroid, false, includeNonInitialized);
         AddObjectProperty("TableroNombre", gxTv_SdtTableros_Tableronombre, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTableros_Tablerofechacreacion;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TableroFechaCreacion", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PropietarioId", gxTv_SdtTableros_Propietarioid, false, includeNonInitialized);
         AddObjectProperty("TableroEstado", gxTv_SdtTableros_Tableroestado, false, includeNonInitialized);
         AddObjectProperty("TableroVisibilidad", gxTv_SdtTableros_Tablerovisibilidad, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTableros_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTableros_Initialized, false, includeNonInitialized);
            AddObjectProperty("TableroId_Z", gxTv_SdtTableros_Tableroid_Z, false, includeNonInitialized);
            AddObjectProperty("TableroNombre_Z", gxTv_SdtTableros_Tableronombre_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTableros_Tablerofechacreacion_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TableroFechaCreacion_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PropietarioId_Z", gxTv_SdtTableros_Propietarioid_Z, false, includeNonInitialized);
            AddObjectProperty("TableroEstado_Z", gxTv_SdtTableros_Tableroestado_Z, false, includeNonInitialized);
            AddObjectProperty("TableroVisibilidad_Z", gxTv_SdtTableros_Tablerovisibilidad_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTableros sdt )
      {
         if ( sdt.IsDirty("TableroId") )
         {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tableroid = sdt.gxTv_SdtTableros_Tableroid ;
         }
         if ( sdt.IsDirty("TableroNombre") )
         {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tableronombre = sdt.gxTv_SdtTableros_Tableronombre ;
         }
         if ( sdt.IsDirty("TableroFechaCreacion") )
         {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tablerofechacreacion = sdt.gxTv_SdtTableros_Tablerofechacreacion ;
         }
         if ( sdt.IsDirty("PropietarioId") )
         {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Propietarioid = sdt.gxTv_SdtTableros_Propietarioid ;
         }
         if ( sdt.IsDirty("TableroEstado") )
         {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tableroestado = sdt.gxTv_SdtTableros_Tableroestado ;
         }
         if ( sdt.IsDirty("TableroVisibilidad") )
         {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tablerovisibilidad = sdt.gxTv_SdtTableros_Tablerovisibilidad ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TableroId" )]
      [  XmlElement( ElementName = "TableroId"   )]
      public short gxTpr_Tableroid
      {
         get {
            return gxTv_SdtTableros_Tableroid ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            if ( gxTv_SdtTableros_Tableroid != value )
            {
               gxTv_SdtTableros_Mode = "INS";
               this.gxTv_SdtTableros_Tableroid_Z_SetNull( );
               this.gxTv_SdtTableros_Tableronombre_Z_SetNull( );
               this.gxTv_SdtTableros_Tablerofechacreacion_Z_SetNull( );
               this.gxTv_SdtTableros_Propietarioid_Z_SetNull( );
               this.gxTv_SdtTableros_Tableroestado_Z_SetNull( );
               this.gxTv_SdtTableros_Tablerovisibilidad_Z_SetNull( );
            }
            gxTv_SdtTableros_Tableroid = value;
            SetDirty("Tableroid");
         }

      }

      [  SoapElement( ElementName = "TableroNombre" )]
      [  XmlElement( ElementName = "TableroNombre"   )]
      public string gxTpr_Tableronombre
      {
         get {
            return gxTv_SdtTableros_Tableronombre ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tableronombre = value;
            SetDirty("Tableronombre");
         }

      }

      [  SoapElement( ElementName = "TableroFechaCreacion" )]
      [  XmlElement( ElementName = "TableroFechaCreacion"  , IsNullable=true )]
      public string gxTpr_Tablerofechacreacion_Nullable
      {
         get {
            if ( gxTv_SdtTableros_Tablerofechacreacion == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTableros_Tablerofechacreacion).value ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTableros_Tablerofechacreacion = DateTime.MinValue;
            else
               gxTv_SdtTableros_Tablerofechacreacion = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Tablerofechacreacion
      {
         get {
            return gxTv_SdtTableros_Tablerofechacreacion ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tablerofechacreacion = value;
            SetDirty("Tablerofechacreacion");
         }

      }

      [  SoapElement( ElementName = "PropietarioId" )]
      [  XmlElement( ElementName = "PropietarioId"   )]
      public short gxTpr_Propietarioid
      {
         get {
            return gxTv_SdtTableros_Propietarioid ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Propietarioid = value;
            SetDirty("Propietarioid");
         }

      }

      [  SoapElement( ElementName = "TableroEstado" )]
      [  XmlElement( ElementName = "TableroEstado"   )]
      public bool gxTpr_Tableroestado
      {
         get {
            return gxTv_SdtTableros_Tableroestado ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tableroestado = value;
            SetDirty("Tableroestado");
         }

      }

      [  SoapElement( ElementName = "TableroVisibilidad" )]
      [  XmlElement( ElementName = "TableroVisibilidad"   )]
      public bool gxTpr_Tablerovisibilidad
      {
         get {
            return gxTv_SdtTableros_Tablerovisibilidad ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tablerovisibilidad = value;
            SetDirty("Tablerovisibilidad");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTableros_Mode ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTableros_Mode_SetNull( )
      {
         gxTv_SdtTableros_Mode = "";
         return  ;
      }

      public bool gxTv_SdtTableros_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTableros_Initialized ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTableros_Initialized_SetNull( )
      {
         gxTv_SdtTableros_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtTableros_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TableroId_Z" )]
      [  XmlElement( ElementName = "TableroId_Z"   )]
      public short gxTpr_Tableroid_Z
      {
         get {
            return gxTv_SdtTableros_Tableroid_Z ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tableroid_Z = value;
            SetDirty("Tableroid_Z");
         }

      }

      public void gxTv_SdtTableros_Tableroid_Z_SetNull( )
      {
         gxTv_SdtTableros_Tableroid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtTableros_Tableroid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TableroNombre_Z" )]
      [  XmlElement( ElementName = "TableroNombre_Z"   )]
      public string gxTpr_Tableronombre_Z
      {
         get {
            return gxTv_SdtTableros_Tableronombre_Z ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tableronombre_Z = value;
            SetDirty("Tableronombre_Z");
         }

      }

      public void gxTv_SdtTableros_Tableronombre_Z_SetNull( )
      {
         gxTv_SdtTableros_Tableronombre_Z = "";
         return  ;
      }

      public bool gxTv_SdtTableros_Tableronombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TableroFechaCreacion_Z" )]
      [  XmlElement( ElementName = "TableroFechaCreacion_Z"  , IsNullable=true )]
      public string gxTpr_Tablerofechacreacion_Z_Nullable
      {
         get {
            if ( gxTv_SdtTableros_Tablerofechacreacion_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTableros_Tablerofechacreacion_Z).value ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTableros_Tablerofechacreacion_Z = DateTime.MinValue;
            else
               gxTv_SdtTableros_Tablerofechacreacion_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Tablerofechacreacion_Z
      {
         get {
            return gxTv_SdtTableros_Tablerofechacreacion_Z ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tablerofechacreacion_Z = value;
            SetDirty("Tablerofechacreacion_Z");
         }

      }

      public void gxTv_SdtTableros_Tablerofechacreacion_Z_SetNull( )
      {
         gxTv_SdtTableros_Tablerofechacreacion_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtTableros_Tablerofechacreacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropietarioId_Z" )]
      [  XmlElement( ElementName = "PropietarioId_Z"   )]
      public short gxTpr_Propietarioid_Z
      {
         get {
            return gxTv_SdtTableros_Propietarioid_Z ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Propietarioid_Z = value;
            SetDirty("Propietarioid_Z");
         }

      }

      public void gxTv_SdtTableros_Propietarioid_Z_SetNull( )
      {
         gxTv_SdtTableros_Propietarioid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtTableros_Propietarioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TableroEstado_Z" )]
      [  XmlElement( ElementName = "TableroEstado_Z"   )]
      public bool gxTpr_Tableroestado_Z
      {
         get {
            return gxTv_SdtTableros_Tableroestado_Z ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tableroestado_Z = value;
            SetDirty("Tableroestado_Z");
         }

      }

      public void gxTv_SdtTableros_Tableroestado_Z_SetNull( )
      {
         gxTv_SdtTableros_Tableroestado_Z = false;
         return  ;
      }

      public bool gxTv_SdtTableros_Tableroestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TableroVisibilidad_Z" )]
      [  XmlElement( ElementName = "TableroVisibilidad_Z"   )]
      public bool gxTpr_Tablerovisibilidad_Z
      {
         get {
            return gxTv_SdtTableros_Tablerovisibilidad_Z ;
         }

         set {
            gxTv_SdtTableros_N = 0;
            gxTv_SdtTableros_Tablerovisibilidad_Z = value;
            SetDirty("Tablerovisibilidad_Z");
         }

      }

      public void gxTv_SdtTableros_Tablerovisibilidad_Z_SetNull( )
      {
         gxTv_SdtTableros_Tablerovisibilidad_Z = false;
         return  ;
      }

      public bool gxTv_SdtTableros_Tablerovisibilidad_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTableros_N = 1;
         gxTv_SdtTableros_Tableronombre = "";
         gxTv_SdtTableros_Tablerofechacreacion = (DateTime)(DateTime.MinValue);
         gxTv_SdtTableros_Mode = "";
         gxTv_SdtTableros_Tableronombre_Z = "";
         gxTv_SdtTableros_Tablerofechacreacion_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tableros", "GeneXus.Programs.tableros_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtTableros_N ;
      }

      private short gxTv_SdtTableros_Tableroid ;
      private short gxTv_SdtTableros_N ;
      private short gxTv_SdtTableros_Propietarioid ;
      private short gxTv_SdtTableros_Initialized ;
      private short gxTv_SdtTableros_Tableroid_Z ;
      private short gxTv_SdtTableros_Propietarioid_Z ;
      private string gxTv_SdtTableros_Tableronombre ;
      private string gxTv_SdtTableros_Mode ;
      private string gxTv_SdtTableros_Tableronombre_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTableros_Tablerofechacreacion ;
      private DateTime gxTv_SdtTableros_Tablerofechacreacion_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtTableros_Tableroestado ;
      private bool gxTv_SdtTableros_Tablerovisibilidad ;
      private bool gxTv_SdtTableros_Tableroestado_Z ;
      private bool gxTv_SdtTableros_Tablerovisibilidad_Z ;
   }

   [DataContract(Name = @"Tableros", Namespace = "ProyectoUMG")]
   public class SdtTableros_RESTInterface : GxGenericCollectionItem<SdtTableros>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTableros_RESTInterface( ) : base()
      {
      }

      public SdtTableros_RESTInterface( SdtTableros psdt ) : base(psdt)
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

      [DataMember( Name = "TableroNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tableronombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tableronombre) ;
         }

         set {
            sdt.gxTpr_Tableronombre = value;
         }

      }

      [DataMember( Name = "TableroFechaCreacion" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Tablerofechacreacion
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Tablerofechacreacion) ;
         }

         set {
            sdt.gxTpr_Tablerofechacreacion = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "PropietarioId" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propietarioid
      {
         get {
            return sdt.gxTpr_Propietarioid ;
         }

         set {
            sdt.gxTpr_Propietarioid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TableroEstado" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Tableroestado
      {
         get {
            return sdt.gxTpr_Tableroestado ;
         }

         set {
            sdt.gxTpr_Tableroestado = value;
         }

      }

      [DataMember( Name = "TableroVisibilidad" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Tablerovisibilidad
      {
         get {
            return sdt.gxTpr_Tablerovisibilidad ;
         }

         set {
            sdt.gxTpr_Tablerovisibilidad = value;
         }

      }

      public SdtTableros sdt
      {
         get {
            return (SdtTableros)Sdt ;
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
            sdt = new SdtTableros() ;
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

   [DataContract(Name = @"Tableros", Namespace = "ProyectoUMG")]
   public class SdtTableros_RESTLInterface : GxGenericCollectionItem<SdtTableros>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTableros_RESTLInterface( ) : base()
      {
      }

      public SdtTableros_RESTLInterface( SdtTableros psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TableroNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tableronombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tableronombre) ;
         }

         set {
            sdt.gxTpr_Tableronombre = value;
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

      public SdtTableros sdt
      {
         get {
            return (SdtTableros)Sdt ;
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
            sdt = new SdtTableros() ;
         }
      }

   }

}
