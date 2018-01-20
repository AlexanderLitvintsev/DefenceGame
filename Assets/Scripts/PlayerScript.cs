using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {


    public Vector2 speed = new Vector2(50, 50);


    private Vector2 movement;

    private Rigidbody2D rg2D_obj;

    // Use this for initialization
    void Start () {
		
	}

    private void Awake()
    {
        rg2D_obj = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update () {
        // 3 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // 4 - Movement per direction
        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

        // 5 - Shooting
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");


        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
            }
        }

        // 6 - Make sure we are not outside the camera bounds
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );

        // End of the update method


    }


    void FixedUpdate()
    {
        // перемещение объекта
        rg2D_obj.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        // Столкновение с врагом
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            // Смерть врага
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

            damagePlayer = true;
        }

        // Повреждения у игрока
        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null) playerHealth.Damage(1);
        }
    }

}
