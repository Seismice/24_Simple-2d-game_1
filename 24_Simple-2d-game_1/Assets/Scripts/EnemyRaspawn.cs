using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaspawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    private NumberOfEnemy _numberOfEnemy;
    private float timer;
    private float increaseRate = 5f;
    public List<Transform> spawnPoints;

    void Start()
    {
        _numberOfEnemy = GameObject.FindWithTag("Player").GetComponentInParent<NumberOfEnemy>();
        // Розпочнемо респавн прямокутників
        SpawnEnemy();
    }

    void Update()
    {
        // Збільшення кількості ворогів кожну секунду
        timer += Time.deltaTime;
        if (timer >= increaseRate)
        {
            SpawnEnemy();
            timer = 0f; // Скидання таймера
        }
    }

    void SpawnEnemy()
    {
        if (_numberOfEnemy.numberOfEnemy > 0)
        {
            // Рандомний вибір точки респауну
            int randomSpawnIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[randomSpawnIndex];

            // Створення нового прямокутника на місці респавну
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            // Додайте слухача події на знищення прямокутника
            //newEnemy.GetComponent<Enemy>().OnDestroyed.AddListener(() => Invoke("SpawnNextEnemy", 5f));
            _numberOfEnemy.numberOfEnemy--;
            _numberOfEnemy.numberOfDestroyEnemy++;
            _numberOfEnemy.textOfEnemy.text = _numberOfEnemy.numberOfDestroyEnemy.ToString(); 
        }
    }

    //void SpawnNextEnemy()
    //{
    //    // Викликайте наступний респаун після видалення попереднього
    //    Invoke("SpawnEnemy", 0f);
    //}
}
