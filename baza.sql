-- Create schemas

-- Create tables
IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'set'))
BEGIN
  CREATE TABLE set
  (
    id INT NOT NULL,
    ime VARCHAR(100) NOT NULL,
    god_pro INT,
    dijelovi_broj INT,
    opis VARCHAR(200),
    id_tema INT,
    PRIMARY KEY(id)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'kockica'))
BEGIN
  CREATE TABLE kockica
  (
    id INT NOT NULL,
    ime VARCHAR(100),
    kategorija VARCHAR(150),
    PRIMARY KEY(id)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'boja'))
BEGIN
  CREATE TABLE boja
  (
    id INT NOT NULL,
    ime VARCHAR(100) NOT NULL UNIQUE,
    PRIMARY KEY(id)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'setovi_dijelovi'))
BEGIN
  CREATE TABLE setovi_dijelovi
  (
    id_boja INT NOT NULL,
    id_koc INT NOT NULL,
    id_set INT NOT NULL,
    broj INT NOT NULL,
    PRIMARY KEY(id_boja, id_koc, id_set)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'user_set'))
BEGIN
  CREATE TABLE user_set
  (
    id_usr INT NOT NULL,
    id_set INT NOT NULL,
    slozeno INT,
    PRIMARY KEY(id_usr, id_set)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'user_kockica'))
BEGIN
  CREATE TABLE user_kockica
  (
    id_usr INT NOT NULL,
    id_koc INT NOT NULL,
    PRIMARY KEY(id_usr, id_koc)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MOC'))
BEGIN
  CREATE TABLE MOC
  (
    id INT NOT NULL,
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

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MOC_dijelovi'))
BEGIN
  CREATE TABLE MOC_dijelovi
  (
    id_boja INT NOT NULL,
    id_koc INT NOT NULL,
    id_set INT NOT NULL,
    broj INT NOT NULL,
    PRIMARY KEY(id_boja, id_koc, id_set)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tema'))
BEGIN
  CREATE TABLE tema
  (
    id_tema INT NOT NULL,
    id_nadtema INT,
    ime_tema VARCHAR(100),
    PRIMARY KEY(id_tema)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'user_MOC'))
BEGIN
  CREATE TABLE user_MOC
  (
    id_usr INT NOT NULL,
    id_moc INT NOT NULL,
    slozeno INT,
    PRIMARY KEY(id_usr, id_moc)
  )
END;


-- Create FKs
ALTER TABLE setovi_dijelovi
    ADD    FOREIGN KEY (id_koc)
    REFERENCES kockica(id)
;
    
ALTER TABLE setovi_dijelovi
    ADD    FOREIGN KEY (id_boja)
    REFERENCES boja(id)
;
    
ALTER TABLE setovi_dijelovi
    ADD    FOREIGN KEY (id_set)
    REFERENCES set(id)
;
    
ALTER TABLE MOC_dijelovi
    ADD    FOREIGN KEY (id_koc)
    REFERENCES kockica(id)
;
    
ALTER TABLE MOC_dijelovi
    ADD    FOREIGN KEY (id_boja)
    REFERENCES boja(id)
;
    
ALTER TABLE MOC_dijelovi
    ADD    FOREIGN KEY (id_set)
    REFERENCES MOC(id)
;
    
ALTER TABLE set
    ADD    FOREIGN KEY (id_tema)
    REFERENCES tema(id_tema)
;
    
ALTER TABLE tema
    ADD    FOREIGN KEY (id_nadtema)
    REFERENCES tema(id_tema)
;
    
ALTER TABLE user_set
    ADD    FOREIGN KEY (id_set)
    REFERENCES set(id)
;
    
ALTER TABLE user_MOC
    ADD    FOREIGN KEY (id_moc)
    REFERENCES MOC(id)
;
    

-- Create Indexes

