using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject cockroachPrefab;
    public GameObject pigeonPrefab;
    public Transform player;

    // Seconds between each spawn
    public float spawnInterval = 2.5f;
    public float enemySpeed = 2f;
    // Must be bigger than half the screen width
    public float spawnDistance = 12f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        while (player != null)
        {
            yield return new WaitForSeconds(spawnInterval);
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        if (player == null) return;
 
        GameObject prefab = Random.value < 0.5f ? cockroachPrefab : pigeonPrefab;
 
        // X is beside the player, Y is whatever height the prefab was saved at
        Vector3 pos = new Vector3(player.position.x + spawnDistance, prefab.transform.position.y, 0f);
 
        Enemy enemy = Instantiate(prefab, pos, Quaternion.identity).GetComponent<Enemy>();
        enemy.speed = enemySpeed;
        enemy.target = player;
    }
}
