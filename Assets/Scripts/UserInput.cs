using System;
using UnityEngine;

public class UserInput : MonoBehaviour, MovementInputProvider
{
    [SerializeField][ReadyOnly] int _xDirection = 0;
    [SerializeField][ReadyOnly] int _yDirection = 0;
    int xDirection
    {
        get { return _xDirection; }
        set
        {
            _xDirection = value;
            setXDirection?.Invoke(_xDirection);
        }
    }
    int yDirection
    {
        get { return _yDirection; }
        set
        {
            _yDirection = value;
            setYDirection?.Invoke(_yDirection);
        }
    }

    public event Action<int> setXDirection;
    public event Action<int> setYDirection;

    void Update()
    {
        int xDirection = 0;
        int yDirection = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xDirection += -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xDirection += 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            yDirection += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            yDirection += -1;
        }

        this.xDirection = xDirection;
        this.yDirection = yDirection;
    }
}
