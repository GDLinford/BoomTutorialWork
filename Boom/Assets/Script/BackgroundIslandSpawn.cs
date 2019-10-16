using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundIslandSpawn : MonoBehaviour
{

    [SerializeField]
    private int width = 1000;
    [SerializeField]
    private int height = 1000;
    [SerializeField]
    private int Depth = 1000;

    [SerializeField]
    private GameObject islandPrefab;

    [SerializeField]
    private int islandsAmount = 100;


    // Start is called before the first frame update
    void Start()
    {
        //Loop through a lot of island amount
        for (int i = 0; i < islandsAmount; i++)
        {
            //Create a instance of a prefab
            GameObject instance = Instantiate(islandPrefab);
            instance.transform.parent = transform; //Parent this to clean up our hierachy
            instance.transform.position = RandomPosition();
            //set a random scale
            //vector3.one, returns a new Vector3(1, 1, 1,);
            //Vector.one * 5 = new Vector3(5, 5, 5,);
            instance.transform.localScale = Vector3.one * Random.Range(5, 20);

            //Set a random rotation Y from 0 - 360
            instance.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
    }

    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-width, width),
            Random.Range(-height, height),
            Random.Range(-Depth, Depth)
            );
    }
}
