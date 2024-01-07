using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Швидкість переміщення гравця")]
    [SerializeField] private int _spead = 10;
    [SerializeField] private int _walkSpead = 10;
    [SerializeField] private int _runSpead = 20;
    [Header("Сила прижка гравця")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private ContactFilter2D _platform;

    private Rigidbody2D _rigidbody2D;
    private bool isOnPlatfom => _rigidbody2D.IsTouching(_platform);

    public bool isRiht = true;

    private Tylob _tylob;
    private Vector3 verticalScaleStay = new Vector3(1f, 2f, 1f);
    private Vector3 verticalScaleSit = new Vector3(1f, 1.3f, 1f);
    private Vector3 tylobPositionStay = new Vector3(0f, -1f, 0f);
    private Vector3 tylobPositionSit = new Vector3(0f, -.66f, 0f);
    private Quaternion verticalRotation = Quaternion.Euler(0f, 0f, 0f);
    [SerializeField] private EndMenu _endMenu;
    [SerializeField] private WinText _winText;
    public bool isPaused = false;
    private PlayerHealth _playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        _tylob = GetComponentInChildren<Tylob>();
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerHealth.isDie)
        {
            Jump();
            GetInput();
        }
        // Якщо гра не на паузі і натиснута кнопка Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // Відновлення гри
            }
            else
            {
                PauseGame(); // Встановлення паузи
            }
        }
    }

    /// <summary>
    /// Метод для керування стрілками клавіатури.
    /// </summary>
    private void GetInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _spead = _runSpead;
        }

        else
        {
            _spead = _walkSpead;
        }


        if (transform.rotation.eulerAngles.z < 70f || transform.rotation.eulerAngles.z > 290f)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.localPosition += -transform.right * _spead * Time.deltaTime;
                isRiht = false;
                //transform.localRotation = verticalRotation;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.localPosition += transform.right * _spead * Time.deltaTime;
                isRiht = true;
                //transform.localRotation = verticalRotation;
            } 
        }

        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //transform.localRotation = transform.Rotate(0f, 0f, 0f);

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _tylob.transform.localScale = verticalScaleSit;
            _tylob.transform.localPosition = tylobPositionSit;
        }

        else
        {
            _tylob.transform.localScale = verticalScaleStay;
            _tylob.transform.localPosition = tylobPositionStay;
        }

    }

    void PauseGame()
    {
        _endMenu.gameObject.SetActive(true); // Виведення панелі EndMenu
        Time.timeScale = 0f; // Постановка гри на паузу
        isPaused = true; // Встановлення прапорця, що гра на паузі
    }

    void ResumeGame()
    {
        _endMenu.gameObject.SetActive(false); // Сховання панелі EndMenu
        _winText.gameObject.SetActive(false);
        Time.timeScale = 1f; // Відновлення швидкості гри
        isPaused = false; // Зняття прапорця, що гра на паузі
    }

    private void Jump()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    if (isOnPlatfom == true)
        //    {
        //        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse); 
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        //}

        if (transform.rotation.eulerAngles.z < 70f || transform.rotation.eulerAngles.z > 290f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isOnPlatfom == true)
                {
                    _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
                }
            } 
        }

    }

}



