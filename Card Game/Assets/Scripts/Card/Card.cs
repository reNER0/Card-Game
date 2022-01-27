using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardProperty _manaValue;
    [SerializeField] private CardProperty _attackValue;
    [SerializeField] private CardProperty _healthValue;

    private CanvasGroup _canvasGroup;

    public CanvasGroup GetCanvasGroup => _canvasGroup;


    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }


    public void SetManaValue(int mana)
    {
        _manaValue.SetValue(mana);
    }

    public void SetAttackValue(int attack)
    {
        _attackValue.SetValue(attack);
    }
    
    public void SetHealthValue(int health) 
    {
        _healthValue.SetValue(health);
    }
}
