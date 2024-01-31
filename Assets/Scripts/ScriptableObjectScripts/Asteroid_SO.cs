using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable Object/Asteroid_SO", fileName = "Asteroid")]
public class Asteroid_SO : ScriptableObject
{
    public int initialSize = 3;
    public float initialSpeed = 10;
    public GameObject[] asteroidPrefabs;
    [SerializeField] UnityEvent<int> onAsteroidDestroyed;

    public GameObject GetRandomAsteroidPrefab()
    {
        return asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
    }

    public void AsteroidDestroyed(int stage)
    {
        onAsteroidDestroyed?.Invoke(stage);
    }
}


