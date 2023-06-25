using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BusTime : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    private void Start()
    {
        messageText.text = "";
    }

    private void OnEnable()
    {
        TimeManager.OnMinuteChanged += TimeCheck;
    }

     private void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }

    private void TimeCheck()
    {
        if(TimeManager.Hour == 19 && TimeManager.Minute == 15)
            StartCoroutine(MoveCar());
            
    }

    private IEnumerator MoveCar()
    {
        transform.position = new Vector3(-36.8f,-13f,0);
        Vector3 targetPos = new Vector3(32.6f,-13f,0);
        Vector3 currentPos = transform.position;

        float timeElapsed = 0;
        float timeToMove = 3;
        messageText.text = "PAYDOS!";

        while(timeElapsed < timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos,targetPos,timeElapsed/timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
