using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="WaveData" , menuName = "ScribtableObjects/WaveData" , order = 0)]
public class WaveData: ScriptableObject
{
    [Min(0f)]
    public int nrOfEnemys;
    [Min(0f)]
    public float speed;
    [Min(0f)]
    public float respawnMinTime;
    [Min(0f)]
    public float respawnRange;
    [Min(0f)]
    public float waitForNextWave;
}
