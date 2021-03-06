/****** Object:  StoredProcedure [dbo].[Upsert_AccountDetail]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Upsert_AccountDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Upsert_AccountDetail]
GO
/****** Object:  StoredProcedure [dbo].[Upsert_BankBooks]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Upsert_BankBooks]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Upsert_BankBooks]
GO
/****** Object:  StoredProcedure [dbo].[Upsert_Ledger]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Upsert_Ledger]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Upsert_Ledger]
GO
/****** Object:  StoredProcedure [dbo].[Upsert_VoucherDetails]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Upsert_VoucherDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Upsert_VoucherDetails]
GO
/****** Object:  StoredProcedure [dbo].[Upsert_VoucherHeader]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Upsert_VoucherHeader]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Upsert_VoucherHeader]
GO
/****** Object:  StoredProcedure [dbo].[GetAccountDetails]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAccountDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAccountDetails]
GO
/****** Object:  StoredProcedure [dbo].[GetCashBankReportDetails]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCashBankReportDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetCashBankReportDetails]
GO
/****** Object:  StoredProcedure [dbo].[GetGeneralLedgerReportDetails]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetGeneralLedgerReportDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetGeneralLedgerReportDetails]
GO
/****** Object:  StoredProcedure [dbo].[GetSPParameters]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSPParameters]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetSPParameters]
GO
/****** Object:  Table [dbo].[Inst_Master]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inst_Master]') AND type in (N'U'))
DROP TABLE [dbo].[Inst_Master]
GO
/****** Object:  StoredProcedure [dbo].[TempUpdateAccounts]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TempUpdateAccounts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TempUpdateAccounts]
GO
/****** Object:  Table [dbo].[User_Master]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Master]') AND type in (N'U'))
DROP TABLE [dbo].[User_Master]
GO
/****** Object:  StoredProcedure [dbo].[CalculateBalance]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CalculateBalance]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CalculateBalance]
GO
/****** Object:  Table [dbo].[CG_Accounts]    Script Date: 01/04/2016 20:17:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CG_Accounts]') AND type in (N'U'))
DROP TABLE [dbo].[CG_Accounts]
GO
/****** Object:  Table [dbo].[CG_Daybooks]    Script Date: 01/04/2016 20:17:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CG_Daybooks]') AND type in (N'U'))
DROP TABLE [dbo].[CG_Daybooks]
GO
/****** Object:  Table [dbo].[CG_Ledger]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CG_Ledger]') AND type in (N'U'))
DROP TABLE [dbo].[CG_Ledger]
GO
/****** Object:  Table [dbo].[CG_Voucher_Detail]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CG_Voucher_Detail]') AND type in (N'U'))
DROP TABLE [dbo].[CG_Voucher_Detail]
GO
/****** Object:  Table [dbo].[CG_Voucher_Header]    Script Date: 01/04/2016 20:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CG_Voucher_Header]') AND type in (N'U'))
DROP TABLE [dbo].[CG_Voucher_Header]
GO
/****** Object:  Table [dbo].[CG_Voucher_Header]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CG_Voucher_Header]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CG_Voucher_Header](
	[VH_Fin_Yr] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VH_Inst_Cd] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VH_Inst_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VH_Brn_Cd] [char](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VH_Lnk_No] [char](12) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VH_Lnk_Dt] [datetime] NULL,
	[VH_Pty_Nm] [char](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Dbk_Cd] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Trn_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Vch_No] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Vch_Dt] [datetime] NULL,
	[VH_Chq_No] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Chq_Dt] [datetime] NULL,
	[VH_Clr_Dt] [datetime] NULL,
	[VH_Ref_No] [char](40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Ref_Dt] [datetime] NULL,
	[VH_Vch_Ref_No] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Lgr_Cd] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Acc_Cd] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Amt] [money] NULL,
	[VH_Cr_Dr] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_ABS_Amt] [money] NULL,
	[VH_Ent_By] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Ent_Dt] [datetime] NULL,
	[VH_Upd_By] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Upd_Dt] [datetime] NULL,
	[VH_Conf_By] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Conf_Dt] [datetime] NULL,
 CONSTRAINT [pk_voucherheader] PRIMARY KEY CLUSTERED 
(
	[VH_Fin_Yr] ASC,
	[VH_Inst_Cd] ASC,
	[VH_Inst_Typ] ASC,
	[VH_Brn_Cd] ASC,
	[VH_Lnk_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[CG_Voucher_Detail]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CG_Voucher_Detail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CG_Voucher_Detail](
	[VD_Fin_Yr] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VD_Inst_Cd] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VD_Inst_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VD_Brn_Cd] [char](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VD_Lnk_No] [char](12) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VD_Seq_No] [char](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VD_Dbk_Cd] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_Trn_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_Vch_No] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_Vch_Ref_No] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_Ref_No] [char](40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_Ref_Dt] [datetime] NULL,
	[VD_Narr] [char](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_Lgr_Cd] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_Acc_Cd] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_Amt] [money] NULL,
	[VD_Cr_Dr] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_ABS_Amt] [money] NULL,
	[VD_Ent_By] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_Ent_Dt] [datetime] NULL,
	[VD_Upd_By] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_Upd_Dt] [datetime] NULL,
	[VD_Conf_By] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_Conf_Dt] [datetime] NULL,
 CONSTRAINT [pk_voucherdetail] PRIMARY KEY CLUSTERED 
(
	[VD_Fin_Yr] ASC,
	[VD_Inst_Cd] ASC,
	[VD_Inst_Typ] ASC,
	[VD_Brn_Cd] ASC,
	[VD_Lnk_No] ASC,
	[VD_Seq_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[CG_Ledger]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CG_Ledger]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CG_Ledger](
	[Lgr_Fin_Yr] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Inst_Cd] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Inst_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Brn_Cd] [char](3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Lnk_No] [char](12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Lnk_Dt] [datetime] NULL,
	[Lgr_Dbk_Cd] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Trn_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Vch_No] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Vch_Dt] [datetime] NULL,
	[Lgr_Vch_Ref_No] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Seq_No] [char](3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Narr] [char](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Chq_No] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Chq_Dt] [datetime] NULL,
	[Lgr_Ref_No] [char](40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Ref_Dt] [datetime] NULL,
	[Lgr_Lgr_Cd] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Acc_Cd] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Amt] [money] NULL,
	[Lgr_Cr_Dr] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_ABS_Amt] [money] NULL,
	[Lgr_Ent_By] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Ent_Dt] [datetime] NULL,
	[Lgr_Upd_By] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Upd_Dt] [datetime] NULL,
	[Lgr_Conf_By] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Conf_Dt] [datetime] NULL
)
END
GO
/****** Object:  Table [dbo].[CG_Daybooks]    Script Date: 01/04/2016 20:17:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CG_Daybooks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CG_Daybooks](
	[DM_Fin_Yr] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DM_Inst_Cd] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DM_Inst_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DM_Brn_Cd] [char](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DM_Dbk_Cd] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DM_Dbk_Nm] [char](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DM_Dbk_Typ] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DM_Acc_Cd] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DM_Bnk_Nm] [char](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DM_Bnk_Brn] [char](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DM_Bnk_AcNo] [char](16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DM_Bnk_OD] [money] NULL,
	[DM_Vch_04] [int] NULL,
	[DM_Lst_04] [datetime] NULL,
	[DM_Vch_05] [int] NULL,
	[DM_Lst_05] [datetime] NULL,
	[DM_Vch_06] [int] NULL,
	[DM_Lst_06] [datetime] NULL,
	[DM_Vch_07] [int] NULL,
	[DM_Lst_07] [datetime] NULL,
	[DM_Vch_08] [int] NULL,
	[DM_Lst_08] [datetime] NULL,
	[DM_Vch_09] [int] NULL,
	[DM_Lst_09] [datetime] NULL,
	[DM_Vch_10] [int] NULL,
	[DM_Lst_10] [datetime] NULL,
	[DM_Vch_11] [int] NULL,
	[DM_Lst_11] [datetime] NULL,
	[DM_Vch_12] [int] NULL,
	[DM_Lst_12] [datetime] NULL,
	[DM_Vch_01] [int] NULL,
	[DM_Lst_01] [datetime] NULL,
	[DM_Vch_02] [int] NULL,
	[DM_Lst_02] [datetime] NULL,
	[DM_Vch_03] [int] NULL,
	[DM_Lst_03] [datetime] NULL,
	[DM_Ent_By] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DM_Ent_Dt] [datetime] NULL,
	[DM_Upd_By] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DM_Upd_Dt] [datetime] NULL,
 CONSTRAINT [pk_daybook] PRIMARY KEY CLUSTERED 
(
	[DM_Fin_Yr] ASC,
	[DM_Inst_Cd] ASC,
	[DM_Inst_Typ] ASC,
	[DM_Brn_Cd] ASC,
	[DM_Dbk_Cd] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[CG_Accounts]    Script Date: 01/04/2016 20:17:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CG_Accounts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CG_Accounts](
	[AM_Fin_Yr] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AM_Inst_Cd] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AM_Inst_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AM_Brn_Cd] [char](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AM_Lgr_Cd] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AM_Acc_Cd] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AM_Acc_Nm] [char](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AM_Calls] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AM_Opn_Bal] [money] NULL,
	[AM_OB_Cr_Dr] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AM_ABS_Opn_Bal] [money] NULL,
	[AM_Net_04] [money] NULL,
	[AM_Net_05] [money] NULL,
	[AM_Net_06] [money] NULL,
	[AM_Net_07] [money] NULL,
	[AM_Net_08] [money] NULL,
	[AM_Net_09] [money] NULL,
	[AM_Net_10] [money] NULL,
	[AM_Net_11] [money] NULL,
	[AM_Net_12] [money] NULL,
	[AM_Net_01] [money] NULL,
	[AM_Net_02] [money] NULL,
	[AM_Net_03] [money] NULL,
	[AM_LLY_Budg] [money] NULL,
	[AM_LLY_Actu] [money] NULL,
	[AM_LYr_Budg] [money] NULL,
	[AM_LYr_Actu] [money] NULL,
	[AM_Cyr_Budg] [money] NULL,
	[AM_Ent_By] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AM_Ent_Dt] [datetime] NULL,
	[AM_Upd_By] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AM_Upd_Dt] [datetime] NULL,
 CONSTRAINT [pk_account] PRIMARY KEY CLUSTERED 
(
	[AM_Fin_Yr] ASC,
	[AM_Inst_Cd] ASC,
	[AM_Inst_Typ] ASC,
	[AM_Brn_Cd] ASC,
	[AM_Lgr_Cd] ASC,
	[AM_Acc_Cd] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  StoredProcedure [dbo].[CalculateBalance]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CalculateBalance]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
ALTER Procedure [dbo].[CalculateBalance]
@lgrCode varchar(10),
@vchDate as datetime,
@instType as varchar(5)
As
Begin

declare @firstDate as datetime
set @firstDate=(SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@vchDate)-1),@vchDate),101))

declare @processingMonth as int
set @processingMonth=DATEPART(mm,@vchDate)

declare @totalBalance as money
declare @balanceAdd as money

declare @opnBalance as money
declare @opnQuery as nvarchar(max)

set @opnQuery=''select @obal=AM_Opn_Bal from ''+@instType+''_Accounts where AM_Acc_Cd=''''+@lgrCode+''''

EXECUTE sp_executesql @opnQuery, N''@obal money OUTPUT'', @obal=@opnBalance OUTPUT                  

declare @monthAmt as money
declare @monthQuery as nvarchar(max)
set @monthQuery=''select @mthAmt=SUM(Lgr_Amt) from ''+@instType+''_Ledger where Lgr_Vch_Dt>=''''+convert(varchar(50),@firstDate)+'''' and Lgr_Vch_Dt<=''''+convert(varchar(50),@vchDate)+''''
                  and Lgr_Acc_Cd=''''+@lgrCode+''''
                  
EXECUTE sp_executesql @monthQuery, N''@mthAmt money OUTPUT'', @mthAmt=@monthAmt OUTPUT                  


--if month is april,return opening balance+month calculation
If @processingMonth=4
Begin
set @balanceAdd=@monthAmt  

set @totalBalance=isnull(@opnBalance,0)+isnull(@balanceAdd,0)

End
Else
Begin
--any other month than april

declare @startCount as int
set @startCount=4

--while loop to calculate balance addition of previous months
While(@startCount<@processingMonth)
Begin
 declare @strQuery as nvarchar(max)
 declare @queryOut as money
 declare @paddedString as varchar(2)
set @paddedString=right('0'+ rtrim(convert(varchar(5),@startCount)), 2)

 set @strQuery=''select @bal=AM_Net_''+@paddedString+'' from ''+@instType+''_Accounts where AM_Acc_Cd=''''+@lgrCode+''''
 EXECUTE sp_executesql @strQuery, N''@bal money OUTPUT'', @bal=@queryOut OUTPUT
 
 set @balanceAdd=isnull(@balanceAdd,0)+ @queryOut
 set @startCount=@startCount+1
End

--add current month amounts
set @balanceAdd=isnull(@balanceAdd,0)+isnull(@monthAmt,0) 

                 
--calculate total balance by adding all calculations to opening balance
set @totalBalance=ISNULL(@opnBalance,0)+isnull(@balanceAdd,0)


End

select ISNULL(@totalBalance,0) as ''Total Balance''

END' 
END
GO
/****** Object:  Table [dbo].[User_Master]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Master]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User_Master](
	[Usr_Id] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Usr_Mdl_Cd] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Usr_Inst_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Usr_Nm] [char](45) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Usr_Role] [char](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Usr_Pwd] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Usr_Lst_Login] [char](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Usr_Lst_Wrk_Stn] [char](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Usr_Lckd] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
END
GO
/****** Object:  StoredProcedure [dbo].[TempUpdateAccounts]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TempUpdateAccounts]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TempUpdateAccounts]
	@month char(2),
	 @instType  varchar(2),  
   @instCode  varchar(5),
   @finYear  varchar(4) ,
   @accno  char(6),
   @lgrAmt  money
AS
declare @amt as money
declare @strQuery as nvarchar(max)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
  
  
  set @strQuery = ''select AM_Net_03 into ''+@amt+'' from [dbo].[''+@instType+''_Accounts] where 
			[AM_Fin_Yr]=''+@finYear+'' and [AM_Inst_Cd]=''''''+@instCode+'''''' and [AM_Inst_Typ]=''''''+@instType+''''''
			and [AM_Acc_Cd]=''''''+@accno+''''''''
  
  exec(@strQuery)

  set @lgrAmt=@lgrAmt +@amt
    
  set @strQuery=''update [dbo].[''+@instType+''_Accounts] '' +
				''set AM_Net_'''''' + @month + ''''''=''''''+@lgrAmt+'''''' where 
			[AM_Fin_Yr]=''+@finYear+'' and [AM_Inst_Cd]=''''''+@instCode+'''''' and [AM_Inst_Typ]=''''''+@instType+''''''
			and [AM_Acc_Cd]=''''''+@accno+''''''''    
           
	
  exec(@strQuery)

END
' 
END
GO
/****** Object:  Table [dbo].[Inst_Master]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inst_Master]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Inst_Master](
	[Inst_Cd] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Nm] [char](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Adr] [char](120) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Tel] [char](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_email] [char](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Fax] [char](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_web_adr] [char](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_PAN] [char](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_STN] [char](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_STN_Reg_Dt] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_80G_Reg_No] [char](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Prin_Nm] [char](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Prin_Dsgn] [char](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_VP_Nm] [char](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Reg_No] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Link_No] [bigint] NULL,
	[Inst_Cls_Yr] [nchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_SAM_Dt] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_FAM_Dt] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Exam_Dt] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_PAM_Dt] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_LiM_Dt] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Bank_Nm] [char](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Acc_No] [char](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_UID_Srl] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Adm_Rct_Srl] [int] NULL,
	[Inst_Exm_Rct_Srl] [int] NULL,
	[Inst_Oth_Rct_Srl] [int] NULL,
	[Inst_Soc_Rct_Srl] [int] NULL,
	[Inst_Mis_Rct_Srl] [int] NULL,
	[Inst_F_Indctr] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_SMTP] [char](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_User] [char](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Pass] [char](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Mdl_Cd] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inst_Vch_Ref_No] [int] NULL
)
END
GO
/****** Object:  StoredProcedure [dbo].[GetSPParameters]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSPParameters]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSPParameters]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select PARAMETER_NAME,DATA_TYPE from information_schema.parameters
where specific_name=''Upsert_LedgerAccount''
order by ORDINAL_POSITION
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetGeneralLedgerReportDetails]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetGeneralLedgerReportDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetGeneralLedgerReportDetails]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--Select Inst_Nm, Inst_Adr from Inst_Master

	SELECT		Lgr_VCH_Dt,Lgr_Vch_No,Lgr_Vch_Ref_No,Lgr_Ref_No,Lgr_Ref_Dt,Lgr_Amt,Lgr_Narr,Lgr_Fin_Yr,Lgr_Acc_Cd
	FROM		CG_Ledger
	Group by	Lgr_Acc_Cd,Lgr_VCH_Dt,Lgr_Vch_No,Lgr_Vch_Ref_No,Lgr_Ref_No,Lgr_Ref_Dt,Lgr_Amt,Lgr_Narr,Lgr_Fin_Yr
	 
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetCashBankReportDetails]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCashBankReportDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCashBankReportDetails]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--Select Inst_Nm, Inst_Adr from Inst_Master

	SELECT			VH.VH_Vch_No, VH.VH_Vch_Ref_No, VD.VD_Lgr_Cd, Acc.AM_Acc_Nm, VD.VD_Narr, VH.VH_Pty_Nm, VD.VD_Ref_Dt, VD.VD_Amt, VD.VD_Fin_Yr
	FROM			CG_Voucher_Detail AS VD 
	INNER JOIN		CG_Voucher_Header AS VH 
	ON				VD.VD_Vch_Ref_No = VH.VH_Vch_Ref_No 
	LEFT OUTER JOIN	CG_Accounts AS Acc 
	ON				VH.VH_Acc_Cd = Acc.AM_Acc_Cd
	 
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAccountDetails]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAccountDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAccountDetails]
	-- Add the parameters for the stored procedure here
	@accCode as char(6)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

if @accCode is not null
begin
SELECT [AM_Fin_Yr]
      ,[AM_Inst_Cd]
      ,[AM_Inst_Typ]
      ,[AM_Brn_Cd]
      ,[AM_Lgr_Cd]
      ,[AM_Acc_Cd]
      ,[AM_Acc_Nm]
      ,[AM_Calls]
      ,[AM_Opn_Bal]
      ,[AM_OB_Cr_Dr]
      ,[AM_ABS_Opn_Bal]      
      ,[AM_LLY_Budg]
      ,[AM_LLY_Actu]
      ,[AM_LYr_Budg]
      ,[AM_LYr_Actu]
      ,[AM_Cyr_Budg]
      ,[AM_Ent_By]
      ,[AM_Ent_Dt]
      ,[AM_Upd_By]
      ,[AM_Upd_Dt]
  FROM [dbo].[CG_Accounts]
  where AM_Acc_Cd=@accCode
end
else
begin
	SELECT [AM_Fin_Yr]
      ,[AM_Inst_Cd]
      ,[AM_Inst_Typ]
      ,[AM_Brn_Cd]
      ,[AM_Lgr_Cd]
      ,[AM_Acc_Cd]
      ,[AM_Acc_Nm]
      ,[AM_Calls]
      ,[AM_Opn_Bal]
      ,[AM_OB_Cr_Dr]
      ,[AM_ABS_Opn_Bal]      
      ,[AM_LLY_Budg]
      ,[AM_LLY_Actu]
      ,[AM_LYr_Budg]
      ,[AM_LYr_Actu]
      ,[AM_Cyr_Budg]
      ,[AM_Ent_By]
      ,[AM_Ent_Dt]
      ,[AM_Upd_By]
      ,[AM_Upd_Dt]
  FROM [dbo].[CG_Accounts]
  
end


END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Upsert_VoucherHeader]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Upsert_VoucherHeader]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[Upsert_VoucherHeader]
	
	@finYear char(4),
	@InstCode char(5),
	@InstType char(2),
	@Branch_cd char(3),
	@Link_no char(12),
	@Link_dt datetime,
	@Party_nm char(100),
	@Daybook_cd char(4),
	@Transaction_ty char(2),
	@Voucher_no char(6),
	@Voucher_dt datetime,
	@Chque_No char(6),
	@Chque_dt datetime,	
	@Clear_dt datetime,
	@Ref_No char(40),
	@Ref_dt datetime,
	@voucherref_no char(40),
	@Lgr_Cd char(2),
	@Acc_Cd char(6),
	@Amount money,
	@Cr_Dr char(2),
	@ABS_Amt money,
	@Ent_By char(5),
	@Ent_Dt datetime ,
 	@updatedBy char(5),
	@updatedOn datetime,
	@Conf_By char(5),
	@Conf_date datetime 
AS
declare @count int

BEGIN
	SET NOCOUNT ON;

   select @count=count(*) from dbo.CG_Voucher_Header where  VH_Fin_Yr=@finYear and VH_Inst_Cd=@InstCode and VH_Inst_Typ=@InstType and VH_Brn_Cd=@Branch_cd and VH_Lnk_No=@Link_no 
   
   
if @count=0 
begin
insert into dbo.CG_Voucher_Header values(@finYear,
	@InstCode ,
	@InstType ,
	@Branch_cd,
	@Link_no ,
	@Link_dt ,
	@Party_nm ,
	@Daybook_cd ,
	@Transaction_ty ,
	@Voucher_no ,
	@Voucher_dt ,
	@Chque_No ,
	@Chque_dt ,
	@Clear_dt ,
	@Ref_No ,
	@Ref_dt ,
	@voucherref_no ,
	@Lgr_Cd ,
	@Acc_Cd ,
	@Amount ,
	@Cr_Dr ,
	@ABS_Amt ,
	@Ent_By ,
	@Ent_Dt  ,
 	@updatedBy ,
	@updatedOn ,
	@Conf_By ,
	@Conf_date  )
END
else
begin

UPDATE dbo.CG_Voucher_Header

   SET VH_Lnk_Dt=@Link_dt ,
	   VH_Pty_Nm =@Party_nm ,
	    VH_Dbk_Cd=@Daybook_cd ,
	    VH_Trn_Typ=@Transaction_ty ,
	    VH_Vch_No=@voucher_no ,
	    VH_Vch_Dt=@Voucher_dt ,
		VH_Chq_No=@Chque_No ,
		VH_Chq_Dt=@Chque_dt,
		VH_Clr_Dt=@Clear_dt ,
		VH_Ref_No=@Ref_No ,
		VH_Ref_Dt=@Ref_dt,
		VH_Vch_Ref_No=@voucherref_no ,
		VH_Lgr_Cd=@Lgr_Cd ,
		VH_Acc_Cd=@Acc_Cd ,
		VH_Cr_Dr=@Cr_Dr ,
		VH_ABS_Amt=@ABS_Amt,
		VH_Ent_By=@Ent_By,
		VH_Ent_Dt=@Ent_Dt,
		VH_Upd_By=@updatedBy,
		VH_Upd_Dt=@updatedOn,
		VH_Conf_By=@Conf_By,
		VH_Conf_Dt=@Conf_date 
	 where VH_Fin_Yr=@finYear and VH_Inst_Cd=@InstCode and VH_Inst_Typ=@InstType and VH_Brn_Cd=@Branch_cd and VH_Lnk_No=@Link_no
   end 
   end  

' 
END
GO
/****** Object:  StoredProcedure [dbo].[Upsert_VoucherDetails]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Upsert_VoucherDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Upsert_VoucherDetails] 
	@finYear char(4),
	@InstCode char(5),
	@InstType char(2),
	@Branch_cd char(3),
	@Link_no char(12),
	@Daybook_cd char(4),
	@Transaction_ty char(2),
	@Voucher_no char(6),	
	@Voucheref_No char(6),
	@seq_no char(3),
	@Ref_no char(40),
	@Ref_dt datetime,
	@Narration char(100),
	@Lgr_Cd char(2),
	@Acc_Cd char(6),
	@Amount money,
	@Cr_Dr char(2),
	@ABS_Amt money,
	@Ent_By char(5),
	@Ent_Dt datetime ,
 	@updatedBy char(5),
	@updatedOn datetime,
	@Conf_By char(5),
	@Conf_date datetime 
AS
declare @count int

BEGIN
	SET NOCOUNT ON;

   select @count=count(*) from dbo.CG_Voucher_Detail where  VD_Fin_Yr=@finYear and VD_Inst_Cd=@InstCode and VD_Inst_Typ=@InstType and VD_Brn_Cd=@Branch_cd and VD_Lnk_No=@Link_no and VD_Seq_No=@seq_no 
   
   
if @count=0 
begin
insert into dbo.CG_Voucher_Detail values(@finYear,
	@InstCode ,
	@InstType ,
	@Branch_cd,
	@Link_no ,
	@Daybook_cd ,
	@Transaction_ty ,
	@Voucher_no,
	@Voucheref_No,
	@seq_no,
	@Ref_No ,
	@Ref_dt ,
	@Narration ,
	@Lgr_Cd ,
	@Acc_Cd ,
	@Amount ,
	@Cr_Dr ,
	@ABS_Amt ,
	@Ent_By ,
	@Ent_Dt  ,
 	@updatedBy ,
	@updatedOn ,
	@Conf_By ,
	@Conf_date  )
END
else
begin

UPDATE dbo.CG_Voucher_Detail

   SET 
	    VD_Dbk_Cd=@Daybook_cd ,
	    [VD_Trn_Typ]=@Transaction_ty ,
	    VD_Vch_No=@voucher_no ,
	    VD_Vch_Ref_No=@Voucheref_No ,
		VD_Ref_No=@Ref_No ,
		VD_Ref_Dt=@Ref_dt,
		VD_Narr=@Narration ,
		VD_Lgr_Cd=@Lgr_Cd ,
		VD_Acc_Cd=@Acc_Cd ,
		VD_Amt=@Amount ,
		VD_Cr_Dr=@Cr_Dr ,
		VD_ABS_Amt=@ABS_Amt,
		VD_Ent_By=@Ent_By,
		VD_Ent_Dt=@Ent_Dt,
		VD_Upd_By=@updatedBy,
		VD_Upd_Dt=@updatedOn,
		VD_Conf_By=@Conf_By,
		VD_Conf_Dt=@Conf_date 
	 where VD_Fin_Yr=@finYear and VD_Inst_Cd=@InstCode and VD_Inst_Typ=@InstType and VD_Brn_Cd=@Branch_cd and VD_Lnk_No=@Link_no and VD_Seq_No=@seq_no 
   end 
   end  

' 
END
GO
/****** Object:  StoredProcedure [dbo].[Upsert_Ledger]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Upsert_Ledger]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Upsert_Ledger] 
	@finYear char(4),
	@InstCode char(5),
	@InstType char(2),
	@Branch_cd char(3),
	@Link_no char(12),
	@Link_dt datetime,
	@Daybook_cd char(4),
	@Transaction_ty char(2),
	@Voucher_no char(6),
	@Voucher_dt datetime,
	@voucherref_no char(6),
	@seq_no char(3),
	@narration char(100),
	@Chque_No char(6),
	@Chque_dt datetime,	
	@Ref_No char(40),
	@Ref_dt datetime,
	@Lgr_Cd char(2),
	@Acc_Cd char(6),
	@Amount money,
	@Cr_Dr char(2),
	@ABS_Amt money,
	@Ent_By char(5),
	@Ent_Dt datetime ,
 	@updatedBy char(5),
	@updatedOn datetime,
	@Conf_By char(5),
	@Conf_date datetime 
AS
declare @count int

BEGIN
	SET NOCOUNT ON  
 insert into dbo.CG_Ledger values(@finYear,
	@InstCode ,
	@InstType ,
	@Branch_cd,
	@Link_no ,
	@Link_dt ,
	@Daybook_cd ,
	@Transaction_ty ,
	@Voucher_no ,
	@Voucher_dt ,
	@voucherref_no ,
	@seq_no ,
	@narration ,
	@Chque_No ,
	@Chque_dt ,
	@Ref_No ,
	@Ref_dt ,
	@Lgr_Cd ,
	@Acc_Cd ,
	@Amount ,
	@Cr_Dr ,
	@ABS_Amt ,
	@Ent_By ,
	@Ent_Dt  ,
 	@updatedBy ,
	@updatedOn ,
	@Conf_By ,
	@Conf_date  )
END
  

' 
END
GO
/****** Object:  StoredProcedure [dbo].[Upsert_BankBooks]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Upsert_BankBooks]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Upsert_BankBooks] 
	-- Add the parameters for the stored procedure here
	@finYear char(4),
	@InstitutionCode char(5),
	@InstType char(2),
	@brnCd char(3)=null,
	@dbkcd char(4),
	@dbkNm char(50),
	@dbkTyp char(1),
	@acccd char(6),
	@bnkNm char(50)=null,
	@bnkBrn char(30)=null,
	@bnkAcNo char(16)=null,
	@bnkOd money=null
AS
declare @count int
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

select @count=count(*) from CG_Daybooks where
DM_Dbk_Cd=@dbkcd and DM_Inst_Typ=@InstType and DM_Inst_Cd=@InstitutionCode


if @count=0 
begin

Insert into CG_Daybooks(DM_Fin_Yr,DM_Inst_Cd,DM_Inst_Typ,DM_Brn_Cd,DM_Dbk_Cd,DM_Dbk_Nm,DM_Dbk_Typ,DM_Acc_Cd,
						DM_Bnk_Nm,DM_Bnk_Brn,DM_Bnk_AcNo,DM_Bnk_OD,DM_Ent_Dt) 
                        values
						(@finYear,@InstitutionCode,@InstType,@brnCd,@dbkcd,@dbkNm,@dbkTyp,@acccd,@bnkNm,@bnkBrn,@bnkAcNo
						,@bnkOd,GetDate())


end
else
begin

Update CG_Daybooks Set DM_Acc_Cd=@acccd,DM_Dbk_Typ=@dbkTyp,DM_Bnk_Brn=@bnkBrn,DM_Dbk_Nm=@dbkNm,
			DM_Bnk_AcNo=@bnkAcNo,DM_Bnk_Nm=@bnkNm,DM_Bnk_OD=@bnkOd,DM_Upd_Dt=GetDate()
			Where DM_Dbk_Cd=@dbkcd and DM_Inst_Typ=@InstType and DM_Inst_Cd=@InstitutionCode

end

End


' 
END
GO
/****** Object:  StoredProcedure [dbo].[Upsert_AccountDetail]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Upsert_AccountDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Upsert_AccountDetail] 
	-- Add the parameters for the stored procedure here
	@finYear char(4),
	@InstitutionCode char(5),
	@InstType char(2),
	@AccCode char(6),
	@AccName char(50),
	@AccOpenBal money,
	@AccOB_CR_DR varchar(2),
	@AccABSOpenBal money,
	@AccLLYBud money,
	@AccLLYAct money,
	@AccLYBud money,
	@AccLYAct money,
	@AccCYBud money,	
	@createBy char(5),
	@createdOn date,
	@updatedBy char(5),
	@updatedOn date
AS
declare @count int
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

select @count=count(*) from CG_Accounts where
AM_Acc_Cd=@AccCode and AM_Inst_Typ=@InstType and AM_Inst_Cd=@InstitutionCode


if @count=0 
begin

INSERT INTO [dbo].[CG_Accounts]
           ([AM_Fin_Yr]
           ,[AM_Inst_Cd]
           ,[AM_Inst_Typ]
           ,[AM_Lgr_Cd]
           ,[AM_Acc_Cd]
           ,[AM_Acc_Nm]           
           ,[AM_Opn_Bal]
           ,[AM_OB_Cr_Dr]
           ,[AM_ABS_Opn_Bal]           
           ,[AM_LLY_Budg]
           ,[AM_LLY_Actu]
           ,[AM_LYr_Budg]
           ,[AM_LYr_Actu]
           ,[AM_Cyr_Budg]
           ,[AM_Ent_By]
           ,[AM_Ent_Dt]
           ,[AM_Upd_By]
           ,[AM_Upd_Dt])
     VALUES
           (@finYear,
		   @InstitutionCode,
		   @InstType,
		   ''00'',
		   @AccCode,
		   Ltrim(Rtrim(@AccName)),		   
	@AccOpenBal ,
	@AccOB_CR_DR ,
	@AccABSOpenBal ,
	@AccLLYBud,
	@AccLLYAct,
	@AccLYBud ,
	@AccLYAct ,
	@AccCYBud ,	
	@createBy ,
	@createdOn,
	@updatedBy,
	@updatedOn
		   )
end
else
begin

UPDATE [dbo].[CG_Accounts]
   SET                  
      [AM_Acc_Nm] = @AccName      
      ,[AM_Opn_Bal] = @AccOpenBal
      ,[AM_OB_Cr_Dr] = @AccOB_CR_DR
      ,[AM_ABS_Opn_Bal] = @AccABSOpenBal      
      ,[AM_LLY_Budg] = @AccLLYBud
      ,[AM_LLY_Actu] = @AccLLYAct
      ,[AM_LYr_Budg] = @AccLYBud
      ,[AM_LYr_Actu] = @AccLYAct
      ,[AM_Cyr_Budg] = @AccCYBud      
      ,[AM_Upd_By] = @updatedBy
      ,[AM_Upd_Dt] = @updatedOn
 WHERE AM_Acc_Cd=@AccCode and AM_Inst_Typ=@InstType and AM_Inst_Cd=@InstitutionCode

end

End


' 
END
GO
/****** Object:  Trigger [UpdateNetAmount]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UpdateNetAmount]'))
EXEC dbo.sp_executesql @statement = N'CREATE trigger [dbo].[UpdateNetAmount] on [dbo].[CG_Ledger]
for Insert
as

select * into #tempInserted from inserted

declare @instType as varchar(10)
set @instType=(select lgr_Inst_Typ from inserted)

declare @voucherDate as date
set @voucherDate=(select Lgr_Vch_Dt from inserted)
declare @vchDateMonth as varchar(2)
set @vchDateMonth=Convert(varchar(2),DatePart(mm,@voucherDate))

declare @paddedString as varchar(2)
set @paddedString=right(''0''+ rtrim(@vchDateMonth), 2)

If @voucherDate is not null
Begin

declare @strQuery as nvarchar(max)

set @strQuery=
''
declare @amAccCd as char(6)
set @amAccCd=(select Lgr_Acc_Cd from #tempInserted)

declare @voucherAmt as money
set @voucherAmt=CONVERT(money,(select Lgr_Amt from #tempInserted ))

update ''+@instType+''_Accounts set AM_Net_''+@paddedString+''=ISNULL(AM_Net_''+@paddedString+'',0)+@voucherAmt where AM_Acc_Cd=@amAccCd''

exec(@strQuery)

drop table #tempInserted

END
'
GO
/****** Object:  Trigger [tgr_updateVoucherHeader]    Script Date: 01/04/2016 20:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgr_updateVoucherHeader]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[tgr_updateVoucherHeader]
   ON  [dbo].[CG_Voucher_Header]
   AFTER UPDATE
AS 

BEGIN
SET NOCOUNT ON;

declare @voucher_no varchar(6)
DECLARE @linkno varchar(12)
set @linkno =(select VH_Lnk_No  from inserted )
SET @voucher_no = (SELECT VH_Vch_No FROM inserted  )
UPDATE 	CG_Voucher_Header SET VH_Vch_No =@voucher_no,@linkno=GETDATE () where VH_Lnk_No=@linkno
   
END
'
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCashBankReportDetails]'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetCashBankReportDetails]
	-- Add the parameters for the stored procedure here
	@instType varchar(2),
	@Fromdate as date,-- vh confirm date
	@ToDate as date,
	@VH_Dbk_Cd char(4)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @strQuery as nvarchar(max)
	set @strQuery = ''SELECT 
					VH.VH_Vch_No, 
					VH.VH_Vch_Ref_No, 
					VD.VD_Lgr_Cd, 
					Acc.AM_Acc_Nm, 
					VD.VD_Narr, 
					VH.VH_Pty_Nm, 
					VD.VD_Ref_Dt,
					VD.VD_Fin_Yr,
					CASE 
					WHEN VD.VD_Amt > 0 THEN VD.VD_ABS_Amt
					END as Receipt,
					CASE 
					WHEN VD.VD_Amt < 0 THEN VD.VD_ABS_Amt
					END as Payment,
					CASE WHEN VH.VH_Chq_No > 0 THEN VH.VH_Chq_No
					ELSE ''Cash''
					END as TransactionType,
					VH.VH_ABS_Amt,
					CASE 
					WHEN VD.VD_Amt > 0 THEN VH.VH_Amt
					END as ReceiptSum,
					CASE 
					WHEN VD.VD_Amt < 0 THEN VH.VH_Amt
					END as PaymentSum,
					VH.VH_Amt,
					VD.VD_Amt,
					VD.VD_Acc_Cd
					,(Select Top 1 sum(VD_Amt) from ''+@instType+''_Voucher_Detail
					where VD_Lnk_No <= VD.VD_Lnk_No) as RunningBalance
					FROM ''+@instType+''_Voucher_Detail AS VD 
	INNER JOIN		''+@instType+''_Voucher_Header AS VH 
	ON				VD.VD_Vch_Ref_No = VH.VH_Vch_Ref_No 
	LEFT OUTER JOIN	''+@instType+''_Accounts AS Acc 
	ON				VH.VH_Acc_Cd = Acc.AM_Acc_Cd
	WHERE			VH.VH_Dbk_Cd = ''''+@VH_Dbk_Cd+'''' AND VH.VH_Vch_No IS NOT NULL 
	ORDER BY		VD.VD_Lnk_No ASC''
	

	exec(@strQuery)

END'
END
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetInstitutionDetails]'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[GetInstitutionDetails]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select Inst_Nm, Inst_Adr from Inst_Master
	 
END
'
END


GO
ALTER trigger [dbo].[UpdateNetAmount] on [dbo].[CG_Ledger]
for Insert
as

select * into #tempInserted from inserted

declare @seqno as varchar(10)

set @seqno=(select top 1 lgr_seq_no from inserted)
if @seqno='000'
BEGIN
declare @instType as varchar(10)
set @instType=(select lgr_Inst_Typ from inserted)

declare @voucherDate as date
set @voucherDate=(select Lgr_Vch_Dt from inserted)
declare @vchDateMonth as varchar(2)
set @vchDateMonth=Convert(varchar(2),DatePart(mm,@voucherDate))

declare @paddedString as varchar(2)
set @paddedString=right('0'+ rtrim(@vchDateMonth), 2)

If @voucherDate is not null
Begin

declare @strQuery as nvarchar(max)

set @strQuery=
'
declare @amAccCd as char(6)
set @amAccCd=(select Lgr_Acc_Cd from #tempInserted)

declare @voucherAmt as money
set @voucherAmt=CONVERT(money,(select Lgr_Amt from #tempInserted ))

update '+@instType+'_Accounts set AM_Net_'+@paddedString+'=ISNULL(AM_Net_'+@paddedString+',0)+@voucherAmt where AM_Acc_Cd=@amAccCd'

exec(@strQuery)
END

drop table #tempInserted

END

GO

ALTER trigger [dbo].[UpdateNetAmount] on [dbo].[CG_Ledger]
for Insert
as

select * into #tempInserted from inserted


declare @instType as varchar(10)
set @instType=(select top 1 lgr_Inst_Typ from inserted)

declare @voucherDate as date
set @voucherDate=(select top 1 Lgr_Vch_Dt from inserted)
declare @vchDateMonth as varchar(2)
set @vchDateMonth=Convert(varchar(2),DatePart(mm,@voucherDate))

declare @paddedString as varchar(2)
set @paddedString=right('0'+ rtrim(@vchDateMonth), 2)

If @voucherDate is not null
Begin

declare @strQuery as nvarchar(max)

set @strQuery=

'update '+@instType+'_Accounts 
set AM_Net_'+@paddedString+'=ISNULL(AM_Net_'+@paddedString+',0)+LG.Lgr_Amt 
FROM '+@instType+'_Accounts AM
INNER JOIN #tempInserted LG
ON AM.AM_Acc_Cd=LG.Lgr_Acc_Cd'

exec(@strQuery)

drop table #tempInserted

END
