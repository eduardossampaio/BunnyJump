using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCollectable : Collectable
{
    
    [SerializeField] private AudioSource onCollectAudio;

    private Renderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    override public void OnCollect()
    {
        if (onCollectAudio != null)
        {
            onCollectAudio.Play();
        }
        
        spriteRenderer.enabled = false;
        Destroy(gameObject, 0.5f);
    }

    public override int Value()
    {
        return 10;
    }
}
