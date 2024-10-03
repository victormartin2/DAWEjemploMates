using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorNum : MonoBehaviour
{
    [SerializeField] private GameObject prefabNum;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generarNumero", 1f, 2f);
    }

    private void generarNumero()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
