using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Cockroach = Low, Pigeon = High
    public bool isHigh;
    public float speed = 2f;
    float dir;
 
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dir = Mathf.Sign(target.position.x - transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
 
        // Walk toward the player along X axis
        transform.position += new Vector3(-1 * speed * Time.deltaTime, 0f, 0f);
    }

    public void Die()
    {
        // Add 20 for pigeons, 10 for cockroaches
        GameManager.instance.AddScore(isHigh ? 20 : 10);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
 
        Animator anim = other.GetComponentInChildren<Animator>();
        if (anim != null) anim.SetTrigger("Hurt");
        
        GameManager.instance.KillPlayer();
        Destroy(gameObject);
    }
}
