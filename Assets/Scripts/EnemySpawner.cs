using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform[] spawnPoints; // corners

    public int maxEnemies; // max amount of enemies at the same time
    public int spawnAmount; // amount it spawns

    public float spawnDelay = 5f;

    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //delay between spawns until 5

        if (timer >= spawnDelay)
        {
            TrySpawn();
            timer = 0f;

        }

        void TrySpawn()
        {
            int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (currentEnemies >= maxEnemies) //check on amount of current enemies
                return;

            for (int i = 0; i < spawnAmount; i++) //to spawn the enemies if there's less than the max
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
                {
                    SpawnEnemy();

                }
            }
        }

        void SpawnEnemy()
        {
            int randomIndex = Random.Range(0, spawnPoints.Length); //random corner for prefab(s) to spawn from
            Transform spawnPoint = spawnPoints[randomIndex];

            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity); //so prefab(s) spawns
        }

    }
}
