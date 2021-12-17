using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManage : MonoBehaviour
{
    public static void Increase()
    {
        Spawner._waveTotal++;
    }

    public static void Decrease()
    {
        if (Spawner._waveTotal <= 0)
        {
            Spawner._waveTotal = 1;
        }
        else
        {
            Spawner._waveTotal--;
        }
    }
}
