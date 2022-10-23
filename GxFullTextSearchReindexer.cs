using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class GxFullTextSearchReindexer
   {
      public static int Reindex( IGxContext context )
      {
         GxSilentTrnSdt obj;
         IGxSilentTrn trn;
         bool result;
         obj = new SdtRoles(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtTareas(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtUsuarios(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtTableros(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtParticipantes(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtTareasComentarios(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtActividades(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtTablerosEtiquetas(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtInvitados(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtCorreo(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         return 1 ;
      }

   }

}
