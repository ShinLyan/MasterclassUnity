using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField, Range(0, 3000f)] private float scoreToFinish;
    [SerializeField] private TMP_Text scoreText;

    private float score;

    private float Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = value.ToString();
        }
    }

    private void Start()
    {
        Score = 0;
        Debug.Log(PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name, 0));
    }

    public void AddScore(float amount)
    {
        Score += amount;
    }

    public bool Finish()
    {
        string message = (score >= scoreToFinish) ? "Pobeda" : "Ne polychilos\'";
        Debug.Log(message);

        if (score > PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name, 0))
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, score);
        }

        return score >= scoreToFinish;
    }
}
