Imports System.Data.SqlClient
Imports System.Data.Sql
Module procedimientos
    Public codigos As SqlCommand
    Public codprod As SqlDataReader

	Sub productos_precios()
		Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            EXEC SPOProductos " & factor & "," & factor2 & "," & factor3 & "," & cprdiva & "," & cprdcos & ""
		Dim cmd As New SqlCommand(sql, cn)
		cmd.CommandTimeout = 300
		Try
			cmd.ExecuteNonQuery()
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
		MsgBox("Productos actualizados con exito", MsgBoxStyle.Information)
	End Sub

	Sub servicios_precios()
		Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            EXEC SPOServicios " & factor & "," & factor2 & "," & factor3 & "," & csrviva & "," & csrvcos & ""
		Dim cmd As New SqlCommand(sql, cn)
		cmd.CommandTimeout = 300
		Try
			cmd.ExecuteNonQuery()
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
		MsgBox("Servicios actualizados con exito", MsgBoxStyle.Information)
	End Sub


	Sub crear_spproductos()

		Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='SPOProductos' AND XTYPE='P')
			BEGIN
			EXEC('create PROCEDURE SPOProductos (@factor decimal(28,4),@factor2 decimal(28,4),@factor3 decimal(28,4),@iva int, @costo int)
                        AS
                        BEGIN
	                        declare @montoiva as decimal(28,3)
	                        declare @codprod as varchar(15)
							declare @redondeo as int = dbo.fnOMRedondeo()
	                        if @costo = 1
	                        begin
			
				                        update saprod
				                        set costact = iif(b.costoact>0,b.costoact * @factor,a.costact) ,
					                        costpro = iif(b.costopro>0,b.costopro * @factor2 ,a.costpro),
					                        costant = iif(b.costoant>0,b.costoant * @factor3 ,a.costant)
				                        from saprod a
				                        inner join opreciosmex b
				                        on a.codprod = b.codprod 
							
	                        end

	                        if @iva = 1
	                        begin
			                        DECLARE dbcursor CURSOR FOR SELECT codprod FROM saprod
			                        OPEN dbcursor;
			                        FETCH NEXT FROM dbcursor INTO @codprod;
			                        WHILE @@FETCH_STATUS = 0 BEGIN

				                        if exists (select codprod from sataxprd where codprod= @codprod)
										begin
											select @montoiva = 1+monto/100 from sataxprd where codprod= @codprod
										end else
											set @montoiva  = 1

				                        update saprod
				                        set precio1 = iif(b.precio1>0,round(b.precio1 * @factor / @montoiva,@redondeo),a.precio1),
											precio2 = iif(b.precio2>0,round(b.precio2 * @factor2 / @montoiva,@redondeo),a.precio2),
											precio3 = iif(b.precio3>0,round(b.precio3 * @factor3 / @montoiva,@redondeo),a.precio3),
											preciou = iif(b.preciou1>0,round(b.preciou1 * @factor / @montoiva,@redondeo),a.preciou),
											preciou2 = iif(b.preciou2>0,round(b.preciou2 * @factor2 / @montoiva,@redondeo),a.preciou2),
											preciou3 = iif(b.preciou3>0,round(b.preciou3 * @factor3 / @montoiva,@redondeo),a.preciou3)
				                        from saprod a
				                        inner join opreciosmex b
				                        on a.codprod = b.codprod 
				                        where a.codprod = @codprod and b.codprod = @codprod
				                        FETCH NEXT FROM dbcursor INTO @codprod;
				                        END;
				                        CLOSE dbcursor;
				                        DEALLOCATE dbcursor;

	                        end

	                        if @iva = 0
	                        begin
			
				                        update saprod
				                        set precio1 = iif(b.precio1>0,round(b.precio1 * @factor,@redondeo),a.precio1),
											precio2 = iif(b.precio2>0,round(b.precio2 * @factor2 ,@redondeo),a.precio2),
											precio3 = iif(b.precio3>0,round(b.precio3 * @factor3 ,@redondeo),a.precio3),
											preciou = iif(b.preciou1>0,round(b.preciou1 * @factor ,@redondeo),a.preciou),
											preciou2 = iif(b.preciou2>0,round(b.preciou2 * @factor2,@redondeo),a.preciou2),
											preciou3 = iif(b.preciou3>0,round(b.preciou3 * @factor3 ,@redondeo),a.preciou3)
				                        from saprod a
				                        inner join opreciosmex b
				                        on a.codprod = b.codprod 
				                       
				
	                        end
                        END')		
		    END"
		Dim cmd As New SqlCommand(sql, cn)
		cmd.CommandTimeout = 300
		Try
			cmd.ExecuteNonQuery()
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub


	Sub crear_spservicios()

		Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='SPOServicios' AND XTYPE='P')
			BEGIN
			EXEC('create PROCEDURE SPOServicios (@factor decimal(28,4),@factor2 decimal(28,4),@factor3 decimal(28,4),@iva int, @costo int)
                        AS
                        BEGIN
	                        declare @montoiva as decimal(28,3)
	                        declare @codprod as varchar(15)
							declare @redondeo as int = dbo.fnOMRedondeo()
	                        if @costo = 1
	                        begin
			
				                        update saserv
				                        set costo = iif(b.costoact>0,round(b.costoact * @factor,@redondeo),a.costo)
				                        from saserv a
				                        inner join opreciosmex b
				                        on a.codserv = b.codprod 
							
	                        end

	                        if @iva = 1
	                        begin
			                        DECLARE dbcursor CURSOR FOR SELECT codserv FROM saserv
			                        OPEN dbcursor;
			                        FETCH NEXT FROM dbcursor INTO @codprod;
			                        WHILE @@FETCH_STATUS = 0 BEGIN
				                         if exists (select codserv from sataxsrv where codserv= @codprod)
										begin
											select @montoiva = 1+monto/100 from sataxsrv where codserv= @codprod
										end else
											set @montoiva  = 1

				                        update saserv
				                        set precio1 = iif(b.precio1>0,round(b.precio1 * @factor / @montoiva,@redondeo),a.precio1),
					                        precio2 = iif(b.precio2>0,round(b.precio2 * @factor2 / @montoiva,@redondeo),a.precio2),
					                        precio3 = iif(b.precio3>0,round(b.precio3 * @factor3 / @montoiva,@redondeo),a.precio3)
					                        
				                        from saserv a
				                        inner join opreciosmex b
				                        on a.codserv = b.codprod 
				                        where a.codserv = @codprod and b.codprod = @codprod
				                        FETCH NEXT FROM dbcursor INTO @codprod;
				                        END;
				                        CLOSE dbcursor;
				                        DEALLOCATE dbcursor;
										
										
	                        end

	                        if @iva = 0
	                        begin
			
				                        update saserv
				                        set precio1 = iif(b.precio1>0,round(b.precio1 * @factor,@redondeo),a.precio1),
					                        precio2 = iif(b.precio2>0,round(b.precio2 * @factor2,@redondeo),a.precio2),
					                        precio3 = iif(b.precio3>0,round(b.precio3 * @factor3,@redondeo),a.precio3)
					                        
				                        from saserv a
				                        inner join opreciosmex b
				                        on a.codserv = b.codprod 
				                       
				
	                        end
                        END')		
		    END"
		Dim cmd As New SqlCommand(sql, cn)
		cmd.CommandTimeout = 300
		Try
			cmd.ExecuteNonQuery()
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try




	End Sub

	Sub crear_spcompras()

        If ccomcos = 1 And ccompre = 1 And cprdiva = 0 Then
			Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='SPOCompras' AND XTYPE='P')
			BEGIN
			EXEC('create PROCedure [dbo].[SPOCompras] 
                        (
                                @Tipocom as varchar(1),
                                @Numerod as varchar(20),
                                @Codprov as varchar(15),
	                            @Factor as decimal(28,4)
                        )
                        as
                        Begin
							declare @redondeo as int = dbo.fnOMRedondeo()
							declare @codprod as varchar(20)	

							if @Factor > 0
							begin
								DECLARE dbcursor CURSOR FOR SELECT coditem FROM saitemcom where tipocom = @tipocom and numerod = @numerod and codprov = @codprov
			                    OPEN dbcursor;
			                    FETCH NEXT FROM dbcursor INTO @codprod;
			                    WHILE @@FETCH_STATUS = 0 BEGIN
									if not exists (select codprod from opreciosmex where codprod = @codprod)
									begin 
										insert into opreciosmex (codprod,costoact,costoant,costopro,precio1,precio2,precio3,preciou1,preciou2,preciou3) 
										values (@codprod,0,0,0,0,0,0,0,0,0)
									end
				                    
				                    update opreciosmex
				                    set costoact = round(b.costo / @factor,@redondeo),
										costopro = round(b.costo / @factor,@redondeo),
										costoant = round(b.costo / @factor,@redondeo),
										precio1 = round(b.precio1 / @factor,@redondeo),
					                    precio2 = round(b.precio2 / @factor,@redondeo),
					                    precio3 = round(b.precio3 / @factor,@redondeo),
										precioU1 = round(b.precioU / @factor,@redondeo),
					                    precioU2 = round(b.precioU2 / @factor,@redondeo),
					                    precioU3 = round(b.precioU3 / @factor,@redondeo)
					                from opreciosmex a
									inner join saitemcom b
									on a.codprod = b.coditem
									where b.coditem = @codprod and b.tipocom = @tipocom and b.numerod = @numerod and b.codprov = @codprov
				                    
				                FETCH NEXT FROM dbcursor INTO @codprod;
				                END;
				                CLOSE dbcursor;
				                DEALLOCATE dbcursor

								
							END	    
                        end')		
			END"
			Dim cmd As New SqlCommand(sql, cn)
            cmd.CommandTimeout = 300
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

        If ccomcos = 1 And ccompre = 1 And cprdiva = 1 Then
			Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='SPOCompras' AND XTYPE='P')
			BEGIN
			EXEC('create PROCedure [dbo].[SPOCompras] 
                        (
                                @Tipocom as varchar(1),
                                @Numerod as varchar(20),
                                @Codprov as varchar(15),
	                            @Factor as  decimal(28,4)
                        )
                        as
                        Begin
							declare @redondeo as int = dbo.fnOMRedondeo()
							declare @codprod as varchar(20)
							declare @montoiva as decimal(28,3)
							if @Factor > 0
							begin
								
								
								DECLARE dbcursor CURSOR FOR SELECT coditem FROM saitemcom where tipocom = @tipocom and numerod = @numerod and codprov = @codprov
			                    OPEN dbcursor;
			                    FETCH NEXT FROM dbcursor INTO @codprod;
			                    WHILE @@FETCH_STATUS = 0 BEGIN
								if not exists (select codprod from opreciosmex where codprod = @codprod)
								begin 
									insert into opreciosmex (codprod,costoact,costoant,costopro,precio1,precio2,precio3,preciou1,preciou2,preciou3) 
									values (@codprod,0,0,0,0,0,0,0,0,0)
								end

								if exists (select codprod from sataxprd where codprod= @codprod)
								begin
									select @montoiva = 1+monto/100 from sataxprd where codprod= @codprod
								end else
									set @montoiva  = 1
				                    
				                    update opreciosmex
				                    set costoact = round(b.costo / @factor,@redondeo),
										costopro = round(b.costo / @factor,@redondeo),
										costoant = round(b.costo / @factor,@redondeo),
										precio1 = round(b.precio1*@montoiva / @factor,@redondeo),
					                    precio2 = round(b.precio2*@montoiva / @factor,@redondeo),
					                    precio3 = round(b.precio3*@montoiva / @factor,@redondeo),
										precioU1 = round(b.precioU*@montoiva / @factor,@redondeo),
					                    precioU2 = round(b.precioU2*@montoiva / @factor,@redondeo),
					                    precioU3 = round(b.precioU3*@montoiva / @factor,@redondeo)
					                from opreciosmex a
									inner join saitemcom b
									on a.codprod = b.coditem
									where b.coditem = @codprod and b.tipocom = @tipocom and b.numerod = @numerod and b.codprov = @codprov
				                    
				                FETCH NEXT FROM dbcursor INTO @codprod;
				                END;
				                CLOSE dbcursor;
				                DEALLOCATE dbcursor

								
							END	    
                        end')		
		    END"
			Dim cmd As New SqlCommand(sql, cn)
            cmd.CommandTimeout = 300
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

        If ccomcos = 1 And ccompre = 0 Then
			Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='SPOCompras' AND XTYPE='P')
			BEGIN
			EXEC('create PROCedure [dbo].[SPOCompras] 
                        (
                                @Tipocom as varchar(1),
                                @Numerod as varchar(20),
                                @Codprov as varchar(15),
	                            @Factor as decimal(28,4)
                        )
                        as
                        Begin
							declare @redondeo as int = dbo.fnOMRedondeo()
							declare @codprod as varchar(20)	

							if @Factor > 0
							begin
								DECLARE dbcursor CURSOR FOR SELECT coditem FROM saitemcom where tipocom = @tipocom and numerod = @numerod and codprov = @codprov
			                    OPEN dbcursor;
			                    FETCH NEXT FROM dbcursor INTO @codprod;
			                    WHILE @@FETCH_STATUS = 0 BEGIN
									if not exists (select codprod from opreciosmex where codprod = @codprod)
									begin 
										insert into opreciosmex (codprod,costoact,costoant,costopro,precio1,precio2,precio3,preciou1,preciou2,preciou3) 
										values (@codprod,0,0,0,0,0,0,0,0,0)
									end
				                    
				                    update opreciosmex
				                    set costoact = round(b.costo / @factor,@redondeo),
										costopro = round(b.costo / @factor,@redondeo),
										costoant = round(b.costo / @factor,@redondeo)
					                from opreciosmex a
									inner join saitemcom b
									on a.codprod = b.coditem
									where b.coditem = @codprod and b.tipocom = @tipocom and b.numerod = @numerod and b.codprov = @codprov
				                    
				                FETCH NEXT FROM dbcursor INTO @codprod;
				                END;
				                CLOSE dbcursor;
				                DEALLOCATE dbcursor

								
							END	    
                        end')			
		    END"
			Dim cmd As New SqlCommand(sql, cn)
            cmd.CommandTimeout = 300
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If ccompre = 1 And ccomcos = 0 And cprdiva = 0 Then
			Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='SPOCompras' AND XTYPE='P')
			BEGIN
			EXEC('create PROCedure [dbo].[SPOCompras] 
                        (
                                @Tipocom as varchar(1),
                                @Numerod as varchar(20),
                                @Codprov as varchar(15),
	                            @Factor as decimal(28,4)
                        )
                        as
                        Begin
							declare @redondeo as int = dbo.fnOMRedondeo()
							declare @codprod as varchar(20)	

							if @Factor > 0
							begin
								DECLARE dbcursor CURSOR FOR SELECT coditem FROM saitemcom where tipocom = @tipocom and numerod = @numerod and codprov = @codprov
			                    OPEN dbcursor;
			                    FETCH NEXT FROM dbcursor INTO @codprod;
			                    WHILE @@FETCH_STATUS = 0 BEGIN
									if not exists (select codprod from opreciosmex where codprod = @codprod)
									begin 
										insert into opreciosmex (codprod,costoact,costoant,costopro,precio1,precio2,precio3,preciou1,preciou2,preciou3) 
										values (@codprod,0,0,0,0,0,0,0,0,0)
									end
				                    
				                    update opreciosmex
				                    set 
										precio1 = round(b.precio1 / @factor,@redondeo),
					                    precio2 = round(b.precio2 / @factor,@redondeo),
					                    precio3 = round(b.precio3 / @factor,@redondeo),
										precioU1 = round(b.precioU / @factor,@redondeo),
					                    precioU2 = round(b.precioU2 / @factor,@redondeo),
					                    precioU3 = round(b.precioU3 / @factor,@redondeo)
					                from opreciosmex a
									inner join saitemcom b
									on a.codprod = b.coditem
									where b.coditem = @codprod and b.tipocom = @tipocom and b.numerod = @numerod and b.codprov = @codprov
				                    
				                FETCH NEXT FROM dbcursor INTO @codprod;
				                END;
				                CLOSE dbcursor;
				                DEALLOCATE dbcursor

								
							END	    
                        end')			
		    END"
			Dim cmd As New SqlCommand(sql, cn)
            cmd.CommandTimeout = 300
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If ccompre = 1 And ccomcos = 0 And cprdiva = 1 Then
			Dim sql As String = "use [" & My.Settings.basedatos & "]; 
            IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='SPOCompras' AND XTYPE='P')
			BEGIN
			EXEC('create PROCedure [dbo].[SPOCompras] 
                        (
                                @Tipocom as varchar(1),
                                @Numerod as varchar(20),
                                @Codprov as varchar(15),
	                            @Factor as  decimal(28,4)
                        )
                        as
                        Begin
							declare @redondeo as int = dbo.fnOMRedondeo()
							declare @codprod as varchar(20)
							declare @montoiva as decimal(28,3)
							if @Factor > 0
							begin
								
								
								DECLARE dbcursor CURSOR FOR SELECT coditem FROM saitemcom where tipocom = @tipocom and numerod = @numerod and codprov = @codprov
			                    OPEN dbcursor;
			                    FETCH NEXT FROM dbcursor INTO @codprod;
			                    WHILE @@FETCH_STATUS = 0 BEGIN
								if not exists (select codprod from opreciosmex where codprod = @codprod)
								begin 
									insert into opreciosmex (codprod,costoact,costoant,costopro,precio1,precio2,precio3,preciou1,preciou2,preciou3) 
									values (@codprod,0,0,0,0,0,0,0,0,0)
								end

								if exists (select codprod from sataxprd where codprod= @codprod)
								begin
									select @montoiva = 1+monto/100 from sataxprd where codprod= @codprod
								end else
									set @montoiva  = 1
				                    
				                    update opreciosmex
				                    set 
										precio1 = round(b.precio1*@montoiva / @factor,@redondeo),
					                    precio2 = round(b.precio2*@montoiva / @factor,@redondeo),
					                    precio3 = round(b.precio3*@montoiva / @factor,@redondeo),
										precioU1 = round(b.precioU*@montoiva / @factor,@redondeo),
					                    precioU2 = round(b.precioU2*@montoiva / @factor,@redondeo),
					                    precioU3 = round(b.precioU3*@montoiva / @factor,@redondeo)
					                from opreciosmex a
									inner join saitemcom b
									on a.codprod = b.coditem
									where b.coditem = @codprod and b.tipocom = @tipocom and b.numerod = @numerod and b.codprov = @codprov
				                    
				                FETCH NEXT FROM dbcursor INTO @codprod;
				                END;
				                CLOSE dbcursor;
				                DEALLOCATE dbcursor

								
							END	    
                        end')		
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
