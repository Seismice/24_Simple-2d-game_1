using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NumberOfEnemy : MonoBehaviour
{
    public TMP_Text textOfEnemy;
    public int numberOfEnemy = 10;
    public int numberOfDestroyEnemy = 10;
    private int killEnemy = 0;
    [SerializeField] TMP_Text numberKillZombie_Text;
    [SerializeField] TMP_Text recordNumberKillZombie_Text;
    [SerializeField] private EndMenu EndMenu;
    private PlayerController _playerController;


    // Start is called before the first frame update
    void Start()
    {
        textOfEnemy.text = numberOfEnemy.ToString();
        numberKillZombie_Text.text = killEnemy.ToString();
        recordNumberKillZombie_Text.text = SettingClass.EnemyRecord.ToString();
        _playerController = GetComponent<PlayerController>();
    }

    public void MinysNumberOfDestroyEnemy()
    {
        numberOfDestroyEnemy--;
        killEnemy++;
        numberKillZombie_Text.text = killEnemy.ToString();
        if (numberOfDestroyEnemy == 0)
        {
            Debug.Log("You win!");
            // Поставити гру на паузу
            Time.timeScale = 0f;
            EndMenu.gameObject.SetActive(true);
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
        SceneManager.LoadScene("Main_0");
        Time.timeScale = 1f;
    }

    public void ButtonContinionClick()
    {
        Time.timeScale = 1f;
        EndMenu.gameObject.SetActive(false);
        _playerController.isPaused = false;
    }

    public void ButtonExitClick()
    {
        Application.Quit();
    }
}
