using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource wbcWalkSFX;
    public AudioSource wbcRollSFX;
    public AudioSource wbcAttack1SFX;
    public AudioSource wbcAttack2SFX;
    public AudioSource wbcAttack3SFX;
    public AudioSource wbcCritSFX;

    public AudioSource tbcPunchSFX;
    public AudioSource tbcShootSFX;
    public AudioSource tbcLightSwingSFX;
    public AudioSource tbcHeavySwingSFX;
    public AudioSource bossSlamSFX;
    public AudioSource bossJumpSFX;
    public AudioSource bossGrowlSFX;

    public AudioSource gameOverSFX;
    public AudioSource levelUpSFX;
    public AudioSource stageClearSFX;
    public AudioSource talentShowSFX;
    public AudioSource pickTalentSFX;

    public void wbcWalkSound()
    {
        wbcWalkSFX.Play();
    }
    public void wbcRollSound()
    {
        wbcRollSFX.Play();
    }
    public void wbcAttack1Sound()
    {
        wbcAttack1SFX.Play();
    }
    public void wbcAttack2Sound()
    {
        wbcAttack2SFX.Play();
    }
    public void wbcAttack3Sound()
    {
        wbcAttack3SFX.Play();
    }
    public void wbcCritSound()
    {
        wbcCritSFX.Play();
    }
    public void tbcPunchSound()
    {
        tbcPunchSFX.Play();
    }
    public void tbcShootSound()
    {
        tbcShootSFX.Play();
    }
    public void tbcLightSwingSound()
    {
        tbcLightSwingSFX.Play();
    }
    public void tbcHeavySwingSound()
    {
        tbcHeavySwingSFX.Play();
    }
    public void bossSlamSound()
    {
        bossSlamSFX.Play();
    }
    public void bossJumpSound()
    {
        bossJumpSFX.Play();
    }
    public void bossGrowlSound()
    {
        bossGrowlSFX.Play();
    }
    public void gameOverSound()
    {
        gameOverSFX.Play();
    }
    public void levelUpSound()
    {
        levelUpSFX.Play();
    }
    public void stageClearSound()
    {
        stageClearSFX.Play();
    }
    public void talentShowSound()
    {
        talentShowSFX.Play();
    }
    public void pickTalentSound()
    {
        pickTalentSFX.Play();
    }
}
