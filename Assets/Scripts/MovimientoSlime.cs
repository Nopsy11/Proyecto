using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSlime : MonoBehaviour {

   int contador; 
   void Start() {
       contador = 0;
   }

    void Update()    {
        if (contador == 0){
           gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-450f * Time.deltaTime, 0));
       }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "Limite" && (contador%2)!=0){
            contador ++;
            Debug.Log(contador + "contador");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f * Time.deltaTime, 0));
            gameObject.GetComponent<SpriteRenderer>().flipX =  false;
        }
        else if(collision.transform.tag == "Limite" && (contador%2)==0){
            contador++;
            Debug.Log(contador + "el cuenteo");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f * Time.deltaTime, 0));
            gameObject.GetComponent<SpriteRenderer>().flipX =  true;
        }
    }
}
