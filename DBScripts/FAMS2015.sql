/****** Object:  UserDefinedFunction [dbo].[Function1]    Script Date: 01/24/2016 13:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Function1]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[Function1]
	(
	@lgrCode varchar(10),
@vchDate datetime,
@instType varchar(5)
	)
RETURNS money
AS
	BEGIN

	declare @firstDate as datetime
set @firstDate=(SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@vchDate)-1),@vchDate),101))

declare @processingMonth as int
set @processingMonth=DATEPART(mm,@vchDate)

declare @totalBalance as money
declare @balanceAdd as money

declare @opnBalance as money
declare @opnQuery as nvarchar(max)

set @opnQuery=''select @obal=AM_Opn_Bal from CG_Accounts where AM_Acc_Cd=''''''+@lgrCode+''''''''

EXECUTE sp_executesql @opnQuery, N''@obal money OUTPUT'', @obal=@opnBalance OUTPUT                  

declare @monthAmt as money
declare @monthQuery as nvarchar(max)
set @monthQuery=''select @mthAmt=SUM(Lgr_Amt) from CG_Ledger where Lgr_Vch_Dt>=''''''+convert(varchar(50),@firstDate)+'''''' and Lgr_Vch_Dt<=''''''+convert(varchar(50),@vchDate)+''''''
                  and Lgr_Acc_Cd=''''''+@lgrCode+'''''''' 
                  
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
set @paddedString=right(''0''+ rtrim(convert(varchar(5),@startCount)), 2)

 set @strQuery=''select @bal=AM_Net_''+@paddedString+'' from CG_Accounts where AM_Acc_Cd=''''''+@lgrCode+''''''''
 EXECUTE sp_executesql @strQuery, N''@bal money OUTPUT'', @bal=@queryOut OUTPUT
 
 set @balanceAdd=isnull(@balanceAdd,0)+ @queryOut
 set @startCount=@startCount+1
End

--add current month amounts
set @balanceAdd=isnull(@balanceAdd,0)+isnull(@monthAmt,0) 

                 
--calculate total balance by adding all calculations to opening balance
set @totalBalance=ISNULL(@opnBalance,0)+isnull(@balanceAdd,0)


End

SET @totalBalance= ISNULL(@totalBalance,0)

	RETURN @totalBalance
	END
' 
END
GO
/****** Object:  Table [dbo].[CG_Voucher_Header]    Script Date: 01/24/2016 13:52:52 ******/
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
	[VH_Vch_No] [char](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'    ', N'     ', N'  ', N'   ', N'            ', CAST(0x0000A59200000000 AS DateTime), N'                                                                                                    ', N'    ', N'  ', N'        ', CAST(0x0000A59200000000 AS DateTime), N'      ', CAST(0x0000A59200000000 AS DateTime), CAST(0x0000A59200000000 AS DateTime), N'                                        ', CAST(0x0000A59200000000 AS DateTime), N'      ', N'  ', N'      ', 0.0000, N'  ', 0.0000, N'     ', CAST(0x0000A59200000000 AS DateTime), N'     ', CAST(0x0000A59200000000 AS DateTime), N'     ', CAST(0x0000A59200000000 AS DateTime))
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000042', CAST(0x0000A58D00000000 AS DateTime), N'SNEHAL                                                                                              ', N'CASH', N'CR', N'01140001', CAST(0x0000A58D00000000 AS DateTime), N'      ', CAST(0x0000000000000000 AS DateTime), NULL, N'REF-CASH1                               ', CAST(0x0000A58D00000000 AS DateTime), N'000019', N'00', N'A00004', 2000.0000, N'Dr', 2000.0000, N'1    ', CAST(0x0000A58D014D1839 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D014D8F12 AS DateTime))
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000043', CAST(0x0000A58D00000000 AS DateTime), N'CHAHAWALA                                                                                           ', N'CASH', N'CP', N'01140002', CAST(0x0000A58D00000000 AS DateTime), N'      ', CAST(0x0000000000000000 AS DateTime), NULL, N'REF-CP                                  ', CAST(0x0000A58D00000000 AS DateTime), N'000020', N'00', N'A00004', -500.0000, N'Cr', 500.0000, N'1    ', CAST(0x0000A58D014EA2A1 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D014EBD7E AS DateTime))
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000044', CAST(0x0000A58D00000000 AS DateTime), N'SUSHIL                                                                                              ', N'BANK', N'BR', N'01140001', CAST(0x0000A58D00000000 AS DateTime), N'120099', CAST(0x0000A58D00000000 AS DateTime), NULL, N'RES-BANK                                ', CAST(0x0000A58D00000000 AS DateTime), N'000021', N'00', N'A00005', 3000.0000, N'Dr', 3000.0000, N'1    ', CAST(0x0000A58D014F992A AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D014FB4C4 AS DateTime))
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000045', CAST(0x0000A58D00000000 AS DateTime), N'SWEEPER                                                                                             ', N'BANK', N'BP', N'01140002', CAST(0x0000A58D00000000 AS DateTime), N'987867', CAST(0x0000A58D00000000 AS DateTime), NULL, N'REF BANK                                ', CAST(0x0000A58D00000000 AS DateTime), N'000022', N'00', N'A00005', -1000.0000, N'Cr', 1000.0000, N'1    ', CAST(0x0000A58D015017E3 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D01502650 AS DateTime))
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000046', CAST(0x0000A58E00000000 AS DateTime), N'15JAN                                                                                               ', N'CASH', N'CR', N'01150003', CAST(0x0000A58E00000000 AS DateTime), N'      ', CAST(0x0000000000000000 AS DateTime), NULL, N'REF15                                   ', CAST(0x0000A58E00000000 AS DateTime), N'000023', N'00', N'A00004', 200.0000, N'Dr', 200.0000, N'1    ', CAST(0x0000A58E013F1284 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58E013F25DD AS DateTime))
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000047', CAST(0x0000A58E00000000 AS DateTime), N'CHECK TEST                                                                                          ', N'BANK', N'BP', N'01150003', CAST(0x0000A58E00000000 AS DateTime), N'898989', CAST(0x0000A58E00000000 AS DateTime), NULL, N'BANKPAY                                 ', CAST(0x0000A58E00000000 AS DateTime), N'000024', N'00', N'A00005', -300.0000, N'Cr', 300.0000, N'1    ', CAST(0x0000A58E014576CA AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58E01458674 AS DateTime))
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000048', CAST(0x0000A58E00000000 AS DateTime), N'PAYMENTVH                                                                                           ', N'CASH', N'CP', N'01150004', CAST(0x0000A58E00000000 AS DateTime), N'      ', CAST(0x0000000000000000 AS DateTime), NULL, N'REFPAY                                  ', CAST(0x0000A58E00000000 AS DateTime), N'000025', N'00', N'A00004', -100.0000, N'Cr', 100.0000, N'1    ', CAST(0x0000A58E015B8662 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58E015B9019 AS DateTime))
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000049', CAST(0x0000A58E00000000 AS DateTime), N'PANKAJ                                                                                              ', N'BANK', N'BP', N'01150004', CAST(0x0000A58E00000000 AS DateTime), N'12345 ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'REF0008                                 ', CAST(0x0000A58E00000000 AS DateTime), N'000026', N'00', N'A00005', -300.0000, N'Cr', 300.0000, N'1    ', CAST(0x0000A58E015EFBDC AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58E015F0A8A AS DateTime))
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000050', CAST(0x0000A58E00000000 AS DateTime), N'BOOK DEPOT                                                                                          ', N'BANK', N'BR', N'01150005', CAST(0x0000A58E00000000 AS DateTime), N'987655', CAST(0x0000A58E00000000 AS DateTime), NULL, N'REF0006                                 ', CAST(0x0000A58E00000000 AS DateTime), N'000027', N'00', N'A00005', 500.0000, N'Dr', 500.0000, N'1    ', CAST(0x0000A58E015F9ECA AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58E015FAE28 AS DateTime))
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000051', CAST(0x0000A59000000000 AS DateTime), N'CHAUDHARI                                                                                           ', N'CASH', N'CR', N'01170005', CAST(0x0000A59000000000 AS DateTime), N'      ', CAST(0x0000000000000000 AS DateTime), NULL, N'REF2344                                 ', CAST(0x0000A59000000000 AS DateTime), N'000028', N'00', N'A00004', 200.0000, N'Dr', 200.0000, N'1    ', CAST(0x0000A59000FD4DFD AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A59000FD5E2F AS DateTime))
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000052', CAST(0x0000A59000000000 AS DateTime), N'99999                                                                                               ', N'CASH', N'CR', N'01170006', CAST(0x0000A59000000000 AS DateTime), N'      ', CAST(0x0000000000000000 AS DateTime), NULL, N'5666                                    ', CAST(0x0000A59000000000 AS DateTime), N'000029', N'00', N'A00004', 300.0000, N'Dr', 300.0000, N'1    ', CAST(0x0000A59001327529 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A59001363239 AS DateTime))
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000053', CAST(0x0000A59100000000 AS DateTime), N'SDFDS                                                                                               ', N'CASH', N'CR', N'01180007', CAST(0x0000A59100000000 AS DateTime), N'      ', CAST(0x0000000000000000 AS DateTime), NULL, N'DSFGD                                   ', CAST(0x0000A59100000000 AS DateTime), N'000030', N'00', N'A00004', 800.0000, N'Dr', 800.0000, N'1    ', CAST(0x0000A591015C7425 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A591015C7F6E AS DateTime))
INSERT [dbo].[CG_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000054', CAST(0x0000A59100000000 AS DateTime), N'JSHDF                                                                                               ', N'CASH', N'CR', N'01180008', CAST(0x0000A59100000000 AS DateTime), N'      ', CAST(0x0000000000000000 AS DateTime), NULL, N'REF455                                  ', CAST(0x0000A59100000000 AS DateTime), N'000031', N'00', N'A00004', 250.0000, N'Dr', 250.0000, N'1    ', CAST(0x0000A591015D168E AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A591015D216D AS DateTime))
/****** Object:  Table [dbo].[CG_Voucher_Detail]    Script Date: 01/24/2016 13:52:52 ******/
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
	[VD_Vch_No] [char](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'    ', N'     ', N'  ', N'   ', N'            ', N'   ', N'    ', N'  ', N'        ', N'      ', N'                                        ', CAST(0x0000A59200000000 AS DateTime), N'                                                                                                    ', N'  ', N'      ', 0.0000, N'  ', 0.0000, N'     ', CAST(0x0000A59200000000 AS DateTime), N'     ', CAST(0x0000A59200000000 AS DateTime), N'     ', CAST(0x0000A59200000000 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000042', N'001', N'CASH', N'CR', N'01140001', N'000019', N'REF-CASH1                               ', CAST(0x0000A58D00000000 AS DateTime), N'tution fee                                                                                          ', N'00', N'A00002', -1000.0000, N'Cr', 1000.0000, N'1    ', CAST(0x0000A58D014D1810 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D014D8F13 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000042', N'002', N'CASH', N'CR', N'01140001', N'000019', N'REF-CASH1                               ', CAST(0x0000A58D00000000 AS DateTime), N'library                                                                                             ', N'00', N'A00003', -1000.0000, N'Cr', 1000.0000, N'1    ', CAST(0x0000A58D014D1817 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D014D8F13 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000042', N'003', N'CASH', N'CR', N'01140001', N'000019', N'REF-CASH1                               ', CAST(0x0000A58D00000000 AS DateTime), N'to give                                                                                             ', N'00', N'A00001', 500.0000, N'Dr', 500.0000, N'1    ', CAST(0x0000A58D014D181E AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D014D8F13 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000042', N'004', N'CASH', N'CR', N'01140001', N'000019', N'REF-CASH1                               ', CAST(0x0000A58D00000000 AS DateTime), N'suffice                                                                                             ', N'00', N'A00002', -500.0000, N'Cr', 500.0000, N'1    ', CAST(0x0000A58D014D1830 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D014D8F13 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000043', N'001', N'CASH', N'CP', N'01140002', N'000020', N'REF-CP                                  ', CAST(0x0000A58D00000000 AS DateTime), N'chahapatti                                                                                          ', N'00', N'A00002', 200.0000, N'Dr', 200.0000, N'1    ', CAST(0x0000A58D014EA294 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D014EBD7E AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000043', N'002', N'CASH', N'CP', N'01140002', N'000020', N'REF-CP                                  ', CAST(0x0000A58D00000000 AS DateTime), N'milk                                                                                                ', N'00', N'A00001', 300.0000, N'Dr', 300.0000, N'1    ', CAST(0x0000A58D014EA29B AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D014EBD7E AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000044', N'001', N'BANK', N'BR', N'01140001', N'000021', N'RES-BANK                                ', CAST(0x0000A58D00000000 AS DateTime), N'bank details                                                                                        ', N'00', N'A00002', -3000.0000, N'Cr', 3000.0000, N'1    ', CAST(0x0000A58D014F9923 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D014FB4C4 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000045', N'001', N'BANK', N'BP', N'01140002', N'000022', N'REF BANK                                ', CAST(0x0000A58D00000000 AS DateTime), N'vd1                                                                                                 ', N'00', N'A00002', 200.0000, N'Dr', 200.0000, N'1    ', CAST(0x0000A58D015017D3 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D01502650 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000045', N'002', N'BANK', N'BP', N'01140002', N'000022', N'REF BANK                                ', CAST(0x0000A58D00000000 AS DateTime), N'vd2                                                                                                 ', N'00', N'A00003', 900.0000, N'Dr', 900.0000, N'1    ', CAST(0x0000A58D015017D6 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D01502650 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000045', N'003', N'BANK', N'BP', N'01140002', N'000022', N'REF BANK                                ', CAST(0x0000A58D00000000 AS DateTime), N'vd3                                                                                                 ', N'00', N'A00002', -100.0000, N'Cr', 100.0000, N'1    ', CAST(0x0000A58D015017DD AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58D01502650 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000046', N'001', N'CASH', N'CR', N'01150003', N'000023', N'REF15                                   ', CAST(0x0000A58E00000000 AS DateTime), N'200 ale                                                                                             ', N'00', N'A00002', -200.0000, N'Cr', 200.0000, N'1    ', CAST(0x0000A58E013F127B AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58E013F25E3 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000047', N'001', N'BANK', N'BP', N'01150003', N'000024', N'BANKPAY                                 ', CAST(0x0000A58E00000000 AS DateTime), N'kdjsf uefkjsdf jhsgd fjsd hfsdg hjgfsdj gdfkh gdfskh ghfdg                                          ', N'00', N'A00006', 100.0000, N'Dr', 100.0000, N'1    ', CAST(0x0000A58E014576C1 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58E01458675 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000047', N'002', N'BANK', N'BP', N'01150003', N'000024', N'BANKPAY                                 ', CAST(0x0000A58E00000000 AS DateTime), N'slkh jsdgkj dfkgh dkj fhgkdhgkd                                                                     ', N'00', N'A00003', 200.0000, N'Dr', 200.0000, N'1    ', CAST(0x0000A58E01455D2D AS DateTime), N'1    ', CAST(0x0000A58E014576C4 AS DateTime), N'1    ', CAST(0x0000A58E01458675 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000048', N'001', N'CASH', N'CP', N'01150004', N'000025', N'REFPAY                                  ', CAST(0x0000A58E00000000 AS DateTime), N'gelele                                                                                              ', N'00', N'A00003', 100.0000, N'Dr', 100.0000, N'1    ', CAST(0x0000A58E015B8651 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58E015B9019 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000049', N'001', N'BANK', N'BP', N'01150004', N'000026', N'REF0008                                 ', CAST(0x0000A58E00000000 AS DateTime), N'VD1 Value 2                                                                                         ', N'00', N'A00002', 200.0000, N'Dr', 200.0000, N'1    ', CAST(0x0000A58E015EFBCA AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58E015F0A8B AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000049', N'002', N'BANK', N'BP', N'01150004', N'000026', N'REF0008                                 ', CAST(0x0000A58E00000000 AS DateTime), N'VD2 Value                                                                                           ', N'00', N'A00006', 100.0000, N'Dr', 100.0000, N'1    ', CAST(0x0000A58E015EFBD4 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58E015F0A8B AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000050', N'001', N'BANK', N'BR', N'01150005', N'000027', N'REF0006                                 ', CAST(0x0000A58E00000000 AS DateTime), N'BD1                                                                                                 ', N'00', N'A00006', -200.0000, N'Cr', 200.0000, N'1    ', CAST(0x0000A58E015F9E9C AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58E015FAE28 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000050', N'002', N'BANK', N'BR', N'01150005', N'000027', N'REF0006                                 ', CAST(0x0000A58E00000000 AS DateTime), N'BD2                                                                                                 ', N'00', N'A00003', -400.0000, N'Cr', 400.0000, N'1    ', CAST(0x0000A58E015F9EA3 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58E015FAE28 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000050', N'003', N'BANK', N'BR', N'01150005', N'000027', N'REF0006                                 ', CAST(0x0000A58E00000000 AS DateTime), N'DR type val                                                                                         ', N'00', N'A00002', 100.0000, N'Dr', 100.0000, N'1    ', CAST(0x0000A58E015F9EAC AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A58E015FAE28 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000051', N'001', N'CASH', N'CR', N'01170005', N'000028', N'REF2344                                 ', CAST(0x0000A59000000000 AS DateTime), N'sne                                                                                                 ', N'00', N'A00001', -100.0000, N'Cr', 100.0000, N'1    ', CAST(0x0000A59000FD4DD8 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A59000FD5E36 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000051', N'002', N'CASH', N'CR', N'01170005', N'000028', N'REF2344                                 ', CAST(0x0000A59000000000 AS DateTime), N'sne                                                                                                 ', N'00', N'A00001', -100.0000, N'Cr', 100.0000, N'1    ', CAST(0x0000A59000FD4DE7 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A59000FD5E36 AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000052', N'001', N'CASH', N'CR', N'01170006', N'000029', N'5666                                    ', CAST(0x0000A59000000000 AS DateTime), N'seq test                                                                                            ', N'00', N'A00002', -200.0000, N'Cr', 200.0000, N'1    ', CAST(0x0000A59001327512 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A5900136323A AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000052', N'002', N'CASH', N'CR', N'01170006', N'000029', N'5666                                    ', CAST(0x0000A59000000000 AS DateTime), N'test1                                                                                               ', N'00', N'A00003', -100.0000, N'Cr', 100.0000, N'1    ', CAST(0x0000A59001327522 AS DateTime), NULL, NULL, N'1    ', CAST(0x0000A5900136323A AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000053', N'001', N'CASH', N'CR', N'01180007', N'000030', N'DSFGD                                   ', CAST(0x0000A59100000000 AS DateTime), N'DRGD                                                                                                ', N'00', N'A00003', -800.0000, N'Cr', 800.0000, N'1    ', CAST(0x0000A591015C744D AS DateTime), N'1    ', CAST(0x0000A591015C744D AS DateTime), N'1    ', CAST(0x0000A591015C7F6E AS DateTime))
INSERT [dbo].[CG_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000054', N'001', N'CASH', N'CR', N'01180008', N'000031', N'REF455                                  ', CAST(0x0000A59100000000 AS DateTime), N'DSF                                                                                                 ', N'00', N'A00008', -250.0000, N'Cr', 250.0000, N'1    ', CAST(0x0000A591015D1691 AS DateTime), N'1    ', CAST(0x0000A591015D1691 AS DateTime), N'1    ', CAST(0x0000A591015D216D AS DateTime))
/****** Object:  Table [dbo].[CG_Ledger]    Script Date: 01/24/2016 13:52:52 ******/
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
	[Lgr_Vch_No] [char](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000042', CAST(0x0000A58D00000000 AS DateTime), N'CASH', N'CR', N'01140001', CAST(0x0000A58D00000000 AS DateTime), N'000019', N'000', N'SNEHAL                                                                                              ', N'      ', CAST(0x0000000000000000 AS DateTime), N'REF-CASH1                               ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00004', 2000.0000, N'Dr', 2000.0000, N'1    ', CAST(0x0000A58D014D8F23 AS DateTime), N'1    ', CAST(0x0000A58D014D8F23 AS DateTime), N'1    ', CAST(0x0000A58D014D8F23 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000042', CAST(0x0000A58D00000000 AS DateTime), N'CASH', N'CR', N'01140001', CAST(0x0000A58D00000000 AS DateTime), N'000019', N'001', N'tution fee                                                                                          ', NULL, NULL, N'REF-CASH1                               ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00002', -1000.0000, N'Cr', 1000.0000, N'1    ', CAST(0x0000A58D014D9093 AS DateTime), N'1    ', CAST(0x0000A58D014D9093 AS DateTime), N'1    ', CAST(0x0000A58D014D9093 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000042', CAST(0x0000A58D00000000 AS DateTime), N'CASH', N'CR', N'01140001', CAST(0x0000A58D00000000 AS DateTime), N'000019', N'002', N'library                                                                                             ', NULL, NULL, N'REF-CASH1                               ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00003', -1000.0000, N'Cr', 1000.0000, N'1    ', CAST(0x0000A58D014D9093 AS DateTime), N'1    ', CAST(0x0000A58D014D9093 AS DateTime), N'1    ', CAST(0x0000A58D014D9093 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000042', CAST(0x0000A58D00000000 AS DateTime), N'CASH', N'CR', N'01140001', CAST(0x0000A58D00000000 AS DateTime), N'000019', N'003', N'to give                                                                                             ', NULL, NULL, N'REF-CASH1                               ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00001', 500.0000, N'Dr', 500.0000, N'1    ', CAST(0x0000A58D014D9093 AS DateTime), N'1    ', CAST(0x0000A58D014D9093 AS DateTime), N'1    ', CAST(0x0000A58D014D9093 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000042', CAST(0x0000A58D00000000 AS DateTime), N'CASH', N'CR', N'01140001', CAST(0x0000A58D00000000 AS DateTime), N'000019', N'004', N'suffice                                                                                             ', NULL, NULL, N'REF-CASH1                               ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00002', -500.0000, N'Cr', 500.0000, N'1    ', CAST(0x0000A58D014D9093 AS DateTime), N'1    ', CAST(0x0000A58D014D9093 AS DateTime), N'1    ', CAST(0x0000A58D014D9093 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000043', CAST(0x0000A58D00000000 AS DateTime), N'CASH', N'CP', N'01140002', CAST(0x0000A58D00000000 AS DateTime), N'000020', N'000', N'CHAHAWALA                                                                                           ', N'      ', CAST(0x0000000000000000 AS DateTime), N'REF-CP                                  ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00004', -500.0000, N'Cr', 500.0000, N'1    ', CAST(0x0000A58D014EBD82 AS DateTime), N'1    ', CAST(0x0000A58D014EBD82 AS DateTime), N'1    ', CAST(0x0000A58D014EBD82 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000043', CAST(0x0000A58D00000000 AS DateTime), N'CASH', N'CP', N'01140002', CAST(0x0000A58D00000000 AS DateTime), N'000020', N'001', N'chahapatti                                                                                          ', NULL, NULL, N'REF-CP                                  ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00002', 200.0000, N'Dr', 200.0000, N'1    ', CAST(0x0000A58D014EBD95 AS DateTime), N'1    ', CAST(0x0000A58D014EBD95 AS DateTime), N'1    ', CAST(0x0000A58D014EBD95 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000043', CAST(0x0000A58D00000000 AS DateTime), N'CASH', N'CP', N'01140002', CAST(0x0000A58D00000000 AS DateTime), N'000020', N'002', N'milk                                                                                                ', NULL, NULL, N'REF-CP                                  ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00001', 300.0000, N'Dr', 300.0000, N'1    ', CAST(0x0000A58D014EBD95 AS DateTime), N'1    ', CAST(0x0000A58D014EBD95 AS DateTime), N'1    ', CAST(0x0000A58D014EBD95 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000044', CAST(0x0000A58D00000000 AS DateTime), N'BANK', N'BR', N'01140001', CAST(0x0000A58D00000000 AS DateTime), N'000021', N'000', N'SUSHIL                                                                                              ', N'120099', CAST(0x0000A58D00000000 AS DateTime), N'RES-BANK                                ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00005', 3000.0000, N'Dr', 3000.0000, N'1    ', CAST(0x0000A58D014FB4C7 AS DateTime), N'1    ', CAST(0x0000A58D014FB4C7 AS DateTime), N'1    ', CAST(0x0000A58D014FB4C7 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000044', CAST(0x0000A58D00000000 AS DateTime), N'BANK', N'BR', N'01140001', CAST(0x0000A58D00000000 AS DateTime), N'000021', N'001', N'bank details                                                                                        ', NULL, NULL, N'RES-BANK                                ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00002', -3000.0000, N'Cr', 3000.0000, N'1    ', CAST(0x0000A58D014FB4CF AS DateTime), N'1    ', CAST(0x0000A58D014FB4CF AS DateTime), N'1    ', CAST(0x0000A58D014FB4CF AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000045', CAST(0x0000A58D00000000 AS DateTime), N'BANK', N'BP', N'01140002', CAST(0x0000A58D00000000 AS DateTime), N'000022', N'000', N'SWEEPER                                                                                             ', N'987867', CAST(0x0000A58D00000000 AS DateTime), N'REF BANK                                ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00005', -1000.0000, N'Cr', 1000.0000, N'1    ', CAST(0x0000A58D0150265E AS DateTime), N'1    ', CAST(0x0000A58D0150265E AS DateTime), N'1    ', CAST(0x0000A58D0150265E AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000045', CAST(0x0000A58D00000000 AS DateTime), N'BANK', N'BP', N'01140002', CAST(0x0000A58D00000000 AS DateTime), N'000022', N'001', N'vd1                                                                                                 ', NULL, NULL, N'REF BANK                                ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00002', 200.0000, N'Dr', 200.0000, N'1    ', CAST(0x0000A58D01502665 AS DateTime), N'1    ', CAST(0x0000A58D01502665 AS DateTime), N'1    ', CAST(0x0000A58D01502665 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000045', CAST(0x0000A58D00000000 AS DateTime), N'BANK', N'BP', N'01140002', CAST(0x0000A58D00000000 AS DateTime), N'000022', N'002', N'vd2                                                                                                 ', NULL, NULL, N'REF BANK                                ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00003', 900.0000, N'Dr', 900.0000, N'1    ', CAST(0x0000A58D01502665 AS DateTime), N'1    ', CAST(0x0000A58D01502665 AS DateTime), N'1    ', CAST(0x0000A58D01502665 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000045', CAST(0x0000A58D00000000 AS DateTime), N'BANK', N'BP', N'01140002', CAST(0x0000A58D00000000 AS DateTime), N'000022', N'003', N'vd3                                                                                                 ', NULL, NULL, N'REF BANK                                ', CAST(0x0000A58D00000000 AS DateTime), NULL, N'A00002', -100.0000, N'Cr', 100.0000, N'1    ', CAST(0x0000A58D01502665 AS DateTime), N'1    ', CAST(0x0000A58D01502665 AS DateTime), N'1    ', CAST(0x0000A58D01502665 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000046', CAST(0x0000A58E00000000 AS DateTime), N'CASH', N'CR', N'01150003', CAST(0x0000A58E00000000 AS DateTime), N'000023', N'000', N'15JAN                                                                                               ', N'      ', CAST(0x0000000000000000 AS DateTime), N'REF15                                   ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00004', 200.0000, N'Dr', 200.0000, N'1    ', CAST(0x0000A58E013F2605 AS DateTime), N'1    ', CAST(0x0000A58E013F2605 AS DateTime), N'1    ', CAST(0x0000A58E013F2605 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000046', CAST(0x0000A58E00000000 AS DateTime), N'CASH', N'CR', N'01150003', CAST(0x0000A58E00000000 AS DateTime), N'000023', N'001', N'200 ale                                                                                             ', NULL, NULL, N'REF15                                   ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00002', -200.0000, N'Cr', 200.0000, N'1    ', CAST(0x0000A58E013F2787 AS DateTime), N'1    ', CAST(0x0000A58E013F2787 AS DateTime), N'1    ', CAST(0x0000A58E013F2787 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000047', CAST(0x0000A58E00000000 AS DateTime), N'BANK', N'BP', N'01150003', CAST(0x0000A58E00000000 AS DateTime), N'000024', N'000', N'CHECK TEST                                                                                          ', N'898989', CAST(0x0000A58E00000000 AS DateTime), N'BANKPAY                                 ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00005', -300.0000, N'Cr', 300.0000, N'1    ', CAST(0x0000A58E0145867A AS DateTime), N'1    ', CAST(0x0000A58E0145867A AS DateTime), N'1    ', CAST(0x0000A58E0145867A AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000047', CAST(0x0000A58E00000000 AS DateTime), N'BANK', N'BP', N'01150003', CAST(0x0000A58E00000000 AS DateTime), N'000024', N'001', N'kdjsf uefkjsdf jhsgd fjsd hfsdg hjgfsdj gdfkh gdfskh ghfdg                                          ', NULL, NULL, N'BANKPAY                                 ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00006', 100.0000, N'Dr', 100.0000, N'1    ', CAST(0x0000A58E01458688 AS DateTime), N'1    ', CAST(0x0000A58E01458688 AS DateTime), N'1    ', CAST(0x0000A58E01458688 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000047', CAST(0x0000A58E00000000 AS DateTime), N'BANK', N'BP', N'01150003', CAST(0x0000A58E00000000 AS DateTime), N'000024', N'002', N'slkh jsdgkj dfkgh dkj fhgkdhgkd                                                                     ', NULL, NULL, N'BANKPAY                                 ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00003', 200.0000, N'Dr', 200.0000, N'1    ', CAST(0x0000A58E01458688 AS DateTime), N'1    ', CAST(0x0000A58E01458688 AS DateTime), N'1    ', CAST(0x0000A58E01458688 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000048', CAST(0x0000A58E00000000 AS DateTime), N'CASH', N'CP', N'01150004', CAST(0x0000A58E00000000 AS DateTime), N'000025', N'000', N'PAYMENTVH                                                                                           ', N'      ', CAST(0x0000000000000000 AS DateTime), N'REFPAY                                  ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00004', -100.0000, N'Cr', 100.0000, N'1    ', CAST(0x0000A58E015B9025 AS DateTime), N'1    ', CAST(0x0000A58E015B9025 AS DateTime), N'1    ', CAST(0x0000A58E015B9025 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000051', CAST(0x0000A59000000000 AS DateTime), N'CASH', N'CR', N'01170005', CAST(0x0000A59000000000 AS DateTime), N'000028', N'000', N'CHAUDHARI                                                                                           ', N'      ', CAST(0x0000000000000000 AS DateTime), N'REF2344                                 ', CAST(0x0000A59000000000 AS DateTime), NULL, N'A00004', 200.0000, N'Dr', 200.0000, N'1    ', CAST(0x0000A59000FD5E5E AS DateTime), N'1    ', CAST(0x0000A59000FD5E5E AS DateTime), N'1    ', CAST(0x0000A59000FD5E5E AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000051', CAST(0x0000A59000000000 AS DateTime), N'CASH', N'CR', N'01170005', CAST(0x0000A59000000000 AS DateTime), N'000028', N'001', N'sne                                                                                                 ', NULL, NULL, N'REF2344                                 ', CAST(0x0000A59000000000 AS DateTime), NULL, N'A00001', -100.0000, N'Cr', 100.0000, N'11111', CAST(0x0000A59000FD6136 AS DateTime), N'11111', CAST(0x0000A59000FD6136 AS DateTime), N'11111', CAST(0x0000A59000FD6136 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000051', CAST(0x0000A59000000000 AS DateTime), N'CASH', N'CR', N'01170005', CAST(0x0000A59000000000 AS DateTime), N'000028', N'002', N'sne                                                                                                 ', NULL, NULL, N'REF2344                                 ', CAST(0x0000A59000000000 AS DateTime), NULL, N'A00001', -100.0000, N'Cr', 100.0000, N'11111', CAST(0x0000A59000FD6136 AS DateTime), N'11111', CAST(0x0000A59000FD6136 AS DateTime), N'11111', CAST(0x0000A59000FD6136 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000052', CAST(0x0000A59000000000 AS DateTime), N'CASH', N'CR', N'01170006', CAST(0x0000A59000000000 AS DateTime), N'000029', N'000', N'99999                                                                                               ', N'      ', CAST(0x0000000000000000 AS DateTime), N'5666                                    ', CAST(0x0000A59000000000 AS DateTime), NULL, N'A00004', 300.0000, N'Dr', 300.0000, N'1    ', CAST(0x0000A5900136323F AS DateTime), N'1    ', CAST(0x0000A5900136323F AS DateTime), N'1    ', CAST(0x0000A5900136323F AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000052', CAST(0x0000A59000000000 AS DateTime), N'CASH', N'CR', N'01170006', CAST(0x0000A59000000000 AS DateTime), N'000029', N'001', N'seq test                                                                                            ', NULL, NULL, N'5666                                    ', CAST(0x0000A59000000000 AS DateTime), NULL, N'A00002', -200.0000, N'Cr', 200.0000, N'11111', CAST(0x0000A5900136325D AS DateTime), N'11111', CAST(0x0000A5900136325D AS DateTime), N'11111', CAST(0x0000A5900136325D AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000052', CAST(0x0000A59000000000 AS DateTime), N'CASH', N'CR', N'01170006', CAST(0x0000A59000000000 AS DateTime), N'000029', N'002', N'test1                                                                                               ', NULL, NULL, N'5666                                    ', CAST(0x0000A59000000000 AS DateTime), NULL, N'A00003', -100.0000, N'Cr', 100.0000, N'11111', CAST(0x0000A5900136325D AS DateTime), N'11111', CAST(0x0000A5900136325D AS DateTime), N'11111', CAST(0x0000A5900136325D AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000048', CAST(0x0000A58E00000000 AS DateTime), N'CASH', N'CP', N'01150004', CAST(0x0000A58E00000000 AS DateTime), N'000025', N'001', N'gelele                                                                                              ', NULL, NULL, N'REFPAY                                  ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00003', 100.0000, N'Dr', 100.0000, N'1    ', CAST(0x0000A58E015B908E AS DateTime), N'1    ', CAST(0x0000A58E015B908E AS DateTime), N'1    ', CAST(0x0000A58E015B908E AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000053', CAST(0x0000A59100000000 AS DateTime), N'CASH', N'CR', N'01180007', CAST(0x0000A59100000000 AS DateTime), N'000030', N'000', N'SDFDS                                                                                               ', N'      ', CAST(0x0000000000000000 AS DateTime), N'DSFGD                                   ', CAST(0x0000A59100000000 AS DateTime), NULL, N'A00004', 800.0000, N'Dr', 800.0000, N'1    ', CAST(0x0000A591015C7F7E AS DateTime), N'1    ', CAST(0x0000A591015C7F7E AS DateTime), N'1    ', CAST(0x0000A591015C7F7E AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000053', CAST(0x0000A59100000000 AS DateTime), N'CASH', N'CR', N'01180007', CAST(0x0000A59100000000 AS DateTime), N'000030', N'001', N'DRGD                                                                                                ', NULL, NULL, N'DSFGD                                   ', CAST(0x0000A59100000000 AS DateTime), NULL, N'A00003', -800.0000, N'Cr', 800.0000, N'1    ', CAST(0x0000A591015C8173 AS DateTime), N'1    ', CAST(0x0000A591015C8173 AS DateTime), N'1    ', CAST(0x0000A591015C8173 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000054', CAST(0x0000A59100000000 AS DateTime), N'CASH', N'CR', N'01180008', CAST(0x0000A59100000000 AS DateTime), N'000031', N'000', N'JSHDF                                                                                               ', N'      ', CAST(0x0000000000000000 AS DateTime), N'REF455                                  ', CAST(0x0000A59100000000 AS DateTime), NULL, N'A00004', 250.0000, N'Dr', 250.0000, N'1    ', CAST(0x0000A591015D2171 AS DateTime), N'1    ', CAST(0x0000A591015D2171 AS DateTime), N'1    ', CAST(0x0000A591015D2171 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000054', CAST(0x0000A59100000000 AS DateTime), N'CASH', N'CR', N'01180008', CAST(0x0000A59100000000 AS DateTime), N'000031', N'001', N'DSF                                                                                                 ', NULL, NULL, N'REF455                                  ', CAST(0x0000A59100000000 AS DateTime), NULL, N'A00008', -250.0000, N'Cr', 250.0000, N'1    ', CAST(0x0000A591015D217F AS DateTime), N'1    ', CAST(0x0000A591015D217F AS DateTime), N'1    ', CAST(0x0000A591015D217F AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000049', CAST(0x0000A58E00000000 AS DateTime), N'BANK', N'BP', N'01150004', CAST(0x0000A58E00000000 AS DateTime), N'000026', N'000', N'PANKAJ                                                                                              ', N'12345 ', CAST(0x0000A58E00000000 AS DateTime), N'REF0008                                 ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00005', -300.0000, N'Cr', 300.0000, N'1    ', CAST(0x0000A58E015F0A8F AS DateTime), N'1    ', CAST(0x0000A58E015F0A8F AS DateTime), N'1    ', CAST(0x0000A58E015F0A8F AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000049', CAST(0x0000A58E00000000 AS DateTime), N'BANK', N'BP', N'01150004', CAST(0x0000A58E00000000 AS DateTime), N'000026', N'001', N'VD1 Value 2                                                                                         ', NULL, NULL, N'REF0008                                 ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00002', 200.0000, N'Dr', 200.0000, N'1    ', CAST(0x0000A58E015F0AF3 AS DateTime), N'1    ', CAST(0x0000A58E015F0AF3 AS DateTime), N'1    ', CAST(0x0000A58E015F0AF3 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000049', CAST(0x0000A58E00000000 AS DateTime), N'BANK', N'BP', N'01150004', CAST(0x0000A58E00000000 AS DateTime), N'000026', N'002', N'VD2 Value                                                                                           ', NULL, NULL, N'REF0008                                 ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00006', 100.0000, N'Dr', 100.0000, N'1    ', CAST(0x0000A58E015F0AF3 AS DateTime), N'1    ', CAST(0x0000A58E015F0AF3 AS DateTime), N'1    ', CAST(0x0000A58E015F0AF3 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000050', CAST(0x0000A58E00000000 AS DateTime), N'BANK', N'BR', N'01150005', CAST(0x0000A58E00000000 AS DateTime), N'000027', N'000', N'BOOK DEPOT                                                                                          ', N'987655', CAST(0x0000A58E00000000 AS DateTime), N'REF0006                                 ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00005', 500.0000, N'Dr', 500.0000, N'1    ', CAST(0x0000A58E015FAE32 AS DateTime), N'1    ', CAST(0x0000A58E015FAE32 AS DateTime), N'1    ', CAST(0x0000A58E015FAE32 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000050', CAST(0x0000A58E00000000 AS DateTime), N'BANK', N'BR', N'01150005', CAST(0x0000A58E00000000 AS DateTime), N'000027', N'001', N'BD1                                                                                                 ', NULL, NULL, N'REF0006                                 ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00006', -200.0000, N'Cr', 200.0000, N'1    ', CAST(0x0000A58E015FAE62 AS DateTime), N'1    ', CAST(0x0000A58E015FAE62 AS DateTime), N'1    ', CAST(0x0000A58E015FAE62 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000050', CAST(0x0000A58E00000000 AS DateTime), N'BANK', N'BR', N'01150005', CAST(0x0000A58E00000000 AS DateTime), N'000027', N'002', N'BD2                                                                                                 ', NULL, NULL, N'REF0006                                 ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00003', -400.0000, N'Cr', 400.0000, N'1    ', CAST(0x0000A58E015FAE62 AS DateTime), N'1    ', CAST(0x0000A58E015FAE62 AS DateTime), N'1    ', CAST(0x0000A58E015FAE62 AS DateTime))
INSERT [dbo].[CG_Ledger] ([Lgr_Fin_Yr], [Lgr_Inst_Cd], [Lgr_Inst_Typ], [Lgr_Brn_Cd], [Lgr_Lnk_No], [Lgr_Lnk_Dt], [Lgr_Dbk_Cd], [Lgr_Trn_Typ], [Lgr_Vch_No], [Lgr_Vch_Dt], [Lgr_Vch_Ref_No], [Lgr_Seq_No], [Lgr_Narr], [Lgr_Chq_No], [Lgr_Chq_Dt], [Lgr_Ref_No], [Lgr_Ref_Dt], [Lgr_Lgr_Cd], [Lgr_Acc_Cd], [Lgr_Amt], [Lgr_Cr_Dr], [Lgr_ABS_Amt], [Lgr_Ent_By], [Lgr_Ent_Dt], [Lgr_Upd_By], [Lgr_Upd_Dt], [Lgr_Conf_By], [Lgr_Conf_Dt]) VALUES (N'2015', N'100  ', N'CG', N'HO ', N'000000000050', CAST(0x0000A58E00000000 AS DateTime), N'BANK', N'BR', N'01150005', CAST(0x0000A58E00000000 AS DateTime), N'000027', N'003', N'DR type val                                                                                         ', NULL, NULL, N'REF0006                                 ', CAST(0x0000A58E00000000 AS DateTime), NULL, N'A00002', 100.0000, N'Dr', 100.0000, N'1    ', CAST(0x0000A58E015FAE62 AS DateTime), N'1    ', CAST(0x0000A58E015FAE62 AS DateTime), N'1    ', CAST(0x0000A58E015FAE62 AS DateTime))
/****** Object:  Table [dbo].[CG_Daybooks]    Script Date: 01/24/2016 13:52:52 ******/
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
INSERT [dbo].[CG_Daybooks] ([DM_Fin_Yr], [DM_Inst_Cd], [DM_Inst_Typ], [DM_Brn_Cd], [DM_Dbk_Cd], [DM_Dbk_Nm], [DM_Dbk_Typ], [DM_Acc_Cd], [DM_Bnk_Nm], [DM_Bnk_Brn], [DM_Bnk_AcNo], [DM_Bnk_OD], [DM_Vch_04], [DM_Lst_04], [DM_Vch_05], [DM_Lst_05], [DM_Vch_06], [DM_Lst_06], [DM_Vch_07], [DM_Lst_07], [DM_Vch_08], [DM_Lst_08], [DM_Vch_09], [DM_Lst_09], [DM_Vch_10], [DM_Lst_10], [DM_Vch_11], [DM_Lst_11], [DM_Vch_12], [DM_Lst_12], [DM_Vch_01], [DM_Lst_01], [DM_Vch_02], [DM_Lst_02], [DM_Vch_03], [DM_Lst_03], [DM_Ent_By], [DM_Ent_Dt], [DM_Upd_By], [DM_Upd_Dt]) VALUES (N'    ', N'     ', N'  ', N'   ', N'    ', N'                                                  ', N' ', N'      ', N'                                                  ', N'                              ', N'                ', 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A5920179205B AS DateTime), NULL, NULL)
INSERT [dbo].[CG_Daybooks] ([DM_Fin_Yr], [DM_Inst_Cd], [DM_Inst_Typ], [DM_Brn_Cd], [DM_Dbk_Cd], [DM_Dbk_Nm], [DM_Dbk_Typ], [DM_Acc_Cd], [DM_Bnk_Nm], [DM_Bnk_Brn], [DM_Bnk_AcNo], [DM_Bnk_OD], [DM_Vch_04], [DM_Lst_04], [DM_Vch_05], [DM_Lst_05], [DM_Vch_06], [DM_Lst_06], [DM_Vch_07], [DM_Lst_07], [DM_Vch_08], [DM_Lst_08], [DM_Vch_09], [DM_Lst_09], [DM_Vch_10], [DM_Lst_10], [DM_Vch_11], [DM_Lst_11], [DM_Vch_12], [DM_Lst_12], [DM_Vch_01], [DM_Lst_01], [DM_Vch_02], [DM_Lst_02], [DM_Vch_03], [DM_Lst_03], [DM_Ent_By], [DM_Ent_Dt], [DM_Upd_By], [DM_Upd_Dt]) VALUES (N'2015', N'100  ', N'CG', N'01 ', N'BANK', N'BANK DAYBOOK                                      ', N'B', N'A00005', N'SBI BANK                                          ', N'KATRAJ                        ', N'11111111        ', 1.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1    ', CAST(0x0000A58D014AC869 AS DateTime), NULL, NULL)
INSERT [dbo].[CG_Daybooks] ([DM_Fin_Yr], [DM_Inst_Cd], [DM_Inst_Typ], [DM_Brn_Cd], [DM_Dbk_Cd], [DM_Dbk_Nm], [DM_Dbk_Typ], [DM_Acc_Cd], [DM_Bnk_Nm], [DM_Bnk_Brn], [DM_Bnk_AcNo], [DM_Bnk_OD], [DM_Vch_04], [DM_Lst_04], [DM_Vch_05], [DM_Lst_05], [DM_Vch_06], [DM_Lst_06], [DM_Vch_07], [DM_Lst_07], [DM_Vch_08], [DM_Lst_08], [DM_Vch_09], [DM_Lst_09], [DM_Vch_10], [DM_Lst_10], [DM_Vch_11], [DM_Lst_11], [DM_Vch_12], [DM_Lst_12], [DM_Vch_01], [DM_Lst_01], [DM_Vch_02], [DM_Lst_02], [DM_Vch_03], [DM_Lst_03], [DM_Ent_By], [DM_Ent_Dt], [DM_Upd_By], [DM_Upd_Dt]) VALUES (N'2015', N'100  ', N'CG', N'01 ', N'CASH', N'CASH DAYBOOK                                      ', N'C', N'A00004', NULL, NULL, NULL, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1    ', CAST(0x0000A58D014A9CC7 AS DateTime), NULL, NULL)
/****** Object:  Table [dbo].[CG_Accounts]    Script Date: 01/24/2016 13:52:51 ******/
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
INSERT [dbo].[CG_Accounts] ([AM_Fin_Yr], [AM_Inst_Cd], [AM_Inst_Typ], [AM_Brn_Cd], [AM_Lgr_Cd], [AM_Acc_Cd], [AM_Acc_Nm], [AM_Calls], [AM_Opn_Bal], [AM_OB_Cr_Dr], [AM_ABS_Opn_Bal], [AM_Net_04], [AM_Net_05], [AM_Net_06], [AM_Net_07], [AM_Net_08], [AM_Net_09], [AM_Net_10], [AM_Net_11], [AM_Net_12], [AM_Net_01], [AM_Net_02], [AM_Net_03], [AM_LLY_Budg], [AM_LLY_Actu], [AM_LYr_Budg], [AM_LYr_Actu], [AM_Cyr_Budg], [AM_Ent_By], [AM_Ent_Dt], [AM_Upd_By], [AM_Upd_Dt]) VALUES (N'2015', N'100  ', N'CG', N'01 ', N'00', N'A00001', N'CREDIT ACCOUNT 1                                  ', NULL, 0.0000, N'CR', 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 700.0000, NULL, NULL, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, N'1    ', CAST(0x0000A58D01490924 AS DateTime), NULL, NULL)
INSERT [dbo].[CG_Accounts] ([AM_Fin_Yr], [AM_Inst_Cd], [AM_Inst_Typ], [AM_Brn_Cd], [AM_Lgr_Cd], [AM_Acc_Cd], [AM_Acc_Nm], [AM_Calls], [AM_Opn_Bal], [AM_OB_Cr_Dr], [AM_ABS_Opn_Bal], [AM_Net_04], [AM_Net_05], [AM_Net_06], [AM_Net_07], [AM_Net_08], [AM_Net_09], [AM_Net_10], [AM_Net_11], [AM_Net_12], [AM_Net_01], [AM_Net_02], [AM_Net_03], [AM_LLY_Budg], [AM_LLY_Actu], [AM_LYr_Budg], [AM_LYr_Actu], [AM_Cyr_Budg], [AM_Ent_By], [AM_Ent_Dt], [AM_Upd_By], [AM_Upd_Dt]) VALUES (N'2015', N'100  ', N'CG', N'01 ', N'00', N'A00002', N'CREDIT ACCOUNT 2-LINKING                          ', NULL, 0.0000, N'CR', 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -3500.0000, NULL, NULL, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, N'1    ', CAST(0x0000A58D0149220F AS DateTime), NULL, NULL)
INSERT [dbo].[CG_Accounts] ([AM_Fin_Yr], [AM_Inst_Cd], [AM_Inst_Typ], [AM_Brn_Cd], [AM_Lgr_Cd], [AM_Acc_Cd], [AM_Acc_Nm], [AM_Calls], [AM_Opn_Bal], [AM_OB_Cr_Dr], [AM_ABS_Opn_Bal], [AM_Net_04], [AM_Net_05], [AM_Net_06], [AM_Net_07], [AM_Net_08], [AM_Net_09], [AM_Net_10], [AM_Net_11], [AM_Net_12], [AM_Net_01], [AM_Net_02], [AM_Net_03], [AM_LLY_Budg], [AM_LLY_Actu], [AM_LYr_Budg], [AM_LYr_Actu], [AM_Cyr_Budg], [AM_Ent_By], [AM_Ent_Dt], [AM_Upd_By], [AM_Upd_Dt]) VALUES (N'2015', N'100  ', N'CG', N'01 ', N'00', N'A00003', N'DEBIT ACOUNT 1                                    ', NULL, 0.0000, N'DR', 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -1100.0000, NULL, NULL, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, N'1    ', CAST(0x0000A58D014939AC AS DateTime), NULL, NULL)
INSERT [dbo].[CG_Accounts] ([AM_Fin_Yr], [AM_Inst_Cd], [AM_Inst_Typ], [AM_Brn_Cd], [AM_Lgr_Cd], [AM_Acc_Cd], [AM_Acc_Nm], [AM_Calls], [AM_Opn_Bal], [AM_OB_Cr_Dr], [AM_ABS_Opn_Bal], [AM_Net_04], [AM_Net_05], [AM_Net_06], [AM_Net_07], [AM_Net_08], [AM_Net_09], [AM_Net_10], [AM_Net_11], [AM_Net_12], [AM_Net_01], [AM_Net_02], [AM_Net_03], [AM_LLY_Budg], [AM_LLY_Actu], [AM_LYr_Budg], [AM_LYr_Actu], [AM_Cyr_Budg], [AM_Ent_By], [AM_Ent_Dt], [AM_Upd_By], [AM_Upd_Dt]) VALUES (N'2015', N'100  ', N'CG', N'01 ', N'00', N'A00004', N'DEBIT ACOUNT 2 -LINKING                           ', N'CASH', 0.0000, N'DR', 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3150.0000, NULL, NULL, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, N'1    ', CAST(0x0000A58D01494DFB AS DateTime), NULL, NULL)
INSERT [dbo].[CG_Accounts] ([AM_Fin_Yr], [AM_Inst_Cd], [AM_Inst_Typ], [AM_Brn_Cd], [AM_Lgr_Cd], [AM_Acc_Cd], [AM_Acc_Nm], [AM_Calls], [AM_Opn_Bal], [AM_OB_Cr_Dr], [AM_ABS_Opn_Bal], [AM_Net_04], [AM_Net_05], [AM_Net_06], [AM_Net_07], [AM_Net_08], [AM_Net_09], [AM_Net_10], [AM_Net_11], [AM_Net_12], [AM_Net_01], [AM_Net_02], [AM_Net_03], [AM_LLY_Budg], [AM_LLY_Actu], [AM_LYr_Budg], [AM_LYr_Actu], [AM_Cyr_Budg], [AM_Ent_By], [AM_Ent_Dt], [AM_Upd_By], [AM_Upd_Dt]) VALUES (N'2015', N'100  ', N'CG', N'01 ', N'00', N'A00005', N'DEBIT ACCOUNT -BANK                               ', N'BANK', 0.0000, N'DR', 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1900.0000, NULL, NULL, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, N'1    ', CAST(0x0000A58D0149B597 AS DateTime), NULL, NULL)
INSERT [dbo].[CG_Accounts] ([AM_Fin_Yr], [AM_Inst_Cd], [AM_Inst_Typ], [AM_Brn_Cd], [AM_Lgr_Cd], [AM_Acc_Cd], [AM_Acc_Nm], [AM_Calls], [AM_Opn_Bal], [AM_OB_Cr_Dr], [AM_ABS_Opn_Bal], [AM_Net_04], [AM_Net_05], [AM_Net_06], [AM_Net_07], [AM_Net_08], [AM_Net_09], [AM_Net_10], [AM_Net_11], [AM_Net_12], [AM_Net_01], [AM_Net_02], [AM_Net_03], [AM_LLY_Budg], [AM_LLY_Actu], [AM_LYr_Budg], [AM_LYr_Actu], [AM_Cyr_Budg], [AM_Ent_By], [AM_Ent_Dt], [AM_Upd_By], [AM_Upd_Dt]) VALUES (N'2015', N'100  ', N'CG', N'01 ', N'00', N'A00006', N'OPENING BALANCE VERIFICATION                      ', NULL, -20000.0000, N'CR', 20000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0.0000, NULL, NULL, 20.0000, 20.0000, 20.0000, 20.0000, 20.0000, N'1    ', CAST(0x0000A58C00006CFC AS DateTime), NULL, NULL)
INSERT [dbo].[CG_Accounts] ([AM_Fin_Yr], [AM_Inst_Cd], [AM_Inst_Typ], [AM_Brn_Cd], [AM_Lgr_Cd], [AM_Acc_Cd], [AM_Acc_Nm], [AM_Calls], [AM_Opn_Bal], [AM_OB_Cr_Dr], [AM_ABS_Opn_Bal], [AM_Net_04], [AM_Net_05], [AM_Net_06], [AM_Net_07], [AM_Net_08], [AM_Net_09], [AM_Net_10], [AM_Net_11], [AM_Net_12], [AM_Net_01], [AM_Net_02], [AM_Net_03], [AM_LLY_Budg], [AM_LLY_Actu], [AM_LYr_Budg], [AM_LYr_Actu], [AM_Cyr_Budg], [AM_Ent_By], [AM_Ent_Dt], [AM_Upd_By], [AM_Upd_Dt]) VALUES (N'2015', N'100  ', N'CG', N'01 ', N'00', N'A00007', N'ACCOUNT7                                          ', NULL, 0.0000, N'DR', 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, N'1    ', CAST(0x0000A591015BC6C8 AS DateTime), NULL, NULL)
INSERT [dbo].[CG_Accounts] ([AM_Fin_Yr], [AM_Inst_Cd], [AM_Inst_Typ], [AM_Brn_Cd], [AM_Lgr_Cd], [AM_Acc_Cd], [AM_Acc_Nm], [AM_Calls], [AM_Opn_Bal], [AM_OB_Cr_Dr], [AM_ABS_Opn_Bal], [AM_Net_04], [AM_Net_05], [AM_Net_06], [AM_Net_07], [AM_Net_08], [AM_Net_09], [AM_Net_10], [AM_Net_11], [AM_Net_12], [AM_Net_01], [AM_Net_02], [AM_Net_03], [AM_LLY_Budg], [AM_LLY_Actu], [AM_LYr_Budg], [AM_LYr_Actu], [AM_Cyr_Budg], [AM_Ent_By], [AM_Ent_Dt], [AM_Upd_By], [AM_Upd_Dt]) VALUES (N'2015', N'100  ', N'CG', N'01 ', N'00', N'A00008', N'ACCOUNT8                                          ', NULL, 1234.0000, N'DR', 1234.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -250.0000, NULL, NULL, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, N'1    ', CAST(0x0000A591015BFD07 AS DateTime), NULL, NULL)
/****** Object:  StoredProcedure [dbo].[CalculateBalance]    Script Date: 01/24/2016 13:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CalculateBalance]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--exec dbo.CalculateBalance ''A01111'',''12-03-2015'',''CG''
CREATE Procedure [dbo].[CalculateBalance]
@lgrCode varchar(10),
@vchDate as datetime,
@instType as varchar(5)
As
Begin
--declare @lgrCode as varchar(10)
--declare @vchDate as datetime
--declare @instType as varchar(5)

--set @vchDate=''2014-06-05''
--set @lgrCode=''A011''
--set @instType=''CG''



declare @firstDate as datetime
set @firstDate=(SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@vchDate)-1),@vchDate),101))

declare @processingMonth as int
set @processingMonth=DATEPART(mm,@vchDate)

declare @totalBalance as money
declare @balanceAdd as money

declare @opnBalance as money
declare @opnQuery as nvarchar(max)

set @opnQuery=''select @obal=AM_Opn_Bal from ''+@instType+''_Accounts where AM_Acc_Cd=''''''+@lgrCode+''''''''

EXECUTE sp_executesql @opnQuery, N''@obal money OUTPUT'', @obal=@opnBalance OUTPUT                  

declare @monthAmt as money
declare @monthQuery as nvarchar(max)
set @monthQuery=''select @mthAmt=SUM(Lgr_Amt) from ''+@instType+''_Ledger where Lgr_Vch_Dt>=''''''+convert(varchar(50),@firstDate)+'''''' and Lgr_Vch_Dt<=''''''+convert(varchar(50),@vchDate)+''''''
                  and Lgr_Acc_Cd=''''''+@lgrCode+'''''''' 
                  
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
set @paddedString=right(''0''+ rtrim(convert(varchar(5),@startCount)), 2)

 set @strQuery=''select @bal=AM_Net_''+@paddedString+'' from ''+@instType+''_Accounts where AM_Acc_Cd=''''''+@lgrCode+''''''''
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
/****** Object:  UserDefinedFunction [dbo].[OpeningBalance]    Script Date: 01/24/2016 13:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OpeningBalance]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[OpeningBalance]
	(
	@lgrCode varchar(10),
@vchDate datetime,
@instType varchar(5)
	)
RETURNS money
AS
	BEGIN

declare @firstDate as datetime
set @firstDate=(SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@vchDate)-1),@vchDate),101))

declare @processingMonth as int
set @processingMonth=DATEPART(mm,@vchDate)

declare @totalBalance as money
declare @balanceAdd as money

declare @opnBalance as money
declare @opnQuery as nvarchar(max)

set @opnQuery=''select @obal=AM_Opn_Bal from ''+@instType+''_Accounts where AM_Acc_Cd=''''''+@lgrCode+''''''''

EXECUTE sp_executesql @opnQuery, N''@obal money OUTPUT'', @obal=@opnBalance OUTPUT                  

declare @monthAmt as money
declare @monthQuery as nvarchar(max)
set @monthQuery=''select @mthAmt=SUM(Lgr_Amt) from ''+@instType+''_Ledger where Lgr_Vch_Dt>=''''''+convert(varchar(50),@firstDate)+'''''' and Lgr_Vch_Dt<=''''''+convert(varchar(50),@vchDate)+''''''
                  and Lgr_Acc_Cd=''''''+@lgrCode+'''''''' 
                  
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
set @paddedString=right(''0''+ rtrim(convert(varchar(5),@startCount)), 2)

 set @strQuery=''select @bal=AM_Net_''+@paddedString+'' from ''+@instType+''_Accounts where AM_Acc_Cd=''''''+@lgrCode+''''''''
 EXECUTE sp_executesql @strQuery, N''@bal money OUTPUT'', @bal=@queryOut OUTPUT
 
 set @balanceAdd=isnull(@balanceAdd,0)+ @queryOut
 set @startCount=@startCount+1
End

--add current month amounts
set @balanceAdd=isnull(@balanceAdd,0)+isnull(@monthAmt,0) 

                 
--calculate total balance by adding all calculations to opening balance
set @totalBalance=ISNULL(@opnBalance,0)+isnull(@balanceAdd,0)
End

SET @totalBalance= ISNULL(@totalBalance,0)

	RETURN @totalBalance
	END
' 
END
GO
/****** Object:  Table [dbo].[JR_Voucher_Header]    Script Date: 01/24/2016 13:52:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JR_Voucher_Header]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[JR_Voucher_Header](
	[VH_Fin_Yr] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VH_Inst_Cd] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VH_Inst_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VH_Brn_Cd] [char](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VH_Lnk_No] [char](12) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VH_Lnk_Dt] [datetime] NULL,
	[VH_Pty_Nm] [char](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Dbk_Cd] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Trn_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VH_Vch_No] [char](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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
 CONSTRAINT [pk_voucherheader_JR] PRIMARY KEY CLUSTERED 
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
INSERT [dbo].[JR_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'101  ', N'JR', N'HO ', N'000000000059', CAST(0x0000A59000000000 AS DateTime), N'AAAAAAAAAAAAAAAAA                                                                                   ', N'LR02', N'CR', NULL, NULL, N'      ', CAST(0x0000000000000000 AS DateTime), NULL, N'RFEE1                                   ', CAST(0x0000A59000000000 AS DateTime), N'000036', N'00', N'L00003', 1000.0000, N'Dr', 1000.0000, N'2    ', CAST(0x0000A590016F80FA AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[JR_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'101  ', N'JR', N'HO ', N'000000000060', CAST(0x0000A59000000000 AS DateTime), N'BBBBBBB                                                                                             ', N'LR02', N'CP', NULL, NULL, N'      ', CAST(0x0000000000000000 AS DateTime), NULL, N'REFFFF                                  ', CAST(0x0000A59000000000 AS DateTime), N'000037', N'00', N'L00003', -800.0000, N'Cr', 800.0000, N'2    ', CAST(0x0000A59001700052 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[JR_Voucher_Header] ([VH_Fin_Yr], [VH_Inst_Cd], [VH_Inst_Typ], [VH_Brn_Cd], [VH_Lnk_No], [VH_Lnk_Dt], [VH_Pty_Nm], [VH_Dbk_Cd], [VH_Trn_Typ], [VH_Vch_No], [VH_Vch_Dt], [VH_Chq_No], [VH_Chq_Dt], [VH_Clr_Dt], [VH_Ref_No], [VH_Ref_Dt], [VH_Vch_Ref_No], [VH_Lgr_Cd], [VH_Acc_Cd], [VH_Amt], [VH_Cr_Dr], [VH_ABS_Amt], [VH_Ent_By], [VH_Ent_Dt], [VH_Upd_By], [VH_Upd_Dt], [VH_Conf_By], [VH_Conf_Dt]) VALUES (N'2015', N'101  ', N'JR', N'HO ', N'000000000061', CAST(0x0000A59200000000 AS DateTime), N'PANKAJ                                                                                              ', N'LR02', N'CR', NULL, NULL, N'      ', CAST(0x0000000000000000 AS DateTime), NULL, N'REF1                                    ', CAST(0x0000A59200000000 AS DateTime), N'000038', N'00', N'L00003', 1000.0000, N'Dr', 1000.0000, N'2    ', CAST(0x0000A592014CDFD1 AS DateTime), NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[JR_Voucher_Detail]    Script Date: 01/24/2016 13:52:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JR_Voucher_Detail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[JR_Voucher_Detail](
	[VD_Fin_Yr] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VD_Inst_Cd] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VD_Inst_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VD_Brn_Cd] [char](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VD_Lnk_No] [char](12) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VD_Seq_No] [char](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VD_Dbk_Cd] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_Trn_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VD_Vch_No] [char](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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
 CONSTRAINT [pk_voucherdetail_JR] PRIMARY KEY CLUSTERED 
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
INSERT [dbo].[JR_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'101  ', N'JR', N'HO ', N'000000000059', N'001', N'LR02', N'CR', NULL, N'000036', N'RFEE1                                   ', CAST(0x0000A59000000000 AS DateTime), N'A1 desc                                                                                             ', N'00', N'L00001', -500.0000, N'Cr', 500.0000, N'2    ', CAST(0x0000A590016F80E1 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[JR_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'101  ', N'JR', N'HO ', N'000000000059', N'002', N'LR02', N'CR', NULL, N'000036', N'RFEE1                                   ', CAST(0x0000A59000000000 AS DateTime), N'A2 desc                                                                                             ', N'00', N'L00001', -500.0000, N'Cr', 500.0000, N'2    ', CAST(0x0000A590016F80E6 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[JR_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'101  ', N'JR', N'HO ', N'000000000060', N'001', N'LR02', N'CP', NULL, N'000037', N'REFFFF                                  ', CAST(0x0000A59000000000 AS DateTime), N'B1 desc                                                                                             ', N'00', N'L00001', 400.0000, N'Dr', 400.0000, N'2    ', CAST(0x0000A59001700042 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[JR_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'101  ', N'JR', N'HO ', N'000000000060', N'002', N'LR02', N'CP', NULL, N'000037', N'REFFFF                                  ', CAST(0x0000A59000000000 AS DateTime), N'B2 desc                                                                                             ', N'00', N'L00001', 500.0000, N'Dr', 500.0000, N'2    ', CAST(0x0000A59001700045 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[JR_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'101  ', N'JR', N'HO ', N'000000000060', N'003', N'LR02', N'CP', NULL, N'000037', N'REFFFF                                  ', CAST(0x0000A59000000000 AS DateTime), N'B3 desc                                                                                             ', N'00', N'L00001', 100.0000, N'Dr', 100.0000, N'2    ', CAST(0x0000A59001700047 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[JR_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'101  ', N'JR', N'HO ', N'000000000061', N'001', N'LR02', N'CR', NULL, N'000038', N'REF1                                    ', CAST(0x0000A59200000000 AS DateTime), N'VD1                                                                                                 ', N'00', N'L00001', -500.0000, N'Cr', 500.0000, N'2    ', CAST(0x0000A592014D0555 AS DateTime), N'2    ', CAST(0x0000A592014D0555 AS DateTime), NULL, NULL)
INSERT [dbo].[JR_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'101  ', N'JR', N'HO ', N'000000000061', N'002', N'LR02', N'CR', NULL, N'000038', N'REF1                                    ', CAST(0x0000A59200000000 AS DateTime), N'VD2                                                                                                 ', N'00', N'L00001', 500.0000, N'Dr', 500.0000, N'2    ', CAST(0x0000A592014D1466 AS DateTime), N'2    ', CAST(0x0000A592014D1466 AS DateTime), NULL, NULL)
INSERT [dbo].[JR_Voucher_Detail] ([VD_Fin_Yr], [VD_Inst_Cd], [VD_Inst_Typ], [VD_Brn_Cd], [VD_Lnk_No], [VD_Seq_No], [VD_Dbk_Cd], [VD_Trn_Typ], [VD_Vch_No], [VD_Vch_Ref_No], [VD_Ref_No], [VD_Ref_Dt], [VD_Narr], [VD_Lgr_Cd], [VD_Acc_Cd], [VD_Amt], [VD_Cr_Dr], [VD_ABS_Amt], [VD_Ent_By], [VD_Ent_Dt], [VD_Upd_By], [VD_Upd_Dt], [VD_Conf_By], [VD_Conf_Dt]) VALUES (N'2015', N'101  ', N'JR', N'HO ', N'000000000061', N'003', N'LR02', N'CR', NULL, N'000038', N'REF1                                    ', CAST(0x0000A59200000000 AS DateTime), N'VD3                                                                                                 ', N'00', N'L00001', -1000.0000, N'Cr', 1000.0000, N'2    ', CAST(0x0000A592014D32B2 AS DateTime), N'2    ', CAST(0x0000A592014D32B2 AS DateTime), NULL, NULL)
/****** Object:  Table [dbo].[JR_Ledger]    Script Date: 01/24/2016 13:52:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JR_Ledger]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[JR_Ledger](
	[Lgr_Fin_Yr] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Inst_Cd] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Inst_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Brn_Cd] [char](3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Lnk_No] [char](12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Lnk_Dt] [datetime] NULL,
	[Lgr_Dbk_Cd] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Trn_Typ] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lgr_Vch_No] [char](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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
/****** Object:  Table [dbo].[JR_Daybooks]    Script Date: 01/24/2016 13:52:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JR_Daybooks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[JR_Daybooks](
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
 CONSTRAINT [pk_daybook_JR] PRIMARY KEY CLUSTERED 
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
INSERT [dbo].[JR_Daybooks] ([DM_Fin_Yr], [DM_Inst_Cd], [DM_Inst_Typ], [DM_Brn_Cd], [DM_Dbk_Cd], [DM_Dbk_Nm], [DM_Dbk_Typ], [DM_Acc_Cd], [DM_Bnk_Nm], [DM_Bnk_Brn], [DM_Bnk_AcNo], [DM_Bnk_OD], [DM_Vch_04], [DM_Lst_04], [DM_Vch_05], [DM_Lst_05], [DM_Vch_06], [DM_Lst_06], [DM_Vch_07], [DM_Lst_07], [DM_Vch_08], [DM_Lst_08], [DM_Vch_09], [DM_Lst_09], [DM_Vch_10], [DM_Lst_10], [DM_Vch_11], [DM_Lst_11], [DM_Vch_12], [DM_Lst_12], [DM_Vch_01], [DM_Lst_01], [DM_Vch_02], [DM_Lst_02], [DM_Vch_03], [DM_Lst_03], [DM_Ent_By], [DM_Ent_Dt], [DM_Upd_By], [DM_Upd_Dt]) VALUES (N'2015', N'101  ', N'JR', N'01 ', N'LR02', N'LRDAYBBOK_                                        ', N'C', N'L00003', NULL, NULL, NULL, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'2    ', CAST(0x0000A590016F3DCE AS DateTime), NULL, NULL)
INSERT [dbo].[JR_Daybooks] ([DM_Fin_Yr], [DM_Inst_Cd], [DM_Inst_Typ], [DM_Brn_Cd], [DM_Dbk_Cd], [DM_Dbk_Nm], [DM_Dbk_Typ], [DM_Acc_Cd], [DM_Bnk_Nm], [DM_Bnk_Brn], [DM_Bnk_AcNo], [DM_Bnk_OD], [DM_Vch_04], [DM_Lst_04], [DM_Vch_05], [DM_Lst_05], [DM_Vch_06], [DM_Lst_06], [DM_Vch_07], [DM_Lst_07], [DM_Vch_08], [DM_Lst_08], [DM_Vch_09], [DM_Lst_09], [DM_Vch_10], [DM_Lst_10], [DM_Vch_11], [DM_Lst_11], [DM_Vch_12], [DM_Lst_12], [DM_Vch_01], [DM_Lst_01], [DM_Vch_02], [DM_Lst_02], [DM_Vch_03], [DM_Lst_03], [DM_Ent_By], [DM_Ent_Dt], [DM_Upd_By], [DM_Upd_Dt]) VALUES (N'2015', N'101  ', N'JR', N'01 ', N'LRD1', N'LR_DAYBOOK1                                       ', N'B', N'L00002', N'HDFC                                              ', N'KATRAJ                        ', N'3444234         ', 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'2    ', CAST(0x0000A5900161766A AS DateTime), NULL, NULL)
/****** Object:  Table [dbo].[JR_Accounts]    Script Date: 01/24/2016 13:52:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JR_Accounts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[JR_Accounts](
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
 CONSTRAINT [pk_account_JR] PRIMARY KEY CLUSTERED 
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
INSERT [dbo].[JR_Accounts] ([AM_Fin_Yr], [AM_Inst_Cd], [AM_Inst_Typ], [AM_Brn_Cd], [AM_Lgr_Cd], [AM_Acc_Cd], [AM_Acc_Nm], [AM_Calls], [AM_Opn_Bal], [AM_OB_Cr_Dr], [AM_ABS_Opn_Bal], [AM_Net_04], [AM_Net_05], [AM_Net_06], [AM_Net_07], [AM_Net_08], [AM_Net_09], [AM_Net_10], [AM_Net_11], [AM_Net_12], [AM_Net_01], [AM_Net_02], [AM_Net_03], [AM_LLY_Budg], [AM_LLY_Actu], [AM_LYr_Budg], [AM_LYr_Actu], [AM_Cyr_Budg], [AM_Ent_By], [AM_Ent_Dt], [AM_Upd_By], [AM_Upd_Dt]) VALUES (N'2015', N'101  ', N'JR', N'01 ', N'00', N'L00001', N'LR_ACCOUNT_01                                     ', NULL, 0.0000, N'CR', 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, N'2    ', CAST(0x0000A590015FF873 AS DateTime), NULL, NULL)
INSERT [dbo].[JR_Accounts] ([AM_Fin_Yr], [AM_Inst_Cd], [AM_Inst_Typ], [AM_Brn_Cd], [AM_Lgr_Cd], [AM_Acc_Cd], [AM_Acc_Nm], [AM_Calls], [AM_Opn_Bal], [AM_OB_Cr_Dr], [AM_ABS_Opn_Bal], [AM_Net_04], [AM_Net_05], [AM_Net_06], [AM_Net_07], [AM_Net_08], [AM_Net_09], [AM_Net_10], [AM_Net_11], [AM_Net_12], [AM_Net_01], [AM_Net_02], [AM_Net_03], [AM_LLY_Budg], [AM_LLY_Actu], [AM_LYr_Budg], [AM_LYr_Actu], [AM_Cyr_Budg], [AM_Ent_By], [AM_Ent_Dt], [AM_Upd_By], [AM_Upd_Dt]) VALUES (N'2015', N'101  ', N'JR', N'01 ', N'00', N'L00002', N'LR_ACCOUNT_02                                     ', N'LRD1', 0.0000, N'DR', 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, N'2    ', CAST(0x0000A5900160E475 AS DateTime), NULL, NULL)
INSERT [dbo].[JR_Accounts] ([AM_Fin_Yr], [AM_Inst_Cd], [AM_Inst_Typ], [AM_Brn_Cd], [AM_Lgr_Cd], [AM_Acc_Cd], [AM_Acc_Nm], [AM_Calls], [AM_Opn_Bal], [AM_OB_Cr_Dr], [AM_ABS_Opn_Bal], [AM_Net_04], [AM_Net_05], [AM_Net_06], [AM_Net_07], [AM_Net_08], [AM_Net_09], [AM_Net_10], [AM_Net_11], [AM_Net_12], [AM_Net_01], [AM_Net_02], [AM_Net_03], [AM_LLY_Budg], [AM_LLY_Actu], [AM_LYr_Budg], [AM_LYr_Actu], [AM_Cyr_Budg], [AM_Ent_By], [AM_Ent_Dt], [AM_Upd_By], [AM_Upd_Dt]) VALUES (N'2015', N'101  ', N'JR', N'01 ', N'00', N'L00003', N'LR_ACCOUNT_LINKING_DEBIT                          ', N'LR02', 2000.0000, N'DR', 2000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, N'2    ', CAST(0x0000A590016EFE1B AS DateTime), NULL, NULL)
/****** Object:  Table [dbo].[Inst_Master]    Script Date: 01/24/2016 13:52:52 ******/
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
INSERT [dbo].[Inst_Master] ([Inst_Cd], [Inst_Nm], [Inst_Typ], [Inst_Adr], [Inst_Tel], [Inst_email], [Inst_Fax], [Inst_web_adr], [Inst_PAN], [Inst_STN], [Inst_STN_Reg_Dt], [Inst_80G_Reg_No], [Inst_Prin_Nm], [Inst_Prin_Dsgn], [Inst_VP_Nm], [Inst_Reg_No], [Inst_Link_No], [Inst_Cls_Yr], [Inst_SAM_Dt], [Inst_FAM_Dt], [Inst_Exam_Dt], [Inst_PAM_Dt], [Inst_LiM_Dt], [Inst_Bank_Nm], [Inst_Acc_No], [Inst_UID_Srl], [Inst_Adm_Rct_Srl], [Inst_Exm_Rct_Srl], [Inst_Oth_Rct_Srl], [Inst_Soc_Rct_Srl], [Inst_Mis_Rct_Srl], [Inst_F_Indctr], [Inst_SMTP], [Inst_User], [Inst_Pass], [Inst_Mdl_Cd], [Inst_Vch_Ref_No]) VALUES (N'100  ', N'SNDT                                              ', N'CG', N'PUNE                                                                                                                    ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 54, NULL, NULL, N'2014-12-12', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 31)
INSERT [dbo].[Inst_Master] ([Inst_Cd], [Inst_Nm], [Inst_Typ], [Inst_Adr], [Inst_Tel], [Inst_email], [Inst_Fax], [Inst_web_adr], [Inst_PAN], [Inst_STN], [Inst_STN_Reg_Dt], [Inst_80G_Reg_No], [Inst_Prin_Nm], [Inst_Prin_Dsgn], [Inst_VP_Nm], [Inst_Reg_No], [Inst_Link_No], [Inst_Cls_Yr], [Inst_SAM_Dt], [Inst_FAM_Dt], [Inst_Exam_Dt], [Inst_PAM_Dt], [Inst_LiM_Dt], [Inst_Bank_Nm], [Inst_Acc_No], [Inst_UID_Srl], [Inst_Adm_Rct_Srl], [Inst_Exm_Rct_Srl], [Inst_Oth_Rct_Srl], [Inst_Soc_Rct_Srl], [Inst_Mis_Rct_Srl], [Inst_F_Indctr], [Inst_SMTP], [Inst_User], [Inst_Pass], [Inst_Mdl_Cd], [Inst_Vch_Ref_No]) VALUES (N'101  ', N'SNDT JR                                           ', N'JR', N'PUNE                                                                                                                    ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 61, NULL, NULL, N'2014-12-12', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 38)
/****** Object:  StoredProcedure [dbo].[GetVoucherHeaderReportDetails]    Script Date: 01/24/2016 13:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVoucherHeaderReportDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetVoucherHeaderReportDetails]
		@instType as varchar(2),		
		@VH_Lnk_No as varchar(12),
		@VH_Dbk_Cd as varchar(4),
		@VH_Trn_Typ as varchar(2),
		@VH_Fin_Yr as varchar(4)

AS
BEGIN
declare @strQuery as nvarchar(max);
            set @strQuery = ''Select LTRIM(RTRIM([VH_Vch_Ref_No])) AS [VH_Ref_No]
									,[VH_Lnk_Dt]
									,[VH_Ref_Dt]
									,[VH_VCH_Dt]
									,LTRIM(RTRIM([VH_VCH_No])) AS [VH_VCH_No]
									,LTRIM(RTRIM([VH_VCH_Ref_No])) AS [VH_VCH_Ref_No]
									,LTRIM(RTRIM([VH_Chq_No])) AS [VH_Chq_No]
									,[VH_Chq_Dt],[VH_Amt],[VH_Abs_Amt]
									,LTRIM(RTRIM([VH_Cr_Dr])) AS [VH_Cr_Dr]
									,LTRIM(RTRIM([VH_Pty_Nm])) AS [VH_Pty_Nm] 
									,ISNULL(UM1.Usr_Nm,''-'') AS [EnteredBy]
									,ISNULL(UM2.Usr_Nm,''-'') AS [ConfirmedBy]
								from  '' + @instType + ''_Voucher_Header VH
								LEFT OUTER JOIN User_Master UM1
								ON UM1.Usr_Id=VH.VH_Ent_By
								LEFT OUTER JOIN User_Master UM2
								ON UM2.Usr_Id=VH.VH_Conf_By
								where [VH_Lnk_No]=''''+@VH_Lnk_No+'''' 
								and [VH_Dbk_Cd]=''''+@VH_Dbk_Cd+'''' 
								and [VH_Trn_Typ]=''''+@VH_Trn_Typ+''''
								and VH_Fin_Yr=''''+@VH_Fin_Yr+''''
								
								exec(@strQuery)

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetVoucherDetailsReportDetails]    Script Date: 01/24/2016 13:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVoucherDetailsReportDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetVoucherDetailsReportDetails]
		@instType as varchar(2),		
		@VH_Lnk_No as varchar(12),
		@VH_Dbk_Cd as varchar(4),
		@VH_Trn_Typ as varchar(2),
		@VH_Fin_Yr as varchar(4)

AS
BEGIN

declare @strQuery as nvarchar(max);
            set @strQuery = ''Select LTRIM(RTRIM(VD_Acc_Cd)) as [LedgerAccount]
									,LTRIM(RTRIM(ac.Am_Acc_Nm)) as [AccountName]
									,VD_ABS_Amt as [Amount]
									,LTRIM(RTRIM(VD_Cr_Dr)) as [CrDr]
									,LTRIM(RTRIM(VD_Ref_No)) as [RefNo]
									,VD_Ref_Dt as [RefDate]
									,LTRIM(RTRIM(VD_Narr)) as [VoucherDesc]
									,LTRIM(RTRIM(VD_Seq_No)) as [VD_Seq_No] 
							from '' + @instType + ''_Voucher_Detail vd 
							Inner Join '' + @instType + ''_Accounts ac 
							on vd.VD_Acc_Cd=ac.Am_Acc_Cd  
							where [VD_Lnk_No]=''''''+@VH_Lnk_No+'''''' 
							and [VD_Dbk_Cd]=''''''+@VH_Dbk_Cd+'''''' 
							and [VD_Trn_Typ]=''''''+@VH_Trn_Typ+''''''
							and [VD_Fin_Yr]=''''''+@VH_Fin_Yr+'''''' 
							ORDER BY [VD_Seq_No] Asc''
								
			exec(@strQuery)
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTrialBalanceReportDetails]    Script Date: 01/24/2016 13:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTrialBalanceReportDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetTrialBalanceReportDetails]
	-- Add the parameters for the stored procedure here
	@instType varchar(2),
	@Fromdate as datetime,-- vh confirm date
	@ToDate as datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @strQuery as nvarchar(max)
	
set @strQuery = ''SELECT
				AM_Acc_Nm
				,dbo.OpeningBalanceValue(AM_Acc_Cd,''''''+CONVERT(VARCHAR(25),DATEADD(DAY,-1,@Fromdate),101)+'''''',''''''+@instType+'''''') as OpeningBalance
				,AM_Acc_Cd
				,ISNULL((SELECT SUM(Lgr_Amt) FROM ''+@instType+''_Ledger WHERE Lgr_Vch_Dt >= ''''''+CONVERT(VARCHAR(10),@Fromdate,110)+'''''' 
				and Lgr_Vch_Dt <= ''''''+CONVERT(VARCHAR(10),@ToDate,110)+'''''' AND Lgr_Acc_Cd=AM_Acc_Cd AND LOWER(Lgr_Cr_Dr)=''''cr''''),0) AS Credit
				,ISNULL((SELECT SUM(Lgr_Amt) FROM ''+@instType+''_Ledger WHERE Lgr_Vch_Dt >= ''''''+CONVERT(VARCHAR(10),@Fromdate,110)+'''''' 
				and Lgr_Vch_Dt <= ''''''+CONVERT(VARCHAR(10),@ToDate,110)+'''''' AND Lgr_Acc_Cd=AM_Acc_Cd AND LOWER(Lgr_Cr_Dr)=''''dr''''),0) AS Debit
				,dbo.OpeningBalanceValue(AM_Acc_Cd,''''''+CONVERT(VARCHAR(25),DATEADD(DAY,0,@ToDate),101)+'''''',''''''+@instType+'''''') as ClosingBalance
			FROM ''+@instType+''_Accounts''

	exec(@strQuery)

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTrailBalanceDetails]    Script Date: 01/24/2016 13:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTrailBalanceDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetTrailBalanceDetails]
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
	set @strQuery = ''SELECT		Acc.AM_ACC_Nm,
								Lgr.Lgr_Acc_Cd,
								CASE 
								WHEN Lgr.Lgr_Trn_Typ in(''''CR'''',''''BR'''') THEN Lgr.Lgr_ABS_Amt
								END as Credit,
								CASE 
								WHEN Lgr.Lgr_Trn_Typ in(''''CP'''',''''BP'''') THEN Lgr.Lgr_ABS_Amt
								END as Debit
								,(Select Top 1 sum(Lgr_Amt) from ''+@instType+''_Ledger
								where Lgr_Lnk_No <= Lgr.Lgr_Lnk_No AND Lgr_vch_dt < getdate() AND Lgr.Lgr_Trn_Typ in(''''CR'''',''''BR'''')) as RunningCreditBalance
								,(Select Top 1 sum(Lgr_Amt) from ''+@instType+''_Ledger
								where Lgr_Lnk_No <= Lgr.Lgr_Lnk_No AND Lgr_vch_dt < getdate() AND Lgr.Lgr_Trn_Typ in(''''CP'''',''''BP'''')) as RunningDebitBalance
								,(Select Top 1 sum(Lgr_Amt) from ''+ @instType +''_Ledger Lgr
								where Lgr_Lnk_No <= Lgr.Lgr_Lnk_No AND Lgr_vch_dt < getdate()) as RunningBalance								
					FROM ''+@instType+''_Accounts Acc
					LEFT OUTER JOIN ''+@instType+''_Ledger Lgr
					ON Acc.AM_ACC_Cd=Lgr.Lgr_Acc_Cd
					WHERE Acc.AM_Calls Is NULL AND Lgr.Lgr_Dbk_Cd = ''''''+@VH_Dbk_Cd+'''''' AND Lgr.Lgr_Vch_No IS NOT NULL 
					''--and VH.VH_Conf_Dt >= @Fromdate and VH.VH_Conf_Dt <= @ToDate
	 
	exec(@strQuery)

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetSPParameters]    Script Date: 01/24/2016 13:52:53 ******/
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
/****** Object:  StoredProcedure [dbo].[TempUpdateAccounts]    Script Date: 01/24/2016 13:52:53 ******/
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
/****** Object:  Table [dbo].[User_Master]    Script Date: 01/24/2016 13:52:52 ******/
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
INSERT [dbo].[User_Master] ([Usr_Id], [Usr_Mdl_Cd], [Usr_Inst_Typ], [Usr_Nm], [Usr_Role], [Usr_Pwd], [Usr_Lst_Login], [Usr_Lst_Wrk_Stn], [Usr_Lckd]) VALUES (N'1    ', N'FAM ', N'CG', N'a                                            ', N'admin               ', N'a         ', N'jj                  ', N'jj             ', N'0')
INSERT [dbo].[User_Master] ([Usr_Id], [Usr_Mdl_Cd], [Usr_Inst_Typ], [Usr_Nm], [Usr_Role], [Usr_Pwd], [Usr_Lst_Login], [Usr_Lst_Wrk_Stn], [Usr_Lckd]) VALUES (N'2    ', N'FAM ', N'JR', N'a                                            ', N'admin               ', N'a         ', N'jj                  ', N'jj             ', N'0')
INSERT [dbo].[User_Master] ([Usr_Id], [Usr_Mdl_Cd], [Usr_Inst_Typ], [Usr_Nm], [Usr_Role], [Usr_Pwd], [Usr_Lst_Login], [Usr_Lst_Wrk_Stn], [Usr_Lckd]) VALUES (N'3    ', N'FAM ', N'CG', N'a                                            ', N'ADMIN OFFICER       ', N'a         ', N'Jan 16 2016  2:14PM ', NULL, N'N')
INSERT [dbo].[User_Master] ([Usr_Id], [Usr_Mdl_Cd], [Usr_Inst_Typ], [Usr_Nm], [Usr_Role], [Usr_Pwd], [Usr_Lst_Login], [Usr_Lst_Wrk_Stn], [Usr_Lckd]) VALUES (N'4    ', N'FAM ', N'CG', N'a                                            ', N'JUNIOR CLERK        ', N'a         ', N'Jan 16 2016  2:18PM ', NULL, N'N')
INSERT [dbo].[User_Master] ([Usr_Id], [Usr_Mdl_Cd], [Usr_Inst_Typ], [Usr_Nm], [Usr_Role], [Usr_Pwd], [Usr_Lst_Login], [Usr_Lst_Wrk_Stn], [Usr_Lckd]) VALUES (N'5    ', N'FAM ', N'CG', N'a                                            ', N'SENIOR CLERK        ', N'a         ', N'Jan 16 2016  2:21PM ', NULL, N'N')
/****** Object:  StoredProcedure [dbo].[GetGeneralLedgerReportDetails]    Script Date: 01/24/2016 13:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetGeneralLedgerReportDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetGeneralLedgerReportDetails]
	-- Add the parameters for the stored procedure here
	@instType varchar(2),
	@Fromdate as datetime,-- vh confirm date
	@ToDate as datetime,
	@IsCashBank as bit,
	@AccountFrom as char(6),
	@AccountTo as char(6)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @strQuery as nvarchar(max)

	set @strQuery = ''SELECT		Acc.AM_ACC_Nm,
								dbo.OpeningBalanceValue(Lgr.Lgr_Acc_cd,''''''+CONVERT(VARCHAR(25),DATEADD(DAY,-1,@Fromdate),101)+'''''',''''''+@instType+'''''') as OpeningBalance,
								Lgr.Lgr_VCH_Dt,
								Lgr.Lgr_Vch_No,
								Lgr.Lgr_Vch_Ref_No,
								Lgr.Lgr_Ref_No,
								Lgr.Lgr_Ref_Dt,
								Lgr.Lgr_Amt,
								Lgr.Lgr_Seq_No,
								Lgr.Lgr_Narr,
								Lgr.Lgr_Fin_Yr,
								Lgr.Lgr_Acc_Cd,
								Lgr.Lgr_Cr_Dr,
								Lgr.Lgr_Trn_Typ,
								CASE 
								WHEN LOWER(Lgr.Lgr_Cr_Dr)=''''cr'''' THEN Lgr.Lgr_ABS_Amt
								END as Credit,
								CASE 
								WHEN LOWER(Lgr.Lgr_Cr_Dr)=''''dr'''' THEN Lgr.Lgr_ABS_Amt
								END as Debit,
								CASE 
								WHEN LOWER(Lgr.Lgr_Cr_Dr)=''''cr'''' THEN Lgr.Lgr_Cr_Dr
								END as CreditCRDR,
								CASE 
								WHEN LOWER(Lgr.Lgr_Cr_Dr)=''''dr'''' THEN Lgr.Lgr_Cr_Dr
								END as DebitCRDR
								,(Select Top 1 sum(Lgr_Amt) from ''+ @instType +''_Ledger Lgr
								where Lgr_acc_cd= Acc.AM_Acc_Cd AND Lgr_vch_dt < getdate()) as RunningBalance								
								,dbo.OpeningBalanceValue(Lgr.Lgr_Acc_Cd,''''''+CONVERT(VARCHAR(25),DATEADD(DAY,0,@ToDate),101)+'''''',''''''+@instType+'''''') as ClosingBalance
					FROM ''+@instType+''_Accounts Acc
					LEFT OUTER JOIN ''+@instType+''_Ledger Lgr
					ON Acc.AM_ACC_Cd=Lgr.Lgr_Acc_Cd
					WHERE Lgr.Lgr_Vch_Dt >= ''''''+CONVERT(VARCHAR(10),@Fromdate,110)+'''''' 
					and Lgr.Lgr_Vch_Dt <= ''''''+CONVERT(VARCHAR(10),@ToDate,110)+''''''''
					

	IF (@IsCashBank = ''True'')
	BEGIN
	SET  @strQuery = @strQuery + '' AND Acc.AM_Calls IS NOT NULL''
	END
	ELSE
	BEGIN
	SET  @strQuery = @strQuery + '' AND Acc.AM_Calls IS NULL''
	END

	SET  @strQuery = @strQuery +'' and Acc.AM_ACC_Cd between ''''''+@AccountFrom+'''''' and ''''''+@AccountTo+''''''''

	--print(@strQuery)
	exec(@strQuery)

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetCashBankReportDetails]    Script Date: 01/24/2016 13:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCashBankReportDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetCashBankReportDetails]
	-- Add the parameters for the stored procedure here
	@instType varchar(2),
	@Fromdate as datetime = NULL,-- vh confirm date
	@ToDate as datetime = NULL,
	@VH_Dbk_Cd char(4)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @strQuery as nvarchar(max)
	

	set @strQuery = ''SELECT 
					VH.VH_acc_cd, 
					dbo.OpeningBalanceValue(VH.VH_acc_cd,''''''+CONVERT(VARCHAR(25),DATEADD(DAY,-1,@Fromdate),101)+'''''',''''''+@instType+'''''') as OpeningBalance,
					VH.VH_Vch_No, 
					VH.VH_Vch_Ref_No, 
					VD.VD_Lgr_Cd, 
					Acc.AM_Acc_Nm, 
					VD.VD_Narr, 
					VH.VH_Pty_Nm, 
					CASE WHEN VH.VH_Chq_No > 0 THEN VH.VH_Chq_Dt
					ELSE [VD_Ref_Dt] END AS [VD_Ref_Dt],
					VD.VD_Fin_Yr,
					VD.VD_Cr_Dr,
					VD.VD_Seq_No,
					VH.VH_Trn_Typ,
					CASE 
					WHEN LOWER(VH.VH_Cr_Dr)=''''dr'''' THEN VD.VD_ABS_Amt
					END as Receipt,
					CASE 
					WHEN LOWER(VH.VH_Cr_Dr)=''''cr'''' THEN VD.VD_ABS_Amt
					END as Payment,
					CASE 
					WHEN LOWER(VH.VH_Cr_Dr)=''''dr'''' THEN VD.VD_Cr_Dr
					END as ReceiptCRDR,
					CASE 
					WHEN LOWER(VH.VH_Cr_Dr)=''''cr'''' THEN VD.VD_Cr_Dr 
					END as PaymentCRDR,
					CASE WHEN VH.VH_Chq_No > 0 THEN VH.VH_Chq_No
					ELSE ''''Cash''''
					END as TransactionType,
					VH.VH_ABS_Amt,
					CASE 
					WHEN LOWER(VH.VH_Cr_Dr)=''''dr'''' THEN VH.VH_Amt
					END as ReceiptSum,
					CASE 
					WHEN LOWER(VH.VH_Cr_Dr)=''''cr'''' THEN VH.VH_Amt
					END as PaymentSum,
					VH.VH_Amt,
					VD.VD_Amt,
					VD.VD_Acc_Cd,
					VH.VH_Vch_Dt,
					dbo.OpeningBalanceValue(VH.VH_acc_cd,''''''+CONVERT(VARCHAR(25),DATEADD(DAY,0,@ToDate),101)+'''''',''''''+@instType+'''''') as ClosingBalance
					FROM ''+@instType+''_Voucher_Detail AS VD 
	INNER JOIN		''+@instType+''_Voucher_Header AS VH 
	ON				VD.VD_Vch_Ref_No = VH.VH_Vch_Ref_No 
	LEFT OUTER JOIN	''+@instType+''_Accounts AS Acc 
	ON				VD.VD_Acc_Cd = Acc.AM_Acc_Cd
	WHERE			VH.VH_Dbk_Cd = ''''''+@VH_Dbk_Cd+'''''' AND VH.VH_Vch_No IS NOT NULL and VH.VH_Vch_Dt >= ''''''+CONVERT(VARCHAR(10),@Fromdate,110)+'''''' and VH.VH_Vch_Dt <= ''''''+CONVERT(VARCHAR(10),@ToDate,110)+''''''
	ORDER BY		VD.VD_Lnk_No ASC''

	exec(@strQuery)

END' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[testfunc]    Script Date: 01/24/2016 13:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[testfunc]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[testfunc]
	(
	@lgrCode varchar(10),
@vchDate datetime,
@instType varchar(5)
	)
RETURNS money
AS
	BEGIN

declare @firstDate as datetime
set @firstDate=(SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@vchDate)-1),@vchDate),101))

declare @processingMonth as int
set @processingMonth=DATEPART(mm,@vchDate)

declare @totalBalance as money
declare @balanceAdd as money

declare @opnBalance as money
declare @opnQuery as nvarchar(max)

select @opnBalance=AM_Opn_Bal from CG_Accounts where AM_Acc_Cd=@lgrCode                

declare @monthAmt as money
declare @monthQuery as nvarchar(max)
select @monthAmt=SUM(Lgr_Amt) from CG_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
                  and Lgr_Acc_Cd= @lgrCode            

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
set @paddedString=right(''0''+ rtrim(convert(varchar(5),@startCount)), 2)

SELECT @queryOut = case 

                    when @paddedString = ''01'' then AM_Net_01
                    when @paddedString = ''02'' then AM_Net_02
                    when @paddedString = ''03'' then AM_Net_03
                    when @paddedString = ''04'' then AM_Net_04
                    when @paddedString = ''05'' then AM_Net_05
                    when @paddedString = ''06'' then AM_Net_06
                    when @paddedString = ''07'' then AM_Net_07
                    when @paddedString = ''08'' then AM_Net_08
                    when @paddedString = ''09'' then AM_Net_09
                    when @paddedString = ''10'' then AM_Net_10
                    when @paddedString = ''11'' then AM_Net_11
                    when @paddedString = ''12'' then AM_Net_12
               end
			   FROM CG_Accounts where AM_Acc_Cd=@lgrCode
 
 set @balanceAdd=isnull(@balanceAdd,0)+ @queryOut
 set @startCount=@startCount+1
End

--add current month amounts
set @balanceAdd=isnull(@balanceAdd,0)+isnull(@monthAmt,0) 

                 
--calculate total balance by adding all calculations to opening balance
set @totalBalance=ISNULL(@opnBalance,0)+isnull(@balanceAdd,0)
End

SET @totalBalance= ISNULL(@totalBalance,0)

	RETURN @totalBalance
	END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAccountDetails]    Script Date: 01/24/2016 13:52:53 ******/
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
/****** Object:  StoredProcedure [dbo].[Upsert_VoucherHeader]    Script Date: 01/24/2016 13:52:53 ******/
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
/****** Object:  StoredProcedure [dbo].[Upsert_VoucherDetails]    Script Date: 01/24/2016 13:52:53 ******/
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
/****** Object:  StoredProcedure [dbo].[Upsert_Ledger]    Script Date: 01/24/2016 13:52:53 ******/
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
/****** Object:  StoredProcedure [dbo].[Upsert_BankBooks]    Script Date: 01/24/2016 13:52:53 ******/
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
/****** Object:  StoredProcedure [dbo].[Upsert_AccountDetail]    Script Date: 01/24/2016 13:52:53 ******/
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
/****** Object:  Trigger [UpdateNetAmount_JR]    Script Date: 01/24/2016 13:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UpdateNetAmount_JR]'))
EXEC dbo.sp_executesql @statement = N'CREATE trigger [dbo].[UpdateNetAmount_JR] on [dbo].[JR_Ledger]
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
set @paddedString=right(''0''+ rtrim(@vchDateMonth), 2)

If @voucherDate is not null
Begin

declare @strQuery as nvarchar(max)

set @strQuery=

''update ''+@instType+''_Accounts 
set AM_Net_''+@paddedString+''=ISNULL(AM_Net_''+@paddedString+'',0)+LG.Lgr_Amt 
FROM ''+@instType+''_Accounts AM
INNER JOIN #tempInserted LG
ON AM.AM_Acc_Cd=LG.Lgr_Acc_Cd''

exec(@strQuery)

drop table #tempInserted

END
'
GO
/****** Object:  Trigger [UpdateNetAmount]    Script Date: 01/24/2016 13:52:53 ******/
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
set @instType=(select top 1 lgr_Inst_Typ from inserted)

declare @voucherDate as date
set @voucherDate=(select top 1 Lgr_Vch_Dt from inserted)
declare @vchDateMonth as varchar(2)
set @vchDateMonth=Convert(varchar(2),DatePart(mm,@voucherDate))

declare @paddedString as varchar(2)
set @paddedString=right(''0''+ rtrim(@vchDateMonth), 2)

If @voucherDate is not null
Begin

declare @strQuery as nvarchar(max)

set @strQuery=

''update ''+@instType+''_Accounts 
set AM_Net_''+@paddedString+''=ISNULL(AM_Net_''+@paddedString+'',0)+LG.Lgr_Amt 
FROM ''+@instType+''_Accounts AM
INNER JOIN #tempInserted LG
ON AM.AM_Acc_Cd=LG.Lgr_Acc_Cd''

exec(@strQuery)

drop table #tempInserted

END
'
GO
/****** Object:  UserDefinedFunction [dbo].[OpeningBalanceValue]    Script Date: 01/24/2016 13:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OpeningBalanceValue]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[OpeningBalanceValue]
(
	@lgrCode varchar(10),
	@vchDate date,
	@instType varchar(5)
)
RETURNS money
AS
	BEGIN

		declare @firstDate as datetime
		set @firstDate=(SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@vchDate)-1),@vchDate),101))

		declare @processingMonth as int
		set @processingMonth=DATEPART(mm,@vchDate)

		declare @totalBalance as money
		declare @balanceAdd as money

		declare @opnBalance as money
		declare @opnQuery as nvarchar(max)

		declare @monthAmt as money
		declare @monthQuery as nvarchar(max)

		--Institution Type
		--UR – Undergraduate Regular Section
		--UP – Undergraduate Professional Section
		--JR – Junior College Section
		--PG – Post Graduate Section
		--VO – Vocational (MCVC) Section
		--PO – Polytechnic
		--EN – Engineering College Section
		--PP – Pre-Primary Section
		--PR – Primary Section
		--SE – Secondary Section
		--SO – Society Section
		--AB – Apex Body (Education Trust)

		IF @instType = ''CG''
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from CG_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from CG_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = ''UR''
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from UR_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from UR_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = ''UP''
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from UP_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from UP_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = ''JR''
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from JR_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from JR_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = ''PG''
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from PG_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from PG_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = ''VO''
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from VO_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from VO_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = ''PO''
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from PO_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from PO_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = ''EN''
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from EN_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from EN_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = ''PP''
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from PP_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from PP_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = ''PR''
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from PR_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from PR_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = ''SE''
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from SE_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from SE_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = ''SO''
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from SO_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from SO_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = ''AB''
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from AB_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from AB_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END

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
		set @paddedString=right(''0''+ rtrim(convert(varchar(5),@startCount)), 2)

		IF @instType = ''CG''
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = ''01'' then AM_Net_01
							when @paddedString = ''02'' then AM_Net_02
							when @paddedString = ''03'' then AM_Net_03
							when @paddedString = ''04'' then AM_Net_04
							when @paddedString = ''05'' then AM_Net_05
							when @paddedString = ''06'' then AM_Net_06
							when @paddedString = ''07'' then AM_Net_07
							when @paddedString = ''08'' then AM_Net_08
							when @paddedString = ''09'' then AM_Net_09
							when @paddedString = ''10'' then AM_Net_10
							when @paddedString = ''11'' then AM_Net_11
							when @paddedString = ''12'' then AM_Net_12
						end
						FROM CG_Accounts where AM_Acc_Cd=@lgrCode           

		END
		ELSE IF @instType = ''UR''
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = ''01'' then AM_Net_01
							when @paddedString = ''02'' then AM_Net_02
							when @paddedString = ''03'' then AM_Net_03
							when @paddedString = ''04'' then AM_Net_04
							when @paddedString = ''05'' then AM_Net_05
							when @paddedString = ''06'' then AM_Net_06
							when @paddedString = ''07'' then AM_Net_07
							when @paddedString = ''08'' then AM_Net_08
							when @paddedString = ''09'' then AM_Net_09
							when @paddedString = ''10'' then AM_Net_10
							when @paddedString = ''11'' then AM_Net_11
							when @paddedString = ''12'' then AM_Net_12
						end
						FROM UR_Accounts where AM_Acc_Cd=@lgrCode            

		END
		ELSE IF @instType = ''UP''
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = ''01'' then AM_Net_01
							when @paddedString = ''02'' then AM_Net_02
							when @paddedString = ''03'' then AM_Net_03
							when @paddedString = ''04'' then AM_Net_04
							when @paddedString = ''05'' then AM_Net_05
							when @paddedString = ''06'' then AM_Net_06
							when @paddedString = ''07'' then AM_Net_07
							when @paddedString = ''08'' then AM_Net_08
							when @paddedString = ''09'' then AM_Net_09
							when @paddedString = ''10'' then AM_Net_10
							when @paddedString = ''11'' then AM_Net_11
							when @paddedString = ''12'' then AM_Net_12
						end
						FROM UP_Accounts where AM_Acc_Cd=@lgrCode            

		END
		ELSE IF @instType = ''JR''
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = ''01'' then AM_Net_01
							when @paddedString = ''02'' then AM_Net_02
							when @paddedString = ''03'' then AM_Net_03
							when @paddedString = ''04'' then AM_Net_04
							when @paddedString = ''05'' then AM_Net_05
							when @paddedString = ''06'' then AM_Net_06
							when @paddedString = ''07'' then AM_Net_07
							when @paddedString = ''08'' then AM_Net_08
							when @paddedString = ''09'' then AM_Net_09
							when @paddedString = ''10'' then AM_Net_10
							when @paddedString = ''11'' then AM_Net_11
							when @paddedString = ''12'' then AM_Net_12
						end
						FROM JR_Accounts where AM_Acc_Cd=@lgrCode           

		END
		ELSE IF @instType = ''PG''
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = ''01'' then AM_Net_01
							when @paddedString = ''02'' then AM_Net_02
							when @paddedString = ''03'' then AM_Net_03
							when @paddedString = ''04'' then AM_Net_04
							when @paddedString = ''05'' then AM_Net_05
							when @paddedString = ''06'' then AM_Net_06
							when @paddedString = ''07'' then AM_Net_07
							when @paddedString = ''08'' then AM_Net_08
							when @paddedString = ''09'' then AM_Net_09
							when @paddedString = ''10'' then AM_Net_10
							when @paddedString = ''11'' then AM_Net_11
							when @paddedString = ''12'' then AM_Net_12
						end
						FROM PG_Accounts where AM_Acc_Cd=@lgrCode            

		END
		ELSE IF @instType = ''VO''
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = ''01'' then AM_Net_01
							when @paddedString = ''02'' then AM_Net_02
							when @paddedString = ''03'' then AM_Net_03
							when @paddedString = ''04'' then AM_Net_04
							when @paddedString = ''05'' then AM_Net_05
							when @paddedString = ''06'' then AM_Net_06
							when @paddedString = ''07'' then AM_Net_07
							when @paddedString = ''08'' then AM_Net_08
							when @paddedString = ''09'' then AM_Net_09
							when @paddedString = ''10'' then AM_Net_10
							when @paddedString = ''11'' then AM_Net_11
							when @paddedString = ''12'' then AM_Net_12
						end
						FROM VO_Accounts where AM_Acc_Cd=@lgrCode 
		END
		ELSE IF @instType = ''PO''
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = ''01'' then AM_Net_01
							when @paddedString = ''02'' then AM_Net_02
							when @paddedString = ''03'' then AM_Net_03
							when @paddedString = ''04'' then AM_Net_04
							when @paddedString = ''05'' then AM_Net_05
							when @paddedString = ''06'' then AM_Net_06
							when @paddedString = ''07'' then AM_Net_07
							when @paddedString = ''08'' then AM_Net_08
							when @paddedString = ''09'' then AM_Net_09
							when @paddedString = ''10'' then AM_Net_10
							when @paddedString = ''11'' then AM_Net_11
							when @paddedString = ''12'' then AM_Net_12
						end
						FROM PO_Accounts where AM_Acc_Cd=@lgrCode            

		END
		ELSE IF @instType = ''EN''
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = ''01'' then AM_Net_01
							when @paddedString = ''02'' then AM_Net_02
							when @paddedString = ''03'' then AM_Net_03
							when @paddedString = ''04'' then AM_Net_04
							when @paddedString = ''05'' then AM_Net_05
							when @paddedString = ''06'' then AM_Net_06
							when @paddedString = ''07'' then AM_Net_07
							when @paddedString = ''08'' then AM_Net_08
							when @paddedString = ''09'' then AM_Net_09
							when @paddedString = ''10'' then AM_Net_10
							when @paddedString = ''11'' then AM_Net_11
							when @paddedString = ''12'' then AM_Net_12
						end
						FROM EN_Accounts where AM_Acc_Cd=@lgrCode          

		END
		ELSE IF @instType = ''PP''
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = ''01'' then AM_Net_01
							when @paddedString = ''02'' then AM_Net_02
							when @paddedString = ''03'' then AM_Net_03
							when @paddedString = ''04'' then AM_Net_04
							when @paddedString = ''05'' then AM_Net_05
							when @paddedString = ''06'' then AM_Net_06
							when @paddedString = ''07'' then AM_Net_07
							when @paddedString = ''08'' then AM_Net_08
							when @paddedString = ''09'' then AM_Net_09
							when @paddedString = ''10'' then AM_Net_10
							when @paddedString = ''11'' then AM_Net_11
							when @paddedString = ''12'' then AM_Net_12
						end
						FROM PP_Accounts where AM_Acc_Cd=@lgrCode           

		END
		ELSE IF @instType = ''PR''
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = ''01'' then AM_Net_01
							when @paddedString = ''02'' then AM_Net_02
							when @paddedString = ''03'' then AM_Net_03
							when @paddedString = ''04'' then AM_Net_04
							when @paddedString = ''05'' then AM_Net_05
							when @paddedString = ''06'' then AM_Net_06
							when @paddedString = ''07'' then AM_Net_07
							when @paddedString = ''08'' then AM_Net_08
							when @paddedString = ''09'' then AM_Net_09
							when @paddedString = ''10'' then AM_Net_10
							when @paddedString = ''11'' then AM_Net_11
							when @paddedString = ''12'' then AM_Net_12
						end
						FROM PR_Accounts where AM_Acc_Cd=@lgrCode            

		END
		ELSE IF @instType = ''SE''
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = ''01'' then AM_Net_01
							when @paddedString = ''02'' then AM_Net_02
							when @paddedString = ''03'' then AM_Net_03
							when @paddedString = ''04'' then AM_Net_04
							when @paddedString = ''05'' then AM_Net_05
							when @paddedString = ''06'' then AM_Net_06
							when @paddedString = ''07'' then AM_Net_07
							when @paddedString = ''08'' then AM_Net_08
							when @paddedString = ''09'' then AM_Net_09
							when @paddedString = ''10'' then AM_Net_10
							when @paddedString = ''11'' then AM_Net_11
							when @paddedString = ''12'' then AM_Net_12
						end
						FROM SE_Accounts where AM_Acc_Cd=@lgrCode           

		END
		ELSE IF @instType = ''SO''
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = ''01'' then AM_Net_01
							when @paddedString = ''02'' then AM_Net_02
							when @paddedString = ''03'' then AM_Net_03
							when @paddedString = ''04'' then AM_Net_04
							when @paddedString = ''05'' then AM_Net_05
							when @paddedString = ''06'' then AM_Net_06
							when @paddedString = ''07'' then AM_Net_07
							when @paddedString = ''08'' then AM_Net_08
							when @paddedString = ''09'' then AM_Net_09
							when @paddedString = ''10'' then AM_Net_10
							when @paddedString = ''11'' then AM_Net_11
							when @paddedString = ''12'' then AM_Net_12
						end
						FROM SO_Accounts where AM_Acc_Cd=@lgrCode         

		END
		ELSE IF @instType = ''AB''
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = ''01'' then AM_Net_01
							when @paddedString = ''02'' then AM_Net_02
							when @paddedString = ''03'' then AM_Net_03
							when @paddedString = ''04'' then AM_Net_04
							when @paddedString = ''05'' then AM_Net_05
							when @paddedString = ''06'' then AM_Net_06
							when @paddedString = ''07'' then AM_Net_07
							when @paddedString = ''08'' then AM_Net_08
							when @paddedString = ''09'' then AM_Net_09
							when @paddedString = ''10'' then AM_Net_10
							when @paddedString = ''11'' then AM_Net_11
							when @paddedString = ''12'' then AM_Net_12
						end
						FROM AB_Accounts where AM_Acc_Cd=@lgrCode 

		END
 
			set @balanceAdd=isnull(@balanceAdd,0)+ @queryOut
			set @startCount=@startCount+1
		End

		--add current month amounts
		set @balanceAdd=isnull(@balanceAdd,0)+isnull(@monthAmt,0) 

                 
		--calculate total balance by adding all calculations to opening balance
		set @totalBalance=ISNULL(@opnBalance,0)+isnull(@balanceAdd,0)
		End

		SET @totalBalance= ISNULL(@totalBalance,0)

RETURN @totalBalance
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetInstitutionDetails]    Script Date: 01/24/2016 13:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetInstitutionDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetInstitutionDetails]
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
