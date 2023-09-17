using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] GameObject playingMenu;
    [SerializeField] GameObject levelFailedMenu;
    [SerializeField] GameObject levelCompletedMenu;
    [SerializeField] GameObject pauseMenu;
    public static bool gamePaused = false;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    public void PauseGame()
    {

        Debug.Log("faoe");
        pauseMenu.SetActive(true);
        playingMenu.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        playingMenu.SetActive(true);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void LevelFailed()
    {
        playingMenu.SetActive(false);
        levelFailedMenu.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(0);

    }

    public void LevelCompleted()
    {
        StartCoroutine(LevelCompleteActive());
    }

    IEnumerator LevelCompleteActive()
    {
        yield return new WaitForSeconds(2f);
        levelCompletedMenu.SetActive(true);
        playingMenu.SetActive(false);
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
