using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType : int 
{
   NONE,
   PORTAL
}
static class PowerUpTypeMethods
{
    public static Color color(this PowerUpType power)
    {
        switch (power)
        {
            case PowerUpType.NONE:
                return new Color(0, 235, 253);
            case PowerUpType.PORTAL:
                return new Color(88, 0, 161);
            default: return new Color(0, 235, 253);
        }
    }

    public static int powerMultiplier(this PowerUpType power)
    {
        switch (power)
        {
            case PowerUpType.PORTAL:
                return 2;
            default:
                return 1;
        }
    }
}