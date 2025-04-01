using GoDotPillar;

namespace Godot;

public static class RandomGDPBetaExtension
{
    public static T GetRandomElement<T>(this T[] arr)
    {
        return arr[Random.Shared.Next(arr.Length)];
    }

    public static T GetRandomElement<T>(this T[] arr, float[] weights)
    {
        return RandomGp.GetOption(arr, weights);
    }

    public static E GetRandomType<E>(this E @enum, float[] weights = default)
        where E : struct, Enum
    {
        return weights == default
            ? RandomGp.GetOption(Enum.GetValues<E>())
            : RandomGp.GetOption(Enum.GetValues<E>(), weights);
    }
}