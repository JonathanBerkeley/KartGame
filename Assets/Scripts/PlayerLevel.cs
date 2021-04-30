using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel
{
    public static float playerXp;

    public static int GetLevel()
    {
        return (int) (playerXp / 100.0f);
    }
}
