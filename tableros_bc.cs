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
   public class tableros_bc : GXHttpHandler, IGxSilentTrn
   {
      public tableros_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public tableros_bc( IGxContext context )
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
         ReadRow033( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey033( ) ;
         standaloneModal( ) ;
         AddRow033( ) ;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               if ( AnyError == 0 )
               {
                  ZM033( 4) ;
               }
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z10TableroNombre = A10TableroNombre;
            Z11TableroFechaCreacion = A11TableroFechaCreacion;
            Z34TableroEstado = A34TableroEstado;
            Z35TableroVisibilidad = A35TableroVisibilidad;
            Z17PropietarioId = A17PropietarioId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -3 )
         {
            Z9TableroId = A9TableroId;
            Z10TableroNombre = A10TableroNombre;
            Z11TableroFechaCreacion = A11TableroFechaCreacion;
            Z34TableroEstado = A34TableroEstado;
            Z35TableroVisibilidad = A35TableroVisibilidad;
            Z17PropietarioId = A17PropietarioId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
      }

      protected void Load033( )
      {
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
            A10TableroNombre = BC00035_A10TableroNombre[0];
            A11TableroFechaCreacion = BC00035_A11TableroFechaCreacion[0];
            A34TableroEstado = BC00035_A34TableroEstado[0];
            A35TableroVisibilidad = BC00035_A35TableroVisibilidad[0];
            A17PropietarioId = BC00035_A17PropietarioId[0];
            ZM033( -3) ;
         }
         pr_default.close(3);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A11TableroFechaCreacion) || ( A11TableroFechaCreacion >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Tablero Fecha Creacion fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00034 */
         pr_default.execute(2, new Object[] {A17PropietarioId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Propietario'.", "ForeignKeyNotFound", 1, "PROPIETARIOID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( A11TableroFechaCreacion < Gx_date )
         {
            GX_msglist.addItem("La fecha del tablero no puede ser menor al dia de hoy", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors033( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor BC00036 */
         pr_default.execute(4, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00033 */
         pr_default.execute(1, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 3) ;
            RcdFound3 = 1;
            A9TableroId = BC00033_A9TableroId[0];
            A10TableroNombre = BC00033_A10TableroNombre[0];
            A11TableroFechaCreacion = BC00033_A11TableroFechaCreacion[0];
            A34TableroEstado = BC00033_A34TableroEstado[0];
            A35TableroVisibilidad = BC00033_A35TableroVisibilidad[0];
            A17PropietarioId = BC00033_A17PropietarioId[0];
            Z9TableroId = A9TableroId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode3;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
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
         CONFIRM_030( ) ;
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

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00032 */
            pr_default.execute(0, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tableros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z10TableroNombre, BC00032_A10TableroNombre[0]) != 0 ) || ( Z11TableroFechaCreacion != BC00032_A11TableroFechaCreacion[0] ) || ( Z34TableroEstado != BC00032_A34TableroEstado[0] ) || ( Z35TableroVisibilidad != BC00032_A35TableroVisibilidad[0] ) || ( Z17PropietarioId != BC00032_A17PropietarioId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Tableros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00037 */
                     pr_default.execute(5, new Object[] {A9TableroId, A10TableroNombre, A11TableroFechaCreacion, A34TableroEstado, A35TableroVisibilidad, A17PropietarioId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Tableros");
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00038 */
                     pr_default.execute(6, new Object[] {A10TableroNombre, A11TableroFechaCreacion, A34TableroEstado, A35TableroVisibilidad, A17PropietarioId, A9TableroId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Tableros");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tableros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00039 */
                  pr_default.execute(7, new Object[] {A9TableroId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("Tableros");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel033( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000310 */
            pr_default.execute(8, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {" T10"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000311 */
            pr_default.execute(9, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Participantes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000312 */
            pr_default.execute(10, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tableros Etiquetas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000313 */
            pr_default.execute(11, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Listas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000314 */
            pr_default.execute(12, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tareas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
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

      public void ScanKeyStart033( )
      {
         /* Using cursor BC000315 */
         pr_default.execute(13, new Object[] {A9TableroId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound3 = 1;
            A9TableroId = BC000315_A9TableroId[0];
            A10TableroNombre = BC000315_A10TableroNombre[0];
            A11TableroFechaCreacion = BC000315_A11TableroFechaCreacion[0];
            A34TableroEstado = BC000315_A34TableroEstado[0];
            A35TableroVisibilidad = BC000315_A35TableroVisibilidad[0];
            A17PropietarioId = BC000315_A17PropietarioId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound3 = 0;
         ScanKeyLoad033( ) ;
      }

      protected void ScanKeyLoad033( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound3 = 1;
            A9TableroId = BC000315_A9TableroId[0];
            A10TableroNombre = BC000315_A10TableroNombre[0];
            A11TableroFechaCreacion = BC000315_A11TableroFechaCreacion[0];
            A34TableroEstado = BC000315_A34TableroEstado[0];
            A35TableroVisibilidad = BC000315_A35TableroVisibilidad[0];
            A17PropietarioId = BC000315_A17PropietarioId[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd033( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void AddRow033( )
      {
         VarsToRow3( bcTableros) ;
      }

      protected void ReadRow033( )
      {
         RowToVars3( bcTableros, 1) ;
      }

      protected void InitializeNonKey033( )
      {
         A10TableroNombre = "";
         A11TableroFechaCreacion = (DateTime)(DateTime.MinValue);
         A17PropietarioId = 0;
         A34TableroEstado = false;
         A35TableroVisibilidad = false;
         Z10TableroNombre = "";
         Z11TableroFechaCreacion = (DateTime)(DateTime.MinValue);
         Z34TableroEstado = false;
         Z35TableroVisibilidad = false;
         Z17PropietarioId = 0;
      }

      protected void InitAll033( )
      {
         A9TableroId = 0;
         InitializeNonKey033( ) ;
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

      public void VarsToRow3( SdtTableros obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Tableronombre = A10TableroNombre;
         obj3.gxTpr_Tablerofechacreacion = A11TableroFechaCreacion;
         obj3.gxTpr_Propietarioid = A17PropietarioId;
         obj3.gxTpr_Tableroestado = A34TableroEstado;
         obj3.gxTpr_Tablerovisibilidad = A35TableroVisibilidad;
         obj3.gxTpr_Tableroid = A9TableroId;
         obj3.gxTpr_Tableroid_Z = Z9TableroId;
         obj3.gxTpr_Tableronombre_Z = Z10TableroNombre;
         obj3.gxTpr_Tablerofechacreacion_Z = Z11TableroFechaCreacion;
         obj3.gxTpr_Propietarioid_Z = Z17PropietarioId;
         obj3.gxTpr_Tableroestado_Z = Z34TableroEstado;
         obj3.gxTpr_Tablerovisibilidad_Z = Z35TableroVisibilidad;
         obj3.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow3( SdtTableros obj3 )
      {
         obj3.gxTpr_Tableroid = A9TableroId;
         return  ;
      }

      public void RowToVars3( SdtTableros obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A10TableroNombre = obj3.gxTpr_Tableronombre;
         A11TableroFechaCreacion = obj3.gxTpr_Tablerofechacreacion;
         A17PropietarioId = obj3.gxTpr_Propietarioid;
         A34TableroEstado = obj3.gxTpr_Tableroestado;
         A35TableroVisibilidad = obj3.gxTpr_Tablerovisibilidad;
         A9TableroId = obj3.gxTpr_Tableroid;
         Z9TableroId = obj3.gxTpr_Tableroid_Z;
         Z10TableroNombre = obj3.gxTpr_Tableronombre_Z;
         Z11TableroFechaCreacion = obj3.gxTpr_Tablerofechacreacion_Z;
         Z17PropietarioId = obj3.gxTpr_Propietarioid_Z;
         Z34TableroEstado = obj3.gxTpr_Tableroestado_Z;
         Z35TableroVisibilidad = obj3.gxTpr_Tablerovisibilidad_Z;
         Gx_mode = obj3.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A9TableroId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey033( ) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
         }
         ZM033( -3) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
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
         RowToVars3( bcTableros, 0) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
         }
         ZM033( -3) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert033( ) ;
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A9TableroId != Z9TableroId )
               {
                  A9TableroId = Z9TableroId;
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
                  Update033( ) ;
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
                  if ( A9TableroId != Z9TableroId )
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
                        Insert033( ) ;
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
                        Insert033( ) ;
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
         RowToVars3( bcTableros, 1) ;
         SaveImpl( ) ;
         VarsToRow3( bcTableros) ;
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
         RowToVars3( bcTableros, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
         AfterTrn( ) ;
         VarsToRow3( bcTableros) ;
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
            SdtTableros auxBC = new SdtTableros(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A9TableroId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTableros);
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
         RowToVars3( bcTableros, 1) ;
         UpdateImpl( ) ;
         VarsToRow3( bcTableros) ;
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
         RowToVars3( bcTableros, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
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
         VarsToRow3( bcTableros) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcTableros, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey033( ) ;
         if ( RcdFound3 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A9TableroId != Z9TableroId )
            {
               A9TableroId = Z9TableroId;
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
            if ( A9TableroId != Z9TableroId )
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
         context.RollbackDataStores("tableros_bc",pr_default);
         VarsToRow3( bcTableros) ;
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
         Gx_mode = bcTableros.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTableros.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTableros )
         {
            bcTableros = (SdtTableros)(sdt);
            if ( StringUtil.StrCmp(bcTableros.gxTpr_Mode, "") == 0 )
            {
               bcTableros.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow3( bcTableros) ;
            }
            else
            {
               RowToVars3( bcTableros, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTableros.gxTpr_Mode, "") == 0 )
            {
               bcTableros.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars3( bcTableros, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtTableros Tableros_BC
      {
         get {
            return bcTableros ;
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
         Z10TableroNombre = "";
         A10TableroNombre = "";
         Z11TableroFechaCreacion = (DateTime)(DateTime.MinValue);
         A11TableroFechaCreacion = (DateTime)(DateTime.MinValue);
         Gx_date = DateTime.MinValue;
         BC00035_A9TableroId = new short[1] ;
         BC00035_A10TableroNombre = new string[] {""} ;
         BC00035_A11TableroFechaCreacion = new DateTime[] {DateTime.MinValue} ;
         BC00035_A34TableroEstado = new bool[] {false} ;
         BC00035_A35TableroVisibilidad = new bool[] {false} ;
         BC00035_A17PropietarioId = new short[1] ;
         BC00034_A17PropietarioId = new short[1] ;
         BC00036_A9TableroId = new short[1] ;
         BC00033_A9TableroId = new short[1] ;
         BC00033_A10TableroNombre = new string[] {""} ;
         BC00033_A11TableroFechaCreacion = new DateTime[] {DateTime.MinValue} ;
         BC00033_A34TableroEstado = new bool[] {false} ;
         BC00033_A35TableroVisibilidad = new bool[] {false} ;
         BC00033_A17PropietarioId = new short[1] ;
         sMode3 = "";
         BC00032_A9TableroId = new short[1] ;
         BC00032_A10TableroNombre = new string[] {""} ;
         BC00032_A11TableroFechaCreacion = new DateTime[] {DateTime.MinValue} ;
         BC00032_A34TableroEstado = new bool[] {false} ;
         BC00032_A35TableroVisibilidad = new bool[] {false} ;
         BC00032_A17PropietarioId = new short[1] ;
         BC000310_A9TableroId = new short[1] ;
         BC000310_A40RegistroInvitadoId = new short[1] ;
         BC000311_A9TableroId = new short[1] ;
         BC000311_A18ParticipanteTableroId = new short[1] ;
         BC000312_A9TableroId = new short[1] ;
         BC000312_A36EtiquetaId = new short[1] ;
         BC000313_A9TableroId = new short[1] ;
         BC000313_A21ListaId = new short[1] ;
         BC000314_A9TableroId = new short[1] ;
         BC000314_A12TareaId = new short[1] ;
         BC000315_A9TableroId = new short[1] ;
         BC000315_A10TableroNombre = new string[] {""} ;
         BC000315_A11TableroFechaCreacion = new DateTime[] {DateTime.MinValue} ;
         BC000315_A34TableroEstado = new bool[] {false} ;
         BC000315_A35TableroVisibilidad = new bool[] {false} ;
         BC000315_A17PropietarioId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tableros_bc__default(),
            new Object[][] {
                new Object[] {
               BC00032_A9TableroId, BC00032_A10TableroNombre, BC00032_A11TableroFechaCreacion, BC00032_A34TableroEstado, BC00032_A35TableroVisibilidad, BC00032_A17PropietarioId
               }
               , new Object[] {
               BC00033_A9TableroId, BC00033_A10TableroNombre, BC00033_A11TableroFechaCreacion, BC00033_A34TableroEstado, BC00033_A35TableroVisibilidad, BC00033_A17PropietarioId
               }
               , new Object[] {
               BC00034_A17PropietarioId
               }
               , new Object[] {
               BC00035_A9TableroId, BC00035_A10TableroNombre, BC00035_A11TableroFechaCreacion, BC00035_A34TableroEstado, BC00035_A35TableroVisibilidad, BC00035_A17PropietarioId
               }
               , new Object[] {
               BC00036_A9TableroId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000310_A9TableroId, BC000310_A40RegistroInvitadoId
               }
               , new Object[] {
               BC000311_A9TableroId, BC000311_A18ParticipanteTableroId
               }
               , new Object[] {
               BC000312_A9TableroId, BC000312_A36EtiquetaId
               }
               , new Object[] {
               BC000313_A9TableroId, BC000313_A21ListaId
               }
               , new Object[] {
               BC000314_A9TableroId, BC000314_A12TareaId
               }
               , new Object[] {
               BC000315_A9TableroId, BC000315_A10TableroNombre, BC000315_A11TableroFechaCreacion, BC000315_A34TableroEstado, BC000315_A35TableroVisibilidad, BC000315_A17PropietarioId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
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
      private short GX_JID ;
      private short Z17PropietarioId ;
      private short A17PropietarioId ;
      private short RcdFound3 ;
      private short nIsDirty_3 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z10TableroNombre ;
      private string A10TableroNombre ;
      private string sMode3 ;
      private DateTime Z11TableroFechaCreacion ;
      private DateTime A11TableroFechaCreacion ;
      private DateTime Gx_date ;
      private bool Z34TableroEstado ;
      private bool A34TableroEstado ;
      private bool Z35TableroVisibilidad ;
      private bool A35TableroVisibilidad ;
      private bool mustCommit ;
      private SdtTableros bcTableros ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00035_A9TableroId ;
      private string[] BC00035_A10TableroNombre ;
      private DateTime[] BC00035_A11TableroFechaCreacion ;
      private bool[] BC00035_A34TableroEstado ;
      private bool[] BC00035_A35TableroVisibilidad ;
      private short[] BC00035_A17PropietarioId ;
      private short[] BC00034_A17PropietarioId ;
      private short[] BC00036_A9TableroId ;
      private short[] BC00033_A9TableroId ;
      private string[] BC00033_A10TableroNombre ;
      private DateTime[] BC00033_A11TableroFechaCreacion ;
      private bool[] BC00033_A34TableroEstado ;
      private bool[] BC00033_A35TableroVisibilidad ;
      private short[] BC00033_A17PropietarioId ;
      private short[] BC00032_A9TableroId ;
      private string[] BC00032_A10TableroNombre ;
      private DateTime[] BC00032_A11TableroFechaCreacion ;
      private bool[] BC00032_A34TableroEstado ;
      private bool[] BC00032_A35TableroVisibilidad ;
      private short[] BC00032_A17PropietarioId ;
      private short[] BC000310_A9TableroId ;
      private short[] BC000310_A40RegistroInvitadoId ;
      private short[] BC000311_A9TableroId ;
      private short[] BC000311_A18ParticipanteTableroId ;
      private short[] BC000312_A9TableroId ;
      private short[] BC000312_A36EtiquetaId ;
      private short[] BC000313_A9TableroId ;
      private short[] BC000313_A21ListaId ;
      private short[] BC000314_A9TableroId ;
      private short[] BC000314_A12TareaId ;
      private short[] BC000315_A9TableroId ;
      private string[] BC000315_A10TableroNombre ;
      private DateTime[] BC000315_A11TableroFechaCreacion ;
      private bool[] BC000315_A34TableroEstado ;
      private bool[] BC000315_A35TableroVisibilidad ;
      private short[] BC000315_A17PropietarioId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class tableros_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00035;
          prmBC00035 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC00034;
          prmBC00034 = new Object[] {
          new ParDef("@PropietarioId",GXType.Int16,4,0)
          };
          Object[] prmBC00036;
          prmBC00036 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC00033;
          prmBC00033 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC00032;
          prmBC00032 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC00037;
          prmBC00037 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TableroNombre",GXType.NChar,100,0) ,
          new ParDef("@TableroFechaCreacion",GXType.DateTime,8,5) ,
          new ParDef("@TableroEstado",GXType.Boolean,4,0) ,
          new ParDef("@TableroVisibilidad",GXType.Boolean,1,0) ,
          new ParDef("@PropietarioId",GXType.Int16,4,0)
          };
          Object[] prmBC00038;
          prmBC00038 = new Object[] {
          new ParDef("@TableroNombre",GXType.NChar,100,0) ,
          new ParDef("@TableroFechaCreacion",GXType.DateTime,8,5) ,
          new ParDef("@TableroEstado",GXType.Boolean,4,0) ,
          new ParDef("@TableroVisibilidad",GXType.Boolean,1,0) ,
          new ParDef("@PropietarioId",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC00039;
          prmBC00039 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC000310;
          prmBC000310 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC000311;
          prmBC000311 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC000312;
          prmBC000312 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC000313;
          prmBC000313 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC000314;
          prmBC000314 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC000315;
          prmBC000315 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00032", "SELECT [TableroId], [TableroNombre], [TableroFechaCreacion], [TableroEstado], [TableroVisibilidad], [PropietarioId] AS PropietarioId FROM [Tableros] WITH (UPDLOCK) WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00033", "SELECT [TableroId], [TableroNombre], [TableroFechaCreacion], [TableroEstado], [TableroVisibilidad], [PropietarioId] AS PropietarioId FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00034", "SELECT [UsuarioId] AS PropietarioId FROM [Usuarios] WHERE [UsuarioId] = @PropietarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00035", "SELECT TM1.[TableroId], TM1.[TableroNombre], TM1.[TableroFechaCreacion], TM1.[TableroEstado], TM1.[TableroVisibilidad], TM1.[PropietarioId] AS PropietarioId FROM [Tableros] TM1 WHERE TM1.[TableroId] = @TableroId ORDER BY TM1.[TableroId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00035,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00036", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00036,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00037", "INSERT INTO [Tableros]([TableroId], [TableroNombre], [TableroFechaCreacion], [TableroEstado], [TableroVisibilidad], [PropietarioId]) VALUES(@TableroId, @TableroNombre, @TableroFechaCreacion, @TableroEstado, @TableroVisibilidad, @PropietarioId)", GxErrorMask.GX_NOMASK,prmBC00037)
             ,new CursorDef("BC00038", "UPDATE [Tableros] SET [TableroNombre]=@TableroNombre, [TableroFechaCreacion]=@TableroFechaCreacion, [TableroEstado]=@TableroEstado, [TableroVisibilidad]=@TableroVisibilidad, [PropietarioId]=@PropietarioId  WHERE [TableroId] = @TableroId", GxErrorMask.GX_NOMASK,prmBC00038)
             ,new CursorDef("BC00039", "DELETE FROM [Tableros]  WHERE [TableroId] = @TableroId", GxErrorMask.GX_NOMASK,prmBC00039)
             ,new CursorDef("BC000310", "SELECT TOP 1 [TableroId], [RegistroInvitadoId] FROM [Invitados] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000310,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000311", "SELECT TOP 1 [TableroId], [ParticipanteTableroId] FROM [Participantes] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000311,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000312", "SELECT TOP 1 [TableroId], [EtiquetaId] FROM [TablerosEtiquetas] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000312,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000313", "SELECT TOP 1 [TableroId], [ListaId] FROM [Listas] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000313,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000314", "SELECT TOP 1 [TableroId], [TareaId] FROM [Tareas] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000314,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000315", "SELECT TM1.[TableroId], TM1.[TableroNombre], TM1.[TableroFechaCreacion], TM1.[TableroEstado], TM1.[TableroVisibilidad], TM1.[PropietarioId] AS PropietarioId FROM [Tableros] TM1 WHERE TM1.[TableroId] = @TableroId ORDER BY TM1.[TableroId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000315,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
