using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 11f;
 
    public GameObject highHitbox;
    public GameObject lowHitbox;
    // delay before the hitbox turns on
    public float windup = 0.1f;     
    // how long the hitbox stays on 
    public float activeTime = 0.15f;
    // delay before the next action
    public float recovery = 0.15f;
 
    Rigidbody2D rb;
    Animator animator;
    bool grounded, attacking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
 
        highHitbox.SetActive(false);
        lowHitbox.SetActive(false);
    }

    // Assume we are in the air unless our collision logic tells us we are in the ground
    void FixedUpdate()
    {
        grounded = false;
    }

    // Somewhat hacky solution to make things simpler, checks that whatever we're touching is pointing upwards (and if so, that is the ground)
    void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f) {
                grounded = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) {
            return;
        }

        // Movement logic
        float x = 0f;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed)
        {
            x -= 1f;
        } 
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed)
        {
            x += 1f;
        } 
        rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);
        // Flip if need be
        if (x != 0f)
        {
            transform.localScale = new Vector3(Mathf.Sign(x), 1f, 1f); 
        }

        // Jumping logic
        if (kb.spaceKey.wasPressedThisFrame && grounded && !attacking)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
        }
        
        // Attacking logic
        if (grounded && !attacking)
        {
            if (kb.jKey.wasPressedThisFrame) StartCoroutine(Attack("HighAttack", highHitbox));
            else if (kb.kKey.wasPressedThisFrame) StartCoroutine(Attack("LowAttack", lowHitbox));
        }

        // Animator handling
        animator.SetFloat("Speed", Mathf.Abs(x));
        animator.SetBool("Grounded", grounded);
    }

    IEnumerator Attack(string trigger, GameObject hitbox)
    {
        attacking = true;
        animator.SetTrigger(trigger);
 
        yield return new WaitForSeconds(windup);
        hitbox.SetActive(true);
 
        yield return new WaitForSeconds(activeTime);
        hitbox.SetActive(false);
 
        yield return new WaitForSeconds(recovery);
        attacking = false;
    }
}
