using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level;


    public GameObject levelParent;
    public List<GameObject> levels;
    public List<int> levelColliderCap;





    private void Start()
    {
          
        //for (int i = 0; i < levelParent.transform.childCount; i++)
        //{
        //    levels.Add(levelParent.transform.GetChild(i).gameObject);
        //}
    }


    public void initializeLeve()
    {
        //Debug.Log(levels.Count);
        levels[level].SetActive(true);
    }

    public void updateLevel()
    {
        levels[level++].SetActive(false);
        levels[level].SetActive(true);
    }

}
