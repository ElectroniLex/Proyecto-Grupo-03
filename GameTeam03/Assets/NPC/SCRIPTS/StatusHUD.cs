using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusHUD : MonoBehaviour
{
    public PlayerRPG m_PlayerRPG;

    public StatusBar experienceBar;
    public HealthBar healthBar;
    public StatusBar manaBar;

    public float expTimer;

    // Start is called before the first frame update
    private void Start()
    {
        experienceBar.ChangeMaxvalue(PlayerRPG.MAX_EXPERIENCE);
        healthBar.ChangeMaxvalue(m_PlayerRPG.health.maxValue);
        manaBar.ChangeMaxvalue(m_PlayerRPG.mana.maxValue);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time.time > expTimer)
        {
            expTimer = Time.time + 0.1f;
            m_PlayerRPG.AddExperience(5);
        }

        experienceBar.UpdateInfo(m_PlayerRPG.experience);
        healthBar.UpdateInfo(m_PlayerRPG.health.currentValue);
        manaBar.UpdateInfo(m_PlayerRPG.mana.currentValue);
    }
}
