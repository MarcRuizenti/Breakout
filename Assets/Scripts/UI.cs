using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.WSA;

public class UI : MonoBehaviour
{
    public TMP_Text Puntuacion;
    public TMP_Text Vidas;
    public GameObject win;
    public float vidas;
    public float puntuacion;
    void Update()
    {
        Vidas.text = vidas.ToString();
        Puntuacion.text = puntuacion.ToString();
        if (puntuacion >= 210)
        {
            win.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
