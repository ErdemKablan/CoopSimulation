using CoopSimulation.Collection;

namespace CoopSimulation.Data
{
    public interface ICoopService
    {
        void StartCoop();
        void getInstance();
        void LifeCyclePoultry(Coop _coop, int _months);
        void AddLifeCycle(Coop _coop);
        void Show(int _months, Coop _coop);
    }
}
