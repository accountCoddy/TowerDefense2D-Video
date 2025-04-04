using TMPro;
using UnityEngine;

public class BalanceView : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;

    public void UpdateView(int value)
    {
        _valueText.text = value.ToString();
    }
}
