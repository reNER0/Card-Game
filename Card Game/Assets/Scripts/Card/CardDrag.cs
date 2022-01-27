using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
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
        if (table)
        {
            transform.SetParent(table.transform.parent);
            table.RepositionCards();
        }
        else
        {
            _deck.SelectCard(_card);
            transform.SetParent(_deck.transform.parent);
        }

        _shineFX.Play();
        _card.GetCanvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Table table = transform.GetComponentInParent<Table>();
        if (table)
        {
            table.RepositionCards();
        }
        else
        {
            transform.SetParent(_deck.transform);
            _deck.AddCard(_card);
        }

        _shineFX.Stop();
        _card.GetCanvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.DOComplete();
        transform.DOMove(Input.mousePosition, 0.15f);
        transform.DORotate(Quaternion.identity.eulerAngles, 0.15f);
    }
}
