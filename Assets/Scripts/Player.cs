using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    bool puedeSaltar;
    float vida;
    int puntos;

    public Image relleno;
    
    // Start is called before the first frame update
    void Start()    {
        vida = 3;
        puntos = 0;
    }

    // Update is called once per frame
    void Update()    {

        //inicio movimiento
        // sprint izquierda
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

        if (SceneManager.GetActiveScene().name == "Nivel1"){
            if(Input.GetKeyDown(KeyCode.Space)){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000f));
            }
        }

        //fin movimiento

        // if(Input.GetKeyDown(KeyCode.J)) {
        //     Atacar();
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "Suelo"){
            puedeSaltar = true;
        }

        if(collision.transform.tag == "Plataforma"){
            puedeSaltar = true;
        }

        if(collision.transform.tag == "Moneda"){
            puntos++;
            Debug.Log(puntos + " puntos");
        }

        if(collision.transform.tag == "Corazon"){
            if (vida == 3){
                puntos++;
                Debug.Log(puntos + " puntos");
            }
            else{
                vida++;
                Debug.Log(vida + " vida");
                relleno.fillAmount = vida / 3;
            }
        }

        if(collision.transform.tag == "Slime"){
            vida --;
            relleno.fillAmount = vida / 3;
            Debug.Log(vida + " vida");
            if(vida == 0){
                Debug.Log("Has perdido!");
                // PlayerPrefs.SetFloat("volumenAudio", sliderValue);
                SceneManager.LoadScene("Reintentar");
                // gameObject.Destroy;
            }
        }

        if(collision.transform.tag == "BotonParaNivel1"){
            SceneManager.LoadScene("Nivel1");
        }
    }

}
