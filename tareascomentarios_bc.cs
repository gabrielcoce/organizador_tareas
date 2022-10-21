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
   public class tareascomentarios_bc : GXHttpHandler, IGxSilentTrn
   {
      public tareascomentarios_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public tareascomentarios_bc( IGxContext context )
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
         ReadRow088( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey088( ) ;
         standaloneModal( ) ;
         AddRow088( ) ;
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
               Z27ComentarioId = A27ComentarioId;
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

      protected void CONFIRM_080( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls088( ) ;
            }
            else
            {
               CheckExtendedTable088( ) ;
               if ( AnyError == 0 )
               {
                  ZM088( 3) ;
                  ZM088( 4) ;
               }
               CloseExtendedTableCursors088( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z28ComentarioTexto = A28ComentarioTexto;
            Z29ComentarioFecha = A29ComentarioFecha;
            Z26ComentaristaId = A26ComentaristaId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -2 )
         {
            Z27ComentarioId = A27ComentarioId;
            Z28ComentarioTexto = A28ComentarioTexto;
            Z29ComentarioFecha = A29ComentarioFecha;
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
            Z26ComentaristaId = A26ComentaristaId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load088( )
      {
         /* Using cursor BC00086 */
         pr_default.execute(4, new Object[] {A9TableroId, A12TareaId, A27ComentarioId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound8 = 1;
            A28ComentarioTexto = BC00086_A28ComentarioTexto[0];
            A29ComentarioFecha = BC00086_A29ComentarioFecha[0];
            A26ComentaristaId = BC00086_A26ComentaristaId[0];
            ZM088( -2) ;
         }
         pr_default.close(4);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
      }

      protected void CheckExtendedTable088( )
      {
         nIsDirty_8 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00084 */
         pr_default.execute(2, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tareas'.", "ForeignKeyNotFound", 1, "TAREAID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A29ComentarioFecha) || ( A29ComentarioFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Comentario Fecha fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00085 */
         pr_default.execute(3, new Object[] {A26ComentaristaId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Comentarista'.", "ForeignKeyNotFound", 1, "COMENTARISTAID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors088( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey088( )
      {
         /* Using cursor BC00087 */
         pr_default.execute(5, new Object[] {A9TableroId, A12TareaId, A27ComentarioId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00083 */
         pr_default.execute(1, new Object[] {A9TableroId, A12TareaId, A27ComentarioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM088( 2) ;
            RcdFound8 = 1;
            A27ComentarioId = BC00083_A27ComentarioId[0];
            A28ComentarioTexto = BC00083_A28ComentarioTexto[0];
            A29ComentarioFecha = BC00083_A29ComentarioFecha[0];
            A9TableroId = BC00083_A9TableroId[0];
            A12TareaId = BC00083_A12TareaId[0];
            A26ComentaristaId = BC00083_A26ComentaristaId[0];
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
            Z27ComentarioId = A27ComentarioId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load088( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey088( ) ;
            }
            Gx_mode = sMode8;
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode8;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey088( ) ;
         if ( RcdFound8 == 0 )
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
         CONFIRM_080( ) ;
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

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00082 */
            pr_default.execute(0, new Object[] {A9TableroId, A12TareaId, A27ComentarioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TareasComentarios"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z28ComentarioTexto, BC00082_A28ComentarioTexto[0]) != 0 ) || ( Z29ComentarioFecha != BC00082_A29ComentarioFecha[0] ) || ( Z26ComentaristaId != BC00082_A26ComentaristaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TareasComentarios"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00088 */
                     pr_default.execute(6, new Object[] {A27ComentarioId, A28ComentarioTexto, A29ComentarioFecha, A9TableroId, A12TareaId, A26ComentaristaId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("TareasComentarios");
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00089 */
                     pr_default.execute(7, new Object[] {A28ComentarioTexto, A29ComentarioFecha, A26ComentaristaId, A9TableroId, A12TareaId, A27ComentarioId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("TareasComentarios");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TareasComentarios"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate088( ) ;
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
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000810 */
                  pr_default.execute(8, new Object[] {A9TableroId, A12TareaId, A27ComentarioId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("TareasComentarios");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel088( ) ;
         Gx_mode = sMode8;
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel088( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete088( ) ;
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

      public void ScanKeyStart088( )
      {
         /* Using cursor BC000811 */
         pr_default.execute(9, new Object[] {A9TableroId, A12TareaId, A27ComentarioId});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound8 = 1;
            A27ComentarioId = BC000811_A27ComentarioId[0];
            A28ComentarioTexto = BC000811_A28ComentarioTexto[0];
            A29ComentarioFecha = BC000811_A29ComentarioFecha[0];
            A9TableroId = BC000811_A9TableroId[0];
            A12TareaId = BC000811_A12TareaId[0];
            A26ComentaristaId = BC000811_A26ComentaristaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound8 = 0;
         ScanKeyLoad088( ) ;
      }

      protected void ScanKeyLoad088( )
      {
         sMode8 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound8 = 1;
            A27ComentarioId = BC000811_A27ComentarioId[0];
            A28ComentarioTexto = BC000811_A28ComentarioTexto[0];
            A29ComentarioFecha = BC000811_A29ComentarioFecha[0];
            A9TableroId = BC000811_A9TableroId[0];
            A12TareaId = BC000811_A12TareaId[0];
            A26ComentaristaId = BC000811_A26ComentaristaId[0];
         }
         Gx_mode = sMode8;
      }

      protected void ScanKeyEnd088( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void AddRow088( )
      {
         VarsToRow8( bcTareasComentarios) ;
      }

      protected void ReadRow088( )
      {
         RowToVars8( bcTareasComentarios, 1) ;
      }

      protected void InitializeNonKey088( )
      {
         A28ComentarioTexto = "";
         A29ComentarioFecha = (DateTime)(DateTime.MinValue);
         A26ComentaristaId = 0;
         Z28ComentarioTexto = "";
         Z29ComentarioFecha = (DateTime)(DateTime.MinValue);
         Z26ComentaristaId = 0;
      }

      protected void InitAll088( )
      {
         A9TableroId = 0;
         A12TareaId = 0;
         A27ComentarioId = 0;
         InitializeNonKey088( ) ;
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

      public void VarsToRow8( SdtTareasComentarios obj8 )
      {
         obj8.gxTpr_Mode = Gx_mode;
         obj8.gxTpr_Comentariotexto = A28ComentarioTexto;
         obj8.gxTpr_Comentariofecha = A29ComentarioFecha;
         obj8.gxTpr_Comentaristaid = A26ComentaristaId;
         obj8.gxTpr_Tableroid = A9TableroId;
         obj8.gxTpr_Tareaid = A12TareaId;
         obj8.gxTpr_Comentarioid = A27ComentarioId;
         obj8.gxTpr_Tableroid_Z = Z9TableroId;
         obj8.gxTpr_Tareaid_Z = Z12TareaId;
         obj8.gxTpr_Comentarioid_Z = Z27ComentarioId;
         obj8.gxTpr_Comentariotexto_Z = Z28ComentarioTexto;
         obj8.gxTpr_Comentariofecha_Z = Z29ComentarioFecha;
         obj8.gxTpr_Comentaristaid_Z = Z26ComentaristaId;
         obj8.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow8( SdtTareasComentarios obj8 )
      {
         obj8.gxTpr_Tableroid = A9TableroId;
         obj8.gxTpr_Tareaid = A12TareaId;
         obj8.gxTpr_Comentarioid = A27ComentarioId;
         return  ;
      }

      public void RowToVars8( SdtTareasComentarios obj8 ,
                              int forceLoad )
      {
         Gx_mode = obj8.gxTpr_Mode;
         A28ComentarioTexto = obj8.gxTpr_Comentariotexto;
         A29ComentarioFecha = obj8.gxTpr_Comentariofecha;
         A26ComentaristaId = obj8.gxTpr_Comentaristaid;
         A9TableroId = obj8.gxTpr_Tableroid;
         A12TareaId = obj8.gxTpr_Tareaid;
         A27ComentarioId = obj8.gxTpr_Comentarioid;
         Z9TableroId = obj8.gxTpr_Tableroid_Z;
         Z12TareaId = obj8.gxTpr_Tareaid_Z;
         Z27ComentarioId = obj8.gxTpr_Comentarioid_Z;
         Z28ComentarioTexto = obj8.gxTpr_Comentariotexto_Z;
         Z29ComentarioFecha = obj8.gxTpr_Comentariofecha_Z;
         Z26ComentaristaId = obj8.gxTpr_Comentaristaid_Z;
         Gx_mode = obj8.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A9TableroId = (short)getParm(obj,0);
         A12TareaId = (short)getParm(obj,1);
         A27ComentarioId = (short)getParm(obj,2);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey088( ) ;
         ScanKeyStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000812 */
            pr_default.execute(10, new Object[] {A9TableroId, A12TareaId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("No existe 'Tareas'.", "ForeignKeyNotFound", 1, "TAREAID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
            Z27ComentarioId = A27ComentarioId;
         }
         ZM088( -2) ;
         OnLoadActions088( ) ;
         AddRow088( ) ;
         ScanKeyEnd088( ) ;
         if ( RcdFound8 == 0 )
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
         RowToVars8( bcTareasComentarios, 0) ;
         ScanKeyStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000812 */
            pr_default.execute(10, new Object[] {A9TableroId, A12TareaId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("No existe 'Tareas'.", "ForeignKeyNotFound", 1, "TAREAID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
            Z27ComentarioId = A27ComentarioId;
         }
         ZM088( -2) ;
         OnLoadActions088( ) ;
         AddRow088( ) ;
         ScanKeyEnd088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey088( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert088( ) ;
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) || ( A27ComentarioId != Z27ComentarioId ) )
               {
                  A9TableroId = Z9TableroId;
                  A12TareaId = Z12TareaId;
                  A27ComentarioId = Z27ComentarioId;
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
                  Update088( ) ;
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
                  if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) || ( A27ComentarioId != Z27ComentarioId ) )
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
                        Insert088( ) ;
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
                        Insert088( ) ;
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
         RowToVars8( bcTareasComentarios, 1) ;
         SaveImpl( ) ;
         VarsToRow8( bcTareasComentarios) ;
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
         RowToVars8( bcTareasComentarios, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert088( ) ;
         AfterTrn( ) ;
         VarsToRow8( bcTareasComentarios) ;
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
            SdtTareasComentarios auxBC = new SdtTareasComentarios(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A9TableroId, A12TareaId, A27ComentarioId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTareasComentarios);
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
         RowToVars8( bcTareasComentarios, 1) ;
         UpdateImpl( ) ;
         VarsToRow8( bcTareasComentarios) ;
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
         RowToVars8( bcTareasComentarios, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert088( ) ;
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
         VarsToRow8( bcTareasComentarios) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars8( bcTareasComentarios, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey088( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) || ( A27ComentarioId != Z27ComentarioId ) )
            {
               A9TableroId = Z9TableroId;
               A12TareaId = Z12TareaId;
               A27ComentarioId = Z27ComentarioId;
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
            if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) || ( A27ComentarioId != Z27ComentarioId ) )
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
         context.RollbackDataStores("tareascomentarios_bc",pr_default);
         VarsToRow8( bcTareasComentarios) ;
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
         Gx_mode = bcTareasComentarios.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTareasComentarios.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTareasComentarios )
         {
            bcTareasComentarios = (SdtTareasComentarios)(sdt);
            if ( StringUtil.StrCmp(bcTareasComentarios.gxTpr_Mode, "") == 0 )
            {
               bcTareasComentarios.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow8( bcTareasComentarios) ;
            }
            else
            {
               RowToVars8( bcTareasComentarios, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTareasComentarios.gxTpr_Mode, "") == 0 )
            {
               bcTareasComentarios.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars8( bcTareasComentarios, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtTareasComentarios TareasComentarios_BC
      {
         get {
            return bcTareasComentarios ;
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
         Z28ComentarioTexto = "";
         A28ComentarioTexto = "";
         Z29ComentarioFecha = (DateTime)(DateTime.MinValue);
         A29ComentarioFecha = (DateTime)(DateTime.MinValue);
         BC00086_A27ComentarioId = new short[1] ;
         BC00086_A28ComentarioTexto = new string[] {""} ;
         BC00086_A29ComentarioFecha = new DateTime[] {DateTime.MinValue} ;
         BC00086_A9TableroId = new short[1] ;
         BC00086_A12TareaId = new short[1] ;
         BC00086_A26ComentaristaId = new short[1] ;
         BC00084_A9TableroId = new short[1] ;
         BC00085_A26ComentaristaId = new short[1] ;
         BC00087_A9TableroId = new short[1] ;
         BC00087_A12TareaId = new short[1] ;
         BC00087_A27ComentarioId = new short[1] ;
         BC00083_A27ComentarioId = new short[1] ;
         BC00083_A28ComentarioTexto = new string[] {""} ;
         BC00083_A29ComentarioFecha = new DateTime[] {DateTime.MinValue} ;
         BC00083_A9TableroId = new short[1] ;
         BC00083_A12TareaId = new short[1] ;
         BC00083_A26ComentaristaId = new short[1] ;
         sMode8 = "";
         BC00082_A27ComentarioId = new short[1] ;
         BC00082_A28ComentarioTexto = new string[] {""} ;
         BC00082_A29ComentarioFecha = new DateTime[] {DateTime.MinValue} ;
         BC00082_A9TableroId = new short[1] ;
         BC00082_A12TareaId = new short[1] ;
         BC00082_A26ComentaristaId = new short[1] ;
         BC000811_A27ComentarioId = new short[1] ;
         BC000811_A28ComentarioTexto = new string[] {""} ;
         BC000811_A29ComentarioFecha = new DateTime[] {DateTime.MinValue} ;
         BC000811_A9TableroId = new short[1] ;
         BC000811_A12TareaId = new short[1] ;
         BC000811_A26ComentaristaId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000812_A9TableroId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tareascomentarios_bc__default(),
            new Object[][] {
                new Object[] {
               BC00082_A27ComentarioId, BC00082_A28ComentarioTexto, BC00082_A29ComentarioFecha, BC00082_A9TableroId, BC00082_A12TareaId, BC00082_A26ComentaristaId
               }
               , new Object[] {
               BC00083_A27ComentarioId, BC00083_A28ComentarioTexto, BC00083_A29ComentarioFecha, BC00083_A9TableroId, BC00083_A12TareaId, BC00083_A26ComentaristaId
               }
               , new Object[] {
               BC00084_A9TableroId
               }
               , new Object[] {
               BC00085_A26ComentaristaId
               }
               , new Object[] {
               BC00086_A27ComentarioId, BC00086_A28ComentarioTexto, BC00086_A29ComentarioFecha, BC00086_A9TableroId, BC00086_A12TareaId, BC00086_A26ComentaristaId
               }
               , new Object[] {
               BC00087_A9TableroId, BC00087_A12TareaId, BC00087_A27ComentarioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000811_A27ComentarioId, BC000811_A28ComentarioTexto, BC000811_A29ComentarioFecha, BC000811_A9TableroId, BC000811_A12TareaId, BC000811_A26ComentaristaId
               }
               , new Object[] {
               BC000812_A9TableroId
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
      private short Z27ComentarioId ;
      private short A27ComentarioId ;
      private short GX_JID ;
      private short Z26ComentaristaId ;
      private short A26ComentaristaId ;
      private short RcdFound8 ;
      private short nIsDirty_8 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z28ComentarioTexto ;
      private string A28ComentarioTexto ;
      private string sMode8 ;
      private DateTime Z29ComentarioFecha ;
      private DateTime A29ComentarioFecha ;
      private bool mustCommit ;
      private SdtTareasComentarios bcTareasComentarios ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00086_A27ComentarioId ;
      private string[] BC00086_A28ComentarioTexto ;
      private DateTime[] BC00086_A29ComentarioFecha ;
      private short[] BC00086_A9TableroId ;
      private short[] BC00086_A12TareaId ;
      private short[] BC00086_A26ComentaristaId ;
      private short[] BC00084_A9TableroId ;
      private short[] BC00085_A26ComentaristaId ;
      private short[] BC00087_A9TableroId ;
      private short[] BC00087_A12TareaId ;
      private short[] BC00087_A27ComentarioId ;
      private short[] BC00083_A27ComentarioId ;
      private string[] BC00083_A28ComentarioTexto ;
      private DateTime[] BC00083_A29ComentarioFecha ;
      private short[] BC00083_A9TableroId ;
      private short[] BC00083_A12TareaId ;
      private short[] BC00083_A26ComentaristaId ;
      private short[] BC00082_A27ComentarioId ;
      private string[] BC00082_A28ComentarioTexto ;
      private DateTime[] BC00082_A29ComentarioFecha ;
      private short[] BC00082_A9TableroId ;
      private short[] BC00082_A12TareaId ;
      private short[] BC00082_A26ComentaristaId ;
      private short[] BC000811_A27ComentarioId ;
      private string[] BC000811_A28ComentarioTexto ;
      private DateTime[] BC000811_A29ComentarioFecha ;
      private short[] BC000811_A9TableroId ;
      private short[] BC000811_A12TareaId ;
      private short[] BC000811_A26ComentaristaId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] BC000812_A9TableroId ;
   }

   public class tareascomentarios_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC00086;
          prmBC00086 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ComentarioId",GXType.Int16,4,0)
          };
          Object[] prmBC00084;
          prmBC00084 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmBC00085;
          prmBC00085 = new Object[] {
          new ParDef("@ComentaristaId",GXType.Int16,4,0)
          };
          Object[] prmBC00087;
          prmBC00087 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ComentarioId",GXType.Int16,4,0)
          };
          Object[] prmBC00083;
          prmBC00083 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ComentarioId",GXType.Int16,4,0)
          };
          Object[] prmBC00082;
          prmBC00082 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ComentarioId",GXType.Int16,4,0)
          };
          Object[] prmBC00088;
          prmBC00088 = new Object[] {
          new ParDef("@ComentarioId",GXType.Int16,4,0) ,
          new ParDef("@ComentarioTexto",GXType.NChar,200,0) ,
          new ParDef("@ComentarioFecha",GXType.DateTime,8,5) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ComentaristaId",GXType.Int16,4,0)
          };
          Object[] prmBC00089;
          prmBC00089 = new Object[] {
          new ParDef("@ComentarioTexto",GXType.NChar,200,0) ,
          new ParDef("@ComentarioFecha",GXType.DateTime,8,5) ,
          new ParDef("@ComentaristaId",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ComentarioId",GXType.Int16,4,0)
          };
          Object[] prmBC000810;
          prmBC000810 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ComentarioId",GXType.Int16,4,0)
          };
          Object[] prmBC000811;
          prmBC000811 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@ComentarioId",GXType.Int16,4,0)
          };
          Object[] prmBC000812;
          prmBC000812 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00082", "SELECT [ComentarioId], [ComentarioTexto], [ComentarioFecha], [TableroId], [TareaId], [ComentaristaId] AS ComentaristaId FROM [TareasComentarios] WITH (UPDLOCK) WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ComentarioId] = @ComentarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00083", "SELECT [ComentarioId], [ComentarioTexto], [ComentarioFecha], [TableroId], [TareaId], [ComentaristaId] AS ComentaristaId FROM [TareasComentarios] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ComentarioId] = @ComentarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00084", "SELECT [TableroId] FROM [Tareas] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00084,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00085", "SELECT [UsuarioId] AS ComentaristaId FROM [Usuarios] WHERE [UsuarioId] = @ComentaristaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00085,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00086", "SELECT TM1.[ComentarioId], TM1.[ComentarioTexto], TM1.[ComentarioFecha], TM1.[TableroId], TM1.[TareaId], TM1.[ComentaristaId] AS ComentaristaId FROM [TareasComentarios] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[TareaId] = @TareaId and TM1.[ComentarioId] = @ComentarioId ORDER BY TM1.[TableroId], TM1.[TareaId], TM1.[ComentarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00086,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00087", "SELECT [TableroId], [TareaId], [ComentarioId] FROM [TareasComentarios] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ComentarioId] = @ComentarioId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00087,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00088", "INSERT INTO [TareasComentarios]([ComentarioId], [ComentarioTexto], [ComentarioFecha], [TableroId], [TareaId], [ComentaristaId]) VALUES(@ComentarioId, @ComentarioTexto, @ComentarioFecha, @TableroId, @TareaId, @ComentaristaId)", GxErrorMask.GX_NOMASK,prmBC00088)
             ,new CursorDef("BC00089", "UPDATE [TareasComentarios] SET [ComentarioTexto]=@ComentarioTexto, [ComentarioFecha]=@ComentarioFecha, [ComentaristaId]=@ComentaristaId  WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ComentarioId] = @ComentarioId", GxErrorMask.GX_NOMASK,prmBC00089)
             ,new CursorDef("BC000810", "DELETE FROM [TareasComentarios]  WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId AND [ComentarioId] = @ComentarioId", GxErrorMask.GX_NOMASK,prmBC000810)
             ,new CursorDef("BC000811", "SELECT TM1.[ComentarioId], TM1.[ComentarioTexto], TM1.[ComentarioFecha], TM1.[TableroId], TM1.[TareaId], TM1.[ComentaristaId] AS ComentaristaId FROM [TareasComentarios] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[TareaId] = @TareaId and TM1.[ComentarioId] = @ComentarioId ORDER BY TM1.[TableroId], TM1.[TareaId], TM1.[ComentarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000811,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000812", "SELECT [TableroId] FROM [Tareas] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000812,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 200);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 200);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
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
                ((string[]) buf[1])[0] = rslt.getString(2, 200);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 200);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
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
