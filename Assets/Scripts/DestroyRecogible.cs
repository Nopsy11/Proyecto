using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRecogible : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "Player"){
            
            Destroy(gameObject, 0.001f);
        }
    }
}
