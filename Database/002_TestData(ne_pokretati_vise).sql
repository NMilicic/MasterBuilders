USE [MasterBuilders]
GO

INSERT INTO [dbo].[korisnik] 
            ([email], 
             [zaporka], 
             [ime], 
             [prezime]) 
VALUES      ('test@test.com', 
             'test', 
             'testName', 
             'testLastName') 

INSERT INTO [dbo].[korisnik] 
            ([email], 
             [zaporka], 
             [ime], 
             [prezime]) 
VALUES      ('test2@test.com', 
             'test2', 
             'testName2', 
             'testLastName2') 

INSERT INTO [dbo].[tema]
           ([id_nadtema]
           ,[ime_tema])
     VALUES
           (NULL
           ,'Tema 1')

		   INSERT INTO [dbo].[tema]
           ([id_nadtema]
           ,[ime_tema])
     VALUES
           (1
           ,'Tema 2')

		   		   INSERT INTO [dbo].[tema]
           ([id_nadtema]
           ,[ime_tema])
     VALUES
           (NULL
           ,'Tema 3')

INSERT INTO [dbo].[moc] 
            ([ime], 
             [god_pro], 
             [dijelovi_broj], 
             [tema1], 
             [tema2], 
             [tema3], 
             [opis], 
             [id_autor]) 
VALUES      ('Moc 2', 
             2016, 
             150, 
             'Tema bez teme2', 
             '', 
             NULL, 
             'Opis', 
             1) 

INSERT INTO [dbo].[moc] 
            ([ime], 
             [god_pro], 
             [dijelovi_broj], 
             [tema1], 
             [tema2], 
             [tema3], 
             [opis], 
             [id_autor]) 
VALUES      ('Moc 1', 
             2016, 
             150, 
             'Tema bez teme', 
             '', 
             NULL, 
             'Opis', 
             2) 

INSERT INTO [dbo].[moc] 
            ([ime], 
             [god_pro], 
             [dijelovi_broj], 
             [tema1], 
             [tema2], 
             [tema3], 
             [opis], 
             [id_autor]) 
VALUES      ('Moc 3', 
             2016, 
             150, 
             'Tema bez teme 3', 
             '', 
             NULL, 
             'Opis', 
             2) 

INSERT INTO [dbo].[lset] 
            ([ime], 
             [god_pro], 
             [dijelovi_broj], 
             [opis], 
             [id_tema]) 
VALUES      ('Prvi set', 
             2017, 
             20, 
             'Neki opis', 
             1) 

INSERT INTO [dbo].[lset] 
            ([ime], 
             [god_pro], 
             [dijelovi_broj], 
             [opis], 
             [id_tema]) 
VALUES      ('Drugi set', 
             2016, 
             20, 
             'Neki opis', 
             2) 

INSERT INTO [dbo].[lset] 
            ([ime], 
             [god_pro], 
             [dijelovi_broj], 
             [opis], 
             [id_tema]) 
VALUES      ('Treci set', 
             2010, 
             20, 
             'Neki opis', 
             1)
			 
INSERT INTO [dbo].[user_set] 
            ([korisnik_id], 
             [lset_id], 
             [slozeno]) 
VALUES      (1, 
             1, 
             1) 

INSERT INTO [dbo].[user_set] 
            ([korisnik_id], 
             [lset_id], 
             [slozeno]) 
VALUES      (2, 
             1, 
             0) 

INSERT INTO [dbo].[user_set] 
            ([korisnik_id], 
             [lset_id], 
             [slozeno]) 
VALUES      (2, 
             2, 
             1) 
			 
INSERT INTO [dbo].[boja] 
            ([ime]) 
VALUES      ('Zelena') 

INSERT INTO [dbo].[boja] 
            ([ime]) 
VALUES      ('Žuta') 

INSERT INTO [dbo].[boja] 
            ([ime]) 
VALUES      ('Plava') 

DECLARE @i INT = 1; 
WHILE( @i < 6 ) 
  BEGIN 
      INSERT INTO [dbo].[kockica] 
                  ([ime], 
                   [kategorija]) 
      VALUES      (Concat('Kockica ', @i), 
                   Concat('Kategorija ', @i)) 

      SET @i = @i + 1; 
  END 
  
INSERT INTO [dbo].[moc_dijelovi] 
            ([id_boja], 
             [id_koc], 
             [id_set], 
             [broj]) 
VALUES      (2, 
             1, 
             1, 
             10) 

INSERT INTO [dbo].[moc_dijelovi] 
            ([id_boja], 
             [id_koc], 
             [id_set], 
             [broj]) 
VALUES      (2, 
             5, 
             1, 
             2) 

INSERT INTO [dbo].[moc_dijelovi] 
            ([id_boja], 
             [id_koc], 
             [id_set], 
             [broj]) 
VALUES      (3, 
             2, 
             1, 
             2)  

INSERT INTO [dbo].[setovi_dijelovi] 
            ([id_boja], 
             [id_koc], 
             [id_set], 
             [broj]) 
VALUES      (2, 
             1, 
             1, 
             10) 

INSERT INTO [dbo].[setovi_dijelovi] 
            ([id_boja], 
             [id_koc], 
             [id_set], 
             [broj]) 
VALUES      (2, 
             5, 
             1, 
             2) 

INSERT INTO [dbo].[setovi_dijelovi] 
            ([id_boja], 
             [id_koc], 
             [id_set], 
             [broj]) 
VALUES      (3, 
             2, 
             1, 
             2) 

INSERT INTO [dbo].[user_kockica] 
            ([korisnik_id], 
             [kockica_id]) 
VALUES      (2, 
             2) 

INSERT INTO [dbo].[user_kockica] 
            ([korisnik_id], 
             [kockica_id]) 
VALUES      (2, 
             3) 

INSERT INTO [dbo].[user_kockica] 
            ([korisnik_id], 
             [kockica_id]) 
VALUES      (1, 
             3) 

INSERT INTO [dbo].[user_moc] 
            ([korisnik_id], 
             [id_moc], 
             [slozeno]) 
VALUES      (1, 
             1, 
             1) 

INSERT INTO [dbo].[user_moc] 
            ([korisnik_id], 
             [id_moc], 
             [slozeno]) 
VALUES      (2, 
             2, 
             1) 

INSERT INTO [dbo].[user_moc] 
            ([korisnik_id], 
             [id_moc], 
             [slozeno]) 
VALUES      (1, 
             2, 
             1) 
