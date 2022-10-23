

using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyBehavior : MonoBehaviour
{
    public Camera cam;
    public GameObject moneySpritePrefab;
    public Canvas canvas;
    

    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        if (canvas == null)
        {
            canvas = GameManager.Instance.canvas;
        }

        //transform.LeanRotate(transform.position, -1).setLoopType(LeanTweenType.easeInCirc);
        transform.DORotate(new Vector3(270, 270, 360), 2f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
        //transform.Rotate(transform.up*Time.deltaTime);
    }
    

    private void MoveMoneySprite()
    {
        
        var moneyPos = cam.WorldToScreenPoint(transform.position);
        var moneySprite = Instantiate(moneySpritePrefab,canvas.transform);
        moneySprite.transform.position = moneyPos;
        moneySprite.transform.LeanMove(new Vector2(1275, 850), 1f).setEase(LeanTweenType.easeInQuart)
            .setDestroyOnComplete(true);
    }
    
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (!collision.gameObject.CompareTag("Player")) return;
    //     gameObject.SetActive(false);
    //     GameManager.Instance.UpdateScore();
    //     MoveMoneySprite();
    //
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Circle")) return;
        gameObject.SetActive(false);
        GameManager.Instance.UpdateScore();
        MoveMoneySprite();

    }
}
