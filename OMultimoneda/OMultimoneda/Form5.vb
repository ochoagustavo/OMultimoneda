Imports System.Data.SqlClient
Public Class Form5
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim r As New Globalization.CultureInfo("es-ES")
        r.NumberFormat.CurrencyDecimalSeparator = "."
        r.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = r

        abrirconex()

        Try
            empresas = New SqlCommand("use " & My.Settings.basedatos & "; 
            select factor from SACONF", cn)
            descripcion = empresas.ExecuteReader
            While descripcion.Read()
                factor = descripcion.Item("factor")
                TextBox1.Text = FormatNumber(factor, decimales)
            End While
            descripcion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        abrirconex()
        If cactprd = 1 Then
            If cprdpre = 1 Then
                If cprdiva = 1 Then
                    Dim sql As String = "use [" & My.Settings.basedatos & "];
                    declare @factor as decimal(28,8)
                    set @factor = " & Me.TextBox1.Text & "
                    update opreciosmex
                    set precio1 = b.precio1 / @factor * case when b.esexento = 1 then 1 else isnull((1+c.monto/100),1) end,
	                    precio2 = b.precio2 / @factor * case when b.esexento = 1 then 1 else isnull((1+c.monto/100),1) end,
	                    precio3 = b.precio3 / @factor * case when b.esexento = 1 then 1 else isnull((1+c.monto/100),1) end,
                        preciou1 = b.preciou / @factor * case when b.esexento = 1 then 1 else isnull((1+c.monto/100),1) end,
	                    preciou2 = b.preciou2 / @factor * case when b.esexento = 1 then 1 else isnull((1+c.monto/100),1) end,
	                    preciou3 = b.preciou3 / @factor * case when b.esexento = 1 then 1 else isnull((1+c.monto/100),1) end
                    from opreciosmex a
                    inner join saprod b
                    on a.codprod = b.codprod
                    left join sataxprd c
                    on a.codprod = c.codprod"
                    Dim cmd As New SqlCommand(sql, cn)
                    Try
                        Dim da As New SqlDataAdapter(cmd)
                        cmd.ExecuteNonQuery()
                        MsgBox("Precios productos actualizados con exito", MsgBoxStyle.Information)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    Dim sql As String = "use [" & My.Settings.basedatos & "];
                    declare @factor as decimal(28,8)
                    set @factor = " & Me.TextBox1.Text & "
                    update opreciosmex
                    set precio1 = a.precio1 / @factor,
	                    precio2 = a.precio2 / @factor,
	                    precio3 = a.precio3 / @factor,
                        preciou1 = a.preciou / @factor,
	                    preciou2 = a.preciou2 / @factor,
	                    preciou3 = a.preciou3 / @factor
                    from saprod a 
                    inner join opreciosmex b
                    on a.codprod = b.codprod"
                    Dim cmd As New SqlCommand(sql, cn)
                    Try
                        Dim da As New SqlDataAdapter(cmd)
                        cmd.ExecuteNonQuery()
                        MsgBox("Precios productos actualizados con exito", MsgBoxStyle.Information)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            End If
            If cprdcos = 1 Then
                Dim sql As String = "use [" & My.Settings.basedatos & "];
                    declare @factor as decimal(28,8)
                    set @factor = " & Me.TextBox1.Text & "
                    update opreciosmex
                    set costoact = b.costact / @factor, 
	                    costoant = b.costant / @factor, 
	                    costopro = b.costpro / @factor 
                    from opreciosmex a
                    inner join saprod b
                    on a.codprod = b.codprod"
                Dim cmd As New SqlCommand(sql, cn)
                Try
                    Dim da As New SqlDataAdapter(cmd)
                    cmd.ExecuteNonQuery()
                    MsgBox("Costos productos actualizados con exito", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If


        End If
        If cactsrv = 1 Then
            If csrvpre = 1 Then
                If csrviva = 1 Then
                    Dim sql As String = "use [" & My.Settings.basedatos & "];
                    declare @factor as decimal(28,8)
                    set @factor = " & Me.TextBox1.Text & "
                    update opreciosmex
                    set precio1 = b.precio1 / @factor * case when b.esexento = 1 then 1 else isnull((1+c.monto/100),1) end,
	                    precio2 = b.precio2 / @factor * case when b.esexento = 1 then 1 else isnull((1+c.monto/100),1) end,
	                    precio3 = b.precio3 / @factor * case when b.esexento = 1 then 1 else isnull((1+c.monto/100),1) end
                    from opreciosmex a
                    inner join saserv b
                    on b.codserv = a.codprod
                    left join sataxsrv c
                    on a.codprod = c.codserv"
                    Dim cmd As New SqlCommand(sql, cn)
                    Try
                        Dim da As New SqlDataAdapter(cmd)
                        cmd.ExecuteNonQuery()
                        MsgBox("Precios servicios actualizados con exito", MsgBoxStyle.Information)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    Dim sql As String = "use [" & My.Settings.basedatos & "];
                    declare @factor as decimal(28,8)
                    set @factor = " & Me.TextBox1.Text & "
                    update opreciosmex
                    set precio1 = a.precio1 / @factor,
	                    precio2 = a.precio2 / @factor,
	                    precio3 = a.precio3 / @factor
                    from saserv a 
                    inner join opreciosmex b
                    on a.codserv = b.codprod"
                    Dim cmd As New SqlCommand(sql, cn)
                    Try
                        Dim da As New SqlDataAdapter(cmd)
                        cmd.ExecuteNonQuery()
                        MsgBox("Precios servicios actualizados con exito", MsgBoxStyle.Information)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            End If
            If csrvcos = 1 Then
                Dim sql As String = "use [" & My.Settings.basedatos & "];
                    declare @factor as decimal(28,8)
                    set @factor = " & Me.TextBox1.Text & "
                    update opreciosmex
                    set costoact = b.costo / @factor
                    from opreciosmex a
                    inner join saserv b
                    on a.codprod = b.codserv"
                Dim cmd As New SqlCommand(sql, cn)
                Try
                    Dim da As New SqlDataAdapter(cmd)
                    cmd.ExecuteNonQuery()
                    MsgBox("Costos servicios actualizados con exito", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

        End If


    End Sub
End Class