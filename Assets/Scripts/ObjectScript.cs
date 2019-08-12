using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    //private void OnCollisionEnter(Collision collision)
    //{
    //    this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (RefHolder.instance.gameplayScript.gameStarted)
        {
            if (collision.gameObject.CompareTag("Plain")|| collision.gameObject.CompareTag("Ball")|| collision.gameObject.CompareTag("Destroyer"))
            {
                RefHolder.instance.gameplayScript.ObjectCollided++;
            }
        }
    }
}
