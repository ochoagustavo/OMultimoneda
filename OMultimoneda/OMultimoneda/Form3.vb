Imports System.Data.SqlClient

Public Class Form3
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        leer_configuracion()

        Me.CheckBox1.Checked = cactprd
        Me.CheckBox2.Checked = cactsrv

        Me.CheckBox3.Checked = cprdpre
        Me.CheckBox4.Checked = cprdcos
        Me.CheckBox5.Checked = cprdiva

        Me.CheckBox7.Checked = csrvpre
        Me.CheckBox8.Checked = csrvcos
        Me.CheckBox6.Checked = csrviva

        Me.CheckBox9.Checked = cactcom
        Me.CheckBox10.Checked = ccompre
        Me.CheckBox11.Checked = ccomcos

        Me.ComboBox1.Text = decimales

        If CheckBox1.Checked = False Then
            CheckBox3.Checked = False
            CheckBox3.Enabled = False
            CheckBox4.Checked = False
            CheckBox4.Enabled = False
            CheckBox5.Checked = False
            CheckBox5.Enabled = False
        Else
            CheckBox3.Enabled = True
            CheckBox4.Enabled = True
            CheckBox5.Enabled = True
        End If
        If CheckBox2.Checked = False Then
            CheckBox6.Checked = False
            CheckBox6.Enabled = False
            CheckBox7.Checked = False
            CheckBox7.Enabled = False
            CheckBox8.Checked = False
            CheckBox8.Enabled = False
        Else
            CheckBox6.Enabled = True
            CheckBox7.Enabled = True
            CheckBox8.Enabled = True
        End If

        If CheckBox9.Checked = False Then
            CheckBox10.Checked = False
            CheckBox10.Enabled = False
            CheckBox11.Checked = False
            CheckBox11.Enabled = False
        Else
            CheckBox10.Enabled = True
            CheckBox11.Enabled = True
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cactprd = Me.CheckBox1.Checked.GetHashCode
        cactsrv = Me.CheckBox2.Checked.GetHashCode

        cprdpre = Me.CheckBox3.Checked.GetHashCode
        cprdcos = Me.CheckBox4.Checked.GetHashCode
        cprdiva = Me.CheckBox5.Checked.GetHashCode

        csrvpre = Me.CheckBox7.Checked.GetHashCode
        csrvcos = Me.CheckBox8.Checked.GetHashCode
        csrviva = Me.CheckBox6.Checked.GetHashCode

        cactcom = Me.CheckBox9.Checked.GetHashCode
        ccompre = Me.CheckBox10.Checked.GetHashCode
        ccomcos = Me.CheckBox11.Checked.GetHashCode

        abrirconex()
        act_configuracion()
        act_fn_redondeo()

        If cactprd = 1 Then

            actprd()
            crear_spproductos()

        End If

        If cactprd = 0 Then
            desprd()

        End If

        If cactsrv = 1 Then
            actsrv()
            crear_spservicios()

        End If

        If cactsrv = 0 Then
            dessrv()

        End If

        If cactcom = 1 Then

            actcom()
            crear_spcompras()


        End If

        If cactcom = 0 Then
            des_compras()


        End If



        Me.Close()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            CheckBox3.Checked = False
            CheckBox3.Enabled = False
            CheckBox4.Checked = False
            CheckBox4.Enabled = False
            CheckBox5.Checked = False
            CheckBox5.Enabled = False
        Else
            CheckBox3.Enabled = True
            CheckBox4.Enabled = True
            CheckBox5.Enabled = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = False Then
            CheckBox6.Checked = False
            CheckBox6.Enabled = False
            CheckBox7.Checked = False
            CheckBox7.Enabled = False
            CheckBox8.Checked = False
            CheckBox8.Enabled = False
        Else
            CheckBox6.Enabled = True
            CheckBox7.Enabled = True
            CheckBox8.Enabled = True
        End If
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.Checked = False Then
            CheckBox10.Checked = False
            CheckBox10.Enabled = False
            CheckBox11.Checked = False
            CheckBox11.Enabled = False
        Else
            CheckBox10.Enabled = True
            CheckBox11.Enabled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        decimales = Me.ComboBox1.Text

    End Sub
End Class