using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public float knockBackForce = 2000f;
    public float swordDamage = 1;
    public Collider2D swordCollider;
    public Vector3 faceRight = new Vector3(0, 0, 0);
    public Vector3 faceLeft = new Vector3(-2, 0, 0);

  
    void Start()
    {
        if(swordCollider==null){
            Debug.LogWarning("Sword Collider not set");
        }
    }

    void OnCollisionEnter2D(Collision2D col){

         IDamageable damageableObject = col.collider.GetComponent<IDamageable>();

        if(damageableObject != null){

            //Calcolo direzione tra pg e nemico
            Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
         
            Vector2 direction = (Vector2) (col.collider.gameObject.transform.position-parentPosition).normalized;
            Vector2 knockback = direction * knockBackForce;

            //invoco il metodo OnHit
            damageableObject.OnHit(swordDamage, knockback);
            
        }else{
            Debug.LogWarning("Collider does not implement IDamageable");
        }
    }

    

    //Questa funzione, in base alla posizione del pg, inverte la posizione dell'hitbox
    void IsFacingRight(bool isFacingRight){
        if(isFacingRight){
            gameObject.transform.localPosition = faceRight;
        }else{
            gameObject.transform.localPosition = faceLeft; 
        }
    }
}
