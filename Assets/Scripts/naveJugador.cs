using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float _vel;
    Vector2 minPantalla, maxPantalla;
    
    // Start is called before the first frame update
    void Start()
    {
        _vel = 6;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        float dirIndicadaX = Input.GetAxisRaw("Horizontal");
        float dirIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + dirIndicadaX + " - Y: " + dirIndicadaY);
        Vector2 dirIndicada = new Vector2(dirIndicadaX, dirIndicadaY).normalized; //Todo se mueva a la misma velocidad

        Vector2 nuevaPos = transform.position; //Direccion actual de la nave
        nuevaPos = nuevaPos + dirIndicada * _vel * Time.deltaTime;
        //Debug.Log(Time.deltaTime);

        nuevaPos.x = Mathf.Clamp(nuevaPos.x, minPantalla.x, maxPantalla.x);
        nuevaPos.y = Mathf.Clamp(nuevaPos.y, minPantalla.y, maxPantalla.y);

        transform.position = nuevaPos;
    }
}
