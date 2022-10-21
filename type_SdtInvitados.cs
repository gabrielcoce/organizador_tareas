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
   [XmlRoot(ElementName = "Invitados" )]
   [XmlType(TypeName =  "Invitados" , Namespace = "ProyectoUMG" )]
   [Serializable]
   public class SdtInvitados : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtInvitados( )
      {
      }

      public SdtInvitados( IGxContext context )
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
                        short AV40RegistroInvitadoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV9TableroId,(short)AV40RegistroInvitadoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TableroId", typeof(short)}, new Object[]{"RegistroInvitadoId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Invitados");
         metadata.Set("BT", "Invitados");
         metadata.Set("PK", "[ \"TableroId\",\"RegistroInvitadoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"RolId\" ],\"FKMap\":[ \"InvitadoRolId-RolId\" ] },{ \"FK\":[ \"TableroId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Registroinvitadoid_Z");
         state.Add("gxTpr_Registroinvitadousuario_Z");
         state.Add("gxTpr_Registroinvitadoemail_Z");
         state.Add("gxTpr_Invitadorolid_Z");
         state.Add("gxTpr_Registroinvitadofecha_Z_Nullable");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtInvitados sdt;
         sdt = (SdtInvitados)(source);
         gxTv_SdtInvitados_Tableroid = sdt.gxTv_SdtInvitados_Tableroid ;
         gxTv_SdtInvitados_Registroinvitadoid = sdt.gxTv_SdtInvitados_Registroinvitadoid ;
         gxTv_SdtInvitados_Registroinvitadousuario = sdt.gxTv_SdtInvitados_Registroinvitadousuario ;
         gxTv_SdtInvitados_Registroinvitadoemail = sdt.gxTv_SdtInvitados_Registroinvitadoemail ;
         gxTv_SdtInvitados_Invitadorolid = sdt.gxTv_SdtInvitados_Invitadorolid ;
         gxTv_SdtInvitados_Registroinvitadofecha = sdt.gxTv_SdtInvitados_Registroinvitadofecha ;
         gxTv_SdtInvitados_Mode = sdt.gxTv_SdtInvitados_Mode ;
         gxTv_SdtInvitados_Initialized = sdt.gxTv_SdtInvitados_Initialized ;
         gxTv_SdtInvitados_Tableroid_Z = sdt.gxTv_SdtInvitados_Tableroid_Z ;
         gxTv_SdtInvitados_Registroinvitadoid_Z = sdt.gxTv_SdtInvitados_Registroinvitadoid_Z ;
         gxTv_SdtInvitados_Registroinvitadousuario_Z = sdt.gxTv_SdtInvitados_Registroinvitadousuario_Z ;
         gxTv_SdtInvitados_Registroinvitadoemail_Z = sdt.gxTv_SdtInvitados_Registroinvitadoemail_Z ;
         gxTv_SdtInvitados_Invitadorolid_Z = sdt.gxTv_SdtInvitados_Invitadorolid_Z ;
         gxTv_SdtInvitados_Registroinvitadofecha_Z = sdt.gxTv_SdtInvitados_Registroinvitadofecha_Z ;
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
         AddObjectProperty("TableroId", gxTv_SdtInvitados_Tableroid, false, includeNonInitialized);
         AddObjectProperty("RegistroInvitadoId", gxTv_SdtInvitados_Registroinvitadoid, false, includeNonInitialized);
         AddObjectProperty("RegistroInvitadoUsuario", gxTv_SdtInvitados_Registroinvitadousuario, false, includeNonInitialized);
         AddObjectProperty("RegistroInvitadoEmail", gxTv_SdtInvitados_Registroinvitadoemail, false, includeNonInitialized);
         AddObjectProperty("InvitadoRolId", gxTv_SdtInvitados_Invitadorolid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtInvitados_Registroinvitadofecha;
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
         AddObjectProperty("RegistroInvitadoFecha", sDateCnv, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtInvitados_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtInvitados_Initialized, false, includeNonInitialized);
            AddObjectProperty("TableroId_Z", gxTv_SdtInvitados_Tableroid_Z, false, includeNonInitialized);
            AddObjectProperty("RegistroInvitadoId_Z", gxTv_SdtInvitados_Registroinvitadoid_Z, false, includeNonInitialized);
            AddObjectProperty("RegistroInvitadoUsuario_Z", gxTv_SdtInvitados_Registroinvitadousuario_Z, false, includeNonInitialized);
            AddObjectProperty("RegistroInvitadoEmail_Z", gxTv_SdtInvitados_Registroinvitadoemail_Z, false, includeNonInitialized);
            AddObjectProperty("InvitadoRolId_Z", gxTv_SdtInvitados_Invitadorolid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtInvitados_Registroinvitadofecha_Z;
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
            AddObjectProperty("RegistroInvitadoFecha_Z", sDateCnv, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtInvitados sdt )
      {
         if ( sdt.IsDirty("TableroId") )
         {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Tableroid = sdt.gxTv_SdtInvitados_Tableroid ;
         }
         if ( sdt.IsDirty("RegistroInvitadoId") )
         {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Registroinvitadoid = sdt.gxTv_SdtInvitados_Registroinvitadoid ;
         }
         if ( sdt.IsDirty("RegistroInvitadoUsuario") )
         {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Registroinvitadousuario = sdt.gxTv_SdtInvitados_Registroinvitadousuario ;
         }
         if ( sdt.IsDirty("RegistroInvitadoEmail") )
         {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Registroinvitadoemail = sdt.gxTv_SdtInvitados_Registroinvitadoemail ;
         }
         if ( sdt.IsDirty("InvitadoRolId") )
         {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Invitadorolid = sdt.gxTv_SdtInvitados_Invitadorolid ;
         }
         if ( sdt.IsDirty("RegistroInvitadoFecha") )
         {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Registroinvitadofecha = sdt.gxTv_SdtInvitados_Registroinvitadofecha ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TableroId" )]
      [  XmlElement( ElementName = "TableroId"   )]
      public short gxTpr_Tableroid
      {
         get {
            return gxTv_SdtInvitados_Tableroid ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            if ( gxTv_SdtInvitados_Tableroid != value )
            {
               gxTv_SdtInvitados_Mode = "INS";
               this.gxTv_SdtInvitados_Tableroid_Z_SetNull( );
               this.gxTv_SdtInvitados_Registroinvitadoid_Z_SetNull( );
               this.gxTv_SdtInvitados_Registroinvitadousuario_Z_SetNull( );
               this.gxTv_SdtInvitados_Registroinvitadoemail_Z_SetNull( );
               this.gxTv_SdtInvitados_Invitadorolid_Z_SetNull( );
               this.gxTv_SdtInvitados_Registroinvitadofecha_Z_SetNull( );
            }
            gxTv_SdtInvitados_Tableroid = value;
            SetDirty("Tableroid");
         }

      }

      [  SoapElement( ElementName = "RegistroInvitadoId" )]
      [  XmlElement( ElementName = "RegistroInvitadoId"   )]
      public short gxTpr_Registroinvitadoid
      {
         get {
            return gxTv_SdtInvitados_Registroinvitadoid ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            if ( gxTv_SdtInvitados_Registroinvitadoid != value )
            {
               gxTv_SdtInvitados_Mode = "INS";
               this.gxTv_SdtInvitados_Tableroid_Z_SetNull( );
               this.gxTv_SdtInvitados_Registroinvitadoid_Z_SetNull( );
               this.gxTv_SdtInvitados_Registroinvitadousuario_Z_SetNull( );
               this.gxTv_SdtInvitados_Registroinvitadoemail_Z_SetNull( );
               this.gxTv_SdtInvitados_Invitadorolid_Z_SetNull( );
               this.gxTv_SdtInvitados_Registroinvitadofecha_Z_SetNull( );
            }
            gxTv_SdtInvitados_Registroinvitadoid = value;
            SetDirty("Registroinvitadoid");
         }

      }

      [  SoapElement( ElementName = "RegistroInvitadoUsuario" )]
      [  XmlElement( ElementName = "RegistroInvitadoUsuario"   )]
      public short gxTpr_Registroinvitadousuario
      {
         get {
            return gxTv_SdtInvitados_Registroinvitadousuario ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Registroinvitadousuario = value;
            SetDirty("Registroinvitadousuario");
         }

      }

      [  SoapElement( ElementName = "RegistroInvitadoEmail" )]
      [  XmlElement( ElementName = "RegistroInvitadoEmail"   )]
      public string gxTpr_Registroinvitadoemail
      {
         get {
            return gxTv_SdtInvitados_Registroinvitadoemail ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Registroinvitadoemail = value;
            SetDirty("Registroinvitadoemail");
         }

      }

      [  SoapElement( ElementName = "InvitadoRolId" )]
      [  XmlElement( ElementName = "InvitadoRolId"   )]
      public short gxTpr_Invitadorolid
      {
         get {
            return gxTv_SdtInvitados_Invitadorolid ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Invitadorolid = value;
            SetDirty("Invitadorolid");
         }

      }

      [  SoapElement( ElementName = "RegistroInvitadoFecha" )]
      [  XmlElement( ElementName = "RegistroInvitadoFecha"  , IsNullable=true )]
      public string gxTpr_Registroinvitadofecha_Nullable
      {
         get {
            if ( gxTv_SdtInvitados_Registroinvitadofecha == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtInvitados_Registroinvitadofecha).value ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtInvitados_Registroinvitadofecha = DateTime.MinValue;
            else
               gxTv_SdtInvitados_Registroinvitadofecha = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Registroinvitadofecha
      {
         get {
            return gxTv_SdtInvitados_Registroinvitadofecha ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Registroinvitadofecha = value;
            SetDirty("Registroinvitadofecha");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtInvitados_Mode ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtInvitados_Mode_SetNull( )
      {
         gxTv_SdtInvitados_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtInvitados_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtInvitados_Initialized ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtInvitados_Initialized_SetNull( )
      {
         gxTv_SdtInvitados_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtInvitados_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TableroId_Z" )]
      [  XmlElement( ElementName = "TableroId_Z"   )]
      public short gxTpr_Tableroid_Z
      {
         get {
            return gxTv_SdtInvitados_Tableroid_Z ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Tableroid_Z = value;
            SetDirty("Tableroid_Z");
         }

      }

      public void gxTv_SdtInvitados_Tableroid_Z_SetNull( )
      {
         gxTv_SdtInvitados_Tableroid_Z = 0;
         SetDirty("Tableroid_Z");
         return  ;
      }

      public bool gxTv_SdtInvitados_Tableroid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RegistroInvitadoId_Z" )]
      [  XmlElement( ElementName = "RegistroInvitadoId_Z"   )]
      public short gxTpr_Registroinvitadoid_Z
      {
         get {
            return gxTv_SdtInvitados_Registroinvitadoid_Z ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Registroinvitadoid_Z = value;
            SetDirty("Registroinvitadoid_Z");
         }

      }

      public void gxTv_SdtInvitados_Registroinvitadoid_Z_SetNull( )
      {
         gxTv_SdtInvitados_Registroinvitadoid_Z = 0;
         SetDirty("Registroinvitadoid_Z");
         return  ;
      }

      public bool gxTv_SdtInvitados_Registroinvitadoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RegistroInvitadoUsuario_Z" )]
      [  XmlElement( ElementName = "RegistroInvitadoUsuario_Z"   )]
      public short gxTpr_Registroinvitadousuario_Z
      {
         get {
            return gxTv_SdtInvitados_Registroinvitadousuario_Z ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Registroinvitadousuario_Z = value;
            SetDirty("Registroinvitadousuario_Z");
         }

      }

      public void gxTv_SdtInvitados_Registroinvitadousuario_Z_SetNull( )
      {
         gxTv_SdtInvitados_Registroinvitadousuario_Z = 0;
         SetDirty("Registroinvitadousuario_Z");
         return  ;
      }

      public bool gxTv_SdtInvitados_Registroinvitadousuario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RegistroInvitadoEmail_Z" )]
      [  XmlElement( ElementName = "RegistroInvitadoEmail_Z"   )]
      public string gxTpr_Registroinvitadoemail_Z
      {
         get {
            return gxTv_SdtInvitados_Registroinvitadoemail_Z ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Registroinvitadoemail_Z = value;
            SetDirty("Registroinvitadoemail_Z");
         }

      }

      public void gxTv_SdtInvitados_Registroinvitadoemail_Z_SetNull( )
      {
         gxTv_SdtInvitados_Registroinvitadoemail_Z = "";
         SetDirty("Registroinvitadoemail_Z");
         return  ;
      }

      public bool gxTv_SdtInvitados_Registroinvitadoemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvitadoRolId_Z" )]
      [  XmlElement( ElementName = "InvitadoRolId_Z"   )]
      public short gxTpr_Invitadorolid_Z
      {
         get {
            return gxTv_SdtInvitados_Invitadorolid_Z ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Invitadorolid_Z = value;
            SetDirty("Invitadorolid_Z");
         }

      }

      public void gxTv_SdtInvitados_Invitadorolid_Z_SetNull( )
      {
         gxTv_SdtInvitados_Invitadorolid_Z = 0;
         SetDirty("Invitadorolid_Z");
         return  ;
      }

      public bool gxTv_SdtInvitados_Invitadorolid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RegistroInvitadoFecha_Z" )]
      [  XmlElement( ElementName = "RegistroInvitadoFecha_Z"  , IsNullable=true )]
      public string gxTpr_Registroinvitadofecha_Z_Nullable
      {
         get {
            if ( gxTv_SdtInvitados_Registroinvitadofecha_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtInvitados_Registroinvitadofecha_Z).value ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtInvitados_Registroinvitadofecha_Z = DateTime.MinValue;
            else
               gxTv_SdtInvitados_Registroinvitadofecha_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Registroinvitadofecha_Z
      {
         get {
            return gxTv_SdtInvitados_Registroinvitadofecha_Z ;
         }

         set {
            gxTv_SdtInvitados_N = 0;
            gxTv_SdtInvitados_Registroinvitadofecha_Z = value;
            SetDirty("Registroinvitadofecha_Z");
         }

      }

      public void gxTv_SdtInvitados_Registroinvitadofecha_Z_SetNull( )
      {
         gxTv_SdtInvitados_Registroinvitadofecha_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Registroinvitadofecha_Z");
         return  ;
      }

      public bool gxTv_SdtInvitados_Registroinvitadofecha_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtInvitados_N = 1;
         gxTv_SdtInvitados_Registroinvitadoemail = "";
         gxTv_SdtInvitados_Registroinvitadofecha = (DateTime)(DateTime.MinValue);
         gxTv_SdtInvitados_Mode = "";
         gxTv_SdtInvitados_Registroinvitadoemail_Z = "";
         gxTv_SdtInvitados_Registroinvitadofecha_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "invitados", "GeneXus.Programs.invitados_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtInvitados_N ;
      }

      private short gxTv_SdtInvitados_Tableroid ;
      private short gxTv_SdtInvitados_N ;
      private short gxTv_SdtInvitados_Registroinvitadoid ;
      private short gxTv_SdtInvitados_Registroinvitadousuario ;
      private short gxTv_SdtInvitados_Invitadorolid ;
      private short gxTv_SdtInvitados_Initialized ;
      private short gxTv_SdtInvitados_Tableroid_Z ;
      private short gxTv_SdtInvitados_Registroinvitadoid_Z ;
      private short gxTv_SdtInvitados_Registroinvitadousuario_Z ;
      private short gxTv_SdtInvitados_Invitadorolid_Z ;
      private string gxTv_SdtInvitados_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtInvitados_Registroinvitadofecha ;
      private DateTime gxTv_SdtInvitados_Registroinvitadofecha_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtInvitados_Registroinvitadoemail ;
      private string gxTv_SdtInvitados_Registroinvitadoemail_Z ;
   }

   [DataContract(Name = @"Invitados", Namespace = "ProyectoUMG")]
   public class SdtInvitados_RESTInterface : GxGenericCollectionItem<SdtInvitados>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtInvitados_RESTInterface( ) : base()
      {
      }

      public SdtInvitados_RESTInterface( SdtInvitados psdt ) : base(psdt)
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

      [DataMember( Name = "RegistroInvitadoId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Registroinvitadoid
      {
         get {
            return sdt.gxTpr_Registroinvitadoid ;
         }

         set {
            sdt.gxTpr_Registroinvitadoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RegistroInvitadoUsuario" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Registroinvitadousuario
      {
         get {
            return sdt.gxTpr_Registroinvitadousuario ;
         }

         set {
            sdt.gxTpr_Registroinvitadousuario = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RegistroInvitadoEmail" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Registroinvitadoemail
      {
         get {
            return sdt.gxTpr_Registroinvitadoemail ;
         }

         set {
            sdt.gxTpr_Registroinvitadoemail = value;
         }

      }

      [DataMember( Name = "InvitadoRolId" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Invitadorolid
      {
         get {
            return sdt.gxTpr_Invitadorolid ;
         }

         set {
            sdt.gxTpr_Invitadorolid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RegistroInvitadoFecha" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Registroinvitadofecha
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Registroinvitadofecha) ;
         }

         set {
            sdt.gxTpr_Registroinvitadofecha = DateTimeUtil.CToT2( value);
         }

      }

      public SdtInvitados sdt
      {
         get {
            return (SdtInvitados)Sdt ;
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
            sdt = new SdtInvitados() ;
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

   [DataContract(Name = @"Invitados", Namespace = "ProyectoUMG")]
   public class SdtInvitados_RESTLInterface : GxGenericCollectionItem<SdtInvitados>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtInvitados_RESTLInterface( ) : base()
      {
      }

      public SdtInvitados_RESTLInterface( SdtInvitados psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RegistroInvitadoEmail" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Registroinvitadoemail
      {
         get {
            return sdt.gxTpr_Registroinvitadoemail ;
         }

         set {
            sdt.gxTpr_Registroinvitadoemail = value;
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

      public SdtInvitados sdt
      {
         get {
            return (SdtInvitados)Sdt ;
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
            sdt = new SdtInvitados() ;
         }
      }

   }

}
