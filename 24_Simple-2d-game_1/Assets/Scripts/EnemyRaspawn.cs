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
        // ���������� ������� ������������
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (_numberOfEnemy.numberOfEnemy > 0)
        {
            // ��������� ������ ������������ �� ���� ��������
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // ������� ������� ��䳿 �� �������� ������������
            newEnemy.GetComponent<Enemy>().OnDestroyed.AddListener(() => Invoke("SpawnNextEnemy", 5f));
            _numberOfEnemy.numberOfEnemy--;
            _numberOfEnemy.textOfEnemy.text = _numberOfEnemy.numberOfEnemy.ToString(); 
        }
    }

    void SpawnNextEnemy()
    {
        // ���������� ��������� ������� ���� ��������� ������������
        Invoke("SpawnEnemy", 0f);
    }
}
