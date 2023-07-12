Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Imports System.Runtime.CompilerServices

Public Class Form6

    Private dt As New DataTable
    Private empaque As Integer
    Private cantempaq As Integer
    Private impuesto As Integer
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim sql As String
    Private dtc As New DataTable
    Private instancia As Integer
    Private proveedor As String
    Private signo As Char = "+"


    Private Sub formato()
        txtCostoAct.Text = FormatNumber(txtCostoAct.Text, 4)
        txtCostoPro.Text = FormatNumber(txtCostoPro.Text, 4)
        txtCostoAnt.Text = FormatNumber(txtCostoAnt.Text, 4)
        txtPrecio1.Text = FormatNumber(txtPrecio1.Text, 4)
        txtPrecio2.Text = FormatNumber(txtPrecio2.Text, 4)
        txtPrecio3.Text = FormatNumber(txtPrecio3.Text, 4)
        txtPrecioU1.Text = FormatNumber(txtPrecioU1.Text, 4)
        txtPrecioU2.Text = FormatNumber(txtPrecioU2.Text, 4)
        txtPrecioU3.Text = FormatNumber(txtPrecioU3.Text, 4)

    End Sub

    Private Sub fillCombo(sql As String, cbo As ComboBox)
        Try
            'cn.Open()

            cmd = New SqlCommand
            da = New SqlDataAdapter
            dtc = New DataTable

            With cmd
                .Connection = cn
                .CommandText = sql
            End With

            With da
                .SelectCommand = cmd
                .Fill(dtc)
            End With

            cbo.DataSource = dtc
            cbo.DisplayMember = dtc.Columns(1).ColumnName
            cbo.ValueMember = dtc.Columns(0).ColumnName

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
            da.Dispose()
        End Try
    End Sub


    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim r As New Globalization.CultureInfo("es-ES")
        r.NumberFormat.CurrencyDecimalSeparator = "."
        r.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = r
        formato()
        abrirconex()
        Using adp As New SqlDataAdapter("select p.Codigo, p.Descripcion, p.Instancia, p.Marca 
                    from (select p.codprod as Codigo, p.descrip as Descripcion, p.codinst as Instancia, p.marca as Marca from saprod p, omconf c where p.activo = 1 and c.actprd = 1  
                    union all
                    select s.codserv as Codigo, s.descrip as Descripcion, s.codinst as Instancia, '' as Marca from saserv s, omconf c where s.activo = 1 and c.actsrv = 1) p", cn)
            adp.Fill(dt)
        End Using
        DataGridView1.DataSource = dt
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            signo = "+"
        Else
            signo = "-"
        End If

    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        dt.DefaultView.RowFilter = "Descripcion like '%" & txtBuscar.Text & "%' or Codigo like '%" & txtBuscar.Text & "%'"
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtCostoAct_leave(sender As Object, e As EventArgs) Handles txtCostoAct.Leave
        formato()
    End Sub

    Private Sub txtCostoant_leave(sender As Object, e As EventArgs) Handles txtCostoAnt.Leave
        formato()
    End Sub

    Private Sub txtCostoAct_keypress(sender As Object, e As EventArgs) Handles txtCostoAct.KeyPress
        NumConFrac(txtCostoAct, e)
    End Sub

    Private Sub txtCostoPro_keypress(sender As Object, e As EventArgs) Handles txtCostoPro.KeyPress
        NumConFrac(txtCostoPro, e)
    End Sub

    Private Sub txtCostoAnt_keypress(sender As Object, e As EventArgs) Handles txtCostoAnt.KeyPress
        NumConFrac(txtCostoAnt, e)
    End Sub

    Private Sub txtPrecio1_keypress(sender As Object, e As EventArgs) Handles txtPrecio1.KeyPress
        NumConFrac(txtPrecio1, e)
    End Sub

    Private Sub txtPrecio2_keypress(sender As Object, e As EventArgs) Handles txtPrecio2.KeyPress
        NumConFrac(txtPrecio2, e)
    End Sub

    Private Sub txtPrecio3_keypress(sender As Object, e As EventArgs) Handles txtPrecio3.KeyPress
        NumConFrac(txtPrecio3, e)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim ask As MsgBoxResult = MsgBox("Seguro que desea actualizar?", 4)
        If ask = MsgBoxResult.Yes Then
            If CheckBox2.Checked = True Then
                abrirconex()
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        Dim sql As String = "use [" & My.Settings.basedatos & "];
                    declare @factor as decimal(28,8)
                    set @factor = " & factor & "
                    update opreciosmex
                    set costoact = " & txtCostoAct.Text & ",
	                costopro = " & txtCostoPro.Text & ",
                    costoant = " & txtCostoAnt.Text & ",
                    precio1 = " & txtPrecio1.Text & ",
                    precio2 = " & txtPrecio2.Text & ",
                    precio3 = " & txtPrecio3.Text & ",
                    
                    preciou1 = " & txtPrecioU1.Text & ",
                    preciou2 = " & txtPrecioU2.Text & ",
                    preciou3 = " & txtPrecioU3.Text & "
                    where codprod = '" & row.Cells(0).Value.ToString & "'"
                        Dim cmd As New SqlCommand(sql, cn)
                        Try
                            Dim da As New SqlDataAdapter(cmd)
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                        'MessageBox.Show(row.Cells(0).Value.ToString & "," & row.Cells(1).Value.ToString)
                    End If
                Next


            Else


                abrirconex()
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        Dim sql As String = "use [" & My.Settings.basedatos & "];
                    declare @factor as decimal(28,8)
                    set @factor = " & factor & "
                    update opreciosmex
                    set costoact = costoact " & signo & " costoact * (" & txtCostoAct.Text / 100 & "),
	                costopro = costopro " & signo & " costopro * (" & txtCostoPro.Text / 100 & "),
                    costoant = costoant " & signo & " costoant * (" & txtCostoAnt.Text / 100 & "),
                    precio1 = precio1 " & signo & " precio1 * (" & txtPrecio1.Text / 100 & "),
                    precio2 = precio2 " & signo & " precio2 * (" & txtPrecio2.Text / 100 & "),
                    precio3 = precio3 " & signo & " precio3 * (" & txtPrecio3.Text / 100 & "),
                    
                    preciou1 = preciou1 " & signo & " preciou1 * (" & txtPrecioU1.Text / 100 & "),
                    preciou2 = preciou2 " & signo & " preciou2 * (" & txtPrecioU2.Text / 100 & "),
                    preciou3 = preciou3 " & signo & " preciou3 * (" & txtPrecioU3.Text / 100 & ")
                    where codprod = '" & row.Cells(0).Value.ToString & "'"
                        Dim cmd As New SqlCommand(sql, cn)
                        Try
                            Dim da As New SqlDataAdapter(cmd)
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                        'MessageBox.Show(row.Cells(0).Value.ToString & "," & row.Cells(1).Value.ToString)
                    End If
                Next

            End If



            MsgBox("Actualizacion Exitosa", MsgBoxStyle.Information)
            Me.Close()

        Else

        End If
    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.MouseClick
        abrirconex()
        sql = "SELECT codinst, descrip FROM sainsta where descrip like '%" & ComboBox1.Text & "%'"
        fillCombo(sql, ComboBox1)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If ComboBox1.Enabled = True Then
            instancia = 0
            ComboBox1.Enabled = False
            ComboBox1.Text = "Haga click en la palabra ""Instancia"" para activar"
        Else
            ComboBox1.Enabled = True
            ComboBox1.Text = ""
            instancia = 0
        End If

    End Sub

    Private Sub ComboBox2_Click(sender As Object, e As EventArgs) Handles ComboBox2.MouseClick
        abrirconex()
        sql = "SELECT codprov, descrip FROM saprov where descrip like '%" & ComboBox2.Text & "%'"
        fillCombo(sql, ComboBox2)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        If ComboBox2.Enabled = True Then

            ComboBox2.Enabled = False
            ComboBox2.Text = "Haga click en la palabra ""Proveedor"" para activar"
        Else
            ComboBox2.Enabled = True
            ComboBox2.Text = ""

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.Leave
        instancia = ComboBox1.SelectedValue
        btnFiltrar_Click(sender, e)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.Leave
        proveedor = ComboBox2.SelectedValue
        btnFiltrar_Click(sender, e)
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        If ComboBox2.Enabled = True Then
            dt.Clear()
            DataGridView1.DataSource = dt
            DataGridView1.DataSource = Nothing
            Using adp As New SqlDataAdapter("select a.codprod as Codigo, a.descrip as Descripcion, a.codinst as Instancia, a.Marca as Marca from saprod a, sapvpr b where a.codprod = b.codprod and b.codprov = '" & proveedor & "'", cn)
                adp.Fill(dt)
            End Using
            DataGridView1.DataSource = dt
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            If ComboBox1.Enabled = True Then
                dt.DefaultView.RowFilter = "Instancia = " & instancia

            End If
            If txtMarca.Enabled = True Then
                dt.DefaultView.RowFilter = "Marca like '%" & txtMarca.Text & "%'"

            End If
            btnAceptar.Enabled = 1
        Else
            dt.Clear()
            DataGridView1.DataSource = dt
            DataGridView1.DataSource = Nothing
            Using adp As New SqlDataAdapter("select p.Codigo, p.Descripcion, p.Instancia, p.Marca
                    from (select p.codprod as Codigo, p.descrip as Descripcion, p.codinst as Instancia, p.Marca as Marca from saprod p, omconf c where p.activo = 1 and c.actprd = 1  
                    union all
                    select s.codserv as Codigo, s.descrip as Descripcion, s.codinst as Instancia, '' as Marca from saserv s, omconf c where s.activo = 1 and c.actsrv = 1) p", cn)
                adp.Fill(dt)
            End Using
            DataGridView1.DataSource = dt
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            If ComboBox1.Enabled = True Then
                dt.DefaultView.RowFilter = "Instancia = " & instancia

            End If
            If txtMarca.Enabled = True Then
                dt.DefaultView.RowFilter = "Marca like '%" & txtMarca.Text & "%'"

            End If

            btnAceptar.Enabled = True

        End If




    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        If txtCostoAct.Enabled = True Then
            txtCostoAct.Enabled = False
            txtCostoAct.Text = 0
        Else
            txtCostoAct.Enabled = True
            txtCostoAct.Text = 0
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        If txtCostoPro.Enabled = True Then
            txtCostoPro.Enabled = False
            txtCostoPro.Text = 0
        Else
            txtCostoPro.Enabled = True
            txtCostoPro.Text = 0
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        If txtCostoAnt.Enabled = True Then
            txtCostoAnt.Enabled = False
            txtCostoAnt.Text = 0
        Else
            txtCostoAnt.Enabled = True
            txtCostoAnt.Text = 0
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        If txtPrecio1.Enabled = True Then
            txtPrecio1.Enabled = False
            txtPrecio1.Text = 0
        Else
            txtPrecio1.Enabled = True
            txtPrecio1.Text = 0
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        If txtPrecio2.Enabled = True Then
            txtPrecio2.Enabled = False
            txtPrecio2.Text = 0
        Else
            txtPrecio2.Enabled = True
            txtPrecio2.Text = 0
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        If txtPrecio3.Enabled = True Then
            txtPrecio3.Enabled = False
            txtPrecio3.Text = 0
        Else
            txtPrecio3.Enabled = True
            txtPrecio3.Text = 0
        End If
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        If txtPrecioU1.Enabled = True Then
            txtPrecioU1.Enabled = False
            txtPrecioU1.Text = 0
        Else
            txtPrecioU1.Enabled = True
            txtPrecioU1.Text = 0
        End If
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        If txtPrecioU2.Enabled = True Then
            txtPrecioU2.Enabled = False
            txtPrecioU2.Text = 0
        Else
            txtPrecioU2.Enabled = True
            txtPrecioU2.Text = 0
        End If
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        If txtPrecioU3.Enabled = True Then
            txtPrecioU3.Enabled = False
            txtPrecioU3.Text = 0
        Else
            txtPrecioU3.Enabled = True
            txtPrecioU3.Text = 0
        End If
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        If CheckBox1.Enabled = True Then
            CheckBox1.Enabled = False

        Else
            CheckBox1.Enabled = True

        End If
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        If txtMarca.Enabled = True Then
            txtMarca.Enabled = False
            txtMarca.Text = Nothing
        Else
            txtMarca.Enabled = True
            txtMarca.Text = Nothing
        End If
    End Sub

    Private Sub txtMarca_TextChanged(sender As Object, e As EventArgs) Handles txtMarca.TextChanged
        dt.DefaultView.RowFilter = "Marca like '%" & txtMarca.Text & "%'"
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        If CheckBox2.Enabled = True Then
            CheckBox2.Enabled = False

        Else
            CheckBox2.Enabled = True

        End If
    End Sub


End Class