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
        SpawnChildren(asteroid, asteroidSo.initialSize - 1);
        
        //get it moving
        asteroid.GetComponent<AsteroidMovement>().FreeAsteroid();
    }

    private void SpawnChildren(GameObject asteroid, int stage)
    {
        if(stage <= 0) return;
        
        GameObject child1 = Instantiate(asteroidSo.GetRandomAsteroidPrefab(), asteroid.transform);
        GameObject child2 = Instantiate(asteroidSo.GetRandomAsteroidPrefab(), asteroid.transform);
            
        //set stuff...
        SetAsteroidFeatures(child1, stage);
        SetAsteroidFeatures(child2, stage);

        child1.GetComponent<Rigidbody>().isKinematic = true;
        child2.GetComponent<Rigidbody>().isKinematic = true;

        child1.GetComponent<Collider>().enabled = false;
        child2.GetComponent<Collider>().enabled = false;

        
        SpawnChildren(child1, stage - 1);
        SpawnChildren(child2, stage - 1);
    }

    private void SetAsteroidFeatures(GameObject asteroid, int stage)
    {
        Vector3 randomRotation = new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
        Vector3 randomShift = new Vector3(Random.Range(0, 0.5f), Random.Range(0, 0.5f), 0);
        Vector3 randomDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
        //offset position slightly
        asteroid.transform.localPosition = Vector3.zero + randomShift;
        asteroid.transform.Rotate(randomRotation);
        
        //set size
        asteroid.transform.localScale *= stage * 1.0f / asteroidSo.initialSize;

        //set velocity
        asteroid.GetComponent<AsteroidMovement>().Velocity = Random.Range(5.0f, 10.0f) / stage;
        asteroid.GetComponent<AsteroidMovement>().Direction = randomDirection;
    }
}
