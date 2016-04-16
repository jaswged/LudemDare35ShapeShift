using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour 
    {
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 4.0f;
    public float jumpSpeed = 3.0f;
    public float upDownRange = 60.0f;
    public float runSpeed = 1.75f;
    public float inAirRatio = 0.6f;

    float verticalRotation = 0;
    CharacterController characterController;
    float verticalVelocity = 0;
       
	// Update is called once per frame
	void Update ()
    {
        #region Rotation

        /*if (Input.GetKeyDown(KeyCode.E))
            {
            Debug.Log("Fucking E key");
            }*/

    float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
    transform.Rotate(0, rotLeftRight, 0);
      
    verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
    verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
    Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    //Camera.mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);   
        #endregion
    #region Movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
            {
            forwardSpeed *= runSpeed;
            }
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

            verticalVelocity += Physics.gravity.y * Time.deltaTime;
            
        if (characterController.isGrounded)
            {
            if (Input.GetButtonDown("Jump"))
                {
                verticalVelocity = jumpSpeed;
                }
            }
        else
            {
                forwardSpeed *= inAirRatio;
                sideSpeed *= inAirRatio;
            }
            Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

            speed = transform.rotation * speed;

            // Simple move doesn't allow for jumping.
            //cc.SimpleMove(speed);
            characterController.Move(speed * Time.deltaTime);

    #endregion
    }

    // Use this for initialization
    void Start()
        {
        Screen.lockCursor = true;
        characterController = GetComponent<CharacterController>();
        }
}