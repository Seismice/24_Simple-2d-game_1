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
        // Створення нового прямокутника на місці респавну
        GameObject newHealth = Instantiate(healthPrefab, transform.position, Quaternion.identity);

        // Додайте слухача події на знищення прямокутника
        newHealth.GetComponent<AddHealth>().OnDestroyedHealth.AddListener(() => Invoke("SpawnNextHealth", 10f));
    }

    void SpawnNextHealth()
    {
        // Викликайте наступний респаун після видалення попереднього
        Invoke("SpawnHealth", 0f);
    }
}
