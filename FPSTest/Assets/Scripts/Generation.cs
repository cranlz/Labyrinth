using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public int worldW;
    public int worldH;
    public int gridSize;
    public GameObject[] morphs;
    public GameObject[] morphEdges;
    public GameObject[] morphCorners;
    private int[,] worldGrid;

    // Start is called before the first frame update
    void Start()
    {
        worldGrid = new int[worldW, worldH];
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        for(int x = -gridSize; x < (worldW * gridSize) + gridSize; x += gridSize)
        {
            for (int y = -gridSize; y < (worldH * gridSize) + gridSize; y += gridSize)
            {
                if ((x < 0 || x > (worldW * gridSize) - gridSize) && (y < 0 || y > (worldH * gridSize) - gridSize))
                {
                    int morph = Random.Range(0, morphCorners.Length);
                    int rot = 0;
                    if (x < 0 && y < 0) { rot = 180; }
                    else if (x > 0 && y < 0) { rot = 90; }
                    else if (x < 0 && y > 0) { rot = -90; }
                    Instantiate(morphCorners[morph], new Vector3(x, 0, y), Quaternion.Euler(0, rot, 0));
                }
                else if(x < 0 || y < 0 || x > (worldW * gridSize) - gridSize || y > (worldH * gridSize) - gridSize)
                {
                    int morph = Random.Range(0, morphEdges.Length);
                    int rot = 0;
                    if (x < 0) { rot = 180; }
                    else if (y < 0) { rot = 90; }
                    else if (y > (worldH * gridSize) - gridSize) { rot = -90; }
                    Instantiate(morphEdges[morph], new Vector3(x, 0, y), Quaternion.Euler(0, rot, 0));
                } else
                {
                    int morph = Random.Range(0, morphs.Length);
                    int rot = Random.Range(0, 2) * 90;
                    Instantiate(morphs[morph], new Vector3(x, 0, y), Quaternion.Euler(0, rot, 0));
                }
                
            }
        }


    }
}
