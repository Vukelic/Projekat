CREATE TRIGGER [ServisTrigger6]
ON [dbo].[Servisi]

INSTEAD OF INSERT
AS

BEGIN
	
	DECLARE @Id1 INT, @Cena1 BIGINT, @Komentar1 nvarchar(MAX), @Datum1 dateTime, @VoziloId1 INT, @ServiserJmbg1 nvarchar(MAX);

	SELECT @Id1=Id, @Cena1=Cena, @Komentar1=Komentar, @Datum1=Datum, @VoziloId1=VoziloId, @ServiserJmbg1=ServiserJmbg from inserted;

		if (@Cena1 < 2 )
			BEGIN
				INSERT INTO Servisi(Id, Cena, Komentar, Datum, VoziloId, ServiserJmbg) values (@Id1, 5, @Komentar1, @Datum1, @VoziloId1, @ServiserJmbg1)
			END
	    else
		BEGIN
				INSERT INTO Servisi(Id, Cena, Komentar, Datum, VoziloId, ServiserJmbg) values (@Id1, @Cena1, @Komentar1, @Datum1, @VoziloId1, @ServiserJmbg1)
			END
END