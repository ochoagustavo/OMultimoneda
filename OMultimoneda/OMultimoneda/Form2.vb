Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtServ.Text = My.Settings.servSQL
        txtUser.Text = My.Settings.userSQL
        txtPass.Text = My.Settings.passSQL
        txtBd.Text = My.Settings.basedatos
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub

    Private Sub btnAcep_Click(sender As Object, e As EventArgs) Handles btnAcep.Click
        My.Settings.servSQL = txtServ.Text
        My.Settings.userSQL = txtUser.Text
        My.Settings.passSQL = txtPass.Text
        My.Settings.basedatos = txtBd.Text
        abrirconex()
        If cn.State = 1 Then
            MsgBox("CONECTADO, Datos Guardados", MsgBoxStyle.Information)
            Me.Close()

        Else
            MsgBox("NO CONECTADO, Verifique sus datos", MsgBoxStyle.Critical)
        End If

    End Sub
End Class