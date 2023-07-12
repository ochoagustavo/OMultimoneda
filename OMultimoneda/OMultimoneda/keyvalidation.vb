Imports System.Text.RegularExpressions
Imports System.Globalization


Module keyvalidation

    Public Sub NumConFrac(ByVal CajaTexto As Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim sep As Char
        sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = sep And Not CajaTexto.Text.IndexOf(sep) Then
            e.Handled = True
        ElseIf e.KeyChar = sep Then
            e.Handled = False
        ElseIf e.KeyChar = "," And Not CajaTexto.Text.IndexOf(sep) Then
            e.Handled = True
        ElseIf e.KeyChar = "," Then
            e.KeyChar = sep
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

End Module
