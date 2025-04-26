using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float shiftSspeed = 10f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Animator anim;
    private int health;
    float stamina = 5f;
    bool isGrounded = true;
    float currentSpeed;
    bool jumpRequest = false;
    float personLVL = 1;
    Rigidbody rb;
    Vector3 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        currentSpeed = movementSpeed;
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);
        if (direction.x != 0 || direction.z != 0)
        {
            anim.SetBool("Run", true);
        }
        if (direction.x == 0 && direction.z == 0)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Sprint", false);
        }



        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                stamina -= Time.deltaTime;
                anim.SetBool("Run", false);
                anim.SetBool("Sprint", true);
                currentSpeed = shiftSspeed;


            }
            else
            {
                anim.SetBool("Sprint", false);
                anim.SetBool("Run", true);
                currentSpeed = movementSpeed;
            }
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime;
            anim.SetBool("Sprint", false);
            currentSpeed = movementSpeed;
        }
        if (stamina > 5f)
        {
            stamina = 5f;
        }
        else if (stamina < 0)
        {
            stamina = 0;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (direction.x != 0 || direction.z != 0)
            {
                anim.SetBool("Jumprun", true);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                isGrounded = false;
            }
            if (direction.x == 0 && direction.z == 0)
            {
                anim.SetBool("Jump", true);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                isGrounded = false;
            }


        }

    }

    void OnCollisionEnter(Collision Collision)
    {
        isGrounded = true;
        anim.SetBool("Jump", false);
        anim.SetBool("Jumprun", false);
    }


    public void ChangeHealth(int count)
    {
        //вычитаем здоровье
        health -= count;
        //если здоровье меньше либо равно нулю, то...
        if (health <= 0)
        {
            //јктивируем анимацию смерти
            //anim.SetBool("Die", true);
            //отключаем скрипт PlayerController, чтобы персонаж не мог передвигатьс€
            this.enabled = false;
        }
    }
}

