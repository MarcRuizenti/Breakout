using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBall : MonoBehaviour
{
    public GameObject pelota;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pala"))
        {
            Destroy(gameObject);
        }
    }
}
