using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class AU_PlayerController : MonoBehaviour
{
    [SerializeField] bool hasControl;
    public static AU_PlayerController localPlayer;

    // Componenets
    Rigidbody myRB;
    Transform myAvatar;
    Animator MyAnim;

    // Player Movement
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;

    // Player Color
    static Color myColor;
    SpriteRenderer myAvatarSprite;

    private void OnEnable() {
        WASD.Enable();
    }

    private void OnDisable() {
        WASD.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(hasControl)
        {
            localPlayer = this;
        }
        myRB = GetComponent<Rigidbody>();
        myAvatar = transform.GetChild(0);
        MyAnim = GetComponent<Animator>();
        myAvatarSprite = myAvatar.GetComponent<SpriteRenderer>();
        if(myColor == Color.clear) {
            myColor = Color.white;
        }
        myAvatarSprite.color = myColor;
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = WASD.ReadValue<Vector2>();

        if (movementInput.x != 0) {
            myAvatar.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);
        }

        MyAnim.SetFloat("Speed", movementInput.magnitude);      
    }

    private void FixedUpdate() {
        myRB.velocity = movementSpeed * movementInput;
    }

    public void SetColor(Color newColor) {
        myColor = newColor;
        if(myAvatarSprite != null)
        {
            myAvatarSprite.color = myColor;
        }
    }
}
