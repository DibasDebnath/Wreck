using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrePrediction : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public float velocity;
    public float angle;

    public int resolution;

    float g;
    float radianAngle;

    private void Start()
    {
        g = Physics.gravity.y;
        renderArc();
    }


    public void renderArc()
    {
        lineRenderer.positionCount = resolution + 1;
        lineRenderer.SetPositions(calculateArcArray());
    }

    Vector3[] calculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];
        radianAngle = Mathf.Deg2Rad * angle;

        float maxDistance = (velocity * velocity * Mathf.Sin(radianAngle)) / g;

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = calculatePoint(t, maxDistance);
        }
        return arcArray;
    }


    Vector3 calculatePoint(float t_t , float t_maxDistance)
    {
        float x = t_t * t_maxDistance;

        float y = x * Mathf.Tan(radianAngle) - ((g * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));

        return new Vector3(0,x, y);
    }
}
