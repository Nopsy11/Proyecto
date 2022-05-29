using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarListadoPuntuaciones : MonoBehaviour {

    public Text Puntuaciones_listado;

    void Start()     {
        DevolverListadoPuntuaciones();
    }

    public void DevolverListadoPuntuaciones(){
        AlmacenarPuntuaciones temp = Player.instance.cargarDatos();
        foreach (int i in temp.puntuaciones){
            Puntuaciones_listado.text += i.ToString();
        }
    }
}