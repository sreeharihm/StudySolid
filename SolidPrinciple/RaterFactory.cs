namespace SolidPrinciple
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine) {
            try
            {
                return (Rater)Activator.CreateInstance(Type.GetType($"SolidPrinciple.{policy.Type}PolicyRater"), new object[] { engine, engine.Logger });
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
