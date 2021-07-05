using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    Animator anim;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        anim.SetTrigger("Fire");
        StartCoroutine("Flame");
    }
    IEnumerator Flame()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}
