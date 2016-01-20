Public Class CommonFunctions

    Public Shared Function BindCreditDebit() As List(Of ComboBoxHelper)
        Dim creditDebit As New List(Of ComboBoxHelper)
        'creditDebit.Add(New ComboBoxHelper() With { _
        '      .Text = "Select", _
        '     .Value = "Select" _
        '})

        creditDebit.Add(New ComboBoxHelper() With { _
             .Text = "Credit", _
            .Value = "CR" _
       })

        creditDebit.Add(New ComboBoxHelper() With { _
            .Text = "Debit", _
           .Value = "DR" _
      })

        Return creditDebit
    End Function
End Class
