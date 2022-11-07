using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range (0f, 1f)]float shootingVolume = 1f;
    [Header("Damage Recieved")]
    [SerializeField] AudioClip ExplosionClip;
    [SerializeField] AudioClip projectileHitClip;
    [SerializeField] [Range (0f, 1f)]float damageVolume = 1f;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }
    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip,cameraPos,volume);
        }
    }
    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void ExplodeSFX()
    {
        PlayClip(ExplosionClip,damageVolume);
    }
    public void ProjectileHitSFX()
    {
        PlayClip(projectileHitClip, damageVolume);
    }
    public void MuteAudio()
    {
        audioSource.mute = !audioSource.mute;
    }
    
}
