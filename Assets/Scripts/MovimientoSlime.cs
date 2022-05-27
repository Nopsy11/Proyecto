using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSlime : MonoBehaviour {

   int contador;
   float velocidad;
   int vidaSlime;

   void Start() {
       contador = 0;
       vidaSlime = 2;
   }

    void Update()    {
        if (contador == 0){
           gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-250f * Time.deltaTime, 0));
       }
       else{
           gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocidad, 0));
       }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "Limite" && (contador%2)!=0){
            contador ++;
            velocidad = (-250f * Time.deltaTime);
            gameObject.GetComponent<SpriteRenderer>().flipX =  false;
        }
        else if(collision.transform.tag == "Limite" && (contador%2)==0){
            contador++;
            velocidad = (250f * Time.deltaTime);
            gameObject.GetComponent<SpriteRenderer>().flipX =  true;
        }

        if(collision.transform.tag == "Ataque"){
            vidaSlime--;
            Debug.Log(vidaSlime + " vida slime");
            if(vidaSlime <= 0){
                Destroy(gameObject, 0.02f);
            }
        }
    }
}
