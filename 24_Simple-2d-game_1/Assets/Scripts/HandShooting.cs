using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // ������ ������� (���������, �����)
    public Transform shootPoint; // ����� ������� (�������� ����, ����� ������ ������� �������)
    public float shootForce = 30f; // ���� �������

    private RykaVerHor _rykaVerHor; // ���������, �� ����� �� ������������� ��������� ����
    private PlayerController _playerController;
    private NumberOfShoot _numberOfShoot;
    private PlayerHealth _playerHealth;

    private Vector3 shotPointLeft = new Vector3(0f, 0.7f, 0f);
    private Vector3 shotPointRight = new Vector3(0f, -0.7f, 0f);

    void Start()
    {
        _rykaVerHor = GetComponent<RykaVerHor>();
        _playerController = GetComponentInParent<PlayerController>();
        _numberOfShoot = GetComponentInParent<NumberOfShoot>();
        _playerHealth = GetComponentInParent<PlayerHealth>();
    }

    void Update()
    {

        // �������� ���������� ������ X
        if (Input.GetKeyDown(KeyCode.X) && _rykaVerHor.isHorizontal)
        {
            if (_playerController.transform.rotation.eulerAngles.z < 70f || _playerController.transform.rotation.eulerAngles.z > 290f)
            {
                if (_numberOfShoot.numberOfPatron > 0 && !_playerHealth.isDie)
                {
                    Shoot();
                    _numberOfShoot.numberOfPatron--;
                    _numberOfShoot.textOfPatrons.text = _numberOfShoot.numberOfPatron.ToString();
                    //Debug.Log("_numberOfShoot.numberOfPatron = " + _numberOfShoot.numberOfPatron); 
                }
            }
        }
    }

    void Shoot()
    {
        if (_rykaVerHor.isHorizontalPositionLeft == false)
        {
            shootPoint.transform.localPosition = shotPointRight;
            // ��������� ������� � �������
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

            // ������������ ���� �������
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(Vector2.right * shootForce, ForceMode2D.Impulse);
            }

            Destroy(projectile, 2);
        }

        if (_rykaVerHor.isHorizontalPositionLeft == true)
        {
            shootPoint.transform.localPosition = shotPointLeft;
            // ��������� ������� � �������
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

            // ������������ ���� �������
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(Vector2.left * shootForce, ForceMode2D.Impulse);
            }

            Destroy(projectile, 2);
        }


    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    // �������� �������� � ������ ��'����� (���������, �����)
    //    if (other.CompareTag("Hand"))
    //    {
    //        isHorizontal = true;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    // �������� ������ � ���� ��������
    //    if (other.CompareTag("Hand"))
    //    {
    //        isHorizontal = false;
    //    }
    //}
}
