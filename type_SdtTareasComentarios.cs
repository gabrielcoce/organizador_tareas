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
   [XmlRoot(ElementName = "TareasComentarios" )]
   [XmlType(TypeName =  "TareasComentarios" , Namespace = "ProyectoUMG" )]
   [Serializable]
   public class SdtTareasComentarios : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTareasComentarios( )
      {
      }

      public SdtTareasComentarios( IGxContext context )
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
                        short AV27ComentarioId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV9TableroId,(short)AV12TareaId,(short)AV27ComentarioId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TableroId", typeof(short)}, new Object[]{"TareaId", typeof(short)}, new Object[]{"ComentarioId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "TareasComentarios");
         metadata.Set("BT", "TareasComentarios");
         metadata.Set("PK", "[ \"TableroId\",\"TareaId\",\"ComentarioId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"TableroId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TableroId\",\"TareaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"UsuarioId\" ],\"FKMap\":[ \"ComentaristaId-UsuarioId\" ] } ]");
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
         state.Add("gxTpr_Comentarioid_Z");
         state.Add("gxTpr_Comentariotexto_Z");
         state.Add("gxTpr_Comentariofecha_Z_Nullable");
         state.Add("gxTpr_Comentaristaid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTareasComentarios sdt;
         sdt = (SdtTareasComentarios)(source);
         gxTv_SdtTareasComentarios_Tableroid = sdt.gxTv_SdtTareasComentarios_Tableroid ;
         gxTv_SdtTareasComentarios_Tareaid = sdt.gxTv_SdtTareasComentarios_Tareaid ;
         gxTv_SdtTareasComentarios_Comentarioid = sdt.gxTv_SdtTareasComentarios_Comentarioid ;
         gxTv_SdtTareasComentarios_Comentariotexto = sdt.gxTv_SdtTareasComentarios_Comentariotexto ;
         gxTv_SdtTareasComentarios_Comentariofecha = sdt.gxTv_SdtTareasComentarios_Comentariofecha ;
         gxTv_SdtTareasComentarios_Comentaristaid = sdt.gxTv_SdtTareasComentarios_Comentaristaid ;
         gxTv_SdtTareasComentarios_Mode = sdt.gxTv_SdtTareasComentarios_Mode ;
         gxTv_SdtTareasComentarios_Initialized = sdt.gxTv_SdtTareasComentarios_Initialized ;
         gxTv_SdtTareasComentarios_Tableroid_Z = sdt.gxTv_SdtTareasComentarios_Tableroid_Z ;
         gxTv_SdtTareasComentarios_Tareaid_Z = sdt.gxTv_SdtTareasComentarios_Tareaid_Z ;
         gxTv_SdtTareasComentarios_Comentarioid_Z = sdt.gxTv_SdtTareasComentarios_Comentarioid_Z ;
         gxTv_SdtTareasComentarios_Comentariotexto_Z = sdt.gxTv_SdtTareasComentarios_Comentariotexto_Z ;
         gxTv_SdtTareasComentarios_Comentariofecha_Z = sdt.gxTv_SdtTareasComentarios_Comentariofecha_Z ;
         gxTv_SdtTareasComentarios_Comentaristaid_Z = sdt.gxTv_SdtTareasComentarios_Comentaristaid_Z ;
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
         AddObjectProperty("TableroId", gxTv_SdtTareasComentarios_Tableroid, false, includeNonInitialized);
         AddObjectProperty("TareaId", gxTv_SdtTareasComentarios_Tareaid, false, includeNonInitialized);
         AddObjectProperty("ComentarioId", gxTv_SdtTareasComentarios_Comentarioid, false, includeNonInitialized);
         AddObjectProperty("ComentarioTexto", gxTv_SdtTareasComentarios_Comentariotexto, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTareasComentarios_Comentariofecha;
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
         AddObjectProperty("ComentarioFecha", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ComentaristaId", gxTv_SdtTareasComentarios_Comentaristaid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTareasComentarios_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTareasComentarios_Initialized, false, includeNonInitialized);
            AddObjectProperty("TableroId_Z", gxTv_SdtTareasComentarios_Tableroid_Z, false, includeNonInitialized);
            AddObjectProperty("TareaId_Z", gxTv_SdtTareasComentarios_Tareaid_Z, false, includeNonInitialized);
            AddObjectProperty("ComentarioId_Z", gxTv_SdtTareasComentarios_Comentarioid_Z, false, includeNonInitialized);
            AddObjectProperty("ComentarioTexto_Z", gxTv_SdtTareasComentarios_Comentariotexto_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTareasComentarios_Comentariofecha_Z;
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
            AddObjectProperty("ComentarioFecha_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ComentaristaId_Z", gxTv_SdtTareasComentarios_Comentaristaid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTareasComentarios sdt )
      {
         if ( sdt.IsDirty("TableroId") )
         {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Tableroid = sdt.gxTv_SdtTareasComentarios_Tableroid ;
         }
         if ( sdt.IsDirty("TareaId") )
         {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Tareaid = sdt.gxTv_SdtTareasComentarios_Tareaid ;
         }
         if ( sdt.IsDirty("ComentarioId") )
         {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Comentarioid = sdt.gxTv_SdtTareasComentarios_Comentarioid ;
         }
         if ( sdt.IsDirty("ComentarioTexto") )
         {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Comentariotexto = sdt.gxTv_SdtTareasComentarios_Comentariotexto ;
         }
         if ( sdt.IsDirty("ComentarioFecha") )
         {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Comentariofecha = sdt.gxTv_SdtTareasComentarios_Comentariofecha ;
         }
         if ( sdt.IsDirty("ComentaristaId") )
         {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Comentaristaid = sdt.gxTv_SdtTareasComentarios_Comentaristaid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TableroId" )]
      [  XmlElement( ElementName = "TableroId"   )]
      public short gxTpr_Tableroid
      {
         get {
            return gxTv_SdtTareasComentarios_Tableroid ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            if ( gxTv_SdtTareasComentarios_Tableroid != value )
            {
               gxTv_SdtTareasComentarios_Mode = "INS";
               this.gxTv_SdtTareasComentarios_Tableroid_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Tareaid_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Comentarioid_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Comentariotexto_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Comentariofecha_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Comentaristaid_Z_SetNull( );
            }
            gxTv_SdtTareasComentarios_Tableroid = value;
            SetDirty("Tableroid");
         }

      }

      [  SoapElement( ElementName = "TareaId" )]
      [  XmlElement( ElementName = "TareaId"   )]
      public short gxTpr_Tareaid
      {
         get {
            return gxTv_SdtTareasComentarios_Tareaid ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            if ( gxTv_SdtTareasComentarios_Tareaid != value )
            {
               gxTv_SdtTareasComentarios_Mode = "INS";
               this.gxTv_SdtTareasComentarios_Tableroid_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Tareaid_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Comentarioid_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Comentariotexto_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Comentariofecha_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Comentaristaid_Z_SetNull( );
            }
            gxTv_SdtTareasComentarios_Tareaid = value;
            SetDirty("Tareaid");
         }

      }

      [  SoapElement( ElementName = "ComentarioId" )]
      [  XmlElement( ElementName = "ComentarioId"   )]
      public short gxTpr_Comentarioid
      {
         get {
            return gxTv_SdtTareasComentarios_Comentarioid ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            if ( gxTv_SdtTareasComentarios_Comentarioid != value )
            {
               gxTv_SdtTareasComentarios_Mode = "INS";
               this.gxTv_SdtTareasComentarios_Tableroid_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Tareaid_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Comentarioid_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Comentariotexto_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Comentariofecha_Z_SetNull( );
               this.gxTv_SdtTareasComentarios_Comentaristaid_Z_SetNull( );
            }
            gxTv_SdtTareasComentarios_Comentarioid = value;
            SetDirty("Comentarioid");
         }

      }

      [  SoapElement( ElementName = "ComentarioTexto" )]
      [  XmlElement( ElementName = "ComentarioTexto"   )]
      public string gxTpr_Comentariotexto
      {
         get {
            return gxTv_SdtTareasComentarios_Comentariotexto ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Comentariotexto = value;
            SetDirty("Comentariotexto");
         }

      }

      [  SoapElement( ElementName = "ComentarioFecha" )]
      [  XmlElement( ElementName = "ComentarioFecha"  , IsNullable=true )]
      public string gxTpr_Comentariofecha_Nullable
      {
         get {
            if ( gxTv_SdtTareasComentarios_Comentariofecha == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTareasComentarios_Comentariofecha).value ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTareasComentarios_Comentariofecha = DateTime.MinValue;
            else
               gxTv_SdtTareasComentarios_Comentariofecha = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Comentariofecha
      {
         get {
            return gxTv_SdtTareasComentarios_Comentariofecha ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Comentariofecha = value;
            SetDirty("Comentariofecha");
         }

      }

      [  SoapElement( ElementName = "ComentaristaId" )]
      [  XmlElement( ElementName = "ComentaristaId"   )]
      public short gxTpr_Comentaristaid
      {
         get {
            return gxTv_SdtTareasComentarios_Comentaristaid ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Comentaristaid = value;
            SetDirty("Comentaristaid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTareasComentarios_Mode ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTareasComentarios_Mode_SetNull( )
      {
         gxTv_SdtTareasComentarios_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTareasComentarios_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTareasComentarios_Initialized ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTareasComentarios_Initialized_SetNull( )
      {
         gxTv_SdtTareasComentarios_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTareasComentarios_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TableroId_Z" )]
      [  XmlElement( ElementName = "TableroId_Z"   )]
      public short gxTpr_Tableroid_Z
      {
         get {
            return gxTv_SdtTareasComentarios_Tableroid_Z ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Tableroid_Z = value;
            SetDirty("Tableroid_Z");
         }

      }

      public void gxTv_SdtTareasComentarios_Tableroid_Z_SetNull( )
      {
         gxTv_SdtTareasComentarios_Tableroid_Z = 0;
         SetDirty("Tableroid_Z");
         return  ;
      }

      public bool gxTv_SdtTareasComentarios_Tableroid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TareaId_Z" )]
      [  XmlElement( ElementName = "TareaId_Z"   )]
      public short gxTpr_Tareaid_Z
      {
         get {
            return gxTv_SdtTareasComentarios_Tareaid_Z ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Tareaid_Z = value;
            SetDirty("Tareaid_Z");
         }

      }

      public void gxTv_SdtTareasComentarios_Tareaid_Z_SetNull( )
      {
         gxTv_SdtTareasComentarios_Tareaid_Z = 0;
         SetDirty("Tareaid_Z");
         return  ;
      }

      public bool gxTv_SdtTareasComentarios_Tareaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComentarioId_Z" )]
      [  XmlElement( ElementName = "ComentarioId_Z"   )]
      public short gxTpr_Comentarioid_Z
      {
         get {
            return gxTv_SdtTareasComentarios_Comentarioid_Z ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Comentarioid_Z = value;
            SetDirty("Comentarioid_Z");
         }

      }

      public void gxTv_SdtTareasComentarios_Comentarioid_Z_SetNull( )
      {
         gxTv_SdtTareasComentarios_Comentarioid_Z = 0;
         SetDirty("Comentarioid_Z");
         return  ;
      }

      public bool gxTv_SdtTareasComentarios_Comentarioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComentarioTexto_Z" )]
      [  XmlElement( ElementName = "ComentarioTexto_Z"   )]
      public string gxTpr_Comentariotexto_Z
      {
         get {
            return gxTv_SdtTareasComentarios_Comentariotexto_Z ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Comentariotexto_Z = value;
            SetDirty("Comentariotexto_Z");
         }

      }

      public void gxTv_SdtTareasComentarios_Comentariotexto_Z_SetNull( )
      {
         gxTv_SdtTareasComentarios_Comentariotexto_Z = "";
         SetDirty("Comentariotexto_Z");
         return  ;
      }

      public bool gxTv_SdtTareasComentarios_Comentariotexto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComentarioFecha_Z" )]
      [  XmlElement( ElementName = "ComentarioFecha_Z"  , IsNullable=true )]
      public string gxTpr_Comentariofecha_Z_Nullable
      {
         get {
            if ( gxTv_SdtTareasComentarios_Comentariofecha_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTareasComentarios_Comentariofecha_Z).value ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTareasComentarios_Comentariofecha_Z = DateTime.MinValue;
            else
               gxTv_SdtTareasComentarios_Comentariofecha_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Comentariofecha_Z
      {
         get {
            return gxTv_SdtTareasComentarios_Comentariofecha_Z ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Comentariofecha_Z = value;
            SetDirty("Comentariofecha_Z");
         }

      }

      public void gxTv_SdtTareasComentarios_Comentariofecha_Z_SetNull( )
      {
         gxTv_SdtTareasComentarios_Comentariofecha_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Comentariofecha_Z");
         return  ;
      }

      public bool gxTv_SdtTareasComentarios_Comentariofecha_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComentaristaId_Z" )]
      [  XmlElement( ElementName = "ComentaristaId_Z"   )]
      public short gxTpr_Comentaristaid_Z
      {
         get {
            return gxTv_SdtTareasComentarios_Comentaristaid_Z ;
         }

         set {
            gxTv_SdtTareasComentarios_N = 0;
            gxTv_SdtTareasComentarios_Comentaristaid_Z = value;
            SetDirty("Comentaristaid_Z");
         }

      }

      public void gxTv_SdtTareasComentarios_Comentaristaid_Z_SetNull( )
      {
         gxTv_SdtTareasComentarios_Comentaristaid_Z = 0;
         SetDirty("Comentaristaid_Z");
         return  ;
      }

      public bool gxTv_SdtTareasComentarios_Comentaristaid_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTareasComentarios_N = 1;
         gxTv_SdtTareasComentarios_Comentariotexto = "";
         gxTv_SdtTareasComentarios_Comentariofecha = (DateTime)(DateTime.MinValue);
         gxTv_SdtTareasComentarios_Mode = "";
         gxTv_SdtTareasComentarios_Comentariotexto_Z = "";
         gxTv_SdtTareasComentarios_Comentariofecha_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tareascomentarios", "GeneXus.Programs.tareascomentarios_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtTareasComentarios_N ;
      }

      private short gxTv_SdtTareasComentarios_Tableroid ;
      private short gxTv_SdtTareasComentarios_N ;
      private short gxTv_SdtTareasComentarios_Tareaid ;
      private short gxTv_SdtTareasComentarios_Comentarioid ;
      private short gxTv_SdtTareasComentarios_Comentaristaid ;
      private short gxTv_SdtTareasComentarios_Initialized ;
      private short gxTv_SdtTareasComentarios_Tableroid_Z ;
      private short gxTv_SdtTareasComentarios_Tareaid_Z ;
      private short gxTv_SdtTareasComentarios_Comentarioid_Z ;
      private short gxTv_SdtTareasComentarios_Comentaristaid_Z ;
      private string gxTv_SdtTareasComentarios_Comentariotexto ;
      private string gxTv_SdtTareasComentarios_Mode ;
      private string gxTv_SdtTareasComentarios_Comentariotexto_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTareasComentarios_Comentariofecha ;
      private DateTime gxTv_SdtTareasComentarios_Comentariofecha_Z ;
      private DateTime datetime_STZ ;
   }

   [DataContract(Name = @"TareasComentarios", Namespace = "ProyectoUMG")]
   public class SdtTareasComentarios_RESTInterface : GxGenericCollectionItem<SdtTareasComentarios>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTareasComentarios_RESTInterface( ) : base()
      {
      }

      public SdtTareasComentarios_RESTInterface( SdtTareasComentarios psdt ) : base(psdt)
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

      [DataMember( Name = "ComentarioId" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Comentarioid
      {
         get {
            return sdt.gxTpr_Comentarioid ;
         }

         set {
            sdt.gxTpr_Comentarioid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ComentarioTexto" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Comentariotexto
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Comentariotexto) ;
         }

         set {
            sdt.gxTpr_Comentariotexto = value;
         }

      }

      [DataMember( Name = "ComentarioFecha" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Comentariofecha
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Comentariofecha) ;
         }

         set {
            sdt.gxTpr_Comentariofecha = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "ComentaristaId" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Comentaristaid
      {
         get {
            return sdt.gxTpr_Comentaristaid ;
         }

         set {
            sdt.gxTpr_Comentaristaid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtTareasComentarios sdt
      {
         get {
            return (SdtTareasComentarios)Sdt ;
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
            sdt = new SdtTareasComentarios() ;
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

   [DataContract(Name = @"TareasComentarios", Namespace = "ProyectoUMG")]
   public class SdtTareasComentarios_RESTLInterface : GxGenericCollectionItem<SdtTareasComentarios>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTareasComentarios_RESTLInterface( ) : base()
      {
      }

      public SdtTareasComentarios_RESTLInterface( SdtTareasComentarios psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ComentarioTexto" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Comentariotexto
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Comentariotexto) ;
         }

         set {
            sdt.gxTpr_Comentariotexto = value;
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

      public SdtTareasComentarios sdt
      {
         get {
            return (SdtTareasComentarios)Sdt ;
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
            sdt = new SdtTareasComentarios() ;
         }
      }

   }

}
