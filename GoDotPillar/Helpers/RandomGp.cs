namespace GoDotPillar;

public static class RandomGp
{
    public static float Float(float minValue, float maxValue)
    {
        var dif = maxValue - minValue;
        return (float)Random.Shared.NextDouble() * dif + minValue;
    }

    public static int Int(int minValue, int maxValue)
    {
        var dif = maxValue - minValue;
        return (int)(Random.Shared.NextDouble() * dif + minValue);
    }
}