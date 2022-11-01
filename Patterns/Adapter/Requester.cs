using System;

namespace CSharpGround.Patterns.Adapter
{
    public class Requester
    {
        public void SendRequest(string message)
        {
            Console.WriteLine("Sending something...");
        }
    }
}
