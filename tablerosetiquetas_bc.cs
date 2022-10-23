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
   public class tablerosetiquetas_bc : GXHttpHandler, IGxSilentTrn
   {
      public tablerosetiquetas_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public tablerosetiquetas_bc( IGxContext context )
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
         ReadRow0A10( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0A10( ) ;
         standaloneModal( ) ;
         AddRow0A10( ) ;
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
               Z36EtiquetaId = A36EtiquetaId;
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

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A10( ) ;
            }
            else
            {
               CheckExtendedTable0A10( ) ;
               if ( AnyError == 0 )
               {
                  ZM0A10( 2) ;
               }
               CloseExtendedTableCursors0A10( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0A10( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z37EtiquetaNombre = A37EtiquetaNombre;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z36EtiquetaId = A36EtiquetaId;
            Z37EtiquetaNombre = A37EtiquetaNombre;
            Z9TableroId = A9TableroId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0A10( )
      {
         /* Using cursor BC000A5 */
         pr_default.execute(3, new Object[] {A9TableroId, A36EtiquetaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound10 = 1;
            A37EtiquetaNombre = BC000A5_A37EtiquetaNombre[0];
            ZM0A10( -1) ;
         }
         pr_default.close(3);
         OnLoadActions0A10( ) ;
      }

      protected void OnLoadActions0A10( )
      {
      }

      protected void CheckExtendedTable0A10( )
      {
         nIsDirty_10 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000A4 */
         pr_default.execute(2, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0A10( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0A10( )
      {
         /* Using cursor BC000A6 */
         pr_default.execute(4, new Object[] {A9TableroId, A36EtiquetaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000A3 */
         pr_default.execute(1, new Object[] {A9TableroId, A36EtiquetaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A10( 1) ;
            RcdFound10 = 1;
            A36EtiquetaId = BC000A3_A36EtiquetaId[0];
            A37EtiquetaNombre = BC000A3_A37EtiquetaNombre[0];
            A9TableroId = BC000A3_A9TableroId[0];
            Z9TableroId = A9TableroId;
            Z36EtiquetaId = A36EtiquetaId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0A10( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0A10( ) ;
            }
            Gx_mode = sMode10;
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0A10( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode10;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A10( ) ;
         if ( RcdFound10 == 0 )
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
         CONFIRM_0A0( ) ;
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

      protected void CheckOptimisticConcurrency0A10( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000A2 */
            pr_default.execute(0, new Object[] {A9TableroId, A36EtiquetaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TablerosEtiquetas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z37EtiquetaNombre, BC000A2_A37EtiquetaNombre[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TablerosEtiquetas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A10( 0) ;
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A7 */
                     pr_default.execute(5, new Object[] {A36EtiquetaId, A37EtiquetaNombre, A9TableroId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("TablerosEtiquetas");
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
               Load0A10( ) ;
            }
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void Update0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A8 */
                     pr_default.execute(6, new Object[] {A37EtiquetaNombre, A9TableroId, A36EtiquetaId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("TablerosEtiquetas");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TablerosEtiquetas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A10( ) ;
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
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void DeferredUpdate0A10( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A10( ) ;
            AfterConfirm0A10( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A10( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000A9 */
                  pr_default.execute(7, new Object[] {A9TableroId, A36EtiquetaId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("TablerosEtiquetas");
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0A10( ) ;
         Gx_mode = sMode10;
      }

      protected void OnDeleteControls0A10( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0A10( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A10( ) ;
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

      public void ScanKeyStart0A10( )
      {
         /* Using cursor BC000A10 */
         pr_default.execute(8, new Object[] {A9TableroId, A36EtiquetaId});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound10 = 1;
            A36EtiquetaId = BC000A10_A36EtiquetaId[0];
            A37EtiquetaNombre = BC000A10_A37EtiquetaNombre[0];
            A9TableroId = BC000A10_A9TableroId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0A10( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound10 = 0;
         ScanKeyLoad0A10( ) ;
      }

      protected void ScanKeyLoad0A10( )
      {
         sMode10 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound10 = 1;
            A36EtiquetaId = BC000A10_A36EtiquetaId[0];
            A37EtiquetaNombre = BC000A10_A37EtiquetaNombre[0];
            A9TableroId = BC000A10_A9TableroId[0];
         }
         Gx_mode = sMode10;
      }

      protected void ScanKeyEnd0A10( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0A10( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A10( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A10( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A10( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A10( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A10( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A10( )
      {
      }

      protected void send_integrity_lvl_hashes0A10( )
      {
      }

      protected void AddRow0A10( )
      {
         VarsToRow10( bcTablerosEtiquetas) ;
      }

      protected void ReadRow0A10( )
      {
         RowToVars10( bcTablerosEtiquetas, 1) ;
      }

      protected void InitializeNonKey0A10( )
      {
         A37EtiquetaNombre = "";
         Z37EtiquetaNombre = "";
      }

      protected void InitAll0A10( )
      {
         A9TableroId = 0;
         A36EtiquetaId = 0;
         InitializeNonKey0A10( ) ;
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

      public void VarsToRow10( SdtTablerosEtiquetas obj10 )
      {
         obj10.gxTpr_Mode = Gx_mode;
         obj10.gxTpr_Etiquetanombre = A37EtiquetaNombre;
         obj10.gxTpr_Tableroid = A9TableroId;
         obj10.gxTpr_Etiquetaid = A36EtiquetaId;
         obj10.gxTpr_Tableroid_Z = Z9TableroId;
         obj10.gxTpr_Etiquetaid_Z = Z36EtiquetaId;
         obj10.gxTpr_Etiquetanombre_Z = Z37EtiquetaNombre;
         obj10.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow10( SdtTablerosEtiquetas obj10 )
      {
         obj10.gxTpr_Tableroid = A9TableroId;
         obj10.gxTpr_Etiquetaid = A36EtiquetaId;
         return  ;
      }

      public void RowToVars10( SdtTablerosEtiquetas obj10 ,
                               int forceLoad )
      {
         Gx_mode = obj10.gxTpr_Mode;
         A37EtiquetaNombre = obj10.gxTpr_Etiquetanombre;
         A9TableroId = obj10.gxTpr_Tableroid;
         A36EtiquetaId = obj10.gxTpr_Etiquetaid;
         Z9TableroId = obj10.gxTpr_Tableroid_Z;
         Z36EtiquetaId = obj10.gxTpr_Etiquetaid_Z;
         Z37EtiquetaNombre = obj10.gxTpr_Etiquetanombre_Z;
         Gx_mode = obj10.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A9TableroId = (short)getParm(obj,0);
         A36EtiquetaId = (short)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0A10( ) ;
         ScanKeyStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000A11 */
            pr_default.execute(9, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
               AnyError = 1;
            }
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
            Z36EtiquetaId = A36EtiquetaId;
         }
         ZM0A10( -1) ;
         OnLoadActions0A10( ) ;
         AddRow0A10( ) ;
         ScanKeyEnd0A10( ) ;
         if ( RcdFound10 == 0 )
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
         RowToVars10( bcTablerosEtiquetas, 0) ;
         ScanKeyStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000A11 */
            pr_default.execute(9, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
               AnyError = 1;
            }
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
            Z36EtiquetaId = A36EtiquetaId;
         }
         ZM0A10( -1) ;
         OnLoadActions0A10( ) ;
         AddRow0A10( ) ;
         ScanKeyEnd0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0A10( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0A10( ) ;
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A36EtiquetaId != Z36EtiquetaId ) )
               {
                  A9TableroId = Z9TableroId;
                  A36EtiquetaId = Z36EtiquetaId;
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
                  Update0A10( ) ;
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
                  if ( ( A9TableroId != Z9TableroId ) || ( A36EtiquetaId != Z36EtiquetaId ) )
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
                        Insert0A10( ) ;
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
                        Insert0A10( ) ;
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
         RowToVars10( bcTablerosEtiquetas, 1) ;
         SaveImpl( ) ;
         VarsToRow10( bcTablerosEtiquetas) ;
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
         RowToVars10( bcTablerosEtiquetas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A10( ) ;
         AfterTrn( ) ;
         VarsToRow10( bcTablerosEtiquetas) ;
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
            SdtTablerosEtiquetas auxBC = new SdtTablerosEtiquetas(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A9TableroId, A36EtiquetaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTablerosEtiquetas);
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
         RowToVars10( bcTablerosEtiquetas, 1) ;
         UpdateImpl( ) ;
         VarsToRow10( bcTablerosEtiquetas) ;
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
         RowToVars10( bcTablerosEtiquetas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A10( ) ;
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
         VarsToRow10( bcTablerosEtiquetas) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars10( bcTablerosEtiquetas, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0A10( ) ;
         if ( RcdFound10 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A9TableroId != Z9TableroId ) || ( A36EtiquetaId != Z36EtiquetaId ) )
            {
               A9TableroId = Z9TableroId;
               A36EtiquetaId = Z36EtiquetaId;
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
            if ( ( A9TableroId != Z9TableroId ) || ( A36EtiquetaId != Z36EtiquetaId ) )
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
         context.RollbackDataStores("tablerosetiquetas_bc",pr_default);
         VarsToRow10( bcTablerosEtiquetas) ;
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
         Gx_mode = bcTablerosEtiquetas.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTablerosEtiquetas.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTablerosEtiquetas )
         {
            bcTablerosEtiquetas = (SdtTablerosEtiquetas)(sdt);
            if ( StringUtil.StrCmp(bcTablerosEtiquetas.gxTpr_Mode, "") == 0 )
            {
               bcTablerosEtiquetas.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow10( bcTablerosEtiquetas) ;
            }
            else
            {
               RowToVars10( bcTablerosEtiquetas, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTablerosEtiquetas.gxTpr_Mode, "") == 0 )
            {
               bcTablerosEtiquetas.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars10( bcTablerosEtiquetas, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtTablerosEtiquetas TablerosEtiquetas_BC
      {
         get {
            return bcTablerosEtiquetas ;
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
         Z37EtiquetaNombre = "";
         A37EtiquetaNombre = "";
         BC000A5_A36EtiquetaId = new short[1] ;
         BC000A5_A37EtiquetaNombre = new string[] {""} ;
         BC000A5_A9TableroId = new short[1] ;
         BC000A4_A9TableroId = new short[1] ;
         BC000A6_A9TableroId = new short[1] ;
         BC000A6_A36EtiquetaId = new short[1] ;
         BC000A3_A36EtiquetaId = new short[1] ;
         BC000A3_A37EtiquetaNombre = new string[] {""} ;
         BC000A3_A9TableroId = new short[1] ;
         sMode10 = "";
         BC000A2_A36EtiquetaId = new short[1] ;
         BC000A2_A37EtiquetaNombre = new string[] {""} ;
         BC000A2_A9TableroId = new short[1] ;
         BC000A10_A36EtiquetaId = new short[1] ;
         BC000A10_A37EtiquetaNombre = new string[] {""} ;
         BC000A10_A9TableroId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000A11_A9TableroId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tablerosetiquetas_bc__default(),
            new Object[][] {
                new Object[] {
               BC000A2_A36EtiquetaId, BC000A2_A37EtiquetaNombre, BC000A2_A9TableroId
               }
               , new Object[] {
               BC000A3_A36EtiquetaId, BC000A3_A37EtiquetaNombre, BC000A3_A9TableroId
               }
               , new Object[] {
               BC000A4_A9TableroId
               }
               , new Object[] {
               BC000A5_A36EtiquetaId, BC000A5_A37EtiquetaNombre, BC000A5_A9TableroId
               }
               , new Object[] {
               BC000A6_A9TableroId, BC000A6_A36EtiquetaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A10_A36EtiquetaId, BC000A10_A37EtiquetaNombre, BC000A10_A9TableroId
               }
               , new Object[] {
               BC000A11_A9TableroId
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
      private short Z36EtiquetaId ;
      private short A36EtiquetaId ;
      private short GX_JID ;
      private short RcdFound10 ;
      private short nIsDirty_10 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z37EtiquetaNombre ;
      private string A37EtiquetaNombre ;
      private string sMode10 ;
      private bool mustCommit ;
      private SdtTablerosEtiquetas bcTablerosEtiquetas ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000A5_A36EtiquetaId ;
      private string[] BC000A5_A37EtiquetaNombre ;
      private short[] BC000A5_A9TableroId ;
      private short[] BC000A4_A9TableroId ;
      private short[] BC000A6_A9TableroId ;
      private short[] BC000A6_A36EtiquetaId ;
      private short[] BC000A3_A36EtiquetaId ;
      private string[] BC000A3_A37EtiquetaNombre ;
      private short[] BC000A3_A9TableroId ;
      private short[] BC000A2_A36EtiquetaId ;
      private string[] BC000A2_A37EtiquetaNombre ;
      private short[] BC000A2_A9TableroId ;
      private short[] BC000A10_A36EtiquetaId ;
      private string[] BC000A10_A37EtiquetaNombre ;
      private short[] BC000A10_A9TableroId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] BC000A11_A9TableroId ;
   }

   public class tablerosetiquetas_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC000A5;
          prmBC000A5 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@EtiquetaId",GXType.Int16,4,0)
          };
          Object[] prmBC000A4;
          prmBC000A4 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC000A6;
          prmBC000A6 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@EtiquetaId",GXType.Int16,4,0)
          };
          Object[] prmBC000A3;
          prmBC000A3 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@EtiquetaId",GXType.Int16,4,0)
          };
          Object[] prmBC000A2;
          prmBC000A2 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@EtiquetaId",GXType.Int16,4,0)
          };
          Object[] prmBC000A7;
          prmBC000A7 = new Object[] {
          new ParDef("@EtiquetaId",GXType.Int16,4,0) ,
          new ParDef("@EtiquetaNombre",GXType.NChar,20,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC000A8;
          prmBC000A8 = new Object[] {
          new ParDef("@EtiquetaNombre",GXType.NChar,20,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@EtiquetaId",GXType.Int16,4,0)
          };
          Object[] prmBC000A9;
          prmBC000A9 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@EtiquetaId",GXType.Int16,4,0)
          };
          Object[] prmBC000A10;
          prmBC000A10 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@EtiquetaId",GXType.Int16,4,0)
          };
          Object[] prmBC000A11;
          prmBC000A11 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000A2", "SELECT [EtiquetaId], [EtiquetaNombre], [TableroId] FROM [TablerosEtiquetas] WITH (UPDLOCK) WHERE [TableroId] = @TableroId AND [EtiquetaId] = @EtiquetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A3", "SELECT [EtiquetaId], [EtiquetaNombre], [TableroId] FROM [TablerosEtiquetas] WHERE [TableroId] = @TableroId AND [EtiquetaId] = @EtiquetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A4", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A5", "SELECT TM1.[EtiquetaId], TM1.[EtiquetaNombre], TM1.[TableroId] FROM [TablerosEtiquetas] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[EtiquetaId] = @EtiquetaId ORDER BY TM1.[TableroId], TM1.[EtiquetaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A6", "SELECT [TableroId], [EtiquetaId] FROM [TablerosEtiquetas] WHERE [TableroId] = @TableroId AND [EtiquetaId] = @EtiquetaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A7", "INSERT INTO [TablerosEtiquetas]([EtiquetaId], [EtiquetaNombre], [TableroId]) VALUES(@EtiquetaId, @EtiquetaNombre, @TableroId)", GxErrorMask.GX_NOMASK,prmBC000A7)
             ,new CursorDef("BC000A8", "UPDATE [TablerosEtiquetas] SET [EtiquetaNombre]=@EtiquetaNombre  WHERE [TableroId] = @TableroId AND [EtiquetaId] = @EtiquetaId", GxErrorMask.GX_NOMASK,prmBC000A8)
             ,new CursorDef("BC000A9", "DELETE FROM [TablerosEtiquetas]  WHERE [TableroId] = @TableroId AND [EtiquetaId] = @EtiquetaId", GxErrorMask.GX_NOMASK,prmBC000A9)
             ,new CursorDef("BC000A10", "SELECT TM1.[EtiquetaId], TM1.[EtiquetaNombre], TM1.[TableroId] FROM [TablerosEtiquetas] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[EtiquetaId] = @EtiquetaId ORDER BY TM1.[TableroId], TM1.[EtiquetaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A11", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A11,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
