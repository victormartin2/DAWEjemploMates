using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puntosObtenidos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Puntos obtenidos: " + datosGlobales.puntos.ToString();
        Invoke("irPantallaInicio", 5f);
        
    }

    private void irPantallaInicio()
    {
        SceneManager.LoadScene("PantallaInicio");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
