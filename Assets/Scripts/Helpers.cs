using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers
{
    public static float random(float from, float to)
    {
        return Random.value * (to - from) + from;
    }

    public static Vector2 polarToOrthogonal(float len, float ang)
    {
        return new Vector2(Mathf.Cos(ang * Mathf.Deg2Rad), Mathf.Sin(ang * Mathf.Deg2Rad));
    }
}
