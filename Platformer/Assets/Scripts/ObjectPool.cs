using System.Collections.Generic;
using UnityEngine;


public class ObjectPool
{
    private GameObject prefab;
    private List<GameObject> availableObjects;

    public ObjectPool(GameObject prefab, int initialSize)
    {
        this.prefab = prefab;
        availableObjects = new List<GameObject>();


        //Create the initial pool
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.SetActive(false);
            availableObjects.Add(obj);
        }
    }

    public GameObject Get()
    {
        //find available objects
        foreach (GameObject obj in availableObjects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        //no available object -> create a new one
        GameObject newObj = GameObject.Instantiate(prefab);
        availableObjects.Add(newObj);
        return newObj;
    }


    public void Return(GameObject obj)
    {
        obj.SetActive(false);
    }
}