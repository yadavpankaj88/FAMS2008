Imports System.Data.SqlClient
Imports System.Text

Public Class DayBooksHelper
    Public Function SaveDaybooks(ByVal daybook As Daybooks)
        Try
            Dim dataHelper As New DataHelper
            'dataHelper.CreateConnection()
            Dim saveQuery As String
            saveQuery = "If((Select COUNT('x') from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Dbk_Cd=@dbkcd and DM_Fin_Yr=@finYear and DM_Inst_Cd=@instCode and DM_Inst_Typ=@instTyp)=0)" _
                            & " Begin " _
                            & " Insert into " + InstitutionMasterData.XInstType + "_Daybooks(DM_Fin_Yr,DM_Inst_Cd,DM_Inst_Typ,DM_Brn_Cd,DM_Dbk_Cd,DM_Dbk_Nm,DM_Dbk_Typ,DM_Acc_Cd,DM_Bnk_Nm,DM_Bnk_Brn,DM_Bnk_AcNo,DM_Bnk_OD,DM_Ent_By,DM_Ent_Dt) " _
                            & " values(@finYear,@instCode,@instTyp,@brnCd,@dbkcd,@dbkNm,@dbkTyp,@acccd,@bnkNm,@bnkBrn,@bnkAcNo,@bnkOd,@EntBy, GetDate())" _
                            & " UPDATE " + InstitutionMasterData.XInstType + "_Accounts SET AM_Calls=@dbkcd WHERE AM_Acc_Cd=@acccd AND AM_Inst_Typ='" + InstitutionMasterData.XInstType + "' AND AM_Inst_Cd='" + InstitutionMasterData.XInstCode + "' AND AM_Fin_Yr='" + InstitutionMasterData.XFinYr + "'" _
                            & " End" _
                            & " Else BEGIN" _
                            & " Update " + InstitutionMasterData.XInstType + "_Daybooks" _
                            & " Set DM_Acc_Cd=@acccd ,DM_Dbk_Typ=@dbkTyp,DM_Bnk_Brn=@bnkBrn,DM_Dbk_Nm=@dbkNm,DM_Bnk_AcNo=@bnkAcNo,DM_Bnk_Nm=@bnkNm,DM_Bnk_OD=@bnkOd,DM_Upd_By=@UpdateBy,DM_Upd_Dt=GetDate()" _
                            & " Where DM_Dbk_Cd=@dbkcd and DM_Fin_Yr=@finYear and DM_Inst_Cd=@instCode and DM_Inst_Typ=@instTyp" _
                            & " UPDATE " + InstitutionMasterData.XInstType + "_Accounts SET AM_Calls=@dbkcd WHERE AM_Acc_Cd=@acccd AND AM_Inst_Typ='" + InstitutionMasterData.XInstType + "' AND AM_Inst_Cd='" + InstitutionMasterData.XInstCode + "' AND AM_Fin_Yr='" + InstitutionMasterData.XFinYr + "'" _
                            & " End"

            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@finYear", daybook.DMFinYear)
            parameters.Add("@instCode", daybook.DMInstCd)
            parameters.Add("@instTyp", daybook.DMInstTyp)
            parameters.Add("@brnCd", daybook.DMBranchCode)
            parameters.Add("@dbkcd", daybook.DMDaybookCode)
            parameters.Add("@dbkNm", daybook.DMDaybookName)
            parameters.Add("@dbkTyp", daybook.DMDaybookType)
            parameters.Add("@acccd", daybook.DMAccountCode)
            parameters.Add("@bnkNm", daybook.DMBankName)
            parameters.Add("@bnkBrn", daybook.DMBankBranch)
            parameters.Add("@bnkAcNo", daybook.DMBankAccNo)
            parameters.Add("@bnkOd", daybook.DMBankOD)
            parameters.Add("@EntBy", InstitutionMasterData.XUsrId)
            parameters.Add("@UpdateBy", InstitutionMasterData.XUsrId)
            dataHelper.ExecuteNonQuery(saveQuery, CommandType.Text, parameters)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetDaybooks() As DataTable
        Dim daybooksDT As New DataTable
        Dim datahelper As New DataHelper
        'datahelper.CreateConnection()
        Dim query As String = String.Format("Select * from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Fin_Yr ='{0}' and DM_Inst_Cd='{1}' and DM_Inst_Typ='{2}' " + _
                                            "order by DM_Ent_Dt desc", InstitutionMasterData.XFinYr, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType)
        daybooksDT = datahelper.ExecuteQuery(query, CommandType.Text)
        Return daybooksDT
    End Function

    Public Function GetDaybooksByCode(ByVal daybookCode As String) As DataTable
        Dim daybooksDT As New DataTable
        Dim datahelper As New DataHelper
        'datahelper.CreateConnection()
        Dim query As String = String.Format("Select * from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Fin_Yr ='{0}' and DM_Inst_Cd='{1}' and DM_Inst_Typ='{2}' " + _
                                            "and DM_Dbk_Cd='{3}' order by DM_Ent_Dt desc", InstitutionMasterData.XFinYr, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, daybookCode)
        daybooksDT = datahelper.ExecuteQuery(query, CommandType.Text)
        Return daybooksDT
    End Function

    Public Sub Delete(ByVal daybookCode As String)
        Dim datahelper As New DataHelper
        Dim query As String = String.Format("delete from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Fin_Yr ='{0}' and DM_Inst_Cd='{1}' and DM_Inst_Typ='{2}' " + _
                                            "and DM_Dbk_Cd='{3}'", InstitutionMasterData.XFinYr, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, daybookCode)
        datahelper.ExecuteNonQuery(query, CommandType.Text)
    End Sub

    Public Function GetDaybooksByType(ByVal daybookType As String, Optional ByVal isContra As Boolean = False) As DataTable
        Dim daybooksDT As New DataTable
        Dim datahelper As New DataHelper
        Dim query As String
        'datahelper.CreateConnection()
        If Not isContra Then
            query = String.Format("Select LTRIM(RTRIM(DM_Dbk_Nm)) as 'DM_Dbk_Nm',LTRIM(RTRIM(DM_Dbk_Cd)) as 'DM_Dbk_Cd',LTRIM(RTRIM(DM_Acc_Cd)) AS DM_Acc_Cd,RTRIM(LTRIM(DM_Dbk_Cd))+' - '+RTRIM(LTRIM(DM_Dbk_Nm))+' - '+RTRIM(LTRIM(DM_Acc_Cd)) as 'DisplayName' from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Fin_Yr ='{0}' and " + _
                                              "DM_Inst_Cd='{1}' and DM_Inst_Typ='{2}' and DM_Dbk_Typ='{3}' " + _
                                              "order by DM_Ent_Dt desc", InstitutionMasterData.XFinYr, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, daybookType)
        Else
            query = String.Format("Select LTRIM(RTRIM(DM_Dbk_Nm)) as 'DM_Dbk_Nm',LTRIM(RTRIM(DM_Dbk_Cd)) as 'DM_Dbk_Cd',LTRIM(RTRIM(DM_Acc_Cd)) AS DM_Acc_Cd,DM_Dbk_Typ,RTRIM(LTRIM(DM_Dbk_Cd))+' - '+RTRIM(LTRIM(DM_Dbk_Nm))+' - '+RTRIM(LTRIM(DM_Acc_Cd)) as 'DisplayName' from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Fin_Yr ='{0}' and " + _
                                              "DM_Inst_Cd='{1}' and DM_Inst_Typ='{2}'" + _
                                              "order by DM_Ent_Dt desc", InstitutionMasterData.XFinYr, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType)
        End If

        daybooksDT = datahelper.ExecuteQuery(query, CommandType.Text)
        Return daybooksDT
    End Function

    Public Function GetDaybooksDetails(ByVal dbk_cd As String) As DataTable
        Dim daybooksDT As New DataTable
        Dim datahelper As New DataHelper
        'datahelper.CreateConnection()
        Dim query As String = String.Format("Select LTRIM(RTRIM([DM_Dbk_Typ])) as [DM_Dbk_Typ],LTRIM(RTRIM([DM_Acc_Cd])) as [DM_Acc_Cd],LTRIM(RTRIM([DM_Dbk_Nm])) as [DM_Dbk_Nm],LTRIM(RTRIM([DM_Bnk_Nm])) as [DM_Bnk_Nm],LTRIM(RTRIM([DM_Bnk_Brn])) as [DM_Bnk_Brn],LTRIM(RTRIM([DM_Bnk_AcNo])) as [DM_Bnk_AcNo], [DM_Bnk_OD] from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Dbk_Cd='{0}'", dbk_cd)
        daybooksDT = datahelper.ExecuteQuery(query, CommandType.Text)
        Return daybooksDT
    End Function

    Function CheckDaybookCd(ByVal DaybookID As String) As DataTable
        Dim query As StringBuilder
        Dim datahelper As New DataHelper
        Try
            query = New StringBuilder()
            If String.IsNullOrEmpty(DaybookID) Then
                query.Append(String.Format("select LTRIM(RTRIM([DM_Dbk_Cd])) as DaybookCode,LTRIM(RTRIM([DM_Dbk_Nm])) as DaybookName from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Inst_Cd='{0}' and DM_Inst_Typ='{1}' and DM_Fin_Yr='{2}' ", InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr))
            Else
                query.Append(String.Format("select LTRIM(RTRIM([DM_Dbk_Cd])) as DaybookCode,LTRIM(RTRIM([DM_Dbk_Nm])) as DaybookName from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Inst_Cd='{0}' and DM_Inst_Typ='{1}' and DM_Fin_Yr='{2}' and DM_Dbk_Cd like  '%" & DaybookID & "%' ", InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr))
            End If
            Return datahelper.ExecuteQuery(query.ToString, CommandType.Text)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Function GetCount(ByVal DaybookCode As String) As Integer
        Dim query As StringBuilder
        Dim datahelper As New DataHelper
        Try
            query = New StringBuilder()
            query.Append(String.Format("select count(*) from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Dbk_Cd='" + DaybookCode + "' and DM_Inst_Cd= '" + InstitutionMasterData.XInstCode + "' and DM_Inst_Typ='" + InstitutionMasterData.XInstType + "' and DM_Fin_Yr='" + InstitutionMasterData.XFinYr + "'"))
            Return datahelper.ExecuteScalar(query.ToString, CommandType.Text, Nothing)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub UpdateAccCode(ByVal AccountCode As String)
        Dim datahelper As New DataHelper
        Dim query As String = String.Format(" UPDATE " + InstitutionMasterData.XInstType + "_Accounts SET AM_Calls= 'NULL' WHERE AM_Acc_Cd='" + AccountCode + "' AND AM_Inst_Typ='" + InstitutionMasterData.XInstType + "' AND AM_Inst_Cd='" + InstitutionMasterData.XInstCode + "' AND AM_Fin_Yr='" + InstitutionMasterData.XFinYr + "'")
        datahelper.ExecuteNonQuery(query, CommandType.Text)
    End Sub

End Class
