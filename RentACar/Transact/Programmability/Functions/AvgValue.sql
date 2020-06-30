CREATE FUNCTION [dbo].[AvgValue]
(
	@param1 BIGINT
)
RETURNS DECIMAL
AS
BEGIN
	
	DECLARE @prosek AS DECIMAL
	SELECT @prosek = AVG(vrednost) FROM ocena INNER JOIN "Vozilo" ON ocena.vozilo_voziloid = "Vozilo".voziloid
	WHERE "Vozilo".vozilo = @param1

	RETURN @prosek 

END
