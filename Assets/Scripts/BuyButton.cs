using UnityEngine;
using UnityEngine.Events;

public class BuyButton : MonoBehaviour
{
    public UnityEvent<int, BuyButton> OnTryBuyEvent = new();

    [SerializeField] private GameObject _towerBody;
    [SerializeField] private int _price;

    private void OnMouseDown()
    {
       OnTryBuyEvent.Invoke(_price, this);
    }

    public void BuyConfirm()
    {
        _towerBody.SetActive(true);
        gameObject.SetActive(false);
    }
}
