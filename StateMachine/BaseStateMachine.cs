using UnityEngine;

namespace VinhNguyen.AI
{
    /// <summary>
    /// Máy nhà nước hữu hạn cơ bản
    /// </summary>
    [System.Serializable]
    public abstract class BaseStateMachine
    {
        [Tooltip("Trạng thái mặc định")]
        [SerializeField]
        protected State defaultState;

        /// <summary>
        /// Trạng thái hiện tại
        /// </summary>
        [System.NonSerialized]
        protected State currentState;

        /// <summary>
        /// Trạng thái hiện tại
        /// </summary>
        public State CurrentState
        {
            get
            {
                if (currentState == null)
                {
                    SetState(defaultState);
                }

                return currentState;
            }
        }

        /// <summary>
        /// Thiết lập trạng thái hiện tại
        /// </summary>
        /// <param name="state"></param>
        public void SetState(State state)
        {
            if (currentState == state)
                return;

            if (currentState != null)
            {
                currentState.ExitState(this);
            }

            currentState = state;

            if (currentState != null)
            {
                currentState.EnterState(this);
            }
        }

        /// <summary>
        /// Thiếp lập chủ nhân máy trạng thái
        /// </summary>
        /// <param name="owner"> Chủ nhân </param>
        public abstract void SetOwner(GameObject owner);

        /// <summary>
        /// Cập nhật máy nhà nước
        /// </summary>
        public virtual void UpdateStateMachine()
        {
            CurrentState.UpdateState(this);
        }
    }
}