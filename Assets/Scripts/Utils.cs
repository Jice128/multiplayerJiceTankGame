using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector3 GetRandomSpawnPoint()
    {
        Vector3 _spawnVector = new Vector3(Random.Range(-8, 8), 0.75f, Random.Range(-4.5f, 2.45f)); //gives coordinates to spawn
        return _spawnVector;
    }
}
