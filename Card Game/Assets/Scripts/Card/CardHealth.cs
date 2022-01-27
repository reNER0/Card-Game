using System.Collections;

public class CardHealth : CardProperty
{
    private Card _card;
    private Deck _cardDeck;


    protected override void Start()
    {
        base.Start();

        _card = GetComponentInParent<Card>();
        _cardDeck = GetComponentInParent<Deck>();
    }


    protected override IEnumerator CountValue(int newValue)
    {
        yield return StartCoroutine(base.CountValue(newValue));

        yield return null;

        if (newValue < 1)
        {
            _cardDeck.RemoveCard(_card);
        }
    }
}
