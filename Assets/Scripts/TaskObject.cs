using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObject : MonoBehaviour
{

    private void OnMouseDown()
    {
        Debug.Log(Vector2.Distance((Vector2)transform.position, (Vector2)GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).position));

        if (Vector2.Distance((Vector2)transform.position, (Vector2)GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).position) > 4.00f)
            return;

        MissionManager.Instance.CurrentTaskObject = this;
    }
}