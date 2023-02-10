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
        public IRatingContext Context { get; set; } = new DefaultRatingContext();
        public RatingEngine() { 
            Context.Engine= this;
        }   
        public decimal Rating { get; set; }

        public void Rate()
        {

            Context.Log("Starting rate.");
            Context.Log("Loading policy.");
            string policyJson = Context.LoadPolicyFromFile();
            var policy = Context.GetPolicyFromJsonString(policyJson);
            var rater = Context.CreateRaterForPolicy(policy, Context);
            rater.Rate(policy);
            Context.Log("Rating completed..");
        }

    }
}
