using System;

namespace DesignPatterns.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Instance.Log("Hello World", ConsoleColor.Green);

            Test.Init();

            SoundService soundService = new SoundService();

            soundService.PlaySound("Foo Fighters");
        }
    }

    class Test
    {
        public static void Init()
        {
            Logger.Instance.Log("Hello from another world", ConsoleColor.Red);
        }
    }

    public class SoundService
    {
        public void PlaySound(string sound)
        {
            // lógica para tocar o som       
            
            Logger.Instance.Log("Som iniciado" + sound);
        }
    }
}