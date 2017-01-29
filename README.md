# MasterBuilders

Drive folder:https://drive.google.com/drive/folders/0By_qyIKmuu8WWmtQalJZQWNYaU0?usp=sharing

Use case:https://docs.google.com/document/d/1tN5cN3THoLty2c4a44iEDinpXfy4qhf6kADtMjs9dvI/edit

Dokumentacija: https://docs.google.com/document/d/1VmzhJ_FfaCRXGdTA0hcSvCsyHife0CxImZAuAtyNyd8/edit


Postavljanje projekta:

1.Treba imati instalirano:
  Visual studio 2015 ili noviji
  MSSQL Server 2012 (instalirajte si Microsoft SQL Server Management Studio ja imam 2014 verziju) 
  
2. Folder Database
  U ovom folderu se nalaze sve skripte vezane za bazu. Označeni su brojevima zbog redosljeda izvršavanja pa ako dodajete nešto upišite broj veći od prethodnog :)
  1. 001_InitalScript - Kreira sve tablice
  2. 002_TestData - ne pokretati imamo novi test data
  3. 003_Added_Whishlist - dodaje tablice za popis želja
  4. 004_dodatni_atributi
  5. 005_lego_podaci - novi testini podatci
  6. 006_upute - dodane upute
  7. 007_slike_automatski
  8. 008_upute_automatski
  
3. Otvorite Solution:
1. Namjestite connection string -> Trenutno u WebApi Projektu -> Web.config -> Search "ConnectionString" (Ja sam commitao s svojim tako da si lokalno postavite svoj i nakon toga će vam javljati da to commitate, nemojte :) Nego svaki puta kada povučete nešto novo opet ga promijeniti. Najjednostavnije bi bilo da svatko svoj doda kao komentar ispod mog i onda si nakog svakog pulla to odkomentirate.)
2. Postavite StartUp project -> Desni klik na projektu na kojem radite i Set As StartUp Project
3. Trebalo bi se to sve pokrenuti
