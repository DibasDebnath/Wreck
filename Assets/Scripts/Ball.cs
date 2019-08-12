using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float radius;
    public float power;

    
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            if (Random.Range(0, 2) == 0)
            {
                RefHolder.instance.leftCameraActivate();

            }
            else
            {
                RefHolder.instance.rightCameraActivate();
            }
            RefHolder.instance.timeManager.slowToFast();
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

                        //Debug.Log(i++);
                    }
                }
                else if (hit.gameObject.CompareTag("Exploder"))
                {
                    hit.gameObject.GetComponent<ExploderScript>().explode();
                }


            }
            Destroy(this.gameObject);
        }
        
    }
    
    

    private void OnDestroy()
    {
        RefHolder.instance.followCameraScript.following = false;
    }

}
