/**
 * Helpers.cs - a helpers function collection
 * 
 * a collection of public static functions for use in the game
 */


using UnityEngine;

public class Helpers
{
    /**
     * a random function that is closer to the Lua version used in Colton's Löve2D implementation
     */
    public static float random(float from, float to)
    {
        return Random.value * (to - from) + from;
    }

    /**
     * get dx, dy from length and angle.
     */
    public static Vector2 polarToOrthogonal(float len, float ang)
    {
        return new Vector2(Mathf.Cos(ang * Mathf.Deg2Rad), Mathf.Sin(ang * Mathf.Deg2Rad));
    }
}
