using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarListadoPuntuaciones : MonoBehaviour {

    public Text Puntuaciones_listado;

    public AlmacenarPuntuaciones cargarDatos() {
        string puntuaciones = PlayerPrefs.GetString("PuntuacionesTotales");
        AlmacenarPuntuaciones aux = JsonUtility.FromJson<AlmacenarPuntuaciones>(puntuaciones);
        return aux;
    }

    void Start()     {
        AlmacenarPuntuaciones temp = cargarDatos();
        foreach (int i in temp.puntuaciones){
            Puntuaciones_listado.text += "Partida anterior: " + i.ToString() + "\n";
        }
    }
}