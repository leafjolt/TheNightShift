using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public bool isHigh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();
 
        if (enemy != null && enemy.isHigh == isHigh) enemy.Die();
    }
}
