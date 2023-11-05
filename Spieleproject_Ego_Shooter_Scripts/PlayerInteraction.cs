using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction selectInput;

    private Transform target = null;

    public PlayerStats playerStats;
    public GameObject pickUpText;

    public UnityEvent<int> OnHealthChanged;
    public UnityEvent<bool> OnBatChanged;
    public UnityEvent<bool> OnAkChanged;
    public UnityEvent<int> OnMoneyChanged;
    public UnityEvent<int> OnPillsChanged;
    void Start()
    {
        pickUpText.gameObject.SetActive(false);
        playerInput = new PlayerInput();
        selectInput = playerInput.Player.Select;
        selectInput.Enable();
        playerStats.Health = 100;
    }
    
    void Update()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, transform.forward, out hit, 5f);


        if (hit.collider && hit.transform.tag == "Collectable")
        {
            pickUpText.gameObject.SetActive(true);
            target = hit.transform; 
          

            hit.transform.GetComponent<Renderer>().material.color = Color.blue;

            if(selectInput.triggered)
            {
                var collectable = hit.transform.GetComponent<ICollectable>();

                if (collectable == null) return;

                switch (collectable.Type)
                {
                    case CollectType.Pills:
                        Pills += collectable.Value;
                        collectable.Collect();
                        break;
                    case CollectType.Money:
                        Money += collectable.Value;
                        collectable.Collect();
                        break;

                }
            } 
        }
        else
        {
            if(target != null)
            {
                target.transform.GetComponent<Renderer>().material.color = Color.white;
            }
            pickUpText.gameObject.SetActive(false);
        }

        if (hit.collider && hit.transform.tag == "CollectableWeapon")
        {
            pickUpText.gameObject.SetActive(true);                   

            if (selectInput.triggered)
            {
                var collectableWeapon = hit.transform.GetComponent<ICWeapon>();

                if (collectableWeapon == null) return;

                switch (collectableWeapon.Type)
                {
                    case CollectTypeWeapon.Baseballbat:
                        IsBatEquiped = collectableWeapon.Value;
                        collectableWeapon.Collect();
                        break;
                    case CollectTypeWeapon.Ak:
                        IsAkEquiped = collectableWeapon.Value;
                        collectableWeapon.Collect();
                        break;
                }
            }
        }     
    }

    
    public bool IsBatEquiped
    {
        get => playerStats.Baseballbat; set
        {
            playerStats.Baseballbat = value;
            playerStats.Ak = false;
            OnBatChanged.Invoke(playerStats.Baseballbat);
        }
    }

    public bool IsAkEquiped
    {
        get => playerStats.Ak; set
        {
            playerStats.Ak = value;
            playerStats.Baseballbat = false;
            OnAkChanged.Invoke(playerStats.Ak);
        }
    }

    public int Health
    {
        get => playerStats.Health; set
        {
            playerStats.Health = value;
            OnHealthChanged.Invoke(playerStats.Health);
        }
    }
    public int Money { get => playerStats.Money; set
        {
            playerStats.Money = value;
            OnMoneyChanged.Invoke(playerStats.Money);
        }
        }
    public int Pills
    {
        get => playerStats.Pills; set
        {
            playerStats.Pills = value;
            OnPillsChanged.Invoke(playerStats.Pills);
        }
    }

    private void OnDisable()
    {
        selectInput = playerInput.Player.Select;
        selectInput.Disable();
    }
}
