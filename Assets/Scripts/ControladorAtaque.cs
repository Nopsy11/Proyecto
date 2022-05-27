using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAtaque : MonoBehaviour {

    // Update is called once per frame
    void Update()    {
        if(Input.GetKey(KeyCode.J)){
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}