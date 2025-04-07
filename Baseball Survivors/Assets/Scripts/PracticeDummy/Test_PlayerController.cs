using NUnit.Framework;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private bool activePlayer;
    [SerializeField] private int playerIndex;

    [SerializeField] private Animator bodyAnim;
    [SerializeField] private Animator legsAnim;

    //[SerializeField] private GameObject mapUI;

    private Test_UserInput userInput;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    //[SerializeField] private List<GameObject> interactableObjects;
    [SerializeField] private GameObject nearestInteractable;
    //private bool playerFound;
    //private bool mapFound;

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
            if(nearestInteractable != null)
            {
                nearestInteractable.GetComponent<InteractableObject>().Interact();
            }
        }

        //if(interactableObjects.Count > 0)
        //{
        //    float distance = float.MaxValue;

        //    for(int i = 0; i < interactableObjects.Count; i++)
        //    {
        //        if(interactableObjects[i] != null)
        //        {
        //            if(Vector3.Distance(this.transform.position, interactableObjects[i].transform.position) < distance)
        //            {
        //                nearestInteractable = interactableObjects[i];
        //            }
        //        }
        //    }

        //    for(int i = 0; i < interactableObjects.Count; ++i)
        //    {
        //        if(interactableObjects[i] != nearestInteractable)
        //            interactableObjects[i].GetComponent<InteractableObject>().DeactivateHighlight();
        //    }
        //    nearestInteractable.GetComponent<InteractableObject>().HighlightObject();
        //}
        //else
        //{
        //    nearestInteractable.GetComponent<InteractableObject>().DeactivateHighlight();
        //    nearestInteractable = null;
        //}

        //if(userInput.InteractIsPressed)
        //{
        //    if(playerFound)
        //    {
        //        Debug.Log("E was pressed");
        //        this.ActivateAndDeactivePlayer();
        //        lobbyPlayer.GetComponent<Test_PlayerController>().ActivateAndDeactivePlayer();
        //    }
        //    else if(mapFound)
        //    {
        //        if(mapUI.activeInHierarchy)
        //            mapUI.SetActive(false);
        //        else if(!mapUI.activeInHierarchy)
        //            mapUI.SetActive(true);
        //    }
        //}
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    private void LateUpdate()
    {
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }

        if (moveInput != Vector2.zero)
        {
            bodyAnim.SetBool("moving", true);
            legsAnim.SetBool("moving", true);
        }
        else
        {
            bodyAnim.SetBool("moving", false);
            legsAnim.SetBool("moving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<InteractableObject>())
        {
            if(nearestInteractable ==  null)
            {
                nearestInteractable = other.gameObject;
                nearestInteractable.gameObject.GetComponent<InteractableObject>().HighlightObject();
            }
            if(nearestInteractable != null)
            {
                nearestInteractable.gameObject.GetComponent<InteractableObject>().DeactivateHighlight();
                nearestInteractable = other.gameObject;
                nearestInteractable.gameObject.GetComponent<InteractableObject>().HighlightObject();
            }
        }


        //string tag = other.tag;

        //switch(tag)
        //{
        //    case "LobbyPlayer":
        //        lobbyPlayer = other.gameObject;
        //        playerFound = true;
        //        break;
        //    case "Map":
        //        mapFound = true;
        //        break;
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == nearestInteractable)
        {
            nearestInteractable.gameObject.GetComponent<InteractableObject>().DeactivateHighlight();
            nearestInteractable = null;
        }
        //string tag = other.tag;

        //switch (tag)
        //{
        //    case "LobbyPlayer":
        //        lobbyPlayer = null;
        //        playerFound = false;
        //        break;
        //    case "Map":
        //        mapFound = false;
        //        break;
        //}
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
