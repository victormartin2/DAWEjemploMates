using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("destruirExplosion", 1f);
    }

    private void destruirExplosion()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
