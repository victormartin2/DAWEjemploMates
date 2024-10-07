using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numero : MonoBehaviour
{
    private float vel;
    private Vector2 minPantalla;
    [SerializeField] private Sprite[] arraySpritesNum = new Sprite[10];
    private int valorNum;

    // Start is called before the first frame update
    void Start()
    {
        vel = 3f;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        System.Random numAleatorio = new System.Random();
        valorNum = numAleatorio.Next(0, 10);
        GetComponent<SpriteRenderer>().sprite = arraySpritesNum[valorNum];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posActual = transform.position;
        posActual = posActual + new Vector2(0, -1) * vel * Time.deltaTime;
        transform.position = posActual;

        if (transform.position.y < minPantalla.y)
        {
            Destroy(gameObject);
        }
    }
}
