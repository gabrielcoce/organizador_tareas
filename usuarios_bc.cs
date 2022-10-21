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
   public class usuarios_bc : GXHttpHandler, IGxSilentTrn
   {
      public usuarios_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public usuarios_bc( IGxContext context )
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
         ReadRow022( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey022( ) ;
         standaloneModal( ) ;
         AddRow022( ) ;
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
               Z3UsuarioId = A3UsuarioId;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               if ( AnyError == 0 )
               {
                  ZM022( 3) ;
               }
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z4UsuarioNombre = A4UsuarioNombre;
            Z5UsuarioApellido = A5UsuarioApellido;
            Z6UsuarioEmail = A6UsuarioEmail;
            Z7UsuarioPassword = A7UsuarioPassword;
            Z8UsuarioEstado = A8UsuarioEstado;
            Z1RolId = A1RolId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -2 )
         {
            Z3UsuarioId = A3UsuarioId;
            Z4UsuarioNombre = A4UsuarioNombre;
            Z5UsuarioApellido = A5UsuarioApellido;
            Z6UsuarioEmail = A6UsuarioEmail;
            Z7UsuarioPassword = A7UsuarioPassword;
            Z8UsuarioEstado = A8UsuarioEstado;
            Z1RolId = A1RolId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load022( )
      {
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {A3UsuarioId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
            A4UsuarioNombre = BC00025_A4UsuarioNombre[0];
            n4UsuarioNombre = BC00025_n4UsuarioNombre[0];
            A5UsuarioApellido = BC00025_A5UsuarioApellido[0];
            n5UsuarioApellido = BC00025_n5UsuarioApellido[0];
            A6UsuarioEmail = BC00025_A6UsuarioEmail[0];
            A7UsuarioPassword = BC00025_A7UsuarioPassword[0];
            n7UsuarioPassword = BC00025_n7UsuarioPassword[0];
            A8UsuarioEstado = BC00025_A8UsuarioEstado[0];
            A1RolId = BC00025_A1RolId[0];
            ZM022( -2) ;
         }
         pr_default.close(3);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A6UsuarioEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de Usuario Email no coincide con el patr�n especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00024 */
         pr_default.execute(2, new Object[] {A1RolId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, "ROLID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor BC00026 */
         pr_default.execute(4, new Object[] {A3UsuarioId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A3UsuarioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 2) ;
            RcdFound2 = 1;
            A3UsuarioId = BC00023_A3UsuarioId[0];
            A4UsuarioNombre = BC00023_A4UsuarioNombre[0];
            n4UsuarioNombre = BC00023_n4UsuarioNombre[0];
            A5UsuarioApellido = BC00023_A5UsuarioApellido[0];
            n5UsuarioApellido = BC00023_n5UsuarioApellido[0];
            A6UsuarioEmail = BC00023_A6UsuarioEmail[0];
            A7UsuarioPassword = BC00023_A7UsuarioPassword[0];
            n7UsuarioPassword = BC00023_n7UsuarioPassword[0];
            A8UsuarioEstado = BC00023_A8UsuarioEstado[0];
            A1RolId = BC00023_A1RolId[0];
            Z3UsuarioId = A3UsuarioId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode2;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
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
         CONFIRM_020( ) ;
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

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A3UsuarioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuarios"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z4UsuarioNombre, BC00022_A4UsuarioNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z5UsuarioApellido, BC00022_A5UsuarioApellido[0]) != 0 ) || ( StringUtil.StrCmp(Z6UsuarioEmail, BC00022_A6UsuarioEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z7UsuarioPassword, BC00022_A7UsuarioPassword[0]) != 0 ) || ( Z8UsuarioEstado != BC00022_A8UsuarioEstado[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1RolId != BC00022_A1RolId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Usuarios"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00027 */
                     pr_default.execute(5, new Object[] {A3UsuarioId, n4UsuarioNombre, A4UsuarioNombre, n5UsuarioApellido, A5UsuarioApellido, A6UsuarioEmail, n7UsuarioPassword, A7UsuarioPassword, A8UsuarioEstado, A1RolId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Usuarios");
                     if ( (pr_default.getStatus(5) == 1) )
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00028 */
                     pr_default.execute(6, new Object[] {n4UsuarioNombre, A4UsuarioNombre, n5UsuarioApellido, A5UsuarioApellido, A6UsuarioEmail, n7UsuarioPassword, A7UsuarioPassword, A8UsuarioEstado, A1RolId, A3UsuarioId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Usuarios");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuarios"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00029 */
                  pr_default.execute(7, new Object[] {A3UsuarioId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("Usuarios");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel022( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000210 */
            pr_default.execute(8, new Object[] {A3UsuarioId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tareas Comentarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000211 */
            pr_default.execute(9, new Object[] {A3UsuarioId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tareas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000212 */
            pr_default.execute(10, new Object[] {A3UsuarioId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Participantes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000213 */
            pr_default.execute(11, new Object[] {A3UsuarioId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tableros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
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

      public void ScanKeyStart022( )
      {
         /* Using cursor BC000214 */
         pr_default.execute(12, new Object[] {A3UsuarioId});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound2 = 1;
            A3UsuarioId = BC000214_A3UsuarioId[0];
            A4UsuarioNombre = BC000214_A4UsuarioNombre[0];
            n4UsuarioNombre = BC000214_n4UsuarioNombre[0];
            A5UsuarioApellido = BC000214_A5UsuarioApellido[0];
            n5UsuarioApellido = BC000214_n5UsuarioApellido[0];
            A6UsuarioEmail = BC000214_A6UsuarioEmail[0];
            A7UsuarioPassword = BC000214_A7UsuarioPassword[0];
            n7UsuarioPassword = BC000214_n7UsuarioPassword[0];
            A8UsuarioEstado = BC000214_A8UsuarioEstado[0];
            A1RolId = BC000214_A1RolId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound2 = 0;
         ScanKeyLoad022( ) ;
      }

      protected void ScanKeyLoad022( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound2 = 1;
            A3UsuarioId = BC000214_A3UsuarioId[0];
            A4UsuarioNombre = BC000214_A4UsuarioNombre[0];
            n4UsuarioNombre = BC000214_n4UsuarioNombre[0];
            A5UsuarioApellido = BC000214_A5UsuarioApellido[0];
            n5UsuarioApellido = BC000214_n5UsuarioApellido[0];
            A6UsuarioEmail = BC000214_A6UsuarioEmail[0];
            A7UsuarioPassword = BC000214_A7UsuarioPassword[0];
            n7UsuarioPassword = BC000214_n7UsuarioPassword[0];
            A8UsuarioEstado = BC000214_A8UsuarioEstado[0];
            A1RolId = BC000214_A1RolId[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd022( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void AddRow022( )
      {
         VarsToRow2( bcUsuarios) ;
      }

      protected void ReadRow022( )
      {
         RowToVars2( bcUsuarios, 1) ;
      }

      protected void InitializeNonKey022( )
      {
         A4UsuarioNombre = "";
         n4UsuarioNombre = false;
         A5UsuarioApellido = "";
         n5UsuarioApellido = false;
         A6UsuarioEmail = "";
         A7UsuarioPassword = "";
         n7UsuarioPassword = false;
         A8UsuarioEstado = false;
         A1RolId = 0;
         Z4UsuarioNombre = "";
         Z5UsuarioApellido = "";
         Z6UsuarioEmail = "";
         Z7UsuarioPassword = "";
         Z8UsuarioEstado = false;
         Z1RolId = 0;
      }

      protected void InitAll022( )
      {
         A3UsuarioId = 0;
         InitializeNonKey022( ) ;
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

      public void VarsToRow2( SdtUsuarios obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Usuarionombre = A4UsuarioNombre;
         obj2.gxTpr_Usuarioapellido = A5UsuarioApellido;
         obj2.gxTpr_Usuarioemail = A6UsuarioEmail;
         obj2.gxTpr_Usuariopassword = A7UsuarioPassword;
         obj2.gxTpr_Usuarioestado = A8UsuarioEstado;
         obj2.gxTpr_Rolid = A1RolId;
         obj2.gxTpr_Usuarioid = A3UsuarioId;
         obj2.gxTpr_Usuarioid_Z = Z3UsuarioId;
         obj2.gxTpr_Usuarionombre_Z = Z4UsuarioNombre;
         obj2.gxTpr_Usuarioapellido_Z = Z5UsuarioApellido;
         obj2.gxTpr_Usuarioemail_Z = Z6UsuarioEmail;
         obj2.gxTpr_Usuariopassword_Z = Z7UsuarioPassword;
         obj2.gxTpr_Usuarioestado_Z = Z8UsuarioEstado;
         obj2.gxTpr_Rolid_Z = Z1RolId;
         obj2.gxTpr_Usuarionombre_N = (short)(Convert.ToInt16(n4UsuarioNombre));
         obj2.gxTpr_Usuarioapellido_N = (short)(Convert.ToInt16(n5UsuarioApellido));
         obj2.gxTpr_Usuariopassword_N = (short)(Convert.ToInt16(n7UsuarioPassword));
         obj2.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow2( SdtUsuarios obj2 )
      {
         obj2.gxTpr_Usuarioid = A3UsuarioId;
         return  ;
      }

      public void RowToVars2( SdtUsuarios obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         A4UsuarioNombre = obj2.gxTpr_Usuarionombre;
         n4UsuarioNombre = false;
         A5UsuarioApellido = obj2.gxTpr_Usuarioapellido;
         n5UsuarioApellido = false;
         A6UsuarioEmail = obj2.gxTpr_Usuarioemail;
         A7UsuarioPassword = obj2.gxTpr_Usuariopassword;
         n7UsuarioPassword = false;
         A8UsuarioEstado = obj2.gxTpr_Usuarioestado;
         A1RolId = obj2.gxTpr_Rolid;
         A3UsuarioId = obj2.gxTpr_Usuarioid;
         Z3UsuarioId = obj2.gxTpr_Usuarioid_Z;
         Z4UsuarioNombre = obj2.gxTpr_Usuarionombre_Z;
         Z5UsuarioApellido = obj2.gxTpr_Usuarioapellido_Z;
         Z6UsuarioEmail = obj2.gxTpr_Usuarioemail_Z;
         Z7UsuarioPassword = obj2.gxTpr_Usuariopassword_Z;
         Z8UsuarioEstado = obj2.gxTpr_Usuarioestado_Z;
         Z1RolId = obj2.gxTpr_Rolid_Z;
         n4UsuarioNombre = (bool)(Convert.ToBoolean(obj2.gxTpr_Usuarionombre_N));
         n5UsuarioApellido = (bool)(Convert.ToBoolean(obj2.gxTpr_Usuarioapellido_N));
         n7UsuarioPassword = (bool)(Convert.ToBoolean(obj2.gxTpr_Usuariopassword_N));
         Gx_mode = obj2.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A3UsuarioId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey022( ) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z3UsuarioId = A3UsuarioId;
         }
         ZM022( -2) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
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
         RowToVars2( bcUsuarios, 0) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z3UsuarioId = A3UsuarioId;
         }
         ZM022( -2) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert022( ) ;
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A3UsuarioId != Z3UsuarioId )
               {
                  A3UsuarioId = Z3UsuarioId;
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
                  Update022( ) ;
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
                  if ( A3UsuarioId != Z3UsuarioId )
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
                        Insert022( ) ;
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
                        Insert022( ) ;
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
         RowToVars2( bcUsuarios, 1) ;
         SaveImpl( ) ;
         VarsToRow2( bcUsuarios) ;
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
         RowToVars2( bcUsuarios, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         AfterTrn( ) ;
         VarsToRow2( bcUsuarios) ;
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
            SdtUsuarios auxBC = new SdtUsuarios(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A3UsuarioId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcUsuarios);
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
         RowToVars2( bcUsuarios, 1) ;
         UpdateImpl( ) ;
         VarsToRow2( bcUsuarios) ;
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
         RowToVars2( bcUsuarios, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
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
         VarsToRow2( bcUsuarios) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars2( bcUsuarios, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey022( ) ;
         if ( RcdFound2 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A3UsuarioId != Z3UsuarioId )
            {
               A3UsuarioId = Z3UsuarioId;
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
            if ( A3UsuarioId != Z3UsuarioId )
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
         context.RollbackDataStores("usuarios_bc",pr_default);
         VarsToRow2( bcUsuarios) ;
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
         Gx_mode = bcUsuarios.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcUsuarios.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcUsuarios )
         {
            bcUsuarios = (SdtUsuarios)(sdt);
            if ( StringUtil.StrCmp(bcUsuarios.gxTpr_Mode, "") == 0 )
            {
               bcUsuarios.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow2( bcUsuarios) ;
            }
            else
            {
               RowToVars2( bcUsuarios, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcUsuarios.gxTpr_Mode, "") == 0 )
            {
               bcUsuarios.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars2( bcUsuarios, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtUsuarios Usuarios_BC
      {
         get {
            return bcUsuarios ;
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
         Z4UsuarioNombre = "";
         A4UsuarioNombre = "";
         Z5UsuarioApellido = "";
         A5UsuarioApellido = "";
         Z6UsuarioEmail = "";
         A6UsuarioEmail = "";
         Z7UsuarioPassword = "";
         A7UsuarioPassword = "";
         BC00025_A3UsuarioId = new short[1] ;
         BC00025_A4UsuarioNombre = new string[] {""} ;
         BC00025_n4UsuarioNombre = new bool[] {false} ;
         BC00025_A5UsuarioApellido = new string[] {""} ;
         BC00025_n5UsuarioApellido = new bool[] {false} ;
         BC00025_A6UsuarioEmail = new string[] {""} ;
         BC00025_A7UsuarioPassword = new string[] {""} ;
         BC00025_n7UsuarioPassword = new bool[] {false} ;
         BC00025_A8UsuarioEstado = new bool[] {false} ;
         BC00025_A1RolId = new short[1] ;
         BC00024_A1RolId = new short[1] ;
         BC00026_A3UsuarioId = new short[1] ;
         BC00023_A3UsuarioId = new short[1] ;
         BC00023_A4UsuarioNombre = new string[] {""} ;
         BC00023_n4UsuarioNombre = new bool[] {false} ;
         BC00023_A5UsuarioApellido = new string[] {""} ;
         BC00023_n5UsuarioApellido = new bool[] {false} ;
         BC00023_A6UsuarioEmail = new string[] {""} ;
         BC00023_A7UsuarioPassword = new string[] {""} ;
         BC00023_n7UsuarioPassword = new bool[] {false} ;
         BC00023_A8UsuarioEstado = new bool[] {false} ;
         BC00023_A1RolId = new short[1] ;
         sMode2 = "";
         BC00022_A3UsuarioId = new short[1] ;
         BC00022_A4UsuarioNombre = new string[] {""} ;
         BC00022_n4UsuarioNombre = new bool[] {false} ;
         BC00022_A5UsuarioApellido = new string[] {""} ;
         BC00022_n5UsuarioApellido = new bool[] {false} ;
         BC00022_A6UsuarioEmail = new string[] {""} ;
         BC00022_A7UsuarioPassword = new string[] {""} ;
         BC00022_n7UsuarioPassword = new bool[] {false} ;
         BC00022_A8UsuarioEstado = new bool[] {false} ;
         BC00022_A1RolId = new short[1] ;
         BC000210_A9TableroId = new short[1] ;
         BC000210_A12TareaId = new short[1] ;
         BC000210_A27ComentarioId = new short[1] ;
         BC000211_A9TableroId = new short[1] ;
         BC000211_A12TareaId = new short[1] ;
         BC000212_A9TableroId = new short[1] ;
         BC000212_A18ParticipanteTableroId = new short[1] ;
         BC000213_A9TableroId = new short[1] ;
         BC000214_A3UsuarioId = new short[1] ;
         BC000214_A4UsuarioNombre = new string[] {""} ;
         BC000214_n4UsuarioNombre = new bool[] {false} ;
         BC000214_A5UsuarioApellido = new string[] {""} ;
         BC000214_n5UsuarioApellido = new bool[] {false} ;
         BC000214_A6UsuarioEmail = new string[] {""} ;
         BC000214_A7UsuarioPassword = new string[] {""} ;
         BC000214_n7UsuarioPassword = new bool[] {false} ;
         BC000214_A8UsuarioEstado = new bool[] {false} ;
         BC000214_A1RolId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuarios_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A3UsuarioId, BC00022_A4UsuarioNombre, BC00022_n4UsuarioNombre, BC00022_A5UsuarioApellido, BC00022_n5UsuarioApellido, BC00022_A6UsuarioEmail, BC00022_A7UsuarioPassword, BC00022_n7UsuarioPassword, BC00022_A8UsuarioEstado, BC00022_A1RolId
               }
               , new Object[] {
               BC00023_A3UsuarioId, BC00023_A4UsuarioNombre, BC00023_n4UsuarioNombre, BC00023_A5UsuarioApellido, BC00023_n5UsuarioApellido, BC00023_A6UsuarioEmail, BC00023_A7UsuarioPassword, BC00023_n7UsuarioPassword, BC00023_A8UsuarioEstado, BC00023_A1RolId
               }
               , new Object[] {
               BC00024_A1RolId
               }
               , new Object[] {
               BC00025_A3UsuarioId, BC00025_A4UsuarioNombre, BC00025_n4UsuarioNombre, BC00025_A5UsuarioApellido, BC00025_n5UsuarioApellido, BC00025_A6UsuarioEmail, BC00025_A7UsuarioPassword, BC00025_n7UsuarioPassword, BC00025_A8UsuarioEstado, BC00025_A1RolId
               }
               , new Object[] {
               BC00026_A3UsuarioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000210_A9TableroId, BC000210_A12TareaId, BC000210_A27ComentarioId
               }
               , new Object[] {
               BC000211_A9TableroId, BC000211_A12TareaId
               }
               , new Object[] {
               BC000212_A9TableroId, BC000212_A18ParticipanteTableroId
               }
               , new Object[] {
               BC000213_A9TableroId
               }
               , new Object[] {
               BC000214_A3UsuarioId, BC000214_A4UsuarioNombre, BC000214_n4UsuarioNombre, BC000214_A5UsuarioApellido, BC000214_n5UsuarioApellido, BC000214_A6UsuarioEmail, BC000214_A7UsuarioPassword, BC000214_n7UsuarioPassword, BC000214_A8UsuarioEstado, BC000214_A1RolId
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
      private short Z3UsuarioId ;
      private short A3UsuarioId ;
      private short GX_JID ;
      private short Z1RolId ;
      private short A1RolId ;
      private short RcdFound2 ;
      private short nIsDirty_2 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z4UsuarioNombre ;
      private string A4UsuarioNombre ;
      private string Z5UsuarioApellido ;
      private string A5UsuarioApellido ;
      private string Z7UsuarioPassword ;
      private string A7UsuarioPassword ;
      private string sMode2 ;
      private bool Z8UsuarioEstado ;
      private bool A8UsuarioEstado ;
      private bool n4UsuarioNombre ;
      private bool n5UsuarioApellido ;
      private bool n7UsuarioPassword ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z6UsuarioEmail ;
      private string A6UsuarioEmail ;
      private SdtUsuarios bcUsuarios ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00025_A3UsuarioId ;
      private string[] BC00025_A4UsuarioNombre ;
      private bool[] BC00025_n4UsuarioNombre ;
      private string[] BC00025_A5UsuarioApellido ;
      private bool[] BC00025_n5UsuarioApellido ;
      private string[] BC00025_A6UsuarioEmail ;
      private string[] BC00025_A7UsuarioPassword ;
      private bool[] BC00025_n7UsuarioPassword ;
      private bool[] BC00025_A8UsuarioEstado ;
      private short[] BC00025_A1RolId ;
      private short[] BC00024_A1RolId ;
      private short[] BC00026_A3UsuarioId ;
      private short[] BC00023_A3UsuarioId ;
      private string[] BC00023_A4UsuarioNombre ;
      private bool[] BC00023_n4UsuarioNombre ;
      private string[] BC00023_A5UsuarioApellido ;
      private bool[] BC00023_n5UsuarioApellido ;
      private string[] BC00023_A6UsuarioEmail ;
      private string[] BC00023_A7UsuarioPassword ;
      private bool[] BC00023_n7UsuarioPassword ;
      private bool[] BC00023_A8UsuarioEstado ;
      private short[] BC00023_A1RolId ;
      private short[] BC00022_A3UsuarioId ;
      private string[] BC00022_A4UsuarioNombre ;
      private bool[] BC00022_n4UsuarioNombre ;
      private string[] BC00022_A5UsuarioApellido ;
      private bool[] BC00022_n5UsuarioApellido ;
      private string[] BC00022_A6UsuarioEmail ;
      private string[] BC00022_A7UsuarioPassword ;
      private bool[] BC00022_n7UsuarioPassword ;
      private bool[] BC00022_A8UsuarioEstado ;
      private short[] BC00022_A1RolId ;
      private short[] BC000210_A9TableroId ;
      private short[] BC000210_A12TareaId ;
      private short[] BC000210_A27ComentarioId ;
      private short[] BC000211_A9TableroId ;
      private short[] BC000211_A12TareaId ;
      private short[] BC000212_A9TableroId ;
      private short[] BC000212_A18ParticipanteTableroId ;
      private short[] BC000213_A9TableroId ;
      private short[] BC000214_A3UsuarioId ;
      private string[] BC000214_A4UsuarioNombre ;
      private bool[] BC000214_n4UsuarioNombre ;
      private string[] BC000214_A5UsuarioApellido ;
      private bool[] BC000214_n5UsuarioApellido ;
      private string[] BC000214_A6UsuarioEmail ;
      private string[] BC000214_A7UsuarioPassword ;
      private bool[] BC000214_n7UsuarioPassword ;
      private bool[] BC000214_A8UsuarioEstado ;
      private short[] BC000214_A1RolId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class usuarios_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00025;
          prmBC00025 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmBC00024;
          prmBC00024 = new Object[] {
          new ParDef("@RolId",GXType.Int16,4,0)
          };
          Object[] prmBC00026;
          prmBC00026 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmBC00023;
          prmBC00023 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmBC00022;
          prmBC00022 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmBC00027;
          prmBC00027 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0) ,
          new ParDef("@UsuarioNombre",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@UsuarioApellido",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@UsuarioEmail",GXType.NVarChar,100,0) ,
          new ParDef("@UsuarioPassword",GXType.NChar,200,0){Nullable=true} ,
          new ParDef("@UsuarioEstado",GXType.Boolean,4,0) ,
          new ParDef("@RolId",GXType.Int16,4,0)
          };
          Object[] prmBC00028;
          prmBC00028 = new Object[] {
          new ParDef("@UsuarioNombre",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@UsuarioApellido",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@UsuarioEmail",GXType.NVarChar,100,0) ,
          new ParDef("@UsuarioPassword",GXType.NChar,200,0){Nullable=true} ,
          new ParDef("@UsuarioEstado",GXType.Boolean,4,0) ,
          new ParDef("@RolId",GXType.Int16,4,0) ,
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmBC00029;
          prmBC00029 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmBC000210;
          prmBC000210 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmBC000211;
          prmBC000211 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmBC000212;
          prmBC000212 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmBC000213;
          prmBC000213 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmBC000214;
          prmBC000214 = new Object[] {
          new ParDef("@UsuarioId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00022", "SELECT [UsuarioId], [UsuarioNombre], [UsuarioApellido], [UsuarioEmail], [UsuarioPassword], [UsuarioEstado], [RolId] FROM [Usuarios] WITH (UPDLOCK) WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00023", "SELECT [UsuarioId], [UsuarioNombre], [UsuarioApellido], [UsuarioEmail], [UsuarioPassword], [UsuarioEstado], [RolId] FROM [Usuarios] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00024", "SELECT [RolId] FROM [Roles] WHERE [RolId] = @RolId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00025", "SELECT TM1.[UsuarioId], TM1.[UsuarioNombre], TM1.[UsuarioApellido], TM1.[UsuarioEmail], TM1.[UsuarioPassword], TM1.[UsuarioEstado], TM1.[RolId] FROM [Usuarios] TM1 WHERE TM1.[UsuarioId] = @UsuarioId ORDER BY TM1.[UsuarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00026", "SELECT [UsuarioId] FROM [Usuarios] WHERE [UsuarioId] = @UsuarioId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00027", "INSERT INTO [Usuarios]([UsuarioId], [UsuarioNombre], [UsuarioApellido], [UsuarioEmail], [UsuarioPassword], [UsuarioEstado], [RolId]) VALUES(@UsuarioId, @UsuarioNombre, @UsuarioApellido, @UsuarioEmail, @UsuarioPassword, @UsuarioEstado, @RolId)", GxErrorMask.GX_NOMASK,prmBC00027)
             ,new CursorDef("BC00028", "UPDATE [Usuarios] SET [UsuarioNombre]=@UsuarioNombre, [UsuarioApellido]=@UsuarioApellido, [UsuarioEmail]=@UsuarioEmail, [UsuarioPassword]=@UsuarioPassword, [UsuarioEstado]=@UsuarioEstado, [RolId]=@RolId  WHERE [UsuarioId] = @UsuarioId", GxErrorMask.GX_NOMASK,prmBC00028)
             ,new CursorDef("BC00029", "DELETE FROM [Usuarios]  WHERE [UsuarioId] = @UsuarioId", GxErrorMask.GX_NOMASK,prmBC00029)
             ,new CursorDef("BC000210", "SELECT TOP 1 [TableroId], [TareaId], [ComentarioId] FROM [TareasComentarios] WHERE [ComentaristaId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000210,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000211", "SELECT TOP 1 [TableroId], [TareaId] FROM [Tareas] WHERE [ResponsableId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000211,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000212", "SELECT TOP 1 [TableroId], [ParticipanteTableroId] FROM [Participantes] WHERE [ParticipanteTableroId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000212,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000213", "SELECT TOP 1 [TableroId] FROM [Tableros] WHERE [PropietarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000214", "SELECT TM1.[UsuarioId], TM1.[UsuarioNombre], TM1.[UsuarioApellido], TM1.[UsuarioEmail], TM1.[UsuarioPassword], TM1.[UsuarioEstado], TM1.[RolId] FROM [Usuarios] TM1 WHERE TM1.[UsuarioId] = @UsuarioId ORDER BY TM1.[UsuarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000214,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 200);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((short[]) buf[9])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 200);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((short[]) buf[9])[0] = rslt.getShort(7);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 200);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((short[]) buf[9])[0] = rslt.getShort(7);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 200);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((short[]) buf[9])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
