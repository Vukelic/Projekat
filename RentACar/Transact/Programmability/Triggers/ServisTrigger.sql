CREATE TRIGGER [ServisTrigger]
ON [dbo].servis

AFTER INSERT
AS

BEGIN
	
	DECLARE @serviserJmbg VARCHAR;
	DECLARE @servisId INT;
	DECLARE @cenaServisa BIGINT;

	SELECT @serviserJmbg = i.serviser_jmbg from inserted i;
	SELECT @servisId = i.servis_servisId from inserted i;
	SELECT @cenaServisa = i.servis_cena FROM inserted i;

		if (@serviserJmbg = '02118984512' )
			BEGIN
				SELECT @cenaServisa = @cenaServisa * 3;
				UPDATE servis SET cenaServisa = @cenaServisa WHERE id = @servisId
			END
END