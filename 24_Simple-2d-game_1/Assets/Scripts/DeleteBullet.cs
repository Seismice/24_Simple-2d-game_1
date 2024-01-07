using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ������� Bullet ���� �� ��������� � Enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            //Debug.Log("DeleteBullet");
        }

    }
}
