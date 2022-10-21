/*
				   File: type_SdtAnadirUsuarioColaboradorTestSDT
			Description: AnadirUsuarioColaboradorTestSDT
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

using GeneXus.Programs;
namespace GeneXus.Programs.tests
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="AnadirUsuarioColaboradorTestSDT")]
	[XmlType(TypeName="AnadirUsuarioColaboradorTestSDT" , Namespace="ProyectoUMG" )]
	[Serializable]
	public class SdtAnadirUsuarioColaboradorTestSDT : GxUserType
	{
		public SdtAnadirUsuarioColaboradorTestSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtAnadirUsuarioColaboradorTestSDT_Testcaseid = "";

			gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgtableroid = "";

			gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgregistroinvitadoid = "";

			gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgresult = "";

		}

		public SdtAnadirUsuarioColaboradorTestSDT(IGxContext context)
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
			AddObjectProperty("TestCaseId", gxTpr_Testcaseid, false);


			AddObjectProperty("TableroId", gxTpr_Tableroid, false);


			AddObjectProperty("ExpectedTableroId", gxTpr_Expectedtableroid, false);


			AddObjectProperty("MsgTableroId", gxTpr_Msgtableroid, false);


			AddObjectProperty("RegistroInvitadoId", gxTpr_Registroinvitadoid, false);


			AddObjectProperty("ExpectedRegistroInvitadoId", gxTpr_Expectedregistroinvitadoid, false);


			AddObjectProperty("MsgRegistroInvitadoId", gxTpr_Msgregistroinvitadoid, false);


			AddObjectProperty("result", gxTpr_Result, false);


			AddObjectProperty("Expectedresult", gxTpr_Expectedresult, false);


			AddObjectProperty("Msgresult", gxTpr_Msgresult, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TestCaseId")]
		[XmlElement(ElementName="TestCaseId")]
		public string gxTpr_Testcaseid
		{
			get {
				return gxTv_SdtAnadirUsuarioColaboradorTestSDT_Testcaseid; 
			}
			set {
				gxTv_SdtAnadirUsuarioColaboradorTestSDT_Testcaseid = value;
				SetDirty("Testcaseid");
			}
		}




		[SoapElement(ElementName="TableroId")]
		[XmlElement(ElementName="TableroId")]
		public short gxTpr_Tableroid
		{
			get {
				return gxTv_SdtAnadirUsuarioColaboradorTestSDT_Tableroid; 
			}
			set {
				gxTv_SdtAnadirUsuarioColaboradorTestSDT_Tableroid = value;
				SetDirty("Tableroid");
			}
		}




		[SoapElement(ElementName="ExpectedTableroId")]
		[XmlElement(ElementName="ExpectedTableroId")]
		public short gxTpr_Expectedtableroid
		{
			get {
				return gxTv_SdtAnadirUsuarioColaboradorTestSDT_Expectedtableroid; 
			}
			set {
				gxTv_SdtAnadirUsuarioColaboradorTestSDT_Expectedtableroid = value;
				SetDirty("Expectedtableroid");
			}
		}




		[SoapElement(ElementName="MsgTableroId")]
		[XmlElement(ElementName="MsgTableroId")]
		public string gxTpr_Msgtableroid
		{
			get {
				return gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgtableroid; 
			}
			set {
				gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgtableroid = value;
				SetDirty("Msgtableroid");
			}
		}




		[SoapElement(ElementName="RegistroInvitadoId")]
		[XmlElement(ElementName="RegistroInvitadoId")]
		public short gxTpr_Registroinvitadoid
		{
			get {
				return gxTv_SdtAnadirUsuarioColaboradorTestSDT_Registroinvitadoid; 
			}
			set {
				gxTv_SdtAnadirUsuarioColaboradorTestSDT_Registroinvitadoid = value;
				SetDirty("Registroinvitadoid");
			}
		}




		[SoapElement(ElementName="ExpectedRegistroInvitadoId")]
		[XmlElement(ElementName="ExpectedRegistroInvitadoId")]
		public short gxTpr_Expectedregistroinvitadoid
		{
			get {
				return gxTv_SdtAnadirUsuarioColaboradorTestSDT_Expectedregistroinvitadoid; 
			}
			set {
				gxTv_SdtAnadirUsuarioColaboradorTestSDT_Expectedregistroinvitadoid = value;
				SetDirty("Expectedregistroinvitadoid");
			}
		}




		[SoapElement(ElementName="MsgRegistroInvitadoId")]
		[XmlElement(ElementName="MsgRegistroInvitadoId")]
		public string gxTpr_Msgregistroinvitadoid
		{
			get {
				return gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgregistroinvitadoid; 
			}
			set {
				gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgregistroinvitadoid = value;
				SetDirty("Msgregistroinvitadoid");
			}
		}




		[SoapElement(ElementName="result")]
		[XmlElement(ElementName="result")]
		public bool gxTpr_Result
		{
			get {
				return gxTv_SdtAnadirUsuarioColaboradorTestSDT_Result; 
			}
			set {
				gxTv_SdtAnadirUsuarioColaboradorTestSDT_Result = value;
				SetDirty("Result");
			}
		}




		[SoapElement(ElementName="Expectedresult")]
		[XmlElement(ElementName="Expectedresult")]
		public bool gxTpr_Expectedresult
		{
			get {
				return gxTv_SdtAnadirUsuarioColaboradorTestSDT_Expectedresult; 
			}
			set {
				gxTv_SdtAnadirUsuarioColaboradorTestSDT_Expectedresult = value;
				SetDirty("Expectedresult");
			}
		}




		[SoapElement(ElementName="Msgresult")]
		[XmlElement(ElementName="Msgresult")]
		public string gxTpr_Msgresult
		{
			get {
				return gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgresult; 
			}
			set {
				gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgresult = value;
				SetDirty("Msgresult");
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
			gxTv_SdtAnadirUsuarioColaboradorTestSDT_Testcaseid = "";


			gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgtableroid = "";


			gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgregistroinvitadoid = "";


			gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgresult = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtAnadirUsuarioColaboradorTestSDT_Testcaseid;
		 

		protected short gxTv_SdtAnadirUsuarioColaboradorTestSDT_Tableroid;
		 

		protected short gxTv_SdtAnadirUsuarioColaboradorTestSDT_Expectedtableroid;
		 

		protected string gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgtableroid;
		 

		protected short gxTv_SdtAnadirUsuarioColaboradorTestSDT_Registroinvitadoid;
		 

		protected short gxTv_SdtAnadirUsuarioColaboradorTestSDT_Expectedregistroinvitadoid;
		 

		protected string gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgregistroinvitadoid;
		 

		protected bool gxTv_SdtAnadirUsuarioColaboradorTestSDT_Result;
		 

		protected bool gxTv_SdtAnadirUsuarioColaboradorTestSDT_Expectedresult;
		 

		protected string gxTv_SdtAnadirUsuarioColaboradorTestSDT_Msgresult;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"AnadirUsuarioColaboradorTestSDT", Namespace="ProyectoUMG")]
	public class SdtAnadirUsuarioColaboradorTestSDT_RESTInterface : GxGenericCollectionItem<SdtAnadirUsuarioColaboradorTestSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtAnadirUsuarioColaboradorTestSDT_RESTInterface( ) : base()
		{	
		}

		public SdtAnadirUsuarioColaboradorTestSDT_RESTInterface( SdtAnadirUsuarioColaboradorTestSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TestCaseId", Order=0)]
		public  string gxTpr_Testcaseid
		{
			get { 
				return sdt.gxTpr_Testcaseid;

			}
			set { 
				 sdt.gxTpr_Testcaseid = value;
			}
		}

		[DataMember(Name="TableroId", Order=1)]
		public short gxTpr_Tableroid
		{
			get { 
				return sdt.gxTpr_Tableroid;

			}
			set { 
				sdt.gxTpr_Tableroid = value;
			}
		}

		[DataMember(Name="ExpectedTableroId", Order=2)]
		public short gxTpr_Expectedtableroid
		{
			get { 
				return sdt.gxTpr_Expectedtableroid;

			}
			set { 
				sdt.gxTpr_Expectedtableroid = value;
			}
		}

		[DataMember(Name="MsgTableroId", Order=3)]
		public  string gxTpr_Msgtableroid
		{
			get { 
				return sdt.gxTpr_Msgtableroid;

			}
			set { 
				 sdt.gxTpr_Msgtableroid = value;
			}
		}

		[DataMember(Name="RegistroInvitadoId", Order=4)]
		public short gxTpr_Registroinvitadoid
		{
			get { 
				return sdt.gxTpr_Registroinvitadoid;

			}
			set { 
				sdt.gxTpr_Registroinvitadoid = value;
			}
		}

		[DataMember(Name="ExpectedRegistroInvitadoId", Order=5)]
		public short gxTpr_Expectedregistroinvitadoid
		{
			get { 
				return sdt.gxTpr_Expectedregistroinvitadoid;

			}
			set { 
				sdt.gxTpr_Expectedregistroinvitadoid = value;
			}
		}

		[DataMember(Name="MsgRegistroInvitadoId", Order=6)]
		public  string gxTpr_Msgregistroinvitadoid
		{
			get { 
				return sdt.gxTpr_Msgregistroinvitadoid;

			}
			set { 
				 sdt.gxTpr_Msgregistroinvitadoid = value;
			}
		}

		[DataMember(Name="result", Order=7)]
		public bool gxTpr_Result
		{
			get { 
				return sdt.gxTpr_Result;

			}
			set { 
				sdt.gxTpr_Result = value;
			}
		}

		[DataMember(Name="Expectedresult", Order=8)]
		public bool gxTpr_Expectedresult
		{
			get { 
				return sdt.gxTpr_Expectedresult;

			}
			set { 
				sdt.gxTpr_Expectedresult = value;
			}
		}

		[DataMember(Name="Msgresult", Order=9)]
		public  string gxTpr_Msgresult
		{
			get { 
				return sdt.gxTpr_Msgresult;

			}
			set { 
				 sdt.gxTpr_Msgresult = value;
			}
		}


		#endregion

		public SdtAnadirUsuarioColaboradorTestSDT sdt
		{
			get { 
				return (SdtAnadirUsuarioColaboradorTestSDT)Sdt;
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
				sdt = new SdtAnadirUsuarioColaboradorTestSDT() ;
			}
		}
	}
	#endregion
}