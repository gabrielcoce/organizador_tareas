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
   public class gxdomainhtmlelements
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainhtmlelements ()
      {
         domain["<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>"] = "Input de texto deshabilitado";
         domain["<br><p class=\"text-center\" style=\"font-family:titillium web,arial; font-size:3em; color:#21262c !important;\"><strong>$</strong></p>"] = "PageTitle";
         domain["<br><p class=\"text-center\" style=\"font-family:titillium web,arial; font-size:1.5em; color:#21262c !important;\"><strong>$</strong></p>"] = "PageSubTitle";
         domain["<center><div id=\"bm\" style=\"width:300px;\"> </div></center><script>var animation = bodymovin.loadAnimation({container: document.getElementById('bm'), renderer: 'svg', loop: false, autoplay: true, path: '#LOTTIE'})</script>"] = "Icono con animación";
         domain["<canvas id=\"#DATAID\" width=\"500\" height=\"500\" style=\"display: block; box-sizing: border-box; height: 500px; width: 500px;\"></canvas><script>const ctx = document.getElementById('#DATAID');const myChart = new Chart(ctx, {type: 'bar',data: {labels: [#DATASET],datasets: [{label: '#DATATITLE',data: [#DATAVALUE],backgroundColor: [#DATACOLORS],borderColor: [#DATABORDERCOLORS],borderWidth: 1}]},options: {scales: {y: {beginAtZero: true}}}});</script>"] = "Chart Bar";
         domain["<div class=\"widget-user-header bg-info\"><h3 class=\"widget-user-username\">#TAREA</h3><h5 class=\"widget-user-desc\">#RESPONSABLE</h5></div>"] = "Titulo de tarea";
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
            domainMap["InputDisabled"] = "<div class=\"col-12\"><div class=\"form-group\" style=\"margin-left:2px;margin-top:2px;margin-right:2px;\"><label>#LABEL</label><input type=\"text\" class=\"form-control\" value=\"#VALUE\" disabled></div></div>";
            domainMap["PageTitle"] = "<br><p class=\"text-center\" style=\"font-family:titillium web,arial; font-size:3em; color:#21262c !important;\"><strong>$</strong></p>";
            domainMap["PageSubTitle"] = "<br><p class=\"text-center\" style=\"font-family:titillium web,arial; font-size:1.5em; color:#21262c !important;\"><strong>$</strong></p>";
            domainMap["Lottie"] = "<center><div id=\"bm\" style=\"width:300px;\"> </div></center><script>var animation = bodymovin.loadAnimation({container: document.getElementById('bm'), renderer: 'svg', loop: false, autoplay: true, path: '#LOTTIE'})</script>";
            domainMap["ChartBar"] = "<canvas id=\"#DATAID\" width=\"500\" height=\"500\" style=\"display: block; box-sizing: border-box; height: 500px; width: 500px;\"></canvas><script>const ctx = document.getElementById('#DATAID');const myChart = new Chart(ctx, {type: 'bar',data: {labels: [#DATASET],datasets: [{label: '#DATATITLE',data: [#DATAVALUE],backgroundColor: [#DATACOLORS],borderColor: [#DATABORDERCOLORS],borderWidth: 1}]},options: {scales: {y: {beginAtZero: true}}}});</script>";
            domainMap["TituloTarea"] = "<div class=\"widget-user-header bg-info\"><h3 class=\"widget-user-username\">#TAREA</h3><h5 class=\"widget-user-desc\">#RESPONSABLE</h5></div>";
         }
         return (string)domainMap[key] ;
      }

   }

}
