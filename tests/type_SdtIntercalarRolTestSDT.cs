/*
				   File: type_SdtIntercalarRolTestSDT
			Description: IntercalarRolTestSDT
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
	[XmlRoot(ElementName="IntercalarRolTestSDT")]
	[XmlType(TypeName="IntercalarRolTestSDT" , Namespace="ProyectoUMG" )]
	[Serializable]
	public class SdtIntercalarRolTestSDT : GxUserType
	{
		public SdtIntercalarRolTestSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtIntercalarRolTestSDT_Testcaseid = "";

			gxTv_SdtIntercalarRolTestSDT_Msgtableroid = "";

			gxTv_SdtIntercalarRolTestSDT_Msgparticipantetableroid = "";

			gxTv_SdtIntercalarRolTestSDT_Msgrol = "";

		}

		public SdtIntercalarRolTestSDT(IGxContext context)
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


			AddObjectProperty("ParticipanteTableroId", gxTpr_Participantetableroid, false);


			AddObjectProperty("ExpectedParticipanteTableroId", gxTpr_Expectedparticipantetableroid, false);


			AddObjectProperty("MsgParticipanteTableroId", gxTpr_Msgparticipantetableroid, false);


			AddObjectProperty("rol", gxTpr_Rol, false);


			AddObjectProperty("Expectedrol", gxTpr_Expectedrol, false);


			AddObjectProperty("Msgrol", gxTpr_Msgrol, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TestCaseId")]
		[XmlElement(ElementName="TestCaseId")]
		public string gxTpr_Testcaseid
		{
			get {
				return gxTv_SdtIntercalarRolTestSDT_Testcaseid; 
			}
			set {
				gxTv_SdtIntercalarRolTestSDT_Testcaseid = value;
				SetDirty("Testcaseid");
			}
		}




		[SoapElement(ElementName="TableroId")]
		[XmlElement(ElementName="TableroId")]
		public short gxTpr_Tableroid
		{
			get {
				return gxTv_SdtIntercalarRolTestSDT_Tableroid; 
			}
			set {
				gxTv_SdtIntercalarRolTestSDT_Tableroid = value;
				SetDirty("Tableroid");
			}
		}




		[SoapElement(ElementName="ExpectedTableroId")]
		[XmlElement(ElementName="ExpectedTableroId")]
		public short gxTpr_Expectedtableroid
		{
			get {
				return gxTv_SdtIntercalarRolTestSDT_Expectedtableroid; 
			}
			set {
				gxTv_SdtIntercalarRolTestSDT_Expectedtableroid = value;
				SetDirty("Expectedtableroid");
			}
		}




		[SoapElement(ElementName="MsgTableroId")]
		[XmlElement(ElementName="MsgTableroId")]
		public string gxTpr_Msgtableroid
		{
			get {
				return gxTv_SdtIntercalarRolTestSDT_Msgtableroid; 
			}
			set {
				gxTv_SdtIntercalarRolTestSDT_Msgtableroid = value;
				SetDirty("Msgtableroid");
			}
		}




		[SoapElement(ElementName="ParticipanteTableroId")]
		[XmlElement(ElementName="ParticipanteTableroId")]
		public short gxTpr_Participantetableroid
		{
			get {
				return gxTv_SdtIntercalarRolTestSDT_Participantetableroid; 
			}
			set {
				gxTv_SdtIntercalarRolTestSDT_Participantetableroid = value;
				SetDirty("Participantetableroid");
			}
		}




		[SoapElement(ElementName="ExpectedParticipanteTableroId")]
		[XmlElement(ElementName="ExpectedParticipanteTableroId")]
		public short gxTpr_Expectedparticipantetableroid
		{
			get {
				return gxTv_SdtIntercalarRolTestSDT_Expectedparticipantetableroid; 
			}
			set {
				gxTv_SdtIntercalarRolTestSDT_Expectedparticipantetableroid = value;
				SetDirty("Expectedparticipantetableroid");
			}
		}




		[SoapElement(ElementName="MsgParticipanteTableroId")]
		[XmlElement(ElementName="MsgParticipanteTableroId")]
		public string gxTpr_Msgparticipantetableroid
		{
			get {
				return gxTv_SdtIntercalarRolTestSDT_Msgparticipantetableroid; 
			}
			set {
				gxTv_SdtIntercalarRolTestSDT_Msgparticipantetableroid = value;
				SetDirty("Msgparticipantetableroid");
			}
		}




		[SoapElement(ElementName="rol")]
		[XmlElement(ElementName="rol")]
		public short gxTpr_Rol
		{
			get {
				return gxTv_SdtIntercalarRolTestSDT_Rol; 
			}
			set {
				gxTv_SdtIntercalarRolTestSDT_Rol = value;
				SetDirty("Rol");
			}
		}




		[SoapElement(ElementName="Expectedrol")]
		[XmlElement(ElementName="Expectedrol")]
		public short gxTpr_Expectedrol
		{
			get {
				return gxTv_SdtIntercalarRolTestSDT_Expectedrol; 
			}
			set {
				gxTv_SdtIntercalarRolTestSDT_Expectedrol = value;
				SetDirty("Expectedrol");
			}
		}




		[SoapElement(ElementName="Msgrol")]
		[XmlElement(ElementName="Msgrol")]
		public string gxTpr_Msgrol
		{
			get {
				return gxTv_SdtIntercalarRolTestSDT_Msgrol; 
			}
			set {
				gxTv_SdtIntercalarRolTestSDT_Msgrol = value;
				SetDirty("Msgrol");
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
			gxTv_SdtIntercalarRolTestSDT_Testcaseid = "";


			gxTv_SdtIntercalarRolTestSDT_Msgtableroid = "";


			gxTv_SdtIntercalarRolTestSDT_Msgparticipantetableroid = "";


			gxTv_SdtIntercalarRolTestSDT_Msgrol = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtIntercalarRolTestSDT_Testcaseid;
		 

		protected short gxTv_SdtIntercalarRolTestSDT_Tableroid;
		 

		protected short gxTv_SdtIntercalarRolTestSDT_Expectedtableroid;
		 

		protected string gxTv_SdtIntercalarRolTestSDT_Msgtableroid;
		 

		protected short gxTv_SdtIntercalarRolTestSDT_Participantetableroid;
		 

		protected short gxTv_SdtIntercalarRolTestSDT_Expectedparticipantetableroid;
		 

		protected string gxTv_SdtIntercalarRolTestSDT_Msgparticipantetableroid;
		 

		protected short gxTv_SdtIntercalarRolTestSDT_Rol;
		 

		protected short gxTv_SdtIntercalarRolTestSDT_Expectedrol;
		 

		protected string gxTv_SdtIntercalarRolTestSDT_Msgrol;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"IntercalarRolTestSDT", Namespace="ProyectoUMG")]
	public class SdtIntercalarRolTestSDT_RESTInterface : GxGenericCollectionItem<SdtIntercalarRolTestSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtIntercalarRolTestSDT_RESTInterface( ) : base()
		{	
		}

		public SdtIntercalarRolTestSDT_RESTInterface( SdtIntercalarRolTestSDT psdt ) : base(psdt)
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

		[DataMember(Name="ParticipanteTableroId", Order=4)]
		public short gxTpr_Participantetableroid
		{
			get { 
				return sdt.gxTpr_Participantetableroid;

			}
			set { 
				sdt.gxTpr_Participantetableroid = value;
			}
		}

		[DataMember(Name="ExpectedParticipanteTableroId", Order=5)]
		public short gxTpr_Expectedparticipantetableroid
		{
			get { 
				return sdt.gxTpr_Expectedparticipantetableroid;

			}
			set { 
				sdt.gxTpr_Expectedparticipantetableroid = value;
			}
		}

		[DataMember(Name="MsgParticipanteTableroId", Order=6)]
		public  string gxTpr_Msgparticipantetableroid
		{
			get { 
				return sdt.gxTpr_Msgparticipantetableroid;

			}
			set { 
				 sdt.gxTpr_Msgparticipantetableroid = value;
			}
		}

		[DataMember(Name="rol", Order=7)]
		public short gxTpr_Rol
		{
			get { 
				return sdt.gxTpr_Rol;

			}
			set { 
				sdt.gxTpr_Rol = value;
			}
		}

		[DataMember(Name="Expectedrol", Order=8)]
		public short gxTpr_Expectedrol
		{
			get { 
				return sdt.gxTpr_Expectedrol;

			}
			set { 
				sdt.gxTpr_Expectedrol = value;
			}
		}

		[DataMember(Name="Msgrol", Order=9)]
		public  string gxTpr_Msgrol
		{
			get { 
				return sdt.gxTpr_Msgrol;

			}
			set { 
				 sdt.gxTpr_Msgrol = value;
			}
		}


		#endregion

		public SdtIntercalarRolTestSDT sdt
		{
			get { 
				return (SdtIntercalarRolTestSDT)Sdt;
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
				sdt = new SdtIntercalarRolTestSDT() ;
			}
		}
	}
	#endregion
}