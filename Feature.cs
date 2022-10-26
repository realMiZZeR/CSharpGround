namespace CSharpGround
{
    public abstract class Feature
    {
        public abstract int Id { get; }
        public abstract string Name { get; }
        public virtual void Show()
        {
            System.Console.WriteLine("Main Menu - [x] (I think that it don't work for now :P)\n");
        }
    }
}
