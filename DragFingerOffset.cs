using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerOffset : MonoBehaviour
{
    bool isMoving = false;

    bool IsMoving{
        set{
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }

    public float Speed = 100f;
    private float attackInterval = 1.3f;  // Intervallo tra gli attacchi in secondi

    public float idleFriction = 0f;
    public GameObject swordHitbox;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;          //servirà per cambiare la posizione del pg
    
    Collider2D swordCollider;

    private Vector2 touchStartPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();      
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        swordCollider = swordHitbox.GetComponent<Collider2D>();

        Debug.Log("Intervallo attacco: "+attackInterval);

        InvokeRepeating("PerformAttack", 0f, attackInterval);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    IsMoving = true;
                    break;

                case TouchPhase.Moved:
                    Vector2 touchDelta = touch.position - touchStartPos;
                    Vector2 moveDirection = new Vector2(touchDelta.x, touchDelta.y).normalized;
                    rb.velocity = moveDirection * Speed * Time.deltaTime;

                    if (moveDirection.x > 0){
                        spriteRenderer.flipX = false;
                        gameObject.BroadcastMessage("IsFacingRight", true);
                    }else if (moveDirection.x < 0){
                        spriteRenderer.flipX = true;
                        gameObject.BroadcastMessage("IsFacingRight", false);
                    }
                break;


                case TouchPhase.Ended:
                    rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
                    IsMoving = false;
                    break;
            }
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            IsMoving = false;
        }
    }

    void PerformAttack()
    {
        Debug.Log("intervallo" + attackInterval);
        // Codice per eseguire l'attacco automatico
        animator.SetTrigger("swordAttack");
    }

    public void ModifyAttackInterval()
    {
        attackInterval -= 0.7f;
        CancelInvoke("PerformAttack");
        InvokeRepeating("PerformAttack", 0f, attackInterval);
    }

    public void ReturnToNormalAttack()
    {
        attackInterval += 0.7f;
        CancelInvoke("PerformAttack");
        InvokeRepeating("PerformAttack", 0f, attackInterval);
    }
}
