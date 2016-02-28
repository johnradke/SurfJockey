namespace SurfJockey.RegistryManagement
{
    public interface IRegistryStep
    {
        void Do();
        void Undo();
    }
}
