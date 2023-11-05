using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemieHealth : MonoBehaviour
{
    public int health;

    private int maxHealth;
    private Slider healthBar;

    private Enemie enemie;
    private AudioSource AudioSourceChild;
    
    void Start()
    {
        AudioSourceChild = GetComponentInChildren<AudioSource>();
        enemie = GetComponent<Enemie>();
        healthBar = GetComponentInChildren<Slider>();
        maxHealth = health;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
        healthBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;

        if(health < maxHealth)
        {
            healthBar.gameObject.SetActive(true);
        }

        if(health <= 0)
        {
            healthBar.gameObject.SetActive(false);
            enemie.Die();
        }
    }

    public void TakeDamage(int dmg, AudioClip impactSound)
    {
        health -= dmg;
        AudioSourceChild.clip = impactSound;
        AudioSourceChild.Play();
    }

}
