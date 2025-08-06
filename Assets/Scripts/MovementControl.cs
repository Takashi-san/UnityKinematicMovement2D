using System;
using UnityEngine;

public interface MovementInputProvider
{
    event Action<int> setXDirection;
    event Action<int> setYDirection;
}

public class MovementControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody2D;
    [SerializeField][Interface(typeof(MovementInputProvider))] Component inputComponent;
    MovementInputProvider inputProvider { get { return (MovementInputProvider)inputComponent; } }

    [Header("Params")]
    [SerializeField][Min(0)] float xAcceleration = 0;
    [SerializeField][Min(0)] float yAcceleration = 0;

    public Vector2 linearVelocity { get { return rigidBody2D.linearVelocity; } }
    public float angularVelocity { get { return rigidBody2D.angularVelocity; } }

    int xDirection = 0;
    int yDirection = 0;

    #region Unity Messages

    void OnValidate()
    {
        Setup();
    }

    void Awake()
    {
        Setup();
    }

    void Start()
    {
        inputProvider.setXDirection += UpdateXDirection;
        inputProvider.setYDirection += UpdateYDirection;
    }

    void OnDestroy()
    {
        inputProvider.setXDirection -= UpdateXDirection;
        inputProvider.setYDirection -= UpdateYDirection;
    }

    void FixedUpdate()
    {
        float xVelocity = linearVelocity.x + xDirection * xAcceleration * Time.deltaTime;
        float yVelocity = linearVelocity.y + yDirection * yAcceleration * Time.deltaTime;
        rigidBody2D.linearVelocity = new Vector2(xVelocity, yVelocity);
    }

    #endregion

    #region Internal Methods

    void Setup()
    {
        rigidBody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    void UpdateXDirection(int direction)
    {
        xDirection = direction;
    }

    void UpdateYDirection(int direction)
    {
        yDirection = direction;
    }

    #endregion
}
