using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    private Vector3 direccion;
    public float speed;
    public GameObject multiBall;
    public GameObject extraBall;
    public GameObject escopeta;


    private void Start()
    {
        Time.timeScale = 1f;
        Spawn();
    }
    void Update()
    {
        transform.position += direccion * Time.deltaTime * speed;
    }

    void Spawn()
    {
        transform.position = Vector3.zero;
        float horizontal = Random.Range(-1f, 1f);
        float vertical = -1f;
        direccion = new Vector3(horizontal, vertical, 0f).normalized;
    }

    void SpawnPowerUP()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag("Horizontal"))
        {
            direccion.y *= -1;
        }
        if (collision.gameObject.CompareTag("Vertical"))
        {
            direccion.x *= -1;
        }
        if (collision.gameObject.CompareTag("Suelo"))
        {
            Spawn();
        }
        if (collision.gameObject.CompareTag("Blokest"))
        {
            direccion.y *= -1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Pala"))
        {
            Vector3 newDirecction = transform.position - collision.transform.position;
            newDirecction.Normalize();
            direccion = newDirecction;
        }
    }
}
