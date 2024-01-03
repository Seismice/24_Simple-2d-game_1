using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddPatrons : MonoBehaviour
{
    
    NumberOfShoot _numberOfShoot;
    public UnityEvent OnDestroyedPatron;

    // Start is called before the first frame update
    void Start()
    {
        
        _numberOfShoot = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<NumberOfShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter2D");
            _numberOfShoot.numberOfPatron += 20;
            _numberOfShoot.textOfPatrons.text = _numberOfShoot.numberOfPatron.ToString();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Викликаємо подію при знищенні прямокутника
        OnDestroyedPatron.Invoke();
    }
}
