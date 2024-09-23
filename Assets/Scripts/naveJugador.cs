using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float _vel;
    

    // Start is called before the first frame update
    void Start()
    {
        _vel = 6;
    }

    // Update is called once per frame
    void Update()
    {
        float dirIndicadaX = Input.GetAxisRaw("Horizontal");
        float dirIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + dirIndicadaX + " - Y: " + dirIndicadaY);
        Vector2 dirIndicada = new Vector2(dirIndicadaX, dirIndicadaY);

        Vector2 nuevaPos = transform.position; //Direccion actual de la nave
        nuevaPos = nuevaPos + dirIndicada * _vel * Time.deltaTime;
        // Debug.Log(Time.deltaTime);
        transform.position = nuevaPos;
    }
}
