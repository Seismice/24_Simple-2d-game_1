using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaspawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    private NumberOfEnemy _numberOfEnemy;

    void Start()
    {
        _numberOfEnemy = GameObject.FindWithTag("Player").GetComponentInParent<NumberOfEnemy>();
        // Розпочнемо респавн прямокутників
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (_numberOfEnemy.numberOfEnemy > 0)
        {
            // Створення нового прямокутника на місці респавну
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Додайте слухача події на знищення прямокутника
            newEnemy.GetComponent<Enemy>().OnDestroyed.AddListener(() => Invoke("SpawnNextEnemy", 5f));
            _numberOfEnemy.numberOfEnemy--;
            _numberOfEnemy.textOfEnemy.text = _numberOfEnemy.numberOfEnemy.ToString(); 
        }
    }

    void SpawnNextEnemy()
    {
        // Викликайте наступний респаун після видалення попереднього
        Invoke("SpawnEnemy", 0f);
    }
}
