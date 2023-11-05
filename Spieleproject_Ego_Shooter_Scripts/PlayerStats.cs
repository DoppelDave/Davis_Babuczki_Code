using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu (fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int Pills = 0;
    public int Money = 0;
   
    public int Health = 100;

    public bool Baseballbat;
    public bool Ak;    
}
