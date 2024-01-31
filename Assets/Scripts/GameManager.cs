using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Asteroid_SO asteroidSo;
    
    private float minSpeed = 5f;

    private float maxSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAsteroid()
    {
        GameObject asteroid = Instantiate(asteroidSo.GetRandomAsteroidPrefab());
        
        SetAsteroidFeatures(asteroid,asteroidSo.initialSize);
        
        //set children
        //TODO - make recursive so that parenting is recursive
        for (int x = asteroidSo.initialSize - 1; x > 0; x--)
        {
            GameObject child1 = Instantiate(asteroidSo.GetRandomAsteroidPrefab(), asteroid.transform);
            GameObject child2 = Instantiate(asteroidSo.GetRandomAsteroidPrefab(), asteroid.transform);
            
            //set stuff...
            SetAsteroidFeatures(child1, x);
            SetAsteroidFeatures(child2, x);
        }
        
        //set velocity
        //TODO - set velocity
    }

    private void SetAsteroidFeatures(GameObject asteroid, int stage)
    {
        Vector3 randomRotation = new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
        Vector3 randomShift = new Vector3(Random.Range(0, 0.5f), Random.Range(0, 0.5f), 0);
        //offset position slightly
        asteroid.transform.localPosition = Vector3.zero + randomShift;
        asteroid.transform.Rotate(randomRotation);
        
        //set size
        asteroid.transform.localScale *= stage * 1.0f / 3.0f;

        //set velocity?
    }
}
