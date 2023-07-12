Imports System.Data.SqlClient

Public Class Form1
    Private Sub Form1_Close(sender As Object, e As EventArgs) Handles MyBase.Closed
        LoginForm1.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        factor = txtFactor1.Text
        factor2 = IIf(txtFactor2.Enabled = True, txtFactor2.Text, txtFactor1.Text)
        factor3 = IIf(txtFactor3.Enabled = True, txtFactor3.Text, txtFactor1.Text)
        factorm = txtFactorm.Text
        abrirconex()
        If cactprd = 1 Then
            productos_precios()
        End If

        If cactsrv = 1 Then
            servicios_precios()
        End If

        If txtFactorm.Text <> "" Then
            Dim sql As String = "use [" & My.Settings.basedatos & "];
                declare @factor as decimal(28,8)
                set @factor = " & factorm & "
                update saconf
                set factor = @factor,
	            factorM = @factor
                IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'MONTO' AND TABLE_NAME = 'SATARJ')
                BEGIN
                        EXEC('update satarj set monto = '+ @factor +' where tipoins = 0')
                END"
            Dim cmd As New SqlCommand(sql, cn)
            Try
                Dim da As New SqlDataAdapter(cmd)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If cactprd = 0 And cactsrv = 0 Then
            MsgBox("Ingrese a la configuracion", MsgBoxStyle.Information)
        End If

    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub GeneralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralToolStripMenuItem.Click
        Form3.Show()

    End Sub

    Private Sub TextBox1_Keypress(sender As Object, e As Object) Handles txtFactor1.KeyPress
        NumConFrac(Me.txtFactor1, e)
    End Sub

    Private Sub TextBox2_Keypress(sender As Object, e As Object) Handles txtFactorm.KeyPress
        NumConFrac(Me.txtFactorm, e)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim r As New Globalization.CultureInfo("es-ES")
        r.NumberFormat.CurrencyDecimalSeparator = "."
        r.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = r

        abrirconex()
        tabla_configuracion()
        creartabla()
        refrescartabla()
        fn_redondeo()
        leer_configuracion()

        txtFactor1.Text = FormatNumber(factor, 4)
        txtFactor2.Text = txtFactor1.Text
        txtFactor3.Text = txtFactor1.Text
        txtFactorm.Text = FormatNumber(factorm, 4)
    End Sub

    Private Sub ImportarPreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarPreciosToolStripMenuItem.Click
        Form5.Show()
    End Sub

    Private Sub AjusteManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjusteManualToolStripMenuItem.Click
        Form4.Show()
    End Sub

    Private Sub AjusteAutomaticoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjusteAutomaticoToolStripMenuItem.Click
        Form6.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        If txtFactor2.Enabled = True Then
            txtFactor2.Enabled = False
            txtFactor2.Text = txtFactor1.Text
        Else
            txtFactor2.Enabled = True
            txtFactor2.Text = txtFactor1.Text
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        If txtFactor3.Enabled = True Then
            txtFactor3.Enabled = False
            txtFactor3.Text = txtFactor1.Text
        Else
            txtFactor3.Enabled = True
            txtFactor3.Text = txtFactor1.Text
        End If
    End Sub
End Class
