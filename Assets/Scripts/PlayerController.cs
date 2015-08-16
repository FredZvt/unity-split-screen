using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public KeyCode JumpKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;
    public float JumpForce = 1f;
    public float MoveForce = 1f;
    public float maxSpeed = 10f;
    
    private bool paused = false;
    private Rigidbody2D Body;
    private Vector2 savedVelocity;
    private float savedAngularVelocity;
    
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!paused) 
        {
            if (Input.GetKeyDown(JumpKey))
                Body.AddForce(new Vector2(0, JumpForce));
            
            if (Input.GetKey(LeftKey))
                Body.AddForce(new Vector2(-MoveForce, 0));
            
            if (Input.GetKey(RightKey))
                Body.AddForce(new Vector2(MoveForce, 0));
        
            if (Mathf.Abs(Body.velocity.x) > maxSpeed || 
                Mathf.Abs(Body.velocity.y) > maxSpeed) 
                Body.velocity = Body.velocity.normalized * maxSpeed;
        }
    }
    
    public void Pause()
    {
        paused = true;
        savedVelocity = Body.velocity;
        savedAngularVelocity = Body.angularVelocity;
        Body.isKinematic = true;
    }
    
    public void Unpause()
    {
        paused = false;
        Body.isKinematic = false;        
        Body.AddForce(savedVelocity, ForceMode2D.Impulse);
        Body.AddTorque(savedAngularVelocity, ForceMode2D.Force);
        Body.WakeUp();
    }
}
