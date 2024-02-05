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
        ballManager = GetComponent<BallManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pala"))
        {
            List<GameObject> nuevasBolas = new List<GameObject>();
            if (ballManager != null)
            {
                for (int i = 0; i < ballManager.balls.Count; i++)
                {
                    GameObject temp = Instantiate(pelota, ballManager.balls[i].transform.position, ballManager.balls[i].transform.rotation);
                    float vertical = Random.Range(-1f, 1f);
                    float horizontal = Random.Range(-1f, 1f);
                    temp.GetComponent<MoveBall>().direccion = new Vector3(horizontal, vertical, 0);
                    nuevasBolas.Add(temp);
                }
            }

            ballManager.balls.AddRange(nuevasBolas);

            Destroy(gameObject);
        }
    }
}
