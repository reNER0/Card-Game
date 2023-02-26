using DG.Tweening;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardProperty _manaValue;
    [SerializeField] private CardProperty _attackValue;
    [SerializeField] private CardProperty _healthValue;
    [SerializeField] private float _cardDestroyTime = 0.3f;

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

    public void Destroy() 
    {
        GetCanvasGroup.blocksRaycasts = false;

        transform.DOScale(Vector3.one * 1.25f, _cardDestroyTime / 2).OnComplete(() =>
        {
            transform.DOScale(Vector3.zero, _cardDestroyTime / 2).OnComplete(() =>
            {
                transform.DOKill();
                Destroy(gameObject);
            });
        });
    }
}
