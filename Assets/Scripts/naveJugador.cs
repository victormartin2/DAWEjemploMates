using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float _vel;
    private Vector2 minPantalla, maxPantalla;
    [SerializeField]private GameObject prefabProyectil;
    [SerializeField] private GameObject prefabExplosion;
    [SerializeField] private TMPro.TextMeshProUGUI componenteTextoVidas;
    private int vidasNave;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 6;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float mitadMedidaImgX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float mitadMedidaImgY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y / 2;

        minPantalla.x = minPantalla.x + mitadMedidaImgX;
        maxPantalla.x = maxPantalla.x - mitadMedidaImgX;
        minPantalla.y += mitadMedidaImgY;
        maxPantalla.y -= mitadMedidaImgY;

        vidasNave = 3;
    }

    // Update is called once per frame
    void Update()
    {
        moverNave();
        dispararProyectil();
    }
    private void moverNave()
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
    private void dispararProyectil()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject proyectil = Instantiate(prefabProyectil);
            proyectil.transform.position = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D objetoTocado)
    {
        if(objetoTocado.tag == "numero")
        {
            vidasNave--;
            if (vidasNave <= 0)
            {
                GameObject explosion = Instantiate(prefabExplosion);
                explosion.transform.position = transform.position;

                Destroy(gameObject);
            }
        }
    }
}
