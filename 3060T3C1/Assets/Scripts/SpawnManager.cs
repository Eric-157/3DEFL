using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> zones;
    public GameObject enemyPrefab;
    private List<GameObject> activeEnemies = new List<GameObject>();
    public Vector3 startPos;
    public GameObject player;

    void Start()
    {
        startPos = transform.position;
        SpawnEnemy();
    }

    void Update()
    {
        foreach (GameObject zone in zones)
        {
            if (player.GetComponent<Movement>().currentRoom == zone.name)
            {
                return;
            }
        }

        activeEnemies.RemoveAll(enemy => enemy == null);

        foreach (GameObject enemy in activeEnemies)
        {
            if (enemy.GetComponent<Enemy>().currentRoom == zones[0].name)
            {
                return;
            }
        }

        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        activeEnemies.Add(newEnemy);
    }
}