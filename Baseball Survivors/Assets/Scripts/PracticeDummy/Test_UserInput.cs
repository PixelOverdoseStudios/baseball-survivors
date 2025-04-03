using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Test_UserInput : MonoBehaviour
{
    public Vector2 MoveInput {  get; private set; }
    public bool InteractIsPressed { get; private set; }

    private PlayerInput _playerInput;

    private InputAction _moveAction;
    private InputAction _interactAction;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        SetupInputActions();
    }

    private void Update()
    {
        UpdateInputs();
    }

    private void SetupInputActions()
    {
        _moveAction = _playerInput.actions["Movement"];
        _interactAction = _playerInput.actions["Interact"];
    }

    private void UpdateInputs()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();
        InteractIsPressed = _interactAction.WasPressedThisFrame();

        //testing
        if(Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene(GameManager.instance.GetMapToLoad);
            SaveManager.instance.SaveGame();
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene("SurvivorLounge");
            SaveManager.instance.SaveGame();
        }
    }

    private void OnDisable()
    {
        MoveInput = Vector2.zero;
        InteractIsPressed = false;
    }
}
