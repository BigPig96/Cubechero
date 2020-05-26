namespace Cubechero.Interfaces
{
    public interface IController<in T>
    {
        void Control(T input);
    }

    public interface IController
    {
        void Control();
    }
}