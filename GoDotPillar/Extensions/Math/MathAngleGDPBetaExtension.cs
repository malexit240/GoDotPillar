namespace Godot;

public static class MathAngleGDPBetaExtension
{
    public static float ToPositiveAngle(this float angle)
    {
        while (angle < 0)
        {
            angle += Mathf.Pi * 2;
        }

        while (angle > Mathf.Pi * 2)
        {
            angle -= Mathf.Pi * 2;
        }

        return angle;
    }

    public static float AngleDifference(this float from, float to)
    {
        return Mathf.AngleDifference(from, to);
    }

    public static Vector2 ToDirection(this float angle)
    {
        return Vector2.FromAngle(angle);
    }
}