using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerPvP : MonoBehaviour {

    PhotonView view;
    bool puedeSaltar;
    int vida;

    // Start is called before the first frame update
    void Start()    {
        vida = 3;
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()    {
        if (view.IsMine){
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2000f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX =  true;
        }

        //sprint derecha
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2000f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX =  false;
        }

        //izquierda
        if (Input.GetKey(KeyCode.A)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX =  true;
        }
        
        //derecha
        if (Input.GetKey(KeyCode.D)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX =  false;
        }

        //saltar
        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar) {
            puedeSaltar = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000f));
        }

        //comprobar si se mueve
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)){
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }

        //fin movimiento
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "Suelo"){
            puedeSaltar = true;
        }

        if(collision.transform.tag == "Plataforma"){
            puedeSaltar = true;
        }

        if(collision.transform.tag == "Slime"){
            vida --;
            Debug.Log(vida);
            if(vida == 0){
                Debug.Log("Has perdido!");
            }
        }
    }
}