/*
				   File: type_SdtgetNumeroIntegrantesTestSDT
			Description: getNumeroIntegrantesTestSDT
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
	[XmlRoot(ElementName="getNumeroIntegrantesTestSDT")]
	[XmlType(TypeName="getNumeroIntegrantesTestSDT" , Namespace="ProyectoUMG" )]
	[Serializable]
	public class SdtgetNumeroIntegrantesTestSDT : GxUserType
	{
		public SdtgetNumeroIntegrantesTestSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtgetNumeroIntegrantesTestSDT_Testcaseid = "";

			gxTv_SdtgetNumeroIntegrantesTestSDT_Msgcount = "";

		}

		public SdtgetNumeroIntegrantesTestSDT(IGxContext context)
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


			AddObjectProperty("count", gxTpr_Count, false);


			AddObjectProperty("Expectedcount", gxTpr_Expectedcount, false);


			AddObjectProperty("Msgcount", gxTpr_Msgcount, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TestCaseId")]
		[XmlElement(ElementName="TestCaseId")]
		public string gxTpr_Testcaseid
		{
			get {
				return gxTv_SdtgetNumeroIntegrantesTestSDT_Testcaseid; 
			}
			set {
				gxTv_SdtgetNumeroIntegrantesTestSDT_Testcaseid = value;
				SetDirty("Testcaseid");
			}
		}




		[SoapElement(ElementName="TableroId")]
		[XmlElement(ElementName="TableroId")]
		public short gxTpr_Tableroid
		{
			get {
				return gxTv_SdtgetNumeroIntegrantesTestSDT_Tableroid; 
			}
			set {
				gxTv_SdtgetNumeroIntegrantesTestSDT_Tableroid = value;
				SetDirty("Tableroid");
			}
		}




		[SoapElement(ElementName="count")]
		[XmlElement(ElementName="count")]
		public short gxTpr_Count
		{
			get {
				return gxTv_SdtgetNumeroIntegrantesTestSDT_Count; 
			}
			set {
				gxTv_SdtgetNumeroIntegrantesTestSDT_Count = value;
				SetDirty("Count");
			}
		}




		[SoapElement(ElementName="Expectedcount")]
		[XmlElement(ElementName="Expectedcount")]
		public short gxTpr_Expectedcount
		{
			get {
				return gxTv_SdtgetNumeroIntegrantesTestSDT_Expectedcount; 
			}
			set {
				gxTv_SdtgetNumeroIntegrantesTestSDT_Expectedcount = value;
				SetDirty("Expectedcount");
			}
		}




		[SoapElement(ElementName="Msgcount")]
		[XmlElement(ElementName="Msgcount")]
		public string gxTpr_Msgcount
		{
			get {
				return gxTv_SdtgetNumeroIntegrantesTestSDT_Msgcount; 
			}
			set {
				gxTv_SdtgetNumeroIntegrantesTestSDT_Msgcount = value;
				SetDirty("Msgcount");
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
			gxTv_SdtgetNumeroIntegrantesTestSDT_Testcaseid = "";



			gxTv_SdtgetNumeroIntegrantesTestSDT_Msgcount = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtgetNumeroIntegrantesTestSDT_Testcaseid;
		 

		protected short gxTv_SdtgetNumeroIntegrantesTestSDT_Tableroid;
		 

		protected short gxTv_SdtgetNumeroIntegrantesTestSDT_Count;
		 

		protected short gxTv_SdtgetNumeroIntegrantesTestSDT_Expectedcount;
		 

		protected string gxTv_SdtgetNumeroIntegrantesTestSDT_Msgcount;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"getNumeroIntegrantesTestSDT", Namespace="ProyectoUMG")]
	public class SdtgetNumeroIntegrantesTestSDT_RESTInterface : GxGenericCollectionItem<SdtgetNumeroIntegrantesTestSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtgetNumeroIntegrantesTestSDT_RESTInterface( ) : base()
		{	
		}

		public SdtgetNumeroIntegrantesTestSDT_RESTInterface( SdtgetNumeroIntegrantesTestSDT psdt ) : base(psdt)
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

		[DataMember(Name="count", Order=2)]
		public short gxTpr_Count
		{
			get { 
				return sdt.gxTpr_Count;

			}
			set { 
				sdt.gxTpr_Count = value;
			}
		}

		[DataMember(Name="Expectedcount", Order=3)]
		public short gxTpr_Expectedcount
		{
			get { 
				return sdt.gxTpr_Expectedcount;

			}
			set { 
				sdt.gxTpr_Expectedcount = value;
			}
		}

		[DataMember(Name="Msgcount", Order=4)]
		public  string gxTpr_Msgcount
		{
			get { 
				return sdt.gxTpr_Msgcount;

			}
			set { 
				 sdt.gxTpr_Msgcount = value;
			}
		}


		#endregion

		public SdtgetNumeroIntegrantesTestSDT sdt
		{
			get { 
				return (SdtgetNumeroIntegrantesTestSDT)Sdt;
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
				sdt = new SdtgetNumeroIntegrantesTestSDT() ;
			}
		}
	}
	#endregion
}