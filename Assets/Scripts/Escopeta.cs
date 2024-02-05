using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escopeta : MonoBehaviour
{
    public GameObject pelota;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pala"))
        {
            GameObject tempVertical = Instantiate(pelota, collision.transform.position, collision.transform.rotation);
            tempVertical.GetComponent<MoveBall>().direccion = new Vector3(0, 1f, 0);

            GameObject tempDerecha = Instantiate(pelota, collision.transform.position, collision.transform.rotation);
            tempDerecha.GetComponent<MoveBall>().direccion = new Vector3(-1f, 1f, 0);


            GameObject tempIzquierda = Instantiate(pelota, collision.transform.position, collision.transform.rotation);
            tempIzquierda.GetComponent<MoveBall>().direccion = new Vector3(1f, 1f, 0);

            Destroy(gameObject);
        }
    }
}
