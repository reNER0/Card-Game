using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private float _cardMoveTime = 0.15f;

    private Card _card;
    private Deck _deck;
    private ParticleSystem _shineFX;


    private void Start()
    {
        _card = GetComponent<Card>();
        _deck = GetComponentInParent<Deck>();
        _shineFX = GetComponentInChildren<ParticleSystem>();

        _shineFX.Stop();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Table table = transform.GetComponentInParent<Table>();

        _shineFX.Play();
        _card.GetCanvasGroup.blocksRaycasts = false;

        if (table)
        {
            transform.SetParent(table.transform.parent);
            table.RepositionCards();
            return;
        }

        _deck.RemoveCard(_card);
        transform.SetParent(_deck.transform.parent);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Table table = transform.GetComponentInParent<Table>();

        _shineFX.Stop();
        _card.GetCanvasGroup.blocksRaycasts = true;

        if (table)
        {
            table.RepositionCards();
            return;
        }

        transform.SetParent(_deck.transform);
        _deck.AddCard(_card);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.DOComplete();
        transform.DOMove(Input.mousePosition, _cardMoveTime);
        transform.DORotate(Quaternion.identity.eulerAngles, _cardMoveTime);
    }
}
