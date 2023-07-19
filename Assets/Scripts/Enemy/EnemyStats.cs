using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField, Range(0, 100f)] private float maxHealth;
    public float currentHealth;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        animator.SetTrigger("Hurt");

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float damage)
    {
        currentHealth += damage;
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        StartCoroutine(WaitAndDie(1000));
    }

    IEnumerator WaitMilliseconds(float ms)
    {
        yield return new WaitForSeconds(ms / 1000);
    }

    IEnumerator WaitAndDie(float ms)
    {
        GetComponentInParent<EnemyPatrol>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(ms / 1000);
        Destroy(gameObject);
    }

    public void ResetDieTrigger()
    {
        animator.ResetTrigger("Die");
    }

}
