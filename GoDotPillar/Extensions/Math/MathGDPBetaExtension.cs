namespace Godot;

public static class MathGDPBetaExtension
{
    public static T GetValueByIndex<T>(this T[] arr, int index)
    {
        while (index >= arr.Length)
        {
            index -= arr.Length;
        }

        return arr[index];
    }
}