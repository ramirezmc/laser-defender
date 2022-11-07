using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int scoreValue = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    LevelManager levelManager;
    ScoreKeeper scoreKeeper;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            PlayHitEffect();
            audioPlayer.ExplodeSFX();
            Die();
        }
        audioPlayer.ProjectileHitSFX();    
    }

    void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(scoreValue);
        }
        else
        {
            audioPlayer.MuteAudio();
            levelManager.GameOver();
        }
        Destroy(gameObject);
    }
    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
