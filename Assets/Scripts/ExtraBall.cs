using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExtraBall : MonoBehaviour
{
    private UI ui;
    private BallManager ballManager;
    public GameObject pelota;
    private void Start()
    {
        ui = FindObjectOfType<UI>();
        ballManager = FindObjectOfType<BallManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pala"))
        {
            float horizontal = Random.Range(-1f, 1f);
            GameObject temp = Instantiate(pelota, new Vector3(0, -0.9f, 0), collision.transform.rotation);
            temp.GetComponent<MoveBall>().direccion = new Vector3(horizontal, -1f, 0);
            ballManager.balls.Add(temp);
            Destroy(gameObject);
            ui.vidas += 1;
        }
    }
}
