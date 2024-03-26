namespace Interface
{
    public interface IController
    {
        public void SetData(IModel characterModel, IView characterView,
            CharacterEvent characterEvent);
        public void Initialize();
        public void Handle();
        public void Move();
        public void Attack();

        public void DetectTarget();
    }
}