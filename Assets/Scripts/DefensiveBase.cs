using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveBase : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private int _maxHp;
    [SerializeField] private ValueView _valueView;

    void Start()
    {
        _hp = _maxHp;
        _valueView.UpdateView(_hp);
    }

    public void GetDamage(int damage)
    {
        if(_hp <= 0)
        {
            return;
        }


        _hp -= damage;
        

        if (_hp <= 0)
        {
            _hp = 0;
            print("Проиграли");
        }

        _valueView.UpdateView(_hp);
    }

    public void RestoreHp(int value)
    {
        _hp += value;

        if(_hp > _maxHp)
        {
            _hp = _maxHp;
        }

        _valueView.UpdateView(_hp);
    }
}
