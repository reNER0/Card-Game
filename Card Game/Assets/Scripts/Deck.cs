using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Deck : MonoBehaviour
{
    [SerializeField] private float _anglePerCard;
    [SerializeField] private float _cardLayoutRadius;
    [SerializeField] private float _cardMoveTime;

    private List<Card> _cards = new List<Card>();

    public Card[] Cards => _cards.ToArray();


    public void RemoveCard(Card card) 
    {
        _cards.Remove(card);

        RepositionCards();
    }
    
    public void AddCard(Card card)
    {
        _cards.Add(card);

        RepositionCards();
    }

    public void DestroyCard(Card card)
    {
        _cards.Remove(card);

        card.Destroy();

        RepositionCards();
    }

    public void RepositionCards()
    {
        float fullAngle = (_cards.Count - 1) * _anglePerCard;

        for (int i = 0; i < _cards.Count; i++)
        {
            float angle = fullAngle / 2 - _anglePerCard * i;

            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            float sin = Mathf.Sin(angle * Mathf.Deg2Rad);
            float cos = Mathf.Cos(angle * Mathf.Deg2Rad);

            float x = _cardLayoutRadius * sin;
            float y = _cardLayoutRadius * (1 - cos);

            Vector3 position = new Vector2(-x, -y);

            _cards[i].transform.DOComplete();
            _cards[i].transform.DORotate(rotation.eulerAngles, _cardMoveTime);
            _cards[i].transform.DOLocalMove(position, _cardMoveTime);
        }
    }
}
