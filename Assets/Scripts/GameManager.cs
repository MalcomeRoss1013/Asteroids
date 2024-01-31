using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Asteroid_SO asteroidSo;

    [SerializeField] private HUDController hudController;
    
    private float minSpeed = 5f;

    private float maxSpeed = 10f;

    private int currentScore = 0;
    private int currentLives = 3;
    

    public void SpawnAsteroid()
    {
        GameObject asteroid = Instantiate(asteroidSo.GetRandomAsteroidPrefab());
        
        asteroid.GetComponent<AsteroidManager>().ConfigureNewAsteroid();
        
    }

    public void IncreasePoints(int points)
    {
        currentScore += points;
        hudController.UpdateScore(currentScore);
    }

}
