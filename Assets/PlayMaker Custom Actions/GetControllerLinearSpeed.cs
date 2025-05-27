using UnityEngine;
 
namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Character)]
    [Tooltip("Gets the linear speed (magnitude of velocity) of a CharacterController.")]
    public class GetControllerLinearSpeed : ComponentAction<CharacterController>
    {
        [RequiredField]
        [CheckForComponent(typeof(CharacterController))]
        [Tooltip("The GameObject with a CharacterController.")]
        public FsmOwnerDefault gameObject;
 
        [UIHint(UIHint.Variable)]
        [Tooltip("Store the linear speed (velocity magnitude) in a Float variable.")]
        public FsmFloat storeLinearSpeed;
 
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;
 
        private CharacterController controller
        {
            get { return cachedComponent; }
        }
 
        public override void Reset()
        {
            gameObject = null;
            storeLinearSpeed = null;
            everyFrame = false;
        }
 
        public override void OnEnter()
        {
            DoGetLinearSpeed();
 
            if (!everyFrame)
            {
                Finish();
            }
        }
 
        public override void OnUpdate()
        {
            DoGetLinearSpeed();
        }
 
        private void DoGetLinearSpeed()
        {
            if (!UpdateCache(Fsm.GetOwnerDefaultTarget(gameObject)))
                return;
 
            var velocity = controller.velocity;
            storeLinearSpeed.Value = velocity.magnitude;
        }
    }
}