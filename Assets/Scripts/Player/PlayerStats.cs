using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    float maxHealth = 100f;
    float currentHealth;

    [SerializeField] private PlayerHealthBar healthBar;
    [SerializeField] private SceneController sceneController;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start() 
    {
        currentHealth = maxHealth;
        FindObjectOfType<AudioManager>().Play("Ambient");
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }


    public void TakeDamage(float amount) 
    {
        FindObjectOfType<AudioManager>().Play("PlayerHurt");

        animator.SetBool("isHurt", true);
        currentHealth -= amount;
        healthBar.UpdateHealth(Mathf.Max(currentHealth / maxHealth, 0));

        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            animator.SetBool("isHurt", false);
            Die();
        }
    }

    public void Heal(float amount) => currentHealth += amount;

    public void EndTakeDamage() => GetComponent<Animator>().SetBool("isHurt", false);

    public void Die()
    {
        DisableCollider();
        DisableMovement();
        StartCoroutine(WaitAndDie(1000));
        Debug.Log("Dead");
    }

    private void DisableCollider()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
    }

    private void DisableMovement()
    {
        GetComponent<Move>().enabled = false;
        GetComponent<Jump>().enabled = false;
    }

    IEnumerator WaitMilliseconds(float ms)
    {
        yield return new WaitForSeconds(ms / 1000);
    }

    IEnumerator WaitAndDie(float ms)
    {
        yield return new WaitForSeconds(ms / 1000);
        sceneController.ReloadCurrentScene();
    }

}
