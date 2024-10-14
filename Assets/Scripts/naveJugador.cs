using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * 
 * Que hemos visto:
 * - Crear objectos en la escena.
 * - Crear EmptyObjects (para hacer generador de numeros).
 * - Crear Prefabs (crear objetos cuando el juego esta en ejecucion).
 *  - Para crearlos: arrastrar el objeto que ya hay creado y lo arrastramos en la carpeta Prefabs
 *  - Para crear un Prefab en la escena en ejecuci�n: metodo Instanciate(variablePrefab)
 *      - VariablePrefab: variable de tipo GameObject.
 *      
 * - Encontrar posicion objeto actual: (transform.position).
 * - Encontrar margenes pantalla: (Camera.main.ViewportToWorldPoint()).
 * - [Serialize Field]: para hacer que una variable privada de la clase se muestre en el editor de Unity.
 * - Utilizar una imagen/sprite como si fuese mas de una (conteniendo subimagenes).
 *  - Seleccinamos el sprite.
 *  - En la opcion Sprite Mode cambiamos de Single a Multiple, y le damos al bot�n Apply.
 *  - Utilizamos las opciones del bot�n Sprite Editor.
 *  
 * - Destruir objeto acutal: Destroy(GameObject).
 * - Llamar metodo al cabo de x segundos: Invoke("NombreMetodo", xf).
 * - Llamar metodo al cabo de x segundos y cada y segundos: InvokeRepeating("NombreMetodo", xf, yf).
 * - Como parar un metodo InvokeRepeating: CancelInvoke("NombreMetodo").
 * - Detectar objeto toca a otro:
 *  - A�adir a los objetos que queramos que se toquen, los componentes: BoxCollider2D y Rigidbody2D.
 *  - En el BoxCollider2D: activar checkbox IsTrigger.
 *  - En el Rigibody2D: GravityScale ponerlo a 0.
 * 
 */


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
            componenteTextoVidas.text = "Vidas: " + vidasNave.ToString();

            if (vidasNave <= 0)
            {
                GameObject explosion = Instantiate(prefabExplosion);
                explosion.transform.position = transform.position;

                SceneManager.LoadScene("PantallaResultados");  
                Destroy(gameObject);
            }
        }
    }
}
