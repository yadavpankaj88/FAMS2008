GO
ALTER FUNCTION [dbo].[OpeningBalanceValue]
(
	@accCode AS NVARCHAR(6),
	@vchDate AS DATETIME,
	@instType AS VARCHAR(2),
	@finYear AS NVARCHAR(4)
)
RETURNS money
AS
	BEGIN
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

		DECLARE @FinYearStartDate DateTime;
		DECLARE @OpeningBalance FLOAT;
		DECLARE @TotalBalance FLOAT;
		DECLARE @LedgerBalance FLOAT;
		DECLARE @VoucherDateToConsider DateTime;
		DECLARE @FinYearStartDateString NVARCHAR(MAX);

		SET @FinYearStartDateString='01-04-'+@finYear
		SET @FinYearStartDate=CONVERT(DATETIME,@FinYearStartDateString ,105)

		IF @instType = 'CG'
		BEGIN
		
		SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) FROM CG_Accounts WHERE AM_Acc_Cd=@accCode

		SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
								FROM CG_Ledger
								WHERE Lgr_Acc_Cd=@accCode 
								AND Lgr_Inst_Typ=@instType 
								AND Lgr_Fin_Yr=@finYear
								AND Lgr_Vch_Dt>=@FinYearStartDate
								AND Lgr_Vch_Dt<=@vchDate
		END
		ELSE IF @instType = 'UR'
		BEGIN
		
		SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) FROM UR_Accounts WHERE AM_Acc_Cd=@accCode

		SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
								FROM UR_Ledger
								WHERE Lgr_Acc_Cd=@accCode 
								AND Lgr_Inst_Typ=@instType 
								AND Lgr_Fin_Yr=@finYear
								AND Lgr_Vch_Dt>=@FinYearStartDate
								AND Lgr_Vch_Dt<=@vchDate       

		END
		ELSE IF @instType = 'UP'
		BEGIN
		
		SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) FROM UP_Accounts WHERE AM_Acc_Cd=@accCode

		SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
								FROM UP_Ledger
								WHERE Lgr_Acc_Cd=@accCode 
								AND Lgr_Inst_Typ=@instType 
								AND Lgr_Fin_Yr=@finYear
								AND Lgr_Vch_Dt>=@FinYearStartDate
								AND Lgr_Vch_Dt<=@vchDate      

		END
		ELSE IF @instType = 'JR'
		BEGIN
		
		SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) FROM JR_Accounts WHERE AM_Acc_Cd=@accCode

		SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
								FROM JR_Ledger
								WHERE Lgr_Acc_Cd=@accCode 
								AND Lgr_Inst_Typ=@instType 
								AND Lgr_Fin_Yr=@finYear
								AND Lgr_Vch_Dt>=@FinYearStartDate
								AND Lgr_Vch_Dt<=@vchDate         

		END
		ELSE IF @instType = 'PG'
		BEGIN
		
		SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) FROM PG_Accounts WHERE AM_Acc_Cd=@accCode

		SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
								FROM PG_Ledger
								WHERE Lgr_Acc_Cd=@accCode 
								AND Lgr_Inst_Typ=@instType 
								AND Lgr_Fin_Yr=@finYear
								AND Lgr_Vch_Dt>=@FinYearStartDate
								AND Lgr_Vch_Dt<=@vchDate               

		END
		ELSE IF @instType = 'VO'
		BEGIN
		
		SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) FROM VO_Accounts WHERE AM_Acc_Cd=@accCode

		SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
								FROM VO_Ledger
								WHERE Lgr_Acc_Cd=@accCode 
								AND Lgr_Inst_Typ=@instType 
								AND Lgr_Fin_Yr=@finYear
								AND Lgr_Vch_Dt>=@FinYearStartDate
								AND Lgr_Vch_Dt<=@vchDate             

		END
		ELSE IF @instType = 'PO'
		BEGIN
		
		SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) FROM PO_Accounts WHERE AM_Acc_Cd=@accCode

		SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
								FROM PO_Ledger
								WHERE Lgr_Acc_Cd=@accCode 
								AND Lgr_Inst_Typ=@instType 
								AND Lgr_Fin_Yr=@finYear
								AND Lgr_Vch_Dt>=@FinYearStartDate
								AND Lgr_Vch_Dt<=@vchDate              

		END
		ELSE IF @instType = 'EN'
		BEGIN
		
		SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) FROM EN_Accounts WHERE AM_Acc_Cd=@accCode

		SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
								FROM EN_Ledger
								WHERE Lgr_Acc_Cd=@accCode 
								AND Lgr_Inst_Typ=@instType 
								AND Lgr_Fin_Yr=@finYear
								AND Lgr_Vch_Dt>=@FinYearStartDate
								AND Lgr_Vch_Dt<=@vchDate            

		END
		ELSE IF @instType = 'PP'
		BEGIN
		
		SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) FROM PP_Accounts WHERE AM_Acc_Cd=@accCode

		SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
								FROM PP_Ledger
								WHERE Lgr_Acc_Cd=@accCode 
								AND Lgr_Inst_Typ=@instType 
								AND Lgr_Fin_Yr=@finYear
								AND Lgr_Vch_Dt>=@FinYearStartDate
								AND Lgr_Vch_Dt<=@vchDate          

		END
		ELSE IF @instType = 'PR'
		BEGIN
		
		SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) FROM PR_Accounts WHERE AM_Acc_Cd=@accCode

		SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
								FROM PR_Ledger
								WHERE Lgr_Acc_Cd=@accCode 
								AND Lgr_Inst_Typ=@instType 
								AND Lgr_Fin_Yr=@finYear
								AND Lgr_Vch_Dt>=@FinYearStartDate
								AND Lgr_Vch_Dt<=@vchDate            

		END
		ELSE IF @instType = 'SE'
		BEGIN
		
		SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) FROM SE_Accounts WHERE AM_Acc_Cd=@accCode

		SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
								FROM SE_Ledger
								WHERE Lgr_Acc_Cd=@accCode 
								AND Lgr_Inst_Typ=@instType 
								AND Lgr_Fin_Yr=@finYear
								AND Lgr_Vch_Dt>=@FinYearStartDate
								AND Lgr_Vch_Dt<=@vchDate            

		END
		ELSE IF @instType = 'SO'
		BEGIN
		
		SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) FROM SO_Accounts WHERE AM_Acc_Cd=@accCode

		SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
								FROM SO_Ledger
								WHERE Lgr_Acc_Cd=@accCode 
								AND Lgr_Inst_Typ=@instType 
								AND Lgr_Fin_Yr=@finYear
								AND Lgr_Vch_Dt>=@FinYearStartDate
								AND Lgr_Vch_Dt<=@vchDate             

		END
		ELSE IF @instType = 'AB'
		BEGIN
		
		SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) FROM AB_Accounts WHERE AM_Acc_Cd=@accCode

		SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
								FROM AB_Ledger
								WHERE Lgr_Acc_Cd=@accCode 
								AND Lgr_Inst_Typ=@instType 
								AND Lgr_Fin_Yr=@finYear
								AND Lgr_Vch_Dt>=@FinYearStartDate
								AND Lgr_Vch_Dt<=@vchDate             

		END
		
		SET @TotalBalance=ISNULL(@OpeningBalance,0)+ISNULL(@LedgerBalance,0);
		RETURN @TotalBalance;
END
GO

print'----------------------------------------------------------------------------------------------'
GO
ALTER PROCEDURE [dbo].[GetCashBankReportDetails]
	-- Add the parameters for the stored procedure here
	@instType NVARCHAR(2),
	@Fromdate AS DATETIME = NULL,
	@ToDate AS DATETIME = NULL,
	@VH_Dbk_Cd NVARCHAR(4),
	@DayBookName NVARCHAR(50),
	@DayBookType  NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @strQuery AS NVARCHAR(MAX)
	

	SET @strQuery = 'SELECT * FROM (SELECT 
					VH.VH_acc_cd, 
					dbo.OpeningBalanceValue(VH.VH_acc_cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,-1,@Fromdate),101)+''','''+@instType+''',VH.VH_Fin_Yr) as OpeningBalance,
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
					WHEN LOWER(VH.VH_Cr_Dr)=''dr'' THEN VD.VD_ABS_Amt
					END as Receipt,
					CASE 
					WHEN LOWER(VH.VH_Cr_Dr)=''cr'' THEN VD.VD_ABS_Amt
					END as Payment,
					CASE 
					WHEN LOWER(VH.VH_Cr_Dr)=''dr'' THEN VD.VD_Cr_Dr
					END as ReceiptCRDR,
					CASE 
					WHEN LOWER(VH.VH_Cr_Dr)=''cr'' THEN VD.VD_Cr_Dr 
					END as PaymentCRDR,
					CASE WHEN VH.VH_Chq_No > 0 THEN VH.VH_Chq_No
					ELSE ''Cash''
					END as TransactionType,
					VH.VH_ABS_Amt,
					CASE 
					WHEN LOWER(VH.VH_Cr_Dr)=''dr'' THEN VH.VH_Amt
					END as ReceiptSum,
					CASE 
					WHEN LOWER(VH.VH_Cr_Dr)=''cr'' THEN VH.VH_Amt
					END as PaymentSum,
					VH.VH_Amt,
					VD.VD_Amt,
					VD.VD_Acc_Cd,
					VH.VH_Vch_Dt,
					dbo.OpeningBalanceValue(VH.VH_acc_cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,0,@ToDate),101)+''','''+@instType+''',VH.VH_Fin_Yr) as ClosingBalance
					FROM '+@instType+'_Voucher_Detail AS VD 
	INNER JOIN		'+@instType+'_Voucher_Header AS VH 
	ON				VD.VD_Vch_Ref_No = VH.VH_Vch_Ref_No 
	LEFT OUTER JOIN	'+@instType+'_Accounts AS Acc 
	ON				VD.VD_Acc_Cd = Acc.AM_Acc_Cd
	WHERE			VH.VH_Dbk_Cd = '''+@VH_Dbk_Cd+''' AND VH.VH_Vch_No IS NOT NULL and VH.VH_Vch_Dt >= '''+CONVERT(VARCHAR(10),@Fromdate,110)+''' and VH.VH_Vch_Dt <= '''+CONVERT(VARCHAR(10),@ToDate,110)+'''
	
	UNION ALL
	
					SELECT 
					VD_acc_cd AS VH_acc_cd, 
					dbo.OpeningBalanceValue(VD_acc_cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,-1,@Fromdate),101)+''','''+@instType+''',VD_Fin_Yr) as OpeningBalance,
					VD_Vch_No AS VH_Vch_No, 
					VD_Vch_Ref_No AS VH_Vch_Ref_No, 
					VD_Lgr_Cd, 
					AM_Acc_Nm, 
					VH_Pty_Nm AS VD_Narr, 
					VH_Pty_Nm AS VD_Narr, 
					CASE WHEN VH_Chq_No > 0 THEN VH_Chq_Dt
					ELSE NULL END AS [VD_Ref_Dt],
					VD_Fin_Yr,
					VH_Cr_Dr AS VD_Cr_Dr,
					VD_Seq_No,
					VD_Trn_Typ AS VH_Trn_Typ,
					CASE 
					WHEN LOWER(VD_Cr_Dr)=''dr'' THEN VH_ABS_Amt
					END as Receipt,
					CASE 
					WHEN LOWER(VD_Cr_Dr)=''cr'' THEN VH_ABS_Amt
					END as Payment,
					CASE 
					WHEN LOWER(VD_Cr_Dr)=''dr'' THEN VH_Cr_Dr
					END as ReceiptCRDR,
					CASE 
					WHEN LOWER(VD_Cr_Dr)=''cr'' THEN VH_Cr_Dr 
					END as PaymentCRDR,
					CASE WHEN VH_Chq_No > 0 THEN VH_Chq_No
					ELSE ''Cash''
					END as TransactionType,
					VD_ABS_Amt AS VH_ABS_Amt,
					CASE 
					WHEN LOWER(VD_Cr_Dr)=''dr'' THEN VD_Amt
					END as ReceiptSum,
					CASE 
					WHEN LOWER(VD_Cr_Dr)=''cr'' THEN VD_Amt
					END as PaymentSum,
					VD_Amt AS VH_Amt,
					VH_Amt AS VD_Amt,
					VD_Acc_Cd,
					VH_Vch_Dt,
					dbo.OpeningBalanceValue(VD_acc_cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,0,@ToDate),101)+''','''+@instType+''',VD_Fin_Yr) as ClosingBalance
					FROM '+@instType+'_Voucher_Detail VD
					INNER JOIN '+@instType+'_Voucher_Header VH
					ON VD.VD_Lnk_No=VH.VH_Lnk_No
					LEFT OUTER JOIN '+@instType+'_Accounts AM
					ON AM.AM_Acc_Cd=VD.VD_Acc_Cd
					WHERE VD_Trn_Typ=''CT''
					AND VD_Dbk_Cd='''+@VH_Dbk_Cd+''' AND VD_Vch_No IS NOT NULL and VH_Vch_Dt >= '''+CONVERT(VARCHAR(10),@Fromdate,110)+''' and VH_Vch_Dt <= '''+CONVERT(VARCHAR(10),@ToDate,110)+'''
					)dataset ORDER BY VH_Vch_Dt,VH_Vch_Ref_No, VD_Seq_No asc'
	
--print @strQuery
	EXEC(@strQuery)

END
GO
print'----------------------------------------------------------------------------------------------'
GO
ALTER PROCEDURE [dbo].[GetGeneralLedgerReportDetails]
	-- Add the parameters for the stored procedure here
	@instType AS NVARCHAR(2),
	@Fromdate AS DATETIME,
	@ToDate AS DATETIME,
	@IsCashBank AS BIT,
	@AccountFrom AS NVARCHAR(6),
	@AccountTo AS NVARCHAR(6)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @strQuery AS NVARCHAR(MAX)

	SET @strQuery = 'SELECT		Acc.AM_ACC_Nm,
								dbo.OpeningBalanceValue(Lgr.Lgr_Acc_cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,-1,@Fromdate),101)+''','''+@instType+''',Lgr.Lgr_Fin_Yr) as OpeningBalance,
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
								Lgr.Lgr_Dbk_Cd,
								CASE 
								WHEN LOWER(Lgr.Lgr_Cr_Dr)=''cr'' THEN Lgr.Lgr_ABS_Amt
								END as Credit,
								CASE 
								WHEN LOWER(Lgr.Lgr_Cr_Dr)=''dr'' THEN Lgr.Lgr_ABS_Amt
								END as Debit,
								CASE 
								WHEN LOWER(Lgr.Lgr_Cr_Dr)=''cr'' THEN Lgr.Lgr_Cr_Dr
								END as CreditCRDR,
								CASE 
								WHEN LOWER(Lgr.Lgr_Cr_Dr)=''dr'' THEN Lgr.Lgr_Cr_Dr
								END as DebitCRDR
								,(Select Top 1 sum(Lgr_Amt) from '+ @instType +'_Ledger Lgr
								where Lgr_acc_cd= Acc.AM_Acc_Cd AND Lgr_vch_dt < getdate()) as RunningBalance								
								,dbo.OpeningBalanceValue(Lgr.Lgr_Acc_Cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,0,@ToDate),101)+''','''+@instType+''',Lgr.Lgr_Fin_Yr) as ClosingBalance
					FROM '+@instType+'_Accounts Acc
					LEFT OUTER JOIN '+@instType+'_Ledger Lgr
					ON Acc.AM_ACC_Cd=Lgr.Lgr_Acc_Cd
					WHERE Lgr.Lgr_Vch_Dt >= '''+CONVERT(VARCHAR(10),@Fromdate,110)+''' 
					and Lgr.Lgr_Vch_Dt <= '''+CONVERT(VARCHAR(10),@ToDate,110)+''''
					

	IF (@IsCashBank = 'True')
	BEGIN
	SET  @strQuery = @strQuery + ' AND Acc.AM_Calls IS NOT NULL'
	END
	ELSE
	BEGIN
	SET  @strQuery = @strQuery + ' AND Acc.AM_Calls IS NULL'
	END

	SET  @strQuery = @strQuery +' and Acc.AM_ACC_Cd between '''+@AccountFrom+''' and '''+@AccountTo+''''
	SET  @strQuery = @strQuery +' ORDER BY Lgr.Lgr_VCH_Dt,Lgr.Lgr_Vch_Ref_No,Lgr.Lgr_Seq_No ASC'



	EXEC(@strQuery)

END

GO

print'----------------------------------------------------------------------------------------------'

go
ALTER FUNCTION [dbo].[OpeningBalance]
(
@accCode AS NVARCHAR(6),
@vchDate AS DATETIME,
@instType AS VARCHAR(2),
@finYear AS NVARCHAR(4)
)
RETURNS FLOAT
AS
BEGIN
	
DECLARE @FinYearStartDate DateTime;
DECLARE @OpeningBalance FLOAT;
DECLARE @TotalBalance FLOAT;
DECLARE @LedgerBalance FLOAT;
DECLARE @VoucherDateToConsider DateTime;
DECLARE @FinYearStartDateString NVARCHAR(MAX);

SET @FinYearStartDateString='01-04-'+@finYear
SET @FinYearStartDate=CONVERT(DATETIME,@FinYearStartDateString ,105)


DECLARE @SQL NVARCHAR(MAX)
DECLARE @TABLENAME NVARCHAR(MAX)
SET @TABLENAME = @instType+'_Accounts'
SET @SQL = 'SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) 
			FROM '+@TABLENAME+' 
			WHERE AM_Acc_Cd='''+@accCode+''' 
			AND AM_Inst_Typ='''+@instType+''' 
			AND AM_Fin_Yr='''+@finYear+''''
			
EXECUTE sp_executesql @SQL, N'@OpeningBalance FLOAT OUTPUT', @OpeningBalance=@OpeningBalance OUTPUT 

SET @TABLENAME = @instType+'_Ledger'
SET @SQL = 'SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
			FROM '+@TABLENAME+' 
			WHERE Lgr_Acc_Cd='''+@accCode+''' 
			AND Lgr_Inst_Typ='''+@instType+''' 
			AND Lgr_Fin_Yr='''+@finYear+'''
			AND Lgr_Vch_Dt>='''+CONVERT(VARCHAR(11),@FinYearStartDate,105)+'''
			AND Lgr_Vch_Dt<'''+CONVERT(VARCHAR(11),@vchDate,105)+''''
			
EXECUTE sp_executesql @SQL, N'@LedgerBalance FLOAT OUTPUT', @LedgerBalance=@LedgerBalance OUTPUT 

SET @TotalBalance=ISNULL(@OpeningBalance,0)+ISNULL(@LedgerBalance,0);
RETURN @TotalBalance;

END
	
print'--------------------------------------------------------------------------'
go
ALTER PROCEDURE [dbo].[GetVoucherHeaderReportDetails]
		@instType as varchar(2),		
		@VH_Lnk_No as varchar(12),
		@VH_Dbk_Cd as varchar(4),
		@VH_Trn_Typ as varchar(2),
		@VH_Fin_Yr as varchar(4)

AS
BEGIN
declare @strQuery as nvarchar(max);
            set @strQuery = 'Select LTRIM(RTRIM([VH_Vch_Ref_No])) AS [VH_Ref_No]
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
								from  ' + @instType + '_Voucher_Header VH
								LEFT OUTER JOIN User_Master UM1
								ON UM1.Usr_Id=VH.VH_Ent_By
								LEFT OUTER JOIN User_Master UM2
								ON UM2.Usr_Id=VH.VH_Conf_By
								where [VH_Lnk_No]='''+@VH_Lnk_No+''' 
								and [VH_Dbk_Cd]='''+@VH_Dbk_Cd+''' 
								and [VH_Trn_Typ]='''+@VH_Trn_Typ+'''
								and VH_Fin_Yr='''+@VH_Fin_Yr+''''
								
								exec(@strQuery)

END

	go
	
print'--------------------------------------------------------------------------'
go
ALTER PROCEDURE [dbo].[GetVoucherDetailsReportDetails]
		@instType as varchar(2),		
		@VH_Lnk_No as varchar(12),
		@VH_Dbk_Cd as varchar(4),
		@VH_Trn_Typ as varchar(2),
		@VH_Fin_Yr as varchar(4)

AS
BEGIN

declare @strQuery as nvarchar(max);
            set @strQuery = 'Select LTRIM(RTRIM(VD_Acc_Cd)) as [LedgerAccount]
									,LTRIM(RTRIM(ac.Am_Acc_Nm)) as [AccountName]
									,VD_ABS_Amt as [Amount]
									,LTRIM(RTRIM(VD_Cr_Dr)) as [CrDr]
									,LTRIM(RTRIM(VD_Ref_No)) as [RefNo]
									,VD_Ref_Dt as [RefDate]
									,LTRIM(RTRIM(VD_Narr)) as [VoucherDesc]
									,LTRIM(RTRIM(VD_Seq_No)) as [VD_Seq_No] 
							from ' + @instType + '_Voucher_Detail vd 
							Inner Join ' + @instType + '_Accounts ac 
							on vd.VD_Acc_Cd=ac.Am_Acc_Cd  
							where [VD_Lnk_No]='''+@VH_Lnk_No+''' 
							--and [VD_Dbk_Cd]='''+@VH_Dbk_Cd+''' 
							and [VD_Trn_Typ]='''+@VH_Trn_Typ+'''
							and [VD_Fin_Yr]='''+@VH_Fin_Yr+''' 
							ORDER BY [VD_Seq_No] Asc'
								
			exec(@strQuery)
END

go

print'-----------------------------------------------------------'
go
ALTER PROCEDURE dbo.GetAccountDetailsReport
		@AccCode as char(6),
		@InstType as varchar(2),		
		@AM_Fin_Yr as varchar(4)
AS
BEGIN
declare @strQuery as nvarchar(max);
      set @strQuery = 'SELECT [AM_Fin_Yr]
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
  FROM [dbo].[' + @instType + '_Accounts]
  where AM_Acc_Cd='''+@AccCode+'''
  and AM_Fin_Yr='''+@AM_Fin_Yr+''''
								
exec(@strQuery)

END
go

print'-----------------------------------------------------------'
go

ALTER PROCEDURE dbo.GetDaybookDetailsReport
		@DaybookCode as char(4),
		@InstType as varchar(2),		
		@DM_Fin_Yr as varchar(4)
AS
BEGIN
declare @strQuery as nvarchar(max);
      set @strQuery = 'SELECT        
							DM_Fin_Yr
							, DM_Inst_Cd
							, DM_Inst_Typ
							, DM_Brn_Cd
							, DM_Dbk_Cd
							, DM_Dbk_Nm
							, DM_Dbk_Typ
							, DM_Acc_Cd
							, DM_Bnk_Nm
							, DM_Bnk_Brn
							, DM_Bnk_AcNo
							, DM_Bnk_OD
							, DM_Ent_By
							, DM_Ent_Dt
							, DM_Upd_By
							, DM_Upd_Dt
				FROM ' + @instType + '_Daybooks
				where DM_Dbk_Cd='''+@DaybookCode+'''
				and DM_Fin_Yr='''+@DM_Fin_Yr+''''
								
exec(@strQuery)

END


go

print'-----------------------------------------------------------'
go

ALTER PROCEDURE [dbo].[GetInstitutionDetails]
	@instType nvarchar(2)
	,@instCode nvarchar(5)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select Inst_Nm, Inst_Adr from Inst_Master
	where Inst_cd=@instCode
	AND Inst_Typ=@instType
	 
END


go

print'-----------------------------------------------------------'
GO
ALTER PROCEDURE [dbo].[GetTrialBalanceReportDetails] 
	-- Add the parameters for the stored procedure here
	@instType AS NVARCHAR(2),
	@Fromdate AS DATETIME,
	@ToDate AS DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @strQuery AS NVARCHAR(MAX)
	
	SET @strQuery = 'SELECT
					AM_Acc_Nm
					,dbo.OpeningBalanceValue(AM_Acc_Cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,-1,@Fromdate),101)+''','''+@instType+''',AM_Fin_Yr) as OpeningBalance
					,AM_Acc_Cd
					,ISNULL((SELECT SUM(Lgr_ABS_Amt) FROM '+@instType+'_Ledger WHERE Lgr_Vch_Dt >= '''+CONVERT(VARCHAR(10),@Fromdate,110)+''' 
					and Lgr_Vch_Dt <= '''+CONVERT(VARCHAR(10),@ToDate,110)+''' AND Lgr_Acc_Cd=AM_Acc_Cd AND LOWER(Lgr_Cr_Dr)=''cr''),0) AS Credit
					,ISNULL((SELECT SUM(Lgr_ABS_Amt) FROM '+@instType+'_Ledger WHERE Lgr_Vch_Dt >= '''+CONVERT(VARCHAR(10),@Fromdate,110)+''' 
					and Lgr_Vch_Dt <= '''+CONVERT(VARCHAR(10),@ToDate,110)+''' AND Lgr_Acc_Cd=AM_Acc_Cd AND LOWER(Lgr_Cr_Dr)=''dr''),0) AS Debit
					,dbo.OpeningBalanceValue(AM_Acc_Cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,0,@ToDate),101)+''','''+@instType+''',AM_Fin_Yr) as ClosingBalance
				FROM '+@instType+'_Accounts'


	EXEC(@strQuery)

END

GO

print '---------------------------------------------------------------------------------------------------------'
GO

ALTER Procedure [dbo].[CalculateBalance] --'','A00001','02-06-2016','CG','2015'
@lgrCode AS NVARCHAR(2),
@accCode AS NVARCHAR(6),
@vchDate AS DATETIME,
@instType AS NVARCHAR(2),
@finYear AS NVARCHAR(4)
As
Begin

DECLARE @FinYearStartDate DateTime;
DECLARE @OpeningBalance FLOAT;
DECLARE @TotalBalance FLOAT;
DECLARE @LedgerBalance FLOAT;
DECLARE @VoucherDateToConsider DateTime;
DECLARE @FinYearStartDateString NVARCHAR(MAX);

SET @FinYearStartDateString='01-04-'+@finYear
SET @FinYearStartDate=CONVERT(DATETIME,@FinYearStartDateString ,105)

DECLARE @SQL NVARCHAR(MAX)
DECLARE @TABLENAME NVARCHAR(MAX)
SET @TABLENAME = @instType+'_Accounts'
SET @SQL = 'SELECT @OpeningBalance=ISNULL(AM_Opn_Bal,0) 
			FROM '+@TABLENAME+' 
			WHERE AM_Acc_Cd='''+@accCode+''' 
			AND AM_Inst_Typ='''+@instType+''' 
			AND AM_Fin_Yr='''+@finYear+''''
			
EXECUTE sp_executesql @SQL, N'@OpeningBalance FLOAT OUTPUT', @OpeningBalance=@OpeningBalance OUTPUT 

SET @TABLENAME = @instType+'_Ledger'
SET @SQL = 'SELECT @LedgerBalance=SUM(ISNULL(Lgr_Amt,0)) 
			FROM '+@TABLENAME+' 
			WHERE Lgr_Acc_Cd='''+@accCode+''' 
			AND Lgr_Inst_Typ='''+@instType+''' 
			AND Lgr_Fin_Yr='''+@finYear+'''
			AND Lgr_Vch_Dt>='''+CONVERT(VARCHAR(50),@FinYearStartDate)+'''
			AND Lgr_Vch_Dt<='''+CONVERT(VARCHAR(50),@vchDate)+''''
			
EXECUTE sp_executesql @SQL, N'@LedgerBalance FLOAT OUTPUT', @LedgerBalance=@LedgerBalance OUTPUT 

SET @TotalBalance=ISNULL(@OpeningBalance,0)+ISNULL(@LedgerBalance,0);

SELECT ISNULL(@TotalBalance,0) AS 'Total Balance'

END
GO