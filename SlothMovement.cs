using UnityEngine;

public class SlothMovement : MonoBehaviour
{
    [Header("移动设置")]
    public float moveDistance = 1.0f;   
    public float moveSpeed = 2.0f;       
    public float waitTime = 2.0f;        

    private Vector3 originalPosition;    
    private bool isMovingUp = false;     
    private bool isMovingDown = false;   
    private float timer = 0f;            

    void Start()
    {
        
        originalPosition = transform.position;
    }

    void Update()
    {
        
        timer += Time.deltaTime;

        
        if (timer >= waitTime && !isMovingUp && !isMovingDown)
        {
            isMovingUp = true;
            timer = 0f;  
        }

       
        if (isMovingUp)
        {
            
            Vector3 targetPosition = originalPosition + Vector3.up * moveDistance;
            
            
            transform.position = Vector3.MoveTowards(transform.position, 
                targetPosition, moveSpeed * Time.deltaTime);

           
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMovingUp = false;    
                isMovingDown = true;  
            }
        }

       
        if (isMovingDown)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, 
                originalPosition, moveSpeed * Time.deltaTime);

            
            if (Vector3.Distance(transform.position, originalPosition) < 0.01f)
            {
                isMovingDown = false;  
                
            }
        }
    }
}