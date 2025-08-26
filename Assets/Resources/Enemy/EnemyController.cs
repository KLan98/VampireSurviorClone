using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStateMachine stateMachine;
    public EnemyMoveState enemyMoveState;
    public EnemyDieState enemyDieState;
    public EnemyKnockedBackState enemyKnockedBackState;
    
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
        enemyKnockedBackState = new EnemyKnockedBackState(stateMachine, this);

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
        stateMachine.currentState.SpriteUpdate();
        stateMachine.currentState.BoolUpdate();
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
