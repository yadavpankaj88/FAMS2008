Imports System.Data
Imports System.Data.SqlClient
Public Class DataHelper
    Dim sqlConnection As SqlConnection

    Public Sub CreateConnection()
        Try
            sqlConnection = New SqlConnection("Server=.\sql2008r2;initial catalog=FAM;integrated security=true")
            sqlConnection.Open()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ExecuteQuery(pQuery As String, pQueryType As CommandType) As DataTable
        Dim sqlCommand As New SqlCommand(pQuery)
        sqlCommand.CommandType = pQueryType
        sqlCommand.Connection = sqlConnection
        Dim adapter As New SqlDataAdapter(sqlCommand)
        Dim ds As New DataSet
        adapter.Fill(ds)
        Return ds.Tables(0)
    End Function
End Class
