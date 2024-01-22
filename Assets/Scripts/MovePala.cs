using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePala : MonoBehaviour
{
    public float speed;
    public string input;
    void Update()
    {

        float vertical = Input.GetAxis(input);

        transform.position += new Vector3(vertical, 0, 0) * Time.deltaTime * speed;
    }
}
