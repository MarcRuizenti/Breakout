using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public Vector3 direccion;
    public float speed;
    public GameObject multiBall;
    public GameObject extraBall;
    public GameObject escopeta;
    private float probalidadSpawPowerUp;
    private Ball ball;

    public enum Ball {MULTIBALL, EXTRABALL, ESCOPETA, NADA};
    private void Start()
    {
        Time.timeScale = 1f;
        
    }
    void Update()
    {
        if (Time.time == 0)
        {
            Spawn();
        }
        transform.position += direccion * Time.deltaTime * speed;
    }

    void Spawn()
    {
        float vertical = -1f;
        float horizontal = Random.Range(-1f, 1f);
        direccion = new Vector3(horizontal, vertical, 0f).normalized;
    }

    void SpawnPowerUP(Collider2D collision)
    {
        ball = (Ball)Random.Range(0, 3);


        switch (ball)
        {
            case Ball.MULTIBALL:
                GameObject temp = Instantiate(multiBall, collision.transform.position, collision.transform.rotation);
                Destroy(temp, 5);
                break;
            case Ball.EXTRABALL:
                GameObject temp1 = Instantiate(extraBall, collision.transform.position, collision.transform.rotation);
                Destroy(temp1, 5);
                break;
            case Ball.ESCOPETA:
                GameObject temp2 = Instantiate(escopeta, collision.transform.position, collision.transform.rotation);
                Destroy(temp2, 5);
                break;
            default:
                break;
        }
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
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Blokest"))
        {
            direccion.y *= -1;
            Destroy(collision.gameObject);

            probalidadSpawPowerUp = Random.Range(1, 10);
            if (probalidadSpawPowerUp <= 2)
            {
                SpawnPowerUP(collision);
            }

        }
        if (collision.gameObject.CompareTag("Pala"))
        {
            Vector3 newDirecction = transform.position - collision.transform.position;
            newDirecction.Normalize();
            direccion = newDirecction;
        }
    }
}
