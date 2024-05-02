using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    [SerializeField] private TimeSystem timeSystem;
    private Image spriteRenderer;
    [SerializeField] private List<Sprite> windowImage;
    private void Awake()
    {
        spriteRenderer = GetComponent<Image>();
        timeSystem.AddChangeTimeEvent((time) =>
        {
            spriteRenderer.sprite = windowImage[(int)time];
        });
    }
}
