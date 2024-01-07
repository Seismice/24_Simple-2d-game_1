using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{

    public bool hasBeenDestroyed = false;
    public float speed = 1f; // �������� ���� ������������
    private GameObject player;
    private bool isLying = false;
    //public UnityEvent OnDestroyed;
    //private int hitCount = 0;
    private float lieStartTime;
    [SerializeField] float health = 3f;
    [SerializeField] float maxHealth = 3f;
    private FloatingHealthBar _floatingHealthBar;
    private NumberOfEnemy _numberOfEnemy;

    private void Awake()
    {
        _floatingHealthBar = GetComponentInChildren<FloatingHealthBar>();
        _numberOfEnemy = GameObject.FindWithTag("Player").GetComponentInParent<NumberOfEnemy>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        _floatingHealthBar.UpdateHealthBar(health, maxHealth);
    }

    void Update()
    {
        // ��������, �� ����������� ���� (Rotation Z ������� �� 90 ��� �� 270)
        //if (!hasBeenDestroyed && transform.rotation.eulerAngles.z > 260f && transform.rotation.eulerAngles.z < 280f ||
        //    !hasBeenDestroyed && transform.rotation.eulerAngles.z > 80f && transform.rotation.eulerAngles.z < 100f)
        //{
        //    isLying = true;
        //    // �������� ������������
        //    //Destroy(gameObject, 2);
        //    //hasBeenDestroyed = true;
        //    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
        //    isLying = false;
        //}

        if (!hasBeenDestroyed && !isLying &&
        (transform.rotation.eulerAngles.z > 260f && transform.rotation.eulerAngles.z < 280f ||
         transform.rotation.eulerAngles.z > 80f && transform.rotation.eulerAngles.z < 100f))
        {
            isLying = true;
            lieStartTime = Time.time;
        }

        if (isLying && Time.time - lieStartTime >= 5f)
        {
            // ϳ��� 2 ������ �������� 䳿
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
            isLying = false;
        }

        if (!hasBeenDestroyed && !isLying)
        {
            if (player != null)
            {
                // ���������� �������� �� ������
                Vector3 direction = player.transform.position - transform.position;
                direction.Normalize(); // ����������� ������� ��� ��������� ���������� ��������

                // ��� ������������ � �������� ������
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
    }

    //void OnDestroy()
    //{
    //    // ��������� ���� ��� ������� ������������
    //    OnDestroyed.Invoke();
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {


            // ���� ������ ����� � �����������, �������� ��������
            //hitCount++;

            // ���������, �� ��������� ��������� ������� ��������
            //if (hitCount >= numberDeadShoot)
            //{
            //    // ��������� ���� ��� ������� ������������
            //    //OnDestroyed.Invoke();

            //    // ������� �����������
            //    Destroy(gameObject);
            //}

            TakeDamage(1f);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        _floatingHealthBar.UpdateHealthBar(health, maxHealth);
        if(health <= 0)
        {
            Destroy(gameObject);
            _numberOfEnemy.MinysNumberOfDestroyEnemy();
        }
    }
}
