using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAtaque : MonoBehaviour {

    void Start() {
        Destroy(gameObject, 0.02f);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "Slime"){
            
        }
    }
}