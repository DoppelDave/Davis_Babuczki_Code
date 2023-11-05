using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] private int value;
    public int Value { get => value; set => this.value = value; }

    [SerializeField] private CollectType type;
    public CollectType Type { get => type; set => type = value; }

    public void Collect()
    {
        Destroy(gameObject);
    }

}
