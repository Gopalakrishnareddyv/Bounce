using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    
    void Update()
    {
        transform.Translate(Vector2.left * 5.0f * Time.deltaTime);
        StartCoroutine("Disable");
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(15);
        this.gameObject.SetActive(false);
    }
}   
