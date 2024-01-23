
--CREARTE SP
CREATE OR ALTER PROCEDURE [dbo].[SP_Reporte_Aspirantes_Get]

	AS

	BEGIN
		SET NOCOUNT ON;
			SELECT a.IdTipoDocumento,
				   td.Descripcion TipoDocumento,
				   a.NumeroDocumento,
				   a.Id IdAspirante,
				   RTRIM(a.Nombre +' '+a.Apellido) Aspirante,
				   aps.IdPruebaSeleccion,
				   ps.NombreDescripcion PruebaSeleccion,
				   aps.Calificacion,
				   aps.IdEstadoPrueba,
				   ep.Descripcion EstadoPrueba,
				   a.Direccion,
				   a.Telefono,
				   a.Estado,
				   a.IdUsuarioActualizacion,
				   u.NombreUsuario UsuarioActualizacion,
				   a.FechaActualizacion
			FROM dbo.Aspirantes AS a
			INNER JOIN dbo.TipoDocumentos AS td WITH(NOLOCK) ON a.IdTipoDocumento = td.Id
			LEFT JOIN dbo.AspirantePruebaSeleccion AS aps WITH(NOLOCK) ON aps.IdAspirante = a.Id 
			LEFT JOIN dbo.PruebaSeleccion AS ps WITH(NOLOCK) ON aps.IdPruebaSeleccion = ps.Id
			LEFT JOIN dbo.EstadoPruebas AS ep WITH(NOLOCK) ON aps.IdEstadoPrueba = ep.Id
			LEFT JOIN dbo.Usuarios AS u WITH(NOLOCK) ON td.IdUsuarioActualizacion = u.Id
			WHERE a.Estado = 1 	
		
	END;