using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    protected static int totalEnemy = 20;
    [SerializeField] GameObject touchInfo;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject anyKey;
    [SerializeField] Movement aliens;
    [SerializeField] GameObject playerDies;
    [SerializeField] GameObject enemyDies;
    bool isGameStarted = false;
    void Start()
    {
        Time.timeScale = 0f;
        anyKey.SetActive(true);
        touchInfo.SetActive(true);
    }
    public void HowWins(bool check)
    {
        if(!check)
        {
            aliens.direction = Vector2.down;
            aliens.speed = 2f;
            Invoke(nameof(PlayerDies),1f);
        }
        else
        {
            CheckNumberOfEnemy();
        }
    }
    public void GameStart()
    {
        if(!isGameStarted)
        {        
            anyKey.SetActive(false);
        touchInfo.SetActive(false);
        Time.timeScale = 1f;
        }
        isGameStarted = true;
    }
    private void PlayerDies()
    {
        playerDies.SetActive(true);
    }
    private void EnemyDies()
    {
        enemyDies.SetActive(true);
    }
    public void CheckNumberOfEnemy()
    {
        totalEnemy--;
        if(totalEnemy <= 0)
        {
            EnemyDies();
        }
    }
    public void Pause()
    {
        FreezeOrUnfreezeTime();
        menu.SetActive(true);
    }
    public void Close()
    {
        FreezeOrUnfreezeTime();
        menu.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FreezeOrUnfreezeTime();
    }
    void OnDestroy()
    {
        CancelInvoke();
    }
    public void FreezeOrUnfreezeTime()
    {
        if(Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        else if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }
}
