using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseHandler : MonoBehaviour
{
    [SerializeField] private BuyButton[] _buyButtons;
    [SerializeField] private Balance _balance;

    private void Awake()
    {
        _buyButtons = FindObjectsOfType<BuyButton>();

        foreach(BuyButton buyButton in _buyButtons)
        {
            buyButton.OnTryBuyEvent.AddListener(BuyHandler);
        }
    }

    private void BuyHandler(int price, BuyButton buyButton)
    {
        if(_balance.TrySpend(price) == true)
        {
            buyButton.BuyConfirm();
        }
    }
}
