Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Class Form4

    Private dt As New DataTable
    Private empaque As Integer
    Private cantempaq As Integer
    Private impuesto As Integer

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
        txtUtil1.Text = FormatNumber(txtUtil1.Text, 4)
        txtUtil2.Text = FormatNumber(txtUtil2.Text, 4)
        txtUtil3.Text = FormatNumber(txtUtil3.Text, 4)
        txtUtilU1.Text = FormatNumber(txtUtilU1.Text, 4)
        txtUtilU2.Text = FormatNumber(txtUtilU2.Text, 4)
        txtUtilU3.Text = FormatNumber(txtUtilU3.Text, 4)
        txtIVA1.Text = FormatNumber(txtIVA1.Text, 4)
        txtIVA2.Text = FormatNumber(txtIVA2.Text, 4)
        txtIVA3.Text = FormatNumber(txtIVA3.Text, 4)
        txtIVAU1.Text = FormatNumber(txtIVAU1.Text, 4)
        txtIVAU2.Text = FormatNumber(txtIVAU2.Text, 4)
        txtIVAU3.Text = FormatNumber(txtIVAU3.Text, 4)
    End Sub


    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim r As New Globalization.CultureInfo("es-ES")
        r.NumberFormat.CurrencyDecimalSeparator = "."
        r.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = r
        formato()
        abrirconex()
        Using adp As New SqlDataAdapter("select p.Codigo, p.Descripcion, p.Marca
                    from (select p.codprod as Codigo, p.descrip as Descripcion, p.Marca as Marca from saprod p, omconf c where p.activo = 1 and c.actprd = 1
                    union all
                    select s.codserv as Codigo, s.descrip as Descripcion, '' as Marca from saserv s, omconf c where s.activo = 1 and c.actsrv = 1) p", cn)
            adp.Fill(dt)
        End Using
        DataGridView1.DataSource = dt
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        dt.DefaultView.RowFilter = "Descripcion like '%" & txtBuscar.Text & "%' or Codigo like '%" & txtBuscar.Text & "%' or Marca like '%" & txtBuscar.Text & "%'"
    End Sub

    Private Sub DataGridView1_DoblelClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        btnModificar_Click(sender, e)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtCodigo.Text = row.Cells(0).Value.ToString
            txtDescrip.Text = row.Cells(1).Value.ToString
            btnModificar.Enabled = True
            Try
                empresas = New SqlCommand("use " & My.Settings.basedatos & "; 
                select p.codigo, p.descrip2, p.esempaque, p.cantempaq from 
                (select p.codprod as codigo, isnull(p.descrip2,'') as descrip2, p.EsEmpaque, p.cantempaq from saprod p 
                union all 
                select s.codserv as codigo, isnull(s.descrip2,'') as descrip2, 0 as esempaque, 0 as cantempaq from saserv s) p where p.codigo = '" & row.Cells(0).Value.ToString & "'", cn)
                descripcion = empresas.ExecuteReader
                While descripcion.Read()
                    txtDescrip2.Text = descripcion.Item("descrip2")
                    empaque = descripcion.Item("esempaque")
                    cantempaq = descripcion.Item("cantempaq")
                End While
                descripcion.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Try
                empresas = New SqlCommand("use " & My.Settings.basedatos & "; 
                select a.codprod
                , a.costoact
                , a.costopro
                , a.costoant
                , a.util1
                , a.util2
                , a.util3
                , a.utilu1
                , a.utilu2
                , a.utilu3
                , c.prdiva
                , isnull(b.monto,0) monto
                , iif(c.prdiva=0,a.precio1,a.precio1/isnull(1+b.monto/100,1)) precio1
                , iif(c.prdiva=0,a.precio2,a.precio2/isnull(1+b.monto/100,1)) precio2
                , iif(c.prdiva=0,a.precio3,a.precio3/isnull(1+b.monto/100,1)) precio3
                , iif(c.prdiva=1,a.precio1,a.precio1*isnull(1+b.monto/100,1)) iva1
                , iif(c.prdiva=1,a.precio2,a.precio2*isnull(1+b.monto/100,1)) iva2
                , iif(c.prdiva=1,a.precio3,a.precio3*isnull(1+b.monto/100,1)) iva3
                , iif(c.prdiva=0,a.preciou1,a.preciou1/isnull(1+b.monto/100,1)) preciou1
                , iif(c.prdiva=0,a.preciou2,a.preciou2/isnull(1+b.monto/100,1)) preciou2
                , iif(c.prdiva=0,a.preciou3,a.preciou3/isnull(1+b.monto/100,1)) preciou3
                , iif(c.prdiva=1,a.preciou1,a.preciou1*isnull(1+b.monto/100,1)) ivau1
                , iif(c.prdiva=1,a.preciou2,a.preciou2*isnull(1+b.monto/100,1)) ivau2
                , iif(c.prdiva=1,a.preciou3,a.preciou3*isnull(1+b.monto/100,1)) ivau3
                from opreciosmex a left join sataxprd b on a.codprod = b.codprod cross join omconf c
                where a.codprod = '" & row.Cells(0).Value.ToString & "'", cn)
                descripcion = empresas.ExecuteReader
                While descripcion.Read()
                    txtCostoAct.Text = descripcion.Item("costoact")
                    txtCostoPro.Text = descripcion.Item("costopro")
                    txtCostoAnt.Text = descripcion.Item("costoant")
                    txtPrecio1.Text = descripcion.Item("precio1")
                    txtPrecio2.Text = descripcion.Item("precio2")
                    txtPrecio3.Text = descripcion.Item("precio3")
                    txtPrecioU1.Text = descripcion.Item("preciou1")
                    txtPrecioU2.Text = descripcion.Item("preciou2")
                    txtPrecioU3.Text = descripcion.Item("preciou3")
                    txtUtil1.Text = descripcion.Item("util1")
                    txtUtil2.Text = descripcion.Item("util2")
                    txtUtil3.Text = descripcion.Item("util3")
                    txtUtilU1.Text = descripcion.Item("utilu1")
                    txtUtilU2.Text = descripcion.Item("utilu2")
                    txtUtilU3.Text = descripcion.Item("utilu3")
                    impuesto = descripcion.Item("monto")
                    txtIVA1.Text = descripcion.Item("iva1")
                    txtIVA2.Text = descripcion.Item("iva2")
                    txtIVA3.Text = descripcion.Item("iva3")
                    txtIVAU1.Text = descripcion.Item("ivau1")
                    txtIVAU2.Text = descripcion.Item("ivau2")
                    txtIVAU3.Text = descripcion.Item("ivau3")
                End While
                descripcion.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            formato()
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        btnModificar.Enabled = False
        btnAceptar.Enabled = True
        btnCancelar.Enabled = True
        txtBuscar.Enabled = False
        DataGridView1.Enabled = False

        txtCostoAct.Enabled = True
        txtCostoAnt.Enabled = True
        txtCostoPro.Enabled = True


        txtPrecio1.Enabled = True
        txtPrecio2.Enabled = True
        txtPrecio3.Enabled = True



        txtIVA1.Enabled = True
        txtIVA2.Enabled = True
        txtIVA3.Enabled = True



        txtUtil1.Enabled = True
        txtUtil2.Enabled = True
        txtUtil3.Enabled = True

        If empaque = 1 Then
            If (cactprd = 1 Or cactsrv = 1) And cprdiva = 0 Then
                txtPrecioU1.Enabled = True
                txtPrecioU2.Enabled = True
                txtPrecioU3.Enabled = True
            End If

            txtUtilU1.Enabled = True
            txtUtilU2.Enabled = True
            txtUtilU3.Enabled = True

            If (cactprd = 1 Or cactsrv = 1) And cprdiva = 1 Then
                txtIVAU1.Enabled = True
                txtIVAU2.Enabled = True
                txtIVAU3.Enabled = True
            End If

        End If


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        btnModificar.Enabled = True
        btnAceptar.Enabled = False
        btnCancelar.Enabled = False
        txtBuscar.Enabled = True
        DataGridView1.Enabled = True

        txtCostoAct.Enabled = False
        txtCostoAnt.Enabled = False
        txtCostoPro.Enabled = False

        txtPrecio1.Enabled = False
        txtPrecio2.Enabled = False
        txtPrecio3.Enabled = False

        txtUtil1.Enabled = False
        txtUtil2.Enabled = False
        txtUtil3.Enabled = False

        txtIVA1.Enabled = False
        txtIVA2.Enabled = False
        txtIVA3.Enabled = False

        If empaque = 1 Then
            txtPrecioU1.Enabled = False
            txtPrecioU2.Enabled = False
            txtPrecioU3.Enabled = False

            txtUtilU1.Enabled = False
            txtUtilU2.Enabled = False
            txtUtilU3.Enabled = False

            txtIVAU1.Enabled = False
            txtIVAU2.Enabled = False
            txtIVAU3.Enabled = False
        End If

        formato()


    End Sub

    Private Sub txtCostoAct_leave(sender As Object, e As EventArgs) Handles txtCostoAct.Leave
        formato()
    End Sub

    Private Sub txtCostoant_leave(sender As Object, e As EventArgs) Handles txtCostoAnt.Leave
        formato()
    End Sub

    Private Sub txtCostoPro_Leave(sender As Object, e As EventArgs) Handles txtCostoPro.Leave

        txtPrecio1.Text = txtCostoPro.Text * (1 + txtUtil1.Text / 100)
        txtPrecio2.Text = txtCostoPro.Text * (1 + txtUtil2.Text / 100)
        txtPrecio3.Text = txtCostoPro.Text * (1 + txtUtil3.Text / 100)

        txtIVA1.Text = txtCostoPro.Text * (1 + txtUtil1.Text / 100) * (1 + impuesto / 100)
        txtIVA2.Text = txtCostoPro.Text * (1 + txtUtil2.Text / 100) * (1 + impuesto / 100)
        txtIVA3.Text = txtCostoPro.Text * (1 + txtUtil3.Text / 100) * (1 + impuesto / 100)

        If empaque = 1 Then
            txtPrecioU1.Text = txtCostoPro.Text * (1 + txtUtilU1.Text / 100) / cantempaq
            txtPrecioU2.Text = txtCostoPro.Text * (1 + txtUtilU2.Text / 100) / cantempaq
            txtPrecioU3.Text = txtCostoPro.Text * (1 + txtUtilU3.Text / 100) / cantempaq

            txtIVAU1.Text = txtCostoPro.Text * (1 + txtUtilU1.Text / 100) * (1 + impuesto / 100) / cantempaq
            txtIVAU2.Text = txtCostoPro.Text * (1 + txtUtilU2.Text / 100) * (1 + impuesto / 100) / cantempaq
            txtIVAU3.Text = txtCostoPro.Text * (1 + txtUtilU3.Text / 100) * (1 + impuesto / 100) / cantempaq
        End If

        formato()
    End Sub

    Private Sub txtPrecio1_Leave(sender As Object, e As EventArgs) Handles txtPrecio1.Leave
        txtUtil1.Text = IIf(txtCostoPro.Text > 0, (txtPrecio1.Text / txtCostoPro.Text - 1) * 100, 0)
        txtIVA1.Text = txtPrecio1.Text * (1 + impuesto / 100)
        formato()
    End Sub

    Private Sub txtPrecio2_Leave(sender As Object, e As EventArgs) Handles txtPrecio2.Leave
        txtUtil2.Text = IIf(txtCostoPro.Text > 0, (txtPrecio2.Text / txtCostoPro.Text - 1) * 100, 0)
        txtIVA2.Text = txtPrecio2.Text * (1 + impuesto / 100)
        formato()
    End Sub

    Private Sub txtPrecio3_Leave(sender As Object, e As EventArgs) Handles txtPrecio3.Leave
        txtUtil3.Text = IIf(txtCostoPro.Text > 0, (txtPrecio3.Text / txtCostoPro.Text - 1) * 100, 0)
        txtIVA3.Text = txtPrecio3.Text * (1 + impuesto / 100)
        formato()
    End Sub

    Private Sub txtPrecioU1_Leave(sender As Object, e As EventArgs) Handles txtPrecioU1.Leave
        txtUtilU1.Text = IIf(txtCostoPro.Text > 0, (txtPrecioU1.Text / (txtCostoPro.Text / cantempaq) - 1) * 100, 0)
        txtIVAU1.Text = txtPrecioU1.Text * (1 + impuesto / 100)
        formato()
    End Sub
    Private Sub txtPrecioU2_Leave(sender As Object, e As EventArgs) Handles txtPrecioU2.Leave
        txtUtilU2.Text = IIf(txtCostoPro.Text > 0, (txtPrecioU2.Text / (txtCostoPro.Text / cantempaq) - 1) * 100, 0)
        txtIVAU2.Text = txtPrecioU2.Text * (1 + impuesto / 100)
        formato()
    End Sub
    Private Sub txtPrecioU3_Leave(sender As Object, e As EventArgs) Handles txtPrecioU3.Leave
        txtUtilU3.Text = IIf(txtCostoPro.Text > 0, (txtPrecioU3.Text / (txtCostoPro.Text / cantempaq) - 1) * 100, 0)
        txtIVAU3.Text = txtPrecioU3.Text * (1 + impuesto / 100)
        formato()
    End Sub

    Private Sub txtUtil1_Leave(sender As Object, e As EventArgs) Handles txtUtil1.Leave
        txtPrecio1.Text = txtCostoPro.Text * (1 + txtUtil1.Text / 100)
        txtIVA1.Text = txtPrecio1.Text * (1 + impuesto / 100)
        formato()
    End Sub
    Private Sub txtUtil2_Leave(sender As Object, e As EventArgs) Handles txtUtil2.Leave
        txtPrecio2.Text = txtCostoPro.Text * (1 + txtUtil2.Text / 100)
        txtIVA2.Text = txtPrecio2.Text * (1 + impuesto / 100)
        formato()
    End Sub
    Private Sub txtUtil3_Leave(sender As Object, e As EventArgs) Handles txtUtil3.Leave
        txtPrecio3.Text = txtCostoPro.Text * (1 + txtUtil3.Text / 100)
        txtIVA3.Text = txtPrecio3.Text * (1 + impuesto / 100)
        formato()
    End Sub
    Private Sub txtUtilU1_Leave(sender As Object, e As EventArgs) Handles txtUtilU1.Leave
        txtPrecioU1.Text = txtCostoPro.Text / cantempaq * (1 + txtUtilU1.Text / 100)
        txtIVAU1.Text = txtPrecioU1.Text * (1 + impuesto / 100)
        formato()
    End Sub
    Private Sub txtUtilU2_Leave(sender As Object, e As EventArgs) Handles txtUtilU2.Leave
        txtPrecioU2.Text = txtCostoPro.Text / cantempaq * (1 + txtUtilU2.Text / 100)
        txtIVAU2.Text = txtPrecioU2.Text * (1 + impuesto / 100)
        formato()
    End Sub
    Private Sub txtUtilU3_Leave(sender As Object, e As EventArgs) Handles txtUtilU3.Leave
        txtPrecioU3.Text = txtCostoPro.Text / cantempaq * (1 + txtUtilU3.Text / 100)
        txtIVAU3.Text = txtPrecioU3.Text * (1 + impuesto / 100)
        formato()
    End Sub

    Private Sub txtIVA1_Leave(sender As Object, e As EventArgs) Handles txtIVA1.Leave
        txtPrecio1.Text = txtIVA1.Text / (1 + impuesto / 100)
        txtUtil1.Text = IIf(txtCostoPro.Text > 0, (txtPrecio1.Text / txtCostoPro.Text - 1) * 100, 0)
        formato()
    End Sub

    Private Sub txtIVA2_Leave(sender As Object, e As EventArgs) Handles txtIVA2.Leave
        txtPrecio2.Text = txtIVA2.Text / (1 + impuesto / 100)
        txtUtil2.Text = IIf(txtCostoPro.Text > 0, (txtPrecio2.Text / txtCostoPro.Text - 1) * 100, 0)
        formato()
    End Sub

    Private Sub txtIVA3_Leave(sender As Object, e As EventArgs) Handles txtIVA3.Leave
        txtPrecio3.Text = txtIVA3.Text / (1 + impuesto / 100)
        txtUtil3.Text = IIf(txtCostoPro.Text > 0, (txtPrecio3.Text / txtCostoPro.Text - 1) * 100, 0)
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

    Private Sub txtUtil1_keypress(sender As Object, e As EventArgs) Handles txtUtil1.KeyPress
        NumConFrac(txtUtil1, e)
    End Sub

    Private Sub txtUtil2_keypress(sender As Object, e As EventArgs) Handles txtUtil2.KeyPress
        NumConFrac(txtUtil2, e)
    End Sub

    Private Sub txtUtil3_keypress(sender As Object, e As EventArgs) Handles txtUtil3.KeyPress
        NumConFrac(txtUtil3, e)
    End Sub

    Private Sub txtIVA1_keypress(sender As Object, e As EventArgs) Handles txtIVA1.KeyPress
        NumConFrac(txtIVA1, e)
    End Sub

    Private Sub txtIVA2_keypress(sender As Object, e As EventArgs) Handles txtIVA2.KeyPress
        NumConFrac(txtIVA2, e)
    End Sub

    Private Sub txtIVA3_keypress(sender As Object, e As EventArgs) Handles txtIVA3.KeyPress
        NumConFrac(txtIVA3, e)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim ask As MsgBoxResult = MsgBox("Seguro que desea actualizar?", 4)
        If ask = MsgBoxResult.Yes Then
            abrirconex()
            If (cactprd = 1 Or cactsrv = 1) And cprdiva = 0 Then
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
                preciou3 = " & txtPrecioU3.Text & ",
                util1 = " & txtUtil1.Text & ",
                util2 = " & txtUtil2.Text & ",
                util3 = " & txtUtil3.Text & ",
                utilu1 = " & txtUtilU1.Text & ",
                utilu2 = " & txtUtilU2.Text & ",
                utilu3 = " & txtUtilU3.Text & "
                where codprod = '" & txtCodigo.Text & "'"
                Dim cmd As New SqlCommand(sql, cn)
                Try
                    Dim da As New SqlDataAdapter(cmd)
                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                btnCancelar_Click(sender, e)
            Else
                Dim sql As String = "use [" & My.Settings.basedatos & "];
                declare @factor as decimal(28,8)
                set @factor = " & factor & "
                update opreciosmex
                set costoact = " & txtCostoAct.Text & ",
	            costopro = " & txtCostoPro.Text & ",
                costoant = " & txtCostoAnt.Text & ",
                precio1 = " & txtIVA1.Text & ",
                precio2 = " & txtIVA2.Text & ",
                precio3 = " & txtIVA3.Text & ",
                preciou1 = " & txtIVAU1.Text & ",
                preciou2 = " & txtIVAU2.Text & ",
                preciou3 = " & txtIVAU3.Text & ",
                util1 = " & txtUtil1.Text & ",
                util2 = " & txtUtil2.Text & ",
                util3 = " & txtUtil3.Text & ",
                utilu1 = " & txtUtilU1.Text & ",
                utilu2 = " & txtUtilU2.Text & ",
                utilu3 = " & txtUtilU3.Text & "
                where codprod = '" & txtCodigo.Text & "'"
                Dim cmd As New SqlCommand(sql, cn)
                Try
                    Dim da As New SqlDataAdapter(cmd)
                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                btnCancelar_Click(sender, e)

            End If

        Else
            btnCancelar_Click(sender, e)

        End If



    End Sub


End Class