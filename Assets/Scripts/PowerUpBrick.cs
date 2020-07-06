using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]

public class PowerUpBrick : Brick
{
    Animator _animator;

    private void OnEnable()
    {
        _animator = this.GetComponent<Animator>();
    }

    public override void TakeDamage(int ammount)
    {
        if (ammount > hitsToBreak)
        {

            //Ask the Pool Prefab of particles to PlayOne
            //Particle Manager Play
            //Sound Manager Play
            if (OnBrickBroken != null)
            {
                OnBrickBroken(this);
            }
            Destroy(this.gameObject);

        }
        AudioManager.PlaySoundEffect(AudioAssets.Soundeffects.BrickHit, this.transform.position, 0.25f);

        hitsToBreak -= ammount;
        UpdateVisuals();

        _animator.SetTrigger("Wobble");
        if (OnBrickHit != null)
        {
            OnBrickHit(this);
        }
    }

    protected override void UpdateVisuals()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }
}
