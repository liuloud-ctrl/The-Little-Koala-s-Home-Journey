using UnityEngine;

public class ParrotUpDownMovement : MonoBehaviour
{
    [Header("上下移动设置")]
    public float moveHeight = 2.0f;      
    public float moveSpeed = 1.0f;      
    public float waitTime = 0.5f;        

    private Vector3 highPosition;        
    private Vector3 lowPosition;       
    private Vector3 originalPosition;    
    private bool isMovingUp = true;      
    private bool isWaiting = false;     
    private float waitTimer = 0f;        

    void Start()
    {
        
        originalPosition = transform.position;
        
        
        highPosition = originalPosition + Vector3.up * moveHeight;
        lowPosition = originalPosition + Vector3.down * moveHeight;
        
        
        isMovingUp = true;
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
            
            if (isMovingUp)
            {
               
                transform.position = Vector3.MoveTowards(transform.position, 
                    highPosition, moveSpeed * Time.deltaTime);

                
                if (Vector3.Distance(transform.position, highPosition) < 0.01f)
                {
                    isMovingUp = false;  
                    isWaiting = true;    
                }
            }
            else
            {
                
                transform.position = Vector3.MoveTowards(transform.position, 
                    lowPosition, moveSpeed * Time.deltaTime);

               
                if (Vector3.Distance(transform.position, lowPosition) < 0.01f)
                {
                    isMovingUp = true;   
                    isWaiting = true;    
                }
            }
        }
    }

    
    void OnDrawGizmosSelected()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(lowPosition, highPosition);
            Gizmos.DrawWireSphere(lowPosition, 0.2f);
            Gizmos.DrawWireSphere(highPosition, 0.2f);
        }
        else
        {
            Gizmos.color = Color.cyan;
            Vector3 currentPos = transform.position;
            Gizmos.DrawLine(currentPos + Vector3.down * moveHeight, 
                           currentPos + Vector3.up * moveHeight);
            Gizmos.DrawWireSphere(currentPos + Vector3.down * moveHeight, 0.2f);
            Gizmos.DrawWireSphere(currentPos + Vector3.up * moveHeight, 0.2f);
        }
    }
}
