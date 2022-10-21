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
   [XmlRoot(ElementName = "Tareas" )]
   [XmlType(TypeName =  "Tareas" , Namespace = "ProyectoUMG" )]
   [Serializable]
   public class SdtTareas : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTareas( )
      {
      }

      public SdtTareas( IGxContext context )
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
                        short AV12TareaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV9TableroId,(short)AV12TareaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TableroId", typeof(short)}, new Object[]{"TareaId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Tareas");
         metadata.Set("BT", "Tareas");
         metadata.Set("PK", "[ \"TableroId\",\"TareaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"TableroId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"UsuarioId\" ],\"FKMap\":[ \"ResponsableId-UsuarioId\" ] } ]");
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
         state.Add("gxTpr_Tareanombre_Z");
         state.Add("gxTpr_Responsableid_Z");
         state.Add("gxTpr_Tareafechainicio_Z_Nullable");
         state.Add("gxTpr_Tareafechafin_Z_Nullable");
         state.Add("gxTpr_Tareaestado_Z");
         state.Add("gxTpr_Responsableid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTareas sdt;
         sdt = (SdtTareas)(source);
         gxTv_SdtTareas_Tableroid = sdt.gxTv_SdtTareas_Tableroid ;
         gxTv_SdtTareas_Tareaid = sdt.gxTv_SdtTareas_Tareaid ;
         gxTv_SdtTareas_Tareanombre = sdt.gxTv_SdtTareas_Tareanombre ;
         gxTv_SdtTareas_Responsableid = sdt.gxTv_SdtTareas_Responsableid ;
         gxTv_SdtTareas_Tareafechainicio = sdt.gxTv_SdtTareas_Tareafechainicio ;
         gxTv_SdtTareas_Tareafechafin = sdt.gxTv_SdtTareas_Tareafechafin ;
         gxTv_SdtTareas_Tareaetiquetas = sdt.gxTv_SdtTareas_Tareaetiquetas ;
         gxTv_SdtTareas_Tareaestado = sdt.gxTv_SdtTareas_Tareaestado ;
         gxTv_SdtTareas_Mode = sdt.gxTv_SdtTareas_Mode ;
         gxTv_SdtTareas_Initialized = sdt.gxTv_SdtTareas_Initialized ;
         gxTv_SdtTareas_Tableroid_Z = sdt.gxTv_SdtTareas_Tableroid_Z ;
         gxTv_SdtTareas_Tareaid_Z = sdt.gxTv_SdtTareas_Tareaid_Z ;
         gxTv_SdtTareas_Tareanombre_Z = sdt.gxTv_SdtTareas_Tareanombre_Z ;
         gxTv_SdtTareas_Responsableid_Z = sdt.gxTv_SdtTareas_Responsableid_Z ;
         gxTv_SdtTareas_Tareafechainicio_Z = sdt.gxTv_SdtTareas_Tareafechainicio_Z ;
         gxTv_SdtTareas_Tareafechafin_Z = sdt.gxTv_SdtTareas_Tareafechafin_Z ;
         gxTv_SdtTareas_Tareaestado_Z = sdt.gxTv_SdtTareas_Tareaestado_Z ;
         gxTv_SdtTareas_Responsableid_N = sdt.gxTv_SdtTareas_Responsableid_N ;
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
         AddObjectProperty("TableroId", gxTv_SdtTareas_Tableroid, false, includeNonInitialized);
         AddObjectProperty("TareaId", gxTv_SdtTareas_Tareaid, false, includeNonInitialized);
         AddObjectProperty("TareaNombre", gxTv_SdtTareas_Tareanombre, false, includeNonInitialized);
         AddObjectProperty("ResponsableId", gxTv_SdtTareas_Responsableid, false, includeNonInitialized);
         AddObjectProperty("ResponsableId_N", gxTv_SdtTareas_Responsableid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTareas_Tareafechainicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTareas_Tareafechainicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTareas_Tareafechainicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TareaFechaInicio", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTareas_Tareafechafin)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTareas_Tareafechafin)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTareas_Tareafechafin)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TareaFechaFin", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TareaEtiquetas", gxTv_SdtTareas_Tareaetiquetas, false, includeNonInitialized);
         AddObjectProperty("TareaEstado", gxTv_SdtTareas_Tareaestado, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTareas_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTareas_Initialized, false, includeNonInitialized);
            AddObjectProperty("TableroId_Z", gxTv_SdtTareas_Tableroid_Z, false, includeNonInitialized);
            AddObjectProperty("TareaId_Z", gxTv_SdtTareas_Tareaid_Z, false, includeNonInitialized);
            AddObjectProperty("TareaNombre_Z", gxTv_SdtTareas_Tareanombre_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsableId_Z", gxTv_SdtTareas_Responsableid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTareas_Tareafechainicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTareas_Tareafechainicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTareas_Tareafechainicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TareaFechaInicio_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTareas_Tareafechafin_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTareas_Tareafechafin_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTareas_Tareafechafin_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TareaFechaFin_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TareaEstado_Z", gxTv_SdtTareas_Tareaestado_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsableId_N", gxTv_SdtTareas_Responsableid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTareas sdt )
      {
         if ( sdt.IsDirty("TableroId") )
         {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tableroid = sdt.gxTv_SdtTareas_Tableroid ;
         }
         if ( sdt.IsDirty("TareaId") )
         {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareaid = sdt.gxTv_SdtTareas_Tareaid ;
         }
         if ( sdt.IsDirty("TareaNombre") )
         {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareanombre = sdt.gxTv_SdtTareas_Tareanombre ;
         }
         if ( sdt.IsDirty("ResponsableId") )
         {
            gxTv_SdtTareas_Responsableid_N = (short)(sdt.gxTv_SdtTareas_Responsableid_N);
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Responsableid = sdt.gxTv_SdtTareas_Responsableid ;
         }
         if ( sdt.IsDirty("TareaFechaInicio") )
         {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareafechainicio = sdt.gxTv_SdtTareas_Tareafechainicio ;
         }
         if ( sdt.IsDirty("TareaFechaFin") )
         {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareafechafin = sdt.gxTv_SdtTareas_Tareafechafin ;
         }
         if ( sdt.IsDirty("TareaEtiquetas") )
         {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareaetiquetas = sdt.gxTv_SdtTareas_Tareaetiquetas ;
         }
         if ( sdt.IsDirty("TareaEstado") )
         {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareaestado = sdt.gxTv_SdtTareas_Tareaestado ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TableroId" )]
      [  XmlElement( ElementName = "TableroId"   )]
      public short gxTpr_Tableroid
      {
         get {
            return gxTv_SdtTareas_Tableroid ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            if ( gxTv_SdtTareas_Tableroid != value )
            {
               gxTv_SdtTareas_Mode = "INS";
               this.gxTv_SdtTareas_Tableroid_Z_SetNull( );
               this.gxTv_SdtTareas_Tareaid_Z_SetNull( );
               this.gxTv_SdtTareas_Tareanombre_Z_SetNull( );
               this.gxTv_SdtTareas_Responsableid_Z_SetNull( );
               this.gxTv_SdtTareas_Tareafechainicio_Z_SetNull( );
               this.gxTv_SdtTareas_Tareafechafin_Z_SetNull( );
               this.gxTv_SdtTareas_Tareaestado_Z_SetNull( );
            }
            gxTv_SdtTareas_Tableroid = value;
            SetDirty("Tableroid");
         }

      }

      [  SoapElement( ElementName = "TareaId" )]
      [  XmlElement( ElementName = "TareaId"   )]
      public short gxTpr_Tareaid
      {
         get {
            return gxTv_SdtTareas_Tareaid ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            if ( gxTv_SdtTareas_Tareaid != value )
            {
               gxTv_SdtTareas_Mode = "INS";
               this.gxTv_SdtTareas_Tableroid_Z_SetNull( );
               this.gxTv_SdtTareas_Tareaid_Z_SetNull( );
               this.gxTv_SdtTareas_Tareanombre_Z_SetNull( );
               this.gxTv_SdtTareas_Responsableid_Z_SetNull( );
               this.gxTv_SdtTareas_Tareafechainicio_Z_SetNull( );
               this.gxTv_SdtTareas_Tareafechafin_Z_SetNull( );
               this.gxTv_SdtTareas_Tareaestado_Z_SetNull( );
            }
            gxTv_SdtTareas_Tareaid = value;
            SetDirty("Tareaid");
         }

      }

      [  SoapElement( ElementName = "TareaNombre" )]
      [  XmlElement( ElementName = "TareaNombre"   )]
      public string gxTpr_Tareanombre
      {
         get {
            return gxTv_SdtTareas_Tareanombre ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareanombre = value;
            SetDirty("Tareanombre");
         }

      }

      [  SoapElement( ElementName = "ResponsableId" )]
      [  XmlElement( ElementName = "ResponsableId"   )]
      public short gxTpr_Responsableid
      {
         get {
            return gxTv_SdtTareas_Responsableid ;
         }

         set {
            gxTv_SdtTareas_Responsableid_N = 0;
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Responsableid = value;
            SetDirty("Responsableid");
         }

      }

      public void gxTv_SdtTareas_Responsableid_SetNull( )
      {
         gxTv_SdtTareas_Responsableid_N = 1;
         gxTv_SdtTareas_Responsableid = 0;
         SetDirty("Responsableid");
         return  ;
      }

      public bool gxTv_SdtTareas_Responsableid_IsNull( )
      {
         return (gxTv_SdtTareas_Responsableid_N==1) ;
      }

      [  SoapElement( ElementName = "TareaFechaInicio" )]
      [  XmlElement( ElementName = "TareaFechaInicio"  , IsNullable=true )]
      public string gxTpr_Tareafechainicio_Nullable
      {
         get {
            if ( gxTv_SdtTareas_Tareafechainicio == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTareas_Tareafechainicio).value ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTareas_Tareafechainicio = DateTime.MinValue;
            else
               gxTv_SdtTareas_Tareafechainicio = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Tareafechainicio
      {
         get {
            return gxTv_SdtTareas_Tareafechainicio ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareafechainicio = value;
            SetDirty("Tareafechainicio");
         }

      }

      [  SoapElement( ElementName = "TareaFechaFin" )]
      [  XmlElement( ElementName = "TareaFechaFin"  , IsNullable=true )]
      public string gxTpr_Tareafechafin_Nullable
      {
         get {
            if ( gxTv_SdtTareas_Tareafechafin == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTareas_Tareafechafin).value ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTareas_Tareafechafin = DateTime.MinValue;
            else
               gxTv_SdtTareas_Tareafechafin = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Tareafechafin
      {
         get {
            return gxTv_SdtTareas_Tareafechafin ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareafechafin = value;
            SetDirty("Tareafechafin");
         }

      }

      [  SoapElement( ElementName = "TareaEtiquetas" )]
      [  XmlElement( ElementName = "TareaEtiquetas"   )]
      public string gxTpr_Tareaetiquetas
      {
         get {
            return gxTv_SdtTareas_Tareaetiquetas ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareaetiquetas = value;
            SetDirty("Tareaetiquetas");
         }

      }

      [  SoapElement( ElementName = "TareaEstado" )]
      [  XmlElement( ElementName = "TareaEstado"   )]
      public short gxTpr_Tareaestado
      {
         get {
            return gxTv_SdtTareas_Tareaestado ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareaestado = value;
            SetDirty("Tareaestado");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTareas_Mode ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTareas_Mode_SetNull( )
      {
         gxTv_SdtTareas_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTareas_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTareas_Initialized ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTareas_Initialized_SetNull( )
      {
         gxTv_SdtTareas_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTareas_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TableroId_Z" )]
      [  XmlElement( ElementName = "TableroId_Z"   )]
      public short gxTpr_Tableroid_Z
      {
         get {
            return gxTv_SdtTareas_Tableroid_Z ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tableroid_Z = value;
            SetDirty("Tableroid_Z");
         }

      }

      public void gxTv_SdtTareas_Tableroid_Z_SetNull( )
      {
         gxTv_SdtTareas_Tableroid_Z = 0;
         SetDirty("Tableroid_Z");
         return  ;
      }

      public bool gxTv_SdtTareas_Tableroid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TareaId_Z" )]
      [  XmlElement( ElementName = "TareaId_Z"   )]
      public short gxTpr_Tareaid_Z
      {
         get {
            return gxTv_SdtTareas_Tareaid_Z ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareaid_Z = value;
            SetDirty("Tareaid_Z");
         }

      }

      public void gxTv_SdtTareas_Tareaid_Z_SetNull( )
      {
         gxTv_SdtTareas_Tareaid_Z = 0;
         SetDirty("Tareaid_Z");
         return  ;
      }

      public bool gxTv_SdtTareas_Tareaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TareaNombre_Z" )]
      [  XmlElement( ElementName = "TareaNombre_Z"   )]
      public string gxTpr_Tareanombre_Z
      {
         get {
            return gxTv_SdtTareas_Tareanombre_Z ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareanombre_Z = value;
            SetDirty("Tareanombre_Z");
         }

      }

      public void gxTv_SdtTareas_Tareanombre_Z_SetNull( )
      {
         gxTv_SdtTareas_Tareanombre_Z = "";
         SetDirty("Tareanombre_Z");
         return  ;
      }

      public bool gxTv_SdtTareas_Tareanombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsableId_Z" )]
      [  XmlElement( ElementName = "ResponsableId_Z"   )]
      public short gxTpr_Responsableid_Z
      {
         get {
            return gxTv_SdtTareas_Responsableid_Z ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Responsableid_Z = value;
            SetDirty("Responsableid_Z");
         }

      }

      public void gxTv_SdtTareas_Responsableid_Z_SetNull( )
      {
         gxTv_SdtTareas_Responsableid_Z = 0;
         SetDirty("Responsableid_Z");
         return  ;
      }

      public bool gxTv_SdtTareas_Responsableid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TareaFechaInicio_Z" )]
      [  XmlElement( ElementName = "TareaFechaInicio_Z"  , IsNullable=true )]
      public string gxTpr_Tareafechainicio_Z_Nullable
      {
         get {
            if ( gxTv_SdtTareas_Tareafechainicio_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTareas_Tareafechainicio_Z).value ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTareas_Tareafechainicio_Z = DateTime.MinValue;
            else
               gxTv_SdtTareas_Tareafechainicio_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Tareafechainicio_Z
      {
         get {
            return gxTv_SdtTareas_Tareafechainicio_Z ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareafechainicio_Z = value;
            SetDirty("Tareafechainicio_Z");
         }

      }

      public void gxTv_SdtTareas_Tareafechainicio_Z_SetNull( )
      {
         gxTv_SdtTareas_Tareafechainicio_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tareafechainicio_Z");
         return  ;
      }

      public bool gxTv_SdtTareas_Tareafechainicio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TareaFechaFin_Z" )]
      [  XmlElement( ElementName = "TareaFechaFin_Z"  , IsNullable=true )]
      public string gxTpr_Tareafechafin_Z_Nullable
      {
         get {
            if ( gxTv_SdtTareas_Tareafechafin_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTareas_Tareafechafin_Z).value ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTareas_Tareafechafin_Z = DateTime.MinValue;
            else
               gxTv_SdtTareas_Tareafechafin_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Tareafechafin_Z
      {
         get {
            return gxTv_SdtTareas_Tareafechafin_Z ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareafechafin_Z = value;
            SetDirty("Tareafechafin_Z");
         }

      }

      public void gxTv_SdtTareas_Tareafechafin_Z_SetNull( )
      {
         gxTv_SdtTareas_Tareafechafin_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tareafechafin_Z");
         return  ;
      }

      public bool gxTv_SdtTareas_Tareafechafin_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TareaEstado_Z" )]
      [  XmlElement( ElementName = "TareaEstado_Z"   )]
      public short gxTpr_Tareaestado_Z
      {
         get {
            return gxTv_SdtTareas_Tareaestado_Z ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Tareaestado_Z = value;
            SetDirty("Tareaestado_Z");
         }

      }

      public void gxTv_SdtTareas_Tareaestado_Z_SetNull( )
      {
         gxTv_SdtTareas_Tareaestado_Z = 0;
         SetDirty("Tareaestado_Z");
         return  ;
      }

      public bool gxTv_SdtTareas_Tareaestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsableId_N" )]
      [  XmlElement( ElementName = "ResponsableId_N"   )]
      public short gxTpr_Responsableid_N
      {
         get {
            return gxTv_SdtTareas_Responsableid_N ;
         }

         set {
            gxTv_SdtTareas_N = 0;
            gxTv_SdtTareas_Responsableid_N = value;
            SetDirty("Responsableid_N");
         }

      }

      public void gxTv_SdtTareas_Responsableid_N_SetNull( )
      {
         gxTv_SdtTareas_Responsableid_N = 0;
         SetDirty("Responsableid_N");
         return  ;
      }

      public bool gxTv_SdtTareas_Responsableid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTareas_N = 1;
         gxTv_SdtTareas_Tareanombre = "";
         gxTv_SdtTareas_Tareafechainicio = DateTime.MinValue;
         gxTv_SdtTareas_Tareafechafin = DateTime.MinValue;
         gxTv_SdtTareas_Tareaetiquetas = "";
         gxTv_SdtTareas_Mode = "";
         gxTv_SdtTareas_Tareanombre_Z = "";
         gxTv_SdtTareas_Tareafechainicio_Z = DateTime.MinValue;
         gxTv_SdtTareas_Tareafechafin_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tareas", "GeneXus.Programs.tareas_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtTareas_N ;
      }

      private short gxTv_SdtTareas_Tableroid ;
      private short gxTv_SdtTareas_N ;
      private short gxTv_SdtTareas_Tareaid ;
      private short gxTv_SdtTareas_Responsableid ;
      private short gxTv_SdtTareas_Tareaestado ;
      private short gxTv_SdtTareas_Initialized ;
      private short gxTv_SdtTareas_Tableroid_Z ;
      private short gxTv_SdtTareas_Tareaid_Z ;
      private short gxTv_SdtTareas_Responsableid_Z ;
      private short gxTv_SdtTareas_Tareaestado_Z ;
      private short gxTv_SdtTareas_Responsableid_N ;
      private string gxTv_SdtTareas_Tareanombre ;
      private string gxTv_SdtTareas_Mode ;
      private string gxTv_SdtTareas_Tareanombre_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTareas_Tareafechainicio ;
      private DateTime gxTv_SdtTareas_Tareafechafin ;
      private DateTime gxTv_SdtTareas_Tareafechainicio_Z ;
      private DateTime gxTv_SdtTareas_Tareafechafin_Z ;
      private string gxTv_SdtTareas_Tareaetiquetas ;
   }

   [DataContract(Name = @"Tareas", Namespace = "ProyectoUMG")]
   public class SdtTareas_RESTInterface : GxGenericCollectionItem<SdtTareas>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTareas_RESTInterface( ) : base()
      {
      }

      public SdtTareas_RESTInterface( SdtTareas psdt ) : base(psdt)
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

      [DataMember( Name = "TareaNombre" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Tareanombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tareanombre) ;
         }

         set {
            sdt.gxTpr_Tareanombre = value;
         }

      }

      [DataMember( Name = "ResponsableId" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Responsableid
      {
         get {
            return sdt.gxTpr_Responsableid ;
         }

         set {
            sdt.gxTpr_Responsableid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TareaFechaInicio" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Tareafechainicio
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Tareafechainicio) ;
         }

         set {
            sdt.gxTpr_Tareafechainicio = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "TareaFechaFin" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Tareafechafin
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Tareafechafin) ;
         }

         set {
            sdt.gxTpr_Tareafechafin = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "TareaEtiquetas" , Order = 6 )]
      public string gxTpr_Tareaetiquetas
      {
         get {
            return sdt.gxTpr_Tareaetiquetas ;
         }

         set {
            sdt.gxTpr_Tareaetiquetas = value;
         }

      }

      [DataMember( Name = "TareaEstado" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Tareaestado
      {
         get {
            return sdt.gxTpr_Tareaestado ;
         }

         set {
            sdt.gxTpr_Tareaestado = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtTareas sdt
      {
         get {
            return (SdtTareas)Sdt ;
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
            sdt = new SdtTareas() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 8 )]
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

   [DataContract(Name = @"Tareas", Namespace = "ProyectoUMG")]
   public class SdtTareas_RESTLInterface : GxGenericCollectionItem<SdtTareas>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTareas_RESTLInterface( ) : base()
      {
      }

      public SdtTareas_RESTLInterface( SdtTareas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TareaNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tareanombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tareanombre) ;
         }

         set {
            sdt.gxTpr_Tareanombre = value;
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

      public SdtTareas sdt
      {
         get {
            return (SdtTareas)Sdt ;
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
            sdt = new SdtTareas() ;
         }
      }

   }

}
