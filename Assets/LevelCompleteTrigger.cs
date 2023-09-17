using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    [SerializeField] ParticleSystem levelWonParticleEff;

    bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered)
            return;

        if(other.CompareTag("Player"))
        {
            LevelCompleted();
            triggered = true;
        }
        else if(other.CompareTag("Enemy"))
        {
            LevelFailed();
            triggered = true;
        }
    }

    public void LevelCompleted()
    {
        if (levelWonParticleEff != null)
            levelWonParticleEff.Play();
        LevelManager.instance.GameOver();
        UIManager.instance.LevelCompleted();
    }
    public void LevelFailed()
    {
        LevelManager.instance.GameOver();
        UIManager.instance.LevelFailed();
    }
}
