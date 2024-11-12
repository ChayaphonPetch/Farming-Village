using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private PlayerInputs playerinputs;
    private PlayerMovement PlayerMovement;
    [SerializeField] private int sprintSpeed = 10;
    [SerializeField] private int normalSpeed = 5;

    private void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        if (PlayerMovement == null)
        {
            Debug.LogError("PlayerMovement component missing from the object");
        }
        playerinputs = new PlayerInputs();
    }
    private void OnEnable()
    {
        playerinputs.InGame.Enable();
        playerinputs.InGame.Sprint.performed += ctx => PlayerMovement.SetSpeed(sprintSpeed);
        playerinputs.InGame.Sprint.canceled += ctx => PlayerMovement.SetSpeed(normalSpeed);
    }

    private void OnDisable()
    {
        playerinputs.InGame.Disable();
        playerinputs.InGame.Sprint.performed -= ctx => PlayerMovement.SetSpeed(sprintSpeed);
        playerinputs.InGame.Sprint.canceled -= ctx => PlayerMovement.SetSpeed(normalSpeed);
    }


}
