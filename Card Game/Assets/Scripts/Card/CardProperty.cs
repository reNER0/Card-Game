using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Text))]
public class CardProperty : MonoBehaviour
{
    [SerializeField] private float _countFPS = 10;

    private Text _text;


    protected virtual void Start()
    {
        _text = GetComponent<Text>();

        SetValue(7);
    }


    public void SetValue(int value) 
    {
        StopAllCoroutines();

        StartCoroutine(CountValue(value));
    }


    protected virtual IEnumerator CountValue(int newValue) 
    {
        float countTime = 1 / _countFPS;
        int currentValue = int.Parse(_text.text);

        while (newValue != currentValue) 
        {
            if (newValue > currentValue)
            {
                currentValue++;
            }
            else 
            {
                currentValue--;
            }

            _text.text = currentValue.ToString();

            transform.DOComplete();
            transform.DOPunchScale(Vector2.up, countTime / 2, 20);

            yield return new WaitForSeconds(countTime);
        }
    }


    private void OnDestroy()
    {
        transform.DOKill();
    }
}
