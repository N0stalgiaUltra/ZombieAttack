using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace WrongWay{
//    public class AbilityRunner : MonoBehaviour
//    {
//        enum Ability
//        {
//            Fireball, 
//            Rage, 
//            Heal, 
//            Melee
//        }

//        [SerializeField] private Ability m_Ability = Ability.Fireball;

//        // Update is called once per frame
//        void Update()
//        {
//            if (Input.GetMouseButtonDown(0))
//                UseAbility();
//        }

//        public void UseAbility()
//        {
//            switch(m_Ability)
//            {
//                case Ability.Fireball:
//                    print("Fireball");
//                    break;
//                case Ability.Rage:
//                    print("Rage");
//                    break;
//                case Ability.Heal:
//                    print("Heal");
//                    break;
//                case Ability.Melee:
//                    print("Melee");
//                    break;
//                default:
//                    print("no ability");
//                    break;
//            }
//        }
//    }
//}

namespace StrategyPattern
{
    public class AbilityRunner : MonoBehaviour
    {
        private BaseAbility m_currentAbility;
        //[SerializeField] private IAbillity m_currentAbility;

        public BaseAbility CurrentAbility
        {
            get => this.m_currentAbility;
            set => this.m_currentAbility = value;
        }
        // public IAbillity CurrentAbility
        //{
        //    get => this.m_currentAbility;
        //    set => this.m_currentAbility = value;
        //}

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                m_currentAbility.Use();
        }
    }
}