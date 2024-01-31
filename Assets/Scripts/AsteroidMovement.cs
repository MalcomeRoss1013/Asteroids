using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidMovement : MonoBehaviour
{

    public float Velocity { get; set; }
    public Vector3 Direction { private get; set; } //to remove
    private Rigidbody _body;
    
    // Start is called before the first frame update
    void Awake()
    {
        _body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FreeAsteroid()
    {
        //Vector3 direction = new Vector3(Random.Range(1f, Velocity), Random.Range(1f, Velocity), 0);
        _body.AddForce(Direction * Velocity, ForceMode.VelocityChange);
    }
}
