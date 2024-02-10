using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBall : MonoBehaviour
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
            List<GameObject> nuevasBolas = new List<GameObject>();

            foreach (GameObject ball in ballManager.balls)
            {
                GameObject temp = Instantiate(pelota, ball.transform.position, ball.transform.rotation);
                float vertical = Random.Range(-1f, 1f);
                float horizontal = Random.Range(-1f, 1f);
                temp.GetComponent<MoveBall>().direccion = new Vector3(horizontal, vertical, 0).normalized;
                nuevasBolas.Add(temp);
                ui.vidas += 1;
            }

            ballManager.balls.AddRange(nuevasBolas);

            Destroy(gameObject);
        }
    }
}
