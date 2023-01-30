using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailManager : MonoBehaviour
{

    public GameObject[] tilePreFabs;
    private Transform playerTransform;
    private float spawnZ = -10.0f;
    private float tileLength = 10.0f;
    private int amnTilesOnscreen = 10;
    private float safeZone = 30.0f;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;


        for (int i = 0; i < amnTilesOnscreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();


        }



    }


    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnscreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }


    }

    private void SpawnTile(int prefabindex = -1)
    {
        GameObject go;
        if (prefabindex ==  -1)

            go = Instantiate(tilePreFabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePreFabs[prefabindex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);

    }

    private int RandomPrefabIndex() 
    {
        if (tilePreFabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex) 
        {
            randomIndex = Random.Range(0, tilePreFabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    
    
    }

}
