PRINT ('CREATE PROCEDURE [dbo].[PA_VehiculosDisponibles]')
IF OBJECT_ID(N'[dbo].[PA_VehiculosDisponibles]', 'P') IS NOT NULL
	DROP PROCEDURE [dbo].[PA_VehiculosDisponibles];
GO

create procedure [dbo].[PA_VehiculosDisponibles] 
@localidadRecogida varchar(50),
@LocalidadDevolucion varchar(10)
with encryption 
as
begin try 
	DECLARE @BO_VALIDO AS BIT = 1
	,@BO_MOSTRAR_MENSAJE AS BIT = 0
	,@DS_RESPUESTA AS VARCHAR(500) = 'PA_VehiculosDisponibles'
	,@DS_ESTADO AS VARCHAR(3) = 'OK'
	,@FE_PROCESO AS DATETIME = GETDATE()
	,@DS_ERROR_VALIDACION AS NVARCHAR(250) = ''
	IF @DS_ERROR_VALIDACION <> ''
		BEGIN
			SET @DS_ERROR_VALIDACION = 'Descripcion de la validacion realizada'
			GOTO ERROR_VALIDACION	
		END 
	
	        select b.Tipo as TipoVehiculo, a.Marca, a .Modelo, a.Color ,d.Recogida as LocalidadRecogida ,c.Devolucion as LocalidadDevolucion from Vehiculo(nolock) as a
			join TipoVehiculo(nolock) as b on a.Id_TipoVehiculo = b.id
			join LocalidadDevolucion(nolock) as c on c.Id = a.Id_LocalidadDevolucion
			join LocalidadRecogida(nolock) as d on d.Id = a.Id_LocalidadRecogida
			where c.Devolucion=@LocalidadDevolucion and d.Recogida = @localidadRecogida
			
	RETURN
	ERROR_VALIDACION:
		RAISERROR (@DS_ERROR_VALIDACION,16,1) 
		
END TRY
BEGIN CATCH
	SET @BO_VALIDO = 0
	SET @BO_MOSTRAR_MENSAJE = 1
	SET @DS_RESPUESTA = ERROR_MESSAGE() + ' Procedimiento: ' + ERROR_PROCEDURE() + ' LÃnea: ' + CAST(ERROR_LINE() AS VARCHAR)
	SET @DS_ESTADO = 'NOK'
	SELECT @DS_RESPUESTA AS ERROR
END CATCH
GO
IF OBJECT_ID(N'[dbo].[PA_VehiculosDisponibles]', 'P') IS NOT NULL
BEGIN
	PRINT '   OK'
END
ELSE
BEGIN
	PRINT '   UPS! NOK!'
END
GO

--exec PA_VehiculosDisponibles 'Medellin', 'Medellin'


