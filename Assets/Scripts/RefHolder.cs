using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefHolder : MonoBehaviour
{
    public static RefHolder instance;

    [Header("Scripts")]
    public GamePlay gameplayScript;
    public LevelManager levelManagerScript;
    public Ball ballScript;
    public InputManager inputManagerScript;
    public SlingShot sligshotScript;
    public PrePrediction prePredictionScript;
    public FollowCamera followCameraScript;
    public TimeManager timeManager;
    public AnimManager animManagerScript;
    
    [Header("Objects")]
    public GameObject ballGameObject;
    public GameObject mainCameraObject;
    public GameObject followCameraObject;
    public GameObject leftCameraObject;
    public GameObject rightCameraObject;
    public GameObject animCameraObject;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
        }

    private void Start()
    {
        
        Application.targetFrameRate = 60;
    }

    public void mainCameraActivate()
    {
        deactivateAllCamera();
        mainCameraObject.SetActive(true);
    }
    public void followCameraActivate()
    {
        deactivateAllCamera();
        followCameraObject.SetActive(true);
        followCameraScript.following = true;
    }
    public void leftCameraActivate()
    {
        deactivateAllCamera();
        leftCameraObject.SetActive(true);
    }
    public void rightCameraActivate()
    {
        deactivateAllCamera();
        rightCameraObject.SetActive(true);
    }
    public void animCameraActivate()
    {
        deactivateAllCamera();
        animCameraObject.SetActive(true);
    }

    public void deactivateAllCamera()
    {
        mainCameraObject.SetActive(false);
        followCameraObject.SetActive(false);
        leftCameraObject.SetActive(false);
        rightCameraObject.SetActive(false);
        animCameraObject.SetActive(false);
        
    }
}
