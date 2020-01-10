using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterBehaviour 
{
    float AttackRange { get; }
    bool CanAttack { get; }
    IAP_Stats Stats { get;  }
}
