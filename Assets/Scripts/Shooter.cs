using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float speed = 4;
    [SerializeField]
    private float secondsBetweenBullets = 0.5f;
    private bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && Input.GetButton("Fire1") && bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, speed), ForceMode.VelocityChange);
            StartCoroutine(ShootDelay());

            Destroy(bullet, 2.0f);
        }
    }

    IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(secondsBetweenBullets);
        canShoot = true;
    }
}
