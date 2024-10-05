using System; 

class CoordinatesHelpers
{
    private const int RadiusOfStarMap = 500; 

    private static double DegreeToRadian (double degree) 
    {
        return degree * Math.PI / 180;
    }

    private static (double x, double y) PolarToCartesian(double radius, double theta)
    {
        double x = radius * Math.Cos(theta);
        double y = radius * Math.Sin(theta);
        return (x, y);
    }

    public static (double x, double y) GetStarCatesianCoordinatesInStarMap(double ra, double dec)
    {
        double radius = Math.Cos(DegreeToRadian(dec)) * RadiusOfStarMap;
        double theta = DegreeToRadian(ra); 

        return PolarToCartesian(radius, theta);
    }
}

