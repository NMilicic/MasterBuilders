BEGIN
  CREATE TABLE MasterBuilders.dbo.wishlist
  (
	id INT IDENTITY(1,1) NOT NULL,
    Korisnik_id INT NOT NULL,
    LSet_id INT NOT NULL,
    Komada INT,
    PRIMARY KEY(id),
	FOREIGN KEY (Korisnik_Id) REFERENCES Korisnik(id),
	FOREIGN KEY (LSet_id) REFERENCES Lset(id),
  )
END;

  ALTER TABLE MasterBuilders.dbo.user_set
	ADD Komada INT
  