using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;

    [SerializeField] private string actionMapName = "Player";

    [SerializeField] private string move = "Movement";
    [SerializeField] private string inventory = "Inventory";
    [SerializeField] private string attack = "Attack";
    [SerializeField] private string pause = "Pause";
    [SerializeField] private string roll = "Roll";
    [SerializeField] private string reload = "Reload";
    [SerializeField] private string eat = "Eat";
    [SerializeField] private string interact = "Interact";
    [SerializeField] private string look = "Look";

    private InputAction moveAction;
    private InputAction inventoryAction;
    private InputAction attackAction;
    private InputAction pauseAction;
    private InputAction rollAction;
    private InputAction reloadAction;
    private InputAction eatAction;
    private InputAction interactAction;
    private InputAction lookAction;


    public Vector2 moveInput {  get; private set; }
    public bool inventoryTriggered { get; private set; }
    public bool attackTriggered { get; private set; }
    public bool pauseTriggered { get; private set; }
    public bool rollTriggered { get; private set; }
    public bool reloadTriggered { get; private set; }
    public bool eatTriggered { get; private set; }
    public bool interactTriggered { get; private set; }
    public Vector2 lookInput { get; private set; }


    public static PlayerInputHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
        inventoryAction = playerControls.FindActionMap(actionMapName).FindAction(inventory);
        attackAction = playerControls.FindActionMap(actionMapName).FindAction(attack);
        pauseAction = playerControls.FindActionMap(actionMapName).FindAction(pause);
        rollAction = playerControls.FindActionMap(actionMapName).FindAction(roll);
        reloadAction = playerControls.FindActionMap(actionMapName).FindAction(reload);
        eatAction = playerControls.FindActionMap(actionMapName).FindAction(eat);
        interactAction = playerControls.FindActionMap(actionMapName).FindAction(interact);
        lookAction = playerControls.FindActionMap(actionMapName).FindAction(look);
        RegisterInputAction();

    }

    void RegisterInputAction()
    {
        moveAction.performed += context => moveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => moveInput = Vector2.zero;

        inventoryAction.performed += context => inventoryTriggered = true;
        inventoryAction.canceled += context => inventoryTriggered = false;

        attackAction.performed += context => attackTriggered = true;
        attackAction.canceled += context => attackTriggered = false;

        pauseAction.performed += context => pauseTriggered = true;
        pauseAction.canceled += context => pauseTriggered = false;

        rollAction.performed += context => rollTriggered = true;
        rollAction.canceled += context => rollTriggered = false;

        reloadAction.performed += context => reloadTriggered = true;
        reloadAction.canceled += context => reloadTriggered = false;

        eatAction.performed += context => eatTriggered = true;
        eatAction.canceled += context => eatTriggered = false;

        interactAction.performed += context => interactTriggered = true;
        interactAction.canceled += context => interactTriggered = false;

        lookAction.performed += context => lookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => lookInput = Vector2.zero;

    }


    private void OnEnable()
    {
        moveAction.Enable();
        inventoryAction.Enable();
        attackAction.Enable();
        pauseAction.Enable();
        rollAction.Enable();
        reloadAction.Enable();
        eatAction.Enable();
        interactAction.Enable();

    }

    private void OnDisable()
    {
        moveAction.Disable();
        inventoryAction.Disable();
        attackAction.Disable();
        pauseAction.Disable();
        rollAction.Disable();
        reloadAction.Disable();
        eatAction.Disable();
        interactAction.Disable();

    }





}
