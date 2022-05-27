using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    bool puedeSaltar;
    int vida;
    int puntos;
    // [SerializedField] private float vida;
    // [SerializedField] private float maximoVida;
    // [SerializedField] private BarraDeVida barraDeVida;
    
    // Start is called before the first frame update
    void Start()    {
        vida = 3;
        puntos = 0;
        // vida = maximoVida;
        // barraDeVida.InicializarBarraDeVida(vida);
    }

    // public TomarDaño(float daño) {
    //     vida -= daño;
    //     barraDeVida.CambiarVidaActual(vida);
    //     if (vida <= 0) {
    //         Destroy(gameObject);
    //     }
    // }

    // public void Curar(float curacion) {
    //     if ((vida + curacion) > maximoVida){
    //         vida = maximoVida;
    //     }
    //     else{
    //         vida += curacion;
    //     }
    // }


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
            Debug.Log(puntos);
        }

        if(collision.transform.tag == "Corazon"){
            if (vida == 3){
                puntos++;
                Debug.Log(puntos);
            }
            else{
                vida++;
                Debug.Log(vida);
            }
        }

        if(collision.transform.tag == "Slime"){
            vida --;
            Debug.Log(vida);
            if(vida == 0){
                Debug.Log("Has perdido!");
                SceneManager.LoadScene("Reintentar");
                // gameObject.Destroy;
            }
        }
    }

}
