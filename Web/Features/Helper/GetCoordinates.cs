using System; 

class PolarCoordinateHelperCalculator
{
    const var RadiusOfStarMap = 500; 

    public static (double x, double y) PolarToCartesian(double radius, double theta)
    {
        double x = radius * Math.Cos(theta);
        double y = radius * Math.Sin(theta);
        return (x, y);
    }

    private static double DegreeToRadian (double degree) 
    {
        return degree * Math.PI / 180;
    }

    public static (double x, double y) GetStarCatesianCoordinatesInStarMap(double ra, double dec)
    {
        double radius = Math.Cos(DegreeToRadian(dec)) * RadiusOfStarMap;
        double theta = DegreeToRadian(ra - 90); 

        return PolarToCartesian(radius, theta);
    }
}

