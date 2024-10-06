INSERT INTO Planets (Name, RightAscensionInDegrees, DeclinationInDegrees, DistanceFromEarthInParsecs, RelativeBrightnessToSun, SunTemperatureInKelvin, RelativeSizeToEarth, RelativeMassToEarth, RelativeGravityToEarth, NumberOfStarsInSystem) VALUES
    ('L 98-59 d', 1, 1, 3.5, 1, 3000, 2, 2, 2, 1),
    ('GJ 806 b', 2, 2, 4.2, 1.1, 4000, 1.8, 1.8, 1.8, 1),
    ('Gliese 12 b', 3, 3, 4.5, 1.14, 5000, 0.43, 0.23, 0.3, 4),
    ('LHS 475 b', 4, 4, 5.0, 1.2, 6000, 0.452, 0.41234, 0.4212, 3),
    ('TOI-540 b', 5, 5, 5.5, 1.51, 7000, 0.5, 0.5, 0.5, 2),
    ('LHS 3844 b', 6, 6, 6.0, 1.6, 8000, 1.6, 1.6, 1.6, 3),
    ('GJ 238 b', 7, 7, 6.5, 1.7, 9000, 1.7, 1.7, 1.7, 1),
    ('GJ 3929 b', 8, 8, 7.0, 2, 10000, 0.8, 0.8, 0.8, 1),
    ('GJ 143 b', 9, 9, 7.5, 3.9421, 11000, 0.9, 0.9, 0.9, 1);

SET IDENTITY_INSERT Stars ON;

INSERT INTO Stars (Id, Name, RightAscensionInDegrees, DeclinationInDegrees, DistanceFromEarthInParsecs, Luminosity) VALUES
    (1, 'Star 1', 1.0000, 1.0000, 1.0000, 1.0000),
    (2, 'Star 2', 2.0000, 2.0000, 2.0000, 2.0000),
    (3, 'Star 3', 3.0000, 3.0000, 3.0000, 3.0000),
    (4, 'Star 4', 4.0000, 4.0000, 4.0000, 4.0000),
    (5, 'Star 5', 5.0000, 5.0000, 5.0000, 5.0000),
    (6, 'Star 6', 6.0000, 6.0000, 6.0000, 6.0000),
    (7, 'Star 7', 7.0000, 7.0000, 7.0000, 7.0000),
    (8, 'Star 8', 8.0000, 8.0000, 8.0000, 8.0000),
    (9, 'Star 9', 9.0000, 9.0000, 9.0000, 9.0000);

SET IDENTITY_INSERT Stars OFF;

SET IDENTITY_INSERT StarMaps ON;

INSERT INTO StarMaps (Id, PlanetId ) VALUES (1, 1)

SET IDENTITY_INSERT StarMaps OFF;

INSERT INTO VisibleStars (StarId, StarMapId, Longitude, Latitude, Brightness) VALUES
   (1, 1, 10.00, 10.00, 0.999),
   (2, 1, 20.00, 20.00, 0.900),
   (3, 1, 30.00, 30.00, 0.850),
   (4, 1, 40.00, 40.00, 0.750),
   (5, 1, 50.00, 50.00, 0.700),
   (6, 1, 60.00, 60.00, 0.600),
   (7, 1, 70.00, 70.00, 0.500),
   (8, 1, 80.00, 80.00, 0.400),
   (9, 1, 90.00, 90.00, 0.300);
