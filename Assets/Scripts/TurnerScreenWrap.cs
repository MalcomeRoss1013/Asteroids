using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnerScreenWrap : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cam != null && collider != null)
        {
            //get object position in the camera
            Vector3 screenPosition = cam.WorldToScreenPoint(transform.position);
            Vector3 bottomLeftSidePosition = cam.WorldToScreenPoint(transform.position - collider.bounds.extents);
            Vector3 topRightSidePosition = cam.WorldToScreenPoint(transform.position + collider.bounds.extents);


            //get the world positions for camera edges
            Vector2 topRightSide = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            Vector2 bottomLeftSide = cam.ScreenToWorldPoint(new Vector2(0, 0));

            Vector3 modifiedPosition = transform.position;

            if(bottomLeftSidePosition.x > cam.pixelWidth)
            {
                modifiedPosition.x = bottomLeftSide.x - collider.bounds.extents.x;
            }else if(topRightSidePosition.x < 0)
            {
                modifiedPosition.x = topRightSide.x + collider.bounds.extents.x;
            }
            
            if(bottomLeftSidePosition.y > cam.pixelHeight)
            {
                modifiedPosition.y = bottomLeftSide.y - collider.bounds.extents.y;
            }else if(topRightSidePosition.y < 0)
            {
                modifiedPosition.y = topRightSide.y + collider.bounds.extents.y;
            }

            transform.position = modifiedPosition;
        }
    }
}
