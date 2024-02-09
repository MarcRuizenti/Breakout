using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TMP_Text Puntuacion;
    public TMP_Text Vidas;
    public GameObject win;
    public GameObject gameOver;
    public float vidas;
    public float puntuacion;
    private BallManager ballManager;

    private void Start()
    {
        ballManager = FindObjectOfType<BallManager>();
    }
    void Update()
    {
        Vidas.text = vidas.ToString();
        Puntuacion.text = puntuacion.ToString();
        if (puntuacion >= 210)
        {
            win.SetActive(true);
            foreach (GameObject ball in ballManager.balls)
            { 
                Destroy(ball);
            }
            Time.timeScale = 0;
        }
        else if (vidas <= 0)
        { 
            gameOver.SetActive(true);
            foreach (GameObject ball in ballManager.balls)
            {
                Destroy(ball);
            }
            Time.timeScale = 0;
        }
    }
}
