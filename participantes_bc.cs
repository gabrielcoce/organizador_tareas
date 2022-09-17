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
   public class participantes_bc : GXHttpHandler, IGxSilentTrn
   {
      public participantes_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public participantes_bc( IGxContext context )
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
         ReadRow0611( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0611( ) ;
         standaloneModal( ) ;
         AddRow0611( ) ;
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
               Z18ParticipanteTableroId = A18ParticipanteTableroId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate0611( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0611( ) ;
            }
            else
            {
               CheckExtendedTable0611( ) ;
               if ( AnyError == 0 )
               {
                  ZM0611( 3) ;
                  ZM0611( 4) ;
                  ZM0611( 5) ;
               }
               CloseExtendedTableCursors0611( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0611( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z20RegistroFecha = A20RegistroFecha;
            Z42ParticipanteTableroEstado = A42ParticipanteTableroEstado;
            Z39ParticipanteRolId = A39ParticipanteRolId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -2 )
         {
            Z20RegistroFecha = A20RegistroFecha;
            Z42ParticipanteTableroEstado = A42ParticipanteTableroEstado;
            Z9TableroId = A9TableroId;
            Z18ParticipanteTableroId = A18ParticipanteTableroId;
            Z39ParticipanteRolId = A39ParticipanteRolId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0611( )
      {
         /* Using cursor BC00067 */
         pr_default.execute(5, new Object[] {A9TableroId, A18ParticipanteTableroId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound11 = 1;
            A20RegistroFecha = BC00067_A20RegistroFecha[0];
            A42ParticipanteTableroEstado = BC00067_A42ParticipanteTableroEstado[0];
            A39ParticipanteRolId = BC00067_A39ParticipanteRolId[0];
            ZM0611( -2) ;
         }
         pr_default.close(5);
         OnLoadActions0611( ) ;
      }

      protected void OnLoadActions0611( )
      {
      }

      protected void CheckExtendedTable0611( )
      {
         nIsDirty_11 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {A9TableroId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {A18ParticipanteTableroId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Participante Tablero'.", "ForeignKeyNotFound", 1, "PARTICIPANTETABLEROID");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A20RegistroFecha) || ( A20RegistroFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Registro Fecha fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00066 */
         pr_default.execute(4, new Object[] {A39ParticipanteRolId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles Participantes'.", "ForeignKeyNotFound", 1, "PARTICIPANTEROLID");
            AnyError = 1;
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0611( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0611( )
      {
         /* Using cursor BC00068 */
         pr_default.execute(6, new Object[] {A9TableroId, A18ParticipanteTableroId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {A9TableroId, A18ParticipanteTableroId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0611( 2) ;
            RcdFound11 = 1;
            A20RegistroFecha = BC00063_A20RegistroFecha[0];
            A42ParticipanteTableroEstado = BC00063_A42ParticipanteTableroEstado[0];
            A9TableroId = BC00063_A9TableroId[0];
            A18ParticipanteTableroId = BC00063_A18ParticipanteTableroId[0];
            A39ParticipanteRolId = BC00063_A39ParticipanteRolId[0];
            Z9TableroId = A9TableroId;
            Z18ParticipanteTableroId = A18ParticipanteTableroId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0611( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0611( ) ;
            }
            Gx_mode = sMode11;
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0611( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode11;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0611( ) ;
         if ( RcdFound11 == 0 )
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
         CONFIRM_060( ) ;
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

      protected void CheckOptimisticConcurrency0611( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {A9TableroId, A18ParticipanteTableroId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Participantes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z20RegistroFecha != BC00062_A20RegistroFecha[0] ) || ( Z42ParticipanteTableroEstado != BC00062_A42ParticipanteTableroEstado[0] ) || ( Z39ParticipanteRolId != BC00062_A39ParticipanteRolId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Participantes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0611( )
      {
         BeforeValidate0611( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0611( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0611( 0) ;
            CheckOptimisticConcurrency0611( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0611( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0611( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00069 */
                     pr_default.execute(7, new Object[] {A20RegistroFecha, A42ParticipanteTableroEstado, A9TableroId, A18ParticipanteTableroId, A39ParticipanteRolId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Participantes");
                     if ( (pr_default.getStatus(7) == 1) )
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
               Load0611( ) ;
            }
            EndLevel0611( ) ;
         }
         CloseExtendedTableCursors0611( ) ;
      }

      protected void Update0611( )
      {
         BeforeValidate0611( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0611( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0611( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0611( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0611( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000610 */
                     pr_default.execute(8, new Object[] {A20RegistroFecha, A42ParticipanteTableroEstado, A39ParticipanteRolId, A9TableroId, A18ParticipanteTableroId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Participantes");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Participantes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0611( ) ;
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
            EndLevel0611( ) ;
         }
         CloseExtendedTableCursors0611( ) ;
      }

      protected void DeferredUpdate0611( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0611( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0611( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0611( ) ;
            AfterConfirm0611( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0611( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000611 */
                  pr_default.execute(9, new Object[] {A9TableroId, A18ParticipanteTableroId});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("Participantes");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0611( ) ;
         Gx_mode = sMode11;
      }

      protected void OnDeleteControls0611( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0611( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0611( ) ;
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

      public void ScanKeyStart0611( )
      {
         /* Using cursor BC000612 */
         pr_default.execute(10, new Object[] {A9TableroId, A18ParticipanteTableroId});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound11 = 1;
            A20RegistroFecha = BC000612_A20RegistroFecha[0];
            A42ParticipanteTableroEstado = BC000612_A42ParticipanteTableroEstado[0];
            A9TableroId = BC000612_A9TableroId[0];
            A18ParticipanteTableroId = BC000612_A18ParticipanteTableroId[0];
            A39ParticipanteRolId = BC000612_A39ParticipanteRolId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0611( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound11 = 0;
         ScanKeyLoad0611( ) ;
      }

      protected void ScanKeyLoad0611( )
      {
         sMode11 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound11 = 1;
            A20RegistroFecha = BC000612_A20RegistroFecha[0];
            A42ParticipanteTableroEstado = BC000612_A42ParticipanteTableroEstado[0];
            A9TableroId = BC000612_A9TableroId[0];
            A18ParticipanteTableroId = BC000612_A18ParticipanteTableroId[0];
            A39ParticipanteRolId = BC000612_A39ParticipanteRolId[0];
         }
         Gx_mode = sMode11;
      }

      protected void ScanKeyEnd0611( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0611( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0611( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0611( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0611( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0611( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0611( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0611( )
      {
      }

      protected void send_integrity_lvl_hashes0611( )
      {
      }

      protected void AddRow0611( )
      {
         VarsToRow11( bcParticipantes) ;
      }

      protected void ReadRow0611( )
      {
         RowToVars11( bcParticipantes, 1) ;
      }

      protected void InitializeNonKey0611( )
      {
         A20RegistroFecha = (DateTime)(DateTime.MinValue);
         A39ParticipanteRolId = 0;
         A42ParticipanteTableroEstado = false;
         Z20RegistroFecha = (DateTime)(DateTime.MinValue);
         Z42ParticipanteTableroEstado = false;
         Z39ParticipanteRolId = 0;
      }

      protected void InitAll0611( )
      {
         A9TableroId = 0;
         A18ParticipanteTableroId = 0;
         InitializeNonKey0611( ) ;
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

      public void VarsToRow11( SdtParticipantes obj11 )
      {
         obj11.gxTpr_Mode = Gx_mode;
         obj11.gxTpr_Registrofecha = A20RegistroFecha;
         obj11.gxTpr_Participanterolid = A39ParticipanteRolId;
         obj11.gxTpr_Participantetableroestado = A42ParticipanteTableroEstado;
         obj11.gxTpr_Tableroid = A9TableroId;
         obj11.gxTpr_Participantetableroid = A18ParticipanteTableroId;
         obj11.gxTpr_Tableroid_Z = Z9TableroId;
         obj11.gxTpr_Participantetableroid_Z = Z18ParticipanteTableroId;
         obj11.gxTpr_Registrofecha_Z = Z20RegistroFecha;
         obj11.gxTpr_Participanterolid_Z = Z39ParticipanteRolId;
         obj11.gxTpr_Participantetableroestado_Z = Z42ParticipanteTableroEstado;
         obj11.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow11( SdtParticipantes obj11 )
      {
         obj11.gxTpr_Tableroid = A9TableroId;
         obj11.gxTpr_Participantetableroid = A18ParticipanteTableroId;
         return  ;
      }

      public void RowToVars11( SdtParticipantes obj11 ,
                               int forceLoad )
      {
         Gx_mode = obj11.gxTpr_Mode;
         A20RegistroFecha = obj11.gxTpr_Registrofecha;
         A39ParticipanteRolId = obj11.gxTpr_Participanterolid;
         A42ParticipanteTableroEstado = obj11.gxTpr_Participantetableroestado;
         A9TableroId = obj11.gxTpr_Tableroid;
         A18ParticipanteTableroId = obj11.gxTpr_Participantetableroid;
         Z9TableroId = obj11.gxTpr_Tableroid_Z;
         Z18ParticipanteTableroId = obj11.gxTpr_Participantetableroid_Z;
         Z20RegistroFecha = obj11.gxTpr_Registrofecha_Z;
         Z39ParticipanteRolId = obj11.gxTpr_Participanterolid_Z;
         Z42ParticipanteTableroEstado = obj11.gxTpr_Participantetableroestado_Z;
         Gx_mode = obj11.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A9TableroId = (short)getParm(obj,0);
         A18ParticipanteTableroId = (short)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0611( ) ;
         ScanKeyStart0611( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000613 */
            pr_default.execute(11, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000614 */
            pr_default.execute(12, new Object[] {A18ParticipanteTableroId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem("No existe 'Participante Tablero'.", "ForeignKeyNotFound", 1, "PARTICIPANTETABLEROID");
               AnyError = 1;
            }
            pr_default.close(12);
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
            Z18ParticipanteTableroId = A18ParticipanteTableroId;
         }
         ZM0611( -2) ;
         OnLoadActions0611( ) ;
         AddRow0611( ) ;
         ScanKeyEnd0611( ) ;
         if ( RcdFound11 == 0 )
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
         RowToVars11( bcParticipantes, 0) ;
         ScanKeyStart0611( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000613 */
            pr_default.execute(11, new Object[] {A9TableroId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem("No existe 'Tableros'.", "ForeignKeyNotFound", 1, "TABLEROID");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000614 */
            pr_default.execute(12, new Object[] {A18ParticipanteTableroId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem("No existe 'Participante Tablero'.", "ForeignKeyNotFound", 1, "PARTICIPANTETABLEROID");
               AnyError = 1;
            }
            pr_default.close(12);
         }
         else
         {
            Gx_mode = "UPD";
            Z9TableroId = A9TableroId;
            Z18ParticipanteTableroId = A18ParticipanteTableroId;
         }
         ZM0611( -2) ;
         OnLoadActions0611( ) ;
         AddRow0611( ) ;
         ScanKeyEnd0611( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0611( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0611( ) ;
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( ( A9TableroId != Z9TableroId ) || ( A18ParticipanteTableroId != Z18ParticipanteTableroId ) )
               {
                  A9TableroId = Z9TableroId;
                  A18ParticipanteTableroId = Z18ParticipanteTableroId;
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
                  Update0611( ) ;
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
                  if ( ( A9TableroId != Z9TableroId ) || ( A18ParticipanteTableroId != Z18ParticipanteTableroId ) )
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
                        Insert0611( ) ;
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
                        Insert0611( ) ;
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
         RowToVars11( bcParticipantes, 1) ;
         SaveImpl( ) ;
         VarsToRow11( bcParticipantes) ;
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
         RowToVars11( bcParticipantes, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0611( ) ;
         AfterTrn( ) ;
         VarsToRow11( bcParticipantes) ;
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
            SdtParticipantes auxBC = new SdtParticipantes(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A9TableroId, A18ParticipanteTableroId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcParticipantes);
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
         RowToVars11( bcParticipantes, 1) ;
         UpdateImpl( ) ;
         VarsToRow11( bcParticipantes) ;
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
         RowToVars11( bcParticipantes, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0611( ) ;
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
         VarsToRow11( bcParticipantes) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars11( bcParticipantes, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0611( ) ;
         if ( RcdFound11 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A9TableroId != Z9TableroId ) || ( A18ParticipanteTableroId != Z18ParticipanteTableroId ) )
            {
               A9TableroId = Z9TableroId;
               A18ParticipanteTableroId = Z18ParticipanteTableroId;
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
            if ( ( A9TableroId != Z9TableroId ) || ( A18ParticipanteTableroId != Z18ParticipanteTableroId ) )
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
         pr_default.close(11);
         pr_default.close(12);
         context.RollbackDataStores("participantes_bc",pr_default);
         VarsToRow11( bcParticipantes) ;
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
         Gx_mode = bcParticipantes.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcParticipantes.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcParticipantes )
         {
            bcParticipantes = (SdtParticipantes)(sdt);
            if ( StringUtil.StrCmp(bcParticipantes.gxTpr_Mode, "") == 0 )
            {
               bcParticipantes.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow11( bcParticipantes) ;
            }
            else
            {
               RowToVars11( bcParticipantes, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcParticipantes.gxTpr_Mode, "") == 0 )
            {
               bcParticipantes.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars11( bcParticipantes, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtParticipantes Participantes_BC
      {
         get {
            return bcParticipantes ;
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
         pr_default.close(11);
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
         Z20RegistroFecha = (DateTime)(DateTime.MinValue);
         A20RegistroFecha = (DateTime)(DateTime.MinValue);
         BC00067_A20RegistroFecha = new DateTime[] {DateTime.MinValue} ;
         BC00067_A42ParticipanteTableroEstado = new bool[] {false} ;
         BC00067_A9TableroId = new short[1] ;
         BC00067_A18ParticipanteTableroId = new short[1] ;
         BC00067_A39ParticipanteRolId = new short[1] ;
         BC00064_A9TableroId = new short[1] ;
         BC00065_A18ParticipanteTableroId = new short[1] ;
         BC00066_A39ParticipanteRolId = new short[1] ;
         BC00068_A9TableroId = new short[1] ;
         BC00068_A18ParticipanteTableroId = new short[1] ;
         BC00063_A20RegistroFecha = new DateTime[] {DateTime.MinValue} ;
         BC00063_A42ParticipanteTableroEstado = new bool[] {false} ;
         BC00063_A9TableroId = new short[1] ;
         BC00063_A18ParticipanteTableroId = new short[1] ;
         BC00063_A39ParticipanteRolId = new short[1] ;
         sMode11 = "";
         BC00062_A20RegistroFecha = new DateTime[] {DateTime.MinValue} ;
         BC00062_A42ParticipanteTableroEstado = new bool[] {false} ;
         BC00062_A9TableroId = new short[1] ;
         BC00062_A18ParticipanteTableroId = new short[1] ;
         BC00062_A39ParticipanteRolId = new short[1] ;
         BC000612_A20RegistroFecha = new DateTime[] {DateTime.MinValue} ;
         BC000612_A42ParticipanteTableroEstado = new bool[] {false} ;
         BC000612_A9TableroId = new short[1] ;
         BC000612_A18ParticipanteTableroId = new short[1] ;
         BC000612_A39ParticipanteRolId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000613_A9TableroId = new short[1] ;
         BC000614_A18ParticipanteTableroId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.participantes_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A20RegistroFecha, BC00062_A42ParticipanteTableroEstado, BC00062_A9TableroId, BC00062_A18ParticipanteTableroId, BC00062_A39ParticipanteRolId
               }
               , new Object[] {
               BC00063_A20RegistroFecha, BC00063_A42ParticipanteTableroEstado, BC00063_A9TableroId, BC00063_A18ParticipanteTableroId, BC00063_A39ParticipanteRolId
               }
               , new Object[] {
               BC00064_A9TableroId
               }
               , new Object[] {
               BC00065_A18ParticipanteTableroId
               }
               , new Object[] {
               BC00066_A39ParticipanteRolId
               }
               , new Object[] {
               BC00067_A20RegistroFecha, BC00067_A42ParticipanteTableroEstado, BC00067_A9TableroId, BC00067_A18ParticipanteTableroId, BC00067_A39ParticipanteRolId
               }
               , new Object[] {
               BC00068_A9TableroId, BC00068_A18ParticipanteTableroId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000612_A20RegistroFecha, BC000612_A42ParticipanteTableroEstado, BC000612_A9TableroId, BC000612_A18ParticipanteTableroId, BC000612_A39ParticipanteRolId
               }
               , new Object[] {
               BC000613_A9TableroId
               }
               , new Object[] {
               BC000614_A18ParticipanteTableroId
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
      private short Z18ParticipanteTableroId ;
      private short A18ParticipanteTableroId ;
      private short GX_JID ;
      private short Z39ParticipanteRolId ;
      private short A39ParticipanteRolId ;
      private short RcdFound11 ;
      private short nIsDirty_11 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode11 ;
      private DateTime Z20RegistroFecha ;
      private DateTime A20RegistroFecha ;
      private bool Z42ParticipanteTableroEstado ;
      private bool A42ParticipanteTableroEstado ;
      private bool mustCommit ;
      private SdtParticipantes bcParticipantes ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] BC00067_A20RegistroFecha ;
      private bool[] BC00067_A42ParticipanteTableroEstado ;
      private short[] BC00067_A9TableroId ;
      private short[] BC00067_A18ParticipanteTableroId ;
      private short[] BC00067_A39ParticipanteRolId ;
      private short[] BC00064_A9TableroId ;
      private short[] BC00065_A18ParticipanteTableroId ;
      private short[] BC00066_A39ParticipanteRolId ;
      private short[] BC00068_A9TableroId ;
      private short[] BC00068_A18ParticipanteTableroId ;
      private DateTime[] BC00063_A20RegistroFecha ;
      private bool[] BC00063_A42ParticipanteTableroEstado ;
      private short[] BC00063_A9TableroId ;
      private short[] BC00063_A18ParticipanteTableroId ;
      private short[] BC00063_A39ParticipanteRolId ;
      private DateTime[] BC00062_A20RegistroFecha ;
      private bool[] BC00062_A42ParticipanteTableroEstado ;
      private short[] BC00062_A9TableroId ;
      private short[] BC00062_A18ParticipanteTableroId ;
      private short[] BC00062_A39ParticipanteRolId ;
      private DateTime[] BC000612_A20RegistroFecha ;
      private bool[] BC000612_A42ParticipanteTableroEstado ;
      private short[] BC000612_A9TableroId ;
      private short[] BC000612_A18ParticipanteTableroId ;
      private short[] BC000612_A39ParticipanteRolId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] BC000613_A9TableroId ;
      private short[] BC000614_A18ParticipanteTableroId ;
   }

   public class participantes_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
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
          Object[] prmBC00067;
          prmBC00067 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmBC00064;
          prmBC00064 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC00065;
          prmBC00065 = new Object[] {
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmBC00066;
          prmBC00066 = new Object[] {
          new ParDef("@ParticipanteRolId",GXType.Int16,4,0)
          };
          Object[] prmBC00068;
          prmBC00068 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmBC00063;
          prmBC00063 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmBC00062;
          prmBC00062 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmBC00069;
          prmBC00069 = new Object[] {
          new ParDef("@RegistroFecha",GXType.DateTime,8,5) ,
          new ParDef("@ParticipanteTableroEstado",GXType.Boolean,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteRolId",GXType.Int16,4,0)
          };
          Object[] prmBC000610;
          prmBC000610 = new Object[] {
          new ParDef("@RegistroFecha",GXType.DateTime,8,5) ,
          new ParDef("@ParticipanteTableroEstado",GXType.Boolean,4,0) ,
          new ParDef("@ParticipanteRolId",GXType.Int16,4,0) ,
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmBC000611;
          prmBC000611 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmBC000612;
          prmBC000612 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0) ,
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          Object[] prmBC000613;
          prmBC000613 = new Object[] {
          new ParDef("@TableroId",GXType.Int16,4,0)
          };
          Object[] prmBC000614;
          prmBC000614 = new Object[] {
          new ParDef("@ParticipanteTableroId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00062", "SELECT [RegistroFecha], [ParticipanteTableroEstado], [TableroId], [ParticipanteTableroId] AS ParticipanteTableroId, [ParticipanteRolId] AS ParticipanteRolId FROM [Participantes] WITH (UPDLOCK) WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00063", "SELECT [RegistroFecha], [ParticipanteTableroEstado], [TableroId], [ParticipanteTableroId] AS ParticipanteTableroId, [ParticipanteRolId] AS ParticipanteRolId FROM [Participantes] WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00064", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00065", "SELECT [UsuarioId] AS ParticipanteTableroId FROM [Usuarios] WHERE [UsuarioId] = @ParticipanteTableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00066", "SELECT [RolId] AS ParticipanteRolId FROM [Roles] WHERE [RolId] = @ParticipanteRolId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00067", "SELECT TM1.[RegistroFecha], TM1.[ParticipanteTableroEstado], TM1.[TableroId], TM1.[ParticipanteTableroId] AS ParticipanteTableroId, TM1.[ParticipanteRolId] AS ParticipanteRolId FROM [Participantes] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[ParticipanteTableroId] = @ParticipanteTableroId ORDER BY TM1.[TableroId], TM1.[ParticipanteTableroId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00067,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00068", "SELECT [TableroId], [ParticipanteTableroId] AS ParticipanteTableroId FROM [Participantes] WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00068,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00069", "INSERT INTO [Participantes]([RegistroFecha], [ParticipanteTableroEstado], [TableroId], [ParticipanteTableroId], [ParticipanteRolId]) VALUES(@RegistroFecha, @ParticipanteTableroEstado, @TableroId, @ParticipanteTableroId, @ParticipanteRolId)", GxErrorMask.GX_NOMASK,prmBC00069)
             ,new CursorDef("BC000610", "UPDATE [Participantes] SET [RegistroFecha]=@RegistroFecha, [ParticipanteTableroEstado]=@ParticipanteTableroEstado, [ParticipanteRolId]=@ParticipanteRolId  WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId", GxErrorMask.GX_NOMASK,prmBC000610)
             ,new CursorDef("BC000611", "DELETE FROM [Participantes]  WHERE [TableroId] = @TableroId AND [ParticipanteTableroId] = @ParticipanteTableroId", GxErrorMask.GX_NOMASK,prmBC000611)
             ,new CursorDef("BC000612", "SELECT TM1.[RegistroFecha], TM1.[ParticipanteTableroEstado], TM1.[TableroId], TM1.[ParticipanteTableroId] AS ParticipanteTableroId, TM1.[ParticipanteRolId] AS ParticipanteRolId FROM [Participantes] TM1 WHERE TM1.[TableroId] = @TableroId and TM1.[ParticipanteTableroId] = @ParticipanteTableroId ORDER BY TM1.[TableroId], TM1.[ParticipanteTableroId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000612,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000613", "SELECT [TableroId] FROM [Tableros] WHERE [TableroId] = @TableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000613,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000614", "SELECT [UsuarioId] AS ParticipanteTableroId FROM [Usuarios] WHERE [UsuarioId] = @ParticipanteTableroId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000614,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 10 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
