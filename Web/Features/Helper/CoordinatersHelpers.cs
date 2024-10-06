using System;

class CoordinatesHelpers
{
    private const int RadiusOfStarMap = 500;

    private static double DegreeToRadian (double degree)
    {
        return degree * Math.PI / 180;
    }

    private static double RadianToDegree (double radian)
    {
        return radian * 180 / Math.PI;
    }

    private static (double x, double y) PolarToCartesian(double radius, double theta)
    {
        double x = radius * Math.Cos(theta);
        double y = radius * Math.Sin(theta);
        return (x, y);
    }

    static (double, double, double) SphericalToCartesian(double raDeg, double decDeg, double distance)
    {
        double raRad = DegreeToRadian(raDeg);
        double decRad = DegreeToRadian(decDeg);

        double x = distance * Math.Cos(decRad) * Math.Cos(raRad);
        double y = distance * Math.Cos(decRad) * Math.Sin(raRad);
        double z = distance * Math.Sin(decRad);

        return (x, y, z);
    }

    // Convert Cartesian coordinates back to RA, Dec, and Distance
    static (double, double, double) CartesianToSpherical(double x, double y, double z)
    {
        double distance = Math.Sqrt(x * x + y * y + z * z);
        double raRad = Math.Atan2(y, x); // Atan2 automatically handles quadrant.
        double decRad = Math.Asin(z / distance);

        double raDeg = RadianToDegree(raRad);
        if (raDeg < 0) raDeg += 360; // Adjust RA to be in [0, 360] degrees
        double decDeg = RadianToDegree(decRad);

        return (raDeg, decDeg, distance);
    }

    static (double, double, double) ComputeRelativePositionStarPlanet(
            double starRaDeg, double starDecDeg, double starDist,
            double planetRaDeg, double planetDecDeg, double planetDist)
    {
        // Convert star and planet positions to Cartesian coordinates
        var (starX, starY, starZ) = SphericalToCartesian(starRaDeg, starDecDeg, starDist);
        var (planetX, planetY, planetZ) = SphericalToCartesian(planetRaDeg, planetDecDeg, planetDist);

        // Compute the vector from planet P to the star
        double planetStarX = starX - planetX;
        double planetStarY = starY - planetY;
        double planetStarZ = starZ - planetZ;

        // Convert the relative Cartesian coordinates back to spherical (RA, Dec, Distance)
        return CartesianToSpherical(planetStarX, planetStarY, planetStarZ);
    }

    public static (double x, double y) GetStarCatesianCoordinatesInStarMap(double ra, double dec)
    {
        double radius = Math.Cos(DegreeToRadian(dec)) * RadiusOfStarMap;
        double theta = DegreeToRadian(ra);

        return PolarToCartesian(radius, theta);
    }
}
