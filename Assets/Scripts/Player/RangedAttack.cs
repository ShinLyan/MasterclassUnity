using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{

    [SerializeField] private GameObject blobPrefab;
    [SerializeField] private InputController playerController;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform attackPoint;
    private float attackTimer = Mathf.Infinity;

    bool wantsToAttack;

    private void Update()
    {
        wantsToAttack = playerController.RetrieveRangedAttackInput();
        attackTimer += Time.deltaTime;

        if (wantsToAttack && attackTimer > attackCooldown)
        {
            GetComponent<Animator>().SetBool("isAttacking", true);
            attackTimer = 0;
            //attack
            GameObject projectile = Instantiate(blobPrefab, attackPoint.position, Quaternion.identity, null);
            projectile.GetComponent<Projectile>().direction = transform.localScale.x / Mathf.Abs(transform.localScale.x);
        }
    }

    public void EndAttackBool()
    {
        GetComponent<Animator>().SetBool("isAttacking", false);
    }

}
