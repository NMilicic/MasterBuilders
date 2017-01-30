BEGIN
CREATE DATABASE MasterBuilders;
END

GO

BEGIN
  CREATE TABLE MasterBuilders.dbo.Lset
  (
    id INT IDENTITY(1,1) NOT NULL,
    name VARCHAR(100) NOT NULL,
    production_year INT,
    num_parts INT,
    description VARCHAR(200),
    id_theme INT,
    set_code VARCHAR(50),
    picture_url VARCHAR(500),
    instructions_url VARCHAR(400),
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.part
  (
    id INT IDENTITY(1,1) NOT NULL,
    name VARCHAR(100),
    category INT,
    part_code VARCHAR(150),
    picture_url VARCHAR(400),
    PRIMARY KEY(id)
  )
END;

BEGIN
CREATE TABLE MasterBuilders.dbo.category
  (
    id INT IDENTITY(1,1) NOT NULL,
    name VARCHAR(100) NOT NULL,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.color
  (
    id INT IDENTITY(1,1) NOT NULL,
    name VARCHAR(100) NOT NULL UNIQUE,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.Lsets_parts
  (
	id INT IDENTITY(1,1) NOT NULL,
    id_color INT NOT NULL,
    id_part INT NOT NULL,
    id_Lset INT NOT NULL,
    num INT NOT NULL,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.user_Lset
  (
  id INT IDENTITY(1,1) NOT NULL,
    id_user INT NOT NULL,
    id_Lset INT NOT NULL,
    built INT,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.user_part
  (
    id_user INT NOT NULL,
    id_part INT NOT NULL,
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.MOC
  (
    id INT IDENTITY(1,1) NOT NULL,
    name VARCHAR(100) NOT NULL,
    production_year INT,
    num_parts INT,
    theme1 VARCHAR(100),
    theme2 VARCHAR(100),
    theme3 VARCHAR(100),
    description VARCHAR(200),
    id_author INT,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.MOC_parts
  (
  id INT IDENTITY(1,1) NOT NULL,
    id_color INT NOT NULL,
    id_part INT NOT NULL,
    id_set INT NOT NULL,
    num INT NOT NULL,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.theme
  (
    id_theme INT IDENTITY(1,1) NOT NULL,
    id_basetheme INT,
    name_theme VARCHAR(100),
    PRIMARY KEY(id_theme)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.user_MOC
  (
  id INT IDENTITY(1,1) NOT NULL,
    id_user INT NOT NULL,
    id_moc INT NOT NULL,
    built INT,
    PRIMARY KEY(id)
  )
END;

BEGIN
  CREATE TABLE MasterBuilders.dbo.users
  (
    id INT IDENTITY(1,1) NOT NULL,
    email NVARCHAR(50) NOT NULL,
	password NVARCHAR(50) NOT NULL,
    first_name NVARCHAR(MAX) NOT NULL,
	last_name NVARCHAR(MAX) NOT NULL,
    PRIMARY KEY(id)
  )
END;


-- Create FKs
ALTER TABLE MasterBuilders.dbo.Lsets_parts
    ADD    FOREIGN KEY (id_part)
    REFERENCES part(id)
;
    
ALTER TABLE MasterBuilders.dbo.Lsets_parts
    ADD    FOREIGN KEY (id_color)
    REFERENCES color(id)
;
    
ALTER TABLE MasterBuilders.dbo.Lsets_parts
    ADD    FOREIGN KEY (id_Lset)
    REFERENCES Lset(id)
;
    
ALTER TABLE MasterBuilders.dbo.MOC_parts
    ADD    FOREIGN KEY (id_part)
    REFERENCES part(id)
;
    
ALTER TABLE MasterBuilders.dbo.MOC_parts
    ADD    FOREIGN KEY (id_color)
    REFERENCES color(id)
;
    
ALTER TABLE MasterBuilders.dbo.MOC_parts
    ADD    FOREIGN KEY (id_set)
    REFERENCES MOC(id)
;
    
ALTER TABLE MasterBuilders.dbo.Lset
    ADD    FOREIGN KEY (id_theme)
    REFERENCES theme(id_theme)
;
    
ALTER TABLE MasterBuilders.dbo.theme
    ADD    FOREIGN KEY (id_basetheme)
    REFERENCES theme(id_theme)
;
    

    
ALTER TABLE MasterBuilders.dbo.user_MOC
    ADD    FOREIGN KEY (id_moc)
    REFERENCES MOC(id)
;

ALTER TABLE MasterBuilders.dbo.user_MOC
    ADD    FOREIGN KEY (id_user)
    REFERENCES users(id)
;

ALTER TABLE MasterBuilders.dbo.user_Lset
    ADD    FOREIGN KEY (id_user)
    REFERENCES users(id)
;

ALTER TABLE MasterBuilders.dbo.user_Lset
    ADD    FOREIGN KEY (id_Lset)
    REFERENCES Lset(id)
;

ALTER TABLE MasterBuilders.dbo.user_part
    ADD    FOREIGN KEY (id_user)
    REFERENCES users(id)
;

ALTER TABLE MasterBuilders.dbo.user_part
    ADD    FOREIGN KEY (id_part)
    REFERENCES part(id)
;

ALTER TABLE MasterBuilders.dbo.part
    ADD    FOREIGN KEY (category)
    REFERENCES category(id)
;