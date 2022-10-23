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
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gxdomainsw_position
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainsw_position ()
      {
         domain["top"] = "top";
         domain["top-start"] = "top_start";
         domain["top-end"] = "top_end";
         domain["center"] = "center";
         domain["center-start"] = "center_start";
         domain["center-end"] = "center_end";
         domain["bottom"] = "bottom";
         domain["bottom-start"] = "bottom_start";
         domain["bottom-end"] = "bottom_end";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["top"] = "top";
            domainMap["top_start"] = "top-start";
            domainMap["top_end"] = "top-end";
            domainMap["center"] = "center";
            domainMap["center_start"] = "center-start";
            domainMap["center_end"] = "center-end";
            domainMap["bottom"] = "bottom";
            domainMap["bottom_start"] = "bottom-start";
            domainMap["bottom_end"] = "bottom-end";
         }
         return (string)domainMap[key] ;
      }

   }

}
