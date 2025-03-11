using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class Hero : Unit
{
    //переменная для установки макс. скорости персонажа
    public float speed = 3f;
    //переменная для определения направления персонажа вправо/влево
    private bool isFacingRight = true;
    //находится ли персонаж на земле или в прыжке?
    private bool isGrounded = false;
    //ссылка на компонент Transform объекта для определения соприкосновения с землей
    public Transform CheckGround; // для защиты от бесконечных прыжков
                                  //установка силы прыжка
    float jumpForce = 12.4f;
    //установка количества жизней
    private int lives = 5;
    Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float move;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        //определяем на земле ли персонаж
        Collider2D[] collider = Physics2D.OverlapCircleAll(CheckGround.position, 0.1f);
        isGrounded = collider.Length > 1;
        move = Input.GetAxis("Horizontal");
        if (move > 0 && !isFacingRight)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (move < 0 && isFacingRight)
            Flip();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal")) Run();  //  если нажата клавиша бега - бежим
        if (isGrounded && Input.GetButtonDown("Jump")) Jump(); //  если нажата клавиша прыжка и персонаж на земле - прыгаем
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 10.0f); //  защита от слишком высоких прыжков (постоянно ограничиваем ускорение)
    }

    void Run()  // функция бега
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }

    void Jump()  // функция прыжка
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Flip()  // функция отражения картинки
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= 0;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}