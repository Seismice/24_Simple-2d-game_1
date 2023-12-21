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
    public UnityEvent OnDestroyed;
    private int hitCount = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // ��������, �� ����������� ���� (Rotation Z ������� �� 90 ��� �� 270)
        if (!hasBeenDestroyed && transform.rotation.eulerAngles.z > 260f && transform.rotation.eulerAngles.z < 280f ||
            !hasBeenDestroyed && transform.rotation.eulerAngles.z > 80f && transform.rotation.eulerAngles.z < 100f)
        {
            isLying = true;
            // �������� ������������
            Destroy(gameObject, 2);
            hasBeenDestroyed = true;
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

    void OnDestroy()
    {
        // ��������� ���� ��� ������� ������������
        OnDestroyed.Invoke();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // ���� ������ ����� � �����������, �������� ��������
            hitCount++;

            // ���������, �� ��������� ��������� ������� ��������
            if (hitCount >= 5)
            {
                // ��������� ���� ��� ������� ������������
                //OnDestroyed.Invoke();

                // ������� �����������
                Destroy(gameObject);
            }
        }
    }
}
