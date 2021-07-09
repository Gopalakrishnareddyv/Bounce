using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInactive : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyMove")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
