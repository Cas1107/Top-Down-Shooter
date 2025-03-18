using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schiet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform ShootPoint;
    public float bulletForce = 2000f;
    public bool isGrounded = true;

    void Update()
    {
        // Controleer of de linkermuisknop is ingedrukt
        if (Input.GetMouseButtonDown(0)) // 0 = linkermuisknop
        {
            GameObject tempBullet = Instantiate(bulletPrefab, ShootPoint.position, ShootPoint.rotation);

            // Zorg ervoor dat de kogel rood wordt
            SpriteRenderer bulletRenderer = tempBullet.GetComponent<SpriteRenderer>();


            // Voeg kracht toe aan de kogel
            Rigidbody2D rb = tempBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(transform.right * bulletForce);
            }

        }
    }
}
