using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public StateMachine stateMachine;
    public Idle idleState;
    public Move moveState;
    public PlayerInputActions playerInput;

    private PlayerAttack playerAttack;
    private AttackScheduler attackScheduler;
    private IBulletSpawnerRegistry spawnerRegistry;
    private ITimeProvider timeProvider;

    [Header("Components")]
    public Animator animator;
    public Rigidbody2D rb;
    public Camera playerCamera;
    public InventoryManager inventoryManager;
    public PlayerAttackRange playerAttackRange;

    private void Awake()
    {
        // create new instances
        stateMachine = new StateMachine();
        idleState = new Idle(stateMachine, this);
        moveState = new Move(stateMachine, this);
        playerInput = new PlayerInputActions();

        // create new instances for player attack
        timeProvider = new UnityTimeProvider();
        spawnerRegistry = new BulletSpawnerRegistry();
        attackScheduler = new AttackScheduler(spawnerRegistry, timeProvider);
        playerAttack = new PlayerAttack(this, attackScheduler, spawnerRegistry, timeProvider);

        // set init state
        stateMachine.InitState(idleState);

        // enable input action
        playerInput.Enable();

        // load components
        LoadRigidBody();
        LoadAnimator();
        LoadInventoryManager();
        LoadPlayerAttackRange();
    }

    private void Start()
    {
        // init fields
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.HandleInput();
        stateMachine.currentState.LogicUpdate();
        stateMachine.currentState.SpriteUpdate();
        playerAttack.SpawnAttacks();
    }

    void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    private void LoadRigidBody()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void LoadAnimator()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void LoadInventoryManager()
    {
        inventoryManager = GameObject.Find("Managers").GetComponentInChildren<InventoryManager>();
    }

    private void LoadPlayerAttackRange()
    {
        playerAttackRange = gameObject.GetComponentInChildren<PlayerAttackRange>();
    }
}
