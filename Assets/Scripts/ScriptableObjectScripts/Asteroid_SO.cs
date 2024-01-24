using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Asteroid_SO", fileName = "Asteroid")]
public class Asteroid_SO : ScriptableObject
{
    public float initialSize = 3;
    public float initialSpeed = 10;
    public GameObject[] asteroidPrefabs;

    public GameObject GetRandomAsteroidPrefab()
    {
        return asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
    }
}


