
INSERT INTO AspNetUsers 
(Id, UserName, Email, PasswordHash, PhoneNumber, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, LockoutEnd, ConcurrencyStamp, SecurityStamp, Voornaam, Achternaam, Adres, Telefoonnummer, Specialisatie, Licentie)
VALUES
('1', 'janvermeer', 'jan@example.com', 'AQAAAAIA...', '0612345678', 1, 0, 0, 0, 0, NULL, 'SOME_CONCURRENCY_STAMP', 'SOME_SECURITY_STAMP', 'Jan', 'Vermeer', 'Lindelaan 12, Amsterdam', '0612345678', 'Orthodontie', 'NL-12345-ORTHO'),
('2', 'elsjansen', 'els@example.com', 'AQAAAAIA...', '0612345679', 1, 0, 0, 0, 0, NULL, 'SOME_CONCURRENCY_STAMP', 'SOME_SECURITY_STAMP', 'Els', 'Jansen', 'Tulpenstraat 23, Rotterdam', '0612345679', 'Endodontologie', 'NL-67890-ENDO'),
('3', 'keesvandijk', 'kees@example.com', 'AQAAAAIA...', '0612345680', 1, 0, 0, 0, 0, NULL, 'SOME_CONCURRENCY_STAMP', 'SOME_SECURITY_STAMP', 'Kees', 'van Dijk', 'Boomgaard 5, Utrecht', '0612345680', 'Implantologie', 'NL-34567-IMPLANT'),
('4', 'lisadevries', 'lisa@example.com', 'AQAAAAIA...', '0612345681', 1, 0, 0, 0, 0, NULL, 'SOME_CONCURRENCY_STAMP', 'SOME_SECURITY_STAMP', 'Lisa', 'de Vries', 'Esdoornlaan 45, Den Haag', '0612345681', 'Parodontologie', 'NL-89012-PARODONT');

INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
VALUES 
('1', 'Tandarts', 'TANDARTS', NEWID()),
('2', 'TandartsAssistent', 'TANDARTSASSISTENT', NEWID());

INSERT INTO AspNetUserRoles (UserId, RoleId)
VALUES 
('1', '1'), 
('2', '1'),  
('3', '2'), 
('4', '2'); 

INSERT INTO Klant (Voornaam, Achternaam, Adres, Telefoonnummer)
VALUES
('Kees', 'van Dijk', 'Boomgaard 5, Utrecht', '0612345680'),
('Lisa', 'de Vries', 'Esdoornlaan 45, Den Haag', '0612345681'),
('Tom', 'Pietersen', 'Eikenstraat 12, Haarlem', '0612345682'),
('Sophie', 'Bakker', 'Kastanjelaan 78, Eindhoven', '0612345683'),
('Mark', 'Koster', 'Wilgenstraat 34, Groningen', '0612345684'),
('Emma', 'Visser', 'Beukenstraat 67, Maastricht', '0612345685');

SET IDENTITY_INSERT Behandeling ON;
INSERT INTO Behandeling (Id, Naam, Prijs, Beschrijving)
VALUES
(1, 'Tanden Reinigen', 50.00, 'Professionele tandreiniging en tandplak verwijdering.'),
(2, 'Wortelkanaalbehandeling', 250.00, 'Behandeling van geïnfecteerd tandweefsel.'),
(3, 'Tandextractie', 100.00, 'Het trekken van een tand of kies.');
SET IDENTITY_INSERT Behandeling OFF;


SET IDENTITY_INSERT Afspraak ON;
INSERT INTO Afspraak (Id, DatumTijd, Opmerkingen, GebruikerId, KlantId, BehandelingId)
VALUES
(1, '2024-10-20 09:30:00', 'Patiënt heeft last van tandvlees.', '1', '3', 1),
(2, '2024-10-21 11:00:00', 'Controle en reiniging.', '1', '2', 1),
(3, '2024-10-22 14:00:00', 'Wortelkanaalbehandeling nodig.', '2', '3', 2),
(4, '2024-10-23 16:30:00', 'Moeilijke tandextractie verwacht.', '2', '1', 3),
(5, '2024-10-24 09:00:00', 'Patiënt wil een controle afspraak.', '1', '4', 1), 
(6, '2024-10-24 11:30:00', 'Vervolgafspraak voor wortelkanaalbehandeling.', '2', '3', 2), 
(7, '2024-10-25 14:00:00', 'Patiënt wil esthetische tandreiniging.', '1', '5', 1), 
(8, '2024-10-26 10:30:00', 'Ernstige kiespijn, mogelijk extractie nodig.', '2', '6', 3), 
(9, '2024-10-26 16:00:00', 'Controle afspraak na eerdere extractie.', '1', '4', 1), 
(10, '2024-10-27 09:00:00', 'Patiënt klaagt over gevoelig tandvlees.', '2', '5', 1); 
SET IDENTITY_INSERT Afspraak OFF;