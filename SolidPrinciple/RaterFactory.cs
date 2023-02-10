namespace SolidPrinciple
{
    public class RaterFactory
    {
        public Rater Create(Policy policy,  IRatingContext context) {
            try
            {
                return (Rater)Activator.CreateInstance(Type.GetType($"SolidPrinciple.{policy.Type}PolicyRater"), new object[] { new RatingUpdater(context.Engine) });
            }
            catch (Exception)
            {
                return new UnknownPolicyRater(new RatingUpdater(context.Engine)); 
            }
        }
    }
}
