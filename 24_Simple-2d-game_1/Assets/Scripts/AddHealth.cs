using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddHealth : MonoBehaviour
{
    PlayerHealth _playerHealth;
    PlayerFloatingHealthBar _playerFloatingHealthBar;
    public UnityEvent OnDestroyedHealth;
    [SerializeField] float addHealth = 20;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerHealth>();
        _playerFloatingHealthBar = GameObject.FindGameObjectWithTag("PlayerCanvas").GetComponentInChildren<PlayerFloatingHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("OnTriggerEnter2D");
            _playerHealth.currentHealth += addHealth;
            if(_playerHealth.currentHealth > _playerHealth.maxHealth)
            {
                _playerHealth.currentHealth = _playerHealth.maxHealth;
            }
            _playerFloatingHealthBar.UpdatePlayerHealthBar(_playerHealth.currentHealth, _playerHealth.maxHealth);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Викликаємо подію при знищенні прямокутника
        OnDestroyedHealth.Invoke();
    }
}
