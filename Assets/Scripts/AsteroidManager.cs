using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] private Asteroid_SO asteroidSo;
    public int Stage { get; private set; }

    public void onDestroyed()
    {
        //delegate points to SO
        asteroidSo.AsteroidDestroyed(Stage);
    }
    
    public void ConfigureNewAsteroid()
    {
        
        SetAsteroidFeatures(this.gameObject,asteroidSo.initialSize);
        
        //set children
        SpawnChildren(this.gameObject, asteroidSo.initialSize - 1);
        
        //get it moving
        GetComponent<AsteroidMovement>().FreeAsteroid();
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
        
        //set stage
        asteroid.GetComponent<AsteroidManager>().Stage = stage;
    }
}
