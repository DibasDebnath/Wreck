using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("Destroyed - " + other.gameObject.name);
        if (other.CompareTag("Object"))
        {
            if (RefHolder.instance.gameplayScript.levelStarted)
            {
                RefHolder.instance.gameplayScript.ObjectCollided++;
            }
            

        }

        Destroy(other.gameObject);

    }
}
