using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{

    
    public int hp = 1;
    
    public bool isEnemy = true;
    
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            //    gameObject.x = 0;
            //    gameObject.y = 0;
            GetComponent<EnemyScript>().speed.x = 0;
            GetComponent<EnemyScript>().speed.y = 0;
            GetComponent<Animation>().Play("zb_dead1");
            UIScript.GAME_SCORE += 1;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            // Dead!
            Destroy(gameObject, 2f);
            
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {


                Damage(shot.damage);


                // Destroy the shot
                Destroy(shot.gameObject); 
            }
        }
    }
}
