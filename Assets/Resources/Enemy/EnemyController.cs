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
    public Enemy enemy;
    public Rigidbody2D rb;
    public PlayerControl playerControl;
    public EnemyStats enemyStats;
    public SpriteRenderer enemySprite;
    public EnemyDamageReceiver damageReceiver;

    private void Awake()
    {
        //LoadEnemyComponent();
        LoadEnemy();
        LoadRigidBody();
        LoadEnemySprite();
        LoadEnemyDamageReceiver();

        stateMachine = new EnemyStateMachine();

        enemyMoveState = new EnemyMoveState(stateMachine, this, enemyStats);
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

    private void LoadRigidBody()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void LoadEnemy()
    {
        enemy = gameObject.GetComponent<Enemy>();
    }

    private void LoadEnemySprite()
    {
        enemySprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void LoadEnemyDamageReceiver()
    {
        damageReceiver = gameObject.GetComponentInChildren<EnemyDamageReceiver>();
    }
}
