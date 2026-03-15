using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fsm2d : MonoBehaviour
{
    public enum State
    {
        Idle,
        Chase,
        Attack
    }

    public State currentstate;
    public Transform player;
    public float chasedistance = 3f;
    public float attackdistance = 2f;
    public float speed = 2f;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        switch(currentstate)
        {
            case State.Idle:
                if (distance < chasedistance)
                {
                    currentstate = State.Chase;
                }
                break;

            case State.Chase:
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                if (distance < attackdistance)
                {
                    currentstate = State.Attack;
                }
                break;

            case State.Attack:
                Debug.Log("enemy attack on");

                if (distance > attackdistance)
                {
                    currentstate = State.Chase;
                }
                break;
        }
    }
}