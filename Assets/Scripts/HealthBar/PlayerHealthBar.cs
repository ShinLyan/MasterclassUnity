using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Transform snapPoint;
    [SerializeField] private Transform healthBar;

    [SerializeField] private PlayerStats player;

    // normalized amount should be between 0 and 1: 1 - full health, 0 zero health;
    public void UpdateHealth(float normalizedAmount)
    {
        healthBar.localScale = new Vector3(normalizedAmount, 1, 1);
        healthBar.position = snapPoint.position;
    }
}
