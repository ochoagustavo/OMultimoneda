Imports System.Xml
Imports System.IO
Imports System.Data.SqlClient


Public Class LoginForm1

    Public Function compruebaSerial()
        Dim Verificado As Boolean = False

        Dim vs As New VerificarSerial
        Dim SerialGenerado As String
        Dim SerialGuardado As String
        Dim serialsaint As String



        Try

            empresas = New SqlCommand("use [" & My.Settings.basedatos & "]; select nroserial from saconf", cn)
            descripcion = empresas.ExecuteReader

            While descripcion.Read()
                serialsaint = descripcion.Item("nroserial")

            End While
            descripcion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If File.Exists("verificador.xml") = False Then
            'File.Create("verificador.xml").Dispose()

            Dim settings As XmlWriterSettings = New XmlWriterSettings()
            settings.Indent = True

            ' Create XmlWriter.
            Using writer As XmlWriter = XmlWriter.Create("verificador.xml", settings)
                ' Begin writing.
                writer.WriteStartDocument()
                writer.WriteStartElement("VerificadorSeriales") ' Root.

                writer.WriteStartElement("serialinfo")
                writer.WriteElementString("serial", "12345")
                writer.WriteEndElement()

                ' End document.
                writer.WriteEndElement()
                writer.WriteEndDocument()
            End Using
        End If

        Dim myXMLfile As String = "verificador.xml"
        Dim fsReadXml As New System.IO.FileStream(myXMLfile, System.IO.FileMode.Open)

        Try

            Dim ds As New DataSet()
            ds.ReadXml(fsReadXml)

            SerialGuardado = (ds.Tables(0).Rows(0).Item(0).ToString)
            SerialGenerado = VerificarSerial.GenerarSerial(serialsaint & My.Settings.basedatos & "OMULTI")

            fsReadXml.Close()

            If SerialGuardado = SerialGenerado Then
                Verificado = True
            Else
                Dim serial As String = SerialGuardado

                If MessageBox.Show("No ha registrado un serial o el que tiene es inválido ¿Desea introducir el serial ahora?", "Serial Incorrecto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    serial = InputBox("Inserte el serial para continuar", "Serial incorrecto")

                    If serial = SerialGenerado Then
                        Verificado = True

                        ' Create XmlWriterSettings.
                        Dim settings As XmlWriterSettings = New XmlWriterSettings()
                        settings.Indent = True

                        ' Create XmlWriter.
                        Using writer As XmlWriter = XmlWriter.Create("verificador.xml", settings)
                            ' Begin writing.
                            writer.WriteStartDocument()
                            writer.WriteStartElement("VerificadorSeriales") ' Root.

                            writer.WriteStartElement("serialinfo")
                            writer.WriteElementString("serial", serial)
                            writer.WriteEndElement()

                            ' End document.
                            writer.WriteEndElement()
                            writer.WriteEndDocument()
                        End Using
                    End If
                Else
                    MessageBox.Show("Lo sentimos, no puede acceder sin haber registrado este software!", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            End If

            Return Verificado

        Catch ex As Exception
            Return False
        Finally
            fsReadXml.Close()
        End Try

    End Function

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        abrirconex()

        If compruebaSerial() = False Then
        Else
            If UsernameTextBox.Text = My.Settings.user And PasswordTextBox.Text = My.Settings.pass Then
                Form1.Show()

                Me.Hide()
            Else
                MsgBox("Usuario o Clave incorrecta")
            End If

        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()

    End Sub

    Private Sub ConexionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConexionToolStripMenuItem.Click
        Form2.Show()

    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Closed


    End Sub
End Class
