using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntuacionActualGanador : MonoBehaviour {

    public Text puntuacionTotal;
    
    // Start is called before the first frame update
    void Start()    {
        puntuacionTotal.text = PlayerPrefs.GetInt("PuntuacionActual").ToString();
    }

    // Update is called once per frame
    void Update()    {
        
    }
}
