using UnityEngine;

public class PurchaseHandler : MonoBehaviour
{
    [SerializeField] private BuyButton[] _buyButtons;
    [SerializeField] private Balance _balance;
    [SerializeField] private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _buyButtons = FindObjectsOfType<BuyButton>();
        _enemySpawner.OnEnemyDieEvent.AddListener(RewardForEnemyHandler);

        foreach (BuyButton buyButton in _buyButtons)
        {
            buyButton.OnTryBuyEvent.AddListener(BuyHandler);
        }
    }

    private void BuyHandler(int price, BuyButton buyButton)
    {
        if (_balance.TrySpend(price) == true)
        {
            buyButton.BuyConfirm();
        }
    }

    private void RewardForEnemyHandler(int reward)
    {
        _balance.Add(reward);
    }
}
