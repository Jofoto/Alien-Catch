using UnityEngine;

public class Alien : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){

            GameManager.instance.IncrementScore(); //when alien collides with player, score++ 
            Destroy(gameObject);
        }
        else if(collider.gameObject.tag == "Boundary"){
            GameManager.instance.DecreaseLife(); //when alien collides with boundary, decrease life
            Destroy(gameObject);
        }
    }
}
