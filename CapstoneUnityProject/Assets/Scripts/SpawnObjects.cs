using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Some code taken from https://answers.unity.com/questions/714835/best-way-to-spawn-prefabs-in-a-circle.html
public class SpawnObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public int numObjects = 10;
    public int numRows = 10;
    public GameObject prefab;
 
    void Start()
    {
        int currentNumObjects = numObjects;
        int numSpawned = numObjects;
        Vector3 center = transform.position;
        for (int j = 0; j < numRows; j++)
        {
            for (int i = 0; i < currentNumObjects; i++)
            {
                float radius = j * 1.15f + 4;
                Vector3 pos = RandomCircle(center, radius);
                Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
                Instantiate(prefab, pos, rot);
            }
            currentNumObjects = numObjects * (j + 1);
            numSpawned += currentNumObjects;
        }
        Debug.Log(numSpawned);
    }
    
    Vector3 RandomCircle( Vector3 center, float radius)
    {
        float angle = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.z = center.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        pos.y = center.y;
        return pos;
    }
}
