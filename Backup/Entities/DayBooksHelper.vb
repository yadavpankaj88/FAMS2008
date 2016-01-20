Imports System.Data.SqlClient
Public Class DayBooksHelper
    Public Function SaveDaybooks(daybook As Daybooks)
        Try
            Dim dataHelper As New DataHelper
            'dataHelper.CreateConnection()
            Dim saveQuery As String
            saveQuery = "If((Select COUNT('x') from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Dbk_Cd=@dbkcd and DM_Fin_Yr=@finYear and DM_Inst_Cd=@instCode and DM_Inst_Typ=@instTyp)=0)" _
                        & " Begin " _
                      & "Insert into " + InstitutionMasterData.XInstType + "_Daybooks(DM_Fin_Yr,DM_Inst_Cd,DM_Inst_Typ,DM_Brn_Cd,DM_Dbk_Cd,DM_Dbk_Nm,DM_Dbk_Typ,DM_Acc_Cd,DM_Bnk_Nm,DM_Bnk_Brn,DM_Bnk_AcNo,DM_Bnk_OD,DM_Ent_Dt) " _
                        & "values(@finYear,@instCode,@instTyp,@brnCd,@dbkcd,@dbkNm,@dbkTyp,@acccd,@bnkNm,@bnkBrn,@bnkAcNo,@bnkOd,GetDate())" _
                     & " End" _
                     & " Else " _
                     & " Update " + InstitutionMasterData.XInstType + "_Daybooks" _
                     & " Set DM_Acc_Cd=@acccd,DM_Dbk_Typ=@dbkTyp,DM_Bnk_Brn=@bnkBrn,DM_Dbk_Nm=@dbkNm,DM_Bnk_AcNo=@bnkAcNo,DM_Bnk_Nm=@bnkNm,DM_Bnk_OD=@bnkOd,DM_Upd_Dt=GetDate()" _
                     & "  Where DM_Dbk_Cd=@dbkcd and DM_Fin_Yr=@finYear and DM_Inst_Cd=@instCode and DM_Inst_Typ=@instTyp"

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

    Public Function GetDaybooksByCode(daybookCode As String) As DataTable
        Dim daybooksDT As New DataTable
        Dim datahelper As New DataHelper
        'datahelper.CreateConnection()
        Dim query As String = String.Format("Select * from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Fin_Yr ='{0}' and DM_Inst_Cd='{1}' and DM_Inst_Typ='{2}' " + _
                                            "and DM_Dbk_Cd='{3}' order by DM_Ent_Dt desc", InstitutionMasterData.XFinYr, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, daybookCode)
        daybooksDT = datahelper.ExecuteQuery(query, CommandType.Text)
        Return daybooksDT
    End Function

    Public Sub Delete(daybookCode As String)
        Dim datahelper As New DataHelper
        Dim query As String = String.Format("delete from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Fin_Yr ='{0}' and DM_Inst_Cd='{1}' and DM_Inst_Typ='{2}' " + _
                                            "and DM_Dbk_Cd='{3}'", InstitutionMasterData.XFinYr, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, daybookCode)
        datahelper.ExecuteNonQuery(query, CommandType.Text)
    End Sub

    Public Function GetDaybooksByType(daybookType As String, Optional ByVal isContra As Boolean = False) As DataTable
        Dim daybooksDT As New DataTable
        Dim datahelper As New DataHelper
        Dim query As String
        'datahelper.CreateConnection()
        If Not isContra Then
            query = String.Format("Select RTRIM(DM_Dbk_Nm) as 'DM_Dbk_Nm',RTRIM(DM_Dbk_Cd) as 'DM_Dbk_Cd',DM_Acc_Cd from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Fin_Yr ='{0}' and " + _
                                              "DM_Inst_Cd='{1}' and DM_Inst_Typ='{2}' and DM_Dbk_Typ='{3}' " + _
                                              "order by DM_Ent_Dt desc", InstitutionMasterData.XFinYr, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, daybookType)
        Else
            query = String.Format("Select RTRIM(DM_Dbk_Nm) as 'DM_Dbk_Nm',RTRIM(DM_Dbk_Cd) as 'DM_Dbk_Cd',DM_Acc_Cd,DM_Dbk_Typ from " + InstitutionMasterData.XInstType + "_Daybooks where DM_Fin_Yr ='{0}' and " + _
                                              "DM_Inst_Cd='{1}' and DM_Inst_Typ='{2}'" + _
                                              "order by DM_Ent_Dt desc", InstitutionMasterData.XFinYr, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType)
        End If

        daybooksDT = datahelper.ExecuteQuery(query, CommandType.Text)
        Return daybooksDT
    End Function

End Class
