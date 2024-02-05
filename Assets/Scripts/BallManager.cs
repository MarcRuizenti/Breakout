using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public List<GameObject> balls = new List<GameObject>();
    private UI ui;
    public GameObject ball;
    void Start()
    {
        ui = FindObjectOfType<UI>();
    }
    void Update()
    {
        if (balls.Count == 0 && ui.vidas > 0)
        {
            GameObject temp = Instantiate(ball, new Vector3(0, -0.9f, 0), Quaternion.identity);
            temp.GetComponent<MoveBall>().Spawn();
            balls.Add(temp);
        }
    }
}
