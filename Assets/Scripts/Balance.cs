using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private BalanceView _balanceView;

    private void Start()
    {
        _balanceView.UpdateView(_value);
    }

    public void Add(int amount)
    {
        _value += amount;
        _balanceView.UpdateView(_value);
    }

    public bool TrySpend(int amount)
    {
        if (_value - amount >= 0)
        {
            _value -= amount;
            _balanceView.UpdateView(_value);
            return true;
        }
        else
        {
            return false;
        }
    }
}
