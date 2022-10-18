using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelDraw : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,
    IPointerDownHandler, IPointerMoveHandler, IPointerUpHandler
{
    public Transform parentObj;
    public Sprite sprite;

    private List<GameObject> listCirc;
    private bool isDraw;

    // Start is called before the first frame update
    void Start()
    {
        isDraw = false;
        listCirc = new List<GameObject>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(">> OnPointerEnter");
        isDraw = true;
        AddSpot(eventData.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isDraw = false;
        Debug.Log(">> OnPointerExit");
        ClearPanel();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(">> OnPointerDown");
        //AddSpot(eventData.position);        
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        Debug.Log(">> OnPointerMove");

        if (isDraw) AddSpot(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(">> OnPointerUp");
    }

    void AddSpot(Vector2 position)
    {
        Image img = new GameObject().AddComponent<Image>();
        img.transform.SetParent(parentObj);
        img.GetComponent<Image>().sprite = sprite;
        img.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
        img.transform.position = new Vector2(
            position.x,
            position.y);

        listCirc.Add(img.gameObject);
        //Debug.Log(">> add");
    }

    void ClearPanel()
    {
        //Debug.Log(">> 1 count = " + listCirc.Count);

        foreach (GameObject gm in listCirc)
        {
            Destroy(gm);
        }
        listCirc.Clear();
        //Debug.Log(">> 2 count = " + listCirc.Count);

        //Debug.Log(">> 1 childCount = " + parentObj.transform.childCount);
        for (int i = parentObj.transform.childCount - 1; i >= 0; i--)
        {
            //Debug.Log(">> i = " + i);
            Destroy(parentObj.transform.GetChild(i).gameObject);
        }

        //Debug.Log(">> clear");
    }
}
