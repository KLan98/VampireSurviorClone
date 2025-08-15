using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Constructor injection
/// </summary>
public class EnemyController : MonoBehaviour
{
    public EnemyStateMachine stateMachine;
    private EnemyMoveState enemyMoveState;
    public EnemyDieState enemyDieState;

    [Header("Components")]
    public Rigidbody2D rb;
    public PlayerControl playerControl;
    //[SerializeField] private Enemy enemy;

    private void Awake()
    {
        //LoadEnemyComponent();
        LoadRigidBody();
        LoadPlayerControl();

        stateMachine = new EnemyStateMachine();

        enemyMoveState = new EnemyMoveState(stateMachine, this);
        enemyDieState = new EnemyDieState(stateMachine, this);

        // Constructor injection
        stateMachine.InitState(enemyMoveState);    
    }

    private void Start()
    {
        // init fields
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // Constructor injection
        stateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        // Constructor injection
        stateMachine.currentState.PhysicsUpdate();
    }

    //private void LoadEnemyComponent()
    //{
    //    enemy = gameObject.GetComponent<Enemy>();
    //}

    private void LoadRigidBody()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void LoadPlayerControl()
    {
        playerControl = GameObject.Find("PlayerControl").GetComponent<PlayerControl>();
    }
}
