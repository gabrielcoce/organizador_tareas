/*
				   File: type_SdtParticipantesGrid
			Description: ParticipantesGrid
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
	[XmlRoot(ElementName="ParticipantesGrid")]
	[XmlType(TypeName="ParticipantesGrid" , Namespace="ProyectoUMG" )]
	[Serializable]
	public class SdtParticipantesGrid : GxUserType
	{
		public SdtParticipantesGrid( )
		{
			/* Constructor for serialization */
			gxTv_SdtParticipantesGrid_Participanteemail = "";

			gxTv_SdtParticipantesGrid_Participanteicono = "";
			gxTv_SdtParticipantesGrid_Participanteicono_gxi = "";
		}

		public SdtParticipantesGrid(IGxContext context)
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
			AddObjectProperty("ParticipanteId", gxTpr_Participanteid, false);


			AddObjectProperty("ParticipanteEmail", gxTpr_Participanteemail, false);


			AddObjectProperty("ParticipanteExterno", gxTpr_Participanteexterno, false);


			AddObjectProperty("ParticipanteIcono", gxTpr_Participanteicono, false);
			AddObjectProperty("ParticipanteIcono_GXI", gxTpr_Participanteicono_gxi, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ParticipanteId")]
		[XmlElement(ElementName="ParticipanteId")]
		public long gxTpr_Participanteid
		{
			get {
				return gxTv_SdtParticipantesGrid_Participanteid; 
			}
			set {
				gxTv_SdtParticipantesGrid_Participanteid = value;
				SetDirty("Participanteid");
			}
		}




		[SoapElement(ElementName="ParticipanteEmail")]
		[XmlElement(ElementName="ParticipanteEmail")]
		public string gxTpr_Participanteemail
		{
			get {
				return gxTv_SdtParticipantesGrid_Participanteemail; 
			}
			set {
				gxTv_SdtParticipantesGrid_Participanteemail = value;
				SetDirty("Participanteemail");
			}
		}




		[SoapElement(ElementName="ParticipanteExterno")]
		[XmlElement(ElementName="ParticipanteExterno")]
		public bool gxTpr_Participanteexterno
		{
			get {
				return gxTv_SdtParticipantesGrid_Participanteexterno; 
			}
			set {
				gxTv_SdtParticipantesGrid_Participanteexterno = value;
				SetDirty("Participanteexterno");
			}
		}




		[SoapElement(ElementName="ParticipanteIcono")]
		[XmlElement(ElementName="ParticipanteIcono")]
		[GxUpload()]

		public string gxTpr_Participanteicono
		{
			get {
				return gxTv_SdtParticipantesGrid_Participanteicono; 
			}
			set {
				gxTv_SdtParticipantesGrid_Participanteicono = value;
				SetDirty("Participanteicono");
			}
		}


		[SoapElement(ElementName="ParticipanteIcono_GXI" )]
		[XmlElement(ElementName="ParticipanteIcono_GXI" )]
		public string gxTpr_Participanteicono_gxi
		{
			get {
				return gxTv_SdtParticipantesGrid_Participanteicono_gxi ;
			}
			set {
				gxTv_SdtParticipantesGrid_Participanteicono_gxi = value;
				SetDirty("Participanteicono_gxi");
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
			gxTv_SdtParticipantesGrid_Participanteemail = "";

			gxTv_SdtParticipantesGrid_Participanteicono = "";gxTv_SdtParticipantesGrid_Participanteicono_gxi = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtParticipantesGrid_Participanteid;
		 

		protected string gxTv_SdtParticipantesGrid_Participanteemail;
		 

		protected bool gxTv_SdtParticipantesGrid_Participanteexterno;
		 
		protected string gxTv_SdtParticipantesGrid_Participanteicono_gxi;
		protected string gxTv_SdtParticipantesGrid_Participanteicono;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"ParticipantesGrid", Namespace="ProyectoUMG")]
	public class SdtParticipantesGrid_RESTInterface : GxGenericCollectionItem<SdtParticipantesGrid>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtParticipantesGrid_RESTInterface( ) : base()
		{	
		}

		public SdtParticipantesGrid_RESTInterface( SdtParticipantesGrid psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ParticipanteId", Order=0)]
		public  string gxTpr_Participanteid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Participanteid, 10, 0));

			}
			set { 
				sdt.gxTpr_Participanteid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ParticipanteEmail", Order=1)]
		public  string gxTpr_Participanteemail
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Participanteemail);

			}
			set { 
				 sdt.gxTpr_Participanteemail = value;
			}
		}

		[DataMember(Name="ParticipanteExterno", Order=2)]
		public bool gxTpr_Participanteexterno
		{
			get { 
				return sdt.gxTpr_Participanteexterno;

			}
			set { 
				sdt.gxTpr_Participanteexterno = value;
			}
		}

		[DataMember(Name="ParticipanteIcono", Order=3)]
		[GxUpload()]
		public  string gxTpr_Participanteicono
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Participanteicono)) ? PathUtil.RelativePath( sdt.gxTpr_Participanteicono) : StringUtil.RTrim( sdt.gxTpr_Participanteicono_gxi));

			}
			set { 
				 sdt.gxTpr_Participanteicono = value;
			}
		}


		#endregion

		public SdtParticipantesGrid sdt
		{
			get { 
				return (SdtParticipantesGrid)Sdt;
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
				sdt = new SdtParticipantesGrid() ;
			}
		}
	}
	#endregion
}