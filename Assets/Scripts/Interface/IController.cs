namespace Interface
{
    public interface IController
    {
        public void SetData(IModel characterModel, IView characterView,
            CharacterEvent characterEvent, IAttack characterAttack);
        public void Initialize();
        public void Handle();
        public void Move();
        public void Attack();
        public void DetectTarget();
        public CharacterView GetCharacterView();
        public CharacterModel GetCharacterModel();
    }
}