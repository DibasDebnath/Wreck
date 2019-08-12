using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    
       [Header("Line Renderer Setup")]
    public LineRenderer lineRenderer;
    public Transform[] sideAnchors;
    public Transform midAnchor;
    public GameObject psudoBall;
    //public Rigidbody ballRigidBody;
    public GameObject ballprojectilePrefab;
    public GameObject mainBallPrefab;
    public bool lineRendererBool = false;


    public bool activated = false;




    void Start()
    {
        

    }

    public void slingshotStart()
    {
        activated = true;
        StartCoroutine(renderArc());
    }

    public void slingshotStop()
    {
        activated = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (lineRendererBool)
            {
                lineRenderer.SetPosition(0, sideAnchors[0].position);
                lineRenderer.SetPosition(1, psudoBall.transform.position);
                lineRenderer.SetPosition(2, sideAnchors[1].position);
            }
            else
            {
                lineRenderer.SetPosition(0, sideAnchors[0].position);
                lineRenderer.SetPosition(1, sideAnchors[0].position);
                lineRenderer.SetPosition(2, sideAnchors[1].position);
            }
        }
        

    }

    public void activate()
    {
        psudoBall.SetActive(true);
        lineRendererBool = true;
        
        setBallToTouchPosition();
    }
    public void reactivate()
    {
        lineRendererBool = true;
        setBallToTouchPosition();

    }

    public void deactivate()
    {
        psudoBall.SetActive(false);
        lineRendererBool = false;
        //Time.timeScale = 0.5f;
        shootBall();
        RefHolder.instance.gameplayScript.deactivateInputs();
    }




    #region Private Calls


    private void setBallToTouchPosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider)
            {
                psudoBall.transform.position = new Vector3(hit.point.x, hit.point.y - 0.2f, hit.point.z + 0.5f);
            }



        }
    }


    private Vector3 getShootDirection()
    {

        return (midAnchor.position - psudoBall.transform.position).normalized;
        
    }

    private void shootBall()
    {
        GameObject tmp = Instantiate(mainBallPrefab, this.transform);
        tmp.SetActive(true);
        tmp.transform.position = psudoBall.transform.position;
        RefHolder.instance.followCameraScript.target = tmp.transform;

        StartCoroutine(lateFollowCamActivator());
        applyForceToMainBallInDirecton(tmp);
    }

    IEnumerator lateFollowCamActivator()
    {
        yield return new WaitForSeconds(0.1f);
        
       
        RefHolder.instance.followCameraActivate();
    }

    private void applyForceToMainBallInDirecton(GameObject tmp)
    {
        tmp.GetComponent<Rigidbody>().AddForce(30 * getShootDirection(), ForceMode.Impulse);
    }
    private void applyForceToBallproInDirecton(GameObject tmp)
    {
        tmp.GetComponent<Rigidbody>().AddForce(30 * getShootDirection(), ForceMode.Impulse);
    }


    IEnumerator renderArc()
    {

        while (activated)
        {
            yield return new WaitForSeconds(0.15f);
            
            if (lineRendererBool)
            {
                //yield return new WaitForSeconds(0.1f);
                GameObject tmp = Instantiate(ballprojectilePrefab, this.transform);
                tmp.SetActive(true);
                tmp.transform.position = psudoBall.transform.position;
                applyForceToBallproInDirecton(tmp);
                
            }
           
        }
        
    }

    #endregion





}
