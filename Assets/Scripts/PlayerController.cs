using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    [SerializeField] float moveSpeed;
    [SerializeField]  float maxPos;

    void Start()
    {
        
    }

    void Update()
    {
        if(canMove){
            Move();
        }
    }

    private void Move(){
       float inputX = Input.GetAxis("Horizontal");
       
       transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;

       float xPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos); // to restrict player movement w boundaries

       transform.position = new Vector3(xPos, transform.position.y, transform.position.z); // leave y,z positions UNCHANGED
    }
}
