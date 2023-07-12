<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtDescrip = New System.Windows.Forms.TextBox()
        Me.txtDescrip2 = New System.Windows.Forms.TextBox()
        Me.txtCostoAct = New System.Windows.Forms.TextBox()
        Me.txtCostoPro = New System.Windows.Forms.TextBox()
        Me.txtCostoAnt = New System.Windows.Forms.TextBox()
        Me.txtPrecio3 = New System.Windows.Forms.TextBox()
        Me.txtPrecio2 = New System.Windows.Forms.TextBox()
        Me.txtPrecio1 = New System.Windows.Forms.TextBox()
        Me.txtPrecioU3 = New System.Windows.Forms.TextBox()
        Me.txtPrecioU2 = New System.Windows.Forms.TextBox()
        Me.txtPrecioU1 = New System.Windows.Forms.TextBox()
        Me.txtUtilU3 = New System.Windows.Forms.TextBox()
        Me.txtUtilU2 = New System.Windows.Forms.TextBox()
        Me.txtUtilU1 = New System.Windows.Forms.TextBox()
        Me.txtUtil3 = New System.Windows.Forms.TextBox()
        Me.txtUtil2 = New System.Windows.Forms.TextBox()
        Me.txtUtil1 = New System.Windows.Forms.TextBox()
        Me.txtIVAU3 = New System.Windows.Forms.TextBox()
        Me.txtIVAU2 = New System.Windows.Forms.TextBox()
        Me.txtIVAU1 = New System.Windows.Forms.TextBox()
        Me.txtIVA3 = New System.Windows.Forms.TextBox()
        Me.txtIVA2 = New System.Windows.Forms.TextBox()
        Me.txtIVA1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridView1.Location = New System.Drawing.Point(9, 51)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(313, 335)
        Me.DataGridView1.TabIndex = 0
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(55, 25)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(249, 20)
        Me.txtBuscar.TabIndex = 1
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(435, 25)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigo.TabIndex = 2
        '
        'txtDescrip
        '
        Me.txtDescrip.Enabled = False
        Me.txtDescrip.Location = New System.Drawing.Point(435, 51)
        Me.txtDescrip.Name = "txtDescrip"
        Me.txtDescrip.Size = New System.Drawing.Size(263, 20)
        Me.txtDescrip.TabIndex = 3
        '
        'txtDescrip2
        '
        Me.txtDescrip2.Enabled = False
        Me.txtDescrip2.Location = New System.Drawing.Point(435, 77)
        Me.txtDescrip2.Name = "txtDescrip2"
        Me.txtDescrip2.Size = New System.Drawing.Size(263, 20)
        Me.txtDescrip2.TabIndex = 4
        '
        'txtCostoAct
        '
        Me.txtCostoAct.Enabled = False
        Me.txtCostoAct.Location = New System.Drawing.Point(435, 115)
        Me.txtCostoAct.Name = "txtCostoAct"
        Me.txtCostoAct.Size = New System.Drawing.Size(100, 20)
        Me.txtCostoAct.TabIndex = 5
        Me.txtCostoAct.Text = "0"
        '
        'txtCostoPro
        '
        Me.txtCostoPro.Enabled = False
        Me.txtCostoPro.Location = New System.Drawing.Point(435, 141)
        Me.txtCostoPro.Name = "txtCostoPro"
        Me.txtCostoPro.Size = New System.Drawing.Size(100, 20)
        Me.txtCostoPro.TabIndex = 6
        Me.txtCostoPro.Text = "0"
        '
        'txtCostoAnt
        '
        Me.txtCostoAnt.Enabled = False
        Me.txtCostoAnt.Location = New System.Drawing.Point(435, 167)
        Me.txtCostoAnt.Name = "txtCostoAnt"
        Me.txtCostoAnt.Size = New System.Drawing.Size(100, 20)
        Me.txtCostoAnt.TabIndex = 7
        Me.txtCostoAnt.Text = "0"
        '
        'txtPrecio3
        '
        Me.txtPrecio3.Enabled = False
        Me.txtPrecio3.Location = New System.Drawing.Point(447, 271)
        Me.txtPrecio3.Name = "txtPrecio3"
        Me.txtPrecio3.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecio3.TabIndex = 10
        Me.txtPrecio3.Text = "0"
        '
        'txtPrecio2
        '
        Me.txtPrecio2.Enabled = False
        Me.txtPrecio2.Location = New System.Drawing.Point(447, 245)
        Me.txtPrecio2.Name = "txtPrecio2"
        Me.txtPrecio2.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecio2.TabIndex = 9
        Me.txtPrecio2.Text = "0"
        '
        'txtPrecio1
        '
        Me.txtPrecio1.Enabled = False
        Me.txtPrecio1.Location = New System.Drawing.Point(435, 207)
        Me.txtPrecio1.Name = "txtPrecio1"
        Me.txtPrecio1.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecio1.TabIndex = 8
        Me.txtPrecio1.Text = "0"
        '
        'txtPrecioU3
        '
        Me.txtPrecioU3.Enabled = False
        Me.txtPrecioU3.Location = New System.Drawing.Point(447, 362)
        Me.txtPrecioU3.Name = "txtPrecioU3"
        Me.txtPrecioU3.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioU3.TabIndex = 13
        Me.txtPrecioU3.Text = "0"
        '
        'txtPrecioU2
        '
        Me.txtPrecioU2.Enabled = False
        Me.txtPrecioU2.Location = New System.Drawing.Point(447, 336)
        Me.txtPrecioU2.Name = "txtPrecioU2"
        Me.txtPrecioU2.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioU2.TabIndex = 12
        Me.txtPrecioU2.Text = "0"
        '
        'txtPrecioU1
        '
        Me.txtPrecioU1.Enabled = False
        Me.txtPrecioU1.Location = New System.Drawing.Point(447, 310)
        Me.txtPrecioU1.Name = "txtPrecioU1"
        Me.txtPrecioU1.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioU1.TabIndex = 11
        Me.txtPrecioU1.Text = "0"
        '
        'txtUtilU3
        '
        Me.txtUtilU3.Enabled = False
        Me.txtUtilU3.Location = New System.Drawing.Point(553, 362)
        Me.txtUtilU3.Name = "txtUtilU3"
        Me.txtUtilU3.Size = New System.Drawing.Size(51, 20)
        Me.txtUtilU3.TabIndex = 19
        Me.txtUtilU3.Text = "0"
        '
        'txtUtilU2
        '
        Me.txtUtilU2.Enabled = False
        Me.txtUtilU2.Location = New System.Drawing.Point(553, 336)
        Me.txtUtilU2.Name = "txtUtilU2"
        Me.txtUtilU2.Size = New System.Drawing.Size(51, 20)
        Me.txtUtilU2.TabIndex = 18
        Me.txtUtilU2.Text = "0"
        '
        'txtUtilU1
        '
        Me.txtUtilU1.Enabled = False
        Me.txtUtilU1.Location = New System.Drawing.Point(553, 310)
        Me.txtUtilU1.Name = "txtUtilU1"
        Me.txtUtilU1.Size = New System.Drawing.Size(51, 20)
        Me.txtUtilU1.TabIndex = 17
        Me.txtUtilU1.Text = "0"
        '
        'txtUtil3
        '
        Me.txtUtil3.Enabled = False
        Me.txtUtil3.Location = New System.Drawing.Point(553, 271)
        Me.txtUtil3.Name = "txtUtil3"
        Me.txtUtil3.Size = New System.Drawing.Size(51, 20)
        Me.txtUtil3.TabIndex = 16
        Me.txtUtil3.Text = "0"
        '
        'txtUtil2
        '
        Me.txtUtil2.Enabled = False
        Me.txtUtil2.Location = New System.Drawing.Point(553, 245)
        Me.txtUtil2.Name = "txtUtil2"
        Me.txtUtil2.Size = New System.Drawing.Size(51, 20)
        Me.txtUtil2.TabIndex = 15
        Me.txtUtil2.Text = "0"
        '
        'txtUtil1
        '
        Me.txtUtil1.Enabled = False
        Me.txtUtil1.Location = New System.Drawing.Point(553, 219)
        Me.txtUtil1.Name = "txtUtil1"
        Me.txtUtil1.Size = New System.Drawing.Size(51, 20)
        Me.txtUtil1.TabIndex = 14
        Me.txtUtil1.Text = "0"
        '
        'txtIVAU3
        '
        Me.txtIVAU3.Enabled = False
        Me.txtIVAU3.Location = New System.Drawing.Point(610, 362)
        Me.txtIVAU3.Name = "txtIVAU3"
        Me.txtIVAU3.Size = New System.Drawing.Size(100, 20)
        Me.txtIVAU3.TabIndex = 25
        Me.txtIVAU3.Text = "0"
        '
        'txtIVAU2
        '
        Me.txtIVAU2.Enabled = False
        Me.txtIVAU2.Location = New System.Drawing.Point(610, 336)
        Me.txtIVAU2.Name = "txtIVAU2"
        Me.txtIVAU2.Size = New System.Drawing.Size(100, 20)
        Me.txtIVAU2.TabIndex = 24
        Me.txtIVAU2.Text = "0"
        '
        'txtIVAU1
        '
        Me.txtIVAU1.Enabled = False
        Me.txtIVAU1.Location = New System.Drawing.Point(610, 310)
        Me.txtIVAU1.Name = "txtIVAU1"
        Me.txtIVAU1.Size = New System.Drawing.Size(100, 20)
        Me.txtIVAU1.TabIndex = 23
        Me.txtIVAU1.Text = "0"
        '
        'txtIVA3
        '
        Me.txtIVA3.Enabled = False
        Me.txtIVA3.Location = New System.Drawing.Point(610, 271)
        Me.txtIVA3.Name = "txtIVA3"
        Me.txtIVA3.Size = New System.Drawing.Size(100, 20)
        Me.txtIVA3.TabIndex = 22
        Me.txtIVA3.Text = "0"
        '
        'txtIVA2
        '
        Me.txtIVA2.Enabled = False
        Me.txtIVA2.Location = New System.Drawing.Point(610, 245)
        Me.txtIVA2.Name = "txtIVA2"
        Me.txtIVA2.Size = New System.Drawing.Size(100, 20)
        Me.txtIVA2.TabIndex = 21
        Me.txtIVA2.Text = "0"
        '
        'txtIVA1
        '
        Me.txtIVA1.Enabled = False
        Me.txtIVA1.Location = New System.Drawing.Point(610, 219)
        Me.txtIVA1.Name = "txtIVA1"
        Me.txtIVA1.Size = New System.Drawing.Size(100, 20)
        Me.txtIVA1.TabIndex = 20
        Me.txtIVA1.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Buscar:"
        '
        'btnModificar
        '
        Me.btnModificar.Enabled = False
        Me.btnModificar.Location = New System.Drawing.Point(472, 437)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 27
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Location = New System.Drawing.Point(553, 437)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 28
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Location = New System.Drawing.Point(635, 437)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 29
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtBuscar)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDescrip)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDescrip2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCostoAct)
        Me.GroupBox1.Controls.Add(Me.txtCostoPro)
        Me.GroupBox1.Controls.Add(Me.txtCostoAnt)
        Me.GroupBox1.Controls.Add(Me.txtPrecio1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(718, 407)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Productos/Servicios"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(367, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Codigo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(367, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Descripcion"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(367, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Costo Ant."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(367, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Costo Pro."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(367, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Costo Act."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(379, 222)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Precio 1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(379, 248)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Precio 2"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(379, 274)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Precio 3"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(379, 313)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "PrecioU 1"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(379, 339)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "PrecioU 2"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(379, 365)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "PrecioU 3"
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 485)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.txtIVAU3)
        Me.Controls.Add(Me.txtIVAU2)
        Me.Controls.Add(Me.txtIVAU1)
        Me.Controls.Add(Me.txtIVA3)
        Me.Controls.Add(Me.txtIVA2)
        Me.Controls.Add(Me.txtIVA1)
        Me.Controls.Add(Me.txtUtilU3)
        Me.Controls.Add(Me.txtUtilU2)
        Me.Controls.Add(Me.txtUtilU1)
        Me.Controls.Add(Me.txtUtil3)
        Me.Controls.Add(Me.txtUtil2)
        Me.Controls.Add(Me.txtUtil1)
        Me.Controls.Add(Me.txtPrecioU3)
        Me.Controls.Add(Me.txtPrecioU2)
        Me.Controls.Add(Me.txtPrecioU1)
        Me.Controls.Add(Me.txtPrecio3)
        Me.Controls.Add(Me.txtPrecio2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form4"
        Me.Text = "Ajuste de precios Manual"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents txtDescrip As TextBox
    Friend WithEvents txtDescrip2 As TextBox
    Friend WithEvents txtCostoAct As TextBox
    Friend WithEvents txtCostoPro As TextBox
    Friend WithEvents txtCostoAnt As TextBox
    Friend WithEvents txtPrecio3 As TextBox
    Friend WithEvents txtPrecio2 As TextBox
    Friend WithEvents txtPrecio1 As TextBox
    Friend WithEvents txtPrecioU3 As TextBox
    Friend WithEvents txtPrecioU2 As TextBox
    Friend WithEvents txtPrecioU1 As TextBox
    Friend WithEvents txtUtilU3 As TextBox
    Friend WithEvents txtUtilU2 As TextBox
    Friend WithEvents txtUtilU1 As TextBox
    Friend WithEvents txtUtil3 As TextBox
    Friend WithEvents txtUtil2 As TextBox
    Friend WithEvents txtUtil1 As TextBox
    Friend WithEvents txtIVAU3 As TextBox
    Friend WithEvents txtIVAU2 As TextBox
    Friend WithEvents txtIVAU1 As TextBox
    Friend WithEvents txtIVA3 As TextBox
    Friend WithEvents txtIVA2 As TextBox
    Friend WithEvents txtIVA1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
End Class
