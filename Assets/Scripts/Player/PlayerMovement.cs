using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Properties")]
    public bool canMove = true;
    [SerializeField] public float speed = 12f;
    [SerializeField] protected float acceleration = 9;
    [SerializeField] protected float decceleration = 15;
    [SerializeField] [Range(0, 1)] protected float friction = 0.2f;
    [SerializeField] [Range(0, 1)] protected float accelerationInAir = 0.7f;
    [SerializeField] [Range(0, 1)] protected float deccelerationInAir = 1;
    [SerializeField] [Range(.5f, 1f)] protected float turnPower = 1;
    [SerializeField] [Range(.5f, 1f)] protected float accelerationPower = 1;

    [Header("Jump Properties")]
    [SerializeField] public float jumpForce = 42f;
    [SerializeField] [Range(1, 10)] protected float lowJumpMultiplier = 3f;
    [SerializeField] [Range(0, 1)] protected float highJumpMultiplier = 0.7f;

    [Tooltip("Позволяет нажать кнопку прыжка раньше приземления на землю.")]
    [SerializeField] [Range(0, 0.5f)] protected float jumpBufferTime = 0.12f;

    [Tooltip("Позволяет \"пройтись по воздуху\" и все равно прыгнуть.")]
    [SerializeField] [Range(0, 0.5f)] protected float jumpCoyoteTime = 0.08f;

    [Header("Ground Check Properties")]
    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private LayerMask groundLayer;



    // Public properties
    public bool IsGrounded { get; private set; }
    public bool IsJumping { get; protected set; }
    public bool IsInputXZero => inputX == 0f;

    // Protected variables
    protected Player player;
    protected PlayerControls input;
    protected Rigidbody2D rb;

    protected float inputX = 0f;
    protected float smoothInputVelocity = 0f; // не нужно ?

    protected float defaultForce;
    protected float jumpBufferCounter;
    protected float jumpCoyoteCounter;
    protected bool isJumpHolding;



    // ==================================================
    // Awake & Start
    // ==================================================
    protected virtual void Awake()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        defaultForce = rb.gravityScale;
    }

    void Start()
    {
        // Input System
        input = InputManager.Input;
        input.Player.Jump.performed += Jump_performed;
    }



    // ==================================================
    // Update
    // ==================================================
    void Update()
    {
        if (!canMove)
            return;

        inputX = GetInputX();
        Flip();

        isJumpHolding = input.Player.Jump.IsPressed();



        // Jump coyoteTime timer
        if (CheckGround() && !IsJumping)
        {
            jumpCoyoteCounter = jumpCoyoteTime;
        }
        else if (jumpCoyoteCounter > 0f)
            jumpCoyoteCounter -= Time.deltaTime;

        // Jump bufferTime timer
        if (jumpBufferCounter > 0f)
            jumpBufferCounter -= Time.deltaTime;
    }



    // ==================================================
    // FixedUpdate
    // ==================================================
    void FixedUpdate()
    {
        if (!canMove)
            return;

        Move();

        // isGrounded учитывается (для Кости)
        if (jumpBufferCounter > 0f && jumpCoyoteCounter > 0f && !IsJumping)
        {
            //IsJumping = true;
            Jump();
        }
        JumpAdjustment();

        if (Math.Abs(rb.velocity.x) > speed)
        {
            //rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speed, speed), rb.velocity.y);
            rb.AddForce(new Vector2(-rb.velocity.x, 0), ForceMode2D.Force);
        }
    }



    // ==================================================
    //						Methods
    // ==================================================

    #region MOVING
    protected virtual void Move()
    {
        float compensateFrictionSpeed = 6.25f * friction;
        float targetSpeed = inputX * (speed + compensateFrictionSpeed); // direction and desired velocity
        float speedDif = targetSpeed - rb.velocity.x; // difference between current and desired velocity

        if (Math.Abs(speedDif) < 0.01f) speedDif = 0;

        #region Acceleration Rate
        float accelRate;

        // gets an acceleration value based on if we are accelerating (includes turning) or trying to decelerate (stop).
        // As well as applying a multiplier if we're air borne
        if (jumpCoyoteCounter > 0)
        {
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;

            Vector2 frictionForce = friction * rb.velocity.normalized;

            // ensures we only slow the player down, if the player is going really slowly we just apply a force stopping them
            frictionForce.x = Mathf.Min(Mathf.Abs(rb.velocity.x), Mathf.Abs(frictionForce.x));
            frictionForce.y = Mathf.Min(Mathf.Abs(rb.velocity.y), Mathf.Abs(frictionForce.y));
            frictionForce.x *= Mathf.Sign(rb.velocity.x); // finds direction to apply force
            frictionForce.y *= Mathf.Sign(rb.velocity.y);

            rb.AddForce(-frictionForce, ForceMode2D.Impulse);
        }
        else
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration * accelerationInAir : decceleration * deccelerationInAir;

        // if we want to run but are already going faster than max run speed
        if ((rb.velocity.x > targetSpeed && targetSpeed > 0.01f) || (rb.velocity.x < targetSpeed && targetSpeed < -0.01f))
        {
            accelRate = 0; // prevent any deceleration from happening, or in other words conserve are current momentum
        }
        #endregion

        #region Velocity Power
        float velPower;
        // if rotating
        if (Mathf.Abs(rb.velocity.x) > 0 && (Mathf.Sign(targetSpeed) != Mathf.Sign(rb.velocity.x)))
        {
            velPower = turnPower;
        }
        else
        {
            velPower = accelerationPower;
        }
        #endregion

        // applies acceleration to speed difference, then is raised to a set power so the acceleration increases with higher speeds, finally multiplies by sign to preserve direction
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        movement = Mathf.Lerp(rb.velocity.x, movement, 1); // lerp so that we can prevent the Run from immediately slowing the player down, in some situations eg wall jump, dash 

        rb.AddForce(movement * Vector2.right);

        if (Math.Abs(rb.velocity.x) < 0.01f) rb.velocity = new Vector2(0, rb.velocity.y);

        //Debug.Log(speedDif);
        /// Старое
        //Vector2 velocity = inputX * speed * transform.right;
        //Vector2 fallingVelocity = new Vector2(0, rb.velocity.y);
        //velocity += fallingVelocity;

        //if (velocity.magnitude > speed && IsGrounded)
        //{
        //	velocity = velocity.normalized * speed;
        //}
        //rb.velocity = velocity;
    }

    protected virtual float GetInputX()
    {
        return input.Player.Move.ReadValue<Vector2>().x;
    }

    private void Flip()
    {
        if (inputX != 0f)
        {
            FlipBody(inputX > 0);
        }
    }

	public void FlipBody(bool toTheRight)
	{
		int xScale = Convert.ToInt32(toTheRight) * 2 - 1;
		transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
	}

	public bool CheckGround()
    {
        return IsGrounded = groundCheck.IsTouchingLayers(groundLayer);
    }
    #endregion



    #region JUMPING
    public virtual void Jump()
    {
        IsJumping = true;
        // Обнуление скорости по y для того, чтобы не было "мини прыжка" при прыжке сразу после падения
        rb.velocity = new Vector2(rb.velocity.x, 0f);

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        jumpBufferCounter = 0f;
        jumpCoyoteCounter = 0f;
        IsGrounded = false;
    }

    private void Jump_performed(InputAction.CallbackContext context)
    {
        // Jump bufferTime handle
        jumpBufferCounter = jumpBufferTime;
    }



    // ==================================================
    // Jump Adjustment
    // ==================================================
    protected virtual void JumpAdjustment()
    {
        // Увеличение гравитации при падении вниз или при коротком прыжке (без удерживания клавиши)
        if (IsJumping && rb.velocity.y > 0f)
        {
            if (isJumpHolding)
                SetGravityScale(defaultForce * highJumpMultiplier); // High Jump			
            else
                SetGravityScale(defaultForce * lowJumpMultiplier); // Low Jump
        }
        else
        {
            SetGravityScale(defaultForce); // is Falling
            IsJumping = false;
        }

        // Ограничение макс. скорости по Y
        var maxSpeedY = jumpForce / 2f;

        if (rb.velocity.y > maxSpeedY && rb.velocity.y > 0f && canMove)
            rb.velocity = new Vector2(rb.velocity.x, maxSpeedY);
    }
    #endregion



    protected virtual void SetGravityScale(float scale)
    {
        rb.gravityScale = scale;
    }
}
