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

    public static T GetOption<T>(T[] options, float[] weights)
    {
        if (options.Length != weights.Length)
        {
            throw new IndexOutOfRangeException("options length and weights length must be equal");
        }

        var rnd = Random.Shared.NextSingle() * weights.Sum();

        for (int i = 0; i < options.Length; i++)
        {
            if (rnd <= weights[i])
            {
                return options[i];
            }
            else
            {
                rnd -= weights[i];
            }
        }

        return options[^1];
    }

    public static T GetOption<T>(T[] options)
    {
        var weights = options.Select(o => 1f).ToArray();

        return GetOption<T>(options, weights);
    }
}