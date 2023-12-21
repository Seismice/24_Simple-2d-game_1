using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaspawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Start()
    {
        // Розпочнемо респавн прямокутників
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        // Створення нового прямокутника на місці респавну
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // Додайте слухача події на знищення прямокутника
        newEnemy.GetComponent<Enemy>().OnDestroyed.AddListener(() => Invoke("SpawnNextEnemy", 5f));
    }

    void SpawnNextEnemy()
    {
        // Викликайте наступний респаун після видалення попереднього
        Invoke("SpawnEnemy", 0f);
    }
}
