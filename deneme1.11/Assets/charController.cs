using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    Rigidbody charRb;

    float hiz = 10;
    float ziplamaHizi = 500;
    bool zipla, ziplandiMi;
    float hizHorizontal, hizVertical;
    void Start()
    {
        charRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        hizHorizontal = Input.GetAxis("Horizontal");
        hizVertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && ziplandiMi == false)
        {
            zipla = true;
        }
    }

    private void FixedUpdate()
    {
        if (hizHorizontal != 0 || hizVertical != 0)
        {
            charRb.velocity = new Vector3(hizHorizontal * hiz, charRb.velocity.y, hizVertical * hiz);
        }
        if (zipla)
        {
            ziplandiMi = true;
            zipla = false;
            charRb.AddForce(Vector3.up * ziplamaHizi);
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.transform.CompareTag("Zemin"))
        {
            ziplandiMi = false;
        }

    }
}
