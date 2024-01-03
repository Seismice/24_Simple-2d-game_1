using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronRaspawn : MonoBehaviour
{
    public GameObject patronPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPatron();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPatron()
    {
        // Створення нового прямокутника на місці респавну
        GameObject newPatron = Instantiate(patronPrefab, transform.position, Quaternion.identity);

        // Додайте слухача події на знищення прямокутника
        newPatron.GetComponent<AddPatrons>().OnDestroyedPatron.AddListener(() => Invoke("SpawnNextPatron", 10f));
    }

    void SpawnNextPatron()
    {
        // Викликайте наступний респаун після видалення попереднього
        Invoke("SpawnPatron", 0f);
    }
}
