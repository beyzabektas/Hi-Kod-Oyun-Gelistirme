using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignor : MonoBehaviour
{
    [SerializeField] private TaskObject _targetTask = null;
    [SerializeField] private int _quantity = 0;

    public TaskObject TargetTask => _targetTask;

    private void OnMouseDown()
    {
        Debug.Log(Vector2.Distance((Vector2)transform.position, (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position));

        if (Vector2.Distance((Vector2)transform.position, (Vector2)GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).position) > 4.00f)
            return;

        MissionManager.Instance.GiveTask(this);
    }
}