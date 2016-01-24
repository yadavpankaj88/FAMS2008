Imports System.Data
Imports System.Data.SqlClient
Public Class DataHelper
    Dim sqlConnection As SqlConnection

    Private Sub CreateConnection()
        Try
            Dim strConnection As String = System.Configuration.ConfigurationSettings.AppSettings("DBConnection")
            Dim year As String = InstitutionMasterData.XFinYr
            strConnection = String.Format(strConnection, System.Configuration.ConfigurationSettings.AppSettings("Server"), System.Configuration.ConfigurationSettings.AppSettings("Database") + year, System.Configuration.ConfigurationSettings.AppSettings("Username"), System.Configuration.ConfigurationSettings.AppSettings("Password"))
            sqlConnection = New SqlConnection(strConnection)
            sqlConnection.Open()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ExecuteQuery(pQuery As String, pQueryType As CommandType, Optional parameters As Dictionary(Of String, Object) = Nothing) As DataTable
        Dim sqlCommand As New SqlCommand(pQuery)
        Dim adapter As SqlDataAdapter
        Dim ds As DataSet = Nothing
        Try
            Using (sqlCommand)
                sqlCommand.CommandType = pQueryType
                If (sqlConnection Is Nothing) Then
                    CreateConnection()
                End If
                sqlCommand.Connection = sqlConnection
                If parameters IsNot Nothing Then
                    For Each parameter As String In parameters.Keys
                        If (parameters(parameter) Is Nothing) Then
                            sqlCommand.Parameters.AddWithValue(parameter.ToString(), DBNull.Value)
                        Else
                            sqlCommand.Parameters.AddWithValue(parameter.ToString(), parameters(parameter).ToString())
                        End If
                    Next
                End If
                adapter = New SqlDataAdapter(sqlCommand)
                ds = New DataSet
                adapter.Fill(ds)
            End Using
        Catch ex As Exception
            Throw
        Finally
            If sqlConnection IsNot Nothing Then
                sqlConnection.Close()
                sqlConnection = Nothing
            End If
        End Try
        Return ds.Tables(0)
    End Function

    Public Sub ExecuteNonQuery(pQuery As String, pQueryType As CommandType, Optional parameters As Dictionary(Of String, Object) = Nothing)
        Dim sqlCommand As New SqlCommand(pQuery)
        Try
            Using (sqlCommand)

                sqlCommand.CommandType = pQueryType

                If (sqlConnection Is Nothing) Then
                    CreateConnection()
                End If
                sqlCommand.Connection = sqlConnection

                If parameters IsNot Nothing Then
                    For Each parameter As String In parameters.Keys
                        If (parameters(parameter) Is Nothing) Then
                            sqlCommand.Parameters.AddWithValue(parameter.ToString(), DBNull.Value)
                        Else
                            sqlCommand.Parameters.AddWithValue(parameter.ToString(), parameters(parameter).ToString())
                        End If
                    Next
                End If
                sqlCommand.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Throw ex
        Finally
            If sqlConnection IsNot Nothing Then
                sqlConnection.Close()
                sqlConnection = Nothing
            End If
        End Try
    End Sub

    Public Sub ExecuteQueryTransaction(pCommandList As List(Of SqlCommand))
        Dim trans As SqlTransaction = Nothing
        Try
            If (sqlConnection Is Nothing) Then
                CreateConnection()
            End If
            trans = sqlConnection.BeginTransaction()
            For Each Command As SqlCommand In pCommandList
                Command.Transaction = trans
                Command.Connection = sqlConnection
                Command.ExecuteNonQuery()
            Next
            trans.Commit()

        Catch ex As Exception
            If trans IsNot Nothing Then trans.Rollback()
            Throw
        Finally
            If sqlConnection IsNot Nothing Then
                sqlConnection.Close()
                sqlConnection = Nothing
            End If
        End Try
    End Sub

    Function ExecuteScalar(pQuery As String, pQueryType As CommandType, Optional parameters As Dictionary(Of String, Object) = Nothing) As Object
        Dim sqlCommand As New SqlCommand(pQuery)
        Try
            Using (sqlCommand)

                sqlCommand.CommandType = pQueryType

                If (sqlConnection Is Nothing) Then
                    CreateConnection()


                End If
                sqlCommand.Connection = sqlConnection

                If parameters IsNot Nothing Then
                    For Each parameter As String In parameters.Keys
                        If (parameters(parameter) Is Nothing) Then
                            sqlCommand.Parameters.AddWithValue(parameter.ToString(), DBNull.Value)
                        Else
                            sqlCommand.Parameters.AddWithValue(parameter.ToString(), parameters(parameter).ToString())
                        End If
                    Next
                End If
                Return sqlCommand.ExecuteScalar()
            End Using

        Catch ex As Exception
            Throw ex
        Finally
            If sqlConnection IsNot Nothing Then
                sqlConnection.Close()
                sqlConnection = Nothing
            End If
        End Try
    End Function

End Class
