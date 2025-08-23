using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public StateMachine stateMachine;
    public Idle idleState;
    public Move moveState;
    public PlayerInputActions playerInput;

    [Header("Components")]
    public Animator animator;
    public Rigidbody2D rb;
    public Camera playerCamera;
    public InventoryManager inventoryManager;
    public PlayerAttackRange playerAttackRange;

    private void Awake()
    {
        // create new object
        stateMachine = new StateMachine();

        // create new objects 
        idleState = new Idle(stateMachine, this);
        moveState = new Move(stateMachine, this);

        // set init state
        stateMachine.InitState(idleState);

        // create new object
        playerInput = new PlayerInputActions();

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
