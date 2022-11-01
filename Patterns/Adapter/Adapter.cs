namespace CSharpGround.Patterns.Adapter
{
    /// Адаптер - структурный шаблон проектирования, предназначенный для
    /// организации использования функций объекта, недоступного для модификации,
    /// через специально созданный интерфейс
    public class Adapter : Requester, ISender
    {
        public void Send(string message)
        {
            base.SendRequest(message);
        }
    }
}
