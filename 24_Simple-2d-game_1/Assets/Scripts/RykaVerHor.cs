using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RykaVerHor : MonoBehaviour
{
    private Vector3 verticalPosition = new Vector3(0f, -0.7f, 0f);
    private Vector3 horizontalPosition = new Vector3(0.35f, -0.35f, 0f);
    private Vector3 horizontalPositionLeft = new Vector3(-0.35f, -0.35f, 0f);
    private Quaternion verticalRotation = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion horizontalRotation = Quaternion.Euler(0f, 0f, 90f);
    //private Vector3 verticalScale = new Vector3(0.5f, 0.65f, 1f);
    //private Vector3 horizontalScale = new Vector3(0.24f, 1.4f, 1f);
    public bool isHorizontal = false;
    private PlayerController _playerController;
    public bool isHorizontalPositionLeft = false;

    void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }

    void Update()
    {
        // Перевірка натискання кнопки Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (_playerController.isRiht == true)
            {
                // Визначення нових локальних координат в залежності від поточних
                Vector3 newLocalPosition = (transform.localPosition == verticalPosition) ? horizontalPosition : verticalPosition;
                Quaternion newRotation = (transform.localRotation == verticalRotation) ? horizontalRotation : verticalRotation;
                //Vector3 newScale = (transform.localScale == verticalScale) ? horizontalScale : verticalScale;

                // Встановлення нових локальних координат
                transform.localPosition = newLocalPosition;
                transform.localRotation = newRotation;
                //transform.localScale = newScale;

                if (newRotation == horizontalRotation)
                {
                    isHorizontal = true;
                }

                if (newRotation == verticalRotation)
                {
                    isHorizontal = false;
                }

                isHorizontalPositionLeft = false;
            }

            if (_playerController.isRiht == false)
            {
                // Визначення нових локальних координат в залежності від поточних
                Vector3 newLocalPosition = (transform.localPosition == verticalPosition) ? horizontalPositionLeft : verticalPosition;
                Quaternion newRotation = (transform.localRotation == verticalRotation) ? horizontalRotation : verticalRotation;
                //Vector3 newScale = (transform.localScale == verticalScale) ? horizontalScale : verticalScale;

                // Встановлення нових локальних координат
                transform.localPosition = newLocalPosition;
                transform.localRotation = newRotation;
                //transform.localScale = newScale;

                if (newRotation == horizontalRotation)
                {
                    isHorizontal = true;
                }

                if (newRotation == verticalRotation)
                {
                    isHorizontal = false;
                }

                isHorizontalPositionLeft = true;
            }
        }
    }
}
