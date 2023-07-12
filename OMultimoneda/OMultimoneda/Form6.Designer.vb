<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form6
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form6))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.txtCostoAct = New System.Windows.Forms.TextBox()
        Me.txtCostoPro = New System.Windows.Forms.TextBox()
        Me.txtCostoAnt = New System.Windows.Forms.TextBox()
        Me.txtPrecio3 = New System.Windows.Forms.TextBox()
        Me.txtPrecio2 = New System.Windows.Forms.TextBox()
        Me.txtPrecio1 = New System.Windows.Forms.TextBox()
        Me.txtPrecioU3 = New System.Windows.Forms.TextBox()
        Me.txtPrecioU2 = New System.Windows.Forms.TextBox()
        Me.txtPrecioU1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
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
        Me.btnFiltrar = New System.Windows.Forms.Button()
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
        'txtCostoAct
        '
        Me.txtCostoAct.Enabled = False
        Me.txtCostoAct.Location = New System.Drawing.Point(435, 145)
        Me.txtCostoAct.Name = "txtCostoAct"
        Me.txtCostoAct.Size = New System.Drawing.Size(100, 20)
        Me.txtCostoAct.TabIndex = 5
        Me.txtCostoAct.Text = "0"
        '
        'txtCostoPro
        '
        Me.txtCostoPro.Enabled = False
        Me.txtCostoPro.Location = New System.Drawing.Point(435, 171)
        Me.txtCostoPro.Name = "txtCostoPro"
        Me.txtCostoPro.Size = New System.Drawing.Size(100, 20)
        Me.txtCostoPro.TabIndex = 6
        Me.txtCostoPro.Text = "0"
        '
        'txtCostoAnt
        '
        Me.txtCostoAnt.Enabled = False
        Me.txtCostoAnt.Location = New System.Drawing.Point(435, 197)
        Me.txtCostoAnt.Name = "txtCostoAnt"
        Me.txtCostoAnt.Size = New System.Drawing.Size(100, 20)
        Me.txtCostoAnt.TabIndex = 7
        Me.txtCostoAnt.Text = "0"
        '
        'txtPrecio3
        '
        Me.txtPrecio3.Enabled = False
        Me.txtPrecio3.Location = New System.Drawing.Point(447, 293)
        Me.txtPrecio3.Name = "txtPrecio3"
        Me.txtPrecio3.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecio3.TabIndex = 10
        Me.txtPrecio3.Text = "0"
        '
        'txtPrecio2
        '
        Me.txtPrecio2.Enabled = False
        Me.txtPrecio2.Location = New System.Drawing.Point(447, 267)
        Me.txtPrecio2.Name = "txtPrecio2"
        Me.txtPrecio2.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecio2.TabIndex = 9
        Me.txtPrecio2.Text = "0"
        '
        'txtPrecio1
        '
        Me.txtPrecio1.Enabled = False
        Me.txtPrecio1.Location = New System.Drawing.Point(435, 229)
        Me.txtPrecio1.Name = "txtPrecio1"
        Me.txtPrecio1.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecio1.TabIndex = 8
        Me.txtPrecio1.Text = "0"
        '
        'txtPrecioU3
        '
        Me.txtPrecioU3.Enabled = False
        Me.txtPrecioU3.Location = New System.Drawing.Point(447, 376)
        Me.txtPrecioU3.Name = "txtPrecioU3"
        Me.txtPrecioU3.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioU3.TabIndex = 13
        Me.txtPrecioU3.Text = "0"
        '
        'txtPrecioU2
        '
        Me.txtPrecioU2.Enabled = False
        Me.txtPrecioU2.Location = New System.Drawing.Point(447, 350)
        Me.txtPrecioU2.Name = "txtPrecioU2"
        Me.txtPrecioU2.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioU2.TabIndex = 12
        Me.txtPrecioU2.Text = "0"
        '
        'txtPrecioU1
        '
        Me.txtPrecioU1.Enabled = False
        Me.txtPrecioU1.Location = New System.Drawing.Point(447, 324)
        Me.txtPrecioU1.Name = "txtPrecioU1"
        Me.txtPrecioU1.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioU1.TabIndex = 11
        Me.txtPrecioU1.Text = "0"
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
        'btnAceptar
        '
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Location = New System.Drawing.Point(553, 437)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 28
        Me.btnAceptar.Text = "Actualizar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(635, 437)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 29
        Me.btnCancelar.Text = "Cerrar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtMarca)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtBuscar)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
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
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Location = New System.Drawing.Point(552, 114)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(35, 17)
        Me.CheckBox2.TabIndex = 43
        Me.CheckBox2.Text = "Si"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(509, 115)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 13)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "Monto"
        '
        'txtMarca
        '
        Me.txtMarca.Enabled = False
        Me.txtMarca.Location = New System.Drawing.Point(435, 84)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Size = New System.Drawing.Size(100, 20)
        Me.txtMarca.TabIndex = 41
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(367, 87)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 13)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Marca"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(367, 115)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Descuento"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(435, 115)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(35, 17)
        Me.CheckBox1.TabIndex = 38
        Me.CheckBox1.Text = "Si"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.Enabled = False
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(435, 52)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(263, 21)
        Me.ComboBox2.TabIndex = 37
        Me.ComboBox2.Text = "Haga click en la palabra ""Proveedor"" para activar"
        '
        'ComboBox1
        '
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(435, 25)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(263, 21)
        Me.ComboBox1.TabIndex = 36
        Me.ComboBox1.Text = "Haga click en la palabra ""Instancia"" para activar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(367, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Instancia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(367, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Proveedor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(367, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Costo Ant."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(367, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Costo Pro."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(367, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Costo Act."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(379, 244)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Precio 1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(379, 270)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Precio 2"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(379, 296)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Precio 3"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(379, 327)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "PrecioU 1"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(379, 353)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "PrecioU 2"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(379, 379)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "PrecioU 3"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(472, 437)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.btnFiltrar.TabIndex = 42
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'Form6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 485)
        Me.Controls.Add(Me.btnFiltrar)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtPrecioU3)
        Me.Controls.Add(Me.txtPrecioU2)
        Me.Controls.Add(Me.txtPrecioU1)
        Me.Controls.Add(Me.txtPrecio3)
        Me.Controls.Add(Me.txtPrecio2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form6"
        Me.Text = "Ajuste de precios Automatico"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents txtCostoAct As TextBox
    Friend WithEvents txtCostoPro As TextBox
    Friend WithEvents txtCostoAnt As TextBox
    Friend WithEvents txtPrecio3 As TextBox
    Friend WithEvents txtPrecio2 As TextBox
    Friend WithEvents txtPrecio1 As TextBox
    Friend WithEvents txtPrecioU3 As TextBox
    Friend WithEvents txtPrecioU2 As TextBox
    Friend WithEvents txtPrecioU1 As TextBox
    Friend WithEvents Label1 As Label
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
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents txtMarca As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Label15 As Label
End Class
