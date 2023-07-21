using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameInterface : MonoBehaviour
{
    #region Private Fields
    [SerializeField] private GameObject menu;

    [SerializeField] private GameObject winPanel;
    #endregion

    #region Properties
    public static GameInterface Instance { get; set; }
    #endregion

    #region Private Methods
    private void Start()
    {
        menu.SetActive(false);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SwitchMenu();
        }
    }
    #endregion

    #region Public Methods
    public void SwitchMenu()
    {
        menu.SetActive(!menu.activeSelf);

        // Отключаем компоненты игрока (Перемещение, Атака)

        //if (menu.activeSelf)
        //{
        //    Time.timeScale = 0;
        //}
        //else
        //{
        //    Time.timeScale = 1f;
        //}

        Time.timeScale = (menu.activeSelf) ? 0 : 1f;
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void OnClickExitGame()
    {
        print("OnClickExitGame");
        Application.Quit();
    }

    public void OnClickLevel(Button button)
    {
        SceneManager.LoadScene(button.name);
    }

    public void OnClickNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnClickReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}
