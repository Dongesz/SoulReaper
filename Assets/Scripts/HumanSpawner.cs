using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class HumanSpawner : MonoBehaviour
{
    public int spawnLimit = 20;
    public int humansAlive;
    public float spawnDistance = 10f;
    public Transform playerTransform;
    public GameObject HumanPrefab;


    public Vector2 spawnDirection = new Vector2();
    private void Start()
    {
        StartCoroutine(SpawnEnemies());

    }
    void Update()
    {
    }

    public IEnumerator SpawnEnemies()
    {
        while (spawnLimit > humansAlive)
        {
            do
            {
                spawnDirection.x = Random.Range(-1, 2);
                spawnDirection.y = Random.Range(-1, 2);
            } while (spawnDirection == Vector2.zero);

            Vector2 humanSpawnPoint = (Vector2)playerTransform.position + (spawnDirection * spawnDistance);
            GameObject human = Instantiate(HumanPrefab, humanSpawnPoint, Quaternion.identity);
            HumanController hc = human.GetComponent<HumanController>();
            hc.playerTransform = playerTransform;
            humansAlive++;
            yield return new WaitForSeconds(3);
        }
    }
}
