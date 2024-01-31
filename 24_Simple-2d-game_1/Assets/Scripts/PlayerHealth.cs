using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    [SerializeField] private float damage = 10f;
    public bool isDie = false;
    private PlayerFloatingHealthBar _playerFloatingHealthBar;
    private Quaternion dieRotation = Quaternion.Euler(0f, 0f, 90f);
    private float damageCooldown = 1f; // ��������� �����䳿 ��� ������ ������� ������'�
    private float lastDamageTime;
    [SerializeField] private GameOverText _gameOverText;
    [SerializeField] private EndMenu _endMenu;
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        _playerFloatingHealthBar = GetComponentInChildren<PlayerFloatingHealthBar>();
        _playerFloatingHealthBar.UpdatePlayerHealthBar(currentHealth, maxHealth);
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ������� Bullet ���� �� ��������� � Enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerTakeDamage();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // ��������, �� ������ ��������� ���� �� ���������� ������� ������'�
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                PlayerTakeDamage();// ���� ����� ��� ��� ��������� ������'� ������
                
            }
        }    
    }

    private void PlayerTakeDamage()
    {
        if (!isDie)
        {
            currentHealth -= damage;
            _playerFloatingHealthBar.UpdatePlayerHealthBar(currentHealth, maxHealth);
            lastDamageTime = Time.time; // ��������� ���� �� ���������� ������� ������'�
            if (currentHealth <= 0)
            {
                Die();
            } 
        }
    }

    private void Die()
    {
        isDie = true;
        Debug.Log("Die");
        transform.localRotation = dieRotation;
        Time.timeScale = 0f; // ���������� ��� �� �����
        _endMenu.gameObject.SetActive(true);
        _gameOverText.gameObject.SetActive(true);
        _playerController.isPaused = true;
    }
}
