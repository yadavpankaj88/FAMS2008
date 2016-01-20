Imports System.Data.SqlClient
Imports System.Text

Public Class LedgerAccountHelper

    Dim dataHelper As New DataHelper

    Private Function AddLedgerAccount(pAcc As DataTable) As Boolean

        Dim pCommands As New List(Of SqlCommand)
        Try
            If pAcc IsNot Nothing Then
                For row As Integer = 0 To pAcc.Rows.Count - 1
                    Dim upsertAccountCommand As New SqlCommand
                    upsertAccountCommand.CommandType = CommandType.Text
                    upsertAccountCommand.CommandText = "if ((select count(*) from " + InstitutionMasterData.XInstType + "_Accounts where AM_Acc_Cd=@AccCode and AM_Inst_Cd=@InstitutionCode and AM_Inst_Typ=@InstType and AM_Fin_Yr=@finYear)=0)" + _
                        " Begin " + _
                        "INSERT INTO " + InstitutionMasterData.XInstType + "_Accounts([AM_Fin_Yr] ,[AM_Inst_Cd],[AM_Inst_Typ],[AM_Lgr_Cd],[AM_Acc_Cd],[AM_Acc_Nm],[AM_Opn_Bal],[AM_OB_Cr_Dr],[AM_ABS_Opn_Bal],[AM_LLY_Budg],[AM_LLY_Actu],[AM_LYr_Budg],[AM_LYr_Actu],[AM_Cyr_Budg],[AM_Ent_By],[AM_Ent_Dt],[AM_Upd_By],[AM_Upd_Dt])" + _
                        " VALUES (@finYear, @InstitutionCode, @InstType,'00', @AccCode, @AccName,@AccOpenBal,@AccOB_CR_DR,@AccABSOpenBal,@AccLLYBud,@AccLLYAct,@AccLYBud,@AccLYAct,@AccCYBud,@createBy,@createdOn,@updatedBy,@updatedOn)" + _
                        " end " + _
                        " else begin" + _
                        " UPDATE " + InstitutionMasterData.XInstType + "_Accounts" + _
                        " SET [AM_Acc_Nm] = @AccName,[AM_Opn_Bal] = @AccOpenBal,[AM_OB_Cr_Dr] = @AccOB_CR_DR ,[AM_ABS_Opn_Bal] = @AccABSOpenBal,[AM_LLY_Budg] = @AccLLYBud,[AM_LLY_Actu] = @AccLLYAct,[AM_LYr_Budg] = @AccLYBud," + _
                        "[AM_LYr_Actu] = @AccLYAct,[AM_Cyr_Budg] = @AccCYBud,[AM_Upd_By] = @updatedBy,[AM_Upd_Dt] = @updatedOn " + _
                        "where AM_Acc_Cd=@AccCode and AM_Inst_Cd=@InstitutionCode and AM_Inst_Typ=@InstType and AM_Fin_Yr=@finYear" + _
                        " end"


                    upsertAccountCommand.Parameters.AddWithValue("@finYear", InstitutionMasterData.XFinYr)
                    upsertAccountCommand.Parameters.AddWithValue("@InstitutionCode", InstitutionMasterData.XInstCode)
                    upsertAccountCommand.Parameters.AddWithValue("@InstType", InstitutionMasterData.XInstType)
                    upsertAccountCommand.Parameters.AddWithValue("@AccCode", pAcc.Rows(row)("AM_Acc_Cd").ToString().Trim)
                    upsertAccountCommand.Parameters.AddWithValue("@AccName", pAcc.Rows(row)("AM_Acc_Nm").ToString().Trim)

                    If Not pAcc.Rows(row)("AM_ABS_Opn_Bal").ToString() Is String.Empty Then
                        If (pAcc.Rows(row)("AM_OB_Cr_Dr").ToString().Equals("CR")) Then
                            upsertAccountCommand.Parameters.AddWithValue("@AccOpenBal", -Convert.ToDouble(pAcc.Rows(row)("AM_ABS_Opn_Bal").ToString()))
                        Else
                            upsertAccountCommand.Parameters.AddWithValue("@AccOpenBal", Convert.ToDouble(pAcc.Rows(row)("AM_ABS_Opn_Bal").ToString()))
                        End If

                        upsertAccountCommand.Parameters.AddWithValue("@AccABSOpenBal", Math.Abs(Convert.ToDouble(pAcc.Rows(row)("AM_ABS_Opn_Bal").ToString())))

                    Else
                        upsertAccountCommand.Parameters.AddWithValue("@AccOpenBal", DBNull.Value)
                        upsertAccountCommand.Parameters.AddWithValue("@AccABSOpenBal", DBNull.Value)

                    End If

                    upsertAccountCommand.Parameters.AddWithValue("@AccOB_CR_DR", pAcc.Rows(row)("AM_OB_Cr_Dr").ToString())
                    upsertAccountCommand.Parameters.AddWithValue("@AccLLYBud", pAcc.Rows(row)("AM_LLY_Budg"))
                    upsertAccountCommand.Parameters.AddWithValue("@AccLLYAct", pAcc.Rows(row)("AM_LLY_Actu"))
                    upsertAccountCommand.Parameters.AddWithValue("@AccLYBud", pAcc.Rows(row)("AM_LYr_Budg"))
                    upsertAccountCommand.Parameters.AddWithValue("@AccLYAct", pAcc.Rows(row)("AM_LYr_Actu"))
                    upsertAccountCommand.Parameters.AddWithValue("@AccCYBud", pAcc.Rows(row)("AM_Cyr_Budg"))
                    upsertAccountCommand.Parameters.AddWithValue("@createBy", "CG")
                    upsertAccountCommand.Parameters.AddWithValue("@createdOn", DateTime.Now)
                    upsertAccountCommand.Parameters.AddWithValue("@updatedBy", "CG")
                    upsertAccountCommand.Parameters.AddWithValue("@updatedOn", DateTime.Now)
                    pCommands.Add(upsertAccountCommand)

                Next
                dataHelper.ExecuteQueryTransaction(pCommands)
            End If

        Catch ex As Exception
            Throw
        End Try

        Return True
    End Function

    Function GetAccountDetails(pAccCode As String, Optional pNotLinked As Boolean = False) As DataTable

        Dim query As StringBuilder
        Try
            query = New StringBuilder()
            If String.IsNullOrEmpty(pAccCode) Then
                query.Append(String.Format("SELECT [AM_Fin_Yr],[AM_Inst_Cd],[AM_Inst_Typ],[AM_Brn_Cd],[AM_Lgr_Cd],[AM_Acc_Cd],Ltrim(Rtrim([AM_Acc_Nm])) as AM_Acc_Nm,[AM_Calls],[AM_Opn_Bal],[AM_OB_Cr_Dr],[AM_ABS_Opn_Bal],[AM_LLY_Budg],[AM_LLY_Actu],[AM_LYr_Budg],[AM_LYr_Actu],[AM_Cyr_Budg],[AM_Ent_By]" + _
                ",[AM_Ent_Dt],[AM_Upd_By],[AM_Upd_Dt] FROM " + InstitutionMasterData.XInstType + "_Accounts where AM_Inst_Cd='{0}' and AM_Inst_Typ='{1}' and AM_Fin_Yr='{2}'", InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr))
            Else
                query.Append(String.Format("SELECT [AM_Fin_Yr],[AM_Inst_Cd],[AM_Inst_Typ],[AM_Brn_Cd],[AM_Lgr_Cd],[AM_Acc_Cd],Ltrim(Rtrim([AM_Acc_Nm])) as AM_Acc_Nm,[AM_Calls],[AM_Opn_Bal],[AM_OB_Cr_Dr],[AM_ABS_Opn_Bal],[AM_LLY_Budg],[AM_LLY_Actu],[AM_LYr_Budg],[AM_LYr_Actu],[AM_Cyr_Budg],[AM_Ent_By]" + _
                     ",[AM_Ent_Dt],[AM_Upd_By],[AM_Upd_Dt] FROM " + InstitutionMasterData.XInstType + "_Accounts  where AM_Acc_Cd='{0}' and AM_Inst_Cd='{1}' and AM_Inst_Typ='{2}' and AM_Fin_Yr='{3}'", pAccCode, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr))
            End If

            If pNotLinked Then
                query.Append(" and AM_Calls is null order by [AM_Acc_Nm]")
            Else
                query.Append(" order by [AM_Acc_Cd]")
            End If

            Return dataHelper.ExecuteQuery(query.ToString, CommandType.Text, Nothing)
        Catch ex As Exception
            Throw
        End Try

    End Function

    Function GetTransactionCount(pAccCode As String, pDayBookCode As String) As Integer
        Dim query As String
        Dim count As Integer
        Try


            query = String.Format("SELECT count(*) from {0}_Voucher_Header where VH_Fin_Yr='{1}' and VH_Inst_Cd='{2}' and VH_Inst_Typ='{3}'" + _
                                  " and VH_Acc_Cd='{4}' and VH_Dbk_Cd='{5}'", InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, pAccCode, pDayBookCode)

            Int32.TryParse(dataHelper.ExecuteScalar(query, CommandType.Text, Nothing), count)
            Return count
        Catch ex As Exception
            Throw
        End Try

    End Function

    Function SaveData(pAcc As DataTable) As Boolean
        Dim dtAdded As DataTable = pAcc.GetChanges(DataRowState.Added)
        Dim dtModified As DataTable = pAcc.GetChanges(DataRowState.Modified)
        Try
            If dtAdded IsNot Nothing Then
                AddLedgerAccount(dtAdded)
            Else
                AddLedgerAccount(dtModified)
            End If
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function

    Sub DeleteAccount(pAccCode As String)
        Try
            dataHelper.ExecuteNonQuery(String.Format("Delete from " + InstitutionMasterData.XInstType + "_Accounts where AM_Acc_Cd='{0}' and AM_Inst_Cd='{1}' and AM_Inst_Typ='{2}' and AM_Fin_Yr={3}", pAccCode, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr), CommandType.Text)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Function IsAccountLinked(pAccountCode As String, pDaybookcode As String) As Boolean
        Dim count As Integer
        Dim query As String = String.Format("Select AM_Acc_Cd,AM_Calls from {0}_Accounts where AM_Inst_Cd='{1}' and AM_Inst_Typ='{2}' " + _
                                            "and AM_Fin_Yr='{3}' and AM_Acc_Cd='{4}'", InstitutionMasterData.XInstType, InstitutionMasterData.XInstCode,
                                    InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr, pAccountCode.Trim)
        Dim dtAccount As DataTable
        Try
            dtAccount = dataHelper.ExecuteQuery(query, CommandType.Text, Nothing)
            If dtAccount.Rows.Count > 0 Then
                Dim selectedAccount, selectedDaybook As String
                selectedAccount = dtAccount.Rows(0)("AM_Acc_Cd").ToString
                selectedDaybook = dtAccount.Rows(0)("AM_Calls").ToString

                'If selectedDaybook.Equals(pDaybookcode) Then
                '    Return False
                'Else
                '    Return True
                'End If

                If String.IsNullOrEmpty(selectedDaybook) Then
                    Return False
                Else
                    Return True
                End If
            End If
            Return count
        Catch ex As Exception
            Throw
        End Try
    End Function

    Function GetBalance(Optional pDate? As DateTime = Nothing, Optional pDaybookcode As String = "") As Double
        Dim query As String
        Dim dtAcc As DataTable
        Dim dtBalance As DataTable
        Try
            Dim parameters As New Dictionary(Of String, Object)()

            If Not String.IsNullOrEmpty(pDaybookcode) Then
                query = "Select DM_Acc_Cd from  " + InstitutionMasterData.XInstType + "_Daybooks where DM_Dbk_Cd='" + pDaybookcode + "'"
                dtAcc = dataHelper.ExecuteQuery(query, CommandType.Text, Nothing)
            Else
                query = "Select DM_Acc_Cd from  " + InstitutionMasterData.XInstType + "_Daybooks where DM_Dbk_Typ='C'"
                dtAcc = dataHelper.ExecuteQuery(query, CommandType.Text, Nothing)
            End If

            If dtAcc.Rows.Count > 0 Then
                query = "CalculateBalance"
                parameters.Add("@lgrCode", dtAcc.Rows(0)("DM_Acc_Cd").ToString())

                If pDate.HasValue Then
                    parameters.Add("@vchDate", pDate.Value.Date)
                Else
                    parameters.Add("@vchDate", InstitutionMasterData.XDate.Date.ToString("yyyy-MM-dd"))
                End If
                parameters.Add("@instType", InstitutionMasterData.XInstType)

                dtBalance = dataHelper.ExecuteQuery(query, CommandType.StoredProcedure, parameters)
                If dtBalance.Rows.Count > 0 Then
                    Return Convert.ToDouble(dtBalance.Rows(0)("Total Balance"))
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
        Return 0
    End Function

End Class
