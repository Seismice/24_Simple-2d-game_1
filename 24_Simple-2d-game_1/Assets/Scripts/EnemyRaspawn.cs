using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaspawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Start()
    {
        // ���������� ������� ������������
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        // ��������� ������ ������������ �� ���� ��������
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // ������� ������� ��䳿 �� �������� ������������
        newEnemy.GetComponent<Enemy>().OnDestroyed.AddListener(() => Invoke("SpawnNextEnemy", 5f));
    }

    void SpawnNextEnemy()
    {
        // ���������� ��������� ������� ���� ��������� ������������
        Invoke("SpawnEnemy", 0f);
    }
}
