using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIHighlight : MonoBehaviour, IPointerEnterHandler, IDeselectHandler
{
    #region MONOBEHAVIOUR CALLBACK METHODS
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!EventSystem.current.alreadySelecting)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }

    public void OnDeselect(BaseEventData eventData) => GetComponent<Selectable>().OnPointerExit(null);
    #endregion
}