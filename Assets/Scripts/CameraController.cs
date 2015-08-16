using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector2 stageBottomLeft = new Vector2(-4.712282f, -7.241384f);
    public Vector2 stageTopRight =  new Vector2(4.677763f, 25.06674f);
    
    private bool paused = false;
        
    void Start()
    {
        var targetPosition = CopyVector(target.position);
        var constrainedPosition = ConstrainCameraToStage(targetPosition);
        transform.position = constrainedPosition;
    }
    
    void Update()
    {
        if (!paused) {
            var targetPosition = CopyVector(target.position);
            var constrainedPosition = ConstrainCameraToStage(targetPosition);
            transform.position = SmoothMovement(constrainedPosition);
        }
    }
    
    public void Pause()
    {
        this.paused = true;
    }
    
    public void Unpause()
    {
        this.paused = false;
    }    
    
    private Vector3 CopyVector(Vector3 v)
    {
        return new Vector3(v.x, v.y, -10f);
    }
    
    private Vector3 SmoothMovement(Vector3 targetPosition)
    {
        return Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
    }
    
    private Vector3 ConstrainCameraToStage(Vector3 targetPosition)
    {
        var constrainedTargetPosition = targetPosition;
    
        if (targetPosition.x > stageTopRight.x)
            constrainedTargetPosition.x = stageTopRight.x;
        else if (targetPosition.x < stageBottomLeft.x)
            constrainedTargetPosition.x = stageBottomLeft.x;
        
        if (targetPosition.y > stageTopRight.y)
            constrainedTargetPosition.y = stageTopRight.y;
        else if (targetPosition.y < stageBottomLeft.y)
            constrainedTargetPosition.y = stageBottomLeft.y;
            
        return constrainedTargetPosition;
    }
}
