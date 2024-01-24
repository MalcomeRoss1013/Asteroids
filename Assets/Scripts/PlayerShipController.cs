using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlayerShipController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    private Rigidbody body;
    private float xDirection, yDirection;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
    }


    void FixedUpdate()
    {
        body.MovePosition(body.position + (new Vector3(xDirection,yDirection) * speed * Time.deltaTime));
    }
}
