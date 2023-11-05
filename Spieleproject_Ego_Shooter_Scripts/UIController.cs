using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text money;
    [SerializeField] Text pills;
    [SerializeField] GameObject baseballbat;
    [SerializeField] GameObject ak;
    

    public int maxHealthValue = 100;
    

    [SerializeField] Slider staminaBar;
    [SerializeField] Slider healthBar;

    private GameObject player;
    private Animator anim;
    // Start is called before the first frame update

    public void SetBaseballbat(bool isEquiped)
    {
        this.baseballbat.gameObject.SetActive(true);
        this.ak.gameObject.SetActive(false);
    }

    public void SetAk(bool isEquiped)
    {
        this.baseballbat.gameObject.SetActive(false);
        this.ak.gameObject.SetActive(true);
    }
    public void SetMoney(int money)
    {
        this.money.text = "Money: " + money.ToString();
    }

    public void SetPills(int pills)
    {
        this.pills.text = "Pills: " + pills.ToString();
    }

    public void SetHealth(int health)
    {
        this.healthBar.value = health;
    }

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        staminaBar.maxValue = player.GetComponent<CharacterController>().maxStamina;
        staminaBar.value = player.GetComponent<CharacterController>().maxStamina;

        healthBar.maxValue = maxHealthValue;
        healthBar.value = maxHealthValue;

        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.value = player.GetComponent<CharacterController>().stamina;
    }

    public void GetHit()
    {
        anim.SetTrigger("Hit");
    }
}

