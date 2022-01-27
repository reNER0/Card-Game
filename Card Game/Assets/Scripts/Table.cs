using DG.Tweening;
using System.Linq;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private float _cardMoveTime;
    [SerializeField] private float _distanceBetweenCards;


    public void RepositionCards()
    {
        float[] widghts = new float[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            widghts[i] = transform.GetChild(i).GetComponent<RectTransform>().rect.width;
        }

        float allWidght = widghts.Sum() + _distanceBetweenCards * (transform.childCount - 1);

        float currentOffset = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            float posX = -allWidght / 2;
            posX += currentOffset;
            posX += _distanceBetweenCards * i;
            posX += widghts[i] / 2;

            Vector3 position = new Vector2(posX, 0);

            Transform child = transform.GetChild(i);

            child.transform.DOComplete();
            child.DOLocalMove(position, _cardMoveTime);
            child.DORotate(Quaternion.identity.eulerAngles, _cardMoveTime);
            
            currentOffset += widghts[i];
        }
    }
}
