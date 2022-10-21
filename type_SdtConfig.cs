/*
				   File: type_SdtConfig
			Description: Config
				 Author: Nemo 🐠 for C# version 17.0.11.163677
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="Config")]
	[XmlType(TypeName="Config" , Namespace="ProyectoUMG" )]
	[Serializable]
	public class SdtConfig : GxUserType
	{
		public SdtConfig( )
		{
			/* Constructor for serialization */
			gxTv_SdtConfig_Imageprofilepath = "";

			gxTv_SdtConfig_Imageprofileextension = "";

			gxTv_SdtConfig_Imageprofiledefault = "";

			gxTv_SdtConfig_Imageformpath = "";

			gxTv_SdtConfig_Imageformextension = "";

			gxTv_SdtConfig_Imageformdefault = "";

			gxTv_SdtConfig_Imagedpipath = "";

			gxTv_SdtConfig_Imagedpifrontaldefault = "";

			gxTv_SdtConfig_Imagedpiposteriordefault = "";

			gxTv_SdtConfig_Pdfpath = "";

			gxTv_SdtConfig_Pdfextension = "";

			gxTv_SdtConfig_Recaptchasitekey = "";

			gxTv_SdtConfig_Recaptchasecretkey = "";

			gxTv_SdtConfig_Emailkey = "";

			gxTv_SdtConfig_Encripto = "";

		}

		public SdtConfig(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("ImageProfilePath", gxTpr_Imageprofilepath, false);


			AddObjectProperty("ImageProfileExtension", gxTpr_Imageprofileextension, false);


			AddObjectProperty("ImageProfileDefault", gxTpr_Imageprofiledefault, false);


			AddObjectProperty("ImageFormPath", gxTpr_Imageformpath, false);


			AddObjectProperty("ImageFormExtension", gxTpr_Imageformextension, false);


			AddObjectProperty("ImageFormDefault", gxTpr_Imageformdefault, false);


			AddObjectProperty("ImageDPIPath", gxTpr_Imagedpipath, false);


			AddObjectProperty("ImageDPIFrontalDefault", gxTpr_Imagedpifrontaldefault, false);


			AddObjectProperty("ImageDPIPosteriorDefault", gxTpr_Imagedpiposteriordefault, false);


			AddObjectProperty("PDFPath", gxTpr_Pdfpath, false);


			AddObjectProperty("PDFExtension", gxTpr_Pdfextension, false);


			AddObjectProperty("reCaptchaSiteKey", gxTpr_Recaptchasitekey, false);


			AddObjectProperty("reCaptchaSecretKey", gxTpr_Recaptchasecretkey, false);


			AddObjectProperty("version", gxTpr_Version, false);


			AddObjectProperty("MaxLoginAttemps", gxTpr_Maxloginattemps, false);


			AddObjectProperty("EmailKey", gxTpr_Emailkey, false);


			AddObjectProperty("Encripto", gxTpr_Encripto, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ImageProfilePath")]
		[XmlElement(ElementName="ImageProfilePath")]
		public string gxTpr_Imageprofilepath
		{
			get {
				return gxTv_SdtConfig_Imageprofilepath; 
			}
			set {
				gxTv_SdtConfig_Imageprofilepath = value;
				SetDirty("Imageprofilepath");
			}
		}




		[SoapElement(ElementName="ImageProfileExtension")]
		[XmlElement(ElementName="ImageProfileExtension")]
		public string gxTpr_Imageprofileextension
		{
			get {
				return gxTv_SdtConfig_Imageprofileextension; 
			}
			set {
				gxTv_SdtConfig_Imageprofileextension = value;
				SetDirty("Imageprofileextension");
			}
		}




		[SoapElement(ElementName="ImageProfileDefault")]
		[XmlElement(ElementName="ImageProfileDefault")]
		public string gxTpr_Imageprofiledefault
		{
			get {
				return gxTv_SdtConfig_Imageprofiledefault; 
			}
			set {
				gxTv_SdtConfig_Imageprofiledefault = value;
				SetDirty("Imageprofiledefault");
			}
		}




		[SoapElement(ElementName="ImageFormPath")]
		[XmlElement(ElementName="ImageFormPath")]
		public string gxTpr_Imageformpath
		{
			get {
				return gxTv_SdtConfig_Imageformpath; 
			}
			set {
				gxTv_SdtConfig_Imageformpath = value;
				SetDirty("Imageformpath");
			}
		}




		[SoapElement(ElementName="ImageFormExtension")]
		[XmlElement(ElementName="ImageFormExtension")]
		public string gxTpr_Imageformextension
		{
			get {
				return gxTv_SdtConfig_Imageformextension; 
			}
			set {
				gxTv_SdtConfig_Imageformextension = value;
				SetDirty("Imageformextension");
			}
		}




		[SoapElement(ElementName="ImageFormDefault")]
		[XmlElement(ElementName="ImageFormDefault")]
		public string gxTpr_Imageformdefault
		{
			get {
				return gxTv_SdtConfig_Imageformdefault; 
			}
			set {
				gxTv_SdtConfig_Imageformdefault = value;
				SetDirty("Imageformdefault");
			}
		}




		[SoapElement(ElementName="ImageDPIPath")]
		[XmlElement(ElementName="ImageDPIPath")]
		public string gxTpr_Imagedpipath
		{
			get {
				return gxTv_SdtConfig_Imagedpipath; 
			}
			set {
				gxTv_SdtConfig_Imagedpipath = value;
				SetDirty("Imagedpipath");
			}
		}




		[SoapElement(ElementName="ImageDPIFrontalDefault")]
		[XmlElement(ElementName="ImageDPIFrontalDefault")]
		public string gxTpr_Imagedpifrontaldefault
		{
			get {
				return gxTv_SdtConfig_Imagedpifrontaldefault; 
			}
			set {
				gxTv_SdtConfig_Imagedpifrontaldefault = value;
				SetDirty("Imagedpifrontaldefault");
			}
		}




		[SoapElement(ElementName="ImageDPIPosteriorDefault")]
		[XmlElement(ElementName="ImageDPIPosteriorDefault")]
		public string gxTpr_Imagedpiposteriordefault
		{
			get {
				return gxTv_SdtConfig_Imagedpiposteriordefault; 
			}
			set {
				gxTv_SdtConfig_Imagedpiposteriordefault = value;
				SetDirty("Imagedpiposteriordefault");
			}
		}




		[SoapElement(ElementName="PDFPath")]
		[XmlElement(ElementName="PDFPath")]
		public string gxTpr_Pdfpath
		{
			get {
				return gxTv_SdtConfig_Pdfpath; 
			}
			set {
				gxTv_SdtConfig_Pdfpath = value;
				SetDirty("Pdfpath");
			}
		}




		[SoapElement(ElementName="PDFExtension")]
		[XmlElement(ElementName="PDFExtension")]
		public string gxTpr_Pdfextension
		{
			get {
				return gxTv_SdtConfig_Pdfextension; 
			}
			set {
				gxTv_SdtConfig_Pdfextension = value;
				SetDirty("Pdfextension");
			}
		}




		[SoapElement(ElementName="reCaptchaSiteKey")]
		[XmlElement(ElementName="reCaptchaSiteKey")]
		public string gxTpr_Recaptchasitekey
		{
			get {
				return gxTv_SdtConfig_Recaptchasitekey; 
			}
			set {
				gxTv_SdtConfig_Recaptchasitekey = value;
				SetDirty("Recaptchasitekey");
			}
		}




		[SoapElement(ElementName="reCaptchaSecretKey")]
		[XmlElement(ElementName="reCaptchaSecretKey")]
		public string gxTpr_Recaptchasecretkey
		{
			get {
				return gxTv_SdtConfig_Recaptchasecretkey; 
			}
			set {
				gxTv_SdtConfig_Recaptchasecretkey = value;
				SetDirty("Recaptchasecretkey");
			}
		}




		[SoapElement(ElementName="version")]
		[XmlElement(ElementName="version")]
		public short gxTpr_Version
		{
			get {
				return gxTv_SdtConfig_Version; 
			}
			set {
				gxTv_SdtConfig_Version = value;
				SetDirty("Version");
			}
		}




		[SoapElement(ElementName="MaxLoginAttemps")]
		[XmlElement(ElementName="MaxLoginAttemps")]
		public short gxTpr_Maxloginattemps
		{
			get {
				return gxTv_SdtConfig_Maxloginattemps; 
			}
			set {
				gxTv_SdtConfig_Maxloginattemps = value;
				SetDirty("Maxloginattemps");
			}
		}




		[SoapElement(ElementName="EmailKey")]
		[XmlElement(ElementName="EmailKey")]
		public string gxTpr_Emailkey
		{
			get {
				return gxTv_SdtConfig_Emailkey; 
			}
			set {
				gxTv_SdtConfig_Emailkey = value;
				SetDirty("Emailkey");
			}
		}




		[SoapElement(ElementName="Encripto")]
		[XmlElement(ElementName="Encripto")]
		public string gxTpr_Encripto
		{
			get {
				return gxTv_SdtConfig_Encripto; 
			}
			set {
				gxTv_SdtConfig_Encripto = value;
				SetDirty("Encripto");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtConfig_Imageprofilepath = "./public/profile/";
			gxTv_SdtConfig_Imageprofileextension = ".jpg";
			gxTv_SdtConfig_Imageprofiledefault = "./Resources/perfil1.png";
			gxTv_SdtConfig_Imageformpath = "./Resources/forms/";
			gxTv_SdtConfig_Imageformextension = ".jpg";
			gxTv_SdtConfig_Imageformdefault = "./Resources/forms/image.svg";
			gxTv_SdtConfig_Imagedpipath = "./public/dpi/";
			gxTv_SdtConfig_Imagedpifrontaldefault = "./Resources/DPI_Frontal.jpg";
			gxTv_SdtConfig_Imagedpiposteriordefault = "./Resources/DPI_Posterior.jpg";
			gxTv_SdtConfig_Pdfpath = "./public/uploads/";
			gxTv_SdtConfig_Pdfextension = ".pdf";
			gxTv_SdtConfig_Recaptchasitekey = "";
			gxTv_SdtConfig_Recaptchasecretkey = "";
			gxTv_SdtConfig_Version = 1;
			gxTv_SdtConfig_Maxloginattemps = 3;
			gxTv_SdtConfig_Emailkey = "C3EAC6B1126023C27E7212E6CA2707B1";
			gxTv_SdtConfig_Encripto = "0018222FB3001E8CFB35642226A9C3ED";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtConfig_Imageprofilepath;
		 

		protected string gxTv_SdtConfig_Imageprofileextension;
		 

		protected string gxTv_SdtConfig_Imageprofiledefault;
		 

		protected string gxTv_SdtConfig_Imageformpath;
		 

		protected string gxTv_SdtConfig_Imageformextension;
		 

		protected string gxTv_SdtConfig_Imageformdefault;
		 

		protected string gxTv_SdtConfig_Imagedpipath;
		 

		protected string gxTv_SdtConfig_Imagedpifrontaldefault;
		 

		protected string gxTv_SdtConfig_Imagedpiposteriordefault;
		 

		protected string gxTv_SdtConfig_Pdfpath;
		 

		protected string gxTv_SdtConfig_Pdfextension;
		 

		protected string gxTv_SdtConfig_Recaptchasitekey;
		 

		protected string gxTv_SdtConfig_Recaptchasecretkey;
		 

		protected short gxTv_SdtConfig_Version;
		 

		protected short gxTv_SdtConfig_Maxloginattemps;
		 

		protected string gxTv_SdtConfig_Emailkey;
		 

		protected string gxTv_SdtConfig_Encripto;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"Config", Namespace="ProyectoUMG")]
	public class SdtConfig_RESTInterface : GxGenericCollectionItem<SdtConfig>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtConfig_RESTInterface( ) : base()
		{	
		}

		public SdtConfig_RESTInterface( SdtConfig psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ImageProfilePath", Order=0)]
		public  string gxTpr_Imageprofilepath
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imageprofilepath);

			}
			set { 
				 sdt.gxTpr_Imageprofilepath = value;
			}
		}

		[DataMember(Name="ImageProfileExtension", Order=1)]
		public  string gxTpr_Imageprofileextension
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imageprofileextension);

			}
			set { 
				 sdt.gxTpr_Imageprofileextension = value;
			}
		}

		[DataMember(Name="ImageProfileDefault", Order=2)]
		public  string gxTpr_Imageprofiledefault
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imageprofiledefault);

			}
			set { 
				 sdt.gxTpr_Imageprofiledefault = value;
			}
		}

		[DataMember(Name="ImageFormPath", Order=3)]
		public  string gxTpr_Imageformpath
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imageformpath);

			}
			set { 
				 sdt.gxTpr_Imageformpath = value;
			}
		}

		[DataMember(Name="ImageFormExtension", Order=4)]
		public  string gxTpr_Imageformextension
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imageformextension);

			}
			set { 
				 sdt.gxTpr_Imageformextension = value;
			}
		}

		[DataMember(Name="ImageFormDefault", Order=5)]
		public  string gxTpr_Imageformdefault
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imageformdefault);

			}
			set { 
				 sdt.gxTpr_Imageformdefault = value;
			}
		}

		[DataMember(Name="ImageDPIPath", Order=6)]
		public  string gxTpr_Imagedpipath
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imagedpipath);

			}
			set { 
				 sdt.gxTpr_Imagedpipath = value;
			}
		}

		[DataMember(Name="ImageDPIFrontalDefault", Order=7)]
		public  string gxTpr_Imagedpifrontaldefault
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imagedpifrontaldefault);

			}
			set { 
				 sdt.gxTpr_Imagedpifrontaldefault = value;
			}
		}

		[DataMember(Name="ImageDPIPosteriorDefault", Order=8)]
		public  string gxTpr_Imagedpiposteriordefault
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imagedpiposteriordefault);

			}
			set { 
				 sdt.gxTpr_Imagedpiposteriordefault = value;
			}
		}

		[DataMember(Name="PDFPath", Order=9)]
		public  string gxTpr_Pdfpath
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pdfpath);

			}
			set { 
				 sdt.gxTpr_Pdfpath = value;
			}
		}

		[DataMember(Name="PDFExtension", Order=10)]
		public  string gxTpr_Pdfextension
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pdfextension);

			}
			set { 
				 sdt.gxTpr_Pdfextension = value;
			}
		}

		[DataMember(Name="reCaptchaSiteKey", Order=11)]
		public  string gxTpr_Recaptchasitekey
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Recaptchasitekey);

			}
			set { 
				 sdt.gxTpr_Recaptchasitekey = value;
			}
		}

		[DataMember(Name="reCaptchaSecretKey", Order=12)]
		public  string gxTpr_Recaptchasecretkey
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Recaptchasecretkey);

			}
			set { 
				 sdt.gxTpr_Recaptchasecretkey = value;
			}
		}

		[DataMember(Name="version", Order=13)]
		public short gxTpr_Version
		{
			get { 
				return sdt.gxTpr_Version;

			}
			set { 
				sdt.gxTpr_Version = value;
			}
		}

		[DataMember(Name="MaxLoginAttemps", Order=14)]
		public short gxTpr_Maxloginattemps
		{
			get { 
				return sdt.gxTpr_Maxloginattemps;

			}
			set { 
				sdt.gxTpr_Maxloginattemps = value;
			}
		}

		[DataMember(Name="EmailKey", Order=15)]
		public  string gxTpr_Emailkey
		{
			get { 
				return sdt.gxTpr_Emailkey;

			}
			set { 
				 sdt.gxTpr_Emailkey = value;
			}
		}

		[DataMember(Name="Encripto", Order=16)]
		public  string gxTpr_Encripto
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Encripto);

			}
			set { 
				 sdt.gxTpr_Encripto = value;
			}
		}


		#endregion

		public SdtConfig sdt
		{
			get { 
				return (SdtConfig)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtConfig() ;
			}
		}
	}
	#endregion
}