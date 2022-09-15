using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPattern 
{
    [RequireComponent(typeof(AbilityRunner))]
    public class AbilityChanger : MonoBehaviour
    {
        [SerializeField] internal AbilityRunner abilityRunner;

        //[SerializeField] private List<IAbillity> Abilities;
        [SerializeField] private List<BaseAbility> Abilities;
        public int index;

        private void Awake()
        {
            GetComponent<AbilityRunner>();

            //Abilities.Add(new FireballAbility());
            //Abilities.Add(new HealAbility());
            //Abilities.Add(new MeleeAbility());
            //Abilities.Add(new RageAbility());
        }
        private void Start()
        {
            abilityRunner.CurrentAbility = Abilities[0];
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
                ChangeAbility();

        }

        private void ChangeAbility()
        {
            index++;
            index = index <= 3 ? index : 0;
            abilityRunner.CurrentAbility = Abilities[index];
        }
    }

}

