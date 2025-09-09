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
    private OrbitAttackInit orbitAttackInit;
    private IBulletSpawnerRegistry spawnerRegistry;
    private ITimeProvider timeProvider;

    [Header("Components")]
    public Animator animator;
    public Rigidbody2D rb;
    public Camera playerCamera;
    public InventoryManager inventoryManager;
    public PlayerAttackRange playerAttackRange;
    [SerializeField] private PlayerStats playerStats;
    public SpriteRenderer playerSprite;

    private void Awake()
    {
        // create new instances
        stateMachine = new StateMachine();
        idleState = new Idle(stateMachine, this);
        moveState = new Move(stateMachine, this, playerStats);
        playerInput = new PlayerInputActions();

        // create new instances for player attack
        timeProvider = new UnityTimeProvider();
        spawnerRegistry = new BulletSpawnerRegistry();
        attackScheduler = new AttackScheduler(spawnerRegistry, timeProvider);
        orbitAttackInit = new OrbitAttackInit(spawnerRegistry);
        playerAttack = new PlayerAttack(this, attackScheduler, orbitAttackInit, spawnerRegistry, timeProvider);

        // set init state
        stateMachine.InitState(idleState);

        // enable input action
        playerInput.Enable();

        // load components
        LoadRigidBody();
        LoadAnimator();
        LoadPlayerAttackRange();
        LoadPlayerSprite();
    }

    private void Start()
    {
        // init fields
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    private void Update()
    {
        stateMachine.currentState.HandleInput();
        stateMachine.currentState.LogicUpdate();
        stateMachine.currentState.SpriteUpdate();
        playerAttack.SpawnScheduledAttacks();
    }

    private void FixedUpdate()
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

    private void LoadPlayerAttackRange()
    {
        playerAttackRange = gameObject.GetComponentInChildren<PlayerAttackRange>();
    }

    private void OnEnable()
    {
        EventManager.OnOrbitWeaponSelected += HandleSpawnOrbitAttacks;
    }

    private void HandleSpawnOrbitAttacks()
    {
        playerAttack.SpawnOrbitAttacks();
    }

    private void LoadPlayerSprite()
    {
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
    }
}
