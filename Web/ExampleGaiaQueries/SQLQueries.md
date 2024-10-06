## Query to get stars from earth 

- Get the stars visible from the earth
- Looking from the North Pole (ra = 0, dec = 90)
- Getting the 180deg view from this point
- Getting the stars with an apparent magnitude (phot_g_mean_mag) of minimum 4

```sql
SELECT TOP 1000 designation, source_id, parallax, 1000/parallax AS source_distance, ra, dec, phot_g_mean_mag as apparent_magnitude, DISTANCE(0, 90, ra, dec) AS ang_sep
FROM gaiadr3.gaia_source
WHERE DISTANCE(0, 90, ra, dec) < 90
  AND phot_g_mean_mag < 4
  AND parallax is not null
ORDER BY phot_g_mean_mag Desc
```

## Get the stars with the highest absolute brightness from the earth (with apparent magnitude less than 9)

```sql
SELECT TOP 300000 source_id, ra, dec, parallax, abs(1000/parallax) AS source_distance, phot_g_mean_mag as apparent_magnitude, phot_g_mean_mag - 5 * log10(abs(1000/parallax)/10) AS absolute_magnitude
FROM gaiadr3.gaia_source
WHERE parallax is not null
  AND phot_g_mean_mag is not null
  AND phot_g_mean_mag < 9
ORDER BY absolute_magnitude ASC
```