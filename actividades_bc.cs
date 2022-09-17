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
   public class actividades_bc : GXHttpHandler, IGxSilentTrn
   {
      public actividades_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public actividades_bc( IGxContext context )
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
         ReadRow099( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey099( ) ;
         standaloneModal( ) ;
         AddRow099( ) ;
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
               Z12TareaId = A12TareaId;
               Z30ActividadId = A30ActividadId;
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

      protected void CONFIRM_090( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls099( ) ;
            }
            else
            {
               CheckExtendedTable099( ) ;
               if ( AnyError == 0 )
               {
                  ZM099( 2) ;
               }
               CloseExtendedTableCursors099( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z31ActividadNombre = A31ActividadNombre;
            Z32ActividadAvance = A32ActividadAvance;
            Z33ActividadEstado = A33ActividadEstado;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z30ActividadId = A30ActividadId;
            Z31ActividadNombre = A31ActividadNombre;
            Z32ActividadAvance = A32ActividadAvance;
            Z33ActividadEstado = A33ActividadEstado;
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load099( )
      {
         /* Using cursor BC00095 */
         pr_default.execute(3, new Object[] {A9TableroId, A12TareaId, A30ActividadId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
            A31ActividadNombre = BC00095_A31ActividadNombre[0];
            A32ActividadAvance = BC00095_A32ActividadAvance[0];
            A33ActividadEstado = BC00095_A33ActividadEstado[0];
            ZM099( -1) ;
         }
         pr_default.close(3);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
      }

      protected void CheckExtendedTable099( )
      {
         nIsDirty_9 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00094 */
         pr_default.execute(2, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tareas'.", "ForeignKeyNotFound", 1, "TAREAID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors099( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey099( )
      {
         /* Using cursor BC00096 */
         pr_default.execute(4, new Object[] {A9TableroId, A12TareaId, A30ActividadId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00093 */
         pr_default.execute(1, new Object[] {A9TableroId, A12TareaId, A30ActividadId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM099( 1) ;
            RcdFound9 = 1;
            A30ActividadId = BC00093_A30ActividadId[0];
            A31ActividadNombre = BC00093_A31ActividadNombre[0];
            A32ActividadAvance = BC00093_A32ActividadAvance[0];
            A33ActividadEstado = BC00093_A33ActividadEstado[0];
            A9TableroId = BC00093_A9TableroId[0];
            A12TareaId = BC00093_A12TareaId[0];
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
            Z30ActividadId = A30ActividadId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
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
         CONFIRM_090( ) ;
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

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00092 */
            pr_default.execute(0, new Object[] {A9TableroId, A12TareaId, A30ActividadId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Actividades"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z31ActividadNombre, BC00092_A31ActividadNombre[0]) != 0 ) || ( Z32ActividadAvance != BC00092_A32ActividadAvance[0] ) || ( Z33ActividadEstado != BC00092_A33ActividadEstado[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Actividades"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00097 */
                     pr_default.execute(5, new Object[] {A30ActividadId, A31ActividadNombre, A32ActividadAvance, A33ActividadEstado, A9TableroId, A12TareaId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Actividades");
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
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00098 */
                     pr_default.execute(6, new Object[] {A31ActividadNombre, A32ActividadAvance, A33ActividadEstado, A9TableroId, A12TareaId, A30ActividadId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Actividades");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Actividades"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
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
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00099 */
                  pr_default.execute(7, new Object[] {A9TableroId, A12TareaId, A30ActividadId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("Actividades");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel099( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
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

      public void ScanKeyStart099( )
      {
         /* Using cursor BC000910 */
         pr_default.execute(8, new Object[] {A9TableroId, A12TareaId, A30ActividadId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound9 = 1;
            A30ActividadId = BC000910_A30ActividadId[0];
            A31ActividadNombre = BC000910_A31ActividadNombre[0];
            A32ActividadAvance = BC000910_A32ActividadAvance[0];
            A33ActividadEstado = BC000910_A33ActividadEstado[0];
            A9TableroId = BC000910_A9TableroId[0];
            A12TareaId = BC000910_A12TareaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound9 = 0;
         ScanKeyLoad099( ) ;
      }

      protected void ScanKeyLoad099( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound9 = 1;
            A30ActividadId = BC000910_A30ActividadId[0];
            A31ActividadNombre = BC000910_A31ActividadNombre[0];
            A32ActividadAvance = BC000910_A32ActividadAvance[0];
            A33ActividadEstado = BC000910_A33ActividadEstado[0];
            A9TableroId = BC000910_A9TableroId[0];
            A12TareaId = BC000910_A12TareaId[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd099( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void AddRow099( )
      {
         VarsToRow9( bcActividades) ;
      }

      protected void ReadRow099( )
      {
         RowToVars9( bcActividades, 1) ;
      }

      protected void InitializeNonKey099( )
      {
         A31ActividadNombre = "";
         A32ActividadAvance = 0;
         A33ActividadEstado = 0;
         Z31ActividadNombre = "";
         Z32ActividadAvance = 0;
         Z33ActividadEstado = 0;
      }

      protected void InitAll099( )
      {
         A9TableroId = 0;
         A12TareaId = 0;
         A30ActividadId = 0;
         InitializeNonKey099( ) ;
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

      public void VarsToRow9( SdtActividades obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Actividadnombre = A31ActividadNombre;
         obj9.gxTpr_Actividadavance = A32ActividadAvance;
         obj9.gxTpr_Actividadestado = A33ActividadEstado;
         obj9.gxTpr_Tableroid = A9TableroId;
         obj9.gxTpr_Tareaid = A12TareaId;
         obj9.gxTpr_Actividadid = A30ActividadId;
         obj9.gxTpr_Tableroid_Z = Z9TableroId;
         obj9.gxTpr_Tareaid_Z = Z12TareaId;
         obj9.gxTpr_Actividadid_Z = Z30ActividadId;
         obj9.gxTpr_Actividadnombre_Z = Z31ActividadNombre;
         obj9.gxTpr_Actividadavance_Z = Z32ActividadAvance;
         obj9.gxTpr_Actividadestado_Z = Z33ActividadEstado;
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( SdtActividades obj9 )
      {
         obj9.gxTpr_Tableroid = A9TableroId;
         obj9.gxTpr_Tareaid = A12TareaId;
         obj9.gxTpr_Actividadid = A30ActividadId;
         return  ;
      }

      public void RowToVars9( SdtActividades obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A31ActividadNombre = obj9.gxTpr_Actividadnombre;
         A32ActividadAvance = obj9.gxTpr_Actividadavance;
         A33ActividadEstado = obj9.gxTpr_Actividadestado;
         A9TableroId = obj9.gxTpr_Tableroid;
         A12TareaId = obj9.gxTpr_Tareaid;
         A30ActividadId = obj9.gxTpr_Actividadid;
         Z9TableroId = obj9.gxTpr_Tableroid_Z;
         Z12TareaId = obj9.gxTpr_Tareaid_Z;
         Z30ActividadId = obj9.gxTpr_Actividadid_Z;
         Z31ActividadNombre = obj9.gxTpr_Actividadnombre_Z;
         Z32ActividadAvance = obj9.gxTpr_Actividadavance_Z;
         Z33ActividadEstado = obj9.gxTpr_Actividadestado_Z;
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A9TableroId = (short)getParm(obj,0);
         A12TareaId = (short)getParm(obj,1);
         A30ActividadId = (short)getParm(obj,2);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey099( ) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000911 */
            pr_default.execute(9, new Object[] {A9TableroId, A12TareaId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("No existe 'Tareas'.", "ForeignKeyNotFound", 1, "TAREAID");
               AnyError = 1;
            }
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
            Z30ActividadId = A30ActividadId;
         }
         ZM099( -1) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
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
         RowToVars9( bcActividades, 0) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000911 */
            pr_default.execute(9, new Object[] {A9TableroId, A12TareaId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("No existe 'Tareas'.", "ForeignKeyNotFound", 1, "TAREAID");
               AnyError = 1;
            }
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
            Z30ActividadId = A30ActividadId;
         }
         ZM099( -1) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert099( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) || ( A30ActividadId != Z30ActividadId ) )
               {
                  A9TableroId = Z9TableroId;
                  A12TareaId = Z12TareaId;
                  A30ActividadId = Z30ActividadId;
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
                  Update099( ) ;
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
                  if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) || ( A30ActividadId != Z30ActividadId ) )
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
                        Insert099( ) ;
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
                        Insert099( ) ;
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
         RowToVars9( bcActividades, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcActividades) ;
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
         RowToVars9( bcActividades, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert099( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcActividades) ;
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
            SdtActividades auxBC = new SdtActividades(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A9TableroId, A12TareaId, A30ActividadId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcActividades);
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
         RowToVars9( bcActividades, 1) ;
         UpdateImpl( ) ;
         VarsToRow9( bcActividades) ;
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
         RowToVars9( bcActividades, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert099( ) ;
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
         VarsToRow9( bcActividades) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcActividades, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey099( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) || ( A30ActividadId != Z30ActividadId ) )
            {
               A9TableroId = Z9TableroId;
               A12TareaId = Z12TareaId;
               A30ActividadId = Z30ActividadId;
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
            if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) || ( A30ActividadId != Z30ActividadId ) )
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
         pr_default.close(9);
         context.RollbackDataStores("actividades_bc",pr_default);
         VarsToRow9( bcActividades) ;
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
         Gx_mode = bcActividades.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcActividades.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcActividades )
         {
            bcActividades = (SdtActividades)(sdt);
            if ( StringUtil.StrCmp(bcActividades.gxTpr_Mode, "") == 0 )
            {
               bcActividades.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcActividades) ;
            }
            else
            {
               RowToVars9( bcActividades, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcActividades.gxTpr_Mode, "") == 0 )
            {
               bcActividades.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcActividades, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtActividades Actividades_BC
      {
         get {
            return bcActividades ;
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z31ActividadNombre = "";
         A31ActividadNombre = "";
         BC00095_A30ActividadId = new short[1] ;
         BC00095_A31ActividadNombre = new string[] {""} ;
         BC00095_A32ActividadAvance = new short[1] ;
         BC00095_A33ActividadEstado = new short[1] ;
         BC00095_A9TableroId = new short[1] ;
         BC00095_A12TareaId = new short[1] ;
         BC00094_A9TableroId = new short[1] ;
         BC00096_A9TableroId = new short[1] ;
         BC00096_A12TareaId = new short[1] ;
         BC00096_A30ActividadId = new short[1] ;
         BC00093_A30ActividadId = new short[1] ;
         BC00093_A31ActividadNombre = new string[] {""} ;
         BC00093_A32ActividadAvance = new short[1] ;
         BC00093_A33ActividadEstado = new short[1] ;
         BC00093_A9TableroId = new short[1] ;
         BC00093_A12TareaId = new short[1] ;
         sMode9 = "";
         BC00092_A30ActividadId = new short[1] ;
         BC00092_A31ActividadNombre = new string[] {""} ;
         BC00092_A32ActividadAvance = new short[1] ;
         BC00092_A33ActividadEstado = new short[1] ;
         BC00092_A9TableroId = new short[1] ;
         BC00092_A12TareaId = new short[1] ;
         BC000910_A30ActividadId = new short[1] ;
         BC000910_A31ActividadNombre = new string[] {""} ;
         BC000910_A32ActividadAvance = new short[1] ;
         BC000910_A33ActividadEstado = new short[1] ;
         BC000910_A9TableroId = new short[1] ;
         BC000910_A12TareaId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000911_A9TableroId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actividades_bc__default(),
            new Object[][] {
                new Object[] {
               BC00092_A30ActividadId, BC00092_A31ActividadNombre, BC00092_A32ActividadAvance, BC00092_A33ActividadEstado, BC00092_A9TableroId, BC00092_A12TareaId
               }
               , new Object[] {
               BC00093_A30ActividadId, BC00093_A31ActividadNombre, BC00093_A32ActividadAvance, BC00093_A33ActividadEstado, BC00093_A9TableroId, BC00093_A12TareaId
               }
               , new Object[] {
               BC00094_A9TableroId
               }
               , new Object[] {
               BC00095_A30ActividadId, BC00095_A31ActividadNombre, BC00095_A32ActividadAvance, BC00095_A33ActividadEstado, BC00095_A9TableroId, BC00095_A12TareaId
               }
               , new Object[] {
               BC00096_A9TableroId, BC00096_A12TareaId, BC00096_A30ActividadId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000910_A30ActividadId, BC000910_A31ActividadNombre, BC000910_A32ActividadAvance, BC000910_A33ActividadEstado, BC000910_A9TableroId, BC000910_A12TareaId
               }
               , new Object[] {
               BC000911_A9TableroId
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
      private short Z12TareaId ;
      private short A12TareaId ;
      private short Z30ActividadId ;
      private short A30ActividadId ;
      private short GX_JID ;
      private short Z32ActividadAvance ;
      private short A32ActividadAvance ;
      private short Z33ActividadEstado ;
      private short A33ActividadEstado ;
      private short RcdFound9 ;
      private short nIsDirty_9 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z31ActividadNombre ;
      private string A31ActividadNombre ;
      private string sMode9 ;
      private bool mustCommit ;
      private SdtActividades bcActividades ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00095_A30ActividadId ;
      private string[] BC00095_A31ActividadNombre ;
      private short[] BC00095_A32ActividadAvance ;
      private short[] BC00095_A33ActividadEstado ;
      private short[] BC00095_A9TableroId ;
      private short[] BC00095_A12TareaId ;
      private short[] BC00094_A9TableroId ;
      private short[] BC00096_A9TableroId ;
      private short[] BC00096_A12TareaId ;
      private short[] BC00096_A30ActividadId ;
      private short[] BC00093_A30ActividadId ;
      private string[] BC00093_A31ActividadNombre ;
      private short[] BC00093_A32ActividadAvance ;
      private short[] BC00093_A33ActividadEstado ;
      private short[] BC00093_A9TableroId ;
      private short[] BC00093_A12TareaId ;
      private short[] BC00092_A30ActividadId ;
      private string[] BC00092_A31ActividadNombre ;
      private short[] BC00092_A32ActividadAvance ;
      private short[] BC00092_A33ActividadEstado ;
      private short[] BC00092_A9TableroId ;
      private short[] BC00092_A12TareaId ;
      private short[] BC000910_A30ActividadId ;
      private string[] BC000910_A31ActividadNombre ;
      private short[] BC000910_A32ActividadAvance ;
      private short[] BC000910_A33ActividadEstado ;
      private short[] BC000910_A9TableroId ;
      private short[] BC000910_A12TareaId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] BC000911_A9TableroId ;
   }

   public class actividades_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00095;
          prmBC00095 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmBC00094;
          prmBC00094 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmBC00096;
          prmBC00096 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmBC00093;
          prmBC00093 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmBC00092;
          prmBC00092 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmBC00097;
          prmBC00097 = new Object[] {
          new ParDef("@ActividadId",GXType.Int16,4,0) ,
          new ParDef("@ActividadNombre",GXType.NChar,20,0) ,
          new ParDef("@ActividadAvance",GXType.Int16,3,0) ,
          new ParDef("@ActividadEstado",GXType.Int16,1,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmBC00098;
          prmBC00098 = new Object[] {
          new ParDef("@ActividadNombre",GXType.NChar,20,0) ,
          new ParDef("@ActividadAvance",GXType.Int16,3,0) ,
          new ParDef("@ActividadEstado",GXType.Int16,1,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmBC00099;
          prmBC00099 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmBC000910;
          prmBC000910 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ActividadId",GXType.Int16,4,0)
          };
          Object[] prmBC000911;
          prmBC000911 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00092", "SELECT [ActividadId], [ActividadNombre], [ActividadAvance], [ActividadEstado], [TableroId], [TareaId] FROM [Actividades] WITH (UPDLOCK) WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ActividadId] = @ActividadId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00092,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00093", "SELECT [ActividadId], [ActividadNombre], [ActividadAvance], [ActividadEstado], [TableroId], [TareaId] FROM [Actividades] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ActividadId] = @ActividadId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00093,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00094", "SELECT [TableroId] FROM [Tareas] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00094,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00095", "SELECT TM1.[ActividadId], TM1.[ActividadNombre], TM1.[ActividadAvance], TM1.[ActividadEstado], TM1.[TableroId], TM1.[TareaId] FROM [Actividades] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[TareaId] = @TareaId and TM1.[ActividadId] = @ActividadId ORDER BY TM1.[TableroId], TM1.[TareaId], TM1.[ActividadId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00095,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00096", "SELECT [TableroId], [TareaId], [ActividadId] FROM [Actividades] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ActividadId] = @ActividadId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00096,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00097", "INSERT INTO [Actividades]([ActividadId], [ActividadNombre], [ActividadAvance], [ActividadEstado], [TableroId], [TareaId]) VALUES(@ActividadId, @ActividadNombre, @ActividadAvance, @ActividadEstado, @TableroId, @TareaId)", GxErrorMask.GX_NOMASK,prmBC00097)
             ,new CursorDef("BC00098", "UPDATE [Actividades] SET [ActividadNombre]=@ActividadNombre, [ActividadAvance]=@ActividadAvance, [ActividadEstado]=@ActividadEstado  WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ActividadId] = @ActividadId", GxErrorMask.GX_NOMASK,prmBC00098)
             ,new CursorDef("BC00099", "DELETE FROM [Actividades]  WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ActividadId] = @ActividadId", GxErrorMask.GX_NOMASK,prmBC00099)
             ,new CursorDef("BC000910", "SELECT TM1.[ActividadId], TM1.[ActividadNombre], TM1.[ActividadAvance], TM1.[ActividadEstado], TM1.[TableroId], TM1.[TareaId] FROM [Actividades] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[TareaId] = @TareaId and TM1.[ActividadId] = @ActividadId ORDER BY TM1.[TableroId], TM1.[TareaId], TM1.[ActividadId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000910,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000911", "SELECT [TableroId] FROM [Tareas] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000911,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
