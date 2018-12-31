using UnityEngine;

namespace VinhNguyen.AI
{
    public abstract class Condition : ScriptableObject
    {
        public abstract bool CheckCondition(BaseStateMachine stateMachine);
    }
}