using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI Puntuacion;
    public TextMeshProUGUI Vidas;
    public float vidas;
    public float puntuacion;
    void Update()
    {
        Vidas.text = vidas.ToString();
        Puntuacion.text = puntuacion.ToString();
    }
}
