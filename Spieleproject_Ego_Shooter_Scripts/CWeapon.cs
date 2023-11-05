using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWeapon : MonoBehaviour, ICWeapon
{
    [SerializeField] private bool value;
    public bool Value { get => value; set => this.value = value; }

    [SerializeField] private CollectTypeWeapon type;
    public CollectTypeWeapon Type { get => type; set => type = value; }

    public void Collect()
    {
        Destroy(gameObject);
    }
}
