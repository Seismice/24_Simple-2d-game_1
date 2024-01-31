using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRaspawn : MonoBehaviour
{
    public GameObject healthPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnHealth();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnHealth()
    {
        // ��������� ������ ������������ �� ���� ��������
        GameObject newHealth = Instantiate(healthPrefab, transform.position, Quaternion.identity);

        // ������� ������� ��䳿 �� �������� ������������
        newHealth.GetComponent<AddHealth>().OnDestroyedHealth.AddListener(() => Invoke("SpawnNextHealth", 10f));
    }

    void SpawnNextHealth()
    {
        // ���������� ��������� ������� ���� ��������� ������������
        Invoke("SpawnHealth", 0f);
    }
}
