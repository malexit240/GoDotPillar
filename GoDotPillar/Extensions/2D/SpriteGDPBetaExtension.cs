namespace Godot;

public static class SpriteGDPBetaExtension
{
    public static Collections.Array<Vector2[]> ToPolygons(this Sprite2D sprite, float simplification = 5f)
    {
        var bitMap = new Bitmap();
        bitMap.CreateFromImageAlpha(sprite.Texture.GetImage());
        var imageSize = bitMap.GetSize();

        var imageOffset = sprite.Centered ? sprite.Offset - new Vector2I(imageSize.X / 2, imageSize.Y / 2)
            : sprite.Offset;

        var polygons = bitMap.OpaqueToPolygons(new Rect2I(Vector2I.Zero, imageSize),
            simplification);

        var correctedPolygons = new Godot.Collections.Array<Vector2[]>
        {
        };

        for (int i = 0; i < polygons.Count; i++)
        {
            var newPolygon = new Vector2[polygons[i].Length];

            for (int j = 0; j < polygons[i].Length; j++)
            {
                var newX = sprite.FlipH
                    ? -(polygons[i][j].X + imageOffset.X)
                    : polygons[i][j].X + imageOffset.X;

                var newY = sprite.FlipV
                    ? -(polygons[i][j].Y + imageOffset.Y)
                    : polygons[i][j].Y + imageOffset.Y;

                newPolygon[j] = new Vector2(newX, newY);
            }

            correctedPolygons.Add(newPolygon);
        }

        return correctedPolygons;
    }

    public static Polygon2D ToPolygon2D(this Collections.Array<Vector2[]> source)
    {
        var polygon = new Polygon2D();

        if (source.Count == 1)
        {
            polygon.Polygon = source[0];
        }
        else if (source.Count > 1)
        {
            for (int i = 0; i < source.Count; i++)
            {
                polygon.Polygons.Add(source[i]);
            }
        }

        return polygon;
    }

    public static CollisionPolygon2D[] MakeManyCollisionPolygon2D(this Collections.Array<Vector2[]> source)
    {
        var polygons = new CollisionPolygon2D[source.Count];

        for (int i = 0; i < source.Count; i++)
        {
            var polygon = new CollisionPolygon2D();
            polygon.Polygon = source[i];
        }

        return polygons;
    }

    public static CollisionPolygon2D MakeCollisionPolygon2D(this Collections.Array<Vector2[]> source)
    {
        var polygon = new CollisionPolygon2D();
        polygon.Polygon = source[0];

        return polygon;
    }

    public static LightOccluder2D[] MakeManyLightOccluder2D(this Collections.Array<Vector2[]> source)
    {
        var lightOccluders = new LightOccluder2D[source.Count];

        for (int i = 0; i < source.Count; i++)
        {
            var lightOccluder = new LightOccluder2D();
            lightOccluder.Occluder = new OccluderPolygon2D();
            lightOccluder.Occluder.Polygon = source[i];
        }

        return lightOccluders;
    }

    public static LightOccluder2D MakeLightOccluder2D(this Collections.Array<Vector2[]> source)
    {
        var lightOccluder = new LightOccluder2D();
        lightOccluder.Occluder = new OccluderPolygon2D();
        lightOccluder.Occluder.Polygon = source[0];

        return lightOccluder;
    }
}
