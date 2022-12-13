using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerCombat : MonoBehaviour
{
    public float maxHealth = 100f;
    [SerializeField] float health;

    public bool isAlive;

    [SerializeField] TextMeshProUGUI healthIndicator;

    void Start()
    {
        health = maxHealth;
        isAlive = true;
        healthIndicator.text = "HP: " + health.ToString();
    }

    public void Damage (float dmg)
    {
        health -= dmg;

        healthIndicator.text = "HP: "+health.ToString();

        if (health <= Mathf.Epsilon)
        {
            this.gameObject.SetActive(false);
            isAlive = false;
            SceneManager.LoadScene("Gameover");
        }
    }
}
