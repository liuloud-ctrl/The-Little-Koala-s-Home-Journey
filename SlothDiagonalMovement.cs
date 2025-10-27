using UnityEngine;

public class SlothDiagonalMovement : MonoBehaviour
{
    [Header("斜向下移动设置")]
    public Vector2 moveDirection = new Vector2(1, -1); 
    public float moveDistance = 3.0f;                 
    public float moveDuration = 2.0f;                  
    public bool moveOnStart = true;                   

    private Vector3 startPosition;                     
    private Vector3 targetPosition;                    
    private bool isMoving = false;                    
    private float moveTimer = 0f;                      

    void Start()
    {
       
        startPosition = transform.position;
        
        
        moveDirection.Normalize();
        
        
        targetPosition = startPosition + new Vector3(moveDirection.x, moveDirection.y, 0) * moveDistance;

        
        if (moveOnStart)
        {
            StartMovement();
        }
    }

    void Update()
    {
        if (isMoving)
        {
            
            moveTimer += Time.deltaTime;

            
            float progress = Mathf.Clamp01(moveTimer / moveDuration);
            
            
            transform.position = Vector3.Lerp(startPosition, targetPosition, progress);

            
            if (progress >= 1f)
            {
                isMoving = false;
                OnMovementComplete();
            }
        }
    }

    
    public void StartMovement()
    {
        if (!isMoving)
        {
            isMoving = true;
            moveTimer = 0f;
            startPosition = transform.position;
            targetPosition = startPosition + new Vector3(moveDirection.x, moveDirection.y, 0) * moveDistance;
        }
    }

    
    private void OnMovementComplete()
    {
        Debug.Log("树懒移动完成！");
        
    }

    
    void OnDrawGizmosSelected()
    {
        if (Application.isPlaying && isMoving)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(startPosition, targetPosition);
            Gizmos.DrawWireSphere(startPosition, 0.2f);
            Gizmos.DrawWireSphere(targetPosition, 0.2f);
        }
        else
        {
            Gizmos.color = Color.yellow;
            Vector3 currentPos = transform.position;
            Vector3 endPos = currentPos + new Vector3(moveDirection.x, moveDirection.y, 0) * moveDistance;
            Gizmos.DrawLine(currentPos, endPos);
            Gizmos.DrawWireSphere(currentPos, 0.2f);
            Gizmos.DrawWireSphere(endPos, 0.2f);
        }
    }
}