namespace CSharpGround
{
    public abstract class Feature
    {
        public abstract int Id { get; }
        public abstract string Name { get; }
        public abstract void Show();
    }
}
