using UnityEngine;

public class Bomb : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){

            GameManager.instance.DecreaseLife(); //when bomb collides with player, life-- 
            Destroy(gameObject);
        }
    }
}
