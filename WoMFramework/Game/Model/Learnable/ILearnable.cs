namespace WoMFramework.Game.Model
{
    public interface ILearnable
    {
        bool CanLearn(Entity entity);

        bool Learn(Entity entity);

        bool CanUnLearn(Entity entity);

        bool UnLearn(Entity entity);
    }
}
