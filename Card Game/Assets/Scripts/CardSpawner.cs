using UnityEngine;
using DG.Tweening;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private Deck _deck;
    [SerializeField] private Card _card;
    [SerializeField] private int _minCards;
    [SerializeField] private int _maxCards;
    [SerializeField] private float _cardsSpawnIntervalTime = 0.25f;

    private Sequence _sequence;


    private void Start()
    {
        _sequence = DOTween.Sequence();

        int cardsCount = Random.Range(_minCards, _maxCards + 1);
        SpawnCards(cardsCount);
    }


    private void SpawnCards(int count) 
    {
        for (int i = 0; i < count; i++)
        {
            Card card = Instantiate(_card, _deck.transform);

            card.transform.position = transform.position;
            card.transform.localScale = Vector3.zero;

            _sequence.Append(card.transform.DOScale(Vector3.one, _cardsSpawnIntervalTime).OnComplete(() =>
            {
                _deck.AddCard(card);
            }
            ));
        }
    }
}
