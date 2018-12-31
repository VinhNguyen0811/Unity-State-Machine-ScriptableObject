using UnityEngine;

namespace VinhNguyen.AI
{
    [System.Serializable]
    public sealed class Transition
    {
        [SerializeField]
        private Condition condition;

        [SerializeField]
        private State state;

        public bool DoTransition(BaseStateMachine stateMachine)
        {
            bool result = condition.CheckCondition(stateMachine);
            if (result)
            {
                stateMachine.SetState(state);
            }

            return result;
        }
    }
}