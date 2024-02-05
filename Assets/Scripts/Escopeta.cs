using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escopeta : MonoBehaviour
{
    public GameObject pelota;
    private UI ui;
    private BallManager ballManager;
    private void Start()
    {
        ui = FindObjectOfType<UI>();
        ballManager = FindObjectOfType<BallManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pala"))
        {

            GameObject tempVertical = Instantiate(pelota, new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0), collision.transform.rotation);
            tempVertical.GetComponent<MoveBall>().direccion = new Vector3(0, 1f, 0);

            GameObject tempDerecha = Instantiate(pelota, new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0), collision.transform.rotation);
            tempDerecha.GetComponent<MoveBall>().direccion = new Vector3(-1f, 1f, 0);


            GameObject tempIzquierda = Instantiate(pelota, new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0), collision.transform.rotation);
            tempIzquierda.GetComponent<MoveBall>().direccion = new Vector3(1f, 1f, 0);

            ballManager.balls.Add(tempVertical);
            ballManager.balls.Add(tempIzquierda);
            ballManager.balls.Add(tempDerecha);

            Destroy(gameObject);

            ui.vidas += 3;
        }   
    }
}
