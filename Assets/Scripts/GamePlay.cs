using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public int ObjectCollided;
    public bool gameStarted;


    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        gameStarted = true;
        RefHolder.instance.levelManagerScript.initializeLeve();
        RefHolder.instance.sligshotScript.activator();
        RefHolder.instance.inputManagerScript.activator();
        RefHolder.instance.followCameraScript.activated = true;
    }


    public void endLevel()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
