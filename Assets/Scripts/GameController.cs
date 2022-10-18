using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float WalkSpeed = 1.0f;

    private bool isPause = true;

    public GameObject panelUI;
    public GameObject panelPause;
    
    public GameObject boy;
    private Transform boyTransform;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        isPause = true;

        //panelUI.SetActive();
        panelPause.SetActive(true);

        boyTransform = boy.transform;
    }

    // Update is called once per frame
    void Update()
    {
        boyTransform.position = Vector3.MoveTowards(
            boyTransform.position,
            boyTransform.position + boyTransform.forward,
            WalkSpeed * Time.deltaTime);
    }

    public void OnPauseClick()
    {
        Time.timeScale = isPause ? 1 : 0;
        isPause = !isPause;

        // показать меню паузы
        panelPause.SetActive(isPause);
    }
}
