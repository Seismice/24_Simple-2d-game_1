using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int levelUnlock;
    public Button[] buttons;
    [SerializeField] private GameObject _firstScrean;
    [SerializeField] private GameObject _choseLevel;

    void Start()
    {
        levelUnlock = PlayerPrefs.GetInt("levels", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelUnlock; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void NewGameButton()
    {
        PlayerPrefs.SetInt("levels", 1);
        levelUnlock = PlayerPrefs.GetInt("levels", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelUnlock; i++)
        {
            buttons[i].interactable = true;
        }
        _firstScrean.gameObject.SetActive(false);
        _choseLevel.gameObject.SetActive(true);
    }

    public void ContinionButton()
    {
        _firstScrean.gameObject.SetActive(false);
        _choseLevel.gameObject.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
