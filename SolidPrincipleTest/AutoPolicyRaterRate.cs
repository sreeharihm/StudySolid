﻿using SolidPrinciple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincipleTest
{
    public class AutoPolicyRaterRate
    {
        [Fact]
        public void LogsMakeRequiredMessageGivenPolicyWithoutMake()
        {
            var policy = new Policy() { Type = PolicyType.Auto };
            var logger = new FakeLogger();
            var rater = new AutoPolicyRater(null);
            rater.Logger = logger;

            rater.Rate(policy);

            Assert.Equal("Auto policy must specify Make", logger.LoggedMessages.Last());
        }

        [Fact]
        public void SetsRatingTo1000ForBMWWith250Deductible()
        {
            var policy = new Policy()
            {
                Type = PolicyType.Auto,
                Make = "BMW",
                Deductible = 250m
            };
            var ratingUpdater = new FakeRatingUpdater();
            var rater = new AutoPolicyRater(ratingUpdater);

            rater.Rate(policy);

            Assert.Equal(1000m, ratingUpdater.NewRating.Value);
        }

        [Fact]
        public void SetsRatingTo900ForBMWWith500Deductible()
        {
            var policy = new Policy()
            {
                Type = PolicyType.Auto,
                Make = "BMW",
                Deductible = 500m
            };
            var ratingUpdater = new FakeRatingUpdater();
            var rater = new AutoPolicyRater(ratingUpdater);

            rater.Rate(policy);

            Assert.Equal(900m, ratingUpdater.NewRating.Value);
        }
    }
}
