using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool activated;
    public void activator()
    {
        activated = true;
    }
    public void deactivator()
    {
        activated = false;
    }

    private void OnMouseDown()
    {
        if (activated)
        {
            RefHolder.instance.sligshotScript.activate();
        }
       
        

    }
    private void OnMouseDrag()
    {
        if (activated)
        {
            RefHolder.instance.sligshotScript.reactivate();
        }
       
    }
    private void OnMouseUp()
    {
        if (activated)
        {
            StartCoroutine(wait());
        }
        
        
    }
    IEnumerator wait()
    {
       // yield return new WaitForSeconds(0.1f);
        yield return new WaitForEndOfFrame();
        RefHolder.instance.sligshotScript.deactivate();

        //RefHolder.instance.ballGameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
