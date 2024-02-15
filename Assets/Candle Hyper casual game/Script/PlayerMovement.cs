using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rd;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float movespeed;
    [SerializeField] private float LeftandRightSpeed;
    [SerializeField] private Vector2 MiniMax;
    public static Action OngameOver;
    private bool isRun;
    public bool isPlay;
    private float time=5;
    // Start is called before the first frame update
    private void Awake() {
        isRun =true;
        isPlay = false;
        rd = GetComponent<Rigidbody>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isRun && isPlay)
            PlayerMove();
        gameOver();
        playerFreegTime();
        // if(transform.position.y <0.10f)
        // {
        //     transform.position =new Vector3(transform.position.x,0.15f,transform.position.z);
        // }
    }

    private void playerFreegTime()
    {
        if (!isRun)
        {
            time += 5 * Time.deltaTime;
            Debug.Log(time);
            if (time >= 10f)
            {
                isRun = true;
                time = 0;
            }
        }
    }
    public void PlayerScale()
    {
         transform.DOScaleY(0,15);
    }

    private void PlayerMove()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MiniMax.x, MiniMax.y),
                transform.position.y, transform.position.z);

        rd.velocity = new Vector3(joystick.Horizontal * LeftandRightSpeed * UnityEngine.Time.deltaTime,
        rd.velocity.y, movespeed * UnityEngine.Time.deltaTime);
        Debug.Log("Play");
    }
    private void gameOver()
    {
        if(transform.localScale.y <= 0.01f)
        {
            DOTween.Kill(transform);
            Debug.Log("Game Over");
            OngameOver?.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "CandlePlaus")
        {
            Destroy(other.gameObject);
            DOTween.Kill(transform);
            transform.DOScaleY(1.2f,1).OnComplete(() => {
                transform.DOScaleY(0,13);
            });
        }
        if(other.tag == "object")
        {
            Destroy(other.gameObject);
            isRun = false;
        }
    }

}
