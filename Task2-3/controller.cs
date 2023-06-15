using System.Collections;
using UnityEngine;

public class controller : MonoBehaviour{

    public Joystick playerJoystick;
    public Camera playerCamera;
    public Transform gunTransform, aimTransform;
    private Rigidbody body;
    private Animator playerAnimator;

    public bool isGrounded;
    public bool isRunning;
    public float speed, walkSpeed, runSpeed, rotationSpeed;
    public float jumpForce;
    private float vertical;
    private float horizontal;
    
    public GameObject bulletPrefab;
    public float reload, sensivity;
    public bool reloading = false, aiming = false;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        
        playerAnimator.SetTrigger("isStaying");
    }

    private void Update(){
        if(aiming){
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, 35f, Time.fixedDeltaTime*sensivity);
        }
        else{
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, 60f, Time.fixedDeltaTime*sensivity);
        }
    }
    void FixedUpdate()
    {
        if(isGrounded && !aiming){
            
            vertical = playerJoystick.Vertical;
            horizontal = playerJoystick.Horizontal;
        
            if(vertical != 0){
                playerAnimator.ResetTrigger("isStaying");
                if(isRunning){
                    playerAnimator.SetTrigger("isRunning");
                    playerAnimator.ResetTrigger("isWalking");

                    speed = runSpeed;
                }
                else{
                    playerAnimator.SetTrigger("isWalking");
                    playerAnimator.ResetTrigger("isRunning");

                    speed = walkSpeed;
                }
                Vector3 velocity = (transform.forward * vertical) * speed * Time.fixedDeltaTime;
                velocity.y = body.velocity.y;
                body.velocity = velocity;

                transform.Rotate((transform.up * horizontal) * rotationSpeed * Time.fixedDeltaTime);
            }
            else if (horizontal != 0)
            {
                transform.Rotate((transform.up * horizontal) * rotationSpeed * Time.fixedDeltaTime);
            }   
            else if(isGrounded){
                playerAnimator.ResetTrigger("isRunning");
                playerAnimator.ResetTrigger("isWalking");
                playerAnimator.SetTrigger("isStaying");
            }
        }
    }
    public void shootClick(){
        reloading = true;

        playerAnimator.Play("shoot");
        playerAnimator.SetTrigger("isShooting");
        playerAnimator.ResetTrigger("isAiming");
    }
    public void aimClick(){
        if(!reloading && !aiming){
            aiming = true;

            playerAnimator.SetTrigger("isAiming");
            playerAnimator.ResetTrigger("isWalking");
            playerAnimator.ResetTrigger("isJumping");
            playerAnimator.ResetTrigger("isRunning");
            playerAnimator.ResetTrigger("isStaying");

            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, 35f, Time.fixedDeltaTime*sensivity);
        }
        else{
            aiming = false;

            playerAnimator.ResetTrigger("isAiming");

            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, 60f, Time.fixedDeltaTime*sensivity);
        }
    }
    public void runClick(){
        isRunning = !isRunning;
    }
    public void jumpClick(){
        body.AddForce(transform.up * jumpForce);
    }
    public IEnumerator shoot(){
        GameObject axe = Instantiate(bulletPrefab, gunTransform.position, Quaternion.identity) as GameObject;
        axe.transform.LookAt(aimTransform);

        playerAnimator.ResetTrigger("isShooting");

        yield return new WaitForSeconds(reload);

        if(aiming){
            playerAnimator.SetTrigger("isAiming");
        }

        reloading = false;
    }
   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            playerAnimator.ResetTrigger("isJumping");

            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = false;

            playerAnimator.SetTrigger("isJumping");
            playerAnimator.ResetTrigger("isRunning");
            playerAnimator.ResetTrigger("isWalking");
            playerAnimator.ResetTrigger("isStaying");
        }
    }
}