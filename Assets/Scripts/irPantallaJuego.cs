using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class irPantallaJuego : MonoBehaviour
{
    public void irPantallaJugando()
    {
        SceneManager.LoadScene("PantallaJugando");
    }
}
