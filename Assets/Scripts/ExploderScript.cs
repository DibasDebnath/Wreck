using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderScript : MonoBehaviour
{


    float radius = 1.2f;
    float power = 100f;

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            if (Random.Range(0, 2) == 0)
            {
                RefHolder.instance.leftCameraActivate();

            }
            else
            {
                RefHolder.instance.rightCameraActivate();
            }
            explode();
        }
        
    }

    public void explode()
    {
        Vector3 explosionPos = this.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.CompareTag("Object"))
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 0.1f, ForceMode.Impulse);
                    //rb.AddForce(new Vector3(100f,100f,100f));


                }
            }


        }
        Destroy(this.gameObject);
    }
}
