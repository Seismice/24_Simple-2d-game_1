using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberOfShoot : MonoBehaviour
{
    public TMP_Text textOfPatrons;
    public int numberOfPatron = 10;

    // Start is called before the first frame update
    void Start()
    {
        textOfPatrons.text = numberOfPatron.ToString();
    }
}
