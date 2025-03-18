namespace GoDotPillar;

using Godot;

public static class MathGp
{
    public static Vector2 GetFrom(Vector2 position, float rotation, float offset, float distance)
    {
        var s = new Sprite2D();

        return position - ((rotation + offset).ToDirection() * distance);
    }


}