using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public Vector3 lastPos;
    public float offset = 0.7f;

    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 0, 1f);
    }

    public void CreateNewRoadPart()
    {
        Vector3 spawnPos = Vector3.zero;

        float change = Random.Range(0, 100);

        if (change < 50)
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        else
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);

        GameObject g = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));
        lastPos = g.transform.position;

        if(change < 10 || change > 90)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
