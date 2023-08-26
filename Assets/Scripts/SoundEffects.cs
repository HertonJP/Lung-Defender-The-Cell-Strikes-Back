using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource wbcAttackSFX;
    public AudioSource wbcAttack2SFX;
    public AudioSource wbcAttack3SFX;
    public AudioSource wbcWalkSFX;
    public AudioSource wbcRollSFX;
    public AudioSource critDamageSFX;

    public AudioSource virusPunchSFX;
    public AudioSource virusLightSwingSFX;
    public AudioSource virusHeavySwingSFX;
    public AudioSource bossSlamSFX;
    public AudioSource bossJumpSFX;
    public AudioSource bossGrowlSFX;

    public AudioSource levelUpSFX;
    public AudioSource stageClearSFX;
    public AudioSource talentShowUpSFX;
    public AudioSource pickTalentSFX;
    public AudioSource gameOverSFX;

    public void gameOverSound()
    {
        gameOverSFX.Play();
    }
    public void priestWalkSound()
    {
        priestWalkSFX.Play();
    }

    public void necroAttackSound()
    {
        necroAttackSFX.Play();
    }
    public void knigtWalkSound()
    {
        knightWalkSFX.Play();
    }
}
