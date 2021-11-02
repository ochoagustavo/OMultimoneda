Imports System.Data.SqlClient
Public Class Form1
    Private Sub Form1_Close(sender As Object, e As EventArgs) Handles MyBase.Closed
        LoginForm1.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        factor = TextBox1.Text
        factorm = TextBox2.Text
        abrirconex()
        If cactprd = 1 Then
            productos_precios()
        End If

        If cactsrv = 1 Then
            servicios_precios()
        End If

        If TextBox2.Text <> "" Then
            Dim sql As String = "use [" & My.Settings.basedatos & "];
                declare @factor as decimal(28,8)
                set @factor = " & Me.TextBox2.Text & "
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

    Private Sub TextBox1_Keypress(sender As Object, e As Object) Handles TextBox1.KeyPress
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = CChar("")
        ElseIf e.KeyChar = "." Then
            If TextBox1.Text = "" Then
                e.KeyChar = CChar("")
            Else
                If InStr(TextBox1.Text, ".") > 0 Then
                    e.KeyChar = CChar("")
                End If
            End If
        End If
    End Sub

    Private Sub TextBox2_Keypress(sender As Object, e As Object) Handles TextBox2.KeyPress
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = CChar("")
        ElseIf e.KeyChar = "." Then
            If TextBox2.Text = "" Then
                e.KeyChar = CChar("")
            Else
                If InStr(TextBox2.Text, ".") > 0 Then
                    e.KeyChar = CChar("")
                End If
            End If
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        abrirconex()
        tabla_configuracion()
        creartabla()
        refrescartabla()
        fn_redondeo()
        leer_configuracion()

        TextBox1.Text = Replace(factor, ",", ".")
        TextBox2.Text = Replace(factorm, ",", ".")
    End Sub

    Private Sub ImportarPreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarPreciosToolStripMenuItem.Click
        Form5.Show()

    End Sub
End Class
