using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLimiter : MonoBehaviour
{
    public static void Increase()
    {
        Spawner._enemyTotal++;
    }

    public static void Decrease()
    {
        if (Spawner._enemyTotal <= 0)
        {
            Spawner._enemyTotal = 1;
        }
        else
        {
            Spawner._enemyTotal--;
        }
    }
}
