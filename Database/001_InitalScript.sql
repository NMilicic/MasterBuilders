BEGIN
CREATE DATABASE MasterBuilders;
END

GO

BEGIN
  CREATE TABLE MasterBuilders.dbo.Lset
  (
    id INT IDENTITY(1,1) NOT NULL,
    ime VARCHAR(100) NOT NULL,
    god_pro INT,
    dijelovi_broj INT,
    opis VARCHAR(200),
    id_tema INT,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.kockica
  (
    id INT IDENTITY(1,1) NOT NULL,
    ime VARCHAR(100),
    kategorija VARCHAR(150),
    PRIMARY KEY(id)
  )
END;


BEGIN
  CREATE TABLE MasterBuilders.dbo.boja
  (
    id INT IDENTITY(1,1) NOT NULL,
    ime VARCHAR(100) NOT NULL UNIQUE,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.setovi_dijelovi
  (
	id INT IDENTITY(1,1) NOT NULL,
    id_boja INT NOT NULL,
    id_koc INT NOT NULL,
    id_set INT NOT NULL,
    broj INT NOT NULL,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.user_set
  (
  id INT IDENTITY(1,1) NOT NULL,
    Korisnik_id INT NOT NULL,
    LSet_id INT NOT NULL,
    slozeno INT,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.user_kockica
  (
    Korisnik_id INT NOT NULL,
    Kockica_id INT NOT NULL,
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.MOC
  (
    id INT IDENTITY(1,1) NOT NULL,
    ime VARCHAR(100) NOT NULL,
    god_pro INT,
    dijelovi_broj INT,
    tema1 VARCHAR(100),
    tema2 VARCHAR(100),
    tema3 VARCHAR(100),
    opis VARCHAR(200),
    id_autor INT,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.MOC_dijelovi
  (
  id INT IDENTITY(1,1) NOT NULL,
    id_boja INT NOT NULL,
    id_koc INT NOT NULL,
    id_set INT NOT NULL,
    broj INT NOT NULL,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.tema
  (
    id_tema INT IDENTITY(1,1) NOT NULL,
    id_nadtema INT,
    ime_tema VARCHAR(100),
    PRIMARY KEY(id_tema)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.user_MOC
  (
  id INT IDENTITY(1,1) NOT NULL,
    Korisnik_id INT NOT NULL,
    id_moc INT NOT NULL,
    slozeno INT,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.Korisnik
  (
    id INT IDENTITY(1,1) NOT NULL,
    email NVARCHAR(50) NOT NULL,
	zaporka NVARCHAR(50) NOT NULL,
    ime NVARCHAR(MAX) NOT NULL,
	prezime NVARCHAR(MAX) NOT NULL,
    PRIMARY KEY(id)
  )
END;


-- Create FKs
ALTER TABLE MasterBuilders.dbo.setovi_dijelovi
    ADD    FOREIGN KEY (id_koc)
    REFERENCES kockica(id)
;
    
ALTER TABLE MasterBuilders.dbo.setovi_dijelovi
    ADD    FOREIGN KEY (id_boja)
    REFERENCES boja(id)
;
    
ALTER TABLE MasterBuilders.dbo.setovi_dijelovi
    ADD    FOREIGN KEY (id_set)
    REFERENCES Lset(id)
;
    
ALTER TABLE MasterBuilders.dbo.MOC_dijelovi
    ADD    FOREIGN KEY (id_koc)
    REFERENCES kockica(id)
;
    
ALTER TABLE MasterBuilders.dbo.MOC_dijelovi
    ADD    FOREIGN KEY (id_boja)
    REFERENCES boja(id)
;
    
ALTER TABLE MasterBuilders.dbo.MOC_dijelovi
    ADD    FOREIGN KEY (id_set)
    REFERENCES MOC(id)
;
    
ALTER TABLE MasterBuilders.dbo.Lset
    ADD    FOREIGN KEY (id_tema)
    REFERENCES tema(id_tema)
;
    
ALTER TABLE MasterBuilders.dbo.tema
    ADD    FOREIGN KEY (id_nadtema)
    REFERENCES tema(id_tema)
;
    

    
ALTER TABLE MasterBuilders.dbo.user_MOC
    ADD    FOREIGN KEY (id_moc)
    REFERENCES MOC(id)
;

ALTER TABLE MasterBuilders.dbo.user_MOC
    ADD    FOREIGN KEY (Korisnik_id)
    REFERENCES Korisnik(id)
;

ALTER TABLE MasterBuilders.dbo.user_set
    ADD    FOREIGN KEY (Korisnik_id)
    REFERENCES Korisnik(id)
;

ALTER TABLE MasterBuilders.dbo.user_set
    ADD    FOREIGN KEY (LSet_id)
    REFERENCES Lset(id)
;

ALTER TABLE MasterBuilders.dbo.user_kockica
    ADD    FOREIGN KEY (Korisnik_id)
    REFERENCES Korisnik(id)
;

ALTER TABLE MasterBuilders.dbo.user_kockica
    ADD    FOREIGN KEY (Kockica_id)
    REFERENCES kockica(id)
;
