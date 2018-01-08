using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    // скорость объекта
    public Vector2 speed = new Vector2(2, 0);

    // напраавление движения
    public Vector2 direction = new Vector2(1, 0);

    private Vector2 movement;

    private Rigidbody2D rg2D_obj;


    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        rg2D_obj = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // перемещение
        movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y);

    }

    void FixedUpdate()
    {
        // перемещение объекта
        rg2D_obj.velocity = movement;
    }
}