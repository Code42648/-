using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class Hero : Unit
{
    //���������� ��� ��������� ����. �������� ���������
    public float speed = 3f;
    //���������� ��� ����������� ����������� ��������� ������/�����
    private bool isFacingRight = true;
    //��������� �� �������� �� ����� ��� � ������?
    private bool isGrounded = false;
    //������ �� ��������� Transform ������� ��� ����������� ��������������� � ������
    public Transform CheckGround; // ��� ������ �� ����������� �������
                                  //��������� ���� ������
    float jumpForce = 12.4f;
    //��������� ���������� ������
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
        //���������� �� ����� �� ��������
        Collider2D[] collider = Physics2D.OverlapCircleAll(CheckGround.position, 0.1f);
        isGrounded = collider.Length > 1;
        move = Input.GetAxis("Horizontal");
        if (move > 0 && !isFacingRight)
            //�������� ��������� ������
            Flip();
        //�������� ��������. �������� ��������� �����
        else if (move < 0 && isFacingRight)
            Flip();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal")) Run();  //  ���� ������ ������� ���� - �����
        if (isGrounded && Input.GetButtonDown("Jump")) Jump(); //  ���� ������ ������� ������ � �������� �� ����� - �������
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 10.0f); //  ������ �� ������� ������� ������� (��������� ������������ ���������)
    }

    void Run()  // ������� ����
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }

    void Jump()  // ������� ������
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Flip()  // ������� ��������� ��������
    {
        //������ ����������� �������� ���������
        isFacingRight = !isFacingRight;
        //�������� ������� ���������
        Vector3 theScale = transform.localScale;
        //��������� �������� ��������� �� ��� �
        theScale.x *= 0;
        //������ ����� ������ ���������, ������ �������, �� ��������� ����������
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}