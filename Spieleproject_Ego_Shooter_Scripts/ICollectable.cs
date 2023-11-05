using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectType
{
    Pills,
    FirstAid,
    Money,   
}

public interface ICollectable
{     
        public int Value { get; set; }
        
        CollectType Type { get; set; }

        void Collect();
    
}
