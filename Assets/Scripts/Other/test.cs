// private float coyoteTimeCounter = 0; 
// [SerializeField] private float coyoteTime; 
//
// void UpdateJumpVariables()
// {
//     if (Grounded())
//     {
//         pState.jumping = false;
//         coyoteTimeCounter = coyoteTime;
//         airJumpCounter = 0;
//     }
//     else
//     {
//         coyoteTimeCounter -= Time.deltaTime;
//     }
//
//     if (Input.GetButtonDown("Jump"))
//     {
//         jumpBufferCounter = jumpBufferFrames;
//     }
//     else
//     {
//         jumpBufferCounter = jumpBufferCounter - Time.deltaTime * 10;
//     // }
// }
//
// private float jumpBufferCounter = 0;
// [SerializeField] private float jumpBufferFrames; 
//
// void UpdateJumpVariables()
// {
//     // ... (Coyote Time)
//
//     if (Input.GetButtonDown("Jump"))
//     {
//         jumpBufferCounter = jumpBufferFrames;
//     }
//     else
//     {
//         jumpBufferCounter -= Time.deltaTime * 10;
//     }
// }
//
// void Jump()
// {
//     if (jumpBufferCounter > 0 && coyoteTimeCounter > 0 && !pState.jumping)
//     {
//         rb.velocity = new Vector3(rb.velocity.x, jumpForce);
//         pState.jumping = true;
//     }
// }
