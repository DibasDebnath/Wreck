using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public int ObjectCollided;
    public bool levelStarted;


    private void Start()
    {
        
        StartCoroutine(lateTest());
    }

    IEnumerator lateTest()
    {
        startLevel();
        yield return new WaitForSeconds(0.3f);
        RefHolder.instance.animManagerScript.playCameraStartLevel();
        yield return new WaitForSeconds(4f);
        activateInputs();
        RefHolder.instance.followCameraScript.activated = true;
        levelStarted = true;
    }
    public void startLevel()
    {
        
        RefHolder.instance.levelManagerScript.initializeLeve();
        
        
    }


    public void activateInputs()
    {
        RefHolder.instance.sligshotScript.slingshotStart();
        RefHolder.instance.inputManagerScript.activator();
        
    }

    public void deactivateInputs()
    {
        RefHolder.instance.sligshotScript.slingshotStop();
        RefHolder.instance.inputManagerScript.deactivator();
        
    }


    public void endLevel()
    {

    }

    public void reEnterLevel()
    {

    }

    
}
