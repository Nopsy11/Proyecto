using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPuntuacion : MonoBehaviour {

    public static ControlPuntuacion instance;
    public Text puntuacionTexto;

    int puntuacion = 0;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()    {
        puntuacionTexto.text = puntuacion.ToString();
    }

    public void SumarPuntos() {
        puntuacion ++;
        puntuacionTexto.text = puntuacion.ToString();
    }

    public int DevolverPuntuacion(){
        return puntuacion;
    }
}
