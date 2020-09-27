using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    // Always public
    public double maxHealth;
    public bool allowOverheal, healByFrame;

    // Should be private
    private double currentHealth, healPerCycle, dmgPerCycle;
    private bool isOverhealed;
    private int healingFrame, dmgFrame, healFramesPerCycle, dmgFramesPerCycle;


    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
        healingFrame = 0;
        dmgFrame = 0;

        healByFrame = true;
        allowOverheal = true;
        isOverhealed = false;

        healPerCycle = 2.5;
        dmgPerCycle = 5;

        healFramesPerCycle = 60;
        dmgFramesPerCycle = 60;
        
        print(string.Format("Starting with {0} HP with a max of {1}", currentHealth, maxHealth));
        print(string.Format("Overhealing is {0}", allowOverheal));

    }

    // Update is called once per frame
    void FixedUpdate() {
        //print(isOverhealed);

        if (currentHealth > maxHealth && allowOverheal) {
            isOverhealed = true;
        }
        else if (currentHealth <= maxHealth) {
            isOverhealed = false;
        }

        if (healByFrame && !isOverhealed) {
            healingFrame += 1;
            if (healingFrame%healFramesPerCycle == 0) {
                print(",");
                heal(healPerCycle, true);
                healingFrame = 0;
            }
        }
        if (isOverhealed && allowOverheal) {
            dmgFrame += 1;
            if (dmgFrame%dmgFramesPerCycle == 0) {
                print("Damage taken! " + dmgPerCycle);
                takeDamage(dmgPerCycle, true);
                dmgFrame = 0;
            }
        }
    }

    void takeDamage(double amt, bool fromOverheal) {
        currentHealth -= amt;

        if (fromOverheal && currentHealth <= maxHealth) {
            currentHealth = maxHealth;
            isOverhealed = false;
        }
    }

    void heal(double amt, bool fromTime) {
        currentHealth += amt;
        
        if (fromTime && currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }
}
