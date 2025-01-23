using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> zones;
    public GameObject enemy;
    public bool enemyDestroyed;
    public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        enemyDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        // I need to make the spawn manager spawn only when the enemy it spawned is destroyed, and the play is not in it's room or an adjacent room.
        // make a counting for loop, make the base room 0 and make an if check for 0, if an enemy is in the trigger, don't spawn, if player is in the trigger, also don't spawn
        // if the count is more than 0, check if player is in the trigger, if so then don't spawn
        // if neither is met, then spawn an enemy.
    }
}
