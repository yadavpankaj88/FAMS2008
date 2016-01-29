go
ALTER FUNCTION dbo.OpeningBalanceValue
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

		IF @instType = 'CG'
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from CG_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from CG_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = 'UR'
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from UR_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from UR_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = 'UP'
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from UP_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from UP_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = 'JR'
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from JR_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from JR_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = 'PG'
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from PG_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from PG_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = 'VO'
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from VO_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from VO_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = 'PO'
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from PO_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from PO_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = 'EN'
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from EN_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from EN_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = 'PP'
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from PP_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from PP_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = 'PR'
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from PR_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from PR_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = 'SE'
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from SE_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from SE_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = 'SO'
		BEGIN
		
		select @opnBalance=AM_Opn_Bal from SO_Accounts where AM_Acc_Cd=@lgrCode

		select @monthAmt=SUM(Lgr_Amt) from SO_Ledger where Lgr_Vch_Dt>= convert(varchar(50),@firstDate) and Lgr_Vch_Dt<= convert(varchar(50),@vchDate)
							and Lgr_Acc_Cd= @lgrCode            

		END
		ELSE IF @instType = 'AB'
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
		set @paddedString=right('0'+ rtrim(convert(varchar(5),@startCount)), 2)

		IF @instType = 'CG'
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = '01' then AM_Net_01
							when @paddedString = '02' then AM_Net_02
							when @paddedString = '03' then AM_Net_03
							when @paddedString = '04' then AM_Net_04
							when @paddedString = '05' then AM_Net_05
							when @paddedString = '06' then AM_Net_06
							when @paddedString = '07' then AM_Net_07
							when @paddedString = '08' then AM_Net_08
							when @paddedString = '09' then AM_Net_09
							when @paddedString = '10' then AM_Net_10
							when @paddedString = '11' then AM_Net_11
							when @paddedString = '12' then AM_Net_12
						end
						FROM CG_Accounts where AM_Acc_Cd=@lgrCode           

		END
		ELSE IF @instType = 'UR'
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = '01' then AM_Net_01
							when @paddedString = '02' then AM_Net_02
							when @paddedString = '03' then AM_Net_03
							when @paddedString = '04' then AM_Net_04
							when @paddedString = '05' then AM_Net_05
							when @paddedString = '06' then AM_Net_06
							when @paddedString = '07' then AM_Net_07
							when @paddedString = '08' then AM_Net_08
							when @paddedString = '09' then AM_Net_09
							when @paddedString = '10' then AM_Net_10
							when @paddedString = '11' then AM_Net_11
							when @paddedString = '12' then AM_Net_12
						end
						FROM UR_Accounts where AM_Acc_Cd=@lgrCode            

		END
		ELSE IF @instType = 'UP'
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = '01' then AM_Net_01
							when @paddedString = '02' then AM_Net_02
							when @paddedString = '03' then AM_Net_03
							when @paddedString = '04' then AM_Net_04
							when @paddedString = '05' then AM_Net_05
							when @paddedString = '06' then AM_Net_06
							when @paddedString = '07' then AM_Net_07
							when @paddedString = '08' then AM_Net_08
							when @paddedString = '09' then AM_Net_09
							when @paddedString = '10' then AM_Net_10
							when @paddedString = '11' then AM_Net_11
							when @paddedString = '12' then AM_Net_12
						end
						FROM UP_Accounts where AM_Acc_Cd=@lgrCode            

		END
		ELSE IF @instType = 'JR'
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = '01' then AM_Net_01
							when @paddedString = '02' then AM_Net_02
							when @paddedString = '03' then AM_Net_03
							when @paddedString = '04' then AM_Net_04
							when @paddedString = '05' then AM_Net_05
							when @paddedString = '06' then AM_Net_06
							when @paddedString = '07' then AM_Net_07
							when @paddedString = '08' then AM_Net_08
							when @paddedString = '09' then AM_Net_09
							when @paddedString = '10' then AM_Net_10
							when @paddedString = '11' then AM_Net_11
							when @paddedString = '12' then AM_Net_12
						end
						FROM JR_Accounts where AM_Acc_Cd=@lgrCode           

		END
		ELSE IF @instType = 'PG'
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = '01' then AM_Net_01
							when @paddedString = '02' then AM_Net_02
							when @paddedString = '03' then AM_Net_03
							when @paddedString = '04' then AM_Net_04
							when @paddedString = '05' then AM_Net_05
							when @paddedString = '06' then AM_Net_06
							when @paddedString = '07' then AM_Net_07
							when @paddedString = '08' then AM_Net_08
							when @paddedString = '09' then AM_Net_09
							when @paddedString = '10' then AM_Net_10
							when @paddedString = '11' then AM_Net_11
							when @paddedString = '12' then AM_Net_12
						end
						FROM PG_Accounts where AM_Acc_Cd=@lgrCode            

		END
		ELSE IF @instType = 'VO'
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = '01' then AM_Net_01
							when @paddedString = '02' then AM_Net_02
							when @paddedString = '03' then AM_Net_03
							when @paddedString = '04' then AM_Net_04
							when @paddedString = '05' then AM_Net_05
							when @paddedString = '06' then AM_Net_06
							when @paddedString = '07' then AM_Net_07
							when @paddedString = '08' then AM_Net_08
							when @paddedString = '09' then AM_Net_09
							when @paddedString = '10' then AM_Net_10
							when @paddedString = '11' then AM_Net_11
							when @paddedString = '12' then AM_Net_12
						end
						FROM VO_Accounts where AM_Acc_Cd=@lgrCode 
		END
		ELSE IF @instType = 'PO'
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = '01' then AM_Net_01
							when @paddedString = '02' then AM_Net_02
							when @paddedString = '03' then AM_Net_03
							when @paddedString = '04' then AM_Net_04
							when @paddedString = '05' then AM_Net_05
							when @paddedString = '06' then AM_Net_06
							when @paddedString = '07' then AM_Net_07
							when @paddedString = '08' then AM_Net_08
							when @paddedString = '09' then AM_Net_09
							when @paddedString = '10' then AM_Net_10
							when @paddedString = '11' then AM_Net_11
							when @paddedString = '12' then AM_Net_12
						end
						FROM PO_Accounts where AM_Acc_Cd=@lgrCode            

		END
		ELSE IF @instType = 'EN'
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = '01' then AM_Net_01
							when @paddedString = '02' then AM_Net_02
							when @paddedString = '03' then AM_Net_03
							when @paddedString = '04' then AM_Net_04
							when @paddedString = '05' then AM_Net_05
							when @paddedString = '06' then AM_Net_06
							when @paddedString = '07' then AM_Net_07
							when @paddedString = '08' then AM_Net_08
							when @paddedString = '09' then AM_Net_09
							when @paddedString = '10' then AM_Net_10
							when @paddedString = '11' then AM_Net_11
							when @paddedString = '12' then AM_Net_12
						end
						FROM EN_Accounts where AM_Acc_Cd=@lgrCode          

		END
		ELSE IF @instType = 'PP'
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = '01' then AM_Net_01
							when @paddedString = '02' then AM_Net_02
							when @paddedString = '03' then AM_Net_03
							when @paddedString = '04' then AM_Net_04
							when @paddedString = '05' then AM_Net_05
							when @paddedString = '06' then AM_Net_06
							when @paddedString = '07' then AM_Net_07
							when @paddedString = '08' then AM_Net_08
							when @paddedString = '09' then AM_Net_09
							when @paddedString = '10' then AM_Net_10
							when @paddedString = '11' then AM_Net_11
							when @paddedString = '12' then AM_Net_12
						end
						FROM PP_Accounts where AM_Acc_Cd=@lgrCode           

		END
		ELSE IF @instType = 'PR'
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = '01' then AM_Net_01
							when @paddedString = '02' then AM_Net_02
							when @paddedString = '03' then AM_Net_03
							when @paddedString = '04' then AM_Net_04
							when @paddedString = '05' then AM_Net_05
							when @paddedString = '06' then AM_Net_06
							when @paddedString = '07' then AM_Net_07
							when @paddedString = '08' then AM_Net_08
							when @paddedString = '09' then AM_Net_09
							when @paddedString = '10' then AM_Net_10
							when @paddedString = '11' then AM_Net_11
							when @paddedString = '12' then AM_Net_12
						end
						FROM PR_Accounts where AM_Acc_Cd=@lgrCode            

		END
		ELSE IF @instType = 'SE'
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = '01' then AM_Net_01
							when @paddedString = '02' then AM_Net_02
							when @paddedString = '03' then AM_Net_03
							when @paddedString = '04' then AM_Net_04
							when @paddedString = '05' then AM_Net_05
							when @paddedString = '06' then AM_Net_06
							when @paddedString = '07' then AM_Net_07
							when @paddedString = '08' then AM_Net_08
							when @paddedString = '09' then AM_Net_09
							when @paddedString = '10' then AM_Net_10
							when @paddedString = '11' then AM_Net_11
							when @paddedString = '12' then AM_Net_12
						end
						FROM SE_Accounts where AM_Acc_Cd=@lgrCode           

		END
		ELSE IF @instType = 'SO'
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = '01' then AM_Net_01
							when @paddedString = '02' then AM_Net_02
							when @paddedString = '03' then AM_Net_03
							when @paddedString = '04' then AM_Net_04
							when @paddedString = '05' then AM_Net_05
							when @paddedString = '06' then AM_Net_06
							when @paddedString = '07' then AM_Net_07
							when @paddedString = '08' then AM_Net_08
							when @paddedString = '09' then AM_Net_09
							when @paddedString = '10' then AM_Net_10
							when @paddedString = '11' then AM_Net_11
							when @paddedString = '12' then AM_Net_12
						end
						FROM SO_Accounts where AM_Acc_Cd=@lgrCode         

		END
		ELSE IF @instType = 'AB'
		BEGIN
		
		SELECT @queryOut = case 
							when @paddedString = '01' then AM_Net_01
							when @paddedString = '02' then AM_Net_02
							when @paddedString = '03' then AM_Net_03
							when @paddedString = '04' then AM_Net_04
							when @paddedString = '05' then AM_Net_05
							when @paddedString = '06' then AM_Net_06
							when @paddedString = '07' then AM_Net_07
							when @paddedString = '08' then AM_Net_08
							when @paddedString = '09' then AM_Net_09
							when @paddedString = '10' then AM_Net_10
							when @paddedString = '11' then AM_Net_11
							when @paddedString = '12' then AM_Net_12
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
go

print'----------------------------------------------------------------------------------------------'
go
ALTER PROCEDURE [dbo].[GetCashBankReportDetails]
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
	

	set @strQuery = 'SELECT 
					VH.VH_acc_cd, 
					dbo.OpeningBalanceValue(VH.VH_acc_cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,-1,@Fromdate),101)+''','''+@instType+''') as OpeningBalance,
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
					dbo.OpeningBalanceValue(VH.VH_acc_cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,0,@ToDate),101)+''','''+@instType+''') as ClosingBalance
					FROM '+@instType+'_Voucher_Detail AS VD 
	INNER JOIN		'+@instType+'_Voucher_Header AS VH 
	ON				VD.VD_Vch_Ref_No = VH.VH_Vch_Ref_No 
	LEFT OUTER JOIN	'+@instType+'_Accounts AS Acc 
	ON				VD.VD_Acc_Cd = Acc.AM_Acc_Cd
	WHERE			VH.VH_Dbk_Cd = '''+@VH_Dbk_Cd+''' AND VH.VH_Vch_No IS NOT NULL and VH.VH_Vch_Dt >= '''+CONVERT(VARCHAR(10),@Fromdate,110)+''' and VH.VH_Vch_Dt <= '''+CONVERT(VARCHAR(10),@ToDate,110)+'''
	ORDER BY		VD.VD_Lnk_No ASC'

	exec(@strQuery)

END
go
print'----------------------------------------------------------------------------------------------'
go
ALTER PROCEDURE [dbo].[GetGeneralLedgerReportDetails]
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

	set @strQuery = 'SELECT		Acc.AM_ACC_Nm,
								dbo.OpeningBalanceValue(Lgr.Lgr_Acc_cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,-1,@Fromdate),101)+''','''+@instType+''') as OpeningBalance,
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
								,dbo.OpeningBalanceValue(Lgr.Lgr_Acc_Cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,0,@ToDate),101)+''','''+@instType+''') as ClosingBalance
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

	exec(@strQuery)

END

go


print'----------------------------------------------------------------------------------------------'
go
ALTER PROCEDURE [dbo].[GetTrialBalanceReportDetails]
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
	
set @strQuery = 'SELECT
				AM_Acc_Nm
				,dbo.OpeningBalanceValue(AM_Acc_Cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,-1,@Fromdate),101)+''','''+@instType+''') as OpeningBalance
				,AM_Acc_Cd
				,ISNULL((SELECT SUM(Lgr_Amt) FROM '+@instType+'_Ledger WHERE Lgr_Vch_Dt >= '''+CONVERT(VARCHAR(10),@Fromdate,110)+''' 
				and Lgr_Vch_Dt <= '''+CONVERT(VARCHAR(10),@ToDate,110)+''' AND Lgr_Acc_Cd=AM_Acc_Cd AND LOWER(Lgr_Cr_Dr)=''cr''),0) AS Credit
				,ISNULL((SELECT SUM(Lgr_Amt) FROM '+@instType+'_Ledger WHERE Lgr_Vch_Dt >= '''+CONVERT(VARCHAR(10),@Fromdate,110)+''' 
				and Lgr_Vch_Dt <= '''+CONVERT(VARCHAR(10),@ToDate,110)+''' AND Lgr_Acc_Cd=AM_Acc_Cd AND LOWER(Lgr_Cr_Dr)=''dr''),0) AS Debit
				,dbo.OpeningBalanceValue(AM_Acc_Cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,0,@ToDate),101)+''','''+@instType+''') as ClosingBalance
			FROM '+@instType+'_Accounts'

	exec(@strQuery)

END

go
print'----------------------------------------------------------------------------------------------'
go
ALTER FUNCTION dbo.OpeningBalance
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

set @opnQuery='select @obal=AM_Opn_Bal from '+@instType+'_Accounts where AM_Acc_Cd='''+@lgrCode+''''

EXECUTE sp_executesql @opnQuery, N'@obal money OUTPUT', @obal=@opnBalance OUTPUT                  

declare @monthAmt as money
declare @monthQuery as nvarchar(max)
set @monthQuery='select @mthAmt=SUM(Lgr_Amt) from '+@instType+'_Ledger where Lgr_Vch_Dt>='''+convert(varchar(50),@firstDate)+''' and Lgr_Vch_Dt<='''+convert(varchar(50),@vchDate)+'''
                  and Lgr_Acc_Cd='''+@lgrCode+'''' 
                  
EXECUTE sp_executesql @monthQuery, N'@mthAmt money OUTPUT', @mthAmt=@monthAmt OUTPUT                  


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

 set @strQuery='select @bal=AM_Net_'+@paddedString+' from '+@instType+'_Accounts where AM_Acc_Cd='''+@lgrCode+''''
 EXECUTE sp_executesql @strQuery, N'@bal money OUTPUT', @bal=@queryOut OUTPUT
 
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
	go
	
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
							and [VD_Dbk_Cd]='''+@VH_Dbk_Cd+''' 
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
go
ALTER PROCEDURE [dbo].[GetTrialBalanceReportDetails] 
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
	
set @strQuery = 'SELECT
				AM_Acc_Nm
				,dbo.OpeningBalanceValue(AM_Acc_Cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,-1,@Fromdate),101)+''','''+@instType+''') as OpeningBalance
				,AM_Acc_Cd
				,ISNULL((SELECT SUM(Lgr_ABS_Amt) FROM '+@instType+'_Ledger WHERE Lgr_Vch_Dt >= '''+CONVERT(VARCHAR(10),@Fromdate,110)+''' 
				and Lgr_Vch_Dt <= '''+CONVERT(VARCHAR(10),@ToDate,110)+''' AND Lgr_Acc_Cd=AM_Acc_Cd AND LOWER(Lgr_Cr_Dr)=''cr''),0) AS Credit
				,ISNULL((SELECT SUM(Lgr_ABS_Amt) FROM '+@instType+'_Ledger WHERE Lgr_Vch_Dt >= '''+CONVERT(VARCHAR(10),@Fromdate,110)+''' 
				and Lgr_Vch_Dt <= '''+CONVERT(VARCHAR(10),@ToDate,110)+''' AND Lgr_Acc_Cd=AM_Acc_Cd AND LOWER(Lgr_Cr_Dr)=''dr''),0) AS Debit
				,dbo.OpeningBalanceValue(AM_Acc_Cd,'''+CONVERT(VARCHAR(25),DATEADD(DAY,0,@ToDate),101)+''','''+@instType+''') as ClosingBalance
			FROM '+@instType+'_Accounts'


	exec(@strQuery)

END

go