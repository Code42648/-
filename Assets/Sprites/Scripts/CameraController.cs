using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private Transform target;

    private void Awake()
    {
        if (!target) target = FindObjectOfType<Hero>().transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = target.position;
        position.z = -10.0f;
        position.y = 0.0f;
        transform.position = position;
    }
}
