## Query to get stars from earth 

- Get the stars visible from the earth
- Looking from the North Pole (ra = 0, dec = 90)
- Getting the 180deg view from this point
- Getting the stars with an apparent magnitude (phot_g_mean_mag) of minimum 4
- ra : Right ascension (double, Angle[deg])
- dec : Declination (double, Angle[deg])
- phot_g_mean_mag : G-band mean magnitude (float, Magnitude[mag]) = apparent magnitude
- parallax : Parallax (double, Angle[mas] )
- source_distance: parsecs

```sql
SELECT TOP 1000 designation, source_id, parallax, 1000/parallax AS source_distance, ra, dec, phot_g_mean_mag as apparent_magnitude, DISTANCE(0, 90, ra, dec) AS ang_sep
FROM gaiadr3.gaia_source
WHERE DISTANCE(0, 90, ra, dec) < 90
  AND phot_g_mean_mag < 4
  AND parallax is not null
ORDER BY phot_g_mean_mag Desc
```

## Query the 5,000 brightest stars (which might be visible from all the exoplanets)

