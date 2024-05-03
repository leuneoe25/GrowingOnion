using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotweenTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f),0.5f).SetLoops(-1,LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
