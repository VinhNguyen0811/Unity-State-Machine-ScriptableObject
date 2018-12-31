using UnityEngine;

namespace VinhNguyen.AI
{
    /// <summary>
    /// Trạng thái cho máy nhà nước
    /// </summary>
    [CreateAssetMenu(fileName = "New State", menuName = "Vinh Nguyen/AI/Create New State")]
    public sealed class State : ScriptableObject
    {
        [Tooltip("Các hành động được gọi khi bắt đầu đi vào trạng thái này")]
        [SerializeField]
        private Action[] enterActions;

        [Tooltip("Các hành động được gọi khi cập nhật trạng thái này")]
        [SerializeField]
        private Action[] updateActions;

        [Tooltip("Các hành động được gọi khi thoát khỏi trạng thái này")]
        [SerializeField]
        private Action[] exitActions;

        [Tooltip("Các điều kiện để chuyển sang trạng thái khác")]
        [SerializeField]
        private Transition[] transitions;

        /// <summary>
        /// Được gọi bởi máy trạng thái khi bắt đầu trạng thái này
        /// </summary>
        /// <param name="stateMachine"></param>
        public void EnterState(BaseStateMachine stateMachine)
        {
            foreach (Action action in enterActions)
            {
                action.DoAction(stateMachine);
            }
        }

        /// <summary>
        /// Được gọi bởi máy trạng thái khi cập trạng thái này
        /// </summary>
        /// <param name="stateMachine"></param>
        public void UpdateState(BaseStateMachine stateMachine)
        {
            if (CheckTransitions(stateMachine))
                return;

            DoUpdateActions(stateMachine);
        }

        /// <summary>
        /// Được gọi bởi máy trạng thái khi thoát khỏi trạng thái này
        /// </summary>
        /// <param name="stateMachine"></param>
        public void ExitState(BaseStateMachine stateMachine)
        {
            foreach (Action action in exitActions)
            {
                action.DoAction(stateMachine);
            }
        }

        /// <summary>
        /// Thực hiện các hành động
        /// </summary>
        /// <param name="stateMachine"></param>
        private void DoUpdateActions(BaseStateMachine stateMachine)
        {
            foreach (Action action in updateActions)
            {
                action.DoAction(stateMachine);
            }
        }

        /// <summary>
        /// Kiểm tra các chuyển đổi
        /// </summary>
        /// <param name="stateMachine"></param>
        /// <returns></returns>
        private bool CheckTransitions(BaseStateMachine stateMachine)
        {
            foreach (Transition transition in transitions)
            {
                if (transition.DoTransition(stateMachine))
                    return true;
            }

            return false;
        }
    }
}