namespace Godot;

public static class RandomGDPBetaExtension
{
    public static T GetRandomElement<T>(this T[] arr)
    {
        return arr[Random.Shared.Next(arr.Length)];
    }
}