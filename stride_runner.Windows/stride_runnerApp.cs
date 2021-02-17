using Stride.Engine;

namespace Source
{
    class stride_runnerApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
