using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectTypeWeapon
{
    Baseballbat,
    Ak
}

public interface ICWeapon
{
    public bool Value { get; set; }

    CollectTypeWeapon Type { get; set; }

    void Collect();

}
