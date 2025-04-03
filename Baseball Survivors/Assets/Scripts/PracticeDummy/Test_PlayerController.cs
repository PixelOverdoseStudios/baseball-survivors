using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private bool activePlayer;
    [SerializeField] private int playerIndex;

    [SerializeField] private GameObject mapUI;

    private Test_UserInput userInput;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private GameObject lobbyPlayer;
    private bool playerFound;
    private bool mapFound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        userInput = GetComponent<Test_UserInput>();
    }

    private void Start()
    {
        CheckIfActivePlayer();
    }

    private void Update()
    {
        moveInput = userInput.MoveInput;

        if(userInput.InteractIsPressed)
        {
            if(playerFound)
            {
                Debug.Log("E was pressed");
                this.ActivateAndDeactivePlayer();
                lobbyPlayer.GetComponent<Test_PlayerController>().ActivateAndDeactivePlayer();
            }
            else if(mapFound)
            {
                if(mapUI.activeInHierarchy)
                    mapUI.SetActive(false);
                else if(!mapUI.activeInHierarchy)
                    mapUI.SetActive(true);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.tag;

        switch(tag)
        {
            case "LobbyPlayer":
                lobbyPlayer = other.gameObject;
                playerFound = true;
                break;
            case "Map":
                mapFound = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        string tag = other.tag;

        switch (tag)
        {
            case "LobbyPlayer":
                lobbyPlayer = null;
                playerFound = false;
                break;
            case "Map":
                mapFound = false;
                break;
        }
    }

    public void ActivateAndDeactivePlayer()
    {
        if(activePlayer)
        {
            activePlayer = false;
            userInput.enabled = false;
        }
        else if(!activePlayer)
        {
            activePlayer = true;
            userInput.enabled = true;
            GameManager.instance.ChangePlayerIndex(playerIndex);
        }
    }

    public void CheckIfActivePlayer()
    {
        if (this.playerIndex != GameManager.instance.GetActivePlayerIndex)
        {
            userInput.enabled = false;
            activePlayer = false;
        }
        else if (this.playerIndex == GameManager.instance.GetActivePlayerIndex)
        {
            activePlayer = true;
            userInput.enabled = true;
        }
    }
}
