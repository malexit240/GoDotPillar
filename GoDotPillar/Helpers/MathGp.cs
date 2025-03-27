namespace GoDotPillar;

using Godot;

public static class MathGp
{
    public static Vector2 GetFrom(Vector2 position, float rotation, float offset, float distance)
    {
        return position - ((rotation + offset).ToDirection() * distance);
    }

    public static float PingPong(float value, float minValue, float maxValue)
    {
        return Mathf.PingPong(value, maxValue - minValue) + minValue;
    }
}
