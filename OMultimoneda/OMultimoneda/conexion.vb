Imports System.Data.SqlClient
Imports System.Data.Sql

Module conexion
    Public cn As SqlConnection
    Public cadena As String
    Public empresas As SqlCommand
    Public descripcion As SqlDataReader
    Public tablaprd As String
    Public activoprd As Integer
    Public indprd As Integer
    Public tablasrv As String
    Public activosrv As Integer
    Public indsrv As Integer
    Public tablacom As String
    Public activocom As Integer
    Public indcom As Integer

    Public factor As Decimal
    Public factor2 As Decimal
    Public factor3 As Decimal
    Public factorm As Decimal

    Public cactprd As Integer
    Public cactsrv As Integer
    Public cactcom As Integer
    Public cprdpre As Integer
    Public cprdcos As Integer
    Public cprdiva As Integer
    Public csrvpre As Integer
    Public csrvcos As Integer
    Public csrviva As Integer
    Public ccompre As Integer
    Public ccomcos As Integer
    Public decimales As Integer = 2

    Sub abrirconex()
        cn = New SqlConnection
        cadena = "Data Source=" & My.Settings.servSQL & ";Initial Catalog=" & My.Settings.basedatos & ";Persist Security Info=True;User ID=" & My.Settings.userSQL & ";Password=" & My.Settings.passSQL & ";MultipleActiveResultSets=True"
        cn.ConnectionString = cadena
        If cn.State = 1 Then
            cn.Close()
        Else
            Try
                cn.Open()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Sub tabla_configuracion()
        Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='OMConf' AND XTYPE='U')
            BEGIN
            EXEC('CREATE TABLE [dbo].[OMConf](
	            [id] [int] IDENTITY(1,1) NOT NULL,
	            [actprd] [int] NOT NULL DEFAULT(0),
	            [actsrv] [int] NOT NULL DEFAULT(0),
				[actcom] [int] NOT NULL DEFAULT(0),
	            [prdpre] [int] NOT NULL DEFAULT(0),
	            [srvpre] [int] NOT NULL DEFAULT(0),
				[compre] [int] NOT NULL DEFAULT(0),
	            [prdcos] [int] NOT NULL DEFAULT(0),
	            [srvcos] [int] NOT NULL DEFAULT(0),
				[comcos] [int] NOT NULL DEFAULT(0),
	            [prdiva] [int] NOT NULL DEFAULT(0),
	            [srviva] [int] NOT NULL DEFAULT(0)
            ) ON [PRIMARY]')
            END
            
            IF NOT EXISTS (SELECT ID FROM OMConf)
            BEGIN
            EXEC('insert into omconf (actprd,actsrv,prdpre,srvpre,prdcos,srvcos,prdiva,srviva,actcom,compre,comcos)
            values (0,0,0,0,0,0,0,0,0,0,0)')
            END"
        Dim cmd As New SqlCommand(sql, cn)
        cmd.CommandTimeout = 300
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub fn_redondeo()
        Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='fnOMRedondeo' AND XTYPE='FN')
            BEGIN
            EXEC('CREATE FUNCTION fnOMRedondeo() RETURNS int AS
                begin
	                RETURN(" & decimales & ")
                end')
            END"
        Dim cmd As New SqlCommand(sql, cn)
        cmd.CommandTimeout = 300
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub act_fn_redondeo()
        Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='fnOMRedondeo' AND XTYPE='FN')
            BEGIN
            EXEC('ALTER FUNCTION fnOMRedondeo() RETURNS int AS
                begin
	                RETURN(" & decimales & ")
                end')
            END"
        Dim cmd As New SqlCommand(sql, cn)
        cmd.CommandTimeout = 300
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub leer_configuracion()
        Try
            empresas = New SqlCommand("use [" & My.Settings.basedatos & "]; 
            select actprd, actsrv, actcom, prdpre, srvpre, prdcos, srvcos, prdiva, srviva, comcos, compre from omconf", cn)
            descripcion = empresas.ExecuteReader
            While descripcion.Read()
                cactprd = descripcion.Item("actprd")
                cactsrv = descripcion.Item("actsrv")
                cactcom = descripcion.Item("actcom")
                cprdpre = descripcion.Item("prdpre")
                csrvpre = descripcion.Item("srvpre")
                cprdcos = descripcion.Item("prdcos")
                csrvcos = descripcion.Item("srvcos")
                cprdiva = descripcion.Item("prdiva")
                csrviva = descripcion.Item("srviva")
                ccomcos = descripcion.Item("comcos")
                ccompre = descripcion.Item("compre")
            End While
            descripcion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            empresas = New SqlCommand("use [" & My.Settings.basedatos & "]; 
            select dbo.fnomredondeo() as redondeo from omconf", cn)
            descripcion = empresas.ExecuteReader
            While descripcion.Read()
                decimales = descripcion.Item("redondeo")
            End While
            descripcion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            empresas = New SqlCommand("use [" & My.Settings.basedatos & "]; 
            select factor, factorm from saconf", cn)
            descripcion = empresas.ExecuteReader
            While descripcion.Read()
                factor = descripcion.Item("factor")
                factorm = descripcion.Item("factorm")
            End While
            descripcion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub



    Sub act_configuracion()
        Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            update omconf set actprd = " & cactprd &
            ", actsrv = " & cactsrv &
            ", actcom = " & cactcom &
            ", prdpre = " & cprdpre &
            ", srvpre = " & csrvpre &
            ", compre = " & ccompre &
            ", prdcos = " & cprdcos &
            ", srvcos = " & csrvcos &
            ", comcos = " & ccomcos &
            ", prdiva = " & cprdiva &
            ", srviva = " & csrviva

        Dim cmd As New SqlCommand(sql, cn)
        cmd.CommandTimeout = 300
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub creartabla()
        Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='OPreciosMex' AND XTYPE='U')
            BEGIN
            EXEC('CREATE TABLE [dbo].[OPreciosMex](
	                [CodProd] [varchar](15) NOT NULL,
	                [CostoAct] [decimal](28, 4) NOT NULL DEFAULT(0),
	                [CostoAnt] [decimal](28, 4) NOT NULL DEFAULT(0),
	                [CostoPro] [decimal](28, 4) NOT NULL DEFAULT(0),
	                [Precio1] [decimal](28, 4) NOT NULL DEFAULT(0),
	                [Precio2] [decimal](28, 4) NOT NULL DEFAULT(0),
	                [Precio3] [decimal](28, 4) NOT NULL DEFAULT(0),
                    [PrecioU1] [decimal](28, 4) NOT NULL DEFAULT(0),
	                [PrecioU2] [decimal](28, 4) NOT NULL DEFAULT(0),
	                [PrecioU3] [decimal](28, 4) NOT NULL DEFAULT(0),
                    [Util1] [decimal](28, 4) NOT NULL DEFAULT(0),
	                [Util2] [decimal](28, 4) NOT NULL DEFAULT(0),
	                [Util3] [decimal](28, 4) NOT NULL DEFAULT(0),
                    [UtilU1] [decimal](28, 4) NOT NULL DEFAULT(0),
	                [UtilU2] [decimal](28, 4) NOT NULL DEFAULT(0),
	                [UtilU3] [decimal](28, 4) NOT NULL DEFAULT(0))')		
            END
            

            IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE (COLUMN_NAME = 'PrecioU1' OR COLUMN_NAME = 'PrecioU2' OR COLUMN_NAME = 'PrecioU3') AND TABLE_NAME = 'OPreciosMex')
            BEGIN
	            EXEC('ALTER TABLE Opreciosmex ADD PrecioU1 decimal(28,4) NOT NULL DEFAULT(0), PrecioU2 decimal(28,4) NOT NULL DEFAULT(0), PrecioU3 decimal(28,4) NOT NULL DEFAULT(0)')
	        END

            IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE (COLUMN_NAME = 'Util1' OR COLUMN_NAME = 'Util2' OR COLUMN_NAME = 'Util3') AND TABLE_NAME = 'OPreciosMex')
            BEGIN
	            EXEC('ALTER TABLE Opreciosmex ADD Util1 decimal(28,4) NOT NULL DEFAULT(0), Util2 decimal(28,4) NOT NULL DEFAULT(0), Util3 decimal(28,4) NOT NULL DEFAULT(0), UtilU1 decimal(28,4) NOT NULL DEFAULT(0), UtilU2 decimal(28,4) NOT NULL DEFAULT(0), UtilU3 decimal(28,4) NOT NULL DEFAULT(0)')
	        END
            "
        Dim cmd As New SqlCommand(sql, cn)
        cmd.CommandTimeout = 300
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub refrescartabla()
        Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='OPreciosMex' AND XTYPE='U')
            BEGIN
            EXEC('INSERT INTO OPRECIOSMEX (CODPROD,COSTOACT,COSTOANT,COSTOPRO,PRECIO1,PRECIO2,PRECIO3,PRECIOU1,PRECIOU2,PRECIOU3,UTIL1,UTIL2,UTIL3,UTILU1,UTILU2,UTILU3)
            SELECT CODPROD,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 FROM SAPROD where saprod.codprod not in (select codprod from opreciosmex)')

            EXEC('INSERT INTO OPRECIOSMEX (CODPROD,COSTOACT,COSTOANT,COSTOPRO,PRECIO1,PRECIO2,PRECIO3,UTIL1,UTIL2,UTIL3,UTILU1,UTILU2,UTILU3)
            SELECT CODSERV,0,0,0,0,0,0,0,0,0,0,0,0 FROM SASERV where saserv.codserv not in (select codprod from opreciosmex)')
            END"
        Dim cmd As New SqlCommand(sql, cn)
        cmd.CommandTimeout = 300
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Sub actprd()

        Try
            empresas = New SqlCommand("use [" & My.Settings.basedatos & "]; 
            select isnull((select max(NumGrp) maxi from SAAGRUPOS 
                    where CodTbl = 'SAPROD' and NombreGrp = 'OMultimoneda'),0) as ActivoPrd", cn)
            descripcion = empresas.ExecuteReader
            While descripcion.Read()
                activoprd = descripcion.Item("ActivoPrd")
            End While
            descripcion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If activoprd = 0 Then
            Try
                empresas = New SqlCommand("use [" & My.Settings.basedatos & "]; 
                select isnull((select max(NumGrp) MaxNumGrp from SAAGRUPOS 
                        where CodTbl = 'SAPROD'),0)+1 as IndPrd", cn)
                descripcion = empresas.ExecuteReader
                While descripcion.Read()
                    indprd = descripcion.Item("indPrd")
                End While
                descripcion.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If indprd = 0 Then

        Else
            Try
                Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            declare @gmax int = " & indprd & "
            INSERT SAAGRUPOS  
	        (CodTbl,NumGrp,NombreGrp,AliasGrp,EsTrans,NMeses,NMovim) 
	        values('SAPROD',@Gmax,'OMultimoneda','OMultimoneda',0,0,0)
            
            DELETE FROM SAACAMPOS WHERE CODTBL = 'SAPROD' AND NumGrp = @GMAX
	        INSERT SAACAMPOS  
	        (CodTbl,NumGrp,NombCpo,AliasCpo,TipoCpo,Longitud,Requerido,CBusqueda) 
	        VALUES
	        ('SAPROD',@Gmax,'CostoActual','CostoActual',106,13,0,0),
	        ('SAPROD',@Gmax,'CostoAnterior','CostoAnterior',106,13,0,0),
	        ('SAPROD',@Gmax,'CostoPromedio','CostoPromedio',106,13,0,0),
	        ('SAPROD',@Gmax,'Precio1','Precio1',106,13,0,0),
	        ('SAPROD',@Gmax,'Precio2','Precio2',106,13,0,0),
	        ('SAPROD',@Gmax,'Precio3','Precio3',106,13,0,0),
            ('SAPROD',@Gmax,'PrecioU1','PrecioU1',106,13,0,0),
            ('SAPROD',@Gmax,'PrecioU2','PrecioU2',106,13,0,0),
            ('SAPROD',@Gmax,'PrecioU3','PrecioU3',106,13,0,0)
	        Insert into SAAOPER 
	        (CodTbl,NumGrp,NroOper,PDtaReq) 
	        Values('SAPROD',@Gmax,300,0)
            "
                Dim cmd As New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Try
                tablaprd = "SAPROD_" & Format(indprd, "00")
                Dim sql As String = "use [" & My.Settings.basedatos & "]; 
                IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[" & tablaprd & "]'))
                BEGIN
                EXEC('DROP VIEW [dbo].[" & tablaprd & "]')
                END
                IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[" & tablaprd & "]'))
                BEGIN
                EXEC('CREATE VIEW [dbo].[" & tablaprd & "] AS
                select 
	                CodProd
	                ,costoact CostoActual
	                ,costoant CostoAnterior
	                ,costopro CostoPromedio
	                ,precio1 Precio1
	                ,precio2 Precio2
	                ,precio3 Precio3
                    ,precioU1 PrecioU1
                    ,precioU2 PrecioU2
                    ,precioU3 PrecioU3
                from [dbo].[OPRECIOSMEX];')
                END"
                Dim cmd As New SqlCommand(sql, cn)
                cmd.CommandTimeout = 300
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Sub actsrv()
        Try
            empresas = New SqlCommand("use [" & My.Settings.basedatos & "]; 
            select isnull((select max(NumGrp) maxi from SAAGRUPOS 
                    where CodTbl = 'SASERV' and NombreGrp = 'OMultimoneda'),0) as ActivoSrv", cn)
            descripcion = empresas.ExecuteReader
            While descripcion.Read()
                activosrv = descripcion.Item("ActivoSrv")
            End While
            descripcion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If activosrv = 0 Then
            Try
                empresas = New SqlCommand("use [" & My.Settings.basedatos & "]; 
                select isnull((select max(NumGrp) MaxNumGrp from SAAGRUPOS 
                        where CodTbl = 'SASERV'),0)+1 as IndSrv", cn)
                descripcion = empresas.ExecuteReader
                While descripcion.Read()
                    indsrv = descripcion.Item("IndSrv")
                End While
                descripcion.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If indsrv = 0 Then

        Else
            Try
                Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            declare @gmax int = " & indsrv & "
            INSERT SAAGRUPOS  
	        (CodTbl,NumGrp,NombreGrp,AliasGrp,EsTrans,NMeses,NMovim) 
	        values('SASERV',@Gmax,'OMultimoneda','OMultimoneda',0,0,0)
            
            DELETE FROM SAACAMPOS WHERE CODTBL = 'SASERV' AND NUMGRP = @GMAX
	        INSERT SAACAMPOS  
	        (CodTbl,NumGrp,NombCpo,AliasCpo,TipoCpo,Longitud,Requerido,CBusqueda) 
	        VALUES
	        ('SASERV',@Gmax,'Costo','Costo',106,13,0,0),
	        ('SASERV',@Gmax,'Precio1','Precio1',106,13,0,0),
	        ('SASERV',@Gmax,'Precio2','Precio2',106,13,0,0),
	        ('SASERV',@Gmax,'Precio3','Precio3',106,13,0,0)
	        Insert into SAAOPER 
	        (CodTbl,NumGrp,NroOper,PDtaReq) 
	        Values('SASERV',@Gmax,300,0)
            "
                Dim cmd As New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Try
                tablasrv = "SASERV_" & Format(indsrv, "00")
                Dim sql As String = "use [" & My.Settings.basedatos & "]; 
                IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[" & tablasrv & "]'))  
                BEGIN
                EXEC('DROP VIEW [dbo].[" & tablasrv & "]')
                END
                IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[" & tablasrv & "]'))  
                BEGIN
                EXEC('CREATE VIEW [dbo].[" & tablasrv & "] AS
                select 
	                CodProd CodServ
	                ,costoact Costo
	                ,precio1 Precio1
	                ,precio2 Precio2
	                ,precio3 Precio3
                from [dbo].[OPRECIOSMEX];')
                END"
                Dim cmd As New SqlCommand(sql, cn)
                cmd.CommandTimeout = 300
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Sub desprd()
        Try
            empresas = New SqlCommand("use [" & My.Settings.basedatos & "]; 
            select isnull((select max(NumGrp) maxi from SAAGRUPOS 
                    where CodTbl = 'SAPROD' and NombreGrp = 'OMultimoneda'),0) as ActivoPrd", cn)
            descripcion = empresas.ExecuteReader
            While descripcion.Read()
                activoprd = descripcion.Item("ActivoPrd")
            End While
            descripcion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If activoprd = 0 Then
        Else

            Try
                Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            declare @NumGrp int = " & activoprd & "
            DROP VIEW SAPROD_" & Format(activoprd, "00") & "
            IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='SPOProductos' AND XTYPE='P')
            BEGIN
			EXEC('DROP PROCEDURE [dbo].[SPOProductos]')
            END
            delete SAAGRUPOS  where CodTbl = 'SAPROD' and NumGrp = @NumGrp
            delete SAAOPER	  where CodTbl = 'SAPROD' and NumGrp = @NumGrp
            delete SAACAMPOS  where CodTbl = 'SAPROD' and NumGrp = @NumGrp"
                Dim cmd As New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Sub dessrv()
        Try
            empresas = New SqlCommand("use " & My.Settings.basedatos & "; 
            select isnull((select max(NumGrp) maxi from SAAGRUPOS 
                    where CodTbl = 'SASERV' and NombreGrp = 'OMultimoneda'),0) as ActivoSrv", cn)
            descripcion = empresas.ExecuteReader
            While descripcion.Read()
                activosrv = descripcion.Item("Activosrv")
            End While
            descripcion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If activosrv = 0 Then
        Else

            Try
                Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            declare @NumGrp int = " & activosrv & "
            DROP VIEW SASERV_" & Format(activosrv, "00") & "
            IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='SPOServicios' AND XTYPE='P')
            BEGIN
			EXEC('DROP PROCEDURE [dbo].[SPOServicios]')
            END
            delete SAAGRUPOS  where CodTbl = 'SASERV' and NumGrp = @NumGrp
            delete SAAOPER	  where CodTbl = 'SASERV' and NumGrp = @NumGrp
            delete SAACAMPOS  where CodTbl = 'SASERV' and NumGrp = @NumGrp"
                Dim cmd As New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Sub actcom()


        Try
            empresas = New SqlCommand("use [" & My.Settings.basedatos & "]; 
            select isnull((select max(NumGrp) maxi from SAAGRUPOS 
                    where CodTbl = 'SACOMP' and NombreGrp = 'OMultimoneda'),0) as ActivoCom", cn)
            descripcion = empresas.ExecuteReader
            While descripcion.Read()
                activocom = descripcion.Item("ActivoCom")
            End While
            descripcion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If activocom = 0 Then
            Try
                empresas = New SqlCommand("use [" & My.Settings.basedatos & "]; 
                select isnull((select max(NumGrp) MaxNumGrp from SAAGRUPOS 
                        where CodTbl = 'SACOMP'),0)+1 as IndCom", cn)
                descripcion = empresas.ExecuteReader
                While descripcion.Read()
                    indcom = descripcion.Item("IndCom")
                End While
                descripcion.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If indcom = 0 Then

        Else
            Try
                Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            declare @gmax int = " & indcom & "
            INSERT SAAGRUPOS  
	        (CodTbl,NumGrp,NombreGrp,AliasGrp,EsTrans,NMeses,NMovim) 
	        values('SACOMP',@Gmax,'OMultimoneda','OMultimoneda',0,0,0)
            
            DELETE FROM SAACAMPOS WHERE CODTBL = 'SACOMP' AND NUMGRP = @GMAX
	        INSERT SAACAMPOS (CodTbl,NumGrp,NombCpo,AliasCpo,TipoCpo,Longitud,Requerido,CBusqueda) 
	        VALUES ('SACOMP',@Gmax,'Factor','Factor',106,35,1,0)
	        Insert into SAAOPER (CodTbl,NumGrp,NroOper,PDtaReq) 
	        Values('SACOMP',@Gmax,340,0)
            Insert into SAAOPER (CodTbl,NumGrp,NroOper,PDtaReq) 
	        Values('SACOMP',@Gmax,342,0)
            "
                Dim cmd As New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Try
                tablacom = "SACOMP_" & Format(indcom, "00")
                Dim sql As String = "use [" & My.Settings.basedatos & "]; 
                IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='" & tablacom & "' AND XTYPE='U')
                BEGIN
                EXEC('CREATE TABLE [dbo].[" & tablacom & "](
	                [CodSucu] [varchar](5),
	                [TipoCom] [varchar](1),
	                [NumeroD] [varchar](30),
	                [CodProv] [varchar](30),
	                [Factor] [decimal](28, 4))')		
                END
                "
                Dim cmd As New SqlCommand(sql, cn)
                cmd.CommandTimeout = 300
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        Try
            tablacom = "SACOMP_" & Format(indcom, "00")
            Dim sql As String = "use [" & My.Settings.basedatos & "];  
            IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='trOPreciosCompras' AND XTYPE='TR')
			BEGIN
			EXEC('CREATE TRIGGER [dbo].[trOPrecioscompras]
	                ON [dbo].[" & tablacom & "]
	                AFTER INSERT
                AS
                BEGIN
                DECLARE
	                @tipocom VARCHAR(1),
	                @numerod VARCHAR(20),
	                @coditem VARCHAR(15),
					@codprov VARCHAR(15),
                    @factor decimal(28,4)

	                SELECT @tipocom=tipocom, @numerod=numerod, @codprov=codprov, @factor = factor FROM inserted
                    
                    IF @TipoCom in (''H'',''J'')
                    BEGIN
                        EXEC SPOCompras @TIPOCOM, @NUMEROD, @CODPROV, @FACTOR
                    END
				END')		
		    END
            IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='trOPreciosItem' AND XTYPE='TR')
			BEGIN
			EXEC('CREATE TRIGGER [dbo].[trOPreciosItem]
	                ON [dbo].[SAITEMCOM]
	                AFTER INSERT
                AS
                BEGIN
                DECLARE
	                @tipocom VARCHAR(1),
	                @coditem VARCHAR(15),
                    @costo decimal(28,4),
                    @precio1 decimal(28,4),
                    @precio2 decimal(28,4),
                    @precio3 decimal(28,4),
                    @precioU decimal(28,4),
                    @precioU2 decimal(28,4),
                    @precioU3 decimal(28,4)

	                SELECT @coditem = coditem, @costo = costo, @precio1 = precio1, @precio2 = precio2, @precio3 = precio3, @precioU = precioU, @precioU2 = precioU2, @precioU3 = precioU3  FROM inserted
                    
                    IF @TipoCom in (''H'',''J'')
                    BEGIN
                        update saprod
                        set costact = @costo, costpro = @costo, precio1 = @precio1, precio2 = @precio2, precio3 = @precio3, preciou = @preciou, preciou2 = @preciou2, preciou3 = @preciou3
                        where codprod = @coditem
                    END
				END')		
		    END"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.CommandTimeout = 300

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            End Try


    End Sub



    Sub des_compras()
        Try
            empresas = New SqlCommand("use " & My.Settings.basedatos & "; 
            select isnull((select max(NumGrp) maxi from SAAGRUPOS 
                    where CodTbl = 'SACOMP' and NombreGrp = 'OMultimoneda'),0) as ActivoCom", cn)
            descripcion = empresas.ExecuteReader
            While descripcion.Read()
                activocom = descripcion.Item("ActivoCom")
            End While
            descripcion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If activocom = 0 Then
        Else

            Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            declare @NumGrp int = " & activocom & "
            delete SAAGRUPOS  where CodTbl = 'SACOMP' and NumGrp = @NumGrp
            delete SAAOPER	  where CodTbl = 'SACOMP' and NumGrp = @NumGrp
            delete SAACAMPOS  where CodTbl = 'SACOMP' and NumGrp = @NumGrp

            IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='trOPreciosCompras' AND XTYPE='TR')
            BEGIN
			EXEC('DROP TRIGGER [dbo].[trOprecioscompras]')
            END
            IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='trOPreciosItem' AND XTYPE='TR')
            BEGIN
			EXEC('DROP TRIGGER [dbo].[trOpreciosItem]')
            END
            IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='SPOCompras' AND XTYPE='P')
            BEGIN
			EXEC('DROP PROCEDURE [dbo].[SPOCompras]')
            END"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.CommandTimeout = 300
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If


    End Sub



End Module
