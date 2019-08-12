using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        
       

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Object"))
        {
            if (RefHolder.instance.gameplayScript.levelStarted)
            {
                RefHolder.instance.gameplayScript.ObjectCollided++;
            }


        }
    }
}
