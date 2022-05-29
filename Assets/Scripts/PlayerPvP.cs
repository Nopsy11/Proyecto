using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
        if(Input.GetKey(KeyCode.LeftShift)){
            if (Input.GetKey(KeyCode.A)) {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2000f * Time.deltaTime, 0));
                gameObject.GetComponent<Animator>().SetBool("sprint", true);
                gameObject.GetComponent<SpriteRenderer>().flipX =  true;
            }

            //sprint derecha
            if (Input.GetKey(KeyCode.D)) {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2000f * Time.deltaTime, 0));
                gameObject.GetComponent<Animator>().SetBool("sprint", true);
                gameObject.GetComponent<SpriteRenderer>().flipX =  false;
            }
        }
        gameObject.GetComponent<Animator>().SetBool("sprint", false);

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
            gameObject.GetComponent<Animator>().SetBool("jumping", true);
        }
        else{
            gameObject.GetComponent<Animator>().SetBool("jumping", false);
        }

        //comprobar si se mueve
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)){
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }

        if (SceneManager.GetActiveScene().name == "Nivel1"){
            if(Input.GetKeyDown(KeyCode.Space)){
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000f));
                gameObject.GetComponent<Animator>().SetBool("jumping", true);
            }
            else{
                gameObject.GetComponent<Animator>().SetBool("jumping", false);
            }
        }

        //fin movimiento

        if(Input.GetKeyDown(KeyCode.J)) {
            // GameObject.Instantiate(ataque, posicionAtaque.transform.position, gameObject.transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "Suelo"){
            puedeSaltar = true;
        }

        if(collision.transform.tag == "Plataforma"){
            puedeSaltar = true;
        }

        // Modificar por ataque
        if(collision.transform.tag == "Slime"){
            gameObject.GetComponent<Animator>().SetBool("hurted", true);
            vida --;
            // relleno.fillAmount = vida / 3;
            if(vida == 0){
                SceneManager.LoadScene("MainTitle");
            }
        }
        else{
            gameObject.GetComponent<Animator>().SetBool("hurted", false);
        }
    }
}
