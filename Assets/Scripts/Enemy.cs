using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Cockroach = Low, Pigeon = High
    public bool isHigh;
    public float speed = 2f;
 
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
 
        // Walk toward the player along X axis
        float dir = Mathf.Sign(target.position.x - transform.position.x);
        transform.position += new Vector3(dir * speed * Time.deltaTime, 0f, 0f);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
 
        Animator anim = other.GetComponentInChildren<Animator>();
        if (anim != null) anim.SetTrigger("Hurt");
 
        Destroy(gameObject);
    }
}
