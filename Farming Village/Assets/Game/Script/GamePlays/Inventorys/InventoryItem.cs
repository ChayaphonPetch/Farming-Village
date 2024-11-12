using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using static TMPro.Examples.ObjectSpin;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public Text CountText;
    public Slider Waterbar;

    [HideInInspector] public Item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
        Watering();
    }

    public void RefreshCount()
    {
        CountText.text = count.ToString();
        bool textActive = count > 1;
        CountText.gameObject.SetActive(textActive);
    }

    public void Watering()
    {
        bool sliderWater = item != null && item.actionType == ActionType.Watering;
        Waterbar.gameObject.SetActive(sliderWater);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        CountText.raycastTarget = false;
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CountText.raycastTarget = true;
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}