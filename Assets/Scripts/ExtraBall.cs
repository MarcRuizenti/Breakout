using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExtraBall : MonoBehaviour
{
    public GameObject pelota;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pala"))
        {
            float horizontal = Random.Range(-1f, 1f);
            GameObject temp = Instantiate(pelota, collision.transform.position, collision.transform.rotation);
            temp.GetComponent<MoveBall>().direccion = new Vector3(horizontal, 1f, 0);
            Destroy(gameObject);
        }
    }
}
