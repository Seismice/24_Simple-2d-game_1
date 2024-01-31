using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberOfEnemy : MonoBehaviour
{
    public TMP_Text textOfEnemy;
    public int numberOfEnemy = 10;
    public int numberOfDestroyEnemy;
    private int killEnemy = 0;
    [SerializeField] TMP_Text numberKillZombie_Text;
    [SerializeField] TMP_Text recordNumberKillZombie_Text;
    [SerializeField] private EndMenu _endMenu;
    [SerializeField] private WinText _winText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _choseLevelButton;
    private PlayerController _playerController;
    private float timer;
    private float increaseRate = 5f; // Збільшення кількості ворогів кожну секунду


    // Start is called before the first frame update
    void Start()
    {
        //numberOfDestroyEnemy = numberOfEnemy;
        textOfEnemy.text = numberOfDestroyEnemy.ToString();
        numberKillZombie_Text.text = killEnemy.ToString();
        recordNumberKillZombie_Text.text = SettingClass.EnemyRecord.ToString();
        _playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        // Збільшення кількості ворогів кожну секунду
        timer += Time.deltaTime;
        if (timer >= increaseRate)
        {
            numberOfEnemy++;
            //numberOfDestroyEnemy++;
            //textOfEnemy.text = numberOfEnemy.ToString();
            timer = 0f; // Скидання таймера
        }
    }

    public void MinysNumberOfDestroyEnemy()
    {
        numberOfDestroyEnemy--;
        textOfEnemy.text = numberOfDestroyEnemy.ToString();
        killEnemy++;
        ShowEndGame(killEnemy);
        numberKillZombie_Text.text = killEnemy.ToString();
        if (numberOfDestroyEnemy == 0)
        {
            Debug.Log("You win!");
            // Поставити гру на паузу
            Time.timeScale = 0f;
            _endMenu.gameObject.SetActive(true);
            _winText.gameObject.SetActive(true);
            // Вимкнути кнопку продовжити
            _restartButton.gameObject.SetActive(false);
            UnlockLevel();
            // Увімкнути кнопку вибір рівня
            _choseLevelButton.gameObject.SetActive(true);

            ShowEndGame(killEnemy);
        }
    }
    public void ShowEndGame(int enemy)
    {
        numberKillZombie_Text.text = enemy.ToString();

        if (SettingClass.EnemyRecord < enemy)
        {
            SettingClass.EnemyRecord = enemy;
        }

        recordNumberKillZombie_Text.text = SettingClass.EnemyRecord.ToString();
    }

    public void ButtonRestartClick()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
        Time.timeScale = 1f;
    }

    public void ButtonContinionClick()
    {
        Time.timeScale = 1f;
        _endMenu.gameObject.SetActive(false);
        _winText.gameObject.SetActive(false);
        _playerController.isPaused = false;
    }

    public void ButtonExitClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ChoseLevelButton()
    {
        int maxBuildIndex = SceneManager.sceneCountInBuildSettings - 1;
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel != maxBuildIndex)
        {
            SceneManager.LoadScene(currentLevel + 1);
            Time.timeScale = 1f; 
        }
        else
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }

    }

    public void UnlockLevel()
    {
        int maxBuildIndex = SceneManager.sceneCountInBuildSettings - 1;
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel != maxBuildIndex)
        {
            if (currentLevel >= PlayerPrefs.GetInt("levels"))
            {
                PlayerPrefs.SetInt("levels", currentLevel + 1);
            } 
        }
    }
}
