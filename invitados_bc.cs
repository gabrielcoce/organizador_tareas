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
   public class invitados_bc : GXHttpHandler, IGxSilentTrn
   {
      public invitados_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public invitados_bc( IGxContext context )
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
         ReadRow0B12( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0B12( ) ;
         standaloneModal( ) ;
         AddRow0B12( ) ;
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
               Z9TableroId = A9TableroId;
               Z40RegistroInvitadoId = A40RegistroInvitadoId;
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B12( ) ;
            }
            else
            {
               CheckExtendedTable0B12( ) ;
               if ( AnyError == 0 )
               {
                  ZM0B12( 4) ;
                  ZM0B12( 5) ;
               }
               CloseExtendedTableCursors0B12( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0B12( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z43RegistroInvitadoUsuario = A43RegistroInvitadoUsuario;
            Z44RegistroInvitadoEmail = A44RegistroInvitadoEmail;
            Z45RegistroInvitadoFecha = A45RegistroInvitadoFecha;
            Z41InvitadoRolId = A41InvitadoRolId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -3 )
         {
            Z40RegistroInvitadoId = A40RegistroInvitadoId;
            Z43RegistroInvitadoUsuario = A43RegistroInvitadoUsuario;
            Z44RegistroInvitadoEmail = A44RegistroInvitadoEmail;
            Z45RegistroInvitadoFecha = A45RegistroInvitadoFecha;
            Z9TableroId = A9TableroId;
            Z41InvitadoRolId = A41InvitadoRolId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0B12( )
      {
         /* Using cursor BC000B6 */
         pr_default.execute(4, new Object[] {A9TableroId, A40RegistroInvitadoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound12 = 1;
            A43RegistroInvitadoUsuario = BC000B6_A43RegistroInvitadoUsuario[0];
            A44RegistroInvitadoEmail = BC000B6_A44RegistroInvitadoEmail[0];
            A45RegistroInvitadoFecha = BC000B6_A45RegistroInvitadoFecha[0];
            A41InvitadoRolId = BC000B6_A41InvitadoRolId[0];
            ZM0B12( -3) ;
         }
         pr_default.close(4);
         OnLoadActions0B12( ) ;
      }

      protected void OnLoadActions0B12( )
      {
      }

      protected void CheckExtendedTable0B12( )
      {
         nIsDirty_12 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000B4 */
         pr_default.execute(2, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A44RegistroInvitadoEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de Registro Invitado Email no coincide con el patrón especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000B5 */
         pr_default.execute(3, new Object[] {A41InvitadoRolId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Invitado Rol'.", "ForeignKeyNotFound", 1, "INVITADOROLID");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A45RegistroInvitadoFecha) || ( A45RegistroInvitadoFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Registro Invitado Fecha fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0B12( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B12( )
      {
         /* Using cursor BC000B7 */
         pr_default.execute(5, new Object[] {A9TableroId, A40RegistroInvitadoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000B3 */
         pr_default.execute(1, new Object[] {A9TableroId, A40RegistroInvitadoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B12( 3) ;
            RcdFound12 = 1;
            A40RegistroInvitadoId = BC000B3_A40RegistroInvitadoId[0];
            A43RegistroInvitadoUsuario = BC000B3_A43RegistroInvitadoUsuario[0];
            A44RegistroInvitadoEmail = BC000B3_A44RegistroInvitadoEmail[0];
            A45RegistroInvitadoFecha = BC000B3_A45RegistroInvitadoFecha[0];
            A9TableroId = BC000B3_A9TableroId[0];
            A41InvitadoRolId = BC000B3_A41InvitadoRolId[0];
            Z9TableroId = A9TableroId;
            Z40RegistroInvitadoId = A40RegistroInvitadoId;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0B12( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0B12( ) ;
            }
            Gx_mode = sMode12;
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0B12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode12;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B12( ) ;
         if ( RcdFound12 == 0 )
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
         CONFIRM_0B0( ) ;
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

      protected void CheckOptimisticConcurrency0B12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000B2 */
            pr_default.execute(0, new Object[] {A9TableroId, A40RegistroInvitadoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitados"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z43RegistroInvitadoUsuario != BC000B2_A43RegistroInvitadoUsuario[0] ) || ( StringUtil.StrCmp(Z44RegistroInvitadoEmail, BC000B2_A44RegistroInvitadoEmail[0]) != 0 ) || ( Z45RegistroInvitadoFecha != BC000B2_A45RegistroInvitadoFecha[0] ) || ( Z41InvitadoRolId != BC000B2_A41InvitadoRolId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Invitados"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B12( 0) ;
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B8 */
                     pr_default.execute(6, new Object[] {A40RegistroInvitadoId, A43RegistroInvitadoUsuario, A44RegistroInvitadoEmail, A45RegistroInvitadoFecha, A9TableroId, A41InvitadoRolId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Invitados");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
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
               Load0B12( ) ;
            }
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void Update0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B9 */
                     pr_default.execute(7, new Object[] {A43RegistroInvitadoUsuario, A44RegistroInvitadoEmail, A45RegistroInvitadoFecha, A41InvitadoRolId, A9TableroId, A40RegistroInvitadoId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Invitados");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitados"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B12( ) ;
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
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void DeferredUpdate0B12( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B12( ) ;
            AfterConfirm0B12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000B10 */
                  pr_default.execute(8, new Object[] {A9TableroId, A40RegistroInvitadoId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Invitados");
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
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0B12( ) ;
         Gx_mode = sMode12;
      }

      protected void OnDeleteControls0B12( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0B12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B12( ) ;
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

      public void ScanKeyStart0B12( )
      {
         /* Using cursor BC000B11 */
         pr_default.execute(9, new Object[] {A9TableroId, A40RegistroInvitadoId});
         RcdFound12 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound12 = 1;
            A40RegistroInvitadoId = BC000B11_A40RegistroInvitadoId[0];
            A43RegistroInvitadoUsuario = BC000B11_A43RegistroInvitadoUsuario[0];
            A44RegistroInvitadoEmail = BC000B11_A44RegistroInvitadoEmail[0];
            A45RegistroInvitadoFecha = BC000B11_A45RegistroInvitadoFecha[0];
            A9TableroId = BC000B11_A9TableroId[0];
            A41InvitadoRolId = BC000B11_A41InvitadoRolId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0B12( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound12 = 0;
         ScanKeyLoad0B12( ) ;
      }

      protected void ScanKeyLoad0B12( )
      {
         sMode12 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound12 = 1;
            A40RegistroInvitadoId = BC000B11_A40RegistroInvitadoId[0];
            A43RegistroInvitadoUsuario = BC000B11_A43RegistroInvitadoUsuario[0];
            A44RegistroInvitadoEmail = BC000B11_A44RegistroInvitadoEmail[0];
            A45RegistroInvitadoFecha = BC000B11_A45RegistroInvitadoFecha[0];
            A9TableroId = BC000B11_A9TableroId[0];
            A41InvitadoRolId = BC000B11_A41InvitadoRolId[0];
         }
         Gx_mode = sMode12;
      }

      protected void ScanKeyEnd0B12( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0B12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B12( )
      {
      }

      protected void send_integrity_lvl_hashes0B12( )
      {
      }

      protected void AddRow0B12( )
      {
         VarsToRow12( bcInvitados) ;
      }

      protected void ReadRow0B12( )
      {
         RowToVars12( bcInvitados, 1) ;
      }

      protected void InitializeNonKey0B12( )
      {
         A43RegistroInvitadoUsuario = 0;
         A44RegistroInvitadoEmail = "";
         A41InvitadoRolId = 0;
         A45RegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
         Z43RegistroInvitadoUsuario = 0;
         Z44RegistroInvitadoEmail = "";
         Z45RegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
         Z41InvitadoRolId = 0;
      }

      protected void InitAll0B12( )
      {
         A9TableroId = 0;
         A40RegistroInvitadoId = 0;
         InitializeNonKey0B12( ) ;
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

      public void VarsToRow12( SdtInvitados obj12 )
      {
         obj12.gxTpr_Mode = Gx_mode;
         obj12.gxTpr_Registroinvitadousuario = A43RegistroInvitadoUsuario;
         obj12.gxTpr_Registroinvitadoemail = A44RegistroInvitadoEmail;
         obj12.gxTpr_Invitadorolid = A41InvitadoRolId;
         obj12.gxTpr_Registroinvitadofecha = A45RegistroInvitadoFecha;
         obj12.gxTpr_Tableroid = A9TableroId;
         obj12.gxTpr_Registroinvitadoid = A40RegistroInvitadoId;
         obj12.gxTpr_Tableroid_Z = Z9TableroId;
         obj12.gxTpr_Registroinvitadoid_Z = Z40RegistroInvitadoId;
         obj12.gxTpr_Registroinvitadousuario_Z = Z43RegistroInvitadoUsuario;
         obj12.gxTpr_Registroinvitadoemail_Z = Z44RegistroInvitadoEmail;
         obj12.gxTpr_Invitadorolid_Z = Z41InvitadoRolId;
         obj12.gxTpr_Registroinvitadofecha_Z = Z45RegistroInvitadoFecha;
         obj12.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow12( SdtInvitados obj12 )
      {
         obj12.gxTpr_Tableroid = A9TableroId;
         obj12.gxTpr_Registroinvitadoid = A40RegistroInvitadoId;
         return  ;
      }

      public void RowToVars12( SdtInvitados obj12 ,
                               int forceLoad )
      {
         Gx_mode = obj12.gxTpr_Mode;
         A43RegistroInvitadoUsuario = obj12.gxTpr_Registroinvitadousuario;
         A44RegistroInvitadoEmail = obj12.gxTpr_Registroinvitadoemail;
         A41InvitadoRolId = obj12.gxTpr_Invitadorolid;
         A45RegistroInvitadoFecha = obj12.gxTpr_Registroinvitadofecha;
         A9TableroId = obj12.gxTpr_Tableroid;
         A40RegistroInvitadoId = obj12.gxTpr_Registroinvitadoid;
         Z9TableroId = obj12.gxTpr_Tableroid_Z;
         Z40RegistroInvitadoId = obj12.gxTpr_Registroinvitadoid_Z;
         Z43RegistroInvitadoUsuario = obj12.gxTpr_Registroinvitadousuario_Z;
         Z44RegistroInvitadoEmail = obj12.gxTpr_Registroinvitadoemail_Z;
         Z41InvitadoRolId = obj12.gxTpr_Invitadorolid_Z;
         Z45RegistroInvitadoFecha = obj12.gxTpr_Registroinvitadofecha_Z;
         Gx_mode = obj12.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A9TableroId = (short)getParm(obj,0);
         A40RegistroInvitadoId = (short)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0B12( ) ;
         ScanKeyStart0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000B12 */
            pr_default.execute(10, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
            Z40RegistroInvitadoId = A40RegistroInvitadoId;
         }
         ZM0B12( -3) ;
         OnLoadActions0B12( ) ;
         AddRow0B12( ) ;
         ScanKeyEnd0B12( ) ;
         if ( RcdFound12 == 0 )
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
         RowToVars12( bcInvitados, 0) ;
         ScanKeyStart0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000B12 */
            pr_default.execute(10, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
            Z40RegistroInvitadoId = A40RegistroInvitadoId;
         }
         ZM0B12( -3) ;
         OnLoadActions0B12( ) ;
         AddRow0B12( ) ;
         ScanKeyEnd0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0B12( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0B12( ) ;
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A40RegistroInvitadoId != Z40RegistroInvitadoId ) )
               {
                  A9TableroId = Z9TableroId;
                  A40RegistroInvitadoId = Z40RegistroInvitadoId;
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
                  Update0B12( ) ;
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
                  if ( ( A9TableroId != Z9TableroId ) || ( A40RegistroInvitadoId != Z40RegistroInvitadoId ) )
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
                        Insert0B12( ) ;
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
                        Insert0B12( ) ;
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
         RowToVars12( bcInvitados, 1) ;
         SaveImpl( ) ;
         VarsToRow12( bcInvitados) ;
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
         RowToVars12( bcInvitados, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B12( ) ;
         AfterTrn( ) ;
         VarsToRow12( bcInvitados) ;
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
            SdtInvitados auxBC = new SdtInvitados(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A9TableroId, A40RegistroInvitadoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcInvitados);
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
         RowToVars12( bcInvitados, 1) ;
         UpdateImpl( ) ;
         VarsToRow12( bcInvitados) ;
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
         RowToVars12( bcInvitados, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B12( ) ;
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
         VarsToRow12( bcInvitados) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars12( bcInvitados, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0B12( ) ;
         if ( RcdFound12 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A9TableroId != Z9TableroId ) || ( A40RegistroInvitadoId != Z40RegistroInvitadoId ) )
            {
               A9TableroId = Z9TableroId;
               A40RegistroInvitadoId = Z40RegistroInvitadoId;
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
            if ( ( A9TableroId != Z9TableroId ) || ( A40RegistroInvitadoId != Z40RegistroInvitadoId ) )
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
         pr_default.close(10);
         context.RollbackDataStores("invitados_bc",pr_default);
         VarsToRow12( bcInvitados) ;
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
         Gx_mode = bcInvitados.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcInvitados.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcInvitados )
         {
            bcInvitados = (SdtInvitados)(sdt);
            if ( StringUtil.StrCmp(bcInvitados.gxTpr_Mode, "") == 0 )
            {
               bcInvitados.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow12( bcInvitados) ;
            }
            else
            {
               RowToVars12( bcInvitados, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcInvitados.gxTpr_Mode, "") == 0 )
            {
               bcInvitados.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars12( bcInvitados, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtInvitados Invitados_BC
      {
         get {
            return bcInvitados ;
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
         pr_default.close(10);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z44RegistroInvitadoEmail = "";
         A44RegistroInvitadoEmail = "";
         Z45RegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
         A45RegistroInvitadoFecha = (DateTime)(DateTime.MinValue);
         BC000B6_A40RegistroInvitadoId = new short[1] ;
         BC000B6_A43RegistroInvitadoUsuario = new short[1] ;
         BC000B6_A44RegistroInvitadoEmail = new string[] {""} ;
         BC000B6_A45RegistroInvitadoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000B6_A9TableroId = new short[1] ;
         BC000B6_A41InvitadoRolId = new short[1] ;
         BC000B4_A9TableroId = new short[1] ;
         BC000B5_A41InvitadoRolId = new short[1] ;
         BC000B7_A9TableroId = new short[1] ;
         BC000B7_A40RegistroInvitadoId = new short[1] ;
         BC000B3_A40RegistroInvitadoId = new short[1] ;
         BC000B3_A43RegistroInvitadoUsuario = new short[1] ;
         BC000B3_A44RegistroInvitadoEmail = new string[] {""} ;
         BC000B3_A45RegistroInvitadoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000B3_A9TableroId = new short[1] ;
         BC000B3_A41InvitadoRolId = new short[1] ;
         sMode12 = "";
         BC000B2_A40RegistroInvitadoId = new short[1] ;
         BC000B2_A43RegistroInvitadoUsuario = new short[1] ;
         BC000B2_A44RegistroInvitadoEmail = new string[] {""} ;
         BC000B2_A45RegistroInvitadoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000B2_A9TableroId = new short[1] ;
         BC000B2_A41InvitadoRolId = new short[1] ;
         BC000B11_A40RegistroInvitadoId = new short[1] ;
         BC000B11_A43RegistroInvitadoUsuario = new short[1] ;
         BC000B11_A44RegistroInvitadoEmail = new string[] {""} ;
         BC000B11_A45RegistroInvitadoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000B11_A9TableroId = new short[1] ;
         BC000B11_A41InvitadoRolId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000B12_A9TableroId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invitados_bc__default(),
            new Object[][] {
                new Object[] {
               BC000B2_A40RegistroInvitadoId, BC000B2_A43RegistroInvitadoUsuario, BC000B2_A44RegistroInvitadoEmail, BC000B2_A45RegistroInvitadoFecha, BC000B2_A9TableroId, BC000B2_A41InvitadoRolId
               }
               , new Object[] {
               BC000B3_A40RegistroInvitadoId, BC000B3_A43RegistroInvitadoUsuario, BC000B3_A44RegistroInvitadoEmail, BC000B3_A45RegistroInvitadoFecha, BC000B3_A9TableroId, BC000B3_A41InvitadoRolId
               }
               , new Object[] {
               BC000B4_A9TableroId
               }
               , new Object[] {
               BC000B5_A41InvitadoRolId
               }
               , new Object[] {
               BC000B6_A40RegistroInvitadoId, BC000B6_A43RegistroInvitadoUsuario, BC000B6_A44RegistroInvitadoEmail, BC000B6_A45RegistroInvitadoFecha, BC000B6_A9TableroId, BC000B6_A41InvitadoRolId
               }
               , new Object[] {
               BC000B7_A9TableroId, BC000B7_A40RegistroInvitadoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B11_A40RegistroInvitadoId, BC000B11_A43RegistroInvitadoUsuario, BC000B11_A44RegistroInvitadoEmail, BC000B11_A45RegistroInvitadoFecha, BC000B11_A9TableroId, BC000B11_A41InvitadoRolId
               }
               , new Object[] {
               BC000B12_A9TableroId
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
      private short Z9TableroId ;
      private short A9TableroId ;
      private short Z40RegistroInvitadoId ;
      private short A40RegistroInvitadoId ;
      private short GX_JID ;
      private short Z43RegistroInvitadoUsuario ;
      private short A43RegistroInvitadoUsuario ;
      private short Z41InvitadoRolId ;
      private short A41InvitadoRolId ;
      private short RcdFound12 ;
      private short nIsDirty_12 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode12 ;
      private DateTime Z45RegistroInvitadoFecha ;
      private DateTime A45RegistroInvitadoFecha ;
      private bool mustCommit ;
      private string Z44RegistroInvitadoEmail ;
      private string A44RegistroInvitadoEmail ;
      private SdtInvitados bcInvitados ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000B6_A40RegistroInvitadoId ;
      private short[] BC000B6_A43RegistroInvitadoUsuario ;
      private string[] BC000B6_A44RegistroInvitadoEmail ;
      private DateTime[] BC000B6_A45RegistroInvitadoFecha ;
      private short[] BC000B6_A9TableroId ;
      private short[] BC000B6_A41InvitadoRolId ;
      private short[] BC000B4_A9TableroId ;
      private short[] BC000B5_A41InvitadoRolId ;
      private short[] BC000B7_A9TableroId ;
      private short[] BC000B7_A40RegistroInvitadoId ;
      private short[] BC000B3_A40RegistroInvitadoId ;
      private short[] BC000B3_A43RegistroInvitadoUsuario ;
      private string[] BC000B3_A44RegistroInvitadoEmail ;
      private DateTime[] BC000B3_A45RegistroInvitadoFecha ;
      private short[] BC000B3_A9TableroId ;
      private short[] BC000B3_A41InvitadoRolId ;
      private short[] BC000B2_A40RegistroInvitadoId ;
      private short[] BC000B2_A43RegistroInvitadoUsuario ;
      private string[] BC000B2_A44RegistroInvitadoEmail ;
      private DateTime[] BC000B2_A45RegistroInvitadoFecha ;
      private short[] BC000B2_A9TableroId ;
      private short[] BC000B2_A41InvitadoRolId ;
      private short[] BC000B11_A40RegistroInvitadoId ;
      private short[] BC000B11_A43RegistroInvitadoUsuario ;
      private string[] BC000B11_A44RegistroInvitadoEmail ;
      private DateTime[] BC000B11_A45RegistroInvitadoFecha ;
      private short[] BC000B11_A9TableroId ;
      private short[] BC000B11_A41InvitadoRolId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] BC000B12_A9TableroId ;
   }

   public class invitados_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000B6;
          prmBC000B6 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmBC000B4;
          prmBC000B4 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC000B5;
          prmBC000B5 = new Object[] {
          new ParDef("@InvitadoRolId",GXType.Int16,4,0)
          };
          Object[] prmBC000B7;
          prmBC000B7 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmBC000B3;
          prmBC000B3 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmBC000B2;
          prmBC000B2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmBC000B8;
          prmBC000B8 = new Object[] {
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoUsuario",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoEmail",GXType.NVarChar,100,0) ,
          new ParDef("@RegistroInvitadoFecha",GXType.DateTime,8,5) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@InvitadoRolId",GXType.Int16,4,0)
          };
          Object[] prmBC000B9;
          prmBC000B9 = new Object[] {
          new ParDef("@RegistroInvitadoUsuario",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoEmail",GXType.NVarChar,100,0) ,
          new ParDef("@RegistroInvitadoFecha",GXType.DateTime,8,5) ,
          new ParDef("@InvitadoRolId",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmBC000B10;
          prmBC000B10 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmBC000B11;
          prmBC000B11 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@RegistroInvitadoId",GXType.Int16,4,0)
          };
          Object[] prmBC000B12;
          prmBC000B12 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000B2", "SELECT [RegistroInvitadoId], [RegistroInvitadoUsuario], [RegistroInvitadoEmail], [RegistroInvitadoFecha], [TableroId], [InvitadoRolId] AS InvitadoRolId FROM [Invitados] WITH (UPDLOCK) WHERE [TableroId] = @TableroId AND [RegistroInvitadoId] = @RegistroInvitadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B3", "SELECT [RegistroInvitadoId], [RegistroInvitadoUsuario], [RegistroInvitadoEmail], [RegistroInvitadoFecha], [TableroId], [InvitadoRolId] AS InvitadoRolId FROM [Invitados] WHERE [TableroId] = @TableroId AND [RegistroInvitadoId] = @RegistroInvitadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B4", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B5", "SELECT [RolId] AS InvitadoRolId FROM [Roles] WHERE [RolId] = @InvitadoRolId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B6", "SELECT TM1.[RegistroInvitadoId], TM1.[RegistroInvitadoUsuario], TM1.[RegistroInvitadoEmail], TM1.[RegistroInvitadoFecha], TM1.[TableroId], TM1.[InvitadoRolId] AS InvitadoRolId FROM [Invitados] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[RegistroInvitadoId] = @RegistroInvitadoId ORDER BY TM1.[TableroId], TM1.[RegistroInvitadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B7", "SELECT [TableroId], [RegistroInvitadoId] FROM [Invitados] WHERE [TableroId] = @TableroId AND [RegistroInvitadoId] = @RegistroInvitadoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B8", "INSERT INTO [Invitados]([RegistroInvitadoId], [RegistroInvitadoUsuario], [RegistroInvitadoEmail], [RegistroInvitadoFecha], [TableroId], [InvitadoRolId]) VALUES(@RegistroInvitadoId, @RegistroInvitadoUsuario, @RegistroInvitadoEmail, @RegistroInvitadoFecha, @TableroId, @InvitadoRolId)", GxErrorMask.GX_NOMASK,prmBC000B8)
             ,new CursorDef("BC000B9", "UPDATE [Invitados] SET [RegistroInvitadoUsuario]=@RegistroInvitadoUsuario, [RegistroInvitadoEmail]=@RegistroInvitadoEmail, [RegistroInvitadoFecha]=@RegistroInvitadoFecha, [InvitadoRolId]=@InvitadoRolId  WHERE [TableroId] = @TableroId AND [RegistroInvitadoId] = @RegistroInvitadoId", GxErrorMask.GX_NOMASK,prmBC000B9)
             ,new CursorDef("BC000B10", "DELETE FROM [Invitados]  WHERE [TableroId] = @TableroId AND [RegistroInvitadoId] = @RegistroInvitadoId", GxErrorMask.GX_NOMASK,prmBC000B10)
             ,new CursorDef("BC000B11", "SELECT TM1.[RegistroInvitadoId], TM1.[RegistroInvitadoUsuario], TM1.[RegistroInvitadoEmail], TM1.[RegistroInvitadoFecha], TM1.[TableroId], TM1.[InvitadoRolId] AS InvitadoRolId FROM [Invitados] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[RegistroInvitadoId] = @RegistroInvitadoId ORDER BY TM1.[TableroId], TM1.[RegistroInvitadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B12", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B12,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
