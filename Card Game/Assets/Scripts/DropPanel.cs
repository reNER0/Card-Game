using UnityEngine;
using UnityEngine.EventSystems;

public class DropPanel : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag)
        {
            eventData.pointerDrag.transform.SetParent(transform);
        }
    }
}
