using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class GamePlay1 : MonoBehaviour
{
    public TMP_Text Text1;
    public TMP_Text Text2;
    public TMP_Text Text3;
    public float TimeLeft;
    public bool TimerOn = false;
    private int counter;
    private int countera;
    void Start()
    {
        counter = 0;
        countera = 0;
        TimerOn = true;
}
    void Update()
    {
        Text1.text = "Score:" + counter;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name.CompareTo("RedSphere") == 0)
                    counter = counter - 20;
                    countera ++;
                {
                    hit.collider.gameObject.SetActive(false);
                }
                if (hit.collider.gameObject.name.CompareTo("BlueSphere") == 0)
                    counter = counter + 10;
                    countera++;
                {
                    hit.collider.gameObject.SetActive(false);
                }
                if (hit.collider.gameObject.name.CompareTo("GreenSphere") == 0)
                    counter = counter + 20;
                    countera++;
                {
                    hit.collider.gameObject.SetActive(false);
                }
            }
            if (counter == 120)
                Text2.text = "Mission Completed";
            if (counter == 0)
                Text2.text = "Mission Failed";
        }
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Text2.text = "Mission Failed";
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        Text3.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}