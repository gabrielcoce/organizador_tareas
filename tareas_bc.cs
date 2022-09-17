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
   public class tareas_bc : GXHttpHandler, IGxSilentTrn
   {
      public tareas_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public tareas_bc( IGxContext context )
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
         ReadRow044( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey044( ) ;
         standaloneModal( ) ;
         AddRow044( ) ;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls044( ) ;
            }
            else
            {
               CheckExtendedTable044( ) ;
               if ( AnyError == 0 )
               {
                  ZM044( 4) ;
                  ZM044( 5) ;
               }
               CloseExtendedTableCursors044( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z13TareaNombre = A13TareaNombre;
            Z24TareaFechaInicio = A24TareaFechaInicio;
            Z25TareaFechaFin = A25TareaFechaFin;
            Z46TareaEstado = A46TareaEstado;
            Z23ResponsableId = A23ResponsableId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -3 )
         {
            Z12TareaId = A12TareaId;
            Z13TareaNombre = A13TareaNombre;
            Z24TareaFechaInicio = A24TareaFechaInicio;
            Z25TareaFechaFin = A25TareaFechaFin;
            Z38TareaEtiquetas = A38TareaEtiquetas;
            Z46TareaEstado = A46TareaEstado;
            Z9TableroId = A9TableroId;
            Z23ResponsableId = A23ResponsableId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load044( )
      {
         /* Using cursor BC00046 */
         pr_default.execute(4, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound4 = 1;
            A13TareaNombre = BC00046_A13TareaNombre[0];
            A24TareaFechaInicio = BC00046_A24TareaFechaInicio[0];
            A25TareaFechaFin = BC00046_A25TareaFechaFin[0];
            A38TareaEtiquetas = BC00046_A38TareaEtiquetas[0];
            A46TareaEstado = BC00046_A46TareaEstado[0];
            A23ResponsableId = BC00046_A23ResponsableId[0];
            n23ResponsableId = BC00046_n23ResponsableId[0];
            ZM044( -3) ;
         }
         pr_default.close(4);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         nIsDirty_4 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {n23ResponsableId, A23ResponsableId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A23ResponsableId) ) )
            {
               GX_msglist.addItem("No existe 'Responsable'.", "ForeignKeyNotFound", 1, "RESPONSABLEID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A24TareaFechaInicio) || ( DateTimeUtil.ResetTime ( A24TareaFechaInicio ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Tarea Fecha Inicio fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A25TareaFechaFin) || ( DateTimeUtil.ResetTime ( A25TareaFechaFin ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Tarea Fecha Fin fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey044( )
      {
         /* Using cursor BC00047 */
         pr_default.execute(5, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {A9TableroId, A12TareaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 3) ;
            RcdFound4 = 1;
            A12TareaId = BC00043_A12TareaId[0];
            A13TareaNombre = BC00043_A13TareaNombre[0];
            A24TareaFechaInicio = BC00043_A24TareaFechaInicio[0];
            A25TareaFechaFin = BC00043_A25TareaFechaFin[0];
            A38TareaEtiquetas = BC00043_A38TareaEtiquetas[0];
            A46TareaEstado = BC00043_A46TareaEstado[0];
            A9TableroId = BC00043_A9TableroId[0];
            A23ResponsableId = BC00043_A23ResponsableId[0];
            n23ResponsableId = BC00043_n23ResponsableId[0];
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode4;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
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
         CONFIRM_040( ) ;
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

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {A9TableroId, A12TareaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tareas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z13TareaNombre, BC00042_A13TareaNombre[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z24TareaFechaInicio ) != DateTimeUtil.ResetTime ( BC00042_A24TareaFechaInicio[0] ) ) || ( DateTimeUtil.ResetTime ( Z25TareaFechaFin ) != DateTimeUtil.ResetTime ( BC00042_A25TareaFechaFin[0] ) ) || ( Z46TareaEstado != BC00042_A46TareaEstado[0] ) || ( Z23ResponsableId != BC00042_A23ResponsableId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Tareas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00048 */
                     pr_default.execute(6, new Object[] {A12TareaId, A13TareaNombre, A24TareaFechaInicio, A25TareaFechaFin, A38TareaEtiquetas, A46TareaEstado, A9TableroId, n23ResponsableId, A23ResponsableId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Tareas");
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00049 */
                     pr_default.execute(7, new Object[] {A13TareaNombre, A24TareaFechaInicio, A25TareaFechaFin, A38TareaEtiquetas, A46TareaEstado, n23ResponsableId, A23ResponsableId, A9TableroId, A12TareaId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Tareas");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tareas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000410 */
                  pr_default.execute(8, new Object[] {A9TableroId, A12TareaId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Tareas");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel044( ) ;
         Gx_mode = sMode4;
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000411 */
            pr_default.execute(9, new Object[] {A9TableroId, A12TareaId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Actividades"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000412 */
            pr_default.execute(10, new Object[] {A9TableroId, A12TareaId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tareas Comentarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
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

      public void ScanKeyStart044( )
      {
         /* Using cursor BC000413 */
         pr_default.execute(11, new Object[] {A9TableroId, A12TareaId});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound4 = 1;
            A12TareaId = BC000413_A12TareaId[0];
            A13TareaNombre = BC000413_A13TareaNombre[0];
            A24TareaFechaInicio = BC000413_A24TareaFechaInicio[0];
            A25TareaFechaFin = BC000413_A25TareaFechaFin[0];
            A38TareaEtiquetas = BC000413_A38TareaEtiquetas[0];
            A46TareaEstado = BC000413_A46TareaEstado[0];
            A9TableroId = BC000413_A9TableroId[0];
            A23ResponsableId = BC000413_A23ResponsableId[0];
            n23ResponsableId = BC000413_n23ResponsableId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound4 = 0;
         ScanKeyLoad044( ) ;
      }

      protected void ScanKeyLoad044( )
      {
         sMode4 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound4 = 1;
            A12TareaId = BC000413_A12TareaId[0];
            A13TareaNombre = BC000413_A13TareaNombre[0];
            A24TareaFechaInicio = BC000413_A24TareaFechaInicio[0];
            A25TareaFechaFin = BC000413_A25TareaFechaFin[0];
            A38TareaEtiquetas = BC000413_A38TareaEtiquetas[0];
            A46TareaEstado = BC000413_A46TareaEstado[0];
            A9TableroId = BC000413_A9TableroId[0];
            A23ResponsableId = BC000413_A23ResponsableId[0];
            n23ResponsableId = BC000413_n23ResponsableId[0];
         }
         Gx_mode = sMode4;
      }

      protected void ScanKeyEnd044( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void AddRow044( )
      {
         VarsToRow4( bcTareas) ;
      }

      protected void ReadRow044( )
      {
         RowToVars4( bcTareas, 1) ;
      }

      protected void InitializeNonKey044( )
      {
         A13TareaNombre = "";
         A23ResponsableId = 0;
         n23ResponsableId = false;
         A24TareaFechaInicio = DateTime.MinValue;
         A25TareaFechaFin = DateTime.MinValue;
         A38TareaEtiquetas = "";
         A46TareaEstado = 0;
         Z13TareaNombre = "";
         Z24TareaFechaInicio = DateTime.MinValue;
         Z25TareaFechaFin = DateTime.MinValue;
         Z46TareaEstado = 0;
         Z23ResponsableId = 0;
      }

      protected void InitAll044( )
      {
         A9TableroId = 0;
         A12TareaId = 0;
         InitializeNonKey044( ) ;
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

      public void VarsToRow4( SdtTareas obj4 )
      {
         obj4.gxTpr_Mode = Gx_mode;
         obj4.gxTpr_Tareanombre = A13TareaNombre;
         obj4.gxTpr_Responsableid = A23ResponsableId;
         obj4.gxTpr_Tareafechainicio = A24TareaFechaInicio;
         obj4.gxTpr_Tareafechafin = A25TareaFechaFin;
         obj4.gxTpr_Tareaetiquetas = A38TareaEtiquetas;
         obj4.gxTpr_Tareaestado = A46TareaEstado;
         obj4.gxTpr_Tableroid = A9TableroId;
         obj4.gxTpr_Tareaid = A12TareaId;
         obj4.gxTpr_Tableroid_Z = Z9TableroId;
         obj4.gxTpr_Tareaid_Z = Z12TareaId;
         obj4.gxTpr_Tareanombre_Z = Z13TareaNombre;
         obj4.gxTpr_Responsableid_Z = Z23ResponsableId;
         obj4.gxTpr_Tareafechainicio_Z = Z24TareaFechaInicio;
         obj4.gxTpr_Tareafechafin_Z = Z25TareaFechaFin;
         obj4.gxTpr_Tareaestado_Z = Z46TareaEstado;
         obj4.gxTpr_Responsableid_N = (short)(Convert.ToInt16(n23ResponsableId));
         obj4.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow4( SdtTareas obj4 )
      {
         obj4.gxTpr_Tableroid = A9TableroId;
         obj4.gxTpr_Tareaid = A12TareaId;
         return  ;
      }

      public void RowToVars4( SdtTareas obj4 ,
                              int forceLoad )
      {
         Gx_mode = obj4.gxTpr_Mode;
         A13TareaNombre = obj4.gxTpr_Tareanombre;
         A23ResponsableId = obj4.gxTpr_Responsableid;
         n23ResponsableId = false;
         A24TareaFechaInicio = obj4.gxTpr_Tareafechainicio;
         A25TareaFechaFin = obj4.gxTpr_Tareafechafin;
         A38TareaEtiquetas = obj4.gxTpr_Tareaetiquetas;
         A46TareaEstado = obj4.gxTpr_Tareaestado;
         A9TableroId = obj4.gxTpr_Tableroid;
         A12TareaId = obj4.gxTpr_Tareaid;
         Z9TableroId = obj4.gxTpr_Tableroid_Z;
         Z12TareaId = obj4.gxTpr_Tareaid_Z;
         Z13TareaNombre = obj4.gxTpr_Tareanombre_Z;
         Z23ResponsableId = obj4.gxTpr_Responsableid_Z;
         Z24TareaFechaInicio = obj4.gxTpr_Tareafechainicio_Z;
         Z25TareaFechaFin = obj4.gxTpr_Tareafechafin_Z;
         Z46TareaEstado = obj4.gxTpr_Tareaestado_Z;
         n23ResponsableId = (bool)(Convert.ToBoolean(obj4.gxTpr_Responsableid_N));
         Gx_mode = obj4.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A9TableroId = (short)getParm(obj,0);
         A12TareaId = (short)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey044( ) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000414 */
            pr_default.execute(12, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
               AnyError = 1;
            }
            pr_default.close(12);
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
         }
         ZM044( -3) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
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
         RowToVars4( bcTareas, 0) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000414 */
            pr_default.execute(12, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
               AnyError = 1;
            }
            pr_default.close(12);
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
            Z12TareaId = A12TareaId;
         }
         ZM044( -3) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert044( ) ;
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) )
               {
                  A9TableroId = Z9TableroId;
                  A12TareaId = Z12TareaId;
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
                  Update044( ) ;
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
                  if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) )
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
                        Insert044( ) ;
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
                        Insert044( ) ;
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
         RowToVars4( bcTareas, 1) ;
         SaveImpl( ) ;
         VarsToRow4( bcTareas) ;
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
         RowToVars4( bcTareas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
         AfterTrn( ) ;
         VarsToRow4( bcTareas) ;
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
            SdtTareas auxBC = new SdtTareas(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A9TableroId, A12TareaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTareas);
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
         RowToVars4( bcTareas, 1) ;
         UpdateImpl( ) ;
         VarsToRow4( bcTareas) ;
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
         RowToVars4( bcTareas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
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
         VarsToRow4( bcTareas) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcTareas, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey044( ) ;
         if ( RcdFound4 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) )
            {
               A9TableroId = Z9TableroId;
               A12TareaId = Z12TareaId;
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
            if ( ( A9TableroId != Z9TableroId ) || ( A12TareaId != Z12TareaId ) )
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
         pr_default.close(12);
         context.RollbackDataStores("tareas_bc",pr_default);
         VarsToRow4( bcTareas) ;
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
         Gx_mode = bcTareas.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTareas.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTareas )
         {
            bcTareas = (SdtTareas)(sdt);
            if ( StringUtil.StrCmp(bcTareas.gxTpr_Mode, "") == 0 )
            {
               bcTareas.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow4( bcTareas) ;
            }
            else
            {
               RowToVars4( bcTareas, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTareas.gxTpr_Mode, "") == 0 )
            {
               bcTareas.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars4( bcTareas, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtTareas Tareas_BC
      {
         get {
            return bcTareas ;
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z13TareaNombre = "";
         A13TareaNombre = "";
         Z24TareaFechaInicio = DateTime.MinValue;
         A24TareaFechaInicio = DateTime.MinValue;
         Z25TareaFechaFin = DateTime.MinValue;
         A25TareaFechaFin = DateTime.MinValue;
         Z38TareaEtiquetas = "";
         A38TareaEtiquetas = "";
         BC00046_A12TareaId = new short[1] ;
         BC00046_A13TareaNombre = new string[] {""} ;
         BC00046_A24TareaFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC00046_A25TareaFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC00046_A38TareaEtiquetas = new string[] {""} ;
         BC00046_A46TareaEstado = new short[1] ;
         BC00046_A9TableroId = new short[1] ;
         BC00046_A23ResponsableId = new short[1] ;
         BC00046_n23ResponsableId = new bool[] {false} ;
         BC00044_A9TableroId = new short[1] ;
         BC00045_A23ResponsableId = new short[1] ;
         BC00045_n23ResponsableId = new bool[] {false} ;
         BC00047_A9TableroId = new short[1] ;
         BC00047_A12TareaId = new short[1] ;
         BC00043_A12TareaId = new short[1] ;
         BC00043_A13TareaNombre = new string[] {""} ;
         BC00043_A24TareaFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC00043_A25TareaFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC00043_A38TareaEtiquetas = new string[] {""} ;
         BC00043_A46TareaEstado = new short[1] ;
         BC00043_A9TableroId = new short[1] ;
         BC00043_A23ResponsableId = new short[1] ;
         BC00043_n23ResponsableId = new bool[] {false} ;
         sMode4 = "";
         BC00042_A12TareaId = new short[1] ;
         BC00042_A13TareaNombre = new string[] {""} ;
         BC00042_A24TareaFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC00042_A25TareaFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC00042_A38TareaEtiquetas = new string[] {""} ;
         BC00042_A46TareaEstado = new short[1] ;
         BC00042_A9TableroId = new short[1] ;
         BC00042_A23ResponsableId = new short[1] ;
         BC00042_n23ResponsableId = new bool[] {false} ;
         BC000411_A9TableroId = new short[1] ;
         BC000411_A12TareaId = new short[1] ;
         BC000411_A30ActividadId = new short[1] ;
         BC000412_A9TableroId = new short[1] ;
         BC000412_A12TareaId = new short[1] ;
         BC000412_A27ComentarioId = new short[1] ;
         BC000413_A12TareaId = new short[1] ;
         BC000413_A13TareaNombre = new string[] {""} ;
         BC000413_A24TareaFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000413_A25TareaFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000413_A38TareaEtiquetas = new string[] {""} ;
         BC000413_A46TareaEstado = new short[1] ;
         BC000413_A9TableroId = new short[1] ;
         BC000413_A23ResponsableId = new short[1] ;
         BC000413_n23ResponsableId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000414_A9TableroId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tareas_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A12TareaId, BC00042_A13TareaNombre, BC00042_A24TareaFechaInicio, BC00042_A25TareaFechaFin, BC00042_A38TareaEtiquetas, BC00042_A46TareaEstado, BC00042_A9TableroId, BC00042_A23ResponsableId, BC00042_n23ResponsableId
               }
               , new Object[] {
               BC00043_A12TareaId, BC00043_A13TareaNombre, BC00043_A24TareaFechaInicio, BC00043_A25TareaFechaFin, BC00043_A38TareaEtiquetas, BC00043_A46TareaEstado, BC00043_A9TableroId, BC00043_A23ResponsableId, BC00043_n23ResponsableId
               }
               , new Object[] {
               BC00044_A9TableroId
               }
               , new Object[] {
               BC00045_A23ResponsableId
               }
               , new Object[] {
               BC00046_A12TareaId, BC00046_A13TareaNombre, BC00046_A24TareaFechaInicio, BC00046_A25TareaFechaFin, BC00046_A38TareaEtiquetas, BC00046_A46TareaEstado, BC00046_A9TableroId, BC00046_A23ResponsableId, BC00046_n23ResponsableId
               }
               , new Object[] {
               BC00047_A9TableroId, BC00047_A12TareaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000411_A9TableroId, BC000411_A12TareaId, BC000411_A30ActividadId
               }
               , new Object[] {
               BC000412_A9TableroId, BC000412_A12TareaId, BC000412_A27ComentarioId
               }
               , new Object[] {
               BC000413_A12TareaId, BC000413_A13TareaNombre, BC000413_A24TareaFechaInicio, BC000413_A25TareaFechaFin, BC000413_A38TareaEtiquetas, BC000413_A46TareaEstado, BC000413_A9TableroId, BC000413_A23ResponsableId, BC000413_n23ResponsableId
               }
               , new Object[] {
               BC000414_A9TableroId
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
      private short GX_JID ;
      private short Z46TareaEstado ;
      private short A46TareaEstado ;
      private short Z23ResponsableId ;
      private short A23ResponsableId ;
      private short RcdFound4 ;
      private short nIsDirty_4 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z13TareaNombre ;
      private string A13TareaNombre ;
      private string sMode4 ;
      private DateTime Z24TareaFechaInicio ;
      private DateTime A24TareaFechaInicio ;
      private DateTime Z25TareaFechaFin ;
      private DateTime A25TareaFechaFin ;
      private bool n23ResponsableId ;
      private bool mustCommit ;
      private string Z38TareaEtiquetas ;
      private string A38TareaEtiquetas ;
      private SdtTareas bcTareas ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00046_A12TareaId ;
      private string[] BC00046_A13TareaNombre ;
      private DateTime[] BC00046_A24TareaFechaInicio ;
      private DateTime[] BC00046_A25TareaFechaFin ;
      private string[] BC00046_A38TareaEtiquetas ;
      private short[] BC00046_A46TareaEstado ;
      private short[] BC00046_A9TableroId ;
      private short[] BC00046_A23ResponsableId ;
      private bool[] BC00046_n23ResponsableId ;
      private short[] BC00044_A9TableroId ;
      private short[] BC00045_A23ResponsableId ;
      private bool[] BC00045_n23ResponsableId ;
      private short[] BC00047_A9TableroId ;
      private short[] BC00047_A12TareaId ;
      private short[] BC00043_A12TareaId ;
      private string[] BC00043_A13TareaNombre ;
      private DateTime[] BC00043_A24TareaFechaInicio ;
      private DateTime[] BC00043_A25TareaFechaFin ;
      private string[] BC00043_A38TareaEtiquetas ;
      private short[] BC00043_A46TareaEstado ;
      private short[] BC00043_A9TableroId ;
      private short[] BC00043_A23ResponsableId ;
      private bool[] BC00043_n23ResponsableId ;
      private short[] BC00042_A12TareaId ;
      private string[] BC00042_A13TareaNombre ;
      private DateTime[] BC00042_A24TareaFechaInicio ;
      private DateTime[] BC00042_A25TareaFechaFin ;
      private string[] BC00042_A38TareaEtiquetas ;
      private short[] BC00042_A46TareaEstado ;
      private short[] BC00042_A9TableroId ;
      private short[] BC00042_A23ResponsableId ;
      private bool[] BC00042_n23ResponsableId ;
      private short[] BC000411_A9TableroId ;
      private short[] BC000411_A12TareaId ;
      private short[] BC000411_A30ActividadId ;
      private short[] BC000412_A9TableroId ;
      private short[] BC000412_A12TareaId ;
      private short[] BC000412_A27ComentarioId ;
      private short[] BC000413_A12TareaId ;
      private string[] BC000413_A13TareaNombre ;
      private DateTime[] BC000413_A24TareaFechaInicio ;
      private DateTime[] BC000413_A25TareaFechaFin ;
      private string[] BC000413_A38TareaEtiquetas ;
      private short[] BC000413_A46TareaEstado ;
      private short[] BC000413_A9TableroId ;
      private short[] BC000413_A23ResponsableId ;
      private bool[] BC000413_n23ResponsableId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] BC000414_A9TableroId ;
   }

   public class tareas_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00046;
          prmBC00046 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmBC00044;
          prmBC00044 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC00045;
          prmBC00045 = new Object[] {
          new ParDef("@ResponsableId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00047;
          prmBC00047 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmBC00043;
          prmBC00043 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmBC00042;
          prmBC00042 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmBC00048;
          prmBC00048 = new Object[] {
          new ParDef("@TareaId",GXType.Int16,4,0) ,
          new ParDef("@TareaNombre",GXType.NChar,20,0) ,
          new ParDef("@TareaFechaInicio",GXType.Date,8,0) ,
          new ParDef("@TareaFechaFin",GXType.Date,8,0) ,
          new ParDef("@TareaEtiquetas",GXType.NVarChar,2097152,0) ,
          new ParDef("@TareaEstado",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ResponsableId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00049;
          prmBC00049 = new Object[] {
          new ParDef("@TareaNombre",GXType.NChar,20,0) ,
          new ParDef("@TareaFechaInicio",GXType.Date,8,0) ,
          new ParDef("@TareaFechaFin",GXType.Date,8,0) ,
          new ParDef("@TareaEtiquetas",GXType.NVarChar,2097152,0) ,
          new ParDef("@TareaEstado",GXType.Int16,4,0) ,
          new ParDef("@ResponsableId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmBC000410;
          prmBC000410 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmBC000411;
          prmBC000411 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmBC000412;
          prmBC000412 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmBC000413;
          prmBC000413 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@TareaId",GXType.Int16,4,0)
          };
          Object[] prmBC000414;
          prmBC000414 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00042", "SELECT [TareaId], [TareaNombre], [TareaFechaInicio], [TareaFechaFin], [TareaEtiquetas], [TareaEstado], [TableroId], [ResponsableId] AS ResponsableId FROM [Tareas] WITH (UPDLOCK) WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00043", "SELECT [TareaId], [TareaNombre], [TareaFechaInicio], [TareaFechaFin], [TareaEtiquetas], [TareaEstado], [TableroId], [ResponsableId] AS ResponsableId FROM [Tareas] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00044", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00045", "SELECT [UsuarioId] AS ResponsableId FROM [Usuarios] WHERE [UsuarioId] = @ResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00046", "SELECT TM1.[TareaId], TM1.[TareaNombre], TM1.[TareaFechaInicio], TM1.[TareaFechaFin], TM1.[TareaEtiquetas], TM1.[TareaEstado], TM1.[TableroId], TM1.[ResponsableId] AS ResponsableId FROM [Tareas] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[TareaId] = @TareaId ORDER BY TM1.[TableroId], TM1.[TareaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00047", "SELECT [TableroId], [TareaId] FROM [Tareas] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00047,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00048", "INSERT INTO [Tareas]([TareaId], [TareaNombre], [TareaFechaInicio], [TareaFechaFin], [TareaEtiquetas], [TareaEstado], [TableroId], [ResponsableId]) VALUES(@TareaId, @TareaNombre, @TareaFechaInicio, @TareaFechaFin, @TareaEtiquetas, @TareaEstado, @TableroId, @ResponsableId)", GxErrorMask.GX_NOMASK,prmBC00048)
             ,new CursorDef("BC00049", "UPDATE [Tareas] SET [TareaNombre]=@TareaNombre, [TareaFechaInicio]=@TareaFechaInicio, [TareaFechaFin]=@TareaFechaFin, [TareaEtiquetas]=@TareaEtiquetas, [TareaEstado]=@TareaEstado, [ResponsableId]=@ResponsableId  WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId", GxErrorMask.GX_NOMASK,prmBC00049)
             ,new CursorDef("BC000410", "DELETE FROM [Tareas]  WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId", GxErrorMask.GX_NOMASK,prmBC000410)
             ,new CursorDef("BC000411", "SELECT TOP 1 [TableroId], [TareaId], [ActividadId] FROM [Actividades] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000411,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000412", "SELECT TOP 1 [TableroId], [TareaId], [ComentarioId] FROM [TareasComentarios] WHERE [TableroId] = @TableroId AND [TareaId] = @TareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000412,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000413", "SELECT TM1.[TareaId], TM1.[TareaNombre], TM1.[TareaFechaInicio], TM1.[TareaFechaFin], TM1.[TareaEtiquetas], TM1.[TareaEstado], TM1.[TableroId], TM1.[ResponsableId] AS ResponsableId FROM [Tareas] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[TareaId] = @TareaId ORDER BY TM1.[TableroId], TM1.[TareaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000413,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000414", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000414,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
