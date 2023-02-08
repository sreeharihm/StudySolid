using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolidPrinciple
{
    public class RatingEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();
        public decimal Rating { get; set; }

        public void Rate()
        {

            Logger.Log("Starting rate.");
            Logger.Log("Loading policy.");
            string policyJson = PolicySource.GetPolicyFromSource();
            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);
            var factory = new RaterFactory();
            var rater = factory.Create(policy, this);
            rater.Rate(policy);
            Logger.Log("Rating completed..");
        }

    }
}
