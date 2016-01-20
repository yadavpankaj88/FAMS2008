Imports System.Text

Public Class UserHelper

    Public Function SaveUser(ByVal user As User)
        Try
            Dim dataHelper As New DataHelper
            Dim saveQuery As String
            saveQuery = "If(Exists(select 'x' from User_Master where Usr_Id=@UserId)) " &
                        " Begin " &
                        "Update User_Master Set Usr_Inst_Typ=@InstitutionType,Usr_Nm=@UserName,Usr_Role=@Role,Usr_Pwd=@password,Usr_Mdl_Cd=@ModuleCode, Usr_Lckd=@UserLocked,Usr_Lst_Wrk_Stn=@LastWorkStation,Usr_Lst_Login=GetDate() where Usr_Id=@UserId" &
                        " End " &
                        " Else " &
                        "Insert into User_Master(Usr_Id,Usr_Mdl_Cd,Usr_Inst_Typ,Usr_Nm,Usr_Role,Usr_Pwd,Usr_Lst_Login,Usr_Lckd) " &
                        "values(@UserId,@ModuleCode,@InstitutionType,@UserName,@Role,@password,GetDate(),@UserLocked)"

            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@UserId", user.UserId)
            parameters.Add("@UserName", user.UserName)
            parameters.Add("@password", user.password)
            parameters.Add("@LastLogin", user.LastLogin)
            parameters.Add("@UserLocked", user.UserLocked)
            parameters.Add("@ModuleCode", user.ModuleCode)
            parameters.Add("@LastWorkStation", user.LastWorkStation)
            parameters.Add("@InstitutionType", user.InstitutionType)
            parameters.Add("@Role", user.Role)
            dataHelper.ExecuteNonQuery(saveQuery, CommandType.Text, parameters)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function GetTransactionCount(ByVal UserID As String) As Integer
        Dim query As String
        Dim dataHelper As New DataHelper
        Dim count As Integer
        Try
            query = String.Format("SELECT count(*) from User_Master where Usr_Id='{0}'", UserID)

            Int32.TryParse(dataHelper.ExecuteScalar(query, CommandType.Text, Nothing), count)
            Return count
        Catch ex As Exception
            Throw
        End Try

    End Function

    Sub DeleteAccount(ByVal Usr_Id As String)
        Dim dataHelper As New DataHelper
        Dim query As String
        Try
            query = String.Format("Delete from User_Master where Usr_Id='{0}'", Usr_Id)
            dataHelper.ExecuteNonQuery(query, CommandType.Text)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Function FillUserID() As DataTable
        Dim dataHelper As New DataHelper
        Dim dt As DataTable
        Dim query As StringBuilder
        Try
            query = New StringBuilder()
            query.Append(String.Format("select [Usr_Id] as UserID,[Usr_Nm] as UserName from User_Master WHERE Usr_Inst_Typ='" + InstitutionMasterData.XInstType + "'"))
            dt = dataHelper.ExecuteQuery(query.ToString, CommandType.Text)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Function GetUserDetails(ByVal userID As String) As DataTable
        Dim datahelper As New DataHelper
        Dim query As StringBuilder
        Try
            query = New StringBuilder()
            If String.IsNullOrEmpty(userID) Then
                query.Append(String.Format("SELECT [Usr_Id],[Usr_Mdl_Cd],[Usr_Inst_Typ],[Usr_Nm],[Usr_Role],[Usr_Pwd],[Usr_Lst_Login], [Usr_Lst_Wrk_Stn],[Usr_Lckd]  FROM User_Master WHERE Usr_Inst_Typ='" + InstitutionMasterData.XInstType + "'"))
            Else
                query.Append(String.Format("SELECT [Usr_Id],[Usr_Mdl_Cd],[Usr_Inst_Typ],[Usr_Nm],[Usr_Role],[Usr_Pwd],[Usr_Lst_Login], [Usr_Lst_Wrk_Stn],[Usr_Lckd]  FROM User_Master  where Usr_Id='{0}' AND Usr_Inst_Typ='{1}'", userID, InstitutionMasterData.XInstType))
            End If
            Return datahelper.ExecuteQuery(query.ToString(), CommandType.Text, Nothing)
        Catch ex As Exception
            Throw
        End Try

    End Function

    Function GetUserDetailsByID(ByVal userID As String) As DataTable
        Dim datahelper As New DataHelper
        Dim query As StringBuilder
        Try
            query = New StringBuilder()
            query.Append(String.Format("SELECT [Usr_Id],[Usr_Mdl_Cd],[Usr_Inst_Typ],[Usr_Nm],[Usr_Role],[Usr_Pwd],[Usr_Lst_Login], [Usr_Lst_Wrk_Stn] ,[Usr_Lckd] FROM User_Master  where Usr_Id='{0}' AND Usr_Inst_Typ='{1}'", userID, InstitutionMasterData.XInstType))
            Return datahelper.ExecuteQuery(query.ToString(), CommandType.Text, Nothing)
        Catch ex As Exception
            Throw
        End Try

    End Function

    Function GetLastUserID() As String
        Dim query As String
        Dim cnt As String
        Dim datahelper As New DataHelper
        query = "select count(Usr_Id) from User_Master WHERE Usr_Inst_Typ='" + InstitutionMasterData.XInstType + "'"
        cnt = datahelper.ExecuteScalar(query, CommandType.Text)
        Return cnt
    End Function

    Function GetCountUserID(ByVal userid As String) As String
        Dim query As String
        Dim cnt As String
        Dim datahelper As New DataHelper
        query = "select count(*) from User_Master where Usr_Id= '" + userid + "' and Usr_Mdl_Cd='FAM' and Usr_Inst_Typ='" + InstitutionMasterData.XInstType + "'"
        cnt = datahelper.ExecuteScalar(query, CommandType.Text)
        Return cnt
    End Function

    Function CheckUser(ByVal userid As String, ByVal password As String) As DataTable
        Dim query As New StringBuilder
        Dim dt As DataTable
        Dim helper As New DataHelper
        query.Append(String.Format("select Usr_Lst_Login, Usr_Id,Usr_Nm,Usr_Pwd ,Usr_Lckd,Usr_Role from User_Master where Usr_Id= '{0}' and Usr_Pwd='{1}' and Usr_Mdl_Cd='FAM' and Usr_Inst_Typ='" + InstitutionMasterData.XInstType + "'", userid, password))
        dt = helper.ExecuteQuery(query.ToString(), CommandType.Text)
        Return dt
    End Function

End Class
