using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField] private Deck _deck;
    [SerializeField] private int _minRandomValue;
    [SerializeField] private int _maxRandomValue;
    [SerializeField] private int _randomizerPassCount;


    public void RandomizeCards()
    {
        for (int i = 0; i < _randomizerPassCount; i++)
        {
            foreach (Card card in _deck.Cards)
            {
                int randomSelection = Random.Range(0, 3);
                int randomValue = Random.Range(_minRandomValue, _maxRandomValue + 1);

                switch (randomSelection)
                {
                    case 0:

                        card.SetHealthValue(randomValue);

                        break;

                    case 1:

                        card.SetManaValue(randomValue);

                        break;

                    case 2:

                        card.SetAttackValue(randomValue);

                        break;
                }
            }
        }
    }
}
