using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get mouse position
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);

        transform.LookAt(new Vector3(mouse.x, mouse.y, 0), Vector3.back);


    }
}
