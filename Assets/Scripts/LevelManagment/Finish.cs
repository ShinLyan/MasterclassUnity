using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (levelManager.Finish())
            {
                SceneManager.LoadScene(1);
            }
            Debug.Log("Finish");
        }
    }
}
