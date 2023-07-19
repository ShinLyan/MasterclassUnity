using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField, Range(0, 3000f)] private float scoreToFinish;

    [SerializeField] private float score;
    

    private void Start()
    {
        score = 0;
        Debug.Log(PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name, 0));
    }

    public void AddScore(float amount)
    {
        score += amount;
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
