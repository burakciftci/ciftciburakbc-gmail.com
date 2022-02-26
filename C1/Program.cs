using C1.Services.Action;
namespace C1
{
    class Program
    {
        static void Main(string[] args)
        {
            var _actionServices = new ActionService();
            _actionServices.Run();
        }
    }

}
