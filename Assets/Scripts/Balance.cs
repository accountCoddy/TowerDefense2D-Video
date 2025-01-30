using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private int _value;
    
    public void Add(int amount)
    {
        _value += amount;
    }

    public bool TrySpend(int amount)
    {
        if(_value - amount >= 0)
        {
            _value -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }
}
