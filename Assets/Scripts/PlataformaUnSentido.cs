using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaUnSentido : MonoBehaviour {
    private void OnCollisionStay2D(Collision2D other){
        if(other.collider.CompareTag("Player")){
            if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
                Collider2D collisionPlayer = other.collider.GetComponent<Collider2D>();
                StartCoroutine(IgnorarColision(collisionPlayer));
            }
        }
    }

    IEnumerator IgnorarColision(Collider2D playerCollider){
        Physics2D.IgnoreCollision(playerCollider, GetComponent<Collider2D>(), true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(playerCollider, GetComponent<Collider2D>(), false);
    }
}
