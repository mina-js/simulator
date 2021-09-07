using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulate : MonoBehaviour
{
    public int beingType; //1 = Plant, 2 = Herbivore
    public int HP; //Health points, when reduced to 0, counts as death
    public bool isDead = false;
    public int energy;
    public int strength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        transform.position = new Vector3(transform.position.x, -10, transform.position.z); //For now, register death by going under the ground
        //TODO: remove from game so it doesnt keep appearing and moving
        isDead = true;
    }

    //TODO: these will become more nuanced
    void HerbivoreConsumePlant(Simulate other)
    {
        other.HP = 0;
        energy += 1;
    }


    void CarnivoreConsumeHerbivore(Simulate other)
    {
        other.HP = 0;
        energy += 1;
    }

    //TODO: this will  be called by both, how do we prevent or account for this?
    void CarnivoreFightsCarnivore(Simulate other)
    {
        if (other.strength > strength)
        {
            HP -= 2;
            other.energy += 1;
        } else
        {
            energy += 1;
        }
    }

    public void Interact(Simulate other)
    {
        Debug.Log("Type: " + beingType + " going to interact with " + other.beingType);

        if(beingType == 2)
        {
            if(other.beingType == 1)
            {
                HerbivoreConsumePlant(other);
            }
        } else if(beingType == 3)
        {
            if(other.beingType == 2)
            {
                CarnivoreConsumeHerbivore(other);
            } else if(other.beingType == 3)
            {
                CarnivoreFightsCarnivore(other);
            }
        }
    }

    
}
