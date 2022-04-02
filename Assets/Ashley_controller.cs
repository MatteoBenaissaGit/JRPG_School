using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ashley_controller : MonoBehaviour
{
    public float MoveForce = 20;
    public Rigidbody2D Idle_Ashley;
    public Animator Animator;

    void Start()
    {
        
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical);

        
    }

    private void FixedUpdate()
    {
        if (m_direction.magnitude > 0.1f)
        {
            m_direction.Normalize();
            Idle_Ashley.AddForce(m_direction * MoveForce);
            Animator.SetBool("walking", true);
        }
        else
            Animator.SetBool("walking", false);
    }

    Vector2 m_direction;

}
