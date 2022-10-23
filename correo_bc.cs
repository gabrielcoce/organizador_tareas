using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class correo_bc : GXHttpHandler, IGxSilentTrn
   {
      public correo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public correo_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0C13( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0C13( ) ;
         standaloneModal( ) ;
         AddRow0C13( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z50CorreoId = A50CorreoId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C13( ) ;
            }
            else
            {
               CheckExtendedTable0C13( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0C13( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0C13( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z51CorreoIdentificador = A51CorreoIdentificador;
            Z52CorreoNombre = A52CorreoNombre;
            Z53CorreoServidor = A53CorreoServidor;
            Z54CorreoPuerto = A54CorreoPuerto;
            Z55CorreoUsuario = A55CorreoUsuario;
            Z56CorreoContrasena = A56CorreoContrasena;
         }
         if ( GX_JID == -2 )
         {
            Z50CorreoId = A50CorreoId;
            Z51CorreoIdentificador = A51CorreoIdentificador;
            Z52CorreoNombre = A52CorreoNombre;
            Z53CorreoServidor = A53CorreoServidor;
            Z54CorreoPuerto = A54CorreoPuerto;
            Z55CorreoUsuario = A55CorreoUsuario;
            Z56CorreoContrasena = A56CorreoContrasena;
            Z57CorreoPlantilla = A57CorreoPlantilla;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0C13( )
      {
         /* Using cursor BC000C4 */
         pr_default.execute(2, new Object[] {A50CorreoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound13 = 1;
            A51CorreoIdentificador = BC000C4_A51CorreoIdentificador[0];
            A52CorreoNombre = BC000C4_A52CorreoNombre[0];
            A53CorreoServidor = BC000C4_A53CorreoServidor[0];
            A54CorreoPuerto = BC000C4_A54CorreoPuerto[0];
            A55CorreoUsuario = BC000C4_A55CorreoUsuario[0];
            A56CorreoContrasena = BC000C4_A56CorreoContrasena[0];
            A57CorreoPlantilla = BC000C4_A57CorreoPlantilla[0];
            n57CorreoPlantilla = BC000C4_n57CorreoPlantilla[0];
            ZM0C13( -2) ;
         }
         pr_default.close(2);
         OnLoadActions0C13( ) ;
      }

      protected void OnLoadActions0C13( )
      {
      }

      protected void CheckExtendedTable0C13( )
      {
         nIsDirty_13 = 0;
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A55CorreoUsuario,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de Correo Usuario no coincide con el patrón especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0C13( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C13( )
      {
         /* Using cursor BC000C5 */
         pr_default.execute(3, new Object[] {A50CorreoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000C3 */
         pr_default.execute(1, new Object[] {A50CorreoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C13( 2) ;
            RcdFound13 = 1;
            A50CorreoId = BC000C3_A50CorreoId[0];
            A51CorreoIdentificador = BC000C3_A51CorreoIdentificador[0];
            A52CorreoNombre = BC000C3_A52CorreoNombre[0];
            A53CorreoServidor = BC000C3_A53CorreoServidor[0];
            A54CorreoPuerto = BC000C3_A54CorreoPuerto[0];
            A55CorreoUsuario = BC000C3_A55CorreoUsuario[0];
            A56CorreoContrasena = BC000C3_A56CorreoContrasena[0];
            A57CorreoPlantilla = BC000C3_A57CorreoPlantilla[0];
            n57CorreoPlantilla = BC000C3_n57CorreoPlantilla[0];
            Z50CorreoId = A50CorreoId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0C13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0C13( ) ;
            }
            Gx_mode = sMode13;
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0C13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode13;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0C0( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0C13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000C2 */
            pr_default.execute(0, new Object[] {A50CorreoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Correo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z51CorreoIdentificador, BC000C2_A51CorreoIdentificador[0]) != 0 ) || ( StringUtil.StrCmp(Z52CorreoNombre, BC000C2_A52CorreoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z53CorreoServidor, BC000C2_A53CorreoServidor[0]) != 0 ) || ( Z54CorreoPuerto != BC000C2_A54CorreoPuerto[0] ) || ( StringUtil.StrCmp(Z55CorreoUsuario, BC000C2_A55CorreoUsuario[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z56CorreoContrasena, BC000C2_A56CorreoContrasena[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Correo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C13( 0) ;
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C6 */
                     pr_default.execute(4, new Object[] {A51CorreoIdentificador, A52CorreoNombre, A53CorreoServidor, A54CorreoPuerto, A55CorreoUsuario, A56CorreoContrasena, n57CorreoPlantilla, A57CorreoPlantilla});
                     A50CorreoId = BC000C6_A50CorreoId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("Correo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0C13( ) ;
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void Update0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C7 */
                     pr_default.execute(5, new Object[] {A51CorreoIdentificador, A52CorreoNombre, A53CorreoServidor, A54CorreoPuerto, A55CorreoUsuario, A56CorreoContrasena, n57CorreoPlantilla, A57CorreoPlantilla, A50CorreoId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Correo");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Correo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void DeferredUpdate0C13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C13( ) ;
            AfterConfirm0C13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000C8 */
                  pr_default.execute(6, new Object[] {A50CorreoId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("Correo");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0C13( ) ;
         Gx_mode = sMode13;
      }

      protected void OnDeleteControls0C13( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0C13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0C13( )
      {
         /* Using cursor BC000C9 */
         pr_default.execute(7, new Object[] {A50CorreoId});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound13 = 1;
            A50CorreoId = BC000C9_A50CorreoId[0];
            A51CorreoIdentificador = BC000C9_A51CorreoIdentificador[0];
            A52CorreoNombre = BC000C9_A52CorreoNombre[0];
            A53CorreoServidor = BC000C9_A53CorreoServidor[0];
            A54CorreoPuerto = BC000C9_A54CorreoPuerto[0];
            A55CorreoUsuario = BC000C9_A55CorreoUsuario[0];
            A56CorreoContrasena = BC000C9_A56CorreoContrasena[0];
            A57CorreoPlantilla = BC000C9_A57CorreoPlantilla[0];
            n57CorreoPlantilla = BC000C9_n57CorreoPlantilla[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0C13( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound13 = 0;
         ScanKeyLoad0C13( ) ;
      }

      protected void ScanKeyLoad0C13( )
      {
         sMode13 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound13 = 1;
            A50CorreoId = BC000C9_A50CorreoId[0];
            A51CorreoIdentificador = BC000C9_A51CorreoIdentificador[0];
            A52CorreoNombre = BC000C9_A52CorreoNombre[0];
            A53CorreoServidor = BC000C9_A53CorreoServidor[0];
            A54CorreoPuerto = BC000C9_A54CorreoPuerto[0];
            A55CorreoUsuario = BC000C9_A55CorreoUsuario[0];
            A56CorreoContrasena = BC000C9_A56CorreoContrasena[0];
            A57CorreoPlantilla = BC000C9_A57CorreoPlantilla[0];
            n57CorreoPlantilla = BC000C9_n57CorreoPlantilla[0];
         }
         Gx_mode = sMode13;
      }

      protected void ScanKeyEnd0C13( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0C13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C13( )
      {
      }

      protected void send_integrity_lvl_hashes0C13( )
      {
      }

      protected void AddRow0C13( )
      {
         VarsToRow13( bcCorreo) ;
      }

      protected void ReadRow0C13( )
      {
         RowToVars13( bcCorreo, 1) ;
      }

      protected void InitializeNonKey0C13( )
      {
         A51CorreoIdentificador = "";
         A52CorreoNombre = "";
         A53CorreoServidor = "";
         A54CorreoPuerto = 0;
         A55CorreoUsuario = "";
         A56CorreoContrasena = "";
         A57CorreoPlantilla = "";
         n57CorreoPlantilla = false;
         Z51CorreoIdentificador = "";
         Z52CorreoNombre = "";
         Z53CorreoServidor = "";
         Z54CorreoPuerto = 0;
         Z55CorreoUsuario = "";
         Z56CorreoContrasena = "";
      }

      protected void InitAll0C13( )
      {
         A50CorreoId = 0;
         InitializeNonKey0C13( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow13( SdtCorreo obj13 )
      {
         obj13.gxTpr_Mode = Gx_mode;
         obj13.gxTpr_Correoidentificador = A51CorreoIdentificador;
         obj13.gxTpr_Correonombre = A52CorreoNombre;
         obj13.gxTpr_Correoservidor = A53CorreoServidor;
         obj13.gxTpr_Correopuerto = A54CorreoPuerto;
         obj13.gxTpr_Correousuario = A55CorreoUsuario;
         obj13.gxTpr_Correocontrasena = A56CorreoContrasena;
         obj13.gxTpr_Correoplantilla = A57CorreoPlantilla;
         obj13.gxTpr_Correoid = A50CorreoId;
         obj13.gxTpr_Correoid_Z = Z50CorreoId;
         obj13.gxTpr_Correoidentificador_Z = Z51CorreoIdentificador;
         obj13.gxTpr_Correonombre_Z = Z52CorreoNombre;
         obj13.gxTpr_Correoservidor_Z = Z53CorreoServidor;
         obj13.gxTpr_Correopuerto_Z = Z54CorreoPuerto;
         obj13.gxTpr_Correousuario_Z = Z55CorreoUsuario;
         obj13.gxTpr_Correocontrasena_Z = Z56CorreoContrasena;
         obj13.gxTpr_Correoplantilla_N = (short)(Convert.ToInt16(n57CorreoPlantilla));
         obj13.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow13( SdtCorreo obj13 )
      {
         obj13.gxTpr_Correoid = A50CorreoId;
         return  ;
      }

      public void RowToVars13( SdtCorreo obj13 ,
                               int forceLoad )
      {
         Gx_mode = obj13.gxTpr_Mode;
         A51CorreoIdentificador = obj13.gxTpr_Correoidentificador;
         A52CorreoNombre = obj13.gxTpr_Correonombre;
         A53CorreoServidor = obj13.gxTpr_Correoservidor;
         A54CorreoPuerto = obj13.gxTpr_Correopuerto;
         A55CorreoUsuario = obj13.gxTpr_Correousuario;
         A56CorreoContrasena = obj13.gxTpr_Correocontrasena;
         A57CorreoPlantilla = obj13.gxTpr_Correoplantilla;
         n57CorreoPlantilla = false;
         A50CorreoId = obj13.gxTpr_Correoid;
         Z50CorreoId = obj13.gxTpr_Correoid_Z;
         Z51CorreoIdentificador = obj13.gxTpr_Correoidentificador_Z;
         Z52CorreoNombre = obj13.gxTpr_Correonombre_Z;
         Z53CorreoServidor = obj13.gxTpr_Correoservidor_Z;
         Z54CorreoPuerto = obj13.gxTpr_Correopuerto_Z;
         Z55CorreoUsuario = obj13.gxTpr_Correousuario_Z;
         Z56CorreoContrasena = obj13.gxTpr_Correocontrasena_Z;
         n57CorreoPlantilla = (bool)(Convert.ToBoolean(obj13.gxTpr_Correoplantilla_N));
         Gx_mode = obj13.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A50CorreoId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0C13( ) ;
         ScanKeyStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z50CorreoId = A50CorreoId;
         }
         ZM0C13( -2) ;
         OnLoadActions0C13( ) ;
         AddRow0C13( ) ;
         ScanKeyEnd0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars13( bcCorreo, 0) ;
         ScanKeyStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z50CorreoId = A50CorreoId;
         }
         ZM0C13( -2) ;
         OnLoadActions0C13( ) ;
         AddRow0C13( ) ;
         ScanKeyEnd0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0C13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0C13( ) ;
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A50CorreoId != Z50CorreoId )
               {
                  A50CorreoId = Z50CorreoId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0C13( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A50CorreoId != Z50CorreoId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0C13( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0C13( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars13( bcCorreo, 1) ;
         SaveImpl( ) ;
         VarsToRow13( bcCorreo) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars13( bcCorreo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C13( ) ;
         AfterTrn( ) ;
         VarsToRow13( bcCorreo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            SdtCorreo auxBC = new SdtCorreo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A50CorreoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCorreo);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars13( bcCorreo, 1) ;
         UpdateImpl( ) ;
         VarsToRow13( bcCorreo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars13( bcCorreo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C13( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow13( bcCorreo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars13( bcCorreo, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0C13( ) ;
         if ( RcdFound13 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A50CorreoId != Z50CorreoId )
            {
               A50CorreoId = Z50CorreoId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A50CorreoId != Z50CorreoId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         context.RollbackDataStores("correo_bc",pr_default);
         VarsToRow13( bcCorreo) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcCorreo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCorreo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCorreo )
         {
            bcCorreo = (SdtCorreo)(sdt);
            if ( StringUtil.StrCmp(bcCorreo.gxTpr_Mode, "") == 0 )
            {
               bcCorreo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow13( bcCorreo) ;
            }
            else
            {
               RowToVars13( bcCorreo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCorreo.gxTpr_Mode, "") == 0 )
            {
               bcCorreo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars13( bcCorreo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtCorreo Correo_BC
      {
         get {
            return bcCorreo ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z51CorreoIdentificador = "";
         A51CorreoIdentificador = "";
         Z52CorreoNombre = "";
         A52CorreoNombre = "";
         Z53CorreoServidor = "";
         A53CorreoServidor = "";
         Z55CorreoUsuario = "";
         A55CorreoUsuario = "";
         Z56CorreoContrasena = "";
         A56CorreoContrasena = "";
         Z57CorreoPlantilla = "";
         A57CorreoPlantilla = "";
         BC000C4_A50CorreoId = new short[1] ;
         BC000C4_A51CorreoIdentificador = new string[] {""} ;
         BC000C4_A52CorreoNombre = new string[] {""} ;
         BC000C4_A53CorreoServidor = new string[] {""} ;
         BC000C4_A54CorreoPuerto = new short[1] ;
         BC000C4_A55CorreoUsuario = new string[] {""} ;
         BC000C4_A56CorreoContrasena = new string[] {""} ;
         BC000C4_A57CorreoPlantilla = new string[] {""} ;
         BC000C4_n57CorreoPlantilla = new bool[] {false} ;
         BC000C5_A50CorreoId = new short[1] ;
         BC000C3_A50CorreoId = new short[1] ;
         BC000C3_A51CorreoIdentificador = new string[] {""} ;
         BC000C3_A52CorreoNombre = new string[] {""} ;
         BC000C3_A53CorreoServidor = new string[] {""} ;
         BC000C3_A54CorreoPuerto = new short[1] ;
         BC000C3_A55CorreoUsuario = new string[] {""} ;
         BC000C3_A56CorreoContrasena = new string[] {""} ;
         BC000C3_A57CorreoPlantilla = new string[] {""} ;
         BC000C3_n57CorreoPlantilla = new bool[] {false} ;
         sMode13 = "";
         BC000C2_A50CorreoId = new short[1] ;
         BC000C2_A51CorreoIdentificador = new string[] {""} ;
         BC000C2_A52CorreoNombre = new string[] {""} ;
         BC000C2_A53CorreoServidor = new string[] {""} ;
         BC000C2_A54CorreoPuerto = new short[1] ;
         BC000C2_A55CorreoUsuario = new string[] {""} ;
         BC000C2_A56CorreoContrasena = new string[] {""} ;
         BC000C2_A57CorreoPlantilla = new string[] {""} ;
         BC000C2_n57CorreoPlantilla = new bool[] {false} ;
         BC000C6_A50CorreoId = new short[1] ;
         BC000C9_A50CorreoId = new short[1] ;
         BC000C9_A51CorreoIdentificador = new string[] {""} ;
         BC000C9_A52CorreoNombre = new string[] {""} ;
         BC000C9_A53CorreoServidor = new string[] {""} ;
         BC000C9_A54CorreoPuerto = new short[1] ;
         BC000C9_A55CorreoUsuario = new string[] {""} ;
         BC000C9_A56CorreoContrasena = new string[] {""} ;
         BC000C9_A57CorreoPlantilla = new string[] {""} ;
         BC000C9_n57CorreoPlantilla = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.correo_bc__default(),
            new Object[][] {
                new Object[] {
               BC000C2_A50CorreoId, BC000C2_A51CorreoIdentificador, BC000C2_A52CorreoNombre, BC000C2_A53CorreoServidor, BC000C2_A54CorreoPuerto, BC000C2_A55CorreoUsuario, BC000C2_A56CorreoContrasena, BC000C2_A57CorreoPlantilla, BC000C2_n57CorreoPlantilla
               }
               , new Object[] {
               BC000C3_A50CorreoId, BC000C3_A51CorreoIdentificador, BC000C3_A52CorreoNombre, BC000C3_A53CorreoServidor, BC000C3_A54CorreoPuerto, BC000C3_A55CorreoUsuario, BC000C3_A56CorreoContrasena, BC000C3_A57CorreoPlantilla, BC000C3_n57CorreoPlantilla
               }
               , new Object[] {
               BC000C4_A50CorreoId, BC000C4_A51CorreoIdentificador, BC000C4_A52CorreoNombre, BC000C4_A53CorreoServidor, BC000C4_A54CorreoPuerto, BC000C4_A55CorreoUsuario, BC000C4_A56CorreoContrasena, BC000C4_A57CorreoPlantilla, BC000C4_n57CorreoPlantilla
               }
               , new Object[] {
               BC000C5_A50CorreoId
               }
               , new Object[] {
               BC000C6_A50CorreoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C9_A50CorreoId, BC000C9_A51CorreoIdentificador, BC000C9_A52CorreoNombre, BC000C9_A53CorreoServidor, BC000C9_A54CorreoPuerto, BC000C9_A55CorreoUsuario, BC000C9_A56CorreoContrasena, BC000C9_A57CorreoPlantilla, BC000C9_n57CorreoPlantilla
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z50CorreoId ;
      private short A50CorreoId ;
      private short GX_JID ;
      private short Z54CorreoPuerto ;
      private short A54CorreoPuerto ;
      private short RcdFound13 ;
      private short nIsDirty_13 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z51CorreoIdentificador ;
      private string A51CorreoIdentificador ;
      private string Z52CorreoNombre ;
      private string A52CorreoNombre ;
      private string Z53CorreoServidor ;
      private string A53CorreoServidor ;
      private string Z56CorreoContrasena ;
      private string A56CorreoContrasena ;
      private string sMode13 ;
      private bool n57CorreoPlantilla ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z57CorreoPlantilla ;
      private string A57CorreoPlantilla ;
      private string Z55CorreoUsuario ;
      private string A55CorreoUsuario ;
      private SdtCorreo bcCorreo ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000C4_A50CorreoId ;
      private string[] BC000C4_A51CorreoIdentificador ;
      private string[] BC000C4_A52CorreoNombre ;
      private string[] BC000C4_A53CorreoServidor ;
      private short[] BC000C4_A54CorreoPuerto ;
      private string[] BC000C4_A55CorreoUsuario ;
      private string[] BC000C4_A56CorreoContrasena ;
      private string[] BC000C4_A57CorreoPlantilla ;
      private bool[] BC000C4_n57CorreoPlantilla ;
      private short[] BC000C5_A50CorreoId ;
      private short[] BC000C3_A50CorreoId ;
      private string[] BC000C3_A51CorreoIdentificador ;
      private string[] BC000C3_A52CorreoNombre ;
      private string[] BC000C3_A53CorreoServidor ;
      private short[] BC000C3_A54CorreoPuerto ;
      private string[] BC000C3_A55CorreoUsuario ;
      private string[] BC000C3_A56CorreoContrasena ;
      private string[] BC000C3_A57CorreoPlantilla ;
      private bool[] BC000C3_n57CorreoPlantilla ;
      private short[] BC000C2_A50CorreoId ;
      private string[] BC000C2_A51CorreoIdentificador ;
      private string[] BC000C2_A52CorreoNombre ;
      private string[] BC000C2_A53CorreoServidor ;
      private short[] BC000C2_A54CorreoPuerto ;
      private string[] BC000C2_A55CorreoUsuario ;
      private string[] BC000C2_A56CorreoContrasena ;
      private string[] BC000C2_A57CorreoPlantilla ;
      private bool[] BC000C2_n57CorreoPlantilla ;
      private short[] BC000C6_A50CorreoId ;
      private short[] BC000C9_A50CorreoId ;
      private string[] BC000C9_A51CorreoIdentificador ;
      private string[] BC000C9_A52CorreoNombre ;
      private string[] BC000C9_A53CorreoServidor ;
      private short[] BC000C9_A54CorreoPuerto ;
      private string[] BC000C9_A55CorreoUsuario ;
      private string[] BC000C9_A56CorreoContrasena ;
      private string[] BC000C9_A57CorreoPlantilla ;
      private bool[] BC000C9_n57CorreoPlantilla ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class correo_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000C4;
          prmBC000C4 = new Object[] {
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmBC000C5;
          prmBC000C5 = new Object[] {
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmBC000C3;
          prmBC000C3 = new Object[] {
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmBC000C2;
          prmBC000C2 = new Object[] {
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmBC000C6;
          prmBC000C6 = new Object[] {
          new ParDef("@CorreoIdentificador",GXType.NChar,20,0) ,
          new ParDef("@CorreoNombre",GXType.NChar,20,0) ,
          new ParDef("@CorreoServidor",GXType.NChar,22,0) ,
          new ParDef("@CorreoPuerto",GXType.Int16,4,0) ,
          new ParDef("@CorreoUsuario",GXType.NVarChar,100,0) ,
          new ParDef("@CorreoContrasena",GXType.NChar,20,0) ,
          new ParDef("@CorreoPlantilla",GXType.NVarChar,2097152,0){Nullable=true}
          };
          Object[] prmBC000C7;
          prmBC000C7 = new Object[] {
          new ParDef("@CorreoIdentificador",GXType.NChar,20,0) ,
          new ParDef("@CorreoNombre",GXType.NChar,20,0) ,
          new ParDef("@CorreoServidor",GXType.NChar,22,0) ,
          new ParDef("@CorreoPuerto",GXType.Int16,4,0) ,
          new ParDef("@CorreoUsuario",GXType.NVarChar,100,0) ,
          new ParDef("@CorreoContrasena",GXType.NChar,20,0) ,
          new ParDef("@CorreoPlantilla",GXType.NVarChar,2097152,0){Nullable=true} ,
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmBC000C8;
          prmBC000C8 = new Object[] {
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          Object[] prmBC000C9;
          prmBC000C9 = new Object[] {
          new ParDef("@CorreoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000C2", "SELECT [CorreoId], [CorreoIdentificador], [CorreoNombre], [CorreoServidor], [CorreoPuerto], [CorreoUsuario], [CorreoContrasena], [CorreoPlantilla] FROM [Correo] WITH (UPDLOCK) WHERE [CorreoId] = @CorreoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C3", "SELECT [CorreoId], [CorreoIdentificador], [CorreoNombre], [CorreoServidor], [CorreoPuerto], [CorreoUsuario], [CorreoContrasena], [CorreoPlantilla] FROM [Correo] WHERE [CorreoId] = @CorreoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C4", "SELECT TM1.[CorreoId], TM1.[CorreoIdentificador], TM1.[CorreoNombre], TM1.[CorreoServidor], TM1.[CorreoPuerto], TM1.[CorreoUsuario], TM1.[CorreoContrasena], TM1.[CorreoPlantilla] FROM [Correo] TM1 WHERE TM1.[CorreoId] = @CorreoId ORDER BY TM1.[CorreoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C5", "SELECT [CorreoId] FROM [Correo] WHERE [CorreoId] = @CorreoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C6", "INSERT INTO [Correo]([CorreoIdentificador], [CorreoNombre], [CorreoServidor], [CorreoPuerto], [CorreoUsuario], [CorreoContrasena], [CorreoPlantilla]) VALUES(@CorreoIdentificador, @CorreoNombre, @CorreoServidor, @CorreoPuerto, @CorreoUsuario, @CorreoContrasena, @CorreoPlantilla); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000C7", "UPDATE [Correo] SET [CorreoIdentificador]=@CorreoIdentificador, [CorreoNombre]=@CorreoNombre, [CorreoServidor]=@CorreoServidor, [CorreoPuerto]=@CorreoPuerto, [CorreoUsuario]=@CorreoUsuario, [CorreoContrasena]=@CorreoContrasena, [CorreoPlantilla]=@CorreoPlantilla  WHERE [CorreoId] = @CorreoId", GxErrorMask.GX_NOMASK,prmBC000C7)
             ,new CursorDef("BC000C8", "DELETE FROM [Correo]  WHERE [CorreoId] = @CorreoId", GxErrorMask.GX_NOMASK,prmBC000C8)
             ,new CursorDef("BC000C9", "SELECT TM1.[CorreoId], TM1.[CorreoIdentificador], TM1.[CorreoNombre], TM1.[CorreoServidor], TM1.[CorreoPuerto], TM1.[CorreoUsuario], TM1.[CorreoContrasena], TM1.[CorreoPlantilla] FROM [Correo] TM1 WHERE TM1.[CorreoId] = @CorreoId ORDER BY TM1.[CorreoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C9,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 22);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 22);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 22);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 22);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
