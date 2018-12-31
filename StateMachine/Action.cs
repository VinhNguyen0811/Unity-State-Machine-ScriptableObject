using UnityEngine;

namespace VinhNguyen.AI
{
    public abstract class Action : ScriptableObject
    {
        public abstract void DoAction(BaseStateMachine stateMachine);
    }
}