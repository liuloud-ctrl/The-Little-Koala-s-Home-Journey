using UnityEngine;

public class ParrotMovement : MonoBehaviour
{
    [Header("移动设置")]
    public float moveDistance = 3.0f;    
    public float moveSpeed = 1.5f;       
    public float waitTime = 1.0f;        

    private Vector3 leftPosition;        
    private Vector3 rightPosition;       
    private Vector3 originalPosition;    
    private bool isMovingRight = true;   
    private bool isWaiting = false;      
    private float waitTimer = 0f;        

    void Start()
    {
        
        originalPosition = transform.position;
        
        
        leftPosition = originalPosition + Vector3.left * moveDistance;
        rightPosition = originalPosition + Vector3.right * moveDistance;
        
       
        isMovingRight = true;
    }

    void Update()
    {
        if (isWaiting)
        {
            
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                isWaiting = false;
                waitTimer = 0f;
            }
        }
        else
        {
            
            if (isMovingRight)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, 
                    rightPosition, moveSpeed * Time.deltaTime);

                
                if (Vector3.Distance(transform.position, rightPosition) < 0.01f)
                {
                    isMovingRight = false;  
                    isWaiting = true;       
                }
            }
            else
            {
                
                transform.position = Vector3.MoveTowards(transform.position, 
                    leftPosition, moveSpeed * Time.deltaTime);

                
                if (Vector3.Distance(transform.position, leftPosition) < 0.01f)
                {
                    isMovingRight = true;  
                    isWaiting = true;       
                }
            }
        }
    }

   
    void OnDrawGizmosSelected()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(leftPosition, rightPosition);
            Gizmos.DrawWireSphere(leftPosition, 0.3f);
            Gizmos.DrawWireSphere(rightPosition, 0.3f);
        }
        else
        {
            Gizmos.color = Color.red;
            Vector3 currentPos = transform.position;
            Gizmos.DrawLine(currentPos + Vector3.left * moveDistance, 
                           currentPos + Vector3.right * moveDistance);
            Gizmos.DrawWireSphere(currentPos + Vector3.left * moveDistance, 0.3f);
            Gizmos.DrawWireSphere(currentPos + Vector3.right * moveDistance, 0.3f);
        }
    }
}