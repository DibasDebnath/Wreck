using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballproScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        
        if (!RefHolder.instance.sligshotScript.lineRendererBool)
        {
            this.gameObject.GetComponent<TrailRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Ball"))
        {
            Destroy(this.gameObject);
        }
    }

}
