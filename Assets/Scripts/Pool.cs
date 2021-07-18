using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItems
{
    public GameObject prefab;
    public int number;
}
public class Pool : MonoBehaviour
{
    public static Pool instance;
    public List<PoolItems> items;
    public List<GameObject> pooleditems;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pooleditems = new List<GameObject>();
        foreach(PoolItems item in items)
        {
            
            for (int i = 0; i < item.number; i++)
            {
                
                GameObject prefabobj= Instantiate(item.prefab);
                prefabobj.SetActive(false);
                pooleditems.Add(prefabobj);
            }
        }
    }
    public GameObject Get(string tagname)
    {
        for (int i = 0; i < pooleditems.Count; i++)
        {
            if (!pooleditems[i].activeInHierarchy && pooleditems[i].tag == tagname)
            {
           
                return pooleditems[i];
            }
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
