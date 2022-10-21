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
   [XmlRoot(ElementName = "Participantes" )]
   [XmlType(TypeName =  "Participantes" , Namespace = "ProyectoUMG" )]
   [Serializable]
   public class SdtParticipantes : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtParticipantes( )
      {
      }

      public SdtParticipantes( IGxContext context )
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
                        short AV18ParticipanteTableroId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV9TableroId,(short)AV18ParticipanteTableroId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TableroId", typeof(short)}, new Object[]{"ParticipanteTableroId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Participantes");
         metadata.Set("BT", "Participantes");
         metadata.Set("PK", "[ \"TableroId\",\"ParticipanteTableroId\" ]");
         metadata.Set("PKAssigned", "[ \"ParticipanteTableroId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"RolId\" ],\"FKMap\":[ \"ParticipanteRolId-RolId\" ] },{ \"FK\":[ \"TableroId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"UsuarioId\" ],\"FKMap\":[ \"ParticipanteTableroId-UsuarioId\" ] } ]");
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
         state.Add("gxTpr_Participantetableroid_Z");
         state.Add("gxTpr_Registrofecha_Z_Nullable");
         state.Add("gxTpr_Participanterolid_Z");
         state.Add("gxTpr_Participantetableroestado_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtParticipantes sdt;
         sdt = (SdtParticipantes)(source);
         gxTv_SdtParticipantes_Tableroid = sdt.gxTv_SdtParticipantes_Tableroid ;
         gxTv_SdtParticipantes_Participantetableroid = sdt.gxTv_SdtParticipantes_Participantetableroid ;
         gxTv_SdtParticipantes_Registrofecha = sdt.gxTv_SdtParticipantes_Registrofecha ;
         gxTv_SdtParticipantes_Participanterolid = sdt.gxTv_SdtParticipantes_Participanterolid ;
         gxTv_SdtParticipantes_Participantetableroestado = sdt.gxTv_SdtParticipantes_Participantetableroestado ;
         gxTv_SdtParticipantes_Mode = sdt.gxTv_SdtParticipantes_Mode ;
         gxTv_SdtParticipantes_Initialized = sdt.gxTv_SdtParticipantes_Initialized ;
         gxTv_SdtParticipantes_Tableroid_Z = sdt.gxTv_SdtParticipantes_Tableroid_Z ;
         gxTv_SdtParticipantes_Participantetableroid_Z = sdt.gxTv_SdtParticipantes_Participantetableroid_Z ;
         gxTv_SdtParticipantes_Registrofecha_Z = sdt.gxTv_SdtParticipantes_Registrofecha_Z ;
         gxTv_SdtParticipantes_Participanterolid_Z = sdt.gxTv_SdtParticipantes_Participanterolid_Z ;
         gxTv_SdtParticipantes_Participantetableroestado_Z = sdt.gxTv_SdtParticipantes_Participantetableroestado_Z ;
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
         AddObjectProperty("TableroId", gxTv_SdtParticipantes_Tableroid, false, includeNonInitialized);
         AddObjectProperty("ParticipanteTableroId", gxTv_SdtParticipantes_Participantetableroid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtParticipantes_Registrofecha;
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
         AddObjectProperty("RegistroFecha", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ParticipanteRolId", gxTv_SdtParticipantes_Participanterolid, false, includeNonInitialized);
         AddObjectProperty("ParticipanteTableroEstado", gxTv_SdtParticipantes_Participantetableroestado, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtParticipantes_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtParticipantes_Initialized, false, includeNonInitialized);
            AddObjectProperty("TableroId_Z", gxTv_SdtParticipantes_Tableroid_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteTableroId_Z", gxTv_SdtParticipantes_Participantetableroid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtParticipantes_Registrofecha_Z;
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
            AddObjectProperty("RegistroFecha_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ParticipanteRolId_Z", gxTv_SdtParticipantes_Participanterolid_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteTableroEstado_Z", gxTv_SdtParticipantes_Participantetableroestado_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtParticipantes sdt )
      {
         if ( sdt.IsDirty("TableroId") )
         {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Tableroid = sdt.gxTv_SdtParticipantes_Tableroid ;
         }
         if ( sdt.IsDirty("ParticipanteTableroId") )
         {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Participantetableroid = sdt.gxTv_SdtParticipantes_Participantetableroid ;
         }
         if ( sdt.IsDirty("RegistroFecha") )
         {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Registrofecha = sdt.gxTv_SdtParticipantes_Registrofecha ;
         }
         if ( sdt.IsDirty("ParticipanteRolId") )
         {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Participanterolid = sdt.gxTv_SdtParticipantes_Participanterolid ;
         }
         if ( sdt.IsDirty("ParticipanteTableroEstado") )
         {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Participantetableroestado = sdt.gxTv_SdtParticipantes_Participantetableroestado ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TableroId" )]
      [  XmlElement( ElementName = "TableroId"   )]
      public short gxTpr_Tableroid
      {
         get {
            return gxTv_SdtParticipantes_Tableroid ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            if ( gxTv_SdtParticipantes_Tableroid != value )
            {
               gxTv_SdtParticipantes_Mode = "INS";
               this.gxTv_SdtParticipantes_Tableroid_Z_SetNull( );
               this.gxTv_SdtParticipantes_Participantetableroid_Z_SetNull( );
               this.gxTv_SdtParticipantes_Registrofecha_Z_SetNull( );
               this.gxTv_SdtParticipantes_Participanterolid_Z_SetNull( );
               this.gxTv_SdtParticipantes_Participantetableroestado_Z_SetNull( );
            }
            gxTv_SdtParticipantes_Tableroid = value;
            SetDirty("Tableroid");
         }

      }

      [  SoapElement( ElementName = "ParticipanteTableroId" )]
      [  XmlElement( ElementName = "ParticipanteTableroId"   )]
      public short gxTpr_Participantetableroid
      {
         get {
            return gxTv_SdtParticipantes_Participantetableroid ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            if ( gxTv_SdtParticipantes_Participantetableroid != value )
            {
               gxTv_SdtParticipantes_Mode = "INS";
               this.gxTv_SdtParticipantes_Tableroid_Z_SetNull( );
               this.gxTv_SdtParticipantes_Participantetableroid_Z_SetNull( );
               this.gxTv_SdtParticipantes_Registrofecha_Z_SetNull( );
               this.gxTv_SdtParticipantes_Participanterolid_Z_SetNull( );
               this.gxTv_SdtParticipantes_Participantetableroestado_Z_SetNull( );
            }
            gxTv_SdtParticipantes_Participantetableroid = value;
            SetDirty("Participantetableroid");
         }

      }

      [  SoapElement( ElementName = "RegistroFecha" )]
      [  XmlElement( ElementName = "RegistroFecha"  , IsNullable=true )]
      public string gxTpr_Registrofecha_Nullable
      {
         get {
            if ( gxTv_SdtParticipantes_Registrofecha == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtParticipantes_Registrofecha).value ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtParticipantes_Registrofecha = DateTime.MinValue;
            else
               gxTv_SdtParticipantes_Registrofecha = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Registrofecha
      {
         get {
            return gxTv_SdtParticipantes_Registrofecha ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Registrofecha = value;
            SetDirty("Registrofecha");
         }

      }

      [  SoapElement( ElementName = "ParticipanteRolId" )]
      [  XmlElement( ElementName = "ParticipanteRolId"   )]
      public short gxTpr_Participanterolid
      {
         get {
            return gxTv_SdtParticipantes_Participanterolid ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Participanterolid = value;
            SetDirty("Participanterolid");
         }

      }

      [  SoapElement( ElementName = "ParticipanteTableroEstado" )]
      [  XmlElement( ElementName = "ParticipanteTableroEstado"   )]
      public bool gxTpr_Participantetableroestado
      {
         get {
            return gxTv_SdtParticipantes_Participantetableroestado ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Participantetableroestado = value;
            SetDirty("Participantetableroestado");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtParticipantes_Mode ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtParticipantes_Mode_SetNull( )
      {
         gxTv_SdtParticipantes_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtParticipantes_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtParticipantes_Initialized ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtParticipantes_Initialized_SetNull( )
      {
         gxTv_SdtParticipantes_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtParticipantes_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TableroId_Z" )]
      [  XmlElement( ElementName = "TableroId_Z"   )]
      public short gxTpr_Tableroid_Z
      {
         get {
            return gxTv_SdtParticipantes_Tableroid_Z ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Tableroid_Z = value;
            SetDirty("Tableroid_Z");
         }

      }

      public void gxTv_SdtParticipantes_Tableroid_Z_SetNull( )
      {
         gxTv_SdtParticipantes_Tableroid_Z = 0;
         SetDirty("Tableroid_Z");
         return  ;
      }

      public bool gxTv_SdtParticipantes_Tableroid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteTableroId_Z" )]
      [  XmlElement( ElementName = "ParticipanteTableroId_Z"   )]
      public short gxTpr_Participantetableroid_Z
      {
         get {
            return gxTv_SdtParticipantes_Participantetableroid_Z ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Participantetableroid_Z = value;
            SetDirty("Participantetableroid_Z");
         }

      }

      public void gxTv_SdtParticipantes_Participantetableroid_Z_SetNull( )
      {
         gxTv_SdtParticipantes_Participantetableroid_Z = 0;
         SetDirty("Participantetableroid_Z");
         return  ;
      }

      public bool gxTv_SdtParticipantes_Participantetableroid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RegistroFecha_Z" )]
      [  XmlElement( ElementName = "RegistroFecha_Z"  , IsNullable=true )]
      public string gxTpr_Registrofecha_Z_Nullable
      {
         get {
            if ( gxTv_SdtParticipantes_Registrofecha_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtParticipantes_Registrofecha_Z).value ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtParticipantes_Registrofecha_Z = DateTime.MinValue;
            else
               gxTv_SdtParticipantes_Registrofecha_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Registrofecha_Z
      {
         get {
            return gxTv_SdtParticipantes_Registrofecha_Z ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Registrofecha_Z = value;
            SetDirty("Registrofecha_Z");
         }

      }

      public void gxTv_SdtParticipantes_Registrofecha_Z_SetNull( )
      {
         gxTv_SdtParticipantes_Registrofecha_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Registrofecha_Z");
         return  ;
      }

      public bool gxTv_SdtParticipantes_Registrofecha_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteRolId_Z" )]
      [  XmlElement( ElementName = "ParticipanteRolId_Z"   )]
      public short gxTpr_Participanterolid_Z
      {
         get {
            return gxTv_SdtParticipantes_Participanterolid_Z ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Participanterolid_Z = value;
            SetDirty("Participanterolid_Z");
         }

      }

      public void gxTv_SdtParticipantes_Participanterolid_Z_SetNull( )
      {
         gxTv_SdtParticipantes_Participanterolid_Z = 0;
         SetDirty("Participanterolid_Z");
         return  ;
      }

      public bool gxTv_SdtParticipantes_Participanterolid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteTableroEstado_Z" )]
      [  XmlElement( ElementName = "ParticipanteTableroEstado_Z"   )]
      public bool gxTpr_Participantetableroestado_Z
      {
         get {
            return gxTv_SdtParticipantes_Participantetableroestado_Z ;
         }

         set {
            gxTv_SdtParticipantes_N = 0;
            gxTv_SdtParticipantes_Participantetableroestado_Z = value;
            SetDirty("Participantetableroestado_Z");
         }

      }

      public void gxTv_SdtParticipantes_Participantetableroestado_Z_SetNull( )
      {
         gxTv_SdtParticipantes_Participantetableroestado_Z = false;
         SetDirty("Participantetableroestado_Z");
         return  ;
      }

      public bool gxTv_SdtParticipantes_Participantetableroestado_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtParticipantes_N = 1;
         gxTv_SdtParticipantes_Registrofecha = (DateTime)(DateTime.MinValue);
         gxTv_SdtParticipantes_Mode = "";
         gxTv_SdtParticipantes_Registrofecha_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "participantes", "GeneXus.Programs.participantes_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtParticipantes_N ;
      }

      private short gxTv_SdtParticipantes_Tableroid ;
      private short gxTv_SdtParticipantes_N ;
      private short gxTv_SdtParticipantes_Participantetableroid ;
      private short gxTv_SdtParticipantes_Participanterolid ;
      private short gxTv_SdtParticipantes_Initialized ;
      private short gxTv_SdtParticipantes_Tableroid_Z ;
      private short gxTv_SdtParticipantes_Participantetableroid_Z ;
      private short gxTv_SdtParticipantes_Participanterolid_Z ;
      private string gxTv_SdtParticipantes_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtParticipantes_Registrofecha ;
      private DateTime gxTv_SdtParticipantes_Registrofecha_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtParticipantes_Participantetableroestado ;
      private bool gxTv_SdtParticipantes_Participantetableroestado_Z ;
   }

   [DataContract(Name = @"Participantes", Namespace = "ProyectoUMG")]
   public class SdtParticipantes_RESTInterface : GxGenericCollectionItem<SdtParticipantes>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtParticipantes_RESTInterface( ) : base()
      {
      }

      public SdtParticipantes_RESTInterface( SdtParticipantes psdt ) : base(psdt)
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

      [DataMember( Name = "ParticipanteTableroId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Participantetableroid
      {
         get {
            return sdt.gxTpr_Participantetableroid ;
         }

         set {
            sdt.gxTpr_Participantetableroid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RegistroFecha" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Registrofecha
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Registrofecha) ;
         }

         set {
            sdt.gxTpr_Registrofecha = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "ParticipanteRolId" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Participanterolid
      {
         get {
            return sdt.gxTpr_Participanterolid ;
         }

         set {
            sdt.gxTpr_Participanterolid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ParticipanteTableroEstado" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Participantetableroestado
      {
         get {
            return sdt.gxTpr_Participantetableroestado ;
         }

         set {
            sdt.gxTpr_Participantetableroestado = value;
         }

      }

      public SdtParticipantes sdt
      {
         get {
            return (SdtParticipantes)Sdt ;
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
            sdt = new SdtParticipantes() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
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

   [DataContract(Name = @"Participantes", Namespace = "ProyectoUMG")]
   public class SdtParticipantes_RESTLInterface : GxGenericCollectionItem<SdtParticipantes>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtParticipantes_RESTLInterface( ) : base()
      {
      }

      public SdtParticipantes_RESTLInterface( SdtParticipantes psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RegistroFecha" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Registrofecha
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Registrofecha) ;
         }

         set {
            sdt.gxTpr_Registrofecha = DateTimeUtil.CToT2( value);
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

      public SdtParticipantes sdt
      {
         get {
            return (SdtParticipantes)Sdt ;
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
            sdt = new SdtParticipantes() ;
         }
      }

   }

}
