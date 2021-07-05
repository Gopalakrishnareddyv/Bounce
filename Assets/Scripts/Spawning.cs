using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 4.0f)
        {
           
            GameObject spawn = Pool.instance.Get("EnemyMove");
            if (spawn != null)
            {
                spawn.transform.position = this.transform.position;
                //spawn.transform.Translate(Vector2.left * 15f * Time.deltaTime);
                spawn.SetActive(true);
                time = 0;

            }
            time = 0;
        }
    }
}
