using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance { get; private set; }

    [SerializeField] private TaskObject _currentTaskObject = null;

    [SerializeField] private List<Task> _currentTasks = new List<Task>();

    [SerializeField] private List<Image> _currentTaskTicks = new();

    [SerializeField] private List<TextMeshProUGUI> _currentTaskTexts = new();

    [SerializeField] private Sprite _tickSprite = null;

    public TaskObject CurrentTaskObject { private get => _currentTaskObject; set => _currentTaskObject = value; }

    private void Awake()
    {
        Instance = this;

        foreach (Task task in _currentTasks)
            task.AddListenerToAction(() => TickToTask(task));

        SetTaskText();
    }

    private void TickToTask(Task task)
    {
        _currentTaskTicks[_currentTasks.IndexOf(task)].sprite = _tickSprite;
    }

    public void GiveTask(Assignor assignor)
    {
        if (!_currentTaskObject)
            return;

        Task _task = null;
        bool _isMatched = false;

        for (int i = 0; i < _currentTasks.Count; i++)
        {
            if (!_currentTasks[i].CheckTask(assignor.TargetTask))
                continue;

            _task = _currentTasks[i];
            _isMatched = true;
        }

        if (!_isMatched)
            return;

        _currentTaskObject = null;


        _task?.GiveTask();
        SetTaskText();

        CheckTaskIsFinish(_task);
    }

    private void SetTaskText()
    {
        for (int i = 0; i < _currentTaskTexts.Count -1; i++)
            _currentTaskTexts[i].SetText($"{_currentTasks[i].TaskDescription}: {_currentTasks[i].CurrentQuantity} / {_currentTasks[i].Quantity}");
    }

    private void CheckTaskIsFinish(Task _task)
    {
        if (!_task.IsCompleted())
            return;

        int index = _currentTasks.IndexOf(_task);

        _currentTaskTicks[index].sprite = _tickSprite;
        _currentTaskTexts[index].SetText($"{_task.TaskDescription}: {_task.CurrentQuantity} / {_task.Quantity}");

        _currentTasks.Remove(_task);
    }
}

[System.Serializable]
public class Task
{
    [SerializeField] private TaskObject _targetTaskObject = null;
    [SerializeField] private int _quantity = 0;

    [SerializeField] private string _taskDescription = string.Empty;

    private int _currentQuantity = 0;

    private System.Action _endTaskAction = null;

    public TaskObject TargetTaskObject => _targetTaskObject;

    public int CurrentQuantity => _currentQuantity;
    public int Quantity => _quantity;

    public string TaskDescription => _taskDescription;

    public Task(TaskObject targetTaskObject, int quantity, System.Action _action)
    {
        _targetTaskObject = targetTaskObject;
        _quantity = quantity;
        _endTaskAction = _action;
    }

    public void AddListenerToAction(System.Action action) => _endTaskAction += action;

    public bool CheckTask(TaskObject _object) => TargetTaskObject.Equals(_object);

    public void GiveTask() => _currentQuantity++;

    public bool IsCompleted() => _currentQuantity.Equals(_quantity);
}