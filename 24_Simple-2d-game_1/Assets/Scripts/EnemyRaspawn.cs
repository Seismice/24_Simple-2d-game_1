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
        // ���������� ������� ������������
        SpawnEnemy();
    }

    void Update()
    {
        // ��������� ������� ������ ����� �������
        timer += Time.deltaTime;
        if (timer >= increaseRate)
        {
            SpawnEnemy();
            timer = 0f; // �������� �������
        }
    }

    void SpawnEnemy()
    {
        if (_numberOfEnemy.numberOfEnemy > 0)
        {
            // ��������� ���� ����� ��������
            int randomSpawnIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[randomSpawnIndex];

            // ��������� ������ ������������ �� ���� ��������
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            // ������� ������� ��䳿 �� �������� ������������
            //newEnemy.GetComponent<Enemy>().OnDestroyed.AddListener(() => Invoke("SpawnNextEnemy", 5f));
            _numberOfEnemy.numberOfEnemy--;
            _numberOfEnemy.numberOfDestroyEnemy++;
            _numberOfEnemy.textOfEnemy.text = _numberOfEnemy.numberOfDestroyEnemy.ToString(); 
        }
    }

    //void SpawnNextEnemy()
    //{
    //    // ���������� ��������� ������� ���� ��������� ������������
    //    Invoke("SpawnEnemy", 0f);
    //}
}
