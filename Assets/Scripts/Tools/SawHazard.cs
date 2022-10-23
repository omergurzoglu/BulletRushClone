
using DG.Tweening;
using UnityEngine;

public class SawHazard : MonoBehaviour
{
 
      
    
    private void Start()
    {
        transform.DOMove(transform.forward*20, 2.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Flash).SetRelative();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer is 3)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
