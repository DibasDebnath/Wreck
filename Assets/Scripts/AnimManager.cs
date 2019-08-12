using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public Animator camAnimCon;



    public readonly string startlevel = "StartLevel";

    private void Start()
    {
        
    }
    public void playCameraStartLevel()
    {
        RefHolder.instance.animCameraActivate();
        camAnimCon.SetTrigger(startlevel);
        StartCoroutine(lateAnimCamDeactivate());

    }
    IEnumerator lateAnimCamDeactivate()
    {
        yield return new WaitForSeconds(4f);
        RefHolder.instance.mainCameraActivate();
    }

}
