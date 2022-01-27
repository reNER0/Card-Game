using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class RandomImage : MonoBehaviour
{
    [SerializeField] private string _url;

    private RawImage _rawImage;


    private void Start()
    {
        _rawImage = GetComponent<RawImage>();

        StartCoroutine(LoadRandomImage());
    }


    private IEnumerator LoadRandomImage() 
    {
        WWW loader = new WWW(_url);

        yield return loader;

        _rawImage.texture = loader.texture;
    }
}
